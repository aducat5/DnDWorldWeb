using DnDWorld.DAL;

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
