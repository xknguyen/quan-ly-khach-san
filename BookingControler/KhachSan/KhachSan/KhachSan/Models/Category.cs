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
    
    public partial class Category
    {
        public Category()
        {
            this.Rooms = new HashSet<Room>();
        }
    
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
    
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
