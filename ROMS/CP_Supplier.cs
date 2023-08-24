using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_Supplier : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;
        DataTable dtSubGroup = new DataTable();
        DataTable dtSubGroupMapping = new DataTable();
        
        public string varcompanycode;
        public string pbFormStatus;
        public string varstatecode = "", varupdate="0", vardays = "";
        public int varOrderid = 0;
        //tool tip
        private ToolTip tpContactNo = new ToolTip();
        private ToolTip tpAltContactNo = new ToolTip();
        private ToolTip tpemail = new ToolTip();
        private ToolTip tpgstin = new ToolTip();
        private ToolTip tpfssai = new ToolTip();
        private ToolTip tpplno = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpshortname = new ToolTip();
        private ToolTip tppincode = new ToolTip();
        private ToolTip tpcity = new ToolTip();
        private ToolTip tparea = new ToolTip();
        private ToolTip tpstate = new ToolTip();
        public int SupplierUpdate = 0, vardayMonthID=0,varWeekID = 0,vardayID = 0,varrecyclecode = 0, varMonthID=0;
        public string pbSupplierid = "0", varstatusid = "0", varsupplierID = "0";
        public CP_Supplier()
        {
            InitializeComponent();
        }
         
        private void txtcontactName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtcontactName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtcontactName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtcreditlimit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtcontactName_Leave(object sender, EventArgs e)
        {
                try
            {
                if (txtcontactName.Text  == "")
                {

                    errCompany.SetError(txtcontactName, "Please enter contact name");
                    txtcontactName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter contact name.", txtcontactName, 5000);

                }
                else
                {
                    errCompany.Clear();
                    txtcontactName.BackColor = Color.White;
                    tparea.Hide(txtcontactName);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            

        }
 

        private void txtCity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        { 
            try
            {

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvCity.Items.Count == 0 || txtCity.Text == "")
                    {
                        txtCity.Focus();
                        lvCity.Visible = false;
                    }
                    else
                    {
                        lvCity.Focus();
                    }
                    if (lvCity.Items.Count > 0)
                    {
                        lvCity.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtPincode.Focus();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            if (txtCity.Text  == "")
            {

                errCompany.SetError(txtCity, "Please enter city name");
                txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter city name.", txtCity, 5000);

            }
            else
            {
                errCompany.Clear();
                txtCity.BackColor = Color.White;
                tparea.Hide(txtCity);
            }
        }

        private void txtContactNumber_Enter(object sender, EventArgs e)
        {
            try
            {
                txtContactNumber.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtContactNumber_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAContactNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtContactNumber_Leave(object sender, EventArgs e)
        {
            try
            { 
                try
                {
                    if (txtContactNumber.Text != "")
                    {
                        if ( txtContactNumber.Text.Length < 10)
                        {
                            errCompany.SetError(txtContactNumber, "Please enter valid phone No.");
                            txtContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpContactNo.ShowAlways = true;
                            tpContactNo.Show("Please enter valid phone No.", txtContactNumber, 5000); 
                        } 
                        else
                        {
                            errCompany.Clear();
                            txtContactNumber.BackColor = Color.White;
                            tpContactNo.Hide(txtContactNumber);
                        }
                    }
                    else if (txtContactNumber.Text == "")
                    { 
                            errCompany.SetError(txtContactNumber, "Please enter phone No.");
                            txtContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpContactNo.ShowAlways = true;
                            tpContactNo.Show("Please enter phone No.", txtContactNumber, 5000); 
                    }
                    else
                    {
                        errCompany.Clear();
                        txtContactNumber.BackColor = Color.White;
                        tpContactNo.Hide(txtContactNumber);
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAContactNumber_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAContactNumber.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAContactNumber_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtwhatsapp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAContactNumber_Leave(object sender, EventArgs e)
        {
            try
            { 
                if (txtAContactNumber.Text != "")
                {
                    if ( txtAContactNumber.Text.Length < 10)
                    {
                        errCompany.SetError(txtAContactNumber, "Please enter valid mobile No.");
                        txtAContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpAltContactNo.ShowAlways = true;
                        tpAltContactNo.Show("Please enter valid mobile No.", txtAContactNumber, 5000); 
                    }

                    else
                    {
                        errCompany.Clear();
                        txtAContactNumber.BackColor = Color.White;
                        tpAltContactNo.Hide(txtAContactNumber);
                    }
                }
                else if (txtAContactNumber.Text == "")
                {
                    errCompany.SetError(txtAContactNumber, "Please enter mobile No.");
                    txtAContactNumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAltContactNo.ShowAlways = true;
                    tpAltContactNo.Show("Please enter mobile No.", txtAContactNumber, 5000);
                }

                else
                {
                    errCompany.Clear();
                    txtAContactNumber.BackColor = Color.White;
                    tpAltContactNo.Hide(txtAContactNumber);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEmail.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbDesignation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                txtEmail.BackColor = Color.White;
                if (txtEmail.Text == "" && objvalidation.FormatEMail(txtEmail.Text) == false)
                {
                    errCompany.SetError(txtEmail, "Please enter valid EmailID");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpemail.ShowAlways = true;
                    tpemail.Show("Please enter valid EmailID", txtEmail, 5000);
                     
                }
                else
                {
                    errCompany.Clear();
                    txtEmail.BackColor = Color.White;
                    tpemail.Hide(txtEmail);
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
                udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
           
        }
        public void udfnSave()
        {
            try
            {
                bool blnErrorFlag = false; 
                if (txtName.Text == "")
                { 
                    errCompany.SetError(txtName, "Please enter the name");
                    txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter the name.", txtName, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    SPDataService objspdservice = new SPDataService();
                    string result = "";
                    string varStatus = "1";
                    errCompany.Clear();
                    udfncolorchange();

                    int cityid = 0,creditlimit=0,openingvalue=0; string varpincode = "";
                    if (lblcityid.Text == "")
                    {
                        cityid = 0;
                    }
                    else
                    {
                        cityid = Convert.ToInt32(lblcityid.Text);
                    }
                    if (txtPincode.Text == "")
                    {
                        varpincode = "";
                    }
                    else
                    {
                        varpincode = txtPincode.Text;
                    }

                    if (txtopening.Text == "")
                    {
                        openingvalue = 0;
                    }
                    else
                    {
                        openingvalue = Convert.ToInt32(txtopening.Text);
                    }

                    if (txtcreditlimit.Text == "")
                    {
                        creditlimit = 0;
                    }
                    else
                    {
                        creditlimit = Convert.ToInt32(txtcreditlimit.Text) ;
                    }

                    if (rbActive.Checked == true)
                    {
                        varStatus = "1";
                    }
                    else
                    {
                        varStatus = "2"; 
                    }
                    SupplierUpdate = 0;
                    if (Convert.ToInt32(varsupplierID) != 0)
                    {
                        SupplierUpdate = Convert.ToInt32(varsupplierID);
                    }
                    else
                    {
                        SupplierUpdate = Convert.ToInt32(pbSupplierid);
                    }

                    if (btnSave.Text == "Save")
                    {
                        result = objspdservice.udfnSupplierMaster(0, SupplierUpdate, (txtName.Text).Trim(), txtArea.Text, txtaddress2.Text, cityid
                        , varpincode, txtContactNumber.Text,txtwhatsapp.Text, txtAContactNumber.Text, txtEmail.Text, txtgstin.Text,
                        Convert.ToInt32(cmbPaymentTerm.SelectedValue),22, 24, openingvalue, Convert.ToInt32(cmbSupplierType.SelectedValue), Convert.ToInt32(cmbState.SelectedValue), "1",
                        MainForm.pbUserID, MainForm.pbIpAddress, "Supplier Create", Convert.ToInt32(cmbDesignation.SelectedValue),txtcontactName.Text, creditlimit, -1,-1,-1,-1,"","","","",0,"",0);
                    }
                    else
                    {
                        result = objspdservice.udfnSupplierMaster(1, SupplierUpdate, txtName.Text, txtArea.Text, txtaddress2.Text, cityid
                      , varpincode, txtContactNumber.Text, txtwhatsapp.Text, txtAContactNumber.Text, txtEmail.Text, txtgstin.Text,
                      Convert.ToInt32(cmbPaymentTerm.SelectedValue), 22, 24, openingvalue, Convert.ToInt32(cmbSupplierType.SelectedValue), Convert.ToInt32(cmbState.SelectedValue), "1",
                      MainForm.pbUserID, MainForm.pbIpAddress, "Supplier Update", Convert.ToInt32(cmbDesignation.SelectedValue), txtcontactName.Text, creditlimit, -1, -1, -1, -1, "", "", "", "", 0, "",0);

                    }
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = tcSupplier;
                        tcSupplier.SelectedIndex = 1;
                        MainForm.objCP_Supplierlist.udfnList();

                        varsupplierID = varvalue[2];
                        txtName.Focus();
                        if (btnSave.Text == "Update")
                        {
                            varupdate = "1";
                            udfnclose();
                            udfnclear();
                        }

                        if (tcSupplier.SelectedIndex == 1)
                        {
                            btnSave.Text = "Update";
                            btnSaveOrderType.Text = "Update";
                            txtSupplier.Text = txtName.Text;
                            txtsuppliername.Text = txtName.Text;
                        }
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfncolorchange()
        {
            try
            {
                txtName.BackColor = Color.White;
                txtArea.BackColor = Color.White;
                txtaddress2.BackColor = Color.White;
                cmbState.BackColor = Color.White;
                txtCity.BackColor = Color.White;
                txtPincode.BackColor = Color.White;
                txtAContactNumber.BackColor = Color.White;
                txtContactNumber.BackColor = Color.White;
                txtwhatsapp.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                cmbDesignation.BackColor = Color.White;
                cmbSupplierType.BackColor = Color.White;
                cmbPaymentTerm.BackColor = Color.White;  
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        
        private void CP_Supplier_Load(object sender, EventArgs e)
        {
            try
            {

                this.ActiveControl = txtName;
                udfnLoadState(); 
                udfnEdit();
                BindDataGrid();

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>0 ORDER BY STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (10,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbDesignation, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (8,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnPolicy, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (9,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (11,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbSupplierType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (12,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPaymentTerm, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (29,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbfinance, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (13,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrderType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (13,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmborder, "", "MST_DisplayText", "MSTID");
                //objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (13,0) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbMappingordertype, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbMappingordeDay, "", "DY_Name", "DYID");
                objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmborderday, "", "DY_Name", "DYID");
                objDataBind = null; 
                cmbReturnPolicy.SelectedIndex = 0; 
                cmbReturnType.SelectedIndex = 0;
                txtReturnText.Visible = false;
                cmbPolicyContent.Visible = false;
                txtNextLevel.Visible = false;
                cmbSecondLevel.Visible = false;

                BeginInvoke(new Action(() => cmbOrderschedule.Select(int.MaxValue, 0)));
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
     
  
        private void BindDataGrid()
        {
            try
            {  
                DataSet objDs = new DataSet();
                DataService objdserv = new DataService();
                objDs = objdserv.GetDataset("SELECT DYID,DY_Name from DEF_Days WHERE DYID NOT IN (0,-1)");
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    { 
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grddays.DataSource = objDs.Tables[0];
                            grddays.Columns["DYID"].Visible = false;
                            grddays.Columns["DY_Name"].Width = 100;
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

        private void udfnEdit()
        {
            try
            {

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
         

        private void txtAContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.CheckNumeric(e);
                if (varResult == true)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        

        
             private void CP_Supplier_Leave(object sender, EventArgs e)
        {
            try
            {
                tpContactNo.Active = false;
                tpAltContactNo.Active = false;
                tpemail.Active = false;
                tpgstin.Active = false;
                tpfssai.Active = false;
                tpplno.Active = false;
                tpcompanyname.Active = false;
                tpshortname.Active = false;




            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        
        

        private void CP_Supplier_KeyDown(object sender, KeyEventArgs e)
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
         

        private void txtArea_Leave(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.White;
                try
                {
                    if (txtArea.Text == "")
                    {
                       
                            errCompany.SetError(txtArea, "Please enter area");
                            txtArea.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tparea.ShowAlways = true;
                            tparea.Show("Please enter area.", txtArea, 5000); 
                       
                    }
                    else
                    {
                        errCompany.Clear();
                        txtArea.BackColor = Color.White;
                        tparea.Hide(txtArea);
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
           
        }

        private void txtArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtaddress2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void txtPincode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPincode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPincode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPincode.BackColor = Color.White;
                try
                {
                    if (txtPincode.Text != "")
                    {
                        if (txtPincode.Text.Length < 6)
                        {
                            errCompany.SetError(txtPincode, "Please enter valid pincode");
                            txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tppincode.ShowAlways = true;
                            tppincode.Show("Please enter valid pincode.", txtPincode, 5000); 
                        }

                        else
                        {
                            errCompany.Clear();
                            txtPincode.BackColor = Color.White;
                            tppincode.Hide(txtPincode);
                        }
                    }
                    else if(txtPincode.Text  == "")
                    {
                        errCompany.SetError(txtPincode, "Please enter pincode");
                        txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppincode.ShowAlways = true;
                        tppincode.Show("Please enter pincode.", txtPincode, 5000); 
                    }
                    else
                    {
                        errCompany.Clear();
                        txtPincode.BackColor = Color.White;
                        tppincode.Hide(txtPincode);
                    }
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
           
        }

        private void txtPincode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtContactNumber.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtArea_Enter(object sender, EventArgs e)
        {
            try
            {
                txtArea.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        public void udfnLoadState()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_STATE", "Status=1 and 1=1 Order by State", "State,StateCode", cmbState, "", "State", "StateCode");
                objDataBind = null;
                if (varstatecode != "") { cmbState.SelectedValue = varstatecode; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 

        private void cmbState_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void TxtAlterMobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.CheckNumeric(e);
                if (varResult == true)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
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

        private void Txtwhatsapp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.CheckNumeric(e);
                if (varResult == true)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
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

        private void Txtaddress2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtaddress2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtaddress2_Leave(object sender, EventArgs e)
        {
            if (txtaddress2.Text  == "")
            {

                errCompany.SetError(txtaddress2, "Please enter address");
                txtaddress2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter address.", txtaddress2, 5000);

            }
            else
            {
                errCompany.Clear();
                txtaddress2.BackColor = Color.White;
                tparea.Hide(txtaddress2);
            }
        }

        private void Txtaddress2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbState.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        private void Txtwhatsapp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEmail.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtwhatsapp_Enter(object sender, EventArgs e)
        {
            try
            {
                 
                  txtwhatsapp.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtwhatsapp_Leave(object sender, EventArgs e)
        {
            if (txtwhatsapp.Text == "")
            {

                errCompany.SetError(txtwhatsapp, "Please enter whatsapp No.");
                txtwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter whatsapp No.", txtwhatsapp, 5000);

            }
            else if (txtwhatsapp.Text != "")
            {
                if (txtwhatsapp.Text.Length < 10 )
                {

                    errCompany.SetError(txtwhatsapp, "Please enter valid whatsapp No.");
                    txtwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter valid whatsapp No.", txtwhatsapp, 5000); 
                }
                else
                {
                    errCompany.Clear();
                    txtwhatsapp.BackColor = Color.White;
                    tparea.Hide(txtwhatsapp);
                }
            }
            else
            {
                errCompany.Clear();
                txtwhatsapp.BackColor = Color.White;
                tparea.Hide(txtwhatsapp);
            }
        }

        private void Txtcreditlimit_Enter(object sender, EventArgs e)
        {
            try
            {

                txtcreditlimit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtcreditlimit_Leave(object sender, EventArgs e)
        {
            if (txtcreditlimit.Text == "")
            {

                errCompany.SetError(txtcreditlimit, "Please enter credit limit");
                txtcreditlimit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter credit limit.", txtcreditlimit, 5000);

            }
            else
            {
                errCompany.Clear();
                txtwhatsapp.BackColor = Color.White;
                tparea.Hide(txtcreditlimit);
            }
        }

        private void Txtcreditlimit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtopening.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtopening_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtopening.Text  == "")
                {

                    errCompany.SetError(txtopening, "Please enter opening ");
                    txtopening.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter opening.", txtopening, 5000);

                }
                else
                {
                    errCompany.Clear();
                    txtopening.BackColor = Color.White;
                    tparea.Hide(txtopening);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtopening_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbfinance.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtopening_Enter(object sender, EventArgs e)
        {
            try
            {
                txtopening.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbfinance_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPaymentTerm.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
         

        private void Txtsalesmanname_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtsalesmanname.Text == "")
                {

                    errCompany.SetError(txtsalesmanname, "Please enter salesman name");
                    txtsalesmanname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter salesman name", txtsalesmanname, 5000);

                }
                else
                {
                    errCompany.Clear();
                    txtsalesmanname.BackColor = Color.White;
                    tparea.Hide(txtsalesmanname);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Txtsalesmanname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtsalesmanmobile.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsalesmanname_Enter(object sender, EventArgs e)
        {

            try
            { 
                txtsalesmanname.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        
        private void Txtsalesmanaddress_Enter(object sender, EventArgs e)
        {
            
        }

        private void Txtsalesmanmobile_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtsalesmanwhatsapp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsalesmanmobile_Leave(object sender, EventArgs e)
        {

            if (txtsalesmanmobile.Text == "")
            {

                errCompany.SetError(txtsalesmanmobile, "Please enter salesman mobile No.");
                txtsalesmanmobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter salesman mobile No.", txtsalesmanmobile, 5000);

            }
            else
            {
                errCompany.Clear();
                txtsalesmanmobile.BackColor = Color.White;
                tparea.Hide(txtsalesmanmobile);
            }
        }

        private void Txtsalesmanmobile_Enter(object sender, EventArgs e)
        {
            try
            {             }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsalesmanwhatsapp_Leave(object sender, EventArgs e)
        {
            if (txtsalesmanwhatsapp.Text == "")
            {

                errCompany.SetError(txtsalesmanwhatsapp, "Please enter salesman whatsapp No.");
                txtsalesmanwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter salesman whatsapp No.", txtsalesmanwhatsapp, 5000);

            }
            else
            {
                errCompany.Clear();
                txtsalesmanwhatsapp.BackColor = Color.White;
                tparea.Hide(txtsalesmanwhatsapp);
            }
        }

        private void Txtsalesmanwhatsapp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrderType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void Cmbsuppliertype_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtgstin.Enabled == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtgstin.Focus();
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Enter)
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
         
        private void Txtgstin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbReturnPolicy.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtgstin_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtgstin.Text  == "")
                {

                    errCompany.SetError(txtgstin, "Please enter GSTIN");
                    txtgstin.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter supply GSTIN.", txtgstin, 5000);

                }
                else
                {
                    errCompany.Clear();
                    txtgstin.BackColor = Color.White;
                    tparea.Hide(txtgstin);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        } 

        private void Grddays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grddays.Columns[e.ColumnIndex].Name == "chkdays" && e.RowIndex >= 0)
                {
                    DataGridViewCheckBoxCell checkBoxCell = grddays.Rows[e.RowIndex].Cells["chkdays"] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {
                        checkBoxCell.Value = !(bool)(checkBoxCell.Value ?? false);
                        grddays.EndEdit(); // Commit the change
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbDesignation.Select(int.MaxValue, 0)));
                if (Convert.ToString(cmbDesignation.SelectedValue) == "28")
                {
                    txtDShortName.Text = "Proprietor Name";
                }
                if (Convert.ToString(cmbDesignation.SelectedValue) == "29")
                {
                    txtDShortName.Text = "Manager Name";
                }
                if (Convert.ToString(cmbDesignation.SelectedValue) == "-1")
                {
                    txtDShortName.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrpSupplierDetails_Enter(object sender, EventArgs e)
        {

        }

        private void CmbReturnPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbReturnPolicy.Select(int.MaxValue, 0)));
                if (cmbReturnPolicy.Text == "Yes") { cmbReturnType.Visible = true; txtDReturnCycle.Visible = true; }
                else { cmbReturnType.Visible = false; txtDReturnCycle.Visible = false; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BeginInvoke(new Action(() => cmbReturnType.Select(int.MaxValue, 0)));
                if (Convert.ToString(cmbReturnType.SelectedValue) == "24")
                {
                    vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                    cmbPolicyContent.DataSource = null; 
                    txtReturnText.Visible = false;
                    cmbPolicyContent.Visible = false;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                    varrecyclecode = Convert.ToInt32(cmbReturnType.SelectedValue);
                }
                else if ((Convert.ToString(cmbReturnType.SelectedValue) == "25")) {
                    txtReturnText.Text = "Day"; 
                    vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                    cmbPolicyContent.Enabled = true;
                    cmbPolicyContent.DataSource = null; 
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbPolicyContent, "", "DY_Name", "DYID");
                    objDataBind = null; 
                    cmbPolicyContent.SelectedIndex = 0;
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                    vardayID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                }
                else if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                {
                    vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                    txtReturnText.Text = "Week No.";
                    txtReturnText.Visible = true;
                    cmbPolicyContent.DataSource = null;
                    cmbSecondLevel.DataSource = null;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (28,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPolicyContent, "", "MST_DisplayText", "MSTID");
                    objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbSecondLevel, "", "DY_Name", "DYID");
                    varWeekID = Convert.ToInt32(cmbPolicyContent.SelectedValue); 
                    vardayID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                    cmbPolicyContent.SelectedIndex = 0; 
                    cmbSecondLevel.SelectedIndex = 0;
                    txtNextLevel.Text = "Day";
                     
                    objDataBind = null;
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                }
                else if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                {
                    txtReturnText.Text = "Month";
                    vardays = "";
                    vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true; 
                    cmbPolicyContent.DataSource=null;
                    cmbSecondLevel.DataSource = null;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Months", "MONID NOT IN (0,-1)", "MON_Name,MONID", cmbPolicyContent, "", "MON_Name", "MONID"); 
                    cmbPolicyContent.SelectedIndex = 0; 
                    DataService objds = new DataService();
                    vardays = objds.displaydata("SELECT MON_DAY FROM DEF_Months WHERE MONID ='" + Convert.ToString(cmbPolicyContent.SelectedValue) + "'");
                    objds.CloseConnection();
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                    txtNextLevel.Text = "Day of the month"; 
                    objDataBind.BindComboBoxListSelected("DEF_Month_Days", "MONDID <='" + vardays+"'", "MOND_Name,MONDID", cmbSecondLevel, "", "MOND_Name", "MONDID");
                    objDataBind = null;
                    cmbSecondLevel.SelectedIndex = 0;
                    varMonthID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        

        private void TxtName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {

                    errCompany.SetError(txtName, "Please enter the name");
                    txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter the name.", txtName, 5000);

                }
                else
                {
                    errCompany.Clear();
                    txtName.BackColor = Color.White;
                    tparea.Hide(txtName);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtArea.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_Leave(object sender, EventArgs e)
        {
          try
            {
                if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbState, "Please Select State Name");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please Select State Name", cmbState, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbState.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbState_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbState.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BeginInvoke(new Action(() => cmbState.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbDesignation_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDesignation.BackColor = Color.White;
                if (Convert.ToString(cmbDesignation.SelectedValue) == "" || Convert.ToString(cmbDesignation.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbDesignation, "Please Select Designation");
                    cmbDesignation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please Select Designation", cmbDesignation, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbDesignation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtcontactName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDesignation_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbDesignation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDesignation_KeyPress(object sender, KeyPressEventArgs e)
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

       

        private void Cmbfinance_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbfinance.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbfinance_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbfinance.BackColor = Color.White;
                //if (Convert.ToString(cmbfinance.SelectedValue) == "" || Convert.ToString(cmbfinance.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbfinance, "Please Select Finance");
                //    cmbfinance.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please Select Finance", cmbfinance, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbfinance.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbfinance_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmbfinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbfinance.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbPaymentTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPaymentTerm.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentTerm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSupplierType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentTerm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPaymentTerm_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPaymentTerm.BackColor = Color.White;
                if (Convert.ToString(cmbPaymentTerm.SelectedValue) == "" || Convert.ToString(cmbPaymentTerm.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbPaymentTerm, "Please Select Payment Term");
                    cmbPaymentTerm.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please Select Payment Term", cmbPaymentTerm, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbPaymentTerm.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentTerm_Enter(object sender, EventArgs e)
        {

            try {

                cmbPaymentTerm.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSupplierType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbSupplierType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSupplierType.BackColor = Color.White;
                if (Convert.ToString(cmbSupplierType.SelectedValue) == "" || Convert.ToString(cmbSupplierType.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbSupplierType, "Please Select Supplier Type");
                    cmbSupplierType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please Select Payment Supplier Type", cmbSupplierType, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbSupplierType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSupplierType_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbSupplierType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSupplierType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSupplierType.Select(int.MaxValue, 0)));
                if (Convert.ToString(cmbSupplierType.SelectedValue) == "32" || Convert.ToString(cmbSupplierType.SelectedValue) == "-1")
                {
                    txtgstin.Text = "";
                    txtgstin.Enabled = false;
                }
                else
                {  
                    txtgstin.Enabled = true;
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtgstin_Enter(object sender, EventArgs e)
        {
            try
            {

                txtgstin.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbReturnType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReturnPolicy_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReturnPolicy.BackColor = Color.White;
                //if (Convert.ToString(cmbReturnPolicy.SelectedValue) == "" || Convert.ToString(cmbReturnPolicy.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbReturnPolicy, "Please select return policy");
                //    cmbReturnPolicy.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select return policy", cmbReturnPolicy, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbReturnPolicy.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbReturnPolicy.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbPolicyContent.Visible==true)
                    {
                        cmbPolicyContent.Focus();
                    }
                    else {
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

        private void CmbReturnType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReturnType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReturnType.BackColor = Color.White;
                //if (Convert.ToString(cmbReturnType.SelectedValue) == "" || Convert.ToString(cmbReturnType.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbReturnType, "Please select return type");
                //    cmbReturnType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select return type", cmbReturnType, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbReturnType.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_Enter(object sender, EventArgs e)
        {
            try
            { 
                cmbReturnType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPolicyContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPolicyContent.Select(int.MaxValue, 0)));
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                    {
                    vardays = "";
                    vardayMonthID = 0;
                    cmbSecondLevel.DataSource = null;
                    DataBind objDataBind = new DataBind();
                    DataService objds = new DataService();
                    vardays = objds.displaydata("SELECT MON_DAY FROM DEF_Months WHERE MONID ='" + Convert.ToString(cmbPolicyContent.SelectedValue) + "'");
                    objds.CloseConnection();
                    objDataBind.BindComboBoxListSelected("DEF_Month_Days", "MONDID <='" + vardays + "'", "MOND_Name,MONDID", cmbSecondLevel, "", "MOND_Name", "MONDID");
                    objDataBind = null;
                    cmbSecondLevel.SelectedIndex = 0;
                    vardayMonthID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                }

                if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                {
                    vardays = ""; 
                    varWeekID = 0;
                    vardayID = 0;
                    cmbSecondLevel.DataSource = null; 
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbSecondLevel, "", "DY_Name", "DYID");
                    objDataBind = null;
                    varWeekID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                    vardayID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                } 

            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPolicyContent_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPolicyContent.BackColor = Color.White;
                //if (Convert.ToString(cmbPolicyContent.SelectedValue) == "" || Convert.ToString(cmbPolicyContent.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbPolicyContent, "Please select policy content");
                //    cmbPolicyContent.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select policy content", cmbPolicyContent, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbPolicyContent.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbPolicyContent_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbSecondLevel.Visible == true)
                    {
                        cmbSecondLevel.Focus();
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

        private void CmbPolicyContent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPolicyContent_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPolicyContent.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSecondLevel.Select(int.MaxValue, 0)));
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                    {
                    vardayMonthID = 0; 
                    DataBind objDataBind = new DataBind();
                    DataService objds = new DataService();
                    vardayMonthID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                    varMonthID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                }

                if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                {
                    vardays = ""; 
                    varWeekID = 0;
                    vardayID = 0;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true; 
                    varWeekID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                    vardayID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                } 


            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSecondLevel.BackColor = Color.White;
                //if (Convert.ToString(cmbSecondLevel.SelectedValue) == "" || Convert.ToString(cmbSecondLevel.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbSecondLevel, "Please select");
                //    cmbSecondLevel.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select", cmbSecondLevel, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbSecondLevel.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbSecondLevel_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSecondLevel.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (panelStatus.Enabled == false)
                    {

                        btnSave.Focus();
                    }
                    else
                    {

                        rbActive.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtScheduleName_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtScheduleName.Text == "")
                {

                    errCompany.SetError(txtScheduleName, "Please enter the schedule");
                    txtScheduleName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter the schedule", txtScheduleName, 5000);

                }
                else
                {
                    errCompany.Clear();
                    txtScheduleName.BackColor = Color.White;
                    tparea.Hide(txtScheduleName);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtScheduleName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                     
                        txtsalesmanname.Focus();
                    
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtScheduleName_Enter(object sender, EventArgs e)
        {
            try
            {

                txtScheduleName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BeginInvoke(new Action(() => cmbOrderType.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    cmbReturnPolicy.Focus();

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbOrderType_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbOrderType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrderType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderType.BackColor = Color.White;
                if (Convert.ToString(cmbOrderType.SelectedValue) == "" || Convert.ToString(cmbOrderType.SelectedValue) == "-1")
                {
                    errCompany.SetError(cmbOrderType, "Please select order type");
                    cmbOrderType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpstate.ShowAlways = true;
                    tpstate.Show("Please select order type", cmbOrderType, 5000);
                }
                else
                {
                    errCompany.Clear();
                    cmbOrderType.BackColor = Color.White;
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

        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {

                btnAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn_close_Leave(object sender, EventArgs e)
        {
            try
            {

                btn_close.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn_close_Enter(object sender, EventArgs e)
        {
            try
            {

                btn_close.BackColor = Color.LemonChiffon;
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

        private void TxtSearchByProduct2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    btn_Close2.Focus();

                }
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

        private void Btn_Close2_Enter(object sender, EventArgs e)
        {
            try
            {

                btn_Close2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Btn_Close2_Leave(object sender, EventArgs e)
        { 
            try
            {

                btn_Close2.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TbOrder_Enter(object sender, EventArgs e)
        {
            try
            { 
                 
                txtScheduleName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TcSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tcSupplier.SelectedIndex == 1)
                {
                    txtScheduleName.Focus();

                    txtScheduleName.SelectionStart = txtScheduleName.Text.Length;
                }
                if (tcSupplier.SelectedIndex == 0)
                {
                    txtName.Focus();
                    txtName.SelectionStart = txtName.Text.Length;
                }
                if (tcSupplier.SelectedIndex == 3)
                {
                    cmbOrderschedule.Focus();
                    BeginInvoke(new Action(() => cmborder.Select(int.MaxValue, 0)));
                    BeginInvoke(new Action(() => cmborderday.Select(int.MaxValue, 0)));
                    cmborderday.SelectedIndex = 0;
                    cmborder.SelectedIndex = 0;
                    cmborder.SelectionStart = cmborder.Text.Length;
                    cmbOrderschedule.SelectedIndex = 0;

                }
                if (tcSupplier.SelectedIndex == 2)
                {
                    txtSupplier.Focus(); 

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TcSupplier_Selected(object sender, TabControlEventArgs e)
        {

            if (e.TabPageIndex == 1)  
            {
                try
                {

                    this.ActiveControl = txtScheduleName;
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                } 
            }

            if (e.TabPageIndex == 2)
            {
                try
                { 
                    this.ActiveControl = cmbOrderschedule; 
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("MR_Supplier_Schedule", "SPSC_SPID='"+ SupplierUpdate + "' ", "SPSC_Name,SPSCID", cmbMappingorderschedule, "", "SPSC_Name", "SPSCID");
                    objDataBind.BindComboBoxListSelected("MR_ProductGroup", "PRGID not in (-1)", "PRG_EName,PRGID", cmbMappingGroup, "", "PRG_EName", "PRGID"); 
                    objDataBind.BindComboBoxListSelected("MR_ProductSubGroup", " PRSGID not in (-1)  ORDER BY PRSGID,PRSG_EName", "PRSG_EName,PRSGID", cmbMappingSubGroup, "", "PRSG_EName", "PRSGID");
                    objDataBind = null;
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        }

        private void Cmborder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BeginInvoke(new Action(() => cmborder.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmborder_Leave(object sender, EventArgs e)
        {
            try
            {

                cmborder.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Cmborder_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmborder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    cmborderday.Focus();

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmborder_Enter(object sender, EventArgs e)
        {
            try
            {

                cmborder.BackColor=Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmborderday_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BeginInvoke(new Action(() => cmborderday.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmborderday_Leave(object sender, EventArgs e)
        {

            cmborderday.BackColor = Color.White;
            
        }

        private void Cmborderday_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Cmborderday_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    txtSearchByProduct2.Focus();

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Cmborderday_Enter(object sender, EventArgs e)
        {
            try
            {

                cmborderday.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderschedule_Leave(object sender, EventArgs e)
        {
            try
            {

                cmbOrderschedule.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbOrderschedule_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    cmbOrderType.Focus();

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderschedule_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbOrderschedule.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderschedule_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbOrderschedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                BeginInvoke(new Action(() => cmbOrderschedule.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {

                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtCity.Text.Length > 2)
                {
                    objDs = objspdservice.udfncitylist(1, txtCity.Text, MainForm.pbUserID, MainForm.pbIpAddress, Convert.ToString(cmbState.SelectedValue));
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString(), objDs.Tables[0].Rows[i]["CTYID"].ToString() };
                                   ListViewItem objList = new ListViewItem(row);
                                    lvCity.Items.Add(objList);
                                }
                                lvCity.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvCity.Visible = false;
                    lvCity.Items.Clear();
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

        private void LvCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGrdevent();
                    txtPincode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void Txtsuppliername_Enter(object sender, EventArgs e)
        {
            try
            {

                txtsuppliername.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsuppliername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbMappingorderschedule.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsuppliername_Leave(object sender, EventArgs e)
        {
            try
            {

                txtsuppliername.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingorderschedule_Leave(object sender, EventArgs e)
        {
            try
            {

                cmbMappingorderschedule.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingorderschedule_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbMappingorderschedule_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbMappingordeDay.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingorderschedule_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbMappingorderschedule.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingorderschedule_SelectedIndexChanged(object sender, EventArgs e)
        { 
            try
            {
                BeginInvoke(new Action(() => cmbMappingorderschedule.Select(int.MaxValue, 0)));
                udfnMappingGridsLoad();
                udfnMappingDropDownLoad();
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
        public void udfnMappingGridsLoad()
        {
            try
            {
                grdSupplierMappingLoad.DataSource = null;
                SPDataService objspservice = new SPDataService();
                DataSet objDs = new DataSet();
                dtSubGroup = new DataTable();
                dtSubGroup.Columns.Add("", typeof(Boolean));
                dtSubGroup.Columns.Add("S.No.", typeof(string));
                dtSubGroup.Columns.Add("P.I Code", typeof(string));
                dtSubGroup.Columns.Add("Product Name in Tamil", typeof(string));
                dtSubGroup.Columns.Add("Unit", typeof(string));
                dtSubGroup.Columns.Add("Product SubGroup", typeof(string));
                dtSubGroup.Columns.Add("GROUPID", typeof(int));
                dtSubGroup.Columns.Add("SUBGROUPID", typeof(int));
                dtSubGroup.Columns.Add("PRODUCTID", typeof(int)); 

                objDs = objspservice.udfnproductmasterlist(3, 0, 0,Convert.ToInt32(cmbMappingGroup.SelectedValue), Convert.ToInt32(cmbMappingSubGroup.SelectedValue),"", MainForm.pbUserID, MainForm.pbIpAddress, 0);
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtSubGroup.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in Tamil"]
                            , objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["Product SubGroup"], objDs.Tables[0].Rows[i]["GROUPID"], objDs.Tables[0].Rows[i]["SUBGROUPID"],
                            objDs.Tables[0].Rows[i]["PRODUCTID"]);
                    }
                    grdSupplierMappingLoad.DataSource = dtSubGroup;
                    grdSupplierMappingLoad.Columns[0].HeaderText = "";
                    grdSupplierMappingLoad.Columns[0].Width = 30;
                    grdSupplierMappingLoad.Columns["S.No."].Width = 50;
                    grdSupplierMappingLoad.Columns["P.I Code"].Width = 100;
                    grdSupplierMappingLoad.Columns["Product Name in Tamil"].Width = 220;
                    grdSupplierMappingLoad.Columns["Unit"].Width = 100;
                    grdSupplierMappingLoad.Columns["Product SubGroup"].Width = 120;
                    grdSupplierMappingLoad.Columns["GROUPID"].Visible = false;
                    grdSupplierMappingLoad.Columns["SUBGROUPID"].Visible = false;
                    grdSupplierMappingLoad.Columns["PRODUCTID"].Visible = false;
                }
                
                
                objspservice.CloseConnection();
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


        public void udfnMappingDropDownLoad()
        {
            try
            { 
            SPDataService objspservice = new SPDataService();
            DataSet objDs = new DataSet();
            cmbMappingordeDay.DataSource = null;
           
            objDs = objspservice.udfnSupplierList(0, SupplierUpdate, Convert.ToInt32(cmbMappingorderschedule.SelectedValue));
            if (objDs != null)
            {
                if (objDs.Tables.Count != 0)
                {
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        txtordertype.Text = objDs.Tables[0].Rows[0]["MST_DisplayText"].ToString().Replace("''", "'");
                    }
                    if (objDs.Tables[1].Rows.Count != 0)
                    {

                        cmbMappingordeDay.ValueMember = objDs.Tables[1].Columns["ID"].Caption;
                        cmbMappingordeDay.DisplayMember = objDs.Tables[1].Columns["DAYNAME"].Caption;
                        cmbMappingordeDay.DataSource = objDs.Tables[1];
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
            finally
            {
            }
        }

        private void CmbMappingordeDay_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbMappingordeDay.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingordeDay_Leave(object sender, EventArgs e)
        {
            try
            {

                cmbMappingordeDay.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbMappingordeDay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbMappingGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingordeDay_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbMappingordeDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbMappingordeDay.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbMappingSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingGroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbMappingGroup_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbMappingGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbMappingGroup.Select(int.MaxValue, 0)));
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_ProductSubGroup", " PRSGID not in (-1) AND PRSG_PRGID='" + cmbMappingGroup.SelectedValue + "'  OR PRSGID=0 ORDER BY PRSGID,PRSG_EName", "PRSG_EName,PRSGID", cmbMappingSubGroup, "", "PRSG_EName", "PRSGID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingGroup_Leave(object sender, EventArgs e)
        {

            try
            {

                cmbMappingGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbMappingSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnMappingView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingSubGroup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbMappingSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {

                cmbMappingSubGroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingSubGroup_Enter(object sender, EventArgs e)
        {

            try
            {

                cmbMappingSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbMappingSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbMappingSubGroup.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingView_Enter(object sender, EventArgs e)
        {
            try
            {

                btnMappingView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingView_Leave(object sender, EventArgs e)
        {
            try
            { 
                btnMappingView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSearchByProduct1_Leave(object sender, EventArgs e)
        {

        }

        private void TxtSearchByProduct1_KeyDown(object sender, KeyEventArgs e)
        { 
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtmappingproductsearch2.Focus();
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

        private void Txtmappingproductsearch2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtmappingproductsearch2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmappingproductsearch2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtmappingproductsearch2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmappingproductsearch2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnMappingsave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingsave_Enter(object sender, EventArgs e)
        {

            try
            {
                btnMappingsave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingsave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnMappingsave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingClose_Enter(object sender, EventArgs e)
        {
            try
            {
                btnMappingClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnMappingClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClear_Enter(object sender, EventArgs e)
        {

            try
            {
                btnClear.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClear_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClear.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string result = "";

                if (e.RowIndex != -1)
                {
                    if (grdSupplierList.Columns[e.ColumnIndex].Name == "clmdelete")
                    { 
                        DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {

                            SPDataService objspdservice = new SPDataService();
                            result = objspdservice.udfnSupplierMaster(5, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Delete Order Schedule", 0, "", 0, 0, 0, 0, 0, "", "", "", "", 0, "", varOrderid);
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "3")
                            {
                                grdSupplierList.Rows.RemoveAt(this.grdSupplierList.SelectedRows[0].Index);
                                for (int i = 0; i < grdSupplierList.RowCount; i++)
                                {
                                    grdSupplierList.Rows[i].Cells["clmsno"].Value = i + 1;
                                }
                                MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainForm.objCP_Supplierlist.udfnList();
                            }
                            else
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BtnSaveOrderType_Click(object sender, EventArgs e)
        {

            SPDataService objspdservice = new SPDataService();
            string result = "", varoriginator = "";
            int Vartype = 0;

            if (btnSaveOrderType.Text == "Update")
            { 
                result = objspdservice.udfnSupplierMaster(6, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, Convert.ToInt32(cmbReturnPolicy.SelectedValue), Convert.ToInt32(cmbReturnType.SelectedValue), 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Update supplier order type", 0, "", 0, vardayID, varMonthID, varWeekID, vardayMonthID, "", "", "","", 0, "", 0);
            } 

            string[] varvalue = result.Split('~');
            if (varvalue[0] == "3")
            {
                MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm.objCP_Supplierlist.udfnList();
                cmbReturnPolicy.Focus(); 
            }
            else
            {
                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Txtsalesmanmobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void Txtsalesmanwhatsapp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void GrdSupplierMappingLoad_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdSupplierMappingLoad .IsCurrentCellDirty)
                {
                    grdSupplierMappingLoad.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
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
                (grdSupplierMappingLoad.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in Tamil]) LIKE '%" + txtSearchByProduct1.Text + "%' OR ([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmappingproductsearch2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdFinalSupplierMapping.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in Tamil]) LIKE '%" + txtmappingproductsearch2.Text + "%' OR ([P.I Code]) LIKE '%" + txtmappingproductsearch2.Text + "%'";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdSupplierMappingLoad.Rows)
                {
                    row.Cells[0].Value = chkSelectAll.Checked;
                }
            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMappingView_Click(object sender, EventArgs e)
        {
            try
            { 
                udfnMappingGridsLoad(); 
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

        private void BtnaddMove_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSubGroupAdd();
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
        public void udfnSubGroupAdd()
        {
            try
            {
                string varRemoveProduct = "", varAddProduct = "";

                dtSubGroupMapping = new DataTable(); 
                dtSubGroupMapping.Columns.Add("S.No.", typeof(string));
                dtSubGroupMapping.Columns.Add("P.I Code", typeof(string));
                dtSubGroupMapping.Columns.Add("Product Name in Tamil", typeof(string));
                dtSubGroupMapping.Columns.Add("Unit", typeof(string));
                dtSubGroupMapping.Columns.Add("Product SubGroup", typeof(string));
                dtSubGroupMapping.Columns.Add("GROUPID", typeof(int));
                dtSubGroupMapping.Columns.Add("SUBGROUPID", typeof(int));
                dtSubGroupMapping.Columns.Add("PRODUCTID", typeof(int));
                

                if (grdSupplierMappingLoad.Rows.Count > 0)
                {
                    for (int i = 0; i < grdSupplierMappingLoad.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdSupplierMappingLoad.Rows[i].Cells[0].Value) == true)
                        {
                            int varFlag = 0,varcount=1;
                            for (int j = 0; j < dtSubGroupMapping.Rows.Count; j++)
                            {
                                varRemoveProduct = Convert.ToString(grdSupplierMappingLoad.Rows[i].Cells["PRODUCTID"].Value);
                                if (varRemoveProduct == Convert.ToString(dtSubGroupMapping.Rows[j]["PRODUCTID"]))

                                { varFlag = 1; }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                dtSubGroupMapping.Rows.Add(varcount, grdSupplierMappingLoad.Rows[i].Cells["P.I Code"].Value, grdSupplierMappingLoad.Rows[i].Cells["Product Name in Tamil"].Value, grdSupplierMappingLoad.Rows[i].Cells["Unit"].Value, grdSupplierMappingLoad.Rows[i].Cells["Product SubGroup"].Value, grdSupplierMappingLoad.Rows[i].Cells["GROUPID"].Value, grdSupplierMappingLoad.Rows[i].Cells["SUBGROUPID"].Value, grdSupplierMappingLoad.Rows[i].Cells["PRODUCTID"].Value);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < dtSubGroupMapping.Rows.Count; j++)
                            {
                                varAddProduct = Convert.ToString(grdSupplierMappingLoad.Rows[i].Cells["PRODUCTID"].Value);
                                if (varAddProduct == Convert.ToString(dtSubGroupMapping.Rows[j]["PRODUCTID"]))
                                {
                                    dtSubGroupMapping.Rows[j].Delete();
                                    dtSubGroupMapping.AcceptChanges();
                                }
                            }
                        }
                    }
                    grdFinalSupplierMapping.DataSource = dtSubGroupMapping;
                    grdFinalSupplierMapping.Columns["clmMappingRemove"].DisplayIndex = 5;

                    grdFinalSupplierMapping.Columns["S.No."].Width = 50;
                    grdFinalSupplierMapping.Columns["P.I Code"].Width = 100;
                    grdFinalSupplierMapping.Columns["Product Name in Tamil"].Width = 220;
                    grdFinalSupplierMapping.Columns["Unit"].Width = 100;
                    grdFinalSupplierMapping.Columns["Product SubGroup"].Width = 120;
                    grdFinalSupplierMapping.Columns["GROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["SUBGROUPID"].Visible = false;
                    grdFinalSupplierMapping.Columns["PRODUCTID"].Visible = false;

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

        private void GrdFinalSupplierMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdFinalSupplierMapping.Columns[e.ColumnIndex].Name)
                    {
                        case "clmMappingRemove":

                            grdFinalSupplierMapping.Rows.RemoveAt(this.grdFinalSupplierMapping.SelectedRows[0].Index);
                            for (int i = 0; i < grdFinalSupplierMapping.RowCount; i++)
                            {
                                grdFinalSupplierMapping.Rows[i].Cells["S.No."].Value = i + 1;
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

        private void BtnMappingsave_Click(object sender, EventArgs e)
        {
            try {
                string VarproductId = "", result="";


                for (int i = 0; i < grdSupplierMappingLoad.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSupplierMappingLoad.Rows[i].Cells[0].Value) == true)
                    {
                        if (VarproductId == "")
                        {
                            VarproductId = Convert.ToString(grdSupplierMappingLoad.Rows[i].Cells["PRODUCTID"].Value);
                        }
                        else
                        {
                            VarproductId = VarproductId + ',' + Convert.ToString(grdSupplierMappingLoad.Rows[i].Cells["PRODUCTID"].Value);
                        }
                    }
                }

                //if (btnSave.Text == "Save")
                //{
                //    }
                //else
                //{
                  
                //}
                //string[] varvalue = result.Split('~');
                //if (varvalue[0] == "3")
                //{
                //    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    MainForm.objCP_RepresentativeList.udfnlist();
                //    txtCompanyName.Focus();
                //    if (btnSave.Text == "Update")
                //    {
                //        varupdate = "1";
                //        udfnclose();
                //    }

                //    udfnClear();
                //}
                //else
                //{
                //    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}


                //objspdservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnaddMove_Enter(object sender, EventArgs e)
        {
            try
            {
                BtnaddMove.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnaddMove_Leave(object sender, EventArgs e)
        {
            try
            {
                BtnaddMove.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                udfnSupplierOrderSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSupplierOrderSave()
        {
            try
            {
                bool blnErrorFlag = false;
                int varflag = 0;
                if (txtScheduleName.Text == "")
                { 
                    errCompany.SetError(txtScheduleName, "Please enter the schedule");
                    txtScheduleName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter the schedule", txtScheduleName, 5000); 
                    blnErrorFlag = true;
                }
                if (txtsalesmanname.Text == "")
                {

                    errCompany.SetError(txtsalesmanname, "Please enter salesman name");
                    txtsalesmanname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter salesman name", txtsalesmanname, 5000);
                    blnErrorFlag = true; 
                }
                if (txtsalesmanmobile.Text == "")
                {

                    errCompany.SetError(txtsalesmanmobile, "Please enter salesman mobile No.");
                    txtsalesmanmobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tparea.ShowAlways = true;
                    tparea.Show("Please enter salesman mobile No.", txtsalesmanmobile, 5000);
                    blnErrorFlag = true;  
                }
                if (blnErrorFlag == false)
                {
                    foreach (DataGridViewRow row in grdSupplierList.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                        {
                            string gridValue1 = row.Cells[4].Value.ToString();
                            string gridValue2 = row.Cells[1].Value.ToString();

                            if (gridValue1 == Convert.ToString(cmbOrderType.Text) || gridValue2 == txtScheduleName.Text)
                            {
                                varflag = 1;
                            }
                        }
                    }

                    if (varflag == 0)
                    {
                       

                        string VarTotalDays = "";
                        for (int i = 0; i < grddays.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(grddays.Rows[i].Cells["clmcheck"].Value) == true)
                            {
                                if (VarTotalDays == "")
                                {
                                    VarTotalDays = Convert.ToString(grddays.Rows[i].Cells["DYID"].Value);
                                }
                                else
                                {
                                    VarTotalDays = VarTotalDays + ',' + Convert.ToString(grddays.Rows[i].Cells["DYID"].Value);
                                }
                            }

                        }
                        SupplierUpdate = 0;
                        if (Convert.ToInt32(varsupplierID) != 0)
                        {
                            SupplierUpdate = Convert.ToInt32(varsupplierID);
                        }
                        else
                        {
                            SupplierUpdate = Convert.ToInt32(pbSupplierid);
                        }

                        SPDataService objspdservice = new SPDataService();
                        string result = "", varoriginator = "";
                        int Vartype=0 ;

                        if (btnAdd.Text == "Save")
                        {
                            varoriginator = "Supplier Order Create";
                            Vartype = 3;
                           
                        }
                        else
                        {
                            varoriginator = "Supplier Order Update";
                            Vartype = 4; 
                        }
                        result = objspdservice.udfnSupplierMaster(Vartype, SupplierUpdate, "", "", "", 0, "", "", "", "", "","", 0,
                            Convert.ToInt32(cmbReturnPolicy.SelectedValue), varrecyclecode, 0, 0, 0, "",MainForm.pbUserID, MainForm.pbIpAddress, varoriginator,
                            0, "", 0, vardayID, varMonthID, varWeekID, vardayMonthID, txtsalesmanname.Text, txtScheduleName.Text, txtsalesmanmobile.Text,
                            txtsalesmanwhatsapp.Text, Convert.ToInt32(cmbOrderType.SelectedValue), VarTotalDays, varOrderid);

                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.ActiveControl = tcSupplier; 
                            MainForm.objCP_Supplierlist.udfnList(); 
                            txtScheduleName.Focus();
                           
                            if (btnAdd.Text == "Update")
                            {
                                varupdate = "1";
                                udfnclose();
                                udfnclear();
                            }
                            else
                            { 
                                varOrderid = Convert.ToInt32(varvalue[2]);
                            }
                            grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, txtScheduleName.Text, txtsalesmanname.Text, txtsalesmanmobile.Text, Convert.ToString(cmbOrderType.Text), varOrderid);

                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Order Type already exists in Schedule!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
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

        private void BtnClose_Leave(object sender, EventArgs e)
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

        private void BtnClose_Enter(object sender, EventArgs e)
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

        public void udfnGrdevent()
        {
            try
            {
                if (txtCity.Text != "")
                {
                    txtCity.Text = lvCity.SelectedItems[0].SubItems[0].Text;
                    lvCity.Visible = false;
                    DataService objDataService = new DataService();
                    lblcity.Text = lvCity.SelectedItems[0].SubItems[2].Text;
                    objDataService.CloseConnection();
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


    