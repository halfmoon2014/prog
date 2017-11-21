using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BarCode
{
    public partial class BarCodeRoute : Form
    {
        public BarCodeRoute()
        {
            InitializeComponent();
        }
        //private string openFileName = "";
        private void txtRoute_DoubleClick(object sender, EventArgs e)
        {
            FileDialog fd = new SaveFileDialog();
            fd.Filter = "CraxyMouse file (*.CraxyMouse)|*.CraxyMouse";
            fd.InitialDirectory = Application.StartupPath;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                //openFileName = fd.FileName;
                this.txtRoute.Text = fd.FileName;
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
            //XmlElement xmlelem = doc.CreateElement("", "RSP", "");
            //doc.AppendChild(xmlelem);
            //XmlElement xmlElemDataServer = doc.CreateElement("Form");
            //XmlText xmltextDataServer = doc.CreateTextNode(cmbForm.Text.ToString());
            //xmlElemDataServer.AppendChild(xmltextDataServer);
            //doc.ChildNodes.Item(1).AppendChild(xmlElemDataServer);

            //XmlElement xmlElemDataUser = doc.CreateElement("Route");
            //XmlText xmltextDataUser = doc.CreateTextNode(txtRoute.Text.ToString());
            //xmlElemDataUser.AppendChild(xmltextDataUser);
            //doc.ChildNodes.Item(1).AppendChild(xmlElemDataUser);

            //try
            //{
            //    doc.Save("FormRoute.xml");
            //    MessageBox.Show("保存XML文件成功！！");
            //}
            //catch
            //{
            //    MessageBox.Show("保存出错！！");
            //}
            //DataTable dt = CreateData();
            XmlDocument doc = new XmlDocument();
            doc.CreateXmlDeclaration("1.0", "utf-8", "yes");

            XmlElement xeRoot = doc.CreateElement("graph");
            xeRoot.SetAttribute("caption", "每月销售额柱形图");
            xeRoot.SetAttribute("xAxisName", "月份");
            xeRoot.SetAttribute("yAxisName", "Units");
            xeRoot.SetAttribute("showNames", "1");
            xeRoot.SetAttribute("decimalPrecision", "0");
            xeRoot.SetAttribute("formatNumberScale", "0");

            //foreach (DataRow dr in dt.Rows)
            //{
                XmlElement xeItem = doc.CreateElement("set");
                xeItem.SetAttribute("Form", "服装条码");
                xeItem.SetAttribute("Route", "");
                xeRoot.AppendChild(xeItem);
                
                xeItem = doc.CreateElement("set");
                xeItem.SetAttribute("Form", "装箱条码");
                xeItem.SetAttribute("Route", "");
                xeRoot.AppendChild(xeItem);

            //}
            doc.AppendChild(xeRoot);

            doc.Save("FormRoute.xml");

        }
    }
}
