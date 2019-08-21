using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnDWorld.BLL.Utility
{
    public class DBTools
    {
        private static DnDWorldDBEntities _dBInstance;

        public static DnDWorldDBEntities DBInstance
        {
            get
            {
                if (_dBInstance == null) _dBInstance = new DnDWorldDBEntities();
                return _dBInstance;
            }
        }
    }
}