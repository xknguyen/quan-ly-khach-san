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
    
    public partial class Customer
    {
        public Customer()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int ID { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
