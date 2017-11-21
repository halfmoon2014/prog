namespace Merrto.WPH
{
    partial class WTRBarCode
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
            this.TxtPono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnupEXcel = new System.Windows.Forms.Button();
            this.CmbVerify = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BTNbROW = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WPHbROWDGV
            // 
            this.WPHbROWDGV.AllowUserToAddRows = false;
            this.WPHbROWDGV.AllowUserToDeleteRows = false;
            this.WPHbROWDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WPHbROWDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 47);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.ReadOnly = true;
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(813, 579);
            this.WPHbROWDGV.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtPono);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnupEXcel);
            this.groupBox1.Controls.Add(this.CmbVerify);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 47);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // TxtPono
            // 
            this.TxtPono.Location = new System.Drawing.Point(280, 14);
            this.TxtPono.Name = "TxtPono";
            this.TxtPono.Size = new System.Drawing.Size(146, 21);
            this.TxtPono.TabIndex = 20;
            this.TxtPono.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "箱号：";
            this.label2.Visible = false;
            // 
            // TxtCade
            // 
            this.TxtCade.Location = new System.Drawing.Point(61, 14);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(146, 21);
            this.TxtCade.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "箱号：";
            // 
            // btnupEXcel
            // 
            this.btnupEXcel.Location = new System.Drawing.Point(638, 12);
            this.btnupEXcel.Name = "btnupEXcel";
            this.btnupEXcel.Size = new System.Drawing.Size(88, 25);
            this.btnupEXcel.TabIndex = 16;
            this.btnupEXcel.Text = "导出EXCEL";
            this.btnupEXcel.UseVisualStyleBackColor = true;
            this.btnupEXcel.Click += new System.EventHandler(this.btnupEXcel_Click);
            // 
            // CmbVerify
            // 
            this.CmbVerify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbVerify.FormattingEnabled = true;
            this.CmbVerify.Items.AddRange(new object[] {
            "已校验",
            "未校验",
            "全部"});
            this.CmbVerify.Location = new System.Drawing.Point(470, 14);
            this.CmbVerify.Name = "CmbVerify";
            this.CmbVerify.Size = new System.Drawing.Size(82, 20);
            this.CmbVerify.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "校验：";
            // 
            // BTNbROW
            // 
            this.BTNbROW.Location = new System.Drawing.Point(557, 12);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 25);
            this.BTNbROW.TabIndex = 12;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // WTRBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 626);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WTRBarCode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "退货检验查询";
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnupEXcel;
        private System.Windows.Forms.ComboBox CmbVerify;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.TextBox TxtPono;
        private System.Windows.Forms.Label label2;
    }
}