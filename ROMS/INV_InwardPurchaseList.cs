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
    public partial class INV_InwardPurchaseList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        string varUserID = "0";
        int varPRID = 0, Varflag=0, varviewtype=0, varDeleteFlag=0;
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
                MainForm.objINV_InwardPurchase.varConcernId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GIP_COMID"].Value);
                MainForm.objINV_InwardPurchase.varLocationId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["GIP_SLID"].Value);
                MainForm.objINV_InwardPurchase.varSupplierId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["SPID"].Value);
                MainForm.objINV_InwardPurchase.varScheduleId = Convert.ToInt32(grdInwardList.SelectedRows[0].Cells["SPSCID"].Value);
                MainForm.objINV_InwardPurchase.varEditFlag = 1;

                MainForm.objINV_InwardPurchase.txtConcern.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Concern"].Value);
                MainForm.objINV_InwardPurchase.txtStockLocation.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Location"].Value);
                MainForm.objINV_InwardPurchase.dpInwardDate.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Inward Date"].Value);
                MainForm.objINV_InwardPurchase.txtInwardNo.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Inward No."].Value);
               // MainForm.objINV_InwardPurchase.dpInvoiceDate.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Invoice Date"].Value);
               // MainForm.objINV_InwardPurchase.txtInvoiceNo.Text = Convert.ToString(grdInwardList.SelectedRows[0].Cells["Invoice No."].Value);
                //MainForm.objINV_InwardPurchase.dpVoucherDate.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Voucher Date"].Value);
                //MainForm.objINV_InwardPurchase.txtVoucherNo.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Voucher No."].Value);
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
        public void udfnCmbConcern()
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
                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                udfnList();
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
                    txtStockLocation.Focus();
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
                lvProduct.Visible = false;
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
                    txtProductName.Focus();
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
                lvStockLocation.Visible = false;
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
                    if (lvProduct.Items.Count == 0 || txtProductName.Text == "")
                    {
                        txtProductName.Focus();
                        lvProduct.Visible = false;
                    }
                    else
                    {
                        lvProduct.Focus();
                    }
                    if (lvProduct.Items.Count > 0)
                    {
                        lvProduct.Items[0].Selected = true;
                    }
                }
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
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.White;
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
        public void udfnList()
        {
            try
            {
                //dtDefaultGrid = null;
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
                //if (txtSupplier.Text == "")
                //{
                //    varSupplierId = "0";
                //    lblschedule.Text = "0";
                //}
                //else
                //{
                //    string[] values = new string[0];
                //    MR_Supplier objMR_Supplier = new MR_Supplier();
                //    objMR_Supplier.ViewType = 31;
                //    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                //    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                //    DataSet objDsSupplierId = new DataSet();
                //    SPDataService objDserv = new SPDataService();
                //    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
                //    objDserv.CloseConnection();
                //    if (objDsSupplierId != null)
                //    {
                //        if (objDsSupplierId.Tables.Count > 0)
                //        {
                //            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                //            {
                //                varSupplierId = Convert.ToString(objDsSupplierId.Tables[0].Rows[0][0]);
                //                values = Convert.ToString(varSupplierId).Split(',');
                //            }
                //        }
                //    }
                //    if (values[0] == "-1")
                //    {
                //        ep_PurchaseDC.SetError(txtSupplier, "Invalid supplier.");
                //        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpSupplier.ShowAlways = true;
                //        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                //        lblSupplierCode.Text = "0";
                //        lblschedule.Text = "0";
                //        Varflag = 1;
                //    }
                //    else
                //    {
                //        ep_PurchaseDC.Clear();
                //        lblSupplierCode.Text = values[0];
                //        lblschedule.Text = values[1];
                //        txtSupplier.BackColor = Color.White;

                //    }
                //    //VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                //}
                if (Varflag == 0)
                {
                    btnView.Enabled = false;
                    varviewtype = 1;
                    SPDataService objdserv = new SPDataService();
                    TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                    objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                    objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_GoodsInward_Purchase.paraSLID = Convert.ToInt32(lblStockLocationCode.Text);
                    objTRN_GoodsInward_Purchase.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_GoodsInward_Purchase.paraProductId = Convert.ToInt32(varPRID);
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
                                //grdInwardList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //grdInwardList.Columns["Inward No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //grdInwardList.Columns["Inward Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //grdInwardList.Columns["Total Products in Invoice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                //grdInwardList.Columns["Concern"].Width = 150;
                                //grdInwardList.Columns["Voucher Date"].Width = 100;
                                //grdInwardList.Columns["Voucher No."].Width = 100;
                                //grdInwardList.Columns["Supplier"].Width = 300;
                                //grdInwardList.Columns["Total Products in Invoice"].Width = 100;
                                //grdInwardList.Columns["Location"].Width = 130;
                                /////   grdInwardQueueList.Columns["Created By"].Width = 110;
                                //grdInwardList.Columns["Created On"].Width = 140;
                                //grdInwardList.Columns["GSTIN"].Width = 190;
                                //// grdInwardQueueList.Columns["Status"].Width = 100;
                                //grdInwardList.Columns["S.No."].Width = 80;
                                //grdInwardList.Columns["GRNID"].Visible = false;
                                //grdInwardList.Columns["SPID"].Visible = false;
                                ////  grdInwardQueueList.Columns["Status ID"].Visible = false;
                                //grdInwardList.Columns["SPSCID"].Visible = false;
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
                    //if (lblNoRecordsFound.Visible == true)
                    //{
                    //    dtDefaultGrid = objDs.Tables[0];
                    //    udfnDefaultSearchGrid();
                    //}
                    //  else { DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; }
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
                btnView.Enabled = true;
            }
        }
        private void udfnSearchGridHead()
        {
            try
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
                DGV_SearchGrid.Columns["SI.No."].ReadOnly = true;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
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
                            int varUserID = 0;
                            TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                            objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                            objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                            objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                            objTRN_GoodsInward_Purchase.paraOriginator = varorginator;
                            objTRN_GoodsInward_Purchase.paraHostName = MainForm.pbHostName;
                            objTRN_GoodsInward_Purchase.paraDeleteFlag = 0;
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
            if (e.KeyCode == Keys.Enter)
            {
                tsbEdit_Click(sender, e);
            }
            if (e.KeyCode == Keys.Delete)
            {
                TsbDelete_Click(sender, e);
            }
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
                    ListViewItem selectedItem = lvStockLocation.SelectedItems[0];
                    txtStockLocation.Text = selectedItem.SubItems[0].Text;
                    lblStockLocationCode.Text = selectedItem.SubItems[2].Text;
                    lvStockLocation.Visible = false;
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
            try
            {
                udfnPurLocationAutocomplete();
                txtProductName.Focus();
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
                    txtProductName.Focus();
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
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0)
                {
                    objDs = objspdservice.udfnStockLocationList(27, Convert.ToInt32(cmbConcern.SelectedValue), 0, 5, txtStockLocation.Text.Trim(), 0, 0, 0, dpFromDate.Text, dpToDate.Text);
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
                                    lvStockLocation.Items.Add(objList);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
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

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvProduct.Items.Clear();
                if (txtProductName.Text.Length > 0)
                {
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 53;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.paraLocationId = Convert.ToInt32(lblStockLocationCode.Text);
                    objMR_Product.paraProductName = txtProductName.Text;
                    objMR_Product.ParaFromDate = dpFromDate.Text;
                    objMR_Product.ParaToDate = dpToDate.Text;
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
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvProduct.Items.Add(objList);
                                }
                                lvProduct.Visible = true;
                                lvProduct.BringToFront();
                                lvProduct.Columns[0].Width = 90;
                                lvProduct.Columns[1].Width = 200;
                                lvProduct.Columns[2].Width = 230;
                                lvProduct.Columns[3].Width = 0;
                            }
                            else
                            {
                                lvProduct.Visible = false;
                            }
                        }
                        else
                        {
                            lvProduct.Visible = false;
                        }
                    }
                    else
                    {
                        lvProduct.Visible = false;
                    }
                }
                else
                {
                    lvProduct.Visible = false;
                    lvProduct.Items.Clear();
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
                    ListViewItem selectedItem = lvProduct.SelectedItems[0];
                    varPRID = Convert.ToInt32(selectedItem.SubItems[3].Text);
                    txtProductName.Text = selectedItem.SubItems[1].Text;
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
                lvProduct.Visible = false;
            }
        }
        private void LvProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                lvProduct.BringToFront();
                udfnProductEvent();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
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

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

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
                for (int i = 0; i < grdInwardList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdInwardList.Rows[i].Cells["Status ID"].Value) == "46") //entry completed
                    {
                        grdInwardList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdInwardList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grdInwardList.Rows[i].Cells["Status ID"].Value) == "45") //Draft
                    {
                        grdInwardList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdInwardList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                    btnView.Focus();
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
