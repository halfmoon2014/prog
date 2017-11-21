using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mytest
{
    public class Class1 : IDisposable 
    {
       public string b;
       public string a;
        public Class1(string a1, string b1)
        {
            a = a1;
            b = b1;
            
        }

        public void Dispose()
        {
        }
  
    }
}

