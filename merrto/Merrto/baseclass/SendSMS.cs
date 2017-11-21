using System;
using System.Text;
using System.Net;
using System.IO;
using System.Data;

namespace Merrto.baseclass
{
    public class SendSMS
    {
        public string GETGetNO(string http)//GET 方式
        {
            //GET 方式
            String getReturn = doGetRequest(http);
            return "短息条数:"+getReturn.Substring(5, getReturn.Length-5);

        }
        public void GETGetDate(string http,string data)//POST
        {
            string strContent = "迈途";
            //GET 方式
            String getReturn = doGetRequest(http + data);
            Console.WriteLine("Get response is: " + getReturn);
            StringBuilder sbTemp = new StringBuilder();

        }
        //POST方式发送得结果
        public void GETpost(string user,string ip,string Data)//POST
        {
            string strContent = "";
            StringBuilder sbTemp = new StringBuilder();
            sbTemp.Append(user + Data);
            byte[] bTemp = Encoding.UTF8.GetBytes(sbTemp.ToString());
            String postReturn = doPostRequest(ip, bTemp);
            Console.WriteLine("Post response is: " + postReturn);
        }
        //POST方式发送得结果
        private static String doPostRequest(string url, byte[] bData)
        {
            System.Net.HttpWebRequest hwRequest;
            System.Net.HttpWebResponse hwResponse;

            string strResult = string.Empty;
            try
            {
                hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                hwRequest.Timeout = 5000;
                hwRequest.Method = "POST";
                hwRequest.ContentType = "application/x-www-form-urlencoded";
                hwRequest.ContentLength = bData.Length;

                System.IO.Stream smWrite = hwRequest.GetRequestStream();
                smWrite.Write(bData, 0, bData.Length);
                smWrite.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
                return strResult;
            }

            //get response
            try
            {
                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
            }

            return strResult;
        }
        //GET方式发送得结果
        private static String doGetRequest(string url)
        {
            HttpWebRequest hwRequest;
            HttpWebResponse hwResponse;

            string strResult = string.Empty;
            try
            {
                hwRequest = (System.Net.HttpWebRequest)WebRequest.Create(url);
                hwRequest.Timeout = 5000;
                hwRequest.Method = "GET";
                hwRequest.ContentType = "application/x-www-form-urlencoded";
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
                return strResult;
            }

            //get response
            try
            {
                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
            }

            return strResult;
        }

        private static void WriteErrLog(string strErr)
        {
            Console.WriteLine(strErr);
            System.Diagnostics.Trace.WriteLine(strErr);
        }
    }
}
