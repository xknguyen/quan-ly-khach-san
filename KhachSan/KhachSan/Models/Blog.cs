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
    
    public partial class Blog
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<int> accountID { get; set; }
        public string shortDescription { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    }
}
