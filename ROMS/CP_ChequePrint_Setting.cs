using DocumentFormat.OpenXml.VariantTypes;
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

namespace ROMS
{
    //Sivabharathi  Created On :25/09/2023
    public partial class CP_ChequePrint_Setting : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        Boolean BlnSearchImageYN = false;
        public string varconcernvalue="-1",varValues="-1";
        public int varsno = 0,varEditFlag=0;
        public string varSampleTransation = ""; int varId = 0;
        //tool tip
        private ToolTip tpBank = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        private ToolTip tpPrefix = new ToolTip();
        private ToolTip tpSuffix = new ToolTip();
        private ToolTip tpStartingNo = new ToolTip();
        private ToolTip tpResetOn = new ToolTip();
        private ToolTip tpNoofdigits = new ToolTip();
        public CP_ChequePrint_Setting()
        {
            InitializeComponent();
        }
        private void CP_Settings_Leave(object sender, EventArgs e)
        {
            try
            {
                udfnToolTip();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnToolTip()
        {
            tpBank.Active = false;
            tpTransactionType.Active = false;
            tpPrefix.Active = false;
            tpSuffix.Active = false;
            tpStartingNo.Active = false;
            tpResetOn.Active = false;
            cmbBank.BackColor = Color.White;
            cmbTemplate.BackColor = Color.White; 
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
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    MainForm objMainForm = new MainForm();
                    objMainForm.udfnCloseChildForms();
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
       
        public void udfnCmbLoad()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Bank", "BNK_STSID=1   ORDER BY BNKID, BNK_ShortName", "BNKID,BNK_ShortName", cmbBank, "", "BNK_ShortName", "BNKID"); 
                objDataBind.BindComboBoxListSelected("DEF_Cheque_Templates", "CQT_STSID=1  ORDER BY CQT_ImageName ", "CQTID,CQT_ImageName", cmbTemplate, "", "CQT_ImageName", "CQTID");
                objDataBind = null;
                cmbBank.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnList()
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
                grdChequePrint.ClearSelection();
            }
        }
        private void CP_Settings_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbLoad();
                cmbBank.SelectedValue = MainForm.pbDefaultComId; 
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Settings_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbConcern_Enter(object sender, EventArgs e)
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
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbTemplate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbBank.SelectedValue) == "0" || Convert.ToString(cmbBank.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbBank, "Please select bank.");
                    cmbBank.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBank.ShowAlways = true;
                    tpBank.Show("Please select bank.", cmbBank, 5000);
                }
                else
                {
                    epSettings.Clear();
                    cmbBank.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbBank.Select(int.MaxValue, 0))); 
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
                cmbTemplate.BackColor = Color.LemonChiffon;
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
                    btnPreview.Focus();
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
        private void CmbTransactionType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbTemplate.BackColor = Color.White;
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
        private void BtnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSave_Click(sender, e);
                }
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
        public void udfnSave()
        {
            try
            { 
                int varFlag = 0; int varConcern = 0; int varTransactionType = 0; string varStartingNum = ""; int varConcernId = 0;
                string result = "", varOriginator = "";
                int viewType = 0;
                SPDataService objspdservice = new SPDataService();
                varConcern = Convert.ToInt32(cmbBank.SelectedValue);
                varTransactionType = Convert.ToInt32(cmbTemplate.SelectedValue);
                if (btnSave.Text=="Save")
                {
                    varOriginator = "VoucherSettings Save";
                    viewType = 0; varId = 0;
                    for (int i = 0; i < grdChequePrint.Rows.Count; i++)
                    {
                        if (varConcern == Convert.ToInt32(grdChequePrint.Rows[i].Cells["Concern ID"].Value) && varTransactionType == Convert.ToInt32(grdChequePrint.Rows[i].Cells["Transaction TypeID"].Value))
                        {
                            varFlag = 1;
                        }
                    }
                }
                else
                {
                    varOriginator = "VoucherSettings Updation";
                    viewType = 1;
                }
                if (varFlag == 0)
                { 
                    btnSave.Enabled = true;
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        udfnToolTip();
                        epSettings.Clear();
                        udfnList();
                        btnSave.Text = "Save";
                        if(varEditFlag==1)
                        { cmbBank.SelectedValue = MainForm.pbDefaultComId; }
                        varEditFlag = 0;
                        this.ActiveControl = cmbTemplate;
                        cmbTemplate.Focus();
                        BeginInvoke(new Action(() => cmbTemplate.Select(int.MaxValue, 0))); 
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(63);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false; 
                if (blnErrorFlag == false)
                {
                    udfnSave();
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

        private void BtnPreview_Enter(object sender, EventArgs e)
        {
            try
            {
                btnPreview.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPreview_Leave(object sender, EventArgs e)
        {
            try
            {
                btnPreview.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string varImageName = "";
                varImageName = cmbTemplate.Text;
                if (varImageName != "")
                {
                    pbChequePreview.Image = Image.FromFile(Application.StartupPath + "\\ChequeTemplates\\" + varImageName);
                }
                else
                {
                    pbChequePreview.Image = null;
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
                btnAdd.BackColor = Color.Transparent;
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
                bool Addflag = false;
                epSettings.Clear();
                if (Convert.ToString(cmbBank.SelectedValue) == "0" || Convert.ToString(cmbBank.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbBank, "Please select bank.");
                    cmbBank.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBank.ShowAlways = true;
                    tpBank.Show("Please select bank.", cmbBank, 5000);
                    Addflag = true;
                }
                if (Addflag == false)
                { udfnAdd(); }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAdd()
        {
            try
            {
                grdChequePrint.Rows.Add(grdChequePrint.Rows.Count+1,Convert.ToString(cmbBank.Text), Convert.ToString(cmbTemplate.Text), Convert.ToString(cmbBank.SelectedValue), Convert.ToString(cmbTemplate.SelectedValue));
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
                if (e.KeyCode == Keys.Enter)
                {
                    BtnClose_Click(sender, e);
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
