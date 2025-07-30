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
    public partial class PAY_SupplierPayment_BankDate : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpCancel = new ToolTip();
        public int varSupplierId, varScheduleId;
        public PAY_SupplierPayment_BankDate()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errBrand.Clear();
                SPDataService objSPdataservice = new SPDataService();
               string result = objSPdataservice.udfnSupplierMaster(14, varSupplierId,"", "", "",0, "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, "", "", "", "", 0, "", 0, 0, 0,0, 0, "", "", "", "", 0, "", 0, 0, "", "", "", "", "", "", "", "", "", 0, "", 0, 0, 0,0, 0, varScheduleId, 0, "", dpTransactionDate.Text);

                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objPAY_SupplierPaymentList.udfnList();
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
            finally
            {
                this.Close();
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
        private void CP_Brand_Leave(object sender, EventArgs e)
        {
            try
            {
                tpCancel.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void TxtCount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dpTransactionDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpTransactionDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void dpTransactionDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PAY_SupplierPayment_BankDate_Load(object sender, EventArgs e)
        {
            dpTransactionDate.MinDate = MainForm.pbFYStartDate;
            dpTransactionDate.MaxDate = MainForm.pbCurrentDate;
        }

        private void dpTransactionDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpTransactionDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
