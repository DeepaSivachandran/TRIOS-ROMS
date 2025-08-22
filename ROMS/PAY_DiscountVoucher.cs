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
    public partial class PAY_DiscountVoucher : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpDiscamt = new ToolTip();
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0, varCloseFlag = 0, varPURID = 0, varUpdate = 0, PbDiscID = 0, varSTSID = 0;
        public string varcomid = "";
        decimal varInvoiceAmnt = 0;
        public int varSaveDisable = 0;

        public PAY_DiscountVoucher()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclose(object sender, EventArgs e)
        {

            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDropdownLoad()
        {
            try
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

                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                //cmbConcern.SelectedValue = 4;
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
        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epDiscount.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    epDiscount.Clear();
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
                    dpVoucDate.Focus();
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
                lblSuppliername.Visible = false;
                lblSupplierCity.Visible = false;
                lblsupplierGST.Visible = false;
                lblsupplierScheduletype.Visible = false;
                lblsupplierpayment.Visible = false;
                lblSupplierOrderpolicy.Visible = false;
                lblReturn.Visible = false;
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
                if (PbDiscID == 0)
                {
                    if (grdInvoice.Rows.Count != 0)
                    {
                        if (varcomid != Convert.ToString(cmbConcern.SelectedValue))
                        {
                            if (Convert.ToString(cmbConcern.SelectedValue) != "-1")
                            {
                                SPDataService objDServ = new SPDataService();
                                string varMessage = objDServ.udfnGetMessages(78);
                                objDServ.CloseConnection();

                                DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    txtSupplier.Text = "";
                                    lblSupplierCode.Text = "0";
                                }
                                else
                                {
                                    cmbConcern.SelectedValue = varcomid;
                                }
                            }
                        }
                    }
                }
                varcomid = Convert.ToString(cmbConcern.SelectedValue);
                varDateChange = 0;
                udfnvoucherload(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnvoucherload(object sender, EventArgs e)
        {
            try
            {
                if (PbDiscID == 0)
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpVoucDate.Text + "',103)");
                        varResult = objspdservice.udfngetVoucherNo("256", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string Discno = parts[0];
                        if (Discno != "")
                        {
                            txtDiscNo.Text = Discno;
                        }
                        else
                        {
                            varVoucherSkip = false;
                            if (varDateChange == 0)
                            {
                                udfnvoucheradd(sender, e);
                            }
                        }
                    }
                    else
                    {
                        txtDiscNo.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnvoucheradd(object sender, EventArgs e)
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(75);
                objDServ.CloseConnection();
                txtDiscNo.Text = "";
                if (varVoucherSkip == false)
                {
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        varVoucherSkip = true;
                        varClose = 1;
                        udfnclose(sender, e);
                        //MainForm.objCP_Settings = new CP_Settings();
                        //MainForm.objCP_Settings.MdiParent = this.ParentForm;
                        //MainForm.objCP_Settings.Show();
                        //this.Close();

                        MainForm.objCP_Settings = new CP_Settings();
                        MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                        MainForm.objCP_Settings.varValues = Convert.ToString(44);
                        MainForm.objCP_Settings.MdiParent = this.ParentForm;
                        MainForm.objCP_Settings.Show();
                        varCloseFlag = 1;
                        //udfnclose();
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

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
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

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplier.Text == "")
                {
                    epDiscount.SetError(txtSupplier, "Please enter supplier");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                }
                else
                {
                    epDiscount.Clear();
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
                grdInvoice.Rows.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    udfnClear();
                    MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 39;
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
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    udfnsupplierLoad();
                    udfnGridLoad();
                    txtInvoiceamt.Focus();
                    if (varSaveDisable == 0)
                    {
                        btnSave.Visible = false;
                    }
                    else
                    {
                        btnSave.Visible = true;
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
                LV_Supplier.Visible = false;
            }
        }
        public void udfnsupplierLoad()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {
                    int varReturnApplicable = 0, varReturnType = 0;
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {

                            lblSuppliername.Visible = true;
                            lblSupplierCity.Visible = true;
                            lblsupplierGST.Visible = true;
                            lblsupplierScheduletype.Visible = true;
                            lblsupplierpayment.Visible = true;
                            lblSupplierOrderpolicy.Visible = true;
                            //lblReturn.Visible = true;

                            lblSuppliername.Text = objDs.Tables[0].Rows[0]["NAME"].ToString();
                            lblSupplierCity.Text = objDs.Tables[0].Rows[0]["CITY"].ToString();
                            lblsupplierGST.Text = objDs.Tables[0].Rows[0]["GSTIN"].ToString();
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString();
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString();
                            lblSupplierOrderpolicy.Text = "Return Policy - " + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                            varReturnApplicable = Convert.ToInt16(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                            varReturnType = Convert.ToInt16(objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString());
                            //lblReturn.Text = objDs.Tables[0].Rows[0]["RETURNAPPLICABLE"].ToString();
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
        public void udfnGridLoad()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    TRN_DiscountVoucher objTRN_DiscountVoucher = new TRN_DiscountVoucher();
                    objTRN_DiscountVoucher.ViewType = 0;
                    objTRN_DiscountVoucher.paraSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    objTRN_DiscountVoucher.paraScheduleId = Convert.ToInt32(lblschedule.Text);
                    objTRN_DiscountVoucher.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objDs = objspdservice.udfnDiscountVoucherList(objTRN_DiscountVoucher);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            grdInvoice.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdInvoice.Rows.Add(false, Convert.ToString(objDs.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDs.Tables[0].Rows[i]["Voucher No"]), Convert.ToString(objDs.Tables[0].Rows[i]["Voucher Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice No"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Amount"]), Convert.ToString(objDs.Tables[0].Rows[i]["Status"]), Convert.ToString(objDs.Tables[0].Rows[i]["ID"]), Convert.ToString(objDs.Tables[0].Rows[i]["STSID"]));
                                grdInvoice.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInvoice.Columns["clmVoucherDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInvoice.Columns["clmInvoiceDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInvoice.Columns["clmAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                                if (Convert.ToString(objDs.Tables[0].Rows[i]["STSID"]) != "63")
                                {
                                    grdInvoice.Rows[i].Cells["clmCheck"].ReadOnly = true;
                                    grdInvoice.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                                }
                                else
                                {
                                    varSaveDisable = 1;
                                    if (PbDiscID != 0)
                                    {
                                        grdInvoice.Rows[i].Cells["clmCheck"].Value = true;
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
        private void TxtInvoiceamt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtInvoiceamt.Text) == "")
                {
                    epDiscount.SetError(txtInvoiceamt, "Please enter discount amount");
                    txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDiscamt.ShowAlways = true;
                    tpDiscamt.Show("Please enter discount amount", txtInvoiceamt, 5000);
                }
                else
                {
                    epDiscount.Clear();
                    txtInvoiceamt.BackColor = Color.White;
                    tpDiscamt.Active = false;
                    decimal varInvoiceAMT = Math.Round(Convert.ToDecimal(txtInvoiceamt.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                    string AMT = string.Format("{0:0.00}", varInvoiceAMT);
                    string AMT1 = string.Format("{0:G29}", decimal.Parse(AMT));
                    txtInvoiceamt.Text = AMT;
                    if (varInvoiceAmnt!=0)
                    {
                        if (Convert.ToDecimal(txtInvoiceamt.Text) > varInvoiceAmnt)
                        {
                            epDiscount.SetError(txtInvoiceamt, "Please enter valid discount amount");
                            txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpDiscamt.ShowAlways = true;
                            tpDiscamt.Show("Please enter valid discount amount", txtInvoiceamt, 5000);
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
                    btnSave.Focus();
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
                bool VarErrorFlag = false;
                string varSupplierId = "0";
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epDiscount.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select company", cmbConcern, 5000);
                    VarErrorFlag = true;
                }
                if (txtSupplier.Text == "")
                {
                    epDiscount.SetError(txtSupplier, "Please enter supplier");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                    VarErrorFlag = true;
                }
                if (txtDiscNo.Text == "")
                {
                    VarErrorFlag = true;
                }
                if (Convert.ToString(txtInvoiceamt.Text.Trim()) == "")
                {
                    epDiscount.SetError(txtInvoiceamt, "Please enter discount amount");
                    txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDiscamt.ShowAlways = true;
                    tpDiscamt.Show("Please enter discount amount", txtInvoiceamt, 5000);
                    VarErrorFlag = true;
                }
                if (Convert.ToString(txtDiscNo.Text) == "")
                {
                    udfnvoucheradd(sender, e);
                    VarErrorFlag = true;
                }
                string varCheck = "0";
                for (int i = 0; i < grdInvoice.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdInvoice.Rows[i].Cells["clmcheck"].Value) == true)
                    {
                        varCheck = "1";
                        varPURID = Convert.ToInt32(grdInvoice.Rows[i].Cells["clmPURID"].Value);
                    }
                }
                if (varCheck == "0")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(136);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    VarErrorFlag = true;
                }
                if (Convert.ToString(txtInvoiceamt.Text.Trim()) != "")
                {
                    if (Convert.ToDecimal(txtInvoiceamt.Text) > varInvoiceAmnt)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(145);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        VarErrorFlag = true;
                    }
                    if (Convert.ToDecimal(txtInvoiceamt.Text) == 0)
                    {
                        epDiscount.SetError(txtInvoiceamt, "Please enter valid discount amount");
                        txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpDiscamt.ShowAlways = true;
                        tpDiscamt.Show("Please enter valid discount amount", txtInvoiceamt, 5000);
                        VarErrorFlag = true;
                    }
                }
                if (VarErrorFlag == false)
                {
                    udfnSave(sender, e);
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int ViewType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Discount Voucher Creation";
                }
                else
                {
                    varoriginator = "Discount Voucher Updation";
                    ViewType = 1;
                }
                Model.TRN_DiscountVoucher objTRN_DiscountVoucher = new Model.TRN_DiscountVoucher();
                objTRN_DiscountVoucher.ViewType = ViewType;
                objTRN_DiscountVoucher.paraDiscountId = Convert.ToInt32(PbDiscID);
                objTRN_DiscountVoucher.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_DiscountVoucher.paraDiscountDate = dpVoucDate.Text;
                objTRN_DiscountVoucher.paraSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_DiscountVoucher.paraScheduleId = Convert.ToInt32(lblschedule.Text);
                objTRN_DiscountVoucher.ParaDiscountAmt = Convert.ToDecimal(txtInvoiceamt.Text.Trim());
                objTRN_DiscountVoucher.paraRemarks = txtRemark.Text.Trim();
                objTRN_DiscountVoucher.paraPURID = varPURID;
                objTRN_DiscountVoucher.paraStatusID = 102;
                objTRN_DiscountVoucher.paraOriginator = varoriginator;
                varResult = objspservice.udfnDiscountVoucher(objTRN_DiscountVoucher);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    string varAmountInWords = "";
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objPAY_DiscountVoucherList.udfnList();
                    varCloseFlag = 1;
                    udfnclose(sender, e);
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
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
        public void udfntooltiphide()
        {
            try
            {
                epDiscount.Clear();
                cmbConcern.BackColor = Color.White;
                tpConcern.Active = false;
                txtSupplier.BackColor = Color.White;
                tpSuppliername.Active = false;
                txtInvoiceamt.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
        private void PAY_Discount_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
                {
                    udfntooltiphide();
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
            finally
            {

            }
        }
        private void DpVoucDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpVoucDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpVoucDate_KeyDown(object sender, KeyEventArgs e)
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

        private void GrdInvoice_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {   //for check box as radio button function
                varInvoiceAmnt = 0;
                if (grdInvoice.CurrentCell.ColumnIndex == 0)
                {
                    for (int i = 0; i < grdInvoice.Rows.Count; i++)
                    {
                        grdInvoice.Rows[i].Cells[0].Value = false;
                    }
                    grdInvoice.Rows[grdInvoice.CurrentCell.RowIndex].Cells[0].Value = true;
                    varInvoiceAmnt=Convert.ToDecimal(grdInvoice.Rows[grdInvoice.CurrentCell.RowIndex].Cells["clmAmount"].Value);
                    if (txtInvoiceamt.Text!="")
                    {
                        if (Convert.ToDecimal(txtInvoiceamt.Text)> varInvoiceAmnt)
                        {
                            epDiscount.SetError(txtInvoiceamt, "Please enter valid discount amount");
                            txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpDiscamt.ShowAlways = true;
                            tpDiscamt.Show("Please enter valid discount amount", txtInvoiceamt, 5000);
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
        private void DpVoucDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpVoucDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PAY_DiscountVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose(sender, e);
                }
                if (e.KeyCode == Keys.F5)
                {
                    udfnSave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PAY_DiscountVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm objMainForm = new MainForm();
                objMainForm.udfnGetDefaultCompany();
                udfnDropdownLoad();
                udfnClear();
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    this.ActiveControl = txtSupplier;
                    udfnEditLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpVoucDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                varDateChange = 1;
                udfnvoucherload(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                varVoucherSkip = false;
            }
        }
        public void udfnEditLoad()
        {
            try
            {
                if (PbDiscID != 0)
                {
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    Model.TRN_DiscountVoucher objTRN_DiscountVoucher = new Model.TRN_DiscountVoucher();
                    objTRN_DiscountVoucher.ViewType = 2;
                    objTRN_DiscountVoucher.paraDiscountId = PbDiscID;
                    objDs = objdserv.udfnDiscountVoucherList(objTRN_DiscountVoucher);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            MainForm.objPAY_DiscountVoucherList.picLoader.Visible = false;
                            MainForm.objPAY_DiscountVoucherList.picLoader.SendToBack();
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                cmbConcern.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["DISC_COMID"]);
                                txtDiscNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DISC_No"]);
                                dpVoucDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DISC_Date"]);
                                txtSupplier.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Supplier"]);
                                lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SPID"]);
                                lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SPSCID"]);
                                varPURID = Convert.ToInt32(objDs.Tables[0].Rows[0]["DISC_PURID"]);
                                txtInvoiceamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DISC_Amount"]);
                                txtRemark.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DISC_Remarks"]);
                                varSTSID = Convert.ToInt32(objDs.Tables[0].Rows[0]["DISC_STSID"]);
                                int varSource = Convert.ToInt32(objDs.Tables[0].Rows[0]["DISC_Source"]);

                                LV_Supplier.Visible = false;
                                udfnsupplierLoad();

                                grdInvoice.Rows.Add(true, Convert.ToString(objDs.Tables[1].Rows[0]["S.No."]), Convert.ToString(objDs.Tables[1].Rows[0]["Voucher No"]), Convert.ToString(objDs.Tables[1].Rows[0]["Voucher Date"]), Convert.ToString(objDs.Tables[1].Rows[0]["Invoice No"]), Convert.ToString(objDs.Tables[1].Rows[0]["Invoice Date"]), Convert.ToString(objDs.Tables[1].Rows[0]["Invoice Amount"]), Convert.ToString(objDs.Tables[1].Rows[0]["Status"]), Convert.ToString(objDs.Tables[1].Rows[0]["ID"]), Convert.ToString(objDs.Tables[1].Rows[0]["STSID"]));
                                grdInvoice.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInvoice.Columns["clmVoucherDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInvoice.Columns["clmInvoiceDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInvoice.Columns["clmAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                varInvoiceAmnt = Convert.ToDecimal(objDs.Tables[1].Rows[0]["Invoice Amount"]);

                                cmbConcern.Enabled = false;
                                txtSupplier.Enabled = false;
                                txtInvoiceamt.Focus();
                                this.ActiveControl = txtInvoiceamt;
                                if (varSTSID == 103 || varSource == 1) // Source 1 - From mismatch approval, 2 - Direct discount voucher
                                {
                                    grbDiscount.Enabled = false;
                                    //foreach (Control ctrl in grbDiscount.Controls)
                                    //{
                                    //    if (ctrl != textBox1)
                                    //    {
                                    //        ctrl.Enabled = false;
                                    //    }
                                    //}
                                    //if (varSource == 1)
                                    //{
                                    //    btnSave.Enabled = true;
                                    //    txtInvoiceamt.Enabled = true;
                                    //    txtInvoiceamt.ReadOnly = false;
                                    //}
                                    this.ActiveControl = btnClose;
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
    }
}
