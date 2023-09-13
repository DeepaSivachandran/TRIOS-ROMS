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
    //Created By:- Sathish
    //Created On:- 02-09-2023
    public partial class CP_RackSettings : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tpProductGroup = new ToolTip();
        private ToolTip tpProductSubGroup = new ToolTip();

        public DataTable dtSupplierMapping = new DataTable();
        public DataTable dtViewSupplierMapping = new DataTable();

        public int varId = 0;
        public int varGroupId = 0;
        public int varSubGroupId = 0;
        public int varCheckAllFlag = 0;
        public string varProductID = "";
        public int varUpdate = 0;
        public int varRacksettingID = 0;
        public int PbRKID = 0;
        public string PbStockLocation = "";
        public string PbRackName = "";
        public string PbPICode = "";
        public string PbProductName = "";
        public string PbUnit = "";

        public CP_RackSettings()
        {
            InitializeComponent();
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Supplier = new CP_Supplier();
                MainForm.objCP_Supplier.ShowDialog();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsbDelete_Click(object sender, EventArgs e)
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

        private void CP_BrandList_Load(object sender, EventArgs e)
        {
            try
            {
                grbDestination.Visible = false;
                dtSupplierMapping = new DataTable();
                dtSupplierMapping.Columns.Add("", typeof(Boolean));
                dtSupplierMapping.Columns.Add("S.No.", typeof(string));
                dtSupplierMapping.Columns.Add("P.I Code", typeof(string));
                dtSupplierMapping.Columns.Add("Product Name in English", typeof(string));
                dtSupplierMapping.Columns.Add("Product Name in Tamil", typeof(string));
                dtSupplierMapping.Columns.Add("Unit", typeof(string));
                dtSupplierMapping.Columns.Add("PRODUCTID", typeof(int));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_BrandList_KeyDown(object sender, KeyEventArgs e)
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
        }
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
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
        private void RbMove_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbAdd.Checked == true)
                {
                    grbDestination.Visible = false;
                }
                else
                {
                    grbDestination.Visible = true;
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;




                if (blnErrorFlag == false)
                {
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
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
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "RackSettings Creation";
                    if (rbAdd.Checked == true)
                    {
                        varType = 0;
                    }
                    else
                    {
                        varType = 3;
                    }
                }
                else
                {
                    varoriginator = "RackSettings Updation";
                    varType = 1;
                }
                varProductID = ""; 
                for (int i = 0; i < grdViewSupplierMapping.RowCount; i++)
                {
                    if (varProductID == "")
                    {
                        varProductID = Convert.ToString(grdViewSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
                    }
                    else
                    {
                        varProductID = varProductID + "," + Convert.ToString(grdViewSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
                    }
                }


                int varLocationId = 0;
                if (txtLocation.Text == "")
                {
                    varLocationId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_Location = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_StockLocation WHERE SL_EName = '" + txtLocation.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT SLID FROM MR_StockLocation WHERE SL_EName = '" + txtLocation.Text.Trim() + "') END AS SLID ");
                    objDServ.CloseConnection();
                    varLocationId = Convert.ToInt32(varId_Location);
                }
                int varRackId = 0;
                if (txtRack.Text == "")
                {
                    varRackId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_Rack = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_Rack WHERE RK_Name = '" + txtRack.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT RKID FROM MR_Rack WHERE RK_Name = '" + txtRack.Text.Trim() + "') END AS RKID ");
                    objDServ.CloseConnection();
                    varRackId = Convert.ToInt32(varId_Rack);
                }

                int varDLocationId = 0;
                if (txtDLocation.Text == "")
                {
                    varDLocationId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_DLocation = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_StockLocation WHERE SL_EName = '" + txtDLocation.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT SLID FROM MR_StockLocation WHERE SL_EName = '" + txtDLocation.Text.Trim() + "') END AS SLID ");
                    objDServ.CloseConnection();
                    varDLocationId = Convert.ToInt32(varId_DLocation);
                }
                int varDRackId = 0;
                if (txtDRack.Text == "")
                {
                    varDRackId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_DRack = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_Rack WHERE RK_Name = '" + txtDRack.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT RKID FROM MR_Rack WHERE RK_Name = '" + txtDRack.Text.Trim() + "') END AS RKID ");
                    objDServ.CloseConnection();
                    varDRackId = Convert.ToInt32(varId_DRack);
                }

                varResult = objspservice.udfnRackSettings(varType,0,varLocationId,varRackId, varProductID, varDLocationId,varDRackId,varoriginator);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_RackSettinglist.udfnList();
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
                    }
                    udfnclear();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        public void udfnclear()
        {
            
        }

        private void BtnSave_Enter(object sender, EventArgs e)
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

        private void BtnSave_Leave(object sender, EventArgs e)
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

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;

                

                if (blnErrorFlag == false)
                {
                    //btnSave.Enabled = false;
                    try
                    {
                        udfnList();
                        for (int j = 0; j < grdSupplierMapping.RowCount; j++)
                        {
                            if (Convert.ToString(grdViewSupplierMapping.Rows[j].Cells["PRODUCTID"].Value) == Convert.ToString(grdSupplierMapping.Rows[j].Cells["PRODUCTID"].Value))
                            {
                                grdSupplierMapping.Rows[j].Cells[0].Value = true;
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnList()
        {
            try
            {
                int varViewType =13;
                
                dtSupplierMapping.Rows.Clear();
                Application.DoEvents();
                grdSupplierMapping.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                int varGroupId = 0;
                if (txtProductGroup.Text == "")
                {
                    varGroupId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_Group = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_ProductGroup WHERE PRG_EName = '" + txtProductGroup.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT PRGID FROM MR_ProductGroup WHERE PRG_EName = '" + txtProductGroup.Text.Trim() + "') END AS PRGID ");
                    objDServ.CloseConnection();
                    varGroupId = Convert.ToInt32(varId_Group);
                }

                int varSubGroupId = 0;
                if (txtProductSubGroup.Text == "")
                {
                    varSubGroupId = 0;
                }
                else
                {
                    DataService objDServ = new DataService();
                    string varId_SubGroup = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_ProductSubGroup WHERE PRSG_EName = '" + txtProductSubGroup.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT PRSGID FROM MR_ProductSubGroup WHERE PRSG_EName = '" + txtProductSubGroup.Text.Trim() + "') END AS PRSGID ");
                    objDServ.CloseConnection();
                    varSubGroupId = Convert.ToInt32(varId_SubGroup);
                }
                objDs = objdserv.udfnproductmasterlist(varViewType, 0, 0, varGroupId,varSubGroupId, "", "", "", 0);
                objdserv.CloseConnection();

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtSupplierMapping.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in English"],
                           objDs.Tables[0].Rows[i]["Product Name in Tamil"], objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["PRODUCTID"]);
                    }
                }
                grdSupplierMapping.DataSource = null;
                grdSupplierMapping.DataSource = dtSupplierMapping;
                grdSupplierMapping.Columns[0].HeaderText = "";
                grdSupplierMapping.Columns[0].Width = 50;
                grdSupplierMapping.Columns["S.No."].Width = 50;
                grdSupplierMapping.Columns["PRODUCTID"].Visible =false;
                grdSupplierMapping.Columns["P.I Code"].Width = 100;
                grdSupplierMapping.Columns["Product Name in English"].Width = 200;
                grdSupplierMapping.Columns["Product Name in Tamil"].Width = 200;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdSupplierMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    udfnCalculateCheckedCount();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnCalculateCheckedCount()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdSupplierMapping.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSupplierMapping.Rows[i].Cells[0].EditedFormattedValue) == true)
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
            finally
            {
                if (grdSupplierMapping.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag = 1;
                    chkRackSettings.Checked = true;
                }
                else
                {
                    varCheckAllFlag = 1;
                    chkRackSettings.Checked = false;
                }
            }
        }
        private void ChkRackSettings_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (varCheckAllFlag != 1)
                {
                    for (int i = 0; i < grdSupplierMapping.Rows.Count; i++)
                    {
                        grdSupplierMapping.Rows[i].Cells[0].Value = chkRackSettings.Checked;
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                udfnViewSupplier();
                //udfnTotalSuppliers();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnViewSupplier()
        {
            try
            {
                string varRemoveRack = "", varAddRack = "";

                if (grdSupplierMapping.Rows.Count > 0)
                {
                    for (int i = 0; i < grdSupplierMapping.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdSupplierMapping.Rows[i].Cells[0].Value) == true)
                        {
                            int varFlag = 0, varcount = 1; ;

                            for (int j = 0; j < grdViewSupplierMapping.Rows.Count; j++)
                            {
                                varAddRack = Convert.ToString(grdSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
                                if (varAddRack == Convert.ToString(grdViewSupplierMapping.Rows[j].Cells["PRODUCTID"].Value))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                grdViewSupplierMapping.Rows.Add(Convert.ToInt32(grdViewSupplierMapping.Rows.Count) + 1, grdSupplierMapping.Rows[i].Cells["P.I Code"].Value, grdSupplierMapping.Rows[i].Cells["Product Name in English"].Value,
                                    grdSupplierMapping.Rows[i].Cells["Product Name in Tamil"].Value, grdSupplierMapping.Rows[i].Cells["Unit"].Value ,grdSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
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
        
        private void GrdViewSupplierMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdViewSupplierMapping.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemoveSupplier":

                            grdViewSupplierMapping.Rows.RemoveAt(this.grdViewSupplierMapping.SelectedRows[0].Index);
                            for (int i = 0; i < grdViewSupplierMapping.RowCount; i++)
                            {
                                grdViewSupplierMapping.Rows[i].Cells["clmsno"].Value = i + 1;
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

        private void TxtSearchByProduct1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSupplierMapping.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtSearchByProduct1.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdViewSupplierMapping.DataSource as DataTable).DefaultView.RowFilter = "([clmProductEnglish]) LIKE '%" + txtSearchByProduct2.Text + "%'or ([clmdpicode]) LIKE '%" + txtSearchByProduct2.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_RackSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varUpdate == 0)
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
        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtLocation.Text.Length > 0)
                {

                    objDs = objspdservice.udfnStockLocationList(12, 0, 0, 0, txtLocation.Text);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvLocation.Columns[1].Width = 0;
                                    lvLocation.Items.Add(objList);
                                }
                                lvLocation.Visible = true;
                            }
                            else
                            {
                                lvLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvLocation.Visible = false;
                    }
                }
                else
                {
                    lvLocation.Visible = false;
                    lvLocation.Items.Clear();
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

        private void TxtLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvLocation.Items.Count == 0 || txtLocation.Text == "")
                    {
                        txtRack.Focus();
                        lvLocation.Visible = false;
                    }
                    else
                    {
                        lvLocation.Focus();
                    }
                    if (lvLocation.Items.Count > 0)
                    {
                        lvLocation.Items[0].Selected = true;
                    }
                }
                if(e.KeyCode==Keys.Enter)
                {
                    txtRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLocation.BackColor = Color.White;
                if (txtLocation.Text.Trim() == "") { lblSLocation.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSLocationEvent();
                txtRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSLocationEvent();
                    txtRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSLocationEvent()
        {
            try
            {
                if (txtLocation.Text != "")
                {
                    ListViewItem selectedItem = lvLocation.SelectedItems[0];
                    txtLocation.Text = selectedItem.SubItems[0].Text;
                    lblSLocation.Text = selectedItem.SubItems[1].Text;
                    //    lvCity.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvLocation.Visible = false;
            }
        }

        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int varLocationId = 0;
                lvRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRack.Text.Length > 0)
                {
                    if (txtLocation.Text == "")
                    {
                        varLocationId = 0;
                    }
                    else
                    {
                        DataService objDServ = new DataService();
                        string varId_Location = objDServ.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_StockLocation WHERE SL_EName = '" + txtLocation.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT SLID FROM MR_StockLocation WHERE SL_EName = '" + txtLocation.Text.Trim() + "') END AS SLID ");
                        objDServ.CloseConnection();
                        varLocationId = Convert.ToInt32(varId_Location);
                    }
                    if (varLocationId == 0)
                    { 
                        objDs = objspdservice.udfnRackList(7, 0, 0, varLocationId, 0, txtRack.Text);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["RK_Name"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        lvRack.Columns[1].Width = 0;
                                        lvRack.Items.Add(objList);
                                    }
                                    lvRack.Visible = true;
                                }
                                else
                                {
                                    lvRack.Visible = false;
                                }
                            }
                            else
                            {
                                lvRack.Visible = false;
                            }
                        }
                        else
                        {
                            lvRack.Visible = false;
                        }
                    }
                    else
                    {
                        epRackSettings.SetError(txtLocation, "Invalid Location");
                        txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtRack.Text = "";
                    }
                }
                else
                {
                    lvRack.Visible = false;
                    lvRack.Items.Clear();
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

        private void TxtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtLocation.Text.Trim() != "")
                {
                    string VarLocation = "0";
                    DataService objDserv = new DataService();
                    VarLocation = objDserv.displaydata("SELECT COUNT(*) AS Count FROM MR_StockLocation WHERE SL_EName ='" + txtLocation.Text.Trim() + "'");
                    if (VarLocation == "0")
                    {
                        lblSLocation.Text = "0";
                        epRackSettings.SetError(txtLocation, "Invalid Location");
                        txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtRack.Text = "";
                    }
                    else
                    {
                        txtLocation.BackColor = Color.White;
                        epRackSettings.Clear();
                    }
                }
                 
                if (lblSLocation.Text.Trim() != "0")
                {
                    lvLocation.Visible = false;
                    txtRack.BackColor = Color.LemonChiffon;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvRack.Items.Count == 0 || txtRack.Text == "")
                    {
                        //pnlStatus.Focus();
                        lvRack.Visible = false;
                    }
                    else
                    {
                        lvRack.Focus();
                    }
                    if (lvRack.Items.Count > 0)
                    {
                        lvRack.Items[0].Selected = true;
                    }
                }
                if(e.KeyCode==Keys.Enter)
                {
                    if(grbDestination.Enabled==true)
                    {
                        txtDLocation.Focus();
                    }
                    else
                    {
                        txtProductGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRack.Text.Trim() == "")
                { lblSRack.Text = "0"; }

                if (txtDRack.Text != "")
                {
                    if (lblSRack.Text == lblDRack.Text || txtDRack.Text == txtRack.Text)
                    {
                        txtDRack.Text = "";
                    }
                }


                //if (txtRack.Text.Trim() != "")
                //{
                //    //bool blnErrorFlag = false;
                //    string VarRack = "0";
                //    DataService objDserv = new DataService();
                //    VarRack = objDserv.displaydata("SELECT COUNT(*) AS Count FROM MR_Rack WHERE RK_Name ='" + txtRack.Text.Trim() + "'");
                //    if (VarRack == "0")
                //    {
                //        lblSRack.Text = "0";
                //        epRackSettings.SetError(txtRack, "Invalid Rack");
                //        txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        //blnErrorFlag = true;
                //    }
                //    else
                //    {
                //        txtRack.BackColor = Color.White;
                //        epRackSettings.Clear();
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSRackEvent();
                //if (pnlStatus.Enabled == false)
                //{
                //    btnSave.Focus();
                //}
                //else
                //{
                //    pnlStatus.Focus();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSRackEvent();
                    if (rbMove.Checked == true)
                    {
                        txtDLocation.Focus();
                    }
                    else
                    {
                        txtProductGroup.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSRackEvent()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    lblSRack.Text = selectedItem.SubItems[1].Text;
                    //    lvCity.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvRack.Visible = false;
            }
        }

        private void TxtDLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvDLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtDLocation.Text.Length > 0)
                {

                    objDs = objspdservice.udfnStockLocationList(12, 0, 0, 0, txtDLocation.Text);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvDLocation.Columns[1].Width = 0;
                                    lvDLocation.Items.Add(objList);
                                }
                                lvDLocation.Visible = true;
                            }
                            else
                            {
                                lvDLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvDLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvDLocation.Visible = false;
                    }
                }
                else
                {
                    lvDLocation.Visible = false;
                    lvDLocation.Items.Clear();
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

        private void TxtDLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvDLocation.Items.Count == 0 || txtDLocation.Text == "")
                    {
                        txtDRack.Focus();
                        lvDLocation.Visible = false;
                    }
                    else
                    {
                        lvDLocation.Focus();
                    }
                    if (lvDLocation.Items.Count > 0)
                    {
                        lvDLocation.Items[0].Selected = true;
                    }
                }
                if(e.KeyCode==Keys.Enter)
                {
                    txtDRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDLocation.BackColor = Color.White;
                if (txtDLocation.Text.Trim() == "") { lblDLocation.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvDRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtDRack.Text.Length > 0)
                {
                    if (lblDLocation.Text.Trim() != "0")
                    {
                        int varDLocationId = 0;
                        int varLocationId = 0;
                        int varRackId = 0;
                        if (txtDLocation.Text == "")
                        {
                            varDLocationId = 0;
                        }
                        else
                        {
                            if (lblSLocation.Text.Trim() == lblDLocation.Text.Trim())
                            {
                                DataService objdserv = new DataService();
                                string varId_Rack = objdserv.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_Rack WHERE RK_Name = '" + txtRack.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT RKID FROM MR_Rack WHERE RK_Name = '" + txtRack.Text.Trim() + "') END AS RKID ");
                                objdserv.CloseConnection();
                                varRackId = Convert.ToInt32(varId_Rack);
                            }
                            else
                            {
                                DataService objDerv = new DataService();
                                string varId_DDLocation = objDerv.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_StockLocation WHERE SL_EName = '" + txtDLocation.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT SLID FROM MR_StockLocation WHERE SL_EName = '" + txtDLocation.Text.Trim() + "') END AS SLID ");
                                objDerv.CloseConnection();
                                varLocationId = Convert.ToInt32(varId_DDLocation);
                            }
                            DataService objDserv = new DataService();
                            string varId_DLocation = objDserv.displaydata("SELECT CASE WHEN (SELECT COUNT(*) FROM MR_StockLocation WHERE SL_EName = '" + txtDLocation.Text.Trim() + "') = 0 THEN -1 ELSE(SELECT SLID FROM MR_StockLocation WHERE SL_EName = '" + txtDLocation.Text.Trim() + "') END AS SLID ");
                            objDserv.CloseConnection();
                            varLocationId = Convert.ToInt32(varId_DLocation);
                        }

                        objDs = objspdservice.udfnRackList(7, 0, 0, varLocationId, varRackId, txtDRack.Text);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["RK_Name"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        lvDRack.Columns[1].Width = 0;
                                        lvDRack.Items.Add(objList);
                                    }
                                    lvDRack.Visible = true;
                                }
                                else
                                {
                                    lvDRack.Visible = false;
                                }
                            }
                            else
                            {
                                lvDRack.Visible = false;
                            }
                        }
                        else
                        {
                            lvDRack.Visible = false;
                        }
                    }
                    else
                    {
                        epRackSettings.SetError(txtDLocation, "Invalid Location");
                        txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtDRack.Text = "";
                    }
                }
                else
                {
                    lvDRack.Visible = false;
                    lvDRack.Items.Clear();
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

        private void TxtDRack_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtDLocation.Text.Trim() != "")
                {
                    string VarDLocation = "0";
                    DataService objDserv = new DataService();
                    VarDLocation = objDserv.displaydata("SELECT COUNT(*) AS Count FROM MR_StockLocation WHERE SL_EName ='" + txtDLocation.Text.Trim() + "'");
                    if (VarDLocation == "0")
                    {
                        lblDLocation.Text = "0";
                        epRackSettings.SetError(txtDLocation, "Invalid Location");
                        txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        txtDRack.Text = "";
                    }
                    else
                    {
                        epRackSettings.Clear();
                    }
                }
                lvDLocation.Visible = false;
                txtDRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvDRack.Items.Count == 0 || txtDRack.Text == "")
                    {
                        //pnlStatus.Focus();
                        lvDRack.Visible = false;
                    }
                    else
                    {
                        lvDRack.Focus();
                    }
                    if (lvDRack.Items.Count > 0)
                    {
                        lvDRack.Items[0].Selected = true;
                    }
                }
                if(e.KeyCode==Keys.Enter)
                {
                    txtProductGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDRack.Text.Trim() == "") { lblDRack.Text = "0"; }


                //if (txtDRack.Text.Trim() != "")
                //{
                //    string VarDRack = "0";
                //    DataService objDserv = new DataService();
                //    VarDRack = objDserv.displaydata("SELECT COUNT(*) AS Count FROM MR_Rack WHERE RK_Name ='" + txtDRack.Text.Trim() + "'");
                //    if (VarDRack == "0")
                //    {
                //        lblDRack.Text = "0";
                //        epRackSettings.SetError(txtDRack, "Invalid Rack");
                //        txtDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    }
                //    else
                //    {
                //        txtDRack.BackColor = Color.White;
                //        epRackSettings.Clear();
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvDRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnDRackEvent();
                //if (pnlStatus.Enabled == false)
                //{
                //    btnSave.Focus();
                //}
                //else
                //{
                //    pnlStatus.Focus();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvDRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnDRackEvent();
                    txtProductGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDRackEvent()
        {
            try
            {
                if (txtDRack.Text != "")
                {
                    ListViewItem selectedItem = lvDRack.SelectedItems[0];
                    txtDRack.Text = selectedItem.SubItems[0].Text;
                    lblDRack.Text = selectedItem.SubItems[1].Text;
                    //    lvCity.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvDRack.Visible = false;
            }
        }

        private void LvDLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnDLocationEvent();
                txtDRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvDLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnDLocationEvent();
                    txtDRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDLocationEvent()
        {
            try
            {
                if (txtDLocation.Text != "")
                {
                    ListViewItem selectedItem = lvDLocation.SelectedItems[0];
                    txtDLocation.Text = selectedItem.SubItems[0].Text;
                    lblDLocation.Text = selectedItem.SubItems[1].Text;
                    //    lvCity.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvDLocation.Visible = false;
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
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtProductGroup.Text);
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
                                    lvGroup.Columns[2].Width = 200;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode==Keys.Enter)
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
                if(e.KeyCode==Keys.Enter)
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
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", 0, 0, txtProductSubGroup.Text);
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
                                    lvSubGroup.Columns[2].Width = 200;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode==Keys.Enter)
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
                if(e.KeyCode==Keys.Enter)
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
                    btnView.Focus();
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
    }
}
