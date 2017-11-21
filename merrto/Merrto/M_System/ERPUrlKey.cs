using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Merrto.M_System
{
    public partial class ERPUrlKey : Form
    {
        public ERPUrlKey()
        {
            InitializeComponent();
        }

        private void ERPUrlKey_Load(object sender, EventArgs e)
        {
            XmlNodeReader reader = null;
            string s = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                // 装入指定的XML文档
                doc.Load("ErpUrl.xml");
                // 设定XmlNodeReader对象来打开XML文件
                reader = new XmlNodeReader(doc);
                // 读取XML文件中的数据，并显示出来
                while (reader.Read())
                {
                    //判断当前读取得节点类型
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            s = reader.Name;
                            break;
                        case XmlNodeType.Text:
                            if (s.Equals("Api_Url"))
                            {
                                this.txtApiUrl.Text = reader.Value;
                            }
                            else if (s.Equals("Api_Key"))
                            {
                                this.txtApiKey.Text = reader.Value;
                            }
                            else if (s.Equals("Api_Serect"))
                            {
                                this.txtApiSerect.Text = reader.Value;
                            }
                            break;
                    }
                }
            }
            catch
            {  //    //清除打开的数据流
                if (reader != null)
                    reader.Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement xmlelem = doc.CreateElement("", "RSP", "");
            doc.AppendChild(xmlelem);
            XmlElement xmlElemDataServer = doc.CreateElement("Api_Url");
            XmlText xmltextDataServer = doc.CreateTextNode(this.txtApiUrl.Text.ToString());
            xmlElemDataServer.AppendChild(xmltextDataServer);
            doc.ChildNodes.Item(1).AppendChild(xmlElemDataServer);

            XmlElement xmlElemDataUser = doc.CreateElement("Api_Key");
            XmlText xmltextDataUser = doc.CreateTextNode(this.txtApiKey.Text.ToString());
            xmlElemDataUser.AppendChild(xmltextDataUser);
            doc.ChildNodes.Item(1).AppendChild(xmlElemDataUser);

            XmlElement xmlElemDataPass = doc.CreateElement("Api_Serect");
            XmlText xmltextDataPass = doc.CreateTextNode(this.txtApiSerect.Text.ToString());
            xmlElemDataPass.AppendChild(xmltextDataPass);
            doc.ChildNodes.Item(1).AppendChild(xmlElemDataPass);
            try
            {
                doc.Save("ErpUrl.xml");
                MessageBox.Show("保存XML文件成功！！");
            }
            catch
            {
                MessageBox.Show("保存出错！！");
            }
        }
    }
}
