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
            try
            {
                udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSave()
        {
            try
            {
                bool blnErrorFlag = false;
                int varflag = 0, varflag1 = 0;
                if (Convert.ToString(txtPICode.Text).Trim() == "")
                {
                    errItems.SetError(txtPICode, "Please enter PICode");
                    txtPICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    //   tpplno.Show("Please enter PICode", txtPICode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select company", cmbConcern, 5000);
                    //  blnErrorFlag = true;
                }


                if (Convert.ToString(txtItemNameEnglish.Text).Trim() == "")
                {
                    errItems.SetError(txtItemNameEnglish, "Please enter product english name");
                    txtItemNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter product english name", txtItemNameEnglish, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtItemNameTamil.Text).Trim() == "")
                {
                    errItems.SetError(txtItemNameTamil, "Please enter product tamil name");
                    txtItemNameTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter product tamil name", txtItemNameTamil, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtUpp.Text).Trim() == "")
                {
                    errItems.SetError(txtUpp, "Please enter  UPP");
                    txtUpp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter UPP", txtUpp, 5000);
                    //   blnErrorFlag = true;
                }
                if (Convert.ToString(txtMinStock.Text).Trim() == "")
                {
                    errItems.SetError(txtMinStock, "Please enter min stock");
                    txtMinStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter min stock", txtMinStock, 5000);
                    //    blnErrorFlag = true;
                }
                if (Convert.ToString(txtGrossWeight.Text).Trim() == "")
                {
                    errItems.SetError(txtGrossWeight, "Please enter gross weight");
                    txtGrossWeight.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter gross weight", txtGrossWeight, 5000);
                    //  blnErrorFlag = true;
                }
                if (Convert.ToString(txtMaxStock.Text).Trim() == "")
                {
                    errItems.SetError(txtMaxStock, "Please enter max stock");
                    txtMaxStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter max stock", txtMaxStock, 5000);
                    // blnErrorFlag = true;
                }
                if (Convert.ToString(txtReOrderQty.Text).Trim() == "")
                {
                    errItems.SetError(txtReOrderQty, "Please enter Reorder qty");
                    txtReOrderQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter Reorder qty", txtReOrderQty, 5000);
                    // blnErrorFlag = true;
                }
                if (Convert.ToString(txtRMinSaleQty.Text).Trim() == "")
                {
                    errItems.SetError(txtRMinSaleQty, "Please enter retail min sales stock");
                    txtRMinSaleQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter retail min sales stock", txtRMinSaleQty, 5000);
                    //   blnErrorFlag = true;
                }
                if (Convert.ToString(txtRetailRate.Text).Trim() == "")
                {
                    errItems.SetError(txtRetailRate, "Please enter retail rate");
                    txtRetailRate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter retail rate", txtRetailRate, 5000);
                    // blnErrorFlag = true;
                }

                if (Convert.ToString(txtWMinSaleQty.Text).Trim() == "")
                {
                    errItems.SetError(txtWMinSaleQty, "Please enter wholesales min qty");
                    txtWMinSaleQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter wholesales min qty", txtWMinSaleQty, 5000);
                    //   blnErrorFlag = true;
                }
                if (Convert.ToString(txtWSaleRate.Text).Trim() == "")
                {
                    errItems.SetError(txtWSaleRate, "Please enter wholesales rate");
                    txtWSaleRate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter wholesales rate", txtWSaleRate, 5000);
                    //  blnErrorFlag = true;
                }
                if (Convert.ToString(txtBarcode.Text).Trim() == "")
                {
                    errItems.SetError(txtBarcode, "Please enter barcode");
                    txtBarcode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter barcode", txtBarcode, 5000);
                    //  blnErrorFlag = true;
                }

                if (Convert.ToString(cmbProductCategory.SelectedValue) == "" || Convert.ToString(cmbProductCategory.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbProductCategory, "Please select Product category");
                    cmbProductCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select Product category", cmbGroup, 5000);
              //  blnErrorFlag = true;
            }

                if (Convert.ToString(cmbSubGroup.SelectedValue) == "" || Convert.ToString(cmbSubGroup.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbSubGroup, "Please select SubGroup");
                    cmbSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select SubGroup", cmbGroup, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbGroup.SelectedValue) == "" || Convert.ToString(cmbGroup.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbGroup, "Please select Group");
                    cmbGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select Group", cmbGroup, 5000);
                    ///    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbBrand.SelectedValue) == "" || Convert.ToString(cmbBrand.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbBrand, "Please select Brand");
                    cmbBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select Brand", cmbBrand, 5000);
                    //   blnErrorFlag = true;
                }

                if (Convert.ToString(cmbUnit.SelectedValue) == "" || Convert.ToString(cmbUnit.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbUnit, "Please select Unit");
                    cmbUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select Unit", cmbUnit, 5000);
                    // blnErrorFlag = true;
                }

                if (Convert.ToString(cmbBulkUnit.SelectedValue) == "" || Convert.ToString(cmbBulkUnit.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbBulkUnit, "Please select Bulk Unit");
                    cmbBulkUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select Bulk Unit", cmbBulkUnit, 5000);
                    //  blnErrorFlag = true;
                }

                if (Convert.ToString(cmbPosition.SelectedValue) == "" || Convert.ToString(cmbPosition.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbPosition, "Please select purchase godown");
                    cmbPosition.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select purchase godown", cmbPosition, 5000);
                    //    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbPurchaseRack.SelectedValue) == "" || Convert.ToString(cmbPurchaseRack.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbPurchaseRack, "Please select purchase rack");
                    cmbPurchaseRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select purchase rack", cmbPurchaseRack, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbSalesGodown.SelectedValue) == "" || Convert.ToString(cmbSalesGodown.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbSalesGodown, "Please select sales godown");
                    cmbSalesGodown.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales godown", cmbSalesGodown, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbSalesRack.SelectedValue) == "" || Convert.ToString(cmbSalesRack.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbSalesRack, "Please select sales rack");
                    cmbSalesRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales rack", cmbSalesRack, 5000);
                    //    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbBatchNoEntry.SelectedValue) == "" || Convert.ToString(cmbBatchNoEntry.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbBatchNoEntry, "Please select Batch No.");
                    cmbBatchNoEntry.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales Batch No.", cmbBatchNoEntry, 5000);
                    // blnErrorFlag = true;
                }

                if (Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "" || Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbBatchNoGeneration, "Please select Batch No. generation");
                    cmbBatchNoGeneration.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales Batch No. generation", cmbBatchNoGeneration, 5000);
                    // blnErrorFlag = true;
                }

                if (Convert.ToString(cmbPeriod.SelectedValue) == "" || Convert.ToString(cmbPeriod.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbPeriod, "Please select shelflife");
                    cmbPeriod.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select shelflife", cmbPeriod, 5000);
                    //   blnErrorFlag = true;
                }
                 
                if (blnErrorFlag == false)
                {

                    SPDataService objspdservice = new SPDataService();
                    string result = "";
                    string varStatus = "1";
                    errItems.Clear();
                    //udfntextboxcolor();
                    if (Convert.ToString(txtItemNameEnglish.Text).Trim() != "" && Convert.ToString(txtItemNameTamil.Text).Trim() != "")
                    {
                        if (rbActive.Checked == true)
                        {
                            varStatus = "1";
                        }
                        else
                        {
                            varStatus = "2";

                        } 
                         
                        if (btnSave.Text == "Save")
                        {
                            //result = objspdservice.udfnCompanyMaster(0, 0, txtCompanyName.Text, txtShortName.Text, txtAddressLine1.Text, txtAddressLine2.Text, Convert.ToInt32(lblcityid.Text)
                            //, Convert.ToInt32(txtPincode.Text), txtPhoneNo.Text, txtAlterPhoneno.Text, txtwhatsappNo.Text, txtmobileNo.Text, txtAlterMobileno.Text, txtEmail.Text, txtwebsite.Text
                            //, txtGSTTIN.Text, txtPan.Text, txtESI.Text, txtEPF.Text, txtFSSAI.Text, txtPlno.Text, Convert.ToString(cmbState.SelectedValue), "1",
                            //MainForm.pbUserID, MainForm.pbIpAddress, "Company Create", objBankTable, objContactTable);
                        }
                        else
                        {
                            
                        }
                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                         
                    }


                     objspdservice.CloseConnection();
                }


            }
            catch
            {

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
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnsave()
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
                btnClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select company", cmbConcern, 5000); 
                }
                else
                {
                    errItems.Clear();
                    cmbConcern.BackColor = Color.White;
                }
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
                if (Convert.ToString(cmbProductCategory.SelectedValue) == "" || Convert.ToString(cmbProductCategory.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbProductCategory, "Please select Product category");
                    cmbProductCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select Product category", cmbGroup, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbProductCategory.BackColor = Color.White;
                }
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
                if (Convert.ToString(cmbSubGroup.SelectedValue) == "" || Convert.ToString(cmbSubGroup.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbSubGroup, "Please select SubGroup");
                    cmbSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select SubGroup", cmbGroup, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbSubGroup.BackColor = Color.White;
                }
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
                cmbSubGroup.BackColor = Color.LemonChiffon;
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

            if (Convert.ToString(cmbGroup.SelectedValue) == "" || Convert.ToString(cmbGroup.SelectedValue) == "-1")
            {
                errItems.SetError(cmbGroup, "Please select Group");
                cmbGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpcompanyname.ShowAlways = true;
                tpcompanyname.Show("Please select Group", cmbGroup, 5000);
            }
            else
            {
                errItems.Clear();
                cmbGroup.BackColor = Color.White;
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
                if (Convert.ToString(cmbBrand.SelectedValue) == "" || Convert.ToString(cmbBrand.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbBrand, "Please select Brand");
                    cmbBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select Brand", cmbBrand, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbBrand.BackColor = Color.White;
                }
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
                if (Convert.ToString(cmbBulkUnit.SelectedValue) == "" || Convert.ToString(cmbBulkUnit.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbBulkUnit, "Please select Bulk Unit");
                    cmbBulkUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select Bulk Unit", cmbBulkUnit, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbBulkUnit.BackColor = Color.White;
                }
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
                if (Convert.ToString(cmbPosition.SelectedValue) == "" || Convert.ToString(cmbPosition.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbPosition, "Please select purchase godown");
                    cmbPosition.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select purchase godown", cmbPosition, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbPosition.BackColor = Color.White;
                }

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
                if (Convert.ToString(cmbPurchaseRack.SelectedValue) == "" || Convert.ToString(cmbPurchaseRack.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbPurchaseRack, "Please select purchase rack");
                    cmbPurchaseRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select purchase rack", cmbPurchaseRack, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbPurchaseRack.BackColor = Color.White;
                }
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

                if (Convert.ToString(cmbSalesGodown.SelectedValue) == "" || Convert.ToString(cmbSalesGodown.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbSalesGodown, "Please select sales godown");
                    cmbSalesGodown.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales godown", cmbSalesGodown, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbSalesGodown.BackColor = Color.White;
                }
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
                if (Convert.ToString(cmbSalesRack.SelectedValue) == "" || Convert.ToString(cmbSalesRack.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbSalesRack, "Please select sales rack");
                    cmbSalesRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales rack", cmbSalesRack, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbSalesRack.BackColor = Color.White;
                }
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
                if (Convert.ToString(cmbBatchNoEntry.SelectedValue) == "" || Convert.ToString(cmbBatchNoEntry.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbBatchNoEntry, "Please select Batch No.");
                    cmbBatchNoEntry.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales Batch No.", cmbBatchNoEntry, 5000);
                }
                else {
                    errItems.Clear();
                    cmbBatchNoEntry.BackColor = Color.White;
                }
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

                if (Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "" || Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbBatchNoGeneration, "Please select Batch No. generation");
                    cmbBatchNoGeneration.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales Batch No. generation", cmbBatchNoGeneration, 5000);
                }
                else {

                    cmbBatchNoGeneration.BackColor = Color.White;
                    errItems.Clear();
                }
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
                if (Convert.ToString(cmbPeriod.SelectedValue) == "" || Convert.ToString(cmbPeriod.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbPeriod, "Please select shelflife");
                    cmbPeriod.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select shelflife", cmbPeriod, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbPeriod.BackColor = Color.White;
                }
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
                if (Convert.ToString(cmbUnit.SelectedValue) == "" || Convert.ToString(cmbUnit.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbUnit, "Please select Unit");
                    cmbUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select Unit", cmbUnit, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbUnit.BackColor = Color.White;
                }
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
                 
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID=1 AND COMID !=0 ORDER BY COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind.BindComboBoxListSelected("MR_ProductGroup", "PRGID !=0 AND PRG_STSID=1 ORDER BY PRGID", "PRG_EName,PRGID", cmbGroup, "", "PRG_EName", "PRGID");
                objDataBind.BindComboBoxListSelected("MR_Unit", "UT_STSID=1 AND UTID!=0 ORDER BY UTID", "UT_Name,UTID", cmbUnit, "", "UT_Name", "UTID");
                
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubgroup_Click(object sender, EventArgs e)
        {

        }

        private void BtnGroup_Click(object sender, EventArgs e)
        {

        }

        private void BtnBrand_Click(object sender, EventArgs e)
        {

        }

        private void BtnUnit_Click(object sender, EventArgs e)
        {

        }

        private void TxtGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtWMinSaleQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtSelfLife_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtSelfLife_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSelfLife.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSelfLife_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSelfLife.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSelfLife_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPeriod.Focus();
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


    