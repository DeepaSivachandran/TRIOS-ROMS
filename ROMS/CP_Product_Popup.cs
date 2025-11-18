using ROMS.Model;
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
    public partial class CP_Product_Popup : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        public int varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyProduct = 0, varUpDownKeyBrand = 0, varUpDownKeySupplier = 0;
        Boolean BlnSearchImageYN = false;
        public CP_Product_Popup()
        {
            InitializeComponent();
        }

        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtGroup)
                {
                    varUpDownKeyGroup = 0;
                    DGV_FilterGroup.DataSource = null;
                    DGV_FilterGroup.Visible = false;
                }
                if (skipControl != txtSubGroup)
                {
                    varUpDownKeySubgroup = 0;
                    DGV_FilterSubgroup.DataSource = null;
                    DGV_FilterSubgroup.Visible = false;
                }
                if (skipControl != txtProductName)
                {
                    varUpDownKeyProduct = 0;
                    DGV_FilterProduct.DataSource = null;
                    DGV_FilterProduct.Visible = false;
                }
                if (skipControl != txtBrand)
                {
                    varUpDownKeyBrand = 0;
                    DGV_FilterBrand.DataSource = null;
                    DGV_FilterBrand.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtProductName.BackColor = Color.LemonChiffon;
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
                varUpDownKeyProduct = 1;
                udfnListviewProduct();
                btnView.Focus();
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
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
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
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
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
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text.Trim() != "")
                {
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                }
                txtGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Product_Popup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
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

        private void CP_Product_Popup_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (132) AND MSTID<>-1 ORDER BY MSTID ASC", "MST_DisplayText,MSTID", cmbSearchType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                this.ActiveControl = txtProductName;
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
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdItemList.DataSource = null;

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                int varGroupId = 0, varSubgroupId = 0, varBrandId = 0, varProductId = 0, varSupplierId = 0, varScheduleId = 0;
                if(txtGroup.Text.Trim()!="")
                {
                    varGroupId = Convert.ToInt32(lblGroupCode.Text);
                }
                if(txtSubGroup.Text.Trim()!="")
                {
                    varSubgroupId = Convert.ToInt32(lblSubGroupCode.Text);
                }
                if(txtBrand.Text.Trim()!="")
                {
                    varBrandId = Convert.ToInt32(lblBrandCode.Text);
                }
                if(txtProductName.Text.Trim()!="")
                {
                    varProductId = Convert.ToInt32(lblProductcode.Text);
                }
                if(txtSupplier.Text.Trim()!="")
                {
                    varSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    varScheduleId = Convert.ToInt32(lblschedleCode.Text);
                }
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 83;
                objMR_Product.paraGroup = varGroupId;
                objMR_Product.paraSubgroup = varSubgroupId;
                objMR_Product.paraBrandID = varBrandId;
                objMR_Product.ParaProductCode = varProductId;
                objMR_Product.ParaSupplierId = varSupplierId;
                objMR_Product.ParaScheduleid = Convert.ToString(varScheduleId);
                //objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                //objMR_Product.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objDs = objdserv.udfnproductmasterlist(objMR_Product);
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
                            grdItemList.DataSource = objDs.Tables[0];
                            grdItemList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdItemList.Columns["W.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["R.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdItemList.Columns["S.No."].Frozen = true;
                            //grdItemList.Columns["Concern"].Frozen = true;
                            grdItemList.Columns["P.I Code"].Frozen = true;
                            grdItemList.Columns["Product Name"].Frozen = true;
                            grdItemList.Columns["S.No."].Width = 50;
                            grdItemList.Columns["P.I Code"].Width = 100;
                            grdItemList.Columns["Product Name"].Width = 300;
                            grdItemList.Columns["Supplier"].Width = 300;
                            grdItemList.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
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
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["P.I Code"].Width = 100;
                DGV_SearchGrid.Columns["Product Name"].Width = 300;
                DGV_SearchGrid.Columns["Supplier"].Width = 300;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
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
                    udfnGridSearchHeading(grdItemList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdItemList.Columns)
                    {
                        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    DGV_SearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
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
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void txtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyGroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterGroup.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterGroup.Visible == false)
                {
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterGroup.Focus();
                }
                if (DGV_FilterGroup.CurrentCell == null && DGV_FilterGroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterGroup.Focus();
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }
                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyGroup = 1;
                                    udfnGroupAutocomplete();
                                    DGV_FilterGroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtGroup.Focus();
                    //txtGroup.SelectionStart = txtGroup.Text.Length;
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
        private void txtGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyGroup == 0)
                {
                    //lvGroup.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnGroupList(7, 0, 0, txtGroup.Text, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterGroup.Visible = true;
                                    DGV_FilterGroup.DataSource = objDs.Tables[0];
                                    DGV_FilterGroup.Columns["PRGID"].Visible = false;
                                    DGV_FilterGroup.Columns["PRG_EName"].HeaderText = "Group English Name";
                                    DGV_FilterGroup.Columns["PRG_TName"].HeaderText = "Group Tamil Name";
                                    DGV_FilterGroup.Columns["PRG_EName"].Width = 130;
                                    DGV_FilterGroup.Columns["PRG_TName"].Width = 130;
                                    DGV_FilterGroup.Columns["PRG_EName"].DisplayIndex = 0;
                                    DGV_FilterGroup.Columns["PRG_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterGroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterGroup.Visible = false;
                                    DGV_FilterGroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterGroup.Visible = false;
                                DGV_FilterGroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterGroup.Visible = false;
                            DGV_FilterGroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterGroup.Visible = false;
                        DGV_FilterGroup.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyGroup = 1;
                udfnGroupAutocomplete();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterGroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterGroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyGroup = 1;
                    }
                    else
                    {
                        varUpDownKeyGroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            txtGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterGroup.Rows.Count) DGV_FilterGroup.CurrentCell = DGV_FilterGroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterGroup.Rows.Count))
                            {
                                txtGroup.Text = DGV_FilterGroup.Rows[RowIndex].Cells["PRG_EName"].Value.ToString();
                            }

                            txtGroup.Focus();
                            txtGroup.SelectionStart = txtGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterGroup.Rows.Count > 0)
                                {
                                    varUpDownKeyGroup = 1;
                                    udfnGroupAutocomplete();
                                    DGV_FilterGroup.Visible = false;
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
        public void udfnGroupAutocomplete()
        {
            try
            {
                if (txtGroup.Text.Trim() != "")
                {
                    lblGroupCode.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRGID"].Value.ToString();
                    txtGroup.Text = DGV_FilterGroup.SelectedRows[0].Cells["PRG_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySubgroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSubgroup.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSubgroup.Visible == false)
                {
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSubgroup.Focus();
                }
                if (DGV_FilterSubgroup.CurrentCell == null && DGV_FilterSubgroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSubgroup.Focus();
                    int RowIndex = DGV_FilterSubgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSubgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySubgroup = 1;
                    }
                    else
                    {
                        varUpDownKeySubgroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }
                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSubgroup.Rows.Count > 0)
                                {
                                    varUpDownKeySubgroup = 1;
                                    udfnSubGroupAutocomplete();
                                    DGV_FilterSubgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSubGroup.Focus();
                    //txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
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
        private void txtSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeySubgroup == 0)
                {
                    if (txtGroup.Text.Trim() == "")
                    {
                        lblGroupCode.Text = "0";
                    }
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtSubGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupCode.Text), 0, txtSubGroup.Text, 0, 0, 0, 0, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterSubgroup.Visible = true;
                                    DGV_FilterSubgroup.DataSource = objDs.Tables[0];
                                    DGV_FilterSubgroup.Columns["PRSGID"].Visible = false;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].HeaderText = "Subgroup English Name";
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].HeaderText = "Subgroup Tamil Name";
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].Width = 150;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].Width = 200;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].DisplayIndex = 0;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterSubgroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSubgroup.Visible = false;
                                    DGV_FilterSubgroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterSubgroup.Visible = false;
                                DGV_FilterSubgroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterSubgroup.Visible = false;
                            DGV_FilterSubgroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterSubgroup.Visible = false;
                        DGV_FilterSubgroup.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_FilterSubgroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySubgroup = 1;
                udfnSubGroupAutocomplete();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSubgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSubgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySubgroup = 1;
                    }
                    else
                    {
                        varUpDownKeySubgroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            txtSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtSubGroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtSubGroup.Focus();
                            txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSubgroup.Rows.Count > 0)
                                {
                                    varUpDownKeySubgroup = 1;
                                    udfnSubGroupAutocomplete();
                                    DGV_FilterSubgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
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
        public void udfnSubGroupAutocomplete()
        {
            try
            {
                if (txtSubGroup.Text.Trim() != "")
                {
                    lblSubGroupCode.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSGID"].Value.ToString();
                    txtSubGroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyBrand = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterBrand.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterBrand.Visible == false)
                {
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterBrand.Focus();
                }
                if (DGV_FilterBrand.CurrentCell == null && DGV_FilterBrand.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterBrand.Focus();
                    int RowIndex = DGV_FilterBrand.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterBrand.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyBrand = 1;
                    }
                    else
                    {
                        varUpDownKeyBrand = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterBrand.CurrentCell = DGV_FilterBrand.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtBrand.Text = DGV_FilterBrand.Rows[RowIndex].Cells["BD_EName"].Value.ToString();
                            }
                            txtBrand.Focus();
                            txtBrand.SelectionStart = txtBrand.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterBrand.Rows.Count) DGV_FilterBrand.CurrentCell = DGV_FilterBrand.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterBrand.Rows.Count))
                            {
                                txtBrand.Text = DGV_FilterBrand.Rows[RowIndex].Cells["BD_EName"].Value.ToString();
                            }

                            txtBrand.Focus();
                            txtBrand.SelectionStart = txtBrand.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterBrand.Rows.Count > 0)
                                {
                                    varUpDownKeyBrand = 1;
                                    udfnBrandAutocomplete();
                                    DGV_FilterBrand.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtBrand.Focus();
                    //txtBrand.SelectionStart = txtBrand.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtBrand.SelectedText = true;
                        TextBox txtBrand = sender as TextBox;
                        txtBrand.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
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

        private void txtBrand_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBrand.BackColor = Color.White;
                if (txtBrand.Text == "")
                {
                    lblBrandCode.Text = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void txtBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyBrand == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtBrand.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnBrandList(6, "0", 0, 0, 0, txtBrand.Text.Trim(), 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterBrand.Visible = true;
                                    DGV_FilterBrand.DataSource = objDs.Tables[0];
                                    DGV_FilterBrand.Columns["BDID"].Visible = false;
                                    DGV_FilterBrand.Columns["BD_EName"].HeaderText = "Brand English Name";
                                    DGV_FilterBrand.Columns["BD_TName"].HeaderText = "Brand Tamil Name";
                                    DGV_FilterBrand.Columns["BD_EName"].Width = 180;
                                    DGV_FilterBrand.Columns["BD_TName"].Width = 200;
                                    DGV_FilterBrand.Columns["BD_EName"].DisplayIndex = 0;
                                    DGV_FilterBrand.Columns["BD_TName"].DisplayIndex = 1;
                                    DGV_FilterBrand.Columns["BD_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterBrand.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterBrand.Visible = false;
                                    DGV_FilterBrand.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterBrand.Visible = false;
                                DGV_FilterBrand.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterBrand.Visible = false;
                            DGV_FilterBrand.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterBrand.Visible = false;
                        DGV_FilterBrand.DataSource = null;
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

        private void DGV_FilterBrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyBrand = 1;
                udfnBrandAutocomplete();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterBrand.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterBrand.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyBrand = 1;
                    }
                    else
                    {
                        varUpDownKeyBrand = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterBrand.CurrentCell = DGV_FilterBrand.Rows[RowIndex].Cells[ClmIndex];

                            txtBrand.Text = DGV_FilterBrand.SelectedRows[0].Cells["BD_EName"].Value.ToString();

                            txtBrand.Focus();
                            txtBrand.SelectionStart = txtBrand.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterBrand.Rows.Count) DGV_FilterBrand.CurrentCell = DGV_FilterBrand.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterBrand.Rows.Count))
                            {
                                txtBrand.Text = DGV_FilterBrand.Rows[RowIndex].Cells["BD_EName"].Value.ToString();
                            }

                            txtBrand.Focus();
                            txtBrand.SelectionStart = txtBrand.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterBrand.Rows.Count > 0)
                                {
                                    varUpDownKeyBrand = 1;
                                    udfnBrandAutocomplete();
                                    DGV_FilterBrand.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtBrand = sender as TextBox;
                        txtBrand.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
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
        public void udfnBrandAutocomplete()
        {
            try
            {
                if (txtBrand.Text.Trim() != "")
                {
                    txtBrand.Text = DGV_FilterBrand.SelectedRows[0].Cells["BD_EName"].Value.ToString();
                    lblBrandCode.Text = DGV_FilterBrand.SelectedRows[0].Cells["BDID"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
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

        private void grdItemList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdItemList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdItemList.Width > grdItemList.HorizontalScrollingOffset && grdItemList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdItemList);
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
                var vScrollbar = grdItemList.Controls.OfType<VScrollBar>().First();
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
                            if (DGV_SearchGrid.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                            {
                                DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                            }
                            else { DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = ""; }
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

        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    DataService objDser = new DataService();
                    grdItemList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdItemList);
                    objDser.CloseConnection();
                    grdItemList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (e.RowIndex < 0 || e.ColumnIndex < 0)
                        return;
                    if (!(e.ColumnIndex == 0))

                        if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)
                        {
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All
                                & ~(DataGridViewPaintParts.ContentForeground));
                            e.Handled = true;
                        }

                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                    if (DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                    {
                        if (e.Value == null || !(e.Value is Image))
                        {
                            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblNoRecordsFound.Visible == false)
            {
                DataGridViewColumn newColumn = grdItemList.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdItemList.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdItemList.SortOrder == SortOrder.Ascending)
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
                    grdItemList.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdItemList.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    if (grdItemList.ColumnCount > 0)
                    {
                        grdItemList.Columns[e.Column.Index].Width = e.Column.Width;
                        DGV_SearchGrid.HorizontalScrollingOffset = grdItemList.HorizontalScrollingOffset;
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
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdItemList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdItemList);
                objDser.CloseConnection();
                grdItemList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                DataService objDser = new DataService();
                grdItemList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdItemList);
                objDser.CloseConnection();
                grdItemList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                    int offSetValue = grdItemList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdItemList.Width > grdItemList.HorizontalScrollingOffset && grdItemList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdItemList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSupplier_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySupplier = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSupplier.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSupplier.Visible == false)
                {
                    btnView.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSupplier.Focus();
                }
                if (DGV_FilterSupplier.CurrentCell == null && DGV_FilterSupplier.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSupplier.Focus();
                    int RowIndex = DGV_FilterSupplier.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSupplier.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySupplier = 1;
                    }
                    else
                    {
                        varUpDownKeySupplier = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSupplier.CurrentCell = DGV_FilterSupplier.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSupplier.Text = DGV_FilterSupplier.Rows[RowIndex].Cells["SP_NAME"].Value.ToString();
                            }
                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSupplier.Rows.Count) DGV_FilterSupplier.CurrentCell = DGV_FilterSupplier.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSupplier.Rows.Count))
                            {
                                txtSupplier.Text = DGV_FilterSupplier.Rows[RowIndex].Cells["SP_NAME"].Value.ToString();
                            }

                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSupplier.Rows.Count > 0)
                                {
                                    varUpDownKeySupplier = 1;
                                    udfnListViewData();
                                    DGV_FilterSupplier.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSupplier.Focus();
                    //txtSupplier.SelectionStart = txtSupplier.Text.Length;
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
        private void txtSupplier_Leave(object sender, EventArgs e)
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
        private void txtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //LV_Supplier.BringToFront();
                //RPTViewer.SendToBack();
                //LV_Supplier.Items.Clear();
                if (varUpDownKeySupplier == 0)
                {
                    if (txtSupplier.Text.Length > 0)
                    {
                        MR_Supplier objMR_Supplier = new MR_Supplier();
                        objMR_Supplier.ViewType = 15;
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
                                    DGV_FilterSupplier.Visible = true;
                                    DGV_FilterSupplier.DataSource = objDs.Tables[0];
                                    DGV_FilterSupplier.Columns["SPID"].Visible = false;
                                    DGV_FilterSupplier.Columns["SPSCID"].Visible = false;
                                    DGV_FilterSupplier.Columns["SupplierName"].Visible = false;
                                    DGV_FilterSupplier.Columns["ScheduleName"].Visible = false;
                                    DGV_FilterSupplier.Columns["SP_Name1"].Visible = false;
                                    DGV_FilterSupplier.Columns["SP_NAME"].HeaderText = "Supplier";
                                    DGV_FilterSupplier.Columns["SP_NAME"].Width = 260;
                                    DGV_FilterSupplier.Columns["SP_NAME"].DisplayIndex = 0;
                                    DGV_FilterSupplier.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSupplier.Visible = false;
                                    DGV_FilterSupplier.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterSupplier.Visible = false;
                                DGV_FilterSupplier.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterSupplier.Visible = false;
                            DGV_FilterSupplier.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterSupplier.Visible = false;
                        DGV_FilterSupplier.DataSource = null;
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

        private void DGV_FilterSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySupplier = 1;
                udfnListViewData();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSupplier.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSupplier.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySupplier = 1;
                    }
                    else
                    {
                        varUpDownKeySupplier = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSupplier.CurrentCell = DGV_FilterSupplier.Rows[RowIndex].Cells[ClmIndex];

                            txtSupplier.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SP_NAME"].Value.ToString();

                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSupplier.Rows.Count) DGV_FilterSupplier.CurrentCell = DGV_FilterSupplier.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSupplier.Rows.Count))
                            {
                                txtSupplier.Text = DGV_FilterSupplier.Rows[RowIndex].Cells["SP_NAME"].Value.ToString();
                            }

                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSupplier.Rows.Count > 0)
                                {
                                    varUpDownKeySupplier = 1;
                                    udfnListViewData();
                                    DGV_FilterSupplier.Visible = false;
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

        private void cmbSearchType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSearchType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSearchType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtGroup.Visible == true)
                    {
                        txtGroup.Focus();
                    }
                    else if (txtSubGroup.Visible == true)
                    {
                        txtSubGroup.Focus();
                    }
                    else if (txtBrand.Visible == true)
                    {
                        txtBrand.Focus();
                    }
                    else if (txtProductName.Visible == true)
                    {
                        txtProductName.Focus();
                    }
                    else if (txtSupplier.Visible == true)
                    {
                        txtSupplier.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSearchType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSearchType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbSearchType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSearchType.SelectedValue == null)
                    return;

                int selectedType = Convert.ToInt32(cmbSearchType.SelectedValue);

                ResetAllSearchFields();

                switch (selectedType)
                {
                    case 425: // GROUP
                        lblDGroupName.Visible = true;
                        txtGroup.Visible = true;
                        //lblDGroupName.Location = new Point(140, 22);
                        //txtGroup.Location = new Point(140, 45);
                        //DGV_FilterGroup.Location = new Point(152, 84);
                        //txtGroup.Focus();
                        break;

                    case 426: // SUBGROUP
                        lblDSubgroupName.Visible = true;
                        txtSubGroup.Visible = true;
                        //lblDSubgroupName.Location = new Point(140, 22);
                        //txtSubGroup.Location = new Point(140, 45);
                        //DGV_FilterSubgroup.Location = new Point(152, 84);
                        //txtSubGroup.Focus();
                        break;

                    case 427: // BRAND
                        lblDBrandName.Visible = true;
                        txtBrand.Visible = true;
                        //lblDBrandName.Location = new Point(140, 22);
                        //txtBrand.Location = new Point(140, 22);
                        //DGV_FilterBrand.Location = new Point(152, 84);
                        //txtBrand.Focus();
                        break;

                    case 428: // PRODUCT
                        lblDProductName.Visible = true;
                        txtProductName.Visible = true;
                        //lblDProductName.Location = new Point(140, 22);
                        //txtProductName.Location = new Point(140, 22);
                        //DGV_FilterProduct.Location = new Point(152, 84);
                        //txtProductName.Focus();
                        break;

                    case 429: // SUPPLIER
                        lblDSupplierName.Visible = true;
                        txtSupplier.Visible = true;
                        //lblDSupplierName.Location = new Point(140, 22);
                        //txtSupplier.Location = new Point(140, 22);
                        //DGV_FilterSupplier.Location = new Point(152, 84);
                        //txtSupplier.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ResetAllSearchFields()
        {
            // GROUP
            lblDGroupName.Visible = false;
            txtGroup.Visible = false;
            lblGroupCode.Visible = false;
            DGV_FilterGroup.Visible = false;
            txtGroup.Text = "";
            lblGroupCode.Text = "0";

            // SUBGROUP
            lblDSubgroupName.Visible = false;
            txtSubGroup.Visible = false;
            lblSubGroupCode.Visible = false;
            DGV_FilterSubgroup.Visible = false;
            txtSubGroup.Text = "";
            lblSubGroupCode.Text = "0";

            // BRAND
            lblDBrandName.Visible = false;
            txtBrand.Visible = false;
            lblBrandCode.Visible = false;
            DGV_FilterBrand.Visible = false;
            txtBrand.Text = "";
            lblBrandCode.Text = "0";

            // PRODUCT
            lblDProductName.Visible = false;
            txtProductName.Visible = false;
            lblProductcode.Visible = false;
            DGV_FilterProduct.Visible = false;
            txtProductName.Text = "";
            lblProductcode.Text = "0";

            // SUPPLIER
            lblDSupplierName.Visible = false;
            txtSupplier.Visible = false;
            lblSupplierCode.Visible = false;
            lblschedleCode.Visible = false;
            DGV_FilterSupplier.Visible = false;
            txtSupplier.Text = "";
            lblSupplierCode.Text = "0";
            lblschedleCode.Text = "0";
        }

        private void btnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
                DGV_FilterGroup.Visible = false;
                DGV_FilterSubgroup.Visible = false;
                DGV_FilterBrand.Visible = false;
                DGV_FilterProduct.Visible = false;
                DGV_FilterSupplier.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnView_Leave(object sender, EventArgs e)
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

        public void udfnListViewData()
        {
            try
            {
                if (txtSupplier.Text.Trim() != "")
                {
                    lblSupplierCode.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SPID"].Value.ToString();
                    lblschedleCode.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SPSCID"].Value.ToString();
                    txtSupplier.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SP_NAME"].Value.ToString();
                }
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyProduct = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    btnView.Focus();
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
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }
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
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
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
        private void txtProductName_Leave(object sender, EventArgs e)
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
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyProduct == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {

                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 49;
                        objMR_Product.paraGroup = Convert.ToInt32(lblGroupCode.Text);
                        objMR_Product.paraSubgroup = Convert.ToInt32(lblSubGroupCode.Text);
                        objMR_Product.paraProductName = txtProductName.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "P.I Code";
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 0;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
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

    }
}
