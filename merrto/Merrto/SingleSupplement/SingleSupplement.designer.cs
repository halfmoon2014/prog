namespace Merrto.SingleSupplement
{
    partial class SingleSupplement
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DataDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTNOS = new System.Windows.Forms.TextBox();
            this.btnzcm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpaths = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataDGV2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtNOs2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtZzDay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtyjDay = new System.Windows.Forms.TextBox();
            this.BtnExcel2 = new System.Windows.Forms.Button();
            this.BtnDate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TXTEXCEL = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(902, 608);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DataDGV);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(894, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "预警计算1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DataDGV
            // 
            this.DataDGV.AllowUserToAddRows = false;
            this.DataDGV.AllowUserToDeleteRows = false;
            this.DataDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataDGV.Location = new System.Drawing.Point(3, 50);
            this.DataDGV.Name = "DataDGV";
            this.DataDGV.ReadOnly = true;
            this.DataDGV.RowTemplate.Height = 23;
            this.DataDGV.Size = new System.Drawing.Size(888, 530);
            this.DataDGV.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnExcel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TXTNOS);
            this.groupBox1.Controls.Add(this.btnzcm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtpaths);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 47);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // BtnExcel
            // 
            this.BtnExcel.BackColor = System.Drawing.Color.Transparent;
            this.BtnExcel.Location = new System.Drawing.Point(806, 12);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Size = new System.Drawing.Size(75, 29);
            this.BtnExcel.TabIndex = 24;
            this.BtnExcel.Text = "导出Excel";
            this.BtnExcel.UseVisualStyleBackColor = false;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(491, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "唯品会总数";
            // 
            // TXTNOS
            // 
            this.TXTNOS.Location = new System.Drawing.Point(556, 17);
            this.TXTNOS.Name = "TXTNOS";
            this.TXTNOS.Size = new System.Drawing.Size(69, 21);
            this.TXTNOS.TabIndex = 22;
            // 
            // btnzcm
            // 
            this.btnzcm.BackColor = System.Drawing.Color.Transparent;
            this.btnzcm.Location = new System.Drawing.Point(729, 12);
            this.btnzcm.Name = "btnzcm";
            this.btnzcm.Size = new System.Drawing.Size(75, 29);
            this.btnzcm.TabIndex = 21;
            this.btnzcm.Text = "数据处理";
            this.btnzcm.UseVisualStyleBackColor = false;
            this.btnzcm.Click += new System.EventHandler(this.btnzcm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "Excel路径";
            // 
            // txtpaths
            // 
            this.txtpaths.Location = new System.Drawing.Point(71, 17);
            this.txtpaths.Name = "txtpaths";
            this.txtpaths.Size = new System.Drawing.Size(413, 21);
            this.txtpaths.TabIndex = 19;
            this.txtpaths.DoubleClick += new System.EventHandler(this.txtpaths_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DataDGV2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 583);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "预警计算2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DataDGV2
            // 
            this.DataDGV2.AllowUserToAddRows = false;
            this.DataDGV2.AllowUserToDeleteRows = false;
            this.DataDGV2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataDGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataDGV2.Location = new System.Drawing.Point(3, 50);
            this.DataDGV2.Name = "DataDGV2";
            this.DataDGV2.ReadOnly = true;
            this.DataDGV2.RowTemplate.Height = 23;
            this.DataDGV2.Size = new System.Drawing.Size(888, 530);
            this.DataDGV2.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtNOs2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtZzDay);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TxtyjDay);
            this.groupBox2.Controls.Add(this.BtnExcel2);
            this.groupBox2.Controls.Add(this.BtnDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TXTEXCEL);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(888, 47);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "下单数量";
            // 
            // TxtNOs2
            // 
            this.TxtNOs2.Location = new System.Drawing.Point(454, 16);
            this.TxtNOs2.Name = "TxtNOs2";
            this.TxtNOs2.Size = new System.Drawing.Size(53, 21);
            this.TxtNOs2.TabIndex = 29;
            this.TxtNOs2.Text = "300";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(618, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "在制天数";
            // 
            // TxtZzDay
            // 
            this.TxtZzDay.Location = new System.Drawing.Point(672, 15);
            this.TxtZzDay.Name = "TxtZzDay";
            this.TxtZzDay.Size = new System.Drawing.Size(53, 21);
            this.TxtZzDay.TabIndex = 27;
            this.TxtZzDay.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "预警天数";
            // 
            // TxtyjDay
            // 
            this.TxtyjDay.Location = new System.Drawing.Point(563, 17);
            this.TxtyjDay.Name = "TxtyjDay";
            this.TxtyjDay.Size = new System.Drawing.Size(53, 21);
            this.TxtyjDay.TabIndex = 25;
            this.TxtyjDay.Text = "30";
            // 
            // BtnExcel2
            // 
            this.BtnExcel2.BackColor = System.Drawing.Color.Transparent;
            this.BtnExcel2.Location = new System.Drawing.Point(807, 12);
            this.BtnExcel2.Name = "BtnExcel2";
            this.BtnExcel2.Size = new System.Drawing.Size(75, 29);
            this.BtnExcel2.TabIndex = 24;
            this.BtnExcel2.Text = "导出Excel";
            this.BtnExcel2.UseVisualStyleBackColor = false;
            this.BtnExcel2.Click += new System.EventHandler(this.BtnExcel2_Click);
            // 
            // BtnDate
            // 
            this.BtnDate.BackColor = System.Drawing.Color.Transparent;
            this.BtnDate.Location = new System.Drawing.Point(730, 11);
            this.BtnDate.Name = "BtnDate";
            this.BtnDate.Size = new System.Drawing.Size(75, 29);
            this.BtnDate.TabIndex = 21;
            this.BtnDate.Text = "数据处理";
            this.BtnDate.UseVisualStyleBackColor = false;
            this.BtnDate.Click += new System.EventHandler(this.BtnDate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "Excel路径";
            // 
            // TXTEXCEL
            // 
            this.TXTEXCEL.Location = new System.Drawing.Point(71, 17);
            this.TXTEXCEL.Name = "TXTEXCEL";
            this.TXTEXCEL.Size = new System.Drawing.Size(327, 21);
            this.TXTEXCEL.TabIndex = 19;
            this.TXTEXCEL.DoubleClick += new System.EventHandler(this.TXTEXCEL_DoubleClick);
            // 
            // SingleSupplement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 608);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SingleSupplement";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库存动态管理";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DataDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTNOS;
        private System.Windows.Forms.Button btnzcm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpaths;
        private System.Windows.Forms.Button BtnExcel;
        private System.Windows.Forms.DataGridView DataDGV2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtZzDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtyjDay;
        private System.Windows.Forms.Button BtnExcel2;
        private System.Windows.Forms.Button BtnDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXTEXCEL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtNOs2;
    }
}