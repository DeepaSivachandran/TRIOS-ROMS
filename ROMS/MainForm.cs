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
using System.Threading.Tasks;
using System.Net.Http;
using System.Globalization;
using System.IO;



namespace ROMS
{
    public partial class MainForm : Form
    {
        private Dictionary<Form, ToolStripButton> minimizedForms = new Dictionary<Form, ToolStripButton>();
        private Form currentOpenForm = null;
        List<MinimizedFormInfo> minimizedFormList = new List<MinimizedFormInfo>();
        private List<(int Index, string FormName)> minimizedFormInfoList = new List<(int, string)>();
        private MdiClient mdiClientArea = null;
        private Dictionary<Form, int> formMenuCodeMap = new Dictionary<Form, int>();
        // Entry/List control flags
        public bool IsEntryFormOpen = false;
        public Form CurrentEntryForm = null;
        public Form CurrentParentListForm = null;

        public class MinimizedFormInfo
        {
            public int Index { get; set; }
            public string FormName { get; set; }
            public ToolStripButton Button { get; set; }
            public Form FormInstance { get; set; }
        }
        public static readonly Dictionary<string, Action> varSpecialField = new Dictionary<string, Action>
        {
            { "varSpecialFlag", () => pbSpecialFlag = 1 }
        };
        //------- Servic Class object declaration
        DataValidation objValidation = new DataValidation();
        public DataError objError = new DataError();
        //------- Variable Declaration
        public static int pbSpecialFlag = 0;
        public static int PbDeleteFlag = 0;
        public static string PbCurrentForm = "0";
        public int pbCloseForm = 0;
        public int pbForceLogoff = 0;
        public static int varCloseFlag = 0;
        public static int varFormDisable = 0;
        public static string pbVersion = "1.0.1";
        public static string pbUserID = "";
        public static string pbUserName = "";
        public static string pbLoginId = "";
        public static string pbUserRoleId ="0";
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
        public static string pbTelegramPath = "";
        public static string varChatID = "";
        public static string varToken = "";
        public static string varcurrentdate = "";
        public static string pbUserMappedLocationIds = "0";
        public static  int pbMenucode = 0;
        public static string varratechangecount = "0";
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
        public static CP_MappedUserList objCP_MappedUserList;
        public static CP_User_ResetPassword objCP_User_ResetPassword;
        public static CP_PurchaseList objCP_PurchaseList;
        public static CP_SupplierMappinglist objCP_SupplierMappinglist;
        public static CP_Product objCP_Items;
        public static CP_Product_Popup objCP_Product_Popup;
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
        public static CP_HSNBulkUpdate objCP_HSNBulkUpdate;
        public static CP_Spl_Products_Bulk objCP_Spl_Products_Bulk;
        public static CP_BulkAttributeVerify objCP_BulkAttributeVerify; 
        public static CP_CostPrice_Update_Bulk objCP_CostPrice_Update_Bulk;
        public static CP_CostPrice_Update_Bulk_List objCP_CostPrice_Update_Bulk_List;
        public static CP_CostPrice_Update_Bulk_Approval_List objCP_CostPrice_Update_Bulk_Approval_List;
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
        public static CP_Rate_ChangeApproval objCP_Rate_ChangeApproval;
        public static CP_Rate_CategoryList objCP_Rate_CategoryList;
        public static CP_Rate_Category objCP_Rate_Category;
        public static CP_StickerPrint objCP_StickerPrint;
        // added by venkat on 09-08-2025
        public static CP_DLP_SingleProduct objCP_DLP_SingleProduct;
        public static CP_DLP_SingleProduct_List objCP_DLP_SingleProduct_List;
        public static CP_DLP_MultipleProducts objCP_DLP_MultipleProducts;
        public static CP_DLP_MultipleProducts_List objCP_DLP_MultipleProducts_List;
        public static CP_Printer_Setting objCP_PrinterSetting;
        //Added by sivabharathi on 14/08/2025
        public static CP_BankList objCP_BankList;
        public static CP_Bank  objCP_Bank;
        public static PAY_ChequeTransactionList objPAY_ChequeTransactionList;
        public static PAY_ChequeTransaction objPAY_ChequeTransaction;
        public static CP_ChequePrint_Setting objCP_ChequePrint_Setting;
        public static GRN_ADV objGRN_ADV;
        public static CP_Product_Info objCP_Product_Info;
        public static CP_ProductLockTeller objCP_ProductLockTeller;
        public static CP_Sales_Settings objCP_Sales_Settings;
        public static CP_Sales_GeneralSettings objCP_Sales_GeneralSettings;

        // added by venkat on 30-09-2025
        public static CP_UserRole objCP_UserRole;
        // added by venkat on 03-10-2025
        public static CP_UserRoleList objCP_UserRoleList;
        public static CP_UserRole_SPL objCP_UserRole_SPL;

        //Added By Sathish ON 11-11-2025
        public static CP_Route objCP_Route;
        public static CP_Routelist objCP_Routelist;
        public static CP_CustomerType objCP_CustomerType;
        public static CP_CustomerTypelist objCP_CustomerTypelist;
        public static CP_Customer objCP_Customer;
        public static CP_Customerlist objCP_Customerlist;
        public static CP_Vehicle objCP_Vehicle;
        public static CP_Vehiclelist objCP_Vehiclelist;
        //Added by sivabharathi on 27/11/2025
        public static CP_AreaList objCP_AreaList;
        public static CP_Area objCP_Area;
        public static CP_TempCustomerList objCP_TempCustomerList;
        public static CP_TemporaryCustomer objCP_TemporaryCustomer;
        public static CP_CardMachineList objCP_CardMachineList;
        public static CP_CardMachine objCP_CardMachine;
        public static CP_UPIList objCP_UPIList;
        public static CP_UPI objCP_UPI;
        public static CP_DeliveryPerson objCP_DeliveryPerson;
        public static CP_DeliveryPersonlist objCP_DeliveryPersonlist;
        public static CP_Mobile objCP_Mobile;
        public static CP_Mobilelist objCP_Mobilelist;
        public static CP_Transport objCP_Transport;
        public static CP_Transportlist objCP_Transportlist;
        public static CP_MarriageHall objCP_MarriageHall;
        public static CP_MarriageHalllist objCP_MarriageHalllist;
        public static CP_LockItems objCP_LockItems;

        //added by venkat on 21/01/2026 for report rate category 
        public static REPORT_CP_Product_RC objREPORT_CP_Product_RC;

        public static PUR_ReturnDCList objINV_SalesInvoiceList;
        public static PUR_ReturnDCApprovedList objPUR_ReturnApprovedList;
        public static INV_SalesInvoice objINV_SalesInvoice;
        public static INV_GRNPODamaged objINV_GRNPODamaged;
        public static INV_StockRequestList objINV_StockRequestList;
        public static INV_StockRequest objINV_StockRequest;
        public static INV_GodownOutward objINV_GodownOutward;
        public static INV_GodownOutwardList objINV_GodownOutwardList;
        public static INV_GoodsOutward_AutoConversion objINV_GoodsOutward_AutoConversion;
        public static INV_Inwardlist objINV_Inwardlist;
        public static INV_Inward objINV_Inward;
        public static INV_StockTransfer objINV_StockTransfer;
        public static INV_StockTransferQueue objINV_StockTransferQueue;
        public static PUR_PurchaseEntryApprovedList objPUR_PurchaseEntryApprovedList;
        public static PUR_MismatchApprovedList objPUR_MismatchApprovedList;
        public static INV_StockTransferList objINV_StockTransferList;
        public static INV_DamageEntryList objINV_DamageEntryList;
        public static INV_DamageEntryQueue objINV_DamageEntryQueue;
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
        public static INV_ReconciliationList objINV_StockAdjustmentList;
        public static INV_Reconciliation objINV_StockAdjustment; 
        public static INV_StockJournalList objINV_StockJournalList;
        public static INV_StockJournal objINV_StockJournal;
        public static INV_StockJournal_ConversionList objINV_StockJournalConversionList;
        public static INV_StockJournal_Conversion objINV_StockJournalConversion;

        public static Form1 objForm1;


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
        public static REPORT_Damage_Entry objREPORT_Damage_Entry;
        public static INV_StockHold_Entry objINV_StockHold_Entry;
        public static REPORT_Stock_Aging objREPORT_Stock_Aging;
        public static REPORT_Stock_Valuation objREPORT_Stock_Valuation;
        public static REPORT_Stock_Valuation_DateWise objREPORT_Stock_Valuation_DateWise;
        public static REPORT_StockVsZeroRate objREPORT_StockVsZeroRate;
        public static REPORT_Stock_Non_Moving_Products objREPORT_Stock_Non_Moving_Products;
        public static REPORT_CP_UserRole objREPORT_CP_UserRole;

        public static REPORT_Supplier_Payment objREPORT_Supplier_Payment;
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
        public static REPORT_ZeroRate objREPORT_ZeroRate;
        public static REPORT_CP_Product_Category objREPORT_CP_Product_Category;
        public static REPORT_CP_ProductCount objREPORT_CP_ProductCount;
        public static REPORT_CP_InactiveProduct objREPORT_CP_InactiveProduct;
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
        public static REPORT_Tax_Changes objREPORT_Tax_Changes;
        public static REPORT_Pur_PO_Blocked_Products objREPORT_Pur_PO_Blocked_Products;
        public static REPORT_PriceList objREPORT_PriceList;
        public static REPORT_RC_PriceList objREPORT_RC_PriceList;
        public static REPORT_PUR_TCSValue objREPORT_PUR_TCSValue;
        public static REPORT_PUR_AllTax objREPORT_PUR_AllTax;

        public static REPORT_HSN_Code objREPORT_HSN_Code;
        public static REPORT_HSN_Tax_Summary objREPORT_HSN_Tax_Summary;
        public static REPORT_HSN_NameWise_Product objREPORT_HSN_NameWise_Product;
        public static REPORT_CP_RateChange objREPORT_CP_RateChange;

        public static REPORT_Stock_Inward objREPORT_Stock_Inward;
        public static REPORT_Stock_Outward objREPORT_Stock_Outward;
        public static REPORT_Stock_Adjustment objREPORT_Stock_Adjustment;
        public static REPORT_Stock_Conversion objREPORT_Stock_Conversion;
        public static REPORT_Stock_Journal objREPORT_Stock_Journal;
        public static REPORT_Stock_Details objREPORT_Stock_Details;
        public static CP_Rackgroup_Product objCP_Rackgroup_Product;
        public static CP_BulkUpdate_RateCategory objCP_BulkUpdate_RateCategory;
        public static CP_BulkUpdate_Minqty objCP_BulkUpdate_Minqty;
        public static CP_BulkUpdate_Offset_Value objCP_BulkUpdate_Offset_Value;
        public static REPORT_ZeroVsPOGenerated objREPORT_ZeroVsPOGenerated;
        public static PrintFormat objReportFormat;
        public static REPORT_CP_Product_Weight objREPORT_CP_Product_Weight;
        public static REPORT_PUR_Product_Consolidated objREPORT_PUR_Product_Consolidated;
        public static REPORT_Stock_Taking objREPORT_Stock_Taking;
        public static MAR_Entry objMAR_Entry;
        public static SAL_Entry objSAL_Entry;
        public static REPORT_EntryReport objREPORT_EntryReport;


        public static Financial_Year_Process objFinancial_Year_Process;
        //public static CP_SL_Verify objCP_SL_Verify;
        public static DataTable objDtMenuDetails;
        public static DataTable objDtMenuCloseDet;

        public static DataTable objDtMenuSplPermission;

        public static DataTable objDtMenuDetailsUser;
        public static DataTable objDtMenuSplPermissionUser;
        public static DataTable objDtSales_MenuDetails;
        public static DataTable objDtSales_MenuSplPermission;
        public static DataTable objDtSales_MenuDetailsUser;
        public static DataTable objDtSales_MenuSplPermissionUser;
        // added by sivanathan on 04-02-2026
        public static CP_Sales_UserRole obj_Sales_UserRole;
        public static CP_Sales_UserRoleList objCP_Sales_UserRoleList;
        public static CP_Sales_UserRole_SPL objCP_Sales_UserRole_SPL;
        public static CP_SalesUserList objCp_SalesUserList;
        public static CP_SalesUser objCP_SalesUser;

        public static INV_StockRequestQueueList objINV_StockRequestQueueList;
        public static CP_Basketlist objCP_Basketlist;
        public static CP_Basket objCP_Basket;

        public MainForm()
        {
            try
            {
                InitializeComponent();
                objValidation.setFontAndFontSize(this);
                timer1.Start();
                timer2.Start();
                //ms.Renderer = new CustomMenuStripRenderer();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void HideStartScreen()
        {
            try
            {
                if (objStart != null && !objStart.IsDisposed && objStart.Visible)
                {
                    objStart.Close();
                    objStart = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        // Added By Sathish On 30-04-2025 For Minimize Reports Screen
        public void SubForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (sender is Form form && form.WindowState == FormWindowState.Minimized)
                {
                    // ENTRY FORM? → HIDE ONLY, DO NOT ADD STATUS BAR
                    if (IsEntryFormOpen && CurrentEntryForm == form)
                    {
                        form.Hide();
                        return;
                    }
                    form.Hide();
                    AddMinimizedFormToStatusBar(ref form, form.Name, 0);

                    var nextForm = MdiChildren
                        .Where(f => f != form && f.Visible && f.WindowState != FormWindowState.Minimized && !f.IsDisposed)
                        .OrderByDescending(f => f == currentOpenForm)
                        .FirstOrDefault();

                    if (nextForm != null)
                    {
                        nextForm.Show();
                        nextForm.WindowState = FormWindowState.Normal;
                        nextForm.BringToFront();
                        currentOpenForm = nextForm;
                    }
                    else
                    {
                        currentOpenForm = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        // Add minimized form to the status bar
        private void AddMinimizedFormToStatusBar<T>(ref T form, string formName, int flag) where T : Form
        {
            try
            {
                if (form is DEF_Start)
                {
                    return;
                }
                // BLOCK: Prevent EntryForm from being minimized
                if (IsEntryFormOpen && CurrentEntryForm == form)
                {
                    return;  // Skip adding entry to status bar
                }


                if (flag == 1)
                {
                    // Find all minimized instances of this form type
                    var existingList = minimizedFormList
                        .Where(m => m.FormName == formName)
                        .ToList();

                    if (existingList.Any())
                    {
                        foreach (var existing in existingList)
                        {
                            // 🧩 Special handling for CP_BulkAttributes multi-mode forms
                            if (form is CP_BulkAttributes newFormInstance && existing.FormInstance is CP_BulkAttributes existingFormInstance)
                            {
                                // If both are CP_BulkAttributes
                                if (newFormInstance.pbMenuFlag == existingFormInstance.pbMenuFlag)
                                {
                                    // Same mode → remove (existing behavior)
                                    statusBar.Items.Remove(existing.Button);
                                    minimizedFormList.Remove(existing);
                                    form = null;
                                    break;
                                }
                                else
                                {
                                    // Different mode → keep both (skip removal)
                                    continue;
                                }
                            }
                            else
                            {
                                // All other forms → default behavior (only one instance)
                                statusBar.Items.Remove(existing.Button);
                                minimizedFormList.Remove(existing);
                                form = null;
                                break;
                            }
                        }
                    }
                    return;
                }


                if (form == null || form.IsDisposed)
                    return;

                Form localForm = form;
                if (minimizedFormList.Any(m => m.FormInstance == localForm))
                    return;
                form.Hide();
                if (objStart == null || objStart.IsDisposed)
                {
                    objStart = new DEF_Start();
                    objStart.MdiParent = this;
                    CenterChildForm(objStart);
                    objStart.Show();
                }
                else if (!objStart.Visible)
                {
                    CenterChildForm(objStart);
                    objStart.Show();
                }
                ToolStripButton btn = new ToolStripButton(form.Text)
                {
                    DisplayStyle = ToolStripItemDisplayStyle.Text,
                    ToolTipText = form.Text,
                    ForeColor = Color.DarkBlue,          // Set default text color
                    Font = new Font("Segoe UI", 9, FontStyle.Bold) // Optional: bold text
                };
                btn.MouseEnter += (s, e) =>
                {
                    btn.ForeColor = Color.White;         // Hover text color
                    btn.BackColor = Color.DarkBlue;      // Hover background
                };
                btn.MouseLeave += (s, e) =>
                {
                    btn.ForeColor = Color.DarkBlue;      // Reset text color
                    btn.BackColor = Color.Transparent;   // Reset background
                };

                btn.Click += MinimizedFormButton_Click;

                statusBar.Items.Add(btn);

                minimizedFormList.Add(new MinimizedFormInfo
                {
                    FormName = form.Name,
                    FormInstance = form,
                    Button = btn
                });
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        // Restore form when clicked in status barf
        private void MinimizedFormButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripButton btn)
                {
                    var info = minimizedFormList.FirstOrDefault(m => m.Button == btn);

                    if (info == null || info.FormInstance == null || info.FormInstance.IsDisposed)
                    {
                        statusBar.Items.Remove(btn);
                        minimizedFormList.RemoveAll(m => m.Button == btn);
                        return;
                    }

                    if (info.FormInstance.WindowState == FormWindowState.Normal && info.FormInstance.Visible)
                        return;

                    foreach (Form openForm in MdiChildren)
                    {
                        if (openForm != info.FormInstance && openForm.WindowState == FormWindowState.Normal && openForm.Visible && !(openForm is DEF_Start))
                        {
                            Form tempForm = openForm;
                            AddMinimizedFormToStatusBar(ref tempForm, tempForm.Name, 0);
                        }
                    }
                    if (IsEntryFormOpen && CurrentEntryForm != null && !CurrentEntryForm.IsDisposed)
                    {
                        CurrentEntryForm.Hide();
                    }

                    info.FormInstance.SuspendLayout();
                    info.FormInstance.WindowState = FormWindowState.Normal;
                    info.FormInstance.StartPosition = FormStartPosition.Manual;

                    CenterChildForm(info.FormInstance);
                    if (formMenuCodeMap.TryGetValue(info.FormInstance, out int menuCode))
                    {
                        ApplyUserPrivilegesToForm(info.FormInstance, menuCode);
                    }

                    info.FormInstance.Show(); HideStartScreen();

                    CenterChildForm(info.FormInstance);
                    info.FormInstance.BringToFront();
                    if (IsEntryFormOpen && CurrentParentListForm == info.FormInstance)
                    {
                        if (CurrentEntryForm != null && !CurrentEntryForm.IsDisposed)
                        {
                            CurrentEntryForm.Show();
                            CurrentEntryForm.BringToFront();
                        }
                    }
                    info.FormInstance.ResumeLayout();

                    statusBar.Items.Remove(btn);
                    minimizedFormList.Remove(info);
                    currentOpenForm = info.FormInstance;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        // Added By Sathish On 30-04-2025 For Minimize Reports Screen
        public void MoveCurrentOpenFormToStatusBar(Form nextFormToOpen)
        {
            try
            {
                if (currentOpenForm != null && !currentOpenForm.IsDisposed && currentOpenForm != nextFormToOpen)
                {
                    if (IsEntryFormOpen && currentOpenForm == CurrentEntryForm)
                    {
                        currentOpenForm.Hide();
                        return;
                    }
                    AddMinimizedFormToStatusBar(ref currentOpenForm, currentOpenForm.Name, 0);
                    currentOpenForm = null;
                }
                HideStartScreen();
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
                string Str_ChildForm = "";
                bool Bln_NoChildForm = true;

                foreach (Form child in MdiChildren)
                {
                    if (child.Name == "DEF_Start")
                        continue;
                    bool isInMinimizedList = minimizedFormList.Any(m => m.FormInstance == child);
                    if (isInMinimizedList)
                        continue;
                    if (child.WindowState == FormWindowState.Minimized)
                        continue;

                    Bln_NoChildForm = false;

                    bool isFound = IsFrmOpen(child);
                    bool exists = objDtMenuCloseDet.AsEnumerable()
                                    .Where(c => c.Field<string>("MenuName").Equals(child.Text) &&
                                                c.Field<int>("CloseFlag").Equals(0))
                                    .Count() > 0;

                    if (Str_ChildForm != "")
                    {
                        child.Close();
                        isClose = true;
                        return;
                    }

                    if (isFound == true && exists == false)
                    {
                        child.Close();
                        isClose = true;
                        Str_ChildForm = child.Name;
                    }
                    else
                    {
                        child.Close();
                    }
                }

                if (Bln_NoChildForm)
                    isClose = true;

                currentOpenForm = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        // Added By Sathish On 30-04-2025 For Minimize Reports Screen
        public void OpenReportForm<T>(ref T formInstance, string formName, int menuCode, string specialflag = null) where T : Form, new()
        {
            try
            {
                //udfnCloseChildForms();
                if (isClose == false) { return; }
                AddMinimizedFormToStatusBar(ref formInstance, formName, 1);

                if (formInstance != null && !formInstance.IsDisposed)
                {
                    formInstance.FormClosing -= null;
                    formInstance.Dispose();
                    formInstance = null;
                }
                if (formInstance == null || formInstance.IsDisposed)
                {
                    formInstance = new T();
                    formInstance.MdiParent = this;
                    this.CenterChildForm(formInstance);
                    formInstance.Resize += SubForm_Resize;

                    var localForm = formInstance;

                    formInstance.FormClosing += (s, args) =>
                    {
                        if (args.CloseReason == CloseReason.MdiFormClosing || args.CloseReason == CloseReason.FormOwnerClosing || args.CloseReason == CloseReason.ApplicationExitCall)
                        {
                            return;
                        }
                        if (localForm != null && (localForm.WindowState == FormWindowState.Minimized || localForm.Visible))
                        {
                            args.Cancel = true;
                            localForm.Hide();
                            AddMinimizedFormToStatusBar(ref localForm, formName, 1);
                        }
                        else
                        {
                            if (localForm.WindowState == FormWindowState.Maximized)
                                localForm.WindowState = FormWindowState.Normal;

                            var minimizedItem = minimizedFormList.FirstOrDefault(m => m.FormInstance == localForm);
                            if (minimizedItem != null)
                            {
                                statusBar.Items.Remove(minimizedItem.Button);
                                minimizedFormList.Remove(minimizedItem);
                            }
                            currentOpenForm = null;
                        }
                    };
                }
                if (minimizedForms.ContainsKey(formInstance))
                {
                    ToolStripButton btn = minimizedForms[formInstance];
                    statusBar.Items.Remove(btn);
                    minimizedForms.Remove(formInstance);
                    minimizedFormInfoList.RemoveAll(x => x.FormName == formName);
                }
                //if (currentOpenForm != null && currentOpenForm.Visible)
                //{
                //    MoveCurrentOpenFormToStatusBar(formInstance);
                //}
                //udfnCloseChildForms();

                //if (!isClose) return;
                
                // If entry form is open, hide it before opening new list form
                if (IsEntryFormOpen && CurrentEntryForm != null && !CurrentEntryForm.IsDisposed)
                {
                    CurrentEntryForm.Hide();
                }
                //This is move the opened list form to the statusbar inside
                //MoveCurrentOpenFormToStatusBar(formInstance);
                //This is close the already opened form
                CloseAllOtherForms(formInstance);

                if (pbUserRoleId == "0")
                {
                    if (!string.IsNullOrEmpty(specialflag) && MainForm.varSpecialField.ContainsKey(specialflag))
                    {
                        MainForm.varSpecialField[specialflag]();
                    }
                    formInstance.MdiParent = this;
                    this.CenterChildForm(formInstance);
                    formInstance.Show();
                }
                else if (objDtMenuDetailsUser != null)
                {
                    var hasPrivilege = objDtMenuDetailsUser.AsEnumerable()
                        .Any(r => r.Field<int>("MU_Code") == menuCode);

                    if (!hasPrivilege)
                        return;

                    var privileges = objDtMenuDetailsUser.AsEnumerable()
                                    .Where(r => r.Field<int>("MU_Code") == menuCode)
                                    .Select(r => r.Field<string>("MU_PrivilegeCode") // get as string
                                                  .Split(',')                       // split by comma
                                                  .Select(int.Parse)                // convert each to int
                                                  .ToList())
                                    .FirstOrDefault();

                    if (privileges.Contains(8))
                    {
                        if (!string.IsNullOrEmpty(specialflag) && MainForm.varSpecialField.ContainsKey(specialflag))
                        {
                            MainForm.varSpecialField[specialflag]();
                        }
                    }
                    formInstance.MdiParent = this;
                    this.CenterChildForm(formInstance);
                    formInstance.Show(); HideStartScreen();

                }

                //   formInstance.WindowState = FormWindowState.Maximized;

                formInstance.BringToFront();
                currentOpenForm = formInstance;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void HandleFormClosingManually(Form closingForm, string formName, bool isClosing = false)
        {
            if (!isClosing && (closingForm.WindowState == FormWindowState.Minimized || closingForm.Visible))
            {
                closingForm.Hide();
                AddMinimizedFormToStatusBar(ref closingForm, formName, 1);
                return;
            }

            if (closingForm.WindowState == FormWindowState.Maximized)
                closingForm.WindowState = FormWindowState.Normal;

            var minimizedItem = minimizedFormList.FirstOrDefault(m => m.FormInstance == closingForm);
            if (minimizedItem != null)
            {
                statusBar.Items.Remove(minimizedItem.Button);
                minimizedFormList.Remove(minimizedItem);
            }

            currentOpenForm = null;

            bool anyOtherMaximizedForms = this.MdiChildren.Any(f => f.WindowState == FormWindowState.Maximized && f.Visible);
            if (!anyOtherMaximizedForms)
            {
                DEF_Start def = new DEF_Start();
                def.MdiParent = this;
                def.WindowState = FormWindowState.Normal;
                def.Show();
            }

        }

        public void PrepareFormClose(Form closingForm, string formName)
        {
            HandleFormClosingManually(closingForm, formName, true);
            formMenuCodeMap.Remove(closingForm);
            closingForm.Close(); // actual close
        }
        public void CloseAllOtherForms(Form newForm)
        {
            foreach (Form child in MdiChildren)
            {
                if (child == newForm)
                    continue;

                if (child is DEF_Start)
                    continue;

                if (IsEntryFormOpen && child == CurrentEntryForm)
                {
                    CurrentEntryForm.Close();
                    IsEntryFormOpen = false;
                    continue;
                }

                if (child.WindowState == FormWindowState.Minimized)
                    continue;
                child.Close();
            }
            minimizedFormList.RemoveAll(m =>
            {
                if (m.FormInstance == null || m.FormInstance.IsDisposed)
                {
                    statusBar.Items.Remove(m.Button);
                    return true;
                }
                return false;
            });
        }


        public void OpenMainForm<T>(ref T formInstance, string formName, int menuCode, string tsbNewName = null, string tssNewName = null, string tsbEditName = null, string tssEditName = null, string tsbDeleteName = null, Control gridControl = null, EventHandler doubleClickHandler = null, KeyEventHandler keyDownHandler = null, string specialflag = null) where T : Form, new()
        {
            try
            {
                udfnCloseChildForms();
                if (!isClose) return;

                AddMinimizedFormToStatusBar(ref formInstance, formName, 1);

                if (formInstance == null || formInstance.IsDisposed)
                {
                    formInstance = new T();
                    formInstance.MdiParent = this;
                    this.CenterChildForm(formInstance);
                    formInstance.Resize += SubForm_Resize;

                    var localForm = formInstance;
                    localForm.FormClosing += (s, args) =>
                    {
                        if (localForm.WindowState == FormWindowState.Minimized || localForm.Visible)
                        {
                            args.Cancel = true;
                            localForm.Hide();
                            AddMinimizedFormToStatusBar(ref localForm, formName, 1);
                        }
                        else
                        {
                            if (localForm.WindowState == FormWindowState.Maximized)
                                localForm.WindowState = FormWindowState.Normal;

                            var minimizedItem = minimizedFormList.FirstOrDefault(m => m.FormInstance == localForm);
                            if (minimizedItem != null)
                            {
                                statusBar.Items.Remove(minimizedItem.Button);
                                minimizedFormList.Remove(minimizedItem);
                            }
                            currentOpenForm = null;
                            bool anyOtherMaximizedForms = this.MdiChildren.Any(f => f != localForm && f.WindowState == FormWindowState.Maximized && f.Visible);

                            if (!anyOtherMaximizedForms)
                            {
                                DEF_Start def = new DEF_Start();
                                def.MdiParent = this;
                                def.WindowState = FormWindowState.Maximized;
                                def.Show();
                            }
                        }
                    };
                }

                if (minimizedForms.ContainsKey(formInstance))
                {
                    ToolStripButton btn = minimizedForms[formInstance];
                    statusBar.Items.Remove(btn);
                    minimizedForms.Remove(formInstance);
                    minimizedFormInfoList.RemoveAll(x => x.FormName == formName);
                }

                MoveCurrentOpenFormToStatusBar(formInstance);

                if (pbUserRoleId == "0")
                {
                    if (!string.IsNullOrEmpty(specialflag) && MainForm.varSpecialField.ContainsKey(specialflag))
                    {
                        MainForm.varSpecialField[specialflag]();
                    }
                    formInstance.MdiParent = this;
                    this.CenterChildForm(formInstance);
                    formInstance.Show();
                }
                else if (objDtMenuDetailsUser != null)
                {
                    var privileges = objDtMenuDetailsUser.AsEnumerable()
                                    .Where(r => r.Field<int>("MU_Code") == menuCode)
                                    .Select(r => r.Field<string>("MU_PrivilegeCode") // get as string
                                                  .Split(',')                       // split by comma
                                                  .Select(int.Parse)                // convert each to int
                                                  .ToList())
                                    .FirstOrDefault();

                    var toolStrip = formInstance.Controls.OfType<ToolStrip>().FirstOrDefault();

                    var gridView = formInstance.Controls.OfType<DataGridView>().FirstOrDefault();

                    ToolStripItem btnNew = null, sepNew = null;
                    ToolStripItem btnEdit = null, sepEdit = null;
                    ToolStripItem btnDelete = null;


                    if (toolStrip != null)
                    {
                        foreach (ToolStripItem item in toolStrip.Items)
                        {
                            if (item.Name == tsbNewName) btnNew = item;
                            if (item.Name == tssNewName) sepNew = item;
                            if (item.Name == tsbEditName) btnEdit = item;
                            if (item.Name == tssEditName) sepEdit = item;
                            if (item.Name == tsbDeleteName) btnDelete = item;
                        }

                        if (btnNew != null) btnNew.Visible = false;
                        if (sepNew != null) sepNew.Visible = false;
                        if (btnEdit != null) btnEdit.Visible = false;
                        if (sepEdit != null) sepEdit.Visible = false;
                        if (btnDelete != null) btnDelete.Visible = false;

                        if (gridControl != null)
                        {
                            if (doubleClickHandler != null)
                                gridControl.DoubleClick -= doubleClickHandler;

                            if (keyDownHandler != null)
                                gridControl.KeyDown -= keyDownHandler;
                        }
                        if (privileges.Contains(2))
                        {
                            if (btnNew != null) btnNew.Visible = true;
                            if (sepNew != null) sepNew.Visible = true;
                        }


                        if (privileges.Contains(3))
                        {
                            if (btnEdit != null) btnEdit.Visible = true;
                            if (sepEdit != null) sepEdit.Visible = true;

                            if (gridControl != null)
                            {
                                if (doubleClickHandler != null)
                                    gridControl.DoubleClick += doubleClickHandler;

                                if (keyDownHandler != null)
                                    gridControl.KeyDown += keyDownHandler;
                            }
                        }

                        if (privileges.Contains(4))
                        {
                            if (btnDelete != null) btnDelete.Visible = true;
                        }
                        if (privileges.Contains(8))
                        {
                            if (!string.IsNullOrEmpty(specialflag) && MainForm.varSpecialField.ContainsKey(specialflag))
                            {
                                MainForm.varSpecialField[specialflag]();
                            }
                        }
                    }
                    formMenuCodeMap[formInstance] = menuCode;
                    ApplyUserPrivilegesToForm(formInstance, menuCode);
                    formInstance.MdiParent = this;
                    this.CenterChildForm(formInstance);
                    formInstance.Show();
                }
                formInstance.BringToFront();
                currentOpenForm = formInstance;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ApplyUserPrivilegesToForm(Form formInstance, int menuCode)
        {
            if (pbUserRoleId == "0") return;

            if (objDtMenuDetailsUser == null) return;

            var privileges = objDtMenuDetailsUser.AsEnumerable()
                            .Where(r => r.Field<int>("MU_Code") == menuCode)
                            .Select(r => r.Field<string>("MU_PrivilegeCode") // get as string
                                          .Split(',')                       // split by comma
                                          .Select(int.Parse)                // convert each to int
                                          .ToList())
                            .FirstOrDefault();

            SetFormPrivilegeFlag(formInstance, "varNewFlag", privileges.Contains(2) ? 1 : 0);
            SetFormPrivilegeFlag(formInstance, "varEditFlag", privileges.Contains(3) ? 1 : 0);
            SetFormPrivilegeFlag(formInstance, "varDeleteFlag", privileges.Contains(4) ? 1 : 0);
        }

        private void SetFormPrivilegeFlag(Form form, string variableName, int value)
        {
            var field = form.GetType().GetField(variableName);
            if (field != null && field.FieldType == typeof(int))
            {
                field.SetValue(form, value);
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
                udfnUserLoginProcess(Convert.ToInt32(MainForm.pbUserID), 411);  // Type 411 is Logged In  
                timer2_Tick(sender, e);
                GetLocalIPAddress();
                udfnGetDefaultCompany();
                udfnShelflifeLevel();
                udfnUserMappedLocations();
                GetDate();
                udfnGetMenuDetails();
                udfnGetMenuSplPermissionDetails();
                udfnGetMenuDetailsForUser();
                udfnGetSalesMenuDetails();
                udfnGetSalesMenuSplPermissionDetails();
                udfnGetSalesMenuDetailsForUser();
                BindMenu(sender, e);
                CountToolStripMenuItems(ms);
                udfnGetTelegramToken();
                this.Text = "ROMS" + " - " + MainForm.pbVersion + " Release Dt : " + MainForm.pbReleaseDt + " [ " + MainForm.pbSSSSoftwareName + " ]";
                udfnCloseChildForms();
                lblTime.Text = "Welcome " + MainForm.pbUserName + " / " + MainForm.pbUserRoleName + " @ " + MainForm.pbHostName;
                //lblDb.Text = "ROMS DB : "+MainForm.pbRomsSoftwareName;
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is MdiClient client)
                    {
                        mdiClientArea = client;
                        break;
                    }
                }

                objStart = new DEF_Start();
                objStart.MdiParent = this;
                objStart.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError(); 
                objError.WriteFile(ex);
            }
        }


        //take all  menu for sales user role master
        public void udfnGetSalesMenuDetails()
        {
            try
            {
                MR_Menu objMR_Menu = new MR_Menu();
                objMR_Menu.ViewType = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnSalesMenu(objMR_Menu);
                objdserv.CloseConnection();

                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            objDtSales_MenuDetails = objDs.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //take all splfield  menu for sales user role master
        public void udfnGetSalesMenuSplPermissionDetails()
        {
            try
            {
                MR_Menu objMR_Menu = new MR_Menu();
                objMR_Menu.ViewType = 1;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnSalesMenu(objMR_Menu);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            objDtSales_MenuSplPermission = objDs.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        //take a particular sales user 
        public void udfnGetSalesMenuDetailsForUser()
        {
            try
            {
                MR_Menu objMR_Menu = new MR_Menu();
                objMR_Menu.ViewType = 2;
                objMR_Menu.paraUserRoleId = Convert.ToInt32(pbUserRoleId);
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnSalesMenu(objMR_Menu);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            objDtSales_MenuDetailsUser = objDs.Tables[0];
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            objDtSales_MenuSplPermissionUser = objDs.Tables[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                DataService OBJDSERVICE = new DataService();
                varratechangecount = "1";
                OBJDSERVICE.CloseConnection();
                DataService objDservice = new DataService();
                string varFlag = objDservice.displaydata("SELECT RAS_STSID FROM DEF_RATEAPPROVAL_STATUS");
                objDservice.CloseConnection();
                if (varFlag == "1")
                {
                    if (varratechangecount != "0")
                    {
                        tsmGif.Visible = true;
                    }
                    else
                    {
                        tsmGif.Visible = false;
                    }
                }
                else
                {
                    tsmGif.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void CenterChildForm(Form childForm)
        {
            if (mdiClientArea != null && childForm != null)
            {
                childForm.StartPosition = FormStartPosition.Manual;
                childForm.WindowState = FormWindowState.Normal;

                int x = (mdiClientArea.Width - childForm.Width) / 2;
                int y = (mdiClientArea.Height - childForm.Height) / 2;

                childForm.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));
            }
            if (mdiClientArea == null && childForm != null)
            {
                //childForm.StartPosition = FormStartPosition.Manual;
                //childForm.WindowState = FormWindowState.Normal;

                //int x = (1536 - childForm.Width) / 2;
                //int y = (746 - childForm.Height) / 2;
                // Get screen location of parent form
                Point parentScreenLocation = this.PointToScreen(Point.Empty);

                // Now offset manually relative to parent
                int x = parentScreenLocation.X + 91;
                int y = parentScreenLocation.Y + 500;

                childForm.Location = new Point(x, y);

            }
        }
        public void CenterEntryForm(Form parentForm, Form childForm)
        {
            if (parentForm == null || childForm == null)
                return;

            childForm.StartPosition = FormStartPosition.Manual;
            childForm.WindowState = FormWindowState.Normal;

            try
            {
                Point parentScreenLocation = parentForm.PointToScreen(Point.Empty);
                int x = parentScreenLocation.X + (parentForm.Width - childForm.Width) / 2;
                int y = parentScreenLocation.Y + (parentForm.Height - childForm.Height) / 2;

                x = Math.Max(x, 0);
                y = Math.Max(y, 0);
                childForm.Location = new Point(x, y);
            }
            catch
            {
                childForm.StartPosition = FormStartPosition.CenterScreen;
            }
        }


        public void udfnUserMappedLocations()
        {
            try
            {
                pbUserMappedLocationIds = "0";
                SPDataService objSPDataService = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objSPDataService.udfnUserList(12, "", "", "", Convert.ToInt32(MainForm.pbUserID), 0, "");
                objSPDataService.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            pbUserMappedLocationIds = Convert.ToString(objDs.Tables[0].Rows[0]["LocationCode"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public string udfnUserLoginProcess(int varUserID,int varType)
        {
            string varResult = "";
            try
            {
                SPDataService objspservice = new SPDataService();
                varResult = objspservice.udfnUser(5, varUserID, "", "", 0, 0, "", 0, 0, "", "", Convert.ToString(varUserID), 0, null, varType, 0);
                objspservice.CloseConnection();
                return varResult;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                return varResult;
            }
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
                                    udfnUserLoginProcess(Convert.ToInt32(MainForm.pbUserID), 412); // Type 412 is Logged Out
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
                    if (varFormDisable == 1)
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
            try
            {
                if (pbForceLogoff == 1)
                {  
                    udfnUserLoginProcess(Convert.ToInt32(MainForm.pbUserID), 412);  // Type 412 is Logged Out
                    System.Environment.Exit(1);
                    Close();
                }
                else
                {
                    if (pbCloseForm == 0)
                    {
                        DialogResult objResponse = MessageBox.Show("Are you sure want to logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if ((objResponse == DialogResult.Yes))
                        {
                            if ((System.Windows.Forms.Application.MessageLoop))
                            {
                                varCloseFlag = 1;
                                udfnUserLoginProcess(Convert.ToInt32(MainForm.pbUserID), 412);  // Type 412 is Logged Out
                                System.Windows.Forms.Application.Exit();
                            }
                            else
                            {
                                System.Environment.Exit(1);
                            }
                            Close();
                        }
                    }
                    else
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //take all  menu for user role master
        public void udfnGetMenuDetails()
        {
            try
            {
                MR_Menu objMR_Menu = new MR_Menu();
                objMR_Menu.ViewType = 0; 
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnMenu(objMR_Menu);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            objDtMenuDetails = objDs.Tables[0]; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnGetTelegramToken()
        {
            try
            {
                DataSet objds = new DataSet();
                DataService objdser = new DataService(); 
                pbTelegramPath = objdser.displaydata(" SELECT SF_Path FROM DEF_SharedFolderPath");
                objds = objdser.GetDataset("SELECT ChatID, Token  FROM DEF_TELEGRAM_BOT_DETAILS A INNER JOIN DEF_TELEGRAM_GROUP_DETAILS B ON A.BOTID = B.BOTID");
                pbTelegramPath = pbTelegramPath + "\\Telegram Reports\\"; 
                // Ensure the folder exists — creates it if not
                if (!Directory.Exists(pbTelegramPath))
                {
                    Directory.CreateDirectory(pbTelegramPath);
                }
                objdser.CloseConnection();
                if (objds != null)
                {
                    if (objds.Tables.Count > 0)
                    {
                        if (objds.Tables[0].Rows.Count > 0)
                        {  
                            varChatID=(Convert.ToString(objds.Tables[0].Rows[0]["ChatID"]));
                            varToken=(Convert.ToString(objds.Tables[0].Rows[0]["Token"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public async Task udfnSendToTelegram(string varPath)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var form = new MultipartFormDataContent())
                    { 
                        // Add file content
                        var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(varPath));
                        fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("multipart/form-data");
                        form.Add(fileContent, "document", System.IO.Path.GetFileName(varPath));
                        if (varChatID!="")
                        {
                            // Telegram API endpoint for sending documents
                            var apiUrl = $"https://api.telegram.org/bot" + varToken  + "/sendDocument?chat_id=" + varChatID ;
                            // Send request
                            var response = await httpClient.PostAsync(apiUrl, form);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        //take all splfield  menu for user role master
        public void udfnGetMenuSplPermissionDetails()
        {
            try
            {
                MR_Menu objMR_Menu = new MR_Menu();
                objMR_Menu.ViewType = 1;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnMenu(objMR_Menu);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            objDtMenuSplPermission = objDs.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        //take a particular user 
        public void udfnGetMenuDetailsForUser()
        {
            try
            {
                MR_Menu objMR_Menu = new MR_Menu();
                objMR_Menu.ViewType = 2;
                objMR_Menu.paraUserRoleId = Convert.ToInt32(pbUserRoleId);
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnMenu(objMR_Menu);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            objDtMenuDetailsUser = objDs.Tables[0];
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            objDtMenuSplPermissionUser = objDs.Tables[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        // --------- Bind Menus --------------
        public void BindMenu(object sender, EventArgs e)
        {
            try
            {
                 
                List<ToolStripItem> objAllItems = new List<ToolStripItem>();
                List<ToolStripMenuItem> objMenuItems = new List<ToolStripMenuItem>();
                foreach (ToolStripItem objToolItem in ms.Items)
                {
                    objAllItems.Add(objToolItem);
                    if (objToolItem is ToolStripMenuItem)
                    {
                        objMenuItems.Add((ToolStripMenuItem)objToolItem);
                    }
                }
                if (MainForm.pbUserRoleId != "1")
                {
                    for (int i = 0; i <= objDtMenuDetailsUser.Rows.Count - 1; i++)
                    {
                        if (MainForm.pbUserRoleId != "1")
                        {
                            foreach (ToolStripItem varItem in objAllItems)
                            {
                                if (varItem.Name == objDtMenuDetailsUser.Rows[i]["MU_Link"].ToString())
                                {
                                    varItem.Visible = true;
                                }
                            }
                        }
                        else
                        {
                            foreach (ToolStripItem varItem in objAllItems)
                            {
                                varItem.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (ToolStripItem varItem in objAllItems)
                    {
                        varItem.Visible = true;
                    }
                }
                objAllItems.Clear();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private int CountToolStripMenuItems(MenuStrip menustrip)
        {
            int Count = 0;
            try
            {
                if (MainForm.pbUserRoleId == "1")
                {
                    foreach (ToolStripMenuItem item in menustrip.Items)
                    {
                        item.Visible = true;
                        foreach (ToolStripMenuItem item1 in item.DropDownItems)
                        {
                            item1.Visible = true;
                            foreach (ToolStripMenuItem item2 in item1.DropDownItems)
                            {
                                item2.Visible = true;
                                foreach (ToolStripMenuItem item3 in item2.DropDownItems)
                                {
                                    item3.Visible = true;
                                }
                            }
                        }
                    }
                }
                else
                { 
                    for (int i = 0; i <= objDtMenuDetailsUser.Rows.Count - 1; i++)
                    {
                        if (MainForm.pbUserRoleId != "0")
                        {
                            foreach (ToolStripMenuItem item in menustrip.Items)
                            {
                                if (item.Name == objDtMenuDetailsUser.Rows[i]["MU_Link"].ToString())
                                {
                                    item.Visible = true;
                                }

                                foreach (ToolStripMenuItem item1 in item.DropDownItems)
                                {
                                    if (item1.Name == objDtMenuDetailsUser.Rows[i]["MU_Link"].ToString())
                                    {
                                        item1.Visible = true;
                                    }

                                    foreach (ToolStripMenuItem item2 in item1.DropDownItems)
                                    {
                                        if (item2.Name == objDtMenuDetailsUser.Rows[i]["MU_Link"].ToString())
                                        {
                                            item2.Visible = true;
                                        }

                                        foreach (ToolStripMenuItem item3 in item2.DropDownItems)
                                        {
                                            if (item3.Name == objDtMenuDetailsUser.Rows[i]["MU_Link"].ToString())
                                            {
                                                item3.Visible = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (ToolStripMenuItem item in menustrip.Items)
                            {
                                item.Visible = true;
                                foreach (ToolStripMenuItem item1 in item.DropDownItems)
                                {
                                    item1.Visible = true;
                                    foreach (ToolStripMenuItem item2 in item1.DropDownItems)
                                    {
                                        item2.Visible = true;
                                        foreach (ToolStripMenuItem item3 in item2.DropDownItems)
                                        {
                                            item3.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            return Count;
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
                OpenReportForm(ref MainForm.objCP_ChangePassword, "CP_ChangePassword", 9);
                PbCurrentForm = "8.1";
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
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objCP_PurchaseList, "CP_PurchaseList", 201);
                PbCurrentForm = "2.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmpurchaseApprove_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objPUR_PurchaseApprovalList, "PUR_PurchaseApprovalList", 202);
                PbCurrentForm = "2.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmpurchaseReturnDC_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_SalesInvoiceList, "PUR_ReturnDCList", 203);
                PbCurrentForm = "2.2";
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
        private void tsmCityReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.1";
                OpenReportForm(ref MainForm.objREPORT_CP_City, "REPORT_CP_City", 80101);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmState_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.2";
                OpenReportForm(ref MainForm.objREPORT_CP_State, "REPORT_CP_State", 80102);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmCompanyReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.3";
                OpenReportForm(ref MainForm.objREPORT_CP_Company, "REPORT_CP_Company", 80103);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmHSNReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.4";
                OpenReportForm(ref MainForm.objREPORT_CP_HSN, "REPORT_CP_HSN", 80104);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmGroupReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.5";
                OpenReportForm(ref MainForm.objREPORT_CP_Product_Group, "REPORT_CP_Product_Group", 80105);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmBrokerReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.6";
                OpenReportForm(ref MainForm.objREPORT_CP_Broker, "REPORT_CP_Broker", 80106);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmBrandReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.7";
                OpenReportForm(ref MainForm.objREPORT_CP_Brand, "REPORT_CP_Brand", 80107);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmProductSubgroupReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.8";
                OpenReportForm(ref MainForm.objREPORT_CP_Product_Subgroup, "REPORT_CP_Product_Subgroup", 80108);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmStockLocationReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.9";
                OpenReportForm(ref MainForm.objREPORT_CP_StockLocation, "REPORT_CP_StockLocation", 80109);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmRackReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.10";
                OpenReportForm(ref MainForm.objREPORT_CP_Rack, "REPORT_CP_Rack", 80110);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmRackGroupReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.11";
                OpenReportForm(ref MainForm.objREPORT_CP_Rackgroup, "REPORT_CP_Rackgroup", 80111);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmSupplierReport_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.1.12";
                OpenReportForm(ref MainForm.objREPORT_CP_Supplier, "REPORT_CP_Supplier", 80112);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmProductsReport_Click(object sender, EventArgs e)
        {

            try
            {
                //PbCurrentForm = "7.1.13";
                OpenReportForm(ref MainForm.objREPORT_CP_Product, "REPORT_CP_Product", 80113);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmProductCategory_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.8.1";
                OpenReportForm(ref MainForm.objREPORT_CP_Product_Category, "REPORT_CP_Product_Category", 80125);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmMarginEntry_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objMAR_Entry, "MAR_Entry", 80125);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmSalesEntry_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objSAL_Entry, "SAL_Entry", 80125);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmEntryReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_EntryReport, "REPORT_EntryReport", 80125);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmMValueReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_EntryReport, "REPORT_EntryReport", 80125);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmTaxChanges_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.8.1";
                OpenReportForm(ref MainForm.objREPORT_Tax_Changes, "REPORT_Tax_Changes", 80121);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmInactiveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.5.3";
                OpenReportForm(ref MainForm.objREPORT_CP_InactiveProduct, "REPORT_CP_InactiveProduct", 80114);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmSupplierWiseProducts_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.5.1";
                OpenReportForm(ref MainForm.objREPORT_SupplierWiseProduct, "REPORT_SupplierWiseProduct", 80115);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmSupplierWiseBlockedProducts_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.8.1";
                OpenReportForm(ref MainForm.objREPORT_Pur_PO_Blocked_Products, "REPORT_Pur_PO_Blocked_Products", 80120);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmAssigned_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.5.2";
                OpenReportForm(ref MainForm.objREPORT_Assigned_Products, "REPORT_Assigned_Products", 80116);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmUnassignedProducts_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.5.3";
                OpenReportForm(ref MainForm.objREPORT_Unassigned_Products, "REPORT_Unassigned_Products", 80117);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmZeroRate_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.5.3";
                OpenReportForm(ref MainForm.objREPORT_ZeroRate, "REPORT_ZeroRate", 80118);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmPOProductWiseReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_PUR_PurchaseOrder, "REPORT_PUR_PurchaseOrder", 80201);
                PbCurrentForm = "7.3.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmPOStatusWise_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_ProductWise_Po, "REPORT_ProductWise_Po", 80202);
                PbCurrentForm = "7.6.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmPOSummary_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_PUR_Purchaseorder_Summary, "REPORT_PUR_Purchaseorder_Summary", 80203);
                PbCurrentForm = "7.3.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TSMGRNSummary_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_GRNSummary, "REPORT_GRNSummary", 80204);
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
                OpenReportForm(ref MainForm.objREPORT_GRN_Details, "REPORT_GRN_Details", 80205);
                PbCurrentForm = "7.4.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmGRNBatchDetail_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_GRN_Batch_Detail, "REPORT_GRN_Batch_Detail", 80206);
                PbCurrentForm = "7.4.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmGRNSupplierDetail_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_GRN_Supplier_Detail, "REPORT_GRN_Supplier_Detail", 80207);
                PbCurrentForm = "7.4.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmGRNDefectPRoduct_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_GRN_Defect_Product, "REPORT_GRN_Defect_Product", 80208);
                PbCurrentForm = "7.4.5";
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
                    MainForm.objREPORT_CP_Company.udfnList(0);
                }
                if (PbCurrentForm == "7.1.4")
                {
                    MainForm.objREPORT_CP_HSN.udfnHSN(0);
                }
                if (PbCurrentForm == "7.1.5")
                {
                    MainForm.objREPORT_CP_Product_Group.udfnProductGroup(0);
                }
                if (PbCurrentForm == "7.1.6")
                {
                    MainForm.objREPORT_CP_Broker.udfnContact(0);
                }
                if (PbCurrentForm == "7.1.7")
                {
                    MainForm.objREPORT_CP_Brand.udfnBrand(0);
                }
                if (PbCurrentForm == "7.1.8")
                {
                    MainForm.objREPORT_CP_Product_Subgroup.udfnSubgroup(0);
                }
                if (PbCurrentForm == "7.1.9")
                {
                    MainForm.objREPORT_CP_StockLocation.udfnLocation(0);
                }
                if (PbCurrentForm == "7.1.10")
                {
                    MainForm.objREPORT_CP_Rack.udfnRack(0);
                }
                if (PbCurrentForm == "7.1.11")
                {
                    MainForm.objREPORT_CP_Rackgroup.udfnRG(0,0);
                }
                if (PbCurrentForm == "7.1.12")
                {
                    MainForm.objREPORT_CP_Supplier.udfnSupplier(0);
                }
                if (PbCurrentForm == "7.1.13")
                {
                    MainForm.objREPORT_CP_Product.udfnProductGST(0);
                }
                if (PbCurrentForm == "7.2.1")
                {
                    MainForm.objREPORT_Stock.udfnList(0);
                }
                if (PbCurrentForm == "7.3.1")
                {
                    MainForm.objREPORT_PUR_PurchaseOrder.udfnProductDetails(0);
                }
                if (PbCurrentForm == "7.3.2")
                {
                    MainForm.objREPORT_PUR_Purchaseorder_Summary.udfnProductDetails(0);
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
         

        private void tsmItemMovementReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_ItemMovementAnalysis, "REPORT_ItemMovementAnalysis", 807);
                PbCurrentForm = "7.2.1";
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

        private void tsmPurchaseSummary_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Purchase_Summary, "REPORT_Purchase_Summary", 80301);
                PbCurrentForm = "7.7.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmPurchaseDetail_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Purchase_Details, "REPORT_Purchase_Details", 80302);
                PbCurrentForm = "7.7.2";
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
                OpenReportForm(ref MainForm.objREPORT_PUR_BatchDetails, "REPORT_PUR_BatchDetails", 80303);
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
                OpenReportForm(ref MainForm.objREPORT_PUR_CostDetails, "REPORT_PUR_CostDetails", 80304);
                PbCurrentForm = "7.7.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmPurchasePendingSummary_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Unapproved_Purchase_Summary, "REPORT_Unapproved_Purchase_Summary", 80305);
                PbCurrentForm = "7.7.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmPurchasePendingDetail_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Unapproved_Purchase_Detail, "REPORT_Unapproved_Purchase_Detail", 80306);
                PbCurrentForm = "7.7.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmPurchaseDefectProduct_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Purchase_Defect_Product, "REPORT_Purchase_Defect_Product", 80307);
                PbCurrentForm = "7.7.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TSMProductWiseLP_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_PUR_ProductWiseLastPurchase, "REPORT_PUR_ProductWiseLastPurchase", 80308);
                PbCurrentForm = "7.7.9";
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
                OpenReportForm(ref MainForm.objREPORT_PUR_CostPrice, "REPORT_PUR_CostPrice", 80309);
                PbCurrentForm = "7.7.8";
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
                OpenReportForm(ref MainForm.objREPORT_PUR_ProductWiseSummaryDetails, "REPORT_PUR_ProductWiseSummaryDetails", 80310);
                PbCurrentForm = "7.7.7";
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
                OpenReportForm(ref MainForm.objREPORT_PUR_Tally, "REPORT_PUR_Tally", 80311);
                PbCurrentForm = "7.7.10";
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
                OpenReportForm(ref MainForm.objREPORT_CP_RateChange, "REPORT_CP_RateChange", 80312);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmPriceList_Click(object sender, EventArgs e)
        { 
            try
            {
                OpenReportForm(ref MainForm.objREPORT_PriceList, "REPORT_PriceList", 80315);
                PbCurrentForm = "7.8.1";
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
                OpenReportForm(ref MainForm.objREPORT_PUR_AdditionalValue, "REPORT_PUR_AdditionalValue", 80313);
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
                OpenReportForm(ref MainForm.objREPORT_PUR_DiscountValue, "REPORT_PUR_DiscountValue", 80314);
                PbCurrentForm = "7.7.11";
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
                OpenReportForm(ref MainForm.objREPORT_HSN_Code, "REPORT_HSN_Code", 8060601);
                PbCurrentForm = "7.8.1";
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
                OpenReportForm(ref MainForm.objREPORT_HSN_NameWise_Product, "REPORT_HSN_NameWise_Product", 8060602);
                PbCurrentForm = "7.8.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmSupplierLEdgerReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Suppllier_Ledger, "REPORT_Suppllier_Ledger", 80501);
                PbCurrentForm = "7.5.4";
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
                OpenReportForm(ref MainForm.objREPORT_Stock_Inward, "REPORT_Stock_Inward", 80401);
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
                OpenReportForm(ref MainForm.objREPORT_Stock_Outward, "REPORT_Stock_Outward", 80402);
                PbCurrentForm = "7.9.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Stock, "REPORT_Stock", 80403);
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
                OpenReportForm(ref MainForm.objREPORT_Stock_Hold, "REPORT_Stock_Hold", 80404);
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
                OpenReportForm(ref MainForm.objREPORT_Stock_Aging, "REPORT_Stock_Aging", 80405);
                PbCurrentForm = "7.2.3";
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
                OpenReportForm(ref MainForm.objREPORT_Stock_Valuation, "REPORT_Stock_Valuation", 80406);
                PbCurrentForm = "7.2.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockValuationbyDate_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Stock_Valuation_DateWise, "REPORT_Stock_Valuation_DateWise", 80409);
                PbCurrentForm = "7.2.5";
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
                OpenReportForm(ref MainForm.objREPORT_StockVsZeroRate, "REPORT_StockVsZeroRate", 80407);
                PbCurrentForm = "7.2.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmNonMoving_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Stock_Non_Moving_Products, "REPORT_Stock_Non_Moving_Products", 80408);
                PbCurrentForm = "7.2.6";
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
                OpenReportForm(ref MainForm.objREPORT_PUR_BillWiseTax, "REPORT_PUR_BillWiseTax", 80601);
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
                OpenReportForm(ref MainForm.objREPORT_PUR_PeriodWiseTax, "REPORT_PUR_PeriodWiseTax", 80604);
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
                OpenReportForm(ref MainForm.objREPORT_PUR_AllTax, "REPORT_PUR_AllTax", 80603);
                PbCurrentForm = "7.7.12";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmPurchaseTCSValueReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_PUR_TCSValue, "REPORT_PUR_TCSValue", 80602);
                PbCurrentForm = "7.7.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsmPaymentReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Supplier_Payment, "REPORT_Supplier_Payment", 80502);
                PbCurrentForm = "7.5.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void tsmHSNTaxDetailsSummary_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_HSN_Tax_Summary, "REPORT_HSN_Tax_Summary", 80605);
                PbCurrentForm = "7.8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmpurchaseSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objPUR_SupplierScheduleList, "PUR_SupplierScheduleList", 101);
                PbCurrentForm = "1.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmPurchaseOrder_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objPUR_PurchaseOrderList, "PUR_PurchaseOrderList", 102);
                PbCurrentForm = "1.2";
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
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objPUR_GRNDetailsList, "PUR_GRNDetailsList", 103);
                PbCurrentForm = "1.3";
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
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objPUR_PurchaseDCList, "PUR_PurchaseDCList", 104);
                PbCurrentForm = "1.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmPurchaseMismatchApproval_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objPUR_GRNApprovalList, "PUR_GRNApprovalList", 105);
                PbCurrentForm = "1.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmfromPurchase_Grn_DC_Click(object sender, EventArgs e)
        {

            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_InwardPurchaseList, "INV_InwardPurchaseList", 30101);
                PbCurrentForm = "3.2.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmInwardfromothers_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_Inwardlist, "INV_Inwardlist", 30102);
                PbCurrentForm = "3.2.2";
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
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_GodownOutwardList, "INV_GodownOutwardList", 302);
                PbCurrentForm = "3.5";
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
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_StockTransferList, "INV_StockTransferList", 303);
                PbCurrentForm = "3.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmBatchConversion_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_StockConversionList, "INV_StockConversionList", 304);
                PbCurrentForm = "3.8";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockReconciliation_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_StockAdjustmentList, "INV_ReconciliationList", 305);
                PbCurrentForm = "3.5";
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
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_StockHold, "INV_StockHold", 306);
                PbCurrentForm = "3.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmDamageEntry_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_DamageEntryList, "INV_DamageEntryList", 307);
                PbCurrentForm = "3.7";
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
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_StockRequestList, "INV_StockRequestList", 308);
                PbCurrentForm = "3.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmRackTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_RackSettings, "CP_RackSettings", 309);
                PbCurrentForm = "3.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockConversion_Click(object sender, EventArgs e)
        {

            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_StockJournalList, "INV_StockJournalList", 310);
                PbCurrentForm = "3.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmDirectChequePrint_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objPAY_ChequePrint, "PAY_ChequePrint", 401);
                PbCurrentForm = "4.2";
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
                OpenReportForm(ref MainForm.objPAY_BlockedSupplier, "PAY_BlockedSupplier", 402);
                PbCurrentForm = "4.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmDiscountVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objPAY_DiscountVoucherList, "PAY_DiscountVoucherList", 403);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmAdvance_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objPAY_AdvanceList, "PAY_AdvanceList", 404);
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
                OpenReportForm(ref MainForm.objPAY_CreditNoteList, "PAY_CreditNoteList", 405);
                PbCurrentForm = "4.3";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmSupplierPayment_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objPAY_SupplierPaymentList, "PAY_SupplierPaymentList", 406);
                PbCurrentForm = "4.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmChequeTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objPAY_ChequeTransactionList, "PAY_ChequeTransactionList", 407);
                PbCurrentForm = "7.2.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmGSTRDetails_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objPAY_GSTRDetails, "PAY_GSTRDetails", 408);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmCity_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Citylist, "CP_Citylist", 501);
                PbCurrentForm = "5.1";
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
                OpenReportForm(ref MainForm.objCP_BankList, "CP_BankList", 502);
                PbCurrentForm = "7.2.6";
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
                OpenReportForm(ref MainForm.objCP_Companylist, "CP_Companylist", 503);
                PbCurrentForm = "5.2";
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
                OpenReportForm(ref MainForm.objCP_ProductHSNlist, "CP_ProductHSNList", 50501);
                PbCurrentForm = "5.3";
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
                OpenReportForm(ref MainForm.objCP_GroupList, "CP_GroupList", 50502);
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
                OpenReportForm(ref MainForm.objCP_SubGroupList, "CP_SubGroupList", 50503);
                PbCurrentForm = "5.5";
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
                OpenReportForm(ref MainForm.objCP_BrandList, "CP_BrandList", 50504);
                PbCurrentForm = "5.6";
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
                OpenReportForm(ref MainForm.objCP_Unitlist, "CP_Unitlist", 50505);
                PbCurrentForm = "5.7";
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
                OpenReportForm(ref MainForm.objCP_LocationList, "CP_LocationList", 50401);
                PbCurrentForm = "5.8";
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
                OpenReportForm(ref MainForm.objCP_RackList, "CP_RackList", 50402);
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
                OpenReportForm(ref MainForm.objCP_RackGroupList, "CP_RackGroupList", 50403);
                PbCurrentForm = "5.10";
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
                OpenReportForm(ref MainForm.objCP_Itemlist, "CP_ProductList", 50506);
                PbCurrentForm = "5.11";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmProductApproval_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_ProductApprovalList, "CP_ProductApprovalList", 50508);
                PbCurrentForm = "5.12";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmCategory_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_UserCategoryList, "CP_UserCategoryList", 50601);
                PbCurrentForm = "5.13";
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
                OpenReportForm(ref MainForm.objCP_EmployeeList, "CP_EmployeeList", 50602);
                PbCurrentForm = "5.14";
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
                OpenReportForm(ref MainForm.objCP_Userlist, "CP_UserList", 51402);
                PbCurrentForm = "5.15";
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
                OpenReportForm(ref MainForm.objCP_Supplierlist, "CP_Supplierlist", 507);
                PbCurrentForm = "5.16";
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
                OpenReportForm(ref MainForm.objCP_CP_BrokerList, "CP_BrokerList", 508);
                PbCurrentForm = "5.17";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void tsmStockLocationUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.pbMenuFlag = 1;
                pbMenucode = 50901;
                OpenReportForm(ref MainForm.objCP_BulkAttributes, "CP_BulkAttributes", 50901);
                objCP_BulkAttributes.Text = "Stock location, Rack & MSQ"; 
                //objCP_BulkAttributes.tspHeader.Text = "Product Attributes Bulk Update : Stock location, Rack & MSQ"; 
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void tsmMinsalesUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.pbMenuFlag = 2;
                pbMenucode = 50902;
                OpenReportForm(ref MainForm.objCP_BulkAttributes, "CP_BulkAttributes", 50902);
                objCP_BulkAttributes.Text = "Minsales Qty & Barcode";
                //objCP_BulkAttributes.tspHeader.Text = "Product Attributes Bulk Update : Minsales Qty & Barcode";
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void tsmMinMaxUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.pbMenuFlag = 3;
                pbMenucode = 50903;
                OpenReportForm(ref MainForm.objCP_BulkAttributes, "CP_BulkAttributes", 50903);
                objCP_BulkAttributes.Text = "Min, Max stock & Reorder Qty";
               // objCP_BulkAttributes.tspHeader.Text = "Product Attributes Bulk Update : Min, Max stock & Reorder Qty";
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void tsmUnitUppUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.pbMenuFlag = 4;
                pbMenucode = 50904;
                OpenReportForm(ref MainForm.objCP_BulkAttributes, "CP_BulkAttributes", 50904);
                objCP_BulkAttributes.Text = "Bulk Unit, UPP & Shelf Life";
                //objCP_BulkAttributes.tspHeader.Text = "Product Attributes Bulk Update : Bulk Unit, UPP & Shelf Life";
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void tsmProductUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.pbMenuFlag = 5;
                pbMenucode = 50905;
                OpenReportForm(ref MainForm.objCP_BulkAttributes, "CP_BulkAttributes", 50905);
                objCP_BulkAttributes.Text = "Barcode, RM Flag & Batch";
               // objCP_BulkAttributes.tspHeader.Text = "Product Attributes Bulk Update : Product Category, RM Flag & Batch";
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void tsmNetGrossUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.pbMenuFlag = 6;
                pbMenucode = 50906;
                OpenReportForm(ref MainForm.objCP_BulkAttributes, "CP_BulkAttributes", 50906);
                objCP_BulkAttributes.Text = "Net & Gross Weight";
                //objCP_BulkAttributes.tspHeader.Text = "Product Attributes Bulk Update : Net & Gross Weight";
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void tsmSubgrupBrandUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.pbMenuFlag = 7;
                pbMenucode = 50907;
                OpenReportForm(ref MainForm.objCP_BulkAttributes, "CP_BulkAttributes", 50907);
                objCP_BulkAttributes.Text = "Group, Subgroup & Brand";
               // objCP_BulkAttributes.tspHeader.Text = "Product Attributes Bulk Update : Group, Subgroup & Brand";
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmHSNUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_HSNBulkUpdate = new CP_HSNBulkUpdate();
                MainForm.objCP_HSNBulkUpdate.pbMenuFlag = 8;
                pbMenucode = 50908;
                OpenReportForm(ref MainForm.objCP_HSNBulkUpdate, "CP_HSNBulkUpdate", 50908);
                objCP_HSNBulkUpdate.Text = "HSN Name";
               // objCP_HSNBulkUpdate.tspHeader.Text = "Product Attributes Bulk Update : HSN Name";
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void tsmProCodeUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.pbMenuFlag = 9;
                pbMenucode = 50909;
                OpenReportForm(ref MainForm.objCP_BulkAttributes, "CP_BulkAttributes", 50909);
                objCP_BulkAttributes.Text = "Pro. Code, Name & Unit";
                //objCP_BulkAttributes.tspHeader.Text = "Product Attributes Bulk Update : Pro. Code, Name & Unit";
                PbCurrentForm = "5.18";
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
                OpenReportForm(ref MainForm.objCP_RepresentativeList, "CP_RepresentativeList", 510);
                PbCurrentForm = "5.19";
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
                OpenReportForm(ref MainForm.objCP_Rate_ChangeList, "CP_Rate_ChangeList", 51304);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStickerPrint_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_StickerPrint, "CP_StickerPrint", 511);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmDirectLabelPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void tsmUserRole_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_UserRoleList, "CP_UserRoleList", 51401);
                PbCurrentForm = "7.8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmProMapping_Click(object sender, EventArgs e)
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

        private void tsmVoucherSettings_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Settings, "CP_Settings", 601);
                PbCurrentForm = "6.1";
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
                OpenReportForm(ref MainForm.objCP_GeneralSettings, "CP_GeneralSettings", 602);
                PbCurrentForm = "6.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmPrinterSettings_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_PrinterSetting, "CP_Printer_Setting", 603);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmChequePrintSettings_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_ChequePrint_Setting, "CP_ChequePrint_Setting", 604);
                PbCurrentForm = "7.2.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmExportTally_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Tally, "CP_Tally", 701);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmClearTransactions_Click(object sender, EventArgs e)
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

        private void tsmClearMasters_Click(object sender, EventArgs e)
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

        private void tsmFinancialYearProcess_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objFinancial_Year_Process, "Financial_Year_Process", 1002);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

         
        private void tsmPurPOBlockedProducts_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objREPORT_Pur_PO_Blocked_Products = new REPORT_Pur_PO_Blocked_Products();
                MainForm.objREPORT_Pur_PO_Blocked_Products.MdiParent = this;
                MainForm.objREPORT_Pur_PO_Blocked_Products.Show();
                PbCurrentForm = "7.8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsmStockJournal_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                //udfnCloseChildForms();
                //if (isClose == false) { return; }
                //MainForm.objINV_StockJournalConversionList = new INV_StockJournal_ConversionList();
                //MainForm.objINV_StockJournalConversionList.MdiParent = this;
                //MainForm.objINV_StockJournalConversionList.Show();
                OpenReportForm(ref MainForm.objINV_StockJournalConversionList, "INV_StockJournal_ConversionList", 311);
                PbCurrentForm = "3.5";
            }
            catch (Exception ex)
            {
                objError = new DataError();
            }
        }


        private void tsmReportUserRole_Click(object sender, EventArgs e)
        {
            try
            {
                //udfnCloseChildForms();
                //if (isClose == false) { return; }
                //MainForm.objREPORT_CP_UserRole = new REPORT_CP_UserRole();
                //MainForm.objREPORT_CP_UserRole.MdiParent = this;
                //MainForm.objREPORT_CP_UserRole.Show();
                OpenReportForm(ref MainForm.objREPORT_CP_UserRole, "REPORT_CP_UserRole", 80122);
                PbCurrentForm = "7.2.6";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.Alt && e.KeyCode == Keys.L)
                {
                    DEF_IdleLogin obj = new DEF_IdleLogin();
                    obj.ShowDialog();
                }
                if (e.KeyCode == Keys.F10) //PM Stock
                {
                    MainForm.objCP_Product_Popup = new CP_Product_Popup();
                    MainForm.objCP_Product_Popup.MdiParent = this.ParentForm;
                    MainForm.objCP_Product_Popup.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Stock_Adjustment, "REPORT_Stock_Adjustment", 80410);
                PbCurrentForm = "7.9.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockConversionReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Stock_Conversion, "REPORT_Stock_Conversion", 80411);
                PbCurrentForm = "7.9.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockJournalReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Stock_Journal, "REPORT_Stock_Journal", 80412);
                PbCurrentForm = "7.9.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockDetailsReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Stock_Details, "REPORT_Stock_Details", 80413);
                PbCurrentForm = "7.9.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        private void tsmProductClassification_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Spl_Products_Bulk = new CP_Spl_Products_Bulk();
                MainForm.objCP_Spl_Products_Bulk.pbMenuFlag = 1;
                OpenReportForm(ref MainForm.objCP_Spl_Products_Bulk, "CP_Spl_Products_Bulk", 50507);
                //objCP_Spl_Products_Bulk.Text = "Product Classification";
                //objCP_Spl_Products_Bulk.tspHeader.Text = "Product Classification";
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmRateApproval_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Rate_ChangeApproval, "CP_Rate_ChangeApproval", 51305);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmRoute_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Routelist, "CP_Routelist", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmCustomerType_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_CustomerTypelist, "CP_CustomerTypelist", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Customerlist, "CP_Customerlist", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Vehiclelist, "CP_Vehiclelist", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmArea_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_AreaList, "CP_AreaList", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmControlPanel_Click(object sender, EventArgs e)
        {

        }

        private void tsmReports_Click(object sender, EventArgs e)
        {

        }

        private void temporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_TempCustomerList, "CP_TempCustomerList", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmCardMachine_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_CardMachineList, "CP_CardMachineList", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmUPI_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_UPIList, "CP_UPIList", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmDeliveryPerson_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_DeliveryPersonlist, "CP_DeliveryPersonlist", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmMobile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Mobilelist, "CP_Mobilelist", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmTransport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Transportlist, "CP_Transportlist", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmMarriageHall_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_MarriageHalllist, "CP_MarriageHalllist", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmMaster_Click(object sender, EventArgs e)
        {

        }

        private void tsmGif_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Rate_ChangeApproval, "CP_Rate_ChangeApproval", 51305);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmRateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Rate_CategoryList, "CP_Rate_CategoryList", 51301);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmCPBulkUpdate_Click(object sender, EventArgs e)
        {
            try
            { 
                OpenReportForm(ref MainForm.objCP_CostPrice_Update_Bulk_List, "CP_CostPrice_Update_Bulk_List", 51302);
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmCPApproval_Click(object sender, EventArgs e)
        { 
            try
            {
                OpenReportForm(ref MainForm.objCP_CostPrice_Update_Bulk_Approval_List, "CP_CostPrice_Update_Bulk_Approval_List", 51303);
                PbCurrentForm = "5.18";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmRcPriceList_Click(object sender, EventArgs e)
        { 
            try
            {
                OpenReportForm(ref MainForm.objREPORT_RC_PriceList, "REPORT_RC_PriceList", 80315);
                PbCurrentForm = "7.8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmRackgroupProduct_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Rackgroup_Product, "CP_Rackgroup_Product", 80315);
                PbCurrentForm = "7.8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmBulkRateCategory_Click(object sender, EventArgs e)
        { 
            try
            {
                OpenReportForm(ref MainForm.objCP_BulkUpdate_RateCategory, "CP_BulkUpdate_RateCategory", 50509);
                PbCurrentForm = "7.8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmBulkupdateProductminbulk_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_BulkUpdate_Minqty, "CP_BulkUpdate_Minqty", 50510);
                PbCurrentForm = "7.8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void tsmBulkOffsetUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_BulkUpdate_Offset_Value, "CP_BulkUpdate_Offset_Value", 50511);
                PbCurrentForm = "7.8.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            
        }

        private void tsmZeroVsPOGenerated_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_ZeroVsPOGenerated, "REPORT_ZeroVsPOGenerated", 80209);
                PbCurrentForm = "7.3.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmLockItems_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_LockItems, "CP_LockItems", 80209);
                PbCurrentForm = "7.3.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmProductReportRateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_CP_Product_RC, "REPORT_CP_Product_RC", 80123);
                PbCurrentForm = "7.3.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void tsmProductWeight_Click(object sender, EventArgs e)
        {
            try
            {
                //PbCurrentForm = "7.8.1";
                OpenReportForm(ref MainForm.objREPORT_CP_Product_Weight, "REPORT_CP_Product_Weight", 80124);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmSalesVoucherSettings_Click(object sender, EventArgs e)
        {

            try
            {
                OpenReportForm(ref MainForm.objCP_Sales_Settings, "CP_Sales_Settings", 605);
                PbCurrentForm = "6.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmSalesGeneralSettings_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Sales_GeneralSettings, "CP_Sales_GeneralSettings", 606);
                PbCurrentForm = "7";
                 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmSalesUserRole_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Sales_UserRoleList, "CP_Sales_UserRoleList", 51403);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmSalesSystemUser_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCp_SalesUserList, "CP_SalesUserList", 51404);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmDamageEntryReport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Damage_Entry, "REPORT_Damage_Entry", 80414);
                PbCurrentForm = "7.2.2";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmDLPSingleProduct_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_DLP_SingleProduct_List, "CP_DLP_SingleProduct_List", 51201);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmDLPMultipleProducts_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_DLP_MultipleProducts_List, "CP_DLP_MultipleProducts_List", 51202);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockReqQueue_Click(object sender, EventArgs e)
        {
            try
            {
                udfnGetDefaultCompany();
                OpenReportForm(ref MainForm.objINV_StockRequestQueueList, "INV_StockRequestQueueList", 312);
                PbCurrentForm = "3.4";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmBasket_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objCP_Basketlist, "CP_Basketlist", 501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmProductCount_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_CP_ProductCount, "REPORT_CP_ProductCount", 50501);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsmMs_Click(object sender, EventArgs e)
        {

        }

        private void tsmPurchaseConsolidated_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_PUR_Product_Consolidated, "REPORT_PUR_Product_Consolidated", 80316);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmStockTaking_Click(object sender, EventArgs e)
        {
            try
            {
                OpenReportForm(ref MainForm.objREPORT_Stock_Taking, "REPORT_Stock_Taking", 80415);
                PbCurrentForm = "5.1";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsmLock_Click(object sender, EventArgs e)
        {

            try
            {

                DEF_IdleLogin obj = new DEF_IdleLogin();
                obj.ShowDialog();
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