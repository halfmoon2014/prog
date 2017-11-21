<%@ WebService Language="C#" Class="index" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]
public class index  : System.Web.Services.WebService {


    [WebMethod(EnableSession = true)]
    public void getIndex()
    {
        // serverlet url 
        Uri servletURL = new Uri("http://192.168.1.204:8081/myapp/sgetindex");
        System.Net.WebClient client = new System.Net.WebClient();
        client.Headers.Add("Content-type", "application/x-www-form-urlencoded");
        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        String r = "";
        if (SessionHandle.Session.Get("usr") == null)
        {
            r = "{\"err\":\"session_error\"}";
        }
        else
        {
            Byte[] postData = encoding.GetBytes("username=" + HttpUtility.UrlEncode(SessionHandle.Session.Get("usr").ToString().Trim(), encoding));
            // 获取返回值 
            byte[] returnData = client.UploadData(servletURL.ToString(), "POST", postData);
            r = encoding.GetString(returnData);

            //转为C#对象
            MemoryStream stream = new MemoryStream();

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<ModelHandle.IndexModel>));
            StreamWriter wr = new StreamWriter(stream);
            wr.Write(r);
            wr.Flush();
            stream.Position = 0;
            Object obj = ser.ReadObject(stream);
            List<ModelHandle.IndexModel> loginModel = (List<ModelHandle.IndexModel>)obj;
        }
        HttpContext.Current.Response.Write(r);
        HttpContext.Current.Response.End();
    }
}