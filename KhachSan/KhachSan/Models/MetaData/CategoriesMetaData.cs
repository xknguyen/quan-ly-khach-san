using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Thu vien thiết kế metadat
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace KhachSan.Models
{
    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {
        internal sealed class CategoryMetaData
        {
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Tên Loại Phòng")]
            public string name { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Mô Tả")]
            public string description { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Hình")]
            public string image { get; set; }
        }
    }
}