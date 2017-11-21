using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;

namespace Merrto.baseclass
{
    class xmldataset
    {
        protected static DataSet GetDataSetByXml(string xmlData)
        {
            try
            {
                DataSet ds = new DataSet();

                using (StringReader xmlSR = new StringReader(xmlData))
                {

                    ds.ReadXml(xmlSR, XmlReadMode.InferTypedSchema); //忽视任何内联架构，从数据推断出强类型架构并加载数据。如果无法推断，则解释成字符串数据
                    if (ds.Tables.Count > 0)
                    {
                        return ds;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }


        private DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        /// 读取Xml文件信息,并转换成DataTable对象
        /// 
        /// xml文江路径 /// DataTable对象
        public DataTable CXmlToDataTable(string xmlFilePath)
        {
            return CXmlToDataSet(xmlFilePath).Tables[0];
        }
        /**/
        /// <summary>  
        /// 将Xml内容字符串转换成DataSet对象  
        /// </summary>  
        /// <param name="xmlStr">Xml内容字符串</param>  
        /// <returns>DataSet对象</returns>  
        public DataSet CXmlToDataSet(string xmlStr)
        {
            if (!string.IsNullOrEmpty(xmlStr))
            {

                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息  
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据  
                    Xmlrdr = new XmlTextReader(xmlStr);
                    //ds获取Xmlrdr中的数据                  
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源  
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                        StrStream.Dispose();
                    }
                }
            }
            else
            {
                return null;
            }
        }



        /**/
        ///// <summary>
        ///// 读取Xml文件信息,并转换成DataSet对象
        ///// </summary>
        ///// <remarks>
        ///// DataSet ds = new DataSet();
        ///// ds = CXmlFileToDataSet("/XML/upload.xml");
        ///// </remarks>
        ///// <param name="xmlFilePath">Xml文件地址</param>
        ///// <returns>DataSet对象</returns>
        //public static DataSet CXmlFileToDataSet(string xmlFilePath)
        //{
        //    if (!string.IsNullOrEmpty(xmlFilePath))
        //    {
        //        string path = HttpContext.Current.Server.MapPath(xmlFilePath);
        //        StringReader StrStream = null;
        //        XmlTextReader Xmlrdr = null;
        //        try
        //        {
        //            XmlDocument xmldoc = new XmlDocument();
        //            //根据地址加载Xml文件
        //            xmldoc.Load(path);
        //            DataSet ds = new DataSet();
        //            //读取文件中的字符流
        //            StrStream = new StringReader(xmldoc.InnerXml);
        //            //获取StrStream中的数据
        //            Xmlrdr = new XmlTextReader(StrStream);
        //            //ds获取Xmlrdr中的数据
        //            ds.ReadXml(Xmlrdr);
        //            return ds;
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            //释放资源
        //            if (Xmlrdr != null)
        //            {
        //                Xmlrdr.Close();
        //                StrStream.Close();
        //                StrStream.Dispose();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
