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
    public partial class CP_ProductSubGroup : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpgrouptype = new ToolTip();
        private ToolTip tptgroupname = new ToolTip();
        private ToolTip tpegroupname = new ToolTip();
        private ToolTip tptlabelname = new ToolTip();
        private ToolTip tpelabelname = new ToolTip();
        private ToolTip tpsno = new ToolTip();
        public string vargroupcode;
        public String pbFormStatus;
        public CP_ProductSubGroup()
        {
            InitializeComponent();
        }
        private void CP_SubGroup_Load(object sender, EventArgs e)
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
        private void txtEGroupName_Enter(object sender, EventArgs e)
        {

        }

        private void txtEGroupName_Leave(object sender, EventArgs e)
        {

        }
        private void cmbSINO_KeyDown(object sender, KeyEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                errGroup.Clear();
                if (txtESubGroupNameEnglish.Text.Trim() == "")
                {
                    errGroup.SetError(txtESubGroupNameEnglish, "Please enter group english name");
                    txtESubGroupNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");

                    tpegroupname.ShowAlways = true;
                    tpegroupname.Show("Please enter group english name", txtESubGroupNameEnglish, 5000);
                    txtESubGroupNameEnglish.Text = "";

                }
                if (txtESubGroupNameEnglish.Text.Trim() == "")
                {
                    txtESubGroupNameEnglish.Focus();
                    return;

                }
                SPDataService objspdservice = new SPDataService();
                string result = "";
                if (btnSave.Text == "Save")
                {
                 //   result = objspdservice.udfnSPGroupMaster("Create", "0",cmbGroupType.SelectedValue.ToString(),txtTGroupName.Text,txtEGroupName.Text,txtTLabelName.Text,txtELabelName.Text,cmbSINO.SelectedValue.ToString(),  MainForm.pbUserID, MainForm.pbIpAddress, "Group Create");
                }
                else
                {
                  //  result = objspdservice.udfnSPGroupMaster("Update",vargroupcode, cmbGroupType.SelectedValue.ToString(), txtTGroupName.Text, txtEGroupName.Text, txtTLabelName.Text, txtELabelName.Text, cmbSINO.SelectedValue.ToString(), MainForm.pbUserID, MainForm.pbIpAddress, "Group Update");
                }
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (pbFormStatus == "Finished")
                    {
                        pbFormStatus = "";
                        //MainForm.objCP_Product.varGroupCode = varvalue[2];
                        //MainForm.objCP_Product.varGroupName = txtEGroupName.Text;
                        //MainForm.objCP_Product.udfnLoadGroup();
                        this.Close();
                    }
                    if (pbFormStatus == "Raw")
                    {
                        pbFormStatus = "";
                        //MainForm.objCP_RawMaterial.varGroupCode = varvalue[2];
                        //MainForm.objCP_RawMaterial.varGroupName = txtEGroupName.Text;
                        //MainForm.objCP_RawMaterial.udfnLoadGroup();
                        this.Close();
                    }
                    if (btnSave.Text == "Update")
                    {
                        this.Close();
                    }
                    else
                    {
                        udfnclear();
                    }
                  //  udfnLoadSlNo();
                   // MainForm.objCP_SubGroupList.udfnList();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (varvalue[1].Contains("Order number")) {
                        //udfnLoadSlNo(); 
                    }
                }

                objspdservice.CloseConnection();




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


        private void CP_SubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Group = new CP_Group();
                MainForm.objCP_Group.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CmbGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtESubGroupNameEnglish.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtESubGroupNameEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                txtESubGroupNameEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtESubGroupNameEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtESubGroupNameTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtESubGroupNameEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtESubGroupNameEnglish.Text == "")
                {
                    txtESubGroupNameEnglish.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errGroup.SetError(txtESubGroupNameEnglish, "Please Enter Sub Group Name in English");
                }
                else
                {
                    txtESubGroupNameEnglish.BackColor = Color.White;
                    errGroup.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtESubGroupNameTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtESubGroupNameTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtESubGroupNameTamil_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtESubGroupNameTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtESubGroupNameTamil.Text == "")
                {
                    txtESubGroupNameTamil.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errGroup.SetError(txtESubGroupNameTamil, "Please Enter Sub Group Name in Tamil");
                }
                else
                {
                    txtESubGroupNameTamil.BackColor = Color.White;
                    errGroup.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbInactive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactive_KeyDown(object sender, KeyEventArgs e)
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
    }
}
