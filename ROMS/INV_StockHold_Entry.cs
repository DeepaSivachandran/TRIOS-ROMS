using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROMS.Model;


namespace ROMS
{
    //Created By:-Sathish ; Created On:-04-09-2025
    public partial class INV_StockHold_Entry : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpProductNamePICode = new ToolTip();
        private ToolTip tpQty = new ToolTip();
        private ToolTip tpReason = new ToolTip();
        private ToolTip tpTeller = new ToolTip();
        private ToolTip tpProductName = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpStock = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        public string pbFormStatus; 
        public string pbBankName = ""; 
        public string pbBankShortName = ""; 
        public int PbStateId=0; 
        public int varUpdate = 0;
        public int varmastertype = 0;
        public int varflag = 0;
        public string varPICode = "";
        public string varResult = "";
        public int varUpDownKey = 0, varPRID = 0, varUTID = 0, varStockLocationId = 0, varRKID = 0, varDecimal = 0, varDamage = 0, varFlag = 0, SHID = 0, varParentSHID = 0, varParentQty = 0;
        public int varBankId = 0;
        public bool VarSearchFlag = true;
        public string varUserID = "";
        public INV_StockHold_Entry()
        {
            InitializeComponent();
        }
        private void CP_City_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpProductNamePICode.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_City_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbConcern();
                DataBind objDBind = new DataBind();
                objDBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,75) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
                objDBind = null;
                this.ActiveControl = txtProductNamePICode;
                VarSearchFlag = true;
                txtProductDEName.Text = "Search by P.I Code (F11)";
                lblUnit.Text = "";
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
            try
            {
                if (SHID != 0)
                {
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    int ViewType = 1;
                    //objDs = objdserv.udfnStockHoldList(ViewType, SHID);
                    TRN_StockHold objTRNG_StockHold = new TRN_StockHold();
                    objTRNG_StockHold.ViewType = ViewType;
                    objTRNG_StockHold.paraSHID = Convert.ToInt32(SHID);
                    objTRNG_StockHold.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRNG_StockHold.paraIPAddress = MainForm.pbIpAddress;
                    objDs = objdserv.udfnStockHoldList(objTRNG_StockHold);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            udfntooltiphide();
                            tpProductNamePICode.Active = false;
                            if (Convert.ToString(objDs.Tables[0].Rows[0]["Reason"]) == "242")
                            {
                                varDamage = 1;
                                btnEdit.Visible = true;
                            }
                            else
                            {
                                varDamage = 0;
                                btnEdit.Visible = false;
                            }
                            cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["COMID"];
                            //txtProductNamePICode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product"]);
                            txtProductNamePICode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product Name"]);
                            lblUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            varStockLocationId = Convert.ToInt32(objDs.Tables[0].Rows[0]["SLID"]);
                            txtStockLoc.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Stock Location"]);
                            txtRack.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Rack"]);
                            txtMrp.Text = Convert.ToString(objDs.Tables[0].Rows[0]["MRP"]);
                            txtExpiryDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Expiry Date"]);
                            txtBatchNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Batch No"]);
                            txtStockQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Stock Qty"]);
                            txtQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Hold Qty"]);
                            varParentQty = Convert.ToInt32(objDs.Tables[0].Rows[0]["Stock Qty"]);
                            cmbReason.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["Reason"]);
                            varPRID = Convert.ToInt32(objDs.Tables[0].Rows[0]["PRID"]);
                            varRKID = Convert.ToInt32(objDs.Tables[0].Rows[0]["RKID"]);
                            varUTID = Convert.ToInt32(objDs.Tables[0].Rows[0]["UTID"]);
                            txtTeller.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Teller"]);
                            txtRemark.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Remarks"]);
                            lblSupplierName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Supplier"]);
                            lblSupplierName.Visible = true;
                            lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SH_SPID"]);
                            lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SH_SPSCID"]);
                            varParentSHID = Convert.ToInt32(objDs.Tables[0].Rows[0]["SH_parentSHID"]);
                            // btnSave.Text = "Update";
                        }
                    }
                    // btnSave.Text = "Update";
                    cmbConcern.Enabled = false;
                    DGV_FilterProduct.Visible = false;
                    txtProductNamePICode.Enabled = false;
                    txtProductNamePICode.BackColor = Color.White;
                    txtQty.Focus();
                    this.ActiveControl = txtQty;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfntooltiphide()
        {
            try
            {
                epStockHold.Clear();
                tpConcern.Active = false;
                tpProductName.Active = false;
                tpProductNamePICode.Active = false;
                tpStock.Active = false;
                tpRack.Active = false;
                tpStockLocation.Active = false;
                tpQty.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbConcern()
        {
            try
            {
                cmbConcern.Focus();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(3, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void udfnSave()
        {
            try
            {
                int varSPID = 0, varSPSCID = 0;
                string varoriginator = ""; int ViewType = 0;
                //if (btnSave.Text == "Save")
                if (SHID == 0)
                {
                    ViewType = 0;
                    varoriginator = "Stock Hold Creation";
                }
                else
                {
                    ViewType = 1;
                    varoriginator = "Stock Hold Update";
                }
                bool blnErrorFlag = true;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epStockHold.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    epStockHold.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductNamePICode.ShowAlways = true;
                    tpProductNamePICode.Show("Please enter Product name", txtProductNamePICode, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtStockLoc.Text).Trim() == "")
                {
                    epStockHold.SetError(txtStockLoc, "Please enter stock location");
                    txtStockLoc.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location", txtStockLoc, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtRack.Text).Trim() == "")
                {
                    epStockHold.SetError(txtRack, "Please enter rack name");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please enter rack name", txtRack, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtStockQty.Text).Trim() == "" && varParentSHID == 0)
                {
                    epStockHold.SetError(txtStockQty, "Please enter stock quantity");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStock.ShowAlways = true;
                    tpStock.Show("Please enter stock quantity", txtStockQty, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtQty.Text).Trim() == "")
                {
                    epStockHold.SetError(txtQty, "Please enter quantity");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter quantity", txtQty, 5000);
                    blnErrorFlag = false;
                }
                if (varParentSHID == 0)
                {
                    if (Convert.ToDecimal(txtQty.Text) > Convert.ToDecimal(txtStockQty.Text) || Convert.ToDecimal(txtQty.Text) == 0)
                    {
                        //epGoodsOutward.SetError(txtQty, "Please enter a correct Outward Quantity");
                        txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpQty.ShowAlways = true;
                        tpQty.Show("Please enter a correct outward quantity", txtQty, 5000);
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(96);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrorFlag = false;
                        txtQty.Focus();
                    }
                }
                else
                {
                    if (Convert.ToDecimal(txtQty.Text) > Convert.ToDecimal(varParentQty))
                    {
                        txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpQty.ShowAlways = true;
                        tpQty.Show("Please enter a correct outward quantity", txtQty, 5000);
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(96);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrorFlag = false;
                        txtQty.Focus();
                    }
                }
                if (Convert.ToInt32(cmbReason.SelectedValue) == -1)
                {
                    epStockHold.SetError(cmbReason, "Please enter the reason");
                    cmbReason.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReason.ShowAlways = true;
                    tpReason.Show("Please enter the reason", txtQty, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToInt32(cmbReason.SelectedValue) == 242)
                {
                    varSPID = Convert.ToInt32(lblSupplierCode.Text);
                    varSPSCID = Convert.ToInt32(lblschedule.Text);
                }
                if (txtTeller.Text.Trim() == "")
                {
                    epStockHold.SetError(txtTeller, "Please enter teller");
                    txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTeller.ShowAlways = true;
                    tpTeller.Show("Please enter teller", txtTeller, 5000);
                    blnErrorFlag = false;
                }
                if (blnErrorFlag == true)
                {
                    //string varMrp = string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtMrp.Text.Trim())));
                    //varResult = objspservice.udfnStockHold(ViewType,SHID,Convert.ToInt32(cmbConcern.SelectedValue), varPRID, varStockLocationId, varRKID,Convert.ToString(txtMrp.Text), Convert.ToString(txtExpiryDate.Text),Convert.ToString(txtBatchNo.Text),varUTID,Convert.ToInt32(txtQty.Text), varoriginator);

                    DataTable objGrnPO = new DataTable();
                    TRN_StockHold objTRNS_StockHold = new TRN_StockHold();
                    SPDataService objspservice = new SPDataService();
                    objTRNS_StockHold.ViewType = ViewType;
                    objTRNS_StockHold.paraSHID = SHID;
                    objTRNS_StockHold.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNS_StockHold.paraPRID = varPRID;
                    objTRNS_StockHold.paraSLID = varStockLocationId;
                    objTRNS_StockHold.paraRKID = varRKID;
                    objTRNS_StockHold.paraMrp = Convert.ToDecimal(string.Format("{0:G29}", decimal.Parse(txtMrp.Text.Trim())));
                    objTRNS_StockHold.paraExpiryDate = Convert.ToString(txtExpiryDate.Text);
                    objTRNS_StockHold.paraBatchNo = Convert.ToString(txtBatchNo.Text);
                    objTRNS_StockHold.paraReason = Convert.ToInt32(cmbReason.SelectedValue);
                    objTRNS_StockHold.paraSupplierID = varSPID;
                    objTRNS_StockHold.paraScheduleID = varSPSCID;
                    objTRNS_StockHold.paraQty = Convert.ToDecimal(txtQty.Text);
                    objTRNS_StockHold.paraRemarks = Convert.ToString(txtRemark.Text.Trim());
                    objTRNS_StockHold.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRNS_StockHold.paraFlag = 0;
                    objTRNS_StockHold.paraStatus = 96;
                    objTRNS_StockHold.paraParentSHID = varParentSHID;
                    objTRNS_StockHold.paraTeller = txtTeller.Text.Trim();
                    objTRNS_StockHold.paraOriginator = varoriginator;
                    varResult = objspservice.udfnStockHold(objTRNS_StockHold);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varResult.Split('~')[0] == "3")
                    {
                        if (varResult.Split('~')[1] == "1")
                        {
                            MainForm.objCP_Verify = new CP_Verify();
                            MainForm.objCP_Verify.ShowDialog();
                            varUserID = MainForm.objCP_Verify.varUserId;
                            if (MainForm.objCP_Verify.flag == 1)
                            {
                                objspservice = new SPDataService();
                                objTRNS_StockHold.ViewType = ViewType;
                                objTRNS_StockHold.paraSHID = SHID;
                                objTRNS_StockHold.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                                objTRNS_StockHold.paraPRID = varPRID;
                                objTRNS_StockHold.paraSLID = varStockLocationId;
                                objTRNS_StockHold.paraRKID = varRKID;
                                objTRNS_StockHold.paraMrp = Convert.ToDecimal(string.Format("{0:G29}", decimal.Parse(txtMrp.Text.Trim())));
                                objTRNS_StockHold.paraExpiryDate = Convert.ToString(txtExpiryDate.Text);
                                objTRNS_StockHold.paraBatchNo = Convert.ToString(txtBatchNo.Text);
                                //objTRNS_StockHold.paraUTID = varUTID;
                                objTRNS_StockHold.paraBatchNo = Convert.ToString(txtBatchNo.Text);
                                objTRNS_StockHold.paraQty = Convert.ToDecimal(txtQty.Text);
                                objTRNS_StockHold.paraRemarks = Convert.ToString(txtRemark.Text.Trim());
                                objTRNS_StockHold.paraUserID = Convert.ToInt32(varUserID);
                                objTRNS_StockHold.paraFlag = 1;
                                objTRNS_StockHold.paraOriginator = varoriginator;
                                objTRNS_StockHold.paraSupplierID = varSPID;
                                objTRNS_StockHold.paraScheduleID = varSPSCID;
                                objTRNS_StockHold.paraParentSHID = varParentSHID;
                                varResult = objspservice.udfnStockHold(objTRNS_StockHold);
                                objspservice.CloseConnection();
                                string[] varvalue1 = varResult.Split('~');
                                if (varvalue1[0] == "3")
                                {
                                    MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //udfnClear();
                                    MainForm.objINV_StockHold.udfnList();
                                    string varSHID = "0";
                                    if (SHID == 0)
                                    {
                                        varSHID = varvalue1[2];
                                    }
                                    else
                                    {
                                        varSHID = Convert.ToString(SHID);
                                    }
                                    udfnStockHoldPrint(varSHID);
                                    varUpdate = 1;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    //udfnClear();
                                }
                            }
                        }
                        else if (varResult.Split('~')[0] == "4")
                        {
                            MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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
            }
        }
        public void udfnStockHoldPrint(string varSHID)
        {
            try
            {
                DialogResult result1;
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(87);
                objDServ.CloseConnection();
                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_StockHold_Print.rpt");
                    varHeader = "Stock Hold";

                    objBillreport.SetParameterValue("paraSHID", varSHID, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraSHID", varSHID, objBillreport.Subreports[1].Name.ToString());
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[1].Name.ToString());
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[1].Name.ToString());
                    objBillreport.SetParameterValue("paraSHID", varSHID);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);
                    //objValidation.CrySqlConnection(objBillreport);

                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                    MainForm.objReportLoad.Text = varHeader;
                    MainForm.objReportLoad.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.DataSource = null;
                DGV_FilterProduct.Visible = false;
                lvTeller.Visible = false;
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclose()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
                if (varmastertype == 0)
                {
                    MainForm.objCP_BankList.udfnList();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.DataSource = null;
                DGV_FilterProduct.Visible = false;
                lvTeller.Visible = false;
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_City_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void CP_City_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varUpdate == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
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
                DGV_FilterProduct.DataSource = null;
                DGV_FilterProduct.Visible = false;
                lvTeller.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductNamePICode.Focus();
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

        private void TxtProductNamePICode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    txtStockLoc.Text = "";
                    txtRack.Text = "";
                    txtMrp.Text = "";
                    txtExpiryDate.Text = "";
                    txtBatchNo.Text = "";
                    txtStockQty.Text = "";
                    txtQty.Text = "";
                    lblUnit.Text = "";
                    DGV_FilterProduct.BringToFront();
                    //lvproduct.Items.Clear();
                    //if (VarSearchFlag == true)
                    //{
                    //    txtProductNamePICode.CharacterCasing = CharacterCasing.Upper;
                    //}
                    //else
                    //{
                    //    txtProductNamePICode.CharacterCasing = CharacterCasing.Normal;
                    //}
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductNamePICode.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        var ViewType = 42;
                        objMR_Product.paraViewType = ViewType;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        if (VarSearchFlag == false)
                        {
                            objMR_Product.paraProductName = txtProductNamePICode.Text.Trim();
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraPicode = txtProductNamePICode.Text.Trim();
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);

                        }
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    DGV_FilterProduct.Columns["SL_EName"].Width = 70;
                                    DGV_FilterProduct.Columns["RK_ShortName"].Width = 70;
                                    DGV_FilterProduct.Columns["STK_MRP"].Width = 70;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].Width = 90;
                                    DGV_FilterProduct.Columns["STK_BatchNo"].Width = 70;
                                    DGV_FilterProduct.Columns["STK_Qty"].Width = 70;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["UTID"].Visible = false;
                                    DGV_FilterProduct.Columns["PRODUCTLIST"].Visible = false;
                                    //DGV_FilterProduct.Columns["ShelfLife"].Visible = false;
                                    DGV_FilterProduct.Columns["STK_SLID"].Visible = false;
                                    DGV_FilterProduct.Columns["STK_RKID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 60;
                                    DGV_FilterProduct.Columns["SL_EName"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["RK_ShortName"].DisplayIndex = 4;
                                    DGV_FilterProduct.Columns["STK_MRP"].DisplayIndex = 5;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].DisplayIndex = 6;
                                    DGV_FilterProduct.Columns["Shelf Life"].DisplayIndex = 7;
                                    DGV_FilterProduct.Columns["MFD Date"].DisplayIndex = 8;
                                    DGV_FilterProduct.Columns["STK_BatchNo"].DisplayIndex = 9;
                                    DGV_FilterProduct.Columns["STK_Qty"].DisplayIndex = 10;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 11;
                                    DGV_FilterProduct.Columns["Retail Rate"].DisplayIndex = 12;
                                    DGV_FilterProduct.Columns["UPP"].DisplayIndex = 13;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterProduct.Columns["RK_ShortName"].HeaderText = "Rack";
                                    DGV_FilterProduct.Columns["STK_MRP"].HeaderText = "MRP";
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].HeaderText = "Expiry Date";
                                    DGV_FilterProduct.Columns["STK_BatchNo"].HeaderText = "Batch No.";
                                    DGV_FilterProduct.Columns["STK_Qty"].HeaderText = "Stock Qty";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["STK_MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["STK_Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["Retail Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["MFD Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Visible = true;
                                    if (VarSearchFlag == false)
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2;
                                    }
                                    else
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 2;
                                    }
                                }
                                else
                                {
                                    DGV_FilterProduct.DataSource = null;
                                    DGV_FilterProduct.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.DataSource = null;
                                DGV_FilterProduct.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.DataSource = null;
                            DGV_FilterProduct.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.DataSource = null;
                        DGV_FilterProduct.Visible = false;
                        //lvproduct.Visible = false;
                        //lvproduct.Items.Clear();
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

            }
        }

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListviewProduct();
                txtQty.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterProduct.Visible = false;
            }
        }

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
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

        private void TxtQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtQty.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                lvTeller.Visible = false;
                varUpDownKey = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtQty.Text) == "")
                {
                    epStockHold.SetError(txtQty, "Please enter Quantity");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter Quantity", txtQty, 5000);
                }
                else
                {
                    epStockHold.Clear();
                    string Qty = objValidation.udfnDecimal((txtQty.Text).Trim(), varDecimal);
                    txtQty.Text = Qty;
                    txtQty.BackColor = Color.White;
                    tpQty.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbReason.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {  
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }

                TextBox textBox = (TextBox)sender;
                if (varDecimal == 0)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                    {
                        e.Handled = true;
                    }
                }
                if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = false;
                }
                if (varDecimal == 0)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
                if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                {
                    e.Handled = true;
                }
                //only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReason_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.DataSource = null;
                DGV_FilterProduct.Visible = false;
                lvTeller.Visible = false;
                cmbReason.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReason_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReason.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReason_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbReason_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTeller.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbReason.SelectedValue) == 242 && varDamage == 0)
                {
                    MainForm.objINV_StockHold_Supplier = new INV_StockHold_Supplier();
                    MainForm.objINV_StockHold_Supplier.varProductCode = varPRID;
                    MainForm.objINV_StockHold_Supplier.ShowDialog();
                    if (varFlag == 1)
                    {
                        lblSupplierName.Visible = true;
                        btnEdit.Visible = true;
                    }
                    else
                    {
                        lblSupplierName.Visible = false;
                        cmbReason.SelectedValue = -1;
                        btnEdit.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTeller_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTeller.Text.Length > 0)
                {
                    lvTeller.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(15, txtTeller.Text.Trim(), 0, "", 1, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["EMP_Name"].ToString(), objDs.Tables[0].Rows[i]["EMPID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvTeller.Columns[1].Width = 0;
                                    lvTeller.Items.Add(objList);
                                }
                                lvTeller.BringToFront();
                                lvTeller.Visible = true;
                            }
                            else
                            {
                                lvTeller.Visible = false;
                            }
                        }
                        else
                        {
                            lvTeller.Visible = false;
                        }
                    }
                    else
                    {
                        lvTeller.Visible = false;
                    }
                }
                else
                {
                    lvTeller.Visible = false;
                    lvTeller.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvTeller_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnTeller();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvTeller_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnTeller();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnTeller()
        {
            try
            {
                if (txtTeller.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvTeller.SelectedItems[0];
                    txtTeller.Text = selectedItem.SubItems[0].Text;
                    //lblVerified1.Text = selectedItem.SubItems[1].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvTeller.Visible = false;
                txtRemark.Focus();
            }
        }

        private void TxtTeller_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.DataSource = null;
                DGV_FilterProduct.Visible = false;
                txtTeller.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTeller_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvTeller.Items.Count == 0 || txtTeller.Text == "")
                    {
                        lvTeller.Visible = false;
                    }
                    else
                    {
                        lvTeller.Focus();
                    }
                    if (lvTeller.Items.Count > 0)
                    {
                        lvTeller.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemark.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTeller_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRemark_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.DataSource = null;
                DGV_FilterProduct.Visible = false;
                lvTeller.Visible = false;
                txtRemark.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemark_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRemark.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && !e.Shift) // Enter without Shift
                {
                    e.SuppressKeyPress = true; // prevent newline
                    btnSave.Focus();
                }
                else if (e.KeyCode == Keys.Enter && e.Shift) // Shift+Enter for newline
                {
                    // allow newline
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbReason.SelectedValue) == 242)
                {
                    MainForm.objINV_StockHold_Supplier = new INV_StockHold_Supplier();
                    MainForm.objINV_StockHold_Supplier.varProductCode = varPRID;
                    MainForm.objINV_StockHold_Supplier.txtSupplier.Text = lblSupplierName.Text;
                    MainForm.objINV_StockHold_Supplier.LV_Supplier.Visible = false;
                    MainForm.objINV_StockHold_Supplier.ShowDialog();
                    if (varFlag == 1)
                    {
                        lblSupplierName.Visible = true;
                        btnEdit.Visible = true;
                    }
                    else
                    {
                        lblSupplierName.Visible = false;
                    }
                }
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
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epStockHold.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epStockHold.Clear();
                    cmbConcern.BackColor = Color.White;
                }
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

                txtProductNamePICode.Text = "";
                txtStockLoc.Text = "";
                txtRack.Text = "";
                txtMrp.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStockQty.Text = "";
                txtQty.Text = "";
                txtRemark.Text = "";
                lblUnit.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductNamePICode_Enter(object sender, EventArgs e)
        {
            try
            {
                lvTeller.Visible = false;
                txtProductNamePICode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductNamePICode_Leave(object sender, EventArgs e)
        {
            try
            {
                epStockHold.Clear();
                txtProductNamePICode.BackColor = Color.White;
                tpProductNamePICode.Active = false;
                /*
                if (Convert.ToString(txtProductNamePICode.Text) == "")
                {
                    epBank.SetError(txtProductNamePICode, "Please enter the product");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductNamePICode.ShowAlways = true;
                    tpProductNamePICode.Show("Please enter the product", txtProductNamePICode, 5000);
                }
                else
                {
                    epBank.Clear();
                    txtProductNamePICode.BackColor = Color.White;
                    tpProductNamePICode.Active = false;
                }
                */
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductNamePICode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    //if (lvproduct.Items.Count == 0 || txtProductNamePICode.Text == "")
                    //{
                    //    txtQty.Focus();
                    //    lvproduct.Visible = false;
                    //}
                    //else
                    //{
                    //    lvproduct.Focus();
                    //}
                    //if (lvproduct.Items.Count > 0)
                    //{
                    //    lvproduct.Items[0].Selected = true;
                    //}
                    DGV_FilterProduct.Focus();
                }
                //if (e.KeyCode == Keys.Enter)
                //{
                //    txtQty.Focus();
                //}
                //if (DGV_FilterProduct.RowCount > 0)
                //{
                //    DGV_FilterProduct.Focus();
                //}

                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        txtProductDEName.Text = "Search by P.I Code (F11)";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        txtProductDEName.Text = "Search by Product Name (F11)";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    txtQty.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterProduct.Focus();
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductNamePICode.Focus();
                    //txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductNamePICode = sender as TextBox;
                        txtProductNamePICode.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductNamePICode.Text != "")
                {
                    varPRID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString());
                    varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                    varUTID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UTID"].Value.ToString());
                    varStockLocationId = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["STK_SLID"].Value.ToString());
                    varRKID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["STK_RKID"].Value.ToString());
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    txtStockLoc.Text = DGV_FilterProduct.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                    txtRack.Text = DGV_FilterProduct.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                    txtMrp.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                    txtExpiryDate.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                    txtBatchNo.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                    txtStockQty.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_Qty"].Value.ToString();
                    lblUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    varDamage = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterProduct.Visible = false;
            }
        }
    }
}
