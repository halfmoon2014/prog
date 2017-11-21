using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml;


namespace Merrto.baseclass
{
    class sqldatacon
    {
        utils utils = new utils();
        #region  创建SqlDataReader对象
        /// <summary>
        /// 创建一个SqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public SqlDataReader getread(string M_str_sqlstr)
        {
            SqlConnection sqlcon = this.getcon("");
            SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);
            sqlcon.Open();
            SqlDataReader sqlread = sqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return sqlread;
        }
        #endregion


        #region  执行SqlCommand命令
        /// <summary>
        /// 执行SqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public void getcom(string sqlstr)
        {
            SqlConnection sqlcon = this.getcon("");
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlstr, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcom.Dispose();
            sqlcon.Close();
            sqlcon.Dispose();
        }
        #endregion

        #region  取salt
        /// <summary>
        /// 执行SqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public string GenerateRandom(string Name)
        {
            try
            {
                SqlConnection sqlcon = this.getcon("");
                DataTable dt = new DataTable();
                SqlDataAdapter sqlDaper = new SqlDataAdapter("select salt from m_User where USERNAME='" + Name.Trim() + "'", sqlcon);
                DataSet ds = new DataSet();
                sqlcon.Open();
                sqlDaper.Fill(dt);
                sqlcon.Close();
                if (dt.Rows[0]["salt"].ToString()!="")
                {
                    return dt.Rows[0]["salt"].ToString();
                }
                else
                {
                    return utils.GenerateRandom(6);
                }
            }
            catch (Exception ex)
            {

                return utils.GenerateRandom(6);
                //return -100;
            }
        }
        #endregion

        #region  取salt
        /// <summary>
        /// 执行SqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public string GenerateRandom(int Length)
        {

            return utils.GenerateRandom(Length);

        }
        #endregion


        #region  建立数据库连接
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回SqlConnection对象</returns>
        public SqlConnection getcon(string str)
        {
            string M_str_sqlcon;
            if (str == "")
            {
                M_str_sqlcon = this.XML();
            }
            else if (str == "Wei")
            {
                M_str_sqlcon = this.WerXML();
            }
            else
            {
                M_str_sqlcon = str;
            }

            SqlConnection myCon = new SqlConnection(M_str_sqlcon + ";;max pool size=800;min pool size=300;Connect Timeout=500;");
            return myCon;
        }
        #endregion

        #region 读取文本文件
        public string TXT()
        {
            string path = System.Environment.CurrentDirectory;
            string txt = "";
            StreamReader sr = new StreamReader(path + @"\ServerIP.xml");
            //Directory.GetCurrentDirectory;
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                txt += str + "\n";
            }
            return txt;
            sr.Close();
        }
        #endregion

        #region 读取XML文本文件
        public string XML()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            XmlNodeReader reader = null;
            string s = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                // 装入指定的XML文档
                doc.Load(path + @"\ServerIP.xml");
                // 设定XmlNodeReader对象来打开XML文件
                reader = new XmlNodeReader(doc);
                // 读取XML文件中的数据，并显示出来
                while (reader.Read())
                {
                    //判断当前读取得节点类型
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (s != "")
                            {
                                s += ";";
                            }
                            if (reader.Name.ToString() != "RSP")
                            {
                                s += reader.Name;
                            }
                            break;
                        case XmlNodeType.Text:
                            
                            s += "='"+utils.DecryptDES(reader.Value,"abcdefgh")+"'";
                            break;
                        
                    }
                }
            }
            catch
            {  //    //清除打开的数据流
                if (reader != null)
                    reader.Close();
            }
            //finally
            //{
            //    //清除打开的数据流
            //    if (reader != null)
            //        reader.Close();
            //}
            return s;

        }
        #endregion

        #region 读取XML文本文件(软件外路径)
        public string WerXML()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            XmlNodeReader reader = null;
            string s = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                // 装入指定的XML文档
                doc.Load(path + @"\WaiServer.xml");
                // 设定XmlNodeReader对象来打开XML文件
                reader = new XmlNodeReader(doc);
                // 读取XML文件中的数据，并显示出来
                while (reader.Read())
                {
                    //判断当前读取得节点类型
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (s != "")
                            {
                                s += ";";
                            }
                            if (reader.Name.ToString() != "RSP")
                            {
                                s += reader.Name + "=";
                            }
                            break;
                        case XmlNodeType.Text:
                            s += utils.DecryptDES(reader.Value, "abcdefgh");
                            break;
                        //case "Server":
                        //    break;
                    }
                }
            }
            catch
            {  //    //清除打开的数据流
                if (reader != null)
                    reader.Close();
            }
            //finally
            //{
            //    //清除打开的数据流
            //    if (reader != null)
            //        reader.Close();
            //}
            return s;

        }
        #endregion

        #region 读取XML文本文件
        public string XMLIP()
        {
            XmlNodeReader reader = null;
            string sn = "";
            string bl = "";
            XmlDocument doc = new XmlDocument();
            // 装入指定的XML文档
            doc.Load("ServerIP.xml");
            // 设定XmlNodeReader对象来打开XML文件
            reader = new XmlNodeReader(doc);
            // 读取XML文件中的数据，并显示出来
            while (reader.Read())
            {
                //判断当前读取得节点类型
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        sn = reader.Name;
                        break;
                    case XmlNodeType.Text:
                        if (sn.Equals("server"))
                        {
                            bl += "Data Source=" + utils.DecryptDES(reader.Value,"abcdefgh") + ";";
                        }
                        else if (sn.Equals("uid"))
                        {
                            bl += "User ID=" + utils.DecryptDES(reader.Value,"abcdefgh") + ";";
                        }
                        else if (sn.Equals("pwd"))
                        {
                            bl += "Password=" + utils.DecryptDES(reader.Value,"abcdefgh") + ";";
                        }
                        else if (sn.Equals("database"))
                        {
                            bl += "Initial Catalog=" + utils.DecryptDES(reader.Value, "abcdefgh") + ";";
                        }
                        break;
                }
            }
            return "Provider=SQLOLEDB.1;Persist Security Info=True;" + bl + "Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=XULITING;Use Encryption for Data=False;Tag with column collation when possible=False";
        }
        #endregion

        #region  用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="P_str_UserName">用户名</param>
        /// <param name="P_str_UserPwd">用户密码</param>
        /// <returns>返回一个int类型的值</returns>
        public int UserLogin(string P_str_ID, string P_str_UserPwd)
        {
            SqlConnection sqlcon = this.getcon("");
            SqlCommand sqlcom = new SqlCommand("proc_Login", sqlcon);
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add("@UserName", SqlDbType.VarChar, 20).Value = P_str_ID;
            sqlcom.Parameters.Add("@UserPwd", SqlDbType.VarChar, 20).Value = P_str_UserPwd;
            SqlParameter returnValue = sqlcom.Parameters.Add("returnValue", SqlDbType.Int, 4);
            returnValue.Direction = ParameterDirection.ReturnValue;
            sqlcon.Open();
            try
            {
                sqlcom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcom.Dispose();
                sqlcon.Close();
                sqlcon.Dispose();
            }
            int P_int_returnValue = (int)returnValue.Value;
            return P_int_returnValue;
        }
        #endregion

        

        #region  用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="P_str_UserName">用户名</param>
        /// <param name="P_str_UserPwd">用户密码</param>
        /// <returns>返回一个int类型的值</returns>
        public int ULogin(string P_str_ID, string P_str_UserPwd)
        {
            int P_int_returnValue = 0;
            SqlConnection conn = this.getcon("");
            string sqlStr = "select * from m_User where UserName='" + P_str_ID + "' and PassWord='" + P_str_UserPwd + "' and state=1";
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlda.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                P_int_returnValue = 100;
            }
            else
            {
                P_int_returnValue = -100;
            }
            
            return P_int_returnValue;
        }
        #endregion

        #region
        /// <summary>
        /// 对ComboBox控件进行数据绑定
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <param name="M_str_table">表名</param>
        /// <param name="M_str_tbMember">数据表中字段名</param>
        /// <param name="cbox">ComboBox控件ID</param>
        public void cboxBind(string M_str_sqlstr, string M_str_table, string M_str_tbMember, ComboBox cbox)
        {
            DataSet myds = this.getds(M_str_sqlstr, M_str_table);
            cbox.DataSource = myds.Tables[M_str_table];
            cbox.DisplayMember = M_str_tbMember;
        }
        #endregion

        #region  创建DataSet对象
        /// <summary>
        /// 创建一个DataSet对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <param name="M_str_table">表名</param>
        /// <returns>返回DataSet对象</returns>
        public DataSet getds(string M_str_sqlstr, string M_str_table)
        {
            SqlConnection sqlcon = this.getcon("");
            SqlDataAdapter sqlda = new SqlDataAdapter(M_str_sqlstr, sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds, M_str_table);
            return myds;
        }
        #endregion

        #region  创建tv_meuns
        /// <summary>
        /// 创建一个SqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public void tv_meuns(TreeView tv_meun, string userid)
        {
            string sqlStr="";
            SqlConnection conn = this.getcon("");
            if (userid == "Permissions" || userid == "admin")
            {
                sqlStr = "select * from m_softmenu where MENUPARENTID=0";
            }
            else 
            {
                sqlStr = "select * from m_softmenu where MENUPARENTID=0 and " +
                "exists(select * from m_softMenuuser where exists(select * from m_User where username='"
                + userid.Trim() + "' and  id=m_softMenuuser.userid) and m_softMenuuser.menuid=m_softmenu.menuid)  order by MENUID";
            }
            SqlDataAdapter SQLDA = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            SQLDA.Fill(ds);
            DataView dv = ds.Tables[0].DefaultView;
           
            foreach (DataRowView row in dv)
            {
                string unitName = row["menuName"].ToString().Trim();
                int unitID = Convert.ToInt32(row["MENUID"].ToString().Trim());
                string menuurl = row["menuUrl"].ToString().Trim();
                TreeNode unit = new TreeNode(unitName);

                unit.Expand();

                if (userid == "ADMIN" || userid == "Permissions")
                {
                    TreeView_admin(unit, unitID, userid);
                }
                else
                {
                    TreeView_meun(unit, unitID, userid);
                }
                tv_meun.Nodes.Add(unit);
            }
            //关闭连接
            conn.Close();
        }
        protected void TreeView_admin(TreeNode node, int nodeID, string userid)
        {
            SqlConnection conn = this.getcon("");
            //打开连接
            conn.Open();
            string sqlStr = "select * from m_softmenu WHERE MENUPARENTID = " + nodeID + " order by MENUID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DataView dv = ds.Tables[0].DefaultView;

            foreach (DataRowView row in dv)
            {
                string unitName = row["menuName"].ToString().Trim();
                int unitID = Convert.ToInt32(row["MENUID"].ToString().Trim());
                string menuurl = row["menuUrl"].ToString().Trim();
                TreeNode unit = new TreeNode(unitName);
                unit.Expand();

                TreeView_admin(unit, unitID, userid);

                if (unitName == "权限分配" && userid == "ADMIN")  //‘权限分配’不显示
                {
                }
                else
                {
                    node.Nodes.Add(unit);
                }
                if (unitID > 10 && userid == "ADMIN")
                {
                    node.Collapse();
                }
            }
            conn.Close();
        }
        //TreeView递归添加子节点
        protected void TreeView_meun(TreeNode node, int nodeID, string userid)
        {
            SqlConnection conn = this.getcon("");
            //打开连接
            string sqlStr = "";
            conn.Open();
            if (userid == "Permissions" || userid == "admin")
            {
                sqlStr = "select * from m_softmenu WHERE MENUPARENTID = " + nodeID;
            }
            else
            {
                sqlStr = "select * from m_softmenu WHERE MENUPARENTID = " + nodeID + " and " +
                    "exists(select * from m_softMenuuser where exists(select * from m_User where username='"
                    + userid.Trim() + "' and  id=m_softMenuuser.userid) and m_softMenuuser.menuid=m_softmenu.menuid)  order by MENUID";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            DataView dv = ds.Tables[0].DefaultView;

            foreach (DataRowView row in dv)
            {
                string unitName = row["menuName"].ToString().Trim();
                int unitID = Convert.ToInt32(row["MENUID"].ToString().Trim());
                string menuurl = row["menuUrl"].ToString().Trim();
                TreeNode unit = new TreeNode(unitName);
                unit.Expand();

                TreeView_meun(unit, unitID, userid);

                if (unitName != "权限分配")  //‘权限分配’不显示
                {
                    node.Nodes.Add(unit);
                }
                if (unitID > 10)
                {
                    node.Collapse();
                }
            }
            conn.Close();
        }
        #endregion

        #region  创建cbo
        //public ComboBox cbouser()
        public void cbouser(ComboBox usercmbuser)
        {
            this.cboxBind("select id,USERNAME from M_user", "M_user", "USERNAME", usercmbuser);
        }
        public void CboUser(ComboBox CboName)
        {
            SqlConnection conn = this.getcon("");
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select ID,USERNAME from M_user ", conn);
            DataSet ds = new DataSet();
            sqlDaper.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CboName.DataSource = ds.Tables[0];
                CboName.ValueMember = "ID";
                CboName.DisplayMember = "USERNAME";
            }
        }

        public void cboempdept(ComboBox EmpDept)
        {
            this.cboxBind("select classname from tb_class", "tb_class", "classname", EmpDept);
        }

        public void cbostorage(ComboBox Storage)
        {
            this.cboxBind("select StorageName from tb_Storage", "Tb_Storage", "Storagename", Storage);
        }

         #endregion

        

        #region  创建trprm
        /// <summary>
        /// 创建一个SqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public void trprm(string str, TreeNode tnp)
        {
            foreach (TreeNode row in tnp.Nodes)
            {
                if (str == row.Text)
                {
                    row.Checked = true;
                }
                trprm(str, row);
            }
        }
        public int menuadd(string StrUser)
        {
            try
            {
                //string StrUser = "INSERT INTO tb_sfotmenuuser(menuid,userid)VALUES((select menuID from tb_sfotmenu where menuName = '" + menuid.Trim() + "'),(select id from tb_softUser where USERNAME='" + userid.Trim() + "'))";
                getcom(StrUser);
                return 100;
            }
            catch (Exception ex)
            {
                return -100;
            }
        }

        public int menuadd(string menuid, string userid)
        {
            try
            {
                string StrUser = "INSERT INTO tb_sfotmenuuser(menuid,userid)VALUES((select menuID from tb_sfotmenu where menuName = '" + menuid.Trim() + "'),(select id from tb_softUser where USERNAME='" + userid.Trim() + "'))";
                getcom(StrUser);
                return 100;
            }
            catch (Exception ex)
            {
                return -100;
            }
        }
        #endregion


        #region  创建menudel
        /// <summary>
        /// 创建一个SqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public void menudel(string userid)
        {
            string Strdel = "delete from m_SoftMenuUser where userid in (select id from M_User where  USERNAME='" + userid.Trim() + "')";

            getcom(Strdel);
        }
        #endregion

        public void MBDate(DataGridView DGV,string userid)
        {
            string STRSQL = "select CAST ('True' as bit)ok,menuName,m_SoftMenu.id menuID,m_MenuButton.id MBID,name from m_MenuButton "+
            "left join m_MenuButtonUser  on m_MenuButton.id=MBID "+
            "left join m_SoftMenu on m_MenuButton.menuID=m_SoftMenu.id  where  userID='" + userid + "' " +
            "union all select CAST ('False' as bit)ok,menuName,m_SoftMenu.id menuID,m_MenuButton.id MBID,name from m_MenuButton "+
            "left join m_SoftMenu on m_MenuButton.menuID=m_SoftMenu.id where "+
            "not exists(select * from m_MenuButtonUser where userID='" + userid + "' and  m_MenuButtonUser.MBID=m_MenuButton.ID)";
            SqlConnection sqlcon = this.getcon("");
            SqlDataAdapter SDA = new SqlDataAdapter(STRSQL, sqlcon);
            
            DataSet DS = new DataSet();
            sqlcon.Open();
            SDA.Fill(DS);
            sqlcon.Close();
            DGV.DataSource = DS.Tables[0];

        }

        public DataTable DgvHeader(string fromID, string userid,string DBO_)
        {
            string STRSQL = "select CAST ('True' as bit)ok,menuName,m_SoftMenu.id menuID,m_MenuButton.id MBID,name from m_MenuButton " +
            "left join m_MenuButtonUser  on m_MenuButton.id=MBID " +
            "left join m_SoftMenu on m_MenuButton.menuID=m_SoftMenu.id  where  userID='" + userid + "' " +
            "union all select CAST ('False' as bit)ok,menuName,m_SoftMenu.id menuID,m_MenuButton.id MBID,name from m_MenuButton " +
            "left join m_SoftMenu on m_MenuButton.menuID=m_SoftMenu.id where " +
            "not exists(select * from m_MenuButtonUser where userID='" + userid + "' and  m_MenuButtonUser.MBID=m_MenuButton.ID)";
            SqlConnection sqlcon = this.getcon("");
            SqlDataAdapter SDA = new SqlDataAdapter(STRSQL, sqlcon);

            DataSet DS = new DataSet();
            sqlcon.Open();
            SDA.Fill(DS);
            sqlcon.Close();
            return DS.Tables[0];

        }

        #region  创建menudel
        /// <summary>
        /// 创建一个SqlDataReader对象
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public void perm(ComboBox userid, TreeView tnp)
        {
            string strprn = "select menuName from m_sOftmenu where exists(select * from M_sOftmenuuser where exists(select * from m_User where USERNAME='"
                + userid.Text.ToString().Trim() + "' and id=m_sOftmenuuser.userid) and M_sOftmenuuser.menuid=m_sOFtmenu.menuid)";
            SqlConnection sqlcon = this.getcon("");
            SqlCommand sqlcom = new SqlCommand(strprn, sqlcon);
            sqlcon.Open();
            SqlDataReader sqlread = sqlcom.ExecuteReader();
            while (sqlread.Read())
            {
                foreach (TreeNode tn in tnp.Nodes)
                {
                    if (sqlread["menuName"].ToString() == tn.Text)
                    {
                        tn.Checked = true;
                    }
                   trprm(sqlread["menuName"].ToString(), tn);
                }
            }
        }
        #endregion
    }
}

