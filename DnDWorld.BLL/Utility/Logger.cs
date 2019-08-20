using DnDWorld.DAL;
using DnDWorld.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDWorld.BLL.Utility
{
    public class Logger
    {
        private static DnDWorldDBEntities db = DBTools.DBInstance;
        public static void Log(EventLog log)
        {
            db.EventLogs.Add(log);
            db.SaveChanges();
        }
    }
}
