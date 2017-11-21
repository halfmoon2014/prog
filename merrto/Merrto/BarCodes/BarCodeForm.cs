using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Drawing.Printing;
using grproLib;
namespace Merrto
{
    public partial class BarCodeForm: Form
    {
        private GridppReport Report = new GridppReport();


        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public BarCodeForm()
        {
            InitializeComponent();
            AGRDReports.Report = Report;

            OFDReports.InitialDirectory = @"..\..\..\..\Reports";
            
        }

       

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (OFDReports.ShowDialog() == DialogResult.OK)
            {
                Report.LoadFromFile(OFDReports.FileName);
                AGRDReports.Reload();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (OFDReports.FileName != "")
            {
                AGRDReports.Post();
                Report.SaveToFile(OFDReports.FileName);
            }
        }

        private void btnSaveas_Click(object sender, EventArgs e)
        {
            SFDReports.FileName = OFDReports.FileName;
            if (SFDReports.ShowDialog() == DialogResult.OK)
            {
                AGRDReports.Post();
                Report.SaveToFile(SFDReports.FileName);
            }
        }

       
    }
}
