namespace Merrto
{
    partial class BarCodeCade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarCodeCade));
            this.AGRDReports = new AxgrdesLib.AxGRDesigner();
            this.OFDReports = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.AGRDReports)).BeginInit();
            this.SuspendLayout();
            // 
            // AGRDReports
            // 
            this.AGRDReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AGRDReports.Enabled = true;
            this.AGRDReports.Location = new System.Drawing.Point(0, 0);
            this.AGRDReports.Name = "AGRDReports";
            this.AGRDReports.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AGRDReports.OcxState")));
            this.AGRDReports.Size = new System.Drawing.Size(876, 594);
            this.AGRDReports.TabIndex = 0;
            // 
            // OFDReports
            // 
            this.OFDReports.FileName = "OFDReports";
            // 
            // BarCodeCade
            // 
            this.ClientSize = new System.Drawing.Size(876, 594);
            this.Controls.Add(this.AGRDReports);
            this.Name = "BarCodeCade";
            ((System.ComponentModel.ISupportInitialize)(this.AGRDReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxgrdesLib.AxGRDesigner AGRDReports;
        private System.Windows.Forms.OpenFileDialog OFDReports;


        //private AxgrdesLib.AxGRDesigner AGRDReports;
        //private System.Windows.Forms.OpenFileDialog OFDReports;

    }
}