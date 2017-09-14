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
    [MetadataType(typeof(SliderMetaData))]
    public partial class Slider
    {
        internal sealed class SliderMetaData
        {
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Tên Hình")]
            public string image_Name { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Mô Tả Hình")]
            public string image_Description { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Hình")]
            public string image_Path { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Trạng Thái")]
            public Nullable<int> active { get; set; }
        }
    }
}