using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace main
{
    public partial class DialogBrowser : Form
    {
        public DialogBrowser( string url)
        {
            InitializeComponent();
            myDialogBrowser.Navigate(url);
        }

        private void myWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textUrl.Text = myDialogBrowser.Url.ToString();
        }
    }
}
