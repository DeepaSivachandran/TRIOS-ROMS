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

        public int varproductcode=0;
        public string varcompanycode;
        public string pbFormStatus;
        public string varstatecode = "";

        public string varupdate = "0";
        //tool tip
        private ToolTip tpContactNo = new ToolTip();
        private ToolTip tpAltContactNo = new ToolTip();
        private ToolTip tpemail = new ToolTip();
        private ToolTip tpgstin = new ToolTip();
        private ToolTip tpfssai = new ToolTip();
        private ToolTip tpshortname = new ToolTip();
        private ToolTip tppincode = new ToolTip();
        private ToolTip tpcity = new ToolTip();
        private ToolTip tparea = new ToolTip();
        private ToolTip tpstate = new ToolTip();
        private ToolTip tpplno = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();
        private ToolTip tpunit = new ToolTip();
        private ToolTip tpbrand = new ToolTip();
        private ToolTip tpprdG = new ToolTip();
        private ToolTip tpprdSG = new ToolTip();
        private ToolTip tpprd = new ToolTip();
        private ToolTip tptamname = new ToolTip();
        private ToolTip tpengname = new ToolTip();

        public int varGroupCode = 0, varSubgroupCode=0, varUnitCode=0,varbrandcode=0;
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
                btnSave.Enabled = false;
                bool blnErrorFlag = false;
                if (Convert.ToString(txtPICode.Text).Trim() == "")
                {
                    errItems.SetError(txtPICode, "Please enter PICode");
                    txtPICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter PICode", txtPICode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select company", cmbConcern, 5000);
                    blnErrorFlag = true;
                }


                if (Convert.ToString(txtItemNameEnglish.Text).Trim() == "")
                {
                    errItems.SetError(txtItemNameEnglish, "Please enter product english name");
                    txtItemNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpengname.ShowAlways = true;
                    tpplno.Show("Please enter product english name", txtItemNameEnglish, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtItemNameTamil.Text).Trim() == "")
                {
                    errItems.SetError(txtItemNameTamil, "Please enter product tamil name");
                    txtItemNameTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tptamname.ShowAlways = true;
                    tptamname.Show("Please enter product tamil name", txtItemNameTamil, 5000);
                    blnErrorFlag = true;
                }
                //    if (Convert.ToString(txtUpp.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtUpp, "Please enter  UPP");
                //        txtUpp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter UPP", txtUpp, 5000);
                //        //   blnErrorFlag = true;
                //    }
                //    if (Convert.ToString(txtMinStock.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtMinStock, "Please enter min stock");
                //        txtMinStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter min stock", txtMinStock, 5000);
                //        //    blnErrorFlag = true;
                //    }
                //    if (Convert.ToString(txtGrossWeight.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtGrossWeight, "Please enter gross weight");
                //        txtGrossWeight.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter gross weight", txtGrossWeight, 5000);
                //        //  blnErrorFlag = true;
                //    }
                //    if (Convert.ToString(txtMaxStock.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtMaxStock, "Please enter max stock");
                //        txtMaxStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter max stock", txtMaxStock, 5000);
                //        // blnErrorFlag = true;
                //    }
                //    if (Convert.ToString(txtReOrderQty.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtReOrderQty, "Please enter Reorder qty");
                //        txtReOrderQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter Reorder qty", txtReOrderQty, 5000);
                //        // blnErrorFlag = true;
                //    }
                //    if (Convert.ToString(txtRMinSaleQty.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtRMinSaleQty, "Please enter retail min sales stock");
                //        txtRMinSaleQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter retail min sales stock", txtRMinSaleQty, 5000);
                //        //   blnErrorFlag = true;
                //    }
                //    if (Convert.ToString(txtRetailRate.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtRetailRate, "Please enter retail rate");
                //        txtRetailRate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter retail rate", txtRetailRate, 5000);
                //        // blnErrorFlag = true;
                //    }

                //    if (Convert.ToString(txtWMinSaleQty.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtWMinSaleQty, "Please enter wholesales min qty");
                //        txtWMinSaleQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter wholesales min qty", txtWMinSaleQty, 5000);
                //        //   blnErrorFlag = true;
                //    }
                //    if (Convert.ToString(txtWSaleRate.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtWSaleRate, "Please enter wholesales rate");
                //        txtWSaleRate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter wholesales rate", txtWSaleRate, 5000);
                //        //  blnErrorFlag = true;
                //    }
                //    if (Convert.ToString(txtBarcode.Text).Trim() == "")
                //    {
                //        errItems.SetError(txtBarcode, "Please enter barcode");
                //        txtBarcode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpplno.ShowAlways = true;
                //        tpplno.Show("Please enter barcode", txtBarcode, 5000);
                //        //  blnErrorFlag = true;
                //    }

                if (Convert.ToString(cmbProductCategory.SelectedValue) == "" || Convert.ToString(cmbProductCategory.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbProductCategory, "Please select Product category");
                    cmbProductCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpprd.ShowAlways = true;
                    tpprd.Show("Please select Product category", cmbGroup, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbSubGroup.SelectedValue) == "" || Convert.ToString(cmbSubGroup.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbSubGroup, "Please select SubGroup");
                    cmbSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpprdSG.ShowAlways = true;
                    tpprdSG.Show("Please select SubGroup", cmbGroup, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbGroup.SelectedValue) == "" || Convert.ToString(cmbGroup.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbGroup, "Please select Group");
                    cmbGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpprdG.ShowAlways = true;
                    tpprdG.Show("Please select Group", cmbGroup, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbBrand.SelectedValue) == "" || Convert.ToString(cmbBrand.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbBrand, "Please select Brand");
                    cmbBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpbrand.ShowAlways = true;
                    tpbrand.Show("Please select Brand", cmbBrand, 5000);
                    blnErrorFlag = true;
                }

                if (Convert.ToString(cmbUnit.SelectedValue) == "" || Convert.ToString(cmbUnit.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbUnit, "Please select Unit");
                    cmbUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpunit.ShowAlways = true;
                    tpunit.Show("Please select Unit", cmbUnit, 5000);
                    blnErrorFlag = true;
                }

                //    if (Convert.ToString(cmbBulkUnit.SelectedValue) == "" || Convert.ToString(cmbBulkUnit.SelectedValue) == "-1")
                //    {
                //        errItems.SetError(cmbBulkUnit, "Please select Bulk Unit");
                //        cmbBulkUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpcompanyname.ShowAlways = true;
                //        tpcompanyname.Show("Please select Bulk Unit", cmbBulkUnit, 5000);
                //        //  blnErrorFlag = true;
                //    }

                //    if (Convert.ToString(cmbPosition.SelectedValue) == "" || Convert.ToString(cmbPosition.SelectedValue) == "-1")
                //    {
                //        errItems.SetError(cmbPosition, "Please select purchase godown");
                //        cmbPosition.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpcompanyname.ShowAlways = true;
                //        tpcompanyname.Show("Please select purchase godown", cmbPosition, 5000);
                //        //    blnErrorFlag = true;
                //    }

                //    if (Convert.ToString(cmbPurchaseRack.SelectedValue) == "" || Convert.ToString(cmbPurchaseRack.SelectedValue) == "-1")
                //    {
                //        errItems.SetError(cmbPurchaseRack, "Please select purchase rack");
                //        cmbPurchaseRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpcompanyname.ShowAlways = true;
                //        tpcompanyname.Show("Please select purchase rack", cmbPurchaseRack, 5000);
                //        blnErrorFlag = true;
                //    }

                //    if (Convert.ToString(cmbSalesGodown.SelectedValue) == "" || Convert.ToString(cmbSalesGodown.SelectedValue) == "-1")
                //    {
                //        errItems.SetError(cmbSalesGodown, "Please select sales godown");
                //        cmbSalesGodown.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpcompanyname.ShowAlways = true;
                //        tpcompanyname.Show("Please select sales godown", cmbSalesGodown, 5000);
                //        blnErrorFlag = true;
                //    }

                //    if (Convert.ToString(cmbSalesRack.SelectedValue) == "" || Convert.ToString(cmbSalesRack.SelectedValue) == "-1")
                //    {
                //        errItems.SetError(cmbSalesRack, "Please select sales rack");
                //        cmbSalesRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpcompanyname.ShowAlways = true;
                //        tpcompanyname.Show("Please select sales rack", cmbSalesRack, 5000);
                //        //    blnErrorFlag = true;
                //    }

                //    if (Convert.ToString(cmbBatchNoEntry.SelectedValue) == "" || Convert.ToString(cmbBatchNoEntry.SelectedValue) == "-1")
                //    {
                //        errItems.SetError(cmbBatchNoEntry, "Please select Batch No.");
                //        cmbBatchNoEntry.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpcompanyname.ShowAlways = true;
                //        tpcompanyname.Show("Please select sales Batch No.", cmbBatchNoEntry, 5000);
                //        // blnErrorFlag = true;
                //    }

                //    if (Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "" || Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "-1")
                //    {
                //        errItems.SetError(cmbBatchNoGeneration, "Please select Batch No. generation");
                //        cmbBatchNoGeneration.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpcompanyname.ShowAlways = true;
                //        tpcompanyname.Show("Please select sales Batch No. generation", cmbBatchNoGeneration, 5000);
                //        // blnErrorFlag = true;
                //    }

                //    if (Convert.ToString(cmbPeriod.SelectedValue) == "" || Convert.ToString(cmbPeriod.SelectedValue) == "-1")
                //    {
                //        errItems.SetError(cmbPeriod, "Please select shelflife");
                //        cmbPeriod.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpcompanyname.ShowAlways = true;
                //        tpcompanyname.Show("Please select shelflife", cmbPeriod, 5000);
                //        //   blnErrorFlag = true;
                //    }

                if (blnErrorFlag == false)
                {
                    SPDataService objspdservice = new SPDataService();
                    string result = "";
                    string varStatus = "1";
                    double netweight = 0, grossweight = 0, minstk = 0, maxstk = 0, reorderqty = 0, rminsale = 0, retailrate = 0, wminsaleqty = 0, wsalesrate = 0;
                    int shelflife = 0, rackmoq = 0, varshelflife = 0, varrmproduction = 0;
                    errItems.Clear();
                    udfncolorchange();

                    if (rbActive.Checked == true)
                    {
                        varStatus = "1";
                    }
                    else
                    {
                        varStatus = "2";

                    }

                    if (cbExpiry.Checked == true)
                    {
                        varshelflife = 1;
                    }
                    else
                    {
                        varshelflife = 0;
                    }
                    if (cbRMFromProduction.Checked == true)
                    {
                        varrmproduction = 1;
                    }
                    else
                    {
                        varrmproduction = 0;
                    }

                    if (txtWeight.Text == "")
                    {
                        netweight = 0;
                    }
                    else
                    {
                        netweight = Convert.ToDouble(txtWeight.Text);
                    }
                    if (txtGrossWeight.Text == "")
                    {
                        grossweight = 0;
                    }
                    else
                    {
                        grossweight = Convert.ToDouble(txtGrossWeight.Text);
                    }
                    if (txtMinStock.Text == "")
                    {
                        minstk = 0;
                    }
                    else
                    {
                        minstk = Convert.ToDouble(txtMinStock.Text);
                    }
                    if (txtMaxStock.Text == "")
                    {
                        maxstk = 0;
                    }
                    else
                    {
                        maxstk = Convert.ToDouble(txtMaxStock.Text);
                    }


                    if (txtReOrderQty.Text == "")
                    {
                        reorderqty = 0;
                    }
                    else
                    {
                        reorderqty = Convert.ToDouble(txtReOrderQty.Text);
                    }
                    if (txtRMinSaleQty.Text == "")
                    {
                        rminsale = 0;
                    }
                    else
                    {
                        rminsale = Convert.ToDouble(txtRMinSaleQty.Text);
                    }
                    if (txtRetailRate.Text == "")
                    {
                        retailrate = 0;
                    }
                    else
                    {
                        retailrate = Convert.ToDouble(txtRetailRate.Text);
                    }
                    if (txtWMinSaleQty.Text == "")
                    {
                        wminsaleqty = 0;
                    }
                    else
                    {
                        wminsaleqty = Convert.ToDouble(txtWMinSaleQty.Text);
                    }
                    if (txtWSaleRate.Text == "")
                    {
                        wsalesrate = 0;
                    }
                    else
                    {
                        wsalesrate = Convert.ToDouble(txtWSaleRate.Text);
                    }

                    if (txtRackMOQQty.Text == "")
                    {
                        rackmoq = 0;
                    }
                    else
                    {
                        rackmoq = Convert.ToInt32(txtRackMOQQty.Text);
                    }
                    if (txtSelfLife.Text == "")
                    {
                        shelflife = 0;
                    }
                    else
                    {
                        shelflife = Convert.ToInt32(txtSelfLife.Text);
                    }
                    int varviewtype = 0,varupdateproductcode=0;
                    string varorignator = "";
                     
                    if (btnSave.Text == "Save")
                    {
                        varviewtype = 0;
                        varorignator = "Product Create";
                        varupdateproductcode = 0; 
                    }
                    else
                    {
                        varviewtype = 1;
                        varorignator = "Product Update";
                        varupdateproductcode = varproductcode;
                        varupdate = "1";

                    } 
                    result = objspdservice.udfnProductMaster(varviewtype, varupdateproductcode, txtItemNameEnglish.Text, txtItemNameTamil.Text, txtPICode.Text, Convert.ToInt32(cmbConcern.SelectedValue),
                    Convert.ToInt32(cmbProductCategory.SelectedValue), Convert.ToInt32(cmbGroup.SelectedValue), Convert.ToInt32(cmbSubGroup.SelectedValue), Convert.ToInt32(cmbBrand.SelectedValue),
                    Convert.ToInt32(cmbUnit.SelectedValue), Convert.ToInt32(cmbBulkUnit.SelectedValue), txtUpp.Text, Convert.ToInt32(cmbPosition.SelectedValue), Convert.ToInt32(cmbSalesGodown.SelectedValue)
                    , Convert.ToInt32(cmbPurchaseRack.SelectedValue), Convert.ToInt32(cmbSalesRack.SelectedValue), rackmoq, Convert.ToInt32(cmbBatchNoEntry.SelectedValue)
                    , Convert.ToInt32(cmbBatchNoGeneration.SelectedValue), varshelflife, netweight, maxstk, grossweight, minstk, reorderqty, rminsale, retailrate, wminsaleqty,
                    wsalesrate, txtBarcode.Text, Convert.ToInt32(cmbHSNName.SelectedValue), varrmproduction, shelflife,
                    Convert.ToInt32(cmbPeriod.SelectedValue), varStatus, MainForm.pbUserID, MainForm.pbIpAddress, varorignator);

                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MainForm.objCP_Itemlist.udfnDropdownbind();
                        MainForm.objCP_Itemlist.udfnList();
                        cmbConcern.Focus();
                        udfnclear();
                        if (btnSave.Text == "Update")
                        {
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                    objspdservice.CloseConnection();
                }


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        public void udfnclear()
        {
            try
            {
                cmbConcern.SelectedValue = -1;
                cmbProductCategory.SelectedValue = -1;
                cmbSubGroup.SelectedValue = -1;
                cmbGroup.SelectedValue = -1; 
                cmbBrand.SelectedValue = -1;
                cmbUnit.SelectedValue = -1;
                cmbBulkUnit.SelectedValue = -1;
                cmbPurchaseRack.SelectedValue = -1;
                cmbPosition.SelectedValue = -1; 
                cmbSalesGodown.SelectedValue = -1;
                cmbSalesRack.SelectedValue = -1;  
                cmbBatchNoEntry.SelectedValue = -1;
                cmbBatchNoGeneration.SelectedValue = -1; 
                cmbPeriod.SelectedValue = -1;
                cbExpiry.Checked = false;
                cbRMFromProduction.Checked = false; 
                cmbHSNName.SelectedValue = -1; 
                txtPICode.Text = "";
                txtItemNameEnglish.Text = "";
                txtItemNameTamil.Text = "";
                txtRackMOQQty.Text = ""; 
                txtWeight.Text = ""; 
                txtGrossWeight.Text = "";
                txtMinStock.Text = "";
                txtMaxStock.Text = "";
                txtReOrderQty.Text = "";
                txtRMinSaleQty.Text = "";
                txtRetailRate.Text = "";
                txtWMinSaleQty.Text = "";
                txtWSaleRate.Text = "";
                txtBarcode.Text = "";
                txtHSNCode.Text = "";
                txtGST.Text = "";
                txtUpp.Text = ""; 

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        public void udfncolorchange()
        {
            try
            {
                cmbConcern.BackColor = Color.White;
                cmbProductCategory.BackColor = Color.White;
                cmbSubGroup.BackColor = Color.White;
                cmbGroup.BackColor = Color.White;
                cmbBrand.BackColor = Color.White;
                cmbUnit.BackColor = Color.White;
                cmbBulkUnit.BackColor = Color.White;
                cmbPurchaseRack.BackColor = Color.White;
                cmbPosition.BackColor = Color.White;
                cmbSalesGodown.BackColor = Color.White;
                cmbSalesRack.BackColor = Color.White;
                cmbBatchNoEntry.BackColor = Color.White;
                cmbBatchNoGeneration.BackColor = Color.White;
                cmbPeriod.BackColor = Color.White;
                cbExpiry.BackColor = Color.White;;
                cbRMFromProduction.BackColor = Color.White;;
                cmbHSNName.BackColor = Color.White;;
                txtPICode.BackColor = Color.White;
                txtItemNameEnglish.BackColor = Color.White;
                txtItemNameTamil.BackColor = Color.White;
                txtRackMOQQty.BackColor = Color.White;
                txtWeight.BackColor = Color.White;
                txtGrossWeight.BackColor = Color.White;
                txtMinStock.BackColor = Color.White;
                txtMaxStock.BackColor = Color.White;
                txtReOrderQty.BackColor = Color.White;
                txtRMinSaleQty.BackColor = Color.White;
                txtRetailRate.BackColor = Color.White;
                txtWMinSaleQty.BackColor = Color.White;
                txtWSaleRate.BackColor = Color.White;
                txtBarcode.BackColor = Color.White;
                txtHSNCode.BackColor = Color.White;
                txtGST.BackColor = Color.White;
                txtUpp.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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


        public void udfnclose()
        {
            try
            {
                this.Close(); 
                tpplno.ShowAlways = false;
                tpcompanyname.ShowAlways = false;
                tpunit.ShowAlways = false;
                tpbrand.ShowAlways = false;
                tpprdG.ShowAlways = false;
                tpprdSG.ShowAlways = false;
                tpprd.ShowAlways = false;
                tptamname.ShowAlways = false;
                tpengname.ShowAlways = false;
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
                    cmbProductCategory.Focus();
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
                if (e.KeyCode == Keys.Enter)
                {
                    txtGrossWeight.Focus();
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

        private void CbExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //   txtDay.Focus();
                    if (cmbPeriod.Visible==true)
                    {
                        txtSelfLife.Focus();
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
                    txtRMinSaleQty.Focus();
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

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();

                objDs = objdserv.udfnproductmasterlist(2, 0, 0, 0, 0, txtPICode.Text, MainForm.pbUserID, MainForm.pbIpAddress,0,0,0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    { 
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            txtItemNameEnglish.Text = objDs.Tables[0].Rows[0]["ENAME"].ToString();
                            txtItemNameTamil.Text = objDs.Tables[0].Rows[0]["Tname"].ToString();
                        }
                    }
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

                 
                DataBind objDataBind = new DataBind();
                DataService objds = new DataService(); 

                    objDataBind.BindComboBoxListSelected("MR_StockLocation", "SLID<>0 AND SL_STSID=1 AND SL_COMID='" + Convert.ToString(cmbConcern.SelectedValue) + "' OR  SLID=-1", "SL_ShortName,SLID", cmbPosition, "", "SL_ShortName", "SLID");
                objDataBind.BindComboBoxListSelected("MR_StockLocation", "SLID<>0 AND SL_STSID=1 AND SL_COMID='" + Convert.ToString(cmbConcern.SelectedValue) + "' OR  SLID=-1 ", "SL_ShortName,SLID", cmbSalesGodown, "", "SL_ShortName", "SLID");

                objds.CloseConnection();
                objDataBind = null; 
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
              
                if (pnlStatus.Enabled == true)
                {
                    if (e.KeyCode == Keys.Enter)
                        { 
                        rbActive.Focus(); 
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnSave.Focus();
                    }
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

                DataSet objds;
                DataService objdservice = new DataService();
                objds = objdservice.GetDataset("SELECT HSN_Code,GST_Value FROM MR_HSN INNER JOIN DEF_GST ON HSN_GSTID=GSTID WHERE HSNID  IN ('" + Convert.ToInt32(cmbHSNName.SelectedValue) + "') AND GSTID  NOT IN (0,-1)");
                objdservice.CloseConnection();
                if (objds != null)
                {
                    if (objds.Tables.Count > 0)
                    {
                        if (objds.Tables[0].Rows.Count > 0)
                        {
                            txtHSNCode.Text = Convert.ToString(objds.Tables[0].Rows[0]["HSN_Code"]);
                            txtGST.Text = Convert.ToString(objds.Tables[0].Rows[0]["GST_Value"]);
                        }
                        else
                        {
                            txtHSNCode.Text = "";
                            txtGST.Text = "";

                        }
                    }
                }
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
                if (Convert.ToString(cmbHSNName.SelectedValue) == "" || Convert.ToString(cmbHSNName.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbHSNName, "Please select HSN name");
                    cmbHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select sales HSN name", cmbHSNName, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbHSNName.BackColor = Color.White;
                }

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

                string varcmbgroupcode = "";
                DataBind objDataBind = new DataBind();
                DataService objds = new DataService();
                varcmbgroupcode = objds.displaydata("SELECT PRGID FROM MR_ProductSubGroup WHERE  PRSGID='" + Convert.ToString(cmbSubGroup.SelectedValue) + "'");
                objds.CloseConnection();
                 objDataBind = null;
                cmbSubGroup.SelectedValue = varcmbgroupcode;
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
                  
                DataBind objDataBind = new DataBind();
                DataService objds = new DataService(); 
                objDataBind.BindComboBoxListSelected("MR_Rack", "RKID<>0 AND RK_STSID=1 AND RK_SLID='" + Convert.ToString(cmbPosition.SelectedValue) + "' OR  RKID=-1", "RK_ShortName,RKID", cmbPurchaseRack, "", "RK_ShortName", "RKID");
             
                objds.CloseConnection();
                objDataBind = null; 

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
                 
                DataBind objDataBind = new DataBind();
                DataService objds = new DataService(); 
                objDataBind.BindComboBoxListSelected("MR_Rack", "RKID<>0 AND RK_STSID=1 AND RK_SLID='" + Convert.ToString(cmbSalesGodown.SelectedValue) + "' OR  RKID=-1 ", "RK_ShortName,RKID", cmbSalesRack, "", "RK_ShortName", "RKID");

                objds.CloseConnection();
                objDataBind = null; 
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
                    txtRackMOQQty.Focus();
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
                if (Convert.ToString(cmbBatchNoEntry.SelectedValue) == "72")
                {
                    cmbBatchNoGeneration.Enabled = true;
                }
                else
                {
                    cmbBatchNoGeneration.SelectedValue = -1;
                    cmbBatchNoGeneration.Enabled = false;
                }
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
                if (txtRackMOQQty.Text == "")
                {
                    txtRackMOQQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtRackMOQQty, "Please enter the rach MOQ");
                }
                else
                {
                    txtRackMOQQty.BackColor = Color.White;
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
                    cmbBatchNoEntry.Focus();
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
                txtRackMOQQty.BackColor = Color.LemonChiffon;
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

                DataService objds = new DataService();
                if (Convert.ToString(cmbUnit.SelectedValue) == "-1")
                {
                    txtUPPvalue.Text = "";
                }
                else
                {
                    txtUPPvalue.Text = objds.displaydata("Select UT_Symbol FROM MR_UNIT WHERE UTID='" + Convert.ToString(cmbUnit.SelectedValue) + "'");
                }
                objds.CloseConnection();
               
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
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0))); 
                this.ActiveControl = cmbConcern; 
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Unit", "UT_STSID=1 AND UTID!=0 ORDER BY UTID", "UT_Symbol,UTID", cmbUnit, "", "UT_Symbol", "UTID");
                objDataBind.BindComboBoxListSelected("MR_ProductSubGroup", "PRSGID <> 0 AND PRSG_STSID=1", "PRSG_EName,PRSGID", cmbSubGroup, "", "PRSG_EName", "PRSGID"); 
                objDataBind.BindComboBoxListSelected("MR_ProductGroup", "PRGID !=0 AND PRG_STSID=1 ORDER BY PRGID", "PRG_EName,PRGID", cmbGroup, "", "PRG_EName", "PRGID");
                objDataBind.BindComboBoxListSelected("MR_BRAND", "BDID <> 0 AND BD_STSID=1", "BD_EName,BDID", cmbBrand, "", "BD_EName", "BDID");
                objDataBind.BindComboBoxListSelected("MR_Company", "COM_STSID=1 AND COMID !=0 ORDER BY COMID", "COM_ShortName,COMID", cmbConcern, "", "COM_ShortName", "COMID");
                objDataBind.BindComboBoxListSelected("MR_HSN", "HSN_STSID=1 AND HSNID!=0 ORDER BY HSN_STSID", "HSN_Name,HSNID", cmbHSNName, "", "HSN_Name", "HSNID");
                objDataBind.BindComboBoxListSelected("MR_Unit", "UT_STSID=1 AND UTID!=0 ORDER BY UTID", "UT_Symbol,UTID", cmbBulkUnit, "", "UT_Symbol", "UTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (5,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbProductCategory, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (6,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbPeriod, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("MR_StockLocation", "SLID=-1 AND SL_STSID=1 ", "SL_ShortName,SLID", cmbPosition, "", "SL_ShortName", "SLID");
                objDataBind.BindComboBoxListSelected("MR_StockLocation", "SLID=-1 AND SL_STSID=1", "SL_ShortName,SLID", cmbSalesGodown, "", "SL_ShortName", "SLID");
                objDataBind.BindComboBoxListSelected("MR_Rack", "RKID=-1 AND RK_STSID=1 ", "RK_ShortName,RKID", cmbPurchaseRack, "", "RK_ShortName", "RKID");
                objDataBind.BindComboBoxListSelected("MR_Rack", "RKID=-1 AND RK_STSID=1 ", "RK_ShortName,RKID", cmbSalesRack, "", "RK_ShortName", "RKID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (25,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbBatchNoEntry, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (26,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbBatchNoGeneration, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbConcern.SelectedValue = -1;
                cmbGroup.SelectedValue = -1;
                cmbHSNName.SelectedValue = -1;
                cmbUnit.SelectedValue = -1;
                cmbBulkUnit.SelectedValue = -1;
                cmbProductCategory.SelectedValue = -1;
                cmbPeriod.SelectedValue = -1;
                cmbPosition.SelectedValue = -1;
                cmbSalesGodown.SelectedValue = -1;
                cmbPurchaseRack.SelectedValue = -1;
                cmbSalesRack.SelectedValue = -1;
                cmbBatchNoEntry.SelectedValue = -1;
                cmbBatchNoGeneration.SelectedValue = -1;
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

       

        public void udfnEdit()
        {
            try
            {   
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                if (varproductcode != 0)
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS; 
                    DataService objdservice = new DataService();
                    objDS = objdserv.udfnproductmasterlist(1, varproductcode, 0, 0, 0,"",MainForm.pbUserID, MainForm.pbIpAddress, 0,0,0);
                    objdserv.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["COMPANY"].ToString();
                            txtPICode.Text = Convert.ToString( objDS.Tables[0].Rows[0]["PICODE"].ToString().Replace("''", "'")); 
                            txtItemNameEnglish.Text = Convert.ToString(objDS.Tables[0].Rows[0]["ENAME"].ToString().Replace("''", "'"));
                            txtItemNameTamil.Text = Convert.ToString(objDS.Tables[0].Rows[0]["TNAME"].ToString().Replace("''", "'"));
                            cmbProductCategory.SelectedValue= objDS.Tables[0].Rows[0]["PRODUCTCATEGORY"].ToString();
                            cmbGroup.SelectedValue = objDS.Tables[0].Rows[0]["GROUP"].ToString();
                            cmbSubGroup.SelectedValue = objDS.Tables[0].Rows[0]["SUBGROUP"].ToString();
                            cmbBrand.SelectedValue = objDS.Tables[0].Rows[0]["BRAND"].ToString();

                            cmbUnit.SelectedValue = objDS.Tables[0].Rows[0]["UNIT"].ToString();
                            cmbBulkUnit.SelectedValue = objDS.Tables[0].Rows[0]["BULK UNIT"].ToString();
                            txtUpp.Text = Convert.ToString(objDS.Tables[0].Rows[0]["UPP"].ToString().Replace("''", "'"));
                            cmbPosition.SelectedValue = objDS.Tables[0].Rows[0]["LOCATION PURCHASE"].ToString();
                            cmbPurchaseRack.SelectedValue = objDS.Tables[0].Rows[0]["RACK LOCATION"].ToString();
                            cmbSalesGodown.SelectedValue = objDS.Tables[0].Rows[0]["LOCATION SALES"].ToString();
                            cmbSalesRack.SelectedValue = objDS.Tables[0].Rows[0]["RACK SALES"].ToString();
                            txtRackMOQQty.Text = Convert.ToString(objDS.Tables[0].Rows[0]["RACK MOQ"].ToString().Replace("''", "'"));
                            cmbBatchNoEntry.SelectedValue = objDS.Tables[0].Rows[0]["BATCHNO"].ToString();
                            cmbBatchNoGeneration.SelectedValue = objDS.Tables[0].Rows[0]["BARCODE GENERATION"].ToString();
                            cmbPeriod.SelectedValue = objDS.Tables[0].Rows[0]["SHELF LIFE TYPE"].ToString(); 
                            txtSelfLife.Text = Convert.ToString(objDS.Tables[0].Rows[0]["SHELFLIFE VALUE"].ToString().Replace("''", "'"));
                            txtWeight.Text = Convert.ToString(objDS.Tables[0].Rows[0]["NET WEIGHT"].ToString().Replace("''", "'"));
                            txtGrossWeight.Text = Convert.ToString(objDS.Tables[0].Rows[0]["GROSS WEIGHT"].ToString().Replace("''", "'"));
                            txtMinStock.Text = Convert.ToString(objDS.Tables[0].Rows[0]["MINSTK"].ToString().Replace("''", "'"));
                            txtMaxStock.Text = Convert.ToString(objDS.Tables[0].Rows[0]["MAXSTK"].ToString().Replace("''", "'"));
                            txtReOrderQty.Text = Convert.ToString(objDS.Tables[0].Rows[0]["REORDER QTY"].ToString().Replace("''", "'"));
                            txtRMinSaleQty.Text = Convert.ToString(objDS.Tables[0].Rows[0]["RMIN SALES QTY"].ToString().Replace("''", "'"));
                            txtRetailRate.Text = Convert.ToString(objDS.Tables[0].Rows[0]["RETAIL RATE"].ToString().Replace("''", "'"));
                            txtWMinSaleQty.Text = Convert.ToString(objDS.Tables[0].Rows[0]["WMINSALE QTY"].ToString().Replace("''", "'"));
                            txtWSaleRate.Text = Convert.ToString(objDS.Tables[0].Rows[0]["WSALERATE"].ToString().Replace("''", "'"));
                            txtBarcode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["BARCODE"].ToString().Replace("''", "'")); 
                            cmbHSNName.SelectedValue = objDS.Tables[0].Rows[0]["HSN"].ToString();
                             

                            if (Convert.ToString(objDS.Tables[0].Rows[0]["SHELFLIFE"]) == "1") { cbExpiry.Checked = true; } else { cbExpiry.Checked = false; }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["RM PRODUCTION"]) == "1") { cbRMFromProduction.Checked = true; } else { cbRMFromProduction.Checked = false; }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "1") { rbActive.Checked = true; } else { rbInActive.Checked = true; }
                             
                            objDS = objdservice.GetDataset("SELECT HSN_Code,GST_Value FROM MR_HSN INNER JOIN DEF_GST ON HSN_GSTID=GSTID WHERE HSNID  IN ('" + Convert.ToInt32(objDS.Tables[0].Rows[0]["HSN"].ToString()) + "') AND GSTID  NOT IN (0,-1)");
                            objdservice.CloseConnection();
                            if (objDS != null)
                            {
                                if (objDS.Tables.Count > 0)
                                {
                                    if (objDS.Tables[0].Rows.Count > 0)
                                    {
                                        txtHSNCode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["HSN_Code"]);
                                        txtGST.Text = Convert.ToString(objDS.Tables[0].Rows[0]["GST_Value"]);
                                    }
                                }
                            }

                            btnSave.Text = "Update"; 
                            pnlStatus.Enabled = true;
                        }
                       

                    } 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void BtnSubgroup_Click(object sender, EventArgs e)
        {
            try
            { 
                varSubgroupCode = 0;
                MainForm.objCP_SubGroup = new CP_SubGroup(); 
                MainForm.objCP_SubGroup.varmastertype = 1;
                MainForm.objCP_SubGroup.ShowDialog(); 
                DataBind objDataBind = new DataBind(); 
                objDataBind.BindComboBoxListSelected("MR_ProductSubGroup", "PRSGID <> 0 AND PRSG_STSID=1", "PRSG_EName,PRSGID", cmbSubGroup, "", "PRSG_EName", "PRSGID");
                cmbSubGroup.SelectedValue = Convert.ToInt16(varSubgroupCode);
                objDataBind = null;
                cmbSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnGroup_Click(object sender, EventArgs e)
        {

            try
            {
                varGroupCode = 0;
                MainForm.objCP_Group = new CP_Group(); 
                MainForm.objCP_Group.varmastertype = 1;
                MainForm.objCP_Group.ShowDialog();
                DataBind objDataBind = new DataBind(); 
                objDataBind.BindComboBoxListSelected("MR_ProductGroup", "PRGID !=0 AND PRG_STSID=1 ORDER BY PRGID", "PRG_EName,PRGID", cmbGroup, "", "PRG_EName", "PRGID"); 
                cmbGroup.SelectedValue = Convert.ToInt16(varGroupCode);
                objDataBind = null;
                cmbGroup.Focus();
                if (varGroupCode != 0)
                {
                    cmbSubGroup.SelectedValue = -1;
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void BtnBrand_Click(object sender, EventArgs e)
        {
            try
            {

               // MainForm.objCP_Brand = new CP_Brand();
               //// MainForm.objCP_Brand.MdiParent = ParentForm;
               // MainForm.objCP_Brand.varmastertype = 1;
               // MainForm.objCP_Brand.ShowDialog();

               // DataBind objDataBind = new DataBind();
               // objDataBind.BindComboBoxListSelected("MR_BRAND", "BDID <> 0 AND BD_STSID=1", "BD_EName,BDID", cmbBrand, "", "BD_EName", "BDID"); 
               // cmbBrand.SelectedValue = Convert.ToInt16(varbrandcode);
               // objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnit_Click(object sender, EventArgs e)
        {
            try
            {
                varUnitCode = 0;
                MainForm.objCP_Unit = new CP_Unit(); 
                MainForm.objCP_Unit.varmastertype = 1;
                MainForm.objCP_Unit.ShowDialog();

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("MR_Unit", "UT_STSID=1 AND UTID!=0 ORDER BY UTID", "UT_Symbol,UTID", cmbUnit, "", "UT_Symbol", "UTID");
                objDataBind.BindComboBoxListSelected("MR_Unit", "UT_STSID=1 AND UTID!=0 ORDER BY UTID", "UT_Symbol,UTID", cmbBulkUnit, "", "UT_Symbol", "UTID");
                cmbUnit.SelectedValue = Convert.ToInt16(varUnitCode);
                objDataBind = null;
                cmbUnit.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                if (cmbPeriod.Visible == true)
                { 
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbPeriod.Focus();
                    }
                }

                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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

        private void TxtUpp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CP_Product_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varupdate == "0")
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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


    