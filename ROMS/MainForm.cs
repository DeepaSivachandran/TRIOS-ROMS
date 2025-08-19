                  using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using ROMS.Model;

namespace ROMS
{
    public partial class MainForm : Form
    {
        //------- Servic Class object declaration
        DataValidation objValidation = new DataValidation();
        public DataError objError = new DataError();
        //------- Variable Declaration
        public static int PbDeleteFlag = 0;
        public static string PbCurrentForm = "0";
        public static int pbCloseForm = 0;
        public static int varCloseFlag = 0;
        public static int varFormDisable = 0;
        public static string pbVersion = "1.0.1";
        public static string pbUserID = "";
        public static string pbUserName = "";
        public static string pbLoginId = "";
        public static string pbUserRoleId;
        public static string pbView;
        public static string pbSelectedMenu;
        public static string pbIpAddress = "";
        public static string pbHostName = "";
        public static string pbUserRoleName = "";
        public static string pbUserPassKey = "";
        public static string pbUserPassKeyValue = "";
        public static string pbReleaseDt = "";
        public static string pbSSSSoftwareName = "";
        public static string pbRomsSoftwareName = "";
        public static int pbDefaultComId = 0;
        public static int pbShelflifeLevel1 = 0;
        public static int pbShelflifeLevel2 = 0;
        public static bool isFormClosed = false;
        public static bool isClose = false;
        public static bool isFormClosedMenu = false;
        public static DateTime pbCurrentDate, pbFYStartDate, pbFYEndDate;
        //------- Form object declaration
        public static MainForm objMainForm;
        public static DEF_Start objStart;
        public static CP_ChangePassword objCP_ChangePassword;
        public static CP_ChangePasswordConfirmation objCP_ChangePasswordConfirmation;
        public static CP_BrandList objCP_BrandList;
        public static CP_Brand objCP_Brand;
        public static CP_Company objCP_Company;
        public static CP_Supplier objCP_Supplier;
        public static CP_Supplierlist objCP_Supplierlist;
        public static CP_Companylist objCP_Companylist;
        public static CP_ProductHSN objCP_ProductHSN;
        public static CP_ProductHSNList objCP_ProductHSNlist;
        public static CP_ProductHSN_Verify objCP_ProductHSN_Verify;
        public static CP_Unitlist objCP_Unitlist;
        public static CP_Unit objCP_Unit;
        public static CP_City objCP_City;
        public static CP_Citylist objCP_Citylist;
        public static CP_GroupList objCP_GroupList;
        public static CP_Group objCP_Group;
        public static CP_SubGroupList objCP_SubGroupList;
        public static CP_SubGroup objCP_SubGroup;
        public static CP_LocationList objCP_LocationList;
        public static CP_Location objCP_Location;
        public static CP_SL_Verify objCP_SL_Verify;
        public static CP_Rack objCP_Rack;
        public static CP_RackList objCP_RackList;
        public static CP_UserList objCP_Userlist;
        public static CP_User objCP_User;
        public static CP_PurchaseList objCP_PurchaseList;
        public static CP_SupplierMappinglist objCP_SupplierMappinglist;
        public static CP_Product objCP_Items;
        public static CP_RackSettinglist objCP_RackSettinglist;
        public static CP_RackSettings objCP_RackSettings;
        public static CP_ProductList objCP_Itemlist;
        public static CP_ProductDetails objCP_ProductDetails;
        public static CP_Purchase_Inward objCP_Purchase_Inward;
        public static CP_Purchase_PO objCP_Purchase_PO;
        public static CP_SupplierMapping objCP_SupplierMapping;
        public static CP_Purchase objCP_Purchase;
        public static CP_BatchNoConfiguration objCP_BatchNoConfiguration;
        public static CP_BatchNoConfigurationList objCP_BatchNoConfigurationList;
        public static CP_RackGroup objCP_RackGroup;
        public static CP_RackGroupList objCP_RackGroupList;
        public static CP_Settings objCP_Settings;
        public static CP_BrokerList objCP_CP_BrokerList;
        public static CP_Broker objCP_CP_Broker;
        public static CP_UserCategoryList objCP_UserCategoryList;
        public static CP_UserCategory objCP_UserCategory;
        public static CP_SupplierOrderDetailsList objCP_SupplierOrderDetailslist;
        public static CP_SupplierOrderDetails objCP_SupplierOrderDetails;
        public static CP_GeneralSettings objCP_GeneralSettings;
        public static CP_BulkAttributes objCP_BulkAttributes;
        public static CP_BulkAttributeVerify objCP_BulkAttributeVerify;
        public static CP_RepresentativeList objCP_RepresentativeList;
        public static CP_Representative objCP_Representative;
        public static CP_EmployeeList objCP_EmployeeList;
        public static CP_Employee objCP_Employee;
        public static CP_SupplierPopup objCP_SupplierPopup;
        public static CP_Verify objCP_Verify;
        public static ReportLoad objReportLoad;
        public static CP_ProductApprovalList objCP_ProductApprovalList;
        public static CP_ProductApproval objCP_ProductApproval;
        public static CP_Tally objCP_Tally;
        public static LabelCount objLabelCount;
        public static CP_Rate_ChangeList objCP_Rate_ChangeList;
        public static CP_Rate_Change objCP_Rate_Change;
        public static CP_StickerPrint objCP_StickerPrint;
        // added by venkat on 09-08-2025
        public static CP_DirectLabelPrint objCP_DiectLabelPrint;
        public static CP_Printer_Setting objCP_PrinterSetting;
        //Added by sivabharathi on 14/08/2025
        public static CP_BankList objCP_BankList;
        public static CP_Bank  objCP_Bank;

        public static PUR_ReturnDCList objINV_SalesInvoiceList;
        public static PUR_ReturnDCApprovedList objPUR_ReturnApprovedList;
        public static INV_SalesInvoice objINV_SalesInvoice;
        public static INV_GRNPODamaged objINV_GRNPODamaged;
        public static INV_StockRequestList objINV_StockRequestList;
        public static INV_StockRequest objINV_StockRequest;
        public static INV_GodownOutward objINV_GodownOutward;
        public static INV_GodownOutwardList objINV_GodownOutwardList;
        public static INV_Inwardlist objINV_Inwardlist;
        public static INV_Inward objINV_Inward;
        public static INV_StockTransfer objINV_StockTransfer;
        public static INV_StockTransferQueue objINV_StockTransferQueue;
        public static PUR_PurchaseEntryApprovedList objPUR_PurchaseEntryApprovedList;
        public static INV_StockTransferList objINV_StockTransferList;
        public static INV_DamageEntryList objINV_DamageEntryList;
        public static INV_DamageEntry objINV_DamageEntry;
        public static INV_InwardPurchaseList objINV_InwardPurchaseList;
        public static INV_InwardPurchase objINV_InwardPurchase;
        public static INV_StockHold objINV_StockHold;
        public static INV_StockHold_Location objINV_StockHold_Location;
        public static INV_StockHold_Supplier objINV_StockHold_Supplier;
        public static INV_StockHold_Damages objINV_StockHold_Damages;
        public static INV_StockHold_Verify objINV_StockHold_Verify;
        public static INV_StockConversionList objINV_StockConversionList;
        public static INV_StockConversion objINV_StockConversion;
        public static INV_InwardQueueList objINV_InwardQueueList;
        public static INV_InwardlistQueue objINV_InwardlistQueue;
        public static PUR_PurchaseEntryApproval_Copy objPUR_PurchaseEntryApproval_Copy;
        public static PUR_PurchaseEntryApproval objPUR_PurchaseEntryApproval;

        public static PUR_PurchaseApproval objPUR_PurchaseApproval;
        public static PUR_PurchaseApprovalList objPUR_PurchaseApprovalList;  
        public static PUR_PurchaseEntryRejectedList objPUR_PurchaseEntryRejectedList;  
        public static PUR_PurchaseOrder objPUR_PurchaseOrder;
        public static PUR_PODamaged objPUR_PODamaged;
        public static PUR_SupplierScheduleList objPUR_SupplierScheduleList;
        public static PUR_GRNDetailsList objPUR_GRNDetailsList;
        public static PUR_GRNDetails objPUR_GRNDetails;
        public static PUR_GRNVerify objPUR_GRNVerify;
        public static PUR_GRNEntryVerify objPUR_GRNEntryVerify;
        public static PUR_GRNOrderType objPUR_GRNOrderType;
        public static PUR_Purchase_GRNDetails objPUR_Purchase_GRNDetails;
        public static PUR_Product objPUR_Product;
        public static PUR_PurchaseOrderDamage objPUR_PurchaseOrderDamage;
        public static PUR_CreditnoteDetails objPUR_CreditnoteDetails;
        public static PUR_PurchaseOrderList objPUR_PurchaseOrderList;
        public static PUR_SupplierSchedule objPUR_SupplierSchedule;
        public static PUR_PurchaseReturns objPUR_PurchaseReturns;
        public static PUR_RemarksHistory objPUR_RemarksHistory;
        public static PUR_PurchaseRemarksHistory objPUR_PurchaseRemarksHistory;
        public static INV_InwardQueueList_Remarks objINV_InwardQueueList_Remarks;
        public static PUR_POReturns objPUR_POReturns;
        public static PUR_BulkUnit objPUR_BulkUnit;
        public static PUR_DCGoodsInward objPUR_DCGoodsInward;
        public static PUR_GRNApprovalList objPUR_GRNApprovalList;
        public static PUR_GRNApproval objPUR_GRNApproval;
        public static PUR_GRNEntry objPUR_GRNEntry;
        public static PUR_POProducts objPUR_POProducts;
        public static PUR_DCProducts objPUR_DCProducts;
        public static PUR_GRNProducts objPUR_GRNProducts;
        public static PUR_POMappedProducts objPUR_POMappedProducts;
        public static PUR_POIssuedDetails objPUR_POIssuedDetails;
        public static PUR_POScheduledaywise objPUR_POScheduledaywise;
        public static PUR_GSTIN objPUR_GSTIN;
        public static GRN_GSTIN objGRN_GSTIN;
        public static PUR_GSTINVerify objPUR_GSTINVerify;
        public static PUR_PurchaseDCList objPUR_PurchaseDCList;
        public static PUR_PurchaseDC objPUR_PurchaseDC;
        public static PUR_DCDeatils objPUR_DCDeatils;
        public static PUR_PODamagedView objPUR_PODamagedView;
        public static PUR_PurchaseQueue objPUR_PurchaseQueue;
        public static PUR_GRNApprovalVerify objPUR_GRNApprovalVerify;
        public static PUR_Calculator objPUR_Calculator;
        public static PUR_ApprovalCalculator objPUR_ApprovalCalculator;
        public static PUR_POScheduleSummary objPUR_POScheduleSummary;
        public static PUR_GRN_Level_Verified objPUR_GRN_Level_Verified;
        public static PUR_DC_Level_Verified objPUR_DC_Level_Verified;
        public static PUR_Purchase_Level_Verified objPUR_Purchase_Level_Verified;
        public static PUR_DC_PrintPopUp objPUR_DC_PrintPopUp;
        public static PO_Details objPO_Details;
        public static PUR_RemainingProductList objPUR_RemainingProductList;

        public static PAY_SupplierPaymentList objPAY_SupplierPaymentList;
        public static PAY_SupplierPayment objPAY_SupplierPayment;
        public static PAY_ChequePrint objPAY_ChequePrint;
        public static PAY_CreditNoteList objPAY_CreditNoteList;
        public static PAY_CreditNote objPAY_CreditNote;
        public static PAY_AdvanceList objPAY_AdvanceList;
        public static PAY_GSTRDetails objPAY_GSTRDetails;
        public static PAY_Advance objPAY_Advance;
        public static PAY_ADV objPAY_Advance_Popup;
        public static PAY_BlockedSupplier objPAY_BlockedSupplier;
        public static PAY_DiscountVoucherList objPAY_DiscountVoucherList;
        public static PAY_DiscountVoucher objPAY_DiscountVoucher;
        public static PAY_SupplierPayment_BankDate objPAY_SupplierPayment_BankDate;

        public static REPORT_CP_City objREPORT_CP_City;
        public static REPORT_CP_State objREPORT_CP_State;
        public static REPORT_CP_Company objREPORT_CP_Company;
        public static REPORT_CP_HSN objREPORT_CP_HSN;
        public static REPORT_CP_Product_Group objREPORT_CP_Product_Group;
        public static REPORT_CP_Broker objREPORT_CP_Broker;
        public static REPORT_CP_Brand objREPORT_CP_Brand;
        public static REPORT_CP_Product_Subgroup objREPORT_CP_Product_Subgroup;
        public static REPORT_CP_StockLocation objREPORT_CP_StockLocation;
        public static REPORT_CP_Rack objREPORT_CP_Rack;
        public static REPORT_CP_Rackgroup objREPORT_CP_Rackgroup;
        public static REPORT_CP_Supplier objREPORT_CP_Supplier;
        public static REPORT_CP_Product objREPORT_CP_Product;

        public static REPORT_Stock objREPORT_Stock;
        public static REPORT_Stock_Hold objREPORT_Stock_Hold;
        public static REPORT_Stock_Aging objREPORT_Stock_Aging;
        public static REPORT_Godown_Valuation objREPORT_Godown_Valuation;
        public static REPORT_Stock_Valuation objREPORT_Stock_Valuation;
        public static REPORT_StockVsZeroRate objREPORT_StockVsZeroRate;

        public static REPORT_ItemMovementAnalysis objREPORT_ItemMovementAnalysis;
        public static REPORT_PUR_PurchaseOrder objREPORT_PUR_PurchaseOrder;
        public static REPORT_PUR_Purchaseorder_Summary objREPORT_PUR_Purchaseorder_Summary;
        public static REPORT_GRNSummary objREPORT_GRNSummary;
        public static REPORT_GRN_Details objREPORT_GRN_Details;
        public static REPORT_GRN_Batch_Detail objREPORT_GRN_Batch_Detail;
        public static REPORT_GRN_Supplier_Detail objREPORT_GRN_Supplier_Detail;
        public static REPORT_GRN_Defect_Product objREPORT_GRN_Defect_Product;
        public static REPORT_SupplierWiseProduct objREPORT_SupplierWiseProduct;
        public static REPORT_Unassigned_Products objREPORT_Unassigned_Products;
        public static REPORT_Assigned_Products objREPORT_Assigned_Products;
        public static REPORT_Suppllier_Ledger objREPORT_Suppllier_Ledger;
        public static REPORT_PurchaseOrder_Summary objREPORT_PurchaseOrder_Summary;
        public static REPORT_PurchaseOrder_Detail objREPORT_PurchaseOrder_Detail;
        public static REPORT_ProductWise_Po objREPORT_ProductWise_Po;

        public static REPORT_Purchase_Summary objREPORT_Purchase_Summary;
        public static REPORT_Purchase_Details objREPORT_Purchase_Details;
        public static REPORT_Unapproved_Purchase_Summary objREPORT_Unapproved_Purchase_Summary;
        public static REPORT_Unapproved_Purchase_Detail objREPORT_Unapproved_Purchase_Detail;
        public static REPORT_Purchase_Defect_Product objREPORT_Purchase_Defect_Product;
        public static REPORT_PUR_ProductWiseSummaryDetails objREPORT_PUR_ProductWiseSummaryDetails;
        public static REPORT_PUR_CostPrice objREPORT_PUR_CostPrice;
        public static REPORT_PUR_ProductWiseLastPurchase objREPORT_PUR_ProductWiseLastPurchase;
        public static REPORT_PUR_Tally objREPORT_PUR_Tally;
        public static REPORT_PUR_BatchDetails objREPORT_PUR_BatchDetails;
        public static REPORT_PUR_CostDetails objREPORT_PUR_CostDetails;

        public static REPORT_PUR_BillWiseTax objREPORT_PUR_BillWiseTax;
        public static REPORT_PUR_PeriodWiseTax objREPORT_PUR_PeriodWiseTax;
        public static REPORT_PUR_AdditionalValue objREPORT_PUR_AdditionalValue;
        public static REPORT_PUR_DiscountValue objREPORT_PUR_DiscountValue;
        public static REPORT_PUR_AllTax objREPORT_PUR_AllTax;

        public static REPORT_HSN_Code objREPORT_HSN_Code;
        public static REPORT_HSN_Name objREPORT_HSN_Name;
        public static REPORT_HSN_NameWise_Product objREPORT_HSN_NameWise_Product;
        public static REPORT_HSN_NameWise_Product_Consolidated objREPORT_HSN_NameWise_Product_Consolidated;
        public static REPORT_CP_RateChange objREPORT_CP_RateChange;

        public static REPORT_Stock_Inward objREPORT_Stock_Inward;
        public static REPORT_Stock_Outward objREPORT_Stock_Outward;


        public static Financial_Year_Process objFinancial_Year_Process;
        //public static CP_SL_Verify objCP_SL_Verify;
        public static DataTable objDtMenuDetails;
        public static DataTable objDtMenuCloseDet;

        public MainForm()
        {
            try
            {
                InitializeComponent();
                objValidation.setFontAndFontSize(this);
                timer1.Start();
                //ms.Renderer = new CustomMenuStripRenderer();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        //Close Form
        public void udfnCloseChildForms()
        {
            try
            {
                String Str_ChildForm = "";
                Boolean Bln_NoChildForm = true;
                foreach (Form child in MdiChildren)
                {
                    Bln_NoChildForm = false;
                    bool isFound = false;
                    isFound = IsFrmOpen(child);
                    if (child.Name == "DEF_Start" || Str_ChildForm != "")
                    {
                        child.Close();
                        isClose = true;
                        return;
                    }
                    bool exists = false;
                    if (objDtMenuCloseDet != null)
                    {
                        exists = objDtMenuCloseDet.AsEnumerable().Where(c => c.Field<string>("MenuName").Equals(child.Text) && c.Field<int>("CloseFlag").Equals(0)).Count() > 0;
                    }
                    if (isFound == true && exists == false)
                    {
                        //DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (dialogResult == DialogResult.Yes)
                        //{
                        //    child.Close();
                        //    isClose = true;
                        //}
                        //else { isClose = false; }
                        child.Close();
                        isClose = true;
                        Str_ChildForm = child.Name;
                        //isFormClosedMenu = true ;
                    }
                    else { child.Close(); }
                    //isClose = false;
                }
                if (Bln_NoChildForm == true) { isClose = true; }
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public bool IsFrmOpen(Form nameForm)
        {
            bool isFound = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == nameForm.Name)
                {
                    isFound = true;
                }
            }
            return isFound;
        }
        public void udfnGetDefaultCompany() {
            try
            {
                SPDataService objSPDataService = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objSPDataService.udfnCompanyList(11,0,MainForm.pbUserID,MainForm.pbIpAddress,0);
                if (objDs != null) {
                    if (objDs.Tables.Count > 0) {
                        if (objDs.Tables[0].Rows.Count > 0) { pbDefaultComId = Convert.ToInt32(objDs.Tables[0].Rows[0]["COMID"]); }
                    }
                }
                objSPDataService.CloseConnection();
            }
            catch (Exception ex)
            { objError = new DataError(); objError.WriteFile(ex); }
        }
        public void udfnShelflifeLevel()
        {
            try
            {
                SPDataService objSPDataService = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objSPDataService.udfnGeneralSettingList(0);
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            pbShelflifeLevel1 = Convert.ToInt32(objDs.Tables[0].Rows[0]["GS_Level1"]);
                            pbShelflifeLevel2 = Convert.ToInt32(objDs.Tables[0].Rows[0]["GS_Level2"]);
                        }
                    }
                }
                objSPDataService.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError(); objError.WriteFile(ex);
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                GetLocalIPAddress();
                udfnGetDefaultCompany();
                udfnShelflifeLevel();
                GetDate();
                this.Text = "ROMS" + " - " + MainForm.pbVersion + " Release Dt : " + MainForm.pbReleaseDt + " [ " + MainForm.pbSSSSoftwareName + " ]";
                udfnCloseChildForms();
                lblTime.Text = "Welcome " + MainForm.pbUserName + " / " + MainForm.pbUserRoleName + " @ " + MainForm.pbHostName;
                //lblDb.Text = "ROMS DB : "+MainForm.pbRomsSoftwareName;
                objStart = new DEF_Start();
                objStart.MdiParent = this;
                objStart.Show();
            }
            catch (Exception ex)
            { objError = new DataError(); objError.WriteFile(ex); }
        }
        //Close Application when click logout
        private void tsbLogout_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DialogResult objResponse = MessageBox.Show("Are you sure want to Logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    if ((objResponse == DialogResult.Yes))
            //    {
            //        if ((System.Windows.Forms.Application.MessageLoop))
            //        {
            //            varCloseFlag = 1;
            //            System.Windows.Forms.Application.Exit();
            //        }
            //        else
            //        {
            //            System.Environment.Exit(1);
            //        }
            //        Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varFormDisable == 0)
                {
                    if (varCloseFlag == 0)
                    {
                        if (pbCloseForm == 0)
                        {
                            DialogResult objResponse = MessageBox.Show("Are you sure want to logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if ((objResponse == DialogResult.Yes))
                            {
                                e.Cancel = false;
                                varCloseFlag = 1;
                                System.Windows.Forms.Application.Exit();
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            e.Cancel = false;
                            varCloseFlag = 1;
                            System.Windows.Forms.Application.Exit();
                        }
                    }
                }
                if(varFormDisable == 1)
                {
                    this.Cursor = Cursors.No;
                    e.Cancel = true;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog objSaveDialogu = new SaveFileDialog();

                if (objSaveDialogu.ShowDialog() == DialogResult.OK)
                {
                    string varFileName = objSaveDialogu.FileName;
                    SPDataService objSPService = new SPDataService();
                    objSPService.spdbbackup(varFileName);
                    MessageBox.Show("Successfully Downloaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ntfy_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Show();
                WindowState = FormWindowState.Maximized;
                ntfy.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ntfy_Click(object sender, EventArgs e)
        {
            try
            {
                Show();
                WindowState = FormWindowState.Maximized;
                ntfy.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //Get Date
        public void GetDate()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 4;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnMaster(objMR_Master);
                DateTime varDate = DateTime.ParseExact(objDs.Tables[1].Rows[0]["MinToday"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime varFYStartDate = DateTime.ParseExact(objDs.Tables[2].Rows[0]["FY_StartDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime varFYEndDate = DateTime.ParseExact(objDs.Tables[2].Rows[0]["FY_EndDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                pbCurrentDate = varDate;
                pbFYStartDate = varFYStartDate;
                pbFYEndDate = varFYEndDate;
                objspservice.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        //Get IP address
        public void GetLocalIPAddress()
        {
            try
            {
                pbIpAddress = Dns.GetHostAddresses(Dns.GetHostName()).First(a => a.AddressFamily == AddressFamily.InterNetwork).ToString();
            }
            catch (Exception ex) { throw new Exception(ex.ToString()); }
        }
        private void tsbSettings_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClose() {
            try {
                if (pbCloseForm == 0)
                {
                    DialogResult objResponse = MessageBox.Show("Are you sure want to logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if ((objResponse == DialogResult.Yes))
                    {
                        if ((System.Windows.Forms.Application.MessageLoop))
                        {
                            varCloseFlag = 1;
                            System.Windows.Forms.Application.Exit();
                        }
                        else
                        {
                            System.Environment.Exit(1);
                        }
                        Close();
                    }
                }
                else {
                    if ((System.Windows.Forms.Application.MessageLoop))
                    {
                        varCloseFlag = 1;
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        System.Environment.Exit(1);
                    }
                    Close();
                }
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmLogout_Click(object sender, EventArgs e)
        {
            try
            {
                udfnClose();
                //if (pbUserRoleId == "0")
                //{
                //    udfnClose();
                //}
                //else
                //{
                //    if (objDtMenuDetails != null)
                //    {
                //        var varValue = (from r in objDtMenuDetails.AsEnumerable() where r.Field<int>("MenuCode").Equals(Convert.ToInt32(602)) group r by r.Field<int>("PrivilegeCode") into g select g.Key).ToList();
                //        if (varValue.Count() > 0)
                //        {
                //            udfnClose();
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCloseChildForms(Boolean Bln)
        {
            try
            {
                MainForm.objMainForm = new MainForm();
                MainForm.objMainForm.tsmControlPanel.Enabled = Bln;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_ChangePassword = new CP_ChangePassword();
                MainForm.objCP_ChangePassword.MdiParent = this;
                MainForm.objCP_ChangePassword.Show();
                PbCurrentForm = "8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmBrand_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BrandList = new CP_BrandList();
                MainForm.objCP_BrandList.MdiParent = this;
                MainForm.objCP_BrandList.Show();
                PbCurrentForm = "5.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmCompany_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_Companylist = new CP_Companylist();
                MainForm.objCP_Companylist.MdiParent = this;
                MainForm.objCP_Companylist.Show();
                PbCurrentForm = "5.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmSuppliyer_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_Supplierlist = new CP_Supplierlist();
                MainForm.objCP_Supplierlist.MdiParent = this;
                MainForm.objCP_Supplierlist.Show();
                PbCurrentForm = "5.16";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmUnit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_Unitlist = new CP_Unitlist();
                MainForm.objCP_Unitlist.MdiParent = this;
                MainForm.objCP_Unitlist.Show();
                PbCurrentForm = "5.7";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void StateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_Citylist = new CP_Citylist();
                MainForm.objCP_Citylist.MdiParent = this;
                MainForm.objCP_Citylist.Show();
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmGroup_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_GroupList = new CP_GroupList();
                MainForm.objCP_GroupList.MdiParent = this;
                MainForm.objCP_GroupList.Show();
                PbCurrentForm = "5.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmSubGroup_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_SubGroupList = new CP_SubGroupList();
                MainForm.objCP_SubGroupList.MdiParent = this;
                MainForm.objCP_SubGroupList.Show();
                PbCurrentForm = "5.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmUser_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_Userlist = new CP_UserList();
                MainForm.objCP_Userlist.MdiParent = this;
                MainForm.objCP_Userlist.Show();
                PbCurrentForm = "5.15";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmLocation_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_LocationList = new CP_LocationList();
                MainForm.objCP_LocationList.MdiParent = this;
                MainForm.objCP_LocationList.Show();
                PbCurrentForm = "5.8";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Tsmpurchaseentry_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objCP_PurchaseList = new CP_PurchaseList();
                MainForm.objCP_PurchaseList.MdiParent = this;
                MainForm.objCP_PurchaseList.Show();
                PbCurrentForm = "2.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmPurchaseOrder_Click_1(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objPUR_PurchaseOrderList = new PUR_PurchaseOrderList();
                MainForm.objPUR_PurchaseOrderList.MdiParent = this;
                MainForm.objPUR_PurchaseOrderList.Show();
                PbCurrentForm = "1.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmsupplierMapping_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_SupplierMappinglist = new CP_SupplierMappinglist();
                MainForm.objCP_SupplierMappinglist.MdiParent = this;
                MainForm.objCP_SupplierMappinglist.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmrackSettings_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_RackSettings = new CP_RackSettings();
                MainForm.objCP_RackSettings.MdiParent = this;
                MainForm.objCP_RackSettings.Show();
                PbCurrentForm = "3.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Tsmitem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_Itemlist = new CP_ProductList();
                MainForm.objCP_Itemlist.MdiParent = this;
                MainForm.objCP_Itemlist.Show();
                PbCurrentForm = "5.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Tsminward_Click(object sender, EventArgs e)
        {
          
        }
        private void TsmpurchaseApprove_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objPUR_PurchaseApprovalList = new PUR_PurchaseApprovalList();
                MainForm.objPUR_PurchaseApprovalList.MdiParent = this;
                MainForm.objPUR_PurchaseApprovalList.Show();
                PbCurrentForm = "2.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmpurchaseSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objPUR_SupplierScheduleList = new PUR_SupplierScheduleList();
                MainForm.objPUR_SupplierScheduleList.MdiParent = this;
                MainForm.objPUR_SupplierScheduleList.Show();
                PbCurrentForm ="1.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmGRN_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objPUR_GRNDetailsList = new PUR_GRNDetailsList();
                MainForm.objPUR_GRNDetailsList.MdiParent = this;
                MainForm.objPUR_GRNDetailsList.Show();
                PbCurrentForm = "1.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmRack_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_RackList = new CP_RackList();
                MainForm.objCP_RackList.MdiParent = this;
                MainForm.objCP_RackList.Show();
                PbCurrentForm = "5.9";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmRackGroup_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_RackGroupList = new CP_RackGroupList();
                MainForm.objCP_RackGroupList.MdiParent = this;
                MainForm.objCP_RackGroupList.Show();
                PbCurrentForm = "5.10";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Tsmbatchno_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BatchNoConfigurationList = new CP_BatchNoConfigurationList();
                MainForm.objCP_BatchNoConfigurationList.MdiParent = this;
                MainForm.objCP_BatchNoConfigurationList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmStockTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objINV_StockTransferList = new INV_StockTransferList();
                MainForm.objINV_StockTransferList.MdiParent = this;
                MainForm.objINV_StockTransferList.Show();
                PbCurrentForm = "3.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmOutward_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objINV_GodownOutwardList = new INV_GodownOutwardList();
                MainForm.objINV_GodownOutwardList.MdiParent = this;
                MainForm.objINV_GodownOutwardList.Show();
                PbCurrentForm = "3.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmStockRequest_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objINV_StockRequestList = new INV_StockRequestList();
                MainForm.objINV_StockRequestList.MdiParent = this;
                MainForm.objINV_StockRequestList.Show();
                PbCurrentForm = "3.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmgenralSettings_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_GeneralSettings = new CP_GeneralSettings();
                MainForm.objCP_GeneralSettings.MdiParent = this;
                MainForm.objCP_GeneralSettings.Show();
                PbCurrentForm = "6.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Tsmbroker_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_CP_BrokerList = new CP_BrokerList();
                MainForm.objCP_CP_BrokerList.MdiParent = this;
                MainForm.objCP_CP_BrokerList.Show();
                PbCurrentForm = "5.17";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmHSN_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_ProductHSNlist = new CP_ProductHSNList();
                MainForm.objCP_ProductHSNlist.MdiParent = this;
                MainForm.objCP_ProductHSNlist.Show();
                PbCurrentForm = "5.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmpurchaseReturn_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objINV_SalesInvoiceList = new PUR_ReturnDCList();
                MainForm.objINV_SalesInvoiceList.MdiParent = this;
                MainForm.objINV_SalesInvoiceList.Show();
                PbCurrentForm = "2.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }
        private void SupplierPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objPAY_SupplierPaymentList = new PAY_SupplierPaymentList();
                MainForm.objPAY_SupplierPaymentList.MdiParent = this;
                MainForm.objPAY_SupplierPaymentList.Show();
                PbCurrentForm = "4.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmuserCategory_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_UserCategoryList = new CP_UserCategoryList();
                MainForm.objCP_UserCategoryList.MdiParent = this;
                MainForm.objCP_UserCategoryList.Show();
                PbCurrentForm = "5.13";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmSupplierOrder_Click(object sender, EventArgs e)
        {
            
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_SupplierOrderDetailslist = new CP_SupplierOrderDetailsList();
                MainForm.objCP_SupplierOrderDetailslist.MdiParent = this;
                MainForm.objCP_SupplierOrderDetailslist.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DamageEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objINV_DamageEntryList = new INV_DamageEntryList();
                MainForm.objINV_DamageEntryList.MdiParent = this;
                MainForm.objINV_DamageEntryList.Show();
                PbCurrentForm = "3.7";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmfromOtherStockLocation_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objINV_Inwardlist = new INV_Inwardlist();
                MainForm.objINV_Inwardlist.MdiParent = this;
                MainForm.objINV_Inwardlist.Show();
                PbCurrentForm = "3.2.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmfromPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objINV_InwardPurchaseList = new INV_InwardPurchaseList();
                MainForm.objINV_InwardPurchaseList.MdiParent = this;
                MainForm.objINV_InwardPurchaseList.Show();
                PbCurrentForm = "3.2.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmGRNApproval_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objPUR_GRNApprovalList = new PUR_GRNApprovalList();
                MainForm.objPUR_GRNApprovalList.MdiParent = this;
                MainForm.objPUR_GRNApprovalList.Show();
                PbCurrentForm = "1.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmPurchaseDC_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objPUR_PurchaseDCList = new PUR_PurchaseDCList();
                MainForm.objPUR_PurchaseDCList.MdiParent = this;
                MainForm.objPUR_PurchaseDCList.Show();
                PbCurrentForm = "1.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmgeneralSettings_Click(object sender, EventArgs e)
        { 
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_Settings = new CP_Settings();
                MainForm.objCP_Settings.MdiParent = this;
                MainForm.objCP_Settings.Show();
                PbCurrentForm = "6.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBulkAttribute()
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.Show();
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmBulkAttr_Click(object sender, EventArgs e)
        {
            try
            {
                //udfnCloseChildForms();
                //if (isClose == false) { return; }
                //MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                //MainForm.objCP_BulkAttributes.MdiParent = this;
                //MainForm.objCP_BulkAttributes.Show();
                //PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbDirectCheque_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objPAY_ChequePrint = new PAY_ChequePrint();
                MainForm.objPAY_ChequePrint.MdiParent = this;
                MainForm.objPAY_ChequePrint.Show();
                PbCurrentForm = "4.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmStockHold_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objINV_StockHold = new INV_StockHold();
                MainForm.objINV_StockHold.MdiParent = this;
                MainForm.objINV_StockHold.Show();
                PbCurrentForm = "3.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbStockConversion_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objINV_StockConversionList = new INV_StockConversionList();
                MainForm.objINV_StockConversionList.MdiParent = this;
                MainForm.objINV_StockConversionList.Show();
                PbCurrentForm = "3.8";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbCreditNote_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objPAY_CreditNoteList = new PAY_CreditNoteList();
                MainForm.objPAY_CreditNoteList.MdiParent = this;
                MainForm.objPAY_CreditNoteList.Show();
                PbCurrentForm = "4.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmRepresentative_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_RepresentativeList = new CP_RepresentativeList();
                MainForm.objCP_RepresentativeList.MdiParent = this;
                MainForm.objCP_RepresentativeList.Show();
                PbCurrentForm = "5.19";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_EmployeeList = new CP_EmployeeList();
                MainForm.objCP_EmployeeList.MdiParent = this;
                MainForm.objCP_EmployeeList.Show();
                PbCurrentForm = "5.14";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_City = new REPORT_CP_City();
                MainForm.objREPORT_CP_City.MdiParent = this;
                MainForm.objREPORT_CP_City.Show();
                PbCurrentForm = "7.1.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void StateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_State = new REPORT_CP_State();
                MainForm.objREPORT_CP_State.MdiParent = this;
                MainForm.objREPORT_CP_State.Show();
                PbCurrentForm = "7.1.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_Company = new REPORT_CP_Company();
                MainForm.objREPORT_CP_Company.MdiParent = this;
                MainForm.objREPORT_CP_Company.Show();
                PbCurrentForm = "7.1.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void HSNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_HSN = new REPORT_CP_HSN();
                MainForm.objREPORT_CP_HSN.MdiParent = this;
                MainForm.objREPORT_CP_HSN.Show();
                PbCurrentForm = "7.1.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ProductGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_Product_Group = new REPORT_CP_Product_Group();
                MainForm.objREPORT_CP_Product_Group.MdiParent = this;
                MainForm.objREPORT_CP_Product_Group.Show();
                PbCurrentForm = "7.1.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BrokerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_Broker = new REPORT_CP_Broker();
                MainForm.objREPORT_CP_Broker.MdiParent = this;
                MainForm.objREPORT_CP_Broker.Show();
                PbCurrentForm = "7.1.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_Brand = new REPORT_CP_Brand();
                MainForm.objREPORT_CP_Brand.MdiParent = this;
                MainForm.objREPORT_CP_Brand.Show();
                PbCurrentForm = "7.1.7";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ProductSubgroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_Product_Subgroup = new REPORT_CP_Product_Subgroup();
                MainForm.objREPORT_CP_Product_Subgroup.MdiParent = this;
                MainForm.objREPORT_CP_Product_Subgroup.Show();
                PbCurrentForm = "7.1.8";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void StockLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_StockLocation = new REPORT_CP_StockLocation();
                MainForm.objREPORT_CP_StockLocation.MdiParent = this;
                MainForm.objREPORT_CP_StockLocation.Show();
                PbCurrentForm = "7.1.9";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_Rack = new REPORT_CP_Rack();
                MainForm.objREPORT_CP_Rack.MdiParent = this;
                MainForm.objREPORT_CP_Rack.Show();
                PbCurrentForm = "7.1.10";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RackGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_Rackgroup = new REPORT_CP_Rackgroup();
                MainForm.objREPORT_CP_Rackgroup.MdiParent = this;
                MainForm.objREPORT_CP_Rackgroup.Show();
                PbCurrentForm = "7.1.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void SupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_Supplier = new REPORT_CP_Supplier();
                MainForm.objREPORT_CP_Supplier.MdiParent = this;
                MainForm.objREPORT_CP_Supplier.Show();
                PbCurrentForm = "7.1.12";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ProductWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_PurchaseOrder = new REPORT_PUR_PurchaseOrder();
                MainForm.objREPORT_PUR_PurchaseOrder.MdiParent = this;
                MainForm.objREPORT_PUR_PurchaseOrder.Show();
                PbCurrentForm = "7.3.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ProductApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_ProductApprovalList = new CP_ProductApprovalList();
                MainForm.objCP_ProductApprovalList.MdiParent = this;
                MainForm.objCP_ProductApprovalList.Show();
                PbCurrentForm = "5.12";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void SummaryDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_Purchaseorder_Summary = new REPORT_PUR_Purchaseorder_Summary();
                MainForm.objREPORT_PUR_Purchaseorder_Summary.MdiParent = this;
                MainForm.objREPORT_PUR_Purchaseorder_Summary.Show();
                PbCurrentForm = "7.3.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFormLoad()
        {
            try
            {
                if (PbCurrentForm == "1.1")
                {
                    MainForm.objPUR_SupplierScheduleList.udfnList();
                }
                if (PbCurrentForm == "1.2")
                {
                    MainForm.objPUR_PurchaseOrderList.udfnPOEntryLoad();
                }
                if (PbCurrentForm == "1.3")
                {
                    MainForm.objPUR_GRNDetailsList.udfnListLoad();
                }
                if (PbCurrentForm == "1.4")
                {
                    MainForm.objPUR_PurchaseDCList.udfnList();
                }
                if (PbCurrentForm == "1.5")
                {
                    MainForm.objPUR_GRNApprovalList.udfnList();
                }
                if (PbCurrentForm == "2.1")
                {
                    MainForm.objCP_PurchaseList.udfnListLoad();
                }
                if (PbCurrentForm == "2.2")
                {
                    MainForm.objINV_SalesInvoiceList.udfnList();
                }
                if (PbCurrentForm == "2.3")
                {
                    MainForm.objPUR_PurchaseApprovalList.udfnList();
                }
                if (PbCurrentForm == "3.1")
                {

                }
                if (PbCurrentForm == "3.2.1")
                {
                    MainForm.objINV_InwardPurchaseList.udfnList();
                }
                if (PbCurrentForm == "3.2.2")
                {
                    MainForm.objINV_Inwardlist.udfnList();
                }
                if (PbCurrentForm == "3.3")
                {
                    MainForm.objINV_StockHold.udfnList();
                }
                if (PbCurrentForm == "3.4")
                {
                    MainForm.objINV_StockRequestList.udfnList();
                }
                if (PbCurrentForm == "3.5")
                {
                    MainForm.objINV_GodownOutwardList.udfnList();
                }
                if (PbCurrentForm == "3.6")
                {
                    MainForm.objINV_StockTransferList.udfnList();
                }
                if (PbCurrentForm == "3.7")
                {
                    MainForm.objINV_DamageEntryList.udfnTransList();
                }
                if (PbCurrentForm == "3.8")
                {
                    MainForm.objINV_StockConversionList.udfnList();
                }
                if (PbCurrentForm == "4.1")
                {

                }
                if (PbCurrentForm == "4.2")
                {

                }
                if (PbCurrentForm == "4.3")
                {
                    MainForm.objPAY_CreditNoteList.udfnList();
                }
                if (PbCurrentForm == "5.1")
                {
                    MainForm.objCP_Citylist.udfnList();
                }
                if (PbCurrentForm == "5.2")
                {
                    MainForm.objCP_Companylist.udfnList();
                }
                if (PbCurrentForm == "5.3")
                {
                    MainForm.objCP_ProductHSNlist.udfnList();
                }
                if (PbCurrentForm == "5.4")
                {
                    MainForm.objCP_GroupList.udfnList();
                }
                if (PbCurrentForm == "5.5")
                {
                    MainForm.objCP_SubGroupList.udfnList();
                }
                if (PbCurrentForm == "5.6")
                {
                    MainForm.objCP_BrandList.udfnList();
                }
                if (PbCurrentForm == "5.7")
                {
                    MainForm.objCP_Unitlist.udfnList();
                }
                if (PbCurrentForm == "5.8")
                {
                    MainForm.objCP_LocationList.udfnList();
                }
                if (PbCurrentForm == "5.9")
                {
                    MainForm.objCP_RackList.udfnList();
                }
                if (PbCurrentForm == "5.10")
                {
                    MainForm.objCP_RackGroupList.udfnList();
                }
                if (PbCurrentForm == "5.11")
                {
                    MainForm.objCP_Itemlist.udfnList();
                }
                if (PbCurrentForm == "5.12")
                {
                    MainForm.objCP_ProductApprovalList.udfnList();
                }
                if (PbCurrentForm == "5.13")
                {
                    MainForm.objCP_UserCategoryList.udfnList();
                }
                if (PbCurrentForm == "5.14")
                {
                    MainForm.objCP_EmployeeList.udfnList();
                }
                if (PbCurrentForm == "5.15")
                {
                    MainForm.objCP_Userlist.udfnList();
                }
                if (PbCurrentForm == "5.16")
                {
                    MainForm.objCP_Supplierlist.udfnList();
                }
                if (PbCurrentForm == "5.17")
                {
                    MainForm.objCP_CP_BrokerList.udfnList();
                }
                if (PbCurrentForm == "5.18")
                {
                    MainForm.objCP_BulkAttributes.udfnList();
                }
                if (PbCurrentForm == "5.19")
                {
                    MainForm.objCP_RepresentativeList.udfnlist();
                }
                if (PbCurrentForm == "6.1")
                {
                    MainForm.objCP_Settings.udfnList();
                }
                if (PbCurrentForm == "6.2")
                {
                    MainForm.objCP_GeneralSettings.udfnList();
                }
                if (PbCurrentForm == "7.1.1")
                {
                    MainForm.objREPORT_CP_City.udfnCity();
                }
                if (PbCurrentForm == "7.1.2")
                {
                    MainForm.objREPORT_CP_State.udfnState();
                }
                if (PbCurrentForm == "7.1.3")
                {
                    MainForm.objREPORT_CP_Company.udfnList();
                }
                if (PbCurrentForm == "7.1.4")
                {
                    MainForm.objREPORT_CP_HSN.udfnHSN();
                }
                if (PbCurrentForm == "7.1.5")
                {
                    MainForm.objREPORT_CP_Product_Group.udfnProductGroup();
                }
                if (PbCurrentForm == "7.1.6")
                {
                    MainForm.objREPORT_CP_Broker.udfnContact();
                }
                if (PbCurrentForm == "7.1.7")
                {
                    MainForm.objREPORT_CP_Brand.udfnBrand();
                }
                if (PbCurrentForm == "7.1.8")
                {
                    MainForm.objREPORT_CP_Product_Subgroup.udfnSubgroup();
                }
                if (PbCurrentForm == "7.1.9")
                {
                    MainForm.objREPORT_CP_StockLocation.udfnLocation();
                }
                if (PbCurrentForm == "7.1.10")
                {
                    MainForm.objREPORT_CP_Rack.udfnRack();
                }
                if (PbCurrentForm == "7.1.11")
                {
                    MainForm.objREPORT_CP_Rackgroup.udfnRG();
                }
                if (PbCurrentForm == "7.1.12")
                {
                    MainForm.objREPORT_CP_Supplier.udfnSupplier();
                }
                if (PbCurrentForm == "7.1.13")
                {
                    MainForm.objREPORT_CP_Product.udfnProductGST();
                }
                if (PbCurrentForm == "7.2.1")
                {
                    MainForm.objREPORT_Stock.udfnList();
                }
                if (PbCurrentForm == "7.3.1")
                {
                    MainForm.objREPORT_PUR_PurchaseOrder.udfnProductDetails();
                }
                if (PbCurrentForm == "7.3.2")
                {
                    MainForm.objREPORT_PUR_Purchaseorder_Summary.udfnProductDetails();
                }
                if (PbCurrentForm == "8.1")
                {
                    MainForm.objCP_ChangePassword.udfnLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TspClearTransactions_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_ChangePasswordConfirmation = new CP_ChangePasswordConfirmation();
                MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.Text = "Passkey";
                MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.MaxLength = 50;
                MainForm.objCP_ChangePasswordConfirmation.flag = 1;
                PbDeleteFlag = 0;
                MainForm.objCP_ChangePasswordConfirmation.ShowDialog();
                if (PbDeleteFlag == 1)
                {
                    int Result = 0;
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varoriginator = "";
                    varoriginator = "Clear Transactions";
                    varResult = objspservice.udfnDBClearTransaction(0, varoriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Result = 1;
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Result = 0;
                    }
                    if (Result == 1)
                    {
                        udfnFormLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ExportTallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_Tally = new CP_Tally();
                MainForm.objCP_Tally.MdiParent = this;
                MainForm.objCP_Tally.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ItemMovementAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_ItemMovementAnalysis = new REPORT_ItemMovementAnalysis();
                MainForm.objREPORT_ItemMovementAnalysis.MdiParent = this;
                MainForm.objREPORT_ItemMovementAnalysis.Show();
                PbCurrentForm = "7.2.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void TspClearMasters_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_ChangePasswordConfirmation = new CP_ChangePasswordConfirmation();
                MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.Text = "Passkey";
                MainForm.objCP_ChangePasswordConfirmation.txtDPasskey.MaxLength = 50;
                MainForm.objCP_ChangePasswordConfirmation.flag = 1;
                PbDeleteFlag = 0;
                MainForm.objCP_ChangePasswordConfirmation.ShowDialog();
                if (PbDeleteFlag == 1)
                {
                    int Result = 0;
                    SPDataService objspservice = new SPDataService();
                    string varResult = "", varoriginator = "";
                    varoriginator = "Clear Masters";
                    varResult = objspservice.udfnDBClearMaster(0, varoriginator);
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Result = 1;
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Result = 0;
                    }
                    if (Result == 1)
                    {
                        udfnFormLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void FinancialYearProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objFinancial_Year_Process = new Financial_Year_Process();
                MainForm.objFinancial_Year_Process.MdiParent = this;
                MainForm.objFinancial_Year_Process.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_Product = new REPORT_CP_Product();
                MainForm.objREPORT_CP_Product.MdiParent = this;
                MainForm.objREPORT_CP_Product.Show();
                PbCurrentForm = "7.1.13";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void Ms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (varFormDisable == 1)
                {
                    DisablePageControls(false);
                }
                else
                {
                    DisablePageControls(true);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void AdvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objPAY_AdvanceList = new PAY_AdvanceList();
                MainForm.objPAY_AdvanceList.MdiParent = this;
                MainForm.objPAY_AdvanceList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GSTRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objPAY_GSTRDetails = new PAY_GSTRDetails();
                MainForm.objPAY_GSTRDetails.MdiParent = this;
                MainForm.objPAY_GSTRDetails.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void StockLocationRackMSQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    udfnCloseChildForms();
                    if (isClose == false) { return; }
                    MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                    MainForm.objCP_BulkAttributes.MdiParent = this;
                    MainForm.objCP_BulkAttributes.pbMenuFlag = 1;
                    MainForm.objCP_BulkAttributes.Show();
                    PbCurrentForm = "5.18";
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void MinsalesQtyBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.pbMenuFlag = 2;
                MainForm.objCP_BulkAttributes.Show();
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void MinMaxStockReorderQtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.pbMenuFlag = 3;
                MainForm.objCP_BulkAttributes.Show();
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BulkUnitUPPShelfLifeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.pbMenuFlag = 4;
                MainForm.objCP_BulkAttributes.Show();
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ProductCategoryRMFlagBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.pbMenuFlag = 5;
                MainForm.objCP_BulkAttributes.Show();
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void NetGrossWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.pbMenuFlag = 6;
                MainForm.objCP_BulkAttributes.Show();
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GroupSubgroupBrandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.pbMenuFlag = 7;
                MainForm.objCP_BulkAttributes.Show();
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void HSNNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.pbMenuFlag = 8;
                MainForm.objCP_BulkAttributes.Show();
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ProCodeNameUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.pbMenuFlag = 9;
                MainForm.objCP_BulkAttributes.Show();
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmBlockedSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                if (isClose == false) { return; }
                MainForm.objPAY_BlockedSupplier = new PAY_BlockedSupplier();
                MainForm.objPAY_BlockedSupplier.MdiParent = this;
                MainForm.objPAY_BlockedSupplier.Show();
                PbCurrentForm = "4.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GRNSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_GRNSummary = new REPORT_GRNSummary();
                MainForm.objREPORT_GRNSummary.MdiParent = this;
                MainForm.objREPORT_GRNSummary.Show();
                PbCurrentForm = "7.4.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TSMGRNDetails_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_GRN_Details = new REPORT_GRN_Details();
                MainForm.objREPORT_GRN_Details.MdiParent = this;
                MainForm.objREPORT_GRN_Details.Show();
                PbCurrentForm = "7.4.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GRNBatchDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_GRN_Batch_Detail = new REPORT_GRN_Batch_Detail();
                MainForm.objREPORT_GRN_Batch_Detail.MdiParent = this;
                MainForm.objREPORT_GRN_Batch_Detail.Show();
                PbCurrentForm = "7.4.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GRNSupplierDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_GRN_Supplier_Detail = new REPORT_GRN_Supplier_Detail();
                MainForm.objREPORT_GRN_Supplier_Detail.MdiParent = this;
                MainForm.objREPORT_GRN_Supplier_Detail.Show();
                PbCurrentForm = "7.4.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GRNDefectProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_GRN_Defect_Product = new REPORT_GRN_Defect_Product();
                MainForm.objREPORT_GRN_Defect_Product.MdiParent = this;
                MainForm.objREPORT_GRN_Defect_Product.Show();
                PbCurrentForm = "7.4.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void SupplierWiseProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_SupplierWiseProduct = new REPORT_SupplierWiseProduct();
                MainForm.objREPORT_SupplierWiseProduct.MdiParent = this;
                MainForm.objREPORT_SupplierWiseProduct.Show();
                PbCurrentForm = "7.5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void UnassignedProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Unassigned_Products = new REPORT_Unassigned_Products();
                MainForm.objREPORT_Unassigned_Products.MdiParent = this;
                MainForm.objREPORT_Unassigned_Products.Show();
                PbCurrentForm = "7.5.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void AssignedProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Assigned_Products = new REPORT_Assigned_Products();
                MainForm.objREPORT_Assigned_Products.MdiParent = this;
                MainForm.objREPORT_Assigned_Products.Show();
                PbCurrentForm = "7.5.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PurchaseOrderSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PurchaseOrder_Summary = new REPORT_PurchaseOrder_Summary();
                MainForm.objREPORT_PurchaseOrder_Summary.MdiParent = this;
                MainForm.objREPORT_PurchaseOrder_Summary.Show();
                PbCurrentForm = "7.6.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PurchaseOrderDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PurchaseOrder_Detail = new REPORT_PurchaseOrder_Detail();
                MainForm.objREPORT_PurchaseOrder_Detail.MdiParent = this;
                MainForm.objREPORT_PurchaseOrder_Detail.Show();
                PbCurrentForm = "7.6.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ProductWisePOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_ProductWise_Po = new REPORT_ProductWise_Po();
                MainForm.objREPORT_ProductWise_Po.MdiParent = this;
                MainForm.objREPORT_ProductWise_Po.Show();
                PbCurrentForm = "7.6.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PurchaseSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Purchase_Summary = new REPORT_Purchase_Summary();
                MainForm.objREPORT_Purchase_Summary.MdiParent = this;
                MainForm.objREPORT_Purchase_Summary.Show();
                PbCurrentForm = "7.7.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PurchaseDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Purchase_Details = new REPORT_Purchase_Details();
                MainForm.objREPORT_Purchase_Details.MdiParent = this;
                MainForm.objREPORT_Purchase_Details.Show();
                PbCurrentForm = "7.7.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void UnapprovedPurchaseSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Unapproved_Purchase_Summary = new REPORT_Unapproved_Purchase_Summary();
                MainForm.objREPORT_Unapproved_Purchase_Summary.MdiParent = this;
                MainForm.objREPORT_Unapproved_Purchase_Summary.Show();
                PbCurrentForm = "7.7.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void UnapprovedPurchaseDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Unapproved_Purchase_Detail = new REPORT_Unapproved_Purchase_Detail();
                MainForm.objREPORT_Unapproved_Purchase_Detail.MdiParent = this;
                MainForm.objREPORT_Unapproved_Purchase_Detail.Show();
                PbCurrentForm = "7.7.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PurchaseDefectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Purchase_Defect_Product = new REPORT_Purchase_Defect_Product();
                MainForm.objREPORT_Purchase_Defect_Product.MdiParent = this;
                MainForm.objREPORT_Purchase_Defect_Product.Show();
                PbCurrentForm = "7.7.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DiscountVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objPAY_DiscountVoucherList = new PAY_DiscountVoucherList();
                MainForm.objPAY_DiscountVoucherList.MdiParent = this;
                MainForm.objPAY_DiscountVoucherList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void StatusWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_ProductWise_Po = new REPORT_ProductWise_Po();
                MainForm.objREPORT_ProductWise_Po.MdiParent = this;
                MainForm.objREPORT_ProductWise_Po.Show();
                PbCurrentForm = "7.6.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void StickerPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_StickerPrint = new CP_StickerPrint();
                MainForm.objCP_StickerPrint.MdiParent = this;
                MainForm.objCP_StickerPrint.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmHSNCodeWiseReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_HSN_Code = new REPORT_HSN_Code();
                MainForm.objREPORT_HSN_Code.MdiParent = this;
                MainForm.objREPORT_HSN_Code.Show();
                PbCurrentForm = "7.8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmHSNNameWiseReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_HSN_Name = new REPORT_HSN_Name();
                MainForm.objREPORT_HSN_Name.MdiParent = this;
                MainForm.objREPORT_HSN_Name.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmHSNNameWiseProductReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_HSN_NameWise_Product = new REPORT_HSN_NameWise_Product();
                MainForm.objREPORT_HSN_NameWise_Product.MdiParent = this;
                MainForm.objREPORT_HSN_NameWise_Product.Show();
                PbCurrentForm = "7.8.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmHSNNameWiseProductConsolidatedReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_HSN_NameWise_Product_Consolidated = new REPORT_HSN_NameWise_Product_Consolidated();
                MainForm.objREPORT_HSN_NameWise_Product_Consolidated.MdiParent = this;
                MainForm.objREPORT_HSN_NameWise_Product_Consolidated.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void SupplierLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Suppllier_Ledger = new REPORT_Suppllier_Ledger();
                MainForm.objREPORT_Suppllier_Ledger.MdiParent = this;
                MainForm.objREPORT_Suppllier_Ledger.Show();
                PbCurrentForm = "7.5.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmRateChange_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_Rate_ChangeList = new CP_Rate_ChangeList();
                MainForm.objCP_Rate_ChangeList.MdiParent = this;
                MainForm.objCP_Rate_ChangeList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmRateChangeReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_CP_RateChange = new REPORT_CP_RateChange();
                MainForm.objREPORT_CP_RateChange.MdiParent = this;
                MainForm.objREPORT_CP_RateChange.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmStockInward_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Stock_Inward = new REPORT_Stock_Inward();
                MainForm.objREPORT_Stock_Inward.MdiParent = this;
                MainForm.objREPORT_Stock_Inward.Show();
                PbCurrentForm = "7.9.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmStockOutward_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Stock_Outward = new REPORT_Stock_Outward();
                MainForm.objREPORT_Stock_Outward.MdiParent = this;
                MainForm.objREPORT_Stock_Outward.Show();
                PbCurrentForm = "7.9.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void StockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Stock = new REPORT_Stock();
                MainForm.objREPORT_Stock.MdiParent = this;
                MainForm.objREPORT_Stock.Show();
                PbCurrentForm = "7.2.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmStockHoldReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Stock_Hold = new REPORT_Stock_Hold();
                MainForm.objREPORT_Stock_Hold.MdiParent = this;
                MainForm.objREPORT_Stock_Hold.Show();
                PbCurrentForm = "7.2.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmStockAging_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Stock_Aging = new REPORT_Stock_Aging();
                MainForm.objREPORT_Stock_Aging.MdiParent = this;
                MainForm.objREPORT_Stock_Aging.Show();
                PbCurrentForm = "7.2.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmGodownValuation_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Godown_Valuation = new REPORT_Godown_Valuation();
                MainForm.objREPORT_Godown_Valuation.MdiParent = this;
                MainForm.objREPORT_Godown_Valuation.Show();
                PbCurrentForm = "7.2.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmStockValuation_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Stock_Valuation = new REPORT_Stock_Valuation();
                MainForm.objREPORT_Stock_Valuation.MdiParent = this;
                MainForm.objREPORT_Stock_Valuation.Show();
                PbCurrentForm = "7.2.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchaseProductWiseReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_ProductWiseSummaryDetails = new REPORT_PUR_ProductWiseSummaryDetails();
                MainForm.objREPORT_PUR_ProductWiseSummaryDetails.MdiParent = this;
                MainForm.objREPORT_PUR_ProductWiseSummaryDetails.Show();
                PbCurrentForm = "7.7.7";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchaseCostPrice_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_CostPrice = new REPORT_PUR_CostPrice();
                MainForm.objREPORT_PUR_CostPrice.MdiParent = this;
                MainForm.objREPORT_PUR_CostPrice.Show();
                PbCurrentForm = "7.7.8";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmProductWiseLastPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_ProductWiseLastPurchase = new REPORT_PUR_ProductWiseLastPurchase();
                MainForm.objREPORT_PUR_ProductWiseLastPurchase.MdiParent = this;
                MainForm.objREPORT_PUR_ProductWiseLastPurchase.Show();
                PbCurrentForm = "7.7.9";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchaseTallyReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_Tally = new REPORT_PUR_Tally();
                MainForm.objREPORT_PUR_Tally.MdiParent = this;
                MainForm.objREPORT_PUR_Tally.Show();
                PbCurrentForm = "7.7.10";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchaseBatchDetails_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_BatchDetails = new REPORT_PUR_BatchDetails();
                MainForm.objREPORT_PUR_BatchDetails.MdiParent = this;
                MainForm.objREPORT_PUR_BatchDetails.Show();
                PbCurrentForm = "7.7.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchaseCostDetails_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_CostDetails = new REPORT_PUR_CostDetails();
                MainForm.objREPORT_PUR_CostDetails.MdiParent = this;
                MainForm.objREPORT_PUR_CostDetails.Show();
                PbCurrentForm = "7.7.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchaseBillWiseTaxReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_BillWiseTax = new REPORT_PUR_BillWiseTax();
                MainForm.objREPORT_PUR_BillWiseTax.MdiParent = this;
                MainForm.objREPORT_PUR_BillWiseTax.Show();
                PbCurrentForm = "7.7.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchasePeriodWiseTaxReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_PeriodWiseTax = new REPORT_PUR_PeriodWiseTax();
                MainForm.objREPORT_PUR_PeriodWiseTax.MdiParent = this;
                MainForm.objREPORT_PUR_PeriodWiseTax.Show();
                PbCurrentForm = "7.7.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchaseAdditionalValueReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_AdditionalValue = new REPORT_PUR_AdditionalValue();
                MainForm.objREPORT_PUR_AdditionalValue.MdiParent = this;
                MainForm.objREPORT_PUR_AdditionalValue.Show();
                PbCurrentForm = "7.7.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchaseDiscountValueReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_DiscountValue = new REPORT_PUR_DiscountValue();
                MainForm.objREPORT_PUR_DiscountValue.MdiParent = this;
                MainForm.objREPORT_PUR_DiscountValue.Show();
                PbCurrentForm = "7.7.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmAllPurchaseTaxReport_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_PUR_AllTax = new REPORT_PUR_AllTax();
                MainForm.objREPORT_PUR_AllTax.MdiParent = this;
                MainForm.objREPORT_PUR_AllTax.Show();
                PbCurrentForm = "7.7.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void directLabelPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_DiectLabelPrint = new CP_DirectLabelPrint();
                MainForm.objCP_DiectLabelPrint.MdiParent = this;
                MainForm.objCP_DiectLabelPrint.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void printerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                 
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_PrinterSetting = new CP_Printer_Setting();
                MainForm.objCP_PrinterSetting.MdiParent = this;
                MainForm.objCP_PrinterSetting.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmBank_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BankList = new CP_BankList();
                MainForm.objCP_BankList.MdiParent = this;
                MainForm.objCP_BankList.Show();
                PbCurrentForm = "7.2.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmStockVsZeroRate_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_StockVsZeroRate = new REPORT_StockVsZeroRate();
                MainForm.objREPORT_StockVsZeroRate.MdiParent = this;
                MainForm.objREPORT_StockVsZeroRate.Show();
                PbCurrentForm = "7.2.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void DisablePageControls(bool status)
        {
            foreach (Control c in this.Controls)
            {
                if (c is ToolStrip)
                    ((ToolStrip)c).Enabled = status;
                if (c is MainForm)
                    ((MainForm)c).Enabled = status;
                //c.Enabled = status;
            }
        }
    } 
}