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
    public partial class PUR_PurchaseDC : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpDCDate = new ToolTip();
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpDay = new ToolTip();
        private ToolTip tpMonth = new ToolTip();
        private ToolTip tpYear = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpQuantity = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();

        public string varSuppliervalue = "";
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = ""
            , varorderSaleQty = "", varorderqty = "", addproductid = "", flag = "", varunitid = "0", pbProductsCode = "", pbunitname = "", varupdate = "0", varpendingPOID = "0", varReturnDC = "0", varDamage = "0", varcomid = "0";
        public string pbFormStatus;
        public int VarPrevSupplierid = 0;
        public PUR_PurchaseDC()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
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
        private void PUR_PurchaseDC_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbConcern();
                DataService objDservice = new DataService();
                string vardate = objDservice.displaydata("SELECT CONVERT(datetime,GETDATE(),103)");
                objDservice.CloseConnection();
                dpDCDate.Text = vardate;
                dpDCDate.MaxDate = DateTime.Now;
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
                SPDataService objdserv = new SPDataService();
                int varconcerntype = 4;
                if (btnSave.Text == "Save")
                {
                    varconcerntype = 3;
                }
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
                    dpDCDate.Focus();
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
        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epPurchaseDC.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    epPurchaseDC.Clear();
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
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                udfnVocherno();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDCDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpDCDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDCDate_KeyDown(object sender, KeyEventArgs e)
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
        private void DpDCDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpDCDate.BackColor = Color.White;
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
        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductName.Focus();
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
                if (txtSupplier.Text == "")
                {
                    epPurchaseDC.SetError(txtSupplier, "Please enter supplier");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                }
                else
                {
                    epPurchaseDC.Clear();
                    txtSupplier.BackColor = Color.White;
                    tpSuppliername.Active = false;
                }
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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(15, 0, 0, 0, 0, txtSupplier.Text, 0, 0, 0, "", 0, 0, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[3].Width = 0;
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
        }
        public void udfnsupplierLoad()
        {
            try
            {
                //pbSupplierpend = 0;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                //if (lblSupplierCode.Text != "0")
                //{
                //    tbSupplierDetails.Enabled = true;
                //}
                //else
                //{
                //    tbSupplierDetails.Enabled = false;
                //}
                if (lblSupplierCode.Text.Length > 0)
                {
                    int varReturnApplicable = 0, varReturnType = 0;
                    objDs = objspdservice.udfnSupplierList(16, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, "", 0, 0, Convert.ToInt32(cmbConcern.SelectedValue), "", 0, 0, 0, 0, 0, 0);
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
                            varReturnApplicable = Convert.ToInt16(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                            varReturnType = Convert.ToInt16(objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString());
                            if (varReturnApplicable == 22)
                            { lblReturn.Text = "Return Applicable - Yes"; }
                            else if (varReturnApplicable == 23)
                            { lblReturn.Text = "Return Applicable - No"; }
                            if (varReturnType == 24)
                            { lblReturnType.Text = "Return Cycle - Any Time"; }
                            if (varReturnType == 25)
                            { lblReturnType.Text = "Return Cycle - Weekly"; }
                            if (varReturnType == 26)
                            { lblReturnType.Text = "Return Cycle - Monthly"; }
                            if (varReturnType == 27)
                            { lblReturnType.Text = "Return Cycle - Quarterly"; }
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            lblSalesmanName.Text = "Supplier Name -" + objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString();
                            if (objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString() != "")
                            { lblMobileNo.Text = "Mobile No. -" + objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString(); }
                            if (objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString() != "")
                            { lblWhatsAppNo.Text = "WhatsApp No. -" + objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString(); }
                        }
                        if (objDs.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                            {
                                grdRepDetails.DataSource = objDs.Tables[2];
                                grdRepDetails.Columns["S.No."].Width = 40;
                                grdRepDetails.Columns["Rep Name"].Width = 150;
                                grdRepDetails.Columns["Brand"].Width = 150;
                                grdRepDetails.Columns["Phone No."].Width = 90;
                                grdRepDetails.Columns["WhatsApp No."].Width = 90;
                                grdRepDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                    varSuppliervalue = selectedItem.SubItems[3].Text;
                    udfnsupplierLoad();
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
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
            finally
            {
                LV_Supplier.Visible = false;
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
        public void ClearSupplier()
        {
            try
            {

                lblSuppliername.Text = "";
                lblSupplierCity.Text = "";
                lblsupplierGST.Text = "";
                lblsupplierScheduletype.Text = "";
                lblsupplierpayment.Text = "";
                lblSupplierOrderpolicy.Text = "";
                lblReturn.Text = "";
                lblReturnType.Text = "";
                lblSalesmanName.Text = "";
                lblMobileNo.Text = "";
                lblWhatsAppNo.Text = "";
                grdRepDetails.Rows.Clear();
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
                LV_Supplier.Visible = false;
                if (Convert.ToString(txtSupplier.Text) != "")
                {
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(23, 0, 0, 0, 0, txtSupplier.Text.Trim(), 0, 0, 0, "", 0, 0, 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varSupplierId = Convert.ToString(objDsSupplierId.Tables[0].Rows[0][0]);
                                values = Convert.ToString(varSupplierId).Split(',');
                            }
                        }
                    }
                    if (values[0] == "-1")
                    {
                        epPurchaseDC.SetError(txtSupplier, "Invalid supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        ClearSupplier();
                    }
                    else
                    {
                        epPurchaseDC.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White;
                        if (VarPrevSupplierid != Convert.ToInt32(lblSupplierCode.Text))
                        {
                            udfnsupplierLoad();
                        }
                    }
                    VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                }
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
                if (e.KeyCode == Keys.Enter)
                {
                    txtMrp.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvproduct.Items.Count == 0 || txtProductName.Text == "")
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
                if (txtProductName.Text.Trim() == "")
                {
                    epPurchaseDC.SetError(txtProductName, "Please enter product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                }
                else
                {
                    epPurchaseDC.Clear();
                    txtProductName.BackColor = Color.White;
                    tpProduct.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_Enter(object sender, EventArgs e)
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
        private void TxtMrp_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtMrp_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.LemonChiffon;
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
        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
        private void TxtMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMrp.Text.Trim() == "")
                {
                    txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtMrp, "Please enter MRP");
                    tpMRP.ShowAlways = true;
                    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                }
                else
                {
                    txtMrp.BackColor = Color.White;
                    epPurchaseDC.Clear();
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
        private void TxtMonth_Enter(object sender, EventArgs e)
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
        private void TxtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
        private void TxtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMonth.Text.Trim() == "")
                {
                    txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtMonth, "Please enter MRP");
                }
                else
                {
                    txtMonth.BackColor = Color.White;
                    epPurchaseDC.Clear();
                }
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
                    txtBatchNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
        private void TxtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text.Trim() == "")
                {
                    txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtYear, "Please enter MRP");
                }
                else
                {
                    txtYear.BackColor = Color.White;
                    epPurchaseDC.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchNo.BackColor = Color.LemonChiffon;
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
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0)
                {
                    //objDs = objspdservice.udfnStockLocationList(10, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0);
                    objDs = objspdservice.udfnStockLocationList(10,0, 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_TName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvStockLocation.Items.Add(objList);
                                }
                                lvStockLocation.Visible = true;
                            }
                        }
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
            finally
            {
                txtStockLocation.Focus();
            }
        }

        private void TxtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtActualQty.Focus();
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
                string varProductsCodes = "0";
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnproductmasterlist(29, 0, 0, 0, 0, txtProductName.Text, "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, txtProductName.Text, Convert.ToInt32(lblSupplierCode.Text), varProductsCodes, null);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.Columns[0].Width = 100;
                                lvproduct.Columns[1].Width = 250;
                                lvproduct.Columns[2].Width = 250;
                                lvproduct.Columns[3].Width = 0;
                            }
                        }
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
            finally
            {
            }
        }
        public void udfnPurLocationAutocomplete()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    ListViewItem selectedItem = lvStockLocation.SelectedItems[0];
                    txtStockLocation.Text = selectedItem.SubItems[0].Text;
                    lblStockLocationCode.Text = selectedItem.SubItems[2].Text;
                    lvStockLocation.Visible = false;
                    txtRack.Text = "";
                    lblRackCode.Text = "0";
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
        private void LvStockLocation_DoubleClick(object sender, EventArgs e)
        {
            udfnPurLocationAutocomplete();
        }

        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(lblStockLocationCode.Text), 0, txtRack.Text.Trim(), 0, 0);
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

        private void LvStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPurLocationAutocomplete();
                    txtRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            udfnPurRackAutocomplete();
        }
        public void udfnPurRackAutocomplete()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    lblRackCode.Text = selectedItem.SubItems[2].Text;
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
        private void TxtBatchNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBatchNo.Text.Trim() == "")
                {
                    txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtBatchNo, "Please enter BatchNo.");
                    tpBatchNo.ShowAlways = true;
                    tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                }
                else
                {
                    txtBatchNo.BackColor = Color.White;
                    epPurchaseDC.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtActualQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtActualQty.BackColor = Color.LemonChiffon;
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
                txtRemark.BackColor= Color.LemonChiffon;
            }
            catch(Exception ex)
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
                txtRemark.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtActualQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtStockLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtActualQty, "Please enter quantity.");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity.", txtActualQty, 5000);
                }
                else
                {
                    txtActualQty.BackColor = Color.White;
                    epPurchaseDC.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRack.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvStockLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        txtStockLocation.Focus();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtStockLocation.Text.Trim() == "")
                {
                    txtStockLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtStockLocation, "Please enter stock location.");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location.", txtStockLocation, 5000);
                }
                else
                {
                    txtStockLocation.BackColor = Color.White;
                    epPurchaseDC.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_Enter(object sender, EventArgs e)
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
        private void TxtRack_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRack.Text.Trim() == "")
                {
                    txtRack.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtRack, "Please enter rack.");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please enter rack.", txtRack, 5000);
                }
                else
                {
                    txtRack.BackColor = Color.White;
                    epPurchaseDC.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAdd_Click(sender, e);
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
                bool blnErrorFlag = false;
                int varflag = 0;
                if (Convert.ToString(txtProductName.Text).Trim() == "")
                {
                    epPurchaseDC.SetError(txtProductName, "Please enter product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    blnErrorFlag = true;
                }
                if (txtMrp.Text.Trim() == "")
                {
                    txtMrp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtMrp, "Please enter MRP");
                    tpMRP.ShowAlways = true;
                    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                    blnErrorFlag = true;
                }
                if (txtMonth.Text.Trim() == "")
                {
                    txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtMonth, "Please enter MRP");
                    blnErrorFlag = true;
                }
                if (txtYear.Text.Trim() == "")
                {
                    txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtYear, "Please enter MRP");
                    blnErrorFlag = true;
                }
                if (txtBatchNo.Text.Trim() == "")
                {
                    txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtBatchNo, "Please enter BatchNo.");
                    tpBatchNo.ShowAlways = true;
                    tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                    blnErrorFlag = true;
                }
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtActualQty, "Please enter quantity.");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity.", txtActualQty, 5000);
                    blnErrorFlag = true;
                }
                if (txtStockLocation.Text.Trim() == "")
                {
                    txtStockLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtStockLocation, "Please enter stock location.");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location.", txtStockLocation, 5000);
                    blnErrorFlag = true;
                }
                if (txtRack.Text.Trim() == "")
                {
                    txtRack.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epPurchaseDC.SetError(txtRack, "Please enter rack.");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please enter rack.", txtRack, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    udfnAdd();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAddClear()
        {
            try
            {
                txtProductName.Text = "";
                lblProductcode.Text = "0";
                txtMrp.Text = "";
                txtDay.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchNo.Text = "";
                txtActualQty.Text = "";
                txtStockLocation.Text = "";
                lblStockLocationCode.Text = "0";
                txtRack.Text = "";
                lblRackCode.Text = "0";
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAdd()
        {
            try
            {
                string varExpiryDate = "";
                varExpiryDate = txtDay.Text.Trim() + txtMonth.Text.Trim() + txtYear.Text.Trim();
                grdPurchaseDC.Rows.Add(grdPurchaseDC.Rows.Count + 1, varPICode.Trim(), varEName.Trim(), txtMrp.Text.Trim(), varExpiryDate, txtBatchNo.Text.Trim(), txtActualQty.Text.Trim(),lblUnit.Text, txtStockLocation.Text.Trim(), txtRack.Text.Trim(), addproductid, lblStockLocationCode.Text, lblRackCode.Text);
                udfnAddClear();
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
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpDCDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetPONO("149", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string pono = parts[0];
                        if (pono != "")
                        {
                            txtDcNo.Text = pono;
                        }
                        //else
                        //{
                        //    SPDataService objDServ = new SPDataService();
                        //    string varMessage = objDServ.udfnGetMessages(75);
                        //    objDServ.CloseConnection();
                        //    txtDcNo.Text = "";
                        //    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //    if (dialogResult == DialogResult.Yes)
                        //    {
                        //        MainForm.objCP_Settings = new CP_Settings();
                        //        MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                        //        MainForm.objCP_Settings.varValues = Convert.ToString(38);
                        //        MainForm.objCP_Settings.MdiParent = this.ParentForm;
                        //        MainForm.objCP_Settings.Show();
                        //        this.Close();
                        //    }
                        //}
                    }
                    else
                    {
                        txtDcNo.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDCDate_ValueChanged(object sender, EventArgs e)
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
        public void udfnProductAdd()
        {
            try
            {
                if (Convert.ToInt32(lblProductcode.Text) != 0)
                {
                    varPICode = ""; varEName = ""; var_Symbol = ""; var_Text = ""; var_RMinSaleQty = ""; varSTOCK = ""; varPrevious = "";
                    varPARITAL = ""; varReOrderQty = ""; varorderSaleQty = ""; addproductid = ""; varunitid = ""; flag = "0";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnproductmasterlist(34, Convert.ToInt32(lblProductcode.Text), 0, 0, 0, "", "", "", 0, 0, 0, Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, "", Convert.ToInt32(lblSupplierCode.Text), "", null);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varPICode = objDs.Tables[0].Rows[0]["PR_PICode"].ToString();
                            varEName = objDs.Tables[0].Rows[0]["PR_EName"].ToString();
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
                            flag = "3";
                            lblUnit.Text= objDs.Tables[0].Rows[0]["UT_Symbol"].ToString();
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
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[1].Text;
                    lblProductcode.Text = selectedItem.SubItems[3].Text;
                    udfnProductAdd();
                }
                txtMrp.Focus();
                txtMrp.Text = "";
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
        private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
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
