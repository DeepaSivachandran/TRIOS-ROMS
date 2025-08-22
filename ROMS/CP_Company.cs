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
    public partial class CP_Company : Form
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
        public CP_Company()
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
                        tcCompanyDetails.SelectedIndex = 0;
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
                        tcCompanyDetails.SelectedIndex = 1;
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
                    if(tcCompanyDetails.SelectedIndex == 1)
                    {
                        btnSaveContact.Focus();
                        BtnSaveContact_Click(sender, e);
                    }
                    else
                    {
                        btnSave.Focus();
                        BtnSave_Click(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }   

        private void TxtBankShortName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBankShortName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBankShortName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtBankShortName.Text).Trim() == "")
                {
                    epCompany.SetError(txtBankShortName, "Please enter bank short name");
                    txtBankShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank short name", txtBankShortName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtBankShortName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBankShortName_KeyDown(object sender, KeyEventArgs e)
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

        private void Txtbranchname_Enter(object sender, EventArgs e)
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

        private void Txtbranchname_Leave(object sender, EventArgs e)
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

        private void Txtbranchname_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtAccno_Enter(object sender, EventArgs e)
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

        private void TxtAccno_Leave(object sender, EventArgs e)
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
                //else if (txtAccno.Text.Length != 20)
                //{
                //    epCompany.SetError(txtAccno, "Please enter valid account number");
                //    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpAccountNo.ShowAlways = true;
                //    tpAccountNo.Show("Please enter valid account number", txtAccno, 5000);
                //}
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

        private void TxtAccno_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtIFScode_Enter(object sender, EventArgs e)
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

        private void TxtIFScode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(pnlBStatus.Enabled==true)
                    {
                        if(rbBankActive.Checked==true)
                        {
                            rbBankActive.Focus();
                        }
                        else
                        {
                            rbBankInActive.Focus();
                        }
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtIFScode_Leave(object sender, EventArgs e)
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                int varflag = 0;
                varDefault = "";
                if (Convert.ToString(cmbBankName.SelectedValue)== "-1" || Convert.ToString(cmbBankName.SelectedValue) == "0" )
                {
                    epCompany.SetError(cmbBankName, "Please select bank name");
                    cmbBankName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankName.ShowAlways = true;
                    tpBankName.Show("Please select bank name", cmbBankName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtBankShortName.Text).Trim() == "")
                {
                    epCompany.SetError(txtBankShortName, "Please enter bank short name");
                    txtBankShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBankShortName.ShowAlways = true;
                    tpBankShortName.Show("Please enter bank short name", txtBankShortName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtbranchname.Text).Trim() == "")
                {
                    epCompany.SetError(txtbranchname, "Please enter branch name");
                    txtbranchname.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBranchName.ShowAlways = true;
                    tpBranchName.Show("Please enter branch name", txtbranchname, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtAccno.Text).Trim() == "")
                {
                    epCompany.SetError(txtAccno, "Please enter account number");
                    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAccountNo.ShowAlways = true;
                    tpAccountNo.Show("Please enter account number", txtAccno, 5000);
                    blnErrorFlag = true;
                }
                //else if (txtAccno.Text.Length != 20)
                //{
                //    epCompany.SetError(txtAccno, "Please enter valid account number");
                //    txtAccno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpAccountNo.ShowAlways = true;
                //    tpAccountNo.Show("Please enter valid account number", txtAccno, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(txtIFScode.Text).Trim() == "")
                {
                    epCompany.SetError(txtIFScode, "Please enter IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter IFS Code", txtIFScode, 5000);
                    blnErrorFlag = true;
                }
                else if (txtIFScode.Text.Length != 11)
                {
                    epCompany.SetError(txtIFScode, "Please enter valid IFS Code");
                    txtIFScode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpIfsCode.ShowAlways = true;
                    tpIfsCode.Show("Please enter valid IFS Code", txtIFScode, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    pnlBStatus.Enabled = false;
                    //if (varSlNo != "0") { varflag = 0; }
                    //else
                    //{ 
                        foreach (DataGridViewRow row in grdBankDetails.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                            {
                                string gridValue1 = row.Cells[1].Value.ToString();
                                string gridValue2 = row.Cells[3].Value.ToString();//varSlNo
                                string varUpdateSlNo = row.Cells["clmsno"].Value.ToString();
                                string varUpdateAccNo = row.Cells["clmaccno"].Value.ToString();
                                if (varSlNo != varUpdateSlNo && varUpdateAccNo.Trim() == txtAccno.Text.Trim() && gridValue1.ToUpper() == (cmbBankName.Text).Trim().ToUpper() && gridValue2.ToUpper() == (txtbranchname.Text).Trim().ToUpper())
                                {
                                    varflag = 1;
                                }
                                if (varSlNo != varUpdateSlNo && varUpdateAccNo.Trim() == txtAccno.Text.Trim())
                                {
                                    varflag = 1;
                                }
                            }   
                        }
                    //}
                    if (varflag == 0)
                    {
                        if (rbBankActive.Checked == true)
                        {
                            varstatusid = "Active";
                        }
                        else
                        {
                            varstatusid = "Inactive";
                        }
                        if(chkDefaultBank.Checked==true)
                        {
                            varDefaultBank = 1;
                            varDefault = "Yes";
                        }
                        else
                        {
                            varDefaultBank = 0;
                            varDefault = "No";
                        }
                        if (varSlNo == "0")
                        {
                            grdBankDetails.Rows.Add(grdBankDetails.Rows.Count + 1,Convert.ToString(cmbBankName.Text).Trim(), (txtBankShortName.Text).Trim().ToUpper(), (txtbranchname.Text).Trim(), (txtAccno.Text).Trim(), (txtIFScode.Text).Trim(),varstatusid,0, varDefaultBank, varDefault,0, cmbBankName.SelectedValue);
                            grdBankDetails.Columns["clmStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            varCompanyModifiedFlag = 1;
                        }
                        else
                        { 
                            for (int i = 0; i < grdBankDetails.RowCount; i++) {
                                if (Convert.ToString(grdBankDetails.Rows[i].Cells["clmsno"].Value) == varSlNo){
                                  //  grdBankDetails.Rows[i].Cells["clmbankname"].Value = txtBankname.Text;
                                    grdBankDetails.Rows[i].Cells["clmBankShortName"].Value = txtBankShortName.Text.ToUpper();
                                    grdBankDetails.Rows[i].Cells["clmbranch"].Value = txtbranchname.Text;
                                    grdBankDetails.Rows[i].Cells["clmaccno"].Value = txtAccno.Text;
                                    grdBankDetails.Rows[i].Cells["clmifscode"].Value = txtIFScode.Text;
                                    grdBankDetails.Rows[i].Cells["clmStatus"].Value = varstatusid;
                                    grdBankDetails.Rows[i].Cells["clmdefaultbnk"].Value = varDefaultBank;
                                    grdBankDetails.Rows[i].Cells["clmDefault"].Value = varDefault;
                                    grdBankDetails.Rows[i].Cells["clmBNKID"].Value = cmbBankName.SelectedValue;
                                    varCompanyModifiedFlag = 1;
                                }
                            }
                        }
                        for(int i=0;i<grdBankDetails.Rows.Count;i++)
                        {
                            if(Convert.ToInt32(grdBankDetails.Rows[i].Cells["clmdefaultbnk"].Value)==1)
                            {
                                chkDefaultBank.Enabled = false;
                                chkDefaultBank.Checked = false;
                                break;
                            }
                            else
                            {
                                chkDefaultBank.Enabled = true;

                            }
                        }
                        udfnBankclear();
                        rbBankActive.Checked = true;
                        cmbBankName.Focus();
                        grdBankDetails.ClearSelection();
                        btnAdd.Image = ROMS.Properties.Resources.plus;
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(45);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                     
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
                    txtShortName.Focus();
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

        private void TxtShortName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epCompany.SetError(txtShortName, "Please enter short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpShortName.ShowAlways = true;
                    tpShortName.Show("Please enter short name", txtShortName, 5000);
                }
                else
                {
                    epCompany.Clear();
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
                    txtAddressLine1.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAddressLine1_Enter(object sender, EventArgs e)
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

        private void TxtAddressLine1_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtAddressLine1.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtAddressLine1, "Please enter address");
                //    txtAddressLine1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpAddressLine1.ShowAlways = true;
                //    tpAddressLine1.Show("Please enter address", txtAddressLine1, 5000);
                //}
                //else
                //{
                //    epCompany.Clear();
                    txtAddressLine1.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAddressLine1_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtAddressLine2_Enter(object sender, EventArgs e)
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

        private void TxtAddressLine2_Leave(object sender, EventArgs e)
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

        private void TxtAddressLine2_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbState_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                //{
                //    epCompany.SetError(cmbState, "Please select state");
                //    cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpState.ShowAlways = true;
                //    tpState.Show("Please select state", cmbState, 5000);
                //}
                //else
                //{
                //    epCompany.Clear();
                    cmbState.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbState_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtCity_Enter(object sender, EventArgs e)
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

        private void TxtCity_Leave(object sender, EventArgs e)
        {

            try
            {
                //if (Convert.ToString(txtCity.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtCity, "Please enter city");
                //    txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpCity.ShowAlways = true;
                //    tpCity.Show("Please enter city", txtCity, 5000);
                //}
                //else
                //{
                //    epCompany.Clear();
                    txtCity.BackColor = Color.White;
                         
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCity_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtPhoneNo_Enter(object sender, EventArgs e)
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

        private void TxtPhoneNo_Leave(object sender, EventArgs e)
        {

            try
            {
                //if (Convert.ToString(txtPhoneNo.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtPhoneNo, "Please enter phone number");
                //    txtPhoneNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPhoneNo.ShowAlways = true;
                //    tpPhoneNo.Show("Please enter phone number", txtPhoneNo, 5000);
                //}
                //if (Convert.ToString(txtPhoneNo.Text).Trim() != "" && txtPhoneNo.TextLength != 10)
                //{
                //    epCompany.SetError(txtPhoneNo, "Please enter valid phone number");
                //    txtPhoneNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPhoneNo.ShowAlways = true;
                //    tpPhoneNo.Show("Please enter valid phone number", txtPhoneNo, 5000);
                //} 
                //else
                //{
                //    epCompany.Clear();
                //    txtPhoneNo.BackColor = Color.White;
                //}
                txtPhoneNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAlterPhoneno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterPhoneno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtAlterPhoneno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterPhoneno_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtAlterPhoneno.Text =="" )
                //{
                //    epCompany.SetError(txtAlterPhoneno, "please enter alter Phone no.");
                //    txtAlterPhoneno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPhoneNo.ShowAlways = true;
                //    tpPhoneNo.Show("please enter  alter mobile no.", txtAlterPhoneno, 5000);
                //}
                if (Convert.ToString(txtAlterPhoneno.Text).Trim() != "" )
                {
                    txtAlterPhoneno.BackColor = Color.White;
                    //epCompany.SetError(txtAlterPhoneno, "Please enter alter Phone no.");
                    //txtAlterPhoneno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //tpPhoneNo.ShowAlways = true;
                    //tpPhoneNo.Show("Please enter  alter mobile no.", txtAlterPhoneno, 5000);
                }
                //else if (txtAlterPhoneno.Text.Length != 10)
                //{
                //    epCompany.SetError(txtAlterPhoneno, "Please enter valid alter Phone no.");
                //    txtAlterPhoneno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPhoneNo.ShowAlways = true;
                //    tpPhoneNo.Show("Please enter valid alter mobile no.", txtAlterPhoneno, 5000);
                //}
                else
                {
                    epCompany.Clear();
                    txtAlterPhoneno.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAlterPhoneno_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtmobileNo_Enter(object sender, EventArgs e)
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

        private void TxtmobileNo_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtmobileNo.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtmobileNo, "Please enter mobile number");
                //    txtmobileNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpMobileNo.ShowAlways = true;
                //    tpMobileNo.Show("Please enter mobile number", txtmobileNo, 5000);
                //}

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

        private void TxtmobileNo_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtPincode_Enter(object sender, EventArgs e)
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

        private void TxtPincode_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtPincode.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtPincode, "Please enter pincode");
                //    txtPincode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPincode.ShowAlways = true;
                //    tpPincode.Show("Please enter pincode", txtPincode, 5000);
                //}
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

        private void TxtPincode_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtAlterMobileno_Enter(object sender, EventArgs e)
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

        private void TxtAlterMobileno_Leave(object sender, EventArgs e)
        {
            try
            {

                //if (txtAlterMobileno.Text != "")
                //{
                //    epCompany.SetError(txtAlterMobileno, "please enter alter mobile no.");
                //    txtAlterMobileno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPhoneNo.ShowAlways = true;
                //    tpPhoneNo.Show("please enter alter mobile no.", txtAlterMobileno, 5000);
                //}
                if (Convert.ToString(txtAlterMobileno.Text).Trim() != "" && txtAlterMobileno.Text.Length != 10)
                {
                    txtAlterMobileno.BackColor = Color.White;
                    //epCompany.SetError(txtAlterMobileno, "Please enter alter mobile no.");
                    //txtAlterMobileno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //tpPhoneNo.ShowAlways = true;
                    //tpPhoneNo.Show("Please enter alter mobile no.", txtAlterMobileno, 5000);
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

        private void TxtAlterMobileno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtwhatsappNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtwhatsappNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtwhatsappNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtwhatsappNo_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtwhatsappNo.Text).Trim() == "" )
                //{
                //    epCompany.SetError(txtwhatsappNo, "Please enter whatsapp number");
                //    txtwhatsappNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpWhatsAppNo.ShowAlways = true;
                //    tpWhatsAppNo.Show("Please enter whatsapp number", txtwhatsappNo, 5000);
                //}
                if (Convert.ToString(txtwhatsappNo.Text).Trim() != "" && txtwhatsappNo.TextLength != 10)
                {
                    epCompany.SetError(txtwhatsappNo, "Please enter valid whatsapp number");
                    txtwhatsappNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpWhatsAppNo.ShowAlways = true;
                    tpWhatsAppNo.Show("Please enter valid whatsapp number", txtwhatsappNo, 5000);
                } 
                else
                {
                    epCompany.Clear();
                    txtwhatsappNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtwhatsappNo_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtEmail_Enter(object sender, EventArgs e)
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

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtEmail.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtEmail, "Please enter email");
                //    txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpEmail.ShowAlways = true;
                //    tpEmail.Show("Please enter email", txtEmail, 5000);
                //}
                if (Convert.ToString(txtEmail.Text).Trim() != "" &&  objValidation.FormatEMail(txtEmail.Text) == false)
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

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtwebsite.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtwebsite_Enter(object sender, EventArgs e)
        {
            try
            {
                txtwebsite.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtwebsite_Leave(object sender, EventArgs e)
        {
            try
            { 
                //if (Convert.ToString(txtwebsite.Text).Trim() == "" )
                //{
                //    epCompany.SetError(txtwebsite, "Please enter website");
                //    txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpWebsite.ShowAlways = true;
                //    tpWebsite.Show("Please enter website", txtwebsite, 5000);
                //}
                //if (Convert.ToString(txtwebsite.Text).Trim() != "" //&& !objValidation.IsValidUrl(txtwebsite.Text)
                //    )
                //{
                //    epCompany.SetError(txtwebsite, "Please enter valid website");
                //    txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpWebsite.ShowAlways = true;
                //    tpWebsite.Show("Please enter valid website", txtwebsite, 5000);
                //}
                //else
                //{
                    epCompany.Clear();
                    txtwebsite.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtwebsite_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGSTTIN.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGSTTIN_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGSTTIN.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGSTTIN_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtGSTTIN.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtGSTTIN, "Please enter GSTTIN");
                //    txtGSTTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpGstin.ShowAlways = true;
                //    tpGstin.Show("Please enter GSTTIN", txtGSTTIN, 5000);
                //}
                if (Convert.ToString(txtGSTTIN.Text).Trim() != "" &&  txtGSTTIN.Text.Length != 15)
                {
                    epCompany.SetError(txtGSTTIN, "Please enter valid GSTTIN");
                    txtGSTTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGstin.ShowAlways = true;
                    tpGstin.Show("Please enter valid GSTTIN", txtGSTTIN, 5000);
                } 
                else
                {
                    epCompany.Clear();
                    txtGSTTIN.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGSTTIN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPan.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPan_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPan.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPan_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtPan.Text).Trim() == "" )
                //{
                //    epCompany.SetError(txtPan, "Please enter PAN");
                //    txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPan.ShowAlways = true;
                //    tpPan.Show("Please enter PAN", txtPan, 5000);
                //}
                if (Convert.ToString(txtPan.Text).Trim() != "" &&  txtPan.Text.Length != 10)
                {
                    epCompany.SetError(txtPan, "Please enter valid PAN");
                    txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPan.ShowAlways = true;
                    tpPan.Show("Please enter valid PAN", txtPan, 5000);
                } 
                else
                {
                    epCompany.Clear();
                    txtPan.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtESI.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtESI_Enter(object sender, EventArgs e)
        {
            try
            {
                txtESI.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtESI_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtESI.Text).Trim() == "" )
                //{
                //    epCompany.SetError(txtESI, "Please enter ESI");
                //    txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpEsi.ShowAlways = true;
                //    tpEsi.Show("Please enter ESI", txtESI, 5000);
                //}
                if (Convert.ToString(txtESI.Text).Trim() != "" && txtESI.Text.Length != 17)
                {
                    epCompany.SetError(txtESI, "Please enter valid ESI");
                    txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsi.ShowAlways = true;
                    tpEsi.Show("Please enter valid ESI", txtESI, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtESI.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtESI_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEPF.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEPF_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEPF.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEPF_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtEPF.Text).Trim() == "" )
                //{
                //    epCompany.SetError(txtEPF, "Please enter EPF");
                //    txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpEsf.ShowAlways = true;
                //    tpEsf.Show("Please enter EPF", txtEPF, 5000);
                //}
                if (Convert.ToString(txtEPF.Text).Trim() != "" && txtEPF.Text.Length != 12)
                {
                    epCompany.SetError(txtEPF, "Please enter valid EPF");
                    txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpEsf.ShowAlways = true;
                    tpEsf.Show("Please enter valid EPF", txtEPF, 5000);
                }
                
                else
                {
                    epCompany.Clear();
                    txtEPF.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtEPF_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtFSSAI.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtFSSAI_Enter(object sender, EventArgs e)
        {
            try
            {
                txtFSSAI.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtFSSAI_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtFSSAI.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtFSSAI, "Please enter FSSAI");
                //    txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpFssai.ShowAlways = true;
                //    tpFssai.Show("Please enter FSSAI", txtFSSAI, 5000);
                //}
                if (Convert.ToString(txtFSSAI.Text).Trim() != "" && txtFSSAI.Text.Length != 14)
                {
                    epCompany.SetError(txtFSSAI, "Please enter valid FSSAI");
                    txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpFssai.ShowAlways = true;
                    tpFssai.Show("Please enter valid FSSAI", txtFSSAI, 5000);
                } 
                else
                {
                    epCompany.Clear();
                    txtFSSAI.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtFSSAI_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPlno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPlno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPlno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPlno_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtPlno_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtPlno.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtPlno, "Please enter PL number");
                //    txtPlno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPlNo.ShowAlways = true;
                //    tpPlNo.Show("Please enter PL number", txtPlno, 5000);
                //}
                //else
                //{
                    //epCompany.Clear();
                    txtPlno.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        private void BtnClose_Click(object sender, EventArgs e)
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

        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    chkDefaultConcern.Focus();
                }
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

        private void RbInActive_Enter(object sender, EventArgs e)
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

        private void RbInActive_Leave(object sender, EventArgs e)
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

        private void BtnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnClose.Focus();
                }
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

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
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
        public void udfnSave(object sender, EventArgs e)

        {
            try
            {
                btnSave.Enabled = true;
                SPDataService objspdservice = new SPDataService();
                string result = "";
                string varStatus = "1";
                epCompany.Clear();
                if (Convert.ToString(txtShortName.Text).Trim() != "" && Convert.ToString(txtCompanyName.Text).Trim() != "")
                {
                    if (rbActive.Checked == true)
                    {
                        varStatus = "1";
                    }
                    else
                    {
                        varStatus = "2";

                    }                     
                    DataTable objBankTable = new DataTable();
                    DataTable objContactTable = new DataTable();
                    objContactTable.TableName = "MR_Company_Contact";
                    objContactTable.Columns.Add("CMCON_TransactionType", typeof(int));
                    objContactTable.Columns.Add("CMCON_Name", typeof(string));
                    objContactTable.Columns.Add("CMCON_MobileNo", typeof(string));
                    objContactTable.Columns.Add("CMCON_Operator", typeof(string));
                    objContactTable.Columns.Add("CMCON_MobileBrand", typeof(string));
                    objContactTable.Columns.Add("CMCON_Primary", typeof(int));
                    objContactTable.Columns.Add("CMCON_WhatsAppEnabled", typeof(int));
                    objContactTable.Columns.Add("CMCON_StaffName", typeof(string));
                    objContactTable.Columns.Add("CMCON_STSID", typeof(int));

                    int cityid = 0;string varpincode="";
                    if (lblcityid.Text=="")
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

                    objBankTable = udfnBankSave();
                    int companyupdate = 0;
                    if (Convert.ToInt32(varcontactcompanyid) != 0)
                    {
                        companyupdate = Convert.ToInt32(varcontactcompanyid);
                    }
                    else
                    {
                        companyupdate = Convert.ToInt32(varcompanyid);
                    }
                    int varviewtype = 0,varcompanycode=0;
                    string varorginator = "";
                    if (btnSave.Text == "Save")
                    {
                         varviewtype = 0;
                         varorginator = "Company Create";
                        varcompanycode = 0;
                        
                    }
                    else
                    {
                        varviewtype = 1;
                        varorginator = "Company Update";
                        varcompanycode = Convert.ToInt32(companyupdate);  
                    }
                    if (File.Exists(varNewfile))
                    {
                        File.Delete(varNewfile);
                    }
                    if (varflag == 1 && varNewfile != "")
                    {
                        //*********** copy file name & file path **************
                        File.Copy(objfilelogo.FileName, varNewfile, true);
                    }
                    //else
                    //{
                    //    //************ Remove Image from Folder *******
                    //    lblCompanyLogoPath.Text = "";
                    //    lblCompanyLogoFilename.Text = "";
                    //}
                    int varDefaultconcern = 0;
                    if (chkDefaultConcern.Checked==true)
                    {
                        varDefaultconcern = 1;
                    }
                    else
                    {
                        varDefaultconcern = 0;
                    } 
                    result = objspdservice.udfnCompanyMaster(varviewtype, varcompanycode, Convert.ToString(txtCompanyName.Text).Trim(), Convert.ToString(txtShortName.Text).Trim(), txtAddressLine1.Text, txtAddressLine2.Text, cityid
                    , varpincode, txtPhoneNo.Text, txtAlterPhoneno.Text, txtwhatsappNo.Text, txtmobileNo.Text, txtAlterMobileno.Text, txtEmail.Text, txtwebsite.Text
                    , txtGSTTIN.Text, txtPan.Text, txtESI.Text, txtEPF.Text, txtFSSAI.Text, txtPlno.Text, Convert.ToString(cmbState.SelectedValue), varStatus,
                    MainForm.pbUserID, MainForm.pbIpAddress, varorginator, objBankTable, objContactTable, lblCompanyLogoFilename.Text, varDefaultconcern);
                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        varCompanyModifiedFlag = 0;
                        this.ActiveControl = tcCompanyDetails; 
                        MainForm.objCP_Companylist.udfnList();
                        txtCompanyName.Focus();
                        pnlBStatus.Enabled = false;
                        rbBankActive.Checked = true;
                        varupdate = "1";
                        MainForm.objCP_Companylist.udfnList();
                        udfnClear();
                        udfnclose();
                        //if (btnSave.Text == "Update")
                        //{
                        //    if (tcCompanyDetails.SelectedIndex == 1)
                        //    {
                        //        varupdate = "1";
                        //        udfnClear();
                        //        udfnclose();
                        //    }
                        //    else
                        //    {
                        //        tcCompanyDetails.SelectedIndex = 1;
                        //    }
                        //}
                        //else
                        //{ 
                        //    varcontactcompanyid = varvalue[2];
                        //    tcCompanyDetails.SelectedIndex = 1;
                        //}
                        //if (tcCompanyDetails.SelectedIndex == 1)
                        //{ 
                        //    btnSaveContact.Text = "Update";
                        //    btnSave.Text = "Update";
                        //}
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (Convert.ToString(txtCompanyName.Text).Trim() == "")
                    {
                        epCompany.SetError(txtCompanyName, "Please enter company name");
                        txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCompanyName.ShowAlways = true;
                        tpCompanyName.Show("Please enter company name", txtCompanyName, 5000);
                        
                    }

                    if (Convert.ToString(txtShortName.Text).Trim() == "")
                    {
                        epCompany.SetError(txtShortName, "Please enter short name");
                        txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpShortName.ShowAlways = true;
                        tpShortName.Show("Please enter short name", txtShortName, 5000);
                        
                    }
                }
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
        public DataTable udfnBankSave()
        {

            DataTable objBankTable = new DataTable();
            try
            { 
                objBankTable.TableName = "MR_Bank";
                objBankTable.Columns.Add("CMBNK_BNKID", typeof(int)); 
                objBankTable.Columns.Add("CMBNK_BranchName", typeof(string));
                objBankTable.Columns.Add("CMBNK_AccNo", typeof(string));
                objBankTable.Columns.Add("CMBNK_IFSC", typeof(string));
                objBankTable.Columns.Add("CMBNK_STSID", typeof(string));
                objBankTable.Columns.Add("CMBNK_Default", typeof(string));
                objBankTable.Columns.Add("CMBNK_ID", typeof(string));
                for (int i = 0; i < grdBankDetails.Rows.Count; i++)
                {
                    DataService objDser = new DataService();
                    string varvalue = "";
                    if(rbBankActive.Checked==true)
                    {
                        varstatusid = "1";
                    }
                    else
                    {
                        varstatusid = "2";
                    }
                    varvalue = objDser.displaydata("SELECT STS_Name FROM  DEF_Status where STS_ModuleID = '" + varstatusid + "'");
                    string varStatus = "1";
                    if (Convert.ToString(grdBankDetails.Rows[i].Cells["clmStatus"].Value) == varvalue)
                    {
                        varStatus = "1";
                    }
                    else
                    {
                        varStatus = "2";
                    }
                    objBankTable.Rows.Add(Convert.ToInt16(grdBankDetails.Rows[i].Cells["clmBNKID"].Value), 
                    Convert.ToString(grdBankDetails.Rows[i].Cells["clmbranch"].Value), Convert.ToString(grdBankDetails.Rows[i].Cells["clmaccno"].Value),
                    Convert.ToString(grdBankDetails.Rows[i].Cells["clmifscode"].Value), varStatus,Convert.ToString(grdBankDetails.Rows[i].Cells["clmdefaultbnk"].Value), Convert.ToString(grdBankDetails.Rows[i].Cells["clmBankID"].Value)); 
                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return objBankTable;
        }
        public void udfntextboxcolor()
        {
            try
            {
                txtCompanyName.BackColor = Color.White;
                txtShortName.BackColor = Color.White;
                txtAddressLine1.BackColor = Color.White;
                txtAddressLine2.BackColor = Color.White;
                txtCompanyName.BackColor = Color.White;
                cmbState.BackColor = Color.White;
                txtCity.BackColor = Color.White;
                txtPincode.BackColor = Color.White;
                txtPhoneNo.BackColor = Color.White;
                txtAlterPhoneno.BackColor = Color.White;
                txtmobileNo.BackColor = Color.White;
                txtAlterMobileno.BackColor = Color.White;
                txtwhatsappNo.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                txtwebsite.BackColor = Color.White;
                txtGSTTIN.BackColor = Color.White;
                txtPan.BackColor = Color.White;
                txtFSSAI.BackColor = Color.White;
                txtESI.BackColor = Color.White;
                txtEPF.BackColor = Color.White;
                txtPlno.BackColor = Color.White;
                cmbBankName.BackColor = Color.White;
                txtBankShortName.BackColor = Color.White;
                txtbranchname.BackColor = Color.White;
                txtAccno.BackColor = Color.White;
                txtIFScode.BackColor = Color.White;

                txtName.BackColor = Color.White;
                txtOperator.BackColor = Color.White;
                cmbTransactionType .BackColor = Color.White;
                txtMobileBrand.BackColor = Color.White;
                txtMobilenumber.BackColor = Color.White;
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
                txtShortName.Text = "";
                txtAddressLine1.Text = "";
                txtAddressLine2.Text = "";
                txtCompanyName.Text = "";
                cmbState.SelectedValue=-1;
                txtCity.Text = "";
                txtPincode.Text = "";
                txtPhoneNo.Text = "";
                txtAlterPhoneno.Text = "";
                txtmobileNo.Text = "";
                txtAlterMobileno.Text = "";
                txtwhatsappNo.Text = "";
                txtEmail.Text = "";
                txtwebsite.Text = "";
                txtGSTTIN.Text = "";
                txtPan.Text = "";
                txtFSSAI.Text = "";
                txtESI.Text = "";
                txtEPF.Text = "";
                txtPlno.Text = "";
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
            txtBankShortName.Text = "";
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
                if (Convert.ToString(txtShortName.Text).Trim() == "")
                {
                    epCompany.SetError(txtShortName, "Please enter short name");
                    txtShortName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpShortName.ShowAlways = true;
                    tpShortName.Show("Please enter short name", txtShortName, 5000);
                    blnErrorFlag = true;
                }
                // if (Convert.ToString(txtAddressLine1.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtAddressLine1, "Please enter address");
                //     txtAddressLine1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpAddressLine1.ShowAlways = true;
                //     tpAddressLine1.Show("Please enter address", txtAddressLine1, 5000);
                //   //  blnErrorFlag = true;
                // }
                // if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                // {
                //     epCompany.SetError(cmbState, "Please select state");
                //     cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpState.ShowAlways = true;
                //     tpState.Show("Please select state", cmbState, 5000);
                //    // blnErrorFlag = true;
                // }
                // if (Convert.ToString(txtCity.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtCity, "Please enter city");
                //     txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpCity.ShowAlways = true;
                //     tpCity.Show("Please enter city", txtCity, 5000);
                // //    blnErrorFlag = true;
                // }
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
                //if (Convert.ToString(txtwebsite.Text) != "")
                //{
                //    if (!objValidation.IsValidUrl(txtwebsite.Text))
                //    {
                //        epCompany.SetError(txtwebsite, "Please enter valid website");
                //        txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpWebsite.ShowAlways = true;
                //        tpWebsite.Show("Please enter valid website", txtwebsite, 5000);
                //        blnErrorFlag = true;
                //    }
                //}
                //if (Convert.ToString(txtPhoneNo.Text) != "")
                //    {
                //        if (Convert.ToString(txtPhoneNo.Text).Length != 10)
                //        {
                //            epCompany.SetError(txtPhoneNo, "Please enter valid phone number");
                //            txtPhoneNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //            tpPhoneNo.ShowAlways = true;
                //            tpPhoneNo.Show("Please enter valid phone number", txtPhoneNo, 5000);
                //            blnErrorFlag = true;
                //        }
                //    }
                
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
                if (Convert.ToString(txtwhatsappNo.Text) != "")
                {
                    if (Convert.ToString(txtwhatsappNo.Text).Length != 10)
                    {
                        epCompany.SetError(txtwhatsappNo, "Please enter valid whatsapp number");
                        txtwhatsappNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpWhatsAppNo.ShowAlways = true;
                        tpWhatsAppNo.Show("Please enter valid whatsapp number", txtwhatsappNo, 5000);
                        blnErrorFlag = true;
                    }
                }
                //if (Convert.ToString(txtAlterPhoneno.Text) != "")
                //{
                //    if (Convert.ToString(txtAlterPhoneno.Text).Length != 10)
                //    {
                //        epCompany.SetError(txtAlterPhoneno, "Please enter valid alter Phone no.");
                //        txtAlterPhoneno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpPhoneNo.ShowAlways = true;
                //        tpPhoneNo.Show("Please enter valid alter mobile no.", txtAlterPhoneno, 5000);
                //        blnErrorFlag = true;
                //    }
                //}

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




                // if (Convert.ToString(txtEmail.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtEmail, "Please enter email"); 
                //     txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpEmail.ShowAlways = true;
                //     tpEmail.Show("Please enter email", txtEmail, 5000);
                ////     blnErrorFlag = true;
                // }
                // if (Convert.ToString(txtwebsite.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtwebsite, "Please enter website");
                //     txtwebsite.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpWebsite.ShowAlways = true;
                //     tpWebsite.Show("Please enter website", txtwebsite, 5000);
                //   //  blnErrorFlag = true;
                // }
                // if (Convert.ToString(txtGSTTIN.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtGSTTIN, "Please enter GSTTIN");
                //     txtGSTTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpGstin.ShowAlways = true;
                //     tpGstin.Show("Please enter GSTTIN", txtGSTTIN, 5000);
                // //    blnErrorFlag = true;
                // }
                // if (Convert.ToString(txtPan.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtPan, "Please enter PAN");
                //     txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpPan.ShowAlways = true;
                //     tpPan.Show("Please enter PAN", txtPan, 5000);
                // //    blnErrorFlag = true;
                // }
                // if (Convert.ToString(txtESI.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtESI, "Please enter ESI");
                //     txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpEsi.ShowAlways = true;
                //     tpEsi.Show("Please enter ESI", txtESI, 5000);
                //  //   blnErrorFlag = true;
                // }
                // if (Convert.ToString(txtEPF.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtEPF, "Please enter ESF");
                //     txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpEsf.ShowAlways = true;
                //     tpEsf.Show("Please enter ESF", txtEPF, 5000);
                // //    blnErrorFlag = true;
                // }
                // if (Convert.ToString(txtFSSAI.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtFSSAI, "Please enter FSSAI");
                //     txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpFssai.ShowAlways = true;
                //     tpFssai.Show("Please enter FSSAI", txtFSSAI, 5000);
                // //    blnErrorFlag = true;
                // }
                // if (Convert.ToString(txtPlno.Text).Trim() == "")
                // {
                //     epCompany.SetError(txtPlno, "Please enter PL number");
                //     txtPlno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //     tpPlNo.ShowAlways = true;
                //     tpPlNo.Show("Please enter PL number", txtPlno, 5000);
                // //    blnErrorFlag = true;
                // }
                if (Convert.ToString(txtFSSAI.Text) != "")
                {
                    if (txtFSSAI.Text.Length != 14)
                    {
                        epCompany.SetError(txtFSSAI, "Please enter valid FSSAI");
                        txtFSSAI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpFssai.ShowAlways = true;
                        tpFssai.Show("Please enter valid FSSAI", txtFSSAI, 5000);
                        blnErrorFlag = true;
                    }
                }

                if (Convert.ToString(txtEPF.Text) != "")
                {
                    if (txtEPF.Text.Length != 12)
                    {
                        epCompany.SetError(txtEPF, "Please enter valid EPF");
                        txtEPF.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpEsf.ShowAlways = true;
                        tpEsf.Show("Please enter valid EPF", txtEPF, 5000);
                        blnErrorFlag = true;
                    }
                }

                if (Convert.ToString(txtESI.Text) != "")
                {
                    if (txtESI.Text.Length != 17)
                    {
                        epCompany.SetError(txtESI, "Please enter valid ESI");
                        txtESI.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpEsi.ShowAlways = true;
                        tpEsi.Show("Please enter valid ESI", txtESI, 5000);
                        blnErrorFlag = true;
                    }
                }

                if (Convert.ToString(txtPan.Text) != "")
                {
                    if (txtPan.Text.Length != 10)
                    {
                        epCompany.SetError(txtPan, "Please enter valid PAN");
                        txtPan.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPan.ShowAlways = true;
                        tpPan.Show("Please enter valid PAN", txtPan, 5000);
                        blnErrorFlag = true;
                    }
                }

                if (Convert.ToString(txtGSTTIN.Text) != "")
                {
                    if (txtGSTTIN.Text.Length != 15)
                    {
                        epCompany.SetError(txtGSTTIN, "Please enter valid GSTTIN");
                        txtGSTTIN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpGstin.ShowAlways = true;
                        tpGstin.Show("Please enter valid GSTTIN", txtGSTTIN, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtCity.Text) != "")
                {
                    string VarCity = "0";
                    DataSet objDsCity = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsCity = objDserv.udfnCitylist(1, txtCity.Text.Trim(), Convert.ToInt32(cmbState.SelectedValue),0);
                    objDserv.CloseConnection();
                    if (objDsCity != null) {
                        if (objDsCity.Tables.Count > 0) {
                            if (objDsCity.Tables[0].Rows.Count > 0) {
                                VarCity = Convert.ToString(objDsCity.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (VarCity == "0" || VarCity == "-1")
                    {
                        lblcityid.Text = "0";
                        epCompany.SetError(txtCity, "Invalid city");
                        txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCity.ShowAlways = true;
                        tpCity.Show("Invalid city", txtCity, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        lblcityid.Text= VarCity;
                    }
                    if (Convert.ToString(cmbState.SelectedValue) == "" || Convert.ToString(cmbState.SelectedValue) == "-1")
                    {
                        epCompany.SetError(cmbState, "Please select state");
                        cmbState.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpState.ShowAlways = true;
                        tpState.Show("Please select state", cmbState, 5000);
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
                if (Convert.ToString(txtName.Text).Trim() == "")
                {
                    epCompany.SetError(txtName, "Please enter name");
                    txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpName.ShowAlways = true;
                    tpName.Show("Please enter name", txtName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtName.BackColor = Color.White;
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
                    txtMobilenumber.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTransactionType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobilenumber_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMobilenumber.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtOperator_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOperator.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobileBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMobileBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epCompany.SetError(cmbTransactionType, "Please select transaction type");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
                }
                else
                {
                    epCompany.Clear();
                    cmbTransactionType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbTransactionType.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobilenumber_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtMobilenumber.Text).Trim() == "")
                {
                    epCompany.SetError(txtMobilenumber, "Please enter mobile number");
                    txtMobilenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNumber.ShowAlways = true;
                    tpMobileNumber.Show("Please enter mobile number", txtMobilenumber, 5000);
                }
                else if (Convert.ToString(txtMobilenumber.Text).Length != 10)
                {
                    epCompany.SetError(txtMobilenumber, "Please enter valid mobile number");
                    txtMobilenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNumber.ShowAlways = true;
                    tpMobileNumber.Show("Please enter valid mobile number", txtMobilenumber, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtMobilenumber.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobilenumber_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbWhatsApp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOperator_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtOperator.Text).Trim() == "")
                {
                    epCompany.SetError(txtOperator, "Please enter opertaor");
                    txtOperator.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOperator.ShowAlways = true;
                    tpOperator.Show("Please enter operator", txtOperator, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtOperator.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOperator_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMobileBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobileBrand_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtMobileBrand.Text).Trim() == "")
                {
                    epCompany.SetError(txtMobileBrand, "Please enter mobile brand");
                    txtMobileBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileBrand.ShowAlways = true;
                    tpMobileBrand.Show("Please enter mobile brand", txtMobileBrand, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtMobileBrand.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMobileBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtStaffName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAddContact_Enter(object sender, EventArgs e)
        {

        }


        private void TabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void BtnAddContact_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                int varflag = 0, varflag1 = 0,varflag2=0;
                if (Convert.ToString(txtName.Text).Trim() == "")
                {
                    epCompany.SetError(txtName, "Please enter name");
                    txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpName.ShowAlways = true;
                    tpName.Show("Please enter name", txtName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epCompany.SetError(cmbTransactionType, "Please select transaction type");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(txtMobilenumber.Text).Trim() == "" )
                {
                    epCompany.SetError(txtMobilenumber, "Please enter mobile number name");
                    txtMobilenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNumber.ShowAlways = true;
                    tpMobileNumber.Show("Please  enter mobile number name", txtMobilenumber, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(txtMobilenumber.Text).Trim() != "")
                {
                    if (txtMobilenumber.Text.Length != 10)
                    {
                        epCompany.SetError(txtMobilenumber, "Please enter valid mobile number name");
                        txtMobilenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpMobileNumber.ShowAlways = true;
                        tpMobileNumber.Show("Please  enter mobile valid number name", txtMobilenumber, 5000);
                        blnErrorFlag = true;
                    }
                }

                if (txtMobilenumber.Text.Length != 10)
                {
                    epCompany.SetError(txtMobilenumber, "Please enter valid mobile number name");
                    txtMobilenumber.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileNumber.ShowAlways = true;
                    tpMobileNumber.Show("Please  enter mobile valid number name", txtMobilenumber, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtOperator.Text).Trim() == "")
                {
                    epCompany.SetError(txtOperator, "Please enter operator");
                    txtOperator.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOperator.ShowAlways = true;
                    tpOperator.Show("Please enter operator", txtOperator, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(txtMobileBrand.Text).Trim() == "")
                {
                    epCompany.SetError(txtMobileBrand, "Please enter mobile brand");
                    txtMobileBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMobileBrand.ShowAlways = true;
                    tpMobileBrand.Show("Please enter mobile brand", txtMobileBrand, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtStaffName.Text).Trim() == "")
                {
                    epCompany.SetError(txtStaffName, "Please enter staff name");
                    txtStaffName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStaffName.ShowAlways = true;
                    tpStaffName.Show("Please enter staff name", txtStaffName, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    pnlStatusContact.Enabled = false;
                    var varcheckedvalue = "";
                    var varwhatsapp = "";
                    if (cbPrimary.Checked == true)
                    {
                        varcheckedvalue = "Yes";
                    }
                    else
                    {
                        varcheckedvalue = "No";
                    }
                    if (cbWhatsApp.Checked == true)
                    {
                        varwhatsapp = "Yes";
                    }
                    else
                    {
                        varwhatsapp = "No";
                    }

                    //if (varCMSlNo != "0") { varflag = 0; }
                    //else { 
                    varflag = 0;
                    foreach (DataGridViewRow row in grdContactManager.Rows)
                        {
                            if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                            {
                                string gridValue1 = row.Cells[8].Value.ToString();
                                string gridValue2 = row.Cells[5].Value.ToString();
                                string gridValue4 = row.Cells[3].Value.ToString();
                                string varSlNo = row.Cells["clmContsno"].Value.ToString();

                                if (gridValue1 == Convert.ToString(cmbTransactionType.SelectedValue) && gridValue4 == txtMobilenumber.Text && varSlNo != varCMSlNo)
                                {
                                    varflag1 = 1;
                                }
                                if (gridValue4 == txtMobilenumber.Text && varSlNo != varCMSlNo)
                                {
                                    varflag1 = 1;
                                }
                                if (gridValue1 == Convert.ToString(cmbTransactionType.SelectedValue) && gridValue2 == varcheckedvalue && varSlNo != varCMSlNo)
                                {
                                    varflag = 1;
                                    if (varflag == 1 && cbPrimary.Checked == true)
                                    {
                                        varflag2 = 1;
                                    }
                                }
                            }
                        }
                   // }
                    DataService objDser = new DataService();
                    string varvalue = "";
                    varvalue = objDser.displaydata("SELECT MST_DisplayText FROM  DEF_Master where MSTID = '"+ Convert.ToString(cmbTransactionType.SelectedValue) + "'");


                    if (varflag1==0 && varflag2 ==0)
                    {
                        if (rbActiveContact.Checked == true)
                        {
                            varstatusidContact = 1;
                            varstatus = "Active";
                        }
                        else
                        {
                            varstatusidContact =2;
                            varstatus = "Inactive";
                        }
                        if (varCMSlNo == "0")
                        {
                            grdContactManager.Rows.Add(grdContactManager.Rows.Count + 1, varvalue, txtName.Text, txtMobilenumber.Text, varwhatsapp, varcheckedvalue, txtOperator.Text, txtMobileBrand.Text, txtStaffName.Text, Convert.ToString(cmbTransactionType.SelectedValue), varstatusidContact,varstatus);
                            varContactModifiedFlag = 1;
                        }
                        else {
                            for (int i = 0; i < grdContactManager.RowCount; i++)
                            {
                                if (Convert.ToString(grdContactManager.Rows[i].Cells["clmContsno"].Value) == varCMSlNo)
                                {
                                    grdContactManager.Rows[i].Cells["clmTransaction"].Value = varvalue;
                                    grdContactManager.Rows[i].Cells["clmName"].Value = txtName.Text;
                                    grdContactManager.Rows[i].Cells["clmmobile"].Value = txtMobilenumber.Text;
                                    grdContactManager.Rows[i].Cells["clmWhatsAppNo"].Value = varwhatsapp;
                                    grdContactManager.Rows[i].Cells["clmPrimary"].Value = varcheckedvalue;
                                    grdContactManager.Rows[i].Cells["clmOperator"].Value = txtOperator.Text;
                                    grdContactManager.Rows[i].Cells["clmMobileBrand"].Value = txtMobileBrand.Text;
                                    grdContactManager.Rows[i].Cells["clmStaffName"].Value = txtStaffName.Text;
                                    grdContactManager.Rows[i].Cells["clmStatusContact"].Value = varstatus;
                                    grdContactManager.Rows[i].Cells["clmStatusContactID"].Value = varstatusidContact;
                                    grdContactManager.Rows[i].Cells["clmid"].Value = Convert.ToString(cmbTransactionType.SelectedValue);
                                    varContactModifiedFlag = 1;
                                }
                            }
                        }
                        udfnContactClear();
                        this.grdContactManager.Sort(this.grdContactManager.Columns["clmid"], ListSortDirection.Ascending);
                        for(int i=0;i<grdContactManager.Rows.Count;i++)
                        {
                            grdContactManager.Rows[i].Cells["clmContsno"].Value = i + 1;
                        }
                        grdContactManager.Columns["clmContsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        cmbTransactionType.Focus();
                        rbActiveContact.Checked = true;
                        grdContactManager.ClearSelection();
                        btnAddContact.Image = ROMS.Properties.Resources.plus;
                    }
                    else
                    {
                        if (varflag1 != 0)
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(46);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (varflag2 != 0)
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(47);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        public void udfnContactClear()
        {
            try
            {
                txtName.Text = "";
                cmbTransactionType.SelectedValue = -1;
                txtMobilenumber.Text = "";
                txtStaffName.Text = "";
                txtOperator.Text = "";
                txtMobileBrand.Text = "";
                cbWhatsApp.Checked = false;
                cbPrimary.Checked = false;
                varCMSlNo = "0";
                epCompany.Clear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

       

        private void BtnSaveContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdContactManager.Rows.Count > 0)
                {
                     
                        udfnContactSave();
                        udfnContactClear(); 
                    //grdContactManager.Rows.Clear();
                }
                else
                { 
                    MessageBox.Show("Please enter atleast one Transaction", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnContactSave()
        {
            string result = "";
            int contactupdate = 0;
            SPDataService objspdservice = new SPDataService();
            DataTable objContactTable = new DataTable();
            btnSaveContact.Enabled = false;
            try
            {
                objContactTable.TableName = "MR_Company_Contact";
                objContactTable.Columns.Add("CMCON_Name", typeof(string));
                objContactTable.Columns.Add("CMCON_TransactionType", typeof(int));
                objContactTable.Columns.Add("CMCON_MobileNo", typeof(string));
                objContactTable.Columns.Add("CMCON_Operator", typeof(string));
                objContactTable.Columns.Add("CMCON_MobileBrand", typeof(string));
                objContactTable.Columns.Add("CMCON_Primary", typeof(int));
                objContactTable.Columns.Add("CMCON_WhatsAppEnabled", typeof(int));
                objContactTable.Columns.Add("COMCON_StaffName", typeof(string));
                objContactTable.Columns.Add("CMCON_STSID", typeof(int));

                DataTable objBankTable = new DataTable();
                objBankTable.TableName = "MR_Bank";
                objBankTable.Columns.Add("CMBNK_Name", typeof(string));
                objBankTable.Columns.Add("CMBNK_ShortName", typeof(string));
                objBankTable.Columns.Add("CMBNK_BranchName", typeof(string));
                objBankTable.Columns.Add("CMBNK_AccNo", typeof(string));
                objBankTable.Columns.Add("CMBNK_IFSC", typeof(string));
                objBankTable.Columns.Add("CMBNK_STSID", typeof(string));
                objBankTable.Columns.Add("CMBNK_Default", typeof(string));
                objBankTable.Columns.Add("CMBNK_ID", typeof(int));

                for (int i = 0; i < grdContactManager.Rows.Count; i++)
                {
                    int varprimary = 0;
                    int varwhatsapp = 0;
                    if (Convert.ToString(grdContactManager.Rows[i].Cells["clmPrimary"].Value) == "Yes")
                    {
                        varprimary = 1;
                    }
                    else
                    {
                        varprimary = 0;
                    }
                    if (Convert.ToString(grdContactManager.Rows[i].Cells["clmWhatsAppNo"].Value) == "Yes")
                    {
                        varwhatsapp = 1;
                    }
                    else
                    {
                        varwhatsapp = 0;
                    }
                    objContactTable.Rows.Add( Convert.ToString(grdContactManager.Rows[i].Cells["clmName"].Value), Convert.ToInt32(grdContactManager.Rows[i].Cells["clmid"].Value),
                    Convert.ToString(grdContactManager.Rows[i].Cells["clmmobile"].Value), Convert.ToString(grdContactManager.Rows[i].Cells["clmOperator"].Value),
                    Convert.ToString(grdContactManager.Rows[i].Cells["clmMobileBrand"].Value),varprimary, varwhatsapp,Convert.ToString(grdContactManager.Rows[i].Cells["clmStaffName"].Value), Convert.ToString(grdContactManager.Rows[i].Cells["clmStatusContactID"].Value));
                }
                if (Convert.ToInt32(varcontactcompanyid) != 0)
                {
                    contactupdate = Convert.ToInt32(varcontactcompanyid);
                }
                else
                {
                    contactupdate = Convert.ToInt32(varcompanyid);
                }

                if (btnSave.Text == "Save")
                {
                    result = objspdservice.udfnCompanyMaster(3, Convert.ToInt32(varcontactcompanyid), "", "", "", "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", MainForm.pbUserID, MainForm.pbIpAddress, "contact manager Create", objBankTable, objContactTable,"",0);
                }
                else
                {
                    result = objspdservice.udfnCompanyMaster(4, Convert.ToInt32(contactupdate), "", "", "", "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", MainForm.pbUserID, MainForm.pbIpAddress, "contact manager Update", objBankTable, objContactTable,"",0);
                    varupdate = "1";
                }
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varContactModifiedFlag = 0;
                    udfnClear();
                    MainForm.objCP_Companylist.udfnList();
                    if (btnSave.Text == "Update")
                    {
                        udfnclose();
                    }
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                objspdservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { 
                btnSaveContact.Enabled = true;
            }
        }
        private void BtnAddContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAddContact_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSaveContact_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSaveContact.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSaveContact_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSaveContact.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSaveContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSaveContact_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnCloseContact_Click(object sender, EventArgs e)
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

        private void BtnCloseContact_Enter(object sender, EventArgs e)
        {
            try
            {
                btnCloseContact.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnCloseContact_Leave(object sender, EventArgs e)
        {
            try
            {
                btnCloseContact.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnCloseContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPincode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAlterPhoneno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtmobileNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAlterMobileno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtwhatsappNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CP_Company_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_STATE", "ST_STSID=1 AND STID<>0 ORDER BY STID", "ST_Name,STID", cmbState, "", "ST_Name", "STID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,1) AND MSTID !=0 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                DataService objdservice = new DataService();
                pnlBStatus.Enabled = false;
                rbBankActive.Checked = true;
                varstatusid = objdservice.displaydata("select STS_Name as name from DEF_Status where STS_ModuleID=1 AND STSID=1");
                grdContactManager.Rows.Clear();
                grdBankDetails.Rows.Clear();
                udfnBankDropDownLoad();
                udfnEdit();
                this.ActiveControl = txtCompanyName;
                objdservice.CloseConnection();
                DataSet objDS = new DataSet();
                SPDataService objDserv = new SPDataService();
                objDS = objDserv.udfnCompanyList(6,Convert.ToInt32(varcompanyid),MainForm.pbUserID,MainForm.pbIpAddress,0);
                
                if (objDS != null)
                {
                    if (objDS.Tables.Count > 0) {
                        if (objDS.Tables[0].Rows.Count > 0) {
                            int varcount = Convert.ToInt32(objDS.Tables[0].Rows[0][0]);
                            if (varcount == 0)
                            {
                                chkDefaultConcern.Visible = true;
                            }
                            else { chkDefaultConcern.Visible = false; }
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
        private void GrdContactManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.RowIndex != -1)
                {
                    switch (grdContactManager.Columns[e.ColumnIndex].Name)
                    {

                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdContactManager.Rows.RemoveAt(this.grdContactManager.SelectedRows[0].Index);
                                for (int i = 0; i < grdContactManager.RowCount; i++)
                                {
                                    grdContactManager.Rows[i].Cells["clmContsno"].Value = i + 1;
                                }
                                varContactModifiedFlag = 1;
                            }
                            break;
                        case "clmCMEdit":
                            cmbTransactionType.SelectedValue = Convert.ToInt32(grdContactManager.Rows[e.RowIndex].Cells["clmid"].Value);
                            txtName.Text = Convert.ToString(grdContactManager.Rows[e.RowIndex].Cells["clmName"].Value);
                            txtMobilenumber.Text = Convert.ToString(grdContactManager.Rows[e.RowIndex].Cells["clmmobile"].Value);
                            if (Convert.ToString(grdContactManager.Rows[e.RowIndex].Cells["clmWhatsAppNo"].Value) == "Yes") { cbWhatsApp.Checked = true; }
                            if (Convert.ToString(grdContactManager.Rows[e.RowIndex].Cells["clmPrimary"].Value) == "Yes") { cbPrimary.Checked = true; }
                            txtOperator.Text = Convert.ToString(grdContactManager.Rows[e.RowIndex].Cells["clmOperator"].Value);
                            txtMobileBrand.Text = Convert.ToString(grdContactManager.Rows[e.RowIndex].Cells["clmMobileBrand"].Value);
                            txtStaffName.Text = Convert.ToString(grdContactManager.Rows[e.RowIndex].Cells["clmStaffName"].Value);
                            varCMSlNo = Convert.ToString(grdContactManager.Rows[e.RowIndex].Cells["clmContsno"].Value);
                            varstatus = Convert.ToString(grdContactManager.Rows[e.RowIndex].Cells["clmStatusContact"].Value);
                            varstatusidContact = Convert.ToInt32(grdContactManager.Rows[e.RowIndex].Cells["clmStatusContactID"].Value);
                            pnlStatusContact.Enabled = true;
                            if (varstatusidContact == 1)
                            {
                                rbActiveContact.Checked = true;
                            }
                            else if (varstatusidContact == 2)
                            {
                                rbInactiveContact.Checked = true;
                            }
                            tpName.Active = false;
                            btnAddContact.Image = ROMS.Properties.Resources.save16x16;
                            txtName.BackColor = Color.White;
                            epCompany.Clear();
                            //txtName.Focus();
                            cmbTransactionType.Focus();
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

        private void GrdBankDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdBankDetails.Columns[e.ColumnIndex].Name)
                    {

                        case "clmremovebank":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if(Convert.ToInt32(grdBankDetails.SelectedRows[0].Cells["clmdefaultbnk"].Value)==1)
                                {
                                    chkDefaultBank.Enabled = true;
                                }
                                grdBankDetails.Rows.RemoveAt(this.grdBankDetails.SelectedRows[0].Index);
                                for (int i = 0; i < grdBankDetails.RowCount; i++)
                                {
                                    grdBankDetails.Rows[i].Cells["clmsno"].Value = i + 1;
                                }
                                varCompanyModifiedFlag = 1;
                            }
                            break;
                        case "clmEdit":
                            cmbBankName.SelectedValue = Convert.ToInt16(grdBankDetails.Rows[e.RowIndex].Cells["clmBNKID"].Value);
                            txtBankShortName.Text = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmBankShortName"].Value);
                            txtbranchname.Text = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmbranch"].Value);
                            txtAccno.Text = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmaccno"].Value);
                            txtIFScode.Text = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmifscode"].Value);
                            varSlNo = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmsno"].Value);
                            varstatusid = Convert.ToString(grdBankDetails.Rows[e.RowIndex].Cells["clmStatus"].Value);
                            if(Convert.ToUInt32(grdBankDetails.Rows[e.RowIndex].Cells["clmdefaultbnk"].Value)==1)
                            {
                                chkDefaultBank.Checked = true;
                                chkDefaultBank.Enabled = true;
                            }
                            else
                            {
                                chkDefaultBank.Checked = false;
                            }
                        pnlBStatus.Enabled = true;
                        if (varstatusid=="Active")
                        {
                            rbBankActive.Checked = true;
                        }
                        else
                        {
                            rbBankInActive.Checked = true;
                        }
                        btnAdd.Image = ROMS.Properties.Resources.save16x16;
                        cmbBankName.BackColor = Color.White;
                        tpBankName.Active = false;
                        epCompany.Clear();
                        cmbBankName.Focus();
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



        private void udfnEdit()
        {
            try
            {
                if (varcompanyid != "")
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objspservice.udfnCompanyList(1, Convert.ToInt32(varcompanyid), MainForm.pbUserID, MainForm.pbIpAddress,0);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            
                            if (objDS.Tables[0].Rows[0]["DEFAULTID"].ToString()=="1")
                            {
                                chkDefaultConcern.Checked = true;
                            }
                            else
                            {
                                chkDefaultConcern.Checked = false;
                            }
                            txtCompanyName.Text = objDS.Tables[0].Rows[0]["Name"].ToString().Replace("''", "'");
                            txtShortName.Text = objDS.Tables[0].Rows[0]["Shortname"].ToString().Replace("''", "'");
                            txtCity.Text = objDS.Tables[0].Rows[0]["city"].ToString().Replace("''", "'");
                            txtPhoneNo.Text = objDS.Tables[0].Rows[0]["Phone"].ToString().Replace("''", "'");
                            txtwhatsappNo.Text = objDS.Tables[0].Rows[0]["Whatsapp"].ToString().Replace("''", "'");
                            txtGSTTIN.Text = objDS.Tables[0].Rows[0]["GSTIN"].ToString().Replace("''", "'");
                            txtPan.Text = objDS.Tables[0].Rows[0]["Pan"].ToString().Replace("''", "'");
                            txtAddressLine1.Text = objDS.Tables[0].Rows[0]["Address1"].ToString().Replace("''", "'");
                            txtAddressLine2.Text = objDS.Tables[0].Rows[0]["Address2"].ToString().Replace("''", "'");
                            cmbState.Text = objDS.Tables[0].Rows[0]["State"].ToString();
                            txtPincode.Text = objDS.Tables[0].Rows[0]["Pincode"].ToString();
                            txtmobileNo.Text = objDS.Tables[0].Rows[0]["Mobile"].ToString();
                            txtEmail.Text = objDS.Tables[0].Rows[0]["Email"].ToString().Replace("''", "'");
                            txtwebsite.Text = objDS.Tables[0].Rows[0]["Web"].ToString().Replace("''", "'");
                            txtESI.Text = objDS.Tables[0].Rows[0]["ESI"].ToString().Replace("''", "'");
                            txtEPF.Text = objDS.Tables[0].Rows[0]["EPF"].ToString().Replace("''", "'");
                            txtFSSAI.Text = objDS.Tables[0].Rows[0]["FSSAI"].ToString().Replace("''", "'");
                            txtPlno.Text = objDS.Tables[0].Rows[0]["PLNO"].ToString().Replace("''", "'");
                            txtAlterMobileno.Text = objDS.Tables[0].Rows[0]["MobileAlt"].ToString();
                            txtAlterPhoneno.Text = objDS.Tables[0].Rows[0]["PhoneAlt"].ToString(); 
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "1") { rbActive.Checked = true; } else { rbInactive.Checked = true; }
                            lblCompanyLogoFilename.Text = objDS.Tables[0].Rows[0]["COM_LogoName"].ToString();

                            //********** College Logo load from database *************
                            SPDataService objservice = new SPDataService();
                            pbLogoPath = objservice.udfnGetPath(0);
                            objservice.CloseConnection();
                            if (!pbLogoPath.EndsWith("\\"))
                            {
                                pbLogoPath += "\\";
                            }
                            pbCompanypath = pbLogoPath + lblCompanyLogoFilename.Text;
                            lblCompanyLogoPath.Text = pbCompanypath;
                            btnSave.Text = "Update";
                            btnSaveContact.Text = "Update"; ;
                            pnlStatus.Enabled = true;
                            udfnButtontext();
                        }
                        if (objDS.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                            {
                                grdContactManager.Rows.Add(Convert.ToString(objDS.Tables[1].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[1].Rows[i]["TRANSACTIONNAME"]), Convert.ToString(objDS.Tables[1].Rows[i]["NAME"]),
                                Convert.ToString(objDS.Tables[1].Rows[i]["MOBILE"]), Convert.ToString(objDS.Tables[1].Rows[i]["WHATSAPP"]), Convert.ToString(objDS.Tables[1].Rows[i]["PRIMAY"])
                                , Convert.ToString(objDS.Tables[1].Rows[i]["OPERATOR"]), Convert.ToString(objDS.Tables[1].Rows[i]["BRAND"]), Convert.ToString(objDS.Tables[1].Rows[i]["Staff Name"]), Convert.ToString(objDS.Tables[1].Rows[i]["id"]), Convert.ToString(objDS.Tables[1].Rows[i]["StatusId"]), Convert.ToString(objDS.Tables[1].Rows[i]["Status"]));
                               
                            }
                        }
                       
                        if (objDS.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                            {
                                if (Convert.ToInt32(objDS.Tables[2].Rows[i]["Default Bank"]) == 1)
                                {
                                    varDefault = "Yes";
                                }
                                else
                                {
                                    varDefault = "No";
                                }
                                grdBankDetails.Rows.Add(Convert.ToString(objDS.Tables[2].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[2].Rows[i]["NAME"]), Convert.ToString(objDS.Tables[2].Rows[i]["SHORTNAME"]),
                                Convert.ToString(objDS.Tables[2].Rows[i]["BRANCH"]), Convert.ToString(objDS.Tables[2].Rows[i]["ACCOUNT"]), Convert.ToString(objDS.Tables[2].Rows[i]["IFSC"])
                                , Convert.ToString(objDS.Tables[2].Rows[i]["STATUS"]),  Convert.ToString(objDS.Tables[2].Rows[i]["sts"]), Convert.ToString(objDS.Tables[2].Rows[i]["Default Bank"]),varDefault, Convert.ToInt32(objDS.Tables[2].Rows[i]["CMBNK_ID"]),Convert.ToInt16(objDS.Tables[2].Rows[i]["BankID"]));
                                grdBankDetails.Columns["clmStatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                if(Convert.ToInt32(grdBankDetails.Rows[i].Cells["clmdefaultbnk"].Value)==1)
                                {
                                    chkDefaultBank.Checked = false;
                                    chkDefaultBank.Enabled = false;
                                }
                            }
                            btnSave.Text = "Update";
                            btnSaveContact.Text = "Update"; 

                        }

                    }
                    lvCity.Visible = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdBankDetails.ClearSelection();
                grdContactManager.ClearSelection();
            }
        }

        public void udfnButtontext()
        {
            try
            {
                if (btnSave.Text == "Update")
                {
                    if (lblCompanyLogoFilename.Text == "")
                    {
                        picCompanyLogo.BackgroundImage = ROMS.Properties.Resources.picture;
                        picCompanyLogo.Image = ROMS.Properties.Resources.picture;
                        lblCompanyLogoFilename.Text = "";
                        lblCompanyLogoPath.Text = "";
                    }
                    else
                    {
                        //**************set college logo to picturebox******************
                        picCompanyLogo.BackgroundImage = null;
                        picCompanyLogo.Image = null;
                        Image objTmpImage = Image.FromFile(pbCompanypath);
                        Image varcurrentimg = new Bitmap(objTmpImage);
                        objTmpImage.Dispose();
                        picCompanyLogo.BackgroundImage = varcurrentimg;
                        picCompanyLogo.Image = new Bitmap(varcurrentimg);
                        picCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    if (lblCompanyLogoFilename.Text == "" && lblCompanyLogoPath.Text == "")
                    {
                        btncollegeLogoUpload.Text = "Browse";
                        btncollegeLogoUpload.Image = ROMS.Properties.Resources.browse1;
                    }
                    else
                    {
                        btncollegeLogoUpload.Text = "Remove";
                        btncollegeLogoUpload.Image = ROMS.Properties.Resources.remove;
                    }
                }
                else
                {
                    cmbState.SelectedValue = 0;
                }
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

        private void LvCity_DoubleClick(object sender, EventArgs e)
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
                    ListViewItem selectedItem = lvCity.SelectedItems[0];
                    txtCity.Text = selectedItem.SubItems[0].Text; 
                    lblcityid.Text = selectedItem.SubItems[2].Text; 
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

        private void CbWhatsApp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbPrimary.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbPrimary_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtOperator.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbWhatsApp_Enter(object sender, EventArgs e)
        {
            try
            {
                cbWhatsApp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbWhatsApp_Leave(object sender, EventArgs e)
        {
            try
            {
                cbWhatsApp.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbPrimary_Enter(object sender, EventArgs e)
        {
            try
            {
                cbPrimary.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBankDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        { try
            {

                grdBankDetails.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdContactManager_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                grdContactManager.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtAccno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtIFScode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TcCompanyDetails_Selected(object sender, TabControlEventArgs e)
        {
            //try
            //{

            //    if (e.TabPageIndex == 0)
            //    {
            //       // udfntooltiphide(); udfntextboxcolor();
            //        ActiveControl = txtCompanyName;
            //       // txtCompanyName.Select();
            //    }
            //    else {
            //        //udfnClear();
            //        udfntextboxcolor();
            //        this.ActiveControl = txtName;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            //finally
            //{ 
            //   // tpCompanyName.Active = false; 
            //}
        }

        private void Grbform_Leave(object sender, EventArgs e)
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

        private void ChkDefaultConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                chkDefaultConcern.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkDefaultConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                chkDefaultConcern.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void ChkDefaultConcern_KeyDown(object sender, KeyEventArgs e)
        { 
            if (pnlStatus.Enabled)
            {
                rbActive.Focus();
            }
            else { btnSave.Focus(); }
        }

        private void RbBankActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbBankActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbBankActive_KeyDown(object sender, KeyEventArgs e)
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

        private void RbBankActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbBankActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbBankInActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbBankInActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbBankInActive_KeyDown(object sender, KeyEventArgs e)
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

        private void RbBankInActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbBankInActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStaffName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStaffName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStaffName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatusContact.Enabled == true)
                    {
                        if(rbActiveContact.Checked==true)
                        {
                            rbActiveContact.Focus();
                        }
                        else
                        {
                            rbInactiveContact.Focus();
                        }
                    }
                    else
                    {
                        btnAddContact.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStaffName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtStaffName.Text).Trim() == "")
                {
                    epCompany.SetError(txtStaffName, "Please enter staff name");
                    txtStaffName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStaffName.ShowAlways = true;
                    tpStaffName.Show("Please enter staff name", txtStaffName, 5000);
                }
                else
                {
                    epCompany.Clear();
                    txtStaffName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActiveContact_Enter(object sender, EventArgs e)
        {
            try
            {
                rbActiveContact.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActiveContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAddContact.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActiveContact_Leave(object sender, EventArgs e)
        {
            try
            {
                rbActiveContact.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactiveContact_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInactiveContact.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string result ="";  
                result = objDTBank.Tables[0].AsEnumerable()
                           .Where(r => r.Field<int?>("BNKID") == Convert.ToInt16(cmbBankName.SelectedValue)) // handle nulls
                           .Select(r => r.Field<string>("ShortName"))
                           .FirstOrDefault() ?? string.Empty;

                // Assign to TextBox (result will be empty string if nothing found)
                txtBankShortName.Text = result ?? string.Empty; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBankName_Enter(object sender, EventArgs e)
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

        private void CmbBankName_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbBankName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAddressLine2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbBankName_Leave(object sender, EventArgs e)
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

        private void RbInactiveContact_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAddContact.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInactiveContact_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInactiveContact.BackColor = Color.White;
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

        private void BtncollegeLogoUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //***********  Upload College Logo *********

                if (btncollegeLogoUpload.Text == "Browse")
                {
                    objfilelogo.Filter = "JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|PNG files (*.png)|*.png";
                    objfilelogo.FilterIndex = 1;
                    objfilelogo.Multiselect = false;
                    objfilelogo.ShowDialog();

                    if (objfilelogo.FileName != "")
                    {
                        string varExtension = Path.GetExtension(objfilelogo.FileName);

                        SPDataService objservice = new SPDataService();
                        string varFolderPath = objservice.udfnGetPath(0);
                        objservice.CloseConnection();
                        if (!varFolderPath.EndsWith("\\"))
                        {
                            varFolderPath += "\\";
                        }
                        string varFileName = "Company Logo" + varExtension;
                        varNewfile = Path.Combine(varFolderPath, varFileName);

                        File.Copy(objfilelogo.FileName, varNewfile, true);

                        lblCompanyLogoFilename.Text = varFileName;
                        lblCompanyLogoPath.Text = varNewfile;

                        picCompanyLogo.BackgroundImage = null;
                        picCompanyLogo.Image = null;
                        picCompanyLogo.Image = new Bitmap(objfilelogo.FileName);
                        picCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage;

                        if (lblCompanyLogoFilename.Text == "" && lblCompanyLogoPath.Text == "")
                        {
                            btncollegeLogoUpload.Text = "Browse";
                            btncollegeLogoUpload.Image = ROMS.Properties.Resources.browse1;
                        }
                        else
                        {
                            btncollegeLogoUpload.Text = "Remove";
                            btncollegeLogoUpload.Image = ROMS.Properties.Resources.remove;
                        }

                        varflag = 1;
                    }
                }

                // ******* Remove  Company Logo ********
                else
                {
                    DialogResult objDialogResult = MessageBox.Show("Do you want to remove logo ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (objDialogResult == DialogResult.Yes)
                    {

                        varFile = lblCompanyLogoPath.Text;
                        //*********** remove image from picturebox and set default image *********
                        picCompanyLogo.BackgroundImage = ROMS.Properties.Resources.picture;
                        picCompanyLogo.Image = ROMS.Properties.Resources.picture;
                        lblCompanyLogoPath.Text = "";
                        lblCompanyLogoFilename.Text = "";
                        if (lblCompanyLogoFilename.Text == "" && lblCompanyLogoPath.Text == "")
                        {
                            btncollegeLogoUpload.Text = "Browse";
                            btncollegeLogoUpload.Image = ROMS.Properties.Resources.browse1;
                        }
                        else
                        {
                            btncollegeLogoUpload.Text = "Remove";
                            btncollegeLogoUpload.Image = ROMS.Properties.Resources.remove;
                        }
                    }
                    varflag = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TcCompanyDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tcCompanyDetails.SelectedIndex == 0)
                {
                     udfntooltiphide(); udfntextboxcolor();
                    ActiveControl = txtCompanyName;
                }
                else
                {
                    if (varCompanyModifiedFlag == 1)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //udfnClear();
                            udfntextboxcolor();
                            //this.ActiveControl = txtName;
                            this.ActiveControl = cmbTransactionType;
                        }
                        else
                        {
                            tcCompanyDetails.SelectedIndex = 0;
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

        private void CP_Company_Leave(object sender, EventArgs e)
        { 
            try {
                udfntooltiphide();
            }
             
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CbPrimary_Leave(object sender, EventArgs e)
        {
            try
            {
                cbPrimary.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdBankDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdBankDetails.CurrentCell.OwningColumn.Name == "clmStatus")
                {
                    TextBox RefCode = e.Control as TextBox;
                    if (RefCode != null)
                    {
                        RefCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        RefCode.AutoCompleteCustomSource = AutoCompleteLoad();
                        RefCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else
                {
                    TextBox prodCode = e.Control as TextBox;
                    if (prodCode != null)
                    {
                        prodCode.AutoCompleteMode = AutoCompleteMode.None;
                    }
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
