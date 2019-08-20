using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDWorld.DAL;
using DnDWorld.Utility;

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
