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
    
    public partial class AccountGroup
    {
        public AccountGroup()
        {
            this.GroupPaths = new HashSet<GroupPath>();
        }
    
        public int ID { get; set; }
        public Nullable<int> groupPathID { get; set; }
        public Nullable<int> accountID { get; set; }
        public Nullable<int> active { get; set; }
        public string description { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual ICollection<GroupPath> GroupPaths { get; set; }
    }
}
