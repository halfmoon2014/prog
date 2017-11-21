using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
 
    public partial class Form1 : Form
    {
        public static Form1 abcf;

        public Form1()
        {
            InitializeComponent();
            abcf = this;
            var t = typeof(CA);
            //MethodInfo method = t.GetMethod(name, BindingFlags.NonPublic);
            foreach (var m in t.GetMethods())
            {

                //textBox2.Text += m.Name+",";
            } 
            foreach (var m in t.GetMethods(System.Reflection.BindingFlags.NonPublic))
            {

                textBox2.Text += m.Name + ",";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //第一种记录用法
            //（1）FormMain是类名称
            //（2）第二个参数是字符串信息
            LogHelper.WriteLog(typeof(Form1), "测试Log4Net日志是否写入");


            //第二种记录用法
            //（1）FormMain是类名称
            //（2）第二个参数是需要捕捉的异常块
            //try { 

            //}catch(Exception ex){

            //    LogHelper.WriteLog(typeof(FormMain), ex);

            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyStatic.aa = "hello2";
            Form2 frm = new Form2();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyStatic.aa = "hello3";
            Form3 frm = new Form3();
            frm.Show();
        }
        public void showText(string str)
        {
            textBox1.Text = str;
            return;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class CB
    {
    }
    public class CA
    {
        private void f()
        {
        }
        public string _name = "myname";
        public int _num = 94;
        //[System.Xml.Serialization.XmlIgnore]
        public string _city = "tianjin";
        public CB b = new CB();
        [NonSerialized]//对XmlSerializer无效
        private string _address = "bohai";
        public string name { get { return _name; } set { _name = value; } }
    }
}
