using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDWorld.Models;
using DnDWorld.Models.Database;

namespace DnDWorld.Utility
{
    public class DBTools
    {
        private static DnDWorldDBEntities _instance;

        public static DnDWorldDBEntities GetDB()
        {
            if (_instance == null)
            {
                _instance = new DnDWorldDBEntities();
            }

            return _instance;
        }
    }
}