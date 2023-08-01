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


        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpLocationType = new ToolTip();
        private ToolTip tpLocationTypeInEnglish = new ToolTip();
        private ToolTip tpLocationTypeInTamil = new ToolTip();
        private ToolTip tpStoctApplicable = new ToolTip();


        public string varlocationcode;
       
        public CP_Location()
        {
            InitializeComponent();
        }

        
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        errLocation.Clear();

        //        if (txtLocationName.Text.Trim() == "")
        //        {
        //            errLocation.SetError(txtLocationName, "Please enter location name ");
        //            txtLocationName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
        //            tplocationname.ShowAlways = true;
        //            tplocationname.Show("Please enter location name", txtLocationName, 5000);
        //            txtLocationName.Text = "";
        //        }
        //        if (txtLocationName.Text.Trim() == "")
        //        {
        //            txtLocationName.Focus();
        //            return;
        //        }
        //        SPDataService objspdservice = new SPDataService();

        //        string result = "";
        //        if (btnSave.Text == "Save")
        //        {
        //          //  result = objspdservice.udfnSPLocationMaster("Create", "0",txtLocationName.Text,cmbSlNo.SelectedValue.ToString() , MainForm.pbUserID, MainForm.pbIpAddress, "Location Create");

        //        }
        //        else
        //        {
        //          //  result = objspdservice.udfnSPLocationMaster("Update", varlocationcode, txtLocationName.Text, cmbSlNo.SelectedValue.ToString(), MainForm.pbUserID, MainForm.pbIpAddress, "Location Update");
        //        }
        //        string[] varvalue = result.Split('~');
        //        if (varvalue[0] == "3")
        //        {
        //            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            if (btnSave.Text == "Update")
        //            {
        //                this.Close();
        //            }
        //            else
        //            {
        //                udfnclear();
        //            }

        //            MainForm.objCP_LocationList.udfnList();
        //        }
        //        else
        //        {
        //            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            if (varvalue[1].Contains("Order number")) {// udfnSINO();
        //            }
        //        }
        //        objspdservice.CloseConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}


        private void udfnclear()
        {


            //try
            //{
            //    txtLocationName.Text = "";
            //    btnSave.Text = "Save";
            //    txtLocationName.Focus();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}

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
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    pnlStatus.Enabled = true;
                }
                this.ActiveControl = cmbConcern;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void udfnEdit()
        {
            //try
            //{
            //    if (varlocationcode != "")
            //    {
            //        SPDataService objspservice = new SPDataService();
            //        DataSet objDS = new DataSet();
            //      //  objDS = objspservice.udfnSPLocationList("EditLoad", varlocationcode, MainForm.pbUserID, MainForm.pbIpAddress);
            //        objspservice.CloseConnection();
            //        if (objDS != null)
            //        {
            //            if (objDS.Tables[0].Rows.Count > 0)
            //            {
            //                txtLocationName.Text = objDS.Tables[0].Rows[0]["LocationName"].ToString().Replace("''", "'");
            //             //   cmbSlNo.SelectedValue = objDS.Tables[0].Rows[0]["SINO"].ToString();                          
            //                btnSave.Text = "Update";
            //            }
            //        }
            //        if (varlocationcode == "1") { btnSave.Visible = false; } else { btnSave.Visible = true; }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            //finally
            //{

            //}
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

                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbConcern, "Please Select Concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please Select Concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbLocationType.SelectedItem) == "" || Convert.ToString(cmbLocationType.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbLocationType, "Please Select Location Type");
                    cmbLocationType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationType.ShowAlways = true;
                    tpLocationType.Show("Please Select Location Type", cmbLocationType, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(txtLocationNameInEnglish.Text).Trim() == "")
                {
                    epLocation.SetError(txtLocationNameInEnglish, "Please Enter Location Name in English");
                    txtLocationNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInEnglish.ShowAlways = true;
                    tpLocationTypeInEnglish.Show("Please Enter Location Name in English", txtLocationNameInEnglish, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtLocationNameInTamil.Text).Trim() == "")
                {
                    epLocation.SetError(txtLocationNameInTamil, "Please Enter Location Name in Tamil");
                    txtLocationNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInTamil.ShowAlways = true;
                    tpLocationTypeInTamil.Show("Please Enter Location Name in Tamil", txtLocationNameInTamil, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbStockApplicable.SelectedItem) == "" || Convert.ToString(cmbStockApplicable.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbStockApplicable, "Please Select Stock Applicable");
                    cmbStockApplicable.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStoctApplicable.ShowAlways = true;
                    tpStoctApplicable.Show("Please Select Stock Applicable", cmbStockApplicable, 5000);
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

        private void RbLocation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //grbLocation.BringToFront();
                //grbrack.SendToBack();
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
               // grbrack.BringToFront();
                //grbLocation.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rboutside_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //rbActive.Focus();
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
                    btnSave.Focus();
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


        private void CP_Location_Leave(object sender, EventArgs e)
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

        private void CP_Location_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbConcern, "Please Select Concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please Select Concern", cmbConcern, 5000);
                }
                else
                {
                    epLocation.Clear();
                    cmbConcern.BackColor = Color.White;
                }
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
                    cmbLocationType.Focus();
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

        private void CmbLocationType_Enter(object sender, EventArgs e)
        {

            try
            {
                cmbLocationType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbLocationType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLocationNameInEnglish.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbLocationType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbLocationType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbLocationType.SelectedItem) == "" || Convert.ToString(cmbLocationType.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbLocationType, "Please Select Location Type");
                    cmbLocationType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationType.ShowAlways = true;
                    tpLocationType.Show("Please Select Location Type", cmbLocationType, 5000);
                }
                else
                {
                    epLocation.Clear();
                    cmbLocationType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbLocationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbLocationType.Select(int.MaxValue, 0)));
                if (Convert.ToString(cmbLocationType.SelectedItem) == "Godown")
                {
                    pnlGodownType.Enabled = true;
                }
                else
                {
                    pnlGodownType.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocationNameInEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLocationNameInEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocationNameInEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLocationNameInTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocationNameInEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtLocationNameInEnglish.Text).Trim() == "")
                {
                    epLocation.SetError(txtLocationNameInEnglish, "Please Enter Location Name in English");
                    txtLocationNameInEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInEnglish.ShowAlways = true;
                    tpLocationTypeInEnglish.Show("Please Enter Location Name in English", txtLocationNameInEnglish, 5000);
                }
                else
                {
                    epLocation.Clear();
                    txtLocationNameInEnglish.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocationNameInTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLocationNameInTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    
        private void TxtLocationNameInTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    txtShortName.Focus();
                }
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocationNameInTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtLocationNameInTamil.Text).Trim() == "")
                {
                    epLocation.SetError(txtLocationNameInTamil, "Please Enter Location Name in Tamil");
                    txtLocationNameInTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInTamil.ShowAlways = true;
                    tpLocationTypeInTamil.Show("Please Enter Location Name in Tamil", txtLocationNameInTamil, 5000);
                }
                else
                {
                    epLocation.Clear();
                    txtLocationNameInTamil.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInside_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInside.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInside_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInside.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockApplicable_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStockApplicable.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockApplicable_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled)
                    {
                        rbActive.Focus();
                    }
                    else { btnSave.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockApplicable_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbStockApplicable_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbStockApplicable.SelectedItem) == "" || Convert.ToString(cmbStockApplicable.SelectedValue) == "-1")
                {
                    epLocation.SetError(cmbStockApplicable, "Please Select Stock Applicable");
                    cmbStockApplicable.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationType.ShowAlways = true;
                    tpLocationType.Show("Please Select Stock Applicable", cmbStockApplicable, 5000);
                }
                else
                {
                    epLocation.Clear();
                    cmbStockApplicable.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStockApplicable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbStockApplicable.Select(int.MaxValue, 0)));
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

        private void RbInside_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStockApplicable.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rboutside_Enter(object sender, EventArgs e)
        {
            try
            {
                rboutside.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rboutside_Leave(object sender, EventArgs e)
        {
            try
            {
                rboutside.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtShortName_Leave(object sender, EventArgs e)
        {
            
            try
            {
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epLocation.SetError(txtShortName, "Please enter short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLocationTypeInTamil.ShowAlways = true;
                    tpLocationTypeInTamil.Show("Please  enter short name", txtShortName, 5000);
                }
                else
                {
                    epLocation.Clear();
                    txtShortName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtShortName_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlGodownType.Enabled)
                    {
                        rbInside.Focus();
                    }
                    else
                    {
                        cmbStockApplicable.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtShortName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtShortName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
    }
}
