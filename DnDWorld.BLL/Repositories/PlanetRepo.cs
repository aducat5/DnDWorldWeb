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
        DNDWDBEntities db = DBTools.DBInstance;
        public bool DoesPlanetExists(int universeID, string planetName)
        {
            planetName = planetName.ClearText();
            return db.Planets.Any(p => p.UniverseID == universeID && p.Fullname == planetName);
        }
        public bool DoesPlanetExists(int planetID) => db.Planets.Any(p => p.PlanetID == planetID);

        public bool InsertPlanet(Planet newPlanet, out string islemSonucu)
        {
            newPlanet.Fullname = newPlanet.Fullname.ClearText();
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

        public Planet GetPlanet(int planetID)
        {
            if (DoesPlanetExists(planetID)) return db.Planets.Find(planetID);
            else return null;
        }

        public List<Planet> GetPlanets(int userID)
        {
            List<Planet> planetsOfUser = db.Planets.Where(p => p.OwnerID == userID).ToList();
            if (planetsOfUser.Count > 0) return planetsOfUser;
            else return null;
        }

        public List<Planet> GetPlanets(int userID, PermissionTypes permissionType)
        {
            List<Planet> planets = db.Planets.ToList();
            foreach (Planet planet in planets)
            {
                if (planet.IsPublic == false && planet.OwnerID != userID && !UserRepo.IsUserAllowed(userID, planet.PlanetID, permissionType, ContentTypes.Planet))
                {
                    planets.Remove(planet);
                }
            }
            return planets;
        }

        public List<Planet> GetPlanets(int userID, int universeID, PermissionTypes permissionType)
        {
            List<Planet> planetsOfUniverse = db.Planets.Where(p => p.UniverseID == universeID).ToList();
            if (planetsOfUniverse.Count > 0)
            {
                List<Planet> granteds = new List<Planet>();
                foreach (Planet planet in planetsOfUniverse)
                {
                    if (planet.IsPublic || planet.OwnerID == userID || UserRepo.IsUserAllowed(userID, universeID, permissionType, ContentTypes.Planet))
                    {
                        granteds.Add(planet);
                    }
                }
                return granteds;
            }
            else
            {
                return null;
            }
        }

    }
}
