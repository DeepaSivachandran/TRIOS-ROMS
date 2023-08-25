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
         

        private void txtAContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.FormatNumericOnly(e);
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
                 //   btnSave_Click(sender, e);
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
                bool varResult = objvalidation.FormatNumericOnly(e);
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
                bool varResult = objvalidation.FormatNumericOnly(e);
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
                    cmbPaymentTerm.Focus();
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
                  //  txtrepaddress.Focus();
                }
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
                cmbOrderType.Focus();
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
               // txtsalesmanaddress.Focus();
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
                  //  txtrepname.Focus();
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
                if (cmbReturnPolicy.Text == "Yes") { cmbReturnType.Visible = true; }
                else { cmbReturnType.Visible = false; }
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
                    cmbPolicyContent.DataSource = null; 
                    txtReturnText.Visible = false;
                    cmbPolicyContent.Visible = false;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                }
                else if ((Convert.ToString(cmbReturnType.SelectedValue) == "25")) {
                    txtReturnText.Text = "Day";
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
                }
                else if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                {
                    txtReturnText.Text = "Week No.";
                    txtReturnText.Visible = true;
                    cmbPolicyContent.DataSource = null;
                    cmbSecondLevel.DataSource = null;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (28,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPolicyContent, "", "MST_DisplayText", "MSTID");
                    objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbSecondLevel, "", "DY_Name", "DYID");

                    cmbPolicyContent.SelectedIndex = 0;
                    txtNextLevel.Text = "Day";
                     
                    objDataBind = null;
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                    cmbSecondLevel.SelectedIndex = 0;
                }
                else if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                {
                    txtReturnText.Text = "Month";
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true; 
                    cmbPolicyContent.DataSource=null;
                    cmbSecondLevel.DataSource = null;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Months", "MONID NOT IN (0,-1)", "MON_Name,MONID", cmbPolicyContent, "", "MON_Name", "MONID"); 
                    cmbPolicyContent.SelectedIndex = 0;
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                    txtNextLevel.Text = "Day of the month"; 
                    objDataBind.BindComboBoxListSelected("DEF_Month_Days", "1=1", "MOND_Name,MONDID", cmbSecondLevel, "", "MOND_Name", "MONDID");
                    objDataBind = null;
                    cmbSecondLevel.SelectedIndex = 0;
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
                //if (Convert.ToString(cmbDesignation.SelectedValue) == "" || Convert.ToString(cmbDesignation.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbDesignation, "Please Select Designation");
                //    cmbDesignation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please Select Designation", cmbDesignation, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbDesignation.BackColor = Color.White;
                //}
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
                //if (Convert.ToString(cmbPaymentTerm.SelectedValue) == "" || Convert.ToString(cmbPaymentTerm.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbPaymentTerm, "Please Select Payment Term");
                //    cmbPaymentTerm.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please Select Payment Term", cmbPaymentTerm, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbPaymentTerm.BackColor = Color.White;
                //}
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
                //if (Convert.ToString(cmbSupplierType.SelectedValue) == "" || Convert.ToString(cmbSupplierType.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbSupplierType, "Please Select Supplier Type");
                //    cmbSupplierType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please Select Payment Supplier Type", cmbSupplierType, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbSupplierType.BackColor = Color.White;
                //}
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

                    btnAdd.Focus();

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
                //if (Convert.ToString(cmbOrderType.SelectedValue) == "" || Convert.ToString(cmbOrderType.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbOrderType, "Please select order type");
                //    cmbOrderType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select order type", cmbOrderType, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbOrderType.BackColor = Color.White;
                //}
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

                btnAdd.BackColor = Color.White;
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

                btn_close.BackColor = Color.White;
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

                btn_Close2.BackColor = Color.White;
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


    