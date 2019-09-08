using DnDWorld.BLL.Utility;
using DnDWorld.DAL;
using System.Collections.Generic;
using System.Linq;

namespace DnDWorld.BLL.Repositories
{
    public class UniverseRepo
    {
        DNDWDBEntities db = DBTools.DBInstance;
        public bool DoesUniverseExists(string universeName)
        {
            universeName = universeName.ClearText();
            return db.Universes.Any(u => u.Fullname == universeName);
        }

        public bool DoesUniverseExists(int universeID) => db.Universes.Any(u => u.UniverseID == universeID);

        public bool InsertUniverse(Universe newUniverse, out string islemSonucu)
        {
            newUniverse.Fullname = newUniverse.Fullname.ClearText();
            if (!DoesUniverseExists(newUniverse.Fullname))
            {
                db.Universes.Add(newUniverse);
                if (db.SaveChanges() > 0)
                {
                    islemSonucu = "Başarılı";
                    return true;
                }
                else
                {
                    islemSonucu = "Bir hata oluştu";
                    return false;
                }
            }
            else
            {
                islemSonucu = "Bu isim kullanılmakta";
                return false;
            }
        }

        /// <summary>
        /// Gets universes created by specified user.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Universe> GetUniverses(int userID)
        {
            List<Universe> universesOfUser = db.Universes.Where(u => u.OwnerID == userID).ToList();
            if (universesOfUser.Count > 0) return universesOfUser;
            else return null;
        }

        /// <summary>
        /// Gets All Universes
        /// </summary>
        /// <returns></returns>
        public List<Universe> GetUniverses()
        {
            return db.Universes.ToList();
        }

        /// <summary>
        /// Gets universes of specified user that has specified permission
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="permissionType"></param>
        /// <returns></returns>
        public List<Universe> GetUniverses(int userID, PermissionTypes permissionType)
        {
            List<Universe> allUniverses = GetUniverses();
            List<Universe> grantedUniverses = new List<Universe>();

            foreach (Universe universe in allUniverses)
            {
                if (universe.IsPublic == true || universe.OwnerID == userID || UserRepo.IsUserAllowed(userID, universe.UniverseID, permissionType, ContentTypes.Universe))
                {
                    grantedUniverses.Add(universe);
                }
            }

            return grantedUniverses;
        }

        public List<Universe> GetUniverses(bool isPublic)
        {
            return db.Universes.Where(u => u.IsPublic == isPublic).ToList();
        }


        public Universe GetUniverse(int universeID)
        {
            if (DoesUniverseExists(universeID)) return db.Universes.Find(universeID);
            else return null;
        }
    }
}
