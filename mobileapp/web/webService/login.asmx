<%@ WebService Language="C#" Class="login" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using SessionHandle;
using ModelHandle;
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
 [System.Web.Script.Services.ScriptService]
public class login : System.Web.Services.WebService
{

    [WebMethod(EnableSession = true)]
    public void getLogin(string usr,string psw)
    {
        // serverlet url 
        Uri servletURL = new Uri("http://192.168.1.204:8081/myapp/slogin");
        System.Net.WebClient client = new System.Net.WebClient();
        client.Headers.Add("Content-type", "application/x-www-form-urlencoded");
        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        Byte[] postData = encoding.GetBytes("usr=" + HttpUtility.UrlEncode(usr, encoding) + "&psw=" + HttpUtility.UrlEncode(psw, encoding));
        // 获取返回值 
        byte[] returnData = client.UploadData(servletURL.ToString(), "POST", postData);        
        string r = encoding.GetString(returnData);

        //转为C#对象
        MemoryStream stream = new MemoryStream();
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ModelHandle.LoginModel));
        StreamWriter wr = new StreamWriter(stream);
        wr.Write(r);   
        wr.Flush();
        stream.Position = 0;
        Object obj = ser.ReadObject(stream);
        ModelHandle.LoginModel loginModel = (ModelHandle.LoginModel)obj;
        if (loginModel.isSuccess == "T")
        {//登陆成功
            SessionHandle.BusinessSession.UserAdd(usr);            
        }        
        
        HttpContext.Current.Response.Write(r);
        HttpContext.Current.Response.End();
    }     

    [WebMethod(EnableSession = true)]
    public void uploadImgCode()
    {
        string img;//接收经过base64编 之后的字符串    
        HttpContext.Current.Response.ContentType = "text/plain";
        try
        {
            img = HttpContext.Current.Request["img"].ToString();
            //获取base64字符串          
            byte[] imgBytes = Convert.FromBase64String(img);
            //将base64字符串转换为字节数组            
            System.IO.Stream stream = new System.IO.MemoryStream(imgBytes);
            //将字节数组转换为字节流      
            //将流转回Image，用于将PNG 式照片转为jpg，压缩体积以便保存。         
            System.Drawing.Image imgae = System.Drawing.Image.FromStream(stream);
            imgae.Save(HttpContext.Current.Server.MapPath("~/Test/") + Guid.NewGuid().ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);//保存图片             
            HttpContext.Current.Response.Write("OK");//输出调用结果                
        }
        catch (Exception msg)
        {
            img = null;
            HttpContext.Current.Response.Write(msg);
            return;
        }
    }




}