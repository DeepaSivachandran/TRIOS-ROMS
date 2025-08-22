using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;

namespace ROMS
{
    public partial class CP_GeneralSettings : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpcashpurchase = new ToolTip();
        private ToolTip tpLPRate = new ToolTip();
        private ToolTip tpBillAmount = new ToolTip();
        private ToolTip tpGRNQty = new ToolTip();
        private ToolTip tpReturnAlertDays = new ToolTip();
        private ToolTip tpInvoiceEditDays = new ToolTip();
        private ToolTip tpbackuppath = new ToolTip();
        private ToolTip tpPerLevel1 = new ToolTip();
        private ToolTip tpPerLevel2 = new ToolTip();
        private ToolTip tpVerificationDays = new ToolTip();
        private ToolTip tpAgingMonths = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        private ToolTip tpReportText = new ToolTip();
        DataSet objDs = new DataSet();
        public int varSettingID = 0;
        public int varBillAmnt = 0;
        public CP_GeneralSettings()
        {
            InitializeComponent();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
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
        public void udfnTurnAroundTimeLoad()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 0;
                objMR_Master.paraID = 13;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            grdOrderType.DataSource = objDs.Tables[0];
                            grdOrderType.Columns["MSTID"].Visible = false;
                            grdOrderType.Columns["MST_TransactionName"].Visible = false;
                            grdOrderType.Columns["MST_TransactionID"].Visible = false;
                            grdOrderType.Columns["clmDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnGeneralSettingList(0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            varSettingID = Convert.ToInt32(objDs.Tables[0].Rows[0]["GSID"]);
                            txtcashpurchase.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_CPA"]);
                            txtBillAmount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_DVA"]);
                            varBillAmnt= Convert.ToInt32(objDs.Tables[0].Rows[0]["GS_DVA"]);
                            txtGRNQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_GRNQty"]);
                            txtReturnAlertDays.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_RAD"]);
                            txtInvoiceEditDays.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_IED"]);
                            txtbackuppath.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_DBPath"]);
                            txtPerLevel1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_Level1"]);
                            txtPerLevel2.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_Level2"]);
                            txtVerificationDays.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_VerificationDays"]);
                            txtMonths.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_Aging_Months"]);
                            txtLPRate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_LPRatePer"]);
                            txtRTGSMinLimit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RTGSMinLimit"]);

                            if (Convert.ToString(objDs.Tables[0].Rows[0]["GS_POStockenable"]) == "1")
                            {
                                rbYes.Checked = true;
                            }
                            else
                            {
                                rbNo.Checked = true;
                            }
                            if(Convert.ToString(objDs.Tables[0].Rows[0]["GS_GRNPrint"]) == "1")
                            {
                                chkGRNPrint.Checked = true;
                            }
                            else
                            {
                                chkGRNPrint.Checked = false;
                            }
                            if (Convert.ToString(objDs.Tables[0].Rows[0]["GS_DCPrint"]) == "1")
                            {
                                chkDCPrint.Checked = true;
                            }
                            else
                            {
                                chkDCPrint.Checked = false;
                            }
                            if (Convert.ToString(objDs.Tables[0].Rows[0]["GS_RCStockShow"]) == "1")
                            {
                                chkRCStockShow.Checked = true;
                            }
                            else
                            {
                                chkRCStockShow.Checked = false;
                            }
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            grdOrderType.DataSource = objDs.Tables[1];
                            grdOrderType.Columns["Order_TypeID"].Visible = false;
                            ((DataGridViewTextBoxColumn)grdOrderType.Columns["Days"]).MaxInputLength = 3;
                            grdOrderType.Columns["Days"].DefaultCellStyle.BackColor = Color.PaleGreen;
                            grdOrderType.Columns["Days"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdOrderType.Columns["Days"].Width = 50;
                            grdOrderType.Columns["Order Type"].ReadOnly = true;
                        }
                        if (objDs.Tables[2].Rows.Count != 0)
                        {
                            for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                            {
                                grdReport.Rows.Add(Convert.ToString(objDs.Tables[2].Rows[i]["Transaction"]),Convert.ToString(objDs.Tables[2].Rows[i]["Report Text"]), objDs.Tables[2].Rows[i]["TransactionID"] );
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
        public void udfnUpdate()
        {
            try
            {
                epGeneralSettings.Clear();
                string varResult = "";
                int Varflagstock = 0;
                decimal varRTGSMinLimit = 0;
                btnUpdate.Enabled = false; lblReportname.Focus();
                 SPDataService objDser = new SPDataService();
                string varOriginator = "GeneralSettings Updation";
                SPDataService objspdservice = new SPDataService();
                DataTable objGeneralSettings = new DataTable();
                DataTable objGeneralSettingsRPT = new DataTable();
                DataTable objRE = new DataTable();
                objGeneralSettings.TableName = "[MR_GeneralSettings_TAT]";
                objGeneralSettings.Columns.Add("GSTAT_GSID", typeof(int));
                objGeneralSettings.Columns.Add("GSTAT_OrderType", typeof(int));
                objGeneralSettings.Columns.Add("GSTAT_OrderDays", typeof(int));

                objGeneralSettingsRPT.TableName = "[MR_GeneralSettings_RPTText]";
                objGeneralSettingsRPT.Columns.Add("GSRPT_GSID", typeof(int));
                objGeneralSettingsRPT.Columns.Add("GSRPT_MSTID", typeof(int));
                objGeneralSettingsRPT.Columns.Add("GSRPT_Text", typeof(string));

                if (rbYes.Checked==true)
                {
                    Varflagstock = 1;
                }
                for (int i = 0; i < grdReport.Rows.Count; i++)
                {
                    objGeneralSettingsRPT.Rows.Add(varSettingID, Convert.ToInt32(grdReport.Rows[i].Cells["clmTransactionID"].Value), Convert.ToString(grdReport.Rows[i].Cells["clmReportText"].Value).Trim());
                }
                for (int i=0;i<grdOrderType.Rows.Count;i++)
                {
                    objGeneralSettings.Rows.Add(varSettingID,Convert.ToInt32(grdOrderType.Rows[i].Cells["Order_TypeID"].Value), Convert.ToInt32(grdOrderType.Rows[i].Cells["Days"].Value));
                }
                int varGRNCheck = 0, varDCCheck = 0, varRCCheck = 0;
                if(chkGRNPrint.Checked==true)
                {
                    varGRNCheck = 1;
                }
                if(chkDCPrint.Checked==true)
                {
                    varDCCheck = 1;
                }
                if(txtRTGSMinLimit.Text.Trim()!="")
                {
                    varRTGSMinLimit =Convert.ToDecimal(txtRTGSMinLimit.Text);
                }
                if (chkRCStockShow.Checked == true)
                {
                    varRCCheck = 1;
                }
                varResult = objDser.udfnGeneralSettings(0, varSettingID, Convert.ToDecimal(txtcashpurchase.Text), Convert.ToDecimal(txtBillAmount.Text), Convert.ToInt32(txtGRNQty.Text), Convert.ToInt32(txtReturnAlertDays.Text), Convert.ToInt32(txtInvoiceEditDays.Text), objGeneralSettings, objGeneralSettingsRPT, varOriginator, Varflagstock, txtbackuppath.Text, varGRNCheck, varDCCheck, Convert.ToInt32(txtPerLevel1.Text), Convert.ToInt32(txtPerLevel2.Text), Convert.ToInt32(txtVerificationDays.Text),Convert.ToInt32(txtMonths.Text),Convert.ToDecimal(txtLPRate.Text), varRTGSMinLimit, varRCCheck); 
                objDser.CloseConnection();
                btnUpdate.Enabled = true;
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (varResult.Split('~')[0] == "4")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnUpdate.Focus();
                }
                grdReport.Rows.Clear();
                udfnList();
                MainForm objMainForm = new MainForm();
                objMainForm.udfnShelflifeLevel();
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
        private void CP_GeneralSettings_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=49 OR MSTID=-1 ORDER BY MSTID,MST_DisplayText", "MSTID,MST_DisplayText", cmbTransactionType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                //udfnTurnAroundTimeLoad();
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_GeneralSettings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    BtnUpdate_Click(sender, e);
                    btnUpdate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtcashpurchase_Enter(object sender, EventArgs e)
        {
            try
            {
                txtcashpurchase.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtcashpurchase_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtcashpurchase.Text).Trim() == "")
                {
                    epGeneralSettings.SetError(txtcashpurchase, "Please enter amount.");
                    txtcashpurchase.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcashpurchase.ShowAlways = true;
                    tpcashpurchase.Show("Please enter amount.", txtcashpurchase, 5000);
                }
                else
                {
                    epGeneralSettings.Clear();
                    txtcashpurchase.BackColor = Color.White;
                }
                //try
                //{
                //    txtcashpurchase.BackColor = Color.White;
                //}
                //catch (Exception ex)
                //{
                //    objError = new DataError();
                //    objError.WriteFile(ex);
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtcashpurchase_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBillAmount.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBillAmount_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBillAmount.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBillAmount_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    txtBillAmount.BackColor = Color.White;
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            if (Convert.ToString(txtBillAmount.Text).Trim() == "")
            {
                epGeneralSettings.SetError(txtBillAmount, "Please enter amount.");
                txtBillAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpBillAmount.ShowAlways = true;
                tpBillAmount.Show("Please enter amount.", txtBillAmount, 5000);
            }
            else
            {
                epGeneralSettings.Clear();
                txtBillAmount.BackColor = Color.White;
            }
        }
        private void TxtBillAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGRNQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGRNQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGRNQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGRNQty_Leave(object sender, EventArgs e)
        {
            if (Convert.ToString(txtGRNQty.Text).Trim() == "")
            {
                epGeneralSettings.SetError(txtGRNQty, "Please enter quantity.");
                txtGRNQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpGRNQty.ShowAlways = true;
                tpGRNQty.Show("Please enter quantity.", txtGRNQty, 5000);
            }
            else
            {
                epGeneralSettings.Clear();
                txtGRNQty.BackColor = Color.White;
            }
        }
        private void TxtGRNQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReturnAlertDays.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtReturnAlertDays_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceEditDays.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtReturnAlertDays_Enter(object sender, EventArgs e)
        {
            try
            {
                txtReturnAlertDays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtReturnAlertDays_Leave(object sender, EventArgs e)
        {
            if (Convert.ToString(txtReturnAlertDays.Text).Trim() == "")
            {
                epGeneralSettings.SetError(txtReturnAlertDays, "Please enter days.");
                txtReturnAlertDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpReturnAlertDays.ShowAlways = true;
                tpReturnAlertDays.Show("Please enter days.", txtReturnAlertDays, 5000);
            }
            else
            {
                epGeneralSettings.Clear();
                txtReturnAlertDays.BackColor = Color.White;
            }
        }
        private void TxtInvoiceEditDays_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceEditDays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtInvoiceEditDays_Leave(object sender, EventArgs e)
        {
            if (Convert.ToString(txtInvoiceEditDays.Text).Trim() == "")
            {
                epGeneralSettings.SetError(txtInvoiceEditDays, "Please enter days.");
                txtInvoiceEditDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpInvoiceEditDays.ShowAlways = true;
                tpInvoiceEditDays.Show("Please enter days.", txtInvoiceEditDays, 5000);
            }
            else
            {
                epGeneralSettings.Clear();
                txtInvoiceEditDays.BackColor = Color.White;
            }
        }
        private void TxtInvoiceEditDays_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbYes.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUpdate_Enter(object sender, EventArgs e)
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
        private void BtnUpdate_Leave(object sender, EventArgs e)
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
        private void BtnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnUpdate_Click(sender, e);
                }
                if (e.KeyCode == Keys.F5)
                {
                    BtnUpdate_Click(sender, e);
                    btnUpdate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtcashpurchase.Text).Trim() == "")
                {
                    epGeneralSettings.SetError(txtcashpurchase, "Please enter amount.");
                    txtcashpurchase.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcashpurchase.ShowAlways = true;
                    tpcashpurchase.Show("Please enter amount.", txtcashpurchase, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtBillAmount.Text).Trim() == "")
                {
                    epGeneralSettings.SetError(txtBillAmount, "Please enter amount.");
                    txtBillAmount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBillAmount.ShowAlways = true;
                    tpBillAmount.Show("Please enter amount.", txtBillAmount, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtGRNQty.Text).Trim() == "")
                {
                    epGeneralSettings.SetError(txtGRNQty, "Please enter quantity.");
                    txtGRNQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpGRNQty.ShowAlways = true;
                    tpGRNQty.Show("Please enter quantity.", txtGRNQty, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtReturnAlertDays.Text).Trim() == "")
                {
                    epGeneralSettings.SetError(txtReturnAlertDays, "Please enter days.");
                    txtReturnAlertDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReturnAlertDays.ShowAlways = true;
                    tpReturnAlertDays.Show("Please enter days.", txtReturnAlertDays, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtInvoiceEditDays.Text).Trim() == "")
                {
                    epGeneralSettings.SetError(txtInvoiceEditDays, "Please enter days.");
                    txtInvoiceEditDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoiceEditDays.ShowAlways = true;
                    tpInvoiceEditDays.Show("Please enter days.", txtInvoiceEditDays, 5000);
                    blnErrorFlag = true;
                }
                string path = txtbackuppath.Text;
                if (!Directory.Exists(path) && path!="")
                {
                    epGeneralSettings.SetError(txtbackuppath, "Please enter a correct path");
                    txtbackuppath.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpbackuppath.ShowAlways = true;
                    tpbackuppath.Show("Please enter a correct path", txtbackuppath, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtbackuppath.Text).Trim() == "")
                {
                    epGeneralSettings.SetError(txtbackuppath, "Please enter a path");
                    txtbackuppath.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpbackuppath.ShowAlways = true;
                    tpbackuppath.Show("Please enter a path", txtbackuppath, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtPerLevel1.Text.Trim()) == "")
                {
                    epGeneralSettings.SetError(txtPerLevel1, "Please enter level1 value.");
                    txtPerLevel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPerLevel1.ShowAlways = true;
                    tpPerLevel1.Show("Please enter level1 value.", txtPerLevel1, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtPerLevel2.Text.Trim()) == "")
                {
                    epGeneralSettings.SetError(txtPerLevel2, "Please enter level2 value.");
                    txtPerLevel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPerLevel2.ShowAlways = true;
                    tpPerLevel2.Show("Please enter level2 value.", txtPerLevel2, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtPerLevel1.Text.Trim()) != "" && Convert.ToString(txtPerLevel2.Text.Trim()) != "")
                {
                    if(Convert.ToInt32(txtPerLevel1.Text)>Convert.ToInt32(txtPerLevel2.Text))
                    {
                        epGeneralSettings.SetError(txtPerLevel1, "Please enter valid level1 value.");
                        txtPerLevel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPerLevel1.ShowAlways = true;
                        tpPerLevel1.Show("Please enter valid level1 value.", txtPerLevel1, 5000);
                        blnErrorFlag = true;
                    }
                    if(Convert.ToInt32(txtPerLevel2.Text)>99)
                    {
                        epGeneralSettings.SetError(txtPerLevel2, "Please enter valid level2 value.");
                        txtPerLevel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPerLevel2.ShowAlways = true;
                        tpPerLevel2.Show("Please enter valid level2 value.", txtPerLevel2, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtVerificationDays.Text.Trim()) == "")
                {
                    epGeneralSettings.SetError(txtVerificationDays, "Please enter days.");
                    txtVerificationDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerificationDays.ShowAlways = true;
                    tpVerificationDays.Show("Please enter verification days.", txtVerificationDays, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    if (Convert.ToInt32(txtVerificationDays.Text) < 1 || Convert.ToInt32(txtVerificationDays.Text) > 365)
                    {
                        epGeneralSettings.SetError(txtVerificationDays, "Please enter valid days.");
                        txtVerificationDays.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpVerificationDays.ShowAlways = true;
                        tpVerificationDays.Show("Please enter valid days.", txtVerificationDays, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtMonths.Text.Trim()) == "")
                {
                    epGeneralSettings.SetError(txtMonths, "Please enter months.");
                    txtMonths.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpAgingMonths.ShowAlways = true;
                    tpAgingMonths.Show("Please enter months.", txtMonths, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    if (Convert.ToInt32(txtMonths.Text) < 1 )
                    {
                        epGeneralSettings.SetError(txtMonths, "Please enter valid months.");
                        txtMonths.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpAgingMonths.ShowAlways = true;
                        tpAgingMonths.Show("Please enter valid months.", txtMonths, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtLPRate.Text).Trim() == "")
                {
                    epGeneralSettings.SetError(txtLPRate, "Please entry bill rate deviation purchase %.");
                    txtLPRate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLPRate.ShowAlways = true;
                    tpLPRate.Show("Please entry bill rate deviation purchase %.", txtLPRate, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    epGeneralSettings.Clear();
                    udfnClear();
                    udfnUpdate();
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
            finally { btnUpdate.Enabled = true; btnUpdate.Focus(); }
        }
        public void udfnClear()
        {
            try
            {
                txtcashpurchase.BackColor = Color.White;
                txtBillAmount.BackColor = Color.White;
                txtGRNQty.BackColor = Color.White;
                txtReturnAlertDays.BackColor = Color.White;
                txtInvoiceEditDays.BackColor = Color.White;
                txtbackuppath.BackColor = Color.White;
                txtPerLevel1.BackColor = Color.White;
                txtPerLevel2.BackColor = Color.White;
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
        private void Txtcashpurchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
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
        private void TxtBillAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
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

        private void TxtGRNQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtReturnAlertDays_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtInvoiceEditDays_KeyPress(object sender, KeyPressEventArgs e)
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
        private void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdOrderType.CurrentCell.OwningColumn.Name == "Days")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdOrderType_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdOrderType.CurrentCell.OwningColumn.Name == "Days")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdOrderType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdOrderType.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_GeneralSettings_Leave(object sender, EventArgs e)
        {
            try
            {
                tpcashpurchase.Active = false;
                tpBillAmount.Active = false;
                tpGRNQty.Active = false;
                tpInvoiceEditDays.Active = false;
                tpReturnAlertDays.Active = false;
                tpTransactionType.Active = false;
                tpReportText.Active = false;
                tpLPRate.Active = false;
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

        private void CmbTransactionType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "0" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epGeneralSettings.SetError(cmbTransactionType, "Please select transaction type.");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type.", cmbTransactionType, 5000);
                }
                else
                {
                    epGeneralSettings.Clear();
                    cmbTransactionType.BackColor = Color.White;
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

        private void CmbTransactionType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReportText.Focus();
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
        private void TxtReportText_Enter(object sender, EventArgs e)
        {
            try
            {
                txtReportText.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtReportText_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtReportText_Leave(object sender, EventArgs e)
        {
            if (Convert.ToString(txtReportText.Text).Trim() == "")
            {
                epGeneralSettings.SetError(txtReportText, "Please enter report text.");
                txtReportText.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpReportText.ShowAlways = true;
                tpReportText.Show("Please enter reprt text.", txtReportText, 5000);
            }
            else
            {
                epGeneralSettings.Clear();
                txtReportText.BackColor = Color.White;
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
                bool blnErrorFlag = false;
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "0" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epGeneralSettings.SetError(cmbTransactionType, "Please select transaction type.");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type.", cmbTransactionType, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtReportText.Text).Trim() == "")
                {
                    epGeneralSettings.SetError(txtReportText, "Please enter report text.");
                    txtReportText.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpReportText.ShowAlways = true;
                    tpReportText.Show("Please enter reprt text.", txtReportText, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    udfnAdd();
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
                int varFlag = 0; int varTransactionType = 0;
                varTransactionType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                for (int i = 0; i < grdReport.Rows.Count; i++)
                {
                    if (varTransactionType == Convert.ToInt32(grdReport.Rows[i].Cells["clmTransactionID"].Value))
                    {
                        varFlag = 1;
                    }
                }
                if (varFlag == 0)
                {
                    grdReport.Rows.Add( cmbTransactionType.Text.Trim(),txtReportText.Text.Trim(), cmbTransactionType.SelectedValue);
                    cmbTransactionType.SelectedValue = -1;
                    txtReportText.Text = "";
                    cmbTransactionType.Focus();
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(88);
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

        private void GrdReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdReport.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdReport.Rows.RemoveAt(this.grdReport.SelectedRows[0].Index);
                                //for (int i = 0; i < grdReport.RowCount; i++)
                                //{
                                //    grdReport.Rows[i].Cells["clmsno"].Value = i + 1;
                                //}
                            }
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
        private void GrdReport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdReport.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbYes_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbYes_Leave(object sender, EventArgs e)
        {
            try
            {
                rbYes.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbYes_Enter(object sender, EventArgs e)
        {
            try
            {
                rbYes.BackColor = Color.LemonChiffon;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbNo_KeyDown(object sender, KeyEventArgs e)
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

        private void RbNo_Leave(object sender, EventArgs e)
        {
            try
            {
                rbNo.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbNo_Enter(object sender, EventArgs e)
        {
            try
            {
                rbNo.BackColor = Color.LemonChiffon;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtbackuppath_Enter(object sender, EventArgs e)
        {
            try
            {
                txtbackuppath.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtbackuppath_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtbackuppath.Text=="")
                {
                    epGeneralSettings.SetError(txtbackuppath, "Please enter a path");
                    txtbackuppath.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please enter a path", txtbackuppath, 5000);
                }
                else
                {
                    epGeneralSettings.Clear();
                    txtbackuppath.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPerLevel1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPerLevel1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPerLevel1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPerLevel2.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPerLevel1_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtPerLevel1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPerLevel1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPerLevel2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPerLevel2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPerLevel2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtVerificationDays.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtPerLevel2_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtPerLevel2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPerLevel2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtVerificationDays_Enter(object sender, EventArgs e)
        {
            try
            {
                txtVerificationDays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtVerificationDays_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVerificationDays.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtVerificationDays_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtVerificationDays_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMonths.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonths_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMonths.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonths_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLPRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonths_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtMonths_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMonths.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLPRate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLPRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLPRate_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLPRate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLPRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRTGSMinLimit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLPRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
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

        private void TxtRTGSMinLimit_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRTGSMinLimit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRTGSMinLimit_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtRTGSMinLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                } 
                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
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
        private void TxtRTGSMinLimit_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRTGSMinLimit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
