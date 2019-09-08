using DnDWorld.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnDWorld.BLL.Utility
{
    public class DBTools
    {
        private static DNDWDBEntities _dBInstance;

        public static DNDWDBEntities DBInstance
        {
            get
            {
                if (_dBInstance == null) _dBInstance = new DNDWDBEntities();
                return _dBInstance;
            }
        }
    }
}