namespace ROMS
{
    partial class ReportLoad
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
            this.cryptview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cryptview
            // 
            this.cryptview.ActiveViewIndex = -1;
            this.cryptview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cryptview.Cursor = System.Windows.Forms.Cursors.Default;
            this.cryptview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryptview.Location = new System.Drawing.Point(0, 0);
            this.cryptview.Name = "cryptview";
            this.cryptview.ShowCloseButton = false;
            this.cryptview.ShowCopyButton = false;
            this.cryptview.ShowGroupTreeButton = false;
            this.cryptview.ShowParameterPanelButton = false;
            this.cryptview.ShowRefreshButton = false;
            this.cryptview.ShowTextSearchButton = false;
            this.cryptview.ShowZoomButton = false;
            this.cryptview.Size = new System.Drawing.Size(761, 545);
            this.cryptview.TabIndex = 0;
            this.cryptview.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 545);
            this.Controls.Add(this.cryptview);
            this.Name = "ReportLoad";
            this.Text = "ReportLoad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReportLoad_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer cryptview;
    }
}