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
    public partial class INV_StockJournal_Conversion : Form
    {

        public INV_StockJournal_Conversion()
        {
            InitializeComponent();
        }
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpExpiryDate = new ToolTip();
        private ToolTip tpMrp = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpOutwardQuantity = new ToolTip();
        private ToolTip tpRemark = new ToolTip();
        private ToolTip tpTotalItem = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tprack = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        public int varCompleteFlag = 0;
        public string varStockLocationId = "", varTamilname = "", varPICode = "", varPICodeChild = "", varTamilnameChild = "";
        public string varStockApplicable = "";
        public int varErrQty = 0;
        public int varCloseFlag = 0;
        public int varUpDownKey = 0;
        public int varAJId = 0;
        string result = "";
        public int varSTSID = 0;
        public int varUpdate = 0, VarUpdateFlag = 0;
        public int varCompanyId = 0, varDestSLID = 0, varDestRKID = 0, varStatusId = 0, varDecimal = 0, varDecimalChild = 0;
         

        bool varVoucherSkip = false;
        private bool varErrorFlag;
        public bool varChangeFlag = true;
        public string vargroupcode;
        public String pbFormStatus;
        public bool VarSearchFlag = true;
        public int varClose = 0, varDateChange = 0, varparentflag = 0;

        DataTable dtStock = new DataTable(), dtConvertedProduct = new DataTable();
        string varProductID = "", varMRP = "", varExpiryDate = "", varBatchNo = "", varRackId = "", varPrMRPFlag = "", varBatchNoGeneration = "";

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListviewProduct(sender, e);
                txtOutwardQuantity.Focus();
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

                            txtOutwardProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtOutwardProduct.Focus();
                            txtOutwardProduct.SelectionStart = txtOutwardProduct.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtOutwardProduct.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtOutwardProduct.Focus();
                            txtOutwardProduct.SelectionStart = txtOutwardProduct.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewProduct(sender, e);
                                    DGV_FilterProduct.Visible = false;
                                    txtOutwardProduct.Focus();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                varErrorFlag = true;
                if (txtOutwardProduct.Text == "")
                {
                    epStockConvertion.SetError(txtOutwardProduct, "Please enter product name");
                    txtOutwardProduct.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtOutwardProduct, 5000);
                    varErrorFlag = false;
                }
                if (txtStockQuantity.Text == "")
                {
                    epStockConvertion.SetError(txtStockQuantity, "Please enter stock quantity");
                    txtStockQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter stock quantity", txtStockQuantity, 5000);
                    varErrorFlag = false;
                }
                if (txtOutwardQuantity.Text == "")
                {
                    epStockConvertion.SetError(txtOutwardQuantity, "Please enter outward quantity");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter outward quantity", txtOutwardQuantity, 5000);
                    varErrorFlag = false;
                }

                string varMRP = "", varNewExpiryDate = "", varBatch = "", varSLID = "", varmrptxt = "", varRKID="";
                for (int i = 0; i < grdOutward.Rows.Count; i++)
                {
                    if (Convert.ToInt32(lblPRID.Text) == Convert.ToInt32(grdOutward.Rows[i].Cells["clmPRID"].Value))
                    {
                        varMRP = Convert.ToString(grdOutward.Rows[i].Cells["clmmrp"].Value).Trim();
                        varNewExpiryDate = Convert.ToString(grdOutward.Rows[i].Cells["clmExpiryDate"].Value).Trim();
                        varBatch = Convert.ToString(grdOutward.Rows[i].Cells["clmBatchNo"].Value).Trim();
                        varSLID = lblOutwardLocationId.Text;
                        varRKID = Convert.ToString(grdOutward.Rows[i].Cells["clmRKID"].Value).Trim();
                        if (lblMRP.Text == varMRP && lblExpiryDate.Text == varNewExpiryDate && varBatch == lblBatchNo.Text)
                        {
                            if (lblOutwardLocationId.Text.Trim() == varSLID && lblOutwardRackId.Text.Trim() == varRKID)
                            {
                                SPDataService objDServ = new SPDataService();
                                DataSet objDS = new DataSet();
                                txtOutwardProduct.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                string varMessage = objDServ.udfnGetMessages(93);
                                objDServ.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varErrorFlag = false;
                            }
                        }
                    }
                }
                if (varparentflag == 3)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(167);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrorFlag = false; 
                }
                if (varErrorFlag == true)
                {
                    int varflag = 0;

                    if (varflag == 0)
                    {
                        if (Convert.ToDecimal(txtOutwardQuantity.Text) > Convert.ToDecimal(txtStockQuantity.Text) || Convert.ToDecimal(txtOutwardQuantity.Text) == 0)
                        {
                            txtOutwardQuantity.Focus();
                            epStockConvertion.SetError(txtOutwardQuantity, "Please enter a valid outward quantity");
                            txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpOutwardQuantity.ShowAlways = true;
                            tpOutwardQuantity.Show("Please enter a valid outward quantity", txtOutwardQuantity, 5000);
                        }
                        else
                        {
                            if (txtOutwardQuantity.Text != "")
                            {
                                string Qty = objValidation.udfnDecimal((txtOutwardQuantity.Text).Trim(), varDecimal);
                                txtOutwardQuantity.Text = Qty;

                            }
                            grdOutward.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdOutward.Rows.Add(grdOutward.Rows.Count + 1, lblPRID.Text, varPICode, (varTamilname), lblOutwardStockDetail.Text, lblOutwardLocationId.Text, lblOutwardRackId.Text, (lblMRP.Text).Trim(), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtOutwardQuantity.Text), lblQuantity.Text, lblUnitId.Text, lblUtDecimal.Text);

                            dtStock.Rows.Add(lblPRID.Text, string.Format("{0:G29}", decimal.Parse(Convert.ToString(lblMRP.Text.Trim()))), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), lblUnitId.Text, (txtOutwardQuantity.Text), lblOutwardRackId.Text, lblOutwardLocationId.Text, 0, 0,0, grdOutward.Rows.Count);

                            if (varparentflag == 2)
                            {
                                udfnParentLoad();
                                udfnProductClear();
                            }
                            else
                            { 
                                txtOutwardProduct.Enabled = false;
                                txtOutwardQuantity.Enabled = false;
                                btnAdd.Enabled = false; 
                                cmbInward_SelectedIndexChanged(sender, e);
                            }
                            //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                            grdOutward.Columns["ClmBatch"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            txtInwardQty.Text = txtOutwardQuantity.Text;
                            txtOutwardProduct.Focus();
                        }
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
                grdOutward.ClearSelection();
                grdInward.ClearSelection();
                if (grdOutward.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                    txtPStockLocation.Enabled = true;
                } 
            }
        }

        private void INV_StockJournal_Conversion_Load(object sender, EventArgs e)
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
                dtStock.Columns.Add("STK_SNO", typeof(int));
                

                dtConvertedProduct.TableName = "TRN_Stock_Journal_Products";
                dtConvertedProduct.Columns.Add("STKJPR_PRID", typeof(int));
                dtConvertedProduct.Columns.Add("STKJPR_MRP", typeof(decimal));
                dtConvertedProduct.Columns.Add("STKJPR_ExpiryDate", typeof(string));
                dtConvertedProduct.Columns.Add("STKJPR_BatchNo", typeof(string));
                dtConvertedProduct.Columns.Add("STKJPR_TranactionQty", typeof(decimal));
                dtConvertedProduct.Columns.Add("STKJPR_RKID", typeof(int));
                dtConvertedProduct.Columns.Add("STKJPR_SLID", typeof(int));
                dtConvertedProduct.Columns.Add("STKJPR_SNO", typeof(int));

                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dtpConvertDate.MinDate = MainForm.pbFYStartDate;
                dtpConvertDate.MaxDate = MainForm.pbCurrentDate;
                if (varAJId != 0)
                {
                    udfnEdit(sender, e);

                    grdOutward.Columns["clmOutward"].ReadOnly = true;
                }
                else
                {
                    grdOutward.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
                }

                this.ActiveControl = txtOutwardProduct;
                txtInwardQty.BackColor = SystemColors.Control;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOutwardProduct_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (varUpDownKey == 0)
                {
                    if (VarSearchFlag == true)
                    {
                        txtOutwardProduct.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        txtOutwardProduct.CharacterCasing = CharacterCasing.Normal;
                    }
                    //lvproduct.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtOutwardProduct.Text.Length > 0 || txtOutwardProduct.Text == " ")
                    {

                        DataTable dtStockClone = dtStock.DefaultView.ToTable(false, "STK_PRID", "STK_MRP", "STK_ExpiryDate", "STK_BatchNo", "STK_UTID", "STK_QTY", "STK_Source_RKID", "STK_Dest_SLID", "STK_Dest_RKID", "STK_ProType", "STK_Status");
                        var ViewType = 80;
                        int varEntry = 1;
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = ViewType;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraProductName = txtOutwardProduct.Text;
                        objMR_Product.paraType = varEntry; 
                        objMR_Product.paraStockTransfer = dtStockClone;
                        objMR_Product.paraUserLocations = MainForm.pbUserMappedLocationIds;

                        objMR_Product.paraPicode = txtOutwardProduct.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = true;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    DGV_FilterProduct.Columns["slid"].Visible = false; 
                                    DGV_FilterProduct.Columns["SL_EName"].Width = 120;
                                    DGV_FilterProduct.Columns["RK_ShortName"].Width = 70;
                                    DGV_FilterProduct.Columns["STK_MRP"].Width = 60;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].Width = 90;
                                    DGV_FilterProduct.Columns["STK_BatchNo"].Width = 70;
                                    DGV_FilterProduct.Columns["STK_Qty"].Width = 70;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2;
                                    DGV_FilterProduct.Columns["UTID"].Visible = false;
                                    DGV_FilterProduct.Columns["PRODUCTLIST"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Name"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_UPP"].Visible = false;
                                    DGV_FilterProduct.Columns["STK_RKID"].Visible = false;
                                    DGV_FilterProduct.Columns["STK_RKID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["ParentFlag"].Visible = false;
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
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex =11;
                                    DGV_FilterProduct.Columns["Retail Rate"].DisplayIndex = 12;
                                    DGV_FilterProduct.Columns["UPP"].DisplayIndex = 13;
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
                                    DGV_FilterProduct.Columns["SL_EName"].HeaderText = "Stock Location";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["ParentChild"].Visible = false;
                                    
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["STK_MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["STK_Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["MFD Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["Retail Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Visible = true;

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
                epStockConvertion.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void INV_StockJournal_Conversion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                txtOutwardQuantity.TextAlign = HorizontalAlignment.Right;
                if (e.KeyCode == Keys.Escape)
                {
                    DGV_FilterProduct.Visible = false;

                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {


                if (lblOutwardTotQty.Text != lblInwardTotQty.Text)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(172);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (grdInward.Rows.Count == 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (grdOutward.Rows.Count == 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                } 
                udfnSave();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdOutward_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                UpdateTotalChild(grdOutward);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdOutward_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                UpdateTotalChild(grdOutward);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdOutward_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateTotalChild(grdOutward);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOutwardProduct_KeyDown(object sender, KeyEventArgs e)
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
                        txtOutwardProduct.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        txtOutwardProduct.CharacterCasing = CharacterCasing.Normal;
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
                                    txtOutwardProduct.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtOutwardProduct.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtOutwardProduct.Focus();
                            txtOutwardProduct.SelectionStart = txtOutwardProduct.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtOutwardProduct.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtOutwardProduct.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtOutwardProduct.Focus();
                            txtOutwardProduct.SelectionStart = txtOutwardProduct.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewProduct(sender, e);
                                    DGV_FilterProduct.Visible = false;
                                    txtOutwardQuantity.Focus();
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtOutwardProduct.Focus();
                    //txtOutwardProduct.SelectionStart = txtOutwardProduct.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtOutwardProduct.SelectedText = true;
                        TextBox txtOutwardProduct = sender as TextBox;
                        txtOutwardProduct.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtOutwardQuantity.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOutwardProduct_Leave(object sender, EventArgs e)
        {
            try
            {
                txtOutwardProduct.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnInwardAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbInward.SelectedValue) == "") {

                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    cmbInward.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    string varMessage = objDServ.udfnGetMessages(91);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string varMRP = "", varNewExpiryDate = "", varBatch = "", varSLID = "", varmrptxt = "", varRKID = "";
                for (int i = 0; i < grdInward.Rows.Count; i++)
                {
                    if (Convert.ToInt32(cmbInward.SelectedValue) == Convert.ToInt32(grdInward.Rows[i].Cells["clmpridinv"].Value))
                    {
                        varMRP = Convert.ToString(grdInward.Rows[i].Cells["clmmrpinv"].Value).Trim();
                        varNewExpiryDate = Convert.ToString(grdInward.Rows[i].Cells["clmexpirydateinv"].Value).Trim();
                        varBatch = Convert.ToString(grdInward.Rows[i].Cells["clmbatchnoinv"].Value).Trim();
                        varSLID = Convert.ToString(grdInward.Rows[i].Cells["clmlocationidinv"].Value).Trim();
                        varRKID = Convert.ToString(grdInward.Rows[i].Cells["clmrackidinv"].Value).Trim();
                        if (lblMRP.Text == varMRP && lblExpiryDate.Text == varNewExpiryDate && varBatch == lblBatchNo.Text)
                        {
                            if (lblOutwardLocationId.Text.Trim() == varSLID && lblOutwardRackId.Text.Trim() == varRKID)
                            {
                                SPDataService objDServ = new SPDataService();
                                DataSet objDS = new DataSet();
                                cmbInward.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                string varMessage = objDServ.udfnGetMessages(93);
                                objDServ.CloseConnection();
                                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varErrorFlag = false;
                            }
                        }
                    }
                }
                if (varErrorFlag == true)
                { 

                    cmbInward.BackColor = Color.White;
                    grdInward.Rows.Add(grdInward.Rows.Count + 1, cmbInward.SelectedValue, varPICodeChild, varTamilnameChild, lblOutwardStockDetail.Text, lblOutwardLocationId.Text, lblOutwardRackId.Text, (lblMRP.Text).Trim(), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), 0, 0, (txtOutwardQuantity.Text), lblchildunit.Text, lblUnitChildId.Text, varDecimalChild, grdOutward.Rows.Count + 1);

                    grdInward.Columns["clmproductnameinv"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                    dtConvertedProduct.Rows.Add(cmbInward.SelectedValue, string.Format("{0:G29}", decimal.Parse(Convert.ToString((lblMRP.Text).Trim()))), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), (txtOutwardQuantity.Text), lblOutwardRackId.Text, lblOutwardLocationId.Text, grdInward.Rows.Count);
                }
                if (varparentflag == 1)
                { 
                    txtOutwardProduct.Enabled = true;
                    txtOutwardQuantity.Enabled = true;
                    btnAdd.Enabled = true; 
                    txtOutwardProduct.Focus();
                    udfnProductClear();
                }
                else { 
                    cmbInward.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally {
                grdInward.ClearSelection();
                grdOutward.ClearSelection();
            }
        }

        private void cmbInward_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 77;
                objMR_Product.paraId = 1;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.ParaProductCode = Convert.ToInt32(cmbInward.SelectedValue);
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblUnitChildId.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UTID"]);
                            lblchildunit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UT_SYMBOL"]);  
                            varDecimalChild = Convert.ToInt32(objDs.Tables[0].Rows[0]["UT_Decimal"]);
                            varPICodeChild = Convert.ToString(objDs.Tables[0].Rows[0]["PR_picode"]);
                            varTamilnameChild = Convert.ToString(objDs.Tables[0].Rows[0]["PR_tname"]); 
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

        private void grdInward_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateTotalChild(grdInward);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdInward_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                UpdateTotalChild(grdInward);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdInward_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                UpdateTotalChild(grdInward);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOutwardProduct_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOutwardProduct.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                varDateChange = 0;
                udfnVocherno();
                grdOutward.Rows.Clear();


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void dtpConvertDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOutwardProduct.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOutwardQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOutwardQuantity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOutwardQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                txtOutwardQuantity.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOutwardQuantity_KeyDown(object sender, KeyEventArgs e)
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

        private void txtOutwardQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                //if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                //{
                //    e.Handled = true;
                //}     
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

        private void grdOutward_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                decimal StockcellValue = Convert.ToDecimal(grdOutward.CurrentRow.Cells["clmQty"].Value);
                decimal OutwardcellValue = Convert.ToDecimal(grdOutward.CurrentRow.Cells["clmOutward"].Value);

                if (Convert.ToDecimal(OutwardcellValue) > Convert.ToDecimal(StockcellValue))
                {
                    grdOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //epGoodsOutward.SetError(DGV_inward, "Please enter valid outward qty");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter valid outward quantity", grdOutward, 5000);
                    SPDataService objDServ = new SPDataService();
                    objDServ.CloseConnection();
                    varErrQty = 1;
                    //MessageBox.Show("Please Enter Valid Outward Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToString(OutwardcellValue) == "" || Convert.ToString(OutwardcellValue) == "0")
                {
                    grdOutward.Rows[e.RowIndex].Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrQty = 1;
                }
                else
                {
                    grdOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = Color.PaleGreen;
                    varErrQty = 0;
                }
                int varDecimal = Convert.ToInt32(grdOutward.CurrentRow.Cells["clmUTDecimal"].Value);

                string Qty = objValidation.udfnDecimal(Convert.ToString(grdOutward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                grdOutward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                object varEditQty = grdOutward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                // Update the same column value in the DataTable
                dtStock.Rows[e.RowIndex]["STK_QTY"] = varEditQty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdOutward_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdOutward.CurrentCell.OwningColumn.Name == "clmOutward")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdOutward.CurrentCell.OwningColumn.Name == "clmOutward")
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

        private void grdOutward_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0, varRKID = 0, varSLID=0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "",selectedDsno="";
                if (e.RowIndex != -1)
                {
                    switch (grdOutward.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdOutward.SelectedRows[0].Cells["clmPRID"].Value); 
                                //varMRP = Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmmrp"].Value);
                                varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdOutward.SelectedRows[0].Cells["clmmrp"].Value)));
                                varExpiryDate = Convert.ToString(grdOutward.SelectedRows[0].Cells["clmExpirydate"].Value);
                                varBatchNo = Convert.ToString(grdOutward.SelectedRows[0].Cells["clmBatchNo"].Value);
                                varRKID = Convert.ToInt32(grdOutward.SelectedRows[0].Cells["clmRKID"].Value);
                                varSLID = Convert.ToInt32(grdOutward.SelectedRows[0].Cells["locationid"].Value);
                                selectedDsno = Convert.ToString(grdOutward.SelectedRows[0].Cells["clmdsno"].Value);
                                grdOutward.Rows.RemoveAt(this.grdOutward.SelectedRows[0].Index);

                                // Get the selected dsno value from grdOutward


                                for (int i = 0; i < grdOutward.RowCount; i++)
                                {
                                    grdOutward.Rows[i].Cells["clmdsno"].Value = i + 1;
                                }
                                for (int i = 0; i < dtStock.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID) && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtStock.Rows[i]["STK_MRP"]))) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToInt32(dtStock.Rows[i]["STK_Source_RKID"]) == Convert.ToInt32(varRKID))
                                    {
                                        dtStock.Rows[i].Delete();
                                        dtStock.AcceptChanges();
                                    }
                                }
                                if (!string.IsNullOrEmpty(selectedDsno))
                                {
                                    var inwardRow = grdInward.Rows
                                    .Cast<DataGridViewRow>()
                                    .FirstOrDefault(r => r.Cells["clmSnoinv"].Value?.ToString() == selectedDsno);


                                    grdInward.Rows.Remove(inwardRow); 

                                    DataRow[] rowsToDelete = dtConvertedProduct.Select($"STKJPR_SNO = '{selectedDsno}'");
                                    foreach (DataRow dr in rowsToDelete)
                                        dr.Delete();

                                    dtConvertedProduct.AcceptChanges();
                                }
                                for (int i = 0; i < grdInward.RowCount; i++)
                                {
                                    grdInward.Rows[i].Cells["clmSnoinv"].Value = i + 1;
                                }

                                txtOutwardProduct.Enabled = true;
                                txtOutwardQuantity.Enabled = true;
                                btnAdd.Enabled = true;
                                txtOutwardProduct.Focus();
                                udfnProductClear();
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
                if (grdOutward.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                    txtPStockLocation.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                    txtPStockLocation.Enabled = true;
                    txtPStockLocation.BackColor = Color.White;
                    cmbConcern.BackColor = Color.White;

                }
            }
        }

        private void grdInward_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int varProductID = 0, varRKID = 0, varSLID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (grdInward.Columns[e.ColumnIndex].Name)
                    {
                        case "clmConvertedRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdInward.SelectedRows[0].Cells["clmpridinv"].Value);
                                varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdInward.SelectedRows[0].Cells["clmmrpinv"].Value)));
                                varExpiryDate = Convert.ToString(grdInward.SelectedRows[0].Cells["clmexpirydateinv"].Value);
                                varBatchNo = Convert.ToString(grdInward.SelectedRows[0].Cells["clmbatchnoinv"].Value);
                                varRKID = Convert.ToInt32(grdInward.SelectedRows[0].Cells["clmrackidinv"].Value);
                                varSLID = Convert.ToInt32(grdInward.SelectedRows[0].Cells["clmlocationidinv"].Value);
                                var selectedDsno = grdInward.SelectedRows[0].Cells["clmSnoinv"].Value?.ToString();
                                grdInward.Rows.RemoveAt(this.grdInward.SelectedRows[0].Index);
                                for (int i = 0; i < grdInward.RowCount; i++)
                                {
                                    grdInward.Rows[i].Cells["clmSnoinv"].Value = i + 1;
                                }
                                for (int i = 0; i < dtConvertedProduct.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtConvertedProduct.Rows[i]["STKJPR_PRID"]) == Convert.ToInt32(varProductID) && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtConvertedProduct.Rows[i]["STKJPR_MRP"]))) == varMRP && Convert.ToString(dtConvertedProduct.Rows[i]["STKJPR_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtConvertedProduct.Rows[i]["STKJPR_BatchNo"]) == varBatchNo && Convert.ToInt32(dtConvertedProduct.Rows[i]["STKJPR_RKID"]) == Convert.ToInt32(varRKID) && Convert.ToInt32(dtConvertedProduct.Rows[i]["STKJPR_SLID"]) == Convert.ToInt32(varSLID))
                                    {
                                        dtConvertedProduct.Rows[i].Delete();
                                        dtConvertedProduct.AcceptChanges();
                                    }
                                }


                                if (!string.IsNullOrEmpty(selectedDsno))
                                {
                                    var outwardRow = grdOutward.Rows
                                    .Cast<DataGridViewRow>()
                                    .FirstOrDefault(r => r.Cells["clmdsno"].Value?.ToString() == selectedDsno);

                                    grdOutward.Rows.Remove(outwardRow);

                                    DataRow[] rowsToDelete = dtStock.Select($"STK_SNO = '{selectedDsno}'");
                                    foreach (DataRow dr in rowsToDelete)
                                        dr.Delete();

                                    dtStock.AcceptChanges();
                                }
                                for (int i = 0; i < grdOutward.RowCount; i++)
                                {
                                    grdOutward.Rows[i].Cells["clmdsno"].Value = i + 1;
                                }

                                txtOutwardProduct.Enabled = true;
                                txtOutwardQuantity.Enabled = true;
                                btnAdd.Enabled = true;
                                txtOutwardProduct.Focus();
                                udfnProductClear();
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
                if (grdOutward.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                    txtPStockLocation.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                    txtPStockLocation.Enabled = true;
                    txtPStockLocation.BackColor = Color.White;
                    cmbConcern.BackColor = Color.White;

                }
            }
        }

        private void grdOutward_Enter(object sender, EventArgs e)
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

        private void cmbInward_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbInward.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbInward_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbInward.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbInward_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbInward_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnInwardAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRemark_Leave(object sender, EventArgs e)
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

        private void txtRemark_Enter(object sender, EventArgs e)
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

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbConcern_Enter(object sender, EventArgs e)
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
        private void cmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmbConcern_Leave(object sender, EventArgs e)
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
        private void cmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpConvertDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        #region UDFN FUNCTIONS

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
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dtpConvertDate.Text + "',103)");
                    varResult = objspdservice.udfngetVoucherNo("410", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                    objspdservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varResult != "")
                    {
                        txtStockJournalNo.Text = varvalue[0];
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
                txtStockJournalNo.Text = "";
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
        public void udfnListviewProduct(object sender, EventArgs e)
        {
            try
            {
                //clearAll();
                lblPRID.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                txtOutwardProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                lblUnitId.Text = DGV_FilterProduct.SelectedRows[0].Cells["UTID"].Value.ToString();
                lblUtDecimal.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString();
                lblQuantity.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                txtStockQuantity.Text = "";
                txtStockQuantity.TextAlign = HorizontalAlignment.Right;
                txtStockQuantity.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_Qty"].Value.ToString();
                txtPRack.Text = DGV_FilterProduct.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                txtPMrp.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                txtPExpiryDate.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                txtPStockLocation.Text = DGV_FilterProduct.SelectedRows[0].Cells["SL_ENAME"].Value.ToString();

                varTamilname = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();

                lblPRID.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                lblOutwardLocationId.Text = DGV_FilterProduct.SelectedRows[0].Cells["slid"].Value.ToString();
                lblOutwardRackId.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_RKID"].Value.ToString();
                lblMRP.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                lblExpiryDate.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                lblBatchNo.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_Batchno"].Value.ToString();


                cmbInward.Enabled = false;
                varparentflag = 2; //child item
                lblOutwardStockDetail.Text = txtPStockLocation.Text + " - " + txtPRack.Text + " - ₹" + txtPMrp.Text + " - " + txtPExpiryDate.Text + " ";

                if (Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["ParentFlag"].Value) == 1 && Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["ParentChild"].Value) == 1)
                {
                    ////its parent item have child
                    varparentflag = 1;
                }
                else if (Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["ParentFlag"].Value) == 1 && Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["ParentChild"].Value) == 2)
                {
                    ////its parent item doesn't have child
                    varparentflag = 3;
                }
                if (varparentflag == 1)
                {
                    cmbInward.Enabled = true;
                    udfnChildLoad();
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

        public void udfnProductClear()
        {
            try
            {
                txtStockQuantity.Text = "";
                txtOutwardProduct.Text = "";
                if (varparentflag == 1)
                {
                    txtOutwardQuantity.Text = "";
                }
                else
                {
                    txtOutwardQuantity.Text = "";
                    txtInwardQty.Text = "";
                }

                lblPRID.Text = "";
                lblOutwardLocationId.Text = "";
                lblOutwardRackId.Text = "";
                lblMRP.Text = "";
                lblExpiryDate.Text = "";
                lblBatchNo.Text = "";
                lblUnitId.Text = "";
                lblUtDecimal.Text = "";

                txtPRack.Text = "";
                txtPMrp.Text = "";
                txtPExpiryDate.Text = "";
                txtPStockLocation.Text = "";
                lblOutwardStockDetail.Text = "";
                lblQuantity.Text = "";

                varTamilname = "";
                varPICode = "";
                varDecimal = 0;

                ///Child item flag and id 
                txtInwardQty.Text = "";
                lblchildunit.Text = "";
                lblUnitChildId.Text = "0";
                varTamilnameChild = "";
                varPICodeChild = "";
                varDecimalChild = 0;
                cmbInward.DataSource = null;
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


        private void UpdateTotalChild(DataGridView DGV )
        {
            try
            {
                decimal sum = 0;

                foreach (DataGridViewRow row in DGV.Rows)
                {
                    // Skip the new row placeholder
                    if (row.IsNewRow) continue;
                    if (DGV.Name == "grdOutward")
                    {
                        // Make sure value is not null or empty
                        if (row.Cells["clmOutward"].Value != null &&
                            decimal.TryParse(row.Cells["clmOutward"].Value.ToString(), out decimal value))
                        {
                            sum += value;
                        }
                    }
                    else {

                        // Make sure value is not null or empty
                        if (row.Cells["clmInwardQty"].Value != null &&
                            decimal.TryParse(row.Cells["clmInwardQty"].Value.ToString(), out decimal value))
                        {
                            sum += value;
                        }
                    }
                }

                if (DGV.Name == "grdOutward")
                {
                    lblOutwardTotQty.Text = Convert.ToString(sum);
                }
                else
                {
                    lblInwardTotQty.Text = Convert.ToString(sum);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnChildLoad()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 77;
                objMR_Product.ParaProductCode = Convert.ToInt32(lblPRID.Text);

                objDs = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();
                cmbInward.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbInward.ValueMember = "PRID";
                            cmbInward.DisplayMember = "PR_EName";
                            cmbInward.DataSource = objDs.Tables[0];
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

        public void udfnParentLoad()
        {
            try
            {

                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                var ViewType = 75;
                int varEntry = 3; 
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = ViewType;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue); 
                objMR_Product.ParaProductCode = Convert.ToInt32(lblPRID.Text);
                objMR_Product.paraType = varEntry;

                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        { 
                            grdInward.Rows.Add(grdInward.Rows.Count + 1, objDs.Tables[0].Rows[0]["PRID"].ToString(), objDs.Tables[0].Rows[0]["PR_PICode"].ToString(), objDs.Tables[0].Rows[0]["PR_TName"].ToString(), lblOutwardStockDetail.Text, lblOutwardLocationId.Text, lblOutwardRackId.Text, (lblMRP.Text).Trim(), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), 0, 0, (txtOutwardQuantity.Text), objDs.Tables[0].Rows[0]["UT_SYmbol"].ToString(), objDs.Tables[0].Rows[0]["UTID"].ToString(), objDs.Tables[0].Rows[0]["UT_Decimal"].ToString(), grdOutward.Rows.Count + 1);

                            grdInward.Columns["clmproductnameinv"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                            dtConvertedProduct.Rows.Add(objDs.Tables[0].Rows[0]["PRID"].ToString(), string.Format("{0:G29}", decimal.Parse(Convert.ToString((lblMRP.Text).Trim()))), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), (txtOutwardQuantity.Text), lblOutwardRackId.Text, lblOutwardLocationId.Text, grdInward.Rows.Count);
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

        public void udfnSave()
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                string varoriginator = ""; int ViewType = 0; varErrQty = 0;
                varoriginator = "Stock Journal Creation";
                ViewType = 0;
                bool GOID = Convert.ToBoolean(varAJId);
                txtRemark.BackColor = Color.White;
                epStockConvertion.Clear();
                bool blnErrorFlag = true;

                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epStockConvertion.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = false;
                }

                if (txtRemark.Text == "")
                {
                    epStockConvertion.SetError(txtRemark, "Please enter remarks");
                    txtRemark.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter remarks", txtRemark, 5000);
                    blnErrorFlag = false;
                }

                if (varErrQty == 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                }


                if (blnErrorFlag == true)
                { 


                    udfntooltiphide();
                    epStockConvertion.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();
                    TRN_Stock_Journal objTRN_Stock_Journaln = new TRN_Stock_Journal();


                    if (varAJId != 0)
                    {
                        ViewType = 1;
                    }

                   DataTable  dtConvertedProductClone = dtConvertedProduct.DefaultView.ToTable(false, "STKJPR_PRID", "STKJPR_MRP", "STKJPR_ExpiryDate", "STKJPR_BatchNo", "STKJPR_TranactionQty", "STKJPR_RKID", "STKJPR_SLID");

                    DataTable dtStockClone = dtStock.DefaultView.ToTable(false, "STK_PRID", "STK_MRP", "STK_ExpiryDate", "STK_BatchNo", "STK_UTID", "STK_QTY", "STK_Source_RKID", "STK_Dest_SLID", "STK_Dest_RKID", "STK_ProType", "STK_Status");

                       


                    objTRN_Stock_Journaln.ViewType = ViewType;
                    objTRN_Stock_Journaln.ParaTransactionId = varAJId;
                    objTRN_Stock_Journaln.ParaCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_Stock_Journaln.paraOutwardDate = dtpConvertDate.Text; 
                    objTRN_Stock_Journaln.paraRemarks = txtRemark.Text.Trim();
                    objTRN_Stock_Journaln.paraOriginator = varoriginator;
                    objTRN_Stock_Journaln.ParaFlag = varCompleteFlag;
                    objTRN_Stock_Journaln.paraStock_Journal = dtConvertedProductClone;
                    objTRN_Stock_Journaln.paraStockTransfer = dtStockClone;
                    objTRN_Stock_Journaln.paraStatusId = 14;
                    result = objspdservice.udfnStockJournal(objTRN_Stock_Journaln);
                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (result.Split('~')[0] == "3")
                    {
                        if (result.Split('~')[0] != "1")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ActiveControl = txtOutwardProduct;
                            MainForm.objINV_StockJournalConversionList.udfnList();
                            string varSJID = "0";
                            if (varAJId == 0)
                            {
                                varSJID = varvalue[2];
                            }
                            else
                            {
                                varSJID = Convert.ToString(varAJId);
                            }
                            udfnJournalReport(varSJID);
                            udfnClear();
                            this.Close();
                        }
                    }
                    else if (result.Split('~')[0] == "5")
                    {

                        MessageBox.Show(result.Split('~')[1] + "( " + result.Split('~')[2] + " )", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
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
                grdInward.ClearSelection();
                grdOutward.ClearSelection(); 
            }
        }
        public void udfnJournalReport(string varSJID)
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Stock_Journal.rpt");
                    varHeader = "Stock Journal Report";

                    objBillreport.SetParameterValue("paraBrandName", "-All-");
                    objBillreport.SetParameterValue("paraGroupName", "-All-");
                    objBillreport.SetParameterValue("paraSubgroupName", "-All-");
                    objBillreport.SetParameterValue("paraAlphaName", "-All-");
                    objBillreport.SetParameterValue("paraCompanyName", "-All-");
                    objBillreport.SetParameterValue("paraCompanyCode", 0);
                    objBillreport.SetParameterValue("paraFromDate", dtpConvertDate.Text);
                    objBillreport.SetParameterValue("paraToDate", dtpConvertDate.Text);
                    objBillreport.SetParameterValue("paraSLID", 0);
                    objBillreport.SetParameterValue("paraBrandID", 0);
                    objBillreport.SetParameterValue("paraPRGID", 0);
                    objBillreport.SetParameterValue("paraPRSGID", 0);
                    objBillreport.SetParameterValue("paraAlpha", "");
                    objBillreport.SetParameterValue("paraLocationName", "-All-");
                    objBillreport.SetParameterValue("paraPrintName", "271");
                    objBillreport.SetParameterValue("paraUserLocations", MainForm.pbUserMappedLocationIds);
                    objBillreport.SetParameterValue("paraPRID", 0);
                    objBillreport.SetParameterValue("paraId", 1);
                    objBillreport.SetParameterValue("paraTrnID", Convert.ToInt32(varSJID));
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);

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
        public void udfntooltiphide()
        {
            try
            {
                epStockConvertion.Clear();
                cmbConcern.BackColor = Color.White;
                tpConcern.Active = false; 
                tpTransactionType.Active = false;
                txtPStockLocation.BackColor = Color.White;
                tpStockLocation.Active = false;
                //txtProduct.BackColor = Color.White;
                tpProduct.Active = false;
                txtInwardQty.BackColor = Color.White;
                tpOutwardQuantity.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        {
            try
            {
                btnSave.Enabled = true;
                cmbConcern.Text = "";
                txtStockJournalNo.Text = "";
                txtPStockLocation.Text = ""; 
                lblQuantity.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnEdit(object sender, EventArgs e)
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
                    TRN_Stock_Journal objTRN_Stock_Journal = new TRN_Stock_Journal();
                    objTRN_Stock_Journal.ViewType = ViewType;
                    objTRN_Stock_Journal.ParaTransactionId = Convert.ToInt32(varAJId);
                    objDs = objdserv.udfnStockJournalList(objTRN_Stock_Journal);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        { 
                            cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["STKJ_COMID"].ToString();
                            dtpConvertDate.Text = objDs.Tables[0].Rows[0]["STKJ_Date"].ToString();
                            txtStockJournalNo.Text = objDs.Tables[0].Rows[0]["STKJ_No"].ToString();
                            txtRemark.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString(); 
                        }

                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            { 

                                if (Convert.ToString(objDs.Tables[1].Rows[i]["STKJ_Type"]) == "2") // OUTWARD QTY
                                { 
                                    grdOutward.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                                     
                                    string varStockDetail = Convert.ToString(objDs.Tables[1].Rows[i]["SL_ENAME"]) + " - " + Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]) + " - ₹" + Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]) + " - " + Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]) + " ";


                                    grdOutward.Rows.Add(grdOutward.Rows.Count + 1, Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), varStockDetail,
                                        Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), 0, Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKJPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Decimal"]));


                                    dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKJPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), 0, 0, 0,grdOutward.Rows.Count);
                                     
                                     
                                }
                                else  // INWARD QTY
                                {


                                    grdInward.Columns["clmproductnameinv"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                                    string varStockDetail = Convert.ToString(objDs.Tables[1].Rows[i]["SL_ENAME"]) + " - " + Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]) + " - ₹" + Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]) + " - " + Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]) + " ";
                                      

                                    grdInward.Rows.Add(grdInward.Rows.Count + 1, Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), varStockDetail,
                                        Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                    Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), 0, Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKJPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Decimal"]),0);
                                     

                                    dtConvertedProduct.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKJPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), grdInward.Rows.Count);
                                     

                                } 

                            }
                        }
                    }

                    cmbConcern.Enabled = false;
                    dtpConvertDate.Enabled = false; 
                    epStockConvertion.Clear();
                    udfntooltiphide(); 
                    udfnListviewProduct(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdInward.ClearSelection();
                grdOutward.ClearSelection();  
                DGV_FilterProduct.Visible = false;
            }
        }


        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdOutward.CurrentCell.OwningColumn.Name == "clmOutward")
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
                int varDecimal = Convert.ToInt32(grdOutward.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdOutward.CurrentCell.OwningColumn.Name == "clmOutward")
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
        #endregion

    }
}




