namespace Merrto.SingleSupplement
{
    partial class ActivityFrm
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
            this.lblType = new System.Windows.Forms.Label();
            this.DTStop = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNbROW = new System.Windows.Forms.Button();
            this.GpbBtn = new System.Windows.Forms.GroupBox();
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
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 87);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.ReadOnly = true;
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(949, 453);
            this.WPHbROWDGV.TabIndex = 21;
            this.WPHbROWDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WPHbROWDGV_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.DTStop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DTPOrderDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 57);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("隶书", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.ForeColor = System.Drawing.Color.Red;
            this.lblType.Location = new System.Drawing.Point(238, 6);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 20);
            this.lblType.TabIndex = 28;
            // 
            // DTStop
            // 
            this.DTStop.Font = new System.Drawing.Font("宋体", 10F);
            this.DTStop.Location = new System.Drawing.Point(275, 32);
            this.DTStop.Name = "DTStop";
            this.DTStop.Size = new System.Drawing.Size(134, 23);
            this.DTStop.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(214, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "终止时间：";
            // 
            // DTPOrderDate
            // 
            this.DTPOrderDate.Font = new System.Drawing.Font("宋体", 10F);
            this.DTPOrderDate.Location = new System.Drawing.Point(73, 32);
            this.DTPOrderDate.Name = "DTPOrderDate";
            this.DTPOrderDate.Size = new System.Drawing.Size(134, 23);
            this.DTPOrderDate.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "起始时间：";
            // 
            // TxtCade
            // 
            this.TxtCade.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtCade.Location = new System.Drawing.Point(73, 2);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(130, 23);
            this.TxtCade.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(20, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "单据号：";
            // 
            // BTNbROW
            // 
            this.BTNbROW.Font = new System.Drawing.Font("宋体", 10F);
            this.BTNbROW.Location = new System.Drawing.Point(415, 3);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 51);
            this.BTNbROW.TabIndex = 12;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // GpbBtn
            // 
            this.GpbBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.GpbBtn.Font = new System.Drawing.Font("宋体", 1F);
            this.GpbBtn.Location = new System.Drawing.Point(0, 57);
            this.GpbBtn.Name = "GpbBtn";
            this.GpbBtn.Size = new System.Drawing.Size(949, 30);
            this.GpbBtn.TabIndex = 24;
            this.GpbBtn.TabStop = false;
            // 
            // ActivityFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 540);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.GpbBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActivityFrm";
            this.Text = "ActivityFrm";
            this.Load += new System.EventHandler(this.ActivityFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.DateTimePicker DTStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPOrderDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.GroupBox GpbBtn;
    }
}