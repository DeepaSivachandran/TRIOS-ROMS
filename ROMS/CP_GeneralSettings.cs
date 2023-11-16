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
    public partial class CP_GeneralSettings : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpcashpurchase = new ToolTip();
        private ToolTip tpBillAmount = new ToolTip();
        private ToolTip tpGRNQty = new ToolTip();
        private ToolTip tpReturnAlertDays = new ToolTip();
        private ToolTip tpInvoiceEditDays = new ToolTip();
        
        public int varSettingID = 0;
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
        public void udfnTurnAroundTimeLoad()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnMaster(0, 13,0);
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
        public void udfnEditLoad()
        {
            try
            {
                DataSet objDs = new DataSet();
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
                            txtGRNQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_GRNQty"]);
                            txtReturnAlertDays.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_RAD"]);
                            txtInvoiceEditDays.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_IED"]);
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
                string varResult = "";
                btnUpdate.Enabled = false;
                SPDataService objDser = new SPDataService();
                string varOriginator = "GeneralSettings Updation";
                SPDataService objspdservice = new SPDataService();
                DataTable objGeneralSettings = new DataTable();
                objGeneralSettings.TableName = "[MR_GeneralSettings_TAT]";
                objGeneralSettings.Columns.Add("GSTAT_GSID", typeof(int));
                objGeneralSettings.Columns.Add("GSTAT_OrderType", typeof(int));
                objGeneralSettings.Columns.Add("GSTAT_OrderDays", typeof(int));
                for(int i=0;i<grdOrderType.Rows.Count;i++)
                {
                    objGeneralSettings.Rows.Add(varSettingID,Convert.ToInt32(grdOrderType.Rows[i].Cells["Order_TypeID"].Value), Convert.ToInt32(grdOrderType.Rows[i].Cells["Days"].Value));
                }
                varResult = objDser.udfnGeneralSettings(0, varSettingID, Convert.ToDecimal(txtcashpurchase.Text), Convert.ToDecimal(txtBillAmount.Text), Convert.ToInt32(txtGRNQty.Text), Convert.ToInt32(txtReturnAlertDays.Text), Convert.ToInt32(txtInvoiceEditDays.Text), objGeneralSettings, varOriginator);
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
                udfnEditLoad();
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
                //udfnTurnAroundTimeLoad();
                udfnEditLoad();
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
                    btnUpdate.Focus();
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
                if (blnErrorFlag == false)
                {
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
