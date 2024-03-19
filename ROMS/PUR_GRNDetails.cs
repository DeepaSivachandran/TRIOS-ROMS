using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 


namespace ROMS
{
    public partial class PUR_GRNDetails : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpProduct = new ToolTip();
        ToolTip tpconcern = new ToolTip();
        ToolTip tprate = new ToolTip();
        ToolTip tpbatchno = new ToolTip();
        ToolTip tpmonth = new ToolTip();
        ToolTip tpdate = new ToolTip();
        ToolTip tpyear = new ToolTip();
        ToolTip tpInvoiceQty = new ToolTip();
        ToolTip tpExcessQty = new ToolTip();
        ToolTip tpInvoiceNo = new ToolTip();
        ToolTip tpInvoiceAMT = new ToolTip();

        public bool skipValidation = false;
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = ""
            , varorderSaleQty = "", varorderqty = "", addproductid = "", varunitid = "0", varDamage = "0", varReturnDC = "0", pbGRNId = "0", pbSupplierId = "0", dcid = "0",
            varenablefalg = "0", varUserID = "0", varflag = "0", varExpiryDate = "", varTName = "", varexp = "", pbScheduleId = "0", pbPOIdS = "0",
            varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0", varBatchNo = "0", varNewFlag = "0", varErrQty = "0",varTempExpiryDate="0", varExpiryDateAdd = "";
        int grid_flag = 0;
        public int varGrnId = 0, varCloseflag = 0, pbDateflag = 0, varShelflife = 0, expirydateFlag = 0, varErrorFormat = 0, varcount = 0, varErroronGrid = 0,varpono=0, varModifiedFlag = 0, varUpDownKey=0, varDecimal=0;
        public bool VarSearchFlag = true;
        public int PbVerified = 0,ParaSupplierAMT = 0;
        public PUR_GRNDetails()
        {
            InitializeComponent();
        }
        private void PUR_GRNEntry_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtProductName;
                udfnDropdownLoad();
                udfnEditLoad();
                udfnDateSet();
                udfnPODropdownload();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID =61", "MST_DisplayText,MSTID", cmbQtyType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbQtyType.SelectedValue = 202;
                if (chkCompleted.Checked == true)
                {
                    btnVerified.Enabled = false;
                }
                else
                {
                    btnVerified.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPODropdownload()
        {
            try
            { 
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDT = null;
                objDT = objdserv.udfnPOEntry(5, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, "", "", 0, 0, "0", 0, 0, 0, 0, 0, Convert.ToInt32(pbGRNId));
                objdserv.CloseConnection();
                cmbPONo.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbPONo.ValueMember = "poid";
                            cmbPONo.DisplayMember = "PO_No";
                            cmbPONo.DataSource = objDT.Tables[0];
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

        public void udfnDateSet()
        {
            try
            {
                if (pbGRNId != "0")
                { 
                    dpinvoicedate.MinDate = MainForm.pbFYStartDate;
                    dpinvoicedate.MaxDate = MainForm.pbCurrentDate; 
                    //SPDataService objDServ = new SPDataService();
                    //DataSet objd = new DataSet();
                    //objd = objDServ.udfnMaster(4, 6, 0, "", "", 0, "", 0);
                    //if (objd.Tables[1].Rows.Count != 0)
                    //{
                    //    DateTime varmindate = DateTime.ParseExact(Convert.ToString(objd.Tables[1].Rows[0]["MinToday"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //    dpinvoicedate.MaxDate = varmindate;
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDropdownLoad()
        {
            SPDataService objdserv = new SPDataService();
            int varconcerntype = 3;
            DataSet objDT = new DataSet();
            objDT = objdserv.udfnCompanyList(varconcerntype, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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

            DataBind objDataBind = new DataBind();
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (16 ) OR MSTID  IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrderType, "", "MST_DisplayText", "MSTID");
            objDataBind = null;
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

        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errGRNDetails.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpconcern.ShowAlways = true;
                    tpconcern.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    errGRNDetails.Clear();
                    cmbConcern.BackColor = Color.White;
                }
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
                    dpGrnDate.Focus();
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                {
                    string vardate = "", varResult = "";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    DataService objDservice = new DataService();
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,GETDATE(),103)");
                    varResult = objspdservice.udfngetVoucherNo("39", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                    objspdservice.CloseConnection();
                    if (varResult != "")
                    {
                        txtgrnno.Text = varResult;
                    }
                    else
                    {
                        txtgrnno.Text = "";
                    }
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                skipValidation = true;
                udfnclose(sender,e); 
                MainForm.objPUR_GRNDetailsList.PUR_GRNDetailsList_Load(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclose(object sender,EventArgs e)
        {
            try
            {
                if (varModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    { 
                        this.Close();
                    }
                    else
                    { btnSave.Focus(); }
                }
                else
                { 
                    if (varCloseflag == 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            skipValidation = true;
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                    MainForm.objPUR_GRNDetailsList.PUR_GRNDetailsList_Load(sender,e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnVerify1_Click(object sender, EventArgs e)
        {

            try
            {
                udfnverify(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnVerify2_Click(object sender, EventArgs e)
        {
            try
            {
                udfnverify(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnverify(object sender,EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRNVerify = new PUR_GRNVerify();
                MainForm.objPUR_GRNVerify.pbGRNId = pbGRNId;
                if (btnVerify1.Enabled == true)
                {
                    MainForm.objPUR_GRNVerify.varVerifyType = 1;
                }
                else
                {
                    MainForm.objPUR_GRNVerify.varVerifyType = 2;
                }
                MainForm.objPUR_GRNVerify.ShowDialog();
                if (Convert.ToString(MainForm.objPUR_GRNVerify.varUserId) != "")
                { 
                    if (varenablefalg == "1")
                    {
                        btnVerify1.Enabled = false;
                        btnVerify2.Enabled = true;
                        btnDC.Enabled = false;
                        gpAddrow.Enabled = false;
                    }
                    else if (varenablefalg == "2")
                    {
                        btnVerify1.Enabled = false;
                        btnVerify2.Enabled = false;
                    } 
                    varCloseflag = 1;
                    udfnclose(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //SPDataService objdserv = new SPDataService();
                //DataSet objDs = new DataSet();
                //objDs = objdserv.udfnGrnListLoad(4, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0);
                //objdserv.CloseConnection();
                //if (objDs != null)
                //{
                //    if (objDs.Tables.Count != 0)
                //    {
                //        if (objDs.Tables[0].Rows.Count != 0)
                //        {
                //            lblVerified1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["VERIFIED1"]);
                //            lblVerifyDateTime.Text = Convert.ToString(objDs.Tables[0].Rows[0]["VERIFIEDON1"]);
                //        }
                //        if (objDs.Tables[1].Rows.Count != 0)
                //        {
                //            lblVerified2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["VERIFIED2"]);
                //            lblVerifyDateTime2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["VERIFIEDON2"]);
                //        }
                //    }
                //} 
            }
        }

        private void TxtInvoiceamt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceamt.BackColor = Color.White;
                if (Convert.ToDecimal(txtInvoiceamt.Text) >= 25000)
                {
                    if (chkCompleted.Enabled == false)
                    {
                        btnVerify1.Enabled = true;
                    }
                }
                else
                {
                    btnVerify1.Enabled = false;
                    btnVerify2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbOrderType.SelectedValue) == 52) { cmbPONo.Enabled = false; txtProductName.Focus(); }
                else { cmbPONo.Enabled = true; txtProductName.Focus(); }
                //if (Convert.ToInt32(cmbOrderType.SelectedValue) == 53)
                //{

                //    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                //    MainForm.objPUR_GRNOrderType.ShowDialog();
                //}
                //else
                //{
                //    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                //    MainForm.objPUR_GRNOrderType.Close();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                varNewFlag = "0";
                MainForm.objPUR_Product = new PUR_Product();
                MainForm.objPUR_Product.ShowDialog();
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdGrnlist.Rows.Count != 0)
                {
                    string result = "", varPurchaseDC = "0", varSkip = "0", varDC = "0";
                    varflag = "0"; varUserID = "0";
                    DialogResult result1 = DialogResult.Yes;
                    SPDataService objDServ = new SPDataService();
                    DataSet objDs = new DataSet();
                    dcid = "0";
                    for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                    {
                        if (dcid == "0")
                        {
                            dcid = Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                        }
                        else
                        {
                            dcid = dcid + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                        }
                    }
                    //objDs = objDServ.udfnReturnDC(6, Convert.ToInt32(lblSupplierCode.Text),
                    //    Convert.ToInt32(lblschedule.Text), Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, Convert.ToString(dcid));

                    TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                    objTRN_PurchaseReturnDC.paraViewType = 6;
                    objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_PurchaseReturnDC.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    objTRN_PurchaseReturnDC.ParaScheduleID = Convert.ToInt32(lblschedule.Text);
                    objTRN_PurchaseReturnDC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_PurchaseReturnDC.paraDCIDs = Convert.ToString(dcid);
                    objDs = objDServ.udfnReturnDC(objTRN_PurchaseReturnDC);
                    objDServ.CloseConnection();
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        varDC = Convert.ToString(objDs.Tables[0].Rows[0]["ID"]);
                    }
                    //if (varReturnDC != "0" && (chkCompleted.Enabled == true && chkCompleted.Checked == true) && varDC == "1")
                    //{
                    //    string varMessage = objDServ.udfnGetMessages(102);
                    //    objDServ.CloseConnection();
                    //    varSkip = "1";
                    //    result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //}
                    //else
                    //{
                    //    result1 = DialogResult.Yes;
                    //}
                    if (varReturnDC != "0" && (chkCompleted.Enabled == true && chkCompleted.Checked == true))
                    {
                        if (varDC != "0")
                        {
                            string varMessage = objDServ.udfnGetMessages(102);
                            objDServ.CloseConnection();
                            varSkip = "1";
                            result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                    else
                    {
                        result1 = DialogResult.Yes;
                    }
                    if (varErrQty == "1")
                    {
                        SPDataService objDserv = new SPDataService();
                        string varMessage = objDserv.udfnGetMessages(89);
                        objDserv.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result1 = DialogResult.No;
                    }
                    else
                    {
                        result1 = DialogResult.Yes;
                    }
                    if(grdGrnlist.Rows.Count > 0)
                    {
                        varErrorFormat = 0;
                    /*
                    for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                    {
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value) != "0" || Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value) == "")
                        {
                            varTempExpiryDate = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value);
                            string dateString = varTempExpiryDate;
                            if (dateString.Length != 8 && dateString != "")
                            {
                                grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.ForeColor = Color.Black;
                                varErrorFormat = 1;
                            }
                            else
                            {
                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShelflifeenable"].Value) == "1" || dateString != "")
                                {
                                    varExpiryDate = "";

                                    string varTempYear = "0";
                                    object cellValue = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value);
                                    string varExpDate = "";
                                    varExpDate = cellValue.ToString();
                                    string[] DMY = varExpDate.Split('/');
                                    if (DMY.Count() == 3)
                                    {
                                        varTempYear = DMY[2];
                                        if (varTempYear.Length == 2)
                                        {
                                            cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
                                        }
                                    }
                                    varTempExpiryDate = cellValue.ToString();

                                    DataSet objDS = new DataSet();
                                    SPDataService objdServ = new SPDataService();
                                    objDS = objdServ.udfnMaster(8, 0, 0, varTempExpiryDate, "", 0, "", 0);
                                    objdServ.CloseConnection();
                                    if (objDS.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(objDS.Tables[0].Rows[0]["DATE"]) == "0")
                                        {
                                            grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                            grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.ForeColor = Color.Black;
                                            varErrorFormat = 1;
                                        }
                                        else
                                        {
                                            grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                        }
                                    }
                                }
                            }
                        }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value) != "0" || Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value) == "")
                        {
                            string varTempYear = "0";
                            object cellValue = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value);
                            string varExpDate = "";
                            varExpDate = cellValue.ToString();
                            string[] DMY = varExpDate.Split('/');
                            if (DMY.Count() == 3)
                            {
                                varTempYear = DMY[2];
                                if (varTempYear.Length == 2)
                                {
                                    cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
                                }
                            }
                            varTempExpiryDate = cellValue.ToString();
                            SPDataService objDServe = new SPDataService();
                            DataSet objDS = new DataSet();
                            objDS = objDServe.udfnMaster(10, 0, 0, dpGrnDate.Text.Trim(), varTempExpiryDate, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0);
                            objDServe.CloseConnection();
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                                {
                                    varErrorFormat = 1; //error = 1;
                                }
                                else
                                {
                                    int varExpiryDays = 0;
                                    if (objDS.Tables.Count != 0)
                                    {
                                        if (objDS.Tables[1].Rows.Count > 0)
                                        {
                                            varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                        }
                                    }
                                    if (varExpiryDays < 0)
                                    {
                                        varErrorFormat = 1;
                                        grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                        grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                        if (varShelflife == 1)
                                        {
                                            if (objDS.Tables.Count > 1)
                                            {
                                                if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                                {
                                                    pbDateflag = 1;
                                                    grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                                    grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.ForeColor = Color.Black;
                                                }
                                                else
                                                {
                                                    grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //if (error == 1)
                        //{
                        //    string varMessage = objDServ.udfnGetMessages(94);
                        //    objDServ.CloseConnection();
                        //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                    }
                    */
                    }
                    if (varErrorFormat==1)
                    {
                        string varMessage = objDServ.udfnGetMessages(94);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result1 = DialogResult.No;
                    }
                    else
                    {
                        result1 = DialogResult.Yes;
                    }

                    if (txtInvoiceno.Text.Trim() == "")
                    {
                        errGRNDetails.SetError(txtInvoiceno, "Please enter invoiceno.");
                        txtInvoiceno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpInvoiceNo.ShowAlways = true;
                        tpInvoiceNo.Show("Please enter invoiceno.", txtInvoiceno, 5000);
                        result1 = DialogResult.No;
                        varErrorFormat = 1;
                    }
                    if (chkCompleted.Checked == true)
                    {
                        if (lblVerifiedBy1.Text == "" && lblVerifiedBy2.Text == "")
                        {
                            MessageBox.Show("Verification details are mandatory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result1 = DialogResult.No;
                            varErrorFormat = 1;
                        }
                    }
                    if (txtInvoiceamt.Text.Trim() == "")
                    {
                        errGRNDetails.SetError(txtInvoiceamt, "Please enter invoice amount.");
                        txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpInvoiceAMT.ShowAlways = true;
                        tpInvoiceAMT.Show("Please enter invoice amount.", txtInvoiceamt, 5000);
                        result1 = DialogResult.No;
                        varErrorFormat = 1;
                    }
                    if (result1 == DialogResult.Yes)
                    {
                        errGRNDetails.Clear();
                        for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                        {
                            if (varPurchaseDC == "0")
                            {
                                varPurchaseDC = Convert.ToString(grdReurnDC.Rows[i].Cells["ID"].Value);
                            }
                            else
                            {
                                varPurchaseDC = varPurchaseDC + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["ID"].Value);
                            }
                        }
                        DataTable objGRNProd = new DataTable();
                        objGRNProd.TableName = "TRN_GRN_Products";
                        objGRNProd.Columns.Add("GRNPR_GRNID", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_PRID", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_UTID", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_QTY", typeof(float));
                        objGRNProd.Columns.Add("GRNPR_ExcessQty", typeof(float));
                        objGRNProd.Columns.Add("GRNPR_MRP", typeof(float));
                        objGRNProd.Columns.Add("GRNPR_EXP_DD", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_EXP_MM", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_EXP_YY", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_BatchNo", typeof(string));
                        objGRNProd.Columns.Add("GRNPR_ShelfLifeValue", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_ShelfLifeType", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_POID", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_ShelfLife_Per", typeof(float));
                        objGRNProd.Columns.Add("GRNPR_Expirydate", typeof(string));
                        objGRNProd.Columns.Add("GRNPR_PRName", typeof(string));
                        objGRNProd.Columns.Add("GRNPR_ShelfLifeStatus", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_BatchNoStatus", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_BatchNoGenration", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_PRFlag", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_ShelfLife_Flag", typeof(int));
                        objGRNProd.Columns.Add("GRNPR_POQty", typeof(float)); 
                        objGRNProd = udfnobjGRNProd();
                        if (varcount == 0)
                        {
                            SPDataService objspdservice = new SPDataService();
                            string result2 = "";
                            TRN_GRN objTRNS_GRN1 = new TRN_GRN();
                            objTRNS_GRN1.ParaEditFlag = 0;
                            objTRNS_GRN1.ViewType = 3;
                            objTRNS_GRN1.ParaGRNID = Convert.ToInt32(pbGRNId);
                            objTRNS_GRN1.paraGRNDate = dpGrnDate.Text;
                            objTRNS_GRN1.paraSupplierID =Convert.ToInt32(lblSupplierCode.Text);
                            objTRNS_GRN1.paraScheduleID =Convert.ToInt32(lblschedule.Text);
                            objTRNS_GRN1.paraID = ParaSupplierAMT;
                            objTRNS_GRN1.paraSaveFlag = 1;
                            objTRNS_GRN1.paraGRNProd = objGRNProd;
                            result2 = objspdservice.udfnGRNEntry(objTRNS_GRN1);
                            objspdservice.CloseConnection();
                            string[] varvalue1 = result2.Split('~');
                            if (varvalue1[1] == "1")
                            {
                                grdGrnlist.ClearSelection();
                                //MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                                //MainForm.objPUR_GRNApprovalVerify.varTrnType = 1;
                                //MainForm.objPUR_GRNApprovalVerify.ShowDialog();
                                //varUserID = MainForm.objPUR_GRNApprovalVerify.varUserId;
                                //if (MainForm.objPUR_GRNApprovalVerify.flag == 1)
                                //{
                                    varGrnId = Convert.ToInt32(pbGRNId);
                                    varUserID = MainForm.pbUserID;
                                    TRN_GRN objTRNS_GRN = new TRN_GRN();
                                    objTRNS_GRN.ViewType = 3;
                                    objTRNS_GRN.ParaEditFlag = 1;
                                    objTRNS_GRN.ParaGRNID = varGrnId;
                                    objTRNS_GRN.paraINVDate = dpinvoicedate.Text;
                                    objTRNS_GRN.paraINVNo = txtInvoiceno.Text;
                                    objTRNS_GRN.ParaInvAmt = Convert.ToDecimal(txtInvoiceamt.Text);
                                    objTRNS_GRN.ParaPurchaseDC = varPurchaseDC;
                                    objTRNS_GRN.paraUserID = Convert.ToInt32(varUserID);
                                    objTRNS_GRN.paraRemarks = txtRemark.Text;
                                    objTRNS_GRN.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                                    objTRNS_GRN.paraScheduleID = Convert.ToInt32(lblschedule.Text);
                                    objTRNS_GRN.paraID = ParaSupplierAMT;
                                    objTRNS_GRN.paraSkipped = varSkip;
                                    objTRNS_GRN.paraGRNProd = objGRNProd;
                                    objTRNS_GRN.paraGRNDate = dpGrnDate.Text;
                                    if (chkCompleted.Enabled == true)
                                    {
                                        objTRNS_GRN.paraflag = 1;
                                    }
                                    else
                                    {
                                        objTRNS_GRN.paraflag = 0;
                                    }
                                    if (chkCompleted.Enabled == true)
                                    {
                                        if (chkCompleted.Checked == true)
                                        {
                                            objTRNS_GRN.paraStatus = 23;
                                            if (varSkip == "1")
                                            {
                                                objTRNS_GRN.paraOriginator = "GRN DC Skipped";
                                            }
                                            else
                                            {
                                                objTRNS_GRN.paraOriginator = "GRN Detail Complete";
                                            }
                                        }
                                        else
                                        {
                                            objTRNS_GRN.paraStatus = 17;
                                            objTRNS_GRN.paraOriginator = "GRN Detail Update";
                                        }
                                    }
                                    else
                                    {
                                        if (btnVerify2.Enabled == true)
                                        {
                                            //objTRNS_GRN.paraStatus = 24;
                                        }
                                        else
                                        {
                                            objTRNS_GRN.paraStatus = 23;
                                        }
                                    }
                                   K: objTRNS_GRN.paraSaveFlag = 0; 
                                    result = objspdservice.udfnGRNEntry(objTRNS_GRN);
                                    objspdservice.CloseConnection();
                                    string[] varvalue = result.Split('~');
                                if (result.Split('~')[1] == "1")
                                {
                                    int passkeyflag = 0;
                                    if (chkCompleted.Checked==true)
                                    {
                                        MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                                        MainForm.objPUR_GRNApprovalVerify.varTrnType = 1;
                                        MainForm.objPUR_GRNApprovalVerify.ShowDialog();
                                        varUserID = MainForm.objPUR_GRNApprovalVerify.varUserId;
                                        passkeyflag = MainForm.objPUR_GRNApprovalVerify.flag;
                                    }
                                    else
                                    {
                                        passkeyflag = 1;
                                    }
                                    if (passkeyflag == 1)
                                    {
                                        objTRNS_GRN.paraSaveFlag = 1;
                                        objTRNS_GRN.paraUserID = Convert.ToInt32(varUserID);
                                        result = objspdservice.udfnGRNEntry(objTRNS_GRN);
                                        objspdservice.CloseConnection();
                                        varvalue = result.Split('~');
                                        if (varvalue[0] == "3")
                                        {
                                            varModifiedFlag = 0;
                                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.ActiveControl = txtSupplier;
                                            MainForm.objPUR_GRNDetailsList.udfnListLoad();
                                            varCloseflag = 1;
                                            udfnclose(sender, e);
                                        }
                                        else
                                        {
                                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                else
                                {
                                    if (varvalue[0] == "5")
                                    {
                                        DialogResult dialogResult = MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            ParaSupplierAMT = 1;
                                            objTRNS_GRN.paraSaveFlag = 1;
                                            objTRNS_GRN.paraID = ParaSupplierAMT;
                                            goto K;
                                        }
                                        else
                                        {
                                            txtInvoiceamt.Focus();
                                        }
                                    }
                                    else
                                    {
                                        if (varvalue[0] == "3")
                                        {
                                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                                            MainForm.objPUR_GRNDetailsList.udfnListLoad();
                                            varCloseflag = 1;
                                            varModifiedFlag = 0;
                                            udfnclose(sender, e);
                                        }
                                        else
                                        {
                                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                               // }
                            }
                            else
                            {
                                grdGrnlist.ClearSelection();
                                if (varvalue1[0] == "5")
                                {
                                    //string result3 = varvalue1[1];
                                    //string[] message = result3.Split('@');
                                    MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    string varProductID = "", Expirydate = "";
                                    for (int j = 0; j < grdGrnlist.RowCount; j++)
                                    {
                                        string[] varFirstList = varvalue1[2].Split('|');
                                        for (int i = 0; i < varFirstList.Length; i++)
                                        {
                                            string[] varSecondList = varFirstList[i].Split(',');
                                            varProductID = varSecondList[0];
                                            Expirydate = varSecondList[1];

                                            string varTempYear = "0";
                                            object cellValue = Convert.ToString(grdGrnlist.Rows[j].Cells["clmexpirydate"].Value);
                                            string varExpiryDate = "";
                                            varExpiryDate = cellValue.ToString();
                                            string[] DMY = varExpiryDate.Split('/');
                                            if (DMY.Count() == 3)
                                            {
                                                varTempYear = DMY[2];
                                                if (varTempYear.Length == 2)
                                                {
                                                    cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
                                                }
                                            }
                                            varTempExpiryDate = cellValue.ToString();
                                            if (Convert.ToString(grdGrnlist.Rows[j].Cells["clmProid"].Value) == varProductID && varTempExpiryDate == Expirydate)
                                            {
                                                //if (message[1] == "1" || message[1]=="2" || message[1]=="3")
                                                //{
                                                    grdGrnlist.Rows[j].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                                                //}
                                                //if (message[1] == "4")
                                                //{
                                                //    grdGrnlist.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                                //}
                                            }
                                            else
                                            {
                                                /*
                                                //if (message[1] == "1" || message[1] == "2" || message[1] == "3")
                                                //{
                                                    grdGrnlist.Rows[j].DefaultCellStyle.BackColor = Color.White;
                                                    grdGrnlist.Rows[j].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                                    grdGrnlist.Rows[j].Cells["clmInvoiceQty"].Style.BackColor = Color.PaleGreen;
                                                    grdGrnlist.Rows[j].Cells["clmExcessQty"].Style.BackColor = Color.PaleGreen;
                                                    grdGrnlist.Rows[j].Cells["clmmrp"].Style.BackColor = Color.PaleGreen;
                                                //}
                                                */
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (varErrorFormat == 0)
                        {
                            udfnDcAdd();
                        }
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
        public DataTable udfnobjGRNProd()
        {
            varcount = 0;
            DataTable objGRNProd = new DataTable();
            try
            {
                objGRNProd.TableName = "TRN_GRN_Products";
                objGRNProd.Columns.Add("GRNPR_GRNID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_PRID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_UTID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_QTY", typeof(float));
                objGRNProd.Columns.Add("GRNPR_ExcessQty", typeof(float));
                objGRNProd.Columns.Add("GRNPR_MRP", typeof(float));
                objGRNProd.Columns.Add("GRNPR_EXP_DD", typeof(int));
                objGRNProd.Columns.Add("GRNPR_EXP_MM", typeof(int));
                objGRNProd.Columns.Add("GRNPR_EXP_YY", typeof(int));
                objGRNProd.Columns.Add("GRNPR_BatchNo", typeof(string));
                objGRNProd.Columns.Add("GRNPR_ShelfLifeValue", typeof(int));
                objGRNProd.Columns.Add("GRNPR_ShelfLifeType", typeof(int));
                objGRNProd.Columns.Add("GRNPR_POID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_ShelfLife_Per", typeof(float));
                objGRNProd.Columns.Add("GRNPR_Expirydate", typeof(string));
                objGRNProd.Columns.Add("GRNPR_PRName", typeof(string));
                objGRNProd.Columns.Add("GRNPR_ShelfLifeStatus", typeof(int));
                objGRNProd.Columns.Add("GRNPR_BatchNoStatus", typeof(int));
                objGRNProd.Columns.Add("GRNPR_BatchNoGenration", typeof(int));
                objGRNProd.Columns.Add("GRNPR_PRFlag", typeof(int));
                objGRNProd.Columns.Add("GRNPR_ShelfLife_Flag", typeof(int));
                objGRNProd.Columns.Add("GRNPR_POQty", typeof(float));
                if (chkCompleted.Enabled == true)
                {
                    for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                    {
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmShelflifeenable"].Value) == "1")
                        {
                            if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value) == "")
                            {
                                varcount++;
                                grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.LightPink;
                            }
                            else
                            {
                                grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                            }

                        }
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchgeneration"].Value) == "75")
                        {
                            if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value) == "")
                            {
                                varcount++;
                                grdGrnlist.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightPink;
                            }
                            else
                            {
                                grdGrnlist.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.PaleGreen;
                            }
                        }
                        else
                        {
                            if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchgeneration"].Value) == "74" || Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchgeneration"].Value) == "-1")
                            {
                                grdGrnlist.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                            }
                            else
                            {
                                grdGrnlist.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.PaleGreen;
                            }
                        }
                        decimal varMRP = 0;
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmmrp"].Value) != "")
                        {
                            varMRP = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmmrp"].Value);
                        }
                        decimal varPendingQty = 0;
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmInvoiceQty"].Value) != "")
                        {
                            varPendingQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmInvoiceQty"].Value);
                        }
                        decimal varExcessQty = 0;
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmExcessQty"].Value) != "")
                        {
                            varExcessQty = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmExcessQty"].Value);
                        }
                        decimal varShelfPer = 0;
                        int Shelflifevalue = 0, ProShelflife = 0, ProFlag, POno = 0;decimal PoQty = 0;
                        string[] varShelflifevaluesplit = Convert.ToString(grdGrnlist.Rows[i].Cells["clmactuallife"].Value).Split(' ');
                        string[] varShelflifeper = Convert.ToString(grdGrnlist.Rows[i].Cells["clmshelfper"].Value).Split(' ');
                        string[] varProShelfLife = Convert.ToString(grdGrnlist.Rows[i].Cells["clmshelflife"].Value).Split(' ');

                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmPOid"].Value) == "")
                        {
                            POno = 0;
                        }
                        else { POno = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmPOid"].Value); }

                        if (Convert.ToString(varProShelfLife[0]) != "")
                        {
                            ProShelflife = Convert.ToInt32(varProShelfLife[0]);
                        }
                        else { ProShelflife = 0; }

                        if (Convert.ToString(varShelflifevaluesplit[0]) != "")
                        {
                            Shelflifevalue = Convert.ToInt32(varShelflifevaluesplit[0]);
                        }
                        else { Shelflifevalue = 0; }

                        if (Convert.ToString(varShelflifeper[0]) != "")
                        {
                            varShelfPer = Convert.ToDecimal(varShelflifeper[0]);
                        }
                        else { varShelfPer = 0; }
                        // if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmprflag"].Value) == "")
                        //{
                        ProFlag = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmprflag"].Value);
                        //}
                        //else { ProFlag = 1; } 
                        if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmPOQty"].Value) == "")
                        {
                            PoQty = 0;
                        }
                        varTempExpiryDate = "0";
                        string varTempYear = "0";
                        object cellValue = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value);
                        string varExpiryDate = "";
                        varExpiryDate = cellValue.ToString();
                        string[] DMY = varExpiryDate.Split('/');
                        if (DMY.Count() == 3)
                        {
                            varTempYear = DMY[2];
                            if (varTempYear.Length == 2)
                            {
                                cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
                            }
                            else
                            {
                                cellValue = DMY[0] + "/" + DMY[1] + "/" + varTempYear;
                            }
                        }
                        //varTempDay = DMY[0];
                        //varTempMonth = DMY[1];
                        varTempExpiryDate = cellValue.ToString();

                        DataService objDser = new DataService();
                        objGRNProd.Rows.Add(Convert.ToInt32(pbGRNId), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmProid"].Value),
                        Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmUtid"].Value), varPendingQty,varExcessQty ,varMRP,
                         0, 0, 0, Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value),
                         ProShelflife, 0, POno
                        , varShelfPer, varTempExpiryDate
                        , Convert.ToString(grdGrnlist.Rows[i].Cells["clmtam"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmShelflifeenable"].Value)
                        , Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmBatchenable"].Value), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmBatchgeneration"].Value)
                        , ProFlag, Shelflifevalue, PoQty);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return objGRNProd;
        }
        private void ChkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCompleted.Checked) { btnSave.Text = "Update"; } else { btnSave.Text = "Update as Draft"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void DpGrnDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpGrnDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void DpGrnDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpGrnDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void DpGrnDate_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrderType.Focus();
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

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 15;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.BringToFront();
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
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

        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
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
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    udfnsupplierLoad();
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    cmbOrderType.Focus();
                }
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

        private void CmbOrderType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbOrderType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpinvoicedate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txtmrprate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmrprate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtmrprate.Text.Trim() == "")
                {
                    txtmrprate.Text = "0";
                }
                txtmrprate.BackColor = Color.White;
                decimal varMRP = Math.Round(Convert.ToDecimal(txtmrprate.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                string mrp = string.Format("{0:0.00}", varMRP);
                string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                txtmrprate.Text = mrp;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmrprate_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtProductName.Text == "")
                {
                    lblProductcode.Text = "0";
                    txtmrprate.Text = "";
                    txtDate.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtBatchno.Text = "";
                } 
                txtmrprate.BackColor = Color.LemonChiffon;
                lvproduct.Visible = false;
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Month_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtYear.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Month_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Month_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMonth.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Year_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Year_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Year_Enter(object sender, EventArgs e)
        {
            try
            {
                txtYear.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBatchno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBatchno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchno.Text.Trim() == "")
                    {
                        txtBatchno.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtBatchno, "Please enter BatchNo.");
                        tpbatchno.ShowAlways = true;
                        tpbatchno.Show("Please enter BatchNo.", txtBatchno, 5000);
                    }
                    else
                    {
                        txtBatchno.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
                else
                {
                    txtBatchno.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBatchno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkCompleted_Leave(object sender, EventArgs e)
        {
            try
            {
                chkCompleted.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkCompleted_Enter(object sender, EventArgs e)
        {
            try
            {
                chkCompleted.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSave_Leave(object sender, EventArgs e)
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


        private void BtnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClose_Leave(object sender, EventArgs e)
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

        private void BtnDC_Click(object sender, EventArgs e)
        {
            try
            {
                udfnDcAdd();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        public void udfnDcAdd()
        {
            try
            {
                dcid = "0";
                for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                {
                    if (dcid == "0")
                    {
                        dcid = Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                    }
                    else
                    {
                        dcid = dcid + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                    }
                }
                MainForm.objINV_GRNPODamaged = new INV_GRNPODamaged();
                MainForm.objINV_GRNPODamaged.varMasterType = "1";
                MainForm.objINV_GRNPODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void Txtmrprate_KeyPress(object sender, KeyPressEventArgs e)
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void TxtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void Month_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    txtBatchno.BackColor = SystemColors.Control;
                    string varProductsCodes = "0";
                    //lvproduct.Items.Clear();
                    varNewFlag = "0";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    int GRNID = 0;
                    if (txtProductName.Text.Length > 0)
                    {
                        if (Convert.ToInt32(cmbPONo.SelectedValue) == 0)
                        {
                            GRNID = 0;
                        }
                        else { GRNID = Convert.ToInt32(pbGRNId); }
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 29;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.ParaScheduleid = Convert.ToString(lblschedule.Text);
                        objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                        objMR_Product.paraId = Convert.ToInt32(cmbPONo.SelectedValue);
                        objMR_Product.ParaGRNID = GRNID;
                        objMR_Product.ParaProductsCode = varProductsCodes;
                        //ParaGRNID

                        if (VarSearchFlag == true)
                        {
                            objMR_Product.paraPicode = txtProductName.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraProductName = txtProductName.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        objspdservice.CloseConnection();

                        //lvproduct.BeginUpdate();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {   /*
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(),objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(),
                                        objDs.Tables[0].Rows[i]["PR_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PR_BatchNoGeneration"].ToString(),objDs.Tables[0].Rows[i]["PR_RMForProduction"].ToString(),objDs.Tables[0].Rows[i]["PR_PRCTID"].ToString(),objDs.Tables[0].Rows[i]["PR_ShelfLife"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvproduct.Items.Add(objList);
                                    }
                                    lvproduct.Visible = true;
                                    lvproduct.BringToFront();
                                    lvproduct.Columns[0].Width = 100;
                                    lvproduct.Columns[3].Width = 50;
                                    if (VarSearchFlag == true)
                                    {
                                        lvproduct.Columns[1].Width = 320;
                                        lvproduct.Columns[2].Width = 0;
                                    }
                                    else
                                    {
                                        lvproduct.Columns[1].Width = 0;
                                        lvproduct.Columns[2].Width = 320;
                                    }
                                    lvproduct.Columns[3].Width = 0;
                                    lvproduct.Columns[4].Width = 0;
                                    lvproduct.Columns[5].Width = 0;
                                    lvproduct.Columns[6].Width = 0;
                                    lvproduct.Columns[7].Width = 0;
                                    lvproduct.Columns[8].Width = 0;
                                    lvproduct.Columns[9].Width = 0;
                                    lvproduct.EndUpdate();
                                    */

                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.BringToFront();
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Visible = true;
                                    DGV_FilterProduct.Columns["PR_BatchNo"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_BatchNoGeneration"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_RMForProduction"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PRCTID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_ShelfLife"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["pr_retailrate"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 60;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                    //lvProduct.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                                //lvProduct.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                            //lvProduct.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                        //lvProduct.Visible = false;
                        //lvProduct.Items.Clear();
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

        private void TxtInvoiceamt_KeyPress(object sender, KeyPressEventArgs e)
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                pbDateflag = 0;
                udfnAddProductsgrid(); 
                txtTotalpro.Text = Convert.ToString(grdGrnlist.Rows.Count);
                ((DataGridViewTextBoxColumn)grdGrnlist.Columns["clmInvoiceQty"]).MaxInputLength = 8;
                ((DataGridViewTextBoxColumn)grdGrnlist.Columns["clmExcessQty"]).MaxInputLength = 8;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        private void GrdGrnlist_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {   /*
                varErrorFormat = 0;
                if (skipValidation == false)
                {
                    if (grdGrnlist.Columns[e.ColumnIndex].Name == "clmexpirydate")
                    {
                        if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmexpirydate"].Value) != "")
                        {
                            string dateString = varTempExpiryDate;
                            if (dateString.Length != 10 && dateString != "")
                            {
                                varErrorFormat = 1;
                                MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                e.Cancel = true;
                            }
                            else
                            {
                                if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmShelflifeenable"].Value) == "1" || dateString != "")
                                {
                                    varExpiryDate = "";
                                    DataSet objDS = new DataSet();
                                    SPDataService objDServ = new SPDataService();
                                    objDS = objDServ.udfnMaster(8, 0, 0, dateString, "", 0, "", 0);
                                    objDServ.CloseConnection();
                                    if (objDS.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(objDS.Tables[0].Rows[0]["DATE"]) == "0")
                                        {
                                            varErrorFormat = 1;
                                            MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            e.Cancel = true;
                                        }
                                        else
                                        {
                                            varExpiryDate = e.FormattedValue.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                */
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDate.Text.Length == 2)
                {
                    txtMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMonth.Text.Length == 2)
                {
                    txtYear.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListviewProduct();
                cmbQtyType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewProduct();
                                    cmbQtyType.Focus();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbQtyType.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceQty.Text.Trim() == "")
                {
                    errGRNDetails.SetError(txtInvoiceQty, "Please enter quentity");
                    txtInvoiceQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoiceQty.ShowAlways = true;
                    tpInvoiceQty.Show("Please enter quentity", txtInvoiceQty, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtInvoiceQty.Text).Trim(), varDecimal);
                    if(txtInvoiceQty.Text.Trim() == "0" || txtInvoiceQty.Text.Trim() == "00" || txtInvoiceQty.Text.Trim() == "000")
                    {
                        txtInvoiceQty.Text = "0" + Qty;
                    }
                    else
                    {
                        txtInvoiceQty.Text = Qty;
                    }
                    errGRNDetails.Clear();
                    txtInvoiceQty.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceQty_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                txtInvoiceQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnVerified_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_GRN_Level_Verified = new PUR_GRN_Level_Verified();
                MainForm.objPUR_GRN_Level_Verified.pbGRNId = pbGRNId;
                MainForm.objPUR_GRN_Level_Verified.ShowDialog();
                btnSave.Focus();
                if (PbVerified ==1)
                {
                    udfnVerifiedBy();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbQtyType_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                cmbQtyType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbQtyType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtInvoiceQty.Enabled)
                    {
                        txtInvoiceQty.Focus();
                    }
                    else
                    {
                        txtmrprate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbQtyType_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbQtyType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbQtyType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbQtyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbQtyType.SelectedValue) == 202)
                {
                    lblQty.Text = "";
                    txtInvoiceQty.Enabled = false;
                    txtInvoiceQty.Text = "";
                }
                else
                {
                    lblQty.Text = cmbQtyType.Text + " Qty";
                    txtInvoiceQty.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVerifiedBy()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objdserv.udfnGrnListLoad(8, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0, 0, "0", "");
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            lblVerifiedBy1.Visible = true;
                            lblVerifiedDate1.Visible = true;
                            lblVerifiedBy1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["EMP_Name"]);
                            lblVerifiedDate1.Text = " @ " + Convert.ToString(objDs.Tables[0].Rows[0]["GRN_VerifiedOn1"]);
                        }
                    }
                    else
                    {
                        lblVerifiedBy1.Visible = true;
                        lblVerifiedDate1.Visible = true;
                        lblVerifiedBy1.Text = "";
                        lblVerifiedDate1.Text = "";
                    }
                    if (objDs.Tables[1].Rows.Count != 0)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            lblVerifiedBy2.Visible = true;
                            lblVerifiedDate2.Visible = true;
                            lblVerifiedBy2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["EMP_Name"]);
                            lblVerifiedDate2.Text = " @ " + Convert.ToString(objDs.Tables[1].Rows[0]["GRN_VerifiedOn2"]);
                        }
                    }
                    else
                    {
                        lblVerifiedBy2.Visible = true;
                        lblVerifiedDate2.Visible = true;
                        lblVerifiedBy2.Text = "";
                        lblVerifiedDate2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtInvoiceQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    txtmrprate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtInvoiceQty_KeyPress(object sender, KeyPressEventArgs e)
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
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
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
        private void CmbPONo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbPONo.SelectedValue) == 0)
                {
                    BtnNew.Enabled = true;
                }
                else
                {
                    BtnNew.Enabled = false;
                }
                if (Convert.ToInt32(cmbPONo.SelectedValue) != varpono)
                {
                    errGRNDetails.Clear(); 
                    cmbPONo.BackColor = Color.White;
                    txtProductName.Text = "";
                    txtmrprate.Text = "";
                    txtDate.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtBatchno.Text = "";
                    txtProductName.BackColor = Color.White;
                    txtmrprate.BackColor = Color.White;
                    txtDate.BackColor = Color.White;
                    txtMonth.BackColor = Color.White;
                    txtYear.BackColor = Color.White;
                    txtBatchno.BackColor = Color.White;
                } 
                varpono = Convert.ToInt32(cmbPONo.SelectedValue);

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdPODetails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPODetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmpono":
                            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                            {
                                string cellPOValue = Convert.ToString(grdPODetails.Rows[e.RowIndex].Cells["clmpendpoid"].Value);
                                MainForm.objPUR_POProducts = new PUR_POProducts();
                                MainForm.objPUR_POProducts.pbPoid = cellPOValue;
                                MainForm.objPUR_POProducts.pbSupplierCode = lblSupplierCode.Text;
                                MainForm.objPUR_POProducts.pbScheduleCode = lblschedule.Text;
                                MainForm.objPUR_POProducts.ShowDialog();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdReurnDC_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdReurnDC.Columns[e.ColumnIndex].Name)
                    {
                        case "InvoiceNo":
                            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                            {
                                string cellPOValue = Convert.ToString(grdReurnDC.Rows[e.RowIndex].Cells["ID"].Value);
                                MainForm.objPUR_PurchaseOrderDamage = new PUR_PurchaseOrderDamage();
                                MainForm.objPUR_PurchaseOrderDamage.varMasterType = "3";
                                MainForm.objPUR_PurchaseOrderDamage.varDcCode = Convert.ToString(cellPOValue);
                                MainForm.objPUR_PurchaseOrderDamage.ShowDialog();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void GrdGrnlist_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmBatchno" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmmrp" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceQty" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmExcessQty")
                {
                    //e.Control.KeyPress -= udfnHandleKeyPress;
                    //e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceQty" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmExcessQty")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceQty" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmExcessQty")
                {
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmmrp")
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
                    TextBox vartb = sender as TextBox;
                    //if (e.KeyChar == '.' && vartb.Text.Contains('.'))
                    //{
                    //    e.Handled = true;
                    //}
                    if (vartb.Text.Length >= 7 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmBatchno")
                {
                    TextBox vartb = sender as TextBox;
                    if (vartb.Text.Length >= 10 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate")
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
                    {
                        e.Handled = true;  // Disallow the character
                    }
                    TextBox vartb = sender as TextBox;
                    if (vartb.Text.Length >= 8 && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceQty" || grdGrnlist.CurrentCell.OwningColumn.Name == "clmExcessQty")
                {
                    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    //{
                    //    e.Handled = true;  // Disallow the character
                    //}
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
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdGrnlist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                {
                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchenable"].Value) == "72" && Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchgeneration"].Value) == "74")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchenable"].Value) == "73")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.PaleGreen;
                        cell.Style.ForeColor = Color.Black;
                    }

                    string[] varShelflifevalue = Convert.ToString(grdGrnlist.Rows[i].Cells["clmshelfper"].Value).Split(' ');
                    if (varShelflifevalue[0] != "")
                    {
                        if (Convert.ToDecimal(varShelflifevalue[0]) < 25)
                        {
                            DataGridView dataGridView = grdGrnlist;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.Red;
                            cell.Style.ForeColor = Color.White;
                        }
                        else if (Convert.ToDecimal(varShelflifevalue[0]) < 50)
                        {
                            DataGridView dataGridView = grdGrnlist;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.Orange;
                            cell.Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            DataGridView dataGridView = grdGrnlist;
                            DataGridViewCell cell = dataGridView.Rows[i].Cells["clmactuallife"];
                            cell.Style.BackColor = Color.White;
                            cell.Style.ForeColor = Color.Black;
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
        private void TxtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text.Length == 2)
                {
                    if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtInvoiceno_Leave(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceno.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtInvoiceno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceamt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdGrnlist_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string varshelflife = "";
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                int varCellprodid = 0;
                if (grdGrnlist.Columns[e.ColumnIndex].Name == "clmexpirydate")
                {
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmexpirydate"].Value) != "")
                    {
                        varCellprodid = Convert.ToInt32(grdGrnlist.Rows[e.RowIndex].Cells["clmProid"].Value);
                        if (rowIndex >= 0 && columnIndex >= 0)
                        {
                            string varTempYear = "0";
                            object cellValue = grdGrnlist.Rows[rowIndex].Cells[columnIndex].Value;
                            string varExpiryDate = "";
                            varExpiryDate = cellValue.ToString();
                            string[] DMY = varExpiryDate.Split('/');
                            if(DMY.Count()==3)
                            {
                                varTempYear = DMY[2];
                                if (varTempYear.Length == 2)
                                {
                                    cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
                                }
                            }
                            //varTempDay = DMY[0];
                            //varTempMonth = DMY[1];
                            varTempExpiryDate = cellValue.ToString();
                            if (cellValue != null && Convert.ToString(cellValue) != "")
                            {
                                varshelflife = cellValue.ToString();
                                if (varshelflife != "" || varshelflife != null)
                                    objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, dpGrnDate.Text, varCellprodid, 0, "0", "");
                                objdserv.CloseConnection();
                                if (objDs != null)
                                {
                                    if (objDs.Tables[0].Rows.Count != 0)
                                    {
                                        if (objDs.Tables[0].Rows.Count > 0)
                                        {
                                            grdGrnlist.Rows[rowIndex].Cells["clmshelfper"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
                                        }
                                    }
                                        if (objDs.Tables[1].Rows.Count > 0)
                                        {
                                            grdGrnlist.Rows[rowIndex].Cells["clmactuallife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
                                        }

                                    string[] varShelflifevalue = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]).Split(' ');
                                    if (varShelflifevalue[0] != "")
                                    {
                                        if (Convert.ToDecimal(varShelflifevalue[0]) < 25)
                                        {
                                            DataGridView dataGridView = grdGrnlist;
                                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                            cell.Style.BackColor = Color.Red;
                                            cell.Style.ForeColor = Color.White;

                                        }
                                        else if (Convert.ToDecimal(varShelflifevalue[0]) < 50)
                                        {
                                            DataGridView dataGridView = grdGrnlist;
                                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                            cell.Style.BackColor = Color.Orange;
                                            cell.Style.ForeColor = Color.Black;
                                        }

                                        else
                                        {
                                            DataGridView dataGridView = grdGrnlist;
                                            DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                                            cell.Style.BackColor = Color.White;
                                            cell.Style.ForeColor = Color.Black;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        grdGrnlist.Rows[rowIndex].Cells["clmactuallife"].Value = "";
                        DataGridView dataGridView = grdGrnlist;
                        DataGridViewCell cell = dataGridView.Rows[rowIndex].Cells["clmactuallife"];
                        cell.Style.BackColor = Color.White;
                        cell.Style.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdGrnlist_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdGrnlist.IsCurrentCellDirty)
                {
                    grdGrnlist.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPONo_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPONo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPONo_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPONo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbPONo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdGrnlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdGrnlist.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdGrnlist.Rows.RemoveAt(this.grdGrnlist.SelectedCells[0].RowIndex);
                                varModifiedFlag = 1;
                                for (int i = 0; i < grdGrnlist.RowCount; i++)
                                {
                                    grdGrnlist.Rows[i].Cells["clmsno"].Value = i + 1;
                                } 
                                txtTotalpro.Text = Convert.ToString(grdGrnlist.Rows.Count);
                            }
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
            }
        }
        private void GrdGrnlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (varErrorFormat == 0)
                {
                    //udfnGridaddvalue(sender, e);
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmmrp")
                {
                    decimal varMRP = Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmmrp"].Value);
                    string mrp = string.Format("{0:0.00}", varMRP);
                    string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                    grdGrnlist.Rows[e.RowIndex].Cells["clmmrp"].Value = mrp;
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmInvoiceQty")
                {
                    decimal InvoiceQty = Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmInvoiceQty"].Value);
                    if (Convert.ToString(InvoiceQty) == "0" || Convert.ToString(InvoiceQty) == "")
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmInvoiceQty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrQty = "1";
                    }
                    else
                    {
                        grdGrnlist.CurrentRow.Cells["clmInvoiceQty"].Style.BackColor = Color.PaleGreen;
                        varErrQty = "0";
                    }

                    int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmInvoiceQty"].Value), varDecimal);
                    grdGrnlist.Rows[e.RowIndex].Cells["clmInvoiceQty"].Value = Qty;
                    //udfnGridaddvalue( sender,value);
                }
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmExcessQty")
                {
                    decimal ExcessQty = Convert.ToDecimal(grdGrnlist.CurrentRow.Cells["clmExcessQty"].Value);
                    if (Convert.ToString(ExcessQty) == "0" || Convert.ToString(ExcessQty) == "")
                    {
                        grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrQty = "1";
                    }
                    else
                    {
                        grdGrnlist.CurrentRow.Cells["clmExcessQty"].Style.BackColor = Color.PaleGreen;
                        varErrQty = "0";
                    }

                    int varDecimal = Convert.ToInt32(grdGrnlist.CurrentRow.Cells["clmUTDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Value), varDecimal);
                    grdGrnlist.Rows[e.RowIndex].Cells["clmExcessQty"].Value = Qty;
                    //udfnGridaddvalue( sender,value);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridaddvalue(object sender, DataGridViewCellEventArgs value)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;
                varExpiryDate = "";
                varShelflife = 0;
                varErroronGrid = 0;
                int varExpiryDays = 0; int error = 0, rowIndex = value.RowIndex, columnIndex = value.ColumnIndex, varProid = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate")
                {
                    varExpiryDate = Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value);
                    string varTempYear = "0";
                    object cellValue = varExpiryDate;
                    string varExpDate = "";
                    varExpDate = cellValue.ToString();
                    string[] DMY = varExpDate.Split('/');
                    if (DMY.Count() == 3)
                    {
                        varTempYear = DMY[2];
                        if (varTempYear.Length == 2)
                        {
                            cellValue = DMY[0] + "/" + DMY[1] + "/" + 20 + varTempYear;
                        }
                    }
                    //varTempDay = DMY[0];
                    //varTempMonth = DMY[1];
                    varTempExpiryDate = cellValue.ToString();
                }
                varProid = Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmProid"].Value);
                objDS = objDServ.udfnMaster(10, 0, 0, dpGrnDate.Text.Trim(), varTempExpiryDate, varProid, "", 0);
                objDServ.CloseConnection();
                for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                {
                    varShelflife = Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmShelflifeenable"].Value);
                    pbDateflag = 0;
                    if (pbDateflag == 0)
                    {
                        if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate")
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                                {
                                    pbDateflag = 1; error = 1;
                                }
                                else
                                {
                                    if (objDS.Tables.Count != 0)
                                    {
                                        if (objDS.Tables[1].Rows.Count > 0)
                                        {
                                            varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                        }
                                    }
                                    if (varExpiryDays < 0)
                                    {
                                        pbDateflag = 1; error = 1;
                                    }
                                    else
                                    {
                                        if (varShelflife == 1)
                                        {
                                            if (objDS.Tables.Count > 1)
                                            {
                                                if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                                {
                                                    pbDateflag = 1;
                                                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                                                    {
                                                        grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                                        string varMessage = objDServ.udfnGetMessages(98);
                                                        objDServ.CloseConnection();
                                                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }
                                                }
                                                else
                                                {
                                                    grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                                                }
                                            }
                                            else
                                            {
                                                pbDateflag = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (error == 1)
                        {   
                            if (varTempExpiryDate != "")
                            {
                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value) == varTempExpiryDate)
                                {
                                    varErroronGrid = 1;
                                    grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                    string varMessage = objDServ.udfnGetMessages(94);
                                    objDServ.CloseConnection();
                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            if (pbDateflag == 0)
                            {
                                grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                DataGridViewCell cell = dataGridView.Rows[i].Cells["clmmrp"];
                                DataGridViewCell cell1 = dataGridView.Rows[i].Cells["clmexpirydate"];
                                DataGridViewCell cell2 = dataGridView.Rows[i].Cells["clmBatchno"];
                                cell.Style.BackColor = Color.PaleGreen;
                                cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                cell1.Style.BackColor = Color.PaleGreen;
                                cell1.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                cell2.Style.BackColor = Color.PaleGreen;
                                cell2.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchenable"].Value) == "72" && Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchgeneration"].Value) == "74")
                                {
                                    cell2.Style.BackColor = Color.LightGray;
                                    cell2.Style.ForeColor = Color.Black;
                                    cell2.ReadOnly = true;
                                }
                                else if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchenable"].Value) == "73")
                                {
                                    cell2.Style.BackColor = Color.LightGray;
                                    cell2.Style.ForeColor = Color.Black;
                                    cell2.ReadOnly = true;
                                }
                                else
                                {
                                    cell2.Style.BackColor = Color.PaleGreen;
                                    cell2.Style.ForeColor = Color.Black;
                                }
                            }
                        }
                        if (pbDateflag == 0)
                        {
                            //grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                            if (Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmsno"].Value) != Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmsno"].Value))
                            {
                                if (Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmProid"].Value) == Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmProid"].Value))
                                {
                                    string varMRP = Convert.ToString(grdGrnlist.Rows[i].Cells["clmmrp"].Value).Trim();
                                    string varNewExpiryDate = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value).Trim();
                                    string varBatch = Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value).Trim();
                                    string varPoid = Convert.ToString(grdGrnlist.Rows[i].Cells["clmPOid"].Value).Trim();
                                    if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value) == varNewExpiryDate && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmBatchno"].Value) == varBatch)
                                    {
                                        if (Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmPOid"].Value) == Convert.ToInt32(varPoid))
                                        {
                                            MessageBox.Show("Product already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            if (pbDateflag == 0)
                                            {
                                                grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                                DataGridViewCell cell = dataGridView.Rows[i].Cells["clmmrp"];
                                                DataGridViewCell cell1 = dataGridView.Rows[i].Cells["clmexpirydate"];
                                                DataGridViewCell cell2 = dataGridView.Rows[i].Cells["clmBatchno"];
                                                cell.Style.BackColor = Color.PaleGreen;
                                                cell.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                                cell1.Style.BackColor = Color.PaleGreen;
                                                cell1.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                                cell2.Style.BackColor = Color.PaleGreen;
                                                cell2.Style.ForeColor = Color.Black;// Set the background color to the default background color
                                            }
                                        }
                                    }
                                }
                            }
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

        private void CmbPONo_KeyPress(object sender, KeyPressEventArgs e)
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


        private void GrdPODetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdPODetails.Rows.Count; i++)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[i].Cells["clmpono"];
                    if (Convert.ToString(grdPODetails.Rows[i].Cells["clmsts"].Value) == "13")
                    {
                        cell.Style.BackColor = Color.RoyalBlue;
                        cell.Style.ForeColor = Color.White;
                    }
                    else
                    {
                        cell.Style.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        cell.Style.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPODetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PUR_GRNDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    BtnSave_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnDamage_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamaged = new PUR_PODamaged();
                MainForm.objPUR_PODamaged.varMasterType = "3";
                MainForm.objPUR_PODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        public void udfnAddProductsgrid()
        {
            try
            {
                bool varErrorFlag = false;
                lvproduct.Visible = false;
                varExpiryDate = ""; varExpiryDateAdd = "";
                if (txtProductName.Text == "")
                {
                    errGRNDetails.SetError(txtProductName, "Please enter product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    varErrorFlag = true;
                }
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtMonth, "Please enter month.");
                        varErrorFlag = true;
                    }
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtYear, "Please enter year.");
                        varErrorFlag = true;
                    }
                }
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchno.Text.Trim() == "")
                    {
                        txtBatchno.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtBatchno, "Please enter BatchNo.");
                        tpbatchno.ShowAlways = true;
                        tpbatchno.Show("Please enter Batch No.", txtBatchno, 5000);
                        varErrorFlag = true;
                    }
                }
                if (Convert.ToString(varNewFlag) == "0")
                {
                    if (Convert.ToString(txtProductName.Text) != "")
                    {
                        string varproductID = "0";
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 39;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraProductName = txtProductName.Text;
                        objMR_Product.paraId = Convert.ToInt32(cmbPONo.SelectedValue);
                        objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                        objMR_Product.ParaGRNID = Convert.ToInt32(pbGRNId);
                        DataSet objDsproductId = new DataSet();
                        SPDataService objDserv = new SPDataService();
                        objDsproductId = objDserv.udfnproductmasterlist(objMR_Product);
                        objDserv.CloseConnection();
                        if (objDsproductId != null)
                        {
                            if (objDsproductId.Tables.Count > 0)
                            {
                                if (objDsproductId.Tables[0].Rows.Count > 0)
                                {
                                    varproductID = Convert.ToString(objDsproductId.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        if (varproductID == "-1")
                        {
                            lblProductcode.Text = "0";
                            errGRNDetails.SetError(txtProductName, "Invalid product");
                            txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpProduct.ShowAlways = true;
                            tpProduct.Show("Invalid product", txtProductName, 5000);
                            varErrorFlag = true;
                        }
                        else
                        {
                            lblProductcode.Text = varproductID;
                            errGRNDetails.Clear();
                            txtProductName.BackColor = Color.White;
                        }
                    }
                }
                if (varErrorFlag == false)
                {
                    int varflag = 0;
                    string varShelflifevalue = "", varAcutalshelflife = "";
                    lblNoRecordsFound.Visible = false;

                    if (expirydateFlag == 1 || txtDate.Text != "" || txtMonth.Text != "" || txtYear.Text != "")
                    {
                        udfnDatevalidationset();
                    }
                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    if (varExpiryDate != "")
                    {
                        if (expirydateFlag == 1)
                        {
                            objDS = objDServ.udfnMaster(7, 0, 0, dpGrnDate.Text, varExpiryDate, Convert.ToInt32(lblProductcode.Text), "", 0);
                            objDServ.CloseConnection();
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(objDS.Tables[0].Rows[0]["DATEVALIDATE"]) == "0")
                                {
                                    errGRNDetails.SetError(txtDate, "Invalid expiry date");
                                    txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpProduct.ShowAlways = true;
                                    tpProduct.Show("Invalid expiry date", txtDate, 5000);
                                    varflag = 1;
                                }
                                else
                                {
                                    if (objDS.Tables[1].Rows.Count > 0)
                                    {
                                        varShelflifevalue = Convert.ToString(objDS.Tables[1].Rows[0]["SHELFLIFE"]);
                                    }
                                    if (objDS.Tables[2].Rows.Count > 0)
                                    {
                                        varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                                    }
                                }
                            }
                        }
                    }
                    if(txtmrprate.Text.Trim()=="")
                    {
                        txtmrprate.Text = "0";
                    }
                    if (varflag == 0)
                    {
                        for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(lblProductcode.Text) == Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmProid"].Value))
                            {
                                string varMRP = Convert.ToString(grdGrnlist.Rows[i].Cells["clmmrp"].Value).Trim();
                                string varNewExpiryDate = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value).Trim();
                                string varBatch = Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value).Trim();
                                string varPoid = Convert.ToString(grdGrnlist.Rows[i].Cells["clmPOid"].Value).Trim();

                                string varTempYear = "0";
                                object cellValue = varExpiryDate;
                                string[] DMY = varExpiryDate.Split('/');
                                if (DMY.Count() == 3)
                                {
                                    varTempYear = DMY[2];
                                    if (varTempYear.Length == 4)
                                    {
                                        int year = Convert.ToInt32(varTempYear) - 2000;
                                        cellValue = DMY[0] + "/" + DMY[1] + "/" + year;
                                    }
                                }
                                varExpiryDate = cellValue.ToString();

                                if (txtmrprate.Text.Trim() == varMRP && varExpiryDate == varNewExpiryDate && txtBatchno.Text.Trim() == varBatch)
                                {
                                    if (Convert.ToString(cmbPONo.SelectedValue) == varPoid)
                                    {
                                        lblProductcode.Text = "0";
                                        errGRNDetails.SetError(txtProductName, "Product already exist");
                                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                        tpdate.ShowAlways = true;
                                        tpdate.Show("Product already exist", txtProductName, 5000);
                                        varflag = 1;
                                        grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                    }
                                }
                                else
                                {
                                    grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                }
                            }
                            else
                            {
                                grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                grdGrnlist.Rows[i].Cells["clmexpirydate"].Style.BackColor = Color.PaleGreen;
                                grdGrnlist.Rows[i].Cells["clmInvoiceQty"].Style.BackColor = Color.PaleGreen;
                                grdGrnlist.Rows[i].Cells["clmExcessQty"].Style.BackColor = Color.PaleGreen;
                                grdGrnlist.Rows[i].Cells["clmmrp"].Style.BackColor = Color.PaleGreen;
                                //grdGrnlist.Rows[i].Cells["clmBatchno"].Style.BackColor = Color.LightGray;
                            }
                        }
                    }

                    if (Convert.ToInt32(lblSupplierCode.Text) != 0)
                    {
                        if (varflag == 0)
                        {
                            if (pbDateflag == 0)
                            {
                                errGRNDetails.Clear();
                                tpdate.Active = false;
                                txtDate.BackColor = Color.White;
                                txtMonth.BackColor = Color.White;
                                txtYear.BackColor = Color.White;
                                string[] varpono = cmbPONo.Text.Split('~');
                                string productCode = "0";
                                if (Convert.ToString(varNewFlag) == "0")
                                {
                                    productCode = lblProductcode.Text;
                                }
                                else
                                {
                                    objDS = objDServ.udfnMaster(17, 0, 0, "", "", 0, "", 0);
                                    objDServ.CloseConnection();
                                    if (objDS.Tables[0].Rows.Count > 0)
                                    {
                                        productCode = Convert.ToString(objDS.Tables[0].Rows[0]["Proid"]);
                                        varTName = txtProductName.Text;
                                        varPICode = "";
                                        var_Symbol = "";
                                        varexp = "";
                                        //txtmrprate.Text = "";
                                        //varExpiryDate = "";
                                        txtBatchno.Text = "";
                                        varunitid = "0";
                                        expirydateFlag = 0;
                                    }
                                }
                                if (txtInvoiceQty.Text != "")
                                {
                                    string[] Quantity = txtInvoiceQty.Text.Split('.');
                                    string Qty = objValidation.udfnDecimal((txtInvoiceQty.Text).Trim(), varDecimal);
                                    string QtyValue = Quantity[0];
                                    if(QtyValue=="0")
                                    {
                                        txtInvoiceQty.Text ="0" + Qty;
                                    }
                                    else
                                    {
                                        txtInvoiceQty.Text = Qty;
                                    }
                                }
                                decimal varMRP = Math.Round(Convert.ToDecimal(txtmrprate.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                                string mrp = string.Format("{0:0.00}", varMRP);
                                string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                                //string ExpiryDate = txtDate.Text+'/'+txtMonth.Text+'/'+txtYear.Text;
                                grdGrnlist.Rows.Add(grdGrnlist.Rows.Count + 1, (varpono[0]).Trim(), (varPICode).Trim(), (varEName).Trim(), (varTName).Trim(), (var_Symbol).Trim(), txtInvoiceQty.Text.Trim(),Convert.ToInt32(cmbQtyType.SelectedValue) ,Convert.ToDecimal(mrp), (varExpiryDateAdd).Trim()
                                    , (varexp).Trim(), varAcutalshelflife, varShelflifevalue, (txtBatchno.Text).Trim(), (productCode).Trim(), (varunitid).Trim(), cmbPONo.SelectedValue, varBatchNo, varBatchNoGeneration, expirydateFlag, varNewFlag,0,varDecimal);
                                udfnrowclear();
                                varModifiedFlag = 1;
                                //grdsupplieradd.Sort(grdsupplieradd.Columns[1], ListSortDirection.Ascending);
                                //for (int i = 0; i < grdsupplieradd.RowCount; i++)
                                //{
                                //    grdsupplieradd.Rows[i].Cells["clmsno"].Value = i + 1;
                                //}
                                grdGrnlist.Columns["clmInvoiceQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["clmExcessQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                this.ActiveControl = txtProductName;
                                string[] varShelflifeper = Convert.ToString(varShelflifevalue).Split(' ');
                                if (varShelflifeper[0] != "")
                                {
                                    if (Convert.ToDecimal(varShelflifeper[0]) < 25)
                                    {
                                        DataGridView dataGridView = grdGrnlist;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.Red;
                                        cell.Style.ForeColor = Color.White;

                                    }
                                    else if (Convert.ToDecimal(varShelflifeper[0]) < 50)
                                    {
                                        DataGridView dataGridView = grdGrnlist;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.Orange;
                                        cell.Style.ForeColor = Color.Black;
                                    }

                                    else
                                    {
                                        DataGridView dataGridView = grdGrnlist;
                                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                        cell.Style.BackColor = Color.White;
                                        cell.Style.ForeColor = Color.Black;
                                    }
                                }
                                if (varBatchNo == "72" && varBatchNoGeneration == "75")
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    cell.Style.BackColor = Color.PaleGreen;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = false;
                                }
                                if (varBatchNo == "72" && varBatchNoGeneration == "74")
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                }
                                else if (varBatchNo == "73")
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                }
                            }
                            else
                            {
                                //SPDataService objDServ1 = new SPDataService();
                                //string varMessage = objDServ1.udfnGetMessages(70);
                                //objDServ1.CloseConnection();
                                //MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
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
                grdGrnlist.Sort(grdGrnlist.Columns[2], ListSortDirection.Ascending);
                if(grdGrnlist.Rows.Count>0)
                {
                    grdGrnlist.CurrentCell = grdGrnlist[6,0];
                }
            }
        }

        public void udfnrowclear()
        {
            try
            {
                errGRNDetails.Clear();
                cmbPONo.SelectedIndex = 0;
                cmbPONo.BackColor = Color.White;
                txtProductName.Text = "";
                txtmrprate.Text = "";
                txtDate.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchno.Text = "";
                txtInvoiceQty.Text = "";
                txtProductName.BackColor = Color.White;
                txtmrprate.BackColor = Color.White;
                txtDate.BackColor = Color.White;
                txtMonth.BackColor = Color.White;
                txtYear.BackColor = Color.White;
                txtBatchno.BackColor = Color.White;
                txtInvoiceQty.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDatevalidationset()
        {
            try
            {
                string varDay = "", varMonth = "", varYear = "", varDate = ""; string varDcDay = "", varDcMonth = "", varDcYear = "", varExpiry = "";
                int varExpiryDays = 0; int error = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (txtDate.Text.Trim() == "")
                {
                    varDay = "01";
                }
                else
                {
                    if (Convert.ToInt64(txtDate.Text) > 31 || Convert.ToInt64(txtDate.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(95);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtDate.Text.Length == 1)
                        { txtDate.Text = 0 + txtDate.Text.Trim(); }
                        varDay = txtDate.Text.Trim();
                    }
                }
                if (txtMonth.Text.Trim() != "")
                {
                    if (Convert.ToInt64(txtMonth.Text) > 12 || Convert.ToInt64(txtMonth.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(90);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtMonth.Text.Length == 1)
                        { txtMonth.Text = 0 + txtMonth.Text.Trim(); }
                    }
                }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Length < 2)
                    {
                        pbDateflag = 1;
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(92);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (pbDateflag == 0)
                {
                    varMonth = Convert.ToString(txtMonth.Text.Trim());
                    varYear = 20 + Convert.ToString(txtYear.Text.Trim());
                    if (txtDate.Text.Trim() == "")
                    {
                        varDate = varDay + "/" + varMonth + "/" + varYear;
                        objDS = objDServ.udfnMaster(5, 0, 0, varDate, "", 0, "", 0);
                        objDServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varExpiryDate = objDS.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();
                            string varTempYear = "0";
                            object cellValue = varExpiryDate;
                            string[] DMY = varExpiryDate.Split('/');
                            if (DMY.Count() == 3)
                            {
                                varTempYear = DMY[2];
                                if (varTempYear.Length == 4)
                                {
                                    int year = Convert.ToInt32(varTempYear) - 2000;
                                    varExpiryDateAdd = DMY[0] + "/" + DMY[1] + "/" + year;
                                }
                            }
                        }
                    }
                    else
                    {
                        varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                        varExpiryDateAdd = varDay + "/" + varMonth + "/" + txtYear.Text.Trim();
                    }
                    objDS = objDServ.udfnMaster(10, 0, 0, dpGrnDate.Text.Trim(), varExpiryDate, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0);
                    objDServ.CloseConnection();
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                        {
                            pbDateflag = 1; error = 1;
                        }
                        else
                        {
                            if (objDS.Tables.Count != 0)
                            {
                                if (objDS.Tables[1].Rows.Count > 0)
                                {
                                    varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                }
                            }
                            if (varExpiryDays < 0)
                            {
                                pbDateflag = 1; error = 1;
                            }
                            else
                            {
                                if (varShelflife == 1)
                                {
                                    if (objDS.Tables.Count > 1)
                                    {
                                        if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                        {
                                            pbDateflag = 1;
                                            txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            string varMessage = objDServ.udfnGetMessages(98);
                                            objDServ.CloseConnection();
                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        pbDateflag = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                if (error == 1)
                {
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    string varMessage = objDServ.udfnGetMessages(94);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpinvoicedate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpinvoicedate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpinvoicedate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpinvoicedate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpinvoicedate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceamt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceamt.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceamt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPONo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtProductName.Text == "")
                //{
                //    errPO.SetError(txtProductName, "Please enter product");
                //    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpProduct.ShowAlways = true;
                //    tpProduct.Show("Please enter product.", txtProductName, 5000);
                //}
                //else
                //{
                errGRNDetails.Clear();
                txtProductName.BackColor = Color.White;
                tpProduct.Active = false;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                /*
                if (e.KeyCode == Keys.Enter)
                {
                    txtmrprate.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvproduct.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtProductName.Focus();
                        lvproduct.Visible = false;
                    }
                    else
                    {
                        lvproduct.Focus();
                    }
                    if (lvproduct.Items.Count > 0)
                    {
                        lvproduct.Items[0].Selected = true;
                    }
                }*/

                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblDEGroup.Text = "Search by P.I Code";
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblDEGroup.Text = "Search by Product Name";
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount==0)
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
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewProduct();
                                    cmbQtyType.Focus();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbQtyType.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnListviewProduct();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //udfnListviewProduct();
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
                if (txtProductName.Text != "")
                {
                    txtmrprate.Text = "";
                    txtDate.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtBatchno.Text = "";
                    varBatchNo = "0"; varBatchNoGeneration = "0"; varShelflife = 0; expirydateFlag = 0;
                    /*
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[2].Text;
                    lblProductcode.Text = selectedItem.SubItems[4].Text;
                    varBatchNo = selectedItem.SubItems[5].Text;
                    varBatchNoGeneration = selectedItem.SubItems[6].Text;
                    varRMProduction = selectedItem.SubItems[7].Text;
                    varPrcategory = selectedItem.SubItems[8].Text;
                    varShelflife = Convert.ToInt32(selectedItem.SubItems[9].Text);
                    */
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNo"].Value.ToString();
                    varBatchNoGeneration = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNoGeneration"].Value.ToString();
                    varRMProduction = DGV_FilterProduct.SelectedRows[0].Cells["PR_RMForProduction"].Value.ToString();
                    varPrcategory = DGV_FilterProduct.SelectedRows[0].Cells["PR_PRCTID"].Value.ToString();
                    varShelflife = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_ShelfLife"].Value.ToString());
                    lblUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    if (varShelflife == 1)
                    { expirydateFlag = 1; }
                    udfnProductAdd();

                    if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                    {
                        txtBatchno.Text = "";
                        txtBatchno.Enabled = false;
                        //  txtBatchNo.ReadOnly = true;
                    }
                    else if (Convert.ToInt32(varBatchNo) == 72) //enabled
                    {
                        if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                        {
                            txtBatchno.Enabled = true;
                            //txtBatchNo.ReadOnly = false;
                        }
                        else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(14, 0, 0, "", "", 0, "", 0);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtBatchno.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                    txtBatchno.Enabled = false;
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(varPrcategory) == 16)
                    {
                        if (Convert.ToInt32(varRMProduction) == 1)
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(15, 0, 0, dpGrnDate.Text, "", Convert.ToInt32(lblProductcode.Text), "", 0);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtDate.Text = objDs.Tables[0].Rows[0][0].ToString();
                                    txtMonth.Text = objDs.Tables[0].Rows[1][0].ToString();
                                    txtYear.Text = objDs.Tables[0].Rows[2][0].ToString();
                                }
                            }
                        }
                    }
                }
                cmbQtyType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvproduct.Visible = false;
            }
        }

        public void udfnProductAdd()
        {
            try
            {
                if (Convert.ToInt32(lblProductcode.Text) != 0)
                {
                    varPICode = ""; varEName = ""; var_Symbol = ""; var_Text = ""; var_RMinSaleQty = ""; varSTOCK = ""; varPrevious = "";
                    varPARITAL = ""; varReOrderQty = ""; varorderSaleQty = ""; addproductid = ""; varunitid = ""; varexp = "";
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 34;
                    objMR_Product.ParaProductCode = Convert.ToInt32(lblProductcode.Text);
                    objMR_Product.ParaScheduleid = lblschedule.Text;
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varPICode = objDs.Tables[0].Rows[0]["PR_PICode"].ToString();
                            varEName = objDs.Tables[0].Rows[0]["PR_EName"].ToString();
                            varTName = objDs.Tables[0].Rows[0]["PR_TName"].ToString();
                            var_Symbol = objDs.Tables[0].Rows[0]["UT_Symbol"].ToString();
                            var_Text = objDs.Tables[0].Rows[0]["GST_Text"].ToString();
                            var_RMinSaleQty = objDs.Tables[0].Rows[0]["PR_MinStock"].ToString();
                            varSTOCK = objDs.Tables[0].Rows[0]["STOCK"].ToString();
                            varPrevious = objDs.Tables[0].Rows[0]["PRE.PEND"].ToString();
                            varPARITAL = objDs.Tables[0].Rows[0]["PARITAL"].ToString();
                            varReOrderQty = objDs.Tables[0].Rows[0]["PR_ReOrderQty"].ToString();
                            varorderSaleQty = "0";
                            addproductid = objDs.Tables[0].Rows[0]["PRID"].ToString();
                            varunitid = objDs.Tables[0].Rows[0]["UTID"].ToString();
                            varexp = objDs.Tables[0].Rows[0]["PRODUCTEXP"].ToString();
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
                lvproduct.Visible = false;
            }
        }

        public void udfnsupplierLoad()
        {
            try
            {
                if (lblSupplierCode.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            lblSuppliername.Text = objDs.Tables[0].Rows[0]["NAME"].ToString();
                            lblSupplierCity.Text = objDs.Tables[0].Rows[0]["CITY"].ToString();
                            lblsupplierGST.Text = objDs.Tables[0].Rows[0]["GSTIN"].ToString();
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString();
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString();
                            lblSupplierOrderpolicy.Text = "Return Policy -" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                        }
                        if (objDs.Tables[7].Rows.Count > 0)
                        {
                            varDamage = objDs.Tables[7].Rows[0]["DAMAGE"].ToString();
                            varReturnDC = objDs.Tables[7].Rows[0]["RETURNDC"].ToString();
                        }
                        if (objDs.Tables[5].Rows.Count > 0)
                        {
                            grdPODetails.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[5].Rows.Count; i++)
                            {
                                grdPODetails.Rows.Add(objDs.Tables[5].Rows[i]["PO_No"].ToString(),
                                objDs.Tables[5].Rows[i]["PO_Date"].ToString(), objDs.Tables[5].Rows[i]["QTY"].ToString(), objDs.Tables[5].Rows[i]["PO_Final_STSID"].ToString(), objDs.Tables[5].Rows[i]["POID"].ToString()
                                );
                            }
                            DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdPODetails_DataBindingComplete(grdPODetails, args);
                        }
                        else
                        {
                            grdPODetails.Rows.Clear();
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
                if (varReturnDC == "0")
                {
                    btnDC.Enabled = false;
                }
                else
                {
                    btnDC.Enabled = true;
                }
                if (varDamage == "0")
                {
                    btnDamage.Enabled = false;
                }
                else
                {
                    btnDamage.Enabled = true;
                }
            }
        }
        public void udfnEditLoad()
        {
            try
            {
                if (pbGRNId != "0")
                {
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnGrnListLoad(2, Convert.ToInt32(pbSupplierId), 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0,0, "0","");
                    objdserv.CloseConnection(); 
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                cmbConcern.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_COMID"]);
                                dpGrnDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Date"]);
                                txtgrnno.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_No"]);
                                txtSupplier.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SUPPLIER"]);
                                lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_SPID"]);
                                cmbOrderType.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_OrderType"]);
                                lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_SPSCID"]);
                                dpinvoicedate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceDate"]);
                                txtInvoiceno.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceNo"]);
                                txtInvoiceamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceAmnt"]);
                                txtRemark.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Remarks"]);
                                udfnsupplierLoad();
                                LV_Supplier.Visible = false;
                                cmbConcern.Enabled = false;
                                dpGrnDate.Enabled = false;
                                txtSupplier.Enabled = false;
                                cmbOrderType.Enabled = false;
                                if (Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "23" || Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "24" || Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "44")
                                {
                                    chkCompleted.Enabled = false;
                                    chkCompleted.Checked = true;
                                    btnDC.Enabled = false;
                                    gpAddrow.Enabled = false;
                                    grpGrnDetails.Enabled = false;
                                    grdGrnlist.ReadOnly = true;
                                    grdGrnlist.Columns["clmRemove"].Visible = false;
                                    //grdGrnlist.Enabled = false;
                                }
                                else
                                {
                                    chkCompleted.Enabled = true;
                                }
                                if (Convert.ToDecimal(txtInvoiceamt.Text) >= 25000)
                                {
                                    if (chkCompleted.Enabled == false)
                                    {
                                        btnVerify1.Enabled = true;
                                    }
                                }
                                else
                                {
                                    btnVerify1.Enabled = false;
                                    btnVerify2.Enabled = false;
                                }
                            }
                            if (objDs.Tables[3].Rows.Count != 0)
                            {
                                grdGrnlist.Rows.Clear();
                                for (int i = 0; i < objDs.Tables[3].Rows.Count; i++)
                                {
                                    lblNoRecordsFound.Visible = false;
                                    string varMRP = "";
                                    if (Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_MRP"]) == "0")
                                    {
                                        varMRP = "";
                                    }
                                    else
                                    {
                                        varMRP = Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_MRP"]);
                                    }
                                    if (Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_Expirydate"]) != "")
                                    {
                                        string varTempYear = "0";
                                        object cellValue = objDs.Tables[3].Rows[i]["GRNPR_Expirydate"].ToString();
                                        string varExpiryDate = "";
                                        varExpiryDate = cellValue.ToString();
                                        string[] DMY = varExpiryDate.Split('/');
                                        if (DMY.Count() == 3)
                                        {
                                            varTempYear = DMY[2];
                                            if (varTempYear.Length == 4)
                                            {
                                                int year = Convert.ToInt32(varTempYear) - 2000;
                                                cellValue = DMY[0] + "/" + DMY[1] + "/" + year;
                                            }
                                        }
                                        varTempExpiryDate = cellValue.ToString();
                                    }
                                    else
                                    {
                                        varTempExpiryDate = "";
                                    }
                                    grdGrnlist.Rows.Add(grdGrnlist.Rows.Count + 1, Convert.ToString(objDs.Tables[3].Rows[i]["PONO"])
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[3].Rows[i]["PENAME"])
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["PTNAME"]), Convert.ToString(objDs.Tables[3].Rows[i]["UNIT"]), 
                                    Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_QTY"]), Convert.ToString(objDs.Tables[3].Rows[i]["GRNPR_Qty_Type"])
                                    , varMRP, varTempExpiryDate
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["PRODUCTEXP"]), Convert.ToString(objDs.Tables[3].Rows[i]["actuallife"]),
                                    Convert.ToString(objDs.Tables[3].Rows[i]["Shelflifeper"]), Convert.ToString(objDs.Tables[3].Rows[i]["BATCHDate"]),
                                    Convert.ToString(objDs.Tables[3].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[3].Rows[i]["UTID"]),
                                    Convert.ToString(objDs.Tables[3].Rows[i]["POID"])
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["BATCHNO"]), Convert.ToString(objDs.Tables[3].Rows[i]["Batchnogeneration"])
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["PR_ShelfLife"]), Convert.ToString(objDs.Tables[3].Rows[i]["newproflag"])
                                    ,Convert.ToString(objDs.Tables[3].Rows[i]["PO_Qty"]), Convert.ToString(objDs.Tables[3].Rows[i]["MST_DisplayText"])
                                    );
                                    grdGrnlist.Columns["clmexpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    grdGrnlist.Columns["clmInvoiceQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    grdGrnlist.Columns["clmExcessQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                }
                                txtTotalpro.Text = Convert.ToString(grdGrnlist.Rows.Count);
                                DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                GrdGrnlist_DataBindingComplete(grdGrnlist, args2);
                            } 
                            if (objDs.Tables[5].Rows.Count != 0)
                            {
                                if (Convert.ToString(objDs.Tables[5].Rows[0]["VERIFIED1"]) != "")
                                {
                                    //lblVerified1.Text = Convert.ToString(objDs.Tables[5].Rows[0]["VERIFIED1"]);
                                    //lblVerifyDateTime.Text = Convert.ToString(objDs.Tables[5].Rows[0]["VERIFIEDON1"]);
                                    btnVerify1.Enabled = false;
                                    btnVerify2.Enabled = false;
                                    btnDC.Enabled = false;
                                    gpAddrow.Enabled = false;
                                    grpGrnDetails.Enabled = false;
                                    grdGrnlist.Columns["clmRemove"].Visible = false;
                                    grdGrnlist.Enabled = false;
                                    grdGrnlist.ClearSelection();
                                }
                                else
                                {
                                    if (chkCompleted.Enabled == false && chkCompleted.Checked == true)
                                    {
                                        btnVerify1.Enabled = true;
                                        btnVerify2.Enabled = false;
                                    }
                                    //gpAddrow.Enabled = true;
                                }
                            } 
                            if (objDs.Tables[6].Rows.Count != 0)
                            {
                                if (Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIED2"]) != "")
                                {
                                    //lblVerified2.Text = Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIED2"]);
                                    //lblVerifyDateTime2.Text = Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIEDON2"]);
                                    btnVerify2.Enabled = false;
                                }
                                else
                                {
                                    if (lblVerified1.Text != "")
                                    {
                                        if (Convert.ToDecimal(txtInvoiceamt.Text) >= 25000)
                                        {
                                            btnVerify2.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        btnVerify2.Enabled = false;
                                    } 
                                }
                            }
                            if (objDs.Tables[7].Rows.Count != 0)
                            {
                                grdReurnDC.Rows.Clear();
                                for (int i = 0; i < objDs.Tables[7].Rows.Count; i++)
                                {
                                    grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[7].Rows[i]["DCDATE"]), Convert.ToString(objDs.Tables[7].Rows[i]["DCNO"]),
                                    Convert.ToString(objDs.Tables[7].Rows[i]["PRCOUNT"]), Convert.ToString(objDs.Tables[7].Rows[i]["DCVALUE"]), Convert.ToString(objDs.Tables[7].Rows[i]["ID"]));
                                }
                            }
                        }
                    }
                    if(chkCompleted.Checked==true)
                    {
                        btnVerified.Enabled = false;
                        btnSave.Enabled = false;
                        txtRemark.Enabled = false;
                        udfnVerifiedBy();
                    }
                    else
                    {
                        btnVerified.Enabled = true;
                        udfnVerifiedBy();
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
                if(grdGrnlist.Rows.Count>0)
                {
                    grdGrnlist.CurrentCell = grdGrnlist[6, 0];

                }
            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if (grdGrnlist.Focused)
                {
                    grid_flag = 1;
                }

                if (grid_flag == 1)
                {
                    if (keyData == Keys.Enter || keyData == Keys.Right || keyData == Keys.Tab)
                    {
                        int icolumn = grdGrnlist.CurrentCell.ColumnIndex;
                        int irow = grdGrnlist.CurrentCell.RowIndex;
                        int i = irow;
                        int intsection = 0, intlvariant = 0;
                        intsection = grdGrnlist.Columns.Count - 1;
                        intlvariant = grdGrnlist.Columns.Count - 11;
                        if (intsection == icolumn)
                        {
                            grdGrnlist.CurrentCell = grdGrnlist[intsection, irow + 1];
                            icolumn = grdGrnlist.Columns.Count - 1;//grdProDetails.CurrentCell.ColumnIndex;
                            irow = grdGrnlist.CurrentCell.RowIndex;
                        }
                        else if (intlvariant == icolumn)
                        {
                        A: if (icolumn == grdGrnlist.Columns.Count - 11)
                            {
                                //grdProDetails.Rows.Add();
                                if (irow < grdGrnlist.Rows.Count - 1)
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[6, irow + 1];
                                    icolumn = grdGrnlist.CurrentCell.ColumnIndex;
                                    irow = grdGrnlist.CurrentCell.RowIndex;
                                    //goto A;
                                }
                                else
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[icolumn + 1, irow];
                                    if (grdGrnlist.CurrentCell.ReadOnly == true)
                                    {
                                        icolumn++; goto A;
                                    }

                                }
                            }
                            else
                            {
                                grdGrnlist.CurrentCell = grdGrnlist[icolumn + 1, irow];
                                if (grdGrnlist.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                            }
                        }
                        else
                        {
                        A: if (icolumn == grdGrnlist.Columns.Count - 1)
                            {
                                //grdProDetails.Rows.Add();
                                if (irow < grdGrnlist.Rows.Count - 1)
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[1, irow + 1];
                                    icolumn = grdGrnlist.CurrentCell.ColumnIndex;
                                    irow = grdGrnlist.CurrentCell.RowIndex;
                                    //goto A;
                                }
                                else
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[icolumn + 1, irow];
                                    if (grdGrnlist.CurrentCell.ReadOnly == true)
                                    {
                                        icolumn++; goto A;
                                    }

                                }
                            }
                            else
                            {
                                if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmBatchno")
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[6, irow + 1];
                                    icolumn = grdGrnlist.CurrentCell.ColumnIndex;
                                    irow = grdGrnlist.CurrentCell.RowIndex;
                                }
                                else if (grdGrnlist[icolumn + 1, irow].Visible == false)
                                {
                                    { icolumn++; goto A; }
                                }
                                else
                                {
                                    grdGrnlist.CurrentCell = grdGrnlist[icolumn + 1, irow];
                                    if (grdGrnlist.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                                }
                                
                            }
                        }
                        //A: if (icolumn == grdProDetails.Columns.Count - 1)
                        //{
                        //    //grdProDetails.Rows.Add();
                        //    if (irow < grdProDetails.Rows.Count - 1)
                        //    {
                        //        grdProDetails.CurrentCell = grdProDetails[1, irow + 1];
                        //        icolumn = grdProDetails.CurrentCell.ColumnIndex;
                        //        irow = grdProDetails.CurrentCell.RowIndex;
                        //        goto A;
                        //    }
                        //    else
                        //    {
                        //        grdProDetails.CurrentCell = grdProDetails[icolumn + 1, irow];
                        //        if (grdProDetails.CurrentCell.ReadOnly == true)
                        //        {
                        //            icolumn++; goto A;
                        //        }

                        //    }
                        //}
                        //else
                        //{
                        //    grdProDetails.CurrentCell = grdProDetails[icolumn + 1, irow];
                        //    if (grdProDetails.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                        //}

                        grid_flag = 0;
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            //// below is for escape key return
            //return base.ProcessCmdKey(ref msg, keyData);
            // below is for enter key return
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
