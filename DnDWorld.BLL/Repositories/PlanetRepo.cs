using DnDWorld.BLL.Utility;
using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDWorld.BLL.Repositories
{
    public class PlanetRepo
    {
        DnDWorldDBEntities db = DBTools.DBInstance;
        public bool DoesPlanetExists(int universeID, string planetName)
        {
            planetName = GenFunx.ClearText(planetName);
            return db.Planets.Any(p => p.UniverseID == universeID && p.Fullname == planetName);
        }

        public bool InsertPlanet(Planet newPlanet, out string islemSonucu)
        {
            newPlanet.Fullname = GenFunx.ClearText(newPlanet.Fullname);
            if (!DoesPlanetExists(newPlanet.UniverseID, newPlanet.Fullname))
            {
                db.Planets.Add(newPlanet);
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
    }
}
