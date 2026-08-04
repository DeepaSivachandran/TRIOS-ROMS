using ROMS.Model;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace ROMS
{
    public partial class CP_ProductDetailsCopy : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;

        public int varUpDownKeyProduct = 0, varUpDownKey=0; 

         

        //tool tip
        private ToolTip tpRRate = new ToolTip();
        private ToolTip tpWRate = new ToolTip();
        private ToolTip tpVerifier = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        public CP_ProductDetailsCopy()
        {
            InitializeComponent();
        }
         
        public void udfnclose()
        {
            try
            { 
                this.Close();
                MainForm.objCP_Rate_ChangeList.udfnList();
                MainForm.objCP_Rate_ChangeList.grdItemList.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
            finally
            {
            }
        }        

        private void CP_Product_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                } 

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListviewProduct()
        {
            try
            {
                
                //udfnProductDetails();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyProduct = 1;
                udfnListviewProduct(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MainForm.varCloseFlag == 0)
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


    