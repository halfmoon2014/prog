namespace Merrto.SingleSupplement
{
    partial class DateStorage
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
            this.BtnKIS = new System.Windows.Forms.Button();
            this.DTPCade = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnERP = new System.Windows.Forms.Button();
            this.DGVData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTNSave = new System.Windows.Forms.Button();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnKIS
            // 
            this.BtnKIS.Location = new System.Drawing.Point(12, 45);
            this.BtnKIS.Name = "BtnKIS";
            this.BtnKIS.Size = new System.Drawing.Size(109, 33);
            this.BtnKIS.TabIndex = 0;
            this.BtnKIS.Text = "金蝶库存";
            this.BtnKIS.UseVisualStyleBackColor = true;
            this.BtnKIS.Click += new System.EventHandler(this.BtnKIS_Click);
            // 
            // DTPCade
            // 
            this.DTPCade.Location = new System.Drawing.Point(219, 18);
            this.DTPCade.Name = "DTPCade";
            this.DTPCade.Size = new System.Drawing.Size(129, 21);
            this.DTPCade.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "日期";
            // 
            // BtnERP
            // 
            this.BtnERP.Location = new System.Drawing.Point(125, 45);
            this.BtnERP.Name = "BtnERP";
            this.BtnERP.Size = new System.Drawing.Size(109, 33);
            this.BtnERP.TabIndex = 3;
            this.BtnERP.Text = "ERP库存";
            this.BtnERP.UseVisualStyleBackColor = true;
            this.BtnERP.Click += new System.EventHandler(this.BtnERP_Click);
            // 
            // DGVData
            // 
            this.DGVData.AllowUserToAddRows = false;
            this.DGVData.AllowUserToDeleteRows = false;
            this.DGVData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVData.Location = new System.Drawing.Point(0, 87);
            this.DGVData.Name = "DGVData";
            this.DGVData.ReadOnly = true;
            this.DGVData.RowTemplate.Height = 23;
            this.DGVData.Size = new System.Drawing.Size(821, 404);
            this.DGVData.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.BTNSave);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnKIS);
            this.groupBox1.Controls.Add(this.BtnERP);
            this.groupBox1.Controls.Add(this.DTPCade);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(821, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // BTNSave
            // 
            this.BTNSave.Location = new System.Drawing.Point(238, 45);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(109, 33);
            this.BTNSave.TabIndex = 4;
            this.BTNSave.Text = "保存";
            this.BTNSave.UseVisualStyleBackColor = true;
            this.BTNSave.Click += new System.EventHandler(this.BTNSave_Click);
            // 
            // TxtCade
            // 
            this.TxtCade.Location = new System.Drawing.Point(43, 18);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(129, 21);
            this.TxtCade.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "款号";
            // 
            // DateStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 491);
            this.Controls.Add(this.DGVData);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DateStorage";
            this.Text = "DateStorage";
            this.Load += new System.EventHandler(this.DateStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnKIS;
        private System.Windows.Forms.DateTimePicker DTPCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnERP;
        private System.Windows.Forms.DataGridView DGVData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCade;
    }
}