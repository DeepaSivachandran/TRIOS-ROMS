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
            this.tsmStockHold = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockReq = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOutward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.damageEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbStockConversion = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supplierPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDirectCheque = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDebitNote = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTimeValue = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTime = new System.Windows.Forms.ToolStripMenuItem();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.tsnHSN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSubGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRackGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBroker = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBulkUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRepresentative = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmControlPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProMapping = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBatchNoConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVoucherSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGeneralSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMyProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mastersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mastersToolStripMenuItem,
            this.tsmControlPanel,
            this.tsmMyProfile,
            this.reportToolStripMenuItem});
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
            this.tsmStockHold,
            this.tsmStockReq,
            this.tsmOutward,
            this.tsmStockTransfer,
            this.damageEntryToolStripMenuItem,
            this.tsbStockConversion});
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
            this.tsmfromPurchase.Size = new System.Drawing.Size(173, 22);
            this.tsmfromPurchase.Text = "From Purchase & GRN";
            this.tsmfromPurchase.Click += new System.EventHandler(this.TsmfromPurchase_Click);
            // 
            // tsmfromOtherStockLocation
            // 
            this.tsmfromOtherStockLocation.Name = "tsmfromOtherStockLocation";
            this.tsmfromOtherStockLocation.Size = new System.Drawing.Size(173, 22);
            this.tsmfromOtherStockLocation.Text = "From Others";
            this.tsmfromOtherStockLocation.Click += new System.EventHandler(this.TsmfromOtherStockLocation_Click);
            // 
            // tsmStockHold
            // 
            this.tsmStockHold.Name = "tsmStockHold";
            this.tsmStockHold.Size = new System.Drawing.Size(171, 22);
            this.tsmStockHold.Text = "Stock Hold";
            this.tsmStockHold.Click += new System.EventHandler(this.TsmStockHold_Click);
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
            // tsbStockConversion
            // 
            this.tsbStockConversion.Name = "tsbStockConversion";
            this.tsbStockConversion.Size = new System.Drawing.Size(171, 22);
            this.tsbStockConversion.Text = "Batch Conversion";
            this.tsbStockConversion.Click += new System.EventHandler(this.TsbStockConversion_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplierPaymentToolStripMenuItem,
            this.tsbDirectCheque,
            this.tsbDebitNote});
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
            // tsbDebitNote
            // 
            this.tsbDebitNote.Name = "tsbDebitNote";
            this.tsbDebitNote.Size = new System.Drawing.Size(183, 22);
            this.tsbDebitNote.Text = "Debit Note";
            this.tsbDebitNote.Click += new System.EventHandler(this.TsbDebitNote_Click);
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
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCity,
            this.tsmCompany,
            this.tsnHSN,
            this.tsmGroup,
            this.tsmSubGroup,
            this.tsmBrand,
            this.tsmUnit,
            this.tsmLocation,
            this.tsmRack,
            this.tsmRackGroup,
            this.tsmProduct,
            this.tsmCategory,
            this.tsmEmployee,
            this.tsmUser,
            this.tsmSupplier,
            this.tsmBroker,
            this.tsmBulkUpdate,
            this.tsmRepresentative});
            this.mastersToolStripMenuItem.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.mastersToolStripMenuItem.Text = "Ma&sters";
            // 
            // tsmCity
            // 
            this.tsmCity.Name = "tsmCity";
            this.tsmCity.Size = new System.Drawing.Size(225, 22);
            this.tsmCity.Text = "City";
            this.tsmCity.Click += new System.EventHandler(this.StateToolStripMenuItem_Click);
            // 
            // tsmCompany
            // 
            this.tsmCompany.Name = "tsmCompany";
            this.tsmCompany.Size = new System.Drawing.Size(225, 22);
            this.tsmCompany.Text = "Company";
            this.tsmCompany.Click += new System.EventHandler(this.TsmCompany_Click);
            // 
            // tsnHSN
            // 
            this.tsnHSN.Name = "tsnHSN";
            this.tsnHSN.Size = new System.Drawing.Size(225, 22);
            this.tsnHSN.Text = "HSN Name";
            this.tsnHSN.Click += new System.EventHandler(this.TsmHSN_Click);
            // 
            // tsmGroup
            // 
            this.tsmGroup.Name = "tsmGroup";
            this.tsmGroup.Size = new System.Drawing.Size(225, 22);
            this.tsmGroup.Text = "Product Group";
            this.tsmGroup.Click += new System.EventHandler(this.TsmGroup_Click);
            // 
            // tsmSubGroup
            // 
            this.tsmSubGroup.Name = "tsmSubGroup";
            this.tsmSubGroup.Size = new System.Drawing.Size(225, 22);
            this.tsmSubGroup.Text = "Product Sub Group";
            this.tsmSubGroup.Click += new System.EventHandler(this.TsmSubGroup_Click);
            // 
            // tsmBrand
            // 
            this.tsmBrand.Name = "tsmBrand";
            this.tsmBrand.Size = new System.Drawing.Size(225, 22);
            this.tsmBrand.Text = "Brand";
            this.tsmBrand.Click += new System.EventHandler(this.TsmBrand_Click);
            // 
            // tsmUnit
            // 
            this.tsmUnit.Name = "tsmUnit";
            this.tsmUnit.Size = new System.Drawing.Size(225, 22);
            this.tsmUnit.Text = "Unit";
            this.tsmUnit.Click += new System.EventHandler(this.TsmUnit_Click);
            // 
            // tsmLocation
            // 
            this.tsmLocation.Name = "tsmLocation";
            this.tsmLocation.Size = new System.Drawing.Size(225, 22);
            this.tsmLocation.Text = "Stock Location";
            this.tsmLocation.Click += new System.EventHandler(this.TsmLocation_Click);
            // 
            // tsmRack
            // 
            this.tsmRack.Name = "tsmRack";
            this.tsmRack.Size = new System.Drawing.Size(225, 22);
            this.tsmRack.Text = "Rack";
            this.tsmRack.Click += new System.EventHandler(this.TsmRack_Click);
            // 
            // tsmRackGroup
            // 
            this.tsmRackGroup.Name = "tsmRackGroup";
            this.tsmRackGroup.Size = new System.Drawing.Size(225, 22);
            this.tsmRackGroup.Text = "Rack Group";
            this.tsmRackGroup.Click += new System.EventHandler(this.TsmRackGroup_Click);
            // 
            // tsmProduct
            // 
            this.tsmProduct.Name = "tsmProduct";
            this.tsmProduct.Size = new System.Drawing.Size(225, 22);
            this.tsmProduct.Text = "Product";
            this.tsmProduct.Click += new System.EventHandler(this.Tsmitem_Click);
            // 
            // tsmCategory
            // 
            this.tsmCategory.Name = "tsmCategory";
            this.tsmCategory.Size = new System.Drawing.Size(225, 22);
            this.tsmCategory.Text = "Employee Category";
            this.tsmCategory.Click += new System.EventHandler(this.TsmuserCategory_Click);
            // 
            // tsmEmployee
            // 
            this.tsmEmployee.Name = "tsmEmployee";
            this.tsmEmployee.Size = new System.Drawing.Size(225, 22);
            this.tsmEmployee.Text = "Employee";
            this.tsmEmployee.Click += new System.EventHandler(this.TsmEmployee_Click);
            // 
            // tsmUser
            // 
            this.tsmUser.Name = "tsmUser";
            this.tsmUser.Size = new System.Drawing.Size(225, 22);
            this.tsmUser.Text = "User";
            this.tsmUser.Click += new System.EventHandler(this.TsmUser_Click);
            // 
            // tsmSupplier
            // 
            this.tsmSupplier.Name = "tsmSupplier";
            this.tsmSupplier.Size = new System.Drawing.Size(225, 22);
            this.tsmSupplier.Text = "Supplier";
            this.tsmSupplier.Click += new System.EventHandler(this.TsmSuppliyer_Click);
            // 
            // tsmBroker
            // 
            this.tsmBroker.Name = "tsmBroker";
            this.tsmBroker.Size = new System.Drawing.Size(225, 22);
            this.tsmBroker.Text = "Broker";
            this.tsmBroker.Click += new System.EventHandler(this.Tsmbroker_Click);
            // 
            // tsmBulkUpdate
            // 
            this.tsmBulkUpdate.Name = "tsmBulkUpdate";
            this.tsmBulkUpdate.Size = new System.Drawing.Size(225, 22);
            this.tsmBulkUpdate.Text = "Product Attributes Bulk Update";
            this.tsmBulkUpdate.Click += new System.EventHandler(this.TsmBulkAttr_Click);
            // 
            // tsmRepresentative
            // 
            this.tsmRepresentative.Name = "tsmRepresentative";
            this.tsmRepresentative.Size = new System.Drawing.Size(225, 22);
            this.tsmRepresentative.Text = "Representative";
            this.tsmRepresentative.Click += new System.EventHandler(this.TsmRepresentative_Click);
            // 
            // tsmControlPanel
            // 
            this.tsmControlPanel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmProMapping,
            this.tsmBatchNoConfig,
            this.tsmVoucherSettings,
            this.tsmGeneralSettings});
            this.tsmControlPanel.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmControlPanel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmControlPanel.Name = "tsmControlPanel";
            this.tsmControlPanel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.tsmControlPanel.ShowShortcutKeys = false;
            this.tsmControlPanel.Size = new System.Drawing.Size(85, 21);
            this.tsmControlPanel.Text = "&Control Panel";
            this.tsmControlPanel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsmProMapping
            // 
            this.tsmProMapping.Name = "tsmProMapping";
            this.tsmProMapping.Size = new System.Drawing.Size(207, 22);
            this.tsmProMapping.Text = "Supplier - Product Mapping";
            this.tsmProMapping.Visible = false;
            this.tsmProMapping.Click += new System.EventHandler(this.TsmsupplierMapping_Click);
            // 
            // tsmBatchNoConfig
            // 
            this.tsmBatchNoConfig.Name = "tsmBatchNoConfig";
            this.tsmBatchNoConfig.Size = new System.Drawing.Size(207, 22);
            this.tsmBatchNoConfig.Text = "Batch No. Configuration";
            this.tsmBatchNoConfig.Visible = false;
            // 
            // tsmVoucherSettings
            // 
            this.tsmVoucherSettings.Name = "tsmVoucherSettings";
            this.tsmVoucherSettings.Size = new System.Drawing.Size(207, 22);
            this.tsmVoucherSettings.Text = "Voucher Settings";
            this.tsmVoucherSettings.Click += new System.EventHandler(this.TsmgeneralSettings_Click);
            // 
            // tsmGeneralSettings
            // 
            this.tsmGeneralSettings.Name = "tsmGeneralSettings";
            this.tsmGeneralSettings.Size = new System.Drawing.Size(207, 22);
            this.tsmGeneralSettings.Text = "General Settings";
            this.tsmGeneralSettings.Click += new System.EventHandler(this.TsmgenralSettings_Click);
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
            this.tsmProfile.Size = new System.Drawing.Size(180, 22);
            this.tsmProfile.Text = "Profile";
            this.tsmProfile.Click += new System.EventHandler(this.tsmChangePassword_Click);
            // 
            // tsmLogout
            // 
            this.tsmLogout.Name = "tsmLogout";
            this.tsmLogout.Size = new System.Drawing.Size(180, 22);
            this.tsmLogout.Text = "Logout";
            this.tsmLogout.Click += new System.EventHandler(this.tsmLogout_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mastersToolStripMenuItem1});
            this.reportToolStripMenuItem.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // mastersToolStripMenuItem1
            // 
            this.mastersToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cityToolStripMenuItem,
            this.stateToolStripMenuItem,
            this.companyToolStripMenuItem,
            this.hSNToolStripMenuItem});
            this.mastersToolStripMenuItem1.Name = "mastersToolStripMenuItem1";
            this.mastersToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.mastersToolStripMenuItem1.Text = "Masters";
            // 
            // cityToolStripMenuItem
            // 
            this.cityToolStripMenuItem.Name = "cityToolStripMenuItem";
            this.cityToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cityToolStripMenuItem.Text = "City";
            this.cityToolStripMenuItem.Click += new System.EventHandler(this.CityToolStripMenuItem_Click);
            // 
            // stateToolStripMenuItem
            // 
            this.stateToolStripMenuItem.Name = "stateToolStripMenuItem";
            this.stateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stateToolStripMenuItem.Text = "State";
            this.stateToolStripMenuItem.Click += new System.EventHandler(this.StateToolStripMenuItem_Click_1);
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.companyToolStripMenuItem.Text = "Company";
            this.companyToolStripMenuItem.Click += new System.EventHandler(this.CompanyToolStripMenuItem_Click);
            // 
            // hSNToolStripMenuItem
            // 
            this.hSNToolStripMenuItem.Name = "hSNToolStripMenuItem";
            this.hSNToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hSNToolStripMenuItem.Text = "HSN";
            this.hSNToolStripMenuItem.Click += new System.EventHandler(this.HSNToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem tsmProfile;
        private System.Windows.Forms.ToolStripMenuItem tsmLogout;
        private System.Windows.Forms.ToolStripMenuItem lblTime;
        private System.Windows.Forms.ToolStripMenuItem lblTimeValue;
        private System.Windows.Forms.ToolStripMenuItem lblDb;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchase;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseentry;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsminward;
        private System.Windows.Forms.ToolStripMenuItem tsmGRN;
        private System.Windows.Forms.ToolStripMenuItem tsmStockTransfer;
        private System.Windows.Forms.ToolStripMenuItem tsmOutward;
        private System.Windows.Forms.ToolStripMenuItem tsmStockRequest;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supplierPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem damageEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmStockReq;
        private System.Windows.Forms.ToolStripMenuItem tsmfromPurchase;
        private System.Windows.Forms.ToolStripMenuItem tsmfromOtherStockLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmGRNApproval;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseDC;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseSupplier;
        private System.Windows.Forms.ToolStripMenuItem tsmAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseEntry1;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseReturn;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseApprove;
        private System.Windows.Forms.ToolStripMenuItem tsmrackSettings;
        private System.Windows.Forms.ToolStripMenuItem tsbDirectCheque;
        private System.Windows.Forms.ToolStripMenuItem tsmStockHold;
        private System.Windows.Forms.ToolStripMenuItem tsbStockConversion;
        private System.Windows.Forms.ToolStripMenuItem tsbDebitNote;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmCity;
        private System.Windows.Forms.ToolStripMenuItem tsmCompany;
        private System.Windows.Forms.ToolStripMenuItem tsnHSN;
        private System.Windows.Forms.ToolStripMenuItem tsmGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmProMapping;
        private System.Windows.Forms.ToolStripMenuItem tsmSubGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmBrand;
        private System.Windows.Forms.ToolStripMenuItem tsmUnit;
        private System.Windows.Forms.ToolStripMenuItem tsmLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmRack;
        private System.Windows.Forms.ToolStripMenuItem tsmRackGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmUser;
        private System.Windows.Forms.ToolStripMenuItem tsmSupplier;
        private System.Windows.Forms.ToolStripMenuItem tsmBroker;
        private System.Windows.Forms.ToolStripMenuItem tsmBulkUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmRepresentative;
        private System.Windows.Forms.ToolStripMenuItem tsmBatchNoConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmVoucherSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmGeneralSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmEmployee;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSNToolStripMenuItem;
    }
}