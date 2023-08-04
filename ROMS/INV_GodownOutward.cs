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
    public partial class INV_GodownOutward : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpgrouptype = new ToolTip();
        private ToolTip tptgroupname = new ToolTip();
        private ToolTip tpegroupname = new ToolTip();
        private ToolTip tptlabelname = new ToolTip();
        private ToolTip tpelabelname = new ToolTip();
        private ToolTip tpsno = new ToolTip();
        public string vargroupcode;
        public String pbFormStatus;
        public INV_GodownOutward()
        {
            InitializeComponent();
        }
     
        private void btnSave_Click(object sender, EventArgs e)
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

        private void udfnclear()
        {
            
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


        private void BtnClose_Click_1(object sender, EventArgs e)
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

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTransactionType.SelectedItem != "Regular")
                {
                  //  grpproductname.Enabled = false; 
                    DGV_inward.Columns["clmBatch"].Width = 100;
                    DGV_inward.Columns["clmBatch"].Visible = true;
                }
                else
                {

                    DGV_inward.Columns["clmBatch"].Width = 0;
                    DGV_inward.Columns["clmBatch"].Visible = false;
                  //  grpproductname.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void INV_GodownOutward_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
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
    }
}
