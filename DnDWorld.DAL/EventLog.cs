//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DnDWorld.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventLog
    {
        public int LogID { get; set; }
        public int LogTypeID { get; set; }
        public string LogMessage { get; set; }
        public string Detail { get; set; }
        public string MachineName { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual LogType LogType { get; set; }
    }
}
