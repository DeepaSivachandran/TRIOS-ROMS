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

namespace ROMS
{
    public partial class INV_InwardQueueList : Form
    {
        MainForm objMainForm = new MainForm();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpSupplier = new ToolTip();
        public int varPRID = 0, varStockLocationId = 0, Varflag = 0, varviewtype = 0, varUpDownKey = 0, varUpDownKeyLocation = 0;
        DataTable dtDefaultGrid = new DataTable();
        public bool EditAccess = false;
        Boolean BlnSearchImageYN = false;

        public INV_InwardQueueList()
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
        public void udfndelete()
        {
            try
            {
                if (grdInwardQueueList.SelectedRows.Count > 0)
                {
                    string result = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        SPDataService objspdservice = new SPDataService();
                        result = "";
                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           

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
        public void udfnEdit()
        {
            if (EditAccess == true || Convert.ToInt32(MainForm.pbUserRoleId) == 1)
            {
                try
                {
                    if (grdInwardQueueList.Rows.Count != 0 && grdInwardQueueList.SelectedRows.Count == 1)
                    {
                        picLoader.Visible = true;
                        picLoader.BringToFront();
                        Application.DoEvents();
                        MainForm.objINV_InwardPurchase = new INV_InwardPurchase();
                        //MainForm.objINV_InwardPurchase.MdiParent = this.ParentForm;
                        //MainForm.objINV_InwardPurchase.btnSave.Text = "Update";
                        MainForm.objINV_InwardPurchase.varID = Convert.ToInt32(grdInwardQueueList.SelectedRows[0].Cells["ID"].Value);
                        MainForm.objINV_InwardPurchase.varConcernId = Convert.ToInt32(grdInwardQueueList.SelectedRows[0].Cells["Concern ID"].Value);
                        MainForm.objINV_InwardPurchase.varLocationId = Convert.ToInt32(grdInwardQueueList.SelectedRows[0].Cells["Location ID"].Value);
                        MainForm.objINV_InwardPurchase.varSupplierId = Convert.ToInt32(grdInwardQueueList.SelectedRows[0].Cells["SPID"].Value);
                        MainForm.objINV_InwardPurchase.varScheduleId = Convert.ToInt32(grdInwardQueueList.SelectedRows[0].Cells["SPSCID"].Value);
                        MainForm.objINV_InwardPurchase.varGRNPurchaseFlag = Convert.ToInt32(grdInwardQueueList.SelectedRows[0].Cells["Type ID"].Value);
                        MainForm.objINV_InwardPurchase.varRemarkFlag = 2;
                        MainForm.objINV_InwardPurchase.txtConcern.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Con"].Value);
                        MainForm.objINV_InwardPurchase.txtStockLocation.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Location"].Value);
                        MainForm.objINV_InwardPurchase.dpGRNDate.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Trans Date"].Value);
                        MainForm.objINV_InwardPurchase.txtGRNNo.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Trans No."].Value);
                        //MainForm.objINV_InwardPurchase.dpGRNDate.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["GRN Date"].Value);
                        //MainForm.objINV_InwardPurchase.txtGRNNo.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["GRN No."].Value);
                        MainForm.objINV_InwardPurchase.dpInvoiceDate.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Inv Date"].Value);
                        MainForm.objINV_InwardPurchase.txtInvoiceNo.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Inv No."].Value);
                        MainForm.objINV_InwardPurchase.dpVoucherDate.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Trans Date"].Value);
                        MainForm.objINV_InwardPurchase.txtVoucherNo.Text = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Trans No."].Value);
                        MainForm.objINV_InwardPurchase.varGIPTransDate = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Trans Date"].Value);

                        picLoader.Visible = false;
                        picLoader.SendToBack();
                        objMainForm.CenterEntryForm(this, MainForm.objINV_InwardPurchase);
                        MainForm.objINV_InwardPurchase.ShowDialog();
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
        }
        private void INV_InwardQueueList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    //tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    tsbEdit_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    //MainForm.objINV_InwardPurchaseList = new INV_InwardPurchaseList();
                    //MainForm.objINV_InwardPurchaseList.MdiParent = this.ParentForm;
                    //MainForm.objINV_InwardPurchaseList.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
      
        private void INV_InwardQueueList_Load(object sender, EventArgs e)
        {
            try
            {
                udfnDropDown();
                cmbConcern.SelectedValue = 1;
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                udfnDate();
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                this.ActiveControl = cmbConcern;
                if(Convert.ToInt32(cmbShow.SelectedValue)==189)
                {
                    btnPrint.Visible = true;
                    udfnProductList();
                }
                else
                {
                    btnPrint.Visible = false;
                    udfnList();
                }
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=59 AND MSTID IN (188,189)", "MST_DisplayText,MSTID", cmbShow, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=60 AND MSTID IN (190,191)", "MST_DisplayText,MSTID", cmbOrderBy, "", "MST_DisplayText", "MSTID");
                udfnUserAccess();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUserAccess()
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    if (EditAccess == false)
                    {
                        tsbEdit.Visible = EditAccess; 
                    }
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
                objMR_Master.paraFlag = 15;
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(objMR_Master);
                if (objd.Tables[0].Rows.Count > 0)
                {
                    DateTime varDate = DateTime.ParseExact(objd.Tables[0].Rows[0]["Transaction Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpToDate.MinDate = varDate;
                    dpFromDate.Text = Convert.ToString(objd.Tables[0].Rows[0]["DATE1"]);
                }
                objDServ.CloseConnection();
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                //cmbConcern.SelectedValue = 1;
                //udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDropDown()
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID=55 OR MSTID=0", "MST_DisplayText,MSTID", cmbEntryType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
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
                //MainForm.objINV_InwardPurchaseList = new INV_InwardPurchaseList();
                //MainForm.objINV_InwardPurchaseList.MdiParent = this.ParentForm;
                //MainForm.objINV_InwardPurchaseList.Show();
                this.Close();
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

        private void TxtStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
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
                if (txtStockLocation.Text.Trim() == "")
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
                        objMR_Location.paraId = 3;
                        objMR_Location.paraLocationName = txtStockLocation.Text.Trim();
                        objMR_Location.ParaFromDate = dpFromDate.Text;
                        objMR_Location.ParaToDate = dpToDate.Text;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraUserLocations = MainForm.pbUserMappedLocationIds;
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(27, Convert.ToInt32(cmbConcern.SelectedValue), 0, 3, txtStockLocation.Text.Trim(), 0, 0, 0, dpFromDate.Text, dpToDate.Text, 0);
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
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdInwardQueueList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdInwardQueueList.Columns)
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
        public void udfnDefaultProductSearchGrid()
        {
            try
            {
                DGV_ProdSearchGrid.DataSource = dtDefaultGrid;
                DGV_ProdSearchGrid.Columns["S.No."].Width = 50;
                DGV_ProdSearchGrid.Columns["Type"].Width = 80;
                DGV_ProdSearchGrid.Columns["P.I Code"].Width = 100;
                DGV_ProdSearchGrid.Columns["MRP"].Width = 80;
                DGV_ProdSearchGrid.Columns["Expiry Date"].Width = 80;
                DGV_ProdSearchGrid.Columns["Batch No."].Width = 100;
                DGV_ProdSearchGrid.Columns["Invoice No."].Width = 100;
                DGV_ProdSearchGrid.Columns["Invoice Date"].Width = 80;
                DGV_ProdSearchGrid.Columns["SLID"].Visible = false;
                DGV_ProdSearchGrid.Columns["Transaction Date"].Width = 80;
                DGV_ProdSearchGrid.Columns["Trans No."].Width = 80;
                DGV_ProdSearchGrid.Columns["Supplier"].Width = 200;
                DGV_ProdSearchGrid.Columns["Product Name"].Width = 300;           
                //DGV_ProdSearchGrid.Columns["Order By"].Visible = false;           
                DGV_ProdSearchGrid.ScrollBars = ScrollBars.Both;
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
                DGV_SearchGrid.Columns["ID"].Visible = false;
                DGV_SearchGrid.Columns["SPID"].Visible = false;
                DGV_SearchGrid.Columns["SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["Location ID"].Visible = false;
                DGV_SearchGrid.Columns["Concern ID"].Visible = false;
                DGV_SearchGrid.Columns["My Products"].Visible = false;
                DGV_SearchGrid.Columns["Type ID"].Visible = false;
                DGV_SearchGrid.Columns["Entry Type"].Width = 150;
                DGV_SearchGrid.Columns["Con"].Width = 80;
                DGV_SearchGrid.Columns["Trans Date"].Width = 100;
                DGV_SearchGrid.Columns["Trans No."].Width = 80;
                DGV_SearchGrid.Columns["Supplier"].Width = 250;
                DGV_SearchGrid.Columns["Tot Prod in Invoice"].Width = 150;
                DGV_SearchGrid.Columns["Entry Date"].Visible = false;
                DGV_SearchGrid.Columns["Created On"].Width = 140;
                DGV_SearchGrid.Columns["GSTIN"].Visible = false;
                DGV_SearchGrid.Columns["Full Status"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 60;
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
                epQueueList.Clear();
                grdInwardQueueList.DataSource = null;
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
                        epQueueList.SetError(txtSupplier, "Invalid supplier.");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplier.ShowAlways = true;
                        tpSupplier.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        Varflag = 1;
                    }
                    else
                    {
                        epQueueList.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White;

                    }
                    //VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                }
                if (Varflag == 0)
                {
                    btnView.Enabled = false;
                    varviewtype = 3;
                    //SPDataService objdserv = new SPDataService();
                    //objDs = objdserv.udfnGrnListLoad(varviewtype, 0, 0, Convert.ToInt32(cmbConcern.SelectedValue), 0, dpFromDate.Text, dpToDate.Text, 0, Convert.ToInt32(cmbEntryType.SelectedValue), 0, "", "", 0,Convert.ToInt32(lblStockLocationCode.Text));
                    //objdserv.CloseConnection();
                    SPDataService objdserv = new SPDataService();
                    TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                    objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                    objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_GoodsInward_Purchase.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_GoodsInward_Purchase.ParaFromDate = Convert.ToString(dpFromDate.Text);
                    objTRN_GoodsInward_Purchase.ParaToDate = Convert.ToString(dpToDate.Text);
                    objTRN_GoodsInward_Purchase.paraSLID = Convert.ToInt32(lblStockLocationCode.Text);
                    objTRN_GoodsInward_Purchase.paraProductId = Convert.ToInt32(varPRID);
                    objTRN_GoodsInward_Purchase.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    objTRN_GoodsInward_Purchase.paraTypeID = Convert.ToInt32(cmbEntryType.SelectedValue);
                    objTRN_GoodsInward_Purchase.paraUserLocations = MainForm.pbUserMappedLocationIds;
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
                                grdInwardQueueList.DataSource = objDs.Tables[0];
                                grdInwardQueueList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                // grdInwardQueueList.Columns["GRN No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //grdInwardQueueList.Columns["GRN Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //grdInwardQueueList.Columns["Vouc Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInwardQueueList.Columns["Inv Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdInwardQueueList.Columns["Tot Pro in Invoice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdInwardQueueList.Columns["Con"].Width = 80;
                                grdInwardQueueList.Columns["Trans Date"].Width = 80;
                                //grdInwardQueueList.Columns["Vouc Date"].Width = 80;
                                grdInwardQueueList.Columns["Trans No."].Width = 70;
                                //grdInwardQueueList.Columns["Vouc No."].Width = 70;
                                //grdInwardQueueList.Columns["GRN Date"].Width = 100;
                                //grdInwardQueueList.Columns["GRN No."].Width = 80;
                                grdInwardQueueList.Columns["Supplier"].Width = 250;
                                grdInwardQueueList.Columns["Tot Pro in Invoice"].Width = 150;
                                ///   grdInwardQueueList.Columns["Created By"].Width = 110;
                                grdInwardQueueList.Columns["Created By"].Width = 200;
                                grdInwardQueueList.Columns["GSTIN"].Visible = false;
                                grdInwardQueueList.Columns["Location"].Width = 170;
                                grdInwardQueueList.Columns["S.No."].Width = 60;
                                grdInwardQueueList.Columns["Trans Date"].Width = 120;
                                grdInwardQueueList.Columns["ID"].Visible = false;
                                grdInwardQueueList.Columns["SPID"].Visible = false;
                                grdInwardQueueList.Columns["SPSCID"].Visible = false;
                                grdInwardQueueList.Columns["SPSCID"].Visible = false;
                                grdInwardQueueList.Columns["Location ID"].Visible = false;
                                grdInwardQueueList.Columns["Concern ID"].Visible = false;
                                grdInwardQueueList.Columns["My Products"].Visible = false;
                                grdInwardQueueList.Columns["Type ID"].Visible = false;
                                grdInwardQueueList.Columns["Entry Date"].Visible = false;
                                grdInwardQueueList.Columns["UnReadable"].Visible = false;
                                grdInwardQueueList.Columns["Full Status"].Visible = false;
                                grdInwardQueueList.Columns["Full Reason"].Visible = false;
                                grdInwardQueueList.Columns["Transaction Date"].Visible = false;
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
                    grdInwardQueueList.DataSource = null;
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
                this.ActiveControl = btnView;
            }
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
                varviewtype = 6;
                grdProDetails.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                objTRN_GoodsInward_Purchase.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_GoodsInward_Purchase.ParaFromDate = Convert.ToString(dpFromDate.Text);
                objTRN_GoodsInward_Purchase.ParaToDate = Convert.ToString(dpToDate.Text);
                objTRN_GoodsInward_Purchase.paraProductId = varPRID;
                objTRN_GoodsInward_Purchase.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_GoodsInward_Purchase.paraSLID = Convert.ToInt32(lblStockLocationCode.Text);
                objTRN_GoodsInward_Purchase.paraOrderBy = Convert.ToInt32(cmbOrderBy.SelectedValue);
                objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
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
                            grdProDetails.DataSource = objDs.Tables[0];
                            grdProDetails.Columns["S.No."].Width = 50;
                            grdProDetails.Columns["Type"].Width = 80;
                            grdProDetails.Columns["Product Name"].Width = 300;
                            grdProDetails.Columns["P.I Code"].Width = 100;
                            grdProDetails.Columns["Supplier"].Width = 200;
                            grdProDetails.Columns["MRP"].Width = 80;
                            grdProDetails.Columns["Unit"].Width = 50;
                            grdProDetails.Columns["Expiry Date"].Width = 80;
                            grdProDetails.Columns["Batch No."].Width = 100;
                            grdProDetails.Columns["Invoice No."].Width = 100;
                            grdProDetails.Columns["Invoice Date"].Width = 80;
                            grdProDetails.Columns["Transaction No."].Width = 90;
                            grdProDetails.Columns["Transaction Date"].Width = 80;
                            grdProDetails.Columns["SLID"].Visible = false;
                            //grdProDetails.Columns["Order By"].Visible = false;
                            grdProDetails.Columns["Expiry Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["Transaction Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["Invoice Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdProDetails.Columns["MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbShow.SelectedValue) == 189)
                {
                    grdInwardQueueList.Visible = false;
                    DGV_SearchGrid.Visible = false;
                    grdProDetails.Visible = true;
                    DGV_ProdSearchGrid.Visible = true;
                    btnPrint.Visible = true;
                    RPTViewer.Visible = false;
                    RPTViewer.SendToBack();
                    udfnProductList();
                }
                else
                {
                    grdInwardQueueList.Visible = true;
                    DGV_SearchGrid.Visible = true;
                    grdProDetails.Visible = false;
                    DGV_ProdSearchGrid.Visible = false;
                    btnPrint.Visible = false;
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
        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int varSupplierId = 0; string varScheduleId = "0";
                if (txtSupplier.Text.Trim() != "")
                {
                    varSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    varScheduleId = lblschedule.Text;
                }
                if (varUpDownKey == 0)
                {
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 54;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraLocationId = Convert.ToInt32(lblStockLocationCode.Text);
                        objMR_Product.paraProductName = txtProductName.Text;
                        objMR_Product.ParaFromDate = dpFromDate.Text;
                        objMR_Product.ParaToDate = dpToDate.Text;
                        objMR_Product.ParaSupplierId = varSupplierId;
                        objMR_Product.ParaScheduleid = varScheduleId;
                        objMR_Product.paraId = 0;
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
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
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
        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
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
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.White;
                if (txtProductName.Text.Trim() == "")
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
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdInwardQueueList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdInwardQueueList);
                objDser.CloseConnection();
                grdInwardQueueList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdInwardQueueList.ColumnCount > 0)
                {
                    grdInwardQueueList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdInwardQueueList.HorizontalScrollingOffset;
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
                grdInwardQueueList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdInwardQueueList);
                objDser.CloseConnection();
                grdInwardQueueList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataGridViewColumn newColumn = grdInwardQueueList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdInwardQueueList.SortedColumn;
                    ListSortDirection direction;

                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdInwardQueueList.SortOrder == SortOrder.Ascending)
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
                        grdInwardQueueList.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                        DGV_SearchGrid.HorizontalScrollingOffset = grdInwardQueueList.HorizontalScrollingOffset;
                        DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdInwardQueueList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdInwardQueueList);
                objDser.CloseConnection();
                grdInwardQueueList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdInwardQueueList)
        {
            try
            {
                var vScrollbar = grdInwardQueueList.Controls.OfType<VScrollBar>().First();
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
        private void GrdInwardQueueList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdInwardQueueList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdInwardQueueList.Width > grdInwardQueueList.HorizontalScrollingOffset && grdInwardQueueList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnProductscrollVisible(DGV_SearchGrid, grdInwardQueueList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdInwardQueueList_DoubleClick(object sender, EventArgs e)
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
        private void GrdInwardQueueList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //for (int i = 0; i < grdInwardQueueList.Rows.Count; i++)
                //{
                //    if (Convert.ToString(grdInwardQueueList.Rows[i].Cells["Status ID"].Value) == "1")
                //    {
                //        grdInwardQueueList.Rows[i].Cells["Status"].Style.BackColor = Color.LimeGreen;
                //        grdInwardQueueList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                //    }
                //    else
                //    {
                //        grdInwardQueueList.Rows[i].Cells["Status"].Style.BackColor = Color.Tomato;
                //        grdInwardQueueList.Rows[i].Cells["Status"].Style.ForeColor = Color.White;
                //    }
                //}
                for (int i = 0; i < grdInwardQueueList.Rows.Count; i++)
                {
                    if (Convert.ToInt32(grdInwardQueueList.Rows[i].Cells["UnReadable"].Value) > 0 )
                    {
                        grdInwardQueueList.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                        grdInwardQueueList.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                grdInwardQueueList.Columns["clmPrint"].Frozen = true;
                grdInwardQueueList.Columns["clmPrint"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdInwardQueueList.Columns["S.No."].Frozen = true;
                grdInwardQueueList.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdInwardQueueList.Columns["Con"].Frozen = true;
                grdInwardQueueList.Columns["Con"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardQueueList.Columns["Trans No."].Frozen = true;
                //grdInwardQueueList.Columns["Trans No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardQueueList.Columns["Trans Date"].Frozen = true;
                //grdInwardQueueList.Columns["Trans Date"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardQueueList.Columns["Vouc No."].Frozen = true;
                //grdInwardQueueList.Columns["Vouc No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardQueueList.Columns["Vouc Date"].Frozen = true;
                //grdInwardQueueList.Columns["Vouc Date"].DefaultCellStyle.BackColor = Color.AliceBlue;
                //grdInwardQueueList.Columns["Supplier"].Frozen = true;
                //grdInwardQueueList.Columns["Supplier"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdInwardQueueList.Columns["Status"].Frozen = true;
                grdInwardQueueList.Columns["Status"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdInwardQueueList.Columns["clmPrint"].Resizable = DataGridViewTriState.False;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdInwardQueueList.ClearSelection();
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
                    cmbShow.Focus();
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

        private void GrdInwardQueueList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tsbEdit_Click(sender, e);
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
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    objMR_Supplier.ParaToDate = dpToDate.Text;
                    objMR_Supplier.paraFlag = 8;
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
                DGV_FilterLocation.Visible = false;
                DGV_FilterLocation.DataSource = null;
                DGV_FilterProduct.DataSource = null;
                DGV_FilterProduct.Visible = false;
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
                if (txtSupplier.Text.Trim() == "")
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
                    if (cmbOrderBy.Enabled==true)
                    {
                        cmbOrderBy.Focus();
                    }
                    else
                    {
                        btnView.Focus();
                    }
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

        private void CmbOrderBy_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbOrderBy.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderBy_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbOrderBy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbOrderBy_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderBy.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbOrderBy.Select(int.MaxValue, 0)));
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
                if(Convert.ToInt32(cmbShow.SelectedValue)==188)
                {
                    cmbOrderBy.Enabled = false;
                    btnPrint.Visible = false;
                    //grdInwardQueueList.Visible = true;
                    //DGV_SearchGrid.Visible = true;
                    //grdProDetails.Visible = false;
                    //DGV_ProdSearchGrid.Visible = false;
                }
                else
                {
                    cmbOrderBy.Enabled = true;
                    btnPrint.Visible = true;
                    //grdInwardQueueList.Visible = false;
                    //DGV_SearchGrid.Visible = false;
                    //grdProDetails.Visible = true;
                    //DGV_ProdSearchGrid.Visible = true;
                    //udfnProductList();
                }
                //if(Convert.ToInt32(cmbShow.SelectedValue)==189)
                //{
                //    grdInwardQueueList.Visible = false;
                //    DGV_SearchGrid.Visible = false;
                //    grdProDetails.Visible = true;
                //    DGV_ProdSearchGrid.Visible = true;
                //}
                //else
                //{
                //    grdInwardQueueList.Visible = true;
                //    DGV_SearchGrid.Visible = true;
                //    grdProDetails.Visible = false;
                //    DGV_ProdSearchGrid.Visible = false;
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

        private void DGV_ProdSearchGrid_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    if (oldColumn == newColumn && grdProDetails.SortOrder == SortOrder.Ascending)
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
                grdProDetails.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_ProdSearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_ProdSearchGrid.HorizontalScrollingOffset = grdProDetails.HorizontalScrollingOffset;
                DGV_ProdSearchGrid.FirstDisplayedScrollingRowIndex = 0;
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
        private void udfnProdSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdProDetails, DGV_ProdSearchGrid);
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
                    DGV_ProdSearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                    //DGV__SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                    for (int i = 2; i < visibleColumns.Count; i++)
                    {
                        DGV_ProdSearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    if (lblNoRecordsFound.Visible == false)
                    {
                        DGV_ProdSearchGrid.Columns["S.No."].ReadOnly = true;
                    }
                    DGV_ProdSearchGrid.Columns[0].ReadOnly = true;
                    //DGV__SearchGrid.Columns[1].ReadOnly = true;
                    DGV_ProdSearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                    //DGV__SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                objTRN_GoodsInward_Purchase.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_GoodsInward_Purchase.ParaFromDate = Convert.ToString(dpFromDate.Text);
                objTRN_GoodsInward_Purchase.ParaToDate = Convert.ToString(dpToDate.Text);
                objTRN_GoodsInward_Purchase.paraProductId = varPRID;
                objTRN_GoodsInward_Purchase.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_GoodsInward_Purchase.paraSLID = Convert.ToInt32(lblStockLocationCode.Text);
                objTRN_GoodsInward_Purchase.paraOrderBy = Convert.ToInt32(cmbOrderBy.SelectedValue);
                objTRN_GoodsInward_Purchase.paraStatusID = 0;
                objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                objDs = objdserv.udfnInwardPurchaseList(objTRN_GoodsInward_Purchase);
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
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_GoodsInwardQueue_Products.rpt");
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraCompanyId", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("ParaFromDate", Convert.ToString(dpFromDate.Text));
                    objBillreport.SetParameterValue("ParaToDate", Convert.ToString(dpToDate.Text));
                    objBillreport.SetParameterValue("paraProductId", varPRID);
                    objBillreport.SetParameterValue("ParaSupplierId", Convert.ToInt32(lblSupplierCode.Text)); 
                    objBillreport.SetParameterValue("paraSLID", Convert.ToInt32(lblStockLocationCode.Text)); 
                    objBillreport.SetParameterValue("paraOrderBy", Convert.ToInt32(cmbOrderBy.SelectedValue)); 
                    objBillreport.SetParameterValue("paraStatusID", 0); 
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
                picLoader.SendToBack();
                btnPrint.Enabled = true;
                btnPrint.Focus();
                GC.Collect();
            }
        }

        private void GrdInwardQueueList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdInwardQueueList.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPrint":
                            try
                            {
                                string TransactionDate = "0", TypeID = "0", ConcerID = "0", varStockLocationId = "0", varTransactionNo = "0", ID = "0", varSupplierName = "", varVoucherNo = "0", varVoucherDate = "0";
                                ID = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["ID"].Value.ToString());
                                TypeID = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Type ID"].Value);
                                ConcerID = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Concern ID"].Value);
                                varStockLocationId = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Location ID"].Value);
                                varTransactionNo = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Trans No."].Value);
                                TransactionDate = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Trans Date"].Value);
                                varSupplierName = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Supplier"].Value);
                                varVoucherNo = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Trans No."].Value);
                                varVoucherDate = Convert.ToString(grdInwardQueueList.SelectedRows[0].Cells["Trans Date"].Value);
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
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_GoodsInwardQueue_IndividualPrint.rpt");
                                    varHeader = "Inward Queue";

                                    objBillreport.SetParameterValue("paraID", Convert.ToInt32(ID));
                                    objBillreport.SetParameterValue("paraFlag", Convert.ToInt32(TypeID));
                                    objBillreport.SetParameterValue("paraCompanyId", Convert.ToInt32(ConcerID));
                                    objBillreport.SetParameterValue("paraSLID", Convert.ToInt32(varStockLocationId));
                                    objBillreport.SetParameterValue("paraTransactionNo", varTransactionNo);
                                    objBillreport.SetParameterValue("paraTransactionDate", TransactionDate);
                                    objBillreport.SetParameterValue("paraVoucherDate", varVoucherDate);
                                    objBillreport.SetParameterValue("paraVoucherNo", varVoucherNo);
                                    objBillreport.SetParameterValue("paraSupplier", varSupplierName);
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
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

        private void GrdInwardQueueList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == grdInwardQueueList.Columns["Status"].Index)
                {
                    var cell = grdInwardQueueList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ToolTipText = grdInwardQueueList.Rows[e.RowIndex].Cells["Full Status"].Value.ToString();
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

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdInwardQueueList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdInwardQueueList);
                objDser.CloseConnection();
                grdInwardQueueList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                    int offSetValue = grdInwardQueueList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdInwardQueueList.Width > grdInwardQueueList.HorizontalScrollingOffset && grdInwardQueueList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdInwardQueueList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
