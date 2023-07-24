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
    public partial class INV_Inward : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        public INV_Inward()
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
            if (btnSave.Text == "Save")
            {
                grpproductname.Visible = true;
                txtsuppliername.Enabled = true;
                
            }
            else {
                grpproductname.Visible = false;
                txtsuppliername.Enabled = false;
                //cmbPoNo.Enabled = false;
                cmbinwardtype.Enabled = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void Txtsuppliername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btnsaveasdraft_Click(object sender, EventArgs e)
        {

        }
    }
}
