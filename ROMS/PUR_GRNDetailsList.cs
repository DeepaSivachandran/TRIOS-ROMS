using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using ROMS.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    public partial class PUR_GRNDetailsList : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        MainForm objMainForm = new MainForm();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DateTime varmaxdate;
        public DataTable Deftable = new DataTable();
        Boolean BlnSearchImageYN = false;
        public string varUserID = "0", varsuppliername = "";
        public int varGRNPrintFlag = 0;
        public int varCheckChange = 0;
        public ToolTip tpSupplier = new ToolTip();
        public string[] varGRNCheckedId;
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public PUR_GRNDetailsList()
        {
            InitializeComponent();
            windowControl.Initialize(tsGRNEntryList, this);
        }

        private void TsbNew_Click(object sender, EventArgs e)
        { 
            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    MainForm.objPUR_GRNEntry = new PUR_GRNEntry();
                    //MainForm.objPUR_GRNEntry.MdiParent = this.ParentForm;
                    MainForm.objPUR_GRNEntry.ShowDialog();
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        }
        public void udfnDate()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 4;
                objMR_Master.paraID = 6;
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                if (objd.Tables[1].Rows.Count != 0)
                {
                    varmaxdate = DateTime.ParseExact(objd.Tables[1].Rows[0]["mintoday"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                objMR_Master.ViewType = 9;
                objMR_Master.paraID = 6;
                objMR_Master.paraFlag = 6;
                objd = null;
                objd = objDServ.udfnMaster(objMR_Master);
                objDServ.CloseConnection();
                if (objd.Tables[0].Rows.Count != 0)
                {
                    DateTime varmindate = MainForm.pbFYStartDate;
                    dpFromDate.MinDate = varmindate;
                    dpFromDate.Text = Convert.ToString(objd.Tables[0].Rows[0]["DATE1"]);
                }
                dpFromDate.MaxDate = varmaxdate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PUR_GRNDetailsList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    TsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    TsbEdit_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D) || (e.KeyCode == Keys.Delete))
                {
                    if (Convert.ToInt32(grdGRNList.SelectedRows[0].Cells["GRN_STSID"].Value) == 17 && Convert.ToInt32(grdGRNList.SelectedRows[0].Cells["PURREDCID"].Value) == 0)
                    {
                        TsbDelete_Click(sender, e);
                    }
                }
                if (e.KeyCode == Keys.Escape)
                {
                    //MainForm.objStart = new DEF_Start();
                    //MainForm.objStart.MdiParent = this.ParentForm;
                    //MainForm.objStart.Show();
                    //this.Close();
                    windowControl?.TriggerClose();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void TsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void PUR_GRNDetailsList_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 103;
                udfnDate();
                udfnConcernLoad();
                //dpFromDate.Text = Convert.ToString(MainForm.pbCurrentDate);
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                txtSupplier.Text = "";
                udfnListLoad();
                udfnGeneralSettingsList();
                if (grdGRNList.Rows.Count>0)
                {
                    tsTotalGRN.Text = Convert.ToString(grdGRNList.Rows.Count);
                }
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }
                //grdGRNList.Columns["clmCheck"].ReadOnly = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(MenuCode);
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions;
                tsbNew.Visible = privilege.Contains("2");
                tssNew.Visible = privilege.Contains("2");
                tsbEdit.Visible = privilege.Contains("3");
                tssEdit.Visible = privilege.Contains("3");
                tsbDelete.Visible = privilege.Contains("4");
                btnPrint.Visible = privilege.Contains("5");
                btnExport.Visible = privilege.Contains("6");
                grpInvoicePendingDc.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 18 && sp.EditAccess.Split(',').Contains("9"));
                btnComplete.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 19 && sp.EditAccess.Split(',').Contains("9")); 
                udfnGridAccess();  
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridAccess()
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    grdGRNList.Columns["ClmEdit"].Visible = privilege.Contains("3");
                    grdGRNList.Columns["clmCheck"].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 19 && sp.EditAccess.Split(',').Contains("9"));
                    grdGRNList.Columns["clmPrint"].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 44 && sp.EditAccess.Split(',').Contains("9"));
                    grdGRNList.Columns["clmLocPrint"].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 20 && sp.EditAccess.Split(',').Contains("9"));
                    DGV_SearchGrid.Columns[0].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 19 && sp.EditAccess.Split(',').Contains("9"));
                    DGV_SearchGrid.Columns[1].Visible = privilege.Contains("3");
                    DGV_SearchGrid.Columns[2].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 44 && sp.EditAccess.Split(',').Contains("9"));
                    DGV_SearchGrid.Columns[3].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 20 && sp.EditAccess.Split(',').Contains("9"));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGeneralSettingsList()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGeneralSettingList(0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            varGRNPrintFlag = Convert.ToInt32(objDs.Tables[0].Rows[0]["GS_GRNPrint"]);
                        }
                    }
                }
                if(varGRNPrintFlag == 1)
                {
                    grdGRNList.Columns["clmLocPrint"].Visible = true;
                }
                else
                {
                    grdGRNList.Columns["clmLocPrint"].Visible = false;
                    DGV_SearchGrid.Columns["clmLocPrint"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListLoad()
        {
            try
            {
                int Varflag = 0;
                string varSupplierId = "0";
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                else
                {
                    string[] values = new string[0];
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 31;
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedleCode.Text);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varSupplierId = Convert.ToString(objDsSupplierId.Tables[0].Rows[0][0]);
                                values = Convert.ToString(varSupplierId).Split(',');
                            }
                        }
                    }
                    if (values[0] == "-1")
                    {
                        errGRNList.SetError(txtSupplier, "Invalid supplier.");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedleCode.Text = "0";
                        Varflag = 1;
                    }
                    else
                    {
                        errGRNList.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedleCode.Text = values[1];
                        txtSupplier.BackColor = Color.White;

                    }
                }
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                this.ActiveControl = dpFromDate;
                //********** To display a data in a grid  ****************** 
                grdGRNList.DataSource = null;
                errGRNList.Clear();
                DGV_SearchGrid.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGrnListLoad(1, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), Convert.ToInt32(cmbConcern.SelectedValue), 0, dpFromDate.Text, dpToDate.Text, 0, Convert.ToInt32(cmbstatus.SelectedValue), Convert.ToInt32(cmbOrdertype.SelectedValue), "", "", 0, 0, "0", "","", 0, 0, 0, 0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0 && Varflag == 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdGRNList.Columns["ClmEdit"].Visible = true;
                            //grdGRNList.Columns["ClmEdit"].DisplayIndex = objDs.Tables[0].Columns.Count;
                            grdGRNList.Columns["ClmEdit"].Width = 50;
                            grdGRNList.Columns["clmCheck"].Width = 50;
                            grdGRNList.Columns["clmPrint"].Visible = true;
                            //grdGRNList.Columns["clmPrint"].DisplayIndex = objDs.Tables[0].Columns.Count+1;
                            grdGRNList.Columns["clmPrint"].Width = 50;
                            grdGRNList.DataSource = objDs.Tables[0];
                            grdGRNList.Columns["S.No."].Width = 40;
                            //grdGRNList.Columns["Concern"].Visible = false;
                            grdGRNList.Columns["GRN No."].Width = 60;
                            grdGRNList.Columns["GRN Date"].Width = 80;
                            grdGRNList.Columns["Supplier"].Width = 300;
                            grdGRNList.Columns["City"].Width = 100;
                            grdGRNList.Columns["GSTIN"].Visible = false;
                            grdGRNList.Columns["Inv Date"].Width = 85;
                            grdGRNList.Columns["Concern"].Width = 70;
                            grdGRNList.Columns["Inv No."].Width = 100;
                            grdGRNList.Columns["Inv Amt"].Width = 120;
                            grdGRNList.Columns["Created By"].Width = 200;
                            grdGRNList.Columns["Frieght Charges"].Width = 120;
                            grdGRNList.Columns["Unloading Charges"].Width = 120;
                            grdGRNList.Columns["Order Type"].Width = 100;
                            grdGRNList.Columns["Any Pur Returns"].Width = 150;
                            grdGRNList.Columns["GRN Status"].Width = 130;
                            grdGRNList.Columns["Overall Status"].Width = 120;
                            grdGRNList.Columns["GRNID"].Visible = false;
                            //grdGRNList.Columns["NewSts"].Visible = false;
                            grdGRNList.Columns["GRN_SPSCID"].Visible = false;
                            grdGRNList.Columns["GRN_SPID"].Visible = false;
                            grdGRNList.Columns["GRN_STSID"].Visible = false;
                            grdGRNList.Columns["GRN_OrderType"].Visible = false;
                            grdGRNList.Columns["Completed"].Visible = false;
                            grdGRNList.Columns["STSID"].Visible = false;
                            grdGRNList.Columns["GRN_INVSTSID"].Visible = false;
                            grdGRNList.Columns["SP_SupplierType"].Visible = false;
                            grdGRNList.Columns["Totallbl"].Visible = false;
                            grdGRNList.Columns["PURREDCID"].Visible = false;
                            grdGRNList.Columns["GRN Full Status"].Visible = false;
                            grdGRNList.Columns["Overall Full Status"].Visible = false;

                            grdGRNList.Columns["PendingFlag"].Visible = false;
                            grdGRNList.Columns["DraftFlag"].Visible = false;
                            grdGRNList.Columns["GRN_Payment_StsID"].Visible = false;
                            grdGRNList.Columns["GRN_LastTransNo"].Visible = false;
                            grdGRNList.Columns["GRN_Created"].Visible = false;
                            grdGRNList.Columns["Any Pur Returns"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGRNList.Columns["Inv Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGRNList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGRNList.Columns["GRN Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGRNList.Columns["GRN Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGRNList.Columns["Frieght Charges"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGRNList.Columns["Unloading Charges"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGRNList.Columns["Tot Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGRNList.Columns["Overall Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            grdGRNList.Columns["Inv Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            //grdGRNList.Columns["S.No."].ReadOnly = true;
                            //grdGRNList.Columns["Concern"].ReadOnly = true;
                            //grdGRNList.Columns["GRN No."].ReadOnly = true;
                            //grdGRNList.Columns["GRN Date"].ReadOnly = true;
                            //grdGRNList.Columns["Supplier"].ReadOnly = true;
                            //grdGRNList.Columns["City"].ReadOnly = true;
                            //grdGRNList.Columns["GSTIN"].ReadOnly = true;
                            //grdGRNList.Columns["Inv Date"].ReadOnly = true;
                            //grdGRNList.Columns["Inv No."].ReadOnly = true;
                            //grdGRNList.Columns["Inv Amt"].ReadOnly = true;
                            //grdGRNList.Columns["Created By"].ReadOnly = true;
                            //grdGRNList.Columns["Loading Charges"].ReadOnly = true;
                            //grdGRNList.Columns["Unloading Charges"].ReadOnly = true;
                            //grdGRNList.Columns["Order Type"].ReadOnly = true;
                            //grdGRNList.Columns["Any Pur Returns"].ReadOnly = true;
                            //grdGRNList.Columns["GRN Status"].ReadOnly = true;
                            //grdGRNList.Columns["Overall Status"].ReadOnly = true;
                            //grdGRNList.Columns["ClmEdit"].ReadOnly = true;
                            //grdGRNList.Columns["clmPrint"].ReadOnly = true;
                            //grdGRNList.Columns["Tot Pro"].ReadOnly = true;
                            //grdGRNList.Columns["Payment Mode"].ReadOnly = true;
                            //grdGRNList.Columns["clmCheck"].ReadOnly = false;

                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                            grdGRNList.Columns["clmPrint"].Visible = false;
                            grdGRNList.Columns["ClmEdit"].Visible = false;
                            Deftable = objDs.Tables[0];
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                        grdGRNList.Columns["clmPrint"].Visible = false;
                        grdGRNList.Columns["ClmEdit"].Visible = false;
                        Deftable = objDs.Tables[0];
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    grdGRNList.Columns["clmPrint"].Visible = false;
                    grdGRNList.Columns["ClmEdit"].Visible = false;
                    Deftable = objDs.Tables[0];
                } 
                udfnSearchGridHead();
                if (lblNoRecordsFound.Visible == true)
                {
                    udfnDefcolumns();
                }
                else { DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; udfnGridAccess(); }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                tsTotalGRN.Text = Convert.ToString(grdGRNList.Rows.Count);
                if (varCheckChange == 0)
                {
                    btnComplete.Enabled = false;
                }
                if (grdGRNList.Rows.Count > 0)
                {
                    grdGRNList.Columns["S.No."].ReadOnly = true;
                    grdGRNList.Columns["Concern"].ReadOnly = true;
                    grdGRNList.Columns["GRN No."].ReadOnly = true;
                    grdGRNList.Columns["GRN Date"].ReadOnly = true;
                    grdGRNList.Columns["Supplier"].ReadOnly = true;
                    grdGRNList.Columns["City"].ReadOnly = true;
                    grdGRNList.Columns["GSTIN"].ReadOnly = true;
                    grdGRNList.Columns["Inv Date"].ReadOnly = true;
                    grdGRNList.Columns["Inv No."].ReadOnly = true;
                    grdGRNList.Columns["Inv Amt"].ReadOnly = true;
                    grdGRNList.Columns["Created By"].ReadOnly = true;
                    grdGRNList.Columns["Frieght Charges"].ReadOnly = true;
                    grdGRNList.Columns["Unloading Charges"].ReadOnly = true;
                    grdGRNList.Columns["Order Type"].ReadOnly = true;
                    grdGRNList.Columns["Any Pur Returns"].ReadOnly = true;
                    grdGRNList.Columns["GRN Status"].ReadOnly = true;
                    grdGRNList.Columns["Overall Status"].ReadOnly = true;
                    grdGRNList.Columns["ClmEdit"].ReadOnly = true;
                    grdGRNList.Columns["clmPrint"].ReadOnly = true;
                    grdGRNList.Columns["Tot Pro"].ReadOnly = true;
                    grdGRNList.Columns["Payment Mode"].ReadOnly = true;
                    //grdGRNList.Columns["clmCheck"].ReadOnly = false;
                }
            }
            
        }
        public void udfnDefcolumns()
        {
            try
            {
                DGV_SearchGrid.DataSource = null;
                DGV_SearchGrid.DataSource = Deftable;
                DGV_SearchGrid.Columns["GRNID"].Visible = false;
                DGV_SearchGrid.Columns["GRN_SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["GRN_SPID"].Visible = false;
                DGV_SearchGrid.Columns["GRN_STSID"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Concern"].Visible = false;
                DGV_SearchGrid.Columns["GRN No."].Width = 100;
                DGV_SearchGrid.Columns["GRN Date"].Width = 100;
                DGV_SearchGrid.Columns["Supplier"].Width = 300;
                DGV_SearchGrid.Columns["City"].Width = 100;
                DGV_SearchGrid.Columns["GSTIN"].Visible = false;
                DGV_SearchGrid.Columns["Inv Date"].Width = 100;
                DGV_SearchGrid.Columns["Inv No."].Width = 100;
                DGV_SearchGrid.Columns["Inv Amt"].Width = 120;
                DGV_SearchGrid.Columns["Created By"].Width = 100;
                DGV_SearchGrid.Columns["Order Type"].Width = 100;
                DGV_SearchGrid.Columns["Any Pur Returns"].Width = 150;
                DGV_SearchGrid.Columns["GRNID"].Visible = false;
                DGV_SearchGrid.Columns["GRN_SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["GRN_SPID"].Visible = false;
                DGV_SearchGrid.Columns["SP_SupplierType"].Visible = false;
                DGV_SearchGrid.Columns["GRN_OrderType"].Visible = false;
                DGV_SearchGrid.Columns["STSID"].Visible = false;
                DGV_SearchGrid.Columns["PendingFlag"].Visible = false;
                DGV_SearchGrid.Columns["DraftFlag"].Visible = false;
                DGV_SearchGrid.Columns["GRN_Payment_StsID"].Visible = false;
                DGV_SearchGrid.Columns["GRN_LastTransNo"].Visible = false;
                DGV_SearchGrid.Columns["GRN_Created"].Visible = false;
                DGV_SearchGrid.Columns["Completed"].Visible = false;
                DGV_SearchGrid.Columns["PURREDCID"].Visible = false;
                DGV_SearchGrid.Columns["GRN_INVSTSID"].Visible = false;
                DGV_SearchGrid.Columns["GRN Full Status"].Visible = false;
                DGV_SearchGrid.Columns["Overall Full Status"].Visible = false;
                if (DGV_SearchGrid.Columns.Contains("clmPrint") == true) { DGV_SearchGrid.Columns["clmPrint"].Visible = false; }
                if (DGV_SearchGrid.Columns.Contains("ClmEdit") == true) { DGV_SearchGrid.Columns["ClmEdit"].Visible = false; }
                if (DGV_SearchGrid.Columns.Contains("Totallbl") == true) { DGV_SearchGrid.Columns["Totallbl"].Visible = false; }
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnConcernLoad()
        {
            try
            {

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (16 ) OR MSTID  IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrdertype, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID=7 AND STSID IN (17,23) OR STSID=0", "STS_Name,STSID", cmbstatus, "", "STS_Name", "STSID");
                cmbstatus.SelectedValue = 17;
                objDataBind = null;
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(2, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                cmbConcern.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDT.Tables[0];
                        }
                    }
                }

                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPurchaseApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdGRNList.Columns[e.ColumnIndex].Name)
                    {
                        case "ClmEdit":
                            MainForm.objPUR_GRNEntry = new PUR_GRNEntry();
                            MainForm.objPUR_GRNEntry.pbSupplierId = Convert.ToString(grdGRNList.SelectedRows[0].Cells["GRN_SPID"].Value.ToString());
                            MainForm.objPUR_GRNEntry.pbScheduleid = Convert.ToString(grdGRNList.SelectedRows[0].Cells["GRN_SPSCID"].Value.ToString());
                            MainForm.objPUR_GRNEntry.pbGRNId = Convert.ToString(grdGRNList.SelectedRows[0].Cells["GRNID"].Value.ToString());
                            MainForm.objPUR_GRNEntry.pbGRNSTS = Convert.ToString(grdGRNList.SelectedRows[0].Cells["GRN_STSID"].Value.ToString());
                            MainForm.objPUR_GRNEntry.btnSave.Text = "Update && Print";
                            MainForm.objPUR_GRNEntry.ShowDialog();
                            break;
                        case "clmPrint":
                            DialogResult result1 = DialogResult.Yes;
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(87);
                            objDServ.CloseConnection();
                            result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.Yes)
                            {
                                try
                                {
                                    string varHeader = "";
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_LP_GRN_QRCode.rpt");
                                    objBillreport.SetParameterValue("paraGRNID", Convert.ToString(grdGRNList.SelectedRows[0].Cells["GRNID"].Value.ToString()));
                                    objValidation.CrySqlConnection(objBillreport);

                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.Text = varHeader;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                                catch (Exception ex)
                                {
                                    objError = new DataError();
                                    objError.WriteFile(ex);
                                }
                            }
                            break;
                        case "clmLocPrint":
                            SPDataService objDS = new SPDataService();
                            string varMessage1 = objDS.udfnGetMessages(87);
                            objDS.CloseConnection();
                            result1 = MessageBox.Show(varMessage1, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.Yes)
                            {
                                try
                                {
                                    string varHeader = "";
                                    string ID = Convert.ToString(grdGRNList.SelectedRows[0].Cells["GRNID"].Value.ToString());
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_PUR_GRNDetails.rpt");
                                    varHeader = "Godown Wise GRN Transfer";

                                    objBillreport.SetParameterValue("paraGRNID", Convert.ToInt32(ID));
                                    objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(cmbConcern.SelectedValue));
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                                    objValidation.CrySqlConnection(objBillreport);

                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.Text = varHeader;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                                catch (Exception ex)
                                {
                                    objError = new DataError();
                                    objError.WriteFile(ex);
                                }
                            }
                            break;
                        case "clmCheck":
                            List<string> varValues = new List<string>();
                            foreach (DataGridViewRow row in grdGRNList.Rows)
                            {
                                if (Convert.ToString(row.Cells["clmCheck"].Value) != "")
                                {
                                    if (Convert.ToBoolean(row.Cells["clmCheck"].Value) == true)
                                    {
                                        varValues.Add((row.Cells["GRNID"].Value.ToString()));
                                    }
                                }
                            }
                            varGRNCheckedId = varValues.ToArray();

                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            finally
            {
                udfnCheckChange(sender,e);
            }
        }
        public void udfnCheckChange(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdGRNList.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name == "clmCheck")
                {
                    if (Convert.ToBoolean(grdGRNList.Rows[e.RowIndex].Cells["clmCheck"].Value) == true)
                    {
                        btnComplete.Enabled = true;
                        varCheckChange++;
                    }
                    else if (varCheckChange != 0 && Convert.ToBoolean(grdGRNList.Rows[e.RowIndex].Cells["clmCheck"].Value) == false)
                    {
                        varCheckChange--;
                    }
                    if (varCheckChange == 0)
                    {
                        btnComplete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        private void GrdPurchaseApproval_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex); 
            }
        }
        public void udfnEdit()
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objPUR_GRNDetails = new PUR_GRNDetails();
                    MainForm.objPUR_GRNDetails.MdiParent = this.ParentForm;
                    MainForm.objPUR_GRNDetails.pbSupplierId = Convert.ToString(grdGRNList.SelectedRows[0].Cells["GRN_SPID"].Value.ToString());
                    MainForm.objPUR_GRNDetails.pbGRNId = Convert.ToString(grdGRNList.SelectedRows[0].Cells["GRNID"].Value.ToString());
                    MainForm.objPUR_GRNDetails.varSupplierType = Convert.ToInt32(grdGRNList.SelectedRows[0].Cells["SP_SupplierType"].Value);
                    MainForm.objPUR_GRNDetails.varOrderType = Convert.ToInt32(grdGRNList.SelectedRows[0].Cells["GRN_OrderType"].Value);
                    MainForm.objPUR_GRNDetails.pbStsID = Convert.ToString(grdGRNList.SelectedRows[0].Cells["GRN_STSID"].Value);
                    //objMainForm.CenterEntryForm(this, MainForm.objPUR_GRNDetails);
                    MainForm main = (MainForm)this.MdiParent;
                    main.IsEntryFormOpen = true;
                    main.CurrentEntryForm = MainForm.objPUR_GRNDetails;
                    main.CurrentParentListForm = this;
                    MainForm.objPUR_GRNDetails.Show();
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);

                }
                finally
                {
                    picLoader.Visible = false;
                    picLoader.SendToBack();
                }
            }
        }

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpFromDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpToDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupplier.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrdertype.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (LV_Supplier.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        LV_Supplier.Visible = false;
                    }
                    else
                    {
                        LV_Supplier.Focus();
                    }
                    if (LV_Supplier.Items.Count > 0)
                    {
                        LV_Supplier.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.BringToFront();
                //RPTViewer.SendToBack();
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    objMR_Supplier.ParaToDate = dpToDate.Text;
                    objMR_Supplier.paraFlag = 6;
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString()
                                    , objDs.Tables[0].Rows[i]["SupplierName"].ToString(), objDs.Tables[0].Rows[i]["ScheduleName"].ToString()};
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.BringToFront();
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[3].Width = 0;
                                LV_Supplier.Columns[4].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    LV_Supplier.Visible = false;
                    LV_Supplier.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
            }
        }


        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                //TxtSupplier_Leave(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnListViewData()
        {
            try
            {
                if (txtSupplier.Text != "")
                {
                    varsuppliername = "";
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    varsuppliername = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedleCode.Text = selectedItem.SubItems[2].Text;
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                }
                cmbOrdertype.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                LV_Supplier.Visible = false;
            }
        }
        private void LV_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrdertype_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbOrdertype.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrdertype_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrdertype.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                        return;
                    if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                        if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                        {
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All
                                & ~(DataGridViewPaintParts.ContentForeground));

                            //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                            e.Handled = true;
                        }

                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    {
                        if (e.Value == null || !(bool)e.Value)
                        {
                            e.PaintBackground(e.CellBounds, false);
                            e.Handled = true;
                        }
                    }
                    if (DGV_SearchGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Name != "Boolean" )
                    {
                        if (e.ColumnIndex == 1)
                        {
                            DGV_SearchGrid.Rows[e.RowIndex].Cells[3].Value = null;
                            DGV_SearchGrid.Rows[e.RowIndex].Cells[3] = new DataGridViewTextBoxCell();
                            DGV_SearchGrid.Rows[e.RowIndex].Cells[3].Value = "";
                            DGV_SearchGrid.Rows[e.RowIndex].Cells[3].ReadOnly = true;

                        }
                    }

                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (grdGRNList.ColumnCount > 0)
                    {
                        grdGRNList.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdGRNList.HorizontalScrollingOffset;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                //udfnGridSearchHeading(grdGRNList, DGV_SearchGrid);
                //if (DGV_SearchGrid.ColumnCount > 1)
                //{
                //    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                //    DGV_SearchGrid.Columns["ClmEdit"].ReadOnly = true;
                //    DGV_SearchGrid.Columns["clmPrint"].ReadOnly = true;
                //}
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdGRNList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdGRNList.Columns)
                    {
                        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    //DGV_SearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                    DGV_SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                    DGV_SearchGrid.Columns[2].DefaultCellStyle.NullValue = null;
                    DGV_SearchGrid.Columns[3].DefaultCellStyle.NullValue = null;
                    for (int i = 4; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                    //DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[1].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[2].ReadOnly = false;
                    DGV_SearchGrid.Rows[0].Cells[2].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[3].ReadOnly = false;
                    DGV_SearchGrid.Rows[0].Cells[3].Value = new Bitmap(1, 1);
                    //DGV_SearchGrid.Rows[0].Cells[2].Value = new DataGridViewCheckBoxCell();
                    //DGV_SearchGrid.Rows[0].Cells[2].Value = "";
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    //dgv2.DataSource = null;
                    dgv2.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in dgv1.Columns)
                    {
                        if (col.Visible)
                        {
                            dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                            visibleColumns.Add(col.Index);
                        }
                    }
                    int rowIndex = 0;
                    int ColIndex = 0;
                    dgv2.Rows.Clear();
                    dgv2.Rows.Add();
                    BlnSearchImageYN = false;
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                        if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                        {
                            //dgv2.Rows[rowIndex].Visible = false;
                            BlnSearchImageYN = true;
                            ColIndex = i;
                            //dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                            dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                            ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                        }
                        else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                        {
                            BlnSearchImageYN = true;
                            dgv2.Rows[rowIndex].Cells[i].Value = false;
                        }
                        else
                        {
                            dgv2.Rows[rowIndex].Cells[i].Value = "";
                        }
                    }

                    //DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[1].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[2].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[2].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[3].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[3].Value = new Bitmap(1, 1);
                    //DGV_SearchGrid.Rows[0].Cells[2].Value = new DataGridViewTextBoxCell();
                    //DGV_SearchGrid.Rows[0].Cells[2].Value = "";
                    //DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    //DGV_SearchGrid.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int i = e.ColumnIndex + 2;
                    if (e.ColumnIndex == 0)
                    {
                        i = e.ColumnIndex;
                    }
                    DataGridViewColumn newColumn = grdGRNList.Columns[i];
                    DataGridViewColumn oldColumn = grdGRNList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdGRNList.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            // Sort a new column and remove the old SortGlyph.
                            direction = ListSortDirection.Ascending;
                            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                        }
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    if (newColumn.GetType() != typeof(DataGridViewImageColumn))
                    {
                        grdGRNList.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? 
                            SortOrder.Ascending : SortOrder.Descending;
                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdGRNList.HorizontalScrollingOffset;
                        DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int cl = grdGRNList.ColumnCount;
                    int cls = DGV_SearchGrid.ColumnCount;
                    int offSetValue = grdGRNList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdGRNList.Width > grdGRNList.HorizontalScrollingOffset && grdGRNList.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdGRNList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnscrollVisible(DataGridView DGV, DataGridView grdGroupList)
        {
            try
            {
                var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }

                    int I = DGV_SearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            if (DGV_SearchGrid.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                            {
                                DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                            }
                            else { DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = ""; }
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
        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdGRNList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGRNList);
                objDser.CloseConnection();
                grdGRNList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 

                //DGV Grid Searching time checked value again Check 
                if (varGRNCheckedId != null)
                {
                    for (int i = 0; i < grdGRNList.RowCount; i++)
                    {
                        if (varGRNCheckedId.Contains(Convert.ToString(grdGRNList.Rows[i].Cells["GRNID"].Value)))
                        {
                            grdGRNList.Rows[i].Cells["clmCheck"].Value = true;
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


        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                lblschedleCode.Focus();
                RPTViewer.Visible = false;
                RPTViewer.SendToBack();
                udfnListLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGRNList_Scroll(object sender, ScrollEventArgs e)
        {

            try
            {
                int totalWidth = 0;
                int cl = grdGRNList.ColumnCount;
                int cls = DGV_SearchGrid.ColumnCount;
                int offSetValue = grdGRNList.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;

                if (totalWidth - grdGRNList.Width > grdGRNList.HorizontalScrollingOffset && grdGRNList.HorizontalScrollingOffset > 0)
                {
                    //offSetValue = offSetValue ;
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdGRNList);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrdertype_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbstatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGRNList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEdit();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpToDate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                udfndelete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfndelete()
        {
            if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdGRNList.SelectedRows.Count > 0)
                    {
                        string result = "";
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SPDataService objspdservice = new SPDataService();
                            result = "";
                            int pbGRNId = 0;
                            pbGRNId = Convert.ToInt32(grdGRNList.SelectedRows[0].Cells["GRNID"].Value);
                            TRN_GRN objTRNS_GRN = new TRN_GRN();
                            objTRNS_GRN.ViewType = 4;
                            objTRNS_GRN.ParaGRNID = pbGRNId;
                            objTRNS_GRN.paraOriginator = "GRN Delete";
                            objTRNS_GRN.paraDeleteFlag = 0;
                            result = objspdservice.udfnGRNEntry(objTRNS_GRN);
                            objspdservice.CloseConnection(); string[] varvalue = result.Split('~');
                            if (result.Split('~')[1] == "1")
                            {
                                MainForm.objCP_Verify = new CP_Verify();
                                MainForm.objCP_Verify.ShowDialog();
                                varUserID = MainForm.objCP_Verify.varUserId;
                                if (MainForm.objCP_Verify.flag == 1)
                                {
                                    result = "";
                                    objTRNS_GRN.ViewType = 4;
                                    objTRNS_GRN.ParaGRNID = pbGRNId;
                                    objTRNS_GRN.paraOriginator = "GRN Delete";
                                    objTRNS_GRN.paraDeleteFlag = 1;
                                    result = objspdservice.udfnGRNEntry(objTRNS_GRN);
                                    objspdservice.CloseConnection();
                                    string[] varvalue1 = result.Split('~');
                                    if (varvalue1[0] == "3")
                                    {
                                        MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        udfnListLoad();
                                    }
                                    else
                                    {
                                        MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void Cmbstatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Cmbstatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbstatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbstatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrdertype_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void GrdGRNList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdGRNList.ClearSelection();
                for (int i = 0; i < grdGRNList.Rows.Count; i++)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[i].Cells["GRN Status"]; 
                    DataGridViewCell cell3 = dataGridView.Rows[i].Cells["Overall Status"]; 
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "17")
                    {
                        cell.Style.BackColor = Color.Red;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                        //grdGRNList.Rows[i].Cells["clmCheck"].ReadOnly = true;
                        grdGRNList.Rows[i].Cells["clmLocPrint"].ReadOnly = true;
                        DataGridViewTextBoxCell print = new DataGridViewTextBoxCell();
                        print.Value = "";
                        grdGRNList.Rows[i].Cells["clmLocPrint"] = print;
                        print.ReadOnly = true;
                        //DataGridViewTextBoxCell Check = new DataGridViewTextBoxCell();
                        //Check.Value = "";
                        //grdGRNList.Rows[i].Cells["clmCheck"] = Check;
                        //Check.ReadOnly = true;
                    }
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "24")
                    {
                        cell.Style.BackColor = Color.Green;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "23")
                    {
                        cell.Style.BackColor = Color.LimeGreen;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "44")
                    {
                        cell.Style.BackColor = Color.RoyalBlue;
                        cell.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["Totallbl"].Value) == "0")
                    {
                        DataGridViewCell cell2 = dataGridView.Rows[i].Cells["clmPrint"];
                        cell2.Value = new Bitmap(1, 1);
                        cell2.ReadOnly = true;
                    }
                    /*
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN Status"].Value) == "")
                    {
                        cell3.Style.BackColor = Color.Red;
                        cell3.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN Status"].Value) != "" && Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "17")
                    {
                        cell3.Style.BackColor = Color.RoyalBlue;
                        cell3.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "44")
                    {
                        cell3.Style.BackColor = Color.DarkGreen;
                        cell3.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "23" && Convert.ToString(grdGRNList.Rows[i].Cells["GRN_INVSTSID"].Value) == "23" || Convert.ToString(grdGRNList.Rows[i].Cells["GRN_INVSTSID"].Value) == "52" || Convert.ToString(grdGRNList.Rows[i].Cells["GRN_INVSTSID"].Value) == "55")
                    {
                        cell3.Style.BackColor = Color.Orange;
                        cell3.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "44" || Convert.ToString(grdGRNList.Rows[i].Cells["GRN_INVSTSID"].Value) == "55" && Convert.ToString(grdGRNList.Rows[i].Cells["GRN_INVSTSID"].Value) == "23")
                    {
                        cell3.Style.BackColor = Color.DarkGreen;
                        cell3.Style.ForeColor = Color.White;// Set the background color to the default background color
                    }
                    */
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "17" || Convert.ToString(grdGRNList.Rows[i].Cells["GRN_STSID"].Value) == "44" || Convert.ToString(grdGRNList.Rows[i].Cells["Completed"].Value) == "1")
                    {
                        DataGridViewTextBoxCell Check = new DataGridViewTextBoxCell();
                        Check.Value = "";
                        grdGRNList.Rows[i].Cells["clmCheck"] = Check;
                        Check.ReadOnly = true;
                        //Check.Style.BackColor = Color.LightGray;
                    }
                    else
                    {
                        grdGRNList.Rows[i].Cells["clmCheck"].ReadOnly = false;
                    }
                } 
                
                grdGRNList.Columns["ClmEdit"].Frozen = true;
                grdGRNList.Columns["ClmEdit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGRNList.Columns["clmPrint"].Frozen = true;
                grdGRNList.Columns["clmPrint"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGRNList.Columns["clmLocPrint"].Frozen = true;
                grdGRNList.Columns["clmLocPrint"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGRNList.Columns["S.No."].Frozen = true;
                grdGRNList.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGRNList.Columns["Concern"].Frozen = true;
                grdGRNList.Columns["Concern"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGRNList.Columns["GRN Status"].Frozen = true;
                grdGRNList.Columns["GRN Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGRNList.Columns["Overall Status"].Frozen = true;
                grdGRNList.Columns["Overall Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdGRNList.Columns["clmCheck"].ReadOnly = true;
                //grdGRNList.Columns["GRN No."].Frozen = true;
                //grdGRNList.Columns["GRN No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdGRNList.Columns["GRN Date"].Frozen = true;
                //grdGRNList.Columns["GRN Date"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdGRNList.Columns["Supplier"].Frozen = true;
                //grdGRNList.Columns["Supplier"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdGRNList.Columns["clmLocPrint"].Resizable = DataGridViewTriState.False;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void GrdGRNList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                udfnDeleteHide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                LV_Supplier.BringToFront();
                picLoader.BringToFront();
                Application.DoEvents();
                string varSupplier = txtSupplier.Text;
                int varstsid = 0, varOrdertType=0;
                if (varSupplier == "")
                {
                    varSupplier = "-All-";
                    lblSupplierCode.Text = "0";
                }
                int varPrint = 0;
                varstsid = Convert.ToInt32(cmbstatus.SelectedValue);
                varOrdertType = Convert.ToInt32(cmbOrdertype.SelectedValue);
                if(Convert.ToInt32(cmbOrdertype.SelectedValue)==0)
                {
                    varOrdertType = 0;
                }
                if (Convert.ToInt32(cmbstatus.SelectedValue) == 0)
                {
                    varstsid = 0;
                }
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGrnListLoad(10, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), Convert.ToInt32(cmbConcern.SelectedValue), 0, dpFromDate.Text, dpToDate.Text, 0, Convert.ToInt32(cmbstatus.SelectedValue), Convert.ToInt32(cmbOrdertype.SelectedValue), "", "", 0, 0, "0", "","", 0, 0, 0, 0);
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    string Type = Convert.ToString(objDs.Tables[0].Rows[0]["Type"].ToString());
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_GRNDetailsList.rpt");
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("ParaGRNFromDate", Convert.ToString(dpFromDate.Text));
                    objBillreport.SetParameterValue("ParaGRNToDate", Convert.ToString(dpToDate.Text));
                    objBillreport.SetParameterValue("ParaSupplierId", Convert.ToInt32(lblSupplierCode.Text));
                    objBillreport.SetParameterValue("ParaScheduleId", Convert.ToInt32(lblschedleCode.Text));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbstatus.Text));
                    objBillreport.SetParameterValue("paraSupplierName", Convert.ToString(varSupplier));
                    objBillreport.SetParameterValue("paraOrderTypeName", Convert.ToString(cmbOrdertype.Text));
                    objBillreport.SetParameterValue("paraCompanyName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraOrdertype", varOrdertType);
                    objBillreport.SetParameterValue("paraStatus", varstsid);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("varHeader", Type);
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                LV_Supplier.BringToFront();
                picLoader.SendToBack();
                btnPrint.Enabled = true;
                btnPrint.Focus();
                GC.Collect();
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                //btnExport.Enabled = false;
                lblschedleCode.Focus();
                if ((grdGRNList.Rows.Count > 0))
                {
                    Excel._Application ExcelObj = new Excel.Application();
                    // creating new WorkBook within Excel application  
                    Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                    // creating new Excelsheet in workbook  
                    Excel._Worksheet ExcelSheet = null;
                    // see the excel sheet behind the program  
                    ExcelObj.Visible = true;
                    ExcelSheet = ExcelBook.Sheets["Sheet1"];
                    ExcelSheet = ExcelBook.ActiveSheet;
                    // changing the name of active sheet  
                    ExcelSheet.Name = "GRN List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdGRNList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "GRN List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;

                    foreach (DataGridViewColumn col in grdGRNList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            if (cIndex != 1)
                            {
                                if (cIndex == 1 || cIndex == 2 || cIndex == 3) // Skip the first two columns (image columns)
                                {
                                    continue;
                                }
                                ExcelSheet.Cells[2, cIndex - 3] = col.HeaderText;
                                ExcelSheet.Columns[cIndex - 3].NumberFormat = "@";


                                if (col.Name == "S.No.")
                                {
                                    ExcelSheet.Columns[cIndex - 3].ColumnWidth = 10;
                                }
                                if (col.Name == "Supplier")
                                {
                                    ExcelSheet.Columns[cIndex - 3].ColumnWidth = 35;
                                }
                                if (col.Name == "Any Pur Returns")
                                {
                                    ExcelSheet.Columns[cIndex - 3].ColumnWidth = 20;
                                }
                                if (col.Name == "Concern" || col.Name == "GRN No." || col.Name == "GRN Date" || col.Name == "City"
                                    || col.Name == "Payment Mode" || col.Name == "Inv Date"|| col.Name == "Inv No." || col.Name == "Inv Amt" || col.Name == "Created By" || col.Name == "Order Type" || col.Name == "Frieght Charges" || col.Name == "Unloading Charges")
                                {
                                    ExcelSheet.Columns[cIndex - 3].ColumnWidth = 15;
                                }
                                if (col.Name == "City" || col.Name == "Overall Status")
                                {
                                    ExcelSheet.Columns[cIndex - 3].ColumnWidth = 25;
                                }


                                //else if (col.Name == "HSN Name" || col.Name == "HSN Code")
                                //{
                                //    ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                                //}
                                //else
                                //{
                                //    ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                                //}
                                if (col.Name == "S.No.")
                                {
                                    ExcelSheet.Columns[cIndex - 3].HorizontalAlignment = Excel.Constants.xlCenter;
                                }

                                if (col.Name == "Issue Date")
                                {
                                    ExcelSheet.Columns[cIndex - 3].HorizontalAlignment = Excel.Constants.xlCenter;
                                }

                                if (col.Name == "PO Date")
                                {
                                    ExcelSheet.Columns[cIndex - 3].HorizontalAlignment = Excel.Constants.xlCenter;
                                }
                                if (col.Name == "T.Pro")
                                {
                                    ExcelSheet.Columns[cIndex - 3].HorizontalAlignment = Excel.Constants.xlRight;
                                }
                                if (col.Name == "T.Units")
                                {
                                    ExcelSheet.Columns[cIndex - 3].HorizontalAlignment = Excel.Constants.xlRight;
                                }
                                if (col.Name == "TAT")
                                {
                                    ExcelSheet.Columns[cIndex - 3].HorizontalAlignment = Excel.Constants.xlRight;
                                }

                                //if (col.Name == "Total Products" || col.Name == "GST%")
                                //{
                                //    ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                                //}
                                int varSLno = 1;
                                foreach (DataGridViewRow rowa in grdGRNList.Rows)
                                {
                                    if (cIndex != 2)
                                    {
                                        //if (cIndex == 4)
                                        //{
                                        //    ExcelSheet.Cells[rowa.Index + 3, cIndex - 1] = varSLno;
                                        //    varSLno++;
                                        //}
                                        //else
                                        //{
                                        //ExcelSheet.Row(i + 2).Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        //ExcelSheet.Row(i + 2).Style.Fill.BackgroundColor.SetColor(Color.Red);
                                        //rowa.Interior.Color = System.Drawing.Color.Red;
                                        ExcelSheet.Cells[rowa.Index + 3, cIndex - 3] = rowa.Cells[col.Index].Value;
                                        if (cIndex == 3)
                                        {
                                            //-----GET BACK COLOR OF GRID
                                            Color cellBackColor = rowa.Cells[col.Index].Style.BackColor;
                                            //------SET THE BACK COLOR FOR GRID TO EXCEL
                                            ExcelSheet.Cells[rowa.Index + 3, cIndex - 3].Interior.Color = System.Drawing.ColorTranslator.ToOle(cellBackColor);
                                        }
                                        //}
                                    }
                                }
                            }
                            //foreach (DataGridViewRow rowa in grdPurchaseorderlist.Rows)
                            //{
                            //    ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                            //}
                        }
                    }
                    //   ExcelSheet.Protect(System.Configuration.ConfigurationManager.AppSettings["ExcelPassword"]);
                    ExcelObj.Visible = true;
                }
                else
                {
                    MessageBox.Show("No Record Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnCompleted_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string varGrnId = "0";
            //    //int varflag = 0;
            //    for (int i = 0; i < grdGRNList.Rows.Count; i++)
            //    {
            //        if (varGrnId=="0" && Convert.ToBoolean(grdGRNList.Rows[i].Cells["clmCheck"].Value)==true)
            //        {
            //            varGrnId = Convert.ToString(grdGRNList.Rows[i].Cells["GRNID"].Value);
            //        }
            //        else if (varGrnId!="0" && Convert.ToBoolean(grdGRNList.Rows[i].Cells["clmCheck"].Value) == true)
            //        {
            //            varGrnId = varGrnId + ',' + Convert.ToString(grdGRNList.Rows[i].Cells["GRNID"].Value);
            //        }
            //        //if(Convert.ToBoolean(grdGRNList.Rows[i].Cells["clmCheck"].Value) == false)
            //        //{
            //        //    varflag = 0;
            //        //}
            //    }
            //    SPDataService objDServ = new SPDataService();
            //    string result = "";
            //    TRN_GRN objTRNS_GRN = new TRN_GRN();
            //    objTRNS_GRN.ViewType = 6;
            //    objTRNS_GRN.paraCompletedIDs = Convert.ToString(varGrnId);
            //    result = objDServ.udfnGRNEntry(objTRNS_GRN);
            //    objDServ.CloseConnection();
            //    string[] varvalue = result.Split('~');
            //    if (varvalue[0] == "3")
            //    {
            //        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        udfnListLoad();
            //    }
            //    }
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void GrdGRNList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdGRNList.Columns["GRN Status"].Index)
                {
                    var cell = grdGRNList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdGRNList.Rows[e.RowIndex].Cells["GRN Full Status"].Value.ToString();
                }
                if (e.ColumnIndex == grdGRNList.Columns["Overall Status"].Index)
                {
                    var cell = grdGRNList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdGRNList.Rows[e.RowIndex].Cells["Overall Full Status"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGRNList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                // Commit the changes immediately
                grdGRNList.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //udfnGridSearchFilter();
                //DataService objDser = new DataService();
                //grdGRNList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdGRNList);
                //objDser.CloseConnection();
                //grdGRNList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                ////grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                string varGrnId = "0";
                //string IDs = "0";
                for (int i = 0; i < grdGRNList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdGRNList.Rows[i].Cells["clmCheck"].Value) == "")
                    {
                        grdGRNList.Rows[i].Cells["clmCheck"].Value = false;
                    }
                    else if (varGrnId == "0" && Convert.ToBoolean(grdGRNList.Rows[i].Cells["clmCheck"].Value) == true)
                    {
                        varGrnId = Convert.ToString(grdGRNList.Rows[i].Cells["GRNID"].Value);
                    }
                    else if (varGrnId != "0" && Convert.ToBoolean(grdGRNList.Rows[i].Cells["clmCheck"].Value) == true)
                    {
                        varGrnId = varGrnId + ',' + Convert.ToString(grdGRNList.Rows[i].Cells["GRNID"].Value);
                    }
                }
                //if(Convert.ToBoolean(grdGRNList.Rows[i].Cells["clmCheck"].Value) == false)
                //{
                //    varflag = 0;
                //}

                SPDataService objDServ = new SPDataService();
                string result = "";
                TRN_GRN objTRNS_GRN = new TRN_GRN();
                objTRNS_GRN.ViewType = 6;
                objTRNS_GRN.paraCompletedIDs = Convert.ToString(varGrnId);
                result = objDServ.udfnGRNEntry(objTRNS_GRN);
                objDServ.CloseConnection();
                string[] varvalue = result.Split('~');
                if (varvalue[1] == "1")
                {
                    btnPrint.Enabled = false;
                    lblNoRecordsFound.Visible = false;
                    picLoader.Visible = true;
                    RPTViewer.Visible = false;
                    LV_Supplier.BringToFront();
                    picLoader.BringToFront();
                    Application.DoEvents();
                    int varPrint = 0;
                    DataSet objDs = new DataSet();
                    SPDataService objdserv = new SPDataService();
                    objDs = objdserv.udfnGrnListLoad(13, 0, 0, 0, 0, "", "", 0, 0, 0, "", "", 0, 0, "0", "", varGrnId, 0, 0, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                    if (varPrint == 1)
                    {
                        //string Type = Convert.ToString(objDs.Tables[0].Rows[0]["Type"].ToString());
                        RPTViewer.Visible = true;
                        RPTViewer.BringToFront();
                        RPTViewer.ReuseParameterValuesOnRefresh = true;
                        /////RPTViewer.RefreshReport();
                        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_GRNDetailsBillPrint.rpt");
                        objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                        objBillreport.SetParameterValue("paraCompletedIDs", varGrnId);
                        objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        //objBillreport.SetParameterValue("varHeader", Type);
                        objValidation.CrySqlConnection(objBillreport);
                        RPTViewer.ReportSource = objBillreport;
                        RPTViewer.Refresh();
                        varCheckChange = 0;
                        if (varCheckChange == 0)
                        {
                            btnComplete.Enabled = false;
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                LV_Supplier.BringToFront();
                picLoader.SendToBack();
                btnPrint.Enabled = true;
                btnPrint.Focus();
                GC.Collect();
            }

        }

        private void BtnDCPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                LV_Supplier.BringToFront();
                picLoader.BringToFront();
                Application.DoEvents();
                //string varSupplier = txtSupplier.Text;
                //int varstsid = 0, varOrdertType = 0;
                //if (varSupplier == "")
                //{
                //    varSupplier = "-All-";
                //    lblSupplierCode.Text = "0";
                //}
                //varstsid = Convert.ToInt32(cmbstatus.SelectedValue);
                //varOrdertType = Convert.ToInt32(cmbOrdertype.SelectedValue);
                //if (Convert.ToInt32(cmbOrdertype.SelectedValue) == 0)
                //{
                //    varOrdertType = 0;
                //}
                //if (Convert.ToInt32(cmbstatus.SelectedValue) == 0)
                //{
                //    varstsid = 0;
                //}
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGrnListLoad(12, 0, 0, 0, 0, "", "", 0, 0, 0, "", "", 0, 0, "0", "", "", 0, 0, 0, 0);
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    //string Type = Convert.ToString(objDs.Tables[0].Rows[0]["Type"].ToString());
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    /////RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_GRNDetailsDC.rpt");
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    //objBillreport.SetParameterValue("paraCompanyID", Convert.ToInt32(cmbConcern.SelectedValue));
                    //objBillreport.SetParameterValue("ParaGRNFromDate", Convert.ToString(dpFromDate.Text));
                    //objBillreport.SetParameterValue("ParaGRNToDate", Convert.ToString(dpToDate.Text));
                    //objBillreport.SetParameterValue("ParaSupplierId", Convert.ToInt32(lblSupplierCode.Text));
                    //objBillreport.SetParameterValue("ParaScheduleId", Convert.ToInt32(lblschedleCode.Text));
                    //objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbstatus.Text));
                    //objBillreport.SetParameterValue("paraSupplierName", Convert.ToString(varSupplier));
                    //objBillreport.SetParameterValue("paraOrderTypeName", Convert.ToString(cmbOrdertype.Text));
                    //objBillreport.SetParameterValue("paraCompanyName", Convert.ToString(cmbConcern.Text));
                    //objBillreport.SetParameterValue("paraOrdertype", varOrdertType);
                    //objBillreport.SetParameterValue("paraStatus", varstsid);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    //objBillreport.SetParameterValue("varHeader", Type);
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                LV_Supplier.BringToFront();
                picLoader.SendToBack();
                btnPrint.Enabled = true;
                btnPrint.Focus();
                GC.Collect();
            }

        }

        public void udfnDeleteHide()
        {
            if (privilege.Contains("4"))
            {
                try
                {
                    if (Convert.ToInt32(grdGRNList.SelectedRows[0].Cells["GRN_STSID"].Value) == 17 && Convert.ToInt32(grdGRNList.SelectedRows[0].Cells["PURREDCID"].Value) == 0)
                    {
                        tsbDelete.Visible = true;
                        tssEdit.Visible = true;
                    }
                    //else if (Convert.ToInt32(grdGRNList.SelectedRows[0].Cells["PURREDCID"].Value)!=0)
                    //{
                    //    tsbDelete.Visible = true;
                    //    tssEdit.Visible = true;
                    //}
                    else
                    {
                        tsbDelete.Visible = false;
                        tssEdit.Visible = false;

                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        } 
    } 
}
