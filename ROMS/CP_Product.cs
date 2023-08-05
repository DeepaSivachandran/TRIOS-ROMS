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

namespace ROMS
{
    public partial class CP_Product : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;


        public string varcompanycode;
        public string pbFormStatus;
        public string varstatecode = "";

        //tool tip
        private ToolTip tpContactNo = new ToolTip();
        private ToolTip tpAltContactNo = new ToolTip();
        private ToolTip tpemail = new ToolTip();
        private ToolTip tpgstin = new ToolTip();
        private ToolTip tpfssai = new ToolTip();
        private ToolTip tpplno = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpshortname = new ToolTip();
        private ToolTip tppincode = new ToolTip();
        private ToolTip tpcity = new ToolTip();
        private ToolTip tparea = new ToolTip();
        private ToolTip tpstate = new ToolTip();
        public CP_Product()
        {
            InitializeComponent();
        }
         
        private void btnSave_Click(object sender, EventArgs e)
        { 
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

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
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

        private void btnSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSave.BackColor = Color.White;
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
               // MainForm.objCP_CompanyList.udfnList();
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

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
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

        private void btnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Company_Load(object sender, EventArgs e)
        {
            

            cmbPeriod.SelectedIndex = 0; 
            BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
        }


       

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void RbInActive_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void TxtPICode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtItemNameEnglish.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter )
                {
                    txtItemNameTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbHSNName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
          
        private void CmbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbUnit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBulkUnit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPosition_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPurchaseRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        

        private void TxtRetailRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWMinSaleQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWSaleRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBarcode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                txtGrossWeight.Focus();            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

       

        private void TxtPurchaseRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   // txtMRPRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMRPRate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMaxStock.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMaxStock_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReOrderQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMinStock_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMaxStock.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void TxtWMinSaleQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWSaleRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRMinSaleQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRetailRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (pnlStatus.Enabled == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        rbActive.Focus();
                    }
                }
                else
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

        private void CbExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //   txtDay.Focus();
                    if (cmbPeriod.Visible==true)
                    {
                        cmbPeriod.Focus();
                    }
                    else{

                        cbRMFromProduction.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void TxtGST_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        private void TxtReOrderQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMaxOrderQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void RbActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbInActive.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInActive_KeyDown(object sender, KeyEventArgs e)
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

            //////////////////////////////////////////////////////
            



        }

        private void TxtPICode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPICode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                txtItemNameEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtItemNameTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void TxtRetailRate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRetailRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWSaleRate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWSaleRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWeight_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWeight.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurchaseRate_Enter(object sender, EventArgs e)
        {
            try
            {
              //  txtPurchaseRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMRPRate_Enter(object sender, EventArgs e)
        {
            try
            {
              //  txtMRPRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMaxStock_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMaxStock.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMinStock_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMinStock.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 

        private void TxtWMinSaleQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtWMinSaleQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRMinSaleQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRMinSaleQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBarcode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBarcode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void TxtGST_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGST.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
           

        private void TxtReOrderQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtReOrderQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }



        ////////////////////////////////////////////////////


        private void TxtPICode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPICode.Text == "")
                {
                    txtPICode.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtPICode, "Please Enter PI Code");
                }
                else
                {
                    txtPICode.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtItemNameEnglish.Text == "")
                {
                    txtItemNameEnglish.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtItemNameEnglish, "Please Enter Item Name in English");
                }
                else
                {
                    txtItemNameEnglish.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtItemNameTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtItemNameTamil.Text == "")
                {
                    txtItemNameTamil.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtItemNameTamil, "Please Enter Item Name in Tamil");
                }
                else
                {
                    txtItemNameTamil.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }  

        private void TxtRetailRate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRetailRate.Text == "")
                {
                    txtRetailRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtRetailRate, "Please Enter Retail Rate");
                }
                else
                {
                    txtRetailRate.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWSaleRate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtWSaleRate.Text == "")
                {
                    txtWSaleRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtWSaleRate, "Please Enter W Sale Rate");
                }
                else
                {
                    txtWSaleRate.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtWeight.Text == "")
                {
                    txtWeight.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtWeight, "Please Enter Weight");
                }
                else
                {
                    txtWeight.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

      
        private void TxtMaxStock_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMaxStock.Text == "")
                {
                    txtMaxStock.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtMaxStock, "Please Enter Max Stock");
                }
                else
                {
                    txtMaxStock.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMinStock_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMinStock.Text == "")
                {
                    txtMinStock.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtMinStock, "Please Enter Min Stock");
                }
                else
                {
                    txtMinStock.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void TxtWMinSaleQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtWMinSaleQty.Text == "")
                {
                    txtWMinSaleQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtWMinSaleQty, "Please Enter Min Sale Qty");
                }
                else
                {
                    txtWMinSaleQty.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRMinSaleQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRMinSaleQty.Text == "")
                {
                    txtRMinSaleQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtRMinSaleQty, "Please Enter R Min Sale Qty");
                }
                else
                {
                    txtRMinSaleQty.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBarcode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBarcode.Text == "")
                {
                    txtBarcode.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtBarcode, "Please Enter BarCode");
                }
                else
                {
                    txtBarcode.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         

        private void TxtGST_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtGST.Text == "")
                {
                    txtGST.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtGST, "Please Enter GST");
                }
                else
                {
                    txtGST.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 

        private void TxtReOrderQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtReOrderQty.Text == "")
                {
                    txtReOrderQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtReOrderQty, "Please Enter ReOrder Qty");
                }
                else
                {
                    txtReOrderQty.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPICode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    bool varResult = objvalidation.CheckNumeric(e);
            //    if (varResult == true)
            //    {
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Handled = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
            //finally
            //{

            //}
        }
         

        private void TxtRetailRate_KeyPress(object sender, KeyPressEventArgs e)
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
            finally
            {

            }
        }

        private void TxtWSaleRate_KeyPress(object sender, KeyPressEventArgs e)
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
            finally
            {

            }
        }

        private void TxtWeight_KeyPress(object sender, KeyPressEventArgs e)
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
            finally
            {

            }
        }
         

        private void TxtMaxStock_KeyPress(object sender, KeyPressEventArgs e)
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
            finally
            {

            }
        }

        private void TxtMinStock_KeyPress(object sender, KeyPressEventArgs e)
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
            finally
            {

            }
        } 

        private void TxtRMinSaleQty_KeyPress(object sender, KeyPressEventArgs e)
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
            finally
            {

            }
        }

        private void TxtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool varResult = objvalidation.CheckNumeric(e);
                if (varResult == true)
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
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

        private void TxtGST_KeyPress(object sender, KeyPressEventArgs e)
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
            finally
            {

            }
        } 

        private void TxtReOrderQty_KeyPress(object sender, KeyPressEventArgs e)
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
            finally
            {

            }
        }
         
        private void CbExpiry_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbExpiry.Checked == true)
                {
                    cmbPeriod.Visible = true;
                    txtSelfLife.Visible = true;
                }
                else
                {
                    cmbPeriod.Visible = false;
                    txtSelfLife.Visible = false;

                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
          
        }
       

       
        private void CmbBatchNoGeneration_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    BeginInvoke(new Action(() => cmbBatchNoGeneration.Select(int.MaxValue, 0)));
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPICode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbHSNName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbProductCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbHSNName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbHSNName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbHSNName.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbHSNName_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbHSNName.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbHSNName_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbHSNName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProductCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbProductCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbProductCategory_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProductCategory.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbProductCategory.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProductCategory.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProductCategory.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSubGroup.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbGroup.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbGroup.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbBrand_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBrand.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbBrand.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBulkUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbBulkUnit.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBulkUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBulkUnit.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBulkUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbBulkUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUpp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBulkUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBulkUnit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUpp_Leave(object sender, EventArgs e)
        {
            try
            {  
                if (txtUpp.Text == "")
                {
                    txtUpp.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtUpp, "Please Enter UPP");
                }
                else
                {
                    txtUpp.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


        }

        private void TxtUpp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPosition.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtUpp_Enter(object sender, EventArgs e)
        {
            try
            {
                txtUpp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPosition.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbPosition_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPosition.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPosition_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPosition.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurchaseRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPurchaseRack.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbPurchaseRack_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurchaseRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSalesGodown.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurchaseRack_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPurchaseRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPurchaseRack_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPurchaseRack.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbSalesGodown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSalesGodown.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSalesGodown_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSalesGodown.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSalesGodown_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSalesGodown_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSalesRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSalesGodown_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSalesGodown.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSalesRack_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSalesRack.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSalesRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBatchNoEntry.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSalesRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSalesRack.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSalesRack_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSalesRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbSalesRack_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchNoEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbBatchNoEntry.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbBatchNoEntry_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBatchNoEntry.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchNoEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchNoEntry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbBatchNoGeneration.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbBatchNoEntry_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBatchNoEntry.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


        }

        private void CmbBatchNoGeneration_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbBatchNoGeneration.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbBatchNoGeneration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbExpiry.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


        }

        private void CmbBatchNoGeneration_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbBatchNoGeneration_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbBatchNoGeneration.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbRMFromProduction.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


        }

        private void CmbPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPeriod_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPeriod.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


        }

        private void CmbPeriod_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPeriod.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


        }

        private void CmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPeriod.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CbRMFromProduction_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWeight.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }


        }

        private void TxtGrossWeight_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMinStock.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtGrossWeight_Leave(object sender, EventArgs e)
        {
            try
            { 
                if (txtGrossWeight.Text == "")
                {
                    txtGrossWeight.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtGrossWeight, "Please enter the gross weight");
                }
                else
                {
                    txtGrossWeight.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
             
        }

        private void TxtGrossWeight_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGrossWeight.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtMaxOrderQty_Leave(object sender, EventArgs e)
        {
             
             
            try
            {
                if (txtMaxOrderQty.Text == "")
                {
                    txtMaxOrderQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtMaxOrderQty, "Please enter the rach MOQ");
                }
                else
                {
                    txtMaxOrderQty.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtMaxOrderQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRMinSaleQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMaxOrderQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMaxOrderQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbUnit.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbUnit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbUnit.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbExpiry_Enter(object sender, EventArgs e)
        {
            try
            {
                cbExpiry.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CbExpiry_Leave(object sender, EventArgs e)
        {
            try
            {
                cbExpiry.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CbRMFromProduction_Enter(object sender, EventArgs e)
        {
            try
            {
                cbRMFromProduction.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CbRMFromProduction_Leave(object sender, EventArgs e)
        {
            try
            {
                cbRMFromProduction.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CP_Product_Load(object sender, EventArgs e)
        {
            try
            {
                cmbPeriod.SelectedIndex = 0;
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}


    