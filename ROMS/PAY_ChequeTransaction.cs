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
using ROMS.Model;
using System.Globalization;
namespace ROMS
{
    // Sivabharathi    Create date: 09/08/2023    
    public partial class PAY_ChequeTransaction : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;

         
        public int pbId = 0,pbSPID=0,pbPayID=0, varCloseFlag=0,varBankID=0;
        public string varSupplierName = "";
        public string varPaymentNo = "";
        public string varAmount = "";
         
        //tool tip
        private ToolTip tpchequeNo = new ToolTip(); 
      
        public PAY_ChequeTransaction()
        {
            InitializeComponent();
        }
        private void CP_ProductHSN_Leave(object sender, EventArgs e)
        {
            try
            {
                tpchequeNo.Active = false; 
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
                udfnChequeDate();
                udfnEdit();
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
                btnUpdate.BackColor = Color.LemonChiffon;
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
        private void TxtHSNName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.LemonChiffon;
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
                if (txtSupplier.Text.Trim() == "")
                {
                    epHsn.SetError(txtSupplier, "Please enter HSN name.");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpchequeNo.ShowAlways = true;
                    tpchequeNo.Show("Please enter HSN name.", txtSupplier, 5000);
                }
                else
                {
                    epHsn.Clear();
                    txtSupplier.BackColor = Color.White;
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
                    txtPaymentNo.Focus();
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
                txtPaymentNo.BackColor = Color.LemonChiffon;
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
        public void udfnClear()
        {
            try
            {
                txtSupplier.Text = "";
                txtPaymentNo.Text = ""; 
                txtSupplier.Focus();
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
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objspservice = new SPDataService();
                Model.TRN_Payment_ChequeTransaction objTRN_Payment_ChequeTransaction = new Model.TRN_Payment_ChequeTransaction();
                objTRN_Payment_ChequeTransaction.paraViewType = 1;
                objTRN_Payment_ChequeTransaction.paraID = Convert.ToInt32(pbId); 
                objDs = objspservice.udfnPayment_ChequeTransactionlist(objTRN_Payment_ChequeTransaction);
                objspservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        txtSupplier.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Supplier"]);
                        txtPaymentNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PaymentNo"]);
                        txtAmount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Amount"]);
                        txtChequeLimitDays.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ChequeLimitDays"]);
                        txtChequeNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAYCQ_ChequeNo"]);
                        dpChequeDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PAYCQ_ChequeDate"]);
                        pbSPID= Convert.ToInt16(objDs.Tables[0].Rows[0]["SupplierID"]);
                        pbPayID= Convert.ToInt16(objDs.Tables[0].Rows[0]["PAYCQ_PAYID"]);
                        varBankID = Convert.ToInt16(objDs.Tables[0].Rows[0]["BankId"]);  
                    }
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
                string varResult = "";  int varChequeLimitDays = 0;
                if(Convert.ToString(txtChequeLimitDays.Text.Trim())!="")
                { varChequeLimitDays = Convert.ToInt16(txtChequeLimitDays.Text); }
                SPDataService objspservice = new SPDataService();
                Model.TRN_Payment_ChequeTransaction objTRN_Payment_ChequeTransaction = new Model.TRN_Payment_ChequeTransaction();
                objTRN_Payment_ChequeTransaction.paraViewType = 1;
                objTRN_Payment_ChequeTransaction.paraID = pbId;
                objTRN_Payment_ChequeTransaction.paraPAYID = pbPayID;
                objTRN_Payment_ChequeTransaction.paraPAYNo = txtPaymentNo.Text;
                objTRN_Payment_ChequeTransaction.paraSupplierID = pbSPID;
                objTRN_Payment_ChequeTransaction.paraAmount = Convert.ToDecimal(txtAmount.Text); 
                objTRN_Payment_ChequeTransaction.paraChequeDate = dpChequeDate.Text;
                objTRN_Payment_ChequeTransaction.paraChequeNo = txtChequeNo.Text;
                objTRN_Payment_ChequeTransaction.paraOriginator = "Cheque Creation"; 
                objTRN_Payment_ChequeTransaction.paraBankID = varBankID; 
                objTRN_Payment_ChequeTransaction.paraChequeLimitDays = varChequeLimitDays; 
                varResult = objspservice.udfnPayment_ChequeTransaction(objTRN_Payment_ChequeTransaction);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objPAY_ChequeTransactionList.udfnList();
                    varCloseFlag = 1;
                    udfnclose();
                } 
                else if (varResult.Split('~')[0] == "4")
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnUpdate.Focus();
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
                if (txtChequeNo.Text.Trim() == "")
                {
                    epHsn.SetError(txtChequeNo, "Please enter cheque no.");
                    txtChequeNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpchequeNo.ShowAlways = true;
                    tpchequeNo.Show("Please enter cheque no.", txtChequeNo, 5000);
                    blnErrorFlag = true;
                }
                //Check the cheque is sunday or not
                SPDataService objDServ = new SPDataService();
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 27;
                objMR_Master.paraDate = dpChequeDate.Text;
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnMaster(objMR_Master);
                if (objDs.Tables.Count != 0)
                {
                    int flag = 0;
                    flag = Convert.ToInt16(objDs.Tables[0].Rows[0]["DateFlag"]);
                    if (flag == 1)
                    {
                        string varMessage = objDServ.udfnGetMessages(160);
                        objDServ.CloseConnection();
                        DialogResult result1 = DialogResult.Yes;
                        result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result1 == DialogResult.No)
                        {
                            blnErrorFlag = true;
                            return;
                        }
                    }
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnUpdate.Focus();
            }
        }

        private void TxtChequeNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtChequeNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeNo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtChequeNo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtChequeLimitDays.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void DpChequeDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpChequeDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpChequeDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpChequeDate.BackColor = Color.White;
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
                    btnUpdate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeLimitDays_Enter(object sender, EventArgs e)
        {
            try
            {
                txtChequeLimitDays.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeLimitDays_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dpChequeDate.Enabled == true)
                    {
                        dpChequeDate.Focus();
                    }
                    else
                    {
                        btnUpdate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeLimitDays_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtChequeLimitDays_Leave(object sender, EventArgs e)
        {
            try
            {
                txtChequeLimitDays.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtChequeLimitDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnChequeDate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnChequeDate()
        {
            try
            {
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 28;
                objMR_Master.paraDate = dpChequeDate.Text;
                objMR_Master.paraFlag = Convert.ToInt32(txtChequeLimitDays.Text);
                DataSet objDs = new DataSet();
                SPDataService objspservice = new SPDataService();
                objDs = objspservice.udfnMaster(objMR_Master);
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 1)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            dpChequeDate.MinDate = DateTime.ParseExact(objDs.Tables[1].Rows[0]["ChequeDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                    }
                    if (txtChequeLimitDays.Text.Trim() != "")
                    {
                        if (objDs.Tables.Count > 1)
                        {
                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                dpChequeDate.Text = Convert.ToString(DateTime.ParseExact(objDs.Tables[0].Rows[0]["Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                                dpChequeDate.Enabled = false;
                            }
                        }
                    }
                    else
                    { dpChequeDate.Enabled = true; }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpChequeDate_KeyDown(object sender, KeyEventArgs e)
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
        private void CP_ProductHSN_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
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
          
    }
}


    