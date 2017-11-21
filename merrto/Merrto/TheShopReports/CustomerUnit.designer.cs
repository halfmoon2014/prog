namespace Merrto.TheShopReports
{
    partial class CustomerUnit
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
            this.label1 = new System.Windows.Forms.Label();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.DTdatetime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnEXCEL = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomerDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "店铺：";
            // 
            // CmdShop
            // 
            this.CmdShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Location = new System.Drawing.Point(82, 13);
            this.CmdShop.Name = "CmdShop";
            this.CmdShop.Size = new System.Drawing.Size(121, 20);
            this.CmdShop.TabIndex = 2;
            // 
            // DTdatetime
            // 
            this.DTdatetime.Location = new System.Drawing.Point(268, 13);
            this.DTdatetime.Name = "DTdatetime";
            this.DTdatetime.Size = new System.Drawing.Size(122, 21);
            this.DTdatetime.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.BtnEXCEL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTdatetime);
            this.groupBox1.Controls.Add(this.CmdShop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(821, 41);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(485, 12);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnEXCEL
            // 
            this.BtnEXCEL.Location = new System.Drawing.Point(406, 12);
            this.BtnEXCEL.Name = "BtnEXCEL";
            this.BtnEXCEL.Size = new System.Drawing.Size(75, 23);
            this.BtnEXCEL.TabIndex = 5;
            this.BtnEXCEL.Text = "导入EXCEL";
            this.BtnEXCEL.UseVisualStyleBackColor = true;
            this.BtnEXCEL.Click += new System.EventHandler(this.BtnEXCEL_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "日期";
            // 
            // CustomerDGV
            // 
            this.CustomerDGV.AllowUserToAddRows = false;
            this.CustomerDGV.AllowUserToDeleteRows = false;
            this.CustomerDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomerDGV.Location = new System.Drawing.Point(0, 41);
            this.CustomerDGV.Name = "CustomerDGV";
            this.CustomerDGV.ReadOnly = true;
            this.CustomerDGV.RowTemplate.Height = 23;
            this.CustomerDGV.Size = new System.Drawing.Size(821, 536);
            this.CustomerDGV.TabIndex = 5;
            // 
            // CustomerUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 577);
            this.Controls.Add(this.CustomerDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerUnit";
            this.Text = "CustomerUnit";
            this.Load += new System.EventHandler(this.CustomerUnit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmdShop;
        private System.Windows.Forms.DateTimePicker DTdatetime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnEXCEL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView CustomerDGV;
    }
}