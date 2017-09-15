using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace KhachSan.Models
{
    public class CheckPermision:Controller
    {
        KhachSanEntities db = new KhachSanEntities();
        public static  int Check( Account account)
        {
            
            if (account != null)
            {
                try
                {
                    //là admin
                    if (account.isadmin == true)
                    {
                        return 1;
                    }
                    //là nhân viên
                    else if (account.accountGroupID == 2)
                    {

                        return 2;

                    }
                    //là khách hàng
                    else
                    {
                        return 3;
                    }
                }
                catch (Exception)
                {
                    //là khách hàng
                    return 3;
                }


            }
            //chua đăng nhập
            else
                return 4;

           
        }
    }
}