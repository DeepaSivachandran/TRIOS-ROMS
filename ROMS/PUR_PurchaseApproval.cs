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
    public partial class PUR_PurchaseApproval : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public PUR_PurchaseApproval()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            try
            { 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void PUR_PurchaseApprovalList_Load(object sender, EventArgs e)
        {
            try
            { 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPurchaseApproval_DoubleClick(object sender, EventArgs e)
        {
            try
            { 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }

        }

        private void BtnRemarks_Click(object sender, EventArgs e)
        {
            try
            {

                MainForm.objPUR_RemarksHistory = new PUR_RemarksHistory();
                MainForm.objPUR_RemarksHistory.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
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
                    this.Close();
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
