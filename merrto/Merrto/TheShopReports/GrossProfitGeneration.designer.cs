namespace Merrto.TheShopReports
{
    partial class GrossProfitGeneration
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnBBDelete = new System.Windows.Forms.Button();
            this.CmdShop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DTPStop = new System.Windows.Forms.DateTimePicker();
            this.DTPStart = new System.Windows.Forms.DateTimePicker();
            this.DTPCadeDate = new System.Windows.Forms.DateTimePicker();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnYbbDelete = new System.Windows.Forms.Button();
            this.CboYshop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpActualStop = new System.Windows.Forms.DateTimePicker();
            this.DtpActualStart = new System.Windows.Forms.DateTimePicker();
            this.DtpActualCadeDate = new System.Windows.Forms.DateTimePicker();
            this.BtnYSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnYjblDelete = new System.Windows.Forms.Button();
            this.BtnYjblCreate = new System.Windows.Forms.Button();
            this.BtnSjblDelete = new System.Windows.Forms.Button();
            this.BtnSjBlCreate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnYjblDelete);
            this.groupBox1.Controls.Add(this.BtnYjblCreate);
            this.groupBox1.Controls.Add(this.BtnBBDelete);
            this.groupBox1.Controls.Add(this.CmdShop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DTPStop);
            this.groupBox1.Controls.Add(this.DTPStart);
            this.groupBox1.Controls.Add(this.DTPCadeDate);
            this.groupBox1.Controls.Add(this.BtnCreate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 209);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预际报表生成";
            // 
            // BtnBBDelete
            // 
            this.BtnBBDelete.Location = new System.Drawing.Point(116, 167);
            this.BtnBBDelete.Name = "BtnBBDelete";
            this.BtnBBDelete.Size = new System.Drawing.Size(75, 31);
            this.BtnBBDelete.TabIndex = 9;
            this.BtnBBDelete.Text = "删除报表";
            this.BtnBBDelete.UseVisualStyleBackColor = true;
            this.BtnBBDelete.Click += new System.EventHandler(this.BtnBBDelete_Click);
            // 
            // CmdShop
            // 
            this.CmdShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdShop.FormattingEnabled = true;
            this.CmdShop.Location = new System.Drawing.Point(76, 51);
            this.CmdShop.Name = "CmdShop";
            this.CmdShop.Size = new System.Drawing.Size(155, 20);
            this.CmdShop.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "店    铺：";
            // 
            // DTPStop
            // 
            this.DTPStop.Location = new System.Drawing.Point(307, 110);
            this.DTPStop.Name = "DTPStop";
            this.DTPStop.Size = new System.Drawing.Size(155, 21);
            this.DTPStop.TabIndex = 6;
            // 
            // DTPStart
            // 
            this.DTPStart.Location = new System.Drawing.Point(76, 110);
            this.DTPStart.Name = "DTPStart";
            this.DTPStart.Size = new System.Drawing.Size(155, 21);
            this.DTPStart.TabIndex = 5;
            // 
            // DTPCadeDate
            // 
            this.DTPCadeDate.Location = new System.Drawing.Point(306, 51);
            this.DTPCadeDate.Name = "DTPCadeDate";
            this.DTPCadeDate.Size = new System.Drawing.Size(155, 21);
            this.DTPCadeDate.TabIndex = 4;
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(36, 167);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(75, 31);
            this.BtnCreate.TabIndex = 3;
            this.BtnCreate.Text = "生成报表";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "终止时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "起始时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "生成时间：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSjBlCreate);
            this.groupBox2.Controls.Add(this.BtnSjblDelete);
            this.groupBox2.Controls.Add(this.BtnYbbDelete);
            this.groupBox2.Controls.Add(this.CboYshop);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DtpActualStop);
            this.groupBox2.Controls.Add(this.DtpActualStart);
            this.groupBox2.Controls.Add(this.DtpActualCadeDate);
            this.groupBox2.Controls.Add(this.BtnYSave);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(7, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 219);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实际报表生成";
            // 
            // BtnYbbDelete
            // 
            this.BtnYbbDelete.Location = new System.Drawing.Point(116, 168);
            this.BtnYbbDelete.Name = "BtnYbbDelete";
            this.BtnYbbDelete.Size = new System.Drawing.Size(75, 31);
            this.BtnYbbDelete.TabIndex = 9;
            this.BtnYbbDelete.Text = "删除报表";
            this.BtnYbbDelete.UseVisualStyleBackColor = true;
            this.BtnYbbDelete.Click += new System.EventHandler(this.BtnYbbDelete_Click);
            // 
            // CboYshop
            // 
            this.CboYshop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboYshop.FormattingEnabled = true;
            this.CboYshop.Location = new System.Drawing.Point(76, 51);
            this.CboYshop.Name = "CboYshop";
            this.CboYshop.Size = new System.Drawing.Size(155, 20);
            this.CboYshop.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "店    铺：";
            // 
            // DtpActualStop
            // 
            this.DtpActualStop.Location = new System.Drawing.Point(307, 110);
            this.DtpActualStop.Name = "DtpActualStop";
            this.DtpActualStop.Size = new System.Drawing.Size(155, 21);
            this.DtpActualStop.TabIndex = 6;
            // 
            // DtpActualStart
            // 
            this.DtpActualStart.Location = new System.Drawing.Point(76, 110);
            this.DtpActualStart.Name = "DtpActualStart";
            this.DtpActualStart.Size = new System.Drawing.Size(155, 21);
            this.DtpActualStart.TabIndex = 5;
            // 
            // DtpActualCadeDate
            // 
            this.DtpActualCadeDate.Location = new System.Drawing.Point(306, 51);
            this.DtpActualCadeDate.Name = "DtpActualCadeDate";
            this.DtpActualCadeDate.Size = new System.Drawing.Size(155, 21);
            this.DtpActualCadeDate.TabIndex = 4;
            // 
            // BtnYSave
            // 
            this.BtnYSave.Location = new System.Drawing.Point(39, 168);
            this.BtnYSave.Name = "BtnYSave";
            this.BtnYSave.Size = new System.Drawing.Size(75, 31);
            this.BtnYSave.TabIndex = 3;
            this.BtnYSave.Text = "生成报表";
            this.BtnYSave.UseVisualStyleBackColor = true;
            this.BtnYSave.Click += new System.EventHandler(this.BtnYSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "终止时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "起始时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(246, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "生成时间：";
            // 
            // BtnYjblDelete
            // 
            this.BtnYjblDelete.Location = new System.Drawing.Point(347, 167);
            this.BtnYjblDelete.Name = "BtnYjblDelete";
            this.BtnYjblDelete.Size = new System.Drawing.Size(75, 31);
            this.BtnYjblDelete.TabIndex = 11;
            this.BtnYjblDelete.Text = "删除报表";
            this.BtnYjblDelete.UseVisualStyleBackColor = true;
            this.BtnYjblDelete.Click += new System.EventHandler(this.BtnYjblDelete_Click);
            // 
            // BtnYjblCreate
            // 
            this.BtnYjblCreate.Location = new System.Drawing.Point(232, 167);
            this.BtnYjblCreate.Name = "BtnYjblCreate";
            this.BtnYjblCreate.Size = new System.Drawing.Size(110, 31);
            this.BtnYjblCreate.TabIndex = 10;
            this.BtnYjblCreate.Text = "按比率生成报表";
            this.BtnYjblCreate.UseVisualStyleBackColor = true;
            this.BtnYjblCreate.Click += new System.EventHandler(this.BtnYjblCreate_Click);
            // 
            // BtnSjblDelete
            // 
            this.BtnSjblDelete.Location = new System.Drawing.Point(347, 168);
            this.BtnSjblDelete.Name = "BtnSjblDelete";
            this.BtnSjblDelete.Size = new System.Drawing.Size(75, 31);
            this.BtnSjblDelete.TabIndex = 11;
            this.BtnSjblDelete.Text = "删除报表";
            this.BtnSjblDelete.UseVisualStyleBackColor = true;
            this.BtnSjblDelete.Click += new System.EventHandler(this.BtnSjblDelete_Click);
            // 
            // BtnSjBlCreate
            // 
            this.BtnSjBlCreate.Location = new System.Drawing.Point(232, 168);
            this.BtnSjBlCreate.Name = "BtnSjBlCreate";
            this.BtnSjBlCreate.Size = new System.Drawing.Size(110, 31);
            this.BtnSjBlCreate.TabIndex = 12;
            this.BtnSjBlCreate.Text = "按比率生成报表";
            this.BtnSjBlCreate.UseVisualStyleBackColor = true;
            this.BtnSjBlCreate.Click += new System.EventHandler(this.BtnSjBlCreate_Click);
            // 
            // GrossProfitGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 491);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GrossProfitGeneration";
            this.Text = "GrossProfitGeneration";
            this.Load += new System.EventHandler(this.GrossProfitGeneration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DTPStop;
        private System.Windows.Forms.DateTimePicker DTPStart;
        private System.Windows.Forms.DateTimePicker DTPCadeDate;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmdShop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CboYshop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtpActualStop;
        private System.Windows.Forms.DateTimePicker DtpActualStart;
        private System.Windows.Forms.DateTimePicker DtpActualCadeDate;
        private System.Windows.Forms.Button BtnYSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnBBDelete;
        private System.Windows.Forms.Button BtnYbbDelete;
        private System.Windows.Forms.Button BtnYjblDelete;
        private System.Windows.Forms.Button BtnYjblCreate;
        private System.Windows.Forms.Button BtnSjBlCreate;
        private System.Windows.Forms.Button BtnSjblDelete;
    }
}