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
    public partial class CP_RackGroup : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpRackGroupName = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpStaffName = new ToolTip();
      
        public string vargroupcode="";
        public String pbFormStatus="";
        public String varDesignation="";
        public String varUserID = "";
        public String varRackID = "";
        public String varUserId = "";
        public int varStockId = 0;
        public int varStatusid = 1;
        public int varConcernId = 0;
       // public int varStockLocationId = 0;
        public DataTable dtRack = new DataTable();
        public DataTable dtSelectedRack = new DataTable();
        public int varId = 0;
        public int varCloseFlag = 0;
        public int varCmbFlag = 0;
        public int varCompanyId = 0;
        public int varCheckAllFlag = 0;

        public CP_RackGroup()
        {
            InitializeComponent();
        }
        private void CP_RackGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpStockLocation.Active = false;
                tpRackGroupName.Active = false;
                tpStaffName.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_RackGroup_Load(object sender, EventArgs e)
        {
            try
            {
                dtRack = new DataTable();
               //dtSelectedRack = new DataTable();

                dtRack.Columns.Add("", typeof(Boolean));
                dtRack.Columns.Add("S.No.", typeof(string));
                dtRack.Columns.Add("Concern", typeof(string));
                dtRack.Columns.Add("Stock Location", typeof(string));
                dtRack.Columns.Add("Rack", typeof(string));
                dtRack.Columns.Add("Short Name", typeof(string));
                dtRack.Columns.Add("Description", typeof(string));
                dtRack.Columns.Add("Total Products", typeof(int));
                dtRack.Columns.Add("Status", typeof(string));
                dtRack.Columns.Add("ID", typeof(int));
                dtRack.Columns.Add("Concern ID", typeof(int));
                dtRack.Columns.Add("StockLocation ID", typeof(int));
                dtRack.Columns.Add("Status ID", typeof(int));

                udfnCmbConcern();

                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnEdit();
                    varCmbFlag = 1;
                }
              //  udfnList();
                udfnTotalProducts();
                grdStaffDetails.Columns["clmUserId"].Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTotalProducts()
        {
            int varCount = 0;
            try
            {
                if (grdSelectedRack.Rows.Count != 0)
                {
                    for (int i = 0; i < grdSelectedRack.RowCount; i++)
                    {
                        if (Convert.ToInt32(grdSelectedRack.Rows[i].Cells["clmTotalProducts"].Value) != 0)
                        {
                            varCount = varCount + Convert.ToInt32(grdSelectedRack.Rows[i].Cells["clmTotalProducts"].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { lblTotalProduct.Text = Convert.ToString(varCount); }
        }

        public void udfnCmbConcern()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varViewType = 3, varConcernId = 0;
                if(btnSave.Text=="Update")
                {
                    varViewType = 4;
                    varConcernId = varCompanyId;
                }
                objDT = objdserv.udfnCompanyList(varViewType, varConcernId, MainForm.pbUserID, MainForm.pbIpAddress);
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
        public void udfncmbShopLocation()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varRackGroupID = 0;
                int varViewType = 2;
                if (btnSave.Text == "Save")
                {
                    if (varConcernId == -1)
                    {
                        varViewType = 3;
                    }
                    else { varViewType = 4; }
                }
                else {
                    if (varConcernId == -1)
                    {
                        varViewType = 3;
                    }
                    else { varViewType = 5; varRackGroupID = varId; }
                }
                objDT = objdserv.udfnStockLocationList(varViewType, varConcernId,varStockId, varRackGroupID,"");
                objdserv.CloseConnection();
                cmbStockLocation.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbStockLocation.ValueMember = "SLID";
                            cmbStockLocation.DisplayMember = "SL_EName";
                            cmbStockLocation.DataSource = objDT.Tables[0];
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
        public void udfnList()
        {
            try
            {
                int varViewType = 1;
                if(btnSave.Text=="Update")
                {
                    varViewType = 2;
                }
                dtRack.Rows.Clear();
                Application.DoEvents();
                grdRack.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
               objDs = objdserv.udfnRackList(varViewType, 0,varConcernId, varStockId,0,"");
                objdserv.CloseConnection();
                
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtRack.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["Concern"], objDs.Tables[0].Rows[i]["Stock Location"],
                           objDs.Tables[0].Rows[i]["Rack Name"], objDs.Tables[0].Rows[i]["Short Name"], objDs.Tables[0].Rows[i]["Description"], 
                           objDs.Tables[0].Rows[i]["Total Products"], objDs.Tables[0].Rows[i]["Status"], objDs.Tables[0].Rows[i]["ID"], objDs.Tables[0].Rows[i]["ConcernID"],
                           objDs.Tables[0].Rows[i]["StockLocationID"], objDs.Tables[0].Rows[i]["StatusID"]);
                    }
                }
                grdRack.DataSource = null;
                grdRack.DataSource = dtRack;
                grdRack.Columns[0].HeaderText = "";
                grdRack.Columns[0].Width = 50;
                grdRack.Columns["S.No."].Width = 50;
                grdRack.Columns["Rack"].Width = 100;
                grdRack.Columns["Description"].Width = 100;
                grdRack.Columns["Total Products"].Width = 100;
                grdRack.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                grdRack.Columns["Concern"].Visible = false;
                grdRack.Columns["Stock Location"].Visible = false;
                grdRack.Columns["Short Name"].Visible = false;
                grdRack.Columns["Status"].Visible = false;
                grdRack.Columns["ID"].Visible = false;
                grdRack.Columns["Concern ID"].Visible = false;
                grdRack.Columns["Status ID"].Visible = false;
                grdRack.Columns["StockLocation ID"].Visible = false;

                grdRack.Columns[0].ReadOnly = false;
                grdRack.Columns["S.No."].ReadOnly = true;
                grdRack.Columns["Rack"].ReadOnly = true;
                grdRack.Columns["Description"].ReadOnly = true;
                grdRack.Columns["Total Products"].ReadOnly = true;
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
                if (varStatusid == 1)
                {
                    rbActive.Checked = true;
                }
                else 
                {
                    rbInactive.Checked = true;
                }
              
                DataSet objDS = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDS = objdserv.udfnRackGroupList(1,0, varStockId, varId);
                objdserv.CloseConnection();
                if (objDS != null)
                {
                    
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["RKG_COMID"].ToString().Replace("''", "'");
                        txtRackGroupName.Text = objDS.Tables[0].Rows[0]["RKG_Name"].ToString().Replace("''", "'");
                    }
                    cmbStockLocation.SelectedValue = varStockId;
                    udfnList();
                    if (objDS.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                        {
                            grdStaffDetails.Rows.Add(grdStaffDetails.Rows.Count + 1, Convert.ToString(objDS.Tables[1].Rows[i]["U_Name"]), Convert.ToString(objDS.Tables[1].Rows[i]["CT_Name"]), Convert.ToInt16(objDS.Tables[1].Rows[i]["RKGU_UID"]));
                        }
                    }
                    if (objDS.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                        {
                            grdSelectedRack.Rows.Add(grdSelectedRack.Rows.Count + 1, Convert.ToString(objDS.Tables[2].Rows[i]["RK_Name"]), Convert.ToString(objDS.Tables[2].Rows[i]["RK_Description"]), Convert.ToInt16(objDS.Tables[2].Rows[i]["TotalProducts"]), Convert.ToInt16(objDS.Tables[2].Rows[i]["RKID"]));
                        }
                    }
                    for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                    {
                        for (int j = 0; j < grdRack.RowCount; j++)
                        {
                            if (Convert.ToString(objDS.Tables[2].Rows[i]["RKID"]) == Convert.ToString(grdRack.Rows[j].Cells["ID"].Value))
                            {
                                grdRack.Rows[j].Cells[0].Value = true;
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                string varResult = "";
                if (rbActive.Checked)
                {
                    varStatusid = 1;
                }
                else 
                {
                    varStatusid = 2;
                }
                varRackID = "";  varUserID = "";
                for (int i = 0; i < grdSelectedRack.RowCount; i++)
                {
                    if (varRackID == "")
                    {
                        varRackID = Convert.ToString(grdSelectedRack.Rows[i].Cells["ID"].Value);
                    }
                    else
                    {
                        varRackID = varRackID + "," + Convert.ToString(grdSelectedRack.Rows[i].Cells["ID"].Value);
                    }
                }
                for (int i = 0; i < grdStaffDetails.RowCount; i++)
                {
                    if (varUserID == "")
                    {
                        varUserID = Convert.ToString(grdStaffDetails.Rows[i].Cells["clmUserId"].Value);
                    }
                    else
                    {
                        varUserID = varUserID + "," + Convert.ToString(grdStaffDetails.Rows[i].Cells["clmUserId"].Value);
                    }
                }
                SPDataService objDser = new SPDataService();
                if (btnSave.Text == "Save")
                {
                    varResult = objDser.udfnRackGroup(0, 0, Convert.ToInt16(cmbConcern.SelectedValue), txtRackGroupName.Text, varRackID, varUserID, varStatusid, "Rack Group Creation");
                }
                else
                {
                    varResult = objDser.udfnRackGroup(1, varId, Convert.ToInt16(cmbConcern.SelectedValue), txtRackGroupName.Text, varRackID, varUserID, varStatusid, "Rack Group Updation");
                }
                objDser.CloseConnection();
                btnSave.Enabled = true;
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnSave.Text == "Save")
                    {
                        udfnClear();
                    }
                    else
                    {
                        varCloseFlag = 1;
                        udfnclose();
                    }
                    MainForm.objCP_RackGroupList.udfnList();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Focus();
                }
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        {
            try
            {
                txtRackGroupName.Text = "";
                cmbConcern.SelectedValue = -1;
                grdRack.DataSource = null;
                grdSelectedRack.Rows.Clear();
                grdStaffDetails.Rows.Clear();
                chkRack.Checked = false;
                tpStaffName.Active = false;
                cmbConcern.Focus();
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
                if (Convert.ToString(cmbConcern.SelectedItem) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epRackGroup.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtRackGroupName.Text).Trim() == "")
                {
                    epRackGroup.SetError(txtRackGroupName, "Please enter rack group name");
                    txtRackGroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRackGroupName.ShowAlways = true;
                    tpRackGroupName.Show("Please enter rack group name", txtRackGroupName, 5000);
                    blnErrorFlag = true;

                }
                if (grdSelectedRack.Rows.Count <= 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Please select atleast one rack", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    udfnSave(sender, e);
                }
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave_Click(sender, e);
                }
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string varAddStaff = ""; int varFlag = 0; string varStaffName = "";
                if (Convert.ToString(txtStaffName.Text).Trim() == "")
                {
                    epRackGroup.SetError(txtStaffName, "Please enter staff name");
                    txtStaffName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStaffName.ShowAlways = true;
                    tpStaffName.Show("Please enter staff name", txtStaffName, 5000);
                }
                else
                {
                    DataService objDserv = new DataService();
                    varStaffName = objDserv.displaydata("SELECT COUNT(*) FROM MR_User WHERE U_Name='" + txtStaffName.Text + "'");
                    if (varStaffName == "0")
                    {
                        varUserID = "0";
                        epRackGroup.SetError(txtStaffName, "Invalid staff name");
                        txtStaffName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStaffName.ShowAlways = true;
                        tpStaffName.Show("Please enter valid staff name", txtStaffName, 5000);
                    }
                    else
                    {
                        for (int i = 0; i < grdStaffDetails.Rows.Count; i++)
                        {
                            varFlag = 0;
                            
                            varAddStaff = varUserID;
                            if (varAddStaff == Convert.ToString(grdStaffDetails.Rows[i].Cells["clmUserId"].Value))
                            {
                                varFlag = 1;
                                DialogResult dialogResult = MessageBox.Show("Staff name already exists", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        if (varFlag == 0)
                        {
                            grdStaffDetails.Rows.Add(grdStaffDetails.Rows.Count + 1, txtStaffName.Text, varDesignation, varUserID);
                        }
                        txtStaffName.Focus();
                    }
                    txtStaffName.Text = "";
                    varDesignation = "";
                    varUserId = "";
                    tpStaffName.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdStaffDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdStaffDetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmremove":

                            grdStaffDetails.Rows.RemoveAt(this.grdStaffDetails.SelectedRows[0].Index);
                            for (int i = 0; i < grdStaffDetails.RowCount; i++)
                            {
                                grdStaffDetails.Rows[i].Cells["clmSno"].Value = i + 1;
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
        private void DGV_Racklist_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdRack.SelectedRows[0].Cells["Total Products"].Value) != 0)
                {
                    MainForm.objCP_ProductDetails = new CP_ProductDetails();
                    MainForm.objCP_ProductDetails.varRackId = Convert.ToInt32(grdRack.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_ProductDetails.varRackName = Convert.ToString(grdRack.SelectedRows[0].Cells["Rack"].Value);
                    MainForm.objCP_ProductDetails.varDescription = Convert.ToString(grdRack.SelectedRows[0].Cells["Description"].Value);
                    MainForm.objCP_ProductDetails.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdSelectedRackList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(grdSelectedRack.SelectedRows[0].Cells["clmTotalProducts"].Value) != 0)
                {
                    MainForm.objCP_ProductDetails = new CP_ProductDetails();
                    MainForm.objCP_ProductDetails.varRackId = Convert.ToInt32(grdSelectedRack.SelectedRows[0].Cells["ID"].Value);
                    MainForm.objCP_ProductDetails.varRackName = Convert.ToString(grdSelectedRack.SelectedRows[0].Cells["clmRack"].Value);
                    MainForm.objCP_ProductDetails.varDescription = Convert.ToString(grdSelectedRack.SelectedRows[0].Cells["clmDescription"].Value);
                    MainForm.objCP_ProductDetails.ShowDialog();
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
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epRackGroup.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epRackGroup.Clear();
                    cmbConcern.BackColor = Color.White;
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
                varConcernId = Convert.ToInt16(cmbConcern.SelectedValue);
                udfncmbShopLocation();
                grdRack.DataSource = null;
                grdSelectedRack.Rows.Clear();
                chkRack.Checked = false;
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
                    txtRackGroupName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRackGroupName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRackGroupName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRackGroupName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtRackGroupName.Text).Trim() == "")
                {
                    epRackGroup.SetError(txtRackGroupName, "Please enter rack group name");
                    txtRackGroupName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRackGroupName.ShowAlways = true;
                    tpRackGroupName.Show("Please enter rack group name", txtRackGroupName, 5000);

                }
                else
                {
                    epRackGroup.Clear();
                    txtRackGroupName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRackGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStockLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockLocation_Enter(object sender, EventArgs e)
        {

            try
            {
                cmbStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockLocation_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbStockLocation_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStockLocation.BackColor = Color.White; 
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
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Add_Enter(object sender, EventArgs e)
        {
            try
            {
                Add.BackColor = Color.LemonChiffon;
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
        private void Add_Leave(object sender, EventArgs e)
        {

            try
            {
                Add.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStaffName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStaffName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtStaffName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStaffName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSelectedRackList_KeyDown(object sender, KeyEventArgs e)
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

        private void DgvStaffDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbActive.Focus();
                }
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

        private void RbInactive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInactive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_RackGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void TxtStaffName_KeyDown(object sender, KeyEventArgs e)
        {
             try
             {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvStaffName.Items.Count == 0 || txtStaffName.Text == "")
                    {
                        txtStaffName.Focus();
                       // lvStaffName.Visible = false;
                    }
                    else
                    {
                        lvStaffName.Focus();
                    }
                    if (lvStaffName.Items.Count > 0)
                    {
                        lvStaffName.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
             }
             catch (Exception ex)
             {
                objError = new DataError();
                objError.WriteFile(ex);
             }
        }

        private void CP_RackGroup_KeyDown(object sender, KeyEventArgs e)
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

        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                varStockId = Convert.ToInt32(cmbStockLocation.SelectedValue);
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
                for (int j = 0; j < grdRack.RowCount; j++)
                {
                    if (Convert.ToString(grdSelectedRack.Rows[j].Cells["ID"].Value) == Convert.ToString(grdRack.Rows[j].Cells["ID"].Value))
                    {
                        grdRack.Rows[j].Cells[0].Value = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //Added by deepa on 01-09-2023
        public void udfnCaculateCheckedCount()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdRack.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdRack.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        varCheckedCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally {
                if (grdRack.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag = 1;
                    chkRack.Checked = true;
                }
                else {
                    varCheckAllFlag = 1;
                    chkRack.Checked = false;
                }
            }
        }
        public void udfnSelectedRack()
        {
            try
            {
                string varRemoveRack = "", varAddRack = "";

                if (grdRack.Rows.Count > 0)
                {
                    for (int i = 0; i < grdRack.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdRack.Rows[i].Cells[0].Value) == true)
                        {
                            int varFlag = 0, varcount = 1; ;
                          
                            for (int j = 0; j < grdSelectedRack.Rows.Count; j++)
                            {
                                varAddRack = Convert.ToString(grdRack.Rows[i].Cells["ID"].Value);
                                if (varAddRack == Convert.ToString(grdSelectedRack.Rows[j].Cells["ID"].Value))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                grdSelectedRack.Rows.Add(Convert.ToInt32(grdSelectedRack.Rows.Count) + 1, grdRack.Rows[i].Cells["Rack"].Value, grdRack.Rows[i].Cells["Description"].Value,
                                    grdRack.Rows[i].Cells["Total Products"].Value, grdRack.Rows[i].Cells["ID"].Value);
                            }
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSelectedRack();
                //if (chkRack.Checked == false)
                //{
                //    grdSelectedRack.Rows.Clear();
                //}
                udfnTotalProducts();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkRack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (varCheckAllFlag != 1)
                {
                    for (int i = 0; i < grdRack.Rows.Count; i++)
                    {
                        grdRack.Rows[i].Cells[0].Value = chkRack.Checked;

                    }
                }
                else
                {
                    varCheckAllFlag = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSelectedRack_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdSelectedRack.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemoveRack":

                            grdSelectedRack.Rows.RemoveAt(this.grdSelectedRack.SelectedRows[0].Index);
                            for (int i = 0; i < grdSelectedRack.RowCount; i++)
                            {
                                grdSelectedRack.Rows[i].Cells["columnSNo"].Value = i + 1;
                            }
                            udfnTotalProducts();
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
        public void udfnlvStaffname()
        {
            try
            {
                if (txtStaffName.Text != "")
                {
                    ListViewItem selectedItem = lvStaffName.SelectedItems[0];
                    txtStaffName.Text = selectedItem.SubItems[0].Text;
                    varDesignation = selectedItem.SubItems[1].Text;
                    varUserID = selectedItem.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvStaffName.Visible = false;
            }
        }

        private void TxtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvStaffName.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStaffName.Text.Length > 2)
                {
                    objDs = objspdservice.udfnUserList(1, txtStaffName.Text, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                   string[] row = { objDs.Tables[0].Rows[i]["U_Name"].ToString(), objDs.Tables[0].Rows[i]["Designation"].ToString(), objDs.Tables[0].Rows[i]["UID"].ToString()};
                                   
                                    ListViewItem objList = new ListViewItem(row);
                                    lvStaffName.Items.Add(objList);
                                }
                                lvStaffName.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvStaffName.Visible = false;
                    lvStaffName.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStaffName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnlvStaffname();
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStaffName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                udfnlvStaffname();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdRack_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) {
                    udfnCaculateCheckedCount();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Add_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Add_Click(sender, e);
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
