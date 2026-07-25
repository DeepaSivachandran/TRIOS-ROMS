namespace ROMS
{
    partial class CP_Bulk_Image_Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CP_Bulk_Image_Update));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsImageList = new System.Windows.Forms.ToolStrip();
            this.tspHeader = new System.Windows.Forms.ToolStripLabel();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.grbImageUpload = new System.Windows.Forms.GroupBox();
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
            this.grbSubgroups = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tvSubgroupProducts = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flpSubGroups = new System.Windows.Forms.FlowLayoutPanel();
            this.grdSubgroups = new System.Windows.Forms.DataGridView();
            this.clmCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmSubgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmView = new System.Windows.Forms.DataGridViewImageColumn();
            this.clmClear = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsImageList.SuspendLayout();
            this.pnlImage.SuspendLayout();
            this.grbImageUpload.SuspendLayout();
            this.pnlImageContainer.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.grbSubgroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubgroups)).BeginInit();
            this.SuspendLayout();
            // 
            // tsImageList
            // 
            this.tsImageList.BackColor = System.Drawing.Color.White;
            this.tsImageList.Font = new System.Drawing.Font("Oswald Regular", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsImageList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsImageList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsImageList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspHeader});
            this.tsImageList.Location = new System.Drawing.Point(0, 0);
            this.tsImageList.Name = "tsImageList";
            this.tsImageList.Size = new System.Drawing.Size(1354, 25);
            this.tsImageList.TabIndex = 35;
            this.tsImageList.Text = "City";
            // 
            // tspHeader
            // 
            this.tspHeader.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tspHeader.Image = global::ROMS.Properties.Resources.bread_crumb;
            this.tspHeader.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspHeader.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tspHeader.Name = "tspHeader";
            this.tspHeader.Size = new System.Drawing.Size(100, 22);
            this.tspHeader.Text = "Image Update";
            // 
            // pnlImage
            // 
            this.pnlImage.BackColor = System.Drawing.Color.White;
            this.pnlImage.Controls.Add(this.grbImageUpload);
            this.pnlImage.Controls.Add(this.grbSubgroups);
            this.pnlImage.Location = new System.Drawing.Point(0, 31);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(1354, 641);
            this.pnlImage.TabIndex = 36;
            // 
            // grbImageUpload
            // 
            this.grbImageUpload.Controls.Add(this.btnClose);
            this.grbImageUpload.Controls.Add(this.pnlImageContainer);
            this.grbImageUpload.Controls.Add(this.btnSave);
            this.grbImageUpload.Controls.Add(this.flowLayoutPanel1);
            this.grbImageUpload.Controls.Add(this.tsMenu);
            this.grbImageUpload.Location = new System.Drawing.Point(574, 3);
            this.grbImageUpload.Name = "grbImageUpload";
            this.grbImageUpload.Size = new System.Drawing.Size(768, 629);
            this.grbImageUpload.TabIndex = 1;
            this.grbImageUpload.TabStop = false;
            // 
            // pnlImageContainer
            // 
            this.pnlImageContainer.AutoScroll = true;
            this.pnlImageContainer.Controls.Add(this.pnlControls);
            this.pnlImageContainer.Controls.Add(this.pictureBox1);
            this.pnlImageContainer.Location = new System.Drawing.Point(214, 57);
            this.pnlImageContainer.Name = "pnlImageContainer";
            this.pnlImageContainer.Size = new System.Drawing.Size(548, 531);
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
            this.pnlControls.Size = new System.Drawing.Size(545, 74);
            this.pnlControls.TabIndex = 5;
            this.pnlControls.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Saturation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Contrast";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(69, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Brightness";
            // 
            // tbSaturation
            // 
            this.tbSaturation.Location = new System.Drawing.Point(355, 3);
            this.tbSaturation.Maximum = 50;
            this.tbSaturation.Minimum = -50;
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(165, 45);
            this.tbSaturation.TabIndex = 4;
            // 
            // tbBrightness
            // 
            this.tbBrightness.Location = new System.Drawing.Point(13, 3);
            this.tbBrightness.Maximum = 50;
            this.tbBrightness.Minimum = -50;
            this.tbBrightness.Name = "tbBrightness";
            this.tbBrightness.Size = new System.Drawing.Size(165, 45);
            this.tbBrightness.TabIndex = 2;
            // 
            // tbContrast
            // 
            this.tbContrast.Location = new System.Drawing.Point(184, 3);
            this.tbContrast.Maximum = 50;
            this.tbContrast.Minimum = -50;
            this.tbContrast.Name = "tbContrast";
            this.tbContrast.Size = new System.Drawing.Size(165, 45);
            this.tbContrast.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(545, 528);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 57);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(191, 566);
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
            this.tsMenu.Location = new System.Drawing.Point(3, 23);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(762, 31);
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
            // 
            // grbSubgroups
            // 
            this.grbSubgroups.Controls.Add(this.tvSubgroupProducts);
            this.grbSubgroups.Controls.Add(this.flpSubGroups);
            this.grbSubgroups.Controls.Add(this.grdSubgroups);
            this.grbSubgroups.Location = new System.Drawing.Point(12, 3);
            this.grbSubgroups.Name = "grbSubgroups";
            this.grbSubgroups.Size = new System.Drawing.Size(556, 629);
            this.grbSubgroups.TabIndex = 0;
            this.grbSubgroups.TabStop = false;
            this.grbSubgroups.Text = "Subgroups";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnClose.Image = global::ROMS.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(688, 594);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 29);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.btnSave.Image = global::ROMS.Properties.Resources.up_arrow;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(606, 594);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 29);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Upload";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.btnSave_Enter);
            this.btnSave.Leave += new System.EventHandler(this.btnSave_Leave);
            // 
            // tvSubgroupProducts
            // 
            this.tvSubgroupProducts.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSubgroupProducts.ImageIndex = 0;
            this.tvSubgroupProducts.ImageList = this.imageList1;
            this.tvSubgroupProducts.Location = new System.Drawing.Point(9, 440);
            this.tvSubgroupProducts.Name = "tvSubgroupProducts";
            this.tvSubgroupProducts.SelectedImageIndex = 0;
            this.tvSubgroupProducts.Size = new System.Drawing.Size(533, 183);
            this.tvSubgroupProducts.TabIndex = 1111145;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder.png");
            this.imageList1.Images.SetKeyName(1, "Product.png");
            // 
            // flpSubGroups
            // 
            this.flpSubGroups.AutoScroll = true;
            this.flpSubGroups.AutoSize = true;
            this.flpSubGroups.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpSubGroups.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubGroups.Location = new System.Drawing.Point(3, 23);
            this.flpSubGroups.Name = "flpSubGroups";
            this.flpSubGroups.Size = new System.Drawing.Size(0, 603);
            this.flpSubGroups.TabIndex = 1111144;
            this.flpSubGroups.WrapContents = false;
            // 
            // grdSubgroups
            // 
            this.grdSubgroups.AllowUserToAddRows = false;
            this.grdSubgroups.AllowUserToDeleteRows = false;
            this.grdSubgroups.AllowUserToResizeColumns = false;
            this.grdSubgroups.AllowUserToResizeRows = false;
            this.grdSubgroups.BackgroundColor = System.Drawing.Color.White;
            this.grdSubgroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSubgroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdSubgroups.ColumnHeadersHeight = 30;
            this.grdSubgroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdSubgroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCheck,
            this.clmSubgroup,
            this.clmProduct,
            this.clmImage,
            this.clmSGID,
            this.clmView,
            this.clmClear});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSubgroups.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdSubgroups.EnableHeadersVisualStyles = false;
            this.grdSubgroups.GridColor = System.Drawing.Color.White;
            this.grdSubgroups.Location = new System.Drawing.Point(9, 126);
            this.grdSubgroups.Name = "grdSubgroups";
            this.grdSubgroups.ReadOnly = true;
            this.grdSubgroups.RowHeadersVisible = false;
            this.grdSubgroups.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.grdSubgroups.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdSubgroups.RowTemplate.Height = 25;
            this.grdSubgroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSubgroups.Size = new System.Drawing.Size(533, 308);
            this.grdSubgroups.TabIndex = 1111143;
            this.grdSubgroups.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdSubgroups_CellFormatting);
            // 
            // clmCheck
            // 
            this.clmCheck.HeaderText = "";
            this.clmCheck.Name = "clmCheck";
            this.clmCheck.ReadOnly = true;
            this.clmCheck.Width = 40;
            // 
            // clmSubgroup
            // 
            this.clmSubgroup.HeaderText = "Subgroup";
            this.clmSubgroup.Name = "clmSubgroup";
            this.clmSubgroup.ReadOnly = true;
            this.clmSubgroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmSubgroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubgroup.Width = 230;
            // 
            // clmProduct
            // 
            this.clmProduct.HeaderText = "Product";
            this.clmProduct.Name = "clmProduct";
            this.clmProduct.ReadOnly = true;
            this.clmProduct.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmProduct.Width = 140;
            // 
            // clmImage
            // 
            this.clmImage.HeaderText = "Image Name";
            this.clmImage.Name = "clmImage";
            this.clmImage.ReadOnly = true;
            this.clmImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmImage.Width = 120;
            // 
            // clmSGID
            // 
            this.clmSGID.HeaderText = "SGID";
            this.clmSGID.Name = "clmSGID";
            this.clmSGID.ReadOnly = true;
            this.clmSGID.Visible = false;
            this.clmSGID.Width = 10;
            // 
            // clmView
            // 
            this.clmView.HeaderText = "View";
            this.clmView.Image = global::ROMS.Properties.Resources.view_eye;
            this.clmView.Name = "clmView";
            this.clmView.ReadOnly = true;
            this.clmView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmView.Width = 40;
            // 
            // clmClear
            // 
            this.clmClear.HeaderText = "Clear";
            this.clmClear.Image = global::ROMS.Properties.Resources.remove;
            this.clmClear.Name = "clmClear";
            this.clmClear.ReadOnly = true;
            this.clmClear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmClear.Width = 40;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "View";
            this.dataGridViewImageColumn1.Image = global::ROMS.Properties.Resources.view_eye;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 40;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Clear";
            this.dataGridViewImageColumn2.Image = global::ROMS.Properties.Resources.remove;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.Width = 40;
            // 
            // CP_Bulk_Image_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1354, 675);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.tsImageList);
            this.Font = new System.Drawing.Font("Oswald Regular", 10.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CP_Bulk_Image_Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "City";
            this.Load += new System.EventHandler(this.CP_Bulk_Image_Updatelist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CP_Bulk_Image_Updatelist_KeyDown);
            this.tsImageList.ResumeLayout(false);
            this.tsImageList.PerformLayout();
            this.pnlImage.ResumeLayout(false);
            this.grbImageUpload.ResumeLayout(false);
            this.grbImageUpload.PerformLayout();
            this.pnlImageContainer.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.grbSubgroups.ResumeLayout(false);
            this.grbSubgroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubgroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsImageList;
        private System.Windows.Forms.ToolStripLabel tspHeader;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.GroupBox grbSubgroups;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView grdSubgroups;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSGID;
        private System.Windows.Forms.DataGridViewImageColumn clmView;
        private System.Windows.Forms.DataGridViewImageColumn clmClear;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.FlowLayoutPanel flpSubGroups;
        private System.Windows.Forms.TreeView tvSubgroupProducts;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox grbImageUpload;
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
    }
}