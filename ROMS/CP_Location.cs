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
    public partial class CP_Location : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;


        private ToolTip tplocationname = new ToolTip();
        private ToolTip tpsno = new ToolTip();


        public string varlocationcode;
       
        public CP_Location()
        {
            InitializeComponent();
        }

        private void txtLocationName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLocationName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLocationName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtLocationName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLocationName.BackColor = Color.White;
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

                errLocation.Clear();

                if (txtLocationName.Text.Trim() == "")
                {
                    errLocation.SetError(txtLocationName, "Please enter location name ");
                    txtLocationName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tplocationname.ShowAlways = true;
                    tplocationname.Show("Please enter location name", txtLocationName, 5000);
                    txtLocationName.Text = "";
                }
                if (txtLocationName.Text.Trim() == "")
                {
                    txtLocationName.Focus();
                    return;
                }
                SPDataService objspdservice = new SPDataService();

                string result = "";
                if (btnSave.Text == "Save")
                {
                  //  result = objspdservice.udfnSPLocationMaster("Create", "0",txtLocationName.Text,cmbSlNo.SelectedValue.ToString() , MainForm.pbUserID, MainForm.pbIpAddress, "Location Create");

                }
                else
                {
                  //  result = objspdservice.udfnSPLocationMaster("Update", varlocationcode, txtLocationName.Text, cmbSlNo.SelectedValue.ToString(), MainForm.pbUserID, MainForm.pbIpAddress, "Location Update");
                }
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (btnSave.Text == "Update")
                    {
                        this.Close();
                    }
                    else
                    {
                        udfnclear();
                    }

                    MainForm.objCP_LocationList.udfnList();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (varvalue[1].Contains("Order number")) {// udfnSINO();
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
                txtLocationName.Text = "";
                btnSave.Text = "Save";
                txtLocationName.Focus();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
              //  MainForm.objCP_LocationList.udfnList();
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
        private void CP_Location_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtLocationName;
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
                if (varlocationcode != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS = new DataSet();
                  //  objDS = objspservice.udfnSPLocationList("EditLoad", varlocationcode, MainForm.pbUserID, MainForm.pbIpAddress);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtLocationName.Text = objDS.Tables[0].Rows[0]["LocationName"].ToString().Replace("''", "'");
                         //   cmbSlNo.SelectedValue = objDS.Tables[0].Rows[0]["SINO"].ToString();                          
                            btnSave.Text = "Update";
                        }
                    }
                    if (varlocationcode == "1") { btnSave.Visible = false; } else { btnSave.Visible = true; }
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
        private void CP_Location_KeyDown(object sender, KeyEventArgs e)
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

        private void RbLocation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                grbLocation.BringToFront();
                grbrack.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rbrack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                grbrack.BringToFront();
                grbLocation.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
