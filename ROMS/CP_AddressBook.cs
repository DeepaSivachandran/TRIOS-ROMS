using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROMS.Model;
namespace ROMS
{
    public partial class CP_AddressBook : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpCompanyName = new ToolTip();
        private ToolTip tpShortName = new ToolTip();
        private ToolTip tpAddressLine1 = new ToolTip();
        private ToolTip tpAddressLine2 = new ToolTip();
        private ToolTip tpState = new ToolTip();
        private ToolTip tpBankName = new ToolTip();
        private ToolTip tpCity = new ToolTip();
        private ToolTip tpPincode = new ToolTip();
        private ToolTip tpPhoneNo = new ToolTip();
        private ToolTip tpMobileNo = new ToolTip();
        private ToolTip tpWhatsAppNo = new ToolTip();
        private ToolTip tpEmail = new ToolTip();
        private ToolTip tpWebsite = new ToolTip();
        private ToolTip tpGstin = new ToolTip();
        private ToolTip tpPan = new ToolTip();
        private ToolTip tpEsi = new ToolTip();
        private ToolTip tpEsf = new ToolTip();
        private ToolTip tpFssai = new ToolTip();
        private ToolTip tpPlNo = new ToolTip();
        private ToolTip tpName = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        private ToolTip tpMobileNumber = new ToolTip();
        private ToolTip tpOperator = new ToolTip();
        private ToolTip tpStaffName = new ToolTip();
        private ToolTip tpMobileBrand = new ToolTip();
        private ToolTip tpCPName = new ToolTip();
        private ToolTip tpCPPincode = new ToolTip();
        private ToolTip tpcpmobileno2 = new ToolTip(); 
        private ToolTip tpcpMobileNo1 = new ToolTip();
        private ToolTip tpCPEmail = new ToolTip();
         
        private ToolTip tpBankShortName = new ToolTip();
        private ToolTip tpBranchName = new ToolTip();
        private ToolTip tpAccountNo = new ToolTip();
        private ToolTip tpIfsCode = new ToolTip();
        public int varCompanyModifiedFlag = 0;
        public int varContactModifiedFlag = 0;
        public string varupdate = "0";
        public string varcompanyid="0",varstatusid ="0", varcontactcompanyid = "0", varSlNo = "0", varCMSlNo = "0", varstatus="";
        public static int varCloseFlag = 0, varflag = 0, varstatusidContact = 1;
        string varNewfile = ""; string varFile = "";
        OpenFileDialog objfilelogo = new OpenFileDialog();
        public string pbLogoPath = "", pbCompanypath = "";
        public int varDefaultBank = 0,pbCityID=0,pbCPCityid=0,pbABID=0;
        public string varDefault = "";
        DataSet objDTBank = new DataSet();
        public CP_AddressBook()
        {
            InitializeComponent();
        }

        public void udfntooltiphide()
        {
            try
            {
                
                tpCompanyName.Active = false;
                tpCompanyName.Active = false; 
                tpShortName.Active = false; 
                tpAddressLine1.Active = false; 
                tpAddressLine2.Active = false; 
                tpState.Active = false;
                tpBankName.Active = false; 
                tpCity.Active = false; 
                tpPincode.Active = false; 
                tpPhoneNo.Active = false; 
                tpMobileNo.Active = false; 
                tpWhatsAppNo.Active = false; 
                tpEmail.Active = false; 
                tpWebsite.Active = false; 
                tpGstin.Active = false; 
                tpPan.Active = false; 
                tpEsi.Active = false; 
                tpEsf.Active = false; 
                tpFssai.Active = false; 
                tpPlNo.Active = false; 
                tpName.Active = false; 
                tpTransactionType.Active = false; 
                tpMobileNumber.Active = false; 
                tpOperator.Active = false;
                tpStaffName.Active = false;
                tpMobileBrand.Active = false;

                tpBankName.Active = false;
                tpBankShortName.Active = false;
                tpBranchName.Active = false;
                tpAccountNo.Active = false;
                tpIfsCode.Active = false;
                epCompany.Clear();

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
                if (varupdate == "0")
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
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
        private void CP_Company_KeyDown(object sender, KeyEventArgs e)
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
                    BtnSave_Click(sender, e);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }   
               
        private void TxtCompanyName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCompanyName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCompanyName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtCompanyName.Text).Trim() == "")
                {
                    epCompany.SetError(txtCompanyName, "Please enter company name");
                    txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCompanyName.ShowAlways = true;
                    tpCompanyName.Show("Please enter company name", txtCompanyName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtCompanyName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddressLine1.Focus();
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
                btnSave.Enabled = true; string varResult = "", varoriginator="";
                SPDataService objspdservice = new SPDataService();
                string result = "";
                string varStatus = "1";
                int varABID = 0,viewType=0;
                if(varABID==0)
                { viewType = 0; }
                else { viewType = 1; }
                MR_AddressBook objMR_AddressBook = new MR_AddressBook();
                objMR_AddressBook.ViewType = viewType;
                objMR_AddressBook.paraCompanyName = txtCompanyName.Text.Trim();
                objMR_AddressBook.paraAddress1 = txtAddressLine1.Text.Trim();
                objMR_AddressBook.paraAddress2 = txtAddressLine2.Text.Trim();
                objMR_AddressBook.paraStatusID = Convert.ToInt32(cmbState.SelectedValue);
                objMR_AddressBook.paraCTYID = pbCityID;
                objMR_AddressBook.paraPincode = txtPincode.Text.Trim();
                objMR_AddressBook.paraPhoneNo = txtPhoneNo.Text.Trim();
                objMR_AddressBook.paraMobileNo = txtmobileNo.Text.Trim();
                objMR_AddressBook.paraMobileNo1 = txtAlterMobileno.Text.Trim();
                objMR_AddressBook.paraEmail = txtEmail.Text.Trim();
                objMR_AddressBook.paraCPName = txtCPName.Text.Trim();
                objMR_AddressBook.paraCPAddressLine1 = txtCPAddessLine1.Text.Trim();
                objMR_AddressBook.paraCPAddressLine2 = txtCPAddressLine2.Text.Trim();
                objMR_AddressBook.paraCPSTID = Convert.ToInt16(cmbCPState.SelectedValue);
                objMR_AddressBook.paraCPCTYID = pbCPCityid; 
                objMR_AddressBook.paraCPPincode = txtCPPincode.Text.Trim(); 
                objMR_AddressBook.paraCPPhoneNo = txtCPPhoneNo.Text.Trim(); 
                objMR_AddressBook.paraCPMobileNo1 = txtCPMobileNo1.Text.Trim(); 
                objMR_AddressBook.paraCPMobileNo2 = txtCPMobileNo2.Text.Trim(); 
                objMR_AddressBook.paraCPEmail = txtCPEmail.Text.Trim();
                objMR_AddressBook.paraBNKID = Convert.ToInt16(cmbBankName.SelectedValue);
                objMR_AddressBook.paraAccNo = txtAccno.Text.Trim();
                objMR_AddressBook.paraIFSC = txtIFScode.Text.Trim();
                objMR_AddressBook.paraBranchName = txtbranchname.Text.Trim();
                objMR_AddressBook.paraRemarks = txtRemarks.Text.Trim();
                objMR_AddressBook.paraSTID = 1;
                 
                objMR_AddressBook.paraOriginator = varoriginator;
                varResult = objspdservice.udfnAddressBook(objMR_AddressBook);
                objspdservice.CloseConnection();

                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_AddressBookList.udfnList();
                    if (btnSave.Text == "Save")
                    { 
                        this.ActiveControl = txtCompanyName;
                    }
                    if (btnSave.Text == "Update")
                    {
                        //varUpdate = 1;
                        udfnclose();
                    }
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
                }
                epCompany.Clear(); 
                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompanyName.Focus();
            }
        } 
        public void udfntextboxcolor()
        {
            try
            {
                txtCompanyName.BackColor = Color.White; 
                txtAddressLine1.BackColor = Color.White;
                txtAddressLine2.BackColor = Color.White;
                txtCompanyName.BackColor = Color.White;
                cmbState.BackColor = Color.White;
                txtCity.BackColor = Color.White;
                txtPincode.BackColor = Color.White;
                txtPhoneNo.BackColor = Color.White; 
                txtmobileNo.BackColor = Color.White;
                txtAlterMobileno.BackColor = Color.White; 
                txtEmail.BackColor = Color.White;  
                cmbBankName.BackColor = Color.White; 
                txtbranchname.BackColor = Color.White;
                txtAccno.BackColor = Color.White;
                txtIFScode.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClear()
        {
            try
            {
                txtCompanyName.Text = ""; 
                txtAddressLine1.Text = "";
                txtAddressLine2.Text = "";
                txtCompanyName.Text = "";
                cmbState.SelectedValue=-1;
                txtCity.Text = "";
                txtPincode.Text = "";
                txtPhoneNo.Text = ""; 
                txtmobileNo.Text = "";
                txtAlterMobileno.Text = ""; 
                txtEmail.Text = ""; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBankclear()
        { 
            cmbBankName.SelectedValue = -1; 
            txtbranchname.Text = "";
            txtAccno.Text = "";
            txtIFScode.Text = "";
            varSlNo = "0";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                udfntextboxcolor();
                epCompany.Clear();
                bool blnErrorFlag = false;
                if (Convert.ToString(txtCompanyName.Text).Trim() == "")
                {
                    epCompany.SetError(txtCompanyName, "Please enter company name");
                    txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCompanyName.ShowAlways = true;
                    tpCompanyName.Show("Please enter company name", txtCompanyName, 5000);
                    blnErrorFlag = true;
                } 
                if (Convert.ToString(txtPincode.Text)!="")
                {
                    if (Convert.ToString(txtPincode.Text).Length != 6)
                    {
                        epCompany.SetError(txtPincode, "Please enter valid pincode");
                        txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPincode.ShowAlways = true;
                        tpPincode.Show("Please enter valid pincode", txtPincode, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtEmail.Text) != "")
                {
                    if (objValidation.FormatEMail(txtEmail.Text) == false)
                    {
                        epCompany.SetError(txtEmail, "Please enter valid email");
                        txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpEmail.ShowAlways = true;
                        tpEmail.Show("Please enter valid email", txtEmail, 5000);
                        blnErrorFlag = true;
                    }
                } 
                if (Convert.ToString(txtmobileNo.Text) != "")
                {
                    if (Convert.ToString(txtmobileNo.Text).Length != 10)
                    {
                        epCompany.SetError(txtmobileNo, "Please enter valid mobile number");
                        txtmobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpMobileNo.ShowAlways = true;
                        tpMobileNo.Show("Please enter valid mobile number", txtmobileNo, 5000);
                        blnErrorFlag = true;
                    }
                } 
                if (Convert.ToString(txtAlterMobileno.Text) != "")
                {
                    if (Convert.ToString(txtAlterMobileno.Text).Length != 10)
                    {
                        epCompany.SetError(txtAlterMobileno,  "Please enter valid alter mobile no.");
                        txtAlterMobileno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPhoneNo.ShowAlways = true;
                        tpPhoneNo.Show("Please enter valid alter mobile no.", txtAlterMobileno, 5000);
                        blnErrorFlag = true;
                    }
                }      
                if (blnErrorFlag == false)
                {
                    udfnSave(sender, e);
                    udfnBankclear();
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
            finally
            {
                MainForm objMainForm = new MainForm();
                objMainForm.udfnGetDefaultCompany();
            }
        }
                    

        private void CP_Company_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>0 ORDER BY STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID"); 
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>0 ORDER BY STID", "ST_Name,STID", cmbCPState, "", "ST_Name", "STID"); 
                objDataBind = null;
                DataService objdservice = new DataService(); 
                varstatusid = objdservice.displaydata("select STS_Name as name from DEF_Status where STS_ModuleID=1 AND STSID=1"); 
                udfnBankDropDownLoad();
                udfnEdit();
                this.ActiveControl = txtCompanyName;
                objdservice.CloseConnection();
                DataSet objDS = new DataSet();
                SPDataService objDserv = new SPDataService();
                objDS = objDserv.udfnCompanyList(6,Convert.ToInt32(varcompanyid),MainForm.pbUserID,MainForm.pbIpAddress,0);
                 
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void txtAddressLine1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAddressLine1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddressLine1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddressLine2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddressLine1_Leave(object sender, EventArgs e)
        {
            try
            { 
                txtAddressLine1.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddressLine2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAddressLine2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAddressLine2_KeyDown(object sender, KeyEventArgs e)
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

        private void txtAddressLine2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAddressLine2.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbState_Enter(object sender, EventArgs e)
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

        private void cmbState_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbState_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                {
                    epCompany.SetError(cmbState, "Please select state");
                    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpState.ShowAlways = true;
                    tpState.Show("Please select state", cmbState, 5000);
                }
                else
                {
                    epCompany.Clear();
                    cmbState.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
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

            try
            {
                if (Convert.ToString(txtCity.Text).Trim() == "")
                {
                    epCompany.SetError(txtCity, "Please enter city");
                    txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCity.ShowAlways = true;
                    tpCity.Show("Please enter city", txtCity, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtCity.BackColor = Color.White;

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvCity_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGrdevent();
                txtPincode.Focus();
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
                lvCity.Visible = false;
                txtPincode.BackColor = Color.LemonChiffon;
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
                    txtPhoneNo.Focus();
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

        private void txtPincode_Leave(object sender, EventArgs e)
        {
            try
            { 
                if (Convert.ToString(txtPincode.Text).Trim() != "" && txtPincode.TextLength != 6)
                {
                    epCompany.SetError(txtPincode, "Please enter valid pincode");
                    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPincode.ShowAlways = true;
                    tpPincode.Show("Please enter valid pincode", txtPincode, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtPincode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPhoneNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPhoneNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtmobileNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPhoneNo_Leave(object sender, EventArgs e)
        {

            try
            { 
                txtPhoneNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtmobileNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtmobileNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtmobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAlterMobileno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtmobileNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtmobileNo_Leave(object sender, EventArgs e)
        {
            try
            { 
                if (Convert.ToString(txtmobileNo.Text).Trim() != "" && txtmobileNo.Text.Length != 10)
                {
                    epCompany.SetError(txtmobileNo, "Please enter valid mobile number");
                    txtmobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNo.ShowAlways = true;
                    tpMobileNo.Show("Please enter valid mobile number", txtmobileNo, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtmobileNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAlterMobileno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAlterMobileno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAlterMobileno_KeyDown(object sender, KeyEventArgs e)
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

        private void txtAlterMobileno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAlterMobileno_Leave(object sender, EventArgs e)
        {
            try
            { 
                if (Convert.ToString(txtAlterMobileno.Text).Trim() != "" && txtAlterMobileno.Text.Length != 10)
                {
                    txtAlterMobileno.BackColor = Color.White; 
                }
                else if (txtAlterMobileno.Text.Length != 10)
                {
                    epCompany.SetError(txtAlterMobileno, "Please enter valid alter mobile no.");
                    txtAlterMobileno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPhoneNo.ShowAlways = true;
                    tpPhoneNo.Show("Please enter valid alter mobile no.", txtAlterMobileno, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtAlterMobileno.BackColor = Color.White;
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
                    txtCPName.Focus();
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
                if (Convert.ToString(txtEmail.Text).Trim() != "" && objValidation.FormatEMail(txtEmail.Text) == false)
                {
                    epCompany.SetError(txtEmail, "Please enter valid email");
                    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEmail.ShowAlways = true;
                    tpEmail.Show("Please enter valid email", txtEmail, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtEmail.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCPName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCPAddessLine1.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtCPName.Text).Trim() == "")
                {
                    epCompany.SetError(txtCPName, "Please enter contact person name");
                    txtCPName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCPName.ShowAlways = true;
                    tpCPName.Show("Please enter contact person name", txtCPName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtCPName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPAddessLine1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCPAddessLine1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPAddessLine1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCPAddressLine2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPAddessLine1_Leave(object sender, EventArgs e)
        {
            try
            { 
                txtCPAddessLine1.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPAddressLine2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCPAddressLine2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPAddressLine2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCPState.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPAddressLine2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCPAddressLine2.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCPState_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbCPState.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCPState_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCPCity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbCPState_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbCPState_Leave(object sender, EventArgs e)
        {
            try
            { 
                cmbCPState.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPCity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCPCity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvCPCity.Items.Count == 0 || txtCPCity.Text == "")
                    {
                        txtCPCity.Focus();
                        lvCPCity.Visible = false;
                    }
                    else
                    {
                        lvCPCity.Focus();
                    }
                    if (lvCPCity.Items.Count > 0)
                    {
                        lvCPCity.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtCPPincode.Focus();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPCity_Leave(object sender, EventArgs e)
        { 
            try
            { 
                txtCPCity.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPCity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtCPCity.Text.Length > 2)
                {
                    objDs = objspdservice.udfnCitylist(1, txtCPCity.Text, Convert.ToInt32(cmbCPState.SelectedValue), 0);
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
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvCPCity.Items.Add(objList);
                                }
                                lvCPCity.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvCPCity.Visible = false;
                    lvCPCity.Items.Clear();
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

        private void txtCPPincode_Enter(object sender, EventArgs e)
        {
            try
            {
                lvCPCity.Visible = false;
                txtCPPincode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPPincode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCPPhoneNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPPincode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCPPincode_Leave(object sender, EventArgs e)
        {
            try
            { 
                if (Convert.ToString(txtCPPincode.Text).Trim() != "" && txtCPPincode.TextLength != 6)
                {
                    epCompany.SetError(txtCPPincode, "Please enter valid pincode");
                    txtCPPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCPPincode.ShowAlways = true;
                    tpCPPincode.Show("Please enter valid pincode", txtCPPincode, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtCPPincode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPPhoneNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCPPhoneNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCPMobileNo1.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCPPhoneNo_Leave(object sender, EventArgs e)
        {

            try
            { 
                txtCPPhoneNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPMobileNo1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCPMobileNo1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPMobileNo1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCPMobileNo2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPMobileNo1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCPMobileNo1_Leave(object sender, EventArgs e)
        {
            try
            { 
                if (Convert.ToString(txtCPMobileNo1.Text).Trim() != "" && txtCPMobileNo1.Text.Length != 10)
                {
                    epCompany.SetError(txtCPMobileNo1, "Please enter valid mobile number");
                    txtCPMobileNo1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcpMobileNo1.ShowAlways = true;
                    tpcpMobileNo1.Show("Please enter valid mobile number", txtCPMobileNo1, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtCPMobileNo1.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPMobileNo2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCPMobileNo2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPMobileNo2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCPEmail.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPMobileNo2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCPMobileNo2_Leave(object sender, EventArgs e)
        {
            try
            { 
                if (Convert.ToString(txtCPMobileNo2.Text).Trim() != "" && txtCPMobileNo2.Text.Length != 10)
                {
                    txtCPMobileNo2.BackColor = Color.White; 
                }
                else if (txtCPMobileNo2.Text.Length != 10)
                {
                    epCompany.SetError(txtCPMobileNo2, "Please enter valid alter mobile no.");
                    txtCPMobileNo2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcpmobileno2.ShowAlways = true;
                    tpcpmobileno2.Show("Please enter valid alter mobile no.", txtCPMobileNo2, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtCPMobileNo2.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPEmail_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCPEmail.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAccName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtCPEmail_Leave(object sender, EventArgs e)
        {
            try
            { 
                if (Convert.ToString(txtCPEmail.Text).Trim() != "" && objValidation.FormatEMail(txtCPEmail.Text) == false)
                {
                    epCompany.SetError(txtCPEmail, "Please enter valid email");
                    txtCPEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCPEmail.ShowAlways = true;
                    tpCPEmail.Show("Please enter valid email", txtCPEmail, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtCPEmail.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbBankName_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBankName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbBankName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAccno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbBankName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbBankName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbBankName.SelectedValue) == "" || Convert.ToString(cmbBankName.SelectedValue) == "-1")
                {
                    epCompany.SetError(cmbBankName, "Please select bank name.");
                    cmbBankName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankName.ShowAlways = true;
                    tpBankName.Show("Please select bank name.", cmbBankName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    cmbBankName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAccno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAccno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAccno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtIFScode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAccno_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // This will prevent the character from being entered in the TextBox
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAccno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtAccno.Text).Trim() == "")
                {
                    epCompany.SetError(txtAccno, "Please enter account number");
                    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAccountNo.ShowAlways = true;
                    tpAccountNo.Show("Please enter account number", txtAccno, 5000);
                } 
                else
                {
                    epCompany.Clear();
                    txtAccno.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtIFScode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIFScode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtIFScode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtbranchname.Focus();  
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtIFScode_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // This will prevent the character from being entered in the TextBox
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtIFScode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtIFScode.Text).Trim() == "")
                {
                    epCompany.SetError(txtIFScode, "Please enter IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter IFS Code", txtIFScode, 5000);
                }
                else if (txtIFScode.Text.Length != 11)
                {
                    epCompany.SetError(txtIFScode, "Please enter valid IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter valid IFS Code", txtIFScode, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtIFScode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbranchname_Enter(object sender, EventArgs e)
        {
            try
            {
                txtbranchname.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbranchname_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemarks.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtbranchname_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtbranchname.Text).Trim() == "")
                {
                    epCompany.SetError(txtbranchname, "Please enter branch name");
                    txtbranchname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBranchName.ShowAlways = true;
                    tpBranchName.Show("Please enter branch name", txtbranchname, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtbranchname.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRemarks_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRemarks.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRemarks.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
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

        private void rbInactive_Enter(object sender, EventArgs e)
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

        private void rbInactive_KeyDown(object sender, KeyEventArgs e)
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

        private void rbInactive_Leave(object sender, EventArgs e)
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
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSave(sender,e);
                }
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
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }

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

        private void txtAccName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAccName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAccName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBankName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtAccName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtAccName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void lvCity_KeyDown(object sender, KeyEventArgs e)
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
         

        private void txtCity_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtCity.Text.Length > 2)
                {
                    objDs = objspdservice.udfnCitylist(1, txtCity.Text, Convert.ToInt32(cmbState.SelectedValue), 0);
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
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
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
         

        public void udfnBankDropDownLoad()
        {
            try
            {
                objDTBank = null;
                SPDataService objDserv = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Bank objMR_Bank = new MR_Bank();
                objMR_Bank.paraViewType = 2;
                objDs = objDserv.udfnBanklist(objMR_Bank);
                objDserv.CloseConnection();
                cmbBankName.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbBankName.ValueMember = "BNKID";
                            cmbBankName.DisplayMember = "Bank";
                            cmbBankName.DataSource = objDs.Tables[0];
                            objDTBank = objDs;
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
                if (varcompanyid != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    MR_AddressBook objMR_AddressBook = new MR_AddressBook();
                    objMR_AddressBook.ViewType = 4;
                    objMR_AddressBook.paraABID = pbABID;
                    objDS = objspservice.udfnAddressBookList(objMR_AddressBook);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtCompanyName.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Company Name"]);
                            txtAddressLine1.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Company Address1"]);
                            txtAddressLine2.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Company Address2"]);
                            cmbState.SelectedValue = Convert.ToInt16(objDS.Tables[0].Rows[0]["AB_STID"]);
                            txtCity.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Company City"]);
                            pbCityID = Convert.ToInt16(objDS.Tables[0].Rows[0]["AB_CTYID"]);
                            txtPincode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Pincode"]);
                            txtPhoneNo.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Phone No"]);
                            txtmobileNo.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Company Mobile No1"]);
                            txtAlterMobileno.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Company Mobile No2"]);
                            txtEmail.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Company Email"]);
                            txtCPName.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Name"]);
                            txtCPAddessLine1.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Address1"]);
                            txtCPAddressLine2.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Address2"]);
                            cmbCPState.SelectedValue = Convert.ToInt16(objDS.Tables[0].Rows[0]["AB_CPSTID"]);
                            txtCPCity.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Contact City"]);
                            pbCPCityid = Convert.ToInt16(objDS.Tables[0].Rows[0]["AB_CPCTYID"]);
                            txtPincode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Pincode"]);
                            txtCPPincode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Contact Pincode"]);
                            txtCPPhoneNo.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Contact Phone No"]);
                            txtCPMobileNo1.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Mobile No1"]);
                            txtCPEmail.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Email"]);
                            txtAccName.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Account Name"]);
                            cmbBankName.SelectedValue = Convert.ToInt16(objDS.Tables[0].Rows[0]["AB_BNKID"]);
                            txtAccno.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Account Name"]);
                            txtIFScode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["IFSCode"]);
                            txtbranchname.Text = Convert.ToString(objDS.Tables[0].Rows[0]["Branch Name"]);
                        }
                    }
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
        private void TxtCity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvCity.Items.Clear();
                SPDataService objspdservice = new SPDataService(); 
                DataSet objDs = new DataSet();
                if (txtCity.Text.Length > 2)
                {
                    objDs = objspdservice.udfnCitylist(1, txtCity.Text,Convert.ToInt32(cmbState.SelectedValue),0);
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
                                  //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
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
         
         
        public void udfnGrdevent()
        {
            try
            {
                    if (txtCity.Text != "")
                    {
                    ListViewItem selectedItem = lvCity.SelectedItems[0];
                    txtCity.Text = selectedItem.SubItems[0].Text;  
                    lvCity.Visible = false;  
                    }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobilenumber_KeyPress(object sender, KeyPressEventArgs e)
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
        public AutoCompleteStringCollection AutoCompleteLoad()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();
             
            objds = objdservice.GetDataset("select STSID as id,STS_Name as Name from DEF_Status where STS_ModuleID=1 ");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("Name") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            } 
            return varstr;
        }
          
    }
}
