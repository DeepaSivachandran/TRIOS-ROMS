using ROMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_ProductDetailsCopy1 : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;

        public int varUpDownKeyProduct = 0, varUpDownKey=0; 

         

        //tool tip
        private ToolTip tpRRate = new ToolTip();
        private ToolTip tpWRate = new ToolTip();
        private ToolTip tpVerifier = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        public CP_ProductDetailsCopy1()
        {
            InitializeComponent();
        }
            


        public void udfnclose()
        {
            try
            { 
                this.Close();
                MainForm.objCP_Rate_ChangeList.udfnList();
                MainForm.objCP_Rate_ChangeList.grdItemList.ClearSelection();
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

        private void CP_Product_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
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
                if (txtProductName.Text.Trim() != "")
                {
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    DGV_FilterProduct.Visible = false;
                }
                udfnProductDetails();
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
                varUpDownKeyProduct = 1;
                udfnListviewProduct(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MainForm.varCloseFlag == 0)
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

        private void txtProductName_Enter(object sender, EventArgs e)
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

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {  
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

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
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
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
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        } 
        public void udfnProductDetails()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 104; 
                objMR_Product.ParaProductCode = Convert.ToInt32(lblProductcode.Text); 
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblPICode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PR_PICode"]);
                            lblUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            lblGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Group"]);
                            lblSubGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Subgroup"]);
                            lblCategory.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Category"]);
                            lblProductType.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product Type"]);
                            lblPurLocation.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Pur_Location"]);
                            lblPurRack.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Pur_Rack"]);
                            lblSalesLocation.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Sales_Location"]);
                            lblRackGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Rackgroup"]);
                            lblUpp.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UPP"]);
                            lblHSN.Text = Convert.ToString(objDs.Tables[0].Rows[0]["HSN"]);
                            lblTax.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Tax"]);
                            lblShelflife.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Shelf Life"]);
                            lblShelflife.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Shelf Life"]); 
                            lblStock.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Stock"]);
                            lblBulk.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Bulk"]);
                            lblBarcode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Barcode"]);
                            lblStatus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Status"]);
                            lblRetailRate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RetailRate"]);
                            lblWholeRate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["WholesaleRate"]);
                            lblRetailMinQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RetailRate_MinQty"]);
                            lblWholesaleMinQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["WholesaleRate_MinQty"]);  
                            lblProductScheme.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product Scheme Eligible"]);
                            lblRateScheme.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Bill Scheme Eligible"]);
                            lblParentProduct.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ParentTname"]); 
                            lblFocus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Focus"]);
                            lblPriority.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Priority"]);
                            lblSpecial.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Special"]);
                            lblOwn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Own"]);
                        }
                        if (objDs.Tables.Count > 1)
                        {
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                grdSupplierList.DataSource = objDs.Tables[1];
                                grdSupplierList.Columns["S.No."].Width = 50;
                                grdSupplierList.Columns["Supplier"].Width = 450;
                                grdSupplierList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSupplierList.ClearSelection();
                            }
                        }
                        if (objDs.Tables.Count > 2)
                        {
                            grdItemList.DataSource = objDs.Tables[2];
                            grdItemList.Columns["S.No."].Width = 50;
                            grdItemList.Columns["Product"].Width = 400;
                            grdItemList.Columns["Product"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            grdSupplierList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.ClearSelection();
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
        public void udfnProductClear()
        {
            try
            { 
                lblPICode.Text ="";
                lblUnit.Text = "";
                lblGroup.Text = "";
                lblSubGroup.Text = "";
                lblCategory.Text = "";
                lblProductType.Text = "";
                lblPurLocation.Text = "";
                lblPurRack.Text = "";
                lblSalesLocation.Text = "";
                lblRackGroup.Text = "";
                lblUpp.Text = "";
                lblHSN.Text = "";
                lblTax.Text = "";
                lblShelflife.Text = "";
                lblShelflife.Text = "";
                lblStock.Text = "";
                lblBulk.Text = "";
                lblBarcode.Text = "";
                lblStatus.Text = "";
                lblRetailRate.Text = "";
                lblWholeRate.Text = "";
                lblRetailMinQty.Text = "";          
                lblWholesaleMinQty.Text ="";
                lblProductScheme.Text = "";
                lblRateScheme.Text = "";
                lblParentProduct.Text = "";
                lblFocus.Text = "";
                lblPriority.Text = "";
                lblSpecial.Text = "";
                lblOwn.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtProductName.Text.Trim()=="")
                {
                    lblProductcode.Text = "0";
                    grdItemList.DataSource = null;
                    grdSupplierList.DataSource = null;
                    udfnProductClear(); 
                }
                if (varUpDownKey == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 49;
                        objMR_Product.paraProductName = txtProductName.Text;
                        objMR_Product.paraFlag = 1;                         //Load Only Eligible for Sales Products
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "P.I Code";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50; 
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 0;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 1; 
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F); 
                                    DGV_FilterProduct.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
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
        private void txtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProductName.Text == "")
                {
                    errItems.SetError(txtProductName, "Please enter valid product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter valid product", txtProductName, 5000);
                }
                else
                {
                    txtProductName.BackColor = Color.White;
                    errItems.Clear();
                }  
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
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
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
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


    