namespace Merrto.M_System
{
    partial class K_Permissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(K_Permissions));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbuserid = new System.Windows.Forms.ComboBox();
            this.btnPerm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tv_data = new System.Windows.Forms.TreeView();
            this.btnsave = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnSAVE1 = new System.Windows.Forms.Button();
            this.DGVDate = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbuserid);
            this.groupBox1.Controls.Add(this.btnPerm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 43);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cmbuserid
            // 
            this.cmbuserid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbuserid.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbuserid.FormattingEnabled = true;
            this.cmbuserid.Location = new System.Drawing.Point(52, 13);
            this.cmbuserid.Name = "cmbuserid";
            this.cmbuserid.Size = new System.Drawing.Size(153, 24);
            this.cmbuserid.TabIndex = 3;
            this.cmbuserid.SelectedIndexChanged += new System.EventHandler(this.cmbuserid_SelectedIndexChanged);
            // 
            // btnPerm
            // 
            this.btnPerm.Font = new System.Drawing.Font("宋体", 12F);
            this.btnPerm.Image = ((System.Drawing.Image)(resources.GetObject("btnPerm.Image")));
            this.btnPerm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPerm.Location = new System.Drawing.Point(213, 12);
            this.btnPerm.Name = "btnPerm";
            this.btnPerm.Size = new System.Drawing.Size(105, 25);
            this.btnPerm.TabIndex = 2;
            this.btnPerm.Text = "读取权限";
            this.btnPerm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPerm.UseVisualStyleBackColor = true;
            this.btnPerm.Click += new System.EventHandler(this.btnPerm_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.tv_data);
            this.groupBox2.Location = new System.Drawing.Point(8, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 451);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // tv_data
            // 
            this.tv_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tv_data.CheckBoxes = true;
            this.tv_data.Font = new System.Drawing.Font("宋体", 12F);
            this.tv_data.Location = new System.Drawing.Point(8, 12);
            this.tv_data.Name = "tv_data";
            this.tv_data.Size = new System.Drawing.Size(309, 431);
            this.tv_data.TabIndex = 0;
            this.tv_data.Tag = "";
            this.tv_data.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_data_AfterSelect);
            this.tv_data.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tv_data_MouseClick);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnsave.Location = new System.Drawing.Point(256, 495);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 4;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 502);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.DGVDate);
            this.groupBox3.Controls.Add(this.BtnSAVE1);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 1F);
            this.groupBox3.Location = new System.Drawing.Point(344, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(442, 507);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // BtnSAVE1
            // 
            this.BtnSAVE1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSAVE1.Font = new System.Drawing.Font("宋体", 10F);
            this.BtnSAVE1.Location = new System.Drawing.Point(361, 475);
            this.BtnSAVE1.Name = "BtnSAVE1";
            this.BtnSAVE1.Size = new System.Drawing.Size(75, 23);
            this.BtnSAVE1.TabIndex = 10;
            this.BtnSAVE1.Text = "保存";
            this.BtnSAVE1.UseVisualStyleBackColor = true;
            this.BtnSAVE1.Click += new System.EventHandler(this.BtnSAVE1_Click);
            // 
            // DGVDate
            // 
            this.DGVDate.AllowUserToAddRows = false;
            this.DGVDate.AllowUserToDeleteRows = false;
            this.DGVDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVDate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVDate.Location = new System.Drawing.Point(6, 9);
            this.DGVDate.Name = "DGVDate";
            this.DGVDate.RowTemplate.Height = 23;
            this.DGVDate.Size = new System.Drawing.Size(430, 460);
            this.DGVDate.TabIndex = 11;
            // 
            // K_Permissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(238)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(810, 526);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "K_Permissions";
            this.Text = "K_Permissions";
            this.Load += new System.EventHandler(this.K_Permissions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPerm;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView tv_data;
        private System.Windows.Forms.ComboBox cmbuserid;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnSAVE1;
        private System.Windows.Forms.DataGridView DGVDate;
    }
}