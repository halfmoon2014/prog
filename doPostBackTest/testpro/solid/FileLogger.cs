using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace m1
{
    /// <summary>
    ///FileLogger 的摘要说明
    /// </summary>
    public class FileLogger
    {
        public FileLogger()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error);
        }
    }
}