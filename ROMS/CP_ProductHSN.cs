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
    // Sivabharathi    Create date: 09/08/2023    
    public partial class CP_ProductHSN : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;

        public string varcompanycode;
        public string pbFormStatus;
        public int vargstcode = 0;
        public string varHsnname="";
        public string varHsnCode="";
        public int varGstId=-1;
        public int varId = 0;
        public int varStatusid = 1;
        public int varCloseFlag = 0;
        //tool tip
        private ToolTip tpHsnName = new ToolTip();
        private ToolTip tpHsnCode = new ToolTip();
        private ToolTip tpGst = new ToolTip();
      
        public CP_ProductHSN()
        {
            InitializeComponent();
        }
        private void CP_ProductHSN_Leave(object sender, EventArgs e)
        {
            try
            {
                tpHsnName.Active = false;
                tpHsnCode.Active = false;
                tpGst.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

       
        private void CP_ProductHSN_Load(object sender, EventArgs e)
        {
            try
            {
                udfnLoadCmbGst();
                if (btnSave.Text == "Save")
                {
                    pnlStatus.Enabled = false;
                    varCloseFlag = 0;
                }
                else
                {
                    pnlStatus.Enabled = true;
                    udfnEdit();
                }
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
                btnClose.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtHSNName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtHSNName.Text.Trim() == "")
                {
                    epHsn.SetError(txtHSNName, "Please enter HSN name.");
                    txtHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnName.ShowAlways = true;
                    tpHsnName.Show("Please enter HSN name.", txtHSNName, 5000);
                }
                else
                {
                    epHsn.Clear();
                    txtHSNName.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtHSNCode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtHSNCode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtHSNCode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtHSNCode.Text.Trim() == "")
                {
                    epHsn.SetError(txtHSNCode, "Please enter HSN code.");
                    txtHSNCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnCode.ShowAlways = true;
                    tpHsnCode.Show("Please enter HSN code.", txtHSNCode, 5000);
                }
                else
                {
                    epHsn.Clear();
                    txtHSNCode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGST.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGST_KeyPress(object sender, KeyPressEventArgs e)
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

        public void udfnLoadCmbGst()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_GST", " GSTID  not in (0)", "GST_Text,GSTID", cmbGST, "", "GST_Text", "GSTID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGST_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbGST.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGST_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGST.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGST_Leave(object sender, EventArgs e)
        {
            if (Convert.ToString(cmbGST.SelectedValue) == "0" || Convert.ToString(cmbGST.SelectedValue) == "-1")
            {
                epHsn.SetError(cmbGST, "Please select GST.");
                cmbGST.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpGst.ShowAlways = true;
                tpGst.Show("Please select GST.", cmbGST, 5000);
            }
            else
            {
                epHsn.Clear();
                cmbGST.BackColor = Color.White;
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
        private void CmbGST_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled)
                    {
                        rbActive.Focus();
                    }
                    else { btnSave.Focus(); }
                }
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
                txtHSNName.Text = "";
                txtHSNCode.Text = "";
                cmbGST.SelectedIndex = 0;
                txtHSNName.Focus();
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
                txtHSNName.Text = varHsnname;
                txtHSNCode.Text = varHsnCode;
                cmbGST.SelectedValue = varGstId;
                if (varStatusid == 1)
                {
                    rbActive.Checked = true;
                }
                else
                {
                    rbInActive.Checked = true;
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
                string varResult = "";
               if (rbActive.Checked)
               {
                    varStatusid = 1;
               }
               else
               {
                    varStatusid = 2;
               }
               SPDataService objDser = new SPDataService();
               if (btnSave.Text == "Save")
               {
                    varResult = objDser.udfnHsn(0, 0, Convert.ToInt16(cmbGST.SelectedValue), Convert.ToString(txtHSNName.Text), Convert.ToString(txtHSNCode.Text), varStatusid, "HSN Creation");
               }
               else
               {
                    varResult = objDser.udfnHsn(1, Convert.ToInt16(varId), Convert.ToInt16(cmbGST.SelectedValue), Convert.ToString(txtHSNName.Text), Convert.ToString(txtHSNCode.Text), varStatusid, "HSN Updation");
               }
                objDser.CloseConnection();
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnSave.Text == "Save")
                    {
                        udfnClear();
                    }
                    else
                    {
                        varCloseFlag = 1;
                        udfnclose();
                    }
                    MainForm.objCP_ProductHSNlist.udfnList();
                }
                else if(varResult.Split('~')[0] == "4")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(cmbGST.SelectedValue) == "0" || Convert.ToString(cmbGST.SelectedValue) == "-1")
                {
                    epHsn.SetError(cmbGST, "Please select GST.");
                    cmbGST.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGst.ShowAlways = true;
                    tpGst.Show("Please select GST.", cmbGST, 5000);
                    blnErrorFlag = true;
                }
                if (txtHSNName.Text.Trim() == "")
                {
                    epHsn.SetError(txtHSNName, "Please enter HSN name.");
                    txtHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnName.ShowAlways = true;
                    tpHsnName.Show("Please enter HSN name.", txtHSNName, 5000);
                    blnErrorFlag = true;
                }
                if (txtHSNCode.Text.Trim() == "")
                {
                    epHsn.SetError(txtHSNCode, "Please enter HSN code.");
                    txtHSNCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpHsnCode.ShowAlways = true;
                    tpHsnCode.Show("Please enter HSN code.", txtHSNCode, 5000);
                    blnErrorFlag = true;
                }
               
                if (blnErrorFlag == false)
                {
                    udfnSave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
          
        }
        private void CP_ProductHSN_KeyDown(object sender, KeyEventArgs e)
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
                rbInActive.BackColor = Color.LemonChiffon;
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

        private void BtnSave_Leave(object sender, EventArgs e)
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

        private void CP_ProductHSN_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled)
                    {
                        btnSave.Focus();
                    }
                    else { btnSave.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled)
                    {
                        btnSave.Focus();
                    }
                    else { btnSave.Focus(); }
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


    