namespace Merrto.WPH
{
    partial class WPHBarCodeUpdate
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Btnlook = new System.Windows.Forms.Button();
            this.BtnToVoid = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TXTBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnupEXcel = new System.Windows.Forms.Button();
            this.cmbSpecial = new System.Windows.Forms.ComboBox();
            this.BTNbROW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WPHbROWDGV
            // 
            this.WPHbROWDGV.AllowUserToAddRows = false;
            this.WPHbROWDGV.AllowUserToDeleteRows = false;
            this.WPHbROWDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WPHbROWDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 74);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(1001, 370);
            this.WPHbROWDGV.TabIndex = 21;
            this.WPHbROWDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WPHbROWDGV_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSelect);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.Btnlook);
            this.groupBox2.Controls.Add(this.BtnToVoid);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox2.Location = new System.Drawing.Point(0, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1001, 38);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // BtnSelect
            // 
            this.BtnSelect.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnSelect.Location = new System.Drawing.Point(83, 5);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(75, 32);
            this.BtnSelect.TabIndex = 18;
            this.BtnSelect.Text = "查看";
            this.BtnSelect.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10F);
            this.button1.Location = new System.Drawing.Point(318, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 17;
            this.button1.Text = "反审";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btnlook
            // 
            this.Btnlook.Font = new System.Drawing.Font("宋体", 10F);
            this.Btnlook.Location = new System.Drawing.Point(239, 5);
            this.Btnlook.Name = "Btnlook";
            this.Btnlook.Size = new System.Drawing.Size(75, 32);
            this.Btnlook.TabIndex = 16;
            this.Btnlook.Text = "审核";
            this.Btnlook.UseVisualStyleBackColor = true;
            this.Btnlook.Click += new System.EventHandler(this.Btnlook_Click);
            // 
            // BtnToVoid
            // 
            this.BtnToVoid.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnToVoid.Location = new System.Drawing.Point(161, 5);
            this.BtnToVoid.Name = "BtnToVoid";
            this.BtnToVoid.Size = new System.Drawing.Size(75, 32);
            this.BtnToVoid.TabIndex = 15;
            this.BtnToVoid.Text = "作废";
            this.BtnToVoid.UseVisualStyleBackColor = true;
            this.BtnToVoid.Click += new System.EventHandler(this.BtnToVoid_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnSave.Location = new System.Drawing.Point(5, 5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 32);
            this.BtnSave.TabIndex = 13;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TXTBarCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnupEXcel);
            this.groupBox1.Controls.Add(this.cmbSpecial);
            this.groupBox1.Controls.Add(this.BTNbROW);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 36);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // TXTBarCode
            // 
            this.TXTBarCode.Font = new System.Drawing.Font("宋体", 10F);
            this.TXTBarCode.Location = new System.Drawing.Point(288, 6);
            this.TXTBarCode.Name = "TXTBarCode";
            this.TXTBarCode.Size = new System.Drawing.Size(146, 23);
            this.TXTBarCode.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(250, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 29;
            this.label2.Text = "条码：";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("华文新魏", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.ForeColor = System.Drawing.Color.Red;
            this.lblType.Location = new System.Drawing.Point(667, 5);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(0, 27);
            this.lblType.TabIndex = 28;
            // 
            // TxtCade
            // 
            this.TxtCade.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtCade.Location = new System.Drawing.Point(51, 6);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(188, 23);
            this.TxtCade.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "箱号：";
            // 
            // btnupEXcel
            // 
            this.btnupEXcel.Font = new System.Drawing.Font("宋体", 10F);
            this.btnupEXcel.Location = new System.Drawing.Point(813, 6);
            this.btnupEXcel.Name = "btnupEXcel";
            this.btnupEXcel.Size = new System.Drawing.Size(88, 25);
            this.btnupEXcel.TabIndex = 16;
            this.btnupEXcel.Text = "导出EXCEL";
            this.btnupEXcel.UseVisualStyleBackColor = true;
            this.btnupEXcel.Visible = false;
            // 
            // cmbSpecial
            // 
            this.cmbSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecial.Font = new System.Drawing.Font("宋体", 10F);
            this.cmbSpecial.FormattingEnabled = true;
            this.cmbSpecial.Location = new System.Drawing.Point(477, 9);
            this.cmbSpecial.Name = "cmbSpecial";
            this.cmbSpecial.Size = new System.Drawing.Size(184, 21);
            this.cmbSpecial.TabIndex = 8;
            // 
            // BTNbROW
            // 
            this.BTNbROW.Font = new System.Drawing.Font("宋体", 10F);
            this.BTNbROW.Location = new System.Drawing.Point(735, 6);
            this.BTNbROW.Name = "BTNbROW";
            this.BTNbROW.Size = new System.Drawing.Size(75, 25);
            this.BTNbROW.TabIndex = 12;
            this.BTNbROW.Text = "查询";
            this.BTNbROW.UseVisualStyleBackColor = true;
            this.BTNbROW.Click += new System.EventHandler(this.BTNbROW_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(440, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "专场：";
            // 
            // WPHBarCodeUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 444);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WPHBarCodeUpdate";
            this.Text = "WPHBarCodeUpdate";
            this.Load += new System.EventHandler(this.WPHBarCodeUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btnlook;
        private System.Windows.Forms.Button BtnToVoid;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnupEXcel;
        private System.Windows.Forms.ComboBox cmbSpecial;
        private System.Windows.Forms.Button BTNbROW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTBarCode;
        private System.Windows.Forms.Label label2;

    }
}