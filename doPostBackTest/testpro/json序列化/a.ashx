<%@ WebHandler Language="C#" Class="a" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
public class a : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
        //JavaScriptSerializer Serializer = new JavaScriptSerializer();
        //Root objs = Serializer.Deserialize<Root>(context.Request.Form[0]);
        //Root root = JsonConvert.DeserializeObject<Root>(context.Request.Form[0]);        
        //string a = root.R[0].Chdm;
        Root root = JsonConvert.DeserializeObject<Root>(context.Request.Form[0]);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
public class R
{
    private string chdm;
    public string Chdm { get { return chdm; } set { chdm = value; } }
    private int t;
    public int T { get { return t; } set { t = value; } }
    private int row;
    public int Row { get { return row; } set { row = value; } }
    private int col;
    public int Col { get { return col; } set { col = value; } }




}
public class Root
{
    private string mytype;
    public string Mytype { get { return mytype; } set { mytype = value; } }
    private int pageno;
    public int Pageno { get { return pageno; } set { pageno = value; } }
    private List<R> r;
    public List<R> R { get { return r; } set { r = value; } }

}
//public class Raaa
//{
//    private string chdm;
//    public string Chdm { get { return chdm; } set { chdm = value; } }
//    private int row;
//    public int Row { get { return row; } set { row = value; } }
    
//}
//public class Root
//{
//    private List<Raaa> r;
//    public List<Raaa> R { get { return r; } set { r = value; } }
//    private string mytype;
//    public string Mytype { get { return mytype; } set { mytype = value; } }
//    private string chdm;
//    public string Chdm { get { return chdm; } set { chdm = value; } }
//}