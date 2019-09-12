using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDWorld.BLL.Utility;
using DnDWorld.DAL;

namespace DnDWorld.BLL.Repositories
{
    public class RaceRepo
    {
        DNDWDBEntities db = DBTools.DBInstance;

        public List<Race> GetRaces()
        {
            return db.Races.ToList();
        }

        public List<Subrace> GetSubraces(int raceID = 0)
        {
            return db.Subraces.Where(s => s.RaceID == raceID).ToList();
        }
    }
}
