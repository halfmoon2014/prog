using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Merrto
{
    public partial class FrmMian : Form
    {
        DataView dv;
        DataTable dt;
        bool isRun = true;
        baseclass.sqldatacon datacon = new baseclass.sqldatacon();
        public FrmMian()
        {
            InitializeComponent();
        }

        const int CLOSE_SIZE = 15;
      
        //tabPage标签图片
        
        private void TSPsoftUPDAte_Click(object sender, EventArgs e)
        {
            //"SoftUpdate.exe";
            string parf=System.Environment.CurrentDirectory+@"\SoftUpdate.exe";
            if (File.Exists(@parf))
            {
                if (this.isRun) Process.Start(parf);
            }
        }

        private void FrmMian_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("\n欢迎再次使用迈途信息管理系统   \n\n\n    确认是否退出(Y/N)", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;
                this.Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void tspcancel_Click(object sender, EventArgs e)
        {
            frmlogin login = new frmlogin();
            this.Dispose();
            login.Show();

        }

        
        private void FrmMian_Load(object sender, EventArgs e)
        {
            this.LblName.Text = "||当前用户：" + frmlogin.name;
            this.MianTime.Enabled = true;
            this.tclMian.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tclMian.Padding = new System.Drawing.Point(CLOSE_SIZE + 10, CLOSE_SIZE - 8); //设置大小
            this.tclMian.DrawItem += new DrawItemEventHandler(this.tclMian_DrawItem);
            this.tclMian.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tclMian_MouseDown);
            datacon.tv_meuns(tv_meun, frmlogin.userID);
         }
     
        //绘制“Ｘ”号即关闭按钮
         private void tclMian_DrawItem(object sender, DrawItemEventArgs e)
         {  
             try
              {
                  Rectangle myTabRect = this.tclMian.GetTabRect(e.Index);
  
                  //先添加TabPage属性   
                  e.Graphics.DrawString(this.tclMian.TabPages[e.Index].Text,this.Font, SystemBrushes.ControlText, myTabRect.X + 15, myTabRect.Y + 7);
  
                  //再画一个矩形框
                  using (Pen p = new Pen(Color.White))
                  {
                      myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 5), 5);
                      myTabRect.Width = CLOSE_SIZE;
                      myTabRect.Height = CLOSE_SIZE;
                      e.Graphics.DrawRectangle(p, myTabRect);
                  }
 
                 //填充矩形框
                  Color recColor = e.State == DrawItemState.Selected ? Color.Transparent : Color.Transparent;
                  using (Brush b = new SolidBrush(recColor))
                  {
                      e.Graphics.FillRectangle(b, myTabRect);
                  }
  
                  //画关闭符号
                  using (Pen objpen = new Pen(Color.Blue))
                  {
                      //"\"线
                      Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                      Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                      e.Graphics.DrawLine(objpen, p1, p2);
  
                      //"/"线
                      Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                      Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                      e.Graphics.DrawLine(objpen, p3, p4);
                        ////=============================================
                      //Bitmap bt = new Bitmap(image);
                      Point p5 = new Point(myTabRect.X-50, 4);
                      //e.Graphics.DrawImage(bt, p5);
                      //e.Graphics.DrawString(this.tclMian.TabPages[e.Index].Text, this.Font, objpen.Brush, p5);
                  }
                  e.Graphics.Dispose();
              }
              catch (Exception)
              {
  
              }
         }
          //=======================================================================
       
        //关闭按钮功能
        private void tclMian_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
 
                //计算关闭区域   
                Rectangle myTabRect = this.tclMian.GetTabRect(this.tclMian.SelectedIndex);
 
                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;
 
                //如果鼠标在区域内就关闭选项卡   
                bool isClose = x > myTabRect.X && x < myTabRect.Right && y > myTabRect.Y && y < myTabRect.Bottom;
 
                if (isClose == true)
                {
                    this.tclMian.TabPages.Remove(this.tclMian.SelectedTab);
                }
            }
        }

        private void SPTLEFT_Click(object sender, EventArgs e)
        {
            this.PMEUN.Visible = !this.PMEUN.Visible;
        }

        private void AddForm(string name, Form newform)
        {
            if (newform != null)
            {
                bool have = false;
                foreach (TabPage tapage in tclMian.TabPages) //遍历tabcoml
                {
                    if (tapage.Text == name)                  //tabpage名=传进来的值
                    {
                        have = true;
                        this.tclMian.SelectedTab = tapage;//tabpage得到交点
                    }
                }

                ///新建个tabpage
                if (!have)
                {
                    TabPage tapage = new TabPage();
                    tapage.Text = name;
                    newform.TopLevel = false;
                    newform.Dock = DockStyle.Fill;
                    newform.Show();
                    tapage.Controls.Add(newform);
                    tclMian.Controls.Add(tapage);
                    this.tclMian.SelectedTab = tapage;
                }
            }
            else
            {
                MessageBox.Show("该功能还没有开放，请升级！！","信息提示！！");
            }
        }

        public void Removes(string name, Form newform)
        {
            for (int i = 0; i <= tclMian.TabPages.Count; i++)
            {
                TabPage tabPage = tclMian.TabPages[i];
                MessageBox.Show(tabPage.Text);
                if (tabPage.Text == name)
                {
                    this.tclMian.TabPages.Remove(tabPage);
                }
            }
           
       }

        private void MianTime_Tick(object sender, EventArgs e)
        {
            this.LblTime.Text="||系统时间:" + System.DateTime.Now.ToString();
        }

        private void tv_meun_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SqlConnection conn = datacon.getcon("");
            string strsql = "SELECT menuUrl,menuName FROM m_SoftMenu where menuName='" + e.Node.Text + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();

            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows[0]["menuUrl"].ToString() != "")
            {
                Assembly asm = Assembly.Load("Merrto");

                Form frm = (Form)asm.CreateInstance("Merrto." + ds.Tables[0].Rows[0]["menuUrl"].ToString());
                AddForm(e.Node.Text, frm);
            }
            else
            {
                switch (e.Node.Text)
                {
                    
                    case "客单价定义":
                        AddForm(e.Node.Text, new TheShopReports.CustomerUnitSet(0));
                        break;
                    case "客单价修改":
                        AddForm(e.Node.Text, new TheShopReports.CustomerUnitSetBrow());
                        break;
                    

                }
            }
        }

        private void TspEditpassword_Click(object sender, EventArgs e)
        {
            M_System.EditPassWord epwd = new M_System.EditPassWord();
            epwd.ShowDialog();
        }

    }
}
