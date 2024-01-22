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

        private ToolTip tpbrandname = new ToolTip();
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
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpBatchNo2 = new ToolTip();
        private ToolTip tpMonth = new ToolTip();
        private ToolTip tpYear = new ToolTip();
        public int varPRID = 0,varUTID=0,varRKID=0,varStockLocationId=0, varDecimal=0;
        DataTable dtStock = new DataTable();
        private bool varErrorFlag;
        public string varPICode = "", varTamilname ="";
        public string varbrandcode;
        public string pbFormStatus;
        public int varQuantity = 0;
        public decimal varActualQuantity = 0;
        public bool varChangeFlag = true;
        public int varBTID = 0;
        public int sum = 0;
        decimal changedQuantity = 0;
        public bool VarSearchFlag = true;

        public INV_StockConversion()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (varChangeFlag == false)
            {
                udfnDiscard();
            }
            else
            {
                udfnclose();
            }
        }
        public void udfnDiscard()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Discard Changes ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void INV_StockConversion_Load(object sender, EventArgs e)
        {
            try
            {
                dtStock.TableName = "TRN_BatchConversion_Product";
                dtStock.Columns.Add("STK_QTY", typeof(float));
                dtStock.Columns.Add("STK_MRP", typeof(string));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                udfnCmbConcern();
                this.ActiveControl = txtProductName;
                dpConversionDate.MaxDate = MainForm.pbCurrentDate; 
                VarSearchFlag = true;
                lblProductName.Text = "Search by P.I Code";
                grdBatchConversion.ClearSelection();
                if (btnSave.Text == "Save")
                {

                }
                else
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

        private void LblQty_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvproduct.Items.Count == 0 || txtProductName.Text == "")
                    {
                        txtQty.Focus();
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
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtQty.Focus();
                }
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblProductName.Text = "Search by P.I Code";
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductName.Text = "Search by Product Name";
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
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
                    txtMrp2.Focus();
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

        private void TxtBatchNo2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchNo2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBatchNo2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtQty2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBatchNo2_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtBatchNo2.Text) == "")
                //{
                //    epBatchConversion.SetError(txtBatchNo2, "Please enter batch number");
                //    txtBatchNo2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpBatchNo2.ShowAlways = true;
                //    tpBatchNo2.Show("Please enter batch number", txtBatchNo2, 5000);
                //}
                //else
                //{
                epBatchConversion.Clear();
                txtBatchNo2.BackColor = Color.White;
                tpBatchNo2.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQty2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtQty2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQty2_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtQty2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtQty2.Text) == "")
                {
                    epBatchConversion.SetError(txtQty2, "Please enter quantity");
                    txtQty2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty2.ShowAlways = true;
                    tpQty2.Show("Please enter quantity", txtQty2, 5000);
                }
                else
                {
                    epBatchConversion.Clear();
                    txtQty2.BackColor = Color.White;
                    tpQty2.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMrp2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMrp2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMrp2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBatchNo2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMrp2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtMrp2.Text) == "")
                {
                    epBatchConversion.SetError(txtMrp2, "Please enter MRP");
                    txtMrp2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMrp2.ShowAlways = true;
                    tpMrp2.Show("Please enter MRP", txtMrp2, 5000);


                }
                else
                {
                    epBatchConversion.Clear();
                    txtMrp2.BackColor = Color.White;
                    tpMrp2.Active = false;
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
                    txtBatchNo2.Focus();
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
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(75);
                            objDServ.CloseConnection();
                            txtConversionNo.Text = "";
                            DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                MainForm.objCP_Settings = new CP_Settings();
                                //MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                                //MainForm.objCP_Settings.varValues = Convert.ToString(38);
                                MainForm.objCP_Settings.MdiParent = this.ParentForm;
                                MainForm.objCP_Settings.Show();
                                this.Close();
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
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    varPRID = Convert.ToInt32(selectedItem.SubItems[0].Text);
                    txtProductName.Text = selectedItem.SubItems[4].Text;
                    varTamilname = selectedItem.SubItems[3].Text;
                    varPICode = selectedItem.SubItems[1].Text;
                    txtMrp.Text = selectedItem.SubItems[7].Text;
                    txtExpiryDate.Text = selectedItem.SubItems[8].Text;
                    txtBatchNo.Text = selectedItem.SubItems[9].Text;
                    txtStock.Text = selectedItem.SubItems[10].Text;
                    txtUnit.Text = selectedItem.SubItems[11].Text;
                    txtUnit2.Text = selectedItem.SubItems[11].Text;
                    txtUnit3.Text = selectedItem.SubItems[11].Text;
                    txtTotalUnit.Text = selectedItem.SubItems[11].Text;
                    varUTID = Convert.ToInt32(selectedItem.SubItems[12].Text);
                    varStockLocationId = Convert.ToInt32(selectedItem.SubItems[13].Text);
                    varRKID = Convert.ToInt32(selectedItem.SubItems[14].Text);
                    varDecimal = Convert.ToInt32(selectedItem.SubItems[15].Text);
                    txtRack.Text = selectedItem.SubItems[6].Text;
                    txtStockLocation.Text = selectedItem.SubItems[5].Text;
                    udfnExpiryDate();
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
                if (Convert.ToString(txtMonth.Text) == "")
                {
                    epBatchConversion.SetError(txtMonth, "Please enter the month");
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMonth.ShowAlways = true;
                    tpMonth.Show("Please enter month", txtMonth, 5000);
                }
                else
                {
                    epBatchConversion.Clear();
                    txtMonth.BackColor = Color.White;
                    tpMonth.Active = false;
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
                if (Convert.ToString(txtYear.Text) == "")
                {
                    epBatchConversion.SetError(txtYear, "Please enter the year");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpYear.ShowAlways = true;
                    tpYear.Show("Please enter Year", txtYear, 5000);
                }
                else
                {
                    epBatchConversion.Clear();
                    txtYear.BackColor = Color.White;
                    tpYear.Active = false;
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
                txtMrp2.Text = "";
                txtBatchNo2.Text = "";
                txtQty2.Text = "";
                txtUnit.Text = "";
                txtUnit2.Text = "";
                txtUnit3.Text = "";
                txtTotalUnit.Text = "";
                lvproduct.Items.Clear();
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
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PRODUCTLIST"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["STK_Qty"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["UTID"].ToString(), objDs.Tables[0].Rows[i]["STK_SLID"].ToString(), objDs.Tables[0].Rows[i]["STK_RKID"].ToString(), objDs.Tables[0].Rows[i]["UT_Decimal"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[3].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.BringToFront();
                                lvproduct.Columns[0].Width = 0;
                                lvproduct.Columns[1].Width = 120;
                                lvproduct.Columns[2].Width = 0;
                                lvproduct.Columns[3].Width = 250;
                                lvproduct.Columns[4].Width = 250;
                                lvproduct.Columns[5].Width = 70;
                                lvproduct.Columns[6].Width = 70;
                                lvproduct.Columns[7].Width = 60;
                                lvproduct.Columns[8].Width = 90;
                                lvproduct.Columns[9].Width = 70;
                                lvproduct.Columns[10].Width = 70;
                                lvproduct.Columns[11].Width = 50;

                                if (VarSearchFlag == false)
                                {
                                    lvproduct.Columns[4].Width = 320;
                                    lvproduct.Columns[3].Width = 0;
                                }
                                else
                                {
                                    lvproduct.Columns[4].Width = 0;
                                    lvproduct.Columns[3].Width = 320;
                                }
                            }
                            else
                            {
                                lvproduct.Visible = false;
                            }
                        }
                        else
                        {
                            lvproduct.Visible = false;
                        }
                    }

                    else
                    {
                        lvproduct.Visible = false;
                    }
                }
                else
                {
                    lvproduct.Visible = false;
                    lvproduct.Items.Clear();
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
                lvproduct.Visible = false;
                varErrorFlag = true;
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
                if (txtMrp2.Text == "")
                {
                    epBatchConversion.SetError(txtMrp2, "Please enter mrp");
                    txtMrp2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMrp2.ShowAlways = true;
                    tpMrp2.Show("Please enter MRP", txtMrp2, 5000);
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
                if (txtQty2.Text == "")
                {
                    epBatchConversion.SetError(txtQty2, "Please enter quantity");
                    txtQty2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty2.ShowAlways = true;
                    tpQty2.Show("Please enter quantity", txtQty2, 5000);
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

                for (int i = 0; i < dtStock.Rows.Count; i++)
                {
                    if (Convert.ToString(dtStock.Rows[i]["STK_MRP"]) == txtMrp2.Text && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == txtExpiryDate.Text && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == txtBatchNo2.Text)
                    {
                        epBatchConversion.SetError(txtQty2, "Please enter valid quantity");
                        txtQty2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpQty2.ShowAlways = true;
                        tpQty2.Show("Please enter valid quantity", txtQty2, 5000);
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(97);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrorFlag = false;
                    }
                }
                if (varErrorFlag == true)
                {
                    grdBatchConversion.Columns["clmProduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                    varActualQuantity = Convert.ToDecimal(txtQty.Text);
                    changedQuantity = changedQuantity + Convert.ToDecimal(txtQty2.Text);
                    if (changedQuantity > 0 && changedQuantity <= varActualQuantity)
                    {
                        if (txtQty2.Text != "")
                        {

                            string Qty = objValidation.udfnDecimal((txtQty2.Text).Trim(), varDecimal);
                            txtQty2.Text = Qty;
                        }
                        grdBatchConversion.Rows.Add(grdBatchConversion.Rows.Count + 1, varPICode, (varTamilname), (txtMrp2.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo2.Text).Trim(), (txtQty2.Text).Trim(),varPRID,varRKID,varStockLocationId);
                        dtStock.Rows.Add(Convert.ToDecimal(txtQty2.Text), (txtMrp2.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo2.Text).Trim());
                        grdBatchConversion.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdBatchConversion.Columns["clmMrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdBatchConversion.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdBatchConversion.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        totalQty.Text = Convert.ToString(changedQuantity);
                        txtQty2.Text = "";
                        txtMrp2.Focus();
                        udfnClear();
                        txtYear.Enabled = false;
                        txtMonth.Enabled = false;
                        txtDay.Enabled = false;
                    }
                    else
                    {
                        changedQuantity = changedQuantity - Convert.ToDecimal(txtQty2.Text);
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQty2.Focus();
                        txtQty2.Text = "";
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
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                }
                else
                {
                    //txtStockLocation.BackColor =Color.White;
                    cmbConcern.Enabled = true;
                    txtProductName.Enabled = true;
                    txtProductName.BackColor=Color.White;
                }
            }
        }
        public void udfnClear()
        {
            try
            {
                txtMrp2.Text = "";
                txtBatchNo2.Text = "";
                txtQty2.Text = "";
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
                txtMrp2.Text = "";
                txtBatchNo2.Text = "";
                txtQty2.Text = "";
                txtDay.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
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

        private void TxtMrp2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMrp2.TextAlign = HorizontalAlignment.Right;
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

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQty2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtQty2.TextAlign = HorizontalAlignment.Right;

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
                udfnVocherno();
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
                string expiryDate = txtExpiryDate.Text;
                string[] split = expiryDate.Split('/');
                txtYear.Text = Convert.ToString(split[2]);
                txtMonth.Text = Convert.ToString(split[1]);
                txtDay.Text = Convert.ToString(split[0]);
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
                    lvproduct.Visible = false;
                    udfntooltiphide();
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

        private void TxtQty2_KeyPress(object sender, KeyPressEventArgs e)
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
                if (varDecimal == 5)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else if (varDecimal == 6)
                {
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 2)
                    {
                        e.Handled = true;
                    }
                }
                else if (varDecimal == 7)
                {
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                    {
                        e.Handled = true;
                    }
                }
                else if (varDecimal == 8)
                {
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 4)
                    {
                        e.Handled = true;
                    }
                }
                if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = false;
                }
                if (varDecimal == 5)
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

        private void TxtMrp2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Lvproduct_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    objDs = objdserv.udfnBatchList(ViewType, varBTID, 0, "", "", varPRID);
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
                            totalQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Qty"]);
                            txtUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            txtUnit2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            txtUnit3.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            txtTotalUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            udfnExpiryDate();
                            btnSave.Text = "Update";
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                grdBatchConversion.Columns["clmProduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                grdBatchConversion.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["Product"]), Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["BatchNo"]),
                                Convert.ToDecimal(objDs.Tables[1].Rows[i]["Qty"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]), Convert.ToString(objDs.Tables[1].Rows[i]["SLID"]));
                                dtStock.Rows.Add(Convert.ToDecimal(objDs.Tables[1].Rows[i]["Qty"]), Convert.ToString(objDs.Tables[1].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["BatchNo"]));
                                sum += Convert.ToInt32(grdBatchConversion.Rows[i].Cells["clmQty"].Value);
                                grdBatchConversion.Columns["clmMrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdBatchConversion.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdBatchConversion.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //DGV_inward.Rows.Add(DGV_inward.Rows.Count + 1, varPRID, varPICode, (txtProduct.Text).Trim(), varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtOutwardQuantity.Text).Trim(), varUnit, varUTID);
                                //DGV_inward.Columns[10].ReadOnly = false;
                            }
                            changedQuantity = sum;
                            btnSave.Text = "Update";
                        }
                    }
                    lvproduct.Visible = false;
                    cmbConcern.Enabled = false;
                    dpConversionDate.Enabled = false;
                    txtProductName.Enabled = false;
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                    //txtQty.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdBatchConversion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string varMRP = "", varExpiryDate = "", varBatchNo = "",varQty = "";
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
                                    totalQty.Text = Convert.ToString(Sum);
                                }
                                changedQuantity = Sum;
                                for (int i = 0; i < dtStock.Rows.Count; i++)
                                {
                                    if (Convert.ToString(dtStock.Rows[i]["STK_MRP"]) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToString(dtStock.Rows[i]["STK_QTY"]) == varQty)
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
                //totalQty.Text = Convert.ToString(grdBatchConversion.Rows.Count);
                if (grdBatchConversion.Rows.Count > 0)
                {
                    //txtStockLocation.Enabled = false;
                    txtProductName.Enabled = false;
                    cmbConcern.Enabled = false;

                }
                else
                {
                    //txtStockLocation.Enabled = true;
                    txtProductName.Enabled = true;
                    cmbConcern.Enabled = true;
                    txtProductName.BackColor = Color.White;
                }
            }
        }
    }
}
