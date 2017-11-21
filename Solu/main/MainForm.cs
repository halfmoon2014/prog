using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
namespace main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
  
        }

        private void butGo_Click(object sender, EventArgs e)
        {
            int a=1;int b=2;int c=0;
            mySum(a,b, ref c);
            MessageBox.Show(c.ToString());
            string url = textUrl.Text;
            myWebBrowser.Navigate(url);
        }

        private void myWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //web加载完成
            //MessageBox.Show("加载完毕");
            textUrl.Text = myWebBrowser.Url.ToString();
        }

        private void myWebBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            //MessageBox.Show(myWebBrowser.StatusText);
            DialogBrowser db = new DialogBrowser(myWebBrowser.StatusText);
            db.Show();
            //myWebBrowser.Navigate(myWebBrowser.StatusText);
        }
        [DllImport("reg.dll")  ]
        public static extern int  mySum(int a,int b,ref int c);
     
    }
}
