using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ROMS
{
    //Sathish  Created On :02/02/2026
    public partial class CP_Sales_Settings : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        Boolean BlnSearchImageYN = false;
        public string varconcernvalue="-1",varValues="-1";
        public int varsno = 0,varEditFlag=0;
        public string varSampleTransation = ""; int varId = 0;
        //tool tip
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        private ToolTip tpPrefix = new ToolTip();
        private ToolTip tpSuffix = new ToolTip();
        private ToolTip tpStartingNo = new ToolTip();
        private ToolTip tpResetOn = new ToolTip();
        private ToolTip tpNoofdigits = new ToolTip();
        public int MenuCode = 0;
        string privilege = "";
        List<(int MUP_Code, string EditAccess)> SpecialPermissions = new List<(int, string)>();
        public CP_Sales_Settings()
        {
            InitializeComponent();
            windowControl.Initialize(tsVoucherSettings, this);
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
            tpConcern.Active = false;
            tpTransactionType.Active = false;
            tpPrefix.Active = false;
            tpSuffix.Active = false;
            tpStartingNo.Active = false;
            tpResetOn.Active = false;
            cmbConcern.BackColor = Color.White;
            cmbTransactionType.BackColor = Color.White;
            txtPrefix.BackColor = Color.White;
            txtSuffix.BackColor = Color.White;
            txtStartingNo.BackColor = Color.White;
            cmbResetOn.BackColor = Color.White;
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
        public void udfnCmbTransaction()
        {
            try
            {
                if (btnUpdate.Text == "Save")
                {
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 12;
                    objMR_Master.paraID = Convert.ToInt32(cmbConcern.SelectedValue);
                    DataSet objDs = new DataSet();
                    SPDataService objdserv = new SPDataService();
                    objDs = objdserv.udfnMaster(objMR_Master);
                    objdserv.CloseConnection();
                    cmbTransactionType.DataSource = null;
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count > 0)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                cmbTransactionType.ValueMember = "MSTID";
                                cmbTransactionType.DisplayMember = "MST_DisplayText";
                                cmbTransactionType.DataSource = objDs.Tables[0];
                            }
                        }
                    }
                }
                if (btnUpdate.Text == "Update")
                {
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=14 OR MSTID=-1 ORDER BY MSTID,MST_DisplayText", "MSTID,MST_DisplayText", cmbTransactionType, "", "MST_DisplayText", "MSTID");
                    objDataBind = null;
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
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=14 OR MSTID=-1 ORDER BY MSTID,MST_DisplayText", "MSTID,MST_DisplayText", cmbTransactionType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=34 OR MSTID=-1  ORDER BY MSTID,MST_DisplayText", "MSTID,MST_DisplayText", cmbResetOn, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("MR_Company", "COMID NOT IN(0) ORDER BY COM_ShortName,COMID", "COMID,COM_ShortName", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnCompanyList(3, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                cmbConcern.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDs.Tables[0];
                        }
                    }
                }
                objDataBind = null;
                if (varValues == "38")
                {
                   this.ActiveControl =txtPrefix;
                }
                else
                {
                    this.ActiveControl = cmbConcern;
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
                picLoader.Visible = true;
                picLoader.BringToFront();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdSettings.DataSource = null;
                DataSet objDS = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDS = objdserv.udfnVoucherSettingList(0, 1);
                objdserv.CloseConnection();
                //cmbConcern.SelectedValue = varconcernvalue;
                //cmbTransactionType.SelectedValue = varValues;
                //grdSettings.Columns["clmConcernId"].Visible = false;
                //grdSettings.Columns["clmTransactionTypeID"].Visible = false;
                //grdSettings.Columns["clmResetOnId"].Visible = false;
                //grdSettings.Columns["clmNoofdigits"].Visible = false;
                //grdSettings.Columns["clmStartingNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //grdSettings.Columns["clmNoofdigits"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //grdSettings.Columns["clmsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
               
                txtFyyear.Text = Convert.ToString(objDS.Tables[1].Rows[0]["FY_financialYear"]);
                if (objDS != null)
                {
                    if (objDS.Tables.Count != 0)
                    {
                        //lblNoRecordsFound.Visible = false;
                        //if (objDS.Tables[0].Rows.Count != 0)
                        //{
                        //    for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                        //    {
                        //        grdSettings.Rows.Add(objDS.Tables[0].Rows[i]["S.No."], objDS.Tables[0].Rows[i]["Concern"], objDS.Tables[0].Rows[i]["TransactionType"], objDS.Tables[0].Rows[i]["Prefix"], objDS.Tables[0].Rows[i]["Suffix"],
                        //            objDS.Tables[0].Rows[i]["Strating No."], objDS.Tables[0].Rows[i]["No.of Digits"], objDS.Tables[0].Rows[i]["Reset On"], objDS.Tables[0].Rows[i]["Sample Transaction No."],
                        //             objDS.Tables[0].Rows[i]["Concern-ID"], objDS.Tables[0].Rows[i]["Transaction Type-ID"], objDS.Tables[0].Rows[i]["Reset On-ID"]);
                        //    }
                            
                        //}
                        //else
                        //{
                        //    lblNoRecordsFound.Visible = true;
                        //    lblNoRecordsFound.BringToFront();
                        //}
                        lblNoRecordsFound.Visible = false;
                        if (objDS.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdSettings.DataSource = objDS.Tables[0];
                            grdSettings.Columns["Strating No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdSettings.Columns["No.of Digits"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdSettings.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdSettings.Columns["S.No."].Width = 50;
                            grdSettings.Columns["Sample Transaction No."].Width =150;
                            grdSettings.Columns["Transaction Type"].Width =230;
                            grdSettings.Columns["Concern ID"].Visible = false;
                            grdSettings.Columns["No.of Digits"].Visible = false;
                            grdSettings.Columns["ID"].Visible = false;
                            grdSettings.Columns["Transaction TypeID"].Visible = false;
                            grdSettings.Columns["Reset OnID"].Visible = false;
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
                udfnSearchGridHead();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                picLoader.SendToBack();
                grdSettings.ClearSelection();
            }
        }
        private void CP_Settings_Load(object sender, EventArgs e)
        {
            try
            {
                MenuCode = 601;
                udfnCmbLoad();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                if (btnUpdate.Text == "Save")
                {
                    udfnCmbTransaction();
                }
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
                btnUpdate.Visible = privilege.Contains("2");
                btnUpdate.Visible = privilege.Contains("3");   
                udfnGridAccess();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridAccess()
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    grdSettings.Columns["clmEdit"].Visible = privilege.Contains("3");  
                    DGV_SearchGrid.Columns[0].Visible = privilege.Contains("3"); 
                }
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
                    btnUpdate.Focus();
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
                cmbConcern.BackColor = Color.LemonChiffon;
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
                    cmbTransactionType.Focus();
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
                if (Convert.ToString(cmbConcern.SelectedValue) == "0" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbConcern, "Please select concern.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern.", cmbConcern, 5000);
                }
                else
                {
                    epSettings.Clear();
                    cmbConcern.BackColor = Color.White;
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
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                udfnCmbTransaction();
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
        private void CmbTransactionType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPrefix.Focus();
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
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "0" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbTransactionType, "Please select transaction type.");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type.", cmbTransactionType, 5000);
                }
                else
                {
                    epSettings.Clear();
                    cmbTransactionType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPrefix_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPrefix.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPrefix_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtPrefix.Text.Trim() == "")
                //{
                //    epSettings.SetError(txtPrefix, "Please enter prefix.");
                //    txtPrefix.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPrefix.ShowAlways = true;
                //    tpPrefix.Show("Please enter prefix.", txtPrefix, 5000);
                //}
                //else
                //{
                //    epSettings.Clear();
                    txtPrefix.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPrefix_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSuffix.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSuffix_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSuffix.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSuffix_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtSuffix.Text.Trim() == "")
                //{
                    txtSuffix.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSuffix_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtStartingNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStartingNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStartingNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStartingNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtStartingNo.Text.Trim() == "")
                {
                    epSettings.SetError(txtStartingNo, "Please enter starting no.");
                    txtStartingNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStartingNo.ShowAlways = true;
                    tpStartingNo.Show("Please enter starting no.", txtStartingNo, 5000);
                }
                else
                {
                    epSettings.Clear();
                    txtStartingNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStartingNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbResetOn.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbResetOn_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbResetOn.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbResetOn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnUpdate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbResetOn_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbResetOn_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbResetOn.SelectedValue) == "0" || Convert.ToString(cmbResetOn.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbResetOn, "Please select reset on.");
                    cmbResetOn.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpResetOn.ShowAlways = true;
                    tpResetOn.Show("Please select reset on.", cmbResetOn, 5000);
                }
                else
                {
                    epSettings.Clear();
                    cmbResetOn.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbResetOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbResetOn.Select(int.MaxValue, 0)));
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
        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAdd_Click(sender, e);
                }
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
                if (Convert.ToString(cmbConcern.SelectedValue) == "0" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbConcern, "Please select concern.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern.", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "0" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbTransactionType, "Please select transaction type.");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type.", cmbTransactionType, 5000);
                    blnErrorFlag = true;
                }
                //if (txtPrefix.Text.Trim() == "")
                //{
                //    epSettings.SetError(txtPrefix, "Please enter prefix.");
                //    txtPrefix.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPrefix.ShowAlways = true;
                //    tpPrefix.Show("Please enter prefix.", txtPrefix, 5000);
                //    blnErrorFlag = true;
                //}
                if (txtStartingNo.Text.Trim() == "")
                {
                    epSettings.SetError(txtStartingNo, "Please enter starting no.");
                    txtStartingNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStartingNo.ShowAlways = true;
                    tpStartingNo.Show("Please enter starting no.", txtStartingNo, 5000);
                    blnErrorFlag = true;
                }
                //if (txtNoOfDegits.Text.Trim() == "")
                //{
                //    epSettings.SetError(txtNoOfDegits, "Please enter No.of digits.");
                //    txtNoOfDegits.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpNoofdigits.ShowAlways = true;
                //    tpNoofdigits.Show("Please enter No.of digits.", txtNoOfDegits, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(cmbResetOn.SelectedValue) == "0" || Convert.ToString(cmbResetOn.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbResetOn, "Please select reset on.");
                    cmbResetOn.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpResetOn.ShowAlways = true;
                    tpResetOn.Show("Please select reset on.", cmbResetOn, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    if (varEditFlag == 0)
                    {
                        udfnAdd();
                    }
                    else
                    {
                        udfnEdit();
                        varEditFlag = 0;
                    }
                }
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
                int varFlag = 0; int varConcern = 0; int varTransactionType = 0; string varStartingNum = ""; int varConcernId = 0;
                varConcern = Convert.ToInt32(cmbConcern.SelectedValue);
                varTransactionType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                for (int i = 0; i < grdSettings.Rows.Count; i++)
                {
                    if (varConcern == Convert.ToInt32(grdSettings.Rows[i].Cells["clmConcernId"].Value) && varTransactionType == Convert.ToInt32(grdSettings.Rows[i].Cells["clmTransactionTypeID"].Value))
                    {
                        varFlag = 1;
                        //for (int j = 0; j < grdSettings.Rows.Count; j++)
                        //{
                        //    if (varTransactionType == Convert.ToInt32(grdSettings.Rows[j].Cells["clmTransactionTypeID"].Value) && varConcernId == Convert.ToInt32(grdSettings.Rows[j].Cells["clmConcernId"].Value))
                        //    { varFlag = 1; }
                        //}
                    }
                }
                if (varFlag == 0)
                {
                    DataService objdservice = new DataService();
                   // varStartingNum = objdservice.displaydata("SELECT RIGHT('00000000'+ CONVERT(nvarchar,"+ txtStartingNo.Text.Trim()+ "),"+txtNoOfDegits.Text.Trim()+") AS sampleTransactionno FROM MR_VoucherSettings");
                    varSampleTransation = Convert.ToString(txtPrefix.Text.Trim()) + txtStartingNo.Text.Trim()+Convert.ToString(txtSuffix.Text.Trim());
                    grdSettings.Rows.Add(grdSettings.Rows.Count+1, cmbConcern.Text.Trim(), cmbTransactionType.Text.Trim(), txtPrefix.Text.Trim(), txtSuffix.Text.Trim(), txtStartingNo.Text.Trim(), "0", cmbResetOn.Text.Trim(),varSampleTransation,cmbConcern.SelectedValue,cmbTransactionType.SelectedValue,cmbResetOn.SelectedValue);
            
                    udfnClear();
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
            }
        }
        public void udfnEdit()
        {
            try
            {
                int varFlag = 0; int varConcern = 0; int varTransactionType = 0; string varStartingNum = ""; int varConcernId = 0;
                varConcern = Convert.ToInt32(cmbConcern.SelectedValue);
                varTransactionType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                for (int i = 0; i < grdSettings.Rows.Count; i++)
                {
                    if (varConcern == Convert.ToInt32(grdSettings.Rows[i].Cells["clmConcernId"].Value) && varTransactionType == Convert.ToInt32(grdSettings.Rows[i].Cells["clmTransactionTypeID"].Value) && varsno != Convert.ToInt32(grdSettings.Rows[i].Cells["clmsno"].Value))
                    {
                        varFlag = 1;
                        //for (int j = 0; j < grdSettings.Rows.Count; j++)
                        //{
                        //    if (varTransactionType == Convert.ToInt32(grdSettings.Rows[j].Cells["clmTransactionTypeID"].Value) && varConcernId == Convert.ToInt32(grdSettings.Rows[j].Cells["clmConcernId"].Value))
                        //    { varFlag = 1; }
                        //}
                    }
                }
                if (varFlag == 0)
                {
                    for (int i = 0; i < grdSettings.Rows.Count; i++)
                    {
                        if (varsno == Convert.ToInt32(grdSettings.Rows[i].Cells["clmsno"].Value))
                        {
                            DataService objdservice = new DataService();
                            // varStartingNum = objdservice.displaydata("SELECT RIGHT('00000000'+ CONVERT(nvarchar,"+ txtStartingNo.Text.Trim()+ "),"+txtNoOfDegits.Text.Trim()+") AS sampleTransactionno FROM MR_VoucherSettings");
                            varSampleTransation = Convert.ToString(txtPrefix.Text.Trim()) + txtStartingNo.Text.Trim() + Convert.ToString(txtSuffix.Text.Trim());
                            grdSettings.Rows[i].Cells["clmConcern"].Value = cmbConcern.Text.Trim();
                            grdSettings.Rows[i].Cells["clmConcern"].Value = cmbTransactionType.Text.Trim();
                            grdSettings.Rows[i].Cells["clmPrefix"].Value = txtPrefix.Text.Trim();
                            grdSettings.Rows[i].Cells["clmSuffix"].Value = txtSuffix.Text.Trim();
                            grdSettings.Rows[i].Cells["clmStartingNo"].Value = txtStartingNo.Text.Trim();
                            grdSettings.Rows[i].Cells["clmResetOn"].Value = cmbResetOn.Text.Trim();
                            grdSettings.Rows[i].Cells["clmSampleTransactionNo"].Value = varSampleTransation;
                            grdSettings.Rows[i].Cells["clmConcernId"].Value = varConcern;
                            grdSettings.Rows[i].Cells["clmTransactionTypeID"].Value = varTransactionType;
                            grdSettings.Rows[i].Cells["clmResetOnId"].Value = cmbResetOn.SelectedValue;
                            udfnClear();
                            goto L;
                        }
                    }
                L: int varTest = 0;
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
            }
            finally
            {
                cmbConcern.Enabled = true;
                cmbTransactionType.Enabled = true;
                btnAdd.Image = global::ROMS.Properties.Resources.plus;
            }
        }
        private void BtnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.LemonChiffon;
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
                btnUpdate.BackColor = Color.Transparent;
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
                epSettings.Clear();
                cmbTransactionType.SelectedValue = -1;
                txtPrefix.Text = "";
                txtSuffix.Text = "";
                txtStartingNo.Text = "";
                txtNoOfDegits.Text = "";
                cmbResetOn.SelectedValue = -1;
                cmbTransactionType.Focus();
                cmbConcern.Enabled = true;
                cmbTransactionType.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdSettings, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdSettings.Columns)
                {
                    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                int rowIndex = 0;
                DGV_SearchGrid.Rows.Clear();
                DGV_SearchGrid.Rows.Add();
                DGV_SearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                DGV_SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                for (int i = 2; i < visibleColumns.Count; i++)
                {
                    DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                }
                DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                DGV_SearchGrid.Columns[0].ReadOnly = true;
                DGV_SearchGrid.Columns[1].ReadOnly = true;
                DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                dgv2.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in dgv1.Columns)
                {
                    if (col.Visible)
                    {
                        dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                }
                int rowIndex = 0;
                int ColIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                BlnSearchImageYN = false;
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                    if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                    {
                        //dgv2.Rows[rowIndex].Visible = false;
                        BlnSearchImageYN = true;
                        ColIndex = i;
                        dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                        dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                        ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                    }
                    else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                    {
                        BlnSearchImageYN = true;
                        dgv2.Rows[rowIndex].Cells[i].Value = false;
                    }
                    else
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        public void udfnSave()
        {
            try
            {
                //if (grdSettings.Rows.Count != 0)
                //{
                //    DataTable objSettings = new DataTable();
                //    objSettings.TableName = "[MR_VoucherSettings]";
                //    objSettings.Columns.Add("STG_COMID", typeof(int));
                //    objSettings.Columns.Add("STG_TransactionType", typeof(int));
                //    objSettings.Columns.Add("STG_Prefix", typeof(string));
                //    objSettings.Columns.Add("STG_Sufix", typeof(string));
                //    objSettings.Columns.Add("STG_StartingNo", typeof(int));
                //    objSettings.Columns.Add("STG_SampleTransNo", typeof(string));
                //    objSettings.Columns.Add("STG_NoOfDigit", typeof(int));
                //    objSettings.Columns.Add("STG_ResetOn", typeof(int));
                //    for (int i = 0; i < grdSettings.Rows.Count; i++)
                //    {
                //        // objSettings.Rows.Add(grdSettings.Rows[i].Cells["HSN Name-New"].Value).Trim(), cmbTransactionType.SelectedValue, txtPrefix.Text, txtSuffix.Text, txtStartingNo.Text, txtNoOfDegits.Text, cmbResetOn.SelectedValue);
                //        objSettings.Rows.Add(Convert.ToInt32(grdSettings.Rows[i].Cells["clmConcernId"].Value), Convert.ToInt32(grdSettings.Rows[i].Cells["clmTransactionTypeID"].Value), Convert.ToString(grdSettings.Rows[i].Cells["clmPrefix"].Value).Trim(),
                //            Convert.ToString(grdSettings.Rows[i].Cells["clmSuffix"].Value).Trim(), Convert.ToInt32(grdSettings.Rows[i].Cells["clmStartingNo"].Value), Convert.ToString(grdSettings.Rows[i].Cells["clmSampleTransactionNo"].Value).Trim(), Convert.ToInt32(grdSettings.Rows[i].Cells["clmNoofdigits"].Value),
                //             Convert.ToInt32(grdSettings.Rows[i].Cells["clmResetOnId"].Value));
                //    }
                //    DataService objdservice = new DataService();
                //    // varStartingNum = objdservice.displaydata("SELECT RIGHT('00000000'+ CONVERT(nvarchar,"+ txtStartingNo.Text.Trim()+ "),"+txtNoOfDegits.Text.Trim()+") AS sampleTransactionno FROM MR_VoucherSettings");

                //    udfnClear();
                //    btnUpdate.Enabled = false;
                //    SPDataService objDSer = new SPDataService();
                //    varSampleTransation = Convert.ToString(txtPrefix.Text.Trim()) + txtStartingNo.Text.Trim() + Convert.ToString(txtSuffix.Text.Trim());
                //    result = objDSer.udfnVoucherSettings(0, Convert.ToInt32(cmbConcern.SelectedValue), Convert.ToInt32(cmbTransactionType.SelectedValue), Convert.ToString(txtPrefix.Text.Trim()), txtSuffix.Text.Trim(), 0, Convert.ToInt32(txtStartingNo.Text.Trim()), varSampleTransation, Convert.ToInt32(cmbResetOn.SelectedValue), varOriginator);
                //    objDSer.CloseConnection();
                //    btnUpdate.Enabled = true;
                //    string[] varvalue = result.Split('~');
                //    if (varvalue[0] == "3")
                //    {
                //        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        udfnClear();
                //        cmbConcern.SelectedIndex = 0;
                //        udfnToolTip();
                //        cmbConcern.Focus();
                //        cmbTransactionType.BackColor = Color.White;
                //        epSettings.Clear();
                //        udfnList();
                //    }
                //    else
                //    {
                //        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //}
                //else
                //{
                //    SPDataService objDServ = new SPDataService();
                //    string varMessage = objDServ.udfnGetMessages(64);
                //    objDServ.CloseConnection();
                //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                int varFlag = 0; int varConcern = 0; int varTransactionType = 0; string varStartingNum = ""; int varConcernId = 0;
                string result = "", varOriginator = "";
                int viewType = 0;
                SPDataService objspdservice = new SPDataService();
                varConcern = Convert.ToInt32(cmbConcern.SelectedValue);
                varTransactionType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                if (btnUpdate.Text == "Save")
                {
                    varOriginator = "VoucherSettings Save";
                    viewType = 0; varId = 0;
                    for (int i = 0; i < grdSettings.Rows.Count; i++)
                    {
                        if (varConcern == Convert.ToInt32(grdSettings.Rows[i].Cells["Concern ID"].Value) && varTransactionType == Convert.ToInt32(grdSettings.Rows[i].Cells["Transaction TypeID"].Value))
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
                    DataService objdservice = new DataService();
                    // varStartingNum = objdservice.displaydata("SELECT RIGHT('00000000'+ CONVERT(nvarchar,"+ txtStartingNo.Text.Trim()+ "),"+txtNoOfDegits.Text.Trim()+") AS sampleTransactionno FROM MR_VoucherSettings");
                    
                    btnUpdate.Enabled = false;
                    lblResetOn.Focus();
                    SPDataService objDSer = new SPDataService();
                    varSampleTransation = Convert.ToString(txtPrefix.Text.Trim()) + txtStartingNo.Text.Trim() + Convert.ToString(txtSuffix.Text.Trim());
                    result = objDSer.udfnVoucherSettings(viewType, Convert.ToInt32(cmbConcern.SelectedValue), Convert.ToInt32(cmbTransactionType.SelectedValue), Convert.ToString(txtPrefix.Text.Trim()), txtSuffix.Text.Trim(), 0, Convert.ToString(txtStartingNo.Text.Trim()), varSampleTransation, Convert.ToInt32(cmbResetOn.SelectedValue), varId, varOriginator, 1);
                    objDSer.CloseConnection();
                    btnUpdate.Enabled = true;
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnClear();
                        udfnToolTip();
                        epSettings.Clear();
                        udfnList();
                        btnUpdate.Text = "Save";
                        if(varEditFlag==1)
                        { cmbConcern.SelectedValue = MainForm.pbDefaultComId; }
                        varEditFlag = 0;
                        this.ActiveControl = cmbTransactionType;
                        cmbTransactionType.Focus();
                        BeginInvoke(new Action(() => cmbTransactionType.Select(int.MaxValue, 0)));
                        udfnCmbTransaction();
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
                btnUpdate.Focus();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(cmbConcern.SelectedValue) == "0" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbConcern, "Please select concern.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern.", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "0" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbTransactionType, "Please select transaction type.");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type.", cmbTransactionType, 5000);
                    blnErrorFlag = true;
                }
                //if (txtPrefix.Text.Trim() == "")
                //{
                //    epSettings.SetError(txtPrefix, "Please enter prefix.");
                //    txtPrefix.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpPrefix.ShowAlways = true;
                //    tpPrefix.Show("Please enter prefix.", txtPrefix, 5000);
                //    blnErrorFlag = true;
                //}
                if (txtStartingNo.Text.Trim() == "")
                {
                    epSettings.SetError(txtStartingNo, "Please enter starting no.");
                    txtStartingNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStartingNo.ShowAlways = true;
                    tpStartingNo.Show("Please enter starting no.", txtStartingNo, 5000);
                    blnErrorFlag = true;
                }
                //if (txtNoOfDegits.Text.Trim() == "")
                //{
                //    epSettings.SetError(txtNoOfDegits, "Please enter No.of digits.");
                //    txtNoOfDegits.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpNoofdigits.ShowAlways = true;
                //    tpNoofdigits.Show("Please enter No.of digits.", txtNoOfDegits, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(cmbResetOn.SelectedValue) == "0" || Convert.ToString(cmbResetOn.SelectedValue) == "-1")
                {
                    epSettings.SetError(cmbResetOn, "Please select reset on.");
                    cmbResetOn.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpResetOn.ShowAlways = true;
                    tpResetOn.Show("Please select reset on.", cmbResetOn, 5000);
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
                btnUpdate.Focus();
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
        private void GrdSettings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdSettings.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdSettings.Rows.RemoveAt(this.grdSettings.SelectedRows[0].Index);
                                for (int i = 0; i < grdSettings.RowCount; i++)
                                {
                                    grdSettings.Rows[i].Cells["clmsno"].Value = i + 1;
                                }
                            }
                            break;

                        case "clmEdit":
                            varEditFlag = 1;
                            btnUpdate.Text = "Update";
                            udfnCmbTransaction();
                            cmbConcern.SelectedValue=Convert.ToInt32(grdSettings.Rows[e.RowIndex].Cells["Concern ID"].Value);
                            //cmbTransactionType.Text = Convert.ToString(grdSettings.Rows[e.RowIndex].Cells["Transaction Type"].Value);
                            cmbTransactionType.SelectedValue=Convert.ToInt32(grdSettings.Rows[e.RowIndex].Cells["Transaction TypeID"].Value);
                            txtPrefix.Text = Convert.ToString(grdSettings.Rows[e.RowIndex].Cells["Prefix"].Value);
                            txtSuffix.Text = Convert.ToString(grdSettings.Rows[e.RowIndex].Cells["Suffix"].Value);
                            txtStartingNo.Text = Convert.ToString(grdSettings.Rows[e.RowIndex].Cells["Strating No."].Value);
                            cmbResetOn.SelectedValue = Convert.ToInt32(grdSettings.Rows[e.RowIndex].Cells["Reset OnID"].Value);
                            varsno = Convert.ToInt32(grdSettings.Rows[e.RowIndex].Cells["S.No."].Value);
                            varId = Convert.ToInt32(grdSettings.Rows[e.RowIndex].Cells["ID"].Value);
                            cmbConcern.Enabled = false;
                            cmbTransactionType.Enabled = false;
                            txtStartingNo.BackColor = Color.White;
                           // cmbTransactionType.SelectedValue = Convert.ToInt32(grdSettings.Rows[e.RowIndex].Cells["Transaction TypeID"].Value);
                            cmbResetOn.BackColor = Color.White;
                           // btnAdd.Image = global::ROMS.Properties.Resources.save;
                            txtPrefix.Focus();
                            epSettings.Clear();
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
        private void TxtNoOfDegits_Enter(object sender, EventArgs e)
        {
            try
            {
                txtNoOfDegits.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtNoOfDegits_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   cmbResetOn.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtNoOfDegits_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtNoOfDegits.Text.Trim() == "")
            //    {
            //        epSettings.SetError(txtNoOfDegits, "Please enter No.of digits.");
            //        txtNoOfDegits.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //        tpNoofdigits.ShowAlways = true;
            //        tpNoofdigits.Show("Please enter No.of digits.", txtNoOfDegits, 5000);
            //    }
            //    else
            //    {
            //        epSettings.Clear();
            //        txtNoOfDegits.BackColor = Color.White;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
        private void TxtStartingNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar)  && !char.IsControl(e.KeyChar))
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
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdSettings.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSettings);
                objDser.CloseConnection();
                grdSettings.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 0))   /*If not our desired columns*/
                                                                   //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewColumn newColumn = grdSettings.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdSettings.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdSettings.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                if (newColumn.GetType() != typeof(DataGridViewImageColumn))
                {
                    grdSettings.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_SearchGrid.HorizontalScrollingOffset = grdSettings.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdSettings.ColumnCount > 0)
                {
                    grdSettings.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdSettings.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdSettings.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSettings);
                objDser.CloseConnection();
                grdSettings.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdSettings.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdSettings);
                objDser.CloseConnection();
                grdSettings.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdSettings.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdSettings.Width > grdSettings.HorizontalScrollingOffset && grdSettings.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdSettings_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdSettings.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdSettings.Width > grdSettings.HorizontalScrollingOffset && grdSettings.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdSettings);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdCityList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
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

        private void DGV_SearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtNoOfDegits_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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

        private void GrdSettings_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            { grdSettings.ClearSelection(); }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
