using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ROMS
{
    //Sivabharathi  Created On :25/09/2023
    public partial class CP_ChequePrint_Setting : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        public DataTable dtTemplateDetails;
        DataTable dtChequePrintSetting = new DataTable();
        private ToolTip tpBank = new ToolTip();
        public string varImageName = "", varBankID="0";
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public CP_ChequePrint_Setting()
        {
            InitializeComponent();
            windowControl.Initialize(tsChequePrintSettings, this);
        }
        private void CP_Settings_Leave(object sender, EventArgs e)
        {
            try
            {
                tpBank.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnToolTip()
        { 
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
                    //MainForm objMainForm = new MainForm();
                    //objMainForm.udfnCloseChildForms();
                    //MainForm.objStart = new DEF_Start();
                    //MainForm.objStart.MdiParent = this.ParentForm;
                    //MainForm.objStart.Show();
                    //this.Close();
                    windowControl?.TriggerClose();
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
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Bank", "BNK_STSID=1  AND BNKID NOT IN (" + varBankID + ") ORDER BY BNKID , BNK_ShortName", "BNKID,BNK_ShortName", cmbBank, "", "BNK_ShortName", "BNKID");
                objDataBind = null;
                cmbBank.SelectedValue = -1; 
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
                udfnBankDropDownLoad();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Bank", "BNK_STSID=1  AND BNKID NOT IN ("+ varBankID + ") ORDER BY BNKID , BNK_ShortName", "BNKID,BNK_ShortName", cmbBank, "", "BNK_ShortName", "BNKID");
                objDataBind = null;
                cmbBank.SelectedValue = -1;

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                Model.MR_ChequeTransactionSettings objMR_ChequeTransactionSettings = new Model.MR_ChequeTransactionSettings();
                objMR_ChequeTransactionSettings.paraViewType = 0;
                objDs = objspservice.udfnChequePrintSettingsList(objMR_ChequeTransactionSettings);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbTemplate.ValueMember = "CQTID";
                            cmbTemplate.DisplayMember = "TemplateName";
                            cmbTemplate.DataSource = objDs.Tables[0];
                            dtTemplateDetails = objDs.Tables[0];
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
        public void udfnList()
        {
            try
            {
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                Model.MR_ChequeTransactionSettings objMR_ChequeTransactionSettings = new Model.MR_ChequeTransactionSettings();
                objMR_ChequeTransactionSettings.paraViewType = 1;
                objDs = objspservice.udfnChequePrintSettingsList(objMR_ChequeTransactionSettings);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            grdChequePrint.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[0].Rows[i]["Bank"]), Convert.ToString(objDs.Tables[0].Rows[i]["TemplateName"]), Convert.ToString(objDs.Tables[0].Rows[i]["ImageName"]), Convert.ToString(objDs.Tables[0].Rows[i]["BankID"]),
                                Convert.ToString(objDs.Tables[0].Rows[i]["TemplateID"] )  , Convert.ToString(objDs.Tables[0].Rows[i]["ID"])    );
                            if (varBankID == "0")
                            {
                                varBankID = Convert.ToString(objDs.Tables[0].Rows[i]["BankID"]);
                            }
                            else
                            {
                                varBankID = varBankID + "," + Convert.ToString(objDs.Tables[0].Rows[i]["BankID"]);
                            }
                        }
                    }
                    udfnBankDropDownLoad();
                }

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
                MenuCode = 604;
                udfnDropDownLoad(); 
                cmbBank.SelectedValue = MainForm.pbDefaultComId;
                dtChequePrintSetting.TableName = "MR_ChequePrintSettings";
                dtChequePrintSetting.Columns.Add("CQS_CQTID", typeof(int));
                dtChequePrintSetting.Columns.Add("CQS_BNKID", typeof(int)); 
                udfnList();
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    udfnFieldAccess();
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFieldAccess()
        {
            try
            {
                var result = UserAccessHelper.LoadUserAccess(MenuCode);
                privilege = result.PrivilegeCode;
                SpecialPermissions = result.SpecialPermissions;
                btnSave.Visible = privilege.Contains("3"); 
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
                string varResult = "";   
                for(int i=0;i<grdChequePrint.RowCount;i++)
                {
                    dtChequePrintSetting.Rows.Add(Convert.ToInt16(grdChequePrint.Rows[i].Cells["clmTemplateID"].Value), Convert.ToInt16(grdChequePrint.Rows[i].Cells["clmBankId"].Value));
                }
                SPDataService objspservice = new SPDataService();
                Model.MR_ChequeTransactionSettings objMR_ChequeTransactionSettings = new Model.MR_ChequeTransactionSettings();
                objMR_ChequeTransactionSettings.paraViewType = 0; 
                objMR_ChequeTransactionSettings.paraOriginator = "Cheque print settings save"; 
                objMR_ChequeTransactionSettings.paraMR_ChequePrintSettings = dtChequePrintSetting; 
                varResult = objspservice.udfnChequePrintSettings(objMR_ChequeTransactionSettings);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if(grdChequePrint.Rows.Count==0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(156);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
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
                udfnGetImageName();
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
                udfnGetImageName();
                int count = grdChequePrint.Rows.Cast<DataGridViewRow>()
                .Count(r => !r.IsNewRow
                     && Convert.ToInt32(r.Cells["clmBankId"].Value) == Convert.ToInt32(cmbBank.SelectedValue)
                  && Convert.ToInt32(r.Cells["clmTemplateID"].Value) == Convert.ToInt32(cmbTemplate.SelectedValue));

                if (count == 0)
                {
                    grdChequePrint.Rows.Add(grdChequePrint.Rows.Count + 1, Convert.ToString(cmbBank.Text), Convert.ToString(cmbTemplate.Text), varImageName, Convert.ToString(cmbBank.SelectedValue), Convert.ToString(cmbTemplate.SelectedValue));
                    varImageName = ""; 
                    if (varBankID == "0")
                    {
                        varBankID = Convert.ToString(cmbTemplate.SelectedValue);
                    }
                    else
                    {
                        varBankID = varBankID + "," + Convert.ToString(cmbTemplate.SelectedValue);  
                    }
                    udfnBankDropDownLoad();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(97);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGetImageName()
        {
            try
            {
                varImageName = "";
                var result = dtTemplateDetails.AsEnumerable()
                .Where(b => b.Field<int>("CQTID") == Convert.ToInt32(cmbTemplate.SelectedValue))
                .Select(b => b.Field<string>("ImageName"))
                .Where(img => !string.IsNullOrEmpty(img))
                .ToList();
                varImageName = result[0];
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
         
        private void GrdChequePrint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.RowIndex != -1)
                {
                    switch (grdChequePrint.Columns[e.ColumnIndex].Name)
                    { 
                        case "clmPreview":
                            string ImageName = "";
                            ImageName = Convert.ToString(grdChequePrint.Rows[e.RowIndex].Cells["clmImageName"].Value);
                            if (varImageName != "")
                            {
                                pbChequePreview.Image = Image.FromFile(Application.StartupPath + "\\ChequeTemplates\\" + clmImageName);
                            }
                            else
                            {
                                pbChequePreview.Image = null;
                            }
                            break;
                        case "clmRemove":
                            DialogResult response = MessageBox.Show("Do you want to remove?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                            int varBankId = 0;
                            varBankId = Convert.ToInt16(grdChequePrint.Rows[e.RowIndex].Cells["clmBankId"].Value);
                            var ids = varBankID.Split(',')  .Select(id => int.Parse(id.Trim()))  .ToList();

                            if (ids.Contains(varBankId))
                            {
                                ids.Remove(varBankId);
                                varBankID = string.Join(",", ids);
                            }
                            if (varBankID == "") { varBankID = "0"; }
                            if ((response == DialogResult.Yes))
                            {
                                grdChequePrint.Rows.RemoveAt(e.RowIndex); 
                            }
                            udfnBankDropDownLoad();
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
    }
}
