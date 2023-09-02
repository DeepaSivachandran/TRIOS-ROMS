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
    public partial class PAY_SupplierPayment : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public PAY_SupplierPayment()
        {
            InitializeComponent();
        }

        
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {  
                    this.Close();
                }
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

        private void INV_Inward_Load(object sender, EventArgs e)
        {
            udfnShowHideTextBoxes();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void Txtsuppliername_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbPaymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                udfnShowHideTextBoxes();
                cmbPaymentType.Items.Clear();
                if (cmbPaymentmode.SelectedItem == "Cash") { }
                if (cmbPaymentmode.SelectedItem == "Bank")
                {
                    txtDPaymentType.Visible = true;
                    cmbPaymentType.Visible = true;
                    cmbPaymentType.Items.Add("Cheque");
                    cmbPaymentType.Items.Add("Demand Draft");
                    cmbPaymentType.Items.Add("RTGS");
                    cmbPaymentType.Items.Add("NEFT");
                }
                if (cmbPaymentmode.SelectedItem == "Online")
                {
                    txtDPaymentType.Visible = true;
                    cmbPaymentType.Visible = true;
                    cmbPaymentType.Items.Add("RTGS");
                    cmbPaymentType.Items.Add("NEFT");
                    cmbPaymentType.Items.Add("IMBS");
                    cmbPaymentType.Items.Add("UPI");
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnShowHideTextBoxes() {
            try {
                txtDPaymentType.Visible = false;
                cmbPaymentType.Visible = false;
                udfnShowHideTextBoxes2ndlevel();
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnShowHideTextBoxes2ndlevel()
        {
            try
            {
                txtChequeDate.Visible = false;
                txtChequeNo.Visible = false;
                dtChequeDate.Visible = false;
                txtDChequeNo.Visible = false;
                txtDBankName.Visible = false;
                cmbBankName.Visible = false;
                txtDisplay.Text = "";
                txtValue.Text = "";
                txtDisplay.Visible = false;
                txtValue.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnShowHideTextBoxes2ndlevel();
                if (cmbPaymentType.SelectedItem == "Cheque")
                {
                    txtChequeDate.Visible = true;
                    txtChequeNo.Visible = true;
                    dtChequeDate.Visible = true;
                    txtDChequeNo.Visible = true;
                    txtDBankName.Visible = true;
                    cmbBankName.Visible = true;
                }
                if (cmbPaymentType.SelectedItem == "Demand Draft") {
                    txtDisplay.Visible = true;
                    txtValue.Visible = true;
                    txtDisplay.Text = "DD No.";
                }
                if (cmbPaymentType.SelectedItem == "IMBS" || cmbPaymentType.SelectedItem == "UPI") {
                    txtDisplay.Visible = true;
                    txtValue.Visible = true;
                    txtDisplay.Text = "Ref No.";
                }
                if (cmbPaymentType.SelectedItem == "NEFT" && cmbPaymentmode.SelectedItem == "Bank") {
                    txtDisplay.Visible = true;
                    txtValue.Visible = true;
                    txtDisplay.Text = "Cheque No.";
                }
                if (cmbPaymentType.SelectedItem == "RTGS" && cmbPaymentmode.SelectedItem == "Bank") {
                    txtDisplay.Visible = true;
                    txtValue.Visible = true;
                    txtDisplay.Text = "Cheque No.";
                }
                if (cmbPaymentType.SelectedItem == "NEFT" && cmbPaymentmode.SelectedItem == "Online")
                {
                    txtDisplay.Visible = true;
                    txtValue.Visible = true;
                    txtDisplay.Text = "Ref No.";
                }
                if (cmbPaymentType.SelectedItem == "RTGS" && cmbPaymentmode.SelectedItem == "Online")
                {
                    txtDisplay.Visible = true;
                    txtValue.Visible = true;
                    txtDisplay.Text = "Ref No.";
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
