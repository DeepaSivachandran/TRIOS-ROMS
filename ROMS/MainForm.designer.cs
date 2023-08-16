using System.Drawing;

namespace ROMS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ntfy = new System.Windows.Forms.NotifyIcon(this.components);
            this.ms = new System.Windows.Forms.MenuStrip();
            this.tsbLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmpurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmpurchaseSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGRN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGRNApproval = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseDC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseEntry1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmpurchaseReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmpurchaseApprove = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmrackSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsminward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmfromPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmfromOtherStockLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockReq = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOutward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.damageEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDirectCheque = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTimeValue = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmControlPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMasters = new System.Windows.Forms.ToolStripMenuItem();
            this.stateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHSN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSubGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRackGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmitem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuserCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSuppliyer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmbroker = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBulkAttr = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmsupplierMapping = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmbatchno = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmgenralSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmgeneralSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMyProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.ms.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            // 
            // ntfy
            // 
            this.ntfy.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntfy.BalloonTipText = "SSS Exam Cell";
            this.ntfy.BalloonTipTitle = "SSS Exam Cell";
            this.ntfy.Text = "SSS Exam Cell";
            this.ntfy.Click += new System.EventHandler(this.ntfy_Click);
            this.ntfy.DoubleClick += new System.EventHandler(this.ntfy_DoubleClick);
            // 
            // ms
            // 
            this.ms.BackColor = System.Drawing.SystemColors.Menu;
            this.ms.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLogo,
            this.tsmpurchase,
            this.tsmAccounts,
            this.inventoryToolStripMenuItem,
            this.paymentToolStripMenuItem,
            this.lblDb,
            this.tsDLogo,
            this.lblTimeValue,
            this.lblTime,
            this.tsmControlPanel,
            this.tsmMyProfile});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.ms.Size = new System.Drawing.Size(1275, 25);
            this.ms.TabIndex = 112;
            this.ms.Text = "ms";
            // 
            // tsbLogo
            // 
            this.tsbLogo.BackColor = System.Drawing.Color.Transparent;
            this.tsbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsbLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLogo.Name = "tsbLogo";
            this.tsbLogo.Size = new System.Drawing.Size(12, 21);
            this.tsbLogo.Text = "Logo";
            // 
            // tsmpurchase
            // 
            this.tsmpurchase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmpurchaseSupplier,
            this.tsmPurchaseOrder,
            this.tsmGRN,
            this.tsmGRNApproval,
            this.tsmPurchaseDC});
            this.tsmpurchase.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.tsmpurchase.Name = "tsmpurchase";
            this.tsmpurchase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.tsmpurchase.Size = new System.Drawing.Size(63, 21);
            this.tsmpurchase.Text = "&Purchase";
            // 
            // tsmpurchaseSupplier
            // 
            this.tsmpurchaseSupplier.Name = "tsmpurchaseSupplier";
            this.tsmpurchaseSupplier.Size = new System.Drawing.Size(148, 22);
            this.tsmpurchaseSupplier.Text = "PO Schedule";
            this.tsmpurchaseSupplier.Click += new System.EventHandler(this.TsmpurchaseSupplier_Click);
            // 
            // tsmPurchaseOrder
            // 
            this.tsmPurchaseOrder.Name = "tsmPurchaseOrder";
            this.tsmPurchaseOrder.Size = new System.Drawing.Size(148, 22);
            this.tsmPurchaseOrder.Text = "Purchase Order";
            this.tsmPurchaseOrder.Click += new System.EventHandler(this.TsmPurchaseOrder_Click_1);
            // 
            // tsmGRN
            // 
            this.tsmGRN.Name = "tsmGRN";
            this.tsmGRN.Size = new System.Drawing.Size(148, 22);
            this.tsmGRN.Text = "GRN Entry";
            this.tsmGRN.Click += new System.EventHandler(this.TsmGRN_Click);
            // 
            // tsmGRNApproval
            // 
            this.tsmGRNApproval.Name = "tsmGRNApproval";
            this.tsmGRNApproval.Size = new System.Drawing.Size(148, 22);
            this.tsmGRNApproval.Text = "GRN Approval";
            this.tsmGRNApproval.Click += new System.EventHandler(this.TsmGRNApproval_Click);
            // 
            // tsmPurchaseDC
            // 
            this.tsmPurchaseDC.Name = "tsmPurchaseDC";
            this.tsmPurchaseDC.Size = new System.Drawing.Size(148, 22);
            this.tsmPurchaseDC.Text = "Purchase DC";
            this.tsmPurchaseDC.Click += new System.EventHandler(this.TsmPurchaseDC_Click);
            // 
            // tsmAccounts
            // 
            this.tsmAccounts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPurchaseEntry1,
            this.tsmpurchaseReturn,
            this.tsmpurchaseApprove});
            this.tsmAccounts.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAccounts.Name = "tsmAccounts";
            this.tsmAccounts.Size = new System.Drawing.Size(63, 21);
            this.tsmAccounts.Text = "Accounts";
            // 
            // tsmPurchaseEntry1
            // 
            this.tsmPurchaseEntry1.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmPurchaseEntry1.Name = "tsmPurchaseEntry1";
            this.tsmPurchaseEntry1.Size = new System.Drawing.Size(171, 22);
            this.tsmPurchaseEntry1.Text = "Purchase Entry";
            this.tsmPurchaseEntry1.Click += new System.EventHandler(this.Tsmpurchaseentry_Click);
            // 
            // tsmpurchaseReturn
            // 
            this.tsmpurchaseReturn.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmpurchaseReturn.Name = "tsmpurchaseReturn";
            this.tsmpurchaseReturn.Size = new System.Drawing.Size(171, 22);
            this.tsmpurchaseReturn.Text = "Purchase Return DC";
            this.tsmpurchaseReturn.Click += new System.EventHandler(this.TsmpurchaseReturn_Click);
            // 
            // tsmpurchaseApprove
            // 
            this.tsmpurchaseApprove.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmpurchaseApprove.Name = "tsmpurchaseApprove";
            this.tsmpurchaseApprove.Size = new System.Drawing.Size(171, 22);
            this.tsmpurchaseApprove.Text = "Purchase Approval";
            this.tsmpurchaseApprove.Click += new System.EventHandler(this.TsmpurchaseApprove_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmrackSettings,
            this.tsminward,
            this.tsmStockReq,
            this.tsmOutward,
            this.tsmStockTransfer,
            this.damageEntryToolStripMenuItem});
            this.inventoryToolStripMenuItem.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.inventoryToolStripMenuItem.Text = "&Inventory";
            // 
            // tsmrackSettings
            // 
            this.tsmrackSettings.Name = "tsmrackSettings";
            this.tsmrackSettings.Size = new System.Drawing.Size(171, 22);
            this.tsmrackSettings.Text = "Rack Settings";
            this.tsmrackSettings.Click += new System.EventHandler(this.TsmrackSettings_Click);
            // 
            // tsminward
            // 
            this.tsminward.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmfromPurchase,
            this.tsmfromOtherStockLocation});
            this.tsminward.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.tsminward.Name = "tsminward";
            this.tsminward.Size = new System.Drawing.Size(171, 22);
            this.tsminward.Text = "Goods Inward";
            this.tsminward.Click += new System.EventHandler(this.Tsminward_Click);
            // 
            // tsmfromPurchase
            // 
            this.tsmfromPurchase.Name = "tsmfromPurchase";
            this.tsmfromPurchase.Size = new System.Drawing.Size(146, 22);
            this.tsmfromPurchase.Text = "From Purchase";
            this.tsmfromPurchase.Click += new System.EventHandler(this.TsmfromPurchase_Click);
            // 
            // tsmfromOtherStockLocation
            // 
            this.tsmfromOtherStockLocation.Name = "tsmfromOtherStockLocation";
            this.tsmfromOtherStockLocation.Size = new System.Drawing.Size(146, 22);
            this.tsmfromOtherStockLocation.Text = "From Others";
            this.tsmfromOtherStockLocation.Click += new System.EventHandler(this.TsmfromOtherStockLocation_Click);
            // 
            // tsmStockReq
            // 
            this.tsmStockReq.Name = "tsmStockReq";
            this.tsmStockReq.Size = new System.Drawing.Size(171, 22);
            this.tsmStockReq.Text = "Shop Stock Request";
            this.tsmStockReq.Click += new System.EventHandler(this.TsmStockRequest_Click);
            // 
            // tsmOutward
            // 
            this.tsmOutward.Name = "tsmOutward";
            this.tsmOutward.Size = new System.Drawing.Size(171, 22);
            this.tsmOutward.Text = "Goods Outward";
            this.tsmOutward.Click += new System.EventHandler(this.TsmOutward_Click);
            // 
            // tsmStockTransfer
            // 
            this.tsmStockTransfer.Name = "tsmStockTransfer";
            this.tsmStockTransfer.Size = new System.Drawing.Size(171, 22);
            this.tsmStockTransfer.Text = "Stock Transfer";
            this.tsmStockTransfer.Click += new System.EventHandler(this.TsmStockTransfer_Click);
            // 
            // damageEntryToolStripMenuItem
            // 
            this.damageEntryToolStripMenuItem.Name = "damageEntryToolStripMenuItem";
            this.damageEntryToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.damageEntryToolStripMenuItem.Text = "Damage Entry";
            this.damageEntryToolStripMenuItem.Click += new System.EventHandler(this.DamageEntryToolStripMenuItem_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplierPaymentToolStripMenuItem,
            this.tsbDirectCheque});
            this.paymentToolStripMenuItem.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.paymentToolStripMenuItem.Text = "&Finance";
            // 
            // supplierPaymentToolStripMenuItem
            // 
            this.supplierPaymentToolStripMenuItem.Name = "supplierPaymentToolStripMenuItem";
            this.supplierPaymentToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.supplierPaymentToolStripMenuItem.Text = "Supplier Payment";
            this.supplierPaymentToolStripMenuItem.Click += new System.EventHandler(this.SupplierPaymentToolStripMenuItem_Click);
            // 
            // tsbDirectCheque
            // 
            this.tsbDirectCheque.Name = "tsbDirectCheque";
            this.tsbDirectCheque.Size = new System.Drawing.Size(183, 22);
            this.tsbDirectCheque.Text = "Direct Cheque Printing";
            this.tsbDirectCheque.Click += new System.EventHandler(this.TsbDirectCheque_Click);
            // 
            // lblDb
            // 
            this.lblDb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblDb.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDb.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblDb.Name = "lblDb";
            this.lblDb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDb.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.lblDb.ShowShortcutKeys = false;
            this.lblDb.Size = new System.Drawing.Size(12, 21);
            this.lblDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsDLogo
            // 
            this.tsDLogo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsDLogo.BackColor = System.Drawing.Color.Transparent;
            this.tsDLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsDLogo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDLogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDLogo.Name = "tsDLogo";
            this.tsDLogo.Size = new System.Drawing.Size(12, 21);
            this.tsDLogo.Text = "Logo";
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTimeValue.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeValue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.lblTimeValue.ShowShortcutKeys = false;
            this.lblTimeValue.Size = new System.Drawing.Size(12, 21);
            this.lblTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTimeValue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // lblTime
            // 
            this.lblTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblTime.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblTime.Name = "lblTime";
            this.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTime.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.lblTime.ShowShortcutKeys = false;
            this.lblTime.Size = new System.Drawing.Size(12, 21);
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsmControlPanel
            // 
            this.tsmControlPanel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMasters,
            this.settingsToolStripMenuItem});
            this.tsmControlPanel.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmControlPanel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmControlPanel.Name = "tsmControlPanel";
            this.tsmControlPanel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.tsmControlPanel.ShowShortcutKeys = false;
            this.tsmControlPanel.Size = new System.Drawing.Size(85, 21);
            this.tsmControlPanel.Text = "&Control Panel";
            this.tsmControlPanel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsmMasters
            // 
            this.tsmMasters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stateToolStripMenuItem,
            this.tsmCompany,
            this.tsmHSN,
            this.tsmGroup,
            this.tsmSubGroup,
            this.tsmBrand,
            this.tsmUnit,
            this.tsmLocation,
            this.tsmRack,
            this.tsmRackGroup,
            this.tsmitem,
            this.tsmuserCategory,
            this.tsmUser,
            this.tsmSuppliyer,
            this.tsmbroker,
            this.tsmBulkAttr});
            this.tsmMasters.Name = "tsmMasters";
            this.tsmMasters.Size = new System.Drawing.Size(180, 22);
            this.tsmMasters.Text = "Masters";
            // 
            // stateToolStripMenuItem
            // 
            this.stateToolStripMenuItem.Name = "stateToolStripMenuItem";
            this.stateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stateToolStripMenuItem.Text = "City";
            this.stateToolStripMenuItem.Click += new System.EventHandler(this.StateToolStripMenuItem_Click);
            // 
            // tsmCompany
            // 
            this.tsmCompany.Name = "tsmCompany";
            this.tsmCompany.Size = new System.Drawing.Size(180, 22);
            this.tsmCompany.Text = "Company";
            this.tsmCompany.Click += new System.EventHandler(this.TsmCompany_Click);
            // 
            // tsmHSN
            // 
            this.tsmHSN.Name = "tsmHSN";
            this.tsmHSN.Size = new System.Drawing.Size(180, 22);
            this.tsmHSN.Text = "HSN Name";
            this.tsmHSN.Click += new System.EventHandler(this.TsmHSN_Click);
            // 
            // tsmGroup
            // 
            this.tsmGroup.Name = "tsmGroup";
            this.tsmGroup.Size = new System.Drawing.Size(180, 22);
            this.tsmGroup.Text = "Product Group";
            this.tsmGroup.Click += new System.EventHandler(this.TsmGroup_Click);
            // 
            // tsmSubGroup
            // 
            this.tsmSubGroup.Name = "tsmSubGroup";
            this.tsmSubGroup.Size = new System.Drawing.Size(180, 22);
            this.tsmSubGroup.Text = "Product Sub Group";
            this.tsmSubGroup.Click += new System.EventHandler(this.TsmSubGroup_Click);
            // 
            // tsmBrand
            // 
            this.tsmBrand.Name = "tsmBrand";
            this.tsmBrand.Size = new System.Drawing.Size(180, 22);
            this.tsmBrand.Text = "Brand";
            this.tsmBrand.Click += new System.EventHandler(this.TsmBrand_Click);
            // 
            // tsmUnit
            // 
            this.tsmUnit.Name = "tsmUnit";
            this.tsmUnit.Size = new System.Drawing.Size(180, 22);
            this.tsmUnit.Text = "Unit ";
            this.tsmUnit.Click += new System.EventHandler(this.TsmUnit_Click);
            // 
            // tsmLocation
            // 
            this.tsmLocation.Name = "tsmLocation";
            this.tsmLocation.Size = new System.Drawing.Size(180, 22);
            this.tsmLocation.Text = "Stock Location";
            this.tsmLocation.Click += new System.EventHandler(this.TsmLocation_Click);
            // 
            // tsmRack
            // 
            this.tsmRack.Name = "tsmRack";
            this.tsmRack.Size = new System.Drawing.Size(180, 22);
            this.tsmRack.Text = "Rack";
            this.tsmRack.Click += new System.EventHandler(this.TsmRack_Click);
            // 
            // tsmRackGroup
            // 
            this.tsmRackGroup.Name = "tsmRackGroup";
            this.tsmRackGroup.Size = new System.Drawing.Size(180, 22);
            this.tsmRackGroup.Text = "Rack Group";
            this.tsmRackGroup.Click += new System.EventHandler(this.TsmRackGroup_Click);
            // 
            // tsmitem
            // 
            this.tsmitem.Name = "tsmitem";
            this.tsmitem.Size = new System.Drawing.Size(180, 22);
            this.tsmitem.Text = "Product";
            this.tsmitem.Click += new System.EventHandler(this.Tsmitem_Click);
            // 
            // tsmuserCategory
            // 
            this.tsmuserCategory.Name = "tsmuserCategory";
            this.tsmuserCategory.Size = new System.Drawing.Size(180, 22);
            this.tsmuserCategory.Text = "User Category ";
            this.tsmuserCategory.Click += new System.EventHandler(this.TsmuserCategory_Click);
            // 
            // tsmUser
            // 
            this.tsmUser.Name = "tsmUser";
            this.tsmUser.Size = new System.Drawing.Size(180, 22);
            this.tsmUser.Text = "User";
            this.tsmUser.Click += new System.EventHandler(this.TsmUser_Click);
            // 
            // tsmSuppliyer
            // 
            this.tsmSuppliyer.Name = "tsmSuppliyer";
            this.tsmSuppliyer.Size = new System.Drawing.Size(180, 22);
            this.tsmSuppliyer.Text = "Supplier";
            this.tsmSuppliyer.Click += new System.EventHandler(this.TsmSuppliyer_Click);
            // 
            // tsmbroker
            // 
            this.tsmbroker.Name = "tsmbroker";
            this.tsmbroker.Size = new System.Drawing.Size(180, 22);
            this.tsmbroker.Text = "Broker";
            this.tsmbroker.Click += new System.EventHandler(this.Tsmbroker_Click);
            // 
            // tsmBulkAttr
            // 
            this.tsmBulkAttr.Name = "tsmBulkAttr";
            this.tsmBulkAttr.Size = new System.Drawing.Size(225, 22);
            this.tsmBulkAttr.Text = "Product Attributes Bulk Update";
            this.tsmBulkAttr.Click += new System.EventHandler(this.TsmBulkAttr_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmsupplierMapping,
            this.tsmbatchno,
            this.tsmgenralSettings,
            this.tsmgeneralSettings});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // tsmsupplierMapping
            // 
            this.tsmsupplierMapping.Name = "tsmsupplierMapping";
            this.tsmsupplierMapping.Size = new System.Drawing.Size(207, 22);
            this.tsmsupplierMapping.Text = "Supplier - Product Mapping";
            this.tsmsupplierMapping.Visible = false;
            this.tsmsupplierMapping.Click += new System.EventHandler(this.TsmsupplierMapping_Click);
            // 
            // tsmbatchno
            // 
            this.tsmbatchno.Name = "tsmbatchno";
            this.tsmbatchno.Size = new System.Drawing.Size(207, 22);
            this.tsmbatchno.Text = "Batch No. Configuration";
            this.tsmbatchno.Visible = false;
            this.tsmbatchno.Click += new System.EventHandler(this.Tsmbatchno_Click);
            // 
            // tsmgenralSettings
            // 
            this.tsmgenralSettings.Name = "tsmgenralSettings";
            this.tsmgenralSettings.Size = new System.Drawing.Size(207, 22);
            this.tsmgenralSettings.Text = "Voucher Settings";
            this.tsmgenralSettings.Click += new System.EventHandler(this.TsmgenralSettings_Click);
            // 
            // tsmgeneralSettings
            // 
            this.tsmgeneralSettings.Name = "tsmgeneralSettings";
            this.tsmgeneralSettings.Size = new System.Drawing.Size(207, 22);
            this.tsmgeneralSettings.Text = "General Settings";
            this.tsmgeneralSettings.Click += new System.EventHandler(this.TsmgeneralSettings_Click);
            // 
            // tsmMyProfile
            // 
            this.tsmMyProfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmProfile,
            this.tsmLogout});
            this.tsmMyProfile.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmMyProfile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmMyProfile.Name = "tsmMyProfile";
            this.tsmMyProfile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.tsmMyProfile.ShowShortcutKeys = false;
            this.tsmMyProfile.Size = new System.Drawing.Size(68, 21);
            this.tsmMyProfile.Text = "&My Profile";
            this.tsmMyProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsmMyProfile.Click += new System.EventHandler(this.tsbLogout_Click);
            // 
            // tsmProfile
            // 
            this.tsmProfile.Name = "tsmProfile";
            this.tsmProfile.Size = new System.Drawing.Size(109, 22);
            this.tsmProfile.Text = "Profile";
            this.tsmProfile.Click += new System.EventHandler(this.tsmChangePassword_Click);
            // 
            // tsmLogout
            // 
            this.tsmLogout.Name = "tsmLogout";
            this.tsmLogout.Size = new System.Drawing.Size(109, 22);
            this.tsmLogout.Text = "Logout";
            this.tsmLogout.Click += new System.EventHandler(this.tsmLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1275, 559);
            this.Controls.Add(this.ms);
            this.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ROMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.NotifyIcon ntfy;
        private System.Windows.Forms.ToolStripMenuItem tsmMyProfile;
        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem tsbLogo;
        private System.Windows.Forms.ToolStripMenuItem tsDLogo;
        private System.Windows.Forms.ToolStripMenuItem tsmControlPanel;
        private System.Windows.Forms.ToolStripMenuItem tsmMasters;
        private System.Windows.Forms.ToolStripMenuItem tsmCompany;
        private System.Windows.Forms.ToolStripMenuItem tsmUser;
        private System.Windows.Forms.ToolStripMenuItem tsmUnit;
        private System.Windows.Forms.ToolStripMenuItem tsmBrand;
        private System.Windows.Forms.ToolStripMenuItem tsmLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmProfile;
        private System.Windows.Forms.ToolStripMenuItem tsmLogout;
        private System.Windows.Forms.ToolStripMenuItem lblTime;
        private System.Windows.Forms.ToolStripMenuItem lblTimeValue;
        private System.Windows.Forms.ToolStripMenuItem lblDb;
        private System.Windows.Forms.ToolStripMenuItem tsmSubGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmSuppliyer;
        private System.Windows.Forms.ToolStripMenuItem stateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchase;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseentry;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmsupplierMapping;
        private System.Windows.Forms.ToolStripMenuItem tsmitem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsminward;
        private System.Windows.Forms.ToolStripMenuItem tsmGRN;
        private System.Windows.Forms.ToolStripMenuItem tsmRack;
        private System.Windows.Forms.ToolStripMenuItem tsmRackGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmbatchno;
        private System.Windows.Forms.ToolStripMenuItem tsmStockTransfer;
        private System.Windows.Forms.ToolStripMenuItem tsmOutward;
        private System.Windows.Forms.ToolStripMenuItem tsmStockRequest;
        private System.Windows.Forms.ToolStripMenuItem tsmgenralSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmbroker;
        private System.Windows.Forms.ToolStripMenuItem tsmHSN;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmuserCategory;
        private System.Windows.Forms.ToolStripMenuItem damageEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmStockReq;
        private System.Windows.Forms.ToolStripMenuItem tsmfromPurchase;
        private System.Windows.Forms.ToolStripMenuItem tsmfromOtherStockLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmGRNApproval;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseDC;
        private System.Windows.Forms.ToolStripMenuItem tsmgeneralSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseSupplier;
        private System.Windows.Forms.ToolStripMenuItem tsmAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseEntry1;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseReturn;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseApprove;
        private System.Windows.Forms.ToolStripMenuItem tsmrackSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmBulkAttr;
        private System.Windows.Forms.ToolStripMenuItem tsbDirectCheque;
    }
}