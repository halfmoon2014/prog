using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace SessionHandle
{
    public class BusinessSession
    {
        /// <summary>
        /// 用户session
        /// </summary>
        /// <param name="usr">登陆名</param>
        public static void UserAdd(string usr)
        {
            SessionHandle.Session.Add("usr", usr);
        }
         
    }
}
