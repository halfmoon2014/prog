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
using grproLib;


namespace Merrto
{
    public partial class BarCodeCade : Form
    {
        private GridppReport Report = new GridppReport();
        string Rroute;
        string barcode;
        int Sizelong;
        int Nomber;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public BarCodeCade(string route,string BarCode,int sizelong,int nomber)
        {

            InitializeComponent();
            Rroute = route;
            barcode = BarCode;
            Sizelong = sizelong;
            Nomber = nomber;
            AGRDReports.Report = Report;
            OFDReports.FileName = route;
            OFDReports.InitialDirectory = @"..\..\..\..\Reports";
            Report.LoadFromFile(OFDReports.FileName);
            AGRDReports.Reload();
   
        }

   

    }
}
