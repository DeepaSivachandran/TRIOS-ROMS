namespace ROMS
{
    partial class CP_ProductImageApproval
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_ProductImageApproval));
            this.epProductApproval = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsStockTransferList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlGoodsOutward = new System.Windows.Forms.Panel();
            this.tcProductApproval = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblProductName = new System.Windows.Forms.Label();
            this.btnImgClose = new System.Windows.Forms.Button();
            this.btnImageUpdate = new System.Windows.Forms.Button();
            this.pnlImageContainer = new System.Windows.Forms.Panel();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSaturation = new System.Windows.Forms.TrackBar();
            this.tbBrightness = new System.Windows.Forms.TrackBar();
            this.tbContrast = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbReset = new System.Windows.Forms.ToolStripButton();
            this.tssEdit = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRotateR = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRotateL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCropImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCrop = new System.Windows.Forms.ToolStripButton();
            this.tsbBrowse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbColour = new System.Windows.Forms.ToolStripButton();
            this.grpGoodsOutward = new System.Windows.Forms.GroupBox();
            this.btnReject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epProductApproval)).BeginInit();
            this.tsStockTransferList.SuspendLayout();
            this.pnlGoodsOutward.SuspendLayout();
            this.tcProductApproval.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.pnlImageContainer.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // epProductApproval
            // 
            this.epProductApproval.ContainerControl = this;
            // 
            // tsStockTransferList
            // 
            this.tsStockTransferList.BackColor = System.Drawing.Color.White;
            this.tsStockTransferList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStockTransferList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsStockTransferList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsStockTransferList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsStockTransferList.Location = new System.Drawing.Point(0, 0);
            this.tsStockTransferList.Name = "tsStockTransferList";
            this.tsStockTransferList.Size = new System.Drawing.Size(1354, 25);
            this.tsStockTransferList.TabIndex = 958817;
            this.tsStockTransferList.Text = "Goods Outward";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(154, 22);
            this.tspHeader.Text = "Product Image Approval";
            // 
            // pnlGoodsOutward
            // 
            this.pnlGoodsOutward.BackColor = System.Drawing.Color.White;
            this.pnlGoodsOutward.Controls.Add(this.tcProductApproval);
            this.pnlGoodsOutward.Controls.Add(this.grpGoodsOutward);
            this.pnlGoodsOutward.Location = new System.Drawing.Point(0, 29);
            this.pnlGoodsOutward.Name = "pnlGoodsOutward";
            this.pnlGoodsOutward.Size = new System.Drawing.Size(1354, 645);
            this.pnlGoodsOutward.TabIndex = 958819;
            // 
            // tcProductApproval
            // 
            this.tcProductApproval.Controls.Add(this.tabPage3);
            this.tcProductApproval.Location = new System.Drawing.Point(7, 3);
            this.tcProductApproval.Name = "tcProductApproval";
            this.tcProductApproval.SelectedIndex = 0;
            this.tcProductApproval.Size = new System.Drawing.Size(1342, 639);
            this.tcProductApproval.TabIndex = 958820;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnReject);
            this.tabPage3.Controls.Add(this.lblProductName);
            this.tabPage3.Controls.Add(this.btnImgClose);
            this.tabPage3.Controls.Add(this.btnImageUpdate);
            this.tabPage3.Controls.Add(this.pnlImageContainer);
            this.tabPage3.Controls.Add(this.flowLayoutPanel1);
            this.tabPage3.Controls.Add(this.tsMenu);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1334, 607);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Product Image";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(213, 9);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(41, 20);
            this.lblProductName.TabIndex = 43;
            this.lblProductName.Text = "label1";
            // 
            // btnImgClose
            // 
            this.btnImgClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnImgClose.Image = global::ROMS.Properties.Resources.close;
            this.btnImgClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImgClose.Location = new System.Drawing.Point(1244, 576);
            this.btnImgClose.Name = "btnImgClose";
            this.btnImgClose.Size = new System.Drawing.Size(86, 29);
            this.btnImgClose.TabIndex = 42;
            this.btnImgClose.Text = "Close";
            this.btnImgClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImgClose.UseVisualStyleBackColor = true;
            this.btnImgClose.Click += new System.EventHandler(this.btnImgClose_Click);
            // 
            // btnImageUpdate
            // 
            this.btnImageUpdate.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnImageUpdate.Image = global::ROMS.Properties.Resources.save;
            this.btnImageUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImageUpdate.Location = new System.Drawing.Point(1153, 576);
            this.btnImageUpdate.Name = "btnImageUpdate";
            this.btnImageUpdate.Size = new System.Drawing.Size(86, 29);
            this.btnImageUpdate.TabIndex = 19;
            this.btnImageUpdate.Text = "Approve";
            this.btnImageUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImageUpdate.UseVisualStyleBackColor = true;
            this.btnImageUpdate.Click += new System.EventHandler(this.btnImageUpdate_Click);
            // 
            // pnlImageContainer
            // 
            this.pnlImageContainer.AutoScroll = true;
            this.pnlImageContainer.Controls.Add(this.pnlControls);
            this.pnlImageContainer.Controls.Add(this.pictureBox1);
            this.pnlImageContainer.Location = new System.Drawing.Point(442, 33);
            this.pnlImageContainer.Name = "pnlImageContainer";
            this.pnlImageContainer.Size = new System.Drawing.Size(756, 540);
            this.pnlImageContainer.TabIndex = 18;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.label5);
            this.pnlControls.Controls.Add(this.label6);
            this.pnlControls.Controls.Add(this.label7);
            this.pnlControls.Controls.Add(this.tbSaturation);
            this.pnlControls.Controls.Add(this.tbBrightness);
            this.pnlControls.Controls.Add(this.tbContrast);
            this.pnlControls.Location = new System.Drawing.Point(3, 3);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(750, 74);
            this.pnlControls.TabIndex = 5;
            this.pnlControls.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(564, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Saturation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Contrast";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Brightness";
            // 
            // tbSaturation
            // 
            this.tbSaturation.Location = new System.Drawing.Point(499, 3);
            this.tbSaturation.Maximum = 50;
            this.tbSaturation.Minimum = -50;
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(197, 45);
            this.tbSaturation.TabIndex = 4;
            this.tbSaturation.Scroll += new System.EventHandler(this.tbSaturation_Scroll);
            // 
            // tbBrightness
            // 
            this.tbBrightness.Location = new System.Drawing.Point(57, 3);
            this.tbBrightness.Maximum = 50;
            this.tbBrightness.Minimum = -50;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(197, 45);
            this.tbBrightness.TabIndex = 2;
            this.tbBrightness.Scroll += new System.EventHandler(this.tbBrightness_Scroll);
            // 
            // tbContrast
            // 
            this.tbContrast.Location = new System.Drawing.Point(280, 3);
            this.tbContrast.Maximum = 50;
            this.tbContrast.Minimum = -50;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(197, 45);
            this.tbContrast.TabIndex = 3;
            this.tbContrast.Scroll += new System.EventHandler(this.tbContrast_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(750, 534);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 37);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(191, 540);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbReset,
            this.tssEdit,
            this.tsbRotateR,
            this.toolStripSeparator1,
            this.tsbRotateL,
            this.toolStripSeparator2,
            this.tsbZoomOut,
            this.toolStripSeparator3,
            this.tsbZoomIn,
            this.toolStripSeparator4,
            this.tsbCropImage,
            this.toolStripSeparator5,
            this.tsbCrop,
            this.tsbBrowse,
            this.toolStripSeparator6,
            this.tsbColour});
            this.tsMenu.Location = new System.Drawing.Point(3, 3);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1328, 31);
            this.tsMenu.TabIndex = 14;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbReset
            // 
            this.tsbReset.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbReset.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.tsbReset.Image = global::ROMS.Properties.Resources.reset;
            this.tsbReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReset.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbReset.Name = "tsbReset";
            this.tsbReset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbReset.Size = new System.Drawing.Size(68, 28);
            this.tsbReset.Text = "&Reset";
            this.tsbReset.Click += new System.EventHandler(this.tsbReset_Click);
            // 
            // tssEdit
            // 
            this.tssEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssEdit.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.tssEdit.Name = "tssEdit";
            this.tssEdit.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbRotateR
            // 
            this.tsbRotateR.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbRotateR.Image = global::ROMS.Properties.Resources.right_rotate;
            this.tsbRotateR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRotateR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRotateR.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbRotateR.Name = "tsbRotateR";
            this.tsbRotateR.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbRotateR.Size = new System.Drawing.Size(23, 28);
            this.tsbRotateR.Click += new System.EventHandler(this.tsbRotateR_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbRotateL
            // 
            this.tsbRotateL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbRotateL.Image = global::ROMS.Properties.Resources.left_rotate;
            this.tsbRotateL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRotateL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRotateL.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbRotateL.Name = "tsbRotateL";
            this.tsbRotateL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbRotateL.Size = new System.Drawing.Size(23, 28);
            this.tsbRotateL.Click += new System.EventHandler(this.tsbRotateL_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbZoomOut
            // 
            this.tsbZoomOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbZoomOut.Image = global::ROMS.Properties.Resources.zoom_out;
            this.tsbZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomOut.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbZoomOut.Name = "tsbZoomOut";
            this.tsbZoomOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbZoomOut.Size = new System.Drawing.Size(23, 28);
            this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOut_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbZoomIn
            // 
            this.tsbZoomIn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbZoomIn.Image = global::ROMS.Properties.Resources.zoom_in;
            this.tsbZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomIn.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbZoomIn.Name = "tsbZoomIn";
            this.tsbZoomIn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbZoomIn.Size = new System.Drawing.Size(23, 28);
            this.tsbZoomIn.Click += new System.EventHandler(this.tsbZoomIn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbCropImage
            // 
            this.tsbCropImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCropImage.Image = global::ROMS.Properties.Resources.crop;
            this.tsbCropImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCropImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCropImage.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbCropImage.Name = "tsbCropImage";
            this.tsbCropImage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbCropImage.Size = new System.Drawing.Size(23, 28);
            this.tsbCropImage.Click += new System.EventHandler(this.tsbCropImage_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbCrop
            // 
            this.tsbCrop.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbCrop.Image = global::ROMS.Properties.Resources.image_edit;
            this.tsbCrop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCrop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCrop.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbCrop.Name = "tsbCrop";
            this.tsbCrop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbCrop.Size = new System.Drawing.Size(23, 28);
            this.tsbCrop.Click += new System.EventHandler(this.tsbCrop_Click);
            // 
            // tsbBrowse
            // 
            this.tsbBrowse.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.tsbBrowse.Image = global::ROMS.Properties.Resources.folder;
            this.tsbBrowse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBrowse.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbBrowse.Name = "tsbBrowse";
            this.tsbBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbBrowse.Size = new System.Drawing.Size(69, 28);
            this.tsbBrowse.Text = "Browse";
            this.tsbBrowse.Click += new System.EventHandler(this.tsbBrowse_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbColour
            // 
            this.tsbColour.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbColour.Image = global::ROMS.Properties.Resources.Brightness;
            this.tsbColour.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbColour.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbColour.Margin = new System.Windows.Forms.Padding(0, 1, 15, 2);
            this.tsbColour.Name = "tsbColour";
            this.tsbColour.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsbColour.Size = new System.Drawing.Size(24, 28);
            this.tsbColour.Click += new System.EventHandler(this.tsbColour_Click);
            // 
            // grpGoodsOutward
            // 
            this.grpGoodsOutward.BackColor = System.Drawing.Color.White;
            this.grpGoodsOutward.Location = new System.Drawing.Point(11, 3);
            this.grpGoodsOutward.Name = "grpGoodsOutward";
            this.grpGoodsOutward.Size = new System.Drawing.Size(1331, 638);
            this.grpGoodsOutward.TabIndex = 958819;
            this.grpGoodsOutward.TabStop = false;
            // 
            // btnReject
            // 
            this.btnReject.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnReject.Image = global::ROMS.Properties.Resources.Blocked;
            this.btnReject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReject.Location = new System.Drawing.Point(1062, 576);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(86, 29);
            this.btnReject.TabIndex = 44;
            this.btnReject.Text = "Reject";
            this.btnReject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // CP_ProductImageApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlGoodsOutward);
            this.Controls.Add(this.tsStockTransferList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CP_ProductImageApproval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Approval";
            this.Load += new System.EventHandler(this.CP_ProductApproval_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_ProductApproval_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.epProductApproval)).EndInit();
            this.tsStockTransferList.ResumeLayout(false);
            this.tsStockTransferList.PerformLayout();
            this.pnlGoodsOutward.ResumeLayout(false);
            this.tcProductApproval.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.pnlImageContainer.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider epProductApproval;
        private System.Windows.Forms.ToolStrip tsStockTransferList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlGoodsOutward;
        private System.Windows.Forms.GroupBox grpGoodsOutward;
        private System.Windows.Forms.TabControl tcProductApproval;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStrip tsMenu;
        public System.Windows.Forms.ToolStripButton tsbReset;
        public System.Windows.Forms.ToolStripSeparator tssEdit;
        public System.Windows.Forms.ToolStripButton tsbRotateR;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton tsbRotateL;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton tsbZoomOut;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton tsbZoomIn;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripButton tsbCropImage;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripButton tsbCrop;
        public System.Windows.Forms.ToolStripButton tsbBrowse;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        public System.Windows.Forms.ToolStripButton tsbColour;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlImageContainer;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tbSaturation;
        private System.Windows.Forms.TrackBar tbBrightness;
        private System.Windows.Forms.TrackBar tbContrast;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnImageUpdate;
        private System.Windows.Forms.Button btnImgClose;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Button btnReject;
    }
}