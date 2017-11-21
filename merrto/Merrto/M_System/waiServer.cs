using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;

namespace Merrto.M_System
{
    public partial class waiServer : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.utils utils = new baseclass.utils();
        public waiServer()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement xmlelem = doc.CreateElement("", "RSP", "");
            doc.AppendChild(xmlelem);
            XmlElement xmlElemDataServer = doc.CreateElement("server");
            XmlText xmltextDataServer = doc.CreateTextNode(utils.EncryptDES(txtserverIP.Text.ToString(),"abcdefgh"));
            xmlElemDataServer.AppendChild(xmltextDataServer);
            doc.ChildNodes.Item(1).AppendChild(xmlElemDataServer);

            XmlElement xmlElemDataUser = doc.CreateElement("uid");
            XmlText xmltextDataUser = doc.CreateTextNode(utils.EncryptDES(txtuser.Text.ToString(),"abcdefgh"));
            xmlElemDataUser.AppendChild(xmltextDataUser);
            doc.ChildNodes.Item(1).AppendChild(xmlElemDataUser);

            XmlElement xmlElemDataPass = doc.CreateElement("pwd");
            XmlText xmltextDataPass = doc.CreateTextNode(utils.EncryptDES(txtpwd.Text.ToString(),"abcdefgh"));
            xmlElemDataPass.AppendChild(xmltextDataPass);
            doc.ChildNodes.Item(1).AppendChild(xmlElemDataPass);

            XmlElement xmlElemData = doc.CreateElement("database");
            XmlText xmltextData = doc.CreateTextNode(utils.EncryptDES(cmbdbo.Text.ToString(), "abcdefgh"));
            xmlElemData.AppendChild(xmltextData);
            doc.ChildNodes.Item(1).AppendChild(xmlElemData);
            //doc.ChildNodes.Item(1).AppendChild
            //XmlElement rootElement, subElement, subsubElement, subsubsubElement;

            //XmlNode node = doc.CreateXmlDeclaration("1.0","utf-8","no");
            //doc.AppendChild(node);
            //rootElement = doc.CreateElement("Server");
            //doc.AppendChild(rootElement);

            //subElement = doc.CreateElement("DataServer");
            //XmlText Server =doc.CreateTextNode(txtserverIP.Text.ToString());
            //subElement.AppendChild(Server);

            //subsubElement = doc.CreateElement("DataUser");
            //XmlText User = doc.CreateTextNode(txtuser.Text.ToString());
            //subsubElement.AppendChild(User);

            //subsubsubElement = doc.CreateElement("Pass");
            //XmlText Pass = doc.CreateTextNode(txtuser.Text.ToString());
            //subsubsubElement.AppendChild(Pass);
            try
            {
                doc.Save("WaiServer.xml");
                MessageBox.Show("保存XML文件成功！！");
            }
            catch
            {
                MessageBox.Show("保存出错！！");
            }
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            if (this.txtserverIP.Text != "")
            {
                string str = "server=" + txtserverIP.Text + ";database=" + cmbdbo.Text + ";uid=" + txtuser.Text + ";pwd=" + txtpwd.Text;
            }
            if (txtserverIP.Text == string.Empty)
            {
                MessageBox.Show("请输入服务器名称！");
                txtserverIP.Focus();
            }
            else if (txtuser.Text == string.Empty)
            {
                MessageBox.Show("请输入服务器数据库用户名！");
                txtuser.Focus();
            }
            //else if (txtpwd.Text == string.Empty)
            //{
            //    MessageBox.Show("请输入服务器数据库密码！");
            //    txtpwd.Focus();
            //}
            else
            {
                string str = "server=" + txtserverIP.Text + ";database=" + cmbdbo.Text + ";uid=" + txtuser.Text + ";pwd=" + txtpwd.Text; ;
                SqlConnection conn = sqlcon.getcon(str);
                try
                {
                    conn.Open();
                    MessageBox.Show("测试连接数据库成功！");
                }
                catch (Exception)
                {
                    MessageBox.Show("测试连接数据库失败！请检查服务器名称和数据库名称是否正确！");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void cmbdbo_Enter(object sender, EventArgs e)
        {
            string strconn = "server=" + txtserverIP.Text + ";database=master;uid=" + txtuser.Text + ";pwd=" + txtpwd.Text;
            SqlConnection conn = sqlcon.getcon(strconn);
            string str = "SELECT NAME FROM sysdatabases WHERE dbid>=4";
            SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqldaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    this.cmbdbo.DataSource = ds.Tables[0];
                    cmbdbo.ValueMember = "Name";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("测试连接数据库失败！请检查服务器名称和用户名、密码是否正确！");
            }
            finally
            {
                conn.Close();
            }
        }

        private void waiServer_Load(object sender, EventArgs e)
        {
            XmlNodeReader reader = null;
            string s = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                // 装入指定的XML文档
                doc.Load("WaiServer.xml");
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
                            if (s.Equals("server"))
                            {
                                this.txtserverIP.Text = utils.DecryptDES(reader.Value,"abcdefgh");
                            }
                            else if (s.Equals("uid"))
                            {
                                this.txtuser.Text = utils.DecryptDES(reader.Value,"abcdefgh");
                            }
                            else if (s.Equals("pwd"))
                            {
                                this.txtpwd.Text = utils.DecryptDES(reader.Value,"abcdefgh");
                            }
                            else if (s.Equals("database"))
                            {
                                this.cmbdbo.Text = utils.DecryptDES(reader.Value, "abcdefgh");
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
    }
}
