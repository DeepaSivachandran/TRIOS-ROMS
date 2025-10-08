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
    public partial class INV_ReconciliationList : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public string  varStockLocation="", varStockLocationId = "";
        public int varTransactionID = 0, varUpDownKey = 0;
        public int varPRID = 0; int varUserID = 0, ViewType = 0, varUpDownKeyLocation = 0;
        Boolean BlnSearchImageYN = false;

        public INV_ReconciliationList()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {

                MainForm.objINV_StockAdjustment = new INV_Reconciliation(); 
                MainForm.objINV_StockAdjustment.MdiParent = this.ParentForm;
                MainForm.objINV_StockAdjustment.Show();
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
        private void udfnEdit()
        {
            try
            {
                if (grdStockReconciliationList.SelectedRows.Count > 0)
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objINV_StockAdjustment = new INV_Reconciliation();
                    MainForm.objINV_StockAdjustment.MdiParent = this.ParentForm;
                    MainForm.objINV_StockAdjustment.btnSave.Text = "Update";
                    MainForm.objINV_StockAdjustment.varAJId = Convert.ToInt32(grdStockReconciliationList.SelectedRows[0].Cells["TransactionID"].Value);
                    MainForm.objINV_StockAdjustment.varSTSID = Convert.ToInt32(grdStockReconciliationList.SelectedRows[0].Cells["STSID"].Value);
                    MainForm.objINV_StockAdjustment.Show();
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
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdStockReconciliationList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdStockReconciliationList.Columns)
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
                    int ColIndex = 0;
                    dgv2.Rows.Clear();
                    dgv2.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
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
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void INV_GodownOutwardList_KeyDown(object sender, KeyEventArgs e)
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
        private void cmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpReconDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DtpOutwardDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpReconToDate.Focus();
                }
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
                    cmbTransactionType.Focus();
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
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbTransactionType.Focus();
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

        private void DtpOutwardDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dtpReconDate.BackColor = Color.LemonChiffon;
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
        public void udfnList()
        {
            try
            {
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                /* Check stock location is valid or not*/
                if (txtStockLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsSalesLoc = new DataSet();
                    SPDataService objDServ5 = new SPDataService();
                    objDsSalesLoc = objDServ5.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 1, txtStockLocation.Text.Trim(), 0, 0,0,"","",0);
                    objDServ5.CloseConnection();
                    if (objDsSalesLoc != null)
                    {
                        if (objDsSalesLoc.Tables.Count > 0)
                        {
                            if (objDsSalesLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_PurLocation = Convert.ToString(objDsSalesLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varStockLocationId = Convert.ToString(varId_PurLocation);
                }
                else
                {
                    varStockLocationId = "0";
                }
                if (txtProductName.Text == "")
                {
                     varPRID = 0;
                }
                 
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdStockReconciliationList.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                TRN_Stock_Reconciliation_Products objTRNG_Stock_Reconciliation_Products = new TRN_Stock_Reconciliation_Products();
                objTRNG_Stock_Reconciliation_Products.ViewType = 0;
                objTRNG_Stock_Reconciliation_Products.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRNG_Stock_Reconciliation_Products.ParaCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRNG_Stock_Reconciliation_Products.paraFromDate = dtpReconDate.Text;
                objTRNG_Stock_Reconciliation_Products.paraToDate = dtpReconToDate.Text;
                objTRNG_Stock_Reconciliation_Products.paraSLID = Convert.ToInt32(varStockLocationId);
                objTRNG_Stock_Reconciliation_Products.ParaTransactionId = Convert.ToInt32(varTransactionID);
                objTRNG_Stock_Reconciliation_Products.paraTransType = Convert.ToInt32(cmbTransactionType.SelectedValue); 
                objTRNG_Stock_Reconciliation_Products.paraPRID = Convert.ToInt32(varPRID);
                objTRNG_Stock_Reconciliation_Products.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objTRNG_Stock_Reconciliation_Products.paraIPAddress = MainForm.pbIpAddress;
                objDs = objdserv.udfnStockConciliationList(objTRNG_Stock_Reconciliation_Products);
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
                            grdStockReconciliationList.Columns["clmPrint"].Visible = false;
                            grdStockReconciliationList.DataSource = objDs.Tables[0];
                            grdStockReconciliationList.Columns["S.No."].Width = 50;
                            grdStockReconciliationList.Columns["Concern"].Width = 120;
                            grdStockReconciliationList.Columns["Transaction Date"].Width = 120;
                            grdStockReconciliationList.Columns["Transaction No."].Width = 130;
                            grdStockReconciliationList.Columns["Transaction Type"].Width = 130;
                            grdStockReconciliationList.Columns["Stock Location"].Width = 150; 
                            grdStockReconciliationList.Columns["TransactionID"].Visible = false;
                            grdStockReconciliationList.Columns["Total Products"].Width = 120;
                            grdStockReconciliationList.Columns["Created By"].Width = 120;
                            grdStockReconciliationList.Columns["Created On"].Width = 150;
                            grdStockReconciliationList.Columns["STSID"].Visible = false;
                            grdStockReconciliationList.Columns["Status"].Width = 120;
                            grdStockReconciliationList.Columns["Status"].Visible = false;
                            grdStockReconciliationList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockReconciliationList.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockReconciliationList.Columns["Transaction Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        }
                        else
                        {
                            grdStockReconciliationList.Columns["clmPrint"].Visible = false;
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        grdStockReconciliationList.Columns["clmPrint"].Visible = false;
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }

                }
                else
                {
                    grdStockReconciliationList.Columns["clmPrint"].Visible = false;
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
                btnView.Focus();
            }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["Concern"].Width = 120;
                DGV_SearchGrid.Columns["Transaction Date"].Width = 120;
                DGV_SearchGrid.Columns["Transaction No."].Width = 130;
                DGV_SearchGrid.Columns["Transaction Type"].Width = 130;
                DGV_SearchGrid.Columns["Stock Location"].Visible = false;
                DGV_SearchGrid.Columns["TransactionID"].Visible = false;
                DGV_SearchGrid.Columns["Total Products"].Width = 120;
                DGV_SearchGrid.Columns["Created By"].Width = 120;
                DGV_SearchGrid.Columns["STSID"].Visible = false;
                DGV_SearchGrid.Columns["Status"].Width = 120; DGV_SearchGrid.ScrollBars = ScrollBars.Both;
                DGV_SearchGrid.Columns["Status"].Visible = false;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_GodownOutwardList_Load(object sender, EventArgs e)
        {
            try
            {
                udfnConcern();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STSID IN (35,26,0) ORDER BY STSID", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID = 116 OR MSTID=0 ORDER BY MSTID ", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID"); 
                objDataBind = null;
                cmbStatus.SelectedValue = 0;   
                dtpReconDate.MinDate = MainForm.pbFYStartDate;
                dtpReconDate.MaxDate = MainForm.pbCurrentDate;
                dtpReconToDate.MaxDate = MainForm.pbCurrentDate;
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                this.ActiveControl = cmbConcern;
                udfnList();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        public void udfnConcern()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                int varViewType = 2;
                objDs = objdserv.udfnCompanyList(varViewType, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                cmbConcern.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDs.Tables[0];
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
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                btnView.Enabled = true;
                udfnList();
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

                //lvProduct.Items.Clear();
                if (varUpDownKey==0)
                {
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 53;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraLocationId = Convert.ToInt32(varStockLocationId);
                        objMR_Product.paraProductName = txtProductName.Text;
                        objMR_Product.ParaFromDate = dtpReconDate.Text;
                        objMR_Product.ParaToDate = dtpReconToDate.Text;
                        objMR_Product.paraId = 5;
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
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 420;
                                    DGV_FilterProduct.Columns["Unit"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
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
                                    udfnLvStockLocation();
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
                        objDs = objspdservice.udfnStockLocationList(27, Convert.ToInt32(cmbConcern.SelectedValue), 0, 6, txtStockLocation.Text, 0, 0, 0, dtpReconDate.Text, dtpReconToDate.Text, 0);

                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterLocation.Visible = true;
                                    DGV_FilterLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterLocation.Columns["SL_EName"].Width = 160;
                                    DGV_FilterLocation.Columns["SL_EName"].DisplayIndex = 0;
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
        }
        public void udfnLvStockLocation()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    varStockLocationId = Convert.ToString(DGV_FilterLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtStockLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation();
                    txtProductName.Focus();
                }
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

        private void DtpOutwardDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dtpReconDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dtpReconToDate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DtpOutwardDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dtpReconDate.BackColor = Color.White;
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
                grdStockReconciliationList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockReconciliationList);
                objDser.CloseConnection();
                grdStockReconciliationList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                    DataGridViewColumn newColumn = grdStockReconciliationList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdStockReconciliationList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdStockReconciliationList.SortOrder == SortOrder.Ascending)
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
                    grdStockReconciliationList.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_SearchGrid.HorizontalScrollingOffset = grdStockReconciliationList.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdStockReconciliationList.ColumnCount > 0)
                {
                    grdStockReconciliationList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdStockReconciliationList.HorizontalScrollingOffset;
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
                grdStockReconciliationList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockReconciliationList);
                objDser.CloseConnection();
                grdStockReconciliationList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                grdStockReconciliationList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockReconciliationList);
                objDser.CloseConnection();
                grdStockReconciliationList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
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
                    int offSetValue = grdStockReconciliationList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdStockReconciliationList.Width > grdStockReconciliationList.HorizontalScrollingOffset && grdStockReconciliationList.HorizontalScrollingOffset > 0)
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

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                btnExport.Enabled = false;
                if ((grdStockReconciliationList.Rows.Count > 0))
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
                    ExcelSheet.Name = "Stock Reconciliation List";
                    int cIndex = 0;
                    int count = 0;
                    foreach (DataGridViewColumn col in grdStockReconciliationList.Columns)
                    {
                        if (col.Visible)
                        {
                            count += 1;
                        }
                    }
                    //Excel.Range er = ExcelSheet.get_Range("A:A", System.Type.Missing);
                    //er.EntireColumn.ColumnWidth = 35;

                    ExcelSheet.Cells[1, 1].Value = "Stock Reconciliation  List";
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Merge();
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].HorizontalAlignment = Excel.Constants.xlCenter;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[1, 1], ExcelSheet.Cells[1, count]].Font.Size = 12;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.Bold = true;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Font.color = Color.White;
                    ExcelSheet.Range[ExcelSheet.Cells[2, 1], ExcelSheet.Cells[2, count]].Interior.Color = Color.LightSlateGray;


                    foreach (DataGridViewColumn col in grdStockReconciliationList.Columns)
                    {
                        if (col.Visible)
                        {
                            cIndex += 1;
                            ExcelSheet.Cells[2, cIndex] = col.HeaderText;
                            ExcelSheet.Columns[cIndex].NumberFormat = "@";

                            if (col.Name == "Concern" || col.Name == "Transaction Date" || col.Name == "Transaction No." || col.Name == "Stock Location" || col.Name == "Transaction Type" || col.Name == "Total Products" )
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 15;
                            }
                            else
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 10;
                            }
                            if (col.Name == "S.No.")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlCenter;
                            }
                            if (col.Name == "Created On" || col.Name == "Status")
                            {
                                ExcelSheet.Columns[cIndex].ColumnWidth = 20;
                            }

                            if (col.Name == "Total Products")
                            {
                                ExcelSheet.Columns[cIndex].HorizontalAlignment = Excel.Constants.xlRight;
                            }
                            foreach (DataGridViewRow rowa in grdStockReconciliationList.Rows)
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

        private void GrdUserList_DoubleClick(object sender, EventArgs e)
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

        private void GrdUserList_KeyDown(object sender, KeyEventArgs e)
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
        private void GrdUserList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdStockReconciliationList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdStockReconciliationList.Width > grdStockReconciliationList.HorizontalScrollingOffset && grdStockReconciliationList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdStockReconciliationList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdOutwardList)
        {
            try
            {
                var vScrollbar = grdOutwardList.Controls.OfType<VScrollBar>().First();
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
        public void udfndelete()
        {
            try
            {
                DataTable dtStock = new DataTable();
                dtStock.TableName = "TRN_StockTransfer_Product_AutoComplete";
                dtStock.Columns.Add("STK_PRID", typeof(int));
                dtStock.Columns.Add("STK_MRP", typeof(decimal));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(string));
                dtStock.Columns.Add("STK_QTY", typeof(string));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(int));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(int));
                dtStock.Columns.Add("STK_ProType", typeof(int));
                dtStock.Columns.Add("STK_Status", typeof(int));
                if (grdStockReconciliationList.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SPDataService objspdservice = new SPDataService();
                        int vartype = 0;
                        if (Convert.ToString(grdStockReconciliationList.SelectedRows[0].Cells["Transaction Type"].Value) == "Addition")
                        {
                            vartype = 378;
                        }
                        else
                        {
                            vartype = 377;
                        }

                        String varoriginator = "Reconcilation Delete";
                        DataTable objGrnPO = new DataTable();
                        TRN_Stock_Reconciliation_Products objTRNS_Stock_Reconciliation_Products = new TRN_Stock_Reconciliation_Products();
                        objTRNS_Stock_Reconciliation_Products.ViewType = 2; 
                        objTRNS_Stock_Reconciliation_Products.ParaTransactionId = Convert.ToInt32(grdStockReconciliationList.SelectedRows[0].Cells["TransactionID"].Value);
                        objTRNS_Stock_Reconciliation_Products.paraTransferType = vartype;
                        objTRNS_Stock_Reconciliation_Products.paraUserID = varUserID;
                        objTRNS_Stock_Reconciliation_Products.paraIPAddress = MainForm.pbIpAddress;
                        objTRNS_Stock_Reconciliation_Products.paraOriginator = varoriginator;
                        objTRNS_Stock_Reconciliation_Products.paraDeleteflag = 0;
                        string result = objspdservice.udfnStockConciliation(objTRNS_Stock_Reconciliation_Products);
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
                                    objTRNS_Stock_Reconciliation_Products.ViewType = 2;
                                    objTRNS_Stock_Reconciliation_Products.paraUserID = varUserID;
                                    objTRNS_Stock_Reconciliation_Products.paraTransferType = vartype;
                                    objTRNS_Stock_Reconciliation_Products.paraIPAddress = MainForm.pbIpAddress;
                                    objTRNS_Stock_Reconciliation_Products.paraOriginator = varoriginator;
                                    objTRNS_Stock_Reconciliation_Products.ParaTransactionId = Convert.ToInt32(grdStockReconciliationList.SelectedRows[0].Cells["TransactionID"].Value);
                                    //if (Convert.ToString(grdStockReconciliationList.SelectedRows[0].Cells["TransactionID"].Value) == "Addition")
                                    //{ 
                                    //    objTRNS_Stock_Reconciliation_Products.paraTransferType = 378;
                                    //}
                                    //else { 
                                    //    objTRNS_Stock_Reconciliation_Products.paraTransferType = 377;
                                    //}
                                    objTRNS_Stock_Reconciliation_Products.paraDeleteflag = 1;
                                     result = objspdservice.udfnStockConciliation(objTRNS_Stock_Reconciliation_Products);
                                    objspdservice.CloseConnection();
                                    if (result.Split('~')[0] == "3")
                                    {
                                        MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ViewType = 0;
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
        private void GrdUserList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdStockReconciliationList.Rows.Count; i++)
                {
                    if (Convert.ToInt32(grdStockReconciliationList.Rows[i].Cells["STSID"].Value) == 35)
                    {
                        grdStockReconciliationList.Rows[i].Cells["Status"].Style.BackColor = Color.Orange;
                        grdStockReconciliationList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToInt32(grdStockReconciliationList.Rows[i].Cells["STSID"].Value) == 25)
                    {
                        grdStockReconciliationList.Rows[i].Cells["Status"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        grdStockReconciliationList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    else if (Convert.ToInt32(grdStockReconciliationList.Rows[i].Cells["STSID"].Value) == 26)
                    {
                        grdStockReconciliationList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                        grdStockReconciliationList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                    }
                    if (Convert.ToInt32(grdStockReconciliationList.Rows[i].Cells["STSID"].Value) == 35)
                    {
                        grdStockReconciliationList.Rows[i].Cells["clmPrint"].ReadOnly = true;
                        DataGridViewTextBoxCell print = new DataGridViewTextBoxCell();
                        print.Value = "";
                        grdStockReconciliationList.Rows[i].Cells["clmPrint"] = print;
                        print.ReadOnly = true;
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
                grdStockReconciliationList.ClearSelection();
            }
        }
        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterLocation.Visible = false;
                DGV_FilterLocation.DataSource = null;
                DGV_FilterProduct.Visible = false;
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
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                DGV_FilterLocation.Visible = false;
                DGV_FilterLocation.DataSource = null;
                btnView.BackColor = Color.LemonChiffon;
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
                DGV_FilterLocation.Visible = false;
                DGV_FilterLocation.DataSource = null;
                DGV_FilterProduct.Visible = false;
                btnExport.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DtpOutwardToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dtpReconToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }  
        }

        private void DtpOutwardToDate_KeyDown(object sender, KeyEventArgs e)
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

        private void DGV_FilterLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 1;
                udfnLvStockLocation();
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
                                    udfnLvStockLocation();
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

        private void cmbTransactionType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTransactionType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbTransactionType_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbTransactionType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbTransactionType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbTransactionType.BackColor = Color.White;
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
                cmbTransactionType.Focus();
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

        private void GrdOutwardList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdStockReconciliationList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPrint":
                            try
                            {
                                string GOID = "0";
                                GOID = Convert.ToString(grdStockReconciliationList.SelectedRows[0].Cells["GOID"].Value.ToString());
                                DialogResult result1;
                                SPDataService objDServ = new SPDataService();
                                string varMessage = objDServ.udfnGetMessages(87);
                                objDServ.CloseConnection();
                                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result1 == DialogResult.Yes)
                                {
                                    string varHeader = "";
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_GoodsOutward.rpt");
                                    varHeader = "Goods Outward Report";

                                    objBillreport.SetParameterValue("paraGOID", Convert.ToInt32(GOID));
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                                    objValidation.CrySqlConnection(objBillreport);

                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.Text = varHeader;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                            }
                            catch (Exception ex)
                            {
                                objError = new DataError();
                                objError.WriteFile(ex);
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

        private void DtpOutwardToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dtpReconToDate.BackColor = Color.White;
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
    }
}
