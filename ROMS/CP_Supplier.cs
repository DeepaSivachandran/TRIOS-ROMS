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


        public string varcompanycode;
        public string pbFormStatus;
        public string varstatecode = "";

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
        public CP_Supplier()
        {
            InitializeComponent();
        }

        private void txtCompanyName_Enter(object sender, EventArgs e)
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

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCompanyName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text  == "")
            {

                errCompany.SetError(txtName, "Please enter name");
                txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter name.", txtName, 5000);

            }
            else
            {
                errCompany.Clear();
                txtName.BackColor = Color.White;
                tparea.Hide(txtName);
            }
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
                    txtArea.Focus();
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
                txtContactNumber.BackColor = Color.White;
                try
                {
                    if (txtContactNumber.Text == "")
                    {
                        if (objvalidation.FormatNumeric(txtContactNumber.Text) == false || txtContactNumber.Text.Length < 10)
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

        }

        private void txtAContactNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAContactNumber.BackColor = Color.White;
                if (txtAContactNumber.Text == "")
                {
                    if (objvalidation.FormatNumeric(txtAContactNumber.Text) == false || txtAContactNumber.Text.Length < 10)
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
                    txtcreditlimit.Focus();
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

        private void udfnclear()
        {
            try
            {
                txtName.Text = "";
                txtcontactName.Text = "";
                txtArea.Text = "";
                txtCity.Text = "";
                txtContactNumber.Text = "";
                txtAContactNumber.Text = "";
                txtEmail.Text = "";  
                txtPincode.Text = "";
                btnSave.Text = "Save";
                txtName.Focus();
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

        
        
        private void CP_Supplier_Load(object sender, EventArgs e)
        {
            try
            {

                this.ActiveControl = txtName;
                udfnLoadState(); 
                udfnEdit();
                BindDataGrid();
                cmbReturnPolicy.Items.Add("Yes");
                cmbReturnPolicy.Items.Add("No");
                cmbReturnPolicy.SelectedIndex = 0;
                cmbReturnType.Items.Add("Any Time");
                cmbReturnType.Items.Add("Weekly");
                cmbReturnType.Items.Add("Monthly");
                cmbReturnType.Items.Add("Quarterly");
                cmbReturnType.SelectedIndex = 0;
                txtReturnText.Visible = false;
                cmbPolicyContent.Visible = false;
                txtNextLevel.Visible = false;
                cmbSecondLevel.Visible = false;
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
                string[] item = new string[30];
                ListViewItem listitem = new ListViewItem(); DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Day", typeof(string));

                dataTable.Rows.Add("Monday");
                dataTable.Rows.Add("Tuesday");
                dataTable.Rows.Add("Wednesday");
                dataTable.Rows.Add("Thursday");
                dataTable.Rows.Add("Friday");
                dataTable.Rows.Add("Saturday");
                dataTable.Rows.Add("Sunday");


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string day = dataTable.Rows[i]["Day"].ToString();
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(grddays);
                    row.Cells[1].Value = day;
                    grddays.Rows.Add(row);

                    //item[0] = "";
                    //item[1] = dataTable.Rows[i]["Day"].ToString();
                    //listitem = new ListViewItem(item);
                    //grddays.Rows.Add(item[0],item[1]);
                }
                // Assign the DataTable as the data source for the DataGridView 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


            // grddays.DataSource = dataTable;
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

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.FormatAlphabeticWithSpaceOnly(e);
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

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (txtPincode.Text == "")
                    {
                        if (objvalidation.FormatNumeric(txtPincode.Text) == false || txtPincode.Text.Length < 6)
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

        private void txtArea_Enter_1(object sender, EventArgs e)
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

        private void txtPincode_KeyDown_1(object sender, KeyEventArgs e)
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

        private void txtFSSAI_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtDPincode_TextChanged(object sender, EventArgs e)
        {

        }
         

        private void TxtAlterPhno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAContactNumber_KeyDown_1(object sender, KeyEventArgs e)
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
            if (txtwhatsapp.Text  == "")
            {

                errCompany.SetError(txtwhatsapp, "Please enter whatsapp No.");
                txtwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tparea.ShowAlways = true;
                tparea.Show("Please enter whatsapp No.", txtwhatsapp, 5000);

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
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void Txtrepname_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtrepname_Enter(object sender, EventArgs e)
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

        private void Txtrepname_Leave(object sender, EventArgs e)
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

        private void Txtrepaddress_Enter(object sender, EventArgs e)
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

        private void Txtrepaddress_KeyDown(object sender, KeyEventArgs e)
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

        private void Txtrepaddress_Leave(object sender, EventArgs e)
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

        private void Txtrepmobileno_Enter(object sender, EventArgs e)
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

        private void Txtrepmobileno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtrepmobileno_Leave(object sender, EventArgs e)
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

        private void Txtrepwhatsappno_Leave(object sender, EventArgs e)
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

        private void Txtrepwhatsappno_KeyDown(object sender, KeyEventArgs e)
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

        private void Txtrepwhatsappno_Enter(object sender, EventArgs e)
        {
            
        }

        private void Txtsalesmanname_Leave(object sender, EventArgs e)
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

        private void Txtsalesmanname_KeyDown(object sender, KeyEventArgs e)
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

        private void Txtsalesmanname_Enter(object sender, EventArgs e)
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

        private void Txtsalesmanaddress_Leave(object sender, EventArgs e)
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

        private void Txtsalesmanaddress_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsalesmanaddress_Enter(object sender, EventArgs e)
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

        private void Txtsalesmanmobile_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
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
            try
            {
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
            try
            {
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsalesmanwhatsapp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtgstin.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsalesmanwhatsapp_Enter(object sender, EventArgs e)
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

        private void Txtcst_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtcst.Text  == "")
            //    {

            //        errCompany.SetError(txtcst, "Please enter CST");
            //        txtcst.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //        tparea.ShowAlways = true;
            //        tparea.Show("Please enter CST.", txtcst, 5000);

            //    }
            //    else
            //    {
            //        errCompany.Clear();
            //        txtcst.BackColor = Color.White;
            //        tparea.Hide(txtcst);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void Txtcst_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtsupplybrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtcst_Enter(object sender, EventArgs e)
        {
            try
            {
                //txtcst.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsupplybrand_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtsupplybrand.Text  == "")
                //{

                //    errCompany.SetError(txtsupplybrand, "Please enter supply brand");
                //    txtsupplybrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tparea.ShowAlways = true;
                //    tparea.Show("Please enter supply brand.", txtsupplybrand, 5000);

                //}
                //else
                //{
                //    errCompany.Clear();
                //    txtsupplybrand.BackColor = Color.White;
                //    tparea.Hide(txtsupplybrand);
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsupplybrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //rbphorder.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtsupplybrand_Enter(object sender, EventArgs e)
        {
            try
            {
               // txtsupplybrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rbphorder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   // rbvisitdate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rbvisitdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cmbvisitday.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Cmbvisitday_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                  //  rbpropritor.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rbpropritor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                  //  rbmanager.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rbmanager_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
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
                if (panelStatus.Enabled == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        rbActive.Focus();
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

        private void Txtgstin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   // txtcst.Focus();
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

        private void Txtcreditlimit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txtrepmobileno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TextBox34_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDOrderDay_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbESupplierType_Leave(object sender, EventArgs e)
        {
        }

        private void CmbESupplierType_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cmbSupplierType.SelectedItem != "URD")
                {
                    txtgstin.Enabled = true;
                }
                else
                {
                    txtgstin.Enabled = false;
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

        private void TxtDPaymentTerm_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbPaymentTerm_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                if (cmbDesignation.SelectedItem == "The Proprietor")
                {
                    txtDShortName.Text = "Proprietor Name";
                }
                if (cmbDesignation.SelectedItem == "The Manager")
                {
                    txtDShortName.Text = "Manager Name";
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
                if (cmbReturnPolicy.Text == "Yes") { cmbReturnType.Enabled = true; }
                else { cmbReturnType.Enabled = false; }
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
                if (cmbReturnType.Text == "Any Time") {
                    cmbPolicyContent.Items.Clear();
                    txtReturnText.Visible = false;
                    cmbPolicyContent.Visible = false;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                }
                else if (cmbReturnType.Text == "Weekly") {
                    txtReturnText.Text = "Day";
                    cmbPolicyContent.Enabled = true;
                    cmbPolicyContent.Items.Clear();
                    cmbPolicyContent.Items.Add("Monday");
                    cmbPolicyContent.Items.Add("Tuesday");
                    cmbPolicyContent.Items.Add("Wednesday");
                    cmbPolicyContent.Items.Add("Thursday");
                    cmbPolicyContent.Items.Add("Friday");
                    cmbPolicyContent.Items.Add("Saturday");
                    cmbPolicyContent.Items.Add("Sunday");
                    cmbPolicyContent.SelectedIndex = 0;
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                }
                else if (cmbReturnType.Text == "Monthly") {
                    txtReturnText.Text = "Week No.";
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    cmbPolicyContent.Items.Clear();
                    cmbPolicyContent.Items.Add("1st Week");
                    cmbPolicyContent.Items.Add("2nd Week");
                    cmbPolicyContent.Items.Add("3rd Week");
                    cmbPolicyContent.Items.Add("4th Week");
                    cmbPolicyContent.Items.Add("5th Week");
                    cmbPolicyContent.SelectedIndex = 0;
                    txtNextLevel.Text = "Day";
                    cmbSecondLevel.Items.Clear();
                    cmbSecondLevel.Items.Add("Monday");
                    cmbSecondLevel.Items.Add("Tuesday");
                    cmbSecondLevel.Items.Add("Wednesday");
                    cmbSecondLevel.Items.Add("Thursday");
                    cmbSecondLevel.Items.Add("Friday");
                    cmbSecondLevel.Items.Add("Saturday");
                    cmbSecondLevel.Items.Add("Sunday");
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                    cmbSecondLevel.SelectedIndex = 0;
                }
                else if (cmbReturnType.Text == "Quarterly") {
                    txtReturnText.Text = "Month";
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    cmbPolicyContent.Items.Clear();
                    cmbPolicyContent.Items.Add("January");
                    cmbPolicyContent.Items.Add("February");
                    cmbPolicyContent.Items.Add("March");
                    cmbPolicyContent.Items.Add("April");
                    cmbPolicyContent.Items.Add("May");
                    cmbPolicyContent.Items.Add("June");
                    cmbPolicyContent.Items.Add("July");
                    cmbPolicyContent.Items.Add("August");
                    cmbPolicyContent.Items.Add("September");
                    cmbPolicyContent.Items.Add("October");
                    cmbPolicyContent.Items.Add("November");
                    cmbPolicyContent.Items.Add("December");
                    cmbPolicyContent.SelectedIndex = 0;
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                    txtNextLevel.Text = "Day of the month";
                    cmbSecondLevel.Items.Clear();
                    cmbSecondLevel.Items.Add("1");
                    cmbSecondLevel.Items.Add("2");
                    cmbSecondLevel.Items.Add("3");
                    cmbSecondLevel.Items.Add("4");
                    cmbSecondLevel.Items.Add("5");
                    cmbSecondLevel.Items.Add("6");
                    cmbSecondLevel.Items.Add("7");
                    cmbSecondLevel.Items.Add("8");
                    cmbSecondLevel.Items.Add("9");
                    cmbSecondLevel.Items.Add("10");
                    cmbSecondLevel.Items.Add("11");
                    cmbSecondLevel.Items.Add("12");
                    cmbSecondLevel.Items.Add("13");
                    cmbSecondLevel.Items.Add("14");
                    cmbSecondLevel.Items.Add("15");
                    cmbSecondLevel.Items.Add("16");
                    cmbSecondLevel.Items.Add("17");
                    cmbSecondLevel.Items.Add("18");
                    cmbSecondLevel.Items.Add("19");
                    cmbSecondLevel.Items.Add("20");
                    cmbSecondLevel.Items.Add("21");
                    cmbSecondLevel.Items.Add("22");
                    cmbSecondLevel.Items.Add("23");
                    cmbSecondLevel.Items.Add("24");
                    cmbSecondLevel.Items.Add("25");
                    cmbSecondLevel.Items.Add("26");
                    cmbSecondLevel.Items.Add("27");
                    cmbSecondLevel.Items.Add("28");
                    cmbSecondLevel.Items.Add("29");
                    cmbSecondLevel.Items.Add("30");
                    cmbSecondLevel.Items.Add("31");
                    cmbSecondLevel.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPolicyContent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


    