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
    public partial class PUR_PurchaseReturns : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_PurchaseReturns()
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
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
          

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem == "Damage")
            {
                txtProductName.Enabled = false;
                txtpurchaseRate.Enabled = false;
                txtActualQty.Enabled = false;
                btnAdd.Enabled = false;
                lblTotal.Text = "Approximate Total";
            }
            else
            {
                txtProductName.Enabled = true;
                txtpurchaseRate.Enabled = true;
                txtActualQty.Enabled = true;
                btnAdd.Enabled = true;
                lblTotal.Text = "Actual Total";
            }
        }

        private void PUR_PurchaseReturns_Load(object sender, EventArgs e)
        {
            try
            {
                cmbReturnType.Items.Clear();
                cmbReturnType.Items.Add("Credit Note Received");
                cmbReturnType.Items.Add("Equivalent Products Received");
                cmbReturnType.Items.Add("Debit Note Created");
                cmbReturnType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReturnType.SelectedIndex == 1) {
                    MainForm.objPUR_DCGoodsInward = new PUR_DCGoodsInward();
                    MainForm.objPUR_DCGoodsInward.ShowDialog();
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
