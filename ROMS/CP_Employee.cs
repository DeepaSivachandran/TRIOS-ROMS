using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace ROMS
{  //Created By:-Deepa
    //Created On:-19-09-2023
    public partial class CP_Employee : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public DataTable dtModules = new DataTable();
        private ToolTip tpempname = new ToolTip();
        private ToolTip tpempTname = new ToolTip();
        private ToolTip tpempcode = new ToolTip();
        private ToolTip tpUserCategory  = new ToolTip();
        public string PbDefault;
        public int varstatus;
        public string varEmpID ="";
        public string PbNameoftheUser = "";
        public string PbEmpCode = "";
        public string PbUserCategory = "";
        public string pbempTName = "";
        public int PbUserCategoryID = 0;
        public int PbStatus=0;
        public int varUpdate = 0;
        public int varCategoryCode;

        public CP_Employee()
        {
            InitializeComponent();
        }
        private void CP_Employee_Leave(object sender, EventArgs e)
        {
            try
            {
                tpempcode.Active = false;
                tpempname.Active = false;
                tpUserCategory.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtEmpCode.Text).Trim() == "")
                {
                    epUser.SetError(txtEmpCode, "Please enter employee code");
                    txtEmpCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpempcode.ShowAlways = true;
                    tpempcode.Show("Please enter employee code", txtEmpCode, 5000);

                }
                else
                {
                    epUser.Clear();
                    txtEmpCode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtLoginID_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEmpName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtLoginID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEmployeeNameinTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtLoginID_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtEmpName.Text).Trim() == "")
                {
                    epUser.SetError(txtEmpName, "Please enter employee name");
                    txtEmpName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpempname.ShowAlways = true;
                    tpempname.Show("Please enter employee name", txtEmpName, 5000);

                }
                else
                {
                    epUser.Clear();
                    txtEmpName.BackColor = Color.White;
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
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                if (rbActive.Checked == true) { varstatus = 1; }
                else { varstatus = 2; }
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varViewType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Employee Creation";
                    varViewType = 0;
                }
                else
                {
                    varoriginator = "User Updation";
                    varViewType = 1;
                }
                if(varEmpID=="")
                {
                    varEmpID = "0";
                }
                varResult = objspservice.udfnEmployee(varViewType, Convert.ToInt32( varEmpID), (txtEmpCode.Text).Trim(), (txtEmpName.Text).Trim(), Convert.ToInt16(cmbUserCategory.SelectedValue), varstatus, varoriginator,MainForm.pbUserID,0,Convert.ToString(txtEmployeeNameinTamil.Text.Trim()));
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_EmployeeList.udfnList();
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        udfnclose();
                    }
                    udfnClear();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtEmpCode.Text).Trim() == "")
                {
                    epUser.SetError(txtEmpCode, "Please enter employee code");
                    txtEmpCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpempcode.ShowAlways = true;
                    tpempcode.Show("Please enter employee code", txtEmpCode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtEmpName.Text).Trim() == "")
                {
                    epUser.SetError(txtEmpName, "Please enter employee name");
                    txtEmpName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpempname.ShowAlways = true;
                    tpempname.Show("Please enter employee name", txtEmpName, 5000);
                    blnErrorFlag = true;
                }  
                if (Convert.ToString(txtEmployeeNameinTamil.Text).Trim() == "")
                {
                    epUser.SetError(txtEmployeeNameinTamil, "Please enter employee name in tamil");
                    txtEmployeeNameinTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpempTname.ShowAlways = true;
                    tpempTname.Show("Please enter employee name in tamil", txtEmployeeNameinTamil, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbUserCategory.SelectedValue) == "" || Convert.ToString(cmbUserCategory.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbUserCategory, "Please select employee category");
                    cmbUserCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUserCategory.ShowAlways = true;
                    tpUserCategory.Show("Please select employee category", cmbUserCategory, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
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
        private void udfnClear()
        {
            txtEmpCode.Text = "";
            txtEmpName.Text = "";
            txtEmployeeNameinTamil.Text = "";
            cmbUserCategory.SelectedIndex = 0;
            rbActive.Checked = true;
            btnSave.Text = "Save";
            txtEmpCode.Focus();
            this.ActiveControl = txtEmpCode;
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
                MainForm.objCP_EmployeeList.udfnList();
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
        private void CP_Employee_Load(object sender, EventArgs e)
        {
            try
            {
                txtEmpCode.Focus();
                this.ActiveControl = txtEmpCode;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                int varViewType = 3;
                if (btnSave.Text == "Save")
                {
                    varViewType = 2;
                }
                objDs = objdserv.udfnUserCategoryList(varViewType,PbUserCategoryID,"",0);
                objdserv.CloseConnection();
                cmbUserCategory.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbUserCategory.ValueMember = "CTID";
                            cmbUserCategory.DisplayMember = "CT_Name";
                            cmbUserCategory.DataSource = objDs.Tables[0];
                        }
                    }
                }
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                }
                else
                {
                    MainForm.objCP_EmployeeList.picLoader.Visible = false;
                    MainForm.objCP_EmployeeList.picLoader.SendToBack();
                    if (btnSave.Visible)
                    {
                        pnlStatus.Enabled = true;
                    }
                    udfnEditLoad();
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
        
        private void udfnEditLoad()
        {
            try
            {   
                txtEmpCode.Text = PbEmpCode;
                txtEmpName.Text = PbNameoftheUser;
                txtEmployeeNameinTamil.Text = pbempTName;
                cmbUserCategory.SelectedValue = PbUserCategoryID;
                if (PbStatus == 1) { rbActive.Checked = true; } else { rbInactive.Checked = true; }
                if(PbStatus==2)
                {
                    udfnDisable();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDisable()
        {
            txtEmpCode.Enabled = false;
            txtEmpName.Enabled = false;
            cmbUserCategory.Enabled = false;
            btnNew.Enabled = false;
            this.ActiveControl = rbInactive;
        }
        private void CP_Employee_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtUserName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEmpCode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEmpName.Focus();   
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbUserCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(pnlStatus.Enabled==true)
                    {
                        if(rbActive.Checked==true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInactive.Focus();
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
        private void CmbUserCategory_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbUserCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbUserCategory.SelectedValue) == "" || Convert.ToString(cmbUserCategory.SelectedValue) == "-1")
                {
                    epUser.SetError(cmbUserCategory, "Please select employee category");
                    cmbUserCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpUserCategory.ShowAlways = true;
                    tpUserCategory.Show("Please select employee category", cmbUserCategory, 5000);
                }
                else
                {
                    epUser.Clear();
                    cmbUserCategory.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbUserCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbUserCategory.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_UserCategory = new CP_UserCategory();
                MainForm.objCP_UserCategory.varmastertype = 1;
                MainForm.objCP_UserCategory.ShowDialog();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_UserCategory", " CT_STSID=1 and CTID !=0 Order by CTID", "CT_Name,CTID", cmbUserCategory, "", "CT_Name", "CTID");
                objDataBind = null;
                cmbUserCategory.SelectedValue = Convert.ToInt16(varCategoryCode);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void CP_Employee_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtDStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlStatus_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDUserCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDLoginID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmployeeNameinTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtEmployeeNameinTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEmployeeNameinTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbUserCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtEmployeeNameinTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtEmployeeNameinTamil.Text).Trim() == "")
                {
                    epUser.SetError(txtEmployeeNameinTamil, "Please enter employee name in tamil"); 
                    txtEmployeeNameinTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpempTname.ShowAlways = true;
                    tpempTname.Show("Please enter employee name in tamil", txtEmployeeNameinTamil, 5000); 
                }
                else
                {
                    epUser.Clear();
                    txtEmployeeNameinTamil.BackColor = Color.White;
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
