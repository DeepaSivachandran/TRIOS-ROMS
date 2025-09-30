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
            this.tsbLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmpurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmpurchaseSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGRN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseDC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseMismatchApproval = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseEntry1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmpurchaseApprove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmpurchaseReturnDC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsminward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmfromPurchase_Grn_DC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInwardfromothers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOutward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbBatchConversion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockReconciliation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockHold = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDamageEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockReq = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRackTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockConversion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFinance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDirectChequePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBlockedSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDiscountVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdvance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCreditNote = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSupplierPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChequeTransaction = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGSTRDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDb = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTimeValue = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBank = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHSN = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSubGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBrand = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRackGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProductApproval = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEmployeee = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBroker = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBulkUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockLocationUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMinsalesUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMinMaxUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUnitUppUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProductUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNetGrossUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSubgrupBrandUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHSNUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProCodeUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRepresentative = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRateChange = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStickerPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDirectLabelPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmControlPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProMapping = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBatchNoConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVoucherSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGeneralSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPrinterSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChequePrintSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTally = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExportTally = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMastersReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCityReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmState = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCompanyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHSNReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGroupReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBrokerReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBrandReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProductSubgroupReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockLocationReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRackReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRackGroupReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSupplierReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProductsReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInactiveProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSupplierWiseProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAssigned = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUnassignedProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmZeroRate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPO_GRNReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPOProductWiseReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPOStatusWise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPOSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMGRNSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMGRNDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGRNBatchDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGRNSupplierDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGRNDefectPRoduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseBatchDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseCostDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchasePendingSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchasePendingDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseDefectProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMProductWiseLP = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseCostPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseProductWiseReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseTallyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRateChangeReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseAdditionValue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseDiscountValue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInwardStockReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockInwardReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockOutwardReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockHoldReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockAging = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockValuation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStockVsZeroRate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNonMoving = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFinanceReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSupplierLedgerReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPaymentReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseTaxReports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseBillWiseTaxReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseTCSValueReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAllPurchaseTaxReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchasePeriodWiseTaxReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHSNTaxDetailsSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseHSNReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseHSNWise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPurchaseHSNNameWise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmItemMovementReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMyProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFYSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClearDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClearTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClearMasters = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFinancialYearProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.ms = new System.Windows.Forms.MenuStrip();
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
            this.tsmpurchaseSchedule,
            this.tsmPurchaseOrder,
            this.tsmGRN,
            this.tsmPurchaseDC,
            this.tsmPurchaseMismatchApproval});
            this.tsmpurchase.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.tsmpurchase.Name = "tsmpurchase";
            this.tsmpurchase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.tsmpurchase.Size = new System.Drawing.Size(63, 21);
            this.tsmpurchase.Text = "&Purchase";
            // 
            // tsmpurchaseSchedule
            // 
            this.tsmpurchaseSchedule.Name = "tsmpurchaseSchedule";
            this.tsmpurchaseSchedule.Size = new System.Drawing.Size(214, 22);
            this.tsmpurchaseSchedule.Text = "PO Schedule";
            this.tsmpurchaseSchedule.Click += new System.EventHandler(this.TsmpurchaseSupplier_Click);
            // 
            // tsmPurchaseOrder
            // 
            this.tsmPurchaseOrder.Name = "tsmPurchaseOrder";
            this.tsmPurchaseOrder.Size = new System.Drawing.Size(214, 22);
            this.tsmPurchaseOrder.Text = "Purchase Order";
            this.tsmPurchaseOrder.Click += new System.EventHandler(this.TsmPurchaseOrder_Click_1);
            // 
            // tsmGRN
            // 
            this.tsmGRN.Name = "tsmGRN";
            this.tsmGRN.Size = new System.Drawing.Size(214, 22);
            this.tsmGRN.Text = "GRN Entry";
            this.tsmGRN.Click += new System.EventHandler(this.TsmGRN_Click);
            // 
            // tsmPurchaseDC
            // 
            this.tsmPurchaseDC.Name = "tsmPurchaseDC";
            this.tsmPurchaseDC.Size = new System.Drawing.Size(214, 22);
            this.tsmPurchaseDC.Text = "Purchase DC";
            this.tsmPurchaseDC.Click += new System.EventHandler(this.TsmPurchaseDC_Click);
            // 
            // tsmPurchaseMismatchApproval
            // 
            this.tsmPurchaseMismatchApproval.Name = "tsmPurchaseMismatchApproval";
            this.tsmPurchaseMismatchApproval.Size = new System.Drawing.Size(214, 22);
            this.tsmPurchaseMismatchApproval.Text = "Purchase Mismatch Approval";
            this.tsmPurchaseMismatchApproval.Click += new System.EventHandler(this.TsmGRNApproval_Click);
            // 
            // tsmAccounts
            // 
            this.tsmAccounts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPurchaseEntry1,
            this.tsmpurchaseApprove,
            this.tsmpurchaseReturnDC});
            this.tsmAccounts.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmAccounts.Name = "tsmAccounts";
            this.tsmAccounts.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.tsmAccounts.Size = new System.Drawing.Size(63, 21);
            this.tsmAccounts.Text = "&Accounts";
            // 
            // tsmPurchaseEntry1
            // 
            this.tsmPurchaseEntry1.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmPurchaseEntry1.Name = "tsmPurchaseEntry1";
            this.tsmPurchaseEntry1.Size = new System.Drawing.Size(191, 22);
            this.tsmPurchaseEntry1.Text = "Purchase Entry";
            this.tsmPurchaseEntry1.Click += new System.EventHandler(this.Tsmpurchaseentry_Click);
            // 
            // tsmpurchaseApprove
            // 
            this.tsmpurchaseApprove.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmpurchaseApprove.Name = "tsmpurchaseApprove";
            this.tsmpurchaseApprove.Size = new System.Drawing.Size(191, 22);
            this.tsmpurchaseApprove.Text = "Purchase Entry Approval";
            this.tsmpurchaseApprove.Click += new System.EventHandler(this.TsmpurchaseApprove_Click);
            // 
            // tsmpurchaseReturnDC
            // 
            this.tsmpurchaseReturnDC.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmpurchaseReturnDC.Name = "tsmpurchaseReturnDC";
            this.tsmpurchaseReturnDC.Size = new System.Drawing.Size(191, 22);
            this.tsmpurchaseReturnDC.Text = "Purchase Return DC";
            this.tsmpurchaseReturnDC.Click += new System.EventHandler(this.TsmpurchaseReturn_Click);
            // 
            // tsmInventory
            // 
            this.tsmInventory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsminward,
            this.tsmOutward,
            this.tsmStockTransfer,
            this.tsbBatchConversion,
            this.tsmStockReconciliation,
            this.tsmStockHold,
            this.tsmDamageEntry,
            this.tsmStockReq,
            this.tsmRackTransfer,
            this.tsmStockConversion});
            this.tsmInventory.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.tsmInventory.Name = "tsmInventory";
            this.tsmInventory.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.tsmInventory.Size = new System.Drawing.Size(64, 21);
            this.tsmInventory.Text = "&Inventory";
            // 
            // tsminward
            // 
            this.tsminward.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmfromPurchase_Grn_DC,
            this.tsmInwardfromothers});
            this.tsminward.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.tsminward.Name = "tsminward";
            this.tsminward.Size = new System.Drawing.Size(174, 22);
            this.tsminward.Text = "Goods Inward";
            this.tsminward.Click += new System.EventHandler(this.Tsminward_Click);
            // 
            // tsmfromPurchase_Grn_DC
            // 
            this.tsmfromPurchase_Grn_DC.Name = "tsmfromPurchase_Grn_DC";
            this.tsmfromPurchase_Grn_DC.Size = new System.Drawing.Size(240, 22);
            this.tsmfromPurchase_Grn_DC.Text = "From Purchase,GRN &&Purchase DC";
            this.tsmfromPurchase_Grn_DC.Click += new System.EventHandler(this.TsmfromPurchase_Click);
            // 
            // tsmInwardfromothers
            // 
            this.tsmInwardfromothers.Name = "tsmInwardfromothers";
            this.tsmInwardfromothers.Size = new System.Drawing.Size(240, 22);
            this.tsmInwardfromothers.Text = "From Others";
            this.tsmInwardfromothers.Click += new System.EventHandler(this.TsmfromOtherStockLocation_Click);
            // 
            // tsmOutward
            // 
            this.tsmOutward.Name = "tsmOutward";
            this.tsmOutward.Size = new System.Drawing.Size(174, 22);
            this.tsmOutward.Text = "Goods Outward";
            this.tsmOutward.Click += new System.EventHandler(this.TsmOutward_Click);
            // 
            // tsmStockTransfer
            // 
            this.tsmStockTransfer.Name = "tsmStockTransfer";
            this.tsmStockTransfer.Size = new System.Drawing.Size(174, 22);
            this.tsmStockTransfer.Text = "Stock Transfer";
            this.tsmStockTransfer.Click += new System.EventHandler(this.TsmStockTransfer_Click);
            // 
            // tsbBatchConversion
            // 
            this.tsbBatchConversion.Name = "tsbBatchConversion";
            this.tsbBatchConversion.Size = new System.Drawing.Size(174, 22);
            this.tsbBatchConversion.Text = "Batch Conversion";
            this.tsbBatchConversion.Click += new System.EventHandler(this.TsbStockConversion_Click);
            // 
            // tsmStockReconciliation
            // 
            this.tsmStockReconciliation.Name = "tsmStockReconciliation";
            this.tsmStockReconciliation.Size = new System.Drawing.Size(174, 22);
            this.tsmStockReconciliation.Text = "Stock Reconciliation";
            this.tsmStockReconciliation.Click += new System.EventHandler(this.tsmStockadjustment_Click);
            // 
            // tsmStockHold
            // 
            this.tsmStockHold.Name = "tsmStockHold";
            this.tsmStockHold.Size = new System.Drawing.Size(174, 22);
            this.tsmStockHold.Text = "Stock Hold";
            this.tsmStockHold.Click += new System.EventHandler(this.TsmStockHold_Click);
            // 
            // tsmDamageEntry
            // 
            this.tsmDamageEntry.Name = "tsmDamageEntry";
            this.tsmDamageEntry.Size = new System.Drawing.Size(174, 22);
            this.tsmDamageEntry.Text = "Damage Entry";
            this.tsmDamageEntry.Click += new System.EventHandler(this.DamageEntryToolStripMenuItem_Click);
            // 
            // tsmStockReq
            // 
            this.tsmStockReq.Name = "tsmStockReq";
            this.tsmStockReq.Size = new System.Drawing.Size(174, 22);
            this.tsmStockReq.Text = "Shop Stock Request";
            this.tsmStockReq.Click += new System.EventHandler(this.TsmStockRequest_Click);
            // 
            // tsmRackTransfer
            // 
            this.tsmRackTransfer.Name = "tsmRackTransfer";
            this.tsmRackTransfer.Size = new System.Drawing.Size(174, 22);
            this.tsmRackTransfer.Text = "Rack Transfer";
            this.tsmRackTransfer.Click += new System.EventHandler(this.TsmrackSettings_Click);
            // 
            // tsmStockConversion
            // 
            this.tsmStockConversion.Name = "tsmStockConversion";
            this.tsmStockConversion.Size = new System.Drawing.Size(174, 22);
            this.tsmStockConversion.Text = "Stock Conversion";
            this.tsmStockConversion.Click += new System.EventHandler(this.tspStockConversion_Click);
            // 
            // tsmFinance
            // 
            this.tsmFinance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDirectChequePrint,
            this.tsmBlockedSupplier,
            this.tsmDiscountVoucher,
            this.tsmAdvance,
            this.tsmCreditNote,
            this.tsmSupplierPayment,
            this.tsmChequeTransaction,
            this.tsmGSTRDetails});
            this.tsmFinance.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmFinance.Name = "tsmFinance";
            this.tsmFinance.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.tsmFinance.ShowShortcutKeys = false;
            this.tsmFinance.Size = new System.Drawing.Size(56, 21);
            this.tsmFinance.Text = "&Finance";
            // 
            // tsmDirectChequePrint
            // 
            this.tsmDirectChequePrint.Name = "tsmDirectChequePrint";
            this.tsmDirectChequePrint.Size = new System.Drawing.Size(183, 22);
            this.tsmDirectChequePrint.Text = "Direct Cheque Printing";
            this.tsmDirectChequePrint.Click += new System.EventHandler(this.TsbDirectCheque_Click);
            // 
            // tsmBlockedSupplier
            // 
            this.tsmBlockedSupplier.Name = "tsmBlockedSupplier";
            this.tsmBlockedSupplier.Size = new System.Drawing.Size(183, 22);
            this.tsmBlockedSupplier.Text = "Blocked Supplier";
            this.tsmBlockedSupplier.Click += new System.EventHandler(this.TsmBlockedSupplier_Click);
            // 
            // tsmDiscountVoucher
            // 
            this.tsmDiscountVoucher.Name = "tsmDiscountVoucher";
            this.tsmDiscountVoucher.Size = new System.Drawing.Size(183, 22);
            this.tsmDiscountVoucher.Text = "Discount Voucher";
            this.tsmDiscountVoucher.Click += new System.EventHandler(this.DiscountVoucherToolStripMenuItem_Click);
            // 
            // tsmAdvance
            // 
            this.tsmAdvance.Name = "tsmAdvance";
            this.tsmAdvance.Size = new System.Drawing.Size(183, 22);
            this.tsmAdvance.Text = "Advance";
            this.tsmAdvance.Click += new System.EventHandler(this.AdvanceToolStripMenuItem_Click);
            // 
            // tsmCreditNote
            // 
            this.tsmCreditNote.Name = "tsmCreditNote";
            this.tsmCreditNote.Size = new System.Drawing.Size(183, 22);
            this.tsmCreditNote.Text = "Credit Note";
            this.tsmCreditNote.Click += new System.EventHandler(this.TsbCreditNote_Click);
            // 
            // tsmSupplierPayment
            // 
            this.tsmSupplierPayment.Name = "tsmSupplierPayment";
            this.tsmSupplierPayment.Size = new System.Drawing.Size(183, 22);
            this.tsmSupplierPayment.Text = "Supplier Payment";
            this.tsmSupplierPayment.Click += new System.EventHandler(this.SupplierPaymentToolStripMenuItem_Click);
            // 
            // tsmChequeTransaction
            // 
            this.tsmChequeTransaction.Name = "tsmChequeTransaction";
            this.tsmChequeTransaction.Size = new System.Drawing.Size(183, 22);
            this.tsmChequeTransaction.Text = "Cheque Transaction";
            this.tsmChequeTransaction.Click += new System.EventHandler(this.TsmChequeTransaction_Click);
            // 
            // tsmGSTRDetails
            // 
            this.tsmGSTRDetails.Name = "tsmGSTRDetails";
            this.tsmGSTRDetails.Size = new System.Drawing.Size(183, 22);
            this.tsmGSTRDetails.Text = "GSTR Details";
            this.tsmGSTRDetails.Click += new System.EventHandler(this.GSTRToolStripMenuItem_Click);
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
            // tsmMaster
            // 
            this.tsmMaster.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCity,
            this.tsmBank,
            this.tsmCompany,
            this.tsmHSN,
            this.tsmGroup,
            this.tsmSubGroup,
            this.tsmBrand,
            this.tsmUnit,
            this.tsmLocation,
            this.tsmRack,
            this.tsmRackGroup,
            this.tsmProduct,
            this.tsmProductApproval,
            this.tsmCategory,
            this.tsmEmployeee,
            this.tsmUser,
            this.tsmSupplier,
            this.tsmBroker,
            this.tsmBulkUpdate,
            this.tsmRepresentative,
            this.tsmRateChange,
            this.tsmStickerPrint,
            this.tsmDirectLabelPrint});
            this.tsmMaster.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmMaster.Name = "tsmMaster";
            this.tsmMaster.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.tsmMaster.Size = new System.Drawing.Size(58, 21);
            this.tsmMaster.Text = "Ma&sters";
            // 
            // tsmCity
            // 
            this.tsmCity.Name = "tsmCity";
            this.tsmCity.Size = new System.Drawing.Size(225, 22);
            this.tsmCity.Text = "City";
            this.tsmCity.Click += new System.EventHandler(this.StateToolStripMenuItem_Click);
            // 
            // tsmBank
            // 
            this.tsmBank.Name = "tsmBank";
            this.tsmBank.Size = new System.Drawing.Size(225, 22);
            this.tsmBank.Text = "Bank";
            this.tsmBank.Click += new System.EventHandler(this.TsmBank_Click);
            // 
            // tsmCompany
            // 
            this.tsmCompany.Name = "tsmCompany";
            this.tsmCompany.Size = new System.Drawing.Size(225, 22);
            this.tsmCompany.Text = "Company";
            this.tsmCompany.Click += new System.EventHandler(this.TsmCompany_Click);
            // 
            // tsmHSN
            // 
            this.tsmHSN.Name = "tsmHSN";
            this.tsmHSN.Size = new System.Drawing.Size(225, 22);
            this.tsmHSN.Text = "HSN Name";
            this.tsmHSN.Click += new System.EventHandler(this.TsmHSN_Click);
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
            // tsmProductApproval
            // 
            this.tsmProductApproval.Name = "tsmProductApproval";
            this.tsmProductApproval.Size = new System.Drawing.Size(225, 22);
            this.tsmProductApproval.Text = "Product Approval";
            this.tsmProductApproval.Click += new System.EventHandler(this.ProductApprovalToolStripMenuItem_Click);
            // 
            // tsmCategory
            // 
            this.tsmCategory.Name = "tsmCategory";
            this.tsmCategory.Size = new System.Drawing.Size(225, 22);
            this.tsmCategory.Text = "Employee Category";
            this.tsmCategory.Click += new System.EventHandler(this.TsmuserCategory_Click);
            // 
            // tsmEmployeee
            // 
            this.tsmEmployeee.Name = "tsmEmployeee";
            this.tsmEmployeee.Size = new System.Drawing.Size(225, 22);
            this.tsmEmployeee.Text = "Employee";
            this.tsmEmployeee.Click += new System.EventHandler(this.TsmEmployee_Click);
            // 
            // tsmUser
            // 
            this.tsmUser.Name = "tsmUser";
            this.tsmUser.Size = new System.Drawing.Size(225, 22);
            this.tsmUser.Text = "System User";
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
            this.tsmBulkUpdate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmStockLocationUpdate,
            this.tsmMinsalesUpdate,
            this.tsmMinMaxUpdate,
            this.tsmUnitUppUpdate,
            this.tsmProductUpdate,
            this.tsmNetGrossUpdate,
            this.tsmSubgrupBrandUpdate,
            this.tsmHSNUpdate,
            this.tsmProCodeUpdate});
            this.tsmBulkUpdate.Name = "tsmBulkUpdate";
            this.tsmBulkUpdate.Size = new System.Drawing.Size(225, 22);
            this.tsmBulkUpdate.Text = "Product Attributes Bulk Update";
            this.tsmBulkUpdate.Click += new System.EventHandler(this.TsmBulkAttr_Click);
            // 
            // tsmStockLocationUpdate
            // 
            this.tsmStockLocationUpdate.Name = "tsmStockLocationUpdate";
            this.tsmStockLocationUpdate.Size = new System.Drawing.Size(245, 22);
            this.tsmStockLocationUpdate.Text = "Stock location, Rack && MSQ";
            this.tsmStockLocationUpdate.Click += new System.EventHandler(this.StockLocationRackMSQToolStripMenuItem_Click);
            // 
            // tsmMinsalesUpdate
            // 
            this.tsmMinsalesUpdate.Name = "tsmMinsalesUpdate";
            this.tsmMinsalesUpdate.Size = new System.Drawing.Size(245, 22);
            this.tsmMinsalesUpdate.Text = "Minsales Qty && Barcode";
            this.tsmMinsalesUpdate.Click += new System.EventHandler(this.MinsalesQtyBarcodeToolStripMenuItem_Click);
            // 
            // tsmMinMaxUpdate
            // 
            this.tsmMinMaxUpdate.Name = "tsmMinMaxUpdate";
            this.tsmMinMaxUpdate.Size = new System.Drawing.Size(245, 22);
            this.tsmMinMaxUpdate.Text = "Min, Max stock && Reorder Qty";
            this.tsmMinMaxUpdate.Click += new System.EventHandler(this.MinMaxStockReorderQtyToolStripMenuItem_Click);
            // 
            // tsmUnitUppUpdate
            // 
            this.tsmUnitUppUpdate.Name = "tsmUnitUppUpdate";
            this.tsmUnitUppUpdate.Size = new System.Drawing.Size(245, 22);
            this.tsmUnitUppUpdate.Text = "Bulk Unit, UPP && Shelf Life";
            this.tsmUnitUppUpdate.Click += new System.EventHandler(this.BulkUnitUPPShelfLifeToolStripMenuItem_Click);
            // 
            // tsmProductUpdate
            // 
            this.tsmProductUpdate.Name = "tsmProductUpdate";
            this.tsmProductUpdate.Size = new System.Drawing.Size(245, 22);
            this.tsmProductUpdate.Text = "Product Category, RM Flag && Batch";
            this.tsmProductUpdate.Click += new System.EventHandler(this.ProductCategoryRMFlagBatchToolStripMenuItem_Click);
            // 
            // tsmNetGrossUpdate
            // 
            this.tsmNetGrossUpdate.Name = "tsmNetGrossUpdate";
            this.tsmNetGrossUpdate.Size = new System.Drawing.Size(245, 22);
            this.tsmNetGrossUpdate.Text = "Net && Gross Weight";
            this.tsmNetGrossUpdate.Click += new System.EventHandler(this.NetGrossWeightToolStripMenuItem_Click);
            // 
            // tsmSubgrupBrandUpdate
            // 
            this.tsmSubgrupBrandUpdate.Name = "tsmSubgrupBrandUpdate";
            this.tsmSubgrupBrandUpdate.Size = new System.Drawing.Size(245, 22);
            this.tsmSubgrupBrandUpdate.Text = "Group, Subgroup && Brand";
            this.tsmSubgrupBrandUpdate.Click += new System.EventHandler(this.GroupSubgroupBrandToolStripMenuItem_Click);
            // 
            // tsmHSNUpdate
            // 
            this.tsmHSNUpdate.Name = "tsmHSNUpdate";
            this.tsmHSNUpdate.Size = new System.Drawing.Size(245, 22);
            this.tsmHSNUpdate.Text = "HSN Name";
            this.tsmHSNUpdate.Click += new System.EventHandler(this.HSNNameToolStripMenuItem_Click);
            // 
            // tsmProCodeUpdate
            // 
            this.tsmProCodeUpdate.Name = "tsmProCodeUpdate";
            this.tsmProCodeUpdate.Size = new System.Drawing.Size(245, 22);
            this.tsmProCodeUpdate.Text = "Pro. Code, Name && Unit";
            this.tsmProCodeUpdate.Click += new System.EventHandler(this.ProCodeNameUnitToolStripMenuItem_Click);
            // 
            // tsmRepresentative
            // 
            this.tsmRepresentative.Name = "tsmRepresentative";
            this.tsmRepresentative.Size = new System.Drawing.Size(225, 22);
            this.tsmRepresentative.Text = "Representative";
            this.tsmRepresentative.Click += new System.EventHandler(this.TsmRepresentative_Click);
            // 
            // tsmRateChange
            // 
            this.tsmRateChange.Name = "tsmRateChange";
            this.tsmRateChange.Size = new System.Drawing.Size(225, 22);
            this.tsmRateChange.Text = "Rate Change";
            this.tsmRateChange.Click += new System.EventHandler(this.tsmRateChange_Click);
            // 
            // tsmStickerPrint
            // 
            this.tsmStickerPrint.Name = "tsmStickerPrint";
            this.tsmStickerPrint.Size = new System.Drawing.Size(225, 22);
            this.tsmStickerPrint.Text = "Sticker Print";
            this.tsmStickerPrint.Click += new System.EventHandler(this.StickerPrintToolStripMenuItem_Click);
            // 
            // tsmDirectLabelPrint
            // 
            this.tsmDirectLabelPrint.Name = "tsmDirectLabelPrint";
            this.tsmDirectLabelPrint.Size = new System.Drawing.Size(225, 22);
            this.tsmDirectLabelPrint.Text = "Direct Label Print";
            this.tsmDirectLabelPrint.Click += new System.EventHandler(this.directLabelPrintToolStripMenuItem_Click);
            // 
            // tsmControlPanel
            // 
            this.tsmControlPanel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmProMapping,
            this.tsmBatchNoConfig,
            this.tsmVoucherSettings,
            this.tsmGeneralSettings,
            this.tsmPrinterSettings,
            this.tsmChequePrintSettings});
            this.tsmControlPanel.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmControlPanel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmControlPanel.Name = "tsmControlPanel";
            this.tsmControlPanel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
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
            // tsmPrinterSettings
            // 
            this.tsmPrinterSettings.Name = "tsmPrinterSettings";
            this.tsmPrinterSettings.Size = new System.Drawing.Size(207, 22);
            this.tsmPrinterSettings.Text = "Printer Settings";
            this.tsmPrinterSettings.Click += new System.EventHandler(this.printerSettingsToolStripMenuItem_Click);
            // 
            // tsmChequePrintSettings
            // 
            this.tsmChequePrintSettings.Name = "tsmChequePrintSettings";
            this.tsmChequePrintSettings.Size = new System.Drawing.Size(207, 22);
            this.tsmChequePrintSettings.Text = "Cheque Print Settings";
            this.tsmChequePrintSettings.Click += new System.EventHandler(this.TsmChequePrintSettings_Click);
            // 
            // tsmTally
            // 
            this.tsmTally.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExportTally});
            this.tsmTally.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmTally.Name = "tsmTally";
            this.tsmTally.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.tsmTally.Size = new System.Drawing.Size(42, 21);
            this.tsmTally.Text = "&Tally";
            // 
            // tsmExportTally
            // 
            this.tsmExportTally.Name = "tsmExportTally";
            this.tsmExportTally.Size = new System.Drawing.Size(131, 22);
            this.tsmExportTally.Text = "Export Tally";
            this.tsmExportTally.Click += new System.EventHandler(this.ExportTallyToolStripMenuItem_Click);
            // 
            // tsmReports
            // 
            this.tsmReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMastersReport,
            this.tsmPO_GRNReport,
            this.tsmPurchaseReport,
            this.tsmInwardStockReport,
            this.tsmFinanceReport,
            this.tsmPurchaseTaxReports,
            this.tsmItemMovementReport});
            this.tsmReports.Font = new System.Drawing.Font("Oswald Regular", 9.75F);
            this.tsmReports.Name = "tsmReports";
            this.tsmReports.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.tsmReports.Size = new System.Drawing.Size(57, 21);
            this.tsmReports.Text = "&Reports";
            // 
            // tsmMastersReport
            // 
            this.tsmMastersReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCityReport,
            this.tsmState,
            this.tsmCompanyReport,
            this.tsmHSNReport,
            this.tsmGroupReport,
            this.tsmBrokerReport,
            this.tsmBrandReport,
            this.tsmProductSubgroupReport,
            this.tsmStockLocationReport,
            this.tsmRackReport,
            this.tsmRackGroupReport,
            this.tsmSupplierReport,
            this.tsmProductsReport,
            this.tsmInactiveProduct,
            this.tsmSupplierWiseProducts,
            this.tsmAssigned,
            this.tsmUnassignedProducts,
            this.tsmZeroRate,
            this.tsmProductCategory});
            this.tsmMastersReport.Name = "tsmMastersReport";
            this.tsmMastersReport.Size = new System.Drawing.Size(191, 22);
            this.tsmMastersReport.Text = "Masters";
            // 
            // tsmCityReport
            // 
            this.tsmCityReport.Name = "tsmCityReport";
            this.tsmCityReport.Size = new System.Drawing.Size(184, 22);
            this.tsmCityReport.Text = "City";
            this.tsmCityReport.Click += new System.EventHandler(this.tsmCityReport_Click);
            // 
            // tsmState
            // 
            this.tsmState.Name = "tsmState";
            this.tsmState.Size = new System.Drawing.Size(184, 22);
            this.tsmState.Text = "State";
            this.tsmState.Click += new System.EventHandler(this.tsmState_Click);
            // 
            // tsmCompanyReport
            // 
            this.tsmCompanyReport.Name = "tsmCompanyReport";
            this.tsmCompanyReport.Size = new System.Drawing.Size(184, 22);
            this.tsmCompanyReport.Text = "Company";
            this.tsmCompanyReport.Click += new System.EventHandler(this.tsmCompanyReport_Click);
            // 
            // tsmHSNReport
            // 
            this.tsmHSNReport.Name = "tsmHSNReport";
            this.tsmHSNReport.Size = new System.Drawing.Size(184, 22);
            this.tsmHSNReport.Text = "HSN";
            this.tsmHSNReport.Click += new System.EventHandler(this.tsmHSNReport_Click);
            // 
            // tsmGroupReport
            // 
            this.tsmGroupReport.Name = "tsmGroupReport";
            this.tsmGroupReport.Size = new System.Drawing.Size(184, 22);
            this.tsmGroupReport.Text = "Product Group";
            this.tsmGroupReport.Click += new System.EventHandler(this.tsmGroupReport_Click);
            // 
            // tsmBrokerReport
            // 
            this.tsmBrokerReport.Name = "tsmBrokerReport";
            this.tsmBrokerReport.Size = new System.Drawing.Size(184, 22);
            this.tsmBrokerReport.Text = "Broker";
            this.tsmBrokerReport.Click += new System.EventHandler(this.tsmBrokerReport_Click);
            // 
            // tsmBrandReport
            // 
            this.tsmBrandReport.Name = "tsmBrandReport";
            this.tsmBrandReport.Size = new System.Drawing.Size(184, 22);
            this.tsmBrandReport.Text = "Brand";
            this.tsmBrandReport.Click += new System.EventHandler(this.tsmBrandReport_Click);
            // 
            // tsmProductSubgroupReport
            // 
            this.tsmProductSubgroupReport.Name = "tsmProductSubgroupReport";
            this.tsmProductSubgroupReport.Size = new System.Drawing.Size(184, 22);
            this.tsmProductSubgroupReport.Text = "Product Subgroup";
            this.tsmProductSubgroupReport.Click += new System.EventHandler(this.tsmProductSubgroupReport_Click);
            // 
            // tsmStockLocationReport
            // 
            this.tsmStockLocationReport.Name = "tsmStockLocationReport";
            this.tsmStockLocationReport.Size = new System.Drawing.Size(184, 22);
            this.tsmStockLocationReport.Text = "Stock Location";
            this.tsmStockLocationReport.Click += new System.EventHandler(this.tsmStockLocationReport_Click);
            // 
            // tsmRackReport
            // 
            this.tsmRackReport.Name = "tsmRackReport";
            this.tsmRackReport.Size = new System.Drawing.Size(184, 22);
            this.tsmRackReport.Text = "Rack";
            this.tsmRackReport.Click += new System.EventHandler(this.tsmRackReport_Click);
            // 
            // tsmRackGroupReport
            // 
            this.tsmRackGroupReport.Name = "tsmRackGroupReport";
            this.tsmRackGroupReport.Size = new System.Drawing.Size(184, 22);
            this.tsmRackGroupReport.Text = "Rack Group";
            this.tsmRackGroupReport.Click += new System.EventHandler(this.tsmRackGroupReport_Click);
            // 
            // tsmSupplierReport
            // 
            this.tsmSupplierReport.Name = "tsmSupplierReport";
            this.tsmSupplierReport.Size = new System.Drawing.Size(184, 22);
            this.tsmSupplierReport.Text = "Supplier";
            this.tsmSupplierReport.Click += new System.EventHandler(this.tsmSupplierReport_Click);
            // 
            // tsmProductsReport
            // 
            this.tsmProductsReport.Name = "tsmProductsReport";
            this.tsmProductsReport.Size = new System.Drawing.Size(184, 22);
            this.tsmProductsReport.Text = "Product";
            this.tsmProductsReport.Click += new System.EventHandler(this.ProductToolStripMenuItem_Click);
            // 
            // tsmInactiveProduct
            // 
            this.tsmInactiveProduct.Name = "tsmInactiveProduct";
            this.tsmInactiveProduct.Size = new System.Drawing.Size(184, 22);
            this.tsmInactiveProduct.Text = "Inactive Product";
            this.tsmInactiveProduct.Click += new System.EventHandler(this.TsmInactiveProduct_Click);
            // 
            // tsmSupplierWiseProducts
            // 
            this.tsmSupplierWiseProducts.Name = "tsmSupplierWiseProducts";
            this.tsmSupplierWiseProducts.Size = new System.Drawing.Size(184, 22);
            this.tsmSupplierWiseProducts.Text = "Supplier wise Products";
            this.tsmSupplierWiseProducts.Click += new System.EventHandler(this.tsmSupplierWiseProducts_Click);
            // 
            // tsmAssigned
            // 
            this.tsmAssigned.Name = "tsmAssigned";
            this.tsmAssigned.Size = new System.Drawing.Size(184, 22);
            this.tsmAssigned.Text = "Assigned Products";
            this.tsmAssigned.Click += new System.EventHandler(this.tsmAssigned_Click);
            // 
            // tsmUnassignedProducts
            // 
            this.tsmUnassignedProducts.Name = "tsmUnassignedProducts";
            this.tsmUnassignedProducts.Size = new System.Drawing.Size(184, 22);
            this.tsmUnassignedProducts.Text = "Unassigned Products";
            this.tsmUnassignedProducts.Click += new System.EventHandler(this.tsmUnassignedProducts_Click);
            // 
            // tsmZeroRate
            // 
            this.tsmZeroRate.Name = "tsmZeroRate";
            this.tsmZeroRate.Size = new System.Drawing.Size(184, 22);
            this.tsmZeroRate.Text = "Zero Rate";
            this.tsmZeroRate.Click += new System.EventHandler(this.TsmZeroRate_Click);
            // 
            // tsmPO_GRNReport
            // 
            this.tsmPO_GRNReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPOProductWiseReport,
            this.tsmPOStatusWise,
            this.tsmPOSummary,
            this.TSMGRNSummary,
            this.TSMGRNDetails,
            this.tsmGRNBatchDetail,
            this.tsmGRNSupplierDetail,
            this.tsmGRNDefectPRoduct});
            this.tsmPO_GRNReport.Name = "tsmPO_GRNReport";
            this.tsmPO_GRNReport.Size = new System.Drawing.Size(191, 22);
            this.tsmPO_GRNReport.Text = "PO && GRN";
            // 
            // tsmPOProductWiseReport
            // 
            this.tsmPOProductWiseReport.Name = "tsmPOProductWiseReport";
            this.tsmPOProductWiseReport.Size = new System.Drawing.Size(179, 22);
            this.tsmPOProductWiseReport.Text = "PO Product Wise";
            this.tsmPOProductWiseReport.Click += new System.EventHandler(this.tsmPOProductWiseReport_Click);
            // 
            // tsmPOStatusWise
            // 
            this.tsmPOStatusWise.Name = "tsmPOStatusWise";
            this.tsmPOStatusWise.Size = new System.Drawing.Size(179, 22);
            this.tsmPOStatusWise.Text = "PO Status Wise";
            this.tsmPOStatusWise.Click += new System.EventHandler(this.tsmPOStatusWise_Click);
            // 
            // tsmPOSummary
            // 
            this.tsmPOSummary.Name = "tsmPOSummary";
            this.tsmPOSummary.Size = new System.Drawing.Size(179, 22);
            this.tsmPOSummary.Text = "PO Summary && Detail";
            this.tsmPOSummary.Click += new System.EventHandler(this.tsmPOSummary_Click);
            // 
            // TSMGRNSummary
            // 
            this.TSMGRNSummary.Name = "TSMGRNSummary";
            this.TSMGRNSummary.Size = new System.Drawing.Size(179, 22);
            this.TSMGRNSummary.Text = "GRN Summary";
            this.TSMGRNSummary.Click += new System.EventHandler(this.TSMGRNSummary_Click);
            // 
            // TSMGRNDetails
            // 
            this.TSMGRNDetails.Name = "TSMGRNDetails";
            this.TSMGRNDetails.Size = new System.Drawing.Size(179, 22);
            this.TSMGRNDetails.Text = "GRN Detail";
            this.TSMGRNDetails.Click += new System.EventHandler(this.TSMGRNDetails_Click);
            // 
            // tsmGRNBatchDetail
            // 
            this.tsmGRNBatchDetail.Name = "tsmGRNBatchDetail";
            this.tsmGRNBatchDetail.Size = new System.Drawing.Size(179, 22);
            this.tsmGRNBatchDetail.Text = "GRN Batch Detail";
            this.tsmGRNBatchDetail.Click += new System.EventHandler(this.tsmGRNBatchDetail_Click);
            // 
            // tsmGRNSupplierDetail
            // 
            this.tsmGRNSupplierDetail.Name = "tsmGRNSupplierDetail";
            this.tsmGRNSupplierDetail.Size = new System.Drawing.Size(179, 22);
            this.tsmGRNSupplierDetail.Text = "GRN Supplier Detail";
            this.tsmGRNSupplierDetail.Click += new System.EventHandler(this.tsmGRNSupplierDetail_Click);
            // 
            // tsmGRNDefectPRoduct
            // 
            this.tsmGRNDefectPRoduct.Name = "tsmGRNDefectPRoduct";
            this.tsmGRNDefectPRoduct.Size = new System.Drawing.Size(179, 22);
            this.tsmGRNDefectPRoduct.Text = "GRN Defect Product";
            this.tsmGRNDefectPRoduct.Click += new System.EventHandler(this.tsmGRNDefectPRoduct_Click);
            // 
            // tsmPurchaseReport
            // 
            this.tsmPurchaseReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPurchaseSummary,
            this.tsmPurchaseDetail,
            this.tsmPurchaseBatchDetails,
            this.tsmPurchaseCostDetails,
            this.tsmPurchasePendingSummary,
            this.tsmPurchasePendingDetail,
            this.tsmPurchaseDefectProduct,
            this.TSMProductWiseLP,
            this.tsmPurchaseCostPrice,
            this.tsmPurchaseProductWiseReport,
            this.tsmPurchaseTallyReport,
            this.tsmRateChangeReport,
            this.tsmPurchaseAdditionValue,
            this.tsmPurchaseDiscountValue});
            this.tsmPurchaseReport.Name = "tsmPurchaseReport";
            this.tsmPurchaseReport.Size = new System.Drawing.Size(191, 22);
            this.tsmPurchaseReport.Text = "Purchase";
            // 
            // tsmPurchaseSummary
            // 
            this.tsmPurchaseSummary.Name = "tsmPurchaseSummary";
            this.tsmPurchaseSummary.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseSummary.Text = "Purchase Summary";
            this.tsmPurchaseSummary.Click += new System.EventHandler(this.tsmPurchaseSummary_Click);
            // 
            // tsmPurchaseDetail
            // 
            this.tsmPurchaseDetail.Name = "tsmPurchaseDetail";
            this.tsmPurchaseDetail.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseDetail.Text = "Purchase Detail";
            this.tsmPurchaseDetail.Click += new System.EventHandler(this.tsmPurchaseDetail_Click);
            // 
            // tsmPurchaseBatchDetails
            // 
            this.tsmPurchaseBatchDetails.Name = "tsmPurchaseBatchDetails";
            this.tsmPurchaseBatchDetails.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseBatchDetails.Text = "Purchase Batch Details";
            this.tsmPurchaseBatchDetails.Click += new System.EventHandler(this.TsmPurchaseBatchDetails_Click);
            // 
            // tsmPurchaseCostDetails
            // 
            this.tsmPurchaseCostDetails.Name = "tsmPurchaseCostDetails";
            this.tsmPurchaseCostDetails.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseCostDetails.Text = "Purchase Cost Details";
            this.tsmPurchaseCostDetails.Click += new System.EventHandler(this.TsmPurchaseCostDetails_Click);
            // 
            // tsmPurchasePendingSummary
            // 
            this.tsmPurchasePendingSummary.Name = "tsmPurchasePendingSummary";
            this.tsmPurchasePendingSummary.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchasePendingSummary.Text = "Purchase Entry Approval Pending Summary";
            this.tsmPurchasePendingSummary.Click += new System.EventHandler(this.tsmPurchasePendingSummary_Click);
            // 
            // tsmPurchasePendingDetail
            // 
            this.tsmPurchasePendingDetail.Name = "tsmPurchasePendingDetail";
            this.tsmPurchasePendingDetail.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchasePendingDetail.Text = "Purchase Entry Approval Pending Detail";
            this.tsmPurchasePendingDetail.Click += new System.EventHandler(this.tsmPurchasePendingDetail_Click);
            // 
            // tsmPurchaseDefectProduct
            // 
            this.tsmPurchaseDefectProduct.Name = "tsmPurchaseDefectProduct";
            this.tsmPurchaseDefectProduct.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseDefectProduct.Text = "Purchase Defect Product";
            this.tsmPurchaseDefectProduct.Click += new System.EventHandler(this.tsmPurchaseDefectProduct_Click);
            // 
            // TSMProductWiseLP
            // 
            this.TSMProductWiseLP.Name = "TSMProductWiseLP";
            this.TSMProductWiseLP.Size = new System.Drawing.Size(280, 22);
            this.TSMProductWiseLP.Text = "Product Wise Last Purchased";
            this.TSMProductWiseLP.Click += new System.EventHandler(this.TsmProductWiseLastPurchase_Click);
            // 
            // tsmPurchaseCostPrice
            // 
            this.tsmPurchaseCostPrice.Name = "tsmPurchaseCostPrice";
            this.tsmPurchaseCostPrice.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseCostPrice.Text = "Purchase Cost Price";
            this.tsmPurchaseCostPrice.Click += new System.EventHandler(this.TsmPurchaseCostPrice_Click);
            // 
            // tsmPurchaseProductWiseReport
            // 
            this.tsmPurchaseProductWiseReport.Name = "tsmPurchaseProductWiseReport";
            this.tsmPurchaseProductWiseReport.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseProductWiseReport.Text = "Purchase Product Wise";
            this.tsmPurchaseProductWiseReport.Click += new System.EventHandler(this.TsmPurchaseProductWiseReport_Click);
            // 
            // tsmPurchaseTallyReport
            // 
            this.tsmPurchaseTallyReport.Name = "tsmPurchaseTallyReport";
            this.tsmPurchaseTallyReport.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseTallyReport.Text = "Purchase Tally";
            this.tsmPurchaseTallyReport.Click += new System.EventHandler(this.TsmPurchaseTallyReport_Click);
            // 
            // tsmRateChangeReport
            // 
            this.tsmRateChangeReport.Name = "tsmRateChangeReport";
            this.tsmRateChangeReport.Size = new System.Drawing.Size(280, 22);
            this.tsmRateChangeReport.Text = "Rate Change";
            this.tsmRateChangeReport.Click += new System.EventHandler(this.tsmRateChangeReport_Click);
            // 
            // tsmPurchaseAdditionValue
            // 
            this.tsmPurchaseAdditionValue.Name = "tsmPurchaseAdditionValue";
            this.tsmPurchaseAdditionValue.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseAdditionValue.Text = "Purchase Addition Value";
            this.tsmPurchaseAdditionValue.Click += new System.EventHandler(this.TsmPurchaseAdditionalValueReport_Click);
            // 
            // tsmPurchaseDiscountValue
            // 
            this.tsmPurchaseDiscountValue.Name = "tsmPurchaseDiscountValue";
            this.tsmPurchaseDiscountValue.Size = new System.Drawing.Size(280, 22);
            this.tsmPurchaseDiscountValue.Text = "Purchase Discount Value";
            this.tsmPurchaseDiscountValue.Click += new System.EventHandler(this.TsmPurchaseDiscountValueReport_Click);
            // 
            // tsmInwardStockReport
            // 
            this.tsmInwardStockReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmStockInwardReport,
            this.tsmStockOutwardReport,
            this.tsmStockReport,
            this.tsmStockHoldReport,
            this.tsmStockAging,
            this.tsmStockValuation,
            this.tsmStockVsZeroRate,
            this.tsmNonMoving});
            this.tsmInwardStockReport.Name = "tsmInwardStockReport";
            this.tsmInwardStockReport.Size = new System.Drawing.Size(191, 22);
            this.tsmInwardStockReport.Text = "Inventory/Stock Report";
            // 
            // tsmStockInwardReport
            // 
            this.tsmStockInwardReport.Name = "tsmStockInwardReport";
            this.tsmStockInwardReport.Size = new System.Drawing.Size(204, 22);
            this.tsmStockInwardReport.Text = "Stock Inward";
            this.tsmStockInwardReport.Click += new System.EventHandler(this.TsmStockInward_Click);
            // 
            // tsmStockOutwardReport
            // 
            this.tsmStockOutwardReport.Name = "tsmStockOutwardReport";
            this.tsmStockOutwardReport.Size = new System.Drawing.Size(204, 22);
            this.tsmStockOutwardReport.Text = "Stock Outward";
            this.tsmStockOutwardReport.Click += new System.EventHandler(this.TsmStockOutward_Click);
            // 
            // tsmStockReport
            // 
            this.tsmStockReport.Name = "tsmStockReport";
            this.tsmStockReport.Size = new System.Drawing.Size(204, 22);
            this.tsmStockReport.Text = "Stock";
            this.tsmStockReport.Click += new System.EventHandler(this.tsmStockReport_Click);
            // 
            // tsmStockHoldReport
            // 
            this.tsmStockHoldReport.Name = "tsmStockHoldReport";
            this.tsmStockHoldReport.Size = new System.Drawing.Size(204, 22);
            this.tsmStockHoldReport.Text = "Stock Hold";
            this.tsmStockHoldReport.Click += new System.EventHandler(this.TsmStockHoldReport_Click);
            // 
            // tsmStockAging
            // 
            this.tsmStockAging.Name = "tsmStockAging";
            this.tsmStockAging.Size = new System.Drawing.Size(204, 22);
            this.tsmStockAging.Text = "Stock Aging";
            this.tsmStockAging.Click += new System.EventHandler(this.TsmStockAging_Click);
            // 
            // tsmStockValuation
            // 
            this.tsmStockValuation.Name = "tsmStockValuation";
            this.tsmStockValuation.Size = new System.Drawing.Size(204, 22);
            this.tsmStockValuation.Text = "Stock Valuation";
            this.tsmStockValuation.Click += new System.EventHandler(this.TsmStockValuation_Click);
            // 
            // tsmStockVsZeroRate
            // 
            this.tsmStockVsZeroRate.Name = "tsmStockVsZeroRate";
            this.tsmStockVsZeroRate.Size = new System.Drawing.Size(204, 22);
            this.tsmStockVsZeroRate.Text = "Stock Vs Zero Rate";
            this.tsmStockVsZeroRate.Click += new System.EventHandler(this.TsmStockVsZeroRate_Click);
            // 
            // tsmNonMoving
            // 
            this.tsmNonMoving.Name = "tsmNonMoving";
            this.tsmNonMoving.Size = new System.Drawing.Size(204, 22);
            this.tsmNonMoving.Text = "Non-Moving Product Stock";
            this.tsmNonMoving.Click += new System.EventHandler(this.tsmNonMoving_Click);
            // 
            // tsmFinanceReport
            // 
            this.tsmFinanceReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSupplierLedgerReport,
            this.tsmPaymentReport});
            this.tsmFinanceReport.Name = "tsmFinanceReport";
            this.tsmFinanceReport.Size = new System.Drawing.Size(191, 22);
            this.tsmFinanceReport.Text = "Finance";
            // 
            // tsmSupplierLedgerReport
            // 
            this.tsmSupplierLedgerReport.Name = "tsmSupplierLedgerReport";
            this.tsmSupplierLedgerReport.Size = new System.Drawing.Size(149, 22);
            this.tsmSupplierLedgerReport.Text = "Supplier Ledger";
            this.tsmSupplierLedgerReport.Click += new System.EventHandler(this.tsmSupplierLEdgerReport_Click);
            // 
            // tsmPaymentReport
            // 
            this.tsmPaymentReport.Name = "tsmPaymentReport";
            this.tsmPaymentReport.Size = new System.Drawing.Size(149, 22);
            this.tsmPaymentReport.Text = "Payment";
            this.tsmPaymentReport.Click += new System.EventHandler(this.TsmPaymentReport_Click);
            // 
            // tsmPurchaseTaxReports
            // 
            this.tsmPurchaseTaxReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPurchaseBillWiseTaxReport,
            this.tsmPurchaseTCSValueReport,
            this.tsmAllPurchaseTaxReport,
            this.tsmPurchasePeriodWiseTaxReport,
            this.tsmHSNTaxDetailsSummary,
            this.tsmPurchaseHSNReport});
            this.tsmPurchaseTaxReports.Name = "tsmPurchaseTaxReports";
            this.tsmPurchaseTaxReports.Size = new System.Drawing.Size(191, 22);
            this.tsmPurchaseTaxReports.Text = "Purchase Tax";
            // 
            // tsmPurchaseBillWiseTaxReport
            // 
            this.tsmPurchaseBillWiseTaxReport.Name = "tsmPurchaseBillWiseTaxReport";
            this.tsmPurchaseBillWiseTaxReport.Size = new System.Drawing.Size(219, 22);
            this.tsmPurchaseBillWiseTaxReport.Text = "Purchase Bill Wise Tax";
            this.tsmPurchaseBillWiseTaxReport.Click += new System.EventHandler(this.TsmPurchaseBillWiseTaxReport_Click);
            // 
            // tsmPurchaseTCSValueReport
            // 
            this.tsmPurchaseTCSValueReport.Name = "tsmPurchaseTCSValueReport";
            this.tsmPurchaseTCSValueReport.Size = new System.Drawing.Size(219, 22);
            this.tsmPurchaseTCSValueReport.Text = "Purchase TCS Value";
            this.tsmPurchaseTCSValueReport.Click += new System.EventHandler(this.TsmPurchaseTCSValueReport_Click);
            // 
            // tsmAllPurchaseTaxReport
            // 
            this.tsmAllPurchaseTaxReport.Name = "tsmAllPurchaseTaxReport";
            this.tsmAllPurchaseTaxReport.Size = new System.Drawing.Size(219, 22);
            this.tsmAllPurchaseTaxReport.Text = "All Purchase Tax";
            this.tsmAllPurchaseTaxReport.Click += new System.EventHandler(this.TsmAllPurchaseTaxReport_Click);
            // 
            // tsmPurchasePeriodWiseTaxReport
            // 
            this.tsmPurchasePeriodWiseTaxReport.Name = "tsmPurchasePeriodWiseTaxReport";
            this.tsmPurchasePeriodWiseTaxReport.Size = new System.Drawing.Size(219, 22);
            this.tsmPurchasePeriodWiseTaxReport.Text = "Purchase Period Wise Tax";
            this.tsmPurchasePeriodWiseTaxReport.Click += new System.EventHandler(this.TsmPurchasePeriodWiseTaxReport_Click);
            // 
            // tsmHSNTaxDetailsSummary
            // 
            this.tsmHSNTaxDetailsSummary.Name = "tsmHSNTaxDetailsSummary";
            this.tsmHSNTaxDetailsSummary.Size = new System.Drawing.Size(219, 22);
            this.tsmHSNTaxDetailsSummary.Text = "HSN Wise Tax Detail Summary";
            this.tsmHSNTaxDetailsSummary.Click += new System.EventHandler(this.tsmHSNTaxDetailsSummary_Click);
            // 
            // tsmPurchaseHSNReport
            // 
            this.tsmPurchaseHSNReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPurchaseHSNWise,
            this.tsmPurchaseHSNNameWise});
            this.tsmPurchaseHSNReport.Name = "tsmPurchaseHSNReport";
            this.tsmPurchaseHSNReport.Size = new System.Drawing.Size(219, 22);
            this.tsmPurchaseHSNReport.Text = "HSN";
            // 
            // tsmPurchaseHSNWise
            // 
            this.tsmPurchaseHSNWise.Name = "tsmPurchaseHSNWise";
            this.tsmPurchaseHSNWise.Size = new System.Drawing.Size(235, 22);
            this.tsmPurchaseHSNWise.Text = "Purchase Hsn Wise ";
            this.tsmPurchaseHSNWise.Click += new System.EventHandler(this.TsmHSNCodeWiseReport_Click);
            // 
            // tsmPurchaseHSNNameWise
            // 
            this.tsmPurchaseHSNNameWise.Name = "tsmPurchaseHSNNameWise";
            this.tsmPurchaseHSNNameWise.Size = new System.Drawing.Size(235, 22);
            this.tsmPurchaseHSNNameWise.Text = "Purchase Hsn Name Wise Product";
            this.tsmPurchaseHSNNameWise.Click += new System.EventHandler(this.TsmHSNNameWiseProductReport_Click);
            // 
            // tsmItemMovementReport
            // 
            this.tsmItemMovementReport.Name = "tsmItemMovementReport";
            this.tsmItemMovementReport.Size = new System.Drawing.Size(191, 22);
            this.tsmItemMovementReport.Text = "Item Movement Analysis";
            this.tsmItemMovementReport.Click += new System.EventHandler(this.tsmItemMovementReport_Click);
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
            // tsmFYSettings
            // 
            this.tsmFYSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmClearDatabase,
            this.tsmFinancialYearProcess});
            this.tsmFYSettings.Font = new System.Drawing.Font("Oswald Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmFYSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmFYSettings.Name = "tsmFYSettings";
            this.tsmFYSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Y)));
            this.tsmFYSettings.Size = new System.Drawing.Size(73, 21);
            this.tsmFYSettings.Text = "F&Y Settings";
            this.tsmFYSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsmClearDatabase
            // 
            this.tsmClearDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmClearTransactions,
            this.tsmClearMasters});
            this.tsmClearDatabase.Name = "tsmClearDatabase";
            this.tsmClearDatabase.Size = new System.Drawing.Size(182, 22);
            this.tsmClearDatabase.Text = "Clear Database";
            // 
            // tsmClearTransactions
            // 
            this.tsmClearTransactions.Name = "tsmClearTransactions";
            this.tsmClearTransactions.Size = new System.Drawing.Size(165, 22);
            this.tsmClearTransactions.Text = "Clear Transactions";
            this.tsmClearTransactions.Click += new System.EventHandler(this.TspClearTransactions_Click);
            // 
            // tsmClearMasters
            // 
            this.tsmClearMasters.Name = "tsmClearMasters";
            this.tsmClearMasters.Size = new System.Drawing.Size(165, 22);
            this.tsmClearMasters.Text = "Clear Masters";
            this.tsmClearMasters.Click += new System.EventHandler(this.TspClearMasters_Click);
            // 
            // tsmFinancialYearProcess
            // 
            this.tsmFinancialYearProcess.Name = "tsmFinancialYearProcess";
            this.tsmFinancialYearProcess.Size = new System.Drawing.Size(182, 22);
            this.tsmFinancialYearProcess.Text = "Financial Year Process";
            this.tsmFinancialYearProcess.Click += new System.EventHandler(this.FinancialYearProcessToolStripMenuItem_Click);
            // 
            // tsmProductCategory
            // 
            this.ms.BackColor = System.Drawing.SystemColors.Menu;
            this.ms.Font = new System.Drawing.Font("Oswald Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLogo,
            this.tsmpurchase,
            this.tsmAccounts,
            this.tsmInventory,
            this.tsmFinance,
            this.lblDb,
            this.tsDLogo,
            this.lblTimeValue,
            this.lblTime,
            this.tsmMaster,
            this.tsmControlPanel,
            this.tsmTally,
            this.tsmReports,
            this.tsmMyProfile,
            this.tsmFYSettings});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.ms.Size = new System.Drawing.Size(1275, 25);
            this.ms.TabIndex = 112;
            this.ms.Text = "ms";
            this.ms.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Ms_ItemClicked);
            this.tsmProductCategory.Name = "tsmProductCategory";
            this.tsmProductCategory.Size = new System.Drawing.Size(184, 22);
            this.tsmProductCategory.Text = "Product Category";
            this.tsmProductCategory.Click += new System.EventHandler(this.tsmProductCategory_Click);
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
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseentry;
        private System.Windows.Forms.ToolStripMenuItem tsmStockRequest;
        private System.Windows.Forms.ToolStripMenuItem tsmEmployee;
        private System.Windows.Forms.ToolStripMenuItem tsbLogo;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchase;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseSchedule;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmGRN;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseDC;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseMismatchApproval;
        private System.Windows.Forms.ToolStripMenuItem tsmAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseEntry1;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseApprove;
        private System.Windows.Forms.ToolStripMenuItem tsmpurchaseReturnDC;
        private System.Windows.Forms.ToolStripMenuItem tsmInventory;
        private System.Windows.Forms.ToolStripMenuItem tsminward;
        private System.Windows.Forms.ToolStripMenuItem tsmfromPurchase_Grn_DC;
        private System.Windows.Forms.ToolStripMenuItem tsmInwardfromothers;
        private System.Windows.Forms.ToolStripMenuItem tsmOutward;
        private System.Windows.Forms.ToolStripMenuItem tsmStockTransfer;
        private System.Windows.Forms.ToolStripMenuItem tsbBatchConversion;
        private System.Windows.Forms.ToolStripMenuItem tsmStockReconciliation;
        private System.Windows.Forms.ToolStripMenuItem tsmStockHold;
        private System.Windows.Forms.ToolStripMenuItem tsmDamageEntry;
        private System.Windows.Forms.ToolStripMenuItem tsmStockReq;
        private System.Windows.Forms.ToolStripMenuItem tsmRackTransfer;
        private System.Windows.Forms.ToolStripMenuItem tsmStockConversion;
        private System.Windows.Forms.ToolStripMenuItem tsmFinance;
        private System.Windows.Forms.ToolStripMenuItem tsmDirectChequePrint;
        private System.Windows.Forms.ToolStripMenuItem tsmBlockedSupplier;
        private System.Windows.Forms.ToolStripMenuItem tsmDiscountVoucher;
        private System.Windows.Forms.ToolStripMenuItem tsmAdvance;
        private System.Windows.Forms.ToolStripMenuItem tsmCreditNote;
        private System.Windows.Forms.ToolStripMenuItem tsmSupplierPayment;
        private System.Windows.Forms.ToolStripMenuItem tsmChequeTransaction;
        private System.Windows.Forms.ToolStripMenuItem tsmGSTRDetails;
        private System.Windows.Forms.ToolStripMenuItem lblDb;
        private System.Windows.Forms.ToolStripMenuItem tsDLogo;
        private System.Windows.Forms.ToolStripMenuItem lblTimeValue;
        private System.Windows.Forms.ToolStripMenuItem lblTime;
        private System.Windows.Forms.ToolStripMenuItem tsmMaster;
        private System.Windows.Forms.ToolStripMenuItem tsmCity;
        private System.Windows.Forms.ToolStripMenuItem tsmBank;
        private System.Windows.Forms.ToolStripMenuItem tsmCompany;
        private System.Windows.Forms.ToolStripMenuItem tsmHSN;
        private System.Windows.Forms.ToolStripMenuItem tsmGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmSubGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmBrand;
        private System.Windows.Forms.ToolStripMenuItem tsmUnit;
        private System.Windows.Forms.ToolStripMenuItem tsmLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmRack;
        private System.Windows.Forms.ToolStripMenuItem tsmRackGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmProductApproval;
        private System.Windows.Forms.ToolStripMenuItem tsmCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmEmployeee;
        private System.Windows.Forms.ToolStripMenuItem tsmUser;
        private System.Windows.Forms.ToolStripMenuItem tsmSupplier;
        private System.Windows.Forms.ToolStripMenuItem tsmBroker;
        private System.Windows.Forms.ToolStripMenuItem tsmBulkUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmStockLocationUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmMinsalesUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmMinMaxUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmUnitUppUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmProductUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmNetGrossUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmSubgrupBrandUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmHSNUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmProCodeUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmRepresentative;
        private System.Windows.Forms.ToolStripMenuItem tsmRateChange;
        private System.Windows.Forms.ToolStripMenuItem tsmStickerPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmDirectLabelPrint;
        private System.Windows.Forms.ToolStripMenuItem tsmControlPanel;
        private System.Windows.Forms.ToolStripMenuItem tsmProMapping;
        private System.Windows.Forms.ToolStripMenuItem tsmBatchNoConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmVoucherSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmGeneralSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmPrinterSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmChequePrintSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmTally;
        private System.Windows.Forms.ToolStripMenuItem tsmExportTally;
        private System.Windows.Forms.ToolStripMenuItem tsmReports;
        private System.Windows.Forms.ToolStripMenuItem tsmMastersReport;
        private System.Windows.Forms.ToolStripMenuItem tsmCityReport;
        private System.Windows.Forms.ToolStripMenuItem tsmState;
        private System.Windows.Forms.ToolStripMenuItem tsmCompanyReport;
        private System.Windows.Forms.ToolStripMenuItem tsmHSNReport;
        private System.Windows.Forms.ToolStripMenuItem tsmGroupReport;
        private System.Windows.Forms.ToolStripMenuItem tsmBrokerReport;
        private System.Windows.Forms.ToolStripMenuItem tsmBrandReport;
        private System.Windows.Forms.ToolStripMenuItem tsmProductSubgroupReport;
        private System.Windows.Forms.ToolStripMenuItem tsmStockLocationReport;
        private System.Windows.Forms.ToolStripMenuItem tsmRackReport;
        private System.Windows.Forms.ToolStripMenuItem tsmRackGroupReport;
        private System.Windows.Forms.ToolStripMenuItem tsmSupplierReport;
        private System.Windows.Forms.ToolStripMenuItem tsmProductsReport;
        private System.Windows.Forms.ToolStripMenuItem tsmInactiveProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmSupplierWiseProducts;
        private System.Windows.Forms.ToolStripMenuItem tsmAssigned;
        private System.Windows.Forms.ToolStripMenuItem tsmUnassignedProducts;
        private System.Windows.Forms.ToolStripMenuItem tsmZeroRate;
        private System.Windows.Forms.ToolStripMenuItem tsmPO_GRNReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPOProductWiseReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPOStatusWise;
        private System.Windows.Forms.ToolStripMenuItem tsmPOSummary;
        private System.Windows.Forms.ToolStripMenuItem TSMGRNSummary;
        private System.Windows.Forms.ToolStripMenuItem TSMGRNDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmGRNBatchDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmGRNSupplierDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmGRNDefectPRoduct;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseSummary;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseBatchDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseCostDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchasePendingSummary;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchasePendingDetail;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseDefectProduct;
        private System.Windows.Forms.ToolStripMenuItem TSMProductWiseLP;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseCostPrice;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseProductWiseReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseTallyReport;
        private System.Windows.Forms.ToolStripMenuItem tsmRateChangeReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseAdditionValue;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseDiscountValue;
        private System.Windows.Forms.ToolStripMenuItem tsmInwardStockReport;
        private System.Windows.Forms.ToolStripMenuItem tsmStockInwardReport;
        private System.Windows.Forms.ToolStripMenuItem tsmStockOutwardReport;
        private System.Windows.Forms.ToolStripMenuItem tsmStockReport;
        private System.Windows.Forms.ToolStripMenuItem tsmStockHoldReport;
        private System.Windows.Forms.ToolStripMenuItem tsmStockAging;
        private System.Windows.Forms.ToolStripMenuItem tsmStockValuation;
        private System.Windows.Forms.ToolStripMenuItem tsmStockVsZeroRate;
        private System.Windows.Forms.ToolStripMenuItem tsmNonMoving;
        private System.Windows.Forms.ToolStripMenuItem tsmFinanceReport;
        private System.Windows.Forms.ToolStripMenuItem tsmSupplierLedgerReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPaymentReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseTaxReports;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseBillWiseTaxReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseTCSValueReport;
        private System.Windows.Forms.ToolStripMenuItem tsmAllPurchaseTaxReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchasePeriodWiseTaxReport;
        private System.Windows.Forms.ToolStripMenuItem tsmHSNTaxDetailsSummary;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseHSNReport;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseHSNWise;
        private System.Windows.Forms.ToolStripMenuItem tsmPurchaseHSNNameWise;
        private System.Windows.Forms.ToolStripMenuItem tsmItemMovementReport;
        private System.Windows.Forms.ToolStripMenuItem tsmMyProfile;
        private System.Windows.Forms.ToolStripMenuItem tsmProfile;
        private System.Windows.Forms.ToolStripMenuItem tsmLogout;
        private System.Windows.Forms.ToolStripMenuItem tsmFYSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmClearDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmClearTransactions;
        private System.Windows.Forms.ToolStripMenuItem tsmClearMasters;
        private System.Windows.Forms.ToolStripMenuItem tsmFinancialYearProcess;
        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem tsmZeroRate;
        private System.Windows.Forms.ToolStripMenuItem tsmInactiveProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmPaymentReport;
        private System.Windows.Forms.ToolStripMenuItem tsmStockReconciliation;
        private System.Windows.Forms.ToolStripMenuItem tspStockConversion;
        private System.Windows.Forms.ToolStripMenuItem tsmHSNTaxDetailsSummary;
        private System.Windows.Forms.ToolStripMenuItem tsmProductCategory;
    }
}