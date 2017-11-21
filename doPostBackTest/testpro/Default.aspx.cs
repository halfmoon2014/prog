using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using m1;
namespace testpro
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string  r="";
            //m1.Swallow c2 = new m1.Swallow();
            //r+=c2.fly();
            //r+=c2.eat();
            //m1.Penguin2 c3 = new m1.Penguin2();
            //r+=c3.eat();
            //test1.InnerHtml = r;
           
            

            m1.Bird b;
            b = new m1.flyinchina();
            test1.InnerHtml= b.Fly();
            m1.Bird b2;
            b2 = new m1.flyinus();
            test2.InnerHtml= b2.Fly();


            // 主程序，代码层次实现注入并调用
 
            //m1.ITvProvider tvProvider = new m1.KonkaTv();
            //m1.WatchTvControl watchTvControl = new m1.WatchTvControl();
            //watchTvControl.InjectTv(tvProvider);

            Singleton s1 = Singleton.init();
            s1.i = "12";
            Singleton s2 = Singleton.init();
            s2.i = "22";
            if (s1 == s2)
            {
                test2.InnerHtml = s1.i;
            }
            else
            {
                test2.InnerHtml = "2";
            }
 
        }
    }
}
