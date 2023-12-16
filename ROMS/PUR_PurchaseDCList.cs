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
using ROMS.Model;

namespace ROMS
{
    public partial class PUR_PurchaseDCList : Form
    {
        public int varviewtype = 0;
        public int Varflag = 0; 
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpSupplier = new ToolTip();
        public PUR_PurchaseDCList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            { 
                MainForm.objPUR_PurchaseDC = new PUR_PurchaseDC();
                MainForm.objPUR_PurchaseDC.MdiParent = this.ParentForm;
                MainForm.objPUR_PurchaseDC.Show();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
        public void udfnList()
        {
            try
            {
                Varflag = 0;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                ep_PurchaseDC.Clear();
                grdPurchaseDCList.DataSource = null;
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
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(31, 0, Convert.ToInt32(lblschedule.Text), 0, 0, txtSupplier.Text.Trim(), 0, 0, 0, "", 0, 0, 0, 0, 0, 0, "","","",0);
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
                        ep_PurchaseDC.SetError(txtSupplier, "Invalid supplier.");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        Varflag = 1;
                    }
                    else
                    {
                        ep_PurchaseDC.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White;

                    }
                    //VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                }
                if (Varflag == 0)
                {
                    SPDataService objdserv = new SPDataService();
                    TRN_Purchase_DC objTRNG_Purchase_DC = new TRN_Purchase_DC();
                    objTRNG_Purchase_DC.ViewType = varviewtype;
                    objTRNG_Purchase_DC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRNG_Purchase_DC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNG_Purchase_DC.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                    objTRNG_Purchase_DC.paraScheduleID = Convert.ToInt32(lblschedule.Text);
                    objTRNG_Purchase_DC.paraFromDate = dpDcFromDate.Text;
                    objTRNG_Purchase_DC.paraToDate = dpdctodate.Text;
                    objTRNG_Purchase_DC.@paraStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                    objTRNG_Purchase_DC.paraIPAddress = MainForm.pbIpAddress;
                    objDs = objdserv.udfnPurchaseDCList(objTRNG_Purchase_DC);
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
                                grdPurchaseDCList.DataSource = objDs.Tables[0];
                                grdPurchaseDCList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdPurchaseDCList.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdPurchaseDCList.Columns["DC Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdPurchaseDCList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPurchaseDCList.Columns["Concern"].Width = 150;
                                grdPurchaseDCList.Columns["DC Date"].Width = 100;
                                grdPurchaseDCList.Columns["DC No."].Width = 100;
                                grdPurchaseDCList.Columns["Supplier"].Width = 300;
                                grdPurchaseDCList.Columns["Total Products"].Width = 100;
                                grdPurchaseDCList.Columns["GSTIN"].Width = 170;
                                grdPurchaseDCList.Columns["Status"].Width = 80;
                                grdPurchaseDCList.Columns["S.No."].Width = 50;
                                grdPurchaseDCList.Columns["ID"].Visible = false;
                                grdPurchaseDCList.Columns["DC_SPID"].Visible = false;
                                grdPurchaseDCList.Columns["Status ID"].Visible = false;
                                grdPurchaseDCList.Columns["COMID"].Visible = false;
                                grdPurchaseDCList.Columns["DC_SPSCID"].Visible = false;
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
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                    grdPurchaseDCList.DataSource = null;
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
            }
        }
        private void udfnEdit()
        {
            try
            {
                if (grdPurchaseDCList.SelectedRows.Count > 0)
                {
                    picLoader.Visible = true; int statusid = 0;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objPUR_PurchaseDC = new PUR_PurchaseDC();
                    MainForm.objPUR_PurchaseDC.varDCID = Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["ID"].Value.ToString());
                    //MainForm.objPUR_PurchaseDC.btnSave.Text = "Update";
                    MainForm.objPUR_PurchaseDC.pbScheduleid = Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["DC_SPSCID"].Value.ToString());
                    MainForm.objPUR_PurchaseDC.pbSupplierId = Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["DC_SPID"].Value.ToString());
                    if (Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["Status ID"].Value.ToString()) == 18)
                    {
                        MainForm.objPUR_PurchaseDC.editFlag = 1;
                    }
                    else if (Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["Status ID"].Value.ToString()) == 34)
                    {
                        MainForm.objPUR_PurchaseDC.editFlag = 2;
                    }
                    //MainForm.objPUR_PurchaseDC.txtRemark.Text = Convert.ToString(grdPurchaseDCList.SelectedRows[0].Cells["PO_Remarks"].Value.ToString());
                    MainForm.objPUR_PurchaseDC.MdiParent = this.ParentForm;
                    MainForm.objPUR_PurchaseDC.Show();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.SendToBack();
                picLoader.Visible = false;
            }
        } 
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdPurchaseDCList, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdPurchaseDCList.Columns)
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
               // DGV_SearchGrid.Columns["SI.No."].ReadOnly = true;
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
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = grdPurchaseDCList.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = grdPurchaseDCList.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    grdPurchaseDCList.SortOrder == SortOrder.Ascending)
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
            grdPurchaseDCList.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;

            DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
            DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

            DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseDCList.HorizontalScrollingOffset;
            DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
        }
        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdPurchaseDCList.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;

                if (totalWidth - grdPurchaseDCList.Width > grdPurchaseDCList.HorizontalScrollingOffset && grdPurchaseDCList.HorizontalScrollingOffset > 0)
                {
                    //offSetValue = offSetValue ;
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
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
        private void GrdCityList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PUR_PurchaseDCList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    tsbEdit_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.D))
                {
                    TsbDelete_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm objMainForm = new MainForm();
                    objMainForm.udfnCloseChildForms();
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
                    dpDcFromDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfncmbDropdown()
        {
            try
            {
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();

                int varconcerntype = 2;
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", " STS_ModuleID=8 OR STSID=0 ", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDcFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpDcFromDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDcFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpDcFromDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpDcFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpdctodate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Dpdctodate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpdctodate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Dpdctodate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpDcFromDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Dpdctodate_KeyDown(object sender, KeyEventArgs e)
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
        private void PUR_PurchaseDCList_Load(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                udfncmbDropdown();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dpDcFromDate.MinDate = MainForm.pbFYStartDate;
                dpDcFromDate.MaxDate = MainForm.pbCurrentDate;
                udfnDate();
                dpdctodate.MaxDate = MainForm.pbCurrentDate;
                 this.ActiveControl = cmbConcern;
                //txtSupplier.Focus();
                cmbStatus.SelectedValue = 18; //pending
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
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(9, 6, 0, "", "", 0, "",1);
                if (objd.Tables[0].Rows.Count != 0)
                {
                    DateTime vardate = DateTime.ParseExact(Convert.ToString(objd.Tables[0].Rows[0]["DATE"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                  //  dpDcFromDate.MaxDate = varmaxdate;
                    dpDcFromDate.Text = Convert.ToString(vardate);
                    dpdctodate.MinDate= vardate;
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
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
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

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(26, 0, 0, 0, 0, txtSupplier.Text, 0, 0, Convert.ToInt32(cmbConcern.SelectedValue), "", 0, 0, 0, 0, 0, 0,"",dpDcFromDate.Text,dpdctodate.Text,0);
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
                    cmbStatus.Focus();
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
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdPurchaseDCList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseDCList);
                objDser.CloseConnection();
                grdPurchaseDCList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (DGV_SearchGrid.IsCurrentCellDirty)
            //    {
            //        // Commit the changes immediately
            //        DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //    }
            //    //udfnGridSearchFilter();
            //    DataService objDser = new DataService();
            //    grdPurchaseDCList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseDCList);
            //    objDser.CloseConnection();
            //    grdPurchaseDCList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
            //    //grdCompanyList(sender,e); 
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdPurchaseDCList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseDCList);
                objDser.CloseConnection();
                grdPurchaseDCList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void GrdPurchaseDCList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdPurchaseDCList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdPurchaseDCList.Rows[i].Cells["Status ID"].Value) == "18")
                    {
                        grdPurchaseDCList.Rows[i].Cells["Status"].Style.BackColor = Color.Orange;
                        grdPurchaseDCList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grdPurchaseDCList.Rows[i].Cells["Status ID"].Value) == "34")
                    {
                        grdPurchaseDCList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdPurchaseDCList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdPurchaseDCList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdPurchaseDCList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
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
                grdPurchaseDCList.ClearSelection();
            }
        }
        private void GrdPurchaseDCList_DoubleClick(object sender, EventArgs e)
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
        private void GrdPurchaseDCList_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
                if (grdPurchaseDCList.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string varorginator = "Purchase DC Deletion", result = "";
                        varviewtype = 2;
                        int varUserID = 0;
                        TRN_Purchase_DC objTRNS_Purchase_DC = new TRN_Purchase_DC();
                        objTRNS_Purchase_DC.ViewType = varviewtype;
                        objTRNS_Purchase_DC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                        objTRNS_Purchase_DC.paraIPAddress = MainForm.pbIpAddress;
                        objTRNS_Purchase_DC.paraOriginator = varorginator;
                        objTRNS_Purchase_DC.paraDCID = Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["ID"].Value.ToString());
                        objTRNS_Purchase_DC.paraDeleteFlag = 0;
                        SPDataService objspdservice = new SPDataService();
                        result = objspdservice.udfnPurchaseDc(objTRNS_Purchase_DC);
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
                                    objTRNS_Purchase_DC.ViewType = varviewtype;
                                    objTRNS_Purchase_DC.paraUserID = varUserID;
                                    objTRNS_Purchase_DC.paraIPAddress = MainForm.pbIpAddress;
                                    objTRNS_Purchase_DC.paraOriginator = varorginator;
                                    objTRNS_Purchase_DC.paraDCID = Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["ID"].Value.ToString());
                                    objTRNS_Purchase_DC.paraDeleteFlag = 1;
                                    result = objspdservice.udfnPurchaseDc(objTRNS_Purchase_DC);
                                    if (result.Split('~')[0] == "3")
                                    {
                                        MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        varviewtype = 0;
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
        private void GrdPurchaseDCList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdPurchaseDCList.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdPurchaseDCList.Width > grdPurchaseDCList.HorizontalScrollingOffset && grdPurchaseDCList.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdPurchaseDCList);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdPurchaseDCList.ColumnCount > 0)
                {
                    grdPurchaseDCList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseDCList.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
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
                LV_Supplier.Visible = false;
                cmbStatus.BackColor = Color.LemonChiffon;
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
        private void DpDcFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpDcFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpdctodate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

    }
}
