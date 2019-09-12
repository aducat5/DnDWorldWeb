using DnDWorld.BLL.Utility;
using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDWorld.BLL.Repositories
{
    public class ClassRepo
    {
        DNDWDBEntities db = DBTools.DBInstance;

        public List<Class> GetClasses()
        {
            return db.Classes.ToList();
        }
    }
}
