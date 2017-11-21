namespace Merrto.TheShopReports
{
    partial class CustomerUnitSetBrow
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
            this.BtnEdit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // WPHbROWDGV
            // 
            this.WPHbROWDGV.AllowUserToAddRows = false;
            this.WPHbROWDGV.AllowUserToDeleteRows = false;
            this.WPHbROWDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WPHbROWDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WPHbROWDGV.Location = new System.Drawing.Point(0, 50);
            this.WPHbROWDGV.Name = "WPHbROWDGV";
            this.WPHbROWDGV.ReadOnly = true;
            this.WPHbROWDGV.RowTemplate.Height = 23;
            this.WPHbROWDGV.Size = new System.Drawing.Size(908, 562);
            this.WPHbROWDGV.TabIndex = 15;
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(84, 12);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 32);
            this.BtnEdit.TabIndex = 13;
            this.BtnEdit.Text = "修改";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnAdd);
            this.groupBox2.Controls.Add(this.BtnEdit);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(908, 50);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(5, 12);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 32);
            this.BtnAdd.TabIndex = 14;
            this.BtnAdd.Text = "新增";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // CustomerUnitSetBrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 612);
            this.Controls.Add(this.WPHbROWDGV);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerUnitSetBrow";
            this.Text = "CustomerUnitSetBrow";
            this.Load += new System.EventHandler(this.CustomerUnitSetBrow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WPHbROWDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WPHbROWDGV;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnAdd;
    }
}