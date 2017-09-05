using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.MetaData
{
    public class AccountMeta
    {
        public int ID { get; set; }
        [Display(Name = "Tài Khoản")]
        public string accountName { get; set; }
        [Display(Name = "Mật Khẩu")]
        public string password { get; set; }
        [Display(Name = "Tên Tài Khoản")]
        public string fullName { get; set; }
        [Display(Name = "Hình")]
        public string imagePath { get; set; }
        [Display(Name = "Ngày Sinh")]

        public Nullable<System.DateTime> birthDay { get; set; }
        [Display(Name = "Số Điện Thoại")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string address { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        [Display(Name = "Nhóm ")]
        public Nullable<int> accountGroupID { get; set; }
        [Display(Name = "Trạng Thái")]
        public Nullable<bool> active { get; set; }
    }

    [MetadataType(typeof(AccountMeta))]
    public partial class Account
    {

    }
}

