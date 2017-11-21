using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Merrto.CustomerService
{
    public partial class ImageMaxFrm : Form
    {
        public ImageMaxFrm(string url)
        {
            InitializeComponent();
            if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + url))//如果是文件的话
            {
                PictureBox pbimageMax = new PictureBox();
                pbimageMax.Name = "图片";
                pbimageMax.BackColor = System.Drawing.Color.Transparent;
                pbimageMax.ImageLocation = System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + url;
                pbimageMax.Location = new Point(pbimageMax.Location.X, pbimageMax.Location.Y);
                pbimageMax.Size = new System.Drawing.Size(this.Width, this.Height);
                pbimageMax.SizeMode = PictureBoxSizeMode.StretchImage;
                pbimageMax.TabIndex = 21;
                Controls.Add(pbimageMax);
           }
            //DataDGV.Visible = false;
        }

        private void ImageMaxFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
