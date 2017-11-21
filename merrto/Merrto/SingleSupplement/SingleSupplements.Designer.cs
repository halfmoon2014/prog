namespace Merrto.SingleSupplement
{
    partial class SingleSupplements
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
            this.DataDGV2 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TXTItem = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DTPStop = new System.Windows.Forms.DateTimePicker();
            this.DTPStart = new System.Windows.Forms.DateTimePicker();
            this.BtnTheSalesRate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtZzDay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtyjDay = new System.Windows.Forms.TextBox();
            this.BtnExcel2 = new System.Windows.Forms.Button();
            this.BtnDate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataDGV2
            // 
            this.DataDGV2.AllowUserToAddRows = false;
            this.DataDGV2.AllowUserToDeleteRows = false;
            this.DataDGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataDGV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataDGV2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DataDGV2.Location = new System.Drawing.Point(0, 65);
            this.DataDGV2.Name = "DataDGV2";
            this.DataDGV2.RowTemplate.Height = 23;
            this.DataDGV2.Size = new System.Drawing.Size(910, 490);
            this.DataDGV2.TabIndex = 23;
            this.DataDGV2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataDGV2_CellEndEdit);
            this.DataDGV2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataDGV2_DataBindingComplete);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TXTItem);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.DTPStop);
            this.groupBox2.Controls.Add(this.DTPStart);
            this.groupBox2.Controls.Add(this.BtnTheSalesRate);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TxtZzDay);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TxtyjDay);
            this.groupBox2.Controls.Add(this.BtnExcel2);
            this.groupBox2.Controls.Add(this.BtnDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 65);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // TXTItem
            // 
            this.TXTItem.Font = new System.Drawing.Font("宋体", 10F);
            this.TXTItem.Location = new System.Drawing.Point(47, 7);
            this.TXTItem.Multiline = true;
            this.TXTItem.Name = "TXTItem";
            this.TXTItem.Size = new System.Drawing.Size(130, 52);
            this.TXTItem.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.Location = new System.Drawing.Point(367, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 35;
            this.label7.Text = "终止日期";
            // 
            // DTPStop
            // 
            this.DTPStop.Font = new System.Drawing.Font("宋体", 10F);
            this.DTPStop.Location = new System.Drawing.Point(432, 10);
            this.DTPStop.Name = "DTPStop";
            this.DTPStop.Size = new System.Drawing.Size(125, 23);
            this.DTPStop.TabIndex = 31;
            // 
            // DTPStart
            // 
            this.DTPStart.Font = new System.Drawing.Font("宋体", 10F);
            this.DTPStart.Location = new System.Drawing.Point(246, 10);
            this.DTPStart.Name = "DTPStart";
            this.DTPStart.Size = new System.Drawing.Size(119, 23);
            this.DTPStart.TabIndex = 30;
            // 
            // BtnTheSalesRate
            // 
            this.BtnTheSalesRate.BackColor = System.Drawing.Color.Transparent;
            this.BtnTheSalesRate.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnTheSalesRate.Location = new System.Drawing.Point(445, 36);
            this.BtnTheSalesRate.Name = "BtnTheSalesRate";
            this.BtnTheSalesRate.Size = new System.Drawing.Size(104, 24);
            this.BtnTheSalesRate.TabIndex = 29;
            this.BtnTheSalesRate.Text = "销售速度";
            this.BtnTheSalesRate.UseVisualStyleBackColor = false;
            this.BtnTheSalesRate.Visible = false;
            //this.BtnTheSalesRate.Click += new System.EventHandler(this.BtnTheSalesRate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(322, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 28;
            this.label5.Text = "备货天数";
            // 
            // TxtZzDay
            // 
            this.TxtZzDay.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtZzDay.Location = new System.Drawing.Point(387, 37);
            this.TxtZzDay.Name = "TxtZzDay";
            this.TxtZzDay.Size = new System.Drawing.Size(53, 23);
            this.TxtZzDay.TabIndex = 27;
            this.TxtZzDay.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(193, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "预警天数";
            // 
            // TxtyjDay
            // 
            this.TxtyjDay.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtyjDay.Location = new System.Drawing.Point(259, 38);
            this.TxtyjDay.Name = "TxtyjDay";
            this.TxtyjDay.Size = new System.Drawing.Size(53, 23);
            this.TxtyjDay.TabIndex = 25;
            this.TxtyjDay.Text = "30";
            // 
            // BtnExcel2
            // 
            this.BtnExcel2.BackColor = System.Drawing.Color.Transparent;
            this.BtnExcel2.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnExcel2.Location = new System.Drawing.Point(638, 5);
            this.BtnExcel2.Name = "BtnExcel2";
            this.BtnExcel2.Size = new System.Drawing.Size(102, 56);
            this.BtnExcel2.TabIndex = 24;
            this.BtnExcel2.Text = "导出Excel";
            this.BtnExcel2.UseVisualStyleBackColor = false;
            this.BtnExcel2.Click += new System.EventHandler(this.BtnExcel2_Click);
            // 
            // BtnDate
            // 
            this.BtnDate.BackColor = System.Drawing.Color.Transparent;
            this.BtnDate.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnDate.Location = new System.Drawing.Point(559, 6);
            this.BtnDate.Name = "BtnDate";
            this.BtnDate.Size = new System.Drawing.Size(75, 56);
            this.BtnDate.TabIndex = 21;
            this.BtnDate.Text = "数据处理";
            this.BtnDate.UseVisualStyleBackColor = false;
            this.BtnDate.Click += new System.EventHandler(this.BtnDate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 37;
            this.label1.Text = "款号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(184, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 34;
            this.label4.Text = "起始日期";
            // 
            // SingleSupplements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 555);
            this.Controls.Add(this.DataDGV2);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SingleSupplements";
            this.Text = "SingleSupplements";
            this.Load += new System.EventHandler(this.SingleSupplements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataDGV2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataDGV2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTPStop;
        private System.Windows.Forms.DateTimePicker DTPStart;
        private System.Windows.Forms.Button BtnTheSalesRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtZzDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtyjDay;
        private System.Windows.Forms.Button BtnExcel2;
        private System.Windows.Forms.Button BtnDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TXTItem;

    }
}