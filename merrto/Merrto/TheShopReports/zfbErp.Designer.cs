namespace Merrto.TheShopReports
{
    partial class zfbErp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WPHbROWDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPStop = new System.Windows.Forms.DateTimePicker();
            this.DTPStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnupEXcel = new System.Windows.Forms.Button();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.BTNbROW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WPHbROWDGV
            // 
            this.WPHbROWDGV.AllowUserToAddRows = false;
            this.WPHbROWDGV.AllowUserToDeleteRows = false;
            this.WPHbROWDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WPHbROWDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 71);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.ReadOnly = true;
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(769, 311);
            this.WPHbROWDGV.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DTPStop);
            this.groupBox1.Controls.Add(this.DTPStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnupEXcel);
            this.groupBox1.Controls.Add(this.CmdShop);
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 71);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // TxtCade
            // 
            this.TxtCade.Location = new System.Drawing.Point(243, 17);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(110, 21);
            this.TxtCade.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "单据号：";
            // 
            // DTPStop
            // 
            this.DTPStop.Location = new System.Drawing.Point(243, 43);
            this.DTPStop.Name = "DTPStop";
            this.DTPStop.Size = new System.Drawing.Size(110, 21);
            this.DTPStop.TabIndex = 22;
            // 
            // DTPStart
            // 
            this.DTPStart.Location = new System.Drawing.Point(68, 43);
            this.DTPStart.Name = "DTPStart";
            this.DTPStart.Size = new System.Drawing.Size(112, 21);
            this.DTPStart.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "终止时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "起始时间：";
            // 
            // btnupEXcel
            // 
            this.btnupEXcel.Location = new System.Drawing.Point(585, 12);
            this.btnupEXcel.Name = "btnupEXcel";
            this.btnupEXcel.Size = new System.Drawing.Size(88, 51);
            this.btnupEXcel.TabIndex = 16;
            this.btnupEXcel.Text = "导出EXCEL";
            this.btnupEXcel.UseVisualStyleBackColor = true;
            this.btnupEXcel.Visible = false;
            // 
            // CmdShop
            // 
            this.CmdShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Location = new System.Drawing.Point(69, 17);
            this.CmdShop.Name = "CmdShop";
            this.CmdShop.Size = new System.Drawing.Size(111, 20);
            this.CmdShop.TabIndex = 8;
            // 
            // BTNbROW
            // 
            this.BTNbROW.Location = new System.Drawing.Point(435, 14);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 51);
            this.BTNbROW.TabIndex = 12;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "店铺：";
            // 
            // zfbErp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 382);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "zfbErp";
            this.Text = "zfbErp";
            this.Load += new System.EventHandler(this.zfbErp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTPStop;
        private System.Windows.Forms.DateTimePicker DTPStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnupEXcel;
        private System.Windows.Forms.ComboBox CmdShop;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
    }
}