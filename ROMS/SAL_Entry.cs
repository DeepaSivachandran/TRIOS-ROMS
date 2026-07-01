using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms; 

namespace ROMS
{
    public partial class SAL_Entry : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();
        DataValidation objValidation = new DataValidation();
        public int varUpDownKeySupplier = 0, varUpDownKeyGroup = 0, varUpDownKeySubgroup = 0, varUpDownKeyBrand = 0;
        private List<ComboItem> unit;
        DataError objError; public int varUserID = 0;
        DataTable dtDefaultGrid = new DataTable();
        public string pbRateCategoryIDs = "";
        public SAL_Entry()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            windowControl.Initialize(tsSalesEntry, this);
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
                if (skipControl != txtBrand)
                {
                    varUpDownKeyBrand = 0;
                    DGV_FilterBrand.DataSource = null;
                    DGV_FilterBrand.Visible = false;
                }
                if (skipControl != txtSupplier)
                {
                    varUpDownKeySupplier = 0;
                    DGV_FilterSupplier.DataSource = null;
                    DGV_FilterSupplier.Visible = false;
                }
                pnlRateCategory.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void SAL_Entry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnUpdate_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void SAL_Entry_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm objMainForm = new MainForm(); 
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 1202; 
                string ReportTypeIDs = string.Join(",",
                 MainForm.objDtMenuDetailsUser?.AsEnumerable()
                  .Where(r => r.Field<int?>("MU_ParentMenuCode") == currentMUCode)
                  .Select(r => r.Field<int?>("MU_EQID"))
                  .Where(q => q.HasValue)
                  .Select(q => q.Value.ToString())
                  ?? Enumerable.Empty<string>());
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
                lblUnits.Text = "";
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (5,0) AND MSTID NOT IN (-1)", "MST_DisplayText,MSTID", cmbCategory, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID in(1,2) and COMID !=-1 Order by COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,102) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (47,0) AND MSTID!=-1", "MST_DisplayText,MSTID", cmbFilterType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=80 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbProductName, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 32;
                DataSet objDTable = new DataSet();
                SPDataService objdSer = new SPDataService();
                objDTable = objdSer.udfnMaster(objMR_Master);
                objdSer.CloseConnection();
                if (objDTable != null)
                {
                    if (objDTable.Tables.Count > 0)
                    {
                        if (objDTable.Tables[0].Rows.Count > 0)
                        {
                            chkboxRatelist.DrawMode = DrawMode.Normal;
                            chkboxRatelist.FormattingEnabled = true;
                            chkboxRatelist.DisplayMember = "MST_DisplayText";
                            chkboxRatelist.ValueMember = "MSTID";
                            chkboxRatelist.DataSource = objDTable.Tables[0];
                            DataView dv = objDTable.Tables[0].DefaultView;
                            dv.RowFilter = "MSTID <> 0";
                            DataTable dt = dv.ToTable();
                            dt = objDTable.Tables[0];
                            chkboxRatelist.DataSource = dt;
                            chkboxRatelist.DisplayMember = "MST_DisplayText";   // text
                            chkboxRatelist.ValueMember = "MSTID";       // value 
                        }
                    }
                }
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                cmbProductName.SelectedValue = 270;
                cmbType.SelectedValue = 0;
                cmbCategory.SelectedValue = 0;
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    string privilege = "";
                    var result = UserAccessHelper.LoadUserAccess(currentMUCode);
                    privilege = result.PrivilegeCode;
                }
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnUnitList(8, 0, 0);
                cmbMultiUnit.DataSource = null;
                if (objDs != null)
                {
                    if (objDs != null && objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            unit = objDs.Tables[0].AsEnumerable()
                            .Select(r => new ComboItem
                            {
                                Id = r.Field<int>("UTID"),
                                Text = r.Field<string>("UT_Symbol")
                            })
                            .ToList();
                            cmbMultiUnit.LoadItems(unit, "Select Unit");
                        }
                    }
                }
                objdserv.CloseConnection();
                udfnList(0);
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGroup_Enter(object sender, EventArgs e)
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
        private void TxtGroup_KeyDown(object sender, KeyEventArgs e)
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
                    txtSubGroup.Focus();
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
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtSubGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGroup_Leave(object sender, EventArgs e)
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
        private void TxtGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyGroup == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtGroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnGroupList(13, 0, 0, txtGroup.Text, 0);
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
                                    DGV_FilterGroup.Columns["PRG_TName"].Visible = true;
                                    DGV_FilterGroup.Columns["PRG_EName"].Width = 200;
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

        private void DGV_FilterGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyGroup = 1;
                udfnGroupAutocomplete();
                txtSubGroup.Focus();
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
                        txtSubGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSubGroup_Enter(object sender, EventArgs e)
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
        private void TxtSubGroup_KeyDown(object sender, KeyEventArgs e)
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
                    txtBrand.Focus();
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
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtBrand.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSubGroup_Leave(object sender, EventArgs e)
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
        private void TxtSubGroup_TextChanged(object sender, EventArgs e)
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
                        objDs = objspdservice.udfnSubGroupList(18, 0, "", Convert.ToInt32(lblGroupCode.Text), 0, txtSubGroup.Text, 0, 0, 0, 0, 0);
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
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].Visible = true;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].Width = 200;
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
                txtBrand.Focus();
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
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtBrand.Focus();
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
            finally
            {
                txtSubGroup.Focus();
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
            finally
            {
                txtBrand.Focus();
            }
        }
        private void TxtBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyBrand == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtBrand.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnBrandList(14, "0", 0, 0, 0, txtBrand.Text.Trim(), 0);
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
                                    DGV_FilterBrand.Columns["BD_TName"].Visible = true;
                                    DGV_FilterBrand.Columns["BD_EName"].Width = 200;
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

        private void TxtBrand_Enter(object sender, EventArgs e)
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

        private void TxtBrand_KeyDown(object sender, KeyEventArgs e)
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
                    txtSupplier.Focus();
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
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtBrand = sender as TextBox;
                        txtBrand.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
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

        private void TxtBrand_Leave(object sender, EventArgs e)
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

        private void DGV_FilterBrand_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyBrand = 1;
                udfnBrandAutocomplete();
                txtSupplier.Focus();
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
            finally
            {
                btnView.Focus();
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
                    txtAlpha.Focus();
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
                                    udfnSupplierAutocomplete();
                                    DGV_FilterSupplier.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSupplier.Focus();
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtAlpha = sender as TextBox;
                        txtAlpha.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtAlpha.Focus();
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

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
                                    DGV_FilterSupplier.Columns["SP_Name"].HeaderText = "Supplier";
                                    DGV_FilterSupplier.Columns["SP_Name"].Width = 260;
                                    DGV_FilterSupplier.Columns["SP_Name"].DisplayIndex = 0;
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
                udfnSupplierAutocomplete();
                txtAlpha.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSupplierAutocomplete()
        {
            try
            {
                if (txtSupplier.Text.Trim() != "")
                {
                    lblSupplierCode.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SPID"].Value.ToString();
                    lblSchedleCode.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SPSCID"].Value.ToString();
                    txtSupplier.Text = DGV_FilterSupplier.SelectedRows[0].Cells["SP_NAME"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtAlpha.Focus();
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
                                    udfnSupplierAutocomplete();
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
                        txtAlpha.Focus();
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
                udfnGridNull((Control)sender);
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
                    txtGroup.Focus();
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

        private void cmbCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbType.Enabled == true)
                    {
                        cmbType.Focus();
                    }
                    else
                    {
                        cmbProductName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCategory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbCategory.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbMultiUnit.Focus();   
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                if (Convert.ToInt32(cmbCategory.SelectedValue) == 13)   //Trading
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MSTID=13 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                    cmbType.Enabled = false;
                }
                else if (Convert.ToInt32(cmbCategory.SelectedValue) == 14)  //Conversion
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,102) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                    cmbType.Enabled = true;
                }
                else if (Convert.ToInt32(cmbCategory.SelectedValue) == 15)  //Free
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MSTID=15 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                    cmbType.Enabled = false;
                }
                else if (Convert.ToInt32(cmbCategory.SelectedValue) == 16)  //Production
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,76) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                    cmbType.Enabled = true;
                }
                else
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,102) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
                    cmbType.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }       

        private void txtAlpha_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtAlpha.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAlpha_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAlpha.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAlpha_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbMultiUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbMultiUnit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbMultiUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbMultiUnit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbMultiUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbFilterType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbMultiUnit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbFilterType_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbFilterType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbFilterType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbFilterType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbFilterType_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbFilterType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnView_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                btnView.BackColor = Color.LemonChiffon;
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

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                epReport.Clear();
                udfnList(0); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnList(int varFlag)
        {
            try
            {
                epReport.Clear();
                dtDefaultGrid = null;
                picLoader.Visible = true;
                picLoader.BringToFront();
                string varGroupName = "-All-", varSubgroupName = "-All-", varBrandName = "-All-", varAlpha = "", varSupplierName = "-All-", varUnit = "", varFilterType = "";
                int varGroupId = 0, varSubgroupId = 0, varBrandId = 0, varSupplierId = 0, varScheduleId = 0, varTypeId = 0;
                string varAlphaName = "-All-", varTypeName = "-All-", varUnitName = "-All-", VarFilterName = "-All-", varConcern = "-All-", varRateCategoryType = "--All--";
                lblAlphaCode.Text = varAlpha;
                if (txtGroup.Text.Trim() != "")
                {
                    varGroupName = txtGroup.Text;
                    varGroupId = Convert.ToInt32(lblGroupCode.Text);
                }
                if (txtSubGroup.Text.Trim() != "")
                {
                    varSubgroupName = txtSubGroup.Text;
                    varSubgroupId = Convert.ToInt32(lblSubGroupCode.Text);
                }
                if (txtBrand.Text.Trim() != "")
                {
                    varBrandName = txtBrand.Text;
                    varBrandId = Convert.ToInt32(lblBrandCode.Text);
                }
                if (txtAlpha.Text != "")
                {
                    varAlpha = txtAlpha.Text;
                    varAlphaName = txtAlpha.Text;
                }
                if (Convert.ToInt32(cmbCategory.SelectedValue) != 13 && Convert.ToInt32(cmbCategory.SelectedValue) != 15)
                {
                    varTypeId = Convert.ToInt32(cmbType.SelectedValue);
                    varTypeName = cmbType.Text;
                }
                if (txtSupplier.Text.Trim() != "")
                {
                    varSupplierName = txtSupplier.Text;
                    varSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    varScheduleId = Convert.ToInt32(lblSchedleCode.Text);
                }
                if (txtRateCategory.Text.Trim() != "")
                {
                    varRateCategoryType = txtRateCategory.Text;
                }
                var selIds = cmbMultiUnit.CheckedIds;
                var selItems = unit.Where(m => selIds.Contains(m.Id)).ToList();
                varUnit = string.Join(", ", selItems.Select(x => x.Id));
                if (selIds.Count > 0)
                {
                    varUnitName = string.Join(", ", selItems.Select(x => x.Text));
                    lblUnits.Text = varUnitName;
                }
                else
                {
                    lblUnits.Text = "";
                }
                if (Convert.ToInt32(cmbFilterType.SelectedValue) == 0)
                {
                    varFilterType = "";
                    VarFilterName = "-All-";
                }
                else
                {
                    varFilterType = cmbFilterType.Text;
                    VarFilterName = cmbFilterType.Text;
                }
                varConcern = cmbConcern.Text;
                Application.DoEvents();
                int varPrint = 0;
                MR_SalesEntry objMR_SalesEntry = new MR_SalesEntry();
                objMR_SalesEntry.paraViewType = 1;
                objMR_SalesEntry.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_SalesEntry.paraGroup = varGroupId;
                objMR_SalesEntry.paraSubgroup = varSubgroupId;
                objMR_SalesEntry.paraBrandID = varBrandId;
                objMR_SalesEntry.paraSupplier = varSupplierName;
                objMR_SalesEntry.paraSupplierID = varSupplierId;
                objMR_SalesEntry.ParaScheduleid = varScheduleId;
                objMR_SalesEntry.paraAlpha = varAlpha;
                objMR_SalesEntry.paraProductCategory = Convert.ToInt32(cmbCategory.SelectedValue);
                objMR_SalesEntry.paraType = varTypeId;
                objMR_SalesEntry.paraUnitId = varUnit;
                objMR_SalesEntry.paraFilterType = varFilterType;
                objMR_SalesEntry.paraProductNameID = Convert.ToInt32(cmbProductName.SelectedValue);
                objMR_SalesEntry.paraRateCategoryIDs = pbRateCategoryIDs; 
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnsaleslist(objMR_SalesEntry);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varPrint = varFlag;
                        }
                    }
                }
                if (varFlag == 0)
                {
                    DGV_SearchGrid.DataSource = null;
                    grdSalesList.DataSource = null;
                    btnView.Enabled = false;
                    RPTViewer.Visible = false;
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                lblNoRecordsFound.Visible = false;
                                lblNoRecordsFound.SendToBack();
                                grdSalesList.DataSource = objDs.Tables[0];  
                                grdSalesList.Columns["ProuctID"].Visible = false;
                                grdSalesList.Columns["EProduct"].Visible = false;
                                grdSalesList.Columns["UnitCode"].Visible = false;
                                grdSalesList.Columns["BrandCode"].Visible = false;
                                grdSalesList.Columns["EBrnad"].Visible = false;
                                grdSalesList.Columns["SubGroupCode"].Visible = false;
                                grdSalesList.Columns["ESubGroup"].Visible = false;
                                grdSalesList.Columns["GroupCode"].Visible = false;
                                grdSalesList.Columns["EGroup"].Visible = false;
                                grdSalesList.Columns["FilterType"].Visible = false;
                                grdSalesList.Columns["PR_PICode"].Visible = false;

                                grdSalesList.Columns["RCYID"].Visible = false;
                                grdSalesList.Columns["NoofDecimal"].Visible = false;
                                grdSalesList.Columns["S.No."].Width = 50;
                                grdSalesList.Columns["PI Code"].Width = 100;
                                grdSalesList.Columns["Product"].Width = 500;
                                grdSalesList.Columns["Unit"].Width = 50;
                                grdSalesList.Columns["S.Rate"].Width = 80;
                                grdSalesList.Columns["S.Qty"].Width = 80; 
                                grdSalesList.Columns["Brand"].Width = 120;
                                grdSalesList.Columns["Sub Group"].Width = 120;
                                grdSalesList.Columns["Group"].Width = 120;
                                grdSalesList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdSalesList.Columns["S.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSalesList.Columns["S.Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSalesList.Columns["Product"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                //grdSalesList.Columns["Brand"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                //grdSalesList.Columns["Sub Group"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                //grdSalesList.Columns["Group"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                grdSalesList.Columns["S.Rate"].DefaultCellStyle.Format = "0.00";
                                grdSalesList.Columns["S.Qty"].DefaultCellStyle.Format = "0.00";

                                tsbOriginalProducts.Text = objDs.Tables[1].Rows[0]["OriginalProCount"].ToString().Trim();
                                tsbMppedCount.Text = objDs.Tables[2].Rows[0]["MappedCount"].ToString().Trim();
                                tsbUnmappedCount.Text = objDs.Tables[3].Rows[0]["UnmappedCount"].ToString().Trim();
                                lblGroupCount.Text = objDs.Tables[4].Rows[0]["GroupCount"].ToString().Trim();
                                lblSubGroupCount.Text = objDs.Tables[5].Rows[0]["SubGroupCount"].ToString().Trim();
                                lblBrandCount.Text = objDs.Tables[6].Rows[0]["BrandCount"].ToString().Trim();
                                tsbTotalProducts.Text = objDs.Tables[7].Rows[0]["TotalProCount"].ToString().Trim();
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
                        objspservice.CloseConnection();
                    }
                    udfnSearchGridHead();
                    grdSalesList.Columns["S.No."].ReadOnly = true;
                    grdSalesList.Columns["PI Code"].ReadOnly = true;
                    grdSalesList.Columns["Product"].ReadOnly = true;
                    grdSalesList.Columns["Unit"].ReadOnly = true;
                    grdSalesList.Columns["S.Rate"].ReadOnly = true;
                    grdSalesList.Columns["Brand"].ReadOnly = true;
                    grdSalesList.Columns["Sub Group"].ReadOnly = true;
                    grdSalesList.Columns["Group"].ReadOnly = true;
                    if (lblNoRecordsFound.Visible == true)
                    {
                        dtDefaultGrid = objDs.Tables[0];
                        udfnDefaultSearchGrid();
                    }
                    else
                    {
                        DGV_SearchGrid.ScrollBars = ScrollBars.Vertical;
                    }
                    tsbTotal.Visible = true; tsbTotal.Enabled = true;
                    tsbMapped.Visible = true; tsbMapped.Enabled = true;
                    tsbUnmapped.Visible = true; tsbUnmapped.Enabled = true;
                    tsbTotalProducts.Visible = true; tsbUnmappedCount.Visible = true; tsbMppedCount.Visible = true;
                    tss1.Visible = true; tss2.Visible = true; tss3.Visible = true;
                }
                if (varPrint != 0)
                {
                    btnView.Enabled = true;
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    int varEmptyFilledFlag = 0;
                    if (varFlag == 1 || varFlag == 2)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SAL_Entry.rpt");
                       
                    }
                    else if(varFlag==3  || varFlag==4)
                    {
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_SAL_Summary.rpt");
                    }
                    if (varFlag == 2 || varFlag==3)
                    {
                        varEmptyFilledFlag = 2; //Filled
                    }
                    else
                    { 
                        varEmptyFilledFlag = 1; //Empty
                                                   }
                    
                    objBillreport.SetParameterValue("ParaCompanycode", Convert.ToInt32(cmbConcern.SelectedValue));
                    objBillreport.SetParameterValue("paraGroup", varGroupId);
                    objBillreport.SetParameterValue("paraSubgroup", varSubgroupId);
                    objBillreport.SetParameterValue("paraBrandID", varBrandId);
                    objBillreport.SetParameterValue("paraSupplierID", varSupplierId);
                    objBillreport.SetParameterValue("ParaScheduleid", varScheduleId);
                    objBillreport.SetParameterValue("paraAlpha", varAlpha);
                    objBillreport.SetParameterValue("paraProductCategory", Convert.ToInt32(cmbCategory.SelectedValue));
                    objBillreport.SetParameterValue("paraType", varTypeId);
                    objBillreport.SetParameterValue("paraUnitId", varUnit);
                    objBillreport.SetParameterValue("paraFilterType", varFilterType);
                    objBillreport.SetParameterValue("paraProductNameID", Convert.ToInt32(cmbProductName.SelectedValue));
                    objBillreport.SetParameterValue("paraRateCategoryIDs", pbRateCategoryIDs);
                    objBillreport.SetParameterValue("paraRateCategoryType", varRateCategoryType);

                    objBillreport.SetParameterValue("varHeader", "S.Entry Report");
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objBillreport.SetParameterValue("varConcern", varConcern);
                    objBillreport.SetParameterValue("VarGroup", varGroupName);
                    objBillreport.SetParameterValue("VarSubGroup", varSubgroupName);
                    objBillreport.SetParameterValue("varBrandName", varBrandName);
                    objBillreport.SetParameterValue("varSupplierName", varSupplierName);
                    objBillreport.SetParameterValue("varAlphaName", varAlphaName);
                    objBillreport.SetParameterValue("VarCategory", cmbCategory.Text);
                    objBillreport.SetParameterValue("varTypeName", varTypeName);
                    objBillreport.SetParameterValue("varUnitName", varUnitName);
                    objBillreport.SetParameterValue("VarFilterName", VarFilterName);
                    objBillreport.SetParameterValue("varFlag", varFlag);
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblFilterCount.Text = Convert.ToString(grdSalesList.Rows.Count);
                picLoader.Visible = false;
                picLoader.SendToBack();
                btnView.Enabled = true;
                GC.Collect();
            }
        }

        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["ProuctID"].Visible = false;
                DGV_SearchGrid.Columns["EProduct"].Visible = false;
                DGV_SearchGrid.Columns["UnitCode"].Visible = false;
                DGV_SearchGrid.Columns["BrandCode"].Visible = false;
                DGV_SearchGrid.Columns["EBrnad"].Visible = false;
                DGV_SearchGrid.Columns["SubGroupCode"].Visible = false;
                DGV_SearchGrid.Columns["ESubGroup"].Visible = false;
                DGV_SearchGrid.Columns["GroupCode"].Visible = false;
                DGV_SearchGrid.Columns["EGroup"].Visible = false;
                DGV_SearchGrid.Columns["FilterType"].Visible = false;
                DGV_SearchGrid.Columns["S.No."].Width = 50;
                DGV_SearchGrid.Columns["PI Code"].Width = 100;
                DGV_SearchGrid.Columns["Product"].Width = 480;
                DGV_SearchGrid.Columns["Unit"].Width = 50;
                DGV_SearchGrid.Columns["S.Rate"].Width = 80;
                DGV_SearchGrid.Columns["S.Qty"].Width = 80;
                DGV_SearchGrid.Columns["Brand"].Width = 120;
                DGV_SearchGrid.Columns["Sub Group"].Width = 120;
                DGV_SearchGrid.Columns["Group"].Width = 120;
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
                    udfnGridSearchHeading(grdSalesList, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdSalesList.Columns)
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
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                }
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
                if (grdSalesList.ColumnCount > 0)
                {
                    grdSalesList.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdSalesList.HorizontalScrollingOffset;
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
                    int offSetValue = grdSalesList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdSalesList.Width > grdSalesList.HorizontalScrollingOffset && grdSalesList.HorizontalScrollingOffset > 0)
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

        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdSalesList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSalesList);
                objDser.CloseConnection();
                grdSalesList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                udfnSalesEntryGridFilter();
                lblFilterCount.Text = Convert.ToString(grdSalesList.Rows.Count);
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
                DataService objDser = new DataService();
                grdSalesList.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSalesList);
                objDser.CloseConnection();
                grdSalesList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
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
                    DataGridViewColumn newColumn = grdSalesList.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdSalesList.SortedColumn;
                    ListSortDirection direction;
                    if (oldColumn != null)
                    {
                        if (oldColumn == newColumn && grdSalesList.SortOrder == SortOrder.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
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
                        grdSalesList.Sort(newColumn, direction);
                        newColumn.HeaderCell.SortGlyphDirection =
                            direction == ListSortDirection.Ascending ?
                            SortOrder.Ascending : SortOrder.Descending;

                        DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                        DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                        DGV_SearchGrid.HorizontalScrollingOffset = grdSalesList.HorizontalScrollingOffset;
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

        private void grdSalesList_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdSalesList.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdSalesList.Width > grdSalesList.HorizontalScrollingOffset && grdSalesList.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdSalesList);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdSalesList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdSalesList.Rows.Count; i++)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell cell = dataGridView.Rows[i].Cells["S.Qty"];
                    cell.Style.BackColor = Color.PaleGreen;
                    cell.Style.ForeColor = Color.Black;
                    cell.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdSalesList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string MarginValue = Convert.ToString(grdSalesList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if (MarginValue != "")
                {
                    int nooddecimal =Convert.ToInt16(grdSalesList.Rows[e.RowIndex].Cells["NoofDecimal"].Value);
                    grdSalesList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = objValidation.udfnDecimal(MarginValue,nooddecimal);
                }
                btnUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdSalesList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                        e.Handled = true;
                    }
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdSalesList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdSalesList.CurrentCell.OwningColumn.Name == "S.Qty")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdSalesList.CurrentCell.OwningColumn.Name == "S.Qty")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int varDecimal = Convert.ToInt32(grdSalesList.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdSalesList.CurrentCell.OwningColumn.Name == "S.Qty")
                {
                    TextBox textBox = (TextBox)sender;
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                        {
                            e.Handled = true;
                        }
                    }
                    if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
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

        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdSalesList.CurrentCell.OwningColumn.Name == "S.Qty")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                    {
                        e.Handled = true;
                    }
                    //only allow one decimal point
                    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnscrollVisible(DataGridView DGV, DataGridView grdSalesList)
        {
            try
            {
                var vScrollbar = grdSalesList.Controls.OfType<VScrollBar>().First();
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

        private void udfnSalesEntryGridFilter()
        {
            try
            {
                foreach (DataGridViewRow row in grdSalesList.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    bool visible = true;
                    for (int i = 0; i < DGV_SearchGrid.Columns.Count; i++)
                    {
                        object searchObj = DGV_SearchGrid.Rows[0].Cells[i].Value;
                        if (searchObj == null)
                            continue;

                        string searchText = searchObj.ToString().Trim();
                        if (string.IsNullOrWhiteSpace(searchText))
                            continue;

                        string columnName = DGV_SearchGrid.Columns[i].Name;
                        if (!grdSalesList.Columns.Contains(columnName))
                            continue;

                        object cellObj = row.Cells[columnName].Value;
                        string cellValue = cellObj == null
                            ? ""
                            : cellObj.ToString();

                        if (!cellValue.ToLower().Contains(searchText.ToLower()))
                        {
                            visible = false;
                            break;
                        }
                    }
                    row.Visible = visible;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnUpdate_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public BindingSource udfnGridSearchFilterMargin(DataGridView DGV_SearchGrid, DataGridView grdOutwardList)
        {
            DataValidation objValidation = new DataValidation();
            int i = 0;
            BindingSource bs = new BindingSource();
            if (DGV_SearchGrid.ColumnCount > 0)
            {
                bs.DataSource = grdOutwardList.DataSource;
                string filter = "";
                for (int j = 1; j < DGV_SearchGrid.ColumnCount; j++)
                {
                    if (Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) != "" && DGV_SearchGrid.Rows[i].Cells[j].ValueType.Name != "Image")
                    {
                        if (filter != "") filter += "And ";
                        if (objValidation.FormatNumeric(Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value)))
                        {
                            filter += "Convert([" + DGV_SearchGrid.Columns[j].DataPropertyName.ToString() + "]" + ", System.String) LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                        }
                        else
                        {
                            if (Convert.ToInt32(cmbType.SelectedValue) == 18)
                            {
                                if (DGV_SearchGrid.Rows[i].Cells[j].OwningColumn.Name == "Group")
                                {
                                    filter += "[" + DGV_SearchGrid.Columns[j + 1].DataPropertyName.ToString() + "]" + " LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                                }
                            }
                            else if (Convert.ToInt32(cmbType.SelectedValue) == 19)
                            {
                                if (DGV_SearchGrid.Rows[i].Cells[j].OwningColumn.Name == "Raw Material")
                                {
                                    filter += "[" + DGV_SearchGrid.Columns[j - 3].DataPropertyName.ToString() + "]" + " LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                                }
                            }
                            else
                            {
                                filter += "[" + DGV_SearchGrid.Columns[j].DataPropertyName.ToString() + "]" + " LIKE '%" + Convert.ToString(DGV_SearchGrid.Rows[i].Cells[j].Value) + "%'";
                            }
                        }
                    }
                }
                bs.Filter = filter;
                grdOutwardList.DataSource = bs;
            }
            return bs;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                grdSalesList.ClearSelection();
                DGV_SearchGrid.ClearSelection();
                SPDataService objspservice = new SPDataService();
                DataTable objSalesEntries = new DataTable();
                string varResult = "", qty="";
                for (int i = 1; i < DGV_SearchGrid.ColumnCount; i++)
                {
                    DGV_SearchGrid.Rows[0].Cells[i].Value = "";
                }
                grdSalesList.DataSource = udfnGridSearchFilterMargin(DGV_SearchGrid, grdSalesList);
                grdSalesList.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                grdSalesList.DataBindingComplete += grdSalesList_DataBindingComplete;
                for (int i = 0; i < grdSalesList.Rows.Count; i++)
                {
                    qty = Convert.ToString(grdSalesList.Rows[i].Cells["S.Qty"].Value.ToString());
                    if (qty != "")
                    {
                        if (objSalesEntries.Rows.Count == 0)
                        {
                            objSalesEntries.TableName = "TRN_SalesEntry_Details";
                            objSalesEntries.Columns.Add("SE_PRID", typeof(int));
                            objSalesEntries.Columns.Add("SE_SQty", typeof(float));
                            objSalesEntries.Columns.Add("SE_RCYID", typeof(int));
                        }
                        objSalesEntries.Rows.Add(Convert.ToInt32(grdSalesList.Rows[i].Cells["ProuctID"].Value), Convert.ToDouble(grdSalesList.Rows[i].Cells["S.Qty"].Value),
                            Convert.ToInt16(grdSalesList.Rows[i].Cells["RCYID"].Value));
                    }
                }
                MainForm.objCP_Verify = new CP_Verify();
                MainForm.objCP_Verify.ShowDialog();
                varUserID =Convert.ToInt16(MainForm.objCP_Verify.varUserId);
                if (MainForm.objCP_Verify.flag == 1)
                {
                    Model.MR_SalesEntry objSalesEntry = new Model.MR_SalesEntry();
                    objSalesEntry.paraViewType = 1;
                    objSalesEntry.ParaSalesEntry = objSalesEntries;
                    objSalesEntry.paraUserID = varUserID;
                    varResult = objspservice.udfnSalesEntry(objSalesEntry);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "1")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = cmbConcern;
                        udfnList(0);
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                lblFilterCount.Text = Convert.ToString(grdSalesList.Rows.Count);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnUpdate_Enter(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnUpdate_Leave(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void UpdateSelectedValues()
        {
            try
            {
                List<string> texts = new List<string>();
                List<string> ids = new List<string>();

                foreach (DataRowView row in chkboxRatelist.CheckedItems)
                {
                    int id = Convert.ToInt32(row["MSTID"]);

                    // ignore -All- in textbox
                    if (id == 0) continue;

                    texts.Add(row["MST_DisplayText"].ToString());
                    ids.Add(id.ToString());
                }

                // TextBox (RR, WR)
                txtRateCategory.Text = texts.Count > 0
                    ? string.Join(", ", texts)
                    : "";

                // Label (447,448)
                pbRateCategoryIDs = ids.Count > 0
                    ? string.Join(",", ids)
                    : "0";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdSalesList.Rows.Count > 0)
                {
                    SPDataService objDServ = new SPDataService();
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to refresh the filter?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        epReport.Clear();
                        cmbConcern.SelectedValue = "1";
                        txtGroup.Text = "";
                        txtSubGroup.Text = "";
                        txtBrand.Text = "";
                        txtSupplier.Text = "";
                        txtAlpha.Text = "";
                        cmbCategory.SelectedIndex = 0;
                        cmbType.SelectedIndex = 0;
                        cmbFilterType.SelectedIndex = 0;
                        cmbMultiUnit.ClearAll();
                        udfnList(0);
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(79);
                    objDServ.CloseConnection();
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lblFilterCount.Text = Convert.ToString(grdSalesList.Rows.Count);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                cmbProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbMultiUnit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProductName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lblUnit_Click(object sender, EventArgs e)
        {

        }

        private void grpfilter_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtRateCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUnits_Click(object sender, EventArgs e)
        {

        }

        private void pnlRateCategory_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtRateCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                pnlRateCategory.Visible = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRateCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbFilterType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void txtRateCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                //pnlRateCategory.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkboxRatelist_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                BeginInvoke((MethodInvoker)UpdateSelectedValues);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkboxRatelist_KeyDown(object sender, KeyEventArgs e)
        {  
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbFilterType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void btnConditionClear_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < chkboxRatelist.Items.Count; i++)
                {
                    chkboxRatelist.SetItemChecked(i, false);
                }

                txtRateCategory.Text = "";
                pbRateCategoryIDs = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void tsbFilledPrint_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList(3);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbEmptyPrint_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList(4);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            { 
                DialogResult dialogResult = MessageBox.Show("Are you sure want to clear all the products ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string varResult = "";
                    SPDataService objspservice = new SPDataService();
                    Model.MR_SalesEntry objSalesEntry = new Model.MR_SalesEntry();
                    objSalesEntry.paraViewType = 2;  
                    varResult = objspservice.udfnSalesEntry(objSalesEntry);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "1")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = cmbConcern;
                        udfnList(0);
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                lblFilterCount.Text = Convert.ToString(grdSalesList.Rows.Count);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    windowControl?.TriggerClose();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tspEmpty_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList(1);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tspFilled_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList(2);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
