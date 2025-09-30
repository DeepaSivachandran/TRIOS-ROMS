using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class INV_Reconciliation : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpExpiryDate = new ToolTip();
        private ToolTip tpmrp = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpOutwardQuantity = new ToolTip();
        private ToolTip tpRemark = new ToolTip();
        private ToolTip tpTotalItem = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip  tprack = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        public int varCompleteFlag = 0;
        public string varStockLocationId = "", varTamilname = "";
        public string varStockApplicable = "";
        public int varErrQty = 0;
        public int varCloseFlag = 0;
        public int varUpDownKey = 0;
        public int varAJId = 0;
        public int varSTSID = 0;
        public int varUpdate = 0, VarUpdateFlag = 0;
        public int varCompanyId = 0, varDestSLID = 0, varDestRKID = 0, varStatusId = 0, varDecimal = 0;
        string varProductID = "", varMRP = "", varExpiryDate = "", varBatchNo = "", varRackId = "", varBatchNoGeneration="", varPrMRPFlag="";
        DataTable dtStock = new DataTable();
        public string vargroupcode;
        public String pbFormStatus;
        private bool varErrorFlag;
        public bool varChangeFlag = true;
        public bool VarSearchFlag = true;
        string result = "";
        public string varPICode = "", varPEname = "", varPTname = "", varPID = "", varUTID = "", varPRID = "", varRKID = "", varTotalItem = "", varUnit = "", varTransType = "";
       
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0, expirydateFlag = 0, pbDateflag = 0;
        public string varUserID = "";
        DataTable dtStockReconciliation = new DataTable();

        public INV_Reconciliation()
        {
            InitializeComponent();
        }
        public void udfnclose()
        {
            try
            {
                if (varClose == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDiscard()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to discard changes ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            try
            {
              
                    udfnclose();
                    MainForm.objINV_StockAdjustmentList.udfnList(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void INV_GodownOutward_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                txtReconciliationQuantity.TextAlign = HorizontalAlignment.Right;
                if (e.KeyCode == Keys.Escape)
                {
                    DGV_FilterProduct.Visible = false;
                    if (varChangeFlag == false)
                    {
                        udfnDiscard();
                    }
                    else
                    {
                        udfnclose();
                    }
                }
                if (e.KeyCode == Keys.F5)
                {
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbTransactionType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTransactionType.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epStockReconciliation.SetError(cmbTransactionType, "Please select transaction type");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
                }
                else
                {
                    epStockReconciliation.Clear();
                    cmbTransactionType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation();
                    txtStockLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProduct_Enter(object sender, EventArgs e)
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

        private void TxtProduct_Leave(object sender, EventArgs e)
        {
            try
            {
                epStockReconciliation.Clear();
                txtProductName.BackColor = Color.White;
                tpProduct.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

                }
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblProductName.Text = "Search by P.I Code (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductName.Text = "Search by Product Name (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377)
                    {

                        txtReconciliationQuantity.Focus();
                    }
                    else
                    {
                        if (txtMrp.Enabled == true)
                        {
                            txtMrp.Focus();
                        }
                        else {

                            txtDay.Focus();
                        }
                    }
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
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
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
                        if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377)
                        {

                            txtReconciliationQuantity.Focus();
                        }
                        else
                        {
                            if (txtMrp.Enabled == true)
                            {
                                txtMrp.Focus();
                            }
                            else
                            {

                                txtDay.Focus();
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
        private void TxtOutwardQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtReconciliationQuantity.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                lvRack.Visible = false;
                varUpDownKey = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOutwardQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtReconciliationQuantity.Text).Trim() == "")
                {
                    epStockReconciliation.SetError(txtReconciliationQuantity, "Please enter outward quantity");
                    txtReconciliationQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter outward quantity", txtReconciliationQuantity, 5000);

                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtReconciliationQuantity.Text).Trim(), varDecimal);
                    txtReconciliationQuantity.Text = Qty;
                    epStockReconciliation.Clear();
                    txtReconciliationQuantity.BackColor = Color.White;
                }
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
                txtRemark.BackColor = Color.LemonChiffon;
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
                    epStockReconciliation.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epStockReconciliation.Clear();
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
                    dpStockRec.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOutwardQuantity_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTotalItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
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
                varDateChange = 0;
                udfnVocherno();
                grdStockadjustment.Rows.Clear();
                if (btnSave.Text == "Save as Draft")
                {
                    txtStockLocation.Text = "";
                    txtTotalItem.Text = Convert.ToString(grdStockadjustment.Rows.Count);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVocherno()
        {
            try
            { 
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpStockRec.Text + "',103)");
                        varResult = objspdservice.udfngetVoucherNo("381", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] varvalue = varResult.Split('~');
                        if (varResult != "")
                        {
                            txtTransactionNo.Text = varvalue[0];
                        }
                        else
                        {
                            varVoucherSkip = false;
                            if (varDateChange == 0)
                            {
                                udfnvoucheradd();
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
        public void udfnvoucheradd()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(75);
                objDServ.CloseConnection();
                txtTransactionNo.Text = "";
                if (varVoucherSkip == false)
                {
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        varVoucherSkip = true;
                        varClose = 1;
                        udfnclose();
                        MainForm.objCP_Settings = new CP_Settings();
                        MainForm.objCP_Settings.MdiParent = this.ParentForm;
                        MainForm.objCP_Settings.Show();
                    }
                    else { varVoucherSkip = true; }
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

        private void CmbTransactionType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void INV_GodownOutward_Load(object sender, EventArgs e)
        {
            try
            {

                dtStock.TableName = "TRN_StockTransfer_Product_AutoComplete";
                dtStock.Columns.Add("STK_PRID", typeof(int));
                dtStock.Columns.Add("STK_MRP", typeof(decimal));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(string));
                dtStock.Columns.Add("STK_QTY", typeof(string));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(int));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(int));
                dtStock.Columns.Add("STK_ProType", typeof(int));
                dtStock.Columns.Add("STK_Status", typeof(int));

                dtStockReconciliation.TableName = "TRN_Stock_Reconciliation";
                dtStockReconciliation.Columns.Add("STKRCPR_PRID", typeof(int));
                dtStockReconciliation.Columns.Add("STKRCPR_MRP", typeof(decimal));
                dtStockReconciliation.Columns.Add("STKRCPR_ExpiryDate", typeof(string));
                dtStockReconciliation.Columns.Add("STKRCPR_BatchNo", typeof(string));
                dtStockReconciliation.Columns.Add("STKRCPR_TranactionQty", typeof(decimal));
                dtStockReconciliation.Columns.Add("STKRCPR_RKID", typeof(int));


                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dpStockRec.MinDate = MainForm.pbFYStartDate;
                dpStockRec.MaxDate = MainForm.pbCurrentDate;
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    udfnTransactionData();
                    //dtpOutwardDate.MaxDate = DateTime.Now;
                    grdStockadjustment.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
                    //txtStockLocation.BackColor = Color.White;
                    lblProductName.Text = "Search by P.I Code (F11)";
                    VarSearchFlag = true;
                    if (varAJId == 0)
                    {
                        this.ActiveControl = txtStockLocation;
                    }
                    else
                    {
                        this.ActiveControl = txtProductName;
                        udfnEdit();
                    }
                }
                grdStockadjustment.Columns["clmOutward"].HeaderText = cmbTransactionType.Text + " Qty";
                UpdateComboBoxState();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        public void udfnTransactionData()
        {
            DataBind objDataBind = new DataBind();
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID = 116 ORDER BY MSTID DESC", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
            objDataBind = null;
        }

        private void DtpOutwardDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                varDateChange = 1;
                udfnVocherno();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSLocationValid()
        {
            try
            {
                /* Check purchase stock location is valid or not*/
                string varId_PurLocation = "0";
                if (txtStockLocation.Text == "")
                {
                    varId_PurLocation = "0";
                }
                else
                {
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text, 0, 0, 0, "", "", 0);
                    objDServ3.CloseConnection();
                    if (objDsPurLoc != null)
                    {
                        if (objDsPurLoc.Tables.Count > 0)
                        {
                            if (objDsPurLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                varStockLocationId = Convert.ToString(varId_PurLocation);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }


        private void TxtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    if (VarSearchFlag == true)
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    } 
                    txtMrp.Text = "";
                    txtExpiryDate.Text = "";
                    txtBatchNo.Text = "";
                    txtStockQuantity.Text = "";
                    txtReconciliationQuantity.Text = "";
                    lblQuantity.Text = ""; 
                    //lvproduct.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0 || txtProductName.Text == " ")
                    {
                        var ViewType = 51;
                        if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377)
                        {
                            ViewType = 74;
                        }

                        int varEntry = 0;
                        if (btnSave.Text == "Update") { varEntry = varAJId; }
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = ViewType;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraStockTransfer = dtStock;
                        objMR_Product.paraLocationId = Convert.ToInt32(varStockLocationId);
                        objMR_Product.paraId = varEntry;
                        if (VarSearchFlag == false)
                        {
                            objMR_Product.paraProductName = txtProductName.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraPicode = txtProductName.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377) // outward
                                    {
                                        DGV_FilterProduct.DataSource = objDs.Tables[0];
                                        DGV_FilterProduct.Columns["PRID"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                        DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                        DGV_FilterProduct.Columns["RK_ShortName"].Width = 70;
                                        DGV_FilterProduct.Columns["STK_MRP"].Width = 60;
                                        DGV_FilterProduct.Columns["STK_ExpiryDate"].Width = 90;
                                        DGV_FilterProduct.Columns["STK_BatchNo"].Width = 70;
                                        DGV_FilterProduct.Columns["STK_Qty"].Width = 70;
                                        DGV_FilterProduct.Columns["UT_Symbol"].Width = 50;
                                        DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                        DGV_FilterProduct.Columns["UTID"].Visible = false;
                                        DGV_FilterProduct.Columns["PRODUCTLIST"].Visible = false;
                                        DGV_FilterProduct.Columns["UT_Name"].Visible = false;
                                        DGV_FilterProduct.Columns["STK_RKID"].Visible = false;
                                        DGV_FilterProduct.Columns["STK_RKID"].Visible = false;
                                        DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                        DGV_FilterProduct.Columns["UT_Symbol"].Width = 60;
                                        DGV_FilterProduct.Columns["RK_ShortName"].DisplayIndex = 3;
                                        DGV_FilterProduct.Columns["STK_MRP"].DisplayIndex = 4;
                                        DGV_FilterProduct.Columns["STK_ExpiryDate"].DisplayIndex = 5;
                                        DGV_FilterProduct.Columns["STK_BatchNo"].DisplayIndex = 6;
                                        DGV_FilterProduct.Columns["STK_Qty"].DisplayIndex = 7;
                                        DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 8;
                                        DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                        DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                        DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                        DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                        DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
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

                                        DGV_FilterProduct.Width = 880;
                                    }
                                    else {
                                        // inward
                                        DGV_FilterProduct.DataSource = objDs.Tables[0];
                                        DGV_FilterProduct.Columns["PRID"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                        DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                        DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                        DGV_FilterProduct.Columns["UTID"].Visible = false;
                                        DGV_FilterProduct.Columns["UT_Symbol"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_BatchNo"].Visible = false;
                                        DGV_FilterProduct.Columns["Product Shelf Life"].Width = 120;
                                        DGV_FilterProduct.Columns["PR_ShelfLifeType"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_ShelfLife"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_ShelfLifeValue"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_BatchNoGeneration"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_MRPflag"].Visible = false;
                                        DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                        DGV_FilterProduct.Columns["Product Shelf Life"].Visible = false;
                                        DGV_FilterProduct.Columns["Retail Rate"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_RetailRate"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_PICode"].Width = 115;
                                        DGV_FilterProduct.Columns["UT_Symbol"].Width = 60;
                                        DGV_FilterProduct.Columns["Retail Rate"].Width = 80;
                                        DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 3;
                                        DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                        DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                        DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                        DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                        DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                        DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                                        DGV_FilterProduct.Visible = true;
                                        DGV_FilterProduct.Width = 520;
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
                epStockReconciliation.Clear();
            }
        }
         
        public void udfnListviewProduct()
        {
            try
            {
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377) //outward
                { 
                    varPRID = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varTamilname = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                    varUTID = DGV_FilterProduct.SelectedRows[0].Cells["UTID"].Value.ToString();
                    varRKID = DGV_FilterProduct.SelectedRows[0].Cells["STK_RKID"].Value.ToString();
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    varUnit = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    txtRack.Text = DGV_FilterProduct.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                    txtMrp.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                    txtExpiryDate.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                    txtBatchNo.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                    lblQuantity.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    txtStockQuantity.TextAlign = HorizontalAlignment.Right;
                    txtMrp.TextAlign = HorizontalAlignment.Right;

                    txtStockQuantity.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_Qty"].Value.ToString();
                }
                else
                {
                    varPRID = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString(); 
                    varTamilname = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                    varUTID = DGV_FilterProduct.SelectedRows[0].Cells["UTID"].Value.ToString();
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    varUnit = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    lblQuantity.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();

                    txtStockQuantity.Text = "";

                    varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNo"].Value.ToString();
                    varBatchNoGeneration = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNoGeneration"].Value.ToString();

                    varPrMRPFlag = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["PR_MRPflag"].Value);

                    if (varPrMRPFlag == "1")
                    {
                        varPrMRPFlag = "1";
                        txtMrp.ReadOnly = false;
                        txtMrp.Enabled = true;
                    } 
                    else
                    {
                        txtMrp.Text = "0";
                        varPrMRPFlag = "0";
                        txtMrp.ReadOnly = true;
                        txtMrp.Enabled = false;
                    }
                    if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                    {
                        txtBatchNo.Text = "";
                        txtBatchNo.Enabled = false;
                    }
                    else if (Convert.ToInt32(varBatchNo) == 72) //enabled
                    {
                        if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                        {
                            txtBatchNo.Enabled = true;
                            txtBatchNo.BackColor = Color.White;
                        }
                        else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                        {
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 14;
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(objMR_Master);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtBatchNo.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                    txtBatchNo.Enabled = false;
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
            finally
            {
                DGV_FilterProduct.Visible = false;
            }
        }
         

        private void INV_GodownOutward_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpStockLocation.Active = false;
                tpTransactionType.Active = false;
                tpStockLocation.Active = false;
                tpProduct.Active = false;
                tpOutwardQuantity.Active = false;
                tpRemark.Active = false;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
       

        private void TxtStockQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtStockQuantity.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void TxtExpiryDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtExpiryDate.TextAlign = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void DtpOutwardDate_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_inward_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdStockadjustment.CurrentCell.OwningColumn.Name == "clmOutward")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdStockadjustment.CurrentCell.OwningColumn.Name == "clmOutward")
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
                if (grdStockadjustment.CurrentCell.OwningColumn.Name == "clmOutward")
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


        private void TxtOutwardQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GrdGoodsOutward_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                decimal StockcellValue = Convert.ToDecimal(grdStockadjustment.CurrentRow.Cells["clmQty"].Value);
                decimal OutwardcellValue = Convert.ToDecimal(grdStockadjustment.CurrentRow.Cells["clmOutward"].Value);

                if (Convert.ToDecimal(OutwardcellValue) > Convert.ToDecimal(StockcellValue))
                {
                    grdStockadjustment.CurrentRow.Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //epGoodsOutward.SetError(DGV_inward, "Please enter valid outward qty");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter valid outward quantity", grdStockadjustment, 5000);
                    SPDataService objDServ = new SPDataService();
                    objDServ.CloseConnection();
                    varErrQty = 1;
                    //MessageBox.Show("Please Enter Valid Outward Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToString(OutwardcellValue) == "" || Convert.ToString(OutwardcellValue) == "0")
                {
                    grdStockadjustment.Rows[e.RowIndex].Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrQty = 1;
                }
                else
                {
                    grdStockadjustment.CurrentRow.Cells["clmOutward"].Style.BackColor = Color.PaleGreen;
                    varErrQty = 0;
                }
                int varDecimal = Convert.ToInt32(grdStockadjustment.CurrentRow.Cells["clmUTDecimal"].Value);

                string Qty = objValidation.udfnDecimal(Convert.ToString(grdStockadjustment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                grdStockadjustment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                object varEditQty = grdStockadjustment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                // Update the same column value in the DataTable
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377) //outward
                {
                    dtStock.Rows[e.RowIndex]["STK_QTY"] = varEditQty;
                }
                else
                {

                    dtStockReconciliation.Rows[e.RowIndex]["STKRCPR_TranactionQty"] = varEditQty;
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
                int varDecimal = Convert.ToInt32(grdStockadjustment.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdStockadjustment.CurrentCell.OwningColumn.Name == "clmOutward")
                {
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

                            txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
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

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListviewProduct();
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377)
                {

                    txtReconciliationQuantity.Focus();
                }
                else
                {
                    if (txtMrp.Enabled == true)
                    {
                        txtMrp.Focus();
                    }
                    else
                    { 
                        txtDay.Focus();
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
                DGV_FilterProduct.Visible = false;
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


        private void txtStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
                //udfnLvStockLocation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtStockLocation_Leave(object sender, EventArgs e)

        {
            try
            {
                txtStockLocation.BackColor = Color.White;
                if (txtStockLocation.Text == "")
                {
                    varStockLocationId = "0";
                    epStockReconciliation.SetError(txtStockLocation, "Please enter stock location");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location", txtStockLocation, 5000);
                }
                else
                {
                    epStockReconciliation.Clear();
                    txtStockLocation.BackColor = Color.White;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            //finally
            //{
            //    lvStockLocation.Visible = false;
            //}

        }

        private void txtStockLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtProductName.Text = "";
                txtRack.Text = "";
                txtMrp.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStockQuantity.Text = "";
                txtReconciliationQuantity.Text = "";
                lblQuantity.Text = "";
                udfnSLocationValid();
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0 || txtStockLocation.Text == " ")
                {
                    var ViewType = 26;
                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377)
                    {
                        ViewType = 23;
                    }
                    objDs = objspdservice.udfnStockLocationList(ViewType, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text, 0, 0, 0, "", "", 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_TName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(), };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvStockLocation.Items.Add(objList);
                                }
                                lvStockLocation.Visible = true;
                            }
                            else
                            {
                                lvStockLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvStockLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvStockLocation.Visible = false;
                    }
                }

                else
                {
                    lvStockLocation.Visible = false;
                    lvStockLocation.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvStockLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        txtProductName.Focus();
                        lvStockLocation.Visible = false;
                    }
                    else
                    {
                        lvStockLocation.Focus();
                    }
                    if (lvStockLocation.Items.Count > 0)
                    {
                        lvStockLocation.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377) //outward
                    {
                        txtProductName.Focus();
                    }
                    else {
                        if (txtRack.Enabled == true)
                        {
                            txtRack.Focus();
                        }
                        else { 
                            txtProductName.Focus();
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


        private void lvStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation();
                    if (txtRack.Enabled == true)
                    {
                        txtRack.Focus();
                    }
                    else
                    {
                        txtProductName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void lvStockLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvStockLocation();
                if (txtRack.Enabled == true)
                {
                    txtRack.Focus();
                }
                else
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
        public void udfnLvStockLocation()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    ListViewItem selectedItem = lvStockLocation.SelectedItems[0];
                    txtStockLocation.Text = selectedItem.SubItems[0].Text;
                    varStockLocationId = selectedItem.SubItems[2].Text;
                }
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 378) //inward
                { 
                    udfnRackcheck();
                }

                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvStockLocation.Visible = false;
            }
        }

        private void txtRack_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRack.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void txtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //txtBatchNo.Enabled = true;
                lvRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(varStockLocationId), 0, txtRack.Text.Trim(), 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RK_Description"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvRack.Items.Add(objList);
                                }
                                lvRack.Visible = true;
                                lvRack.Columns[1].Width = 200;
                            }
                        }
                    }
                }
                else
                {
                    lvRack.Visible = false;
                    lvRack.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtRack.Text == "")
                {
                    txtRack.Enabled = true;
                }
                DGV_FilterProduct.Visible = false;
                lvStockLocation.Visible = false;
                txtRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    
                        txtProductName.Focus(); 
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvRack.Items.Count == 0 || txtRack.Text == "")
                    {
                        txtRack.Focus();
                        lvRack.Visible = false;
                    }
                    else
                    {
                        lvRack.Focus();
                    }
                    if (lvRack.Items.Count > 0)
                    {
                        lvRack.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnRackAutocomplete(); 
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void lvRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnRackAutocomplete(); 
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnRackAutocomplete()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    varRKID = selectedItem.SubItems[2].Text;
                    //txtRackDescription.Text = selectedItem.SubItems[1].Text;
                    lvRack.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvRack.Visible = false;
            }
        }


        private void txtMrp_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMrp.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                DGV_FilterProduct.Visible = false;
                //DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                lvRack.Visible = false;
                //udfnListviewProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMrp.BackColor = Color.White;
                decimal varMRP = Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                string mrp = string.Format("{0:0.00}", varMRP);
                string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                txtMrp.Text = mrp;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMrp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtDay.Enabled == true)
                    {
                        txtDay.Focus();
                    }
                    else
                    {
                        if (txtBatchNo.Enabled == true)
                        {
                            txtBatchNo.Focus();
                        }
                        else
                        {
                            txtReconciliationQuantity.Focus();
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

        private void txtMrp_KeyPress(object sender, KeyPressEventArgs e)
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


        private void txtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtDay_KeyDown(object sender, KeyEventArgs e)
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
        private void txtDay_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDay.TextAlign = HorizontalAlignment.Right;
                if (txtDay.Text.Length == 2)
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
        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMonth.TextAlign = HorizontalAlignment.Right;
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

        private void txtMonth_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMonth.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMonth_KeyDown(object sender, KeyEventArgs e)
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
        private void txtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epStockReconciliation.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epStockReconciliation.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epStockReconciliation.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epStockReconciliation.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtYear_Enter(object sender, EventArgs e)
        {
            try
            {
                txtYear.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBatchNo.Enabled == true)
                    {
                        txtBatchNo.Focus();
                    }
                    else
                    {
                        txtReconciliationQuantity.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
        private void txtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epStockReconciliation.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epStockReconciliation.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epStockReconciliation.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epStockReconciliation.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtYear.TextAlign = HorizontalAlignment.Right;
                if (txtYear.Text.Length == 2)
                {
                    if (txtBatchNo.Enabled == false)
                    { txtReconciliationQuantity.Focus(); }
                    else
                    {
                        txtBatchNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBatchNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchNo.BackColor = Color.LemonChiffon;
                lvStockLocation.Visible = false;
                lvRack.Visible = false;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtBatchNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBatchNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void txtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReconciliationQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBatchNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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

        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
         

        private void GrdGoodsOutward_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOutwardQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtReconciliationQuantity.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DtpOutwardDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbTransactionType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void DGV_inward_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdStockadjustment.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdStockadjustment.ClearSelection();

            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave()
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                string varoriginator = ""; int ViewType = 0; varErrQty = 0;
                varoriginator = "Stock Reconciliation";
                bool TransId = Convert.ToBoolean(varAJId);
              
               
                epStockReconciliation.Clear();
                bool varErrorFlag = true;

                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epStockReconciliation.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    varErrorFlag = false;
                }
                if (Convert.ToString(txtStockLocation.Text).Trim() == "")
                {
                    epStockReconciliation.SetError(txtStockLocation, "Please enter stock location");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location", txtStockLocation, 5000);
                    varErrorFlag = false;
                }
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epStockReconciliation.SetError(cmbTransactionType, "Please select transaction type");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select transaction type", cmbTransactionType, 5000);
                    varErrorFlag = false;
                }
                if (grdStockadjustment.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrorFlag = false;
                }
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377)
                {
                    for (int i = 0; i < grdStockadjustment.Rows.Count; i++)
                    {
                        if (Convert.ToString(grdStockadjustment.Rows[i].Cells["clmOutward"].Value) == "" || Convert.ToDecimal(grdStockadjustment.Rows[i].Cells["clmOutward"].Value) == 0 || Convert.ToDecimal(grdStockadjustment.Rows[i].Cells["clmQty"].Value) < Convert.ToDecimal(grdStockadjustment.Rows[i].Cells["clmOutward"].Value))
                        {
                            varErrorFlag = false; varErrQty = 1;
                            grdStockadjustment.Rows[i].Cells["clmOutward"].Style.BackColor = Color.LightPink;
                        }
                        else
                        {
                            grdStockadjustment.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                            grdStockadjustment.Rows[i].Cells["clmOutward"].Style.BackColor = Color.PaleGreen;
                        }
                    }
                }
                    
                if (varErrQty == 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrorFlag = false;
                }
                 
                    varCompleteFlag = 1; 

                if (varErrorFlag == true)
                {
                    int type = Convert.ToInt32(cmbTransactionType.SelectedValue);

                   
                    udfntooltiphide();
                    epStockReconciliation.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();
                    TRN_Stock_Reconciliation_Products objTRNS_Stock_Reconciliation_Products = new TRN_Stock_Reconciliation_Products();

                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377)
                    { 
                        objTRNS_Stock_Reconciliation_Products.paraStockTransfer = dtStock;
                        objTRNS_Stock_Reconciliation_Products.paraStockReconciliation = null;
                    }
                    else {
                        objTRNS_Stock_Reconciliation_Products.paraStockTransfer = null; 
                        objTRNS_Stock_Reconciliation_Products.paraStockReconciliation = dtStockReconciliation;
                    }
                    if(varAJId != 0)
                    { 
                        ViewType = 1;
                    }
                    objTRNS_Stock_Reconciliation_Products.ViewType = ViewType;
                    objTRNS_Stock_Reconciliation_Products.ParaTransactionId = varAJId;
                    objTRNS_Stock_Reconciliation_Products.ParaCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNS_Stock_Reconciliation_Products.paraOutwardDate = dpStockRec.Text;
                    objTRNS_Stock_Reconciliation_Products.paraTransferType = type;
                    objTRNS_Stock_Reconciliation_Products.paraRemarks = txtRemark.Text.Trim();
                    objTRNS_Stock_Reconciliation_Products.paraSLID = Convert.ToInt32(varStockLocationId);
                    objTRNS_Stock_Reconciliation_Products.paraOriginator = varoriginator;
                    objTRNS_Stock_Reconciliation_Products.ParaFlag = varCompleteFlag;
                    objTRNS_Stock_Reconciliation_Products.paraStatusId = 14;
                    result = objspdservice.udfnStockConciliation(objTRNS_Stock_Reconciliation_Products);
                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (result.Split('~')[0] == "3")
                    {


                        if (result.Split('~')[0] != "1")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ActiveControl = txtProductName;
                            MainForm.objINV_StockAdjustmentList.udfnList();
                            udfnClear();
                            this.Close();
                        }
                    }
                    else if (result.Split('~')[0] == "5")
                    {

                        MessageBox.Show(result.Split('~')[1] + "( " + result.Split('~')[2] + " )", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else { 
                            MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    }

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
            finally
            {
                grdStockadjustment.ClearSelection();
            }
        }
        public void udfnClear()
        {
            try
            {
                btnSave.Enabled = true;
                cmbConcern.Text = "";
                txtTransactionNo.Text = "";
                txtStockLocation.Text = "";
                cmbTransactionType.Text = "";
                lblQuantity.Text = "";
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
                epStockReconciliation.Clear();
                cmbConcern.BackColor = Color.White;
                tpConcern.Active = false;
                cmbTransactionType.BackColor = Color.White;
                tpTransactionType.Active = false;
                txtStockLocation.BackColor = Color.White;
                tpStockLocation.Active = false;
                //txtProduct.BackColor = Color.White;
                tpProduct.Active = false;
                txtReconciliationQuantity.BackColor = Color.White;
                tpOutwardQuantity.Active = false; 
                 
                tpExpiryDate.Active = false;
                tpmrp.Active = false;
                tpBatchNo.Active = false;
                tprack.Active = false;
                tpTransactionType.Active = false;
                txtProductName.BackColor = Color.White;
                txtMrp.BackColor = Color.White;
                txtExpiryDate.BackColor = Color.White;
                txtBatchNo.BackColor = Color.White;
                txtReconciliationQuantity.BackColor = Color.White;

                txtMonth.BackColor = Color.White;
                txtDay.BackColor = Color.White;
                txtYear.BackColor = Color.White;


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnProductClear();
                txtStockLocation.Text = "";
                varStockLocationId = "0";
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377) //outward
                {
                    txtExpiryDate.Visible = true;
                    txtMonth.Visible = false;
                    txtDay.Visible = false;
                    txtYear.Visible = false;
                     
                    txtRack.ReadOnly = true;  
                    txtMrp.ReadOnly = true;
                    txtBatchNo.ReadOnly = true; 
                    txtRack.Enabled = false; 
                    txtMrp.Enabled = false;
                    txtBatchNo.Enabled = false;

                    txtRack.BackColor = SystemColors.Control;
                    txtMrp.BackColor = SystemColors.Control;
                    txtBatchNo.BackColor = SystemColors.Control;
                     
                }
                else
                {
                    txtExpiryDate.Visible = false;
                    txtMonth.Visible = true;
                    txtDay.Visible = true;
                    txtYear.Visible = true; 

                    txtRack.ReadOnly = false; 
                    txtMrp.ReadOnly = false;
                    txtBatchNo.ReadOnly = false;
                    txtRack.Enabled = true; 
                    txtMrp.Enabled = true;
                    txtBatchNo.Enabled = true;

                     
                    txtRack.BackColor = Color.White;
                    txtMrp.BackColor = Color.White;
                    txtBatchNo.BackColor = Color.White; 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductClear()
        {
            try
            {
                txtProductName.Text = "";
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377)
                {
                    txtRack.Text = "";
                    varRKID = "";
                } 
                    txtMrp.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStockQuantity.Text = "";
                txtReconciliationQuantity.Text = "";
                varPRID = "";
                varPICode = "";
                varUTID = "";
                lblQuantity.Text = "";
                 
                txtMonth.Text = "";
                txtDay.Text = "";
                txtYear.Text = "";

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_inward_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0, varRKID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (grdStockadjustment.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdStockadjustment.SelectedRows[0].Cells["clmPRID"].Value);
                                //varMRP = Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmmrp"].Value);
                                varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdStockadjustment.SelectedRows[0].Cells["clmmrp"].Value)));
                                varExpiryDate = Convert.ToString(grdStockadjustment.SelectedRows[0].Cells["clmExpirydate"].Value);
                                varBatchNo = Convert.ToString(grdStockadjustment.SelectedRows[0].Cells["clmBatchNo"].Value);
                                varRKID = Convert.ToInt32(grdStockadjustment.SelectedRows[0].Cells["clmRKID"].Value);
                                grdStockadjustment.Rows.RemoveAt(this.grdStockadjustment.SelectedRows[0].Index);
                                for (int i = 0; i < grdStockadjustment.RowCount; i++)
                                {
                                    grdStockadjustment.Rows[i].Cells["clmdsno"].Value = i + 1;
                                }
                                for (int i = 0; i < dtStock.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID) && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtStock.Rows[i]["STK_MRP"]))) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToInt32(dtStock.Rows[i]["STK_Source_RKID"]) == Convert.ToInt32(varRKID))
                                    {
                                        dtStock.Rows[i].Delete();
                                        dtStock.AcceptChanges();
                                    }
                                }
                                for (int i = 0; i < dtStockReconciliation.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtStockReconciliation.Rows[i]["STKRCPR_PRID"]) == Convert.ToInt32(varProductID) && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtStockReconciliation.Rows[i]["STKRCPR_MRP"]))) == varMRP && Convert.ToString(dtStockReconciliation.Rows[i]["STKRCPR_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStockReconciliation.Rows[i]["STKRCPR_BatchNo"]) == varBatchNo && Convert.ToInt32(dtStockReconciliation.Rows[i]["STKRCPR_RKID"]) == Convert.ToInt32(varRKID))
                                    {
                                        dtStockReconciliation.Rows[i].Delete();
                                        dtStockReconciliation.AcceptChanges();
                                    }
                                }
                                UpdateComboBoxState();
                            }
                            break;
                    }
                }

                varChangeFlag = false;
            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtTotalItem.Text = Convert.ToString(grdStockadjustment.Rows.Count);
                if (grdStockadjustment.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                    txtStockLocation.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                    txtStockLocation.Enabled = true;
                    txtStockLocation.BackColor = Color.White;
                    cmbConcern.BackColor = Color.White;

                }
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                varErrorFlag = true; pbDateflag = 0;
                if (txtProductName.Text == "")
                {
                    epStockReconciliation.SetError(txtProductName, "Please enter product name");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductName, 5000);
                    varErrorFlag = false;
                }
                if (txtRack.Text == "")
                {
                    epStockReconciliation.SetError(txtRack, "Please enter the rack name");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter the rack name", txtRack, 5000);
                    varErrorFlag = false;
                }
                if (txtReconciliationQuantity.Text == "")
                {
                    epStockReconciliation.SetError(txtReconciliationQuantity, "Please enter quantity");
                    txtReconciliationQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter quantity", txtReconciliationQuantity, 5000);
                    varErrorFlag = false;
                }

                if (txtStockLocation.Text.Trim() == "")
                {
                    txtStockLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epStockReconciliation.SetError(txtStockLocation, "Please enter location.");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location.", txtStockLocation, 5000);
                    varErrorFlag = false;
                }

                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 378) //inward check
                {
                    if ((txtMrp.Text.Trim() == "" || Convert.ToDecimal(txtMrp.Text) == 0) && varPrMRPFlag == "1")
                    {
                        txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epStockReconciliation.SetError(txtMrp, "Please enter MRP.");
                        tpmrp.ShowAlways = true;
                        tpmrp.Show("Please enter MRP.", txtMrp, 5000);
                        varErrorFlag = false;
                    }
                    if (expirydateFlag == 1)
                    {
                        if (txtMonth.Text.Trim() == "")
                        {
                            txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            epStockReconciliation.SetError(txtMonth, "Please enter month.");
                            varErrorFlag = false;
                        }
                        if (txtYear.Text.Trim() == "")
                        {
                            txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            epStockReconciliation.SetError(txtYear, "Please enter year.");
                            varErrorFlag = false;
                        }
                    }

                    /* Check location is valid or not*/
                    if (txtStockLocation.Text != "")
                    {
                        string varLocationId = "0";
                        DataSet objDsLocation = new DataSet();
                        SPDataService objDServ3 = new SPDataService();
                        objDsLocation = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        objDServ3.CloseConnection();
                        if (objDsLocation != null)
                        {
                            if (objDsLocation.Tables.Count > 0)
                            {
                                if (objDsLocation.Tables[0].Rows.Count > 0)
                                {
                                    varLocationId = Convert.ToString(objDsLocation.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        varStockLocationId = Convert.ToString(varLocationId);
                        if (varLocationId == "0" || varLocationId == "-1")
                        {
                            epStockReconciliation.SetError(txtStockLocation, "Please select valid location.");
                            txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpStockLocation.ShowAlways = true;
                            tpStockLocation.Show("Please select location.", txtStockLocation, 5000);
                            varErrorFlag = false;
                        }
                    }
                    if (txtRack.Text.Trim() != "" && txtRack.Text.Trim() != "None" && txtRack.Text.Trim() != "none")
                    {
                        /*check location have a rack or not*/
                        string varId_PurchaseRack = "0";
                        string varId_PurchaseRackCount = "0";
                        DataSet objDsPurchaseRack = new DataSet();
                        SPDataService objDServ6 = new SPDataService();
                        objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varStockLocationId), 0, txtRack.Text.Trim(), 0, 0);
                        objDServ6.CloseConnection();
                        if (txtRack.Text.Trim() != "")
                        {
                            if (varStockLocationId != "0")
                            {
                                if (objDsPurchaseRack != null)
                                {
                                    if (objDsPurchaseRack.Tables.Count > 0)
                                    {
                                        if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                        {
                                            varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                        }
                                        if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                        {
                                            varId_PurchaseRackCount = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                        }
                                        if (varId_PurchaseRackCount == "0")
                                        { varId_PurchaseRack = "0"; }
                                    }
                                }
                                varRKID = Convert.ToString(varId_PurchaseRack);
                                if (Convert.ToInt32(varId_PurchaseRackCount) > 0)
                                {
                                    if (Convert.ToInt32(varId_PurchaseRack) < 0 || varId_PurchaseRack == "-1")
                                    {
                                        epStockReconciliation.SetError(txtRack, "Please enter valid rack.");
                                        txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                                        tprack.ShowAlways = true;
                                        tprack.Show("Please enter valid rack.", txtRack, 5000);
                                        varErrorFlag = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (varStockLocationId != "0")
                            {
                                if (objDsPurchaseRack != null)
                                {
                                    if (objDsPurchaseRack.Tables.Count > 0)
                                    {
                                        if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                        {
                                            varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                        }
                                    }
                                }
                                varRKID = Convert.ToString(varId_PurchaseRack);
                                if (Convert.ToInt32(varId_PurchaseRack) > 0)
                                {
                                    epStockReconciliation.SetError(txtRack, "Please enter rack.");
                                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tprack.ShowAlways = true;
                                    tprack.Show("Please enter rack.", txtRack, 5000);
                                    varErrorFlag = false;
                                }
                                if (varId_PurchaseRack == "0")
                                {
                                    txtRack.Text = "None";
                                    txtRack.Enabled = false;
                                    varRKID = "0";
                                }
                                else
                                {
                                    txtRack.Enabled = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        txtRack.Text = "None";
                        varRKID = "0";
                    }
                    udfnExpiryDate();
                    
                    string varMRP = "", varNewExpiryDate = "", varBatch = "", varSLID = "", varmrptxt = "";
                     
                    if (txtMrp.Text == "") { varmrptxt = "0"; }
                    else
                    { varmrptxt = txtMrp.Text.Trim(); }
                    varmrptxt = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(varmrptxt), 2, MidpointRounding.AwayFromZero));
                    for (int i = 0; i < grdStockadjustment.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(varPRID) == Convert.ToInt32(grdStockadjustment.Rows[i].Cells["ClmPRID"].Value))
                        {
                            varMRP = Convert.ToString(grdStockadjustment.Rows[i].Cells["clmmrp"].Value).Trim();
                            varNewExpiryDate = Convert.ToString(grdStockadjustment.Rows[i].Cells["clmExpiryDate"].Value).Trim();
                            varBatch = Convert.ToString(grdStockadjustment.Rows[i].Cells["clmBatchNo"].Value).Trim();
                            varSLID = varStockLocationId;
                            varRKID = Convert.ToString(grdStockadjustment.Rows[i].Cells["clmRKID"].Value).Trim();
                            if (varmrptxt == varMRP && varExpiryDate == varNewExpiryDate && txtBatchNo.Text.Trim() == varBatch)
                            {
                                if (varStockLocationId.Trim() == varSLID && varRKID.Trim() == varRKID)
                                {
                                    SPDataService objDServ = new SPDataService();
                                    DataSet objDS = new DataSet();
                                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    string varMessage = objDServ.udfnGetMessages(93);
                                    objDServ.CloseConnection();
                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    varErrorFlag = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (txtStockQuantity.Text == "")
                    {
                        epStockReconciliation.SetError(txtStockQuantity, "Please enter stock quantity");
                        txtReconciliationQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpOutwardQuantity.ShowAlways = true;
                        tpOutwardQuantity.Show("Please enter stock quantity", txtStockQuantity, 5000);
                        varErrorFlag = false;
                    }
                }

                if (varErrorFlag == true && pbDateflag == 0)
                {
                    int varflag = 0;

                    if (varflag == 0)
                    {
                        decimal varavlstk = 0;

                        if (txtStockQuantity.Text != "") 
                        {
                            varavlstk =  Convert.ToDecimal(txtStockQuantity.Text);
                        }
                       
                        if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377 )
                        {
                            if (Convert.ToDecimal(txtReconciliationQuantity.Text) > varavlstk || Convert.ToDecimal(txtReconciliationQuantity.Text) == 0) //outward
                            {
                                txtReconciliationQuantity.Focus();
                                epStockReconciliation.SetError(txtReconciliationQuantity, "Please enter a valid  quantity");
                                txtReconciliationQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpOutwardQuantity.ShowAlways = true;
                                tpOutwardQuantity.Show("Please enter a valid  quantity", txtReconciliationQuantity, 5000);
                                return;
                            }
                        } 
                            if (txtReconciliationQuantity.Text != "")
                            {
                                string Qty = objValidation.udfnDecimal((txtReconciliationQuantity.Text).Trim(), varDecimal);
                                txtReconciliationQuantity.Text = Qty;

                            }

                        if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 377) //outward
                        { 
                            grdStockadjustment.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdStockadjustment.Rows.Add(grdStockadjustment.Rows.Count + 1, varPRID, varPICode, (varTamilname), varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtReconciliationQuantity.Text), varUnit, varUTID, varDecimal); 
                        }
                        else
                        { 
                            grdStockadjustment.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdStockadjustment.Rows.Add(grdStockadjustment.Rows.Count + 1, varPRID, varPICode, (varTamilname), varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (varExpiryDate).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtReconciliationQuantity.Text), varUnit, varUTID, varDecimal);
                        }

                         


                        dtStock.Rows.Add(varPRID, string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtMrp.Text.Trim()))), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), varUTID, (txtReconciliationQuantity.Text), varRKID, varDestSLID, varDestRKID, 0);



                            dtStockReconciliation.Rows.Add(varPRID, string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtMrp.Text.Trim()))), (varExpiryDate).Trim(), (txtBatchNo.Text).Trim(), (txtReconciliationQuantity.Text), varRKID);


                            txtTotalItem.Text = Convert.ToString(grdStockadjustment.Rows.Count);
                            //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                            grdStockadjustment.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockadjustment.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockadjustment.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockadjustment.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            grdStockadjustment.Columns["clmOutward"].HeaderText = cmbTransactionType.Text + " Qty";

                            udfnProductClear();
                            txtProductName.Focus();
                            UpdateComboBoxState();
                        
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(70);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    varChangeFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdStockadjustment.Rows.Count.ToString();
                grdStockadjustment.ClearSelection();
                if (grdStockadjustment.Rows.Count > 0)
                {
                    txtStockLocation.Enabled = false;
                    cmbConcern.Enabled = false;
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                }
                else
                {
                    //txtStockLocation.BackColor =Color.White;
                    cmbConcern.Enabled = true;
                    txtStockLocation.Enabled = true;
                }

                txtProductName.Focus();
                //DGV_inward.Sort(DGV_inward.Columns["clmpicode"], ListSortDirection.Ascending);

            }

        }

        public void udfnEdit()
        {
            try
            {
                if (varAJId != 0)
                {
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    int ViewType = 1;
                    TRN_Stock_Reconciliation_Products objTRNG_Stock_Reconciliation_Products = new TRN_Stock_Reconciliation_Products();
                    objTRNG_Stock_Reconciliation_Products.ViewType = ViewType;
                    objTRNG_Stock_Reconciliation_Products.ParaTransactionId = Convert.ToInt32(varAJId);
                    objDs = objdserv.udfnStockConciliationList(objTRNG_Stock_Reconciliation_Products);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["STKRC_COMID"].ToString();
                            varTransType = objDs.Tables[0].Rows[0]["STKRC_TransactionType"].ToString();
                            cmbTransactionType.Text = objDs.Tables[0].Rows[0]["Transaction Type"].ToString();
                            dpStockRec.Text = objDs.Tables[0].Rows[0]["STKRC_Date"].ToString();
                            txtTransactionNo.Text = objDs.Tables[0].Rows[0]["STKRC_No"].ToString();
                            varStockLocationId = objDs.Tables[0].Rows[0]["STKRC_SLID"].ToString();
                            txtStockLocation.Text = objDs.Tables[0].Rows[0]["Stock Location"].ToString();
                            txtRemark.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString(); 
                            if (Convert.ToString(objDs.Tables[0].Rows[0]["RackCount"]) == "0")
                            { txtRack.Enabled = false; txtRack.ReadOnly = true; txtRack.Text = "None"; }
                        }

                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                grdStockadjustment.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                grdStockadjustment.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["STKRCPR_ReqQty"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKRCPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]));
                                 


                                dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKRCPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), 0, 0, 0);

                                dtStockReconciliation.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKRCPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]));

                                grdStockadjustment.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStockadjustment.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStockadjustment.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStockadjustment.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //DGV_inward.Rows.Add(DGV_inward.Rows.Count + 1, varPRID, varPICode, (txtProduct.Text).Trim(), varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtOutwardQuantity.Text).Trim(), varUnit, varUTID);
                                //DGV_inward.Columns[10].ReadOnly = false;
                            }
                        }
                    }

                    cmbConcern.Enabled = false;
                    dpStockRec.Enabled = false;
                    txtTransactionNo.Enabled = false;
                    txtStockLocation.Enabled = false;
                    cmbTransactionType.Enabled = false;
                    lvStockLocation.Visible = false;
                    epStockReconciliation.Clear();
                    udfntooltiphide();
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                    if (varSTSID == 26)
                    {
                        txtProductName.Enabled = false;
                        txtReconciliationQuantity.Enabled = false;
                        txtRemark.Enabled = false; 
                        btnSave.Enabled = false; 
                        btnAdd.Enabled = false;
                        txtProductName.BackColor = Color.White;
                        this.ActiveControl = btnClose;
                        epStockReconciliation.Clear();
                        grdStockadjustment.ReadOnly = true;
                        grdStockadjustment.Columns["clmRemove"].Visible = false;
                        udfntooltiphide();
                        txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtReconciliationQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                        DGV_inward_DataBindingComplete(grdStockadjustment, args);
                        for (int i = 0; i < grdStockadjustment.Rows.Count; i++)
                        {
                            ((DataGridViewImageCell)grdStockadjustment.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
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
                grdStockadjustment.ClearSelection();
                txtTotalItem.Text = Convert.ToString(grdStockadjustment.Rows.Count);
                if (txtRack.Enabled == true)
                {
                    txtRack.Focus();
                }
                else { txtProductName.Focus(); }
            }
        }
        private void UpdateComboBoxState()
        {
            try
            {
                if (grdStockadjustment.Rows.Count == 0)
                {
                    cmbTransactionType.Enabled = true;
                }
                else
                {
                    cmbTransactionType.Enabled = false;
                }
            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnExpiryDate()
        {
            try
            {
                string varDay = "", varMonth = "", varYear = "", varDate = ""; string varDcDay = "", varDcMonth = "", varDcYear = "", varExpiry = "";
                int varExpiryDays = 0; int error = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (txtDay.Text.Trim() == "")
                {
                    varDay = "01";
                }
                else
                {
                    if (Convert.ToInt64(txtDay.Text) > 31 || Convert.ToInt64(txtDay.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(95);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (txtDay.Text.Length == 1)
                        { txtDay.Text = 0 + txtDay.Text.Trim(); }
                        varDay = txtDay.Text.Trim();
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
                        return;
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
                        return;
                    }
                }
                if (pbDateflag == 0)
                {
                    varMonth = Convert.ToString(txtMonth.Text.Trim());
                    varYear = 20 + Convert.ToString(txtYear.Text.Trim());
                    if (txtDay.Text.Trim() == "")
                    {
                        varDate = varDay + "/" + varMonth + "/" + varYear;
                        MR_Master objMR_Master1 = new MR_Master();
                        objMR_Master1.ViewType = 5;
                        objMR_Master1.paraDate = varDate;
                        objDS = objDServ.udfnMaster(objMR_Master1);
                        objDServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varExpiryDate = objDS.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();
                        }
                    }
                    else
                    {
                        varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 10;
                    objMR_Master.paraDate = dpStockRec.Text.Trim();
                    objMR_Master.ParaExpiryDate = varExpiryDate;
                    objMR_Master.paraProductId = Convert.ToInt32(varPRID);
                    objDS = objDServ.udfnMaster(objMR_Master);
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
                           
                        }
                    }
                }
                if (error == 1)
                {
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    string varMessage = objDServ.udfnGetMessages(94);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnRackcheck()
        {
            try
            {
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
                string varId_PurchaseRackCount = "0";
                DataSet objDsPurchaseRack = new DataSet();
                SPDataService objDServ6 = new SPDataService();
                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varStockLocationId), 0, txtRack.Text.Trim(), 0, 0);
                objDServ6.CloseConnection();
                if (txtRack.Text.Trim() != "")
                {
                    if (varStockLocationId != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                }
                                if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                {
                                    varId_PurchaseRackCount = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                }
                                if (varId_PurchaseRackCount == "0")
                                { varId_PurchaseRack = "0"; }
                            }
                        }
                        varRKID = Convert.ToString(varId_PurchaseRack);
                        if (Convert.ToInt32(varId_PurchaseRackCount) > 0)
                        {
                            if (Convert.ToInt32(varId_PurchaseRack) < 0 || varId_PurchaseRack == "-1")
                            {
                                epStockReconciliation.SetError(txtRack, "Please enter valid rack.");
                                txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                                tprack.ShowAlways = true;
                                tprack.Show("Please enter valid rack.", txtRack, 5000);
                            }
                        }
                    }
                }
                else
                {
                    if (varStockLocationId != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                }
                            }
                        } 
                        if (varId_PurchaseRack == "0")
                        {
                            txtRack.Text = "None";
                            txtRack.Enabled = false;
                            varRKID = "0";
                        }
                        else
                        {
                            txtRack.Enabled = true;
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
}




