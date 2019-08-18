using DnDWorld.DAL;
using DnDWorld.Utility;
using System;
using System.Linq;

namespace DnDWorld.BLL.Repositories
{
    public class UserRepo
    {
        private static DnDWorldDBEntities db = DBTools.DBInstance;
        public bool DoesUserExists(int id) => db.Users.Any(u => u.UserID == id);
        public bool DoesUserExists(string email) => db.Users.Any(u => u.Email == email);
        public User GetUser(int id)
        {
            User user = null;
            if (DoesUserExists(id)) user = db.Users.Find(id);
            return user;
        }
        public User GetUser(string email, string password)
        {
            if (db.Users.Any(u => u.Email == email && u.Password == password)) return db.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            else return null;
        }
        public bool InsertUser(User newUser, out string islemSonucu)
        {
            newUser.CreateDate = DateTime.Now;
            newUser.UpdateDate = newUser.CreateDate;
            try
            {
                if (DoesUserExists(newUser.Email))
                {
                    islemSonucu = "Bu email zaten kullanımda.";
                    return false;
                }
                else
                {
                    db.Users.Add(newUser);
                    if (db.SaveChanges() > 0)
                    {
                        islemSonucu = "Başarılı";
                        return true;
                    }
                    else
                    {
                        islemSonucu = "Kayıt sırasında bir hata oluştu.";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                islemSonucu = "Bilinmeyen bir hata oluştu" + ex.Message;
                return false;
            }
        }
        public static bool IsUserAllowed(int userID, int contentID, PermissionTypes permissionType, ContentTypes contentType)
        {
            int permissionTypeID = permissionType.ToInt();
            int contentTypeID = contentType.ToInt();

            return db.Permissions.Any(
                p =>
                p.PermissionTypeID == permissionTypeID &&
                p.ContentTypeID == contentTypeID &&
                p.ContentID == contentID &&
                p.GrantedUserID == userID
            );
        }
    }
}
