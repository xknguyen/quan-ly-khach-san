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
    [MetadataType(typeof(RoomMetaData))]
    //tên Rooms = voi ten trong model
    public partial class Room
    {

        //tên RoomMetaData =  [MetadataType(typeof(RoomsMetaData))]
        internal sealed class RoomMetaData
        {
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Tên Phòng")]
            public string roomName { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Mô tả phòng")]
           
            public string roomDescription { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Giá Phòng")]
            [DataType(DataType.Text)]
            public Nullable<double> roomPrice { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Loại Phòng")]
            public Nullable<int> categoryID { get; set; }
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]
            [Display(Name = "Số lượng phòng")]
            public Nullable<int> roomQuantily { get; set; }



        }
    }
}