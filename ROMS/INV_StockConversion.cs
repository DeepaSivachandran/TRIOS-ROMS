using DocumentFormat.OpenXml.VariantTypes;
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
    public partial class INV_StockConversion : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public bool skipValidation = false;
        private ToolTip tpConvertionNo = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpProductName = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpStock = new ToolTip();
        private ToolTip tpExpiryDate = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tpQty = new ToolTip();
        private ToolTip tpQty2 = new ToolTip();
        private ToolTip tpMrp2 = new ToolTip();
        private ToolTip tpMrp = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpBatchNo2 = new ToolTip();
        private ToolTip tpMonth = new ToolTip();
        private ToolTip tpYear = new ToolTip();
        public string varExpiryDate = "";
        public int varErroronGrid = 0, varErrorFormat = 0, varUpDownKey = 0;
        public int varPRID = 0, varUTID = 0, varRKID = 0, varStockLocationId = 0, varDecimal = 0, pbDateflag = 0, varShelflife = 0, varUpdateFlag = 0, varEditFlag = 0;
        DataTable dtStock = new DataTable();
        private bool varErrorFlag = true;
        int expirydateFlag = 0, error=0;
        public string varPICode = "", varTamilname = "", varAcutalshelflife = "", varShelflifevalue = "";
        public string varbrandcode;
        public string pbFormStatus;
        public int varQuantity = 0;
        public decimal varActualQuantity = 0;
        public bool varChangeFlag = true;
        public int varBTID = 0;
        public decimal sum = 0;
        decimal changedQuantity = 0;
        public bool VarSearchFlag = true;
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0;
        
        public INV_StockConversion()
        {
            InitializeComponent();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (varChangeFlag == false)
                {
                    skipValidation = true;
                    udfnDiscard();
                }
                else
                {
                    skipValidation = true;
                    udfnclose();
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
                    skipValidation = true;
                    this.Close();
                    MainForm.objINV_StockConversionList.udfnList();
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
        private void INV_StockConversion_Load(object sender, EventArgs e)
        {
            try
            {
                dtStock.TableName = "TRN_BatchConversion_Product";
                dtStock.Columns.Add("STK_QTY", typeof(decimal));
                dtStock.Columns.Add("STK_MRP", typeof(string));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_SNo", typeof(int));
                udfnCmbConcern();
                dpConversionDate.MinDate = MainForm.pbFYStartDate;
                dpConversionDate.MaxDate = MainForm.pbCurrentDate;
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    this.ActiveControl = txtProductName;
                    VarSearchFlag = true;
                    lblProductName.Text = "Search by P.I Code (F11)";
                    grdBatchConversion.ClearSelection();
                    if (btnSave.Text == "Save")
                    {
                    }
                    else
                    {
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
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpConversionDate.Focus();
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
                    epBatchConversion.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epBatchConversion.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpConversionDate_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
       {
            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    //if (lvproduct.Items.Count == 0 || txtProductName.Text == "")
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
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                epBatchConversion.Clear();
                txtProductName.BackColor = Color.White;
                tpProductName.Active = false;
                /*
                if (Convert.ToString(txtProductName.Text) == "")
                {
                    epBatchConversion.SetError(txtProductName, "Please enter the product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductName.ShowAlways = true;
                    tpProductName.Show("Please enter the product", txtProductName, 5000);
                }
                else
                {
                    epBatchConversion.Clear();
                    txtProductName.BackColor = Color.White;
                    tpProductName.Active = false;
                }
                */
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
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                txtQty.BackColor = Color.LemonChiffon;
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
                    txtConvertMrp.Focus();
                }
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
                //int gridCount = 0;
                if (Convert.ToString(txtQty.Text) == "")
                {
                    epBatchConversion.SetError(txtQty, "Please enter quantity");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter quantity", txtQty, 5000);
                }
                else
                {
                    epBatchConversion.Clear();
                    txtQty.BackColor = Color.White;
                    tpQty.Active = false;
                }
                if (grdBatchConversion.Rows.Count > 0 && Convert.ToDecimal(txtQty.Text) < changedQuantity)
                {
                    epBatchConversion.SetError(txtQty, "Please enter valid quantity");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter quantity", txtQty, 5000);
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
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
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtYear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtConvertBatch.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_KeyDown(object sender, KeyEventArgs e)
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
        public void udfnVocherno()
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpConversionDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetVoucherNo("152", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string pono = parts[0];
                        if (pono != "")
                        {
                            txtConversionNo.Text = pono;
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
                    else
                    {
                        txtConversionNo.Text = "";
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
                txtConversionNo.Text = "";
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
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    varPRID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString());
                    varTamilname = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();                  
                    varUTID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UTID"].Value.ToString());
                    varStockLocationId = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["STK_SLID"].Value.ToString());
                    varRKID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["STK_RKID"].Value.ToString());
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    varShelflife = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["Shelflife"].Value.ToString());
                    txtRack.Text = DGV_FilterProduct.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                    txtStockLocation.Text = DGV_FilterProduct.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                    txtTotalUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    txtMrp.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                    txtExpiryDate.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                    txtBatchNo.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                    txtStock.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_Qty"].Value.ToString();
                    txtUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    txtUnit2.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    txtUnit3.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    udfnExpiryDate();
                    if (varShelflife == 1)
                    { expirydateFlag = 1; }
                    else
                    {
                        expirydateFlag = 0;
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
        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListviewProduct();
                txtQty.Focus();
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
                    txtQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epBatchConversion.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epBatchConversion.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epBatchConversion.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epBatchConversion.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epBatchConversion.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epBatchConversion.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epBatchConversion.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epBatchConversion.Clear();
                    }
                }
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
                dtStock.TableName = "TRN_BatchConversion_Product";
                dtStock.Columns.Add("STK_QTY", typeof(string));
                dtStock.Columns.Add("STK_MRP", typeof(string));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                for (int i = 0; i < grdBatchConversion.Rows.Count; i++)
                {
                    DataService objDser = new DataService();
                    dtStock.Rows.Add(Convert.ToString(grdBatchConversion.Rows[i].Cells["clmQty"].Value),Convert.ToString(grdBatchConversion.Rows[i].Cells["clmMrp"].Value),
                    Convert.ToString(grdBatchConversion.Rows[i].Cells["clmExpiryDate"].Value), Convert.ToString(grdBatchConversion.Rows[i].Cells["clmBatchNo"].Value));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return dtStock;
        }
        private void TxtProductName_TextChanged(object sender, EventArgs e)
       {
            try
            {
                if (varUpDownKey == 0)
                {
                    txtStockLocation.Text = "";
                    txtRack.Text = "";
                    txtMrp.Text = "";
                    txtExpiryDate.Text = "";
                    txtBatchNo.Text = "";
                    txtStock.Text = "";
                    txtQty.Text = "";
                    txtDay.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtConvertMrp.Text = "";
                    txtConvertBatch.Text = "";
                    txtConvertQty.Text = "";
                    txtUnit.Text = "";
                    txtUnit2.Text = "";
                    txtUnit3.Text = "";
                    txtTotalUnit.Text = "";
                    //DGV_FilterProduct.Items.Clear();

                    if (VarSearchFlag == true)
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {
                        //var ViewType = 42;
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 52;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraUserLocations = MainForm.pbUserMappedLocationIds;
                        if (VarSearchFlag == false)
                        {
                            objMR_Product.paraProductName = txtProductName.Text.Trim();
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraPicode = txtProductName.Text.Trim();
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
                                    DGV_FilterProduct.Columns["STK_MRP"].Width = 60;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].Width = 90;
                                    DGV_FilterProduct.Columns["STK_BatchNo"].Width = 70;
                                    DGV_FilterProduct.Columns["STK_Qty"].Width = 70;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["UTID"].Visible = false;
                                    DGV_FilterProduct.Columns["PRODUCTLIST"].Visible = false;
                                    DGV_FilterProduct.Columns["ShelfLife"].Visible = false;
                                    DGV_FilterProduct.Columns["STK_SLID"].Visible = false;
                                    DGV_FilterProduct.Columns["STK_RKID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
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
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                pbDateflag = 0;
                varEditFlag = 1;
                int varSNo = 0;
                DGV_FilterProduct.Visible = false;
                varErrorFlag = true;
                //decimal varConvertMRP = 0;
                if (txtProductName.Text == "")
                {
                    epBatchConversion.SetError(txtProductName, "Please enter product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductName.ShowAlways = true;
                    tpProductName.Show("Please enter product name", txtProductName, 5000);
                    varErrorFlag = false;
                }
                if (txtStockLocation.Text == "")
                {
                    epBatchConversion.SetError(txtRack, "Please enter the stock location");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter the stock location", txtStockLocation, 5000);
                    varErrorFlag = false;
                }
                if (txtRack.Text == "")
                {
                    epBatchConversion.SetError(txtMrp, "Please enter rack name");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please enter rack name", txtRack, 5000);
                    varErrorFlag = false;
                }
                if (txtConversionNo.Text == "")
                {
                    epBatchConversion.SetError(txtConversionNo, "Please enter convertion no.");
                    txtConversionNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConvertionNo.ShowAlways = true;
                    tpConvertionNo.Show("Please enter convertion no.", txtConversionNo, 5000);
                    varErrorFlag = false;
                }
                else
                {
                    txtConversionNo.BackColor = SystemColors.Control;
                }
                //if (txtExpiryDate.Text == "")
                //{
                //    epBatchConversion.SetError(txtExpiryDate, "Please enter expiry date");
                //    txtExpiryDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpExpiryDate.ShowAlways = true;
                //    tpExpiryDate.Show("Please enter expiry date", txtExpiryDate, 5000);
                //    varErrorFlag = false;
                //}
                if (txtStock.Text == "")
                {
                    epBatchConversion.SetError(txtStock, "Please enter stock quantity");
                    txtStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStock.ShowAlways = true;
                    tpStock.Show("Please enter stock quantity", txtStock, 5000);
                    varErrorFlag = false;
                }
                if (txtQty.Text == "")
                {
                    epBatchConversion.SetError(txtQty, "Please enter quantity");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter quantity", txtQty, 5000);
                    varErrorFlag = false;
                }
                if (txtConvertMrp.Text == "")
                {
                    epBatchConversion.SetError(txtConvertMrp, "Please enter mrp");
                    txtConvertMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMrp2.ShowAlways = true;
                    tpMrp2.Show("Please enter MRP", txtConvertMrp, 5000);
                    varErrorFlag = false;
                }
                if (txtMonth.Text == "")
                {
                    epBatchConversion.SetError(txtMonth, "Please enter the month");
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMonth.ShowAlways = true;
                    tpMonth.Show("Please enter month", txtMonth, 5000);
                    varErrorFlag = false;
                }
                if (txtYear.Text == "")
                {
                    epBatchConversion.SetError(txtYear, "Please enter the year");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpYear.ShowAlways = true;
                    tpYear.Show("Please enter year", txtYear, 5000);
                    varErrorFlag = false;
                }
                //if (txtBatchNo2.Text == "")
                //{
                //    epBatchConversion.SetError(txtQty, "Please enter batch number");
                //    txtBatchNo2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpBatchNo2.ShowAlways = true;
                //    tpBatchNo2.Show("Please enter batch number", txtBatchNo2, 5000);
                //    varErrorFlag = false;
                //}
                if (txtConvertQty.Text == "")
                {
                    epBatchConversion.SetError(txtConvertQty, "Please enter quantity");
                    txtConvertQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty2.ShowAlways = true;
                    tpQty2.Show("Please enter quantity", txtConvertQty, 5000);
                    varErrorFlag = false;
                }
                if (Convert.ToDecimal(txtQty.Text) > Convert.ToDecimal(txtStock.Text) || Convert.ToDecimal(txtQty.Text)==0)
                {
                    epBatchConversion.SetError(txtQty, "Please enter a valid quantity");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter a valid quantity", txtQty, 5000);
                    txtQty.Focus();
                    varErrorFlag = false;
                }
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epBatchConversion.SetError(txtMonth, "Please enter month.");
                        varErrorFlag = false;
                    }
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epBatchConversion.SetError(txtYear, "Please enter year.");
                        varErrorFlag = false;
                    }
                }
                string MRP = "";
                //varConvertMRP = Convert.ToDecimal(txtConvertMrp.Text);
                if (expirydateFlag == 1 || txtDay.Text != "" || txtMonth.Text != "" || txtYear.Text != "")
                {
                    udfnExpiryDateCheck();
                }
                decimal varMRP = Math.Round(Convert.ToDecimal(txtConvertMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                string varConvertMRP = string.Format("{0:0.00}", varMRP);
                MRP = varConvertMRP;
                if (MRP == txtMrp.Text && txtExpiryDate.Text == varExpiryDate && txtBatchNo.Text == txtConvertBatch.Text)
                {
                    udfnError();
                }
                udfnValidation();
                SPDataService objServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (varExpiryDate != "")
                {
                    if (expirydateFlag == 1)
                    {
                        MR_Master objMR_Master = new MR_Master();
                        objMR_Master.ViewType = 7;
                        objMR_Master.paraDate = dpConversionDate.Text;
                        objMR_Master.ParaExpiryDate = varExpiryDate;
                        objMR_Master.paraProductId = Convert.ToInt32(varPRID);
                        objDS = objServ.udfnMaster(objMR_Master);
                        objServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["DATEVALIDATE"]) == "0")
                            {
                                epBatchConversion.SetError(txtDay, "Invalid expiry date");
                                txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpProductName.ShowAlways = true;
                                tpProductName.Show("Invalid expiry date", txtDay, 5000);
                                varErrorFlag = false;
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
                                //varErrorFlag = true;
                            }
                        }
                    }
                }
                if (varErrorFlag == true &&  pbDateflag == 0)
                {
                    grdBatchConversion.Columns["clmProduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                    varActualQuantity = Convert.ToDecimal(txtQty.Text);
                    changedQuantity = changedQuantity + Convert.ToDecimal(txtConvertQty.Text);
                    if (changedQuantity > 0 && changedQuantity <= varActualQuantity)
                    {
                        if (txtConvertQty.Text != "")
                        {
                            string Qty = objValidation.udfnDecimal((txtConvertQty.Text), varDecimal);
                            txtConvertQty.Text = Qty;
                        }
                        if (grdBatchConversion.Rows.Count > 0)
                        {
                            varSNo = (from row in grdBatchConversion.Rows.Cast<DataGridViewRow>()
                                      let snoValue = string.IsNullOrEmpty(Convert.ToString(row.Cells["clmRowNum"].Value)) ? 0 : Convert.ToInt32(row.Cells["clmRowNum"].Value)
                                      select snoValue).Max();
                        }
                        grdBatchConversion.Rows.Add(grdBatchConversion.Rows.Count + 1, varPICode, (varTamilname), (txtConvertMrp.Text), (varExpiryDate).Trim(), (txtConvertBatch.Text).Trim(), (txtConvertQty.Text),varPRID,varRKID,varStockLocationId,varShelflife,varDecimal, varSNo+1);
                        dtStock.Rows.Add(Convert.ToDecimal((txtConvertQty.Text).Trim()),Convert.ToDecimal (txtConvertMrp.Text), (varExpiryDate).Trim(),Convert.ToString ((txtConvertBatch.Text).Trim()), Convert.ToInt32(varSNo+1));
                        grdBatchConversion.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdBatchConversion.Columns["clmMrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdBatchConversion.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdBatchConversion.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        //grdBatchConversion.Columns["clmExpiryDate"].DefaultCellStyle.BackColor = Color.PaleGreen;
                        totalQty.Text = Convert.ToString(changedQuantity);
                        txtConvertQty.Text = "";
                        txtConvertMrp.Focus();
                        udfnClear();
                        txtYear.BackColor = Color.White;
                        txtMonth.BackColor = Color.White;
                        txtDay.BackColor = Color.White;
                    }
                    else
                    {
                        changedQuantity = changedQuantity - Convert.ToDecimal(txtConvertQty.Text);
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtConvertQty.Focus();
                        txtConvertQty.Text = "";
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
                grdBatchConversion.ClearSelection();
                if (grdBatchConversion.Rows.Count > 0)
                {
                    txtProductName.Enabled = false;
                    cmbConcern.Enabled = false;
                    txtQty.Enabled = false;
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                }
                else if (btnSave.Text == "Save")
                {
                    //txtStockLocation.BackColor =Color.White;
                    cmbConcern.Enabled = true;
                    txtProductName.Enabled = true;
                    txtQty.Enabled = true;
                    txtProductName.BackColor=Color.White;
                    txtQty.BackColor = Color.White;
                }
                if(Convert.ToDecimal(txtQty.Text) == Convert.ToDecimal(changedQuantity))
                {
                    txtConvertMrp.Enabled = false;
                    txtConvertBatch.Enabled = false;
                    txtDay.Enabled = false;
                    txtMonth.Enabled = false;
                    txtYear.Enabled = false;
                    txtConvertQty.Enabled = false;
                    btnAdd.Enabled = false;
                    epBatchConversion.Clear();
                    txtConvertQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtConvertMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtConvertBatch.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtUnit3.Text = "";
                }
            }
        }
        public void udfnClear()
        {
            try
            {
                txtConvertMrp.Text = "";
                txtConvertBatch.Text = "";
                txtConvertQty.Text = "";
                txtDay.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                epBatchConversion.Clear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnError()
        {
            try
            {
                txtConvertBatch.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpBatchNo2.Show("Please enter valid batch number", txtConvertBatch, 5000);
                tpBatchNo2.ShowAlways = true;
                epBatchConversion.SetError(txtConvertBatch, "Please enter a valid batch number");
                txtConvertMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpMrp2.Show("Please enter valid MRP", txtConvertMrp, 5000);
                tpMrp2.ShowAlways = true;
                epBatchConversion.SetError(txtConvertMrp, "Please enter a valid MRP");
                txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                epBatchConversion.SetError(txtMonth, "Please enter a valid month");
                txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpMonth.ShowAlways = true;
                epBatchConversion.SetError(txtYear, "Please enter a valid year");
                txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpYear.ShowAlways = true;
                tpMonth.Show("Please enter valid month", txtMonth, 5000);
                tpYear.Show("Please enter valid year", txtYear, 5000);
                varErrorFlag = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnValidation()
        {
            try
            {
                string mrp = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtConvertMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                //string varExpiryDate1 = txtDay.Text + '/' + txtMonth.Text + '/' + "20" + txtYear.Text;
                string varExpiryDate1 = Convert.ToString(varExpiryDate);
                string varBatchNo = Convert.ToString(txtConvertBatch.Text);
                var varDuplicateProuct = from r in dtStock.AsEnumerable()
                                         where (r.Field<string>("STK_MRP").Equals(mrp1) &&
                                                  r.Field<string>("STK_ExpiryDate").Equals(varExpiryDate1) &&
                                                  r.Field<string>("STK_BatchNo").Equals(varBatchNo)
                                                  )
                                         group r by new { MRP = r["STK_MRP"], ExpiryDate = r["STK_ExpiryDate"], BatchNo = r["STK_BatchNo"] }
                                          into g
                                         select g.Key;

                if(varDuplicateProuct.Count()!=0)
                {
                    udfnError();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClearAll()
        {
            try
            {
                txtProductName.Text = "";
                txtStockLocation.Text = "";
                txtRack.Text = "";
                txtMrp.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStock.Text = "";
                txtQty.Text = "";
                txtConvertMrp.Text = "";
                txtConvertBatch.Text = "";
                txtConvertQty.Text = "";
                txtDay.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtUnit.Text = "";
                txtUnit2.Text = "";
                txtUnit3.Text = "";
                txtTotalUnit.Text = "";
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
        private void TxtStock_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtStock.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtQty.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDay_TextChanged(object sender, EventArgs e)
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtQty.Text)==Convert.ToDecimal(totalQty.Text))
                {
                    udfnSave();
                }
                else
                {
                    txtQty.Focus();
                    MessageBox.Show("Please check the quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                varEditFlag = 2;
                SPDataService objspservice = new SPDataService();
                string varoriginator = ""; int ViewType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Stock Conversion Creation";
                    ViewType = 0;
                }
                else
                {
                    varoriginator = "Stock Conversion Updation";
                    ViewType = 1;
                }
                epBatchConversion.Clear();
                bool blnErrorFlag = true;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epBatchConversion.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtProductName.Text).Trim() == "")
                {
                    epBatchConversion.SetError(txtProductName, "Please enter product");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter product", txtProductName, 5000);
                    blnErrorFlag = false;
                }

                if (Convert.ToString(txtQty.Text).Trim() == "")
                {
                    epBatchConversion.SetError(txtQty, "Please enter quantity");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter quantity", txtQty, 5000);
                    blnErrorFlag = false;
                }
                if (grdBatchConversion.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                }
                if (error == 1)
                {
                    blnErrorFlag = false;
                    SPDataService objDServ = new SPDataService();
                    //grdBatchConversion.Rows.Columns["clmExpiryDate"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    string varMessage = objDServ.udfnGetMessages(94);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //var varRowsToUpdate = dtStock.AsEnumerable().Where(r => r.Field<int>("SNo") == Convert.ToInt16(varsno));
                //if (varDuplicateProuct.Count() == 0)
                    //if (Convert.ToString(txtMrp2.Text).Trim() == "")
                    //{
                    //    epBatchConversion.SetError(txtMrp2, "Please enter MRP");
                    //    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpStockLocation.ShowAlways = true;
                    //    tpStockLocation.Show("Please enter MRP", txtMrp2, 5000);
                    //    blnErrorFlag = false;
                    //}
                    //if (Convert.ToString(txtMonth.Text).Trim() == "")
                    //{
                    //    epBatchConversion.SetError(txtMonth, "Please enter Month");
                    //    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpStockLocation.ShowAlways = true;
                    //    tpStockLocation.Show("Please enter Month", txtMonth, 5000);
                    //    blnErrorFlag = false;
                    //}
                    //if (Convert.ToString(txtYear.Text).Trim() == "")
                    //{
                    //    epBatchConversion.SetError(txtYear, "Please enter Year");
                    //    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpStockLocation.ShowAlways = true;
                    //    tpStockLocation.Show("Please enter Year", txtYear, 5000);
                    //    blnErrorFlag = false;
                    //}
                    //if (Convert.ToString(txtQty2.Text).Trim() == "")
                    //{
                    //    epBatchConversion.SetError(txtQty2, "Please enter Quantity");
                    //    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpStockLocation.ShowAlways = true;
                    //    tpStockLocation.Show("Please enter Quantity", txtQty2, 5000);
                    //    blnErrorFlag = false;
                    //}
                udfnValidation();
                string mrp = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                string varExpiryDate = Convert.ToString(txtExpiryDate.Text);
                string varBatchNo = Convert.ToString(txtBatchNo.Text);
                var varDuplicateData = (from r in dtStock.AsEnumerable()
                                         where (r.Field<string>("STK_MRP").Equals(mrp1) &&
                                                  r.Field<string>("STK_ExpiryDate").Equals(varExpiryDate) &&
                                                  r.Field<string>("STK_BatchNo").Equals(varBatchNo)
                                                  )
                                         group r by new { SNo = r["STK_SNo"] /*ExpiryDate = r["STK_ExpiryDate"], BatchNo = r["STK_BatchNo"]*/ }
                                          into g
                                         select g.Key).ToList();
                

                var varDuplicateGrid = dtStock.AsEnumerable()
                 .GroupBy(r => new { expirydate = r["STK_ExpiryDate"], MRP = r["STK_MRP"], BatchNo = r["STK_BatchNo"] })
                 .Where(g => g.Count() > 1)
                 .Select(g => g.Select(r => r["STK_SNo"]))
                 .ToList();

                //For text box
                if (varDuplicateData.Count() != 0)
                {
                    for (int j = 0; j < varDuplicateData.Count(); j++)
                    {
                        for (int i = 0; i < grdBatchConversion.Rows.Count; i++)
                        {
                            var key = varDuplicateData[j];
                            var SNoValue = key.SNo; // Access SNo value
                            if (Convert.ToString(SNoValue) == Convert.ToString(grdBatchConversion.Rows[i].Cells["clmRowNum"].Value))
                            {
                                grdBatchConversion.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                blnErrorFlag = false;
                            }
                        }
                    }
                }
                //For grid
                if (varDuplicateGrid.Count()!=0)
                {
                    for (int j = 0; j < varDuplicateGrid.Count(); j++)
                    {
                        //for (int k = 0; k < varDuplicateGrid[j].Count(); k++)
                        //{
                            for (int i = 0; i < grdBatchConversion.Rows.Count; i++)
                            {
                                var varSno = varDuplicateGrid[j].First();
                                if (Convert.ToString(varSno) == Convert.ToString( grdBatchConversion.Rows[i].Cells["clmRowNum"].Value))
                                {
                                    grdBatchConversion.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                    blnErrorFlag = false;
                                }
                            }
                       // }                            
                    }
                }
                
                //blnErrorFlag = false;
                if (varErrorFlag == false)
                {
                    blnErrorFlag = false;
                }
                if (blnErrorFlag == true)
                {
                    //udfntooltiphide();
                    string result = "";
                    epBatchConversion.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();
                    TRN_BatchConversion objTRN_BatchConversion = new TRN_BatchConversion();
                    objTRN_BatchConversion.ViewType = ViewType;
                    objTRN_BatchConversion.paraBTID = varBTID;
                    objTRN_BatchConversion.paraCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_BatchConversion.paraConversionDate = dpConversionDate.Text;
                    objTRN_BatchConversion.paraPRID = varPRID;
                    objTRN_BatchConversion.paraRKID = varRKID;
                    objTRN_BatchConversion.paraSLID = Convert.ToInt32(varStockLocationId);
                    objTRN_BatchConversion.paraMrp = txtMrp.Text;
                    objTRN_BatchConversion.paraExpiryDate = txtExpiryDate.Text;
                    objTRN_BatchConversion.paraBatchNo = txtBatchNo.Text;
                    objTRN_BatchConversion.paraQuantity = Convert.ToDecimal(txtQty.Text);
                    objTRN_BatchConversion.paraOriginator = varoriginator;
                    objTRN_BatchConversion.paraBatchConversion = dtStock;
                    result = objspdservice.udfnBatchConversion(objTRN_BatchConversion);
                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = txtProductName;
                        MainForm.objINV_StockConversionList.udfnList();
                        udfnClear();
                        this.Close();
                    }
                    else
                    {
                        epBatchConversion.Clear();
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = true;
                        btnSave.Focus();
                        txtStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        udfnClear();
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
                grdBatchConversion.ClearSelection();
            }
        }
        private void DpConversionDate_ValueChanged(object sender, EventArgs e)
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
        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                varDateChange = 0;
                udfnVocherno();
                udfnClearAll();
                grdBatchConversion.Rows.Clear();
                if (btnSave.Text == "Save")
                {
                    txtProductName.Text = "";
                    totalQty.Text = Convert.ToString(grdBatchConversion.Rows.Count);
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
                //string expiryDate = txtExpiryDate.Text;
                //string[] split = expiryDate.Split('/');
                //string varExpiry = Convert.ToString(split[2]);
                //int NewExpiry= Convert.ToInt32(varExpiry) % 100;
                //txtYear.Text = Convert.ToString(NewExpiry);

                //txtMonth.Text = Convert.ToString(split[1]);
                //txtDay.Text = Convert.ToString(split[0]);
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
                tpConcern.Active = false;
                tpProductName.Active = false;
                tpStock.Active = false;
                tpStockLocation.Active = false;
                tpRack.Active = false;
                tpMrp2.Active = false;
                tpQty.Active = false;
                tpQty2.Active = false;
                tpBatchNo.Active = false;
                tpBatchNo2.Active = false;
                tpQty.Active = false;
                tpQty2.Active = false;
                tpMonth.Active = false;
                tpYear.Active = false;      
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_StockConversion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (varChangeFlag==false)
                    {
                        DGV_FilterProduct.Visible = false;
                        udfntooltiphide();
                        udfnDiscard();
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        udfntooltiphide();
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
        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtConvertQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtConvertQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtConvertQty_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtConvertQty_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtConvertQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtConvertQty.Text) == "")
                {
                    epBatchConversion.SetError(txtConvertQty, "Please enter quantity");
                    txtConvertQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty2.ShowAlways = true;
                    tpQty2.Show("Please enter quantity", txtConvertQty, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtConvertQty.Text).Trim(), varDecimal);
                    txtConvertQty.Text = Qty;
                    epBatchConversion.Clear();
                    txtConvertQty.BackColor = Color.White;
                    tpQty2.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtConvertQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtConvertQty.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtConvertMrp_Enter(object sender, EventArgs e)
        {
            try
            {
                txtConvertMrp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtConvertMrp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDay.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtConvertMrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtConvertMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtConvertMrp.Text) == "")
                {
                    epBatchConversion.SetError(txtConvertMrp, "Please enter MRP");
                    txtConvertMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMrp2.ShowAlways = true;
                    tpMrp2.Show("Please enter MRP", txtConvertMrp, 5000);
                }
                else
                {
                    epBatchConversion.Clear();
                    txtConvertMrp.BackColor = Color.White;
                    tpMrp2.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtConvertBatch_Enter(object sender, EventArgs e)
        {
            try
            {
                txtConvertBatch.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        
        }
        private void TxtConvertBatch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtConvertQty.Focus();
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
                txtYear.TextAlign = HorizontalAlignment.Right;
                if (txtYear.Text.Length == 2)
                {
                    txtConvertBatch.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonth_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMonth.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtYear_Enter(object sender, EventArgs e)
        {
            try
            {
                txtYear.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtMonth_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtYear_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtDay_Leave(object sender, EventArgs e)
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

        private void GrdBatchConversion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdBatchConversion.CurrentCell.OwningColumn.Name == "clmExpiryDate")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBatchConversion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //String ExpiryDate = Convert.ToString(grdBatchConversion.CurrentRow.Cells["clmExpiryDate"].Value);
                //SPDataService objDServ = new SPDataService();
                //DataSet objDS = new DataSet();
                //if (Convert.ToString(grdBatchConversion.SelectedRows[0].Cells["clmExpiryDate"].Value) != "")
                //{
                //    if (expirydateFlag == 1)
                //    {
                //        objDS = objDServ.udfnMaster(7, 0, 0, dpConversionDate.Text, Convert.ToString(grdBatchConversion.SelectedRows[0].Cells["clmExpiryDate"].Value), Convert.ToInt32(varPRID), "", 0);
                //        objDServ.CloseConnection();
                //        if (objDS.Tables[0].Rows.Count > 0)
                //        {
                //            if (Convert.ToString(objDS.Tables[0].Rows[0]["DATEVALIDATE"]) == "0")
                //            {
                //                //epBatchConversion.SetError(txtDay, "Invalid expiry date");
                //                error = 1;
                //            }
                //            else
                //            {
                //                if (objDS.Tables[1].Rows.Count > 0)
                //                {
                //                    varShelflifevalue = Convert.ToString(objDS.Tables[1].Rows[0]["SHELFLIFE"]);

                //                }

                //                if (objDS.Tables[2].Rows.Count > 0)
                //                {
                //                    varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                //                }
                //                error = 0;
                //            }
                //        }
                //    }
                //}
                //    udfnExpiryDateCheck();
                //    //grdBatchConversion.CurrentRow.Cells["clmExpiryDate"].Style.BackColor = Color.PaleGreen;
                //    object varEditDate = grdBatchConversion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                //    // Update the same column value in the DataTable
                //    dtStock.Rows[e.RowIndex]["STK_ExpiryDate"] = varEditDate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtConvertBatch_Leave(object sender, EventArgs e)
        {
            try
            {
                txtConvertBatch.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBatchConversion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                //varErrorFormat = 0;
                //if (skipValidation == false)
                //{
                //    if (grdBatchConversion.Columns[e.ColumnIndex].Name == "clmExpiryDate")
                //    {
                //        string dateString = e.FormattedValue.ToString();
                //        if (dateString.Length != 10 && dateString != "")
                //        {
                //            varErrorFormat = 1;
                //            MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            grdBatchConversion.CurrentRow.Cells["clmExpiryDate"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //            //e.Cancel = true;
                //        }
                //        else
                //        {
                //            if (varShelflife==1 || dateString != "")
                //            {
                //                varExpiryDate = "";
                //                DataSet objDS = new DataSet();
                //                SPDataService objDServ = new SPDataService();
                //                objDS = objDServ.udfnMaster(8, 0, 0, dateString, "", 0, "", 0);
                //                objDServ.CloseConnection();
                //                if (objDS.Tables[0].Rows.Count > 0)
                //                {
                //                    if (Convert.ToString(objDS.Tables[0].Rows[0]["DATE"]) == "0")
                //                    {
                //                        varErrorFormat = 1;
                //                        MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //                        grdBatchConversion.CurrentRow.Cells["clmExpiryDate"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //                        e.Cancel = true;
                //                    }
                //                    else
                //                    {
                //                        varExpiryDate = e.FormattedValue.ToString();
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                //skipValidation = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtConvertMrp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtConvertMrp.TextAlign = HorizontalAlignment.Right;
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
        public void udfnEdit()
        {
            try
            {
                if (varBTID != 0)
                {
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    int ViewType = 1;
                    TRN_BatchConversion objTRNG_BatchConversion = new TRN_BatchConversion();
                    objTRNG_BatchConversion.ViewType = ViewType;
                    objTRNG_BatchConversion.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRNG_BatchConversion.paraBTID = Convert.ToInt32(varBTID);
                    objTRNG_BatchConversion.paraPRID = Convert.ToInt32(varPRID);
                    objTRNG_BatchConversion.paraIPAddress = MainForm.pbIpAddress;
                    objDs = objdserv.udfnBatchConversionList(objTRNG_BatchConversion);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbConcern.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["COMID"]);
                            dpConversionDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Date"]);
                            txtConversionNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ConversionNo"]);
                            txtProductName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product"]);
                            varPRID = Convert.ToInt32(objDs.Tables[0].Rows[0]["PRID"]);
                            txtStockLocation.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Stock Location"]);
                            varStockLocationId = Convert.ToInt32(objDs.Tables[0].Rows[0]["SLID"]);
                            txtRack.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Rack"]);
                            varRKID = Convert.ToInt32(objDs.Tables[0].Rows[0]["RKID"]);
                            txtMrp.Text= Convert.ToString(objDs.Tables[0].Rows[0]["MRP"]);
                            txtExpiryDate.Text= Convert.ToString(objDs.Tables[0].Rows[0]["Expiry Date"]);
                            txtBatchNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["BatchNo"]);
                            txtStock.Text = Convert.ToString(objDs.Tables[0].Rows[0]["STKQty"]);
                            txtQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Qty"]);
                            varPICode = Convert.ToString(objDs.Tables[0].Rows[0]["PICode"]);
                            varDecimal = Convert.ToInt32(objDs.Tables[0].Rows[0]["UT_Decimal"]);
                            totalQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Qty"]);
                            txtUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            txtUnit2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            txtUnit3.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            txtTotalUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            varTamilname = Convert.ToString(objDs.Tables[0].Rows[0]["Tamil Name"]);
                            //udfnExpiryDate();
                            btnSave.Text = "Update";
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                grdBatchConversion.Columns["clmProduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                grdBatchConversion.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["Product"]), Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["BatchNo"]),
                                Convert.ToDecimal(objDs.Tables[1].Rows[i]["Qty"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]), Convert.ToString(objDs.Tables[1].Rows[i]["Shelflife"]), Convert.ToString(objDs.Tables[1].Rows[i]["UT_Decimal"]),0);
                                dtStock.Rows.Add(Convert.ToDecimal(objDs.Tables[1].Rows[i]["Qty"]), Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["BatchNo"]),0);
                                sum += Convert.ToDecimal(grdBatchConversion.Rows[i].Cells["clmQty"].Value);
                                grdBatchConversion.Columns["clmMrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdBatchConversion.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdBatchConversion.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //grdBatchConversion.Columns["clmExpiryDate"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                varShelflife = Convert.ToInt32(objDs.Tables[1].Rows[i]["Shelflife"]);
                                if (varShelflife==1)
                                {
                                    expirydateFlag = 1;
                                }
                            }
                            varUpdateFlag = Convert.ToInt32(objDs.Tables[2].Rows[0]["ErrorCount"]);
                            if(varUpdateFlag>0)
                            {
                                btnSave.Enabled = false;
                                txtConvertMrp.Enabled = false;
                                txtDay.Enabled = false;
                                txtMonth.Enabled = false;
                                txtYear.Enabled = false;
                                txtConvertBatch.Enabled = false;
                                txtConvertQty.Enabled = false;
                                btnAdd.Enabled = false;
                                grdBatchConversion.Columns["clmremove"].Visible = false;
                                btnClose.Focus();
                            }
                            changedQuantity = sum;
                            btnSave.Text = "Update";
                        }
                    }
                    DGV_FilterProduct.Visible = false;
                    cmbConcern.Enabled = false;
                    dpConversionDate.Enabled = false;
                    txtProductName.Enabled = false;
                    txtQty.Enabled = false;
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdBatchConversion.ClearSelection();
                if(Convert.ToDecimal(totalQty.Text)==changedQuantity)
                {
                    txtConvertMrp.Enabled = false;
                    txtConvertBatch.Enabled = false;
                    txtDay.Enabled = false;
                    txtMonth.Enabled = false;
                    txtYear.Enabled = false;
                    txtConvertQty.Enabled = false;
                    btnAdd.Enabled = false;
                    epBatchConversion.Clear();
                    txtConvertQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtConvertMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtConvertBatch.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                    txtUnit3.Text = "";
                }
            }
        }
        private void GrdBatchConversion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string varMRP = "", varExpiryDate = "", varBatchNo = "",varQty = "",varPRID="";
                decimal Sum = 0;
                if (e.RowIndex != -1)
                {
                    switch (grdBatchConversion.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            varMRP = Convert.ToString(grdBatchConversion.SelectedRows[0].Cells["clmMrp"].Value);
                            varExpiryDate = Convert.ToString(grdBatchConversion.SelectedRows[0].Cells["clmExpirydate"].Value);
                            varBatchNo = Convert.ToString(grdBatchConversion.SelectedRows[0].Cells["clmBatchNo"].Value);
                            varQty = Convert.ToString(grdBatchConversion.SelectedRows[0].Cells["clmQty"].Value);
                            grdBatchConversion.Rows.RemoveAt(this.grdBatchConversion.SelectedRows[0].Index);
                            for (int i = 0; i < grdBatchConversion.RowCount; i++)
                            {
                                grdBatchConversion.Rows[i].Cells["clmSno"].Value = i + 1;
                                Sum += Convert.ToDecimal(grdBatchConversion.Rows[i].Cells["clmQty"].Value);
                            }
                                totalQty.Text = Convert.ToString(Sum);
                            changedQuantity = Sum;
                            for (int i = 0; i < dtStock.Rows.Count; i++)
                            {
                                if (Convert.ToString(dtStock.Rows[i]["STK_MRP"]) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo )
                                {
                                    dtStock.Rows[i].Delete();
                                    dtStock.AcceptChanges();                                      
                                }
                            }
                            if(grdBatchConversion.Rows.Count<1)
                            {
                                txtQty.Enabled = true;
                                txtQty.BackColor = Color.White;
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
                //totalQty.Text = Convert.ToString(grdBatchConversion.Rows.Count);
                if (grdBatchConversion.Rows.Count > 0)
                {
                    //txtStockLocation.Enabled = false;
                    txtProductName.Enabled = false;
                    cmbConcern.Enabled = false;
                }
                else if (btnSave.Text == "Save")
                {
                    //txtStockLocation.Enabled = true;
                    txtProductName.Enabled = true;
                    cmbConcern.Enabled = true;
                    txtProductName.BackColor = Color.White;
                }
                if (changedQuantity<Convert.ToDecimal(txtQty.Text))
                {
                    txtConvertMrp.Enabled = true;
                    txtConvertBatch.Enabled = true;
                    txtDay.Enabled = true;
                    txtMonth.Enabled = true;
                    txtYear.Enabled = true;
                    txtConvertQty.Enabled = true;
                    btnAdd.Enabled = true;
                    txtConvertQty.BackColor = Color.White;
                    txtConvertMrp.BackColor = Color.White;
                    txtConvertBatch.BackColor = Color.White;
                    txtDay.BackColor = Color.White;
                    txtMonth.BackColor = Color.White;
                    txtYear.BackColor = Color.White;
                    txtUnit3.Text = txtUnit2.Text;
                }

            }
        }
        public void udfnExpiryDateCheck()
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
                    objMR_Master.paraDate = dpConversionDate.Text.Trim();
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
                                            txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            string varMessage = objDServ.udfnGetMessages(98);
                                            objDServ.CloseConnection();
                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            varErrorFlag = false;
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
                    txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
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
        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                
                if (grdBatchConversion.CurrentCell.OwningColumn.Name == "clmExpiryDate")
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
                    {
                        e.Handled = true;  // Disallow the character
                    }
                    TextBox vartb = sender as TextBox;
                    if (vartb.Text.Length >= 10 && !char.IsControl(e.KeyChar))
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
    }
}
