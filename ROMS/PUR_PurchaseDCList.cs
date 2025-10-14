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
using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace ROMS
{
    public partial class PUR_PurchaseDCList : Form
    {
        public int varviewtype = 0;
        public int Varflag = 0, varDCPrintFlag = 0; 
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        ToolTip tpSupplier = new ToolTip();
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public PUR_PurchaseDCList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {

            if (privilege.Contains("2") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
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
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                Varflag = 0;
                varviewtype = 0;
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
                                grdPurchaseDCList.Columns["Pur Dc Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdPurchaseDCList.Columns["DC Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdPurchaseDCList.Columns["Tot Pro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPurchaseDCList.Columns["Concern"].Width = 70;
                                grdPurchaseDCList.Columns["DC Date"].Width = 90;
                                grdPurchaseDCList.Columns["DC No."].Width = 75;
                                grdPurchaseDCList.Columns["Supplier"].Width = 300;
                                grdPurchaseDCList.Columns["Tot Pro"].Width = 100;
                                grdPurchaseDCList.Columns["Created By"].Width = 200;
                                grdPurchaseDCList.Columns["GSTIN"].Width = 140;
                                //grdPurchaseDCList.Columns["Status"].Width = 140;
                                grdPurchaseDCList.Columns["clmPrint"].Width = 50;
                                grdPurchaseDCList.Columns["Pur Dc Status"].Width = 150;
                                grdPurchaseDCList.Columns["Overall Status"].Width = 150;
                                grdPurchaseDCList.Columns["S.No."].Width = 50;
                                grdPurchaseDCList.Columns["ID"].Visible = false;
                                grdPurchaseDCList.Columns["DC_SPID"].Visible = false;
                                grdPurchaseDCList.Columns["Status ID"].Visible = false;
                                grdPurchaseDCList.Columns["COMID"].Visible = false;
                                grdPurchaseDCList.Columns["DC_SPSCID"].Visible = false;
                                grdPurchaseDCList.Columns["Overall Full Status"].Visible = false;
                                grdPurchaseDCList.Columns["Pur Dc Full Status"].Visible = false;
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
                    else
                    {
                        DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; udfnGridAccess();
                    }
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
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["Concern"].Width = 150;
                DGV_SearchGrid.Columns["DC Date"].Width = 100;
                DGV_SearchGrid.Columns["DC No."].Width = 100;
                DGV_SearchGrid.Columns["Supplier"].Width = 300;
                DGV_SearchGrid.Columns["Tot Pro"].Width = 100;
                DGV_SearchGrid.Columns["GSTIN"].Width = 170;
                DGV_SearchGrid.Columns["Pur Dc Status"].Width = 100;
                DGV_SearchGrid.Columns["S.No."].Width = 80;
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["DC_SPID"].Visible = false;
                DGV_SearchGrid.Columns["Status ID"].Visible = false;
                DGV_SearchGrid.Columns["COMID"].Visible = false;
                DGV_SearchGrid.Columns["Overall Full Status"].Visible = false;
                DGV_SearchGrid.Columns["Pur Dc Full Status"].Visible = false;
                DGV_SearchGrid.Columns["DC_SPSCID"].Visible = false; DGV_SearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnEdit()
        {
            if (privilege.Contains("3") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
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
                        MainForm.objPUR_PurchaseDC.lblStatus.Text = Convert.ToString(grdPurchaseDCList.SelectedRows[0].Cells["Pur Dc Full Status"].Value.ToString());
                        if (Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["Status ID"].Value.ToString()) == 18)
                        {
                            MainForm.objPUR_PurchaseDC.editFlag = 1;
                        }
                        else //else if (Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["Status ID"].Value.ToString()) == 34)
                        {
                            // if (Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["Status ID"].Value.ToString()) == 34)
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
        } 
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
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
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
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
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
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
                    if (newColumn.GetType() != typeof(DataGridViewImageColumn))
                    {
                        grdPurchaseDCList.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                        DGV_SearchGrid.HorizontalScrollingOffset = grdPurchaseDCList.HorizontalScrollingOffset;
                        DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
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
                    if (Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["Status ID"].Value) == 18)
                    {
                        TsbDelete_Click(sender, e);
                    }
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
                MenuCode = 104;
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                udfncmbDropdown();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                dpDcFromDate.MinDate = MainForm.pbFYStartDate;
                dpDcFromDate.MaxDate = MainForm.pbCurrentDate;
                udfnDate();
                dpdctodate.MaxDate = MainForm.pbCurrentDate;
                 this.ActiveControl = cmbConcern;
                //txtSupplier.Focus();
                // cmbStatus.SelectedValue = 18; //pending
                
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=62 AND MSTID IN (196,195)", "MST_DisplayText,MSTID", cmbShow, "", "MST_DisplayText", "MSTID");
                cmbShow.SelectedValue = 196;
                if (Convert.ToInt32(cmbShow.SelectedValue) == 196)
                {
                    udfnList();
                }
                else
                {
                    udfnProductList();
                }
                udfnGeneralSettingsList(); 
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(MenuCode);
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions;
                tsbNew.Visible = privilege.Contains("2");
                tssNew.Visible = privilege.Contains("2");
                tsbEdit.Visible = privilege.Contains("3");
                tssEdit.Visible = privilege.Contains("3");
                tsbDelete.Visible = privilege.Contains("4");
                btnPrint.Visible = privilege.Contains("5");
                btnExport.Visible = privilege.Contains("6");
                grdPurchaseDCList.Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 45 && sp.EditAccess.Split(',').Contains("9")); 
                udfnGridAccess();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridAccess()
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                { 
                    grdPurchaseDCList.Columns["clmPrint"].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 45 && sp.EditAccess.Split(',').Contains("9"));  
                    DGV_SearchGrid.Columns[0].Visible = SpecialPermissions.Any(sp => sp.MUP_Code == 45 && sp.EditAccess.Split(',').Contains("9")); 
                }
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
                objMR_Master.paraID = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Master.paraFlag = 1;
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(objMR_Master);
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
        public void udfnGeneralSettingsList()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objdserv.udfnGeneralSettingList(0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            varDCPrintFlag = Convert.ToInt32(objDs.Tables[0].Rows[0]["GS_DCPrint"]);
                        }
                    }
                }
                if(varDCPrintFlag == 0)
                {
                    grdPurchaseDCList.Columns["clmPrint"].Visible = false;
                    DGV_SearchGrid.Columns["clmPrint"].Visible = false;
                }
                else
                {
                    grdPurchaseDCList.Columns["clmPrint"].Visible = true;
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
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.ParaFromDate = dpDcFromDate.Text;
                    objMR_Supplier.ParaToDate = dpdctodate.Text;
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

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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
                grdPurchaseDCList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPurchaseDCList);
                objDser.CloseConnection();
                grdPurchaseDCList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                grdPurchaseDCList.Columns["clmPrint"].Frozen = true;
                grdPurchaseDCList.Columns["clmPrint"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseDCList.Columns["S.No."].Frozen = true;
                grdPurchaseDCList.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseDCList.Columns["Pur Dc Status"].Frozen = true;
                grdPurchaseDCList.Columns["Pur Dc Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseDCList.Columns["Overall Status"].Frozen = true;
                grdPurchaseDCList.Columns["Concern"].Frozen = true;
                grdPurchaseDCList.Columns["Overall Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseDCList.Columns["DC Date"].Frozen = true;
                //grdPurchaseDCList.Columns["Concern"].Frozen = true;
                //grdPurchaseDCList.Columns["DC Date"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdPurchaseDCList.Columns["Concern"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseDCList.Columns["DC No."].Frozen = true;
                //grdPurchaseDCList.Columns["DC No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdPurchaseDCList.Columns["Supplier"].Frozen = true;
                //grdPurchaseDCList.Columns["Supplier"].DefaultCellStyle.BackColor = Color.AliceBlue;

                for (int i = 0; i < grdPurchaseDCList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdPurchaseDCList.Rows[i].Cells["Status ID"].Value) == "18")
                    {
                        //grdPurchaseDCList.Rows[i].Cells["Status"].Style.BackColor = Color.Orange;
                        //grdPurchaseDCList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                        grdPurchaseDCList.Rows[i].Cells["clmPrint"].ReadOnly = true;
                        DataGridViewTextBoxCell c = new DataGridViewTextBoxCell();
                        c.Value = "";
                        grdPurchaseDCList.Rows[i].Cells["clmPrint"] = c;
                        c.ReadOnly = true;
                        grdPurchaseDCList.Rows[i].Cells["Pur Dc Status"].Style.BackColor = Color.Orange;
                        grdPurchaseDCList.Rows[i].Cells["Pur Dc Status"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grdPurchaseDCList.Rows[i].Cells["Status ID"].Value) == "34")
                    {
                        grdPurchaseDCList.Rows[i].Cells["Pur Dc Status"].Style.BackColor = Color.LimeGreen;
                        grdPurchaseDCList.Rows[i].Cells["Pur Dc Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdPurchaseDCList.Rows[i].Cells["Pur Dc Status"].Style.BackColor = Color.Tomato;
                        grdPurchaseDCList.Rows[i].Cells["Pur Dc Status"].Style.ForeColor = Color.White;
                    }
                }

                grdPurchaseDCList.Columns["clmPrint"].Resizable = DataGridViewTriState.False;
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
                    if (Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["Status ID"].Value) == 18)
                    {
                        TsbDelete_Click(sender, e);
                    }
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
                                    objspdservice.CloseConnection();
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
                if (lblNoRecordsFound.Visible == false)
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
                    cmbShow.Focus();
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
                if (Convert.ToInt32(cmbShow.SelectedValue) == 195)
                {
                    grdPurchaseDCList.Visible = false;
                    DGV_SearchGrid.Visible = false;
                    grdProDetails.Visible = true;
                    DGV_ProdSearchGrid.Visible = true;
                    //btnPrint.Visible = true;
                    RPTViewer.Visible = false;
                    RPTViewer.SendToBack();
                    udfnProductList();
                }
                else
                {
                    grdPurchaseDCList.Visible = true;
                    DGV_SearchGrid.Visible = true;
                    grdProDetails.Visible = false;
                    DGV_ProdSearchGrid.Visible = false;
                    //btnPrint.Visible = false;
                    RPTViewer.Visible = false;
                    RPTViewer.SendToBack();
                    udfnList();
                }
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
        public void udfnDeleteHide()
        {
            try
            {
                if (privilege.Contains("4") || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
                {
                    if (Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["Status ID"].Value) != 18)
                    {
                        tsbDelete.Visible = false; 
                    }
                    else
                    {
                        tsbDelete.Visible = true; 
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurchaseDCList_SelectionChanged(object sender, EventArgs e)
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

        private void CmbShow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToInt32(cmbShow.SelectedValue) == 188)
                //{
                //    cmbOrderBy.Enabled = false;
                //    //btnPrint.Visible = false;
                //}
                //else
                //{
                //    cmbOrderBy.Enabled = true;
                //    //btnPrint.Visible = true;
                //}              
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_ProdSearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdProDetails.DataSource = objDser.udfnGridSearchFilter(DGV_ProdSearchGrid, grdProDetails);
                objDser.CloseConnection();
                grdProDetails.HorizontalScrollingOffset = DGV_ProdSearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex)
            {
                objError = new DataError(); objError.WriteFile(ex);
            }
        }

        private void DGV_ProdSearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                DGV_ProdSearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_ProdSearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdProDetails.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdProDetails.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdProDetails.SortOrder == SortOrder.Ascending)
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
                    if (newColumn.GetType() != typeof(DataGridViewImageColumn))
                    {
                        grdProDetails.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                        DGV_SearchGrid.HorizontalScrollingOffset = grdProDetails.HorizontalScrollingOffset;
                        DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_ProdSearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdProDetails.ColumnCount > 0)
                {
                    grdProDetails.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_ProdSearchGrid.HorizontalScrollingOffset = grdProDetails.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_ProdSearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_ProdSearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_ProdSearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdProDetails.DataSource = objDser.udfnGridSearchFilter(DGV_ProdSearchGrid, grdProDetails);
                objDser.CloseConnection();
                grdProDetails.HorizontalScrollingOffset = DGV_ProdSearchGrid.HorizontalScrollingOffset;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_ProdSearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdProDetails.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_ProdSearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdProDetails.Width > grdProDetails.HorizontalScrollingOffset && grdProDetails.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_ProdSearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_ProdSearchGrid.Invalidate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdProDetails_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdProDetails.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_ProdSearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdProDetails.Width > grdProDetails.HorizontalScrollingOffset && grdProDetails.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_ProdSearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_ProdSearchGrid.Invalidate();
                    udfnProductscrollVisible(DGV_ProdSearchGrid, grdProDetails);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnProductscrollVisible(DataGridView DGV, DataGridView grdProDetails)
        {
            try
            {
                var vScrollbar = grdProDetails.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_ProdSearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_ProdSearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_ProdSearchGrid.Rows[rowIndex].Cells[i].Value = "";
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
        private void GrdProDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdProDetails.ClearSelection();
                for (int i = 0; i < grdProDetails.Rows.Count; i++)
                {
                    if (Convert.ToString(grdProDetails.Rows[i].Cells["Status ID"].Value) == "18")
                    {
                        grdProDetails.Rows[i].Cells["Status"].Style.BackColor = Color.Orange;
                        grdProDetails.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToString(grdProDetails.Rows[i].Cells["Status ID"].Value) == "34")
                    {
                        grdProDetails.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdProDetails.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        grdProDetails.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                        grdProDetails.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnGridProductSearchHeading(DataGridView dgv1, DataGridView dgv2)
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
        private void udfnProductSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridProductSearchHeading(grdProDetails, DGV_ProdSearchGrid);
                    DGV_ProdSearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdProDetails.Columns)
                    {
                        DGV_ProdSearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_ProdSearchGrid.Rows.Clear();
                    DGV_ProdSearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        DGV_ProdSearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    //DGV_ProdSearchGrid.Columns["Type"].ReadOnly = false;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        public void udfnProductList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV_ProdSearchGrid.DataSource = null;
                Varflag = 0;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                btnView.Enabled = true;
                varviewtype = 3;
                grdProDetails.DataSource = null;
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                }             
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                TRN_Purchase_DC objTRNG_Purchase_DC = new TRN_Purchase_DC();
                objTRNG_Purchase_DC.ViewType = varviewtype;
                objTRNG_Purchase_DC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRNG_Purchase_DC.paraFromDate = Convert.ToString(dpDcFromDate.Text);
                objTRNG_Purchase_DC.paraToDate = Convert.ToString(dpdctodate.Text);
                objTRNG_Purchase_DC.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                objTRNG_Purchase_DC.paraStatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                objTRNG_Purchase_DC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
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
                            grdProDetails.DataSource = objDs.Tables[0];
                            grdProDetails.Columns["S.No."].Width = 50;
                            grdProDetails.Columns["Status ID"].Visible = false;
                            grdProDetails.Columns["Concern"].Width = 80;
                            grdProDetails.Columns["DC No."].Width = 80;
                            grdProDetails.Columns["DC Date"].Width = 100;
                            grdProDetails.Columns["P.I Code"].Width = 100;
                            grdProDetails.Columns["Product Name"].Width = 300;
                            grdProDetails.Columns["Unit"].Width = 50;
                            grdProDetails.Columns["DC Qty"].Width = 80;
                            grdProDetails.Columns["Location"].Width = 100;
                            grdProDetails.Columns["Supplier"].Width = 250;
                            grdProDetails.Columns["Status"].Width = 150;
                            grdProDetails.Columns["DC Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["DC Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdProDetails.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["Product Name"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
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
                //DGV_SearchGrid.Visible = false;
                udfnProductSearchGridHead();
                if (lblNoRecordsFound.Visible == true)
                {
                    dtDefaultGrid = objDs.Tables[0];
                    udfnDefaultProductSearchGrid();
                }
                else { DGV_ProdSearchGrid.ScrollBars = ScrollBars.Vertical; }
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
    
        public void udfnDefaultProductSearchGrid()
        {
            try
            {
                DGV_ProdSearchGrid.DataSource = dtDefaultGrid;
                DGV_ProdSearchGrid.Columns["Concern"].Width = 80;
                DGV_ProdSearchGrid.Columns["DC No."].Width = 80;
                DGV_ProdSearchGrid.Columns["DC Date"].Width = 100;
                DGV_ProdSearchGrid.Columns["P.I Code"].Width = 100;
                DGV_ProdSearchGrid.Columns["Product Name"].Width = 300;
                DGV_ProdSearchGrid.Columns["Unit"].Width = 50;
                DGV_ProdSearchGrid.Columns["DC Qty"].Width = 80;
                DGV_ProdSearchGrid.Columns["Supplier"].Width = 250;
                DGV_ProdSearchGrid.Columns["Status"].Width = 100;
                DGV_ProdSearchGrid.Columns["Status ID"].Visible = false;
                DGV_ProdSearchGrid.Columns["S.No."].Width = 50;
                DGV_ProdSearchGrid.Columns["Location"].Width = 150;
                DGV_ProdSearchGrid.ScrollBars = ScrollBars.Both;
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

        private void CmbShow_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbShow_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbShow.SelectedValue) == 196)
                {
                    //btnPrint.Visible = false;
                }
                else
                {
                    //btnPrint.Visible = true;
                }

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
                if (Convert.ToInt32(cmbShow.SelectedValue) == 196)
                {
                    udfnPrint();
                }
                else
                {
                    udfnProductPrint();
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
        public void udfnPrint()
        {
            try
            {
                btnExport.Enabled = false;
                lblDSupplier.Focus();
                if ((grdPurchaseDCList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Purchase DC Transaction list";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdPurchaseDCList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Purchase DC";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdPurchaseDCList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            if (cIndex == 1) // Skip the first column (image columns)
                            {
                                continue;
                            }
                            ExcelSheet.Cells[2, cIndex - 1] = col.HeaderText;
                            ExcelSheet.Columns[cIndex - 1].NumberFormat = "@";

                            if (col.Name == "S.No." || col.Name == "Concern")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 10;
                            }
                            else if (col.Name == "Pur Dc Status" || col.Name == "GSTIN" )
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 20;
                            }
                            else if (col.Name == "Supplier")
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 40;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex - 1].ColumnWidth = 15;
                            }
                            if (col.Name == "S.No." || col.Name == "DC Date")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Total Products" || col.Name == "Created By")
                            {
                                ExcelSheet.Columns[cIndex - 1].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdPurchaseDCList.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex - 1] = rowa.Cells[col.Index].Value;
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
        public void udfnProductPrint()
        {
            try
            {
                btnExport.Enabled = false;
                lblDSupplier.Focus();
                if ((grdProDetails.Rows.Count > 0))
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
                    ExcelSheet.Name = "Purchase DC Product list";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdProDetails.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Purchase DC Product list";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdProDetails.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "S.No." || col.Name == "Concern")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            else if (col.Name == "Status")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }
                            else if (col.Name == "Supplier" || col.Name=="Product Name")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 40;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            foreach (DataGridViewRow rowa in grdProDetails.Rows)
                            {
                                ExcelSheet.Cells[rowa.Index + 3, cIndex] = rowa.Cells[col.Index].Value;
                                if (cIndex == 6)
                                {
                                    ExcelSheet.Cells[rowa.Index + 3, cIndex].Font.Name = "Uni Ila.Sundaram-03";
                                }
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

        private void GrdPurchaseDCList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPurchaseDCList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPrint":
                            int ID = Convert.ToInt32(grdPurchaseDCList.SelectedRows[0].Cells["ID"].Value.ToString());
                            SPDataService objDServs = new SPDataService();
                            string varMessage = objDServs.udfnGetMessages(87);
                            objDServs.CloseConnection();
                            DialogResult result1 = DialogResult.Yes;
                            SPDataService objDServ = new SPDataService();
                            result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.Yes)
                            {
                                MainForm.objPUR_DC_PrintPopUp = new PUR_DC_PrintPopUp();
                                MainForm.objPUR_DC_PrintPopUp.varID = Convert.ToString(ID);
                                MainForm.objPUR_DC_PrintPopUp.ShowDialog();
                            }
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

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                LV_Supplier.BringToFront();
                picLoader.BringToFront();
                Application.DoEvents();
                string varSupplier = txtSupplier.Text;
                int varstsid = 0;
                if (varSupplier == "")
                {
                    varSupplier = "-All-";
                    lblSupplierCode.Text = "0";
                }
                int varPrint = 0;
                varstsid = Convert.ToInt32(cmbStatus.SelectedValue);
                if (Convert.ToInt32(cmbStatus.SelectedValue) == 0)
                {
                    varstsid = 0;
                }
                DataSet objDs = new DataSet();
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
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_DCList.rpt");
                    objBillreport.SetParameterValue("paraCompanyId", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraFromDate", Convert.ToString(dpDcFromDate.Text));
                    objBillreport.SetParameterValue("paraToDate", Convert.ToString(dpdctodate.Text));
                    objBillreport.SetParameterValue("paraSupplierID", Convert.ToInt32(lblSupplierCode.Text));
                    objBillreport.SetParameterValue("paraScheduleID", Convert.ToInt32(lblschedule.Text));
                    objBillreport.SetParameterValue("paraStatusName", Convert.ToString(cmbStatus.Text));
                    objBillreport.SetParameterValue("paraSupplierName", Convert.ToString(varSupplier));
                    objBillreport.SetParameterValue("paraCompanyName", Convert.ToString(cmbConcern.Text));
                    objBillreport.SetParameterValue("paraStatusID", varstsid);
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
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
                LV_Supplier.BringToFront();
                picLoader.SendToBack();
                btnPrint.Enabled = true;
                btnPrint.Focus();
                GC.Collect();
            }
        }
         

        private void GrdPurchaseDCList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdPurchaseDCList.Columns["Pur Dc Status"].Index)
                {
                    var cell = grdPurchaseDCList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdPurchaseDCList.Rows[e.RowIndex].Cells["Pur Dc Full Status"].Value.ToString();
                }
                if (e.ColumnIndex == grdPurchaseDCList.Columns["Overall Status"].Index)
                {
                    var cell = grdPurchaseDCList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdPurchaseDCList.Rows[e.RowIndex].Cells["Overall Full Status"].Value.ToString();
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
