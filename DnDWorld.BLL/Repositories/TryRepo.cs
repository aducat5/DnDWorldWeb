using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDWorld.BLL.Utility;
using DnDWorld.DAL;

namespace DnDWorld.BLL.Repositories
{
    public class TryRepo
    {
        DnDWorldDBEntities db = DBTools.DBInstance;
        public bool InsertData(string data)
        {
            db.AuthTypes.Add(new AuthType() { AuthTypeName = data });
            return db.SaveChanges() > 0;
        }
    }
}
