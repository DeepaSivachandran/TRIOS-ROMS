using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;


namespace ROMS
{
    //Created By:-Sathish ; Created On:-11-08-2023
    public partial class CP_Rate_Category : Form
    {
        DataError objError;
        private ToolTip tpcode = new ToolTip();
        private ToolTip tppreftname = new ToolTip(); 
        private ToolTip tpprefename = new ToolTip(); 
        private ToolTip tpsuftname = new ToolTip(); 
        private ToolTip tpsufename = new ToolTip(); 
        public string pbFormStatus; 
        public string pbBankName = ""; 
        public string pbBankShortName = ""; 
        public int PbId=0; 
        public int varUpdate = 0;
        public int varmastertype = 0;
        public int varflag = 0;
        public int varBankId = 0;
        public CP_Rate_Category()
        {
            InitializeComponent();
        }

        private void txtPrefixCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPreTam.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPrefixCode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPrefixCode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPrefixCode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPrefixCode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPreTam_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPreEng.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPreTam_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPreTam.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPreTam_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPreTam.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPreEng_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPreEng.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPreEng_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSufTam.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtPreEng_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPreEng.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSufTam_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSufTam.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSufTam_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSufEng.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSufTam_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSufTam.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSufEng_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSufEng.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSufEng_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReason.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSufEng_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSufEng.BackColor = Color.LemonChiffon;
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
                var ErrorFlag = false;
                if (txtPrefixCode.Text.Trim() == "")
                {
                    epRateChange.SetError(txtPrefixCode, "Please enter prefix Code.");
                    txtPrefixCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcode.ShowAlways = true;
                    tpcode.Show("Please enter prefix Code.", txtPrefixCode, 5000);
                    ErrorFlag = true;
                }
                else if (txtPreTam.Text.Trim() == "")
                {
                    epRateChange.SetError(txtPreTam, "Please enter prefix text tamil.");
                    txtPreTam.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppreftname.ShowAlways = true;
                    tppreftname.Show("Please enter prefix text tamil.", txtPreTam, 5000);
                    ErrorFlag = true;
                }
                else if (txtPreEng.Text.Trim() == "")
                {
                    epRateChange.SetError(txtPreEng, "Please enter prefix text english.");
                    txtPreEng.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpprefename.ShowAlways = true;
                    tpprefename.Show("Please enter prefix text english.", txtPreEng, 5000);
                    ErrorFlag = true;
                }

                else if (txtSufTam.Text.Trim() == "")
                {
                    epRateChange.SetError(txtSufTam, "Please enter suffix text tamil.");
                    txtSufTam.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpsuftname.ShowAlways = true;
                    tpsuftname.Show("Please enter suffix text tamil.", txtSufTam, 5000);
                    ErrorFlag = true;
                }
                else if (txtSufEng.Text.Trim() == "")
                {
                    epRateChange.SetError(txtSufEng, "Please enter suffix text english.");
                    txtSufEng.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpsufename.ShowAlways = true;
                    tpsufename.Show("Please enter prefix text english.", txtSufEng, 5000);
                    ErrorFlag = true;
                }



                if (ErrorFlag == false) {

                    txtPrefixCode.BackColor = Color.White;
                    txtPreTam.BackColor = Color.White;
                    txtPreEng.BackColor = Color.White;
                    txtSufTam.BackColor = Color.White;
                    txtSufEng.BackColor = Color.White;
                    txtReason.BackColor = Color.White;
                    epRateChange.Clear();
                    udfnSave();
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

        public void ClearFields()
        {
            try
            {
                txtPrefixCode.Text = "";
                txtPreTam.Text = "";
                txtPreEng.Text = "";
                txtSufTam.Text = "";
                txtSufEng.Text = "";
                txtReason.Text = "";
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
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Rate Category Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Rate Category Updation";
                    varType = 1;
                }
                 

                MR_Product obj = new MR_Product();
                obj.paraViewType = varType;
                obj.paraprefixcode = txtPrefixCode.Text.Trim();
                obj.paraprefixtname = txtPreTam.Text.Trim();
                obj.paraprefixename = txtPreEng.Text.Trim();
                obj.parasuffixtname = txtSufTam.Text.Trim();
                obj.parasuffixename = txtSufEng.Text.Trim();
                obj.paradescription = txtReason.Text.Trim();
                obj.paraId = PbId;
                obj.paraOriginator = varoriginator;

                varResult = objspservice.udfnRateCategory(obj);
                objspservice.CloseConnection();

                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Rate_CategoryList.udfnList();
                    if (btnSave.Text == "Save")
                    {
                        ClearFields();
                        this.ActiveControl = txtPrefixCode;
                    }
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        ClearFields();
                        udfnclose();
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

        private void txtReason_Enter(object sender, EventArgs e)
        {
            try
            {
                txtReason.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtReason_Leave(object sender, EventArgs e)
        {
            try
            {
                txtReason.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Rate_Category_Load(object sender, EventArgs e)
        {
            try
            {

                MainForm.objCP_Rate_CategoryList.picLoader.Visible = false;
                MainForm.objCP_Rate_CategoryList.picLoader.SendToBack();
                this.ActiveControl = txtPrefixCode;
                if (PbId != 0)
                {
                    udfnedit();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnedit()
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                MR_Product obj = new MR_Product();
                DataSet ds = new DataSet();
                obj.paraViewType = 1;
                obj.paraId = PbId;
                ds = objspservice.udfnRateCategoryList(obj);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPrefixCode.Text = ds.Tables[0].Rows[0]["PrefixCode"].ToString();
                    txtPreTam.Text = ds.Tables[0].Rows[0]["PrefixTName"].ToString();
                    txtPreEng.Text = ds.Tables[0].Rows[0]["PrefixEName"].ToString();
                    txtSufTam.Text = ds.Tables[0].Rows[0]["SuffixTName"].ToString();
                    txtSufEng.Text = ds.Tables[0].Rows[0]["SuffixEName"].ToString();
                    txtReason.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                objspservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Rate_Category_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CP_Rate_Category_KeyDown(object sender, KeyEventArgs e)
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

        private void btnSave_Enter(object sender, EventArgs e)
        {
            try {
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
    }
}
