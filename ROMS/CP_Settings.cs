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
    public partial class CP_Settings : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public string varSampleTransation = "";
        //tool tip
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();
        private ToolTip tpPrefix = new ToolTip();
        private ToolTip tpSuffix = new ToolTip();
        private ToolTip tpStartingNo = new ToolTip();
        private ToolTip tpResetOn = new ToolTip();
        private ToolTip tpNoofdigits = new ToolTip();
        public CP_Settings()
        {
            InitializeComponent();
        }
        private void CP_Settings_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpTransactionType.Active = false;
                tpPrefix.Active = false;
                tpSuffix.Active = false;
                tpStartingNo.Active = false;
                tpResetOn.Active = false;
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
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=14 OR MSTID=-1 ORDER BY MSTID,MST_DisplayText", "MSTID,MST_DisplayText", cmbTransactionType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=34 OR MSTID=-1  ORDER BY MSTID,MST_DisplayText", "MSTID,MST_DisplayText", cmbResetOn, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("MR_Company", "COMID NOT IN(0) ORDER BY COMID,COM_ShortName", "COMID,COM_ShortName", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_Settings_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbLoad();
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
                if (txtPrefix.Text.Trim() == "")
                {
                    epSettings.SetError(txtPrefix, "Please enter prefix.");
                    txtPrefix.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPrefix.ShowAlways = true;
                    tpPrefix.Show("Please enter prefix.", txtPrefix, 5000);
                }
                else
                {
                    epSettings.Clear();
                    txtPrefix.BackColor = Color.White;
                }
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
                if (txtSuffix.Text.Trim() == "")
                {
                    epSettings.SetError(txtSuffix, "Please enter suffix.");
                    txtSuffix.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuffix.ShowAlways = true;
                    tpSuffix.Show("Please enter suffix.", txtSuffix, 5000);
                }
                else
                {
                    epSettings.Clear();
                    txtSuffix.BackColor = Color.White;
                }
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
                    txtNoOfDegits.Focus();
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
                    btnAdd.Focus();
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
                if (txtPrefix.Text.Trim() == "")
                {
                    epSettings.SetError(txtPrefix, "Please enter prefix.");
                    txtPrefix.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPrefix.ShowAlways = true;
                    tpPrefix.Show("Please enter prefix.", txtPrefix, 5000);
                    blnErrorFlag = true;
                }
                if (txtSuffix.Text.Trim() == "")
                {
                    epSettings.SetError(txtSuffix, "Please enter suffix.");
                    txtSuffix.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuffix.ShowAlways = true;
                    tpSuffix.Show("Please enter suffix.", txtSuffix, 5000);
                    blnErrorFlag = true;
                }
                if (txtStartingNo.Text.Trim() == "")
                {
                    epSettings.SetError(txtStartingNo, "Please enter starting no.");
                    txtStartingNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStartingNo.ShowAlways = true;
                    tpStartingNo.Show("Please enter starting no.", txtStartingNo, 5000);
                    blnErrorFlag = true;
                }
                if (txtNoOfDegits.Text.Trim() == "")
                {
                    epSettings.SetError(txtNoOfDegits, "Please enter No.of digits.");
                    txtNoOfDegits.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpNoofdigits.ShowAlways = true;
                    tpNoofdigits.Show("Please enter No.of digits.", txtNoOfDegits, 5000);
                    blnErrorFlag = true;
                }
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
                int varFlag = 0; int varConcern = 0; int varTransactionType = 0;
                for (int i = 0; i < grdSettings.Rows.Count; i++)
                {
                    varConcern = Convert.ToInt32(cmbConcern.SelectedValue);
                    if (varConcern == Convert.ToInt32(grdSettings.Rows[i].Cells["clmConcern"].Value))
                    {
                        varTransactionType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                        for (int j = 0; j < grdSettings.Rows.Count; j++)
                        {
                            if (varTransactionType == Convert.ToInt32(grdSettings.Rows[j].Cells["clmTransactionType"].Value))
                            { varFlag = 1; }
                        }
                    }
                }
                if (varFlag == 0)
                {
                    //varSampleTransation = Convert.ToString(grdSettings.Rows[i].Cells["clmPrefix"].Value).Trim() + Convert.ToString(grdSettings.Rows[i].Cells["clmSuffix"].Value).Trim();
                    varSampleTransation = Convert.ToString(txtPrefix.Text.Trim()) + Convert.ToString(txtSuffix.Text.Trim());
                    grdSettings.Rows.Add(grdSettings.Rows.Count+1, cmbConcern.SelectedValue, cmbTransactionType.SelectedValue, txtPrefix.Text, txtSuffix.Text, txtStartingNo.Text, txtNoOfDegits.Text, cmbResetOn.SelectedValue,varSampleTransation);
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
        public void udfnClear()
        {
            try
            {
                cmbConcern.SelectedValue = -1;
                cmbTransactionType.SelectedValue = -1;
                txtPrefix.Text = "";
                txtSuffix.Text = "";
                txtStartingNo.Text = "";
                txtNoOfDegits.Text = "";
                cmbResetOn.SelectedValue = -1;
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
                string result = ""; 
                SPDataService objspdservice = new SPDataService();
                DataTable objSettings = new DataTable();
                objSettings.TableName = "[MR_VoucherSettings]";
                objSettings.Columns.Add("STG_COMID", typeof(int));
                objSettings.Columns.Add("STG_TransactionType", typeof(int));
                objSettings.Columns.Add("STG_Prefix", typeof(string));
                objSettings.Columns.Add("STG_Sufix", typeof(string));
                objSettings.Columns.Add("STG_StartingNo", typeof(int));
                objSettings.Columns.Add("STG_NoOfDigit", typeof(int));
                objSettings.Columns.Add("STG_ResetOn", typeof(int));
                for (int i = 0; i < grdSettings.Rows.Count; i++)
                {
                    // objSettings.Rows.Add(grdSettings.Rows[i].Cells["HSN Name-New"].Value).Trim(), cmbTransactionType.SelectedValue, txtPrefix.Text, txtSuffix.Text, txtStartingNo.Text, txtNoOfDegits.Text, cmbResetOn.SelectedValue);
                    objSettings.Rows.Add(Convert.ToInt32(grdSettings.Rows[i].Cells["clmConcern"].Value), Convert.ToInt32(grdSettings.Rows[i].Cells["clmTransactionType"].Value), Convert.ToString(grdSettings.Rows[i].Cells["clmPrefix"].Value).Trim(), 
                        Convert.ToString(grdSettings.Rows[i].Cells["clmSuffix"].Value).Trim(), Convert.ToInt32(grdSettings.Rows[i].Cells["clmStartingNo"].Value), Convert.ToInt32(grdSettings.Rows[i].Cells["clmNoofdigits"].Value),
                         Convert.ToInt32(grdSettings.Rows[i].Cells["clmResetOn"].Value)); 
                }
                SPDataService objDSer = new SPDataService();
                result = objDSer.udfnVoucherSettings(0, objSettings);
                objDSer.CloseConnection();
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    udfnClear();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                udfnSave();
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
            try
            {
                if (txtNoOfDegits.Text.Trim() == "")
                {
                    epSettings.SetError(txtNoOfDegits, "Please enter No.of digits.");
                    txtNoOfDegits.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpNoofdigits.ShowAlways = true;
                    tpNoofdigits.Show("Please enter No.of digits.", txtNoOfDegits, 5000);
                }
                else
                {
                    epSettings.Clear();
                    txtNoOfDegits.BackColor = Color.White;
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
