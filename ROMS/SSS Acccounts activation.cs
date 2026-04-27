
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class Activation : Form
    {
        Authentication objauth = new Authentication();
        DataValidation objvalidation = new DataValidation();
        DataError objError;
        private ToolTip mbleno = new ToolTip();
        private ToolTip email = new ToolTip();
        SecurityController _security = new SecurityController();
        public Activation()
        {
            InitializeComponent();
        }
        public string GenerateMD5(string HashString)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(HashString)).Select(s => s.ToString("x2")));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                 
                string processid = "";
                string uniqueid = "";
                string varSerialNumber = "";
                DataValidation obj = new DataValidation();
                varSerialNumber = obj.baseId();
                txtRegistration.Text = GenerateMD5( varSerialNumber).ToUpper();
                DataService dser = new DataService();
                DataValidation dval = new DataValidation();
                if (dval.internetconnection() == false)
                {
                    lblNetwork.Text = "Off";
                    btnGetOtp.Enabled = false;
                    btnSubmit.Enabled = false;
                }
                else
                {
                    lblNetwork.Text = "On";
                    if (obj.checkCloudAccess())
                    {
                        btnGetOtp.Enabled = true;
                        lblWarningText.Visible = false;
                    }
                    else
                    {
                        btnGetOtp.Enabled = false;
                        btnSubmit.Enabled = false;
                        lblWarningText.Visible = true;
                    }
                }
            }
            catch(Exception ex)
            {
                lblNetwork.Text = "Off";
                btnGetOtp.Enabled = false;
                objError = new DataError(); objError.WriteFile(ex);
            }
        }
 private void btnGetOtp_Click(object sender, EventArgs e)
        {
            try
            {
                DataValidation dval = new DataValidation();
                txtotp.Text = "";
                if (txtMobile.Text != "" && txtEmail.Text != "")
                {
                   // if (!NetworkInterface.GetIsNetworkAvailable())
                   if(dval.internetconnection() == false)
                    {
                        MessageBox.Show("No Network Connection, Please Check your Internet Connection", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        //ActivationService.ActivationService activser = new ActivationService.ActivationService();
                        //activser.udfngetOTPForProduct(txtName.Text, txtMobile.Text, txtEmail.Text, txtAddress.Text, txtRegistration.Text, "1.1.1","30");
                        //MessageBox.Show("OTP sent successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                }
                else
                {
                    if (txtMobile.Text == "")
                    {
                        errorProvider1.SetError(txtMobile, "This field is required");
                        txtMobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        mbleno.ShowAlways = true;
                        mbleno.Show("This field is required", txtMobile);
                    }
                    else if (txtMobile.Text != "" && objvalidation.FormatNumeric(txtMobile.Text) == false && txtMobile.Text.Length <= 10)
                    {
                        errorProvider1.SetError(txtMobile, "Please enter correctMobile No.");
                        txtMobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        mbleno.ShowAlways = true;
                        mbleno.Show("Please enter correctMobile No.", txtMobile);
                        txtMobile.Text = "";
                        txtMobile.Focus();
                    }
                    else
                    {
                        errorProvider1.Clear();
                        txtMobile.BackColor = Color.White;
                        mbleno.Hide(txtMobile);
                    }
                    if (txtEmail.Text == "")
                    {
                        errorProvider1.SetError(txtEmail, "This field is required");
                        txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        email.ShowAlways = true;
                        email.Show("This field is required", txtMobile);
                    }
                    else if (txtEmail.Text != "" && objvalidation.FormatEMail(txtEmail.Text) == false)
                    {
                        errorProvider1.SetError(txtEmail, "Please enter correctEmailID");
                        txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        email.ShowAlways = true;
                        email.Show("Please enter correctEmailID", txtEmail);

                        txtEmail.Text = "";
                        txtEmail.Focus();
                    }
                    else
                    {
                        errorProvider1.Clear();
                        txtEmail.BackColor = Color.White;
                        email.Hide(txtEmail);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        public void CreateFile(string filepath, string customername, string mobileno, string emailid, string address, string otp, string encriptedtext)
        {
            try
            {
                DataValidation dserv = new DataValidation();
                deletefile(filepath);
                var textwritten = encriptedtext + Environment.NewLine + dserv.Encrypt(otp) + Environment.NewLine + dserv.Encrypt(customername) + Environment.NewLine + dserv.Encrypt(mobileno) + Environment.NewLine + dserv.Encrypt(emailid) + Environment.NewLine + dserv.Encrypt(address);
                if (!File.Exists(filepath))
                {
                    var fileStream =  File.Create(filepath);
                    fileStream.Close();                 
                    TextWriter tw = new StreamWriter(filepath);
                    tw.WriteLine(textwritten);
                    tw.Close();
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        public void deletefile(string filepath)
        {
            try
            {
                FileInfo info = new FileInfo(filepath);
                if (info.Exists) { System.IO.File.Delete(filepath); }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SPDataService spservice = new SPDataService();
                string result = "";
                string varSerialNumber = "";
                DataValidation obj = new DataValidation();
                varSerialNumber = obj.baseId();
                DataValidation dval = new DataValidation();
                if (dval.internetconnection() == false)
                {
                    MessageBox.Show("No Network Connection, Please Check your Internet Connection", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                   // ActivationService.ActivationService activser = new ActivationService.ActivationService();
                   // DataService dser = new DataService();
                   // // string version = dser.displaydata("select Versionno from tblVersionDetails where status='Active'");
                   // string version = "1.1.1";
                   // dser.CloseConnection();
                   // result = activser.udfnAuthenticate(txtName.Text, txtMobile.Text, txtEmail.Text, txtAddress.Text, txtRegistration.Text, version, txtotp.Text,"30");
                   //// result = "Success";

                   // if (result == "Success")
                   // {
                   // //    spservice.udfnExecuteQuery(" insert into tblSSSProductUserDetails(Username, Address, mobileno, emailid, registrationkey,    versionno,Activationcode,Status) values('" + spservice.ReplaceQuotes(txtName.Text) + "', '" + spservice.ReplaceQuotes(txtAddress.Text) + "','" + txtMobile.Text + "','" + txtEmail.Text + "', '" + txtRegistration.Text + "', '1.1','" + txtotp.Text + "','Activated') ");
                   //     string foldername = obj.Encrypt("Activation");
                   //     string path = Application.StartupPath + "\\"+ foldername;
                   //     if (!Directory.Exists(path))
                   //     { Directory.CreateDirectory(path); }
                   //     string filename = obj.Encrypt("Activation");
                   //     string filepath = path +"\\" + filename + ".sss";
                   //     string encriptedtext = _security.Encrypt("Activation", string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(varSerialNumber)).Select(s => s.ToString("x2"))).ToUpper());
                   //     CreateFile(filepath, txtName.Text, txtMobile.Text,txtEmail.Text, txtAddress.Text, txtotp.Text, encriptedtext);
                   //     this.Hide();
                   //     objauth.Show();
                   // }
                   // if (result == "Blocked")
                   // {
                   //     MessageBox.Show("You are a blocked user, cant access this Product", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                   //     this.Close();
                   // }
                   // if (result == "Activated")
                   // {
                   //     this.Hide();
                   //     objauth.Show();

                   //     //Application.EnableVisualStyles();
                   //     //Application.SetCompatibleTextRenderingDefault(false);
                   //     //Application.Run(new Authentication());

                   // }
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtotp_Leave(object sender, EventArgs e)
        {
            try
            {
                txtotp.BackColor = Color.White;
                if (txtotp.Text!="")
                {
                    btnSubmit.Enabled = true;
                }
                else
                {
                    btnSubmit.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                objError = new DataError();objError.WriteFile(ex);
            }
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            mbleno.Active = false;
            email.Active = false;
        }

        private void txtotp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtotp.Text.Length==6)
                {
                    btnSubmit.Enabled = true;
                }
                else
                {
                    btnSubmit.Enabled = false;
                }

            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void txtotp_Enter(object sender, EventArgs e)
        {

            try
            {
                txtotp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtotp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
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

        private void txtName_Enter(object sender, EventArgs e)
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

        private void txtMobile_Enter(object sender, EventArgs e)
        {

            try
            {
                txtMobile.BackColor = Color.LemonChiffon;
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

        private void txtAddress_Enter(object sender, EventArgs e)
        {

            try
            {
                txtAddress.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtName_Leave(object sender, EventArgs e)
        {

            try
            {
                txtName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtMobile_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMobile.Text == "")
                {
                    errorProvider1.SetError(txtMobile, "This field is required");
                    txtMobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    mbleno.ShowAlways = true;
                    mbleno.Show("This field is required", txtMobile);
                }
                else if (txtMobile.Text != "" && objvalidation.FormatNumeric(txtMobile.Text) == false && txtMobile.Text.Length <= 10)
                {
                    errorProvider1.SetError(txtMobile, "Please enter correctMobile No.");
                    txtMobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    mbleno.ShowAlways = true;
                    mbleno.Show("Please enter correctMobile No.", txtMobile);
                    //txtMobile.Text = "";
                    txtMobile.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    txtMobile.BackColor = Color.White;
                    mbleno.Hide(txtMobile);
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
                if (txtEmail.Text == "")
                {
                    errorProvider1.SetError(txtEmail, "This field is required");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    email.ShowAlways = true;
                    email.Show("This field is required", txtMobile);
                }
                else if (txtEmail.Text != "" && objvalidation.FormatEMail(txtEmail.Text) == false)
                {
                    errorProvider1.SetError(txtEmail, "Please enter correctEmailID");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    email.ShowAlways = true;
                    email.Show("Please enter correctEmailID", txtEmail);

                    //txtEmail.Text = "";
                    txtEmail.Focus();
                }
                else
                {
                    errorProvider1.Clear();
                    txtEmail.BackColor = Color.White;
                    email.Hide(txtEmail);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAddress.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMobile.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                throw ex;
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
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
                throw ex;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddress.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                throw ex;
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtotp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnGetOtp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                throw ex;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                {
                    e.Handled = true;
                    // MessageBox.Show("Please enter only disgits", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ServerSettings obj = new ServerSettings();
                obj.lblformname.Text = "activation";
                obj.Show();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
    }
    }

