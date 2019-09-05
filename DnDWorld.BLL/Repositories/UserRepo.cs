using DnDWorld.BLL.Utility;
using DnDWorld.DAL;
using System;
using System.Linq;

namespace DnDWorld.BLL.Repositories
{
    public class UserRepo
    {
        private static DnDWorldDBEntities db = DBTools.DBInstance;
        public bool CheckUser(int id) => db.Users.Any(u => u.UserID == id);
        public bool CheckUser(string email) => db.Users.Any(u => u.Email == email);
        public User GetUser(int id)
        {
            User user = null;
            if (CheckUser(id)) user = db.Users.Find(id);
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
                if (CheckUser(newUser.Email))
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
                p.PermissionTypeID >= permissionTypeID &&
                p.ContentTypeID == contentTypeID &&
                p.ContentID == contentID &&
                p.GrantedUserID == userID
            );
        }

        public bool DeleteUser(int id, out string islemSonucu)
        {
            bool sonuc = false;
            if (CheckUser(id))
            {
                User user = GetUser(id);
                user.IsDeleted = true;
                try
                {
                    sonuc = db.SaveChanges() > 0;
                    if (sonuc) islemSonucu = "Silme işlemi başarılı.";
                    else islemSonucu = "Bir hata oluştu.";
                }
                catch (Exception ex)
                {
                    islemSonucu = ex.Message;
                }
            }
            else islemSonucu = "Silinmek istenen kullancı bulunamadı.";
            return sonuc;
        }
        public bool UpdateUser(User user, out string islemSonucu)
        {
            bool sonuc = false;
            if (user != null && user.Fullname.IsUsable())
            {
                if (CheckUser(user.UserID))
                {
                    user.UpdateDate = DateTime.Now;
                    db.Entry(GetUser(user.UserID)).CurrentValues.SetValues(user);
                    if (db.SaveChanges() > 0) islemSonucu = "Güncelleme başarılı";
                    else islemSonucu = "Bir hata oluştu";
                }
                else islemSonucu = "Kullanıcı Bulunamadı.";
            }
            else islemSonucu = "Kullanıcı nesnesi boş olamaz";
            return sonuc;
        }
    }
}
