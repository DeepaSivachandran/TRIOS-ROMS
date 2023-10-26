using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class PUR_PurchaseOrderList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        Boolean BlnSearchImageYN = false;
        public int Supplierpend = 0;
        public PUR_PurchaseOrderList()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder();
                MainForm.objPUR_PurchaseOrder.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void TsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder();
                MainForm.objPUR_PurchaseOrder.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseOrder.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            finally { picLoader.Visible = false; }
        }

        private void TsbEdit_Click(object sender, EventArgs e)
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
        private void PUR_PurchaseOrderList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    TsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    TsbEdit_Click(sender, e);
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
        private void GrdPurchaseorderlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex != -1)
                {
                    switch (grdPurchaseorderlist.Columns[e.ColumnIndex].Name)
                    {
                        case "clmView":
                            MainForm.objPUR_POIssuedDetails = new PUR_POIssuedDetails();
                            MainForm.objPUR_POIssuedDetails.varPOID = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString());
                            MainForm.objPUR_POIssuedDetails.varsts = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["STS"].Value.ToString());
                            MainForm.objPUR_POIssuedDetails.ShowDialog();
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void PUR_PurchaseOrderList_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = cmbConcern;
                udfnDropdownLoad();
                udfngridchanges();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnDropdownLoad()
        {
            SPDataService objdserv = new SPDataService();
            DataSet objDT = new DataSet();
            objDT = objdserv.udfnCompanyList(2, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
            objDataBind.BindComboBoxListSelected("DEF_Status", "STSID NOT IN (8,9) AND STS_ModuleID=4 OR STSID=0 ", "STS_Name,STSID", cmbstatus, "", "STS_Name", "STSID");
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=44 AND MSTID IN (135,136)", "MST_DisplayText,MSTID", cmbShow, "", "MST_DisplayText", "MSTID");
            objDataBind = null;
            cmbShow.SelectedIndex = 0;
        }


        private void GrdPurchaseorderlist_DoubleClick(object sender, EventArgs e)
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
                MainForm.objPUR_PurchaseOrder = new PUR_PurchaseOrder();
                MainForm.objPUR_PurchaseOrder.varPOID = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString());
                MainForm.objPUR_PurchaseOrder.lblPOCreateby.Text = Convert.ToString(grdPurchaseorderlist.SelectedRows[0].Cells["Created By"].Value.ToString());
                MainForm.objPUR_PurchaseOrder.lblpocreatedon.Text = Convert.ToString(grdPurchaseorderlist.SelectedRows[0].Cells["Created On"].Value.ToString());
                MainForm.objPUR_PurchaseOrder.VarStatusId = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["STS"].Value.ToString());
                MainForm.objPUR_PurchaseOrder.btnSave.Text = "Update";
                MainForm.objPUR_PurchaseOrder.varPOID = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString());
                MainForm.objPUR_PurchaseOrder.pbScheduleid = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_SPSCID"].Value.ToString());
                MainForm.objPUR_PurchaseOrder.pbSupplierId = Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_SPID"].Value.ToString());
                MainForm.objPUR_PurchaseOrder.txtRemark.Text = Convert.ToString(grdPurchaseorderlist.SelectedRows[0].Cells["PO_Remarks"].Value.ToString());
                MainForm.objPUR_PurchaseOrder.pbSupplierpend = Supplierpend;
                MainForm.objPUR_PurchaseOrder.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseOrder.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
            }
        }

        private void BtnViewProducts_Click(object sender, EventArgs e)
        {
            try
            {
                udfngridchanges();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        public void udfngridchanges()
        {

            try
            {
                if (Convert.ToInt32(cmbShow.SelectedValue) == 135)
                {
                    grpProFilter.Visible = false;
                    grdProDetails.Visible = false;
                    grdPurchaseorderlist.Visible = true;
                    DGV_SearchGrid.Visible = true;
                    grpSearchBy.Visible = false;
                    udfnPOEntryLoad();
                }
                else
                {
                    grpProFilter.Visible = true;
                    grdProDetails.Visible = true;
                    grdPurchaseorderlist.Visible = false;
                    DGV_SearchGrid.Visible = false;
                    grpSearchBy.Visible = true;
                    udfnProductDetails();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void CbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                udfnProductDetails();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void CbPoNo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                udfnProductDetails();
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
                    dpPlanDate.Focus();
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

        private void DpPlanDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpPlanDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpPlanDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpPlanDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpPlanDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dptoPlanDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DptoPlanDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dptoPlanDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DptoPlanDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dptoPlanDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DptoPlanDate_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
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
                    cmbstatus.Focus();
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

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {

            try
            {
                LV_Supplier.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(15, 0, 0, 0, 0, txtSupplier.Text, 0, 0, 0,"",0,0,0,0,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString()
                                    , objDs.Tables[0].Rows[i]["SupplierName"].ToString(), objDs.Tables[0].Rows[i]["ScheduleName"].ToString()};
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[3].Width = 0;
                                LV_Supplier.Columns[4].Width = 0;
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
            finally
            {
            }
        }


        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                //TxtSupplier_Leave(sender, e);
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
                    string varsuppliername = "";
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    varsuppliername = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedleCode.Text = selectedItem.SubItems[2].Text;
                    txtSupplier.Text = selectedItem.SubItems[3].Text;
                    lblscheduleName.Text = selectedItem.SubItems[4].Text; ;
                }
                cmbstatus.Focus();
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
        private void LV_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                    //TxtSupplier_Leave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbstatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_KeyDown(object sender, KeyEventArgs e)
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

        private void Cmbstatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmbstatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbstatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbstatus.Select(int.MaxValue, 0)));
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

        private void CmbShow_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnViewProducts.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbShow_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbShow.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbShow_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbShow_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbShow.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbShow.Select(int.MaxValue, 0)));
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
                udfnPOEntryLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        public void udfnPOEntryLoad()
        {
            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 
                grdPurchaseorderlist.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnPOEntry(1, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedleCode.Text), Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, Convert.ToInt32(lblGroupId.Text), Convert.ToInt32(lblSubGroupId.Text), dpPlanDate.Text, dptoPlanDate.Text, 0, Convert.ToInt32(cmbstatus.SelectedValue));
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
                            grdPurchaseorderlist.DataSource = objDs.Tables[0];
                            grdPurchaseorderlist.Columns["clmView"].Visible = true;
                            grdPurchaseorderlist.Columns["clmView"].DisplayIndex = objDs.Tables[0].Columns.Count;
                            grdPurchaseorderlist.Columns["clmView"].Width = 110;
                            grdPurchaseorderlist.Columns["S.No."].Width = 50;
                            grdPurchaseorderlist.Columns["Concern"].Width = 80;
                            grdPurchaseorderlist.Columns["PO.No"].Width = 100;
                            grdPurchaseorderlist.Columns["PO Date"].Width = 100;
                            grdPurchaseorderlist.Columns["Supplier"].Width = 300;
                            grdPurchaseorderlist.Columns["City"].Width = 100;
                            grdPurchaseorderlist.Columns["GSTIN"].Width = 120;
                            grdPurchaseorderlist.Columns["Total Products"].Width = 100;
                            grdPurchaseorderlist.Columns["Total Qty"].Width = 100;
                            grdPurchaseorderlist.Columns["Turn Around Time"].Width = 120;
                            grdPurchaseorderlist.Columns["Created By"].Width = 100;
                            grdPurchaseorderlist.Columns["Created On"].Width = 100;
                            grdPurchaseorderlist.Columns["Mode of Issue"].Width = 100;
                            grdPurchaseorderlist.Columns["Issue Date"].Width = 100;
                            grdPurchaseorderlist.Columns["Issued By"].Width = 100;
                            grdPurchaseorderlist.Columns["Status"].Width = 100;
                            grdPurchaseorderlist.Columns["STS"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_ID"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_SPSCID"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_SPID"].Visible = false;
                            grdPurchaseorderlist.Columns["po_stsid"].Visible = false;
                            grdPurchaseorderlist.Columns["PO_Remarks"].Visible = false;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                            grdPurchaseorderlist.Columns["clmView"].Visible = false;
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            lblPartial.Text = objDs.Tables[1].Rows[0]["PartialCount"].ToString().Replace("''", "'");
                            lblIssued.Text = objDs.Tables[1].Rows[0]["IssuedCount"].ToString().Replace("''", "'");
                            lblNotissued.Text = objDs.Tables[1].Rows[0]["NotIssuedCount"].ToString().Replace("''", "'");
                            lblDelayed.Text = objDs.Tables[1].Rows[0]["DelayedCount"].ToString().Replace("''", "'");
                            lblTotal.Text = Convert.ToString(Convert.ToInt32(lblPartial.Text) + Convert.ToInt32(lblIssued.Text) + Convert.ToInt32(lblNotissued.Text) + Convert.ToInt32(lblDelayed.Text));
                        }
                        if (objDs.Tables[2].Rows.Count != 0)
                        {
                            if (Convert.ToInt32(objDs.Tables[2].Rows[0]["SupplierPend"].ToString().Replace("''", "'")) != 0)
                            {
                                Supplierpend = Convert.ToInt32(objDs.Tables[2].Rows[0]["SupplierPend"].ToString().Replace("''", "'"));
                            }
                            else
                            {
                                Supplierpend = 0;
                            }
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                        grdPurchaseorderlist.Columns["clmView"].Visible = false;
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    grdPurchaseorderlist.Columns["clmView"].Visible = false;
                }

                udfnSearchGridHead();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
            }
        }
        private void TxtProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvGroup.Items.Count == 0 || txtProductGroup.Text == "")
                    {
                        txtProductGroup.Focus();
                        lvGroup.Visible = false;
                    }
                    else
                    {
                        lvGroup.Focus();
                    }
                    if (lvGroup.Items.Count > 0)
                    {
                        lvGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.White;
                if (txtProductGroup.Text.Trim() == "") { lblGroupId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtProductGroup.Text, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvGroup.Columns[2].Width = 200;
                                    lvGroup.Columns[0].Width = 200;
                                    lvGroup.Items.Add(objList);
                                }
                                lvGroup.Visible = true;
                            }
                            else
                            {
                                lvGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvGroup.Visible = false;
                    }
                }
                else
                {
                    lvGroup.Visible = false;
                    lvGroup.Items.Clear();
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

        private void TxtProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Visible = false;
                txtProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSubGroup.Items.Count == 0 || txtProductSubGroup.Text == "")
                    {
                        txtProductSubGroup.Focus();
                        lvSubGroup.Visible = false;
                    }
                    else
                    {
                        lvSubGroup.Focus();
                    }
                    if (lvSubGroup.Items.Count > 0)
                    {
                        lvSubGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnProductView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.White;
                if (txtProductSubGroup.Text.Trim() == "") { lblSubGroupId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGroupevent();
                txtProductSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGroupevent();
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGroupevent()
        {
            try
            {
                if (txtProductGroup.Text != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    lblGroupId.Text = selectedItem.SubItems[1].Text;
                    txtProductGroup.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvGroup.Visible = false;
            }
        }

        private void TxtProductSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupId.Text), 0, txtProductSubGroup.Text, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvSubGroup.Columns[2].Width = 200;
                                    lvSubGroup.Columns[0].Width = 200;
                                    lvSubGroup.Items.Add(objList);
                                }
                                lvSubGroup.Visible = true;
                            }
                            else
                            {
                                lvSubGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvSubGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvSubGroup.Visible = false;
                    }
                }
                else
                {
                    lvSubGroup.Visible = false;
                    lvSubGroup.Items.Clear();
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

        private void LvSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSubGroupevent();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSubGroupevent();
                    btnProductView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSubGroupevent()
        {
            try
            {
                if (txtProductSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    lblSubGroupId.Text = selectedItem.SubItems[1].Text;
                    txtProductSubGroup.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSubGroup.Visible = false;
            }
        }

        private void TxtProductSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdProDetails.DataSource as DataTable).DefaultView.RowFilter = "([Product]) LIKE '%" + txtProductSearch.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductView_Click(object sender, EventArgs e)
        {
            try
            {
                udfnProductDetails();
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
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 
                grdProDetails.DataSource = null;
                //lblGroupId.Text = "0"; lblSubGroupId.Text = "0";
                //txtProductGroup.Text = "";txtProductSubGroup.Text = "";
                int varsupplier = 0, varpono = 0;
                if (cbPoNo.Checked == true)
                {
                    varpono = 1;
                }
                if (cbSupplier.Checked == true)
                {
                    varsupplier = 1;
                }
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnPOEntry(0, 0, 0, 0, 0, varsupplier, varpono, Convert.ToInt32(lblGroupId.Text), Convert.ToInt32(lblSubGroupId.Text), "", "", 0, 0);
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
                            grdProDetails.DataSource = objDs.Tables[0];
                            grdProDetails.Columns["S.No."].Width = 50;
                            grdProDetails.Columns["P.I Code"].Width = 100;
                            grdProDetails.Columns["Product"].Width = 250;
                            grdProDetails.Columns["Unit"].Width = 80;
                            grdProDetails.Columns["Quantity"].Width = 80;
                            if (cbSupplier.Checked == true)
                            {
                                grdProDetails.Columns["Supplier"].Width = 300;
                                grdProDetails.Columns["GSTIN"].Width = 150;
                            }
                            if (cbPoNo.Checked == true)
                            {
                                grdProDetails.Columns["PO No."].Width = 80;
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
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
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
            }
        }


        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                //if (DGV_SearchGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType.Name == "Image")
                //    return;
                if ((e.ColumnIndex == 0 || e.ColumnIndex == 1))  //|| e.ColumnIndex == IntDispIndex /*If not our desired columns*/
                    return;

                if (e.Value != DBNull.Value && e.Value == "")  /*If value is null*/
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
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdPurchaseorderlist.ColumnCount > 0)
                {
                    grdPurchaseorderlist.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseorderlist.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdPurchaseorderlist.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseorderlist);
                objDser.CloseConnection();
                grdPurchaseorderlist.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
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
                //udfnGridSearchHeading(grdPurchaseorderlist, DGV_SearchGrid);
                //DGV_SearchGrid.Columns.Clear();
                //List<int> visibleColumns = new List<int>();
                //foreach (DataGridViewColumn col in grdPurchaseorderlist.Columns)
                //{
                //    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                //    visibleColumns.Add(col.Index);
                //}
                //int rowIndex = 0;
                //DGV_SearchGrid.Rows.Clear();
                //DGV_SearchGrid.Rows.Add();
                //for (int i = 0; i < visibleColumns.Count; i++)
                //{
                //    DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                //}
                //DGV_SearchGrid.Columns["S.No."].ReadOnly = true; 
                //DGV_SearchGrid.Columns["clmView"].ReadOnly = true;
                udfnGridSearchHeading(grdPurchaseorderlist, DGV_SearchGrid);
                if (DGV_SearchGrid.ColumnCount > 1)
                {
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    DGV_SearchGrid.Columns["clmView"].ReadOnly = true;
                }
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
                int ColIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                BlnSearchImageYN = false;
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                    if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                    {
                        //dgv2.Rows[rowIndex].Visible = false;
                        BlnSearchImageYN = true;
                        ColIndex = i;
                        dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                        dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                        ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                    }
                    else
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = e.ColumnIndex + 2;
            if (e.ColumnIndex == 0)
            {
                i = e.ColumnIndex;
            }
            DataGridViewColumn newColumn = grdPurchaseorderlist.Columns[i];
            DataGridViewColumn oldColumn = grdPurchaseorderlist.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    grdPurchaseorderlist.SortOrder == SortOrder.Ascending)
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
            grdPurchaseorderlist.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
            DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
            DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
            DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseorderlist.HorizontalScrollingOffset;
            DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int cl = grdPurchaseorderlist.ColumnCount;
                int cls = DGV_SearchGrid.ColumnCount;
                int offSetValue = grdPurchaseorderlist.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;

                if (totalWidth - grdPurchaseorderlist.Width > grdPurchaseorderlist.HorizontalScrollingOffset && grdPurchaseorderlist.HorizontalScrollingOffset > 0)
                {
                    //offSetValue = offSetValue ;
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdPurchaseorderlist);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnscrollVisible(DataGridView DGV, DataGridView grdGroupList)
        {
            try
            {
                var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
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
                grdPurchaseorderlist.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseorderlist);
                objDser.CloseConnection();
                grdPurchaseorderlist.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseorderlist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
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

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                udfndelete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfndelete()
        {
            try
            {
                if (grdPurchaseorderlist.SelectedRows.Count > 0)
                {
                    string result = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    { 
                        DataTable objPurchaseOrder = new DataTable();
                        objPurchaseOrder.TableName = "TRN_PO_Product";
                        objPurchaseOrder.Columns.Add("POPR_PRID", typeof(int));
                        objPurchaseOrder.Columns.Add("POPR_MSQ", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_ReorderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_OrderQty", typeof(float));
                        objPurchaseOrder.Columns.Add("POPR_Flag", typeof(int));
                        SPDataService objspdservice = new SPDataService();
                        result = "";
                        result = objspdservice.udfnPurchaseEntry(2, Convert.ToInt32(grdPurchaseorderlist.SelectedRows[0].Cells["PO_ID"].Value.ToString()), 0,
                                "", 0, 0, "", "", "","", objPurchaseOrder, "", "", "","",0);
                        objspdservice.CloseConnection();
                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            udfnPOEntryLoad(); 
                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
