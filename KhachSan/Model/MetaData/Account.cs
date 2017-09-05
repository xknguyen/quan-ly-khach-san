//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.MetaData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.AccountGroups = new HashSet<AccountGroup>();
            this.Blogs = new HashSet<Blog>();
        }
    
        public int ID { get; set; }
        public string accountName { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string imagePath { get; set; }
        public Nullable<System.DateTime> birthDay { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public Nullable<int> accountGroupID { get; set; }
        public Nullable<bool> active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountGroup> AccountGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
