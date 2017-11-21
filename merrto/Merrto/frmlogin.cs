using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Merrto
{
    public partial class frmlogin : Form
    {
        public static string name;//记录登录用户名字
        public static string pwd;//记录登录用户密码
        public static string userID;//记录登录用户名字

        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.utils utils = new baseclass.utils();
        public frmlogin()
        {
            InitializeComponent();
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            LoGIin();
            if (ChkPWD.Checked == true)
            {
                XmlDocument doc = new XmlDocument();
                doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
                XmlElement xmlelem = doc.CreateElement("", "RSP", "");
                doc.AppendChild(xmlelem);
                XmlElement xmlElemDataServer = doc.CreateElement("UserID");
                XmlText xmltextDataServer = doc.CreateTextNode(utils.EncryptDES(this.txtUserID.Text.ToString(), "abcdefgh"));
                xmlElemDataServer.AppendChild(xmltextDataServer);
                doc.ChildNodes.Item(1).AppendChild(xmlElemDataServer);

                XmlElement xmlElemDataUser = doc.CreateElement("PassWord");
                XmlText xmltextDataUser = doc.CreateTextNode(this.txtPassWord.Text.ToString());
                xmlElemDataUser.AppendChild(xmltextDataUser);
                doc.ChildNodes.Item(1).AppendChild(xmlElemDataUser);

                try
                {
                    doc.Save("User.xml");

                }
                catch
                {
                    //MessageBox.Show("保存出错！！");
                }
            }
            else
            {
                if (File.Exists("User.xml"))//判断文件是不是存在           
                {
                    File.Delete("User.xml");//如果存在则删除           
                } 
             }
            
        }

        private void LoGIin()
        {
            string StrPwd = "select PassWord from m_User where UserName='" + txtUserID.Text + "'";
            SqlDataReader SdrPws = sqlcon.getread(StrPwd);
            string PassWord_ = "";
            if (SdrPws.Read())
            {
                PassWord_ = SdrPws["PassWord"].ToString();
            }
            if (txtPassWord.Text.ToString() != PassWord_)
            {
                pwd = utils.StringToMD5Hash(txtPassWord.Text.Trim()).ToUpper() + sqlcon.GenerateRandom(txtUserID.Text);
                pwd = utils.StringToMD5Hash(pwd).ToUpper();
                txtPassWord.Text = pwd;
            }
            else
            {
                pwd = PassWord_;
            }
            int P_int_returnValue = sqlcon.ULogin(txtUserID.Text.Trim(), pwd);
            if (sqlcon.ULogin(txtUserID.Text.Trim(), pwd) == 100)
            {
                userID = txtUserID.Text;
                pwd = txtPassWord.Text.Trim();
                string str = "select UserName,ID from m_User where UserName='" + txtUserID.Text + "'";
                SqlDataReader sqlread = sqlcon.getread(str);
                if (sqlread.Read())
                {
                    name = sqlread["UserName"].ToString();
                }
                sqlread.Close();
                FrmMian fmain = new FrmMian();
                this.Hide();
                fmain.Show();
            }
            else if (sqlcon.ULogin(txtUserID.Text.Trim(), pwd) == -100)
            {
                MessageBox.Show("用户名、密码错误或是用户不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassWord.Text = "";
            }

        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoGIin();
            }
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoGIin();
            }
        }

        private void LblSetServer_Click(object sender, EventArgs e)
        {
            SetServer sets = new SetServer();
            sets.ShowDialog();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            XmlNodeReader reader = null;
            string s = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                // 装入指定的XML文档
                doc.Load("User.xml");
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
                            if (s.Equals("UserID"))
                            {
                                this.txtUserID.Text = utils.DecryptDES(reader.Value, "abcdefgh");
                            }
                            else if (s.Equals("PassWord"))
                            {
                                this.txtPassWord.Text = reader.Value;
                            }
                            ChkPWD.Checked = true;
                            btnlogin.Focus();
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

        private void frmlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
          
            Environment.Exit(0);
       
        }

    }
}
