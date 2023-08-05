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
      
        public string vargroupcode;
        public String pbFormStatus;
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
        private void CP_SubGroup_Load(object sender, EventArgs e)
        {
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
                if (blnErrorFlag == false && grdStaffDetails.Rows.Count <= 0 && grdSelectedRackList.Rows.Count <= 0)
                {
                    if (grdSelectedRackList.Rows.Count <= 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Please select atleast one rack", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    if (grdStaffDetails.Rows.Count <= 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("Please enter atleast one staff name", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    udfnSave(sender, e);
                }
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
                btnSave.BackColor = Color.White;
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
                btnClose.BackColor = Color.White;
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
                    grdStaffDetails.Rows.Add(grdStaffDetails.Rows.Count+1, txtStaffName.Text);
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
                btnView.BackColor = Color.White;
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
                btnView.BackColor = Color.White;
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

        private void CP_RackGroup_Load(object sender, EventArgs e)
        {

            try
            {
                udfnEdit();
                DGV_Racklist.Rows.Add(false, 1, "RACK 01");
                DGV_Racklist.Rows.Add(false, 2, "RACK 02");

                grdSelectedRackList.Rows.Add(1, "RACK 01");
                grdSelectedRackList.Rows.Add(2, "RACK 02");

                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
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
