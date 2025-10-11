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
        public string varStockLocationId = "", varTamilname = "", varPICode = "";
        public string varStockApplicable = "";
        public int varErrQty = 0;
        public int varCloseFlag = 0;
        public int varUpDownKey = 0;
        public int varAJId = 0;
        public int varSTSID = 0;
        public int varUpdate = 0, VarUpdateFlag = 0;
        public int varCompanyId = 0, varDestSLID = 0, varDestRKID = 0, varStatusId = 0, varDecimal = 0;

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

                            dtStock.Rows.Add(lblPRID.Text, string.Format("{0:G29}", decimal.Parse(Convert.ToString(lblMRP.Text.Trim()))), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), lblUnitId.Text, (txtOutwardQuantity.Text), lblOutwardRackId.Text, lblOutwardLocationId.Text, 0, 0);

                            if (varparentflag == 2)
                            {
                                udfnParentLoad();
                            }
                            //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                            grdOutward.Columns["ClmBatch"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            txtInwardQty.Text = txtOutwardQuantity.Text;
                            udfnProductClear();
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
                cmbInward_SelectedIndexChanged(sender, e);
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

                dtConvertedProduct.TableName = "TRN_Stock_Journal_Products";
                dtConvertedProduct.Columns.Add("STKJPR_PRID", typeof(int));
                dtConvertedProduct.Columns.Add("STKJPR_MRP", typeof(decimal));
                dtConvertedProduct.Columns.Add("STKJPR_ExpiryDate", typeof(string));
                dtConvertedProduct.Columns.Add("STKJPR_BatchNo", typeof(string));
                dtConvertedProduct.Columns.Add("STKJPR_TranactionQty", typeof(decimal));
                dtConvertedProduct.Columns.Add("STKJPR_RKID", typeof(int));
                dtConvertedProduct.Columns.Add("STKJPR_SLID", typeof(int));

                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dtpConvertDate.MinDate = MainForm.pbFYStartDate;
                dtpConvertDate.MaxDate = MainForm.pbCurrentDate;
                grdOutward.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
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

                        var ViewType = 80;
                        int varEntry = 1;
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = ViewType;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraProductName = txtOutwardProduct.Text;
                        objMR_Product.paraType = varEntry;


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
                                    DGV_FilterProduct.Columns["PR_PICode"].Visible = false;
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
                                    DGV_FilterProduct.Columns["STK_BatchNo"].DisplayIndex = 7;
                                    DGV_FilterProduct.Columns["STK_Qty"].DisplayIndex = 8;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 9;
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
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["STK_MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["STK_Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            try { }
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
            try { 
                grdInward.Rows.Add(grdInward.Rows.Count + 1,cmbInward.SelectedValue, varPICode, varTamilname, lblOutwardStockDetail.Text, lblOutwardLocationId.Text, lblOutwardRackId.Text, (lblMRP.Text).Trim(), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), 0, 0, (txtOutwardQuantity.Text), lblchildunit.Text, lblUnitId.Text, varDecimal);

                dtConvertedProduct.Rows.Add(cmbInward.SelectedValue, string.Format("{0:G29}", decimal.Parse(Convert.ToString((lblMRP.Text).Trim()))), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), (txtOutwardQuantity.Text), lblOutwardRackId.Text, lblOutwardLocationId.Text);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                            lblUnitId.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ChildUnit"]);  
                            varDecimal = Convert.ToInt32(objDs.Tables[0].Rows[0]["UT_Decimal"]);
                            varPICode = Convert.ToString(objDs.Tables[0].Rows[0]["PR_picode"]);
                            varTamilname = Convert.ToString(objDs.Tables[0].Rows[0]["PR_tname"]); 
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
                        txtStockConvertNo.Text = varvalue[0];
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
                txtStockConvertNo.Text = "";
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

                varTamilname = "";
                varPICode = "";

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
                int varEntry = 0;
                if (btnSave.Text == "Update") { varEntry = varAJId; }
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = ViewType;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue); 
                  
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        { 
                            grdInward.Rows.Add(grdInward.Rows.Count + 1, objDs.Tables[0].Rows[0]["PRID"].ToString(), objDs.Tables[0].Rows[0]["PR_PICode"].ToString(), objDs.Tables[0].Rows[0]["PR_TName"].ToString(), lblOutwardStockDetail.Text, lblOutwardLocationId.Text, lblOutwardRackId.Text, (lblMRP.Text).Trim(), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), 0, 0, (txtOutwardQuantity.Text), objDs.Tables[0].Rows[0]["UT_SYmbol"].ToString(), objDs.Tables[0].Rows[0]["UTID"].ToString(), objDs.Tables[0].Rows[0]["UT_Decimal"].ToString());

                            dtConvertedProduct.Rows.Add(objDs.Tables[0].Rows[0]["PRID"].ToString(), string.Format("{0:G29}", decimal.Parse(Convert.ToString((lblMRP.Text).Trim()))), (lblExpiryDate.Text).Trim(), (lblBatchNo.Text).Trim(), (txtOutwardQuantity.Text), lblOutwardRackId.Text, lblOutwardLocationId.Text);
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




