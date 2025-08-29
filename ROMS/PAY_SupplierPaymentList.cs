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
    public partial class PAY_SupplierPaymentList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable Deftable = new DataTable();
        public Boolean BlnSearchImageYN = false;
        public int varUserID = 0;

        public PAY_SupplierPaymentList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPAY_SupplierPayment = new PAY_SupplierPayment();
                MainForm.objPAY_SupplierPayment.MdiParent = this.ParentForm;
                MainForm.objPAY_SupplierPayment.Show();
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
                udfnEditLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEditLoad()
        {
            try
            {
                
                if (grdSupllierPaymentList.SelectedRows.Count > 0)
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objPAY_SupplierPayment = new PAY_SupplierPayment();
                    MainForm.objPAY_SupplierPayment.MdiParent = this.ParentForm;
                    MainForm.objPAY_SupplierPayment.btnSave.Text = "Update";
                    MainForm.objPAY_SupplierPayment.varSupplierPaymentID = Convert.ToInt32(grdSupllierPaymentList.SelectedRows[0].Cells["PAYID"].Value);
                    MainForm.objPAY_SupplierPayment.varPaymentStatus = Convert.ToInt32(grdSupllierPaymentList.SelectedRows[0].Cells["PAY_STSID"].Value);
                    MainForm.objPAY_SupplierPayment.Show();
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
        private void tsbDelete_Click(object sender, EventArgs e)
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
                int Viewtype = 0;
                DataTable dtPayment = new DataTable();
                dtPayment.TableName = "TRN_Supplier_Payment";
                dtPayment.Columns.Add("PY_PURID", typeof(int));
                dtPayment.Columns.Add("PY_Amount", typeof(float));
                dtPayment.Columns.Add("PY_STSID", typeof(int));
                if (grdSupllierPaymentList.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Viewtype = 2;
                        String varoriginator = "Supplier payment Delete";
                        DataTable objGrnPO = new DataTable();
                        TRN_Supplier_Payment objTRN_Supplier_Payment = new TRN_Supplier_Payment();
                        objTRN_Supplier_Payment.ViewType = Viewtype;
                        objTRN_Supplier_Payment.paraPYID = Convert.ToInt32(grdSupllierPaymentList.SelectedRows[0].Cells["PAYID"].Value);
                        objTRN_Supplier_Payment.paraSTSID = Convert.ToInt32(grdSupllierPaymentList.SelectedRows[0].Cells["PAY_STSID"].Value);
                        objTRN_Supplier_Payment.paraDeleteFlag = 0;
                        objTRN_Supplier_Payment.paraUserID = varUserID;
                        objTRN_Supplier_Payment.paraIPAddress = MainForm.pbIpAddress;
                        objTRN_Supplier_Payment.paraOriginator = varoriginator;
                        SPDataService objspdservice = new SPDataService();
                        string result = objspdservice.udfnSetPayment(objTRN_Supplier_Payment);
                        objspdservice.CloseConnection();
                        string[] varvalue = result.Split('~');
                        if (result.Split('~')[0] == "3")
                        {
                            if (result.Split('~')[1] == "1")
                            {
                                MainForm.objCP_Verify = new CP_Verify();
                                MainForm.objCP_Verify.ShowDialog();
                                if (MainForm.objCP_Verify.flag == 1)
                                {
                                    varUserID = Convert.ToInt32(MainForm.objCP_Verify.varUserId);
                                    objTRN_Supplier_Payment.ViewType = Viewtype;
                                    objTRN_Supplier_Payment.paraPYID = Convert.ToInt32(grdSupllierPaymentList.SelectedRows[0].Cells["PAYID"].Value);
                                    objTRN_Supplier_Payment.paraSTSID = Convert.ToInt32(grdSupllierPaymentList.SelectedRows[0].Cells["PAY_STSID"].Value);
                                    objTRN_Supplier_Payment.paraDeleteFlag = 1;
                                    objTRN_Supplier_Payment.paraUserID = varUserID;
                                    objTRN_Supplier_Payment.paraIPAddress = MainForm.pbIpAddress;
                                    objTRN_Supplier_Payment.paraOriginator = varoriginator;
                                    result = objspdservice.udfnSetPayment(objTRN_Supplier_Payment);
                                    objspdservice.CloseConnection();
                                    if (result.Split('~')[0] == "3")
                                    {
                                        MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Viewtype = 0;
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
            }
        }
        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {

                    if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                        return;
                    if (!(e.ColumnIndex == 0))   /*If not our desired columns*/
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
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (grdSupllierPaymentList.ColumnCount > 0)
                    {
                        grdSupllierPaymentList.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdSupllierPaymentList.HorizontalScrollingOffset;
                    }
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
                if (lblNoRecordsFound.Visible == false)
                {
                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdSupllierPaymentList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSupllierPaymentList);
                    objDser.CloseConnection();
                    grdSupllierPaymentList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //DGV_SearchGrid_CellPainting(sender,e);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdSupllierPaymentList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdSupllierPaymentList.Columns)
                    {
                        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    DGV_SearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                    DGV_SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                    for (int i = 1; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    DGV_SearchGrid.Columns[0].ReadOnly = true; 
                    DGV_SearchGrid.Columns[1].ReadOnly = true;
                    DGV_SearchGrid.Columns[2].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Rows[0].Cells[2].Value = new Bitmap(1, 1);
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
                    int ColIndex = 0;
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
                        else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                        {
                            BlnSearchImageYN = true;
                            dgv2.Rows[rowIndex].Cells[i].Value = false;
                        }
                        else
                        {
                            dgv2.Rows[rowIndex].Cells[i].Value = "";
                        }
                    }

                    DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Columns[1].ReadOnly = true;
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                    DGV_SearchGrid.Columns[2].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Rows[0].Cells[2].Value = new Bitmap(1, 1);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        //private void udfnGridSearchFilter()
        //{
        //    try
        //    {
        //        for (int i = 0; i < DGV_SearchGrid.Rows.Count; ++i)
        //        {
        //            if (DGV_SearchGrid.ColumnCount > 0)
        //            {
        //                BindingSource bs = new BindingSource();
        //                bs.DataSource = grdSupllierPaymentList.DataSource;
        //                string filter = "";
        //                for (int j = 1; j < DGV_SearchGrid.ColumnCount; j++)
        //                {
        //                    if (Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) != "")
        //                    {
        //                        if (filter != "") filter += "And ";
        //                        if (objValidation.FormatNumeric(Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value)))
        //                            filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + "=" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value);
        //                        else
        //                            filter += "[" + DGV_SearchGrid.Columns[j].HeaderText.ToString() + "]" + " LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
        //                    }
        //                }
        //                bs.Filter = filter;
        //                grdSupllierPaymentList.DataSource = bs;
        //            }
        //        }
        //    }
        //    catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        //}

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdSupllierPaymentList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdSupllierPaymentList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdSupllierPaymentList.SortOrder == SortOrder.Ascending)
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
                    grdSupllierPaymentList.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_SearchGrid.HorizontalScrollingOffset = grdSupllierPaymentList.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        public void udfnscrollVisible(DataGridView DGV,DataGridView grdGroupList)
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
        private void PAY_SupplierPaymentList_KeyDown(object sender, KeyEventArgs e)
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
                    tsbDelete_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
                if (e.KeyCode == Keys.Delete)
                {
                    udfndelete();
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
                    dpFromdate.Focus();
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
        private void PAY_SupplierPaymentList_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbConcern();
                //DataSet objDs = new DataSet();
                //SPDataService objspservice = new SPDataService();
                //objDs = objspservice.udfnMaster(9, 0, 0, "", "", 0, "", 2);
                //if (objDs.Tables[0].Rows.Count > 0)
                //{
                //    DateTime varDate = DateTime.ParseExact(objDs.Tables[0].Rows[0]["DATE"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //    dpTodate.MinDate = varDate;
                //    dpFromdate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["DATE1"]);
                //}
                //objspservice.CloseConnection();
                dpFromdate.MinDate = MainForm.pbFYStartDate;
                dpFromdate.MaxDate = MainForm.pbCurrentDate;
                dpTodate.MaxDate = MainForm.pbCurrentDate;
                cmbConcern.SelectedValue = 1;
                this.ActiveControl = txtSupplier;
                udfnList();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromdate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpFromdate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpTodate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromdate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpFromdate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpTodate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpTodate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpTodate_KeyDown(object sender, KeyEventArgs e)
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
        private void DpTodate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpTodate.BackColor = Color.White;
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
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSupplier.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        lvSupplier.Visible = false;
                    }
                    else
                    {
                        lvSupplier.Focus();
                    }
                    if (lvSupplier.Items.Count > 0)
                    {
                        lvSupplier.Items[0].Selected = true;
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
                DGV_SearchGrid.DataSource = null;
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblSchedule.Text = "0";
                }
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdSupllierPaymentList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                Model.TRN_Supplier_Payment objTRN_Supplier_Payment = new Model.TRN_Supplier_Payment();
                objTRN_Supplier_Payment.ViewType = 1;
                objTRN_Supplier_Payment.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_Supplier_Payment.paraFromDate = Convert.ToString(dpFromdate.Text);
                objTRN_Supplier_Payment.ParaToDate = Convert.ToString(dpTodate.Text);
                objTRN_Supplier_Payment.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                objDs = objspservice.udfnGetSupplierPayment(objTRN_Supplier_Payment);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdSupllierPaymentList.DataSource = objDs.Tables[0];                           
                            grdSupllierPaymentList.Columns["S.No."].Width = 50;
                            grdSupllierPaymentList.Columns["Transaction Date"].Width = 120;
                            grdSupllierPaymentList.Columns["Transaction No."].Width = 110;
                            grdSupllierPaymentList.Columns["Supplier"].Width = 300;
                            grdSupllierPaymentList.Columns["GSTIN"].Width = 120;
                            grdSupllierPaymentList.Columns["Advance"].Width = 100;
                            grdSupllierPaymentList.Columns["Sub Total"].Width = 100;
                            grdSupllierPaymentList.Columns["Grand Total"].Width = 100;
                            grdSupllierPaymentList.Columns["Payment Mode"].Width = 100;
                            grdSupllierPaymentList.Columns["Status"].Width = 150;
                            grdSupllierPaymentList.Columns["PAY_PaymentMode"].Visible = false;
                            grdSupllierPaymentList.Columns["PAYID"].Visible = false;
                            grdSupllierPaymentList.Columns["PAY_STSID"].Visible = false;
                            grdSupllierPaymentList.Columns["PAY_BankID"].Visible = false;
                            grdSupllierPaymentList.Columns["ChequeDate"].Visible = false;
                            grdSupllierPaymentList.Columns["PAY_SPID"].Visible = false;
                            grdSupllierPaymentList.Columns["PAY_SPSCID"].Visible = false;
                            grdSupllierPaymentList.Columns["PAY_Bank_Tx_Date"].Visible = false;
                            grdSupllierPaymentList.Columns["RPTName"].Visible = false;
                            grdSupllierPaymentList.Columns["PrintFlag"].Visible = false;
                            grdSupllierPaymentList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdSupllierPaymentList.Columns["transaction Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdSupllierPaymentList.Columns["Advance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdSupllierPaymentList.Columns["Sub Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdSupllierPaymentList.Columns["Grand Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdSupllierPaymentList.BringToFront();
                            DGV_SearchGrid.BringToFront();

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
                    Deftable = objDs.Tables[0];
                    udfnDefaultSearchGrid();
                }
                else { DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdSupllierPaymentList.ClearSelection();
                picLoader.Visible = false;
                picLoader.SendToBack();
                btnView.Enabled = true;
                btnView.Focus();
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = null;
                DGV_SearchGrid.DataSource = Deftable;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Transaction Date"].Width = 120;
                DGV_SearchGrid.Columns["Transaction No."].Width = 100;
                DGV_SearchGrid.Columns["Supplier"].Width = 100;
                DGV_SearchGrid.Columns["GSTIN"].Width = 120;
                DGV_SearchGrid.Columns["Advance"].Width = 100;
                DGV_SearchGrid.Columns["Sub Total"].Width = 100;
                DGV_SearchGrid.Columns["Grand Total"].Width = 100;
                DGV_SearchGrid.Columns["Payment Mode"].Width = 150;
                DGV_SearchGrid.Columns["PAY_PaymentMode"].Visible = false;
                DGV_SearchGrid.Columns["PAYID"].Visible = false;
                DGV_SearchGrid.Columns["Status"].Width = 150;
                DGV_SearchGrid.Columns["PAY_PaymentMode"].Visible = false;
                DGV_SearchGrid.Columns["PAYID"].Visible = false;
                DGV_SearchGrid.Columns["PAY_STSID"].Visible = false;
                DGV_SearchGrid.Columns["PAY_BankID"].Visible = false;
                DGV_SearchGrid.Columns["ChequeDate"].Visible = false;
                DGV_SearchGrid.Columns["PAY_SPID"].Visible = false;
                DGV_SearchGrid.Columns["PAY_SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["PAY_Bank_Tx_Date"].Visible = false;
                DGV_SearchGrid.Columns["RPTName"].Visible = false;
                DGV_SearchGrid.Columns["PrintFlag"].Visible = false;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
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
                udfnExport();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnExport()
        {
            try
            {
                btnExport.Enabled = false;
                if ((grdSupllierPaymentList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Supplier payment List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdSupllierPaymentList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Supplier Payment List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdSupllierPaymentList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";
                            if(col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            if (col.Name == "Transaction Date" || col.Name == "Transaction No." || col.Name == "Advance" || col.Name == "Subtotal" || col.Name == "Grandtotal" || col.Name == "Payment Mode")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            else if (col.Name == "GSTIN")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }
                            else if (col.Name == "Supplier")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 40;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            if (col.Name == "Transaction Date" || col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }

                            if (col.Name == "Sub Total" || col.Name == "Grand Total" || col.Name == "Advance")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdSupllierPaymentList.Rows)
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
        public void udfnSupplierDetails()
        {
            try
            {
                if (txtSupplier.Text != "")
                {
                    ListViewItem selectedItem = lvSupplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblSchedule.Text = selectedItem.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSupplier.Visible = false;
            }
        }
        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSupplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    Model.MR_Supplier objMR_Supplier = new Model.MR_Supplier();
                    objMR_Supplier.ViewType = 43;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.ParaFromDate = dpFromdate.Text;
                    objMR_Supplier.ParaToDate = dpTodate.Text;
                    objMR_Supplier.paraFlag = 1;
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
                                    lvSupplier.Items.Add(objList);
                                }
                                lvSupplier.Visible = true;
                                lvSupplier.BringToFront();
                                lvSupplier.Columns[1].Width = 0;
                                lvSupplier.Columns[2].Width = 0;
                                lvSupplier.Columns[0].Width = 250;
                                lvSupplier.Columns[3].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    lvSupplier.Visible = false;
                    lvSupplier.Items.Clear();
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

        private void LvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSupplierDetails();
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSupplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                udfnSupplierDetails();
                btnView.Focus();
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
                if (lblNoRecordsFound.Visible == false)
                {
                    if (DGV_SearchGrid.IsCurrentCellDirty)
                    {
                        // Commit the changes immediately
                        DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdSupllierPaymentList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSupllierPaymentList);
                objDser.CloseConnection();
                grdSupllierPaymentList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }

            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    //udfnGridSearchFilter();
                    DataService objDser = new DataService();
                    grdSupllierPaymentList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSupllierPaymentList);
                    objDser.CloseConnection();
                    grdSupllierPaymentList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                    //DGV_SearchGrid_CellPainting(sender,e);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdSupllierPaymentList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdSupllierPaymentList.Width > grdSupllierPaymentList.HorizontalScrollingOffset && grdSupllierPaymentList.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdSupllierPaymentList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpFromdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpTodate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupllierPaymentList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdSupllierPaymentList.ClearSelection();
                for (int i = 0; i < grdSupllierPaymentList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdSupllierPaymentList.Rows[i].Cells["PAY_STSID"].Value) == "76")
                    {
                        grdSupllierPaymentList.Rows[i].Cells["Status"].Style.BackColor = Color.Orange;
                        grdSupllierPaymentList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                        DataGridViewTextBoxCell print = new DataGridViewTextBoxCell();
                        print.Value = "";
                        grdSupllierPaymentList.Rows[i].Cells["clmDate"] = print;
                        print.ReadOnly = true;
                    }
                    else if (Convert.ToString(grdSupllierPaymentList.Rows[i].Cells["PAY_STSID"].Value) == "77")
                    {
                        grdSupllierPaymentList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdSupllierPaymentList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToString(grdSupllierPaymentList.Rows[i].Cells["PrintFlag"].Value) == "0")
                    {
                        grdSupllierPaymentList.Rows[i].Cells["clmPrint"].ReadOnly = true;
                        DataGridViewTextBoxCell print = new DataGridViewTextBoxCell();
                        print.Value = "";
                        grdSupllierPaymentList.Rows[i].Cells["clmPrint"] = print;
                        print.ReadOnly = true;
                    }
                    if (Convert.ToString(grdSupllierPaymentList.Rows[i].Cells["PAY_Bank_Tx_Date"].Value) != "")
                    {
                        DataGridViewTextBoxCell print = new DataGridViewTextBoxCell();
                        print.Value = "";
                        grdSupllierPaymentList.Rows[i].Cells["clmDate"] = print;
                        print.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupllierPaymentList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnEditLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupllierPaymentList_DoubleClick(object sender, EventArgs e)
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

        private void GrdSupllierPaymentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdSupllierPaymentList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPrint":
                            if (Convert.ToUInt32(grdSupllierPaymentList.SelectedRows[0].Cells["PAY_BankID"].Value)!=0)
                            {
                                DialogResult result1 = DialogResult.Yes;
                                SPDataService objDServs = new SPDataService();
                                string varMessage = objDServs.udfnGetMessages(87);
                                objDServs.CloseConnection();
                                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result1 == DialogResult.Yes)
                                {
                                    string varRPTName = "";
                                    string varGrandTotal = Convert.ToString(grdSupllierPaymentList.SelectedRows[0].Cells["Grand Total"].Value);
                                    decimal varMRP = Math.Round(Convert.ToDecimal(varGrandTotal.Trim()), 2, MidpointRounding.AwayFromZero);
                                    string varAmt = string.Format("{0:0}", varMRP);
                                    int varAmount = Convert.ToInt32(varAmt);
                                    string lblAmount = Currency.NumbersToWords(varAmount);                                    
                                    string varSupplierName = Convert.ToString(grdSupllierPaymentList.SelectedRows[0].Cells["Supplier"].Value);
                                    string varChequeDate = Convert.ToString(grdSupllierPaymentList.SelectedRows[0].Cells["ChequeDate"].Value);
                                    varRPTName= Convert.ToString(grdSupllierPaymentList.SelectedRows[0].Cells["RPTName"].Value);
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\" + varRPTName);
                                    objBillreport.SetParameterValue("paraSupplierName", varSupplierName);
                                    objBillreport.SetParameterValue("paraAmountInWords", lblAmount);
                                    objBillreport.SetParameterValue("paraAmount", varGrandTotal);
                                    objBillreport.SetParameterValue("paraChequeDate", varChequeDate);
                                    objValidation.CrySqlConnection(objBillreport);
                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                            }
                            break;
                        case "clmReceiptPrint":
                            if (Convert.ToUInt32(grdSupllierPaymentList.SelectedRows[0].Cells["PAYID"].Value) != 0)
                            {
                                DialogResult result1 = DialogResult.Yes;
                                SPDataService objDServs = new SPDataService();
                                string varMessage = objDServs.udfnGetMessages(87);
                                objDServs.CloseConnection();
                                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result1 == DialogResult.Yes)
                                {
                                    int varPAYID = Convert.ToInt16(grdSupllierPaymentList.SelectedRows[0].Cells["PAYID"].Value);
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PAY_PayReceipt.rpt");
                                    objBillreport.SetParameterValue("paraPYID", varPAYID, objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraPYID", varPAYID, objBillreport.Subreports[1].Name.ToString());
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[0].Name.ToString());
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[1].Name.ToString());
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[1].Name.ToString());

                                    objValidation.CrySqlConnection(objBillreport);
                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                            }
                            break;
                        case "clmDate":
                            if (Convert.ToUInt32(grdSupllierPaymentList.SelectedRows[0].Cells["PAY_BankID"].Value) != 0)
                            {

                                int varSPID = Convert.ToInt16(grdSupllierPaymentList.SelectedRows[0].Cells["PAY_SPID"].Value);
                                int varSPSCID = Convert.ToInt16(grdSupllierPaymentList.SelectedRows[0].Cells["PAY_SPSCID"].Value);
                                string varBankDate = Convert.ToString(grdSupllierPaymentList.SelectedRows[0].Cells["PAY_Bank_Tx_Date"].Value);
                                if (varBankDate == "")
                                {
                                    MainForm.objPAY_SupplierPayment_BankDate = new PAY_SupplierPayment_BankDate();
                                    MainForm.objPAY_SupplierPayment_BankDate.varSupplierId = varSPID;
                                    MainForm.objPAY_SupplierPayment_BankDate.varScheduleId = varSPSCID;
                                    MainForm.objPAY_SupplierPayment_BankDate.ShowDialog();
                                }
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

        private void GrdSupllierPaymentList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int cl = grdSupllierPaymentList.ColumnCount;
                int cls = DGV_SearchGrid.ColumnCount;
                int offSetValue = grdSupllierPaymentList.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;

                if (totalWidth - grdSupllierPaymentList.Width > grdSupllierPaymentList.HorizontalScrollingOffset && grdSupllierPaymentList.HorizontalScrollingOffset > 0)
                {
                    //offSetValue = offSetValue ;
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdSupllierPaymentList);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
