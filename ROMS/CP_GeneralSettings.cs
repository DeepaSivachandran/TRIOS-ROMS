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
                objDs = objdserv.udfnMaster(0, 13);
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
                            txtcashpurchase.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_CPA"]);
                            txtBillAmount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_DVA"]);
                            txtGRNQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_GRNQty"]);
                            txtReturnAlertDays.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_RAD"]);
                            txtInvoiceEditDays.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GS_IED"]);
                        }
                        string varOrderDay = "";
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                           for(int i=0;i<grdOrderType.Rows.Count;i++)
                           {
                                if(Convert.ToString(grdOrderType.Rows[i].Cells["MSTID"].Value) == Convert.ToString(objDs.Tables[1].Rows[0]["GSTAT_GSID"]))
                                {
                                    varOrderDay=Convert.ToString(objDs.Tables[1].Rows[0]["GSTAT_OrderDays"]);
                                    grdOrderType.Rows[i].Cells["clmDays"].Value = varOrderDay;
                                }
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
                string varResult = "";
                btnUpdate.Enabled = false;
                SPDataService objDser = new SPDataService();
                varResult = objDser.udfnGeneralSettings(0, Convert.ToInt32(txtcashpurchase.Text), Convert.ToInt32(txtBillAmount), Convert.ToInt32(txtGRNQty.Text), Convert.ToInt32(txtReturnAlertDays.Text), Convert.ToInt32(txtInvoiceEditDays.Text),"General Settings Update");
                objDser.CloseConnection();
                btnUpdate.Enabled = true;
                if (varResult.Split('~')[0] == "3")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void CP_GeneralSettings_Load(object sender, EventArgs e)
        {
            try
            {
                udfnTurnAroundTimeLoad();
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
                //if (Convert.ToString(txtCompanyName.Text).Trim() == "")
                //{
                //    epCompany.SetError(txtCompanyName, "Please enter company name");
                //    txtCompanyName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpCompanyName.ShowAlways = true;
                //    tpCompanyName.Show("Please enter company name", txtCompanyName, 5000);
                //}
                //else
                //{
                //    epCompany.Clear();
                //    txtCompanyName.BackColor = Color.White;
                //}
                try
                {
                    txtcashpurchase.BackColor = Color.White;
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
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
            try
            {
                txtBillAmount.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
            try
            {
                txtGRNQty.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
            try
            {
                txtReturnAlertDays.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
            try
            {
                txtInvoiceEditDays.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                udfnUpdate();
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
    }
}
