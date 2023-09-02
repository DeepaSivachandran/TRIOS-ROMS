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
    public partial class PUR_Calculator : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        double varResult = 0;
        public PUR_Calculator()
        {
            InitializeComponent();
        }

        private void txtPassKey_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAuthorise_Click(object sender, EventArgs e)
        {
            try { this.Close(); }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtValue.Text != "")
                {
                    varResult = Convert.ToDouble(new DataTable().Compute(txtValue.Text, null));
                }
                else { varResult = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { lblFinalValue.Text = Convert.ToString(varResult); }
        }

        private void PUR_Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                MainForm.objCP_Purchase = new CP_Purchase();
                MainForm.objCP_Purchase.varPurchaseRate = lblFinalValue.Text;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
