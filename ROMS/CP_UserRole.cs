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
    public partial class CP_UserRole : Form
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


        public int varDefaultBank = 0;
        public string varDefault = "";
        DataSet objDTBank = new DataSet();

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Enter(object sender, EventArgs e)
        {

        }

        private void BtnSave_Leave(object sender, EventArgs e)
        {

        }

        private void BtnClose_Enter(object sender, EventArgs e)
        {

        }

        private void BtnClose_Leave(object sender, EventArgs e)
        {

        }

        public CP_UserRole()
        {
            InitializeComponent();
        }


        private void txtUserRole_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUserRole.BackColor = Color.LemonChiffon;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtUserRole_Leave(object sender, EventArgs e)
        {
            try
            {
                txtUserRole.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtUserRole_KeyDown(object sender, KeyEventArgs e)
        {

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
                if (varCompanyModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objCP_Companylist.udfnList();
                    }
                    else
                    {
                        tbFirst.SelectedIndex = 0;
                    }
                }
                else if(varContactModifiedFlag==1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objCP_Companylist.Show();
                        MainForm.objCP_Companylist.udfnList();
                    }
                    else
                    {
                        tbFirst.SelectedIndex = 1;
                    }
                }
                else
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Grpform2_Leave(object sender, EventArgs e)
        {
            try
            {
                udfntooltiphide();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                // tpCompanyName.Active = false; 
            }
        }
         

        private void TcCompanyDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbFirst.SelectedIndex == 0)
                {
                     udfntooltiphide();  
                }
                else
                {
                    if (varCompanyModifiedFlag == 1)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        { 
                        }
                        else
                        {
                            tbFirst.SelectedIndex = 0;
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
    }
}
