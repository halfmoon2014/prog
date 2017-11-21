using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FirefoxDriver f = new FirefoxDriver();
            f.Url = "http://www.baidu.com";
            
        }
    }
}
