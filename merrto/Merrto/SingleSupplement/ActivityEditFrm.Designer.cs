namespace Merrto.SingleSupplement
{
    partial class ActivityEditFrm
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
            this.DGVDetailList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnitemSave = new System.Windows.Forms.Button();
            this.TxtQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtBarCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBtnStorage = new System.Windows.Forms.RadioButton();
            this.RBtnYJ = new System.Windows.Forms.RadioButton();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DTPCadeDate = new System.Windows.Forms.DateTimePicker();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetailList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVDetailList
            // 
            this.DGVDetailList.AllowUserToAddRows = false;
            this.DGVDetailList.AllowUserToDeleteRows = false;
            this.DGVDetailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDetailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVDetailList.Location = new System.Drawing.Point(0, 60);
            this.DGVDetailList.Name = "DGVDetailList";
            this.DGVDetailList.RowTemplate.Height = 23;
            this.DGVDetailList.Size = new System.Drawing.Size(830, 349);
            this.DGVDetailList.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.BtnitemSave);
            this.groupBox2.Controls.Add(this.TxtQty);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TxtBarCode);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox2.Location = new System.Drawing.Point(0, 409);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(830, 29);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // BtnitemSave
            // 
            this.BtnitemSave.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnitemSave.Location = new System.Drawing.Point(422, 3);
            this.BtnitemSave.Name = "BtnitemSave";
            this.BtnitemSave.Size = new System.Drawing.Size(90, 25);
            this.BtnitemSave.TabIndex = 3;
            this.BtnitemSave.Text = "保存";
            this.BtnitemSave.UseVisualStyleBackColor = true;
            this.BtnitemSave.Click += new System.EventHandler(this.BtnitemSave_Click);
            // 
            // TxtQty
            // 
            this.TxtQty.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtQty.Location = new System.Drawing.Point(378, 4);
            this.TxtQty.Name = "TxtQty";
            this.TxtQty.Size = new System.Drawing.Size(38, 23);
            this.TxtQty.TabIndex = 2;
            this.TxtQty.Text = "1";
            this.TxtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtQty_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10F);
            this.label10.Location = new System.Drawing.Point(332, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 11;
            this.label10.Text = "数量：";
            // 
            // TxtBarCode
            // 
            this.TxtBarCode.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtBarCode.Location = new System.Drawing.Point(54, 4);
            this.TxtBarCode.Name = "TxtBarCode";
            this.TxtBarCode.Size = new System.Drawing.Size(272, 23);
            this.TxtBarCode.TabIndex = 1;
            this.TxtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarCode_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10F);
            this.label12.Location = new System.Drawing.Point(8, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 14);
            this.label12.TabIndex = 9;
            this.label12.Text = "条码：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBtnStorage);
            this.groupBox1.Controls.Add(this.RBtnYJ);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Controls.Add(this.TxtRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DTPCadeDate);
            this.groupBox1.Controls.Add(this.TxtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 60);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // RBtnStorage
            // 
            this.RBtnStorage.AutoSize = true;
            this.RBtnStorage.Font = new System.Drawing.Font("宋体", 10F);
            this.RBtnStorage.Location = new System.Drawing.Point(461, 5);
            this.RBtnStorage.Name = "RBtnStorage";
            this.RBtnStorage.Size = new System.Drawing.Size(53, 18);
            this.RBtnStorage.TabIndex = 22;
            this.RBtnStorage.Text = "发货";
            this.RBtnStorage.UseVisualStyleBackColor = true;
            // 
            // RBtnYJ
            // 
            this.RBtnYJ.AutoSize = true;
            this.RBtnYJ.Checked = true;
            this.RBtnYJ.Font = new System.Drawing.Font("宋体", 10F);
            this.RBtnYJ.Location = new System.Drawing.Point(401, 5);
            this.RBtnYJ.Name = "RBtnYJ";
            this.RBtnYJ.Size = new System.Drawing.Size(53, 18);
            this.RBtnYJ.TabIndex = 21;
            this.RBtnYJ.TabStop = true;
            this.RBtnYJ.Text = "预计";
            this.RBtnYJ.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnSave.Location = new System.Drawing.Point(727, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(96, 53);
            this.BtnSave.TabIndex = 20;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtRemarks.Location = new System.Drawing.Point(246, 34);
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(272, 23);
            this.TxtRemarks.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F);
            this.label6.Location = new System.Drawing.Point(200, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 18;
            this.label6.Text = "备注：";
            // 
            // DTPCadeDate
            // 
            this.DTPCadeDate.Font = new System.Drawing.Font("宋体", 10F);
            this.DTPCadeDate.Location = new System.Drawing.Point(240, 4);
            this.DTPCadeDate.Name = "DTPCadeDate";
            this.DTPCadeDate.Size = new System.Drawing.Size(150, 23);
            this.DTPCadeDate.TabIndex = 15;
            // 
            // TxtName
            // 
            this.TxtName.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtName.Location = new System.Drawing.Point(54, 33);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(140, 23);
            this.TxtName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(8, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "活  动：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(204, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "日期：";
            // 
            // TxtCade
            // 
            this.TxtCade.Enabled = false;
            this.TxtCade.Font = new System.Drawing.Font("宋体", 10F);
            this.TxtCade.Location = new System.Drawing.Point(54, 4);
            this.TxtCade.Name = "TxtCade";
            this.TxtCade.Size = new System.Drawing.Size(140, 23);
            this.TxtCade.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "凭证号：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10F);
            this.button1.Location = new System.Drawing.Point(514, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 23;
            this.button1.Text = "导入";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ActivityEditFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 438);
            this.Controls.Add(this.DGVDetailList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActivityEditFrm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ActivityEditFrm";
            this.Load += new System.EventHandler(this.ActivityEditFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetailList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVDetailList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnitemSave;
        private System.Windows.Forms.TextBox TxtQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtBarCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBtnStorage;
        private System.Windows.Forms.RadioButton RBtnYJ;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTPCadeDate;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}