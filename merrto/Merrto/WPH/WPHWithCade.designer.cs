namespace Merrto.WPH
{
    partial class WPHWithCade
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
            this.ProductDGV = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BTNADD = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TXtCade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBrow = new System.Windows.Forms.Button();
            this.WithCodeDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WithCodeDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductDGV
            // 
            this.ProductDGV.AllowUserToAddRows = false;
            this.ProductDGV.AllowUserToDeleteRows = false;
            this.ProductDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProductDGV.Location = new System.Drawing.Point(0, 48);
            this.ProductDGV.Name = "ProductDGV";
            this.ProductDGV.ReadOnly = true;
            this.ProductDGV.RowTemplate.Height = 23;
            this.ProductDGV.Size = new System.Drawing.Size(347, 277);
            this.ProductDGV.TabIndex = 9;
            this.ProductDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductDGV_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BTNADD);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 325);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(745, 48);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // BTNADD
            // 
            this.BTNADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTNADD.Location = new System.Drawing.Point(264, 7);
            this.BTNADD.Name = "BTNADD";
            this.BTNADD.Size = new System.Drawing.Size(83, 36);
            this.BTNADD.TabIndex = 0;
            this.BTNADD.Text = "配比定义";
            this.BTNADD.UseVisualStyleBackColor = true;
            this.BTNADD.Click += new System.EventHandler(this.BTNADD_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TXtCade);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnBrow);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 48);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // TXtCade
            // 
            this.TXtCade.Location = new System.Drawing.Point(53, 16);
            this.TXtCade.Name = "TXtCade";
            this.TXtCade.Size = new System.Drawing.Size(177, 21);
            this.TXtCade.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "款号：";
            // 
            // BtnBrow
            // 
            this.BtnBrow.Location = new System.Drawing.Point(236, 13);
            this.BtnBrow.Name = "BtnBrow";
            this.BtnBrow.Size = new System.Drawing.Size(75, 26);
            this.BtnBrow.TabIndex = 0;
            this.BtnBrow.Text = "查询";
            this.BtnBrow.UseVisualStyleBackColor = true;
            this.BtnBrow.Click += new System.EventHandler(this.BtnBrow_Click);
            // 
            // WithCodeDGV
            // 
            this.WithCodeDGV.AllowUserToAddRows = false;
            this.WithCodeDGV.AllowUserToDeleteRows = false;
            this.WithCodeDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.WithCodeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WithCodeDGV.Location = new System.Drawing.Point(353, 48);
            this.WithCodeDGV.Name = "WithCodeDGV";
            this.WithCodeDGV.ReadOnly = true;
            this.WithCodeDGV.RowTemplate.Height = 23;
            this.WithCodeDGV.Size = new System.Drawing.Size(363, 278);
            this.WithCodeDGV.TabIndex = 12;
            // 
            // WPHWithCade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 373);
            this.Controls.Add(this.WithCodeDGV);
            this.Controls.Add(this.ProductDGV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WPHWithCade";
            this.Text = "WPHWithCade";
            this.Load += new System.EventHandler(this.WPHWithCade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WithCodeDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductDGV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BTNADD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TXtCade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBrow;
        private System.Windows.Forms.DataGridView WithCodeDGV;
    }
}