namespace Merrto.TheShopReports
{
    partial class OrderList
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
            this.DataDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btndelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnEXCEL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DTdatetime = new System.Windows.Forms.DateTimePicker();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataDGV
            // 
            this.DataDGV.AllowUserToAddRows = false;
            this.DataDGV.AllowUserToDeleteRows = false;
            this.DataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataDGV.Location = new System.Drawing.Point(0, 41);
            this.DataDGV.Name = "DataDGV";
            this.DataDGV.ReadOnly = true;
            this.DataDGV.RowTemplate.Height = 23;
            this.DataDGV.Size = new System.Drawing.Size(796, 434);
            this.DataDGV.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btndelete);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.BtnEXCEL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTdatetime);
            this.groupBox1.Controls.Add(this.CmdShop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 41);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Btndelete
            // 
            this.Btndelete.Location = new System.Drawing.Point(500, 12);
            this.Btndelete.Name = "Btndelete";
            this.Btndelete.Size = new System.Drawing.Size(75, 23);
            this.Btndelete.TabIndex = 9;
            this.Btndelete.Text = "删除";
            this.Btndelete.UseVisualStyleBackColor = true;
            this.Btndelete.Click += new System.EventHandler(this.Btndelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "导入EXCEL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(704, 15);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Visible = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnEXCEL
            // 
            this.BtnEXCEL.Location = new System.Drawing.Point(628, 14);
            this.BtnEXCEL.Name = "BtnEXCEL";
            this.BtnEXCEL.Size = new System.Drawing.Size(75, 23);
            this.BtnEXCEL.TabIndex = 5;
            this.BtnEXCEL.Text = "导入EXCEL";
            this.BtnEXCEL.UseVisualStyleBackColor = true;
            this.BtnEXCEL.Visible = false;
            this.BtnEXCEL.Click += new System.EventHandler(this.BtnEXCEL_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "日期";
            // 
            // DTdatetime
            // 
            this.DTdatetime.Location = new System.Drawing.Point(210, 13);
            this.DTdatetime.Name = "DTdatetime";
            this.DTdatetime.Size = new System.Drawing.Size(122, 21);
            this.DTdatetime.TabIndex = 3;
            // 
            // CmdShop
            // 
            this.CmdShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Location = new System.Drawing.Point(48, 13);
            this.CmdShop.Name = "CmdShop";
            this.CmdShop.Size = new System.Drawing.Size(121, 20);
            this.CmdShop.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "店铺：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 475);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 40);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(10, 17);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 12);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "label3";
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 515);
            this.Controls.Add(this.DataDGV);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单导入";
            this.Load += new System.EventHandler(this.OrderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnEXCEL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTdatetime;
        private System.Windows.Forms.ComboBox CmdShop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Btndelete;
    }
}