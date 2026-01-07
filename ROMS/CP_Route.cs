using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROMS.Model;

namespace ROMS
{
    //Created By:-Sathish ; Created On:-11-08-2023
    public partial class CP_Route : Form
    {
        DataError objError;
        private ToolTip tpREName = new ToolTip();
        private ToolTip tpRTName = new ToolTip();
        public int varRouteId = 0;
        public int PbStatus = 0;
        public int varUpdate = 0;
        public DataTable dtAvailableArea=new DataTable();
        public DataTable dtMappedArea = new DataTable();

        Boolean BlnSearchImageYN = false;

        public CP_Route()
        {
            InitializeComponent();
        }
        public void udfnLoadSlNo()
        {
            try
            {
                DataSet objDS;
                if (varRouteId != 0)
                {
                    string varRID = Convert.ToString(varRouteId);
                    SPDataService objspservice = new SPDataService();
                    objDS = objspservice.udfnGetSlNo("MR_Route", "Update", "RID", varRID, "R_OrderNo");
                    objspservice.CloseConnection();
                }
                else
                {
                    SPDataService objspservice = new SPDataService();
                    objDS = objspservice.udfnGetSlNo("MR_Route ", "Create", "1=1", "", "R_OrderNo");
                    objspservice.CloseConnection();
                }
                if (objDS != null)
                {
                    cmbRSNo.DataSource = objDS.Tables[0];
                    cmbRSNo.DisplayMember = "num";
                    cmbRSNo.ValueMember = "num";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave(object sender,EventArgs e)
        {
            try
            {
                if (rbActive.Checked == true) { PbStatus = 1; }
                else { PbStatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = "";int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Route Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Route Updation";
                    varType = 1;
                }
                /*
                // Create a new DataTable with only ID column
                DataTable dtArea = new DataTable();
                dtArea.Columns.Add("AID", typeof(int));

                // Filter only checked rows and get only AR_AID
                var ids = grdArea.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["clmCheckBox"].Value) == true)  // Checkbox column name
                .Select(r => Convert.ToInt32(r.Cells["AID"].Value))               // ID column
                .ToList();

                if (ids.Any())
                {
                    foreach (var id in ids)
                    {
                        dtArea.Rows.Add(id);
                    }
                }
                */
                DataTable dtArea = new DataTable();
                dtArea.Columns.Add("AID", typeof(int));

                foreach (DataRow row in dtMappedArea.Rows)
                {
                    dtArea.Rows.Add(Convert.ToInt32(row["AID"]));
                }

                SPDataService objspdservice = new SPDataService();
                MR_Route objMR_Route = new MR_Route();
                objMR_Route.ViewType = varType;
                objMR_Route.paraRouteId = varRouteId;
                objMR_Route.paraRouteTName = txtRTName.Text.Trim();
                objMR_Route.paraRouteEName = txtREName.Text.Trim(); 
                objMR_Route.paraStatusId = PbStatus;
                objMR_Route.paraAreaRoute = dtArea;
                objMR_Route.paraOriginator = varoriginator;
                objMR_Route.paraOrderNo = Convert.ToInt32(cmbRSNo.SelectedValue); 
                varResult = objspdservice.udfnRoute(objMR_Route);
                objspdservice.CloseConnection();
 
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Routelist.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        udfnclear();
                        MainForm.objCP_Routelist.udfnList();
                    }
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
                    }
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
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
                btnSave.Focus();
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        private void udfnclear()
        {
            try
            {
                txtREName.Text = "";
                txtRTName.Text = "";
                udfnLoadSlNo();
                udfnArea();
                txtREName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtREName.Text).Trim() == "")
                {
                    epRoute.SetError(txtREName, "Please enter route english name.");
                    txtREName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpREName.ShowAlways = true;
                    tpREName.Show("Please enter route english name.", txtREName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtRTName.Text).Trim() == "")
                {
                    epRoute.SetError(txtRTName, "Please enter route tamil name.");
                    txtRTName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRTName.ShowAlways = true;
                    tpRTName.Show("Please enter route tamil name.", txtRTName, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    epRoute.Clear();
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
                    btnSave.Enabled = true;
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
        private void btnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclose()
        {
            try
            {
                this.Close();
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
                //if (varmastertype == 0)
                //{
                //    MainForm.objCP_Routelist.udfnList();
                //}
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
        private void RbActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbInActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void RbInActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Route_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varUpdate == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Route_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Route_Leave(object sender, EventArgs e)
        {
            try
            {
                tpREName.Active = false;
                tpRTName.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Route_Load(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                    udfnLoadSlNo();
                    udfnArea();
                }
                else
                {
                    udfnLoadSlNo();
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1) 
                    { 
                        rbActive.Checked = true; 
                    }
                    else 
                    {
                        txtREName.Enabled = false;
                        txtRTName.Enabled = false;
                        cmbRSNo.Enabled = false;
                        rbInActive.Checked = true;
                    }
                }
                MainForm.objCP_Routelist.picLoader.Visible = false;
                MainForm.objCP_Routelist.picLoader.SendToBack(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnArea()
        {
            try
            {
                dtAvailableArea.Columns.Add("", typeof(Boolean));
                dtAvailableArea.Columns.Add("AID", typeof(int));
                dtAvailableArea.Columns.Add("Flag", typeof(int));
                dtAvailableArea.Columns.Add("Area", typeof(string));
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                MR_Route objMR_Route = new MR_Route();
                objMR_Route.ViewType = 2; 
                objDs = objspservice.udfnRouteList(objMR_Route);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            //for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            //{
                            //    dtAvailableArea.Rows.Add(false, Convert.ToInt32(objDs.Tables[0].Rows[i]["AID"].ToString()), Convert.ToInt32(objDs.Tables[0].Rows[i]["Flag"].ToString()), Convert.ToString(objDs.Tables[0].Rows[i]["Area"].ToString()) );
                            //}

                            dtAvailableArea = objDs.Tables[0];
                            dtMappedArea = dtAvailableArea.Clone();

                            grdArea.DataSource = dtAvailableArea;
                            //grdArea.DataSource = objDs.Tables[0];
                            grdMappedArea.DataSource = dtMappedArea;

                            grdArea.Columns["AID"].Visible = false;
                            grdArea.Columns["Flag"].Visible = false;
                            grdArea.Columns["Area"].Width = 250;
                            grdMappedArea.Columns["AID"].Visible = false;
                            grdMappedArea.Columns["Flag"].Visible = false;
                            grdMappedArea.Columns["Area"].Width = 250;

                            udfnPursearchgridHead();
                            udfnPurMappedsearchgridHead();
                            grdArea.Columns["Area"].ReadOnly = true;
                            grdMappedArea.Columns["Area"].ReadOnly = true;
                        } 
                    } 
                    objspservice.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnPursearchgridHead()
        {
            try
            {
                udfnGridSearchHeading(grdArea, DGV_PurSearchGrid);
                DGV_PurSearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdArea.Columns)
                {
                    DGV_PurSearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_PurSearchGrid.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_PurSearchGrid.Rows.Clear();
                    DGV_PurSearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_PurSearchGrid.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_PurSearchGrid.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_PurSearchGrid.Columns[0].ReadOnly = true;
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
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void udfnPurMappedsearchgridHead()
        {
            try
            {
                udfnGridSearchHeading(grdMappedArea, DGV_PurMappedSearchGrid);
                DGV_PurMappedSearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdMappedArea.Columns)
                {
                    DGV_PurMappedSearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_PurMappedSearchGrid.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_PurMappedSearchGrid.Rows.Clear();
                    DGV_PurMappedSearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_PurMappedSearchGrid.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_PurMappedSearchGrid.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_PurMappedSearchGrid.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        public void udfnEdit()
        {
            try
            {
                if (varRouteId != 0)
                {
                    DataSet objDs = new DataSet();  
                    SPDataService objspservice = new SPDataService();
                    MR_Route objMR_Route = new MR_Route();
                    objMR_Route.ViewType = 1;
                    objMR_Route.paraRouteId = varRouteId;
                    objDs = objspservice.udfnRouteList(objMR_Route); 
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtREName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["R_EName"]);
                                txtRTName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["R_TName"]);
                                cmbRSNo.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["R_OrderNo"]);
                                txtREName.Focus();
                            }
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                DataTable dtAreaTable = objDs.Tables[1];
                                dtAvailableArea = dtAreaTable.Clone();
                                dtMappedArea = dtAreaTable.Clone();

                                foreach (DataRow row in dtAreaTable.Rows)
                                {
                                    if (Convert.ToInt32(row["Flag"]) == 1)
                                    {
                                        dtMappedArea.ImportRow(row);      // already mapped
                                    }
                                    else
                                    {
                                        dtAvailableArea.ImportRow(row);   // not mapped
                                    }
                                }
                                grdArea.DataSource = dtAvailableArea;
                                grdMappedArea.DataSource = dtMappedArea;

                                // Available grid
                                grdArea.Columns["AID"].Visible = false;
                                grdArea.Columns["Flag"].Visible = false;
                                grdArea.Columns["Area"].Width = 250;

                                // Mapped grid
                                grdMappedArea.Columns["AID"].Visible = false;
                                grdMappedArea.Columns["Flag"].Visible = false;
                                grdMappedArea.Columns["Area"].Width = 250;

                                udfnPursearchgridHead();
                                udfnPurMappedsearchgridHead();
                                grdArea.Columns["Area"].ReadOnly = true;
                                grdMappedArea.Columns["Area"].ReadOnly = true;
                                //ResetCheckBoxes(grdArea, "clmCheckBox");
                                //ResetCheckBoxes(grdMappedArea, "clmCheck");
                                //UpdateButtonState();
                            }
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
        private void txtREName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtREName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtREName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    txtRTName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtREName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtREName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRTName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRTName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRTName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbRSNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRTName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRTName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRSNo_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRSNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRSNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (rbActive.Enabled == true)
                    {
                        rbActive.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRSNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRSNo_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbRSNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbInActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                        btnSave.Focus(); 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                    btnSave.Focus(); 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPuraddMove_Click(object sender, EventArgs e)
        {
            try
            {
                var checkedRows = grdArea.Rows.Cast<DataGridViewRow>()
        .Where(r => Convert.ToBoolean(r.Cells["clmCheckBox"].Value) == true)
        .ToList();

                if (!checkedRows.Any())
                {
                    ShowWarning();
                    return;
                }

                foreach (var row in checkedRows)
                {
                    DataRow dr = ((DataRowView)row.DataBoundItem).Row;

                    dtMappedArea.ImportRow(dr);   // add to mapped
                    dtAvailableArea.Rows.Remove(dr); // remove from available
                }

                ResetCheckBoxes(grdArea, "clmCheckBox");
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnPurRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var checkedRows = grdMappedArea.Rows.Cast<DataGridViewRow>()
        .Where(r => Convert.ToBoolean(r.Cells["clmCheck"].Value) == true)
        .ToList();

                if (!checkedRows.Any())
                {
                    ShowWarning();
                    return;
                }

                foreach (var row in checkedRows)
                {
                    DataRow dr = ((DataRowView)row.DataBoundItem).Row;

                    dtAvailableArea.ImportRow(dr);
                    dtMappedArea.Rows.Remove(dr);
                }

                ResetCheckBoxes(grdMappedArea, "clmCheck");
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ResetCheckBoxes(DataGridView grid, string checkColumnName)
        {
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    row.Cells[checkColumnName].Value = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void UpdateButtonState()
        {
            try
            {
                bool anyCheckedInArea = HasChecked(grdArea, "clmCheckBox");
                bool anyCheckedInMapped = HasChecked(grdMappedArea, "clmCheck");

                if (anyCheckedInArea)
                {
                    BtnPuraddMove.Enabled = true;
                    btnPurRemove.Enabled = false;
                }
                else if (anyCheckedInMapped)
                {
                    BtnPuraddMove.Enabled = false;
                    btnPurRemove.Enabled = true;
                }
                else
                {
                    BtnPuraddMove.Enabled = true;
                    btnPurRemove.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private bool HasChecked(DataGridView grid,string varColumName)
        {
            return grid.Rows.Cast<DataGridViewRow>()
                .Any(r => Convert.ToBoolean(r.Cells[varColumName].Value) == true);
        }

        private void grdArea_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdArea_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                var grid = sender as DataGridView;
                if (grid.IsCurrentCellDirty)
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ShowWarning()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(198);
                objDServ.CloseConnection();

                MessageBox.Show(varMessage, "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdMappedArea_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdMappedArea_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                var grid = sender as DataGridView;
                if (grid.IsCurrentCellDirty)
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_PurSearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdArea.DataSource = objDser.udfnGridSearchFilter(DGV_PurSearchGrid, grdArea);
                objDser.CloseConnection();
                grdArea.HorizontalScrollingOffset = DGV_PurSearchGrid.HorizontalScrollingOffset;
                //DGV_PurSearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_PurSearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_PurSearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }

        private void DGV_PurSearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        e.Handled = true;
                    }

                DGV_PurSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_PurSearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_PurSearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdArea.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdArea.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdArea.SortOrder == SortOrder.Ascending)
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
                    grdArea.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_PurSearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_PurSearchGrid.HorizontalScrollingOffset = grdArea.HorizontalScrollingOffset;
                    DGV_PurSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_PurSearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdArea.ColumnCount > 0)
                {
                    grdArea.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_PurSearchGrid.HorizontalScrollingOffset = grdArea.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_PurSearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_PurSearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_PurSearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdArea.DataSource = objDser.udfnGridSearchFilter(DGV_PurSearchGrid, grdArea);
                objDser.CloseConnection();
                grdArea.HorizontalScrollingOffset = DGV_PurSearchGrid.HorizontalScrollingOffset;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_PurSearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdArea.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_PurSearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdArea.Width > grdArea.HorizontalScrollingOffset && grdArea.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_PurSearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_PurSearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_PurMappedSearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdMappedArea.DataSource = objDser.udfnGridSearchFilter(DGV_PurMappedSearchGrid, grdMappedArea);
                objDser.CloseConnection();
                grdMappedArea.HorizontalScrollingOffset = DGV_PurMappedSearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_PurMappedSearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_PurMappedSearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }

        private void DGV_PurMappedSearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_PurMappedSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_PurMappedSearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_PurMappedSearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdMappedArea.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdMappedArea.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn
                            &&
                            grdMappedArea.SortOrder == SortOrder.Ascending
                            )
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
                    grdMappedArea.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_PurMappedSearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_PurMappedSearchGrid.HorizontalScrollingOffset = grdMappedArea.HorizontalScrollingOffset;
                    DGV_PurMappedSearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_PurMappedSearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdMappedArea.ColumnCount > 0)
                {
                    grdMappedArea.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_PurMappedSearchGrid.HorizontalScrollingOffset = grdMappedArea.HorizontalScrollingOffset;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_PurMappedSearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_PurMappedSearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_PurMappedSearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdMappedArea.DataSource = objDser.udfnGridSearchFilter(DGV_PurMappedSearchGrid, grdMappedArea);
                objDser.CloseConnection();
                grdMappedArea.HorizontalScrollingOffset = DGV_PurMappedSearchGrid.HorizontalScrollingOffset;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_PurMappedSearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdMappedArea.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_PurMappedSearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdMappedArea.Width > grdMappedArea.HorizontalScrollingOffset && grdMappedArea.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_PurMappedSearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_PurMappedSearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
