using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ROMS.Model;
using System.IO;

namespace ROMS
{
    //Created By:-Sathish ; Created On:-11-08-2023
    public partial class CP_UPI : Form
    {
        DataError objError;
        private ToolTip tpProvider = new ToolTip();
        private ToolTip tpUPIID = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpBank = new ToolTip();
        public int varID = 0;
        public int PbStatus = 0;
        public int varUpdate = 0;
        string varFile = "";
        OpenFileDialog objfilelogo = new OpenFileDialog();
        string varNewfile = "";
        public string varExtension = "";
        public string pbLogoPath = "", pbFilepath="";
        string varFolderPath = "";
        int varflag = 0;
        public CP_UPI()
        {
            InitializeComponent();
        }
         
        public void udfnSave(object sender,EventArgs e)
        {
            try
            {
                if (rbActive.Checked == true) { PbStatus = 1; }
                else { PbStatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = "";int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "UPI Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "UPI Updation";
                    varType = 1;
                }
               
                SPDataService objspdservice = new SPDataService();
                MR_UPI objMR_UPI = new MR_UPI();
                objMR_UPI.ViewType = varType;
                objMR_UPI.paraUPIID = txtUPIId.Text.Trim();
                objMR_UPI.paraConcernID = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_UPI.paraComBankId = Convert.ToInt32(cmbBank.SelectedValue);
                objMR_UPI.paraStatusId = Convert.ToInt32(PbStatus);
                objMR_UPI.paraProviderID = Convert.ToInt32(cmbProvider.SelectedValue);
                objMR_UPI.paraLogoName = lblCompanyLogoFilename.Text;
                objMR_UPI.paraId = Convert.ToInt32(varID);
                objMR_UPI.paraOriginator = varoriginator;
                varResult = objspdservice.udfnUPI(objMR_UPI);
                objspdservice.CloseConnection();
 
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_UPIList.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        udfnclear();
                        varID =Convert.ToInt32(varvalue[2]);
                        MainForm.objCP_UPIList.udfnList();
                    }
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
                    } 
                    if (File.Exists(varNewfile))
                    {
                        File.Delete(varNewfile);
                    }
                    if (varflag == 1 && varNewfile != "")
                    {
                        string varFileName = "UPILogoImage" + Convert.ToString(varID) + varExtension;
                        varNewfile = Path.Combine(varFolderPath, varFileName);
                        //*********** copy file name & file path **************
                        File.Copy(objfilelogo.FileName, varNewfile, true);
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Focus();
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        private void udfnclear()
        {
            try
            {
                txtUPIId.Text = "";  
                txtUPIId.Focus();
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
                if (Convert.ToString(txtUPIId.Text).Trim() == "")
                {
                    epRoute.SetError(txtUPIId, "Please enter UPPI ID.");
                    txtUPIId.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUPIID.ShowAlways = true;
                    tpUPIID.Show("Please enter UPPI ID.", txtUPIId, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbConcern.SelectedValue)=="0" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epRoute.SetError(cmbConcern, "Please select concern.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern.", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbProvider.SelectedValue) == "0" || Convert.ToString(cmbProvider.SelectedValue) == "-1")
                {
                    epRoute.SetError(cmbProvider, "Please select provider.");
                    cmbProvider.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProvider.ShowAlways = true;
                    tpProvider.Show("Please select concern.", cmbProvider, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbBank.SelectedValue) == "0" || Convert.ToString(cmbBank.SelectedValue) == "-1")
                {
                    epRoute.SetError(cmbBank, "Please select bank.");
                    cmbBank.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBank.ShowAlways = true;
                    tpBank.Show("Please select bank.", cmbBank, 5000);
                    blnErrorFlag = true;
                }

                if (blnErrorFlag == false)
                {
                    epRoute.Clear();
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
                //if (varmastertype == 0)
                //{
                //    MainForm.objCP_Routelist.udfnList();
                //}
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
        private void RbInActive_Enter(object sender, EventArgs e)
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
        private void RbInActive_Leave(object sender, EventArgs e)
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

        private void CP_Route_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CP_Route_KeyDown(object sender, KeyEventArgs e)
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

        private void CP_Route_Leave(object sender, EventArgs e)
        {
            try
            {
                tpBank.Active = false;
                tpProvider.Active = false;
                tpConcern.Active = false;
                tpUPIID.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Route_Load(object sender, EventArgs e)
        {
            try
            {
                udfnDropDownLoad();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                    rbActive.Checked = true; 
                }
                else
                { 
                    udfnEdit();
                    pnlStatus.Enabled = true;
                    if (PbStatus == 1) 
                    { 
                        rbActive.Checked = true; 
                    }
                    else 
                    {
                        txtUPIId.Enabled = false; 
                        cmbConcern.Enabled = false;
                        rbInActive.Checked = true;
                    }
                }
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                MainForm.objCP_UPIList.picLoader.Visible = false;
                MainForm.objCP_UPIList.picLoader.SendToBack(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDropDownLoad()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(3, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                cmbConcern.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDT.Tables[0];
                        }
                    }
                }
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (0,142) AND MSTID<>0 ORDER BY MST_DisplayText desc", "MST_DisplayText,MSTID", cmbProvider, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                udfnBankDropDown();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBankDropDown()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(14, Convert.ToInt16(cmbConcern.SelectedValue), "", "", 0);
                objdserv.CloseConnection();
                cmbBank.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbBank.ValueMember = "CMBNK_ID";
                            cmbBank.DisplayMember = "Bank";
                            cmbBank.DataSource = objDT.Tables[0];
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
        public void udfnEdit()
        {
            try
            {
                if (varID != 0)
                {
                    DataSet objDs = new DataSet();  
                    SPDataService objspservice = new SPDataService();
                    MR_UPI objMR_UPI = new MR_UPI();
                    objMR_UPI.ViewType = 1;
                    objMR_UPI.paraId = varID;
                    objDs = objspservice.udfnUPIList(objMR_UPI); 
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtUPIId.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UPI_UPIID"]); 
                                cmbConcern.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["ComID"]);
                                cmbBank.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["BankID"]);
                                cmbProvider.SelectedValue = Convert.ToInt32(objDs.Tables[0].Rows[0]["CRDMH_ProviderID"]); 
                                lblCompanyLogoFilename.Text = objDs.Tables[0].Rows[0]["Logo"].ToString();
                                cmbProvider.Focus();
                                SPDataService objservice = new SPDataService();
                                pbLogoPath = objservice.udfnGetPath(0);
                                objservice.CloseConnection();
                                if (!pbLogoPath.EndsWith("\\"))
                                {
                                    pbLogoPath += "\\";
                                }
                                varFolderPath = pbLogoPath;
                                pbFilepath = pbLogoPath + lblCompanyLogoFilename.Text;  
                                string[] filename = lblCompanyLogoFilename.Text.Split('.');
                                varExtension = filename[1];   
                                lblCompanyLogoPath.Text = pbFilepath;
                                udfnButtontext(); 
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
                        Image objTmpImage = Image.FromFile(pbFilepath);
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
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtREName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUPIId.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtREName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    cmbConcern.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtREName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtUPIId.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
           
        private void cmbRSNo_Enter(object sender, EventArgs e)
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

        private void cmbRSNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBank.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbRSNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbRSNo_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.White;
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
         
        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (rbActive.Enabled == true)
                    {
                        cmbBank.Focus();
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

        private void cmbBank_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBank.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbBank_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbBank_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBank.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProvider_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProvider.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProvider_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUPIId.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProvider_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbProvider_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProvider.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void cmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            udfnBankDropDown();
        }

        private void btncollegeLogoUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //***********  Upload College Logo *********
                varExtension = "";varFolderPath = "";
                if (btncollegeLogoUpload.Text == "Browse")
                {
                    objfilelogo.Filter = "JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|PNG files (*.png)|*.png";
                    objfilelogo.FilterIndex = 1;
                    objfilelogo.Multiselect = false;
                    objfilelogo.ShowDialog();

                    if (objfilelogo.FileName != "")
                    {
                         varExtension = Path.GetExtension(objfilelogo.FileName);

                        SPDataService objservice = new SPDataService();
                        varFolderPath = objservice.udfnGetPath(0);
                        objservice.CloseConnection();
                        if (!varFolderPath.EndsWith("\\"))
                        {
                            varFolderPath += "\\";
                        }
                        Random rnd = new Random();
                        int number = rnd.Next();
                        string varFileName = "UPILogo"+Convert.ToString(number)+ varExtension; 
                        varNewfile = Path.Combine(varFolderPath, varFileName);

                        //File.Copy(objfilelogo.FileName, varNewfile, true);
                        if (!string.Equals(objfilelogo.FileName, varNewfile, StringComparison.OrdinalIgnoreCase))
                        {
                            File.Copy(objfilelogo.FileName, varNewfile, true);
                        }

                        lblCompanyLogoFilename.Text = varFileName;
                        lblCompanyLogoPath.Text = varNewfile;

                        picCompanyLogo.BackgroundImage = null;
                        picCompanyLogo.Image = null;

                        //picCompanyLogo.Image = new Bitmap(objfilelogo.FileName);
                        using (var tempImage = new Bitmap(objfilelogo.FileName))
                        {
                            picCompanyLogo.Image = new Bitmap(tempImage);
                        }
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
    }
}
