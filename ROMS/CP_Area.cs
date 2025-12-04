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
    public partial class CP_Area : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpEAreaName = new ToolTip();
        private ToolTip tpTAreaName = new ToolTip();
        private ToolTip tpRouteName = new ToolTip();
        public int varUpdate = 0;
        public string varSupplierIds;
        public int varUpDownKeyLocation = 0, varAreaId=0;
        public CP_Area()
        {
            InitializeComponent();
        }
        private void CP_Area_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Area_Leave(object sender, EventArgs e)
        {
            try
            {
                tpEAreaName.Active = false;
                tpTAreaName.Active = false;
                tpRouteName.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Area_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Route", "RID NOT IN (0)   ORDER BY R_OrderNo", "R_EName,RID", cmbRoute, "", "R_EName", "RID");
                objDataBind.BindComboBoxListSelected("MR_City", "CTYID NOT IN (0,-1) AND ISNULL(CTY_DispatchEnable,0)=1 ORDER BY CTYID", "CTY_Name,CTYID", cmbCity, "", "CTY_Name", "CTYID");
                objDataBind = null;
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true;
                    udfnLoadSlNo(); 
                }
                else
                {
                    udfnLoadSlNo();
                     udfnEdit();
                    varUpdate = 1;
                    pnlStatus.Enabled = true;   
                }

                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                MainForm.objCP_AreaList.picLoader.Visible = false;
                MainForm.objCP_AreaList.picLoader.SendToBack();
              
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEdit()
        {
            try
            {
                int stsid = 0;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                MR_Area objMR_Area = new MR_Area();
                objMR_Area.ViewType = 1; 
                objMR_Area.paraAreaId = varAreaId; 
                objDs = objspservice.udfnArealist(objMR_Area);
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    { 
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbRoute.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["RouteID"]);
                            txtAEName.Text= Convert.ToString(objDs.Tables[0].Rows[0]["Area Name in English"]);
                            txtATName.Text= Convert.ToString(objDs.Tables[0].Rows[0]["Area Name in Tamil"]);
                            stsid = Convert.ToInt32(objDs.Tables[0].Rows[0]["A_STSID"]);
                            cmbOrderNo.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["A_OrderNo"]);
                            cmbCity.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["A_CTYID"]);
                            txtDistance.Text = Convert.ToString(objDs.Tables[0].Rows[0]["A_Distance"]);
                           if(stsid==1)
                           { rbActive.Checked=true; }
                           else
                           { rbInActive.Checked = true; }
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
        public void udfnLoadSlNo()
        {
            try
            {
                DataSet objDS;
                if (varAreaId != 0)
                {
                    string varAid = Convert.ToString(varAreaId);
                    SPDataService objspservice = new SPDataService();
                    objDS = objspservice.udfnGetSlNo("MR_Area", "Update", "AID", varAid, "A_OrderNo");
                    objspservice.CloseConnection();
                }
                else
                {
                    SPDataService objspservice = new SPDataService();
                    objDS = objspservice.udfnGetSlNo("MR_Area ", "Create", "1=1", "", "A_OrderNo");
                    objspservice.CloseConnection();
                }
                if (objDS != null)
                {
                    cmbOrderNo.DataSource = objDS.Tables[0];
                    cmbOrderNo.DisplayMember = "num";
                    cmbOrderNo.ValueMember = "num";
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
                string varResult = "",
                varoriginator = "";
                int varViewType = 0, varstatus=0;
                decimal varDistance = 0;
                if (rbActive.Checked == true) { varstatus = 1; }
                else { varstatus = 2; }
                if(varAreaId==0)
                { varViewType = 0; varoriginator = "Area Creation"; }
                else { varViewType = 1; varoriginator = "Area Updation"; }

                if(Convert.ToString(txtDistance.Text.Trim())!="")
                { varDistance=Convert.ToDecimal(txtDistance.Text.Trim()); }

                SPDataService objspdservice = new SPDataService();
                MR_Area objMR_Area = new MR_Area();
                objMR_Area.ViewType = varViewType; 
                objMR_Area.paraAreaId = varAreaId;
                objMR_Area.paraAreaTName = txtATName.Text.Trim();
                objMR_Area.paraAreaEName = txtAEName.Text.Trim();
                objMR_Area.paraRouteID = Convert.ToInt32(cmbRoute.SelectedValue);
                objMR_Area.paraStatusId = varstatus;
                objMR_Area.paraOriginator = varoriginator;
                objMR_Area.paraOrderNo = Convert.ToInt32(cmbOrderNo.SelectedValue);
                objMR_Area.paraCTYID = Convert.ToInt32(cmbCity.SelectedValue); 
                objMR_Area.paraDistance =varDistance;
                varResult = objspdservice.udfnArea(objMR_Area);
                objspdservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
              
                varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    
                    MainForm.objCP_AreaList.udfnList();

                    if (btnSave.Text == "Update")
                    { 
                        udfnclose();
                    }
                    else
                    {
                        udfnclear();
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
                 
            }
        }
        public void udfnclear()
        {
            DataBind objDataBind = new DataBind();
            objDataBind.BindComboBoxListSelected("MR_Route", "RID NOT IN (0)   ORDER BY R_OrderNo", "R_EName,RID", cmbRoute, "", "R_EName", "RID");
            objDataBind = null;
            varAreaId = 0;
            txtAEName.Text = "";
            txtATName.Text = "";
            txtDistance.Text = "";
            rbActive.Checked = true;
            udfnLoadSlNo();
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtAEName.Text).Trim() == "")
                {
                    errArea.SetError(txtAEName, "Please enter area english name.");
                    txtAEName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEAreaName.ShowAlways = true;
                    tpEAreaName.Show("Please enter area english name.", txtAEName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtATName.Text).Trim() == "")
                {
                    errArea.SetError(txtATName, "Please enter area tamil name.");
                    txtATName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTAreaName.ShowAlways = true;
                    tpTAreaName.Show("Please enter area tamil name.", txtATName, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    errArea.Clear();
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

        private void txtAEName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAEName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAEName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtATName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAEName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAEName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtATName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtATName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtATName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrderNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtATName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtATName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRName_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbOrderNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInActive.Focus();
                        }
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

        private void txtRName_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderNo.BackColor = Color.White;
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

        private void cmbRoute_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRoute.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRoute_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAEName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRoute_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbRoute_Leave(object sender, EventArgs e)
        {
            try
            { 
                cmbRoute.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbOrderNo_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbRoute.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDistance.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbOrderNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbOrderNo_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void cmbCity_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbCity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void rbActive_Enter(object sender, EventArgs e)
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

        private void rbActive_Leave(object sender, EventArgs e)
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

        private void rbInActive_Enter(object sender, EventArgs e)
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

        private void rbInActive_Leave(object sender, EventArgs e)
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

        private void cmbCity_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbCity.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDistance_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDistance.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDistance_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDistance.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtDistance_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDRouteName_TextChanged(object sender, EventArgs e)
        {

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

        private void cmbOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDAreaTName_TextChanged(object sender, EventArgs e)
        {

        }

        private void grbDetails_Enter(object sender, EventArgs e)
        {

        }

        private void txtDDistance_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDistance_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlStatus_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAEName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtATName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CP_Area_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtDistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
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
 