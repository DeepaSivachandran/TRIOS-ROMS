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
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    public partial class INV_InwardPurchaseList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        string varUserID = "0";
        ToolTip tpSupplier = new ToolTip();
        DataTable dtDefaultGrid = new DataTable();
        public int varUpDownKeyLocation = 0;
        int varPRID = 0, varparaflag = 0, varviewtype = 0, varDeleteFlag = 0, Varflag = 0, varUpDownKey = 0;
        public INV_InwardPurchaseList()
        {
            InitializeComponent();
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
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
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                MainForm.objINV_InwardPurchase = new INV_InwardPurchase();
                MainForm.objINV_InwardPurchase.MdiParent = this.ParentForm;
                //MainForm.objINV_InwardPurchase.btnSave.Text = "Update";
                MainForm.objINV_InwardPurchase.varInwardId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GIPID"].Value);
                MainForm.objINV_InwardPurchase.varID = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GIPID"].Value); //for remarks popup
                MainForm.objINV_InwardPurchase.varConcernId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GIP_COMID"].Value);
                MainForm.objINV_InwardPurchase.varLocationId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GIP_SLID"].Value);
                MainForm.objINV_InwardPurchase.varSupplierId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["SPID"].Value);
                MainForm.objINV_InwardPurchase.varScheduleId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["SPSCID"].Value);
                MainForm.objINV_InwardPurchase.varStausId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Status ID"].Value);
                MainForm.objINV_InwardPurchase.varGRNPurchaseFlag = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GIP_TypeID"].Value);
                MainForm.objINV_InwardPurchase.varEditFlag = 1;
                MainForm.objINV_InwardPurchase.varRemarkFlag = 1;
                MainForm.objINV_InwardPurchase.txtConcern.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Con"].Value);
                MainForm.objINV_InwardPurchase.txtStockLocation.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Location"].Value);
                MainForm.objINV_InwardPurchase.dpInwardDate.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["GIP_Date"].Value);
                MainForm.objINV_InwardPurchase.txtInwardNo.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Inward No."].Value);
                MainForm.objINV_InwardPurchase.dpInvoiceDate.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Inv Date"].Value);
                MainForm.objINV_InwardPurchase.txtInvoiceNo.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Inv No."].Value);
                MainForm.objINV_InwardPurchase.dpVoucherDate.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Transaction Date"].Value);
                MainForm.objINV_InwardPurchase.txtVoucherNo.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Transaction No."].Value);
                MainForm.objINV_InwardPurchase.varPurchaseStatus= Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase Status"].Value);
                MainForm.objINV_InwardPurchase.varPurchaseID= Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase ID"].Value);
                MainForm.objINV_InwardPurchase.varStatus= Convert.ToString(grdInwardList.SelectedRows[0].Cells["Goods Inward Status"].Value);
                MainForm.objINV_InwardPurchase.varGIPTransDate = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Transaction Date"].Value);
                //MainForm.objINV_InwardPurchase.txtGRNNo.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["GRN No."].Value);
                //MainForm.objINV_InwardPurchase.dpGRNDate.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["GRN Date"].Value);
                picLoader.Visible = false;
                picLoader.SendToBack();
                MainForm.objINV_InwardPurchase.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                picLoader.SendToBack();
            }
        }
        private void INV_InwardPurchaseList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    tsbEdit_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbDropDown()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                int varconcerntype = 4;
                //if (btnSave.Text == "Save")
                //{
                //    varconcerntype = 3;
                //}
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", " (STS_ModuleID=13 OR STSID IN (0)) AND STSID NOT IN (52,90) ", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=55 OR MSTID=0", "MST_DisplayText,MSTID", cmbEntryType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_InwardPurchaseList_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbDropDown();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
               // udfnDate();
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                this.ActiveControl = cmbConcern;
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDate()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 9;
                objMR_Master.paraID = 6;
                objMR_Master.paraFlag = 10;
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(objMR_Master);
                if (objd.Tables[0].Rows.Count != 0)
                {
                    DateTime vardate = DateTime.ParseExact(Convert.ToString(objd.Tables[0].Rows[0]["DATE"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //  dpDcFromDate.MaxDate = varmaxdate;
                    dpFromDate.Text = Convert.ToString(vardate);
                    dpToDate.MinDate = vardate;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbQue_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objINV_InwardQueueList = new INV_InwardQueueList();
                MainForm.objINV_InwardQueueList.MdiParent = this.ParentForm;
                MainForm.objINV_InwardQueueList.Show();
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
                    dpFromDate.Focus();
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
                cmbConcern.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpToDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpToDate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_KeyDown(object sender, KeyEventArgs e)
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
        private void DpToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.White;
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
                DGV_FilterProduct.Visible = false;
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
                varUpDownKeyLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterLocation.Visible == false)
                {
                    txtProductName.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterLocation.Focus();
                }
                if (DGV_FilterLocation.CurrentCell == null && DGV_FilterLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterLocation.Focus();
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtStockLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtStockLocation.Focus();
                            txtStockLocation.SelectionStart = txtStockLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtStockLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtStockLocation.Focus();
                            txtStockLocation.SelectionStart = txtStockLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnPurLocationAutocomplete();
                                    DGV_FilterLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtStockLocation.Focus();
                    //txtStockLocation.SelectionStart = txtStockLocation.Text.Length;
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
        private void TxtStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.White;
                if(txtStockLocation.Text.Trim()=="")
                {
                    lblStockLocationCode.Text = "0";
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
                DGV_FilterLocation.Visible = false;
                DGV_FilterLocation.DataSource = null;
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
                    DGV_FilterProduct.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    cmbEntryType.Focus();
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
                                    udfnProductEvent();
                                    //DGV_FilterProduct.Items[0].Selected = true;
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
                        cmbEntryType.Focus();
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
                txtProductName.BackColor = Color.White;
                if(txtProductName.Text.Trim()=="")
                {
                    varPRID = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["GRN ID"].Visible = false;
                DGV_SearchGrid.Columns["Purchase ID"].Visible = false;
                DGV_SearchGrid.Columns["GIP_COMID"].Visible = false;
                DGV_SearchGrid.Columns["GIP_SLID"].Visible = false;
                DGV_SearchGrid.Columns["SPID"].Visible = false;
                DGV_SearchGrid.Columns["GIPID"].Visible = false;

                DGV_SearchGrid.Columns["SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["Status ID"].Visible = false;
                DGV_SearchGrid.Columns["Entry Type"].Width = 170;
                DGV_SearchGrid.Columns["GIP_TypeID"].Visible = false;
                DGV_SearchGrid.Columns["GIP_Date"].Visible = false;
                DGV_SearchGrid.Columns["Purchase Status"].Visible = false;
                DGV_SearchGrid.Columns["Overall Full Status"].Visible = false;
                DGV_SearchGrid.Columns["Goods Inward Full Status"].Visible = false;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                Varflag = 0;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                // ep_PurchaseDC.Clear();
                grdInwardList.DataSource = null;
                DataSet objDs = new DataSet();
                string varSupplierId = "0";
                //**** To call the function from SP ********* 
                if (txtSupplier.Text == "")
                {
                    varSupplierId = "0";
                    lblschedule.Text = "0";
                }
                else
                {
                    string[] values = new string[0];
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 31;
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
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
                        epGoodsInwardList.SetError(txtSupplier, "Invalid supplier.");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        Varflag = 1;
                    }
                    else
                    {
                        epGoodsInwardList.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White;

                    }
                    //VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                }
                if (Varflag == 0)
                {
                    btnView.Enabled = false;
                    lblStatus.Focus();
                    varviewtype = 1;
                    SPDataService objdserv = new SPDataService();
                    TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                    objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                    objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_GoodsInward_Purchase.paraSLID = Convert.ToInt32(lblStockLocationCode.Text);
                    objTRN_GoodsInward_Purchase.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_GoodsInward_Purchase.paraProductId = Convert.ToInt32(varPRID);
                    objTRN_GoodsInward_Purchase.paraStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                    objTRN_GoodsInward_Purchase.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    objTRN_GoodsInward_Purchase.ParaFromDate = Convert.ToString(dpFromDate.Text);
                    objTRN_GoodsInward_Purchase.ParaToDate = Convert.ToString(dpToDate.Text);
                    objTRN_GoodsInward_Purchase.paraStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                    objTRN_GoodsInward_Purchase.paraTypeID = Convert.ToInt32(cmbEntryType.SelectedValue);
                    objDs = objdserv.udfnInwardPurchaseList(objTRN_GoodsInward_Purchase);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                lblNoRecordsFound.Visible = false;
                                lblNoRecordsFound.SendToBack();
                                grdInwardList.DataSource = objDs.Tables[0];
                                grdInwardList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                               // grdInwardList.Columns["Inward No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInwardList.Columns["Inward Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInwardList.Columns["Transaction Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInwardList.Columns["Tot Pro in Invoice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInwardList.Columns["Con"].Width = 80;
                                grdInwardList.Columns["Transaction Date"].Width = 110;
                                grdInwardList.Columns["Transaction No."].Width = 100;
                                grdInwardList.Columns["Supplier"].Width = 250;
                                grdInwardList.Columns["Tot Pro in Invoice"].Width = 160;
                                grdInwardList.Columns["Location"].Width = 130;
                                grdInwardList.Columns["Created By"].Width = 200;
                                grdInwardList.Columns["Goods Inward Status"].Width = 150;
                              //  grdInwardList.Columns["Created On"].Width = 140;
                                grdInwardList.Columns["GSTIN"].Visible = false;
                                grdInwardList.Columns["Location"].Width = 170;
                                // grdInwardQueueList.Columns["Status"].Width = 100;
                                grdInwardList.Columns["S.No."].Width = 60;
                                grdInwardList.Columns["GRN ID"].Visible = false;
                                grdInwardList.Columns["Purchase ID"].Visible = false;
                                grdInwardList.Columns["GIP_COMID"].Visible = false;
                                grdInwardList.Columns["GIP_SLID"].Visible = false;
                                grdInwardList.Columns["GIP_TypeID"].Visible = false;
                                grdInwardList.Columns["Entry Type"].Width = 170;
                                grdInwardList.Columns["SPID"].Visible = false;
                                grdInwardList.Columns["GIPID"].Visible = false;
                                grdInwardList.Columns["GIP_Date"].Visible = false;
                                grdInwardList.Columns["SPSCID"].Visible = false;
                                grdInwardList.Columns["Status ID"].Visible = false;
                                grdInwardList.Columns["Purchase Status"].Visible = false;
                                grdInwardList.Columns["Overall Full Status"].Visible = false;
                                grdInwardList.Columns["Goods Inward Full Status"].Visible = false;
                            }
                            else
                            {
                                lblNoRecordsFound.Visible = true;
                                lblNoRecordsFound.BringToFront();
                            }
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                    udfnSearchGridHead();
                    if (lblNoRecordsFound.Visible == true)
                    {
                        dtDefaultGrid = objDs.Tables[0];
                        udfnDefaultSearchGrid();
                    }
                    else { DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    grdInwardList.DataSource = null;
                    DGV_SearchGrid.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                picLoader.SendToBack();
                btnView.Focus();
                btnView.Enabled = true;
                udfnQueueListCount();
            }
        }
        public void udfnQueueListCount()
        {
            try
            {
                // For Queue Count Calculation Process Directly Call the Queue Details SP the reason is Repeated calculate the issue count - 27-06-2025 Comment By Sathish
                /*
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 14;
                objTRN_PurchaseEntry.paraType = 3;
                //objTRN_PurchaseEntry.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblQueueCount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Queue Count"]);
                    }
                }
                */
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                objTRN_GoodsInward_Purchase.ViewType = 3;
                objTRN_GoodsInward_Purchase.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                DateTime vardate = MainForm.pbFYStartDate;
                string formattedDate = vardate.ToString("dd'/'MM'/'yyyy", CultureInfo.InvariantCulture);
                objTRN_GoodsInward_Purchase.ParaFromDate = formattedDate;
                objTRN_GoodsInward_Purchase.ParaToDate = Convert.ToString(dpToDate.Text);
                objTRN_GoodsInward_Purchase.paraSLID = 0;
                objTRN_GoodsInward_Purchase.paraProductId = 0;
                objTRN_GoodsInward_Purchase.ParaSupplierId = 0;
                objTRN_GoodsInward_Purchase.paraTypeID = 0;
                objDs = objdserv.udfnInwardPurchaseList(objTRN_GoodsInward_Purchase);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblQueueCount.Text = Convert.ToString(objDs.Tables[0].Rows.Count.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdInwardList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdInwardList.Columns)
                    {
                        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    if (lblNoRecordsFound.Visible == false)
                    {
                        DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    //dgv2.DataSource = null;
                    dgv2.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in dgv1.Columns)
                    {
                        if (col.Visible)
                        {
                            dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                            visibleColumns.Add(col.Index);
                        }
                    }
                    int rowIndex = 0;
                    dgv2.Rows.Clear();
                    dgv2.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                udfnDelete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDelete()
        {
            try
            {
                if (varDeleteFlag == 0)
                {
                    if (grdInwardList.SelectedRows.Count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string varorginator = "Goods Inward from GRN Deletion", result = "";
                            varviewtype = 2;
                            if(Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GRN ID"].Value)!=0)
                            { varparaflag = 1; }
                            else if (Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase ID"].Value) != 0)
                            { varparaflag = 2; }
                            int varUserID = 0;
                            TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                            objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                            objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                            objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                            objTRN_GoodsInward_Purchase.paraOriginator = varorginator;
                            objTRN_GoodsInward_Purchase.paraHostName = MainForm.pbHostName;
                            objTRN_GoodsInward_Purchase.paraGRNID = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GRN ID"].Value.ToString());
                            objTRN_GoodsInward_Purchase.paraPurchaseID = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase ID"].Value.ToString());
                            objTRN_GoodsInward_Purchase.paraDeleteFlag = 0;
                            objTRN_GoodsInward_Purchase.paraFlag = varparaflag;
                            objTRN_GoodsInward_Purchase.paraInwardId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GIPID"].Value.ToString());
                            SPDataService objspdservice = new SPDataService();
                            result = objspdservice.udfnGoodsInwardPurchase(objTRN_GoodsInward_Purchase);
                            objspdservice.CloseConnection();
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "3")
                            {
                                if (result.Split('~')[1] == "1")
                                {
                                    MainForm.objCP_Verify = new CP_Verify();
                                    MainForm.objCP_Verify.ShowDialog();
                                    if (MainForm.objCP_Verify.flag == 1)
                                    {
                                        varUserID = Convert.ToInt32(MainForm.objCP_Verify.varUserId);
                                        objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                                        objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(varUserID);
                                        objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                                        objTRN_GoodsInward_Purchase.paraOriginator = varorginator;
                                        objTRN_GoodsInward_Purchase.paraHostName = MainForm.pbHostName;
                                        objTRN_GoodsInward_Purchase.paraDeleteFlag = 1;
                                        objTRN_GoodsInward_Purchase.paraInwardId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GIPID"].Value.ToString());
                                        SPDataService objspdservice1 = new SPDataService();
                                        result = objspdservice1.udfnGoodsInwardPurchase(objTRN_GoodsInward_Purchase);
                                        objspdservice1.CloseConnection();
                                        if (result.Split('~')[0] == "3")
                                        {
                                            MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            varviewtype = 1;
                                            udfnList();
                                        }
                                        else { MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                                    }
                                }
                            }
                            else if (result.Split('~')[0] == "4")
                            {
                                MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
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
        }
        private void GrdInwardList_KeyDown(object sender, KeyEventArgs e)
        {
            int varDeleteFlag = 0;
            if (e.KeyCode == Keys.Enter)
            {
                tsbEdit_Click(sender, e);
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.D)
            {
                if (Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Status ID"].Value) != 45 && Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase ID"].Value) != 0 && (Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase Status"].Value) != 49 || Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase Status"].Value) == 49))
                {
                    varDeleteFlag = 0;
                }
                else
                {
                    varDeleteFlag = 1;
                }
            }
            if(varDeleteFlag==1)
            { TsbDelete_Click(sender, e); }
        }
        private void GrdInwardList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tsbEdit_Click(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                    BtnView_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurLocationAutocomplete()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    lblStockLocationCode.Text = Convert.ToString(DGV_FilterLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtStockLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
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
                if (varUpDownKeyLocation == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtStockLocation.Text.Length > 0)
                    {
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 27;
                        objMR_Location.paraId = 5;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtStockLocation.Text.Trim();
                        objMR_Location.ParaFromDate = dpFromDate.Text;
                        objMR_Location.ParaToDate = dpToDate.Text;
                        objMR_Location.paraUserLocations = MainForm.pbUserMappedLocationIds;
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(27, Convert.ToInt32(cmbConcern.SelectedValue), 0, 5, txtStockLocation.Text.Trim(), 0, 0, 0, dpFromDate.Text, dpToDate.Text, 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterLocation.Visible = true;
                                    DGV_FilterLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_EName"].HeaderText = "Location English Name";
                                    DGV_FilterLocation.Columns["SL_TName"].HeaderText = "Location Tamil Name";
                                    DGV_FilterLocation.Columns["SL_EName"].Width = 160;
                                    DGV_FilterLocation.Columns["SL_TName"].Width = 160;
                                    DGV_FilterLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterLocation.Columns["SL_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterLocation.Visible = false;
                                    DGV_FilterLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterLocation.Visible = false;
                                DGV_FilterLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterLocation.Visible = false;
                            DGV_FilterLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterLocation.Visible = false;
                        DGV_FilterLocation.DataSource = null;
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
                txtStockLocation.Focus();
            }
        }

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //lvProduct.Items.Clear();
                if (varUpDownKey == 0)
                {
                    int varSupplierId = 0; string varScheduleId = "0";
                    if (txtSupplier.Text.Trim() != "")
                    {
                        varSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                        varScheduleId = lblschedule.Text;
                    }
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 53;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraLocationId = Convert.ToInt32(lblStockLocationCode.Text);
                        objMR_Product.paraProductName = txtProductName.Text;
                        objMR_Product.ParaFromDate = dpFromDate.Text;
                        objMR_Product.ParaToDate = dpToDate.Text;
                        objMR_Product.ParaSupplierId = varSupplierId;
                        objMR_Product.ParaScheduleid = varScheduleId;
                        objMR_Product.paraId = 1;
                        DataSet objDs = new DataSet();
                        SPDataService objspdservice = new SPDataService();
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    //for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    //{
                                    //    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString() };
                                    //    ListViewItem objList = new ListViewItem(row);
                                    //    objList.UseItemStyleForSubItems = false;
                                    //    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    //    lvProduct.Items.Add(objList);
                                    //}
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 400;
                                    DGV_FilterProduct.Columns["Unit"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                        //lvProduct.Visible = false;
                        //lvProduct.Items.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductEvent()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    varPRID = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString());
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                }
                btnView.Focus();
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
        //private void LvProduct_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lvProduct.BringToFront();
        //        udfnProductEvent();
        //        cmbEntryType.Focus();
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}
        private void DGV_SearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdInwardList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdInwardList);
                objDser.CloseConnection();
                grdInwardList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdInwardList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdInwardList);
                objDser.CloseConnection();
                grdInwardList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 0))   /*If not our desired columns*/
                                                                   //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdInwardList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdInwardList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdInwardList.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            // Sort a new column and remove the old SortGlyph.
                            direction = ListSortDirection.Ascending;
                            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                        }
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    grdInwardList.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_SearchGrid.HorizontalScrollingOffset = grdInwardList.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdInwardList.ColumnCount > 0)
                {
                    grdInwardList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdInwardList.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdInwardList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdInwardList);
                objDser.CloseConnection();
                grdInwardList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdInwardList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdInwardList.Width > grdInwardList.HorizontalScrollingOffset && grdInwardList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdInwardList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdInwardList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdInwardList.Width > grdInwardList.HorizontalScrollingOffset && grdInwardList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdInwardList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbStatus.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbEntryType_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                varUpDownKey = 0;
                cmbEntryType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbEntryType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbEntryType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbEntryType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbEntryType.BackColor = Color.White;
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
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                    //udfnsupplierLoad();
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    txtStockLocation.Focus();
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
        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    objMR_Supplier.ParaToDate = dpToDate.Text;
                    objMR_Supplier.paraFlag = 7;
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
                    txtStockLocation.Focus();
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
                txtSupplier.BackColor = Color.White;
                if(txtSupplier.Text.Trim()=="")
                {
                    lblSupplierCode.Text = "0";
                    lblschedule.Text = "0";
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
                                    udfnProductEvent();
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
                udfnProductEvent();
                cmbEntryType.Focus();
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
        public void udfnDeleteHide()
        {
            try
            {
                //if(Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Status ID"].Value)==46 && Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase ID"].Value)==0)
                //{
                //    tsbDelete.Visible = false;
                //    tssEdit.Visible = false;
                //}
                if(Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Status ID"].Value) != 45 && Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase ID"].Value) != 0 && (Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase Status"].Value)!=49 || Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["Purchase Status"].Value)==49))
                {
                    tsbDelete.Visible = false;
                    tssEdit.Visible = false;
                }
                else
                {
                    tsbDelete.Visible = true;
                    tssEdit.Visible = true;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdInwardList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                udfnDeleteHide(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                btnExport.Enabled = false;
                lblDProductNamePicode.Focus();
                if ((grdInwardList.Rows.Count > 0))
                {
                    Excel._Application ExcelObj = new Excel.Application();
                    // creating new WorkBook within Excel application  
                    Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                    // creating new Excelsheet in workbook  
                    Excel._Worksheet ExcelSheet = null;
                    // see the excel sheet behind the program  
                    ExcelObj.Visible = true;
                    ExcelSheet = ExcelBook.Sheets["Sheet1"];
                    ExcelSheet = ExcelBook.ActiveSheet;
                    // changing the name of active sheet  
                    ExcelSheet.Name = "Inward From Purchase,GRN,DC ";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdInwardList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Inward From Purchase,GRN & DC";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdInwardList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "S.No." || col.Name == "Con")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            else if (col.Name == "Location" || col.Name == "Tot Pro in Invoice" || col.Name == "Goods Inward Status" || col.Name == "Created On" || col.Name=="Entry Type")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }
                            else if(col.Name=="Supplier")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 40;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            if (col.Name == "S.No." || col.Name == "Goods Inward Status" || col.Name == "Inward Date" || col.Name == "Vouc Date" || col.Name == "Inv Date")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Tot Pro in Invoice")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdInwardList.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                            }
                        }
                    }
                    //   ExcelSheet.Protect(System.Configuration.ConfigurationManager.AppSettings["ExcelPassword"]);
                    ExcelObj.Visible = true;
                }
                else
                {
                    MessageBox.Show("No Record Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnExport.Enabled = true;
                btnExport.Focus();
            }
        }

        private void BtnExport_Enter(object sender, EventArgs e)
        {
            try
            {
                btnExport.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExport_Leave(object sender, EventArgs e)
        {
            try
            {
                btnExport.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdInwardList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdInwardList.Columns["Goods Inward Status"].Index)
                {
                    var cell = grdInwardList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdInwardList.Rows[e.RowIndex].Cells["Goods Inward Full Status"].Value.ToString();
                }
                if (e.ColumnIndex == grdInwardList.Columns["Overall Status"].Index)
                {
                    var cell = grdInwardList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdInwardList.Rows[e.RowIndex].Cells["Overall Full Status"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 1;
                udfnPurLocationAutocomplete();
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtStockLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtStockLocation.Focus();
                            txtStockLocation.SelectionStart = txtStockLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtStockLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtStockLocation.Focus();
                            txtStockLocation.SelectionStart = txtStockLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnPurLocationAutocomplete();
                                    DGV_FilterLocation.Visible = false;
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

        private void CmbEntryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbEntryType.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdCityList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
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

        private void GrdInwardList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdInwardList.Columns["S.No."].Frozen = true;
                grdInwardList.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdInwardList.Columns["Con"].Frozen = true;
                grdInwardList.Columns["Con"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdInwardList.Columns["Goods Inward Status"].Frozen = true;
                grdInwardList.Columns["Goods Inward Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdInwardList.Columns["Overall Status"].Frozen = true;
                grdInwardList.Columns["Overall Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardList.Columns["Inward No."].Frozen = true;
                //grdInwardList.Columns["Inward No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardList.Columns["Inward Date"].Frozen = true;
                //grdInwardList.Columns["Inward Date"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardList.Columns["Vouc No."].Frozen = true;
                //grdInwardList.Columns["Vouc No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardList.Columns["Vouc Date"].Frozen = true;
                //grdInwardList.Columns["Vouc Date"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardList.Columns["Supplier"].Frozen = true;
                //grdInwardList.Columns["Supplier"].DefaultCellStyle.BackColor = Color.AliceBlue;

                for (int i = 0; i < grdInwardList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdInwardList.Rows[i].Cells["Status ID"].Value) == "46") //entry completed
                    {
                        grdInwardList.Rows[i].Cells["Goods Inward Status"].Style.BackColor = Color.LimeGreen;
                        grdInwardList.Rows[i].Cells["Goods Inward Status"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grdInwardList.Rows[i].Cells["Status ID"].Value) == "45") //Draft
                    {
                        grdInwardList.Rows[i].Cells["Goods Inward Status"].Style.BackColor = Color.Tomato;
                        grdInwardList.Rows[i].Cells["Goods Inward Status"].Style.ForeColor = Color.White;
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
                grdInwardList.ClearSelection();
            }
        }

        private void LvProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductEvent();
                    cmbEntryType.Focus();
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
