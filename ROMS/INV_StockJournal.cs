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
    public partial class INV_StockJournal : Form
    {
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
        public string varStockLocationId = "", varTamilname = "";
        public string varStockApplicable = "";
        public int varErrQty = 0;
        public int varCloseFlag = 0;
        public int varUpDownKey = 0;
        public int varAJId = 0;
        public int varSTSID = 0;
        public int varUpdate = 0, VarUpdateFlag = 0;
        public int varCompanyId = 0, varDestSLID = 0, varDestRKID = 0, varStatusId = 0, varDecimal = 0, varUpDownKeyParentLocation = 0;
        string varProductID = "", varMRP = "", varExpiryDate = "", varBatchNo = "", varRackId = "", varPrMRPFlag = "", varBatchNoGeneration = "";
        string varChild1BatchNo = "", varChild1BatchNoGeneration = "", varChild1PrMRPFlag = "";
        DataTable dtStock = new DataTable(), dtConvertedProduct = new DataTable();
        public string vargroupcode;
        public String pbFormStatus;
        private bool varErrorFlag;
        public bool varChangeFlag = true;
        public bool VarSearchFlag = true;
        string SLID = "";
        int GOId = 0;
        string varLocation = "";
        string result = "";
        public string varPICode = "", varPIChildCode = "", varPEname = "", varPTname = "", varPID = "", varUTID = "", varParentId = "", varPRID = "", varRKID = "", varTotalItem = "", varUnit = "", varTransType = "", varParentPIcode = "", varParentTname ="" , varParentUnit ="" ,varParentUnitID = "",varParentUnitDecimal="";
        private int varviewtype = 0;
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0;
        public string varUserID = "";
        public decimal varBalanceqty = 0;

        public INV_StockJournal()
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
        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                    udfnclose();
                    MainForm.objINV_StockJournalList.udfnList(); 
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
                txtParentQuantity.TextAlign = HorizontalAlignment.Right;
                if (e.KeyCode == Keys.Escape)
                {
                    DGV_FilterProduct.Visible = false;
                    
                        udfnclose(); 
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
                    epStockConvertion.SetError(cmbTransactionType, "Please select transaction type");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
                }
                else
                {
                    epStockConvertion.Clear();
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
                    txtProductName.Focus();
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
                epStockConvertion.Clear();
                txtProductName.BackColor = Color.White;
                tpProduct.Active = false;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            //finally
            //{
            //    lvproduct.Visible = false;
            //}
            //errPO.Clear();
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
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
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
                                    udfnListviewProduct(sender, e);
                                    DGV_FilterProduct.Visible = false;
                                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 379) // parent - child
                                    {
                                        txtbatch1.Focus();
                                    }
                                    else if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 380) // child - parent
                                    {
                                        cmbChildProduct2.Focus();
                                    }
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
                        if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 379) // parent - child
                        {
                            txtbatch1.Focus();
                        }
                        else if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 380) // child - parent
                        {
                            cmbChildProduct2.Focus();
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
                txtParentQuantity.BackColor = Color.LemonChiffon;
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

        private void TxtOutwardQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtParentQuantity.Text).Trim() == "")
                {
                    epStockConvertion.SetError(txtParentQuantity, "Please enter outward quantity");
                    txtParentQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter outward quantity", txtParentQuantity, 5000);

                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtParentQuantity.Text).Trim(), varDecimal);
                    txtParentQuantity.Text = Qty;
                    epStockConvertion.Clear();
                    txtParentQuantity.BackColor = Color.White;
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
                    epStockConvertion.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epStockConvertion.Clear();
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
                    dtpConvertDate.Focus();
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
                    txtPStockLocation.Text = "";
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
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dtpConvertDate.Text + "',103)");
                    varResult = objspdservice.udfngetVoucherNo("389", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
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
                        //MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                        //MainForm.objCP_Settings.varValues = Convert.ToString(44);
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


                dtConvertedProduct.TableName = "TRN_Stock_Conversion_Products";
                dtConvertedProduct.Columns.Add("STKCONPR_PRID", typeof(int));
                dtConvertedProduct.Columns.Add("STKCONPR_MRP", typeof(decimal));
                dtConvertedProduct.Columns.Add("STKCONPR_ExpiryDate", typeof(string));
                dtConvertedProduct.Columns.Add("STKCONPR_BatchNo", typeof(string));
                dtConvertedProduct.Columns.Add("STKCONPR_TranactionQty", typeof(decimal));
                dtConvertedProduct.Columns.Add("STKCONPR_RKID", typeof(int));
                dtConvertedProduct.Columns.Add("STKCONPR_SLID", typeof(int));

                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dtpConvertDate.MinDate = MainForm.pbFYStartDate;
                dtpConvertDate.MaxDate = MainForm.pbCurrentDate;
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    udfnTransactionData();
                    //dtpOutwardDate.MaxDate = DateTime.Now;
                    grdStockadjustment.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
                    //txtChildStockLocation2.BackColor = Color.White; 
                    VarSearchFlag = true;
                    if (varAJId == 0)
                    {
                        this.ActiveControl = cmbTransactionType;
                    }
                    else
                    {
                        this.ActiveControl = cmbChildProduct2;
                        udfnEdit(sender, e);
                    }
                } 
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
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID = 117", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
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
                if (txtPStockLocation.Text == "")
                {
                    varId_PurLocation = "0";
                }
                else
                {
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 14;
                    objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Location.paraLocationName = txtPStockLocation.Text;
                    objDsPurLoc = objDServ3.udfnStockLocationList(objMR_Location);
                    objDServ3.CloseConnection();
                    //objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtPStockLocation.Text, 0, 0, 0, "", "", 0);
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
                    //lvproduct.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0 || txtProductName.Text == " ")
                    {
                        
                        var ViewType = 75;
                        int varEntry = 0;
                        if (btnSave.Text == "Update") { varEntry = varAJId; }
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = ViewType;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue); 
                            objMR_Product.paraProductName = txtProductName.Text;
                        if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 379) // parent - child
                        {
                            objMR_Product.paraId = 0;
                        }
                        else
                        {
                            objMR_Product.paraId = 1;
                        }
                        objMR_Product.paraPicode = txtProductName.Text;
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
                                    DGV_FilterProduct.Width = 620;
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

        public void udfnListviewBatch()
        {
            try
            {
                varPRID = DGVFilterBatch.SelectedRows[0].Cells["PRID"].Value.ToString();
                varTamilname = DGVFilterBatch.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                varPICode = DGVFilterBatch.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                varUTID = DGVFilterBatch.SelectedRows[0].Cells["UTID"].Value.ToString();
                varRKID = DGVFilterBatch.SelectedRows[0].Cells["STK_RKID"].Value.ToString();
                varDecimal = Convert.ToInt32(DGVFilterBatch.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                varUnit = DGVFilterBatch.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                txtPRack.Text = DGVFilterBatch.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                txtPMrp.Text = DGVFilterBatch.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                txtExpiryDate.Text = DGVFilterBatch.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                txtPExpiryDate.Text = DGVFilterBatch.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                lblQuantity.Text = DGVFilterBatch.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                txtStockQuantity.TextAlign = HorizontalAlignment.Right;
                txtStockQuantity.Text = DGVFilterBatch.SelectedRows[0].Cells["STK_Qty"].Value.ToString();
                txtPStockLocation.Text = DGVFilterBatch.SelectedRows[0].Cells["SL_ENAME"].Value.ToString();
                txtPBatchNo.Text = DGVFilterBatch.SelectedRows[0].Cells["STK_Batchno"].Value.ToString();

                varStockLocationId = DGVFilterBatch.SelectedRows[0].Cells["slid"].Value.ToString();

                lblParentStockDetail.Text = txtPStockLocation.Text + " - " + txtPRack.Text + " - ₹" + txtPMrp.Text + " - " + txtPExpiryDate.Text + " ";
                txtbatch1.Text = lblParentStockDetail.Text;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        public void udfnListviewBatch2()
        {
            try
            {
                varPRID = DGVBatch2.SelectedRows[0].Cells["PRID"].Value.ToString();
                varTamilname = DGVBatch2.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                varPICode = DGVBatch2.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                varUTID = DGVBatch2.SelectedRows[0].Cells["UTID"].Value.ToString();
                varRKID = DGVBatch2.SelectedRows[0].Cells["STK_RKID"].Value.ToString();
                varDecimal = Convert.ToInt32(DGVBatch2.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                varUnit = DGVBatch2.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                txtPRack.Text = DGVBatch2.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                txtPMrp.Text = DGVBatch2.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                txtExpiryDate2.Text = DGVBatch2.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                txtPExpiryDate.Text = DGVBatch2.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                lblQuantity2.Text = DGVBatch2.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                txtChildStockqty.TextAlign = HorizontalAlignment.Right;
                txtChildStockqty.Text = DGVBatch2.SelectedRows[0].Cells["STK_Qty"].Value.ToString();
                txtPStockLocation.Text = DGVBatch2.SelectedRows[0].Cells["SL_ENAME"].Value.ToString();
                txtPBatchNo.Text = DGVBatch2.SelectedRows[0].Cells["STK_Batchno"].Value.ToString();

                txtupp.Text = Convert.ToString(DGVBatch2.SelectedRows[0].Cells["PR_UPP"].Value.ToString());

                varStockLocationId = DGVBatch2.SelectedRows[0].Cells["slid"].Value.ToString();

                lblChildStockDetail.Text = txtPStockLocation.Text + " - " + txtPRack.Text + " - ₹" + txtPMrp.Text + " - " + txtPExpiryDate.Text + " ";
                txtbatch2.Text = lblChildStockDetail.Text;
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
                clearAll();
                varPRID = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                varTamilname = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                varUTID = DGV_FilterProduct.SelectedRows[0].Cells["UTID"].Value.ToString();
                varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                varUnit = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                lblQuantity.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                txtStockQuantity.Text = "";
                varParentId = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                varParentPIcode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                varParentTname = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();


                varParentUnit = varUnit;
                varParentUnitID = varUTID;
                varParentUnitDecimal = Convert.ToString(varDecimal);
                lblparnetconvertunit.Text = varUnit;

                lblParentTotUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                lblParentBalUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();

                lblparent2balunit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                lblparent2unit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();

                varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNo"].Value.ToString();
                varBatchNoGeneration = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNoGeneration"].Value.ToString();

                varPrMRPFlag = Convert.ToString(DGV_FilterProduct.SelectedRows[0].Cells["PR_MRPflag"].Value);

                txtParentProduct1.Text = txtProductName.Text;
                txtParent2.Text = txtProductName.Text;
                udfnChildLoad();



                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 380) // child - parent 
                {
                    DGV_FilterParentLocation.Visible = false;
                    DGV_FilterParentLocation.DataSource = null;
                    lvParenetRack1.Visible = false;

                    varChild1PrMRPFlag = varPrMRPFlag;
                    if (varChild1PrMRPFlag == "1")
                    {
                        varChild1PrMRPFlag = "1";
                        txtParentMRP.ReadOnly = false;
                        txtParentMRP.Enabled = true;
                    }
                    else
                    {
                        txtParentMRP.Text = "0";
                        varChild1PrMRPFlag = "0";
                        txtParentMRP.ReadOnly = true;
                        txtParentMRP.Enabled = false;
                    }
                    if (Convert.ToInt32(varBatchNoGeneration) == 73)  //disabled
                    {
                        txtBatchno2.Text = "";
                        txtBatchno2.Enabled = false;
                    }
                    else if (Convert.ToInt32(varBatchNoGeneration) == 72) //enabled
                    {
                        if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                        {
                            txtBatchno2.Enabled = true;
                            txtBatchno2.BackColor = Color.White;
                        }
                        else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                        {
                            DataSet objDs = new DataSet();
                            SPDataService objspdservice = new SPDataService();
                               MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 14;
                            objDs = objspdservice.udfnMaster(objMR_Master);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtBatchno2.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                    txtBatchno2.Enabled = false;
                                }
                            }
                        }
                    }
                }

                //udfnProductAdd(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterProduct.Visible = false;
                btnbatch2_Click(sender, e);
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
        public DataTable udfnPurchaseProduct()
        {
            DataTable dtStock = new DataTable();
            try
            {
                dtStock.TableName = "TRN_StockTransfer_Product_AutoComplete";
                dtStock.Columns.Add("STK_PRID", typeof(int));
                dtStock.Columns.Add("STK_MRP", typeof(decimal));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(int));
                dtStock.Columns.Add("STK_QTY", typeof(string));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(int));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(int));
                dtStock.Columns.Add("STK_Status", typeof(int));
                for (int i = 0; i < grdStockadjustment.Rows.Count; i++)
                {
                    DataService objDser = new DataService();
                    dtStock.Rows.Add(Convert.ToInt32(grdStockadjustment.Rows[i].Cells["clmPRID"].Value), Convert.ToString(grdStockadjustment.Rows[i].Cells["clmmrp"].Value),
                    Convert.ToString(grdStockadjustment.Rows[i].Cells["clmExpiryDate"].Value), Convert.ToString(grdStockadjustment.Rows[i].Cells["clmBatchNo"].Value),
                    Convert.ToInt32(grdStockadjustment.Rows[i].Cells["clmUTID"].Value), Convert.ToString(grdStockadjustment.Rows[i].Cells["clmOutward"].Value),
                    Convert.ToString(grdStockadjustment.Rows[i].Cells["clmRKID"].Value), 0, 0);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return dtStock;
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

        private void TxtMrp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPMrp.TextAlign = HorizontalAlignment.Right;
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
                txtPExpiryDate.TextAlign = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                //    if (DGV_inward.Rows.Count > 0)
                //    {
                //        udfnSLocationValid();
                //        if (Convert.ToString(SLID) != Convert.ToString(varStockLocationId))
                //        {
                //            //SPDataService objDServ = new SPDataService();
                //            //string varMessage = objDServ.udfnGetMessages(78);
                //            //objDServ.CloseConnection();
                //            DialogResult dialogResult = MessageBox.Show("This will clear all the products from the Grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            DGV_inward.Rows.Clear();
                //            dtStock.Rows.Clear();
                //            txtChildStockLocation2.Focus();
                //            //varStockLocationId = varLocation;
                //        }
                //    }
                //    lvStockLocation.Visible = false;&

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
        public void allowonlynumbergrdchild2(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdChild2.CurrentCell.OwningColumn.Name == "clmChild2Qty")
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
        public void allowonlynumbergrdparent2(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdParent2.CurrentCell.OwningColumn.Name == "clmparent2Qty")
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
        private void TxtProduct_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtOutwardQuantity_KeyPress(object sender, KeyPressEventArgs e)
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
                dtStock.Rows[e.RowIndex]["STK_QTY"] = varEditQty;
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

        private void udfngrdChild2HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int varDecimal = Convert.ToInt32(grdChild2.CurrentRow.Cells["clmChild2UTDecimal"].Value);
                if (grdChild2.CurrentCell.OwningColumn.Name == "clmChild2Qty")
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

        private void udfngrdParent2HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int varDecimal = Convert.ToInt32(grdParent2.CurrentRow.Cells["clmparent2UTDecimal"].Value);
                if (grdParent2.CurrentCell.OwningColumn.Name == "clmparent2Qty")
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
                                    udfnListviewProduct(sender, e);
                                    DGV_FilterProduct.Visible = false;
                                    if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 379) // parent - child
                                    {
                                        txtbatch1.Focus();
                                    }
                                    else if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 380) // child - parent
                                    {
                                        cmbChildProduct2.Focus();
                                    }
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
                udfnListviewProduct(sender, e);
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 379) // parent - child
                {
                    txtbatch1.Focus();
                }
                else if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 380) // child - parent
                {
                    cmbChildProduct2.Focus();
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

        private void DGV_FilterProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
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

        private void lblConcern_Click(object sender, EventArgs e)
        {

        }

        private void txtbatch1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    if (VarSearchFlag == true)
                    {
                        txtbatch1.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        txtbatch1.CharacterCasing = CharacterCasing.Normal;
                    }
                    txtStockQuantity.Text = "";
                    txtParentQuantity.Text = "";
                    lblQuantity.Text = "";
                    //lvproduct.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtbatch1.Text.Length > 0 || txtbatch1.Text == " ")
                    {


                        int varEntry = 0;
                        if (btnSave.Text == "Update") { varEntry = varAJId; }
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 76;
                        objMR_Product.ParaProductCode = Convert.ToInt32(varParentId);
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraProductName = txtbatch1.Text;
                        objMR_Product.paraStockTransfer = dtStock;
                        objMR_Product.paraId = varEntry;
                        if (VarSearchFlag == false)
                        {
                            objMR_Product.paraProductName = txtbatch1.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraPicode = txtbatch1.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGVFilterBatch.DataSource = objDs.Tables[0];
                                    DGVFilterBatch.Columns["PRID"].Visible = false;

                                    DGVFilterBatch.Columns["PR_TName"].Visible = false;
                                    DGVFilterBatch.Columns["PR_EName"].Visible = false;
                                    DGVFilterBatch.Columns["slid"].Visible = false;
                                    DGVFilterBatch.Columns["PR_PICode"].Visible = false;
                                    DGVFilterBatch.Columns["SL_EName"].Width = 120;
                                    DGVFilterBatch.Columns["RK_ShortName"].Width = 70;
                                    DGVFilterBatch.Columns["STK_MRP"].Width = 60;
                                    DGVFilterBatch.Columns["STK_ExpiryDate"].Width = 90;
                                    DGVFilterBatch.Columns["STK_BatchNo"].Width = 70;
                                    DGVFilterBatch.Columns["STK_Qty"].Width = 70;
                                    DGVFilterBatch.Columns["UT_Symbol"].Width = 50;
                                    DGVFilterBatch.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGVFilterBatch.Columns["UTID"].Visible = false;
                                    DGVFilterBatch.Columns["PRODUCTLIST"].Visible = false;
                                    DGVFilterBatch.Columns["UT_Name"].Visible = false;
                                    DGVFilterBatch.Columns["PR_UPP"].Visible = false; 
                                    DGVFilterBatch.Columns["STK_RKID"].Visible = false;
                                    DGVFilterBatch.Columns["STK_RKID"].Visible = false;
                                    DGVFilterBatch.Columns["UT_Decimal"].Visible = false;
                                    DGVFilterBatch.Columns["PR_PICode"].Width = 120;
                                    DGVFilterBatch.Columns["UT_Symbol"].Width = 60;
                                    DGVFilterBatch.Columns["SL_EName"].DisplayIndex = 2;
                                    DGVFilterBatch.Columns["RK_ShortName"].DisplayIndex = 3;
                                    DGVFilterBatch.Columns["STK_MRP"].DisplayIndex = 4;
                                    DGVFilterBatch.Columns["STK_ExpiryDate"].DisplayIndex = 5;
                                    DGVFilterBatch.Columns["STK_BatchNo"].DisplayIndex = 6;
                                    DGVFilterBatch.Columns["STK_Qty"].DisplayIndex = 7;
                                    DGVFilterBatch.Columns["UT_Symbol"].DisplayIndex = 8;
                                    DGVFilterBatch.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGVFilterBatch.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGVFilterBatch.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGVFilterBatch.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGVFilterBatch.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGVFilterBatch.Columns["RK_ShortName"].HeaderText = "Rack";
                                    DGVFilterBatch.Columns["STK_MRP"].HeaderText = "MRP";
                                    DGVFilterBatch.Columns["STK_ExpiryDate"].HeaderText = "Expiry Date";
                                    DGVFilterBatch.Columns["STK_BatchNo"].HeaderText = "Batch No.";
                                    DGVFilterBatch.Columns["STK_Qty"].HeaderText = "Stock Qty";
                                    DGVFilterBatch.Columns["SL_EName"].HeaderText = "Stock Location";
                                    DGVFilterBatch.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGVFilterBatch.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGVFilterBatch.Columns["STK_MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGVFilterBatch.Columns["STK_Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGVFilterBatch.Columns["STK_ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGVFilterBatch.Visible = true;
                                    btnbatch2.Enabled = true;
                                }
                                else
                                {
                                    DGVFilterBatch.DataSource = null;
                                    DGVFilterBatch.Visible = false;
                                    btnbatch2.Enabled = false;
                                }
                            }
                            else
                            {
                                DGVFilterBatch.DataSource = null;
                                DGVFilterBatch.Visible = false;
                                btnbatch2.Enabled = false;
                            }
                        }
                        else
                        {
                            DGVFilterBatch.DataSource = null;
                            DGVFilterBatch.Visible = false;
                            btnbatch2.Enabled = false;
                        }
                    }
                    else
                    {
                        DGVFilterBatch.DataSource = null;
                        DGVFilterBatch.Visible = false;
                        btnbatch2.Enabled = false;
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

        private void txtbatch1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtbatch1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbatch1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGVFilterBatch.Focus();

                }
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        txtbatch1.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        txtbatch1.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                if (e.KeyCode == Keys.Enter && DGVFilterBatch.Visible == false)
                {
                    txtParentQuantity.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGVFilterBatch.Focus();
                }
                if (DGVFilterBatch.CurrentCell == null && DGVFilterBatch.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGVFilterBatch.Focus();
                    int RowIndex = DGVFilterBatch.CurrentCell.RowIndex;
                    int ClmIndex = DGVFilterBatch.CurrentCell.ColumnIndex;
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
                            if (RowIndex >= 0) DGVFilterBatch.CurrentCell = DGVFilterBatch.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtbatch1.Text = DGVFilterBatch.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtbatch1.Text = DGVFilterBatch.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtbatch1.Focus();
                            txtbatch1.SelectionStart = txtbatch1.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGVFilterBatch.Rows.Count) DGVFilterBatch.CurrentCell = DGVFilterBatch.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGVFilterBatch.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtbatch1.Text = DGVFilterBatch.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtbatch1.Text = DGVFilterBatch.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtbatch1.Focus();
                            txtbatch1.SelectionStart = txtbatch1.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGVFilterBatch.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewBatch();
                                    DGVFilterBatch.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtbatch1.Focus();
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
                        txtParentQuantity.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbatch1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtbatch1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGVFilterBatch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListviewBatch();
                txtParentQuantity.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGVFilterBatch.Visible = false;
            }
        }

        private void DGVFilterBatch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGVFilterBatch.CurrentCell.RowIndex;
                    int ClmIndex = DGVFilterBatch.CurrentCell.ColumnIndex;
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
                            if (RowIndex >= 0) DGVFilterBatch.CurrentCell = DGVFilterBatch.Rows[RowIndex].Cells[ClmIndex];

                            txtbatch1.Text = DGVFilterBatch.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtbatch1.Focus();
                            txtbatch1.SelectionStart = txtbatch1.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGVFilterBatch.Rows.Count) DGVFilterBatch.CurrentCell = DGVFilterBatch.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGVFilterBatch.Rows.Count))
                            {
                                txtbatch1.Text = DGVFilterBatch.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtbatch1.Focus();
                            txtbatch1.SelectionStart = txtbatch1.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGVFilterBatch.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewBatch();
                                    DGVFilterBatch.Visible = false;
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

        private void txtRemark_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChildStockLocation1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtChildStockLocation1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtChildStockLocation1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtChildStockLocation1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtChildStockLocation1_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvChildStockLocation1.Items.Count == 0 || txtChildStockLocation1.Text == "")
                    {
                        txtChildStockLocation1.Focus();
                        lvChildStockLocation1.Visible = false;
                    }
                    else
                    {
                        lvChildStockLocation1.Focus();
                    }
                    if (lvChildStockLocation1.Items.Count > 0)
                    {
                        lvChildStockLocation1.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtRack.Enabled == true)
                    {
                        txtRack.Focus();
                    }
                    else if (txtMrp.Enabled == true)
                    {
                        txtMrp.Focus();
                    }
                    else if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        txtChildQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtChildStockLocation1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtRack.Text = "";
                txtMrp.Text = "";
                txtChildQty.Text = "";
                udfnSLocationValid();
                lvChildStockLocation1.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtChildStockLocation1.Text.Length > 0 || txtChildStockLocation1.Text == " ")
                {
                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 10;
                    objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Location.paraId = Convert.ToInt32(varPRID);
                    objMR_Location.paraLocationName = txtChildStockLocation1.Text;
                    objDs = objspdservice.udfnStockLocationList(objMR_Location);
                    objspdservice.CloseConnection();
                    //objDs = objspdservice.udfnStockLocationList(10, Convert.ToInt32(cmbConcern.SelectedValue), 0, Convert.ToInt32(varPRID), txtChildStockLocation1.Text, 0, 0, 0, "", "", 0);
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
                                    lvChildStockLocation1.Items.Add(objList);
                                }
                                lvChildStockLocation1.Visible = true;
                            }
                            else
                            {
                                lvChildStockLocation1.Visible = false;
                            }
                        }
                        else
                        {
                            lvChildStockLocation1.Visible = false;
                        }
                    }
                    else
                    {
                        lvChildStockLocation1.Visible = false;
                    }
                }

                else
                {
                    lvChildStockLocation1.Visible = false;
                    lvChildStockLocation1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildProduct1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 77;
                objMR_Product.paraId = 1;
                objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Product.ParaProductCode = Convert.ToInt32(cmbChildProduct1.SelectedValue);
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {

                            varChild1BatchNo = objDs.Tables[0].Rows[0]["PR_BatchNo"].ToString();
                            varChild1BatchNoGeneration = objDs.Tables[0].Rows[0]["PR_BatchNoGeneration"].ToString();

                            varChild1PrMRPFlag = Convert.ToString(objDs.Tables[0].Rows[0]["PR_MRPflag"]);
                            varStockLocationId = Convert.ToString(objDs.Tables[0].Rows[0]["slid"]);
                            varRackId = string.IsNullOrEmpty(Convert.ToString(objDs.Tables[0].Rows[0]["rkid"])) ? "0" : Convert.ToString(objDs.Tables[0].Rows[0]["rkid"]);
                            txtChildStockLocation1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SL_EName"]);
                            txtRack.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RK_ShortName"]);
                            txtupp.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PR_UPP"]);
                            lbluppunit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ChildUnit"]);
                            lbluppunitid.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ChildUnitId"]);
                            varPIChildCode = Convert.ToString(objDs.Tables[0].Rows[0]["PR_PICode"]);
                            lblchildunit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UT_Symbol"]);
                            lblchildunitid.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UTID"]);
                            varDecimal = Convert.ToInt32(objDs.Tables[0].Rows[0]["UT_Decimal"]);

                            varPICode = Convert.ToString(objDs.Tables[0].Rows[0]["PR_picode"]);
                            varTamilname = Convert.ToString(objDs.Tables[0].Rows[0]["PR_tname"]);


                            lvChildStockLocation1.Visible = false;
                            lvChildRack1.Visible = false;

                            varChild1PrMRPFlag = Convert.ToString(objDs.Tables[0].Rows[0]["PR_MRPflag"]);
                            if (varChild1PrMRPFlag == "1")
                            {
                                varChild1PrMRPFlag = "1";
                                txtMrp.ReadOnly = false;
                                txtMrp.Enabled = true;
                            }
                            else
                            {
                                txtMrp.Text = "0";
                                varChild1PrMRPFlag = "0";
                                txtMrp.ReadOnly = true;
                                txtMrp.Enabled = false;
                            }
                            if (Convert.ToInt32(varChild1BatchNo) == 73)  //disabled
                            {
                                txtBatchno.Text = "";
                                txtBatchno.Enabled = false;
                            }
                            else if (Convert.ToInt32(varChild1BatchNo) == 72) //enabled
                            {
                                if (Convert.ToInt32(varChild1BatchNoGeneration) == 75)  //manual
                                {
                                    txtBatchno.Enabled = true;
                                    txtBatchno.BackColor = Color.White;
                                }
                                else if (Convert.ToInt32(varChild1BatchNoGeneration) == 74) //auto
                                {
                                    MR_Master objMR_Master = new MR_Master();
                                    objMR_Master.ViewType = 14;
                                    objDs = objspdservice.udfnMaster(objMR_Master);
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

        private void cmbChildProduct1_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbChildProduct1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildProduct1_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbChildProduct1.BackColor = Color.White;
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
                txtRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void txtRack_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvChildRack1.Items.Count == 0 || txtRack.Text == "")
                    {
                        txtRack.Focus();
                        lvChildRack1.Visible = false;
                    }
                    else
                    {
                        lvChildRack1.Focus();
                    }
                    if (lvChildRack1.Items.Count > 0)
                    {
                        lvChildRack1.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtMrp.Enabled == true)
                    {
                        txtMrp.Focus();
                    }
                    else if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        txtChildQty.Focus();
                    }
                }
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
                lvChildRack1.Items.Clear();
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
                                    lvChildRack1.Items.Add(objList);
                                }
                                lvChildRack1.Visible = true;
                                lvChildRack1.Columns[1].Width = 200;
                            }
                        }
                    }
                }
                else
                {
                    lvChildRack1.Visible = false;
                    lvChildRack1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvChildStockLocation1_KeyDown(object sender, KeyEventArgs e)
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
                    else if (txtMrp.Enabled == true)
                    {
                        txtMrp.Focus();
                    }
                    else if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        txtChildQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvChildStockLocation1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvStockLocation();

                if (txtRack.Enabled == true)
                {
                    txtRack.Focus();
                }
                else if (txtMrp.Enabled == true)
                {
                    txtMrp.Focus();
                }
                else if (txtBatchno.Enabled == true)
                {
                    txtBatchno.Focus();
                }
                else
                {
                    txtChildQty.Focus();
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
                if (txtChildStockLocation1.Text != "")
                {
                    ListViewItem selectedItem = lvChildStockLocation1.SelectedItems[0];
                    txtChildStockLocation1.Text = selectedItem.SubItems[0].Text;
                    varStockLocationId = selectedItem.SubItems[2].Text;
                }
                udfnRackcheck();


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvChildStockLocation1.Visible = false;
            }
        }
        public void udfnLvStockLocation2()
        {
            try
            {
                if (txtChildStockLocation2.Text != "")
                {
                    varStockLocationId = Convert.ToString(DGV_FilterParentLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtChildStockLocation2.Text = DGV_FilterParentLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                }
                udfnRackcheck2();


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildProduct1_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtChildStockLocation1.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnChildAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdStockadjustment.RowCount > 0)
                {


                    if (cmbChildProduct1.Text != "")
                    {
                        DGV_FilterProduct.Visible = false;
                        varErrorFlag = true;

                        if (txtRack.Text == "")
                        {
                            epStockConvertion.SetError(txtRack, "Please enter the rack name");
                            txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpOutwardQuantity.ShowAlways = true;
                            tpOutwardQuantity.Show("Please enter the rack name", txtRack, 5000);
                            varErrorFlag = false;
                        }
                        if (txtChildQty.Text == "")
                        {
                            epStockConvertion.SetError(txtChildQty, "Please enter conversion quantity");
                            txtChildQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpOutwardQuantity.ShowAlways = true;
                            tpOutwardQuantity.Show("Please enter conversion quantity", txtChildQty, 5000);
                            varErrorFlag = false;
                        }
                        if (txtChildStockLocation1.Text.Trim() == "")
                        {
                            txtChildStockLocation1.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            epStockConvertion.SetError(txtChildStockLocation1, "Please enter location.");
                            tpStockLocation.ShowAlways = true;
                            tpStockLocation.Show("Please enter location.", txtChildStockLocation1, 5000);
                            varErrorFlag = false;
                        }
                        if ((txtMrp.Text.Trim() == "" || Convert.ToDecimal(txtMrp.Text) == 0) && varPrMRPFlag == "1")
                        {
                            txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            epStockConvertion.SetError(txtMrp, "Please enter MRP.");
                            tpMrp.ShowAlways = true;
                            tpMrp.Show("Please enter MRP.", txtMrp, 5000);
                            varErrorFlag = false;
                        }

                        /* Check location is valid or not*/
                        if (txtChildStockLocation1.Text != "")
                        {
                            string varLocationId = "0";
                            DataSet objDsLocation = new DataSet();
                            SPDataService objDServ3 = new SPDataService();
                            MR_Location objMR_Location = new MR_Location();
                            objMR_Location.paraViewType = 14;
                            objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                            objMR_Location.paraLocationName = txtChildStockLocation1.Text;
                            objDsLocation = objDServ3.udfnStockLocationList(objMR_Location);
                            objDServ3.CloseConnection();
                            //objDsLocation = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtChildStockLocation1.Text.Trim(), 0, 0, 0, "", "", 0);
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
                                epStockConvertion.SetError(txtChildStockLocation1, "Please select valid location.");
                                txtChildStockLocation1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpStockLocation.ShowAlways = true;
                                tpStockLocation.Show("Please select location.", txtChildStockLocation1, 5000);
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
                                            epStockConvertion.SetError(txtRack, "Please enter valid rack.");
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
                                        epStockConvertion.SetError(txtRack, "Please enter rack.");
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
                        string varMRP = "", varNewExpiryDate = "", varBatch = "", varSLID = "", varmrptxt = "";

                        if (txtMrp.Text == "") { varmrptxt = "0"; }
                        else
                        { varmrptxt = txtMrp.Text.Trim(); }
                        varmrptxt = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(varmrptxt), 2, MidpointRounding.AwayFromZero));
                        for (int i = 0; i < grdChild.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(cmbChildProduct1.SelectedValue) == Convert.ToInt32(grdChild.Rows[i].Cells["clmConvertedPRID"].Value))
                            {
                                varMRP = Convert.ToString(grdChild.Rows[i].Cells["clmConvertedMRP"].Value).Trim();
                                varNewExpiryDate = Convert.ToString(grdChild.Rows[i].Cells["clmConvertedExpiryDate"].Value).Trim();
                                varBatch = Convert.ToString(grdChild.Rows[i].Cells["clmConvertedBatchNo"].Value).Trim();
                                varSLID = varStockLocationId;
                                varRKID = Convert.ToString(grdChild.Rows[i].Cells["ConvertedRackId"].Value).Trim();
                                if (varmrptxt == varMRP && varExpiryDate == varNewExpiryDate && txtBatchno.Text.Trim() == varBatch)
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
                        if (varErrorFlag == true)
                        {
                            int varflag = 0;

                            if (varflag == 0)
                            {

                                if (txtChildQty.Text != "")
                                {
                                    string Qty = objValidation.udfnDecimal((txtChildQty.Text).Trim(), varDecimal);
                                    txtChildQty.Text = Qty;

                                }
                                grdChild.Columns["clmConvertedproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                grdChild.Rows.Add(grdChild.Rows.Count + 1, cmbChildProduct1.SelectedValue, varPICode, (varTamilname), varStockLocationId, (txtChildStockLocation1.Text).Trim(), varRackId, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchno.Text).Trim(), 0, 0, (txtChildQty.Text), lblchildunit.Text, lblchildunitid.Text, varDecimal, txtupp.Text);


                                dtConvertedProduct.Rows.Add(cmbChildProduct1.SelectedValue, string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtMrp.Text.Trim()))), (txtExpiryDate.Text).Trim(), (txtBatchno.Text).Trim(), (txtChildQty.Text), varRackId, varStockLocationId);



                                //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                                grdChild.Columns["clmConvertedMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdChild.Columns["clmConvertedQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdChild.Columns["clmConvertedExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;




                                udfnChildProductClear();
                                cmbChildProduct1.Focus();
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
                    else
                    {
                        MessageBox.Show("No child items found for the selected parent. Define child items before converting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtProductName.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please add a parent item before conversion.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdChild.Rows.Count.ToString();

                grdStockadjustment.ClearSelection();
                grdChild.ClearSelection();
                grdParent2.ClearSelection();
                grdChild2.ClearSelection();

                grdChild_DataBindingComplete(grdChild, new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
                cmbChildProduct1_SelectedIndexChanged(sender, e);
                //DGV_inward.Sort(DGV_inward.Columns["clmpicode"], ListSortDirection.Ascending);

            }
        }

        private void grdChild_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int varProductID = 0, varRKID = 0, varSLID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (grdChild.Columns[e.ColumnIndex].Name)
                    {
                        case "clmConvertedRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdChild.SelectedRows[0].Cells["clmConvertedPRID"].Value);
                                varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdChild.SelectedRows[0].Cells["clmConvertedMRP"].Value)));
                                varExpiryDate = Convert.ToString(grdChild.SelectedRows[0].Cells["clmConvertedExpiryDate"].Value);
                                varBatchNo = Convert.ToString(grdChild.SelectedRows[0].Cells["clmConvertedBatchNo"].Value);
                                varRKID = Convert.ToInt32(grdChild.SelectedRows[0].Cells["ConvertedRackId"].Value);
                                varSLID = Convert.ToInt32(grdChild.SelectedRows[0].Cells["Convertedlocationid"].Value);
                                grdChild.Rows.RemoveAt(this.grdChild.SelectedRows[0].Index);
                                for (int i = 0; i < grdChild.RowCount; i++)
                                {
                                    grdChild.Rows[i].Cells["ConvertedSNO"].Value = i + 1;
                                }
                                for (int i = 0; i < dtConvertedProduct.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtConvertedProduct.Rows[i]["STKCONPR_PRID"]) == Convert.ToInt32(varProductID) && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtConvertedProduct.Rows[i]["STKCONPR_MRP"]))) == varMRP && Convert.ToString(dtConvertedProduct.Rows[i]["STKCONPR_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtConvertedProduct.Rows[i]["STKCONPR_BatchNo"]) == varBatchNo && Convert.ToInt32(dtConvertedProduct.Rows[i]["STKCONPR_RKID"]) == Convert.ToInt32(varRKID) && Convert.ToInt32(dtConvertedProduct.Rows[i]["STKCONPR_SLID"]) == Convert.ToInt32(varSLID))
                                    {
                                        dtConvertedProduct.Rows[i].Delete();
                                        dtConvertedProduct.AcceptChanges();
                                    }
                                }
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
                if (grdStockadjustment.Rows.Count > 0)
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

        private void grdChild_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                 

                int varDecimal = Convert.ToInt32(grdChild.CurrentRow.Cells["clmConvertedUTDecimal"].Value);

                string Qty = objValidation.udfnDecimal(Convert.ToString(grdChild.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                grdChild.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                object varEditQty = grdChild.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                // Update the same column value in the DataTable 
                dtConvertedProduct.Rows[e.RowIndex]["STKCONPR_TranactionQty"] = varEditQty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdChild_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdChild.Columns["clmConvertedQty"].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdChild.ClearSelection();

            }
        }

        private void txtChildQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnChildAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtChildQty_Leave(object sender, EventArgs e)
        {
            try
            {
                txtChildQty.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtChildQty_KeyPress(object sender, KeyPressEventArgs e)
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

       

        private void grdStockadjustment_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            try
            {
                UpdateTotal(); 
                UpdateBalanceTotal();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdStockadjustment_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                UpdateTotal(); 
                UpdateBalanceTotal();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdStockadjustment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateTotal();
                UpdateBalanceTotal();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtChildQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtChildQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdChild_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdStockadjustment.CurrentCell.OwningColumn.Name == "clmConvertedQty")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdStockadjustment.CurrentCell.OwningColumn.Name == "clmConvertedQty")
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

        private void grdChild_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                UpdateBalanceTotal(); }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdChild_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                UpdateBalanceTotal();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void grdChild_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateBalanceTotal();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMrp_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMrp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtMrp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMrp_KeyDown(object sender, KeyEventArgs e)
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
                        txtChildQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildProduct2_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbChildProduct2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildProduct2_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbChildProduct2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildProduct2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtbatch2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void cmbChildProduct2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtbatch2.Text = "";
                txtChildQty2.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbatch2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtbatch2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbatch2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtbatch2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbatch2_KeyDown(object sender, KeyEventArgs e)
        { 

            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGVBatch2.Focus();

                }
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        txtbatch2.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        txtbatch2.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                if (e.KeyCode == Keys.Enter && DGVBatch2.Visible == false)
                {
                    txtChildQty2.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGVBatch2.Focus();
                }
                if (DGVBatch2.CurrentCell == null && DGVBatch2.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGVBatch2.Focus();
                    int RowIndex = DGVBatch2.CurrentCell.RowIndex;
                    int ClmIndex = DGVBatch2.CurrentCell.ColumnIndex;
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
                            if (RowIndex >= 0) DGVBatch2.CurrentCell = DGVBatch2.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtbatch2.Text = DGVBatch2.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtbatch2.Text = DGVBatch2.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtbatch2.Focus();
                            txtbatch2.SelectionStart = txtbatch2.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGVBatch2.Rows.Count) DGVBatch2.CurrentCell = DGVBatch2.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGVBatch2.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtbatch2.Text = DGVBatch2.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtbatch2.Text = DGVBatch2.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtbatch2.Focus();
                            txtbatch2.SelectionStart = txtbatch2.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGVBatch2.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewBatch2();
                                    DGVBatch2.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtbatch2.Focus();
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
                        txtChildQty2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbatch2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (varUpDownKey == 0)
                {
                    if (VarSearchFlag == true)
                    {
                        txtbatch2.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        txtbatch2.CharacterCasing = CharacterCasing.Normal;
                    }
                    txtStockQuantity.Text = "";
                    txtParentQuantity.Text = "";
                    lblQuantity.Text = "";
                    //lvproduct.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtbatch2.Text.Length > 0 || txtbatch2.Text == " ")
                    {


                        int varEntry = 0;
                        if (btnSave.Text == "Update") { varEntry = varAJId; }
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 76;
                        objMR_Product.ParaProductCode = Convert.ToInt32(cmbChildProduct2.SelectedValue);
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraProductName = txtbatch2.Text;
                        objMR_Product.paraStockTransfer = dtStock;
                        objMR_Product.paraId = varEntry;
                        if (VarSearchFlag == false)
                        {
                            objMR_Product.paraProductName = txtbatch2.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraPicode = txtbatch2.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGVBatch2.DataSource = objDs.Tables[0];
                                    DGVBatch2.Columns["PRID"].Visible = false;

                                    DGVBatch2.Columns["PR_TName"].Visible = false;
                                    DGVBatch2.Columns["PR_EName"].Visible = false;
                                    DGVBatch2.Columns["slid"].Visible = false;
                                    DGVBatch2.Columns["PR_PICode"].Visible = false;
                                    DGVBatch2.Columns["SL_EName"].Width = 120;
                                    DGVBatch2.Columns["RK_ShortName"].Width = 70;
                                    DGVBatch2.Columns["STK_MRP"].Width = 60;
                                    DGVBatch2.Columns["STK_ExpiryDate"].Width = 90;
                                    DGVBatch2.Columns["STK_BatchNo"].Width = 70;
                                    DGVBatch2.Columns["STK_Qty"].Width = 70;
                                    DGVBatch2.Columns["UT_Symbol"].Width = 50;
                                    DGVBatch2.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGVBatch2.Columns["UTID"].Visible = false;
                                    DGVBatch2.Columns["PRODUCTLIST"].Visible = false;
                                    DGVBatch2.Columns["UT_Name"].Visible = false;
                                    DGVBatch2.Columns["STK_RKID"].Visible = false;
                                    DGVBatch2.Columns["STK_RKID"].Visible = false;
                                    DGVBatch2.Columns["UT_Decimal"].Visible = false;
                                    DGVBatch2.Columns["PR_UPP"].Visible = false;
                                    DGVBatch2.Columns["PR_PICode"].Width = 120;
                                    DGVBatch2.Columns["UT_Symbol"].Width = 60;
                                    DGVBatch2.Columns["SL_EName"].DisplayIndex = 2;
                                    DGVBatch2.Columns["RK_ShortName"].DisplayIndex = 3;
                                    DGVBatch2.Columns["STK_MRP"].DisplayIndex = 4;
                                    DGVBatch2.Columns["STK_ExpiryDate"].DisplayIndex = 5;
                                    DGVBatch2.Columns["STK_BatchNo"].DisplayIndex = 6;
                                    DGVBatch2.Columns["STK_Qty"].DisplayIndex = 7;
                                    DGVBatch2.Columns["UT_Symbol"].DisplayIndex = 8;
                                    DGVBatch2.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGVBatch2.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGVBatch2.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGVBatch2.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGVBatch2.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGVBatch2.Columns["RK_ShortName"].HeaderText = "Rack";
                                    DGVBatch2.Columns["STK_MRP"].HeaderText = "MRP";
                                    DGVBatch2.Columns["STK_ExpiryDate"].HeaderText = "Expiry Date";
                                    DGVBatch2.Columns["STK_BatchNo"].HeaderText = "Batch No.";
                                    DGVBatch2.Columns["STK_Qty"].HeaderText = "Stock Qty";
                                    DGVBatch2.Columns["SL_EName"].HeaderText = "Stock Location";
                                    DGVBatch2.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGVBatch2.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGVBatch2.Columns["STK_MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGVBatch2.Columns["STK_Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGVBatch2.Columns["STK_ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGVBatch2.Visible = true;


                                    

                                }
                                else
                                {
                                    DGVBatch2.DataSource = null;
                                    DGVBatch2.Visible = false;
                                }
                            }
                            else
                            {
                                DGVBatch2.DataSource = null;
                                DGVBatch2.Visible = false;
                            }
                        }
                        else
                        {
                            DGVBatch2.DataSource = null;
                            DGVBatch2.Visible = false;
                        }
                    }
                    else
                    {
                        DGVBatch2.DataSource = null;
                        DGVBatch2.Visible = false;
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

        private void DGVBatch2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListviewBatch2();
                txtChildQty2.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGVBatch2.Visible = false;
            }
        }

        private void DGVBatch2_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGVBatch2.CurrentCell.RowIndex;
                    int ClmIndex = DGVBatch2.CurrentCell.ColumnIndex;
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
                            if (RowIndex >= 0) DGVBatch2.CurrentCell = DGVBatch2.Rows[RowIndex].Cells[ClmIndex];

                            txtbatch2.Text = DGVBatch2.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtbatch2.Focus();
                            txtbatch2.SelectionStart = txtbatch2.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGVBatch2.Rows.Count) DGVBatch2.CurrentCell = DGVBatch2.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGVBatch2.Rows.Count))
                            {
                                txtbatch2.Text = DGVBatch2.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtbatch2.Focus();
                            txtbatch2.SelectionStart = txtbatch2.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGVBatch2.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewBatch2();
                                    DGVBatch2.Visible = false;
                                    txtChildQty2.Focus();
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

        private void txtChildQty2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtChildQty2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtChildQty2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtChildQty2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void btnChild2_Click(object sender, EventArgs e)
        { 
            try
            {
                if (cmbChildProduct2.Text != "")
                {
                    DGVBatch2.Visible = false;
                    varErrorFlag = true;
                    if (txtProductName.Text == "")
                    {
                        epStockConvertion.SetError(txtProductName, "Please enter product name");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpProduct.ShowAlways = true;
                        tpProduct.Show("Please enter product name", txtProductName, 5000);
                        varErrorFlag = false;
                    }
                    if (txtChildStockqty.Text == "")
                    {
                        epStockConvertion.SetError(txtChildStockqty, "Please enter stock quantity");
                        txtChildQty2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpOutwardQuantity.ShowAlways = true;
                        tpOutwardQuantity.Show("Please enter stock quantity", txtChildStockqty, 5000);
                        varErrorFlag = false;
                    }
                    if (txtChildQty2.Text == "")
                    {
                        epStockConvertion.SetError(txtChildQty2, "Please enter outward quantity");
                        txtChildQty2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpOutwardQuantity.ShowAlways = true;
                        tpOutwardQuantity.Show("Please enter outward quantity", txtChildQty2, 5000);
                        varErrorFlag = false;
                    }

                    if (varErrorFlag == true)
                    {
                        int varflag = 0;

                        if (varflag == 0)
                        {
                            if (Convert.ToDecimal(txtChildQty2.Text) > Convert.ToDecimal(txtChildStockqty.Text) || Convert.ToDecimal(txtChildQty2.Text) == 0)
                            {
                                txtChildQty2.Focus();
                                epStockConvertion.SetError(txtChildQty2, "Please enter a valid outward quantity");
                                txtChildQty2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpOutwardQuantity.ShowAlways = true;
                                tpOutwardQuantity.Show("Please enter a valid outward quantity", txtChildQty2, 5000);
                            }
                            else
                            {
                                if (txtChildQty2.Text != "")
                                {
                                    string Qty = objValidation.udfnDecimal((txtChildQty2.Text).Trim(), varDecimal);
                                    txtChildQty2.Text = Qty;

                                }

                                grdChild2.Columns["clmproductChild2"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                                grdChild2.Rows.Add(grdChild2.Rows.Count + 1, varPRID, varPICode, (varTamilname), varStockLocationId, (txtPStockLocation.Text).Trim(), varRKID, (txtPRack.Text).Trim(), (txtPMrp.Text).Trim(), (txtPExpiryDate.Text).Trim(), (txtPBatchNo.Text).Trim(), (txtChildStockqty.Text).Trim(), 0, (txtChildQty2.Text), varUnit, varUTID, varDecimal, txtupp.Text);

                                dtStock.Rows.Add(varPRID, string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtPMrp.Text.Trim()))), (txtPExpiryDate.Text).Trim(), (txtPBatchNo.Text).Trim(), varUTID, (txtChildQty2.Text), varRKID, varStockLocationId, varDestRKID, 0);
                                //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                                grdChild2.Columns["clmChild2MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdChild2.Columns["clmChild2stkqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdChild2.Columns["clmChild2Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdChild2.Columns["clmChild2ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                                udfnProductClear();
                                txtbatch2.Focus();
                                UpdateComboBoxState();
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
                        grdChild2_DataBindingComplete(grdChild2, new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));

                    }
                }
                else {  
                    MessageBox.Show("No child items found for the selected parent. Define child items before converting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdChild2.Rows.Count.ToString();
                grdChild2.ClearSelection();
                grdChild.ClearSelection();
                if (grdChild2.Rows.Count > 0)
                {
                    txtPStockLocation.Enabled = false;
                    cmbConcern.Enabled = false;
                    txtPStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                }
                else
                { 
                    cmbConcern.Enabled = true;
                    txtPStockLocation.Enabled = true;
                } 

            }
        }

        private void txtStockLocationChild_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPStockLocation.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
                //udfnLvStockLocation();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

       

        private void txtStockLocationChild_TextChanged(object sender, EventArgs e)
        {

            try
            {
                txtParentRack.Text = "";
                txtParentMRP.Text = "";
                txtparentqty2.Text = "";
                udfnSLocationValid();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtChildStockLocation2.Text.Length > 0 || txtChildStockLocation2.Text == " ")
                {
                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 10;
                    objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Location.paraId = Convert.ToInt32(varPRID);
                    objMR_Location.paraLocationName = txtChildStockLocation2.Text;
                    objDs = objspdservice.udfnStockLocationList(objMR_Location);
                    objspdservice.CloseConnection();
                    //objDs = objspdservice.udfnStockLocationList(10, Convert.ToInt32(cmbConcern.SelectedValue), 0, Convert.ToInt32(varPRID), txtChildStockLocation2.Text, 0, 0, 0, "", "", 0);
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                DGV_FilterParentLocation.Visible = true;
                                DGV_FilterParentLocation.DataSource = objDs.Tables[0];
                                DGV_FilterParentLocation.Columns["SLID"].Visible = false;
                                DGV_FilterParentLocation.Columns["SL_ShortName"].Visible = false;
                                DGV_FilterParentLocation.Columns["SL_EName"].HeaderText = "Location E Name";
                                DGV_FilterParentLocation.Columns["SL_TName"].HeaderText = "Location T Name";
                                DGV_FilterParentLocation.Columns["SL_EName"].Width = 160;
                                DGV_FilterParentLocation.Columns["SL_TName"].Width = 160;
                                DGV_FilterParentLocation.Columns["SL_EName"].DisplayIndex = 0;
                                DGV_FilterParentLocation.Columns["SL_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                DGV_FilterParentLocation.BringToFront();
                            }
                            else
                            {
                                DGV_FilterParentLocation.Visible = false;
                                DGV_FilterParentLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterParentLocation.Visible = false;
                            DGV_FilterParentLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterParentLocation.Visible = false;
                        DGV_FilterParentLocation.DataSource = null;
                    }
                }
                else
                {
                    DGV_FilterParentLocation.Visible = false;
                    DGV_FilterParentLocation.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtChildStockLocation2Child_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPStockLocation.BackColor = Color.LemonChiffon;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtStockLocationChild_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPStockLocation.BackColor = Color.White;
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtStockLocationChild_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyParentLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterParentLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterParentLocation.Visible == false)
                {
                    if (txtParentRack.Enabled == true)
                    {
                        txtParentRack.Focus();
                    }
                    else if (txtParentMRP.Enabled == true)
                    {
                        txtParentMRP.Focus();
                    }
                    else if (txtBatchno2.Enabled == true)
                    {
                        txtBatchno2.Focus();
                    }
                    else
                    {
                        txtparentqty2.Focus();
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterParentLocation.Focus();
                }
                if (DGV_FilterParentLocation.CurrentCell == null && DGV_FilterParentLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterParentLocation.Focus();
                    int RowIndex = DGV_FilterParentLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterParentLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyParentLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyParentLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterParentLocation.CurrentCell = DGV_FilterParentLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtChildStockLocation2.Text = DGV_FilterParentLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtChildStockLocation2.Focus();
                            txtChildStockLocation2.SelectionStart = txtChildStockLocation2.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterParentLocation.Rows.Count) DGV_FilterParentLocation.CurrentCell = DGV_FilterParentLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterParentLocation.Rows.Count))
                            {
                                txtChildStockLocation2.Text = DGV_FilterParentLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtChildStockLocation2.Focus();
                            txtChildStockLocation2.SelectionStart = txtChildStockLocation2.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterParentLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyParentLocation = 1;
                                    udfnLvStockLocation2();
                                    DGV_FilterParentLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtChildStockLocation2.Focus();
                    //txtChildStockLocation2.SelectionStart = txtChildStockLocation2.Text.Length;
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
                        if (txtParentRack.Enabled == true)
                        {
                            txtParentRack.Focus();
                        }
                        else if (txtParentMRP.Enabled == true)
                        {
                            txtParentMRP.Focus();
                        }
                        else if (txtBatchno2.Enabled == true)
                        {
                            txtBatchno2.Focus();
                        }
                        else
                        {
                            txtparentqty2.Focus();
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

        private void lvParentStockLocation1_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation2();
                    if (txtParentRack.Enabled == true)
                    {
                        txtParentRack.Focus();
                    }
                    else if (txtParentMRP.Enabled == true)
                    {
                        txtParentMRP.Focus();
                    }
                    else if (txtBatchno2.Enabled == true)
                    {
                        txtBatchno2.Focus();
                    }
                    else
                    {
                        txtChildQty2.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvParentStockLocation1_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                udfnLvStockLocation2();

                if (txtParentRack.Enabled == true)
                {
                    txtParentRack.Focus();
                }
                else if (txtParentMRP.Enabled == true)
                {
                    txtParentMRP.Focus();
                }
                else if (txtBatchno2.Enabled == true)
                {
                    txtBatchno2.Focus();
                }
                else
                {
                    txtChildQty2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtChildQty2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnChild2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtParentRack_TextChanged(object sender, EventArgs e)
        {

            try
            {
                //txtBatchNo.Enabled = true;
                lvParenetRack1.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtParentRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(varStockLocationId), 0, txtParentRack.Text.Trim(), 0, 0);
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
                                    lvParenetRack1.Items.Add(objList);
                                }
                                lvParenetRack1.Visible = true;
                                lvParenetRack1.Columns[1].Width = 200;
                            }
                        }
                    }
                }
                else
                {
                    lvParenetRack1.Visible = false;
                    lvParenetRack1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtParentRack_Leave(object sender, EventArgs e)
        {
            try
            {
                txtParentRack.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtParentRack_Enter(object sender, EventArgs e)
        {
            try
            {
                txtParentRack.BackColor = Color.LemonChiffon;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtParentRack_KeyDown(object sender, KeyEventArgs e)
        {


            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvParenetRack1.Items.Count == 0 || txtParentRack.Text == "")
                    {
                        txtParentRack.Focus();
                        lvParenetRack1.Visible = false;
                    }
                    else
                    {
                        lvParenetRack1.Focus();
                    }
                    if (lvParenetRack1.Items.Count > 0)
                    {
                        lvParenetRack1.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                      if (txtParentMRP.Enabled == true)
                    {
                        txtParentMRP.Focus();
                    }
                    else if (txtBatchno2.Enabled == true)
                    {
                        txtBatchno2.Focus();
                    }
                    else
                    {
                        txtChildQty2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvParenetRack1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnRackAutocomplete2();
                    if (txtParentMRP.Enabled == true)
                    {
                        txtParentMRP.Focus();
                    }
                    else if (txtBatchno2.Enabled == true)
                    {
                        txtBatchno2.Focus();
                    }
                    else
                    {
                        txtChildQty2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvParenetRack1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnRackAutocomplete2();
                if (txtParentMRP.Enabled == true)
                {
                    txtParentMRP.Focus();
                }
                else if (txtBatchno2.Enabled == true)
                {
                    txtBatchno2.Focus();
                }
                else
                {
                    txtChildQty2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnRackAutocomplete2()
        {
            try
            {
                if (txtParentRack.Text != "")
                {
                    ListViewItem selectedItem = lvParenetRack1.SelectedItems[0];
                    txtParentRack.Text = selectedItem.SubItems[0].Text;
                    varRackId = selectedItem.SubItems[2].Text;
                    //txtRackDescription.Text = selectedItem.SubItems[1].Text;
                    lvParenetRack1.Visible = false;
                    
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvParenetRack1.Visible = false;
            }
        }

        public void udfnRackAutocomplete()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvChildRack1.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    varRKID = selectedItem.SubItems[2].Text;
                    //txtRackDescription.Text = selectedItem.SubItems[1].Text;
                    lvChildRack1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvChildRack1.Visible = false;
            }
        }
        private void lvChildRack1_DoubleClick(object sender, EventArgs e)
        {
            try
            { 
                    udfnRackAutocomplete();
                if (txtMrp.Enabled == true)
                {
                    txtMrp.Focus();
                }
                else if (txtBatchno.Enabled == true)
                {
                    txtBatchno.Focus();
                }
                else
                {
                    txtChildQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvChildRack1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnRackAutocomplete();
                    if (txtMrp.Enabled == true)
                    {
                        txtMrp.Focus();
                    }
                    else if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        txtChildQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtParentMRP_Leave(object sender, EventArgs e)
        {
            try
            {
                txtParentMRP.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtParentMRP_Enter(object sender, EventArgs e)
        {

            try
            {
                txtParentMRP.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtParentMRP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtParentMRP_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                      if (txtBatchno2.Enabled == true)
                    {
                        txtBatchno2.Focus();
                    }
                    else
                    {
                        txtChildQty2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBatchno2_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyCode == Keys.Enter)
                {
                    
                        txtparentqty2.Focus(); 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBatchno2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBatchno2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBatchno2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchno2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtparentqty2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtparentqty2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtparentqty2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtparentqty2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtparentqty2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnParentAdd2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnParentAdd2_Click(object sender, EventArgs e)
        {

            try
            {
                if (grdChild2.RowCount > 0)
                {
                    DGV_FilterProduct.Visible = false;
                    varErrorFlag = true;

                    if (txtParentRack.Text == "")
                    {
                        epStockConvertion.SetError(txtParentRack, "Please enter the rack name");
                        txtParentRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpOutwardQuantity.ShowAlways = true;
                        tpOutwardQuantity.Show("Please enter the rack name", txtParentRack, 5000);
                        varErrorFlag = false;
                    }
                    if (txtparentqty2.Text == "")
                    {
                        epStockConvertion.SetError(txtparentqty2, "Please enter conversion quantity");
                        txtparentqty2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpOutwardQuantity.ShowAlways = true;
                        tpOutwardQuantity.Show("Please enter conversion quantity", txtparentqty2, 5000);
                        varErrorFlag = false;
                    }
                    if (txtChildStockLocation2.Text.Trim() == "")
                    {
                        txtChildStockLocation2.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epStockConvertion.SetError(txtChildStockLocation2, "Please enter location.");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please enter location.", txtChildStockLocation2, 5000);
                        varErrorFlag = false;
                    }
                    if ((txtParentMRP.Text.Trim() == "" || Convert.ToDecimal(txtParentMRP.Text) == 0) && varPrMRPFlag == "1")
                    {
                        txtParentMRP.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epStockConvertion.SetError(txtParentMRP, "Please enter MRP.");
                        tpMrp.ShowAlways = true;
                        tpMrp.Show("Please enter MRP.", txtParentMRP, 5000);
                        varErrorFlag = false;
                    }

                    /* Check location is valid or not*/
                    if (txtChildStockLocation2.Text != "")
                    {
                        string varLocationId = "0";
                        DataSet objDsLocation = new DataSet();
                        SPDataService objDServ3 = new SPDataService();

                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 14;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtChildStockLocation2.Text;
                        objDsLocation = objDServ3.udfnStockLocationList(objMR_Location);
                        objDServ3.CloseConnection();
                        //objDsLocation = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtChildStockLocation2.Text.Trim(), 0, 0, 0, "", "", 0);
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
                            epStockConvertion.SetError(txtChildStockLocation2, "Please select valid location.");
                            txtChildStockLocation2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpStockLocation.ShowAlways = true;
                            tpStockLocation.Show("Please select location.", txtChildStockLocation2, 5000);
                            varErrorFlag = false;
                        }
                    }
                    if (txtParentRack.Text.Trim() != "" && txtParentRack.Text.Trim() != "None" && txtParentRack.Text.Trim() != "none")
                    {
                        /*check location have a rack or not*/
                        string varId_PurchaseRack = "0";
                        string varId_PurchaseRackCount = "0";
                        DataSet objDsPurchaseRack = new DataSet();
                        SPDataService objDServ6 = new SPDataService();
                        objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varStockLocationId), 0, txtParentRack.Text.Trim(), 0, 0);
                        objDServ6.CloseConnection();
                        if (txtParentRack.Text.Trim() != "")
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
                                        epStockConvertion.SetError(txtParentRack, "Please enter valid rack.");
                                        txtParentRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                                        tprack.ShowAlways = true;
                                        tprack.Show("Please enter valid rack.", txtParentRack, 5000);
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
                                    epStockConvertion.SetError(txtParentRack, "Please enter rack.");
                                    txtParentRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tprack.ShowAlways = true;
                                    tprack.Show("Please enter rack.", txtParentRack, 5000);
                                    varErrorFlag = false;
                                }
                                if (varId_PurchaseRack == "0")
                                {
                                    txtParentRack.Text = "None";
                                    txtParentRack.Enabled = false;
                                    varRKID = "0";
                                }
                                else
                                {
                                    txtParentRack.Enabled = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        txtParentRack.Text = "None";
                        varRKID = "0";
                    }
                    string varMRP = "", varNewExpiryDate = "", varBatch = "", varSLID = "", varmrptxt = "";

                    if (txtParentMRP.Text == "") { varmrptxt = "0"; }
                    else
                    { varmrptxt = txtParentMRP.Text.Trim(); }
                    varmrptxt = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(varmrptxt), 2, MidpointRounding.AwayFromZero));
                    for (int i = 0; i < grdParent2.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(cmbChildProduct1.SelectedValue) == Convert.ToInt32(grdParent2.Rows[i].Cells["clmpridparent2"].Value))
                        {
                            varMRP = Convert.ToString(grdParent2.Rows[i].Cells["clmparent2MRP"].Value).Trim();
                            varNewExpiryDate = Convert.ToString(grdParent2.Rows[i].Cells["clmparent2ExpiryDate"].Value).Trim();
                            varBatch = Convert.ToString(grdParent2.Rows[i].Cells["clmparent2BatchNo"].Value).Trim();
                            varSLID = varStockLocationId;
                            varRKID = Convert.ToString(grdParent2.Rows[i].Cells["clmRackIdparent2"].Value).Trim();
                            if (varmrptxt == varMRP && varExpiryDate == varNewExpiryDate && txtBatchno.Text.Trim() == varBatch)
                            {
                                if (varStockLocationId.Trim() == varSLID && varRKID.Trim() == varRKID)
                                {
                                    SPDataService objDServ = new SPDataService();
                                    DataSet objDS = new DataSet();
                                    txtbatch2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
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
                        int varflag = 0;

                        if (varflag == 0)
                        {

                            if (txtparentqty2.Text != "")
                            {
                                string Qty = objValidation.udfnDecimal((txtparentqty2.Text).Trim(), varDecimal);
                                txtparentqty2.Text = Qty;

                            }
                            grdParent2.Columns["clmproductparent2"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdParent2.Rows.Add(grdParent2.Rows.Count + 1, varParentId, varParentPIcode, (varParentTname), varStockLocationId, (txtChildStockLocation2.Text).Trim(), varRackId, (txtParentRack.Text).Trim(), (varmrptxt).Trim(), (txtExpiryDate2.Text).Trim(), (txtBatchno2.Text).Trim(), 0, 0, (txtparentqty2.Text), varParentUnit, varParentUnitID, varParentUnitDecimal);


                            dtConvertedProduct.Rows.Add(varParentId, string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtParentMRP.Text.Trim()))), (txtExpiryDate2.Text).Trim(), (txtBatchno2.Text).Trim(), (txtparentqty2.Text), varRackId, varStockLocationId);



                            //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                            grdParent2.Columns["clmparent2MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdParent2.Columns["clmparent2Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdParent2.Columns["clmparent2ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;




                            udfnChildProductClear();
                            cmbChildProduct1.Focus();
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(70);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                        varChangeFlag = false;
                        txtChildStockLocation2.Focus();
                    }
                }
                else { 
                    MessageBox.Show("Please add a child item before conversion.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdParent2.Rows.Count.ToString();
                grdChild2.ClearSelection();
                grdParent2.ClearSelection();

                grdParent2_DataBindingComplete(grdParent2, new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
                //DGV_inward.Sort(DGV_inward.Columns["clmpicode"], ListSortDirection.Ascending);

            }
        }

        private void txtChildQty2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void grdChild2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            try
            {
                UpdateTotalChild(); UpdateBalanceTotalChild();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdChild2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            try
            {
                UpdateTotalChild(); UpdateBalanceTotalChild();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdChild2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                UpdateTotalChild(); UpdateBalanceTotalChild();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildProduct1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void grdChild2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0, varRKID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (grdChild2.Columns[e.ColumnIndex].Name)
                    {
                        case "clmChild2Remove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdChild2.SelectedRows[0].Cells["clmpridChild2"].Value);
                                //varMRP = Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmmrp"].Value);
                                varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdChild2.SelectedRows[0].Cells["clmChild2MRP"].Value)));
                                varExpiryDate = Convert.ToString(grdChild2.SelectedRows[0].Cells["clmChild2ExpiryDate"].Value);
                                varBatchNo = Convert.ToString(grdChild2.SelectedRows[0].Cells["clmChild2BatchNo"].Value);
                                varRKID = Convert.ToInt32(grdChild2.SelectedRows[0].Cells["clmRackIdChild2"].Value);
                                grdChild2.Rows.RemoveAt(this.grdChild2.SelectedRows[0].Index);
                                for (int i = 0; i < grdChild2.RowCount; i++)
                                {
                                    grdChild2.Rows[i].Cells["clmslno2"].Value = i + 1;
                                }
                                for (int i = 0; i < dtStock.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID) && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtStock.Rows[i]["STK_MRP"]))) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToInt32(dtStock.Rows[i]["STK_Source_RKID"]) == Convert.ToInt32(varRKID))
                                    {
                                        dtStock.Rows[i].Delete();
                                        dtStock.AcceptChanges();
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
                if (grdStockadjustment.Rows.Count > 0)
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

        private void grdChild2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                decimal StockcellValue = Convert.ToDecimal(grdChild2.CurrentRow.Cells["clmChild2stkqty"].Value);
                decimal OutwardcellValue = Convert.ToDecimal(grdChild2.CurrentRow.Cells["clmChild2Qty"].Value);

                if (Convert.ToDecimal(OutwardcellValue) > Convert.ToDecimal(StockcellValue))
                {
                    grdChild2.CurrentRow.Cells["clmChild2Qty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //epGoodsOutward.SetError(DGV_inward, "Please enter valid outward qty");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter valid outward quantity", grdChild2, 5000);
                    SPDataService objDServ = new SPDataService();
                    objDServ.CloseConnection();
                    varErrQty = 1;
                    //MessageBox.Show("Please Enter Valid Outward Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToString(OutwardcellValue) == "" || Convert.ToString(OutwardcellValue) == "0")
                {
                    grdChild2.Rows[e.RowIndex].Cells["clmChild2Qty"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrQty = 1;
                }
                else
                {
                    grdChild2.CurrentRow.Cells["clmChild2Qty"].Style.BackColor = Color.PaleGreen;
                    varErrQty = 0;
                }
                int varDecimal = Convert.ToInt32(grdChild2.CurrentRow.Cells["clmChild2UTDecimal"].Value);

                string Qty = objValidation.udfnDecimal(Convert.ToString(grdChild2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                grdChild2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                object varEditQty = grdChild2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                // Update the same column value in the DataTable
                dtStock.Rows[e.RowIndex]["STK_QTY"] = varEditQty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdChild2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdChild2.CurrentCell.OwningColumn.Name == "clmChild2Qty")
                {
                    e.Control.KeyPress -= udfngrdChild2HandleKeyPress;
                    e.Control.KeyPress += udfngrdChild2HandleKeyPress;
                }
                if (grdChild2.CurrentCell.OwningColumn.Name == "clmChild2Qty")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumbergrdchild2);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdChild2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdChild2.Columns["clmChild2Qty"].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdParent2.ClearSelection();
                grdChild2.ClearSelection();

            }
        }

        private void grdParent2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                int varDecimal = Convert.ToInt32(grdParent2.CurrentRow.Cells["clmparent2UTDecimal"].Value);

                string Qty = objValidation.udfnDecimal(Convert.ToString(grdParent2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                grdParent2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                object varEditQty = grdParent2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                // Update the same column value in the DataTable 
                dtConvertedProduct.Rows[e.RowIndex]["STKCONPR_TranactionQty"] = varEditQty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdParent2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int varProductID = 0, varRKID = 0, varSLID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (grdParent2.Columns[e.ColumnIndex].Name)
                    {
                        case "clmparent2Remove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdParent2.SelectedRows[0].Cells["clmpridparent2"].Value);
                                varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdParent2.SelectedRows[0].Cells["clmparent2MRP"].Value)));
                                varExpiryDate = Convert.ToString(grdParent2.SelectedRows[0].Cells["clmparent2ExpiryDate"].Value);
                                varBatchNo = Convert.ToString(grdParent2.SelectedRows[0].Cells["clmparent2BatchNo"].Value);
                                varRKID = Convert.ToInt32(grdParent2.SelectedRows[0].Cells["clmRackIdparent2"].Value);
                                varSLID = Convert.ToInt32(grdParent2.SelectedRows[0].Cells["clmlocationidparent2"].Value);
                                grdParent2.Rows.RemoveAt(this.grdParent2.SelectedRows[0].Index);
                                for (int i = 0; i < grdParent2.RowCount; i++)
                                {
                                    grdParent2.Rows[i].Cells["clmslnoparent2"].Value = i + 1;
                                }
                                for (int i = 0; i < dtConvertedProduct.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtConvertedProduct.Rows[i]["STKCONPR_PRID"]) == Convert.ToInt32(varProductID) && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtConvertedProduct.Rows[i]["STKCONPR_MRP"]))) == varMRP && Convert.ToString(dtConvertedProduct.Rows[i]["STKCONPR_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtConvertedProduct.Rows[i]["STKCONPR_BatchNo"]) == varBatchNo && Convert.ToInt32(dtConvertedProduct.Rows[i]["STKCONPR_RKID"]) == Convert.ToInt32(varRKID) && Convert.ToInt32(dtConvertedProduct.Rows[i]["STKCONPR_SLID"]) == Convert.ToInt32(varSLID))
                                    {
                                        dtConvertedProduct.Rows[i].Delete();
                                        dtConvertedProduct.AcceptChanges();
                                    }
                                }
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
                if (grdStockadjustment.Rows.Count > 0)
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

        private void grdParent2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try {
                UpdateBalanceTotalChild();
                    }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnBatch1_Click(object sender, EventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                txtbatch2.Text = " ";
                txtbatch2_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void btnbatch2_Click(object sender, EventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                txtbatch1.Text = " ";
                txtbatch1_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterParentLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyParentLocation = 1;
                udfnLvStockLocation2();

                if (txtParentRack.Enabled == true)
                {
                    txtParentRack.Focus();
                }
                else if (txtParentMRP.Enabled == true)
                {
                    txtParentMRP.Focus();
                }
                else if (txtBatchno2.Enabled == true)
                {
                    txtBatchno2.Focus();
                }
                else
                {
                    txtparentqty2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterParentLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterParentLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterParentLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyParentLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyParentLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterParentLocation.CurrentCell = DGV_FilterParentLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtChildStockLocation2.Text = DGV_FilterParentLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtChildStockLocation2.Focus();
                            txtChildStockLocation2.SelectionStart = txtChildStockLocation2.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterParentLocation.Rows.Count) DGV_FilterParentLocation.CurrentCell = DGV_FilterParentLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterParentLocation.Rows.Count))
                            {
                                txtChildStockLocation2.Text = DGV_FilterParentLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtChildStockLocation2.Focus();
                            txtChildStockLocation2.SelectionStart = txtChildStockLocation2.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterParentLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyParentLocation = 1;
                                    udfnLvStockLocation2();
                                    DGV_FilterParentLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtParentRack.Enabled == true)
                        {
                            txtParentRack.Focus();
                        }
                        else if (txtParentMRP.Enabled == true)
                        {
                            txtParentMRP.Focus();
                        }
                        else if (txtBatchno2.Enabled == true)
                        {
                            txtBatchno2.Focus();
                        }
                        else
                        {
                            txtparentqty2.Focus();
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

        private void grdParent2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                UpdateBalanceTotalChild();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdParent2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateBalanceTotalChild();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildProduct2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void grdParent2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdParent2.CurrentCell.OwningColumn.Name == "clmparent2Qty")
                {
                    e.Control.KeyPress -= udfngrdParent2HandleKeyPress;
                    e.Control.KeyPress += udfngrdParent2HandleKeyPress;
                }
                if (grdParent2.CurrentCell.OwningColumn.Name == "clmparent2Qty")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumbergrdparent2);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdParent2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdParent2.Columns["clmparent2Qty"].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { 

                grdParent2.ClearSelection();
                grdChild2.ClearSelection();

            }

        }

        private void grpChildType1_Enter(object sender, EventArgs e)
        {

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
                txtParentQuantity.TextAlign = HorizontalAlignment.Right;
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
                    txtPStockLocation.Focus();
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
                grdChild.ClearSelection();
                grdParent2.ClearSelection();
                grdChild2.ClearSelection();

            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (varBalanceqty != 0) 
                { 
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(166);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 379) // parent - child

                {

                    if (grdChild.Rows.Count == 0)
                    {





                        SPDataService objDServ = new SPDataService();

                        string varMessage = objDServ.udfnGetMessages(38);

                        objDServ.CloseConnection();

                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;

                    }

                }

                else if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 380) // child - parent

                {

                    if (grdParent2.Rows.Count == 0)

                    {

                        SPDataService objDServ = new SPDataService();

                        string varMessage = objDServ.udfnGetMessages(38);

                        objDServ.CloseConnection();

                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;

                    }

                }
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
                varoriginator = "Stock Conversion Creation";
                ViewType = 0;
                bool GOID = Convert.ToBoolean(varAJId);

                //if(btnSave.Text=="Save as Draft")
                //{
                //    ViewType = 0;
                //    varStatusId = 35;
                //    varoriginator = "Goods Outward Creation";
                //}
                //if (btnSave.Text == "Save")
                //{
                //    ViewType = 0;
                //    varStatusId = 26;
                //    varoriginator = "Goods Outward Updation";
                //}
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

                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epStockConvertion.SetError(cmbTransactionType, "Please select transaction type");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select transaction type", cmbTransactionType, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 379) // parent - child
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
                else
                {
                    for (int i = 0; i < grdChild2.Rows.Count; i++) // child - parent
                    {
                        if (Convert.ToString(grdChild2.Rows[i].Cells["clmChild2Qty"].Value) == "" || Convert.ToDecimal(grdChild2.Rows[i].Cells["clmChild2Qty"].Value) == 0 || Convert.ToDecimal(grdChild2.Rows[i].Cells["clmChild2stkqty"].Value) < Convert.ToDecimal(grdChild2.Rows[i].Cells["clmChild2Qty"].Value))
                        {
                            varErrorFlag = false; varErrQty = 1;
                            grdChild2.Rows[i].Cells["clmChild2Qty"].Style.BackColor = Color.LightPink;
                        }
                        else
                        {
                            grdChild2.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                            grdChild2.Rows[i].Cells["clmChild2Qty"].Style.BackColor = Color.PaleGreen;
                        }
                    }
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
                    int type = Convert.ToInt32(cmbTransactionType.SelectedValue);


                    udfntooltiphide();
                    epStockConvertion.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();
                    TRN_Stock_Converstion objTRN_Stock_Converstion = new TRN_Stock_Converstion();


                    if (varAJId != 0)
                    {
                        ViewType = 1;
                    }
                    objTRN_Stock_Converstion.ViewType = ViewType;
                    objTRN_Stock_Converstion.ParaTransactionId = varAJId;
                    objTRN_Stock_Converstion.ParaCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_Stock_Converstion.paraOutwardDate = dtpConvertDate.Text;
                    objTRN_Stock_Converstion.paraPRID = Convert.ToInt32(varParentId);
                    objTRN_Stock_Converstion.paraTransferType = type;
                    objTRN_Stock_Converstion.paraRemarks = txtRemark.Text.Trim();
                    objTRN_Stock_Converstion.paraOriginator = varoriginator;
                    objTRN_Stock_Converstion.ParaFlag = varCompleteFlag;
                    objTRN_Stock_Converstion.paraStockConversion = dtConvertedProduct;
                    objTRN_Stock_Converstion.paraStockTransfer = dtStock;
                    objTRN_Stock_Converstion.paraStatusId = 14;
                    result = objspdservice.udfnStockConvertion(objTRN_Stock_Converstion);
                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (result.Split('~')[0] == "3")
                    {
                        if (result.Split('~')[0] != "1")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ActiveControl = txtProductName;
                            MainForm.objINV_StockJournalList.udfnList();
                            udfnClear();
                            this.Close();
                        }
                    }
                    else if (result.Split('~')[0] == "5")
                    {

                        MessageBox.Show(result.Split('~')[1] +"( " +result.Split('~')[2] + " )", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                grdStockadjustment.ClearSelection();
                grdChild.ClearSelection();
                grdParent2.ClearSelection();
                grdChild2.ClearSelection();
            }
        }
        public void udfnOutwardReport(string varOutwardId)
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_GoodsOutward.rpt");
                    varHeader = "Goods Outward Report";

                    objBillreport.SetParameterValue("paraGOID", Convert.ToInt32(varOutwardId));
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
        public void udfnClear()
        {
            try
            {
                btnSave.Enabled = true;
                cmbConcern.Text = "";
                txtStockConvertNo.Text = "";
                txtPStockLocation.Text = "";
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
                epStockConvertion.Clear();
                cmbConcern.BackColor = Color.White;
                tpConcern.Active = false;
                cmbTransactionType.BackColor = Color.White;
                tpTransactionType.Active = false;
                txtPStockLocation.BackColor = Color.White;
                tpStockLocation.Active = false;
                //txtProduct.BackColor = Color.White;
                tpProduct.Active = false;
                txtParentQuantity.BackColor = Color.White;
                tpOutwardQuantity.Active = false;
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
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 379) // parent - child
                {
                    grpChildType1.Visible = true;
                    grpParentType1.Visible = true;
                    grpChildType2.Visible = false;
                    grpParentType2.Visible = false;
                }
                else if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 380) // child - parent
                {
                    grpChildType1.Visible = false;
                    grpParentType1.Visible = false;
                    grpChildType2.Visible = true;
                    grpParentType2.Visible = true;
                }
                txtProductName.Text = "";
                varParentId = "0";
                varParentPIcode = "";
                varParentTname = "";


                varParentUnit = "";
                varParentUnitID = "0";
                varParentUnitDecimal = "0";
                lblparnetconvertunit.Text = "";

                udfnProductClear();
                udfnChildProductClear();
                txtParent2.Text = "";
                txtParentProduct1.Text = "";
                txtExpiryDate.Text = "";
                txtExpiryDate2.Text = "";
                grdChild.DataSource = null;
                grdChild2.DataSource = null;
                grdParent2.DataSource = null;
                grdStockadjustment.DataSource = null;
                lvChildRack1.Visible = false;
                lvParenetRack1.Visible = false;
                lvChildStockLocation1.Visible = false;
                DGV_FilterParentLocation.Visible = false;
                DGV_FilterParentLocation.DataSource = null;

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
                txtPRack.Text = "";
                txtPMrp.Text = "";
                txtPExpiryDate.Text = "";
                txtPBatchNo.Text = "";
                txtStockQuantity.Text = "";
                txtParentQuantity.Text = "";

                txtChildStockqty.Text = "";
                txtChildQty2.Text = "";

                varPICode = "";
                varRKID = "";
                varUTID = "";
                lblQuantity.Text = "";

                varStockLocationId = "";
                txtPStockLocation.Text = "";
                lblParentStockDetail.Text = "";
                lblChildStockDetail.Text = "";
                txtbatch1.Text = "";
                txtbatch2.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnChildProductClear()
        {
            try
            {


                varChild1BatchNo = "";
                varChild1BatchNoGeneration = "";

                varChild1PrMRPFlag = "";
                varStockLocationId = "0";
                varRackId = "0";
                txtChildStockLocation1.Text = "";
                txtChildStockLocation2.Text = "";
                txtRack.Text = "";
                txtupp.Text = "";
                lbluppunit.Text = "";
                lbluppunitid.Text = "0";
                varPIChildCode = "";
                txtMrp.Text = "0";
                lblchildunit.Text = "";
                varDecimal = 0;
                lblchildunitid.Text = "0";
                txtBatchno.Text = "";

                txtParentRack.Text = "";
                txtParentMRP.Text = "";
                txtBatchno2.Text = "";
                txtparentqty2.Text = "";
                

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void clearAll()
        {

            try
            {
                txtPRack.Text = "";
                txtPMrp.Text = "";
                txtPExpiryDate.Text = "";
                txtPBatchNo.Text = "";
                txtStockQuantity.Text = "";
                txtParentQuantity.Text = "";
                varPRID = "";
                varPICode = "";
                varRKID = "";
                varUTID = "";
                lblQuantity.Text = "";
                varStockLocationId = "";
                txtPStockLocation.Text = "";
                txtParentProduct1.Text = "";
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
                                UpdateComboBoxState();
                                btnbatch2.Enabled = true;
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
                if (grdStockadjustment.Rows.Count > 0)
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
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                varErrorFlag = true;
                if (txtProductName.Text == "")
                {
                    epStockConvertion.SetError(txtProductName, "Please enter product name");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductName, 5000);
                    varErrorFlag = false;
                }
                if (txtPRack.Text == "")
                {
                    epStockConvertion.SetError(txtPRack, "Please enter the rack name");
                    txtParentQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter the rack name", txtPRack, 5000);
                    varErrorFlag = false;
                }
                if (txtStockQuantity.Text == "")
                {
                    epStockConvertion.SetError(txtStockQuantity, "Please enter stock quantity");
                    txtParentQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter stock quantity", txtStockQuantity, 5000);
                    varErrorFlag = false;
                }
                if (txtParentQuantity.Text == "")
                {
                    epStockConvertion.SetError(txtParentQuantity, "Please enter outward quantity");
                    txtParentQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter outward quantity", txtParentQuantity, 5000);
                    varErrorFlag = false;
                }

                if (varErrorFlag == true)
                {
                    int varflag = 0;

                    if (varflag == 0)
                    {
                        if (Convert.ToDecimal(txtParentQuantity.Text) > Convert.ToDecimal(txtStockQuantity.Text) || Convert.ToDecimal(txtParentQuantity.Text) == 0)
                        {
                            txtParentQuantity.Focus();
                            epStockConvertion.SetError(txtParentQuantity, "Please enter a valid outward quantity");
                            txtParentQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpOutwardQuantity.ShowAlways = true;
                            tpOutwardQuantity.Show("Please enter a valid outward quantity", txtParentQuantity, 5000);
                        }
                        else
                        {
                            if (txtParentQuantity.Text != "")
                            {
                                string Qty = objValidation.udfnDecimal((txtParentQuantity.Text).Trim(), varDecimal);
                                txtParentQuantity.Text = Qty;

                            }
                            grdStockadjustment.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdStockadjustment.Rows.Add(grdStockadjustment.Rows.Count + 1, varPRID, varPICode, (varTamilname), varStockLocationId, (txtPStockLocation.Text).Trim(), varRKID, (txtPRack.Text).Trim(), (txtPMrp.Text).Trim(), (txtPExpiryDate.Text).Trim(), (txtPBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtParentQuantity.Text), varUnit, varUTID, varDecimal);
                            dtStock.Rows.Add(varPRID, string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtPMrp.Text.Trim()))), (txtPExpiryDate.Text).Trim(), (txtPBatchNo.Text).Trim(), varUTID, (txtParentQuantity.Text), varRKID, varStockLocationId, varDestRKID, 0);
                            //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                            grdStockadjustment.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockadjustment.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockadjustment.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockadjustment.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                            udfnProductClear();
                            txtbatch1.Focus();
                            UpdateComboBoxState();
                            cmbChildProduct1_SelectedIndexChanged(sender, e);
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
                grdStockadjustment.Rows.Count.ToString();
                grdStockadjustment.ClearSelection();
                grdChild.ClearSelection();
                grdParent2.ClearSelection();
                grdChild2.ClearSelection();
                if (grdStockadjustment.Rows.Count > 0)
                {
                    txtPStockLocation.Enabled = false;
                    cmbConcern.Enabled = false;
                    txtPStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                }
                else
                {
                    //txtChildStockLocation2.BackColor =Color.White;
                    cmbConcern.Enabled = true;
                    txtPStockLocation.Enabled = true;
                }
                //DGV_inward.Sort(DGV_inward.Columns["clmpicode"], ListSortDirection.Ascending);

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
                    TRN_Stock_Converstion objTRN_Stock_Converstion = new TRN_Stock_Converstion();
                    objTRN_Stock_Converstion.ViewType = ViewType;
                    objTRN_Stock_Converstion.ParaTransactionId = Convert.ToInt32(varAJId);
                    objDs = objdserv.udfnStockConverstionList(objTRN_Stock_Converstion);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            varTransType = objDs.Tables[0].Rows[0]["STKCON_TransactionType"].ToString();
                            cmbTransactionType.Text = objDs.Tables[0].Rows[0]["Transaction Type"].ToString();
                            cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["STKCON_COMID"].ToString();
                            dtpConvertDate.Text = objDs.Tables[0].Rows[0]["STKCON_Date"].ToString();
                            txtStockConvertNo.Text = objDs.Tables[0].Rows[0]["STKCON_No"].ToString();
                            txtRemark.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                            txtProductName.Text = objDs.Tables[0].Rows[0]["parentname"].ToString();
                            varParentId = objDs.Tables[0].Rows[0]["Parentid"].ToString();
                        }

                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 379) // parent - child
                                {

                                    if (Convert.ToString(objDs.Tables[1].Rows[i]["STKCON_Type"]) == "2") // OUTWARD QTY
                                    {

                                        grdStockadjustment.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                                        grdStockadjustment.Rows.Add(grdStockadjustment.Rows.Count + 1, Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SL_ENAME"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), 0, Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKCONPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Decimal"]));


                                        dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKCONPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), 0, 0);

                                        lblParentBalUnit.Text = Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]);
                                        lblParentTotUnit.Text = Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]);

                                        grdStockadjustment.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdStockadjustment.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdStockadjustment.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdStockadjustment.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    }
                                    else  // INWARD QTY
                                    {


                                        grdChild.Columns["clmConvertedproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                                        grdChild.Rows.Add(grdChild.Rows.Count + 1, Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SL_ENAME"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), 0, Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKCONPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Decimal"]), Convert.ToString(objDs.Tables[1].Rows[i]["uppvalue"]));

                                        dtConvertedProduct.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKCONPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]));




                                        grdChild.Columns["clmConvertedMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdChild.Columns["clmConvertedQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdChild.Columns["clmConvertedExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    }
                                }
                                else if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 380) // child - parent
                                {

                                    if (Convert.ToString(objDs.Tables[1].Rows[i]["STKCON_Type"]) == "2") // OUTWARD QTY
                                    {

                                        grdChild2.Columns["clmproductChild2"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                                        grdChild2.Rows.Add(grdChild2.Rows.Count + 1, Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SL_ENAME"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), 0, Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKCONPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Decimal"]), Convert.ToString(objDs.Tables[1].Rows[i]["uppvalue"]));


                                        dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKCONPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), 0, 0);

                                        lblParentBalUnit.Text = Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]);
                                        lblParentTotUnit.Text = Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]);

                                        grdChild2.Columns["clmChild2MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdChild2.Columns["clmChild2stkqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdChild2.Columns["clmChild2Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdChild2.Columns["clmChild2ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    }
                                    else  // INWARD QTY
                                    {


                                        grdParent2.Columns["clmproductparent2"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                                        grdParent2.Rows.Add(grdParent2.Rows.Count + 1, Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SL_ENAME"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                        Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), 0, Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKCONPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Decimal"]));

                                        dtConvertedProduct.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["STKCONPR_TranactionQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]));




                                        grdParent2.Columns["clmparent2MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdParent2.Columns["clmparent2Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                        grdParent2.Columns["clmparent2ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    }
                                }



                            }
                        }
                    }

                    cmbConcern.Enabled = false;
                    dtpConvertDate.Enabled = false;
                    txtStockConvertNo.Enabled = false; 
                    cmbTransactionType.Enabled = false;
                    txtProductName.Enabled = false;
                    epStockConvertion.Clear();
                    udfntooltiphide();
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");

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
                grdStockadjustment.ClearSelection();
                grdChild.ClearSelection();
                grdParent2.ClearSelection();
                grdChild2.ClearSelection();
                grdChild_DataBindingComplete(grdChild, new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
                grdChild2_DataBindingComplete(grdChild2, new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
                grdParent2_DataBindingComplete(grdParent2, new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset));
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) == 380) // child - parent
                {
                    varPRID = varParentId;
                    udfnChildLoad();
                }
                DGV_FilterProduct.Visible = false;
            }
        }
        private void UpdateComboBoxState()
        {
            try
            {
                if (grdStockadjustment.Rows.Count == 0)
                {
                    cmbTransactionType.Enabled = true;
                    txtProductName.Enabled = true;
                }
                else
                {
                    cmbTransactionType.Enabled = false;
                    txtProductName.Enabled = false;
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
                objMR_Product.ParaProductCode = Convert.ToInt32(varPRID); ;

                objDs = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();
                cmbChildProduct1.DataSource = null;
                cmbChildProduct2.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbChildProduct1.ValueMember = "PRID";
                            cmbChildProduct1.DisplayMember = "PR_EName";
                            cmbChildProduct1.DataSource = objDs.Tables[0];

                            cmbChildProduct2.ValueMember = "PRID";
                            cmbChildProduct2.DisplayMember = "PR_EName";
                            cmbChildProduct2.DataSource = objDs.Tables[0];
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
                                epStockConvertion.SetError(txtRack, "Please enter valid rack.");
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

        public void udfnRackcheck2()
        {
            try
            {
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
                string varId_PurchaseRackCount = "0";
                DataSet objDsPurchaseRack = new DataSet();
                SPDataService objDServ6 = new SPDataService();
                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varStockLocationId), 0, txtParentRack.Text.Trim(), 0, 0);
                objDServ6.CloseConnection();
                if (txtParentRack.Text.Trim() != "")
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
                                epStockConvertion.SetError(txtParentRack, "Please enter valid rack.");
                                txtParentRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

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
                            txtParentRack.Text = "None";
                            txtParentRack.Enabled = false;
                            varRKID = "0";
                        }
                        else
                        {
                            txtParentRack.Enabled = true;
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
        private void UpdateTotal()
        {
            try
            {
                decimal sum = 0;

                foreach (DataGridViewRow row in grdStockadjustment.Rows)
                {
                    // Skip the new row placeholder
                    if (row.IsNewRow) continue;

                    // Make sure value is not null or empty
                    if (row.Cells["clmOutward"].Value != null &&
                        decimal.TryParse(row.Cells["clmOutward"].Value.ToString(), out decimal value))
                    {
                        sum += value;
                    }
                }

                lblParenttotqty.Text =  Convert.ToString(sum)  ;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void UpdateBalanceTotal()
        {
            try
            { 
                decimal totalQtyUpp = 0;

                foreach (DataGridViewRow row in grdChild.Rows) // your second grid
                {
                    if (row.IsNewRow) continue;

                    // Get Qty
                    decimal qty = 0;
                    if (row.Cells["clmConvertedQty"].Value != null)
                        decimal.TryParse(row.Cells["clmConvertedQty"].Value.ToString(), out qty);

                    // Get UPP
                    decimal upp = 0;
                    if (row.Cells["clmuppvalue"].Value != null)
                        decimal.TryParse(row.Cells["clmuppvalue"].Value.ToString(), out upp);

                    // Multiply and add
                    totalQtyUpp += qty * upp;
                }

                // Get total from first grid label
                decimal total = Convert.ToDecimal(lblParenttotqty.Text); 

                // Calculate balance
                decimal balance =  total - totalQtyUpp;
                //if (totalQtyUpp == 0) {
                //    balance = totalQtyUpp - total;
                //}
                lblParentbalqty.Text = Convert.ToString(balance);
                varBalanceqty = balance;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void UpdateTotalChild()
        {
            try
            { 
                decimal totalQtyUpp = 0;

                foreach (DataGridViewRow row in grdChild2.Rows)
                {
                    // Skip the new row placeholder
                    if (row.IsNewRow) continue;

                    // Make sure value is not null or empty

                    decimal qty = 0;
                    if (row.Cells["clmChild2Qty"].Value != null)
                        decimal.TryParse(row.Cells["clmChild2Qty"].Value.ToString(), out qty);


                    decimal upp = 0;
                    if (row.Cells["clmchild2uppvalue"].Value != null)
                        decimal.TryParse(row.Cells["clmchild2uppvalue"].Value.ToString(), out upp);

                    // Multiply and add
                    totalQtyUpp += qty * upp;
                }

                lblparent2totqty.Text = Convert.ToString(totalQtyUpp);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void UpdateBalanceTotalChild()
        {
            try
            { 
                decimal qty = 0;

                foreach (DataGridViewRow row in grdParent2.Rows) // your second grid
                {
                    if (row.IsNewRow) continue;
                     
                    // Make sure value is not null or empty
                    if (row.Cells["clmparent2Qty"].Value != null &&
                        decimal.TryParse(row.Cells["clmparent2Qty"].Value.ToString(), out decimal value))
                    {
                        qty += value;
                    }
                }


                // Get total from first grid label
                decimal total = Convert.ToDecimal(lblparent2totqty.Text);

                // Calculate balance
                decimal balance = total - qty;
                lblparent2balqty.Text = Convert.ToString(balance);
                varBalanceqty = balance;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}




