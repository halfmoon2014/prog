namespace Merrto
{
    partial class WphDistribution
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
            this.Cmbstorange = new System.Windows.Forms.ComboBox();
            this.CmbSpecial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnBrow = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DTTDATE = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.DistriButionDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DistriButionDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Cmbstorange
            // 
            this.Cmbstorange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmbstorange.FormattingEnabled = true;
            this.Cmbstorange.Location = new System.Drawing.Point(244, 14);
            this.Cmbstorange.Name = "Cmbstorange";
            this.Cmbstorange.Size = new System.Drawing.Size(124, 20);
            this.Cmbstorange.TabIndex = 0;
            // 
            // CmbSpecial
            // 
            this.CmbSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSpecial.FormattingEnabled = true;
            this.CmbSpecial.Location = new System.Drawing.Point(49, 13);
            this.CmbSpecial.Name = "CmbSpecial";
            this.CmbSpecial.Size = new System.Drawing.Size(154, 20);
            this.CmbSpecial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "专场：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "仓库：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmbSpecial);
            this.groupBox1.Controls.Add(this.Cmbstorange);
            this.groupBox1.Controls.Add(this.BtnBrow);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 43);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // BtnBrow
            // 
            this.BtnBrow.Location = new System.Drawing.Point(374, 12);
            this.BtnBrow.Name = "BtnBrow";
            this.BtnBrow.Size = new System.Drawing.Size(75, 23);
            this.BtnBrow.TabIndex = 4;
            this.BtnBrow.Text = "导入";
            this.BtnBrow.UseVisualStyleBackColor = true;
            this.BtnBrow.Click += new System.EventHandler(this.BtnBrow_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.DTTDATE);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(0, 483);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(864, 52);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // DTTDATE
            // 
            this.DTTDATE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DTTDATE.Location = new System.Drawing.Point(657, 20);
            this.DTTDATE.Name = "DTTDATE";
            this.DTTDATE.Size = new System.Drawing.Size(110, 21);
            this.DTTDATE.TabIndex = 26;
            this.DTTDATE.Value = new System.DateTime(2014, 4, 25, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "日    期:";
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(777, 12);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 37);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // DistriButionDGV
            // 
            this.DistriButionDGV.AllowUserToAddRows = false;
            this.DistriButionDGV.AllowUserToDeleteRows = false;
            this.DistriButionDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DistriButionDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DistriButionDGV.Location = new System.Drawing.Point(0, 43);
            this.DistriButionDGV.Name = "DistriButionDGV";
            this.DistriButionDGV.RowTemplate.Height = 23;
            this.DistriButionDGV.Size = new System.Drawing.Size(864, 440);
            this.DistriButionDGV.TabIndex = 7;
            // 
            // WphDistribution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 535);
            this.Controls.Add(this.DistriButionDGV);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WphDistribution";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "唯品会配货";
            this.Load += new System.EventHandler(this.WphDistribution_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DistriButionDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmbstorange;
        private System.Windows.Forms.ComboBox CmbSpecial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnBrow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.DataGridView DistriButionDGV;
        private System.Windows.Forms.DateTimePicker DTTDATE;
        private System.Windows.Forms.Label label3;
    }
}