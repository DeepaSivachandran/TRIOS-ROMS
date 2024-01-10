                  using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Globalization;

namespace ROMS
{
    public partial class MainForm : Form
    {
        //------- Servic Class object declaration
        DataValidation objValidation = new DataValidation();
        public DataError objError = new DataError();

        //------- Variable Declaration
        public static int pbCloseForm = 0;
        public static int varCloseFlag = 0;
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

        public static PUR_ReturnDCList objINV_SalesInvoiceList;
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
        public static INV_StockTransferList objINV_StockTransferList;
        public static INV_DamageEntryList objINV_DamageEntryList;
        public static INV_DamageEntry objINV_DamageEntry;
        public static INV_InwardPurchaseList objINV_InwardPurchaseList;
        public static INV_InwardPurchase objINV_InwardPurchase;
        public static INV_StockHold objINV_StockHold;
        public static INV_StockConversionList objINV_StockConversionList;
        public static INV_StockConversion objINV_StockConversion;
        public static INV_InwardQueueList objINV_InwardQueueList;
        public static INV_InwardlistQueue objINV_InwardlistQueue;

        public static PUR_PurchaseApproval objPUR_PurchaseApproval;
        public static PUR_PurchaseApprovalList objPUR_PurchaseApprovalList;  
        public static PUR_PurchaseOrder objPUR_PurchaseOrder;
        public static PUR_PODamaged objPUR_PODamaged;
        public static PUR_SupplierScheduleList objPUR_SupplierScheduleList;
        public static PUR_GRNDetailsList objPUR_GRNDetailsList;
        public static PUR_GRNDetails objPUR_GRNDetails;
        public static PUR_GRNVerify objPUR_GRNVerify;
        public static PUR_GRNEntryVerify objPUR_GRNEntryVerify;
        public static PUR_GRNOrderType objPUR_GRNOrderType;
        public static PUR_Product objPUR_Product;
        public static PUR_PurchaseOrderDamage objPUR_PurchaseOrderDamage;
        public static PUR_PurchaseOrderList objPUR_PurchaseOrderList;
        public static PUR_SupplierSchedule objPUR_SupplierSchedule;
        public static PUR_PurchaseReturns objPUR_PurchaseReturns;
        public static PUR_RemarksHistory objPUR_RemarksHistory;
        public static PUR_POReturns objPUR_POReturns;
        public static PUR_BulkUnit objPUR_BulkUnit;
        public static PUR_DCGoodsInward objPUR_DCGoodsInward;
        public static PUR_GRNApprovalList objPUR_GRNApprovalList;
        public static PUR_GRNApproval objPUR_GRNApproval;
        public static PUR_GRNEntry objPUR_GRNEntry;
        public static PUR_POProducts objPUR_POProducts;
        public static PUR_POMappedProducts objPUR_POMappedProducts;
        public static PUR_POIssuedDetails objPUR_POIssuedDetails;
        public static PUR_POScheduledaywise objPUR_POScheduledaywise;
        public static PUR_GSTIN objPUR_GSTIN;
        public static PUR_PurchaseDCList objPUR_PurchaseDCList;
        public static PUR_PurchaseDC objPUR_PurchaseDC;
        public static PUR_DCDeatils objPUR_DCDeatils;
        public static PUR_PODamagedView objPUR_PODamagedView;
        public static PUR_PurchaseQueue objPUR_PurchaseQueue;
        public static PUR_GRNApprovalVerify objPUR_GRNApprovalVerify;
        public static PUR_Calculator objPUR_Calculator;
        public static PUR_POScheduleSummary objPUR_POScheduleSummary;

        public static PAY_SupplierPaymentList objPAY_SupplierPaymentList;
        public static PAY_SupplierPayment objPAY_SupplierPayment;
        public static PAY_ChequePrint objPAY_ChequePrint;
        public static PAY_DebitNoteList objPAY_DebitNoteList;

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
        public static REPORT_PUR_PurchaseOrder objREPORT_PUR_PurchaseOrder;
        public static REPORT_PUR_Purchaseorder_Summary objREPORT_PUR_Purchaseorder_Summary;
         
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
                    exists = objDtMenuCloseDet.AsEnumerable().Where(c => c.Field<string>("MenuName").Equals(child.Text) && c.Field<int>("CloseFlag").Equals(0)).Count() > 0;

                    if (isFound == true && exists == false)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            child.Close();
                            isClose = true;
                        }
                        else { isClose = false; }
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                GetLocalIPAddress();
                udfnGetDefaultCompany();
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
                if (varCloseFlag == 0)
                {
                    if (pbCloseForm == 0)
                    {
                        DialogResult objResponse = MessageBox.Show("Are you sure want to Logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnMaster(4, 0, 0, "", "", 0,"",0);
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
                    DialogResult objResponse = MessageBox.Show("Are you sure want to Logout?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                if (isClose == false) { return; }
                MainForm.objCP_PurchaseList = new CP_PurchaseList();
                MainForm.objCP_PurchaseList.MdiParent = this;
                MainForm.objCP_PurchaseList.Show();
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
                if (isClose == false) { return; }
                MainForm.objPUR_PurchaseOrderList = new PUR_PurchaseOrderList();
                MainForm.objPUR_PurchaseOrderList.MdiParent = this;
                MainForm.objPUR_PurchaseOrderList.Show();
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
                if (isClose == false) { return; }
                MainForm.objPUR_PurchaseApprovalList = new PUR_PurchaseApprovalList();
                MainForm.objPUR_PurchaseApprovalList.MdiParent = this;
                MainForm.objPUR_PurchaseApprovalList.Show();
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
                if (isClose == false) { return; }
                MainForm.objPUR_SupplierScheduleList = new PUR_SupplierScheduleList();
                MainForm.objPUR_SupplierScheduleList.MdiParent = this;
                MainForm.objPUR_SupplierScheduleList.Show();
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
                if (isClose == false) { return; }
                MainForm.objPUR_GRNDetailsList = new PUR_GRNDetailsList();
                MainForm.objPUR_GRNDetailsList.MdiParent = this;
                MainForm.objPUR_GRNDetailsList.Show();
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
                if (isClose == false) { return; }
                MainForm.objINV_StockTransferList = new INV_StockTransferList();
                MainForm.objINV_StockTransferList.MdiParent = this;
                MainForm.objINV_StockTransferList.Show();
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
                if (isClose == false) { return; }
                MainForm.objINV_GodownOutwardList = new INV_GodownOutwardList();
                MainForm.objINV_GodownOutwardList.MdiParent = this;
                MainForm.objINV_GodownOutwardList.Show();
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
                if (isClose == false) { return; }
                MainForm.objINV_StockRequestList = new INV_StockRequestList();
                MainForm.objINV_StockRequestList.MdiParent = this;
                MainForm.objINV_StockRequestList.Show();
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
                if (isClose == false) { return; }
                MainForm.objINV_SalesInvoiceList = new PUR_ReturnDCList();
                MainForm.objINV_SalesInvoiceList.MdiParent = this;
                MainForm.objINV_SalesInvoiceList.Show();
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
                if (isClose == false) { return; }
                MainForm.objINV_DamageEntryList = new INV_DamageEntryList();
                MainForm.objINV_DamageEntryList.MdiParent = this;
                MainForm.objINV_DamageEntryList.Show();
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
                if (isClose == false) { return; }
                MainForm.objINV_Inwardlist = new INV_Inwardlist();
                MainForm.objINV_Inwardlist.MdiParent = this;
                MainForm.objINV_Inwardlist.Show();
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
                if (isClose == false) { return; }
                MainForm.objINV_InwardPurchaseList = new INV_InwardPurchaseList();
                MainForm.objINV_InwardPurchaseList.MdiParent = this;
                MainForm.objINV_InwardPurchaseList.Show();
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
                if (isClose == false) { return; }
                MainForm.objPUR_GRNApprovalList = new PUR_GRNApprovalList();
                MainForm.objPUR_GRNApprovalList.MdiParent = this;
                MainForm.objPUR_GRNApprovalList.Show();
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
                if (isClose == false) { return; }
                MainForm.objPUR_PurchaseDCList = new PUR_PurchaseDCList();
                MainForm.objPUR_PurchaseDCList.MdiParent = this;
                MainForm.objPUR_PurchaseDCList.Show();
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
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objCP_BulkAttributes = new CP_BulkAttributes();
                MainForm.objCP_BulkAttributes.MdiParent = this;
                MainForm.objCP_BulkAttributes.Show();
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
                if (isClose == false) { return; }
                MainForm.objINV_StockHold = new INV_StockHold();
                MainForm.objINV_StockHold.MdiParent = this;
                MainForm.objINV_StockHold.Show();
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
                if (isClose == false) { return; }
                MainForm.objINV_StockConversionList = new INV_StockConversionList();
                MainForm.objINV_StockConversionList.MdiParent = this;
                MainForm.objINV_StockConversionList.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbDebitNote_Click(object sender, EventArgs e)
        {
            try
            {
                udfnCloseChildForms();
                if (isClose == false) { return; }
                MainForm.objPAY_DebitNoteList = new PAY_DebitNoteList();
                MainForm.objPAY_DebitNoteList.MdiParent = this;
                MainForm.objPAY_DebitNoteList.Show();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    } 
}