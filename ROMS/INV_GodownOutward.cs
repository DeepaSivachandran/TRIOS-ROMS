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
    public partial class INV_GodownOutward : Form
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
        private ToolTip tpTeller = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        public int varCompleteFlag = 0;
        public string varStockLocationId = "", varTamilname="";
        public string varStockApplicable = "";
        public int varErrQty = 0;
        public int varCloseFlag = 0;
        public int varUpDownKey = 0;
        public int varGOId = 0;
        public int varSTSID = 0;
        public int varUpdate = 0,VarUpdateFlag=0;
        public int varCompanyId = 0, varDestSLID = 0, varDestRKID = 0,varStatusId=0,varDecimal=0;
        string varProductID = "", varMRP = "", varExpiryDate = "", varBatchNo = "",varRackId="";
        DataTable dtStock = new DataTable();
        public string vargroupcode;
        public String pbFormStatus;
        private bool varErrorFlag;
        public bool varChangeFlag=true;
        public bool VarSearchFlag = true;
        string SLID = "";
        int GOId = 0;
        string varLocation="";
        string result = "";
        public string varPICode = "", varPEname = "", varPTname = "", varPID = "", varUTID = "", varPRID = "", varRKID = "", varTotalItem = "", varUnit = "", varTransType = "";
        private int varviewtype = 0;
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0;
        public string varUserID = "";

        public INV_GodownOutward()
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
                if (varChangeFlag == false)
                {
                    udfnDiscard();
                    MainForm.objINV_GodownOutwardList.udfnList();
                }
                else 
                {
                    udfnclose();
                    MainForm.objINV_GodownOutwardList.udfnList();
                }
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
                txtOutwardQuantity.TextAlign = HorizontalAlignment.Right;
                if (e.KeyCode == Keys.Escape)
                {
                    DGV_FilterProduct.Visible = false;
                    lvStockLocation.Visible = false;
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
                lvStockLocation.Visible = false;
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
                    epGoodsOutward.SetError(txtStockLocation, "Please enter stock location");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location", txtStockLocation, 5000);
                }
                else
                {
                    epGoodsOutward.Clear();
                    txtStockLocation.BackColor = Color.White;
                }
                //if (varStockLocationId != SLID)
                //{
                //    MessageBox.Show("This will clear all the records from the grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    DGV_inward.Rows.Clear();
                //}
                //if (DGV_inward.Rows.Count > 0)
                //{
                //    udfnSLocationValid();
                //    if (Convert.ToString(SLID) != Convert.ToString(varStockLocationId))
                //    {
                //        SPDataService objDServ = new SPDataService();
                //        string varMessage = objDServ.udfnGetMessages(78);
                //        objDServ.CloseConnection();
                //        DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (dialogResult == DialogResult.Yes)
                //        {
                //            DGV_inward.Rows.Clear();
                //            dtStock.Rows.Clear();
                //            txtStockLocation.Focus();
                //        }
                //        else
                //        {
                //            varStockLocationId = varLocation;
                //        }
                //    }
                //}
                //lvStockLocation.Visible = false;

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
                    txtTeller.Focus();
                }
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
                lvStockLocation.Visible = false;
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
                    epGoodsOutward.SetError(cmbTransactionType, "Please select transaction type");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
                }
                else
                {
                    epGoodsOutward.Clear();
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
                lvStockLocation.Visible = false;
                //udfnListviewProduct();
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
                epGoodsOutward.Clear();
                txtProductName.BackColor = Color.White;
                tpProduct.Active = false;
                /*
                if (Convert.ToString(txtProductName.Text) == "")
                {
                    epGoodsOutward.SetError(txtProductName, "Please enter the product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter the product", txtProductName, 5000);                  
                }
                else
                {
                    epGoodsOutward.Clear();
                    txtProductName.BackColor = Color.White;
                    tpProduct.Active = false;
                }
                */
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up )
                {
                    //if (lvproduct.Items.Count == 0 && txtProduct.Text == "")
                    //{
                    //    txtOutwardQuantity.Focus();
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
                //    txtOutwardQuantity.Focus();
                //}
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
                    txtOutwardQuantity.Focus();
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
        private void TxtOutwardQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOutwardQuantity.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                lvStockLocation.Visible = false;
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
                if (Convert.ToString(txtOutwardQuantity.Text).Trim() == "")
                {
                    epGoodsOutward.SetError(txtOutwardQuantity, "Please enter outward quantity");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter outward quantity", txtOutwardQuantity, 5000);

                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtOutwardQuantity.Text).Trim(), varDecimal);
                    txtOutwardQuantity.Text = Qty;
                    epGoodsOutward.Clear();
                    txtOutwardQuantity.BackColor = Color.White;
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

        private void TxtTotalItem_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTotalItem.BackColor = Color.LemonChiffon;
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
                    epGoodsOutward.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epGoodsOutward.Clear();
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
                    dtpOutwardDate.Focus();
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
                grdGoodsOutward.Rows.Clear();
                if (btnSave.Text == "Save as Draft")
                {
                    txtStockLocation.Text = "";
                    txtTotalItem.Text = Convert.ToString(grdGoodsOutward.Rows.Count);
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
                if (btnSave.Text == "Save as Draft")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dtpOutwardDate.Text + "',103)");
                        varResult = objspdservice.udfngetVoucherNo("42", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] varvalue = varResult.Split('~');
                        if (varResult != "")
                        {
                            txtOutwardNo.Text = varvalue[0];
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
                else
                {
                    txtOutwardNo.Text = "";
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
                txtOutwardNo.Text = "";
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
                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dtpOutwardDate.MinDate = MainForm.pbFYStartDate;
                dtpOutwardDate.MaxDate = MainForm.pbCurrentDate;
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    udfnTransactionData();
                    //dtpOutwardDate.MaxDate = DateTime.Now;
                    grdGoodsOutward.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
                    //txtStockLocation.BackColor = Color.White;
                    lblProductName.Text = "Search by P.I Code (F11)";
                    VarSearchFlag = true;
                    if (varGOId == 0)
                    {
                        this.ActiveControl = txtStockLocation;
                    }
                    else
                    {
                        this.ActiveControl = txtProductName;
                        udfnEdit();
                    }
                }
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

        private void Button1_Click(object sender, EventArgs e)
        {

        }


        public void udfnTransactionData()
        {
            DataBind objDataBind = new DataBind();
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID = 24", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
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
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text, 0, 0, 0,"","",0);
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
        private void TxtStockLocation_TextChanged(object sender, EventArgs e)
       {
            try
            {
                txtProductName.Text = "";
                txtRack.Text = "";
                txtMrp.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStockQuantity.Text = "";
                txtOutwardQuantity.Text = "";
                lblQuantity.Text = "";
                udfnSLocationValid();
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0 || txtStockLocation.Text == " ")
                {
                    var ViewType = 23;
                    objDs = objspdservice.udfnStockLocationList(ViewType, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text, 0, 0, 0,"","",0);
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

        private void LvStockLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvStockLocation();
                txtTeller.Focus();
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

        private void LvStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation();
                    txtTeller.Focus();
                }
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
                    txtRack.Text = "";
                    txtMrp.Text = "";
                    txtExpiryDate.Text = "";
                    txtBatchNo.Text = "";
                    txtStockQuantity.Text = "";
                    txtOutwardQuantity.Text = "";
                    lblQuantity.Text = "";
                    SLID = varStockLocationId;
                    //lvproduct.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0 || txtProductName.Text == " ")
                    {
                        var ViewType = 37;
                        int varEntry = 0;
                        if (btnSave.Text == "Update") { varEntry = varGOId; }
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = ViewType;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraLocationId = Convert.ToInt32(varStockLocationId);
                        objMR_Product.paraStockTransfer = dtStock;
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
                                    //for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    //{
                                    //    string[] row = { objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PRODUCTLIST"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["STK_Qty"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["UTID"].ToString(), objDs.Tables[0].Rows[i]["STK_RKID"].ToString(), objDs.Tables[0].Rows[i]["UT_Name"].ToString(), objDs.Tables[0].Rows[i]["UT_Decimal"].ToString() };
                                    //    ListViewItem objList = new ListViewItem(row);
                                    //    objList.UseItemStyleForSubItems = false;
                                    //    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    //    lvproduct.Items.Add(objList);
                                    //}
                                    //lvproduct.Visible = true;
                                    //lvproduct.Columns[0].Width = 0;
                                    //lvproduct.Columns[1].Width = 100;
                                    //lvproduct.Columns[2].Width = 0;
                                    //lvproduct.Columns[3].Width = 0;
                                    //lvproduct.Columns[4].Width = 0;
                                    //lvproduct.Columns[5].Width = 60;
                                    //lvproduct.Columns[6].Width = 60;
                                    //lvproduct.Columns[7].Width = 90;
                                    //lvproduct.Columns[8].Width = 80;
                                    //lvproduct.Columns[9].Width = 70;
                                    //lvproduct.Columns[10].Width = 50;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    //DGV_FilterProduct.Columns["SL_EName"].Width = 70;
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
                //stxtProduct.BackColor = Color.White;
                epGoodsOutward.Clear();
            }
        }

        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListviewProduct();
                txtOutwardQuantity.Focus();
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
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
                    txtOutwardQuantity.Focus();
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
                //ListViewItem selectedItem = lvproduct.SelectedItems[0];
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
                txtStockQuantity.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_Qty"].Value.ToString();
                lblQuantity.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                txtStockQuantity.TextAlign = HorizontalAlignment.Right;
                txtMrp.TextAlign = HorizontalAlignment.Right;
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
                for (int i = 0; i < grdGoodsOutward.Rows.Count; i++)
                {
                    DataService objDser = new DataService();
                    dtStock.Rows.Add(Convert.ToInt32(grdGoodsOutward.Rows[i].Cells["clmPRID"].Value), Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmmrp"].Value),
                    Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmExpiryDate"].Value), Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmBatchNo"].Value),
                    Convert.ToInt32(grdGoodsOutward.Rows[i].Cells["clmUTID"].Value), Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmOutward"].Value),
                    Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmRKID"].Value),0,0);
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
                txtMrp.TextAlign = HorizontalAlignment.Right;
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
                //            txtStockLocation.Focus();
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
                lvStockLocation.Visible = false;
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
                if (grdGoodsOutward.CurrentCell.OwningColumn.Name == "clmOutward")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdGoodsOutward.CurrentCell.OwningColumn.Name == "clmOutward")
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
                if (grdGoodsOutward.CurrentCell.OwningColumn.Name == "clmOutward")
                {
                    if (!(char.IsDigit(e.KeyChar)||char.IsControl(e.KeyChar)||e.KeyChar == '.'))
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

                decimal StockcellValue = Convert.ToDecimal(grdGoodsOutward.CurrentRow.Cells["clmQty"].Value);
                decimal OutwardcellValue = Convert.ToDecimal(grdGoodsOutward.CurrentRow.Cells["clmOutward"].Value);

                if (Convert.ToDecimal(OutwardcellValue) > Convert.ToDecimal(StockcellValue))
                {
                    grdGoodsOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //epGoodsOutward.SetError(DGV_inward, "Please enter valid outward qty");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter valid outward quantity", grdGoodsOutward, 5000);
                    SPDataService objDServ = new SPDataService();
                    objDServ.CloseConnection();
                    varErrQty = 1;
                    //MessageBox.Show("Please Enter Valid Outward Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(Convert.ToString(OutwardcellValue)=="" || Convert.ToString(OutwardcellValue) == "0")
                {
                    grdGoodsOutward.Rows[e.RowIndex].Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrQty =1;
                }
                else
                {
                    grdGoodsOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = Color.PaleGreen;
                    varErrQty = 0;
                } 
                int varDecimal = Convert.ToInt32(grdGoodsOutward.CurrentRow.Cells["clmUTDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdGoodsOutward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                    grdGoodsOutward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;
                
                object varEditQty = grdGoodsOutward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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
                int varDecimal = Convert.ToInt32(grdGoodsOutward.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdGoodsOutward.CurrentCell.OwningColumn.Name == "clmOutward")
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
        private void CbCompleted_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int varStatusId = 0;
                if (cbCompleted.Checked)
                {
                    BtnSave_Click(sender,e);
                }
                else
                {
                    btnSave.Text = "Save as Draft";
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
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnGridviewProduct();
                //    udfnPossibleSupplierLoad();
                //}
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

        private void DGV_FilterProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //try
            //{
            //    //DGV_FilterProduct.ClearSelection();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
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

        private void TxtTeller_Enter(object sender, EventArgs e)
        {
            try
            {
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
                    txtProductName.Focus();
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
                txtProductName.Focus();
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

        private void CbCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbCompleted.Checked)
                {
                    btnSave.Text = "Save";
                    varStatusId = 26;
                }
                else
                {
                    btnSave.Text = "Save as Draft";
                }
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
                lvStockLocation.Visible = false;
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
                txtOutwardQuantity.TextAlign = HorizontalAlignment.Right;
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

        private void TxtTotalItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGV_inward_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int StockcellValue =Convert.ToInt32( grdGoodsOutward.CurrentRow.Cells["clmQty"].Value);
                int OutwardcellValue = Convert.ToInt32(grdGoodsOutward.CurrentRow.Cells["clmOutward"].Value);

                if (Convert.ToInt32(OutwardcellValue) > Convert.ToInt32(StockcellValue))
                {
                    grdGoodsOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //epGoodsOutward.SetError(DGV_inward, "Please enter valid outward qty");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter valid outward quantity", grdGoodsOutward, 5000);
                    SPDataService objDServ = new SPDataService();
                    objDServ.CloseConnection();
                    //MessageBox.Show("Please Enter Valid Outward Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    grdGoodsOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = Color.PaleGreen;

                }
                object varEditQty = grdGoodsOutward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // Update the same column value in the DataTable
                dtStock.Rows[e.RowIndex]["STK_QTY"] = varEditQty;
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

            //MessageBox.Show($"Cell Value Changed: {cellValue}", "Cell Value Changed");
        }

        private void DGV_inward_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdGoodsOutward.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdGoodsOutward.ClearSelection();

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
                varoriginator = "Goods Outward Creation";
                ViewType = 0;
                bool GOID = Convert.ToBoolean(varGOId);
                if (btnSave.Text == "Save as Draft" && cbCompleted.Checked == false && !GOID)
                {
                    varStatusId = 35;
                }
                else if (btnSave.Text == "Save" && cbCompleted.Checked == true && GOID)
                {
                    varStatusId = 26;
                }
                else if (btnSave.Text == "Save" && cbCompleted.Checked == true && !GOID)
                {
                    varStatusId = 26;
                }
                else if (btnSave.Text == "Save as Draft" && cbCompleted.Checked == false && GOID)
                {
                    varStatusId = 35;
                }
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
                epGoodsOutward.Clear();
                bool blnErrorFlag = true;

                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epGoodsOutward.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtStockLocation.Text).Trim() == "")
                {
                    epGoodsOutward.SetError(txtStockLocation, "Please enter stock location");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location", txtStockLocation, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epGoodsOutward.SetError(cmbTransactionType, "Please select transaction type");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select transaction type", cmbTransactionType, 5000);
                    blnErrorFlag = false;
                }
                //if (txtStockLocation.Text !="")
                //{
                //        /* Check purchase stock location is valid or not*/
                //        string varId_PurLocation = "0";
                //        if (txtStockLocation.Text == "")
                //        {
                //            varId_PurLocation = "0";
                //        }
                //        else
                //        {
                //            DataSet objDsPurLoc = new DataSet();
                //            SPDataService objDServ3 = new SPDataService();
                //            objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtStockLocation.Text, 0, 0, 0);
                //            objDServ3.CloseConnection();
                //            if (objDsPurLoc != null)
                //            {
                //                if (objDsPurLoc.Tables.Count > 0)
                //                {
                //                    if (objDsPurLoc.Tables[0].Rows.Count > 0)
                //                    {
                //                        varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                //                    }
                //                }
                //            }
                //        }
                //        varStockLocationId = Convert.ToString(varId_PurLocation);
                //    }          
                if (grdGoodsOutward.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                }
                for (int i = 0; i < grdGoodsOutward.Rows.Count; i++)
                {
                    if (Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmOutward"].Value) == "" || Convert.ToDecimal(grdGoodsOutward.Rows[i].Cells["clmOutward"].Value) == 0 || Convert.ToDecimal(grdGoodsOutward.Rows[i].Cells["clmQty"].Value)< Convert.ToDecimal(grdGoodsOutward.Rows[i].Cells["clmOutward"].Value))
                    {
                        varErrorFlag = false; varErrQty = 1;
                        grdGoodsOutward.Rows[i].Cells["clmOutward"].Style.BackColor = Color.LightPink;
                    }
                    else
                    {
                        grdGoodsOutward.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                        grdGoodsOutward.Rows[i].Cells["clmOutward"].Style.BackColor = Color.PaleGreen;
                    }
                }
                if (varErrQty==1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                }
                if(cbCompleted.Checked == false)
                {
                    varCompleteFlag = 1;
                }
                if (txtTeller.Text.Trim() == "")
                {
                    epGoodsOutward.SetError(txtTeller, "Please enter teller");
                    txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTeller.ShowAlways = true;
                    tpTeller.Show("Please enter teller", txtTeller, 5000);
                    blnErrorFlag = false;
                }
                if (blnErrorFlag == true)
                {
                    udfntooltiphide();
                    epGoodsOutward.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();
                    TRN_GoodsOutward objTRNS_GoodsOutward = new TRN_GoodsOutward();
                    objTRNS_GoodsOutward.ViewType = ViewType;
                    objTRNS_GoodsOutward.ParaGOId = varGOId;
                    objTRNS_GoodsOutward.ParaCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNS_GoodsOutward.paraOutwardDate = dtpOutwardDate.Text;
                    objTRNS_GoodsOutward.paraTransferType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                    objTRNS_GoodsOutward.paraRemarks = txtRemark.Text.Trim();
                    objTRNS_GoodsOutward.paraSLID = Convert.ToInt32(varStockLocationId);
                    objTRNS_GoodsOutward.paraStockTransfer = dtStock;
                    objTRNS_GoodsOutward.paraOriginator = varoriginator;
                    objTRNS_GoodsOutward.ParaFlag = varCompleteFlag;
                    objTRNS_GoodsOutward.paraStatusId = varStatusId;
                    objTRNS_GoodsOutward.paraTeller = txtTeller.Text.Trim();
                    result = objspdservice.udfnGoodsOutward(objTRNS_GoodsOutward);
                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (result.Split('~')[0] == "3")
                    {
                        if (result.Split('~')[1] == "1")
                        {
                            MainForm.objCP_Verify = new CP_Verify();
                            MainForm.objCP_Verify.ShowDialog();
                            varUserID = MainForm.objCP_Verify.varUserId;
                            if (MainForm.objCP_Verify.flag == 1)
                            {
                                objTRNS_GoodsOutward.ViewType = ViewType;
                                objTRNS_GoodsOutward.ParaGOId = varGOId;
                                objTRNS_GoodsOutward.ParaCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                                objTRNS_GoodsOutward.paraOutwardDate = dtpOutwardDate.Text;
                                objTRNS_GoodsOutward.paraTransferType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                                objTRNS_GoodsOutward.paraRemarks = txtRemark.Text.Trim();
                                objTRNS_GoodsOutward.paraSLID = Convert.ToInt32(varStockLocationId);
                                objTRNS_GoodsOutward.paraStockTransfer = dtStock;
                                objTRNS_GoodsOutward.paraOriginator = varoriginator;
                                objTRNS_GoodsOutward.paraCompletedby = Convert.ToInt32(varUserID);
                                objTRNS_GoodsOutward.ParaFlag = 1;
                                objTRNS_GoodsOutward.paraStatusId = varStatusId;
                                result = objspdservice.udfnGoodsOutward(objTRNS_GoodsOutward);
                                objspdservice.CloseConnection();
                                string[] varvalue1 = result.Split('~');
                                if (varvalue1[0] == "3")
                                {
                                    MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.ActiveControl = txtProductName;
                                    MainForm.objINV_GodownOutwardList.udfnList();
                                    string OutwardId = "0";
                                    if (varGOId == 0)
                                    {
                                        OutwardId = varvalue1[2];
                                    }
                                    else
                                    {
                                        OutwardId = Convert.ToString(varGOId);
                                    }
                                    udfnOutwardReport(OutwardId);
                                    udfnClear();
                                    this.Close();
                                }
                                else
                                {
                                    epGoodsOutward.Clear();
                                    txtProductName.BackColor = Color.White;
                                    MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    btnSave.Enabled = true;
                                    btnSave.Focus();
                                    if (varvalue[0] == "5")
                                    {
                                        //for (int i = 0; i < varFirstList.Length; i++)
                                        //{
                                        //    string[] varSecondList = varFirstList[i].Split(',');
                                        //    string varPRID = varSecondList[0];
                                        //    string varMRP = varSecondList[1];
                                        //    string varExpiryDate = varSecondList[2];
                                        //    string varBatchNo = varSecondList[3];
                                        for (int j = 0; j < grdGoodsOutward.RowCount; j++)
                                        {
                                            grdGoodsOutward.Rows[j].DefaultCellStyle.BackColor = Color.White;

                                            string[] varFirstList = varvalue[2].Split('|');
                                            for (int i = 0; i < varFirstList.Length; i++)
                                            {
                                                string[] varSecondList = varFirstList[i].Split(',');
                                                varProductID = varSecondList[0];
                                                varMRP = varSecondList[1];
                                                varExpiryDate = varSecondList[2];
                                                varBatchNo = varSecondList[3];
                                                varRKID = varSecondList[4];
                                                if (Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmPRID"].Value) == varProductID && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmExpirydate"].Value) == varExpiryDate && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmBatchNo"].Value) == varBatchNo && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmRKID"].Value) == varRKID)
                                                {

                                                    grdGoodsOutward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                                }

                                            }

                                        }
                                    }
                                }
                            }
                        }
                        else if (result.Split('~')[0] == "4")
                        {
                            MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (result.Split('~')[0] != "1")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ActiveControl = txtProductName;
                            MainForm.objINV_GodownOutwardList.udfnList();
                            /*
                            string OutwardId = "0";
                            if (varGOId == 0)
                            {
                                OutwardId = varvalue[2];
                            }
                            else
                            {
                                OutwardId = Convert.ToString(varGOId);
                            }
                            udfnOutwardReport(OutwardId);
                            */
                            udfnClear();
                            this.Close();
                        }
                    }
                    //if (varvalue[0] == "3")
                    //{
                    //    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    this.ActiveControl = txtProductName;
                    //    MainForm.objINV_GodownOutwardList.udfnList();
                    //    udfnClear();
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    epGoodsOutward.Clear();
                    //    txtProductName.BackColor = Color.White;
                    //    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    btnSave.Enabled = true;
                    //    btnSave.Focus();
                    //    if (varvalue[0] == "5")
                    //    {
                    //        //for (int i = 0; i < varFirstList.Length; i++)
                    //        //{
                    //        //    string[] varSecondList = varFirstList[i].Split(',');
                    //        //    string varPRID = varSecondList[0];
                    //        //    string varMRP = varSecondList[1];
                    //        //    string varExpiryDate = varSecondList[2];
                    //        //    string varBatchNo = varSecondList[3];
                    //        for (int j = 0; j < grdGoodsOutward.RowCount; j++)
                    //        {
                    //            grdGoodsOutward.Rows[j].DefaultCellStyle.BackColor = Color.White;

                    //            string[] varFirstList = varvalue[2].Split('|');
                    //            for (int i = 0; i < varFirstList.Length; i++)
                    //            {
                    //                string[] varSecondList = varFirstList[i].Split(',');
                    //                varProductID = varSecondList[0];
                    //                varMRP = varSecondList[1];
                    //                varExpiryDate = varSecondList[2];
                    //                varBatchNo = varSecondList[3];
                    //                varRKID = varSecondList[4];
                    //                if (Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmPRID"].Value) == varProductID && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmExpirydate"].Value) == varExpiryDate && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmBatchNo"].Value) == varBatchNo && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmRKID"].Value) == varRKID)
                    //                {

                    //                    grdGoodsOutward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                    //                }

                    //            }

                    //        }
                    //    }
                    //}
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
                grdGoodsOutward.ClearSelection();
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
                txtOutwardNo.Text = "";
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
                epGoodsOutward.Clear();
                cmbConcern.BackColor = Color.White;
                tpConcern.Active = false;
                cmbTransactionType.BackColor = Color.White;
                tpTransactionType.Active = false;
                txtStockLocation.BackColor = Color.White;
                tpStockLocation.Active = false;
                //txtProduct.BackColor = Color.White;
                tpProduct.Active = false;
                txtOutwardQuantity.BackColor = Color.White;
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
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) != 70) // Regular
                {
                    grdGoodsOutward.Columns["clmrequestqty"].Width = 100;
                    grdGoodsOutward.Columns["clmrequestqty"].Visible = true;
                }
                else // Stock Request
                {
                    grdGoodsOutward.Columns["clmrequestqty"].Width = 0;
                    grdGoodsOutward.Columns["clmrequestqty"].Visible = false;
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
                txtRack.Text = "";
                txtMrp.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStockQuantity.Text = "";
                txtOutwardQuantity.Text = "";
                varPRID = "";
                varPICode = "";
                varRKID = "";
                varUTID = "";
                lblQuantity.Text = "";
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
                int varProductID = 0,varRKID=0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (grdGoodsOutward.Columns[e.ColumnIndex].Name)
                    {
                    case "clmRemove":
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            varProductID = Convert.ToInt32(grdGoodsOutward.SelectedRows[0].Cells["clmPRID"].Value);
                            //varMRP = Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmmrp"].Value);
                            varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmmrp"].Value)));
                            varExpiryDate = Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmExpirydate"].Value);
                            varBatchNo = Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmBatchNo"].Value);
                            varRKID = Convert.ToInt32(grdGoodsOutward.SelectedRows[0].Cells["clmRKID"].Value);
                            grdGoodsOutward.Rows.RemoveAt(this.grdGoodsOutward.SelectedRows[0].Index);
                            for (int i = 0; i < grdGoodsOutward.RowCount; i++)
                            {
                                grdGoodsOutward.Rows[i].Cells["clmdsno"].Value = i + 1;
                            }
                            for (int i = 0; i < dtStock.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID)  && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtStock.Rows[i]["STK_MRP"]))) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToInt32(dtStock.Rows[i]["STK_Source_RKID"]) == Convert.ToInt32(varRKID))
                                {
                                    dtStock.Rows[i].Delete();
                                    dtStock.AcceptChanges();
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
                txtTotalItem.Text = Convert.ToString(grdGoodsOutward.Rows.Count);
                if (grdGoodsOutward.Rows.Count > 0)
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
                varErrorFlag = true;
                if (txtProductName.Text == "")
                {
                    epGoodsOutward.SetError(txtProductName, "Please enter product name");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductName, 5000);
                    varErrorFlag = false;
                }
                if (txtRack.Text == "")
                {
                    epGoodsOutward.SetError(txtRack, "Please enter the rack name");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter the rack name", txtRack, 5000);
                    varErrorFlag = false;
                }
                //if (txtMrp.Text == "")
                //{
                //    epGoodsOutward.SetError(txtMrp, "Please enter mrp");
                //    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpOutwardQuantity.ShowAlways = true;
                //    tpOutwardQuantity.Show("Please enter mrp", txtMrp, 5000);
                //    varErrorFlag = false;
                //}
                //if (txtExpiryDate.Text == "")
                //{
                //    epGoodsOutward.SetError(txtExpiryDate, "Please enter expiry date");
                //    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpOutwardQuantity.ShowAlways = true;
                //    tpOutwardQuantity.Show("Please enter expiry date", txtExpiryDate, 5000);
                //    varErrorFlag = false;
                //}
                //if (txtBatchNo.Text == "")
                //{
                //    epGoodsOutward.SetError(txtBatchNo, "Please enter batch number");
                //    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpOutwardQuantity.ShowAlways = true;
                //    tpOutwardQuantity.Show("Please enter batch number", txtBatchNo, 5000);
                //    varErrorFlag = false;
                //}
                if (txtStockQuantity.Text == "")
                {
                    epGoodsOutward.SetError(txtStockQuantity, "Please enter stock quantity");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter stock quantity", txtStockQuantity, 5000);
                    varErrorFlag = false;
                }
                if (txtOutwardQuantity.Text == "")
                {
                    epGoodsOutward.SetError(txtOutwardQuantity, "Please enter outward quantity");
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
                        if (Convert.ToDecimal(txtOutwardQuantity.Text) > Convert.ToDecimal(txtStockQuantity.Text) || Convert.ToDecimal(txtOutwardQuantity.Text)==0)
                        {
                            txtOutwardQuantity.Focus();
                            epGoodsOutward.SetError(txtOutwardQuantity, "Please enter a valid outward quantity");
                            txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpOutwardQuantity.ShowAlways = true;
                            tpOutwardQuantity.Show("Please enter a valid outward quantity", txtOutwardQuantity, 5000);
                        }
                        else
                        {
                            if (txtOutwardQuantity.Text != "")
                            {
                                //if (varDecimal == 6)
                                //{
                                    string Qty = objValidation.udfnDecimal((txtOutwardQuantity.Text).Trim(), varDecimal);
                                    txtOutwardQuantity.Text = Qty;
                                //}
                                //if (varDecimal == 7)
                                //{
                                //    string Qty = objValidation.udfnDecimal((txtOutwardQuantity.Text).Trim(), 2);
                                //    txtOutwardQuantity.Text = Qty;
                                //}
                                //if (varDecimal == 8)
                                //{
                                //    string Qty = objValidation.udfnDecimal((txtOutwardQuantity.Text).Trim(), 3);
                                //    txtOutwardQuantity.Text = Qty;
                                //}
                            }
                            grdGoodsOutward.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdGoodsOutward.Rows.Add(grdGoodsOutward.Rows.Count + 1, varPRID, varPICode, (varTamilname), varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtOutwardQuantity.Text), varUnit, varUTID,varDecimal);
                            dtStock.Rows.Add(varPRID, string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtMrp.Text.Trim()))), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), varUTID, (txtOutwardQuantity.Text), varRKID, varDestSLID, varDestRKID,0);
                            txtTotalItem.Text = Convert.ToString(grdGoodsOutward.Rows.Count);
                            //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                            grdGoodsOutward.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            udfnProductClear();
                            txtProductName.Focus();

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
                grdGoodsOutward.Rows.Count.ToString();
                grdGoodsOutward.ClearSelection();
                if (grdGoodsOutward.Rows.Count > 0)
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
                //DGV_inward.Sort(DGV_inward.Columns["clmpicode"], ListSortDirection.Ascending);

            }

        }

        private void Lvproduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //public void udfnProductAdd()
        //{
        //    try
        //    {
        //            SPDataService objspdservice = new SPDataService();
        //            DataSet objDs = new DataSet();
        //            objDs = objspdservice.udfnproductmasterlist(13, 0, 0, 0, 0, "", "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, txtProduct.Text, 0,"","",dtStock,0,null,"","");

        //        if (objDs != null)
        //        {
        //            if (objDs.Tables[0].Rows.Count > 0)
        //            {
                       
        //                    varPICode = objDs.Tables[0].Rows[0]["P.I Code"].ToString();
        //                    varPEname = objDs.Tables[0].Rows[0]["Product Name in English"].ToString();
        //                    varPTname = objDs.Tables[0].Rows[0]["Product Name in Tamil"].ToString();
        //                    varPID = objDs.Tables[0].Rows[0]["PRODUCTID"].ToString();
                     
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //    finally
        //    {
        //        lvproduct.Visible = false;
        //    }
        //}
        public void udfnEdit()
        {
            try
            {
                if (varGOId != 0)
                {
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    int ViewType = 1;
                    TRN_GoodsOutward objTRNG_GoodsOutward = new TRN_GoodsOutward();
                    objTRNG_GoodsOutward.ViewType = ViewType;
                    objTRNG_GoodsOutward.ParaGOId = Convert.ToInt32(varGOId);
                    objDs = objdserv.udfnGOList(objTRNG_GoodsOutward);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["GO_COMID"].ToString();
                            dtpOutwardDate.Text = objDs.Tables[0].Rows[0]["GO_Date"].ToString();
                            txtOutwardNo.Text = objDs.Tables[0].Rows[0]["GO_No"].ToString();
                            varStockLocationId = objDs.Tables[0].Rows[0]["GO_SLID"].ToString();
                            txtStockLocation.Text = objDs.Tables[0].Rows[0]["Stock Location"].ToString();
                            txtTeller.Text = objDs.Tables[0].Rows[0]["Teller"].ToString();
                            varTransType = objDs.Tables[0].Rows[0]["GO_TransactionType"].ToString();
                            cmbTransactionType.Text = objDs.Tables[0].Rows[0]["Transaction Type"].ToString();
                            txtRemark.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                        }

                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                grdGoodsOutward.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                grdGoodsOutward.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]),Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]),Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GOPR_ReqQty"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GOPR_OutwardQty"]),Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]));
                                dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToDecimal(objDs.Tables[1].Rows[i]["GOPR_OutwardQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]),0,0,0);
                                grdGoodsOutward.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGoodsOutward.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGoodsOutward.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGoodsOutward.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //DGV_inward.Rows.Add(DGV_inward.Rows.Count + 1, varPRID, varPICode, (txtProduct.Text).Trim(), varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtOutwardQuantity.Text).Trim(), varUnit, varUTID);
                                //DGV_inward.Columns[10].ReadOnly = false;
                            }
                        }
                    }
                    
                    lvStockLocation.Visible = false;
                    lvTeller.Visible = false;
                    cmbConcern.Enabled = false;
                    dtpOutwardDate.Enabled = false;
                    txtOutwardNo.Enabled = false;
                    txtStockLocation.Enabled = false;
                    cmbTransactionType.Enabled = false;
                    epGoodsOutward.Clear();
                    udfntooltiphide();
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                    if (varSTSID == 26)
                    {
                        txtTeller.Enabled = false;
                        txtProductName.Enabled = false;
                        txtOutwardQuantity.Enabled = false;
                        txtRemark.Enabled = false;
                        cbCompleted.Checked = true;
                        btnSave.Enabled = false;
                        cbCompleted.Enabled = false;
                        btnAdd.Enabled = false;
                        txtProductName.BackColor = Color.White;
                        this.ActiveControl = btnClose;
                        epGoodsOutward.Clear();
                        grdGoodsOutward.ReadOnly = true;
                        grdGoodsOutward.Columns["clmRemove"].Visible = false;
                        udfntooltiphide();
                        txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                        DGV_inward_DataBindingComplete(grdGoodsOutward, args);
                        for (int i = 0; i < grdGoodsOutward.Rows.Count; i++)
                        {
                            ((DataGridViewImageCell)grdGoodsOutward.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
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
                grdGoodsOutward.ClearSelection();
                txtTotalItem.Text = Convert.ToString(grdGoodsOutward.Rows.Count);
            }
        }

     }                 
}




