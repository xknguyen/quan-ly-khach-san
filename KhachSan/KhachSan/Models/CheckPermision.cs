using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI.WebControls;

namespace KhachSan.Models
{
    public class CheckPermision
    {
        public static int Check(string Permision)
        {
            string [] per = new string[3] { "/Admin/Sliders/", "/Admin/", "/Admin" };
            for (int i = 0; i < 3; i++)
            {
                if (per[i]==Permision)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}