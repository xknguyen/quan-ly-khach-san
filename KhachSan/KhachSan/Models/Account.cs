//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KhachSan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public int ID { get; set; }
        public string accountName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string displayname { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> modified { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string avatar { get; set; }
        public bool isadmin { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public Nullable<int> accountGroupID { get; set; }
        public string IPLast { get; set; }
        public string IPCreated { get; set; }
    }
}
