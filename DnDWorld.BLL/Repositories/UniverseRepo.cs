﻿using DnDWorld.DAL;
using DnDWorld.Utility;
using System.Collections.Generic;
using System.Linq;

namespace DnDWorld.BLL.Repositories
{
    public class UniverseRepo
    {
        DnDWorldDBEntities db = DBTools.DBInstance;
        public bool DoesUniverseExists(string universeName) => db.Universes.Any(u => u.Fullname == universeName);
        public bool DoesUniverseExists(int universeID) => db.Universes.Any(u => u.UniverseID == universeID);
        public bool InsertUniverse(Universe newUniverse, out string islemSonucu)
        {
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
        public List<Universe> GetUniversesByUser(int userID)
        {
            List<Universe> universesOfUser = db.Universes.Where(u => u.OwnerID == userID).ToList();
            if (universesOfUser.Count > 0) return universesOfUser;
            else return null;
        }
        public Universe GetUniverse(int universeID)
        {
            if (DoesUniverseExists(universeID)) return db.Universes.Find(universeID);
            else return null;
        }
    }
}