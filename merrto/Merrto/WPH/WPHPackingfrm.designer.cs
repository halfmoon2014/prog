namespace Merrto.WPH
{
    partial class WPHPackingfrm
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
            this.DistriButionDGV = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkLast = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPackintBarCode = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CmbSpecial = new System.Windows.Forms.ComboBox();
            this.Cmbstorange = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TXTPackNO = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtOneNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtAddre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DTDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnBrow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DistriButionDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DistriButionDGV
            // 
            this.DistriButionDGV.AllowUserToAddRows = false;
            this.DistriButionDGV.AllowUserToDeleteRows = false;
            this.DistriButionDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DistriButionDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DistriButionDGV.Location = new System.Drawing.Point(0, 56);
            this.DistriButionDGV.Name = "DistriButionDGV";
            this.DistriButionDGV.RowTemplate.Height = 23;
            this.DistriButionDGV.Size = new System.Drawing.Size(922, 573);
            this.DistriButionDGV.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkLast);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnPackintBarCode);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(0, 629);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(922, 52);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // chkLast
            // 
            this.chkLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLast.AutoSize = true;
            this.chkLast.Location = new System.Drawing.Point(602, 22);
            this.chkLast.Name = "chkLast";
            this.chkLast.Size = new System.Drawing.Size(96, 16);
            this.chkLast.TabIndex = 17;
            this.chkLast.Text = "最后一箱保存";
            this.chkLast.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(704, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "预览";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnPackintBarCode
            // 
            this.btnPackintBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPackintBarCode.Location = new System.Drawing.Point(824, 9);
            this.btnPackintBarCode.Name = "btnPackintBarCode";
            this.btnPackintBarCode.Size = new System.Drawing.Size(94, 40);
            this.btnPackintBarCode.TabIndex = 15;
            this.btnPackintBarCode.Text = "打印装箱条码";
            this.btnPackintBarCode.UseVisualStyleBackColor = true;
            this.btnPackintBarCode.Click += new System.EventHandler(this.btnPackintBarCode_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(748, 9);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 40);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.BtnBrow);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 56);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CmbSpecial);
            this.groupBox4.Controls.Add(this.Cmbstorange);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(7, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 43);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "条件";
            // 
            // CmbSpecial
            // 
            this.CmbSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSpecial.FormattingEnabled = true;
            this.CmbSpecial.Location = new System.Drawing.Point(50, 16);
            this.CmbSpecial.Name = "CmbSpecial";
            this.CmbSpecial.Size = new System.Drawing.Size(154, 20);
            this.CmbSpecial.TabIndex = 5;
            // 
            // Cmbstorange
            // 
            this.Cmbstorange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmbstorange.FormattingEnabled = true;
            this.Cmbstorange.Location = new System.Drawing.Point(245, 16);
            this.Cmbstorange.Name = "Cmbstorange";
            this.Cmbstorange.Size = new System.Drawing.Size(124, 20);
            this.Cmbstorange.TabIndex = 4;
            this.Cmbstorange.SelectedValueChanged += new System.EventHandler(this.Cmbstorange_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "专场：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "仓库：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TXTPackNO);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.TxtOneNo);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.TxtAddre);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.DTDate);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(395, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 43);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参数";
            // 
            // TXTPackNO
            // 
            this.TXTPackNO.Location = new System.Drawing.Point(375, 13);
            this.TXTPackNO.Name = "TXTPackNO";
            this.TXTPackNO.Size = new System.Drawing.Size(26, 21);
            this.TXTPackNO.TabIndex = 35;
            this.TXTPackNO.Text = "12";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(404, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = "双";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "每箱装";
            // 
            // TxtOneNo
            // 
            this.TxtOneNo.Location = new System.Drawing.Point(286, 13);
            this.TxtOneNo.Name = "TxtOneNo";
            this.TxtOneNo.Size = new System.Drawing.Size(35, 21);
            this.TxtOneNo.TabIndex = 32;
            this.TxtOneNo.Text = "0110";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(227, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 31;
            this.label10.Text = "起始箱号:";
            // 
            // TxtAddre
            // 
            this.TxtAddre.Location = new System.Drawing.Point(187, 13);
            this.TxtAddre.Name = "TxtAddre";
            this.TxtAddre.Size = new System.Drawing.Size(35, 21);
            this.TxtAddre.TabIndex = 28;
            this.TxtAddre.Text = "BJ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(155, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "地址:";
            // 
            // DTDate
            // 
            this.DTDate.Location = new System.Drawing.Point(37, 13);
            this.DTDate.Name = "DTDate";
            this.DTDate.Size = new System.Drawing.Size(110, 21);
            this.DTDate.TabIndex = 26;
            this.DTDate.Value = new System.DateTime(2014, 4, 25, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "日期:";
            // 
            // BtnBrow
            // 
            this.BtnBrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBrow.Location = new System.Drawing.Point(841, 12);
            this.BtnBrow.Name = "BtnBrow";
            this.BtnBrow.Size = new System.Drawing.Size(75, 38);
            this.BtnBrow.TabIndex = 4;
            this.BtnBrow.Text = "导入";
            this.BtnBrow.UseVisualStyleBackColor = true;
            this.BtnBrow.Click += new System.EventHandler(this.BtnBrow_Click);
            // 
            // WPHPackingfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 681);
            this.Controls.Add(this.DistriButionDGV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WPHPackingfrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "唯品会装箱";
            this.Load += new System.EventHandler(this.WPHPackingfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DistriButionDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DistriButionDGV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnBrow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPackintBarCode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox CmbSpecial;
        private System.Windows.Forms.ComboBox Cmbstorange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TXTPackNO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtOneNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtAddre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker DTDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkLast;
    }
}