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
    public partial class Form2 : Form
    {

        public delegate void addText(string text);
        public event addText eventAddText;
        public void addTextToMainform(string a)
        {
            if (eventAddText != null)
            {
                eventAddText(a);
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text=MyStatic.aa;
        }


      

        void Form2_eventAddText(string text)
        {
            Form1.abcf.showText(text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //注册事件方法
            eventAddText += new addText(Form2_eventAddText);
            //触发事件
            addTextToMainform(textBox1.Text);
            //this.Dispose();
        }
    }
}
