<%@ WebService Language="C#" Class="reportforfabric" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using SessionHandle;
using ModelHandle;
using System.Collections.Generic;
 
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class reportforfabric : System.Web.Services.WebService
{

    [WebMethod(EnableSession = true)]
    public void GetReport(int reportnumber,String supplier,String materialcode)
    {
        // serverlet url 
        Uri servletURL = new Uri("http://192.168.1.204:8081/myapp/sgetreportforfabric");
        System.Net.WebClient client = new System.Net.WebClient();
        client.Headers.Add("Content-type", "application/x-www-form-urlencoded");
        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        string r = "";
        if (SessionHandle.Session.Get("usr") == null)
        {
            r = "{\"err\":\"session_error\"}";
        }
        else
        {

            Byte[] postData = encoding.GetBytes("username=" + HttpUtility.UrlEncode(SessionHandle.Session.Get("usr").ToString().Trim(), encoding)
                + "&reportnumber=" + reportnumber
                + "&reportdate=&materialcode=" + HttpUtility.UrlEncode(materialcode, encoding)
                + "&materialdesignation=&supplier=" + HttpUtility.UrlEncode(supplier, encoding) 
                + "&pagenumber=1&pagesize=1");
            // 获取返回值 
            byte[] returnData = client.UploadData(servletURL.ToString(), "POST", postData);
            r = encoding.GetString(returnData);

            //转为C#对象
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<ModelHandle.ReportForFabricModel>));
            StreamWriter wr = new StreamWriter(stream);
            wr.Write(r);
            wr.Flush();
            stream.Position = 0;
            Object obj = ser.ReadObject(stream);
            List<ModelHandle.ReportForFabricModel> loginModel = (List<ModelHandle.ReportForFabricModel>)obj;

        }
        HttpContext.Current.Response.Write(r);
        HttpContext.Current.Response.End();
    }
    [WebMethod(EnableSession = true)]
    public void GetReportDetail(int mykey)
    {
        // serverlet url 
        Uri servletURL = new Uri("http://192.168.1.204:8081/myapp/sgetreportforfabricdetail");
        System.Net.WebClient client = new System.Net.WebClient();
        client.Headers.Add("Content-type", "application/x-www-form-urlencoded");
        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        string r = "";
        if (SessionHandle.Session.Get("usr") == null)
        {
            r = "{\"err\":\"session_error\"}";
        }
        else
        {

            Byte[] postData = encoding.GetBytes("mykey=" + mykey);            
            // 获取返回值 
            byte[] returnData = client.UploadData(servletURL.ToString(), "POST", postData);
            r = encoding.GetString(returnData);

            //转为C#对象
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ModelHandle.ReportForFabricModel));
            StreamWriter wr = new StreamWriter(stream);
            wr.Write(r);
            wr.Flush();
            stream.Position = 0;
            Object obj = ser.ReadObject(stream);
            ModelHandle.ReportForFabricModel loginModel = (ModelHandle.ReportForFabricModel)obj;

        }
        HttpContext.Current.Response.Write(r);
        HttpContext.Current.Response.End();
    }
        [WebMethod(EnableSession = true)]
    public void GetReportTransact(int mykey)
    {
        // serverlet url 
        Uri servletURL = new Uri("http://192.168.1.204:8081/myapp/sgetreportforfabrictransact");
        System.Net.WebClient client = new System.Net.WebClient();
        client.Headers.Add("Content-type", "application/x-www-form-urlencoded");
        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        string r = "";
        if (SessionHandle.Session.Get("usr") == null)
        {
            r = "{\"err\":\"session_error\"}";
        }
        else
        {

            Byte[] postData = encoding.GetBytes("mykey=" + mykey);            
            // 获取返回值 
            byte[] returnData = client.UploadData(servletURL.ToString(), "POST", postData);
            r = encoding.GetString(returnData);
            //ModelHandle.ReportForFabricTransactModel infoList = Newtonsoft.Json.JsonConvert.DeserializeObject<ModelHandle.ReportForFabricTransactModel>(r.Replace("\\", ""));
            
            //转为C#对象
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ModelHandle.ReportForFabricTransactModel));
            StreamWriter wr = new StreamWriter(stream);
            wr.Write(r);
            wr.Flush();
            stream.Position = 0;
            Object obj = ser.ReadObject(stream);
            ModelHandle.ReportForFabricTransactModel info = (ModelHandle.ReportForFabricTransactModel)obj;

            //post
            MemoryStream streamPost = new MemoryStream();
            DataContractJsonSerializer serPost = new DataContractJsonSerializer(typeof(List<ModelHandle.ReportForFabricTransactPostModel>));
            StreamWriter wrPost = new StreamWriter(streamPost);
            wrPost.Write(info.info0);
            wrPost.Flush();
            streamPost.Position = 0;
            Object objPost = serPost.ReadObject(streamPost);
            List<ModelHandle.ReportForFabricTransactPostModel> pos = (List<ModelHandle.ReportForFabricTransactPostModel>)objPost;
            //user
            MemoryStream streamPostUser = new MemoryStream();
            DataContractJsonSerializer serPostUser = new DataContractJsonSerializer(typeof(List<ModelHandle.ReportForFabricTransactPostUserModel>));
            StreamWriter wrPostUser = new StreamWriter(streamPostUser);
            wrPostUser.Write(info.info1);
            wrPostUser.Flush();
            streamPostUser.Position = 0;
            Object objPostUser = serPostUser.ReadObject(streamPostUser);
            List<ModelHandle.ReportForFabricTransactPostUserModel> posUser = (List<ModelHandle.ReportForFabricTransactPostUserModel>)objPostUser;

        }
        HttpContext.Current.Response.Write(r);
        HttpContext.Current.Response.End();
    }
    

}