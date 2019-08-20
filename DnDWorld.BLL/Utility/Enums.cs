using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnDWorld.Utility
{
    public enum PermissionTypes
    {
        Banned = 0,
        Read = 1,
        Write = 2,
        Extend = 3
    }

    public enum ContentTypes
    {
        Universe = 1,
        Planet = 2
    }

    public enum LogTypes
    {
        Error = 1,
        Info = 2,
        Debug = 3
    }
}