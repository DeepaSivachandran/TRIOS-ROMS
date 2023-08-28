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
        public int varStatusid = 1;

        public int varStockLocationId = 0;
        public DataTable dtRack = new DataTable();
        public DataTable dtSelectedRack = new DataTable();

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
                dtSelectedRack = new DataTable();

                dtRack.Columns.Add("", typeof(Boolean));
                dtRack.Columns.Add("S.No.", typeof(string));
                dtRack.Columns.Add("Concern", typeof(string));
                dtRack.Columns.Add("Stock Location", typeof(string));
                dtRack.Columns.Add("Rack Group", typeof(string));
                dtRack.Columns.Add("Rack", typeof(string));
                dtRack.Columns.Add("Short Name", typeof(string));
                dtRack.Columns.Add("Description", typeof(string));
                dtRack.Columns.Add("Total Products", typeof(int));
                dtRack.Columns.Add("Status", typeof(string));
                dtRack.Columns.Add("ID", typeof(int));
                dtRack.Columns.Add("Concern ID", typeof(int));
                dtRack.Columns.Add("StockLocation ID", typeof(int));
                dtRack.Columns.Add("Status ID", typeof(int));

                dtSelectedRack.Columns.Add("S.No.", typeof(string));
                dtSelectedRack.Columns.Add("Rack", typeof(string));
                dtSelectedRack.Columns.Add("Description", typeof(string));
                dtSelectedRack.Columns.Add("Total Products", typeof(int));
                dtSelectedRack.Columns.Add("ID", typeof(int));
                dtSelectedRack.Columns.Add("Remove", typeof(Boolean));

                udfnList();
                udfnCmbConcern();
                udfncmbShopLocation();
               
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnEdit();
                }
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Company", " COMID not in (0)", "COMID,COM_ShortName", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind = null;
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_StockLocation", "SLID NOT IN(0)", "SLID,SL_EName", cmbStockLocation, "", "SL_EName", "SLID");
                objDataBind = null;
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
                dtRack.Rows.Clear();
                Application.DoEvents();
                grdRack.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnRackList(0, 0, varStockLocationId);
                objdserv.CloseConnection();

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtRack.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["Concern"], objDs.Tables[0].Rows[i]["Stock Location"],
                           objDs.Tables[0].Rows[i]["Rack Group"],objDs.Tables[0].Rows[i]["Rack Name"], objDs.Tables[0].Rows[i]["Short Name"], objDs.Tables[0].Rows[i]["Description"], 
                           objDs.Tables[0].Rows[i]["Total Products"], objDs.Tables[0].Rows[i]["Status"], objDs.Tables[0].Rows[i]["ID"], objDs.Tables[0].Rows[i]["ConcernID"],
                           objDs.Tables[0].Rows[i]["StockLocationID"], objDs.Tables[0].Rows[i]["StatusID"]);
                    }
                }

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
                grdRack.Columns["Rack Group"].Visible = false;
                grdRack.Columns["Short Name"].Visible = false;
                grdRack.Columns["Status"].Visible = false;
                grdRack.Columns["ID"].Visible = false;
                grdRack.Columns["Concern ID"].Visible = false;
                grdRack.Columns["StockLocation ID"].Visible = false;
                grdRack.Columns["Status ID"].Visible = false;

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
                if (vargroupcode != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS = new DataSet();
                   // objDS = objspservice.udfnSPGroupList("EditLoad", vargroupcode, "0", MainForm.pbUserID, MainForm.pbIpAddress);
                    objspservice.CloseConnection();

                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            //cmbGroupType.SelectedValue = objDS.Tables[0].Rows[0]["GroupTypeCode"].ToString();
                            //txtTGroupName.Text = objDS.Tables[0].Rows[0]["GTName"].ToString().Replace("''", "'");
                            //txtEGroupName.Text = objDS.Tables[0].Rows[0]["GEName"].ToString().Replace("''", "'");
                            //txtTLabelName.Text = objDS.Tables[0].Rows[0]["GTLabelName"].ToString().Replace("''", "'");
                            //txtELabelName.Text = objDS.Tables[0].Rows[0]["GELabelName"].ToString().Replace("''", "'");
                            //udfnLoadSlNo();
                            //cmbSINO.SelectedValue = objDS.Tables[0].Rows[0]["SINO"].ToString();
                            //if (Convert.ToString(objDS.Tables[0].Rows[0]["RawCount"]) != "0" || Convert.ToString(objDS.Tables[0].Rows[0]["FinishedCount"]) != "0") {
                            //    cmbGroupType.Enabled = false;
                            //}
                            btnSave.Text = "Update";
                        }
                    }

                }
                else {// udfnLoadSlNo(); 
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
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
                    
                }
                objDser.CloseConnection();
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnSave.Text == "Save")
                    {
                            //udfnclose();
                         
                         // udfnClear();
                        
                    }
                    else
                    {
                        //varCloseFlag = 1;
                        udfnclose();
                    }
                    //MainForm.objCP_BrandList.udfnList();
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
                //if (grdSelectedRackList.Rows.Count <= 0)
                //{
                //    DialogResult dialogResult = MessageBox.Show("Please select atleast one rack", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //if (grdStaffDetails.Rows.Count <= 0)
                //{
                //    DialogResult dialogResult = MessageBox.Show("Please enter atleast one staff name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                if (blnErrorFlag == false && grdStaffDetails.Rows.Count <= 0 && grdSelectedRack.Rows.Count <= 0)
                {
                    if (grdSelectedRack.Rows.Count <= 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Please select atleast one rack", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (grdStaffDetails.Rows.Count <= 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Please enter atleast one staff name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
                udfnSave(sender, e);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnclear()
        {
            try
            {
                btnSave.Text = "Save";
               // cmbGroupType.SelectedValue = "-1";
                DataSet objDS = new DataSet();
                SPDataService objspservice = new SPDataService();
               // objDS = objspservice.udfnGetSlNo("CP_SubGroup", "Create", "", "");
                objspservice.CloseConnection();
                if (objDS != null)
                {
                    //cmbSINO.DataSource = objDS.Tables[0];
                    //cmbSINO.DisplayMember = "num";
                    //cmbSINO.ValueMember = "num";
                }
              //  txtTGroupName.Focus();
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
               // MainForm.objCP_SubGroupList.udfnList();
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
                if (Convert.ToString(txtStaffName.Text).Trim() == "")
                {
                    epRackGroup.SetError(txtStaffName, "Please enter staff name");
                    txtStaffName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStaffName.ShowAlways = true;
                    tpStaffName.Show("Please enter staff name", txtStaffName, 5000);
                }
                else
                {
                    grdStaffDetails.Rows.Add(grdStaffDetails.Rows.Count+1, txtStaffName.Text, varDesignation,varUserId);
                    txtStaffName.Text = "";
                    txtStaffName.Focus();
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
                grdStaffDetails.Rows.RemoveAt(this.grdStaffDetails.SelectedRows[0].Index);
                for (int i = 0; i < grdStaffDetails.RowCount; i++)
                {
                    grdStaffDetails.Rows[i].Cells["clmSno"].Value =i+1;
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
                MainForm.objCP_ProductDetails = new CP_ProductDetails();
                MainForm.objCP_ProductDetails.ShowDialog();
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
                MainForm.objCP_ProductDetails = new CP_ProductDetails();
                MainForm.objCP_ProductDetails.ShowDialog();
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
                btnAdd.BackColor = Color.LemonChiffon;
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
                btnView.BackColor = Color.Transparent;
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
                varStockLocationId = Convert.ToInt32(cmbStockLocation.SelectedValue);
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
                            int varFlag = 0,varcount = 1; ;
                            for (int j = 0; j < dtSelectedRack.Rows.Count; j++)
                            {
                                varAddRack = Convert.ToString(grdRack.Rows[i].Cells["ID"].Value);
                                if (varAddRack == Convert.ToString(dtSelectedRack.Rows[j]["ID"]))
                                { varFlag = 1; }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                dtSelectedRack.Rows.Add(varcount, grdRack.Rows[i].Cells["Rack"].Value, grdRack.Rows[i].Cells["Description"].Value, 
                                    grdRack.Rows[i].Cells["Total Products"].Value, grdRack.Rows[i].Cells["ID"].Value,false);
                            }
                        }
                        else
                        {
                            varRemoveRack = Convert.ToString(grdRack.Rows[i].Cells["ID"].Value);
                            for (int j = 0; j < dtSelectedRack.Rows.Count; j++)
                            {
                                if (varRemoveRack == Convert.ToString(dtSelectedRack.Rows[j]["ID"]))
                                {
                                    dtSelectedRack.Rows[j].Delete();
                                    dtSelectedRack.AcceptChanges();
                                }
                            }
                        }
                    }

                    grdSelectedRack.DataSource = dtSelectedRack;
                    grdSelectedRack.Columns["S.No."].Width = 50;
                    grdSelectedRack.Columns["Rack"].Width = 100;
                    grdSelectedRack.Columns["Description"].Width = 100;
                    grdSelectedRack.Columns["Total Products"].Width = 100;
                    grdSelectedRack.Columns["Remove"].Width = 50;
                    grdSelectedRack.Columns["Total Products"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdSelectedRack.Columns["ID"].Visible = false;
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
                for (int i = 0; i < grdRack.Rows.Count; i++)
                {
                    grdRack.Rows[i].Cells[0].Value = chkRack.Checked;

                }
                if (chkRack.Checked == false)
                {
                    foreach (DataGridViewRow row in grdRack.Rows)
                    {
                        row.Cells[0].Value = false;
                    }
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
                grdSelectedRack.Rows.RemoveAt(this.grdSelectedRack.SelectedRows[0].Index);
                for (int i = 0; i < grdSelectedRack.RowCount; i++)
                {
                    grdSelectedRack.Rows[i].Cells["S.No."].Value = i + 1;
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
                    txtStaffName.Text = lvStaffName.SelectedItems[0].Text;
                    lvStaffName.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                                    string[] row = { objDs.Tables[0].Rows[i]["U_Name"].ToString(), objDs.Tables[0].Rows[i]["U_CTID"].ToString(),objDs.Tables[0].Rows[i]["Designation"].ToString(), objDs.Tables[0].Rows[i]["UID"].ToString() };
                                    varDesignation = objDs.Tables[0].Rows[i]["Designation"].ToString();
                                    varUserId = objDs.Tables[0].Rows[i]["UID"].ToString();
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
    }
     
}
