using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
//using Color = System.Drawing.Color;
//using Control = System.Windows.Forms.Control;
//using Font = System.Drawing.Font;

namespace ROMS
{
    public partial class CP_Product : Form
    {
        public class EditableImage
        {
            public string FilePath { get; set; }
            public Bitmap EditedImage { get; set; }
            public PictureBox Thumbnail { get; set; }
            public Panel ContainerPanel { get; set; }
            public int RotationAngle { get; set; } = 0;
        }
        bool isLoadingGrid = false;

        private List<EditableImage> editableImages = new List<EditableImage>();
        private Image originalImage;
        private float zoom = 1.0f;
        private bool cropMode = false;
        private Point dragStartPoint;
        private const int HANDLE_SIZE = 8;
        private Rectangle cropRect;
        private enum CropHandle
        {
            None, TopLeft, TopRight, BottomLeft, BottomRight,
            Left, Right, Top, Bottom
        }
        private CropHandle currentHandle = CropHandle.None;




        DataValidation objvalidation = new DataValidation();
        DataError objError;
        DataTable dtProductHSN = new DataTable();
        DataTable dtPurHSN = new DataTable();
        DataTable dtSalesHSN = new DataTable();
        DataTable dtPrice_Markup = new DataTable();
        public int varUpDownKey = 0, varUpDownKeyPurLocation = 0, varUpDownKeySalesLocation = 0;
        public int varproductcode = 0;
        public string varcompanycode;
        public int pbFormStatus = 0;
        public string varstatecode = "";
        public string varSubgroupId = "";
        public string vargroupId = "";
        public string varupdate = "0";
        public int varProductload = 0;
        public decimal varuppValue = 0;
        public int pbProHSNID = 0, pbSalesHSNID = 0;
        //tool tip
        private ToolTip tpContactNo = new ToolTip();
        private ToolTip tpAltContactNo = new ToolTip();
        private ToolTip tpemail = new ToolTip();
        private ToolTip tpgstin = new ToolTip();
        private ToolTip tpfssai = new ToolTip();
        private ToolTip tpIntermediateUnit = new ToolTip();
        private ToolTip tpStocktaken = new ToolTip();
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
        private ToolTip tppurchaselocation = new ToolTip();
        private ToolTip tpsaleslocation = new ToolTip();
        private ToolTip tppurchaserack = new ToolTip();
        private ToolTip tpsalesrack = new ToolTip();
        private ToolTip tpshelflifevalue = new ToolTip();
        private ToolTip tpHsnCode = new ToolTip();
        private ToolTip tpgst = new ToolTip();
        private ToolTip tpMxstock = new ToolTip();
        private ToolTip tpUPP = new ToolTip();
        private ToolTip tpPurHSN = new ToolTip();
        private ToolTip tpSalesHSN = new ToolTip();
        private ToolTip tpVerifier = new ToolTip();
        private ToolTip tpSalesPICode = new ToolTip();
        private List<string> imagePaths = new List<string>();

        public int varGroupCode = 0, varSubgroupCode = 0, varUnitCode = 0, varbrandcode = 0, varGroupId = 0, varSubGroupId = 0, varHsnId = 0, varUnitid = 0, varcompanyid = 0, varBrandId = 0, varBatchCode = 0, varPURSLID = 0, varPURRKID = 0, varSALESLID = 0, varSALERKID = 0, pbCloneFlag = 0, varPurHSNID = 0, varSalesHSNID = 0, varPurEffectiveFromErr = 0, varSalesEffectiveFromErr = 0;
        public string varSubGroupName = "", varGroupName = "", varPurchaseLocation = "", varSalesLocation = "", varPurchaseRack = "", varMasterType = "0", varSalesRack = "", varBrandName = "", varRackDescription = "", varEname = "", varGRNid = "0", varNewproid = "0", varPurHSNCode = "", varPurGST = "", varSalesHSNCode = "", varSalesGST = "", varSubgroupType = "";
        int varF5Flag = 0;
        int varStatusFlag = 0, varStatusID = 0;
        public bool PurStkLocViewAcess = false, PurStkLocEditAcess = false,
            SalesStkLocViewAcess = false, SalesStkLocEditAcess = false,
            RetailRateViewAcess = false, RetailRateEditAcess = false,
            WholeSaleRateViewAcess = false, WholeSaleRateEditAcess = false,
            SalesHSNViewAcess = false, SalesHSNEditAcess = false,
            PurHSNViewAcess = false, PurHSNEditAcess = false;
        string Subgroupprivilege = "", Groupprivilege = "", Brandprivilege = "", Unitprivilege = "";
        public CP_Product()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lvHsnCode.Visible = false;
                if (txtWeight.Text.Contains(".") && txtWeight.Text.Length < 2)
                {
                    txtWeight.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtWeight, "Please enter valid weight");
                    return;
                }
                if (txtGrossWeight.Text.Contains(".") && txtGrossWeight.Text.Length < 2)
                {
                    txtGrossWeight.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtGrossWeight, "Please enter valid gross weight");
                    return;
                }
                if (txtMinStock.Text.Contains(".") && txtMinStock.Text.Length < 2)
                {
                    txtMinStock.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtMinStock, "Please enter valid min stock");
                    return;
                }
                if (txtMaxStock.Text.Contains(".") && txtMaxStock.Text.Length < 2)
                {
                    txtMaxStock.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtMaxStock, "Please enter valid max stock");
                    return;
                }
                if (txtReOrderQty.Text.Contains(".") && txtReOrderQty.Text.Length < 2)
                {
                    txtReOrderQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtReOrderQty, "Please enter valid reorder qty");
                    return;
                }
                if (txtRMinSaleQty.Text.Contains(".") && txtRMinSaleQty.Text.Length < 2)
                {
                    txtRMinSaleQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtRMinSaleQty, "Please enter valid retail min sales stock");
                    return;
                }
                if (txtRetailRate.Text.Contains(".") && txtRetailRate.Text.Length < 2)
                {
                    txtRetailRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtRetailRate, "Please enter valid retail rate");
                    return;
                }
                if (txtWMinSaleQty.Text.Contains(".") && txtWMinSaleQty.Text.Length < 2)
                {
                    txtWMinSaleQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtWMinSaleQty, "Please enter valid wholesales min qty");
                    return;
                }
                if (txtWSaleRate.Text.Contains(".") && txtWSaleRate.Text.Length < 2)
                {
                    txtWSaleRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtWSaleRate, "Please enter valid wholesales rate");
                    return;
                }
                if (txtBarcode.Text.Contains(".") && txtBarcode.Text.Length < 2)
                {
                    txtBarcode.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtBarcode, "Please enter valid barcode");
                    return;
                }
                if (Convert.ToInt16(cmbProductType.SelectedValue) == 342 && Convert.ToInt16(lblParentcode.Text) == 0)
                {
                    txtProductName.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtProductName, "Please enter valid parent product");
                    return;
                }
                if (Convert.ToString(cmbUnit.SelectedValue) != "-1" && cmbUnit.Text != "" && Convert.ToString(cmbChildUnit.SelectedValue) != "-1" && cmbChildUnit.Text != "")
                {
                    if (Convert.ToString(cmbUnit.SelectedValue) == Convert.ToString(cmbChildUnit.SelectedValue))
                    {
                        MessageBox.Show("Base unit and upp unit cannot be same!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return;
                    }
                }
                if (grdPurHSN.Rows.Count < 1 && cbCompleted.Checked == true)
                {
                    SPDataService objDataService = new SPDataService();
                    string varMessage = objDataService.udfnGetMessages(149);
                    objDataService.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbProduct.TabPages[1].Enabled = true;
                    tbProduct.SelectedIndex = 1;
                    return;
                }
                /*
                if (grdSalesHSN.Rows.Count < 1)
                {
                    MessageBox.Show("Please add atleast one sales hsn.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                */
                dtProductHSN.Rows.Clear();
                foreach (DataRow row in dtPurHSN.Rows)
                {
                    dtProductHSN.ImportRow(row);
                }
                foreach (DataRow row in dtSalesHSN.Rows)
                {
                    dtProductHSN.ImportRow(row);
                }
                if (grdPurHSN.Rows.Count > 0 || grdSalesHSN.Rows.Count > 0)
                {
                    varPurEffectiveFromErr = 0;
                    varSalesEffectiveFromErr = 0;
                    udfnEffectiveDateValidation();
                }
                errItems.Clear();
                if (varPurEffectiveFromErr == 0 && varSalesEffectiveFromErr == 0)
                {
                    udfnSave();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { varF5Flag = 0; }
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

                if (Convert.ToString(txtItemNameEnglish.Text).Trim() == "")
                {
                    errItems.SetError(txtItemNameEnglish, "Please enter product name in english");
                    txtItemNameEnglish.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpengname.ShowAlways = true;
                    tpplno.Show("Please enter product name in english", txtItemNameEnglish, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtItemNameTamil.Text).Trim() == "")
                {
                    errItems.SetError(txtItemNameTamil, "Please enter product name in tamil");
                    txtItemNameTamil.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tptamname.ShowAlways = true;
                    tptamname.Show("Please enter product name in tamil", txtItemNameTamil, 5000);
                    blnErrorFlag = true;
                }
                if (varStatusFlag == 1 && Convert.ToString(txtTeller.Text).Trim() == "")
                {
                    errItems.SetError(txtTeller, "Please enter name.");
                    txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerifier.ShowAlways = true;
                    tpVerifier.Show("Please enter name.", txtTeller, 5000);
                    blnErrorFlag = true;
                }
                if (cbCompleted.Checked == true)
                {
                    if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                    {
                        errItems.SetError(cmbConcern, "Please select company");
                        cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpcompanyname.ShowAlways = true;
                        tpcompanyname.Show("Please select company", cmbConcern, 5000);
                        blnErrorFlag = true;
                    }
                    if (txtBrand.Text == "")
                    {
                        txtBrand.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errItems.SetError(txtBrand, "Please select brand");
                        blnErrorFlag = true;
                    }
                    if (Convert.ToInt32(cmbChildUnit.SelectedValue) != -1)
                    {
                        if (Convert.ToInt32(cmbProductCategory.SelectedValue) == 14 && Convert.ToInt32(cmbProductType.SelectedValue) == 342)
                        {
                            if (Convert.ToString(txtUpp.Text) == "" || Convert.ToString(txtUpp.Text) == "0")
                            {
                                errItems.SetError(txtUpp, "Please enter upp");
                                txtUpp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpUPP.ShowAlways = true;
                                tpUPP.Show("Please enter upp", txtUpp, 5000);
                                blnErrorFlag = true;
                            }
                        }
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
                    if (Convert.ToString(txtMaxStock.Text).Trim() != "")
                    {
                        int varMinStock = 0; int varMaxStock = 0;
                        if (Convert.ToString(txtMinStock.Text) != "") { varMinStock = Convert.ToInt32(txtMinStock.Text); }
                        if (Convert.ToString(txtMaxStock.Text) != "") { varMaxStock = Convert.ToInt32(txtMaxStock.Text); }
                        if (varMaxStock < varMinStock)
                        {
                            errItems.SetError(txtMaxStock, "Max stock should be greater that min stock!");
                            txtMaxStock.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpMxstock.ShowAlways = true;
                            tpMxstock.Show("Max stock should be greater that min stock!", txtMaxStock, 5000);
                            blnErrorFlag = true;
                        }
                    }
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
                        errItems.SetError(cmbProductCategory, "Please select product category");
                        cmbProductCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpprd.ShowAlways = true;
                        tpprd.Show("Please select product category", cmbProductCategory, 5000);
                        blnErrorFlag = true;
                    }

                    if (Convert.ToString(lblSubGroupCode.Text) == "" || Convert.ToString(lblSubGroupCode.Text) == "0" || Convert.ToString(txtSubGroup.Text) == "")
                    {
                        errItems.SetError(txtSubGroup, "Please select subgroup");
                        txtSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpprdSG.ShowAlways = true;
                        tpprdSG.Show("Please select subgroup", txtSubGroup, 5000);
                        blnErrorFlag = true;
                    }

                    if (Convert.ToString(lblGroupCode.Text) == "" || Convert.ToString(lblGroupCode.Text) == "0" || Convert.ToString(txtGroup.Text) == "")
                    {
                        errItems.SetError(txtGroup, "Please select group");
                        txtGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpprdG.ShowAlways = true;
                        tpprdG.Show("Please select group", txtGroup, 5000);
                        blnErrorFlag = true;
                    }
                    if (txtPurLocation.Text == "")
                    {
                        txtPurLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        tppurchaselocation.ShowAlways = true;
                        tppurchaselocation.Show("Please select valid purchase stock location", txtPurLocation, 5000);
                        txtPurRack.Text = "";
                        lblPurRackCode.Text = "0";
                        txtRackDescription.Text = "";
                        blnErrorFlag = true;
                    }
                    if (txtSaleLocation.Text == "")
                    {
                        txtSaleLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        tpsaleslocation.ShowAlways = true;
                        tpsaleslocation.Show("Please select valid sales location", txtSaleLocation, 5000);
                        txtSaleRack.Text = "";
                        lblSaleRackCode.Text = "0";
                        txtRackDescriptionSales.Text = "";
                        blnErrorFlag = true;
                    }
                    //if (Convert.ToString(cmbBrand.SelectedValue) == "" || Convert.ToString(cmbBrand.SelectedValue) == "-1")
                    //{
                    //    errItems.SetError(cmbBrand, "Please select Brand");
                    //    cmbBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpbrand.ShowAlways = true;
                    //    tpbrand.Show("Please select Brand", cmbBrand, 5000);
                    //    blnErrorFlag = true;
                    //}
                    if (Convert.ToString(cmbUnit.SelectedValue) == "" || Convert.ToString(cmbUnit.SelectedValue) == "-1")
                    {
                        errItems.SetError(cmbUnit, "Please select unit");
                        cmbUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpunit.ShowAlways = true;
                        tpunit.Show("Please select unit", cmbUnit, 5000);
                        blnErrorFlag = true;
                    }
                    /*
                    // Check product HSN is valid or not
                    string varId_HSN = "0";
                    DataSet objDsHSN = new DataSet();
                    SPDataService objDs = new SPDataService();
                    objDsHSN = objDs.udfnHsnList(9, 0, Convert.ToInt32(cmbGst.SelectedValue), 0, txtHsnName.Text.Trim(), txtHSNCode.Text.Trim());
                    objDs.CloseConnection();
                    if (objDsHSN != null)
                    {
                        if (objDsHSN.Tables.Count > 0)
                        {
                            if (objDsHSN.Tables[0].Rows.Count > 0)
                            {
                                varId_HSN = Convert.ToString(objDsHSN.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblHsnName.Text = Convert.ToString(varId_HSN);
                    if (Convert.ToString(lblHsnName.Text) == "" || Convert.ToString(lblHsnName.Text) == "0" || Convert.ToString(lblHsnName.Text) == "-1")
                    {
                        errItems.SetError(txtHSNCode, "Please enter valid HSN code");
                        txtHSNCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpHsnCode.ShowAlways = true;
                        tpHsnCode.Show("Please enter valid HSN code", txtHSNCode, 5000);
                        blnErrorFlag = true;
                        txtHsnName.Text = "";
                    }

                    if (Convert.ToString(cmbGst.SelectedValue) == "" || Convert.ToString(cmbGst.SelectedValue) == "-1")
                    {
                        errItems.SetError(cmbGst, "Please select GST%");
                        cmbGst.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpgst.ShowAlways = true;
                        tpgst.Show("Please select GST%", cmbGst, 5000);
                        blnErrorFlag = true;
                    }
                    */



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

                    if (Convert.ToString(cmbBatchNoEntry.SelectedValue) == "" || Convert.ToString(cmbBatchNoEntry.SelectedValue) == "-1")
                    {
                        errItems.SetError(cmbBatchNoEntry, "Please select Batch No.");
                        cmbBatchNoEntry.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpcompanyname.ShowAlways = true;
                        tpcompanyname.Show("Please select sales Batch No.", cmbBatchNoEntry, 5000);
                        blnErrorFlag = true;
                    }
                    if (Convert.ToInt32(cmbBatchNoEntry.SelectedValue) == 72)
                    {
                        if (Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "" || Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "-1")
                        {
                            errItems.SetError(cmbBatchNoGeneration, "Please select Batch No. generation");
                            cmbBatchNoGeneration.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpcompanyname.ShowAlways = true;
                            tpcompanyname.Show("Please select sales Batch No. generation", cmbBatchNoGeneration, 5000);
                            blnErrorFlag = true;
                        }
                    }
                    if (cmbProductType.Text == "Child")
                    {
                        if (Convert.ToString(cmbChildUnit.SelectedValue) == "" || Convert.ToString(cmbChildUnit.SelectedValue) == "-1")
                        {
                            errItems.SetError(cmbChildUnit, "Please select upp Unit");
                            cmbChildUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpcompanyname.ShowAlways = true;
                            tpcompanyname.Show("Please select upp Unit", cmbChildUnit, 5000);
                            blnErrorFlag = true;
                        }
                    }


                    //if (Convert.ToString(cmbPeriod.SelectedValue) == "" || Convert.ToString(cmbPeriod.SelectedValue) == "-1")
                    //{
                    //    if (cmbPeriod.Visible == true)
                    //    {
                    //        errItems.SetError(cmbPeriod, "Please select shelflife");
                    //        cmbPeriod.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //        tpcompanyname.ShowAlways = true;
                    //        tpcompanyname.Show("Please select shelflife", cmbPeriod, 5000);
                    //        blnErrorFlag = true;
                    //    }
                    //    else
                    //    {
                    //        errItems.SetError(cbExpiry, "Please select shelflife");
                    //        cbExpiry.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //        tpcompanyname.ShowAlways = true;
                    //        tpcompanyname.Show("Please select shelflife", cbExpiry, 5000);
                    //        blnErrorFlag = true;
                    //    }
                    //}
                    //if(cbExpiry.Checked==false)
                    //{
                    //    errItems.SetError(cbExpiry, "Please select shelflife");
                    //    cbExpiry.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpcompanyname.ShowAlways = true;
                    //    tpcompanyname.Show("Please select shelflife", cbExpiry, 5000);
                    //    blnErrorFlag = true;
                    //}
                    if (Convert.ToInt32(cmbBatchNoEntry.SelectedValue) == 72 && Convert.ToInt32(cmbBatchNoGeneration.SelectedValue) == -1)
                    {
                        errItems.SetError(cmbBatchNoGeneration, "Please select batcn no. generation");
                        cmbBatchNoGeneration.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpcompanyname.ShowAlways = true;
                        tpcompanyname.Show("Please select sales batcn no. generation", cmbBatchNoGeneration, 5000);
                        blnErrorFlag = true;
                    }
                    //if (Convert.ToString(txtHSNCode.Text).Trim() == "")
                    //{
                    //    errItems.SetError(txtHSNCode, "Please enter HSN code");
                    //    txtHSNCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpHsnCode.ShowAlways = true;
                    //    tpHsnCode.Show("Please enter HSN code", txtHSNCode, 5000);
                    //    blnErrorFlag = true;
                    //}
                    if (cbExpiry.Checked == true)
                    {
                        errItems.Clear();
                        if (Convert.ToInt32(cmbPeriod.SelectedValue) == -1)
                        {
                            errItems.SetError(cmbPeriod, "Please select shelflife");
                            cmbPeriod.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpcompanyname.ShowAlways = true;
                            tpcompanyname.Show("Please select shelflife", cmbPeriod, 5000);
                            blnErrorFlag = true;
                        }
                        if (txtSelfLife.Text == "")
                        {
                            errItems.SetError(txtSelfLife, "Please enter shelflife");
                            txtSelfLife.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpplno.ShowAlways = true;
                            tpplno.Show("Please enter shelflife", txtSelfLife, 5000);
                            blnErrorFlag = true;
                        }
                        else
                        {
                            if (Convert.ToInt32(txtSelfLife.Text) == 0)
                            {
                                errItems.SetError(txtSelfLife, "Please enter valid shelflife");
                                txtSelfLife.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpshelflifevalue.ShowAlways = true;
                                tpshelflifevalue.Show("Please enter valid shelflife", txtSelfLife, 5000);
                                blnErrorFlag = true;
                            }
                        }
                    }
                    if (txtWeight.Text == "")
                    {
                        txtWeight.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errItems.SetError(txtWeight, "Please enter weight");
                        blnErrorFlag = true;
                    }
                    else
                    {
                        if (Convert.ToDouble(txtWeight.Text) == 0)
                        {
                            txtWeight.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            errItems.SetError(txtWeight, "Please enter valid weight");
                            blnErrorFlag = true;
                        }
                    }
                    if (txtGrossWeight.Text == "")
                    {
                        txtGrossWeight.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errItems.SetError(txtGrossWeight, "Please enter the gross weight");
                        blnErrorFlag = true;
                    }
                    else
                    {
                        if (Convert.ToDouble(txtGrossWeight.Text) == 0)
                        {
                            txtGrossWeight.BackColor = ColorTranslator.FromHtml("#fabdbd");
                            errItems.SetError(txtGrossWeight, "Please enter valid gross weight");
                            blnErrorFlag = true;
                        }
                    }
                    /* Check product sub group is valid or not*/
                    string varId_SubGroup = "0";
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblSubGroupCode.Text = Convert.ToString(varId_SubGroup);
                    if (varId_SubGroup == "0" || varId_SubGroup == "-1")
                    {
                        errItems.SetError(txtSubGroup, "Please select valid subgroup");
                        txtSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpprdSG.ShowAlways = true;
                        tpprdSG.Show("Please select valid subgroup", txtSubGroup, 5000);
                        blnErrorFlag = true;
                    }
                    /* Check product group is valid or not*/
                    string varId_Group = "0";
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, Convert.ToInt32(varId_SubGroup), txtGroup.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblGroupCode.Text = Convert.ToString(varId_Group);
                    if (varId_Group == "0" || varId_Group == "-1")
                    {
                        errItems.SetError(txtGroup, "Please select valid group");
                        txtGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpprdG.ShowAlways = true;
                        tpprdG.Show("Please select valid group", txtGroup, 5000);
                        blnErrorFlag = true;
                    }
                    if (txtBrand.Text != "")
                    {
                        /* Check product brand is valid or not*/
                        string varId_Brand = "0";
                        DataSet objDsBrand = new DataSet();
                        SPDataService objDServ2 = new SPDataService();
                        objDsBrand = objDServ2.udfnBrandList(9, "", 0, Convert.ToInt32(lblSubGroupCode.Text), 0, txtBrand.Text.Trim(), 0);
                        objDServ2.CloseConnection();
                        if (objDsBrand != null)
                        {
                            if (objDsBrand.Tables.Count > 0)
                            {
                                if (objDsBrand.Tables[0].Rows.Count > 0)
                                {
                                    varId_Brand = Convert.ToString(objDsBrand.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        lblBrand.Text = Convert.ToString(varId_Brand);
                        if (varId_Brand == "0" || varId_Brand == "-1")
                        {
                            errItems.SetError(txtBrand, "Please select valid brand");
                            txtBrand.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpbrand.ShowAlways = true;
                            tpbrand.Show("Please select valid brand", txtBrand, 5000);
                            blnErrorFlag = true;
                        }
                    }
                    /* Check purchase location is valid or not*/
                    if (txtPurLocation.Text != "")
                    {
                        string varId_PurLocation = "0";
                        DataSet objDsPurLoc = new DataSet();
                        SPDataService objDServ3 = new SPDataService();

                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 14;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtPurLocation.Text.Trim();
                        objDsPurLoc = objDServ3.udfnStockLocationList(objMR_Location);
                        objDServ3.CloseConnection();
                        //objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtPurLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        if (objDsPurLoc != null)
                        {
                            if (objDsPurLoc.Tables.Count > 0)
                            {
                                if (objDsPurLoc.Tables[0].Rows.Count > 0)
                                {
                                    varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        lblPurLocationCode.Text = Convert.ToString(varId_PurLocation);
                        if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                        {
                            errItems.SetError(txtPurLocation, "Please select valid purchase stock location");
                            txtPurLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tppurchaselocation.ShowAlways = true;
                            tppurchaselocation.Show("Please select valid purchase stock location", txtPurLocation, 5000);
                            blnErrorFlag = true;
                        }
                    }
                    if (Convert.ToString(txtPurRack.Text) != "" && Convert.ToString(txtPurRack.Text) != "None")
                    {
                        //check location have a rack or not
                        string varId_PurchaseRack = "0";
                        DataSet objDsPurchaseRack = new DataSet();
                        SPDataService objDServ6 = new SPDataService();
                        objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(lblPurLocationCode.Text), 0, txtPurRack.Text.Trim(), 0, 0);
                        objDServ6.CloseConnection();
                        if (txtPurRack.Text.Trim() != "")
                        {
                            if (lblPurLocationCode.Text != "0")
                            {
                                if (objDsPurchaseRack != null)
                                {
                                    if (objDsPurchaseRack.Tables.Count > 0)
                                    {
                                        if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                        {
                                            varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                        }
                                    }
                                }
                                lblPurRackCode.Text = Convert.ToString(varId_PurchaseRack);
                                if (varId_PurchaseRack == "0" || varId_PurchaseRack == "-1")
                                {
                                    errItems.SetError(txtPurRack, "Please select valid purchase rack");
                                    txtPurRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tppurchaserack.ShowAlways = true;
                                    tppurchaserack.Show("Please select valid purchase rack", txtPurRack, 5000);
                                    blnErrorFlag = true;
                                }
                            }
                        }
                        else
                        {
                            if (lblPurLocationCode.Text != "0")
                            {
                                if (objDsPurchaseRack != null)
                                {
                                    if (objDsPurchaseRack.Tables.Count > 0)
                                    {
                                        if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                        {
                                            varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                        }
                                    }
                                }
                                lblPurRackCode.Text = Convert.ToString(varId_PurchaseRack);
                                if (varId_PurchaseRack != "0")
                                {
                                    errItems.SetError(txtPurRack, "Please enter rack");
                                    txtPurRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tppurchaserack.ShowAlways = true;
                                    tppurchaserack.Show("Please enter rack", txtPurRack, 5000);
                                    blnErrorFlag = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        txtPurRack.BackColor = Color.White;
                        lblPurRackCode.Text = "0";
                    }
                    /* Check sales stock location is valid or not*/
                    if (txtSaleLocation.Text != "")
                    {
                        string varId_SalesLocation = "0";
                        DataSet objDsSalesLoc = new DataSet();
                        SPDataService objDServ5 = new SPDataService();
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 14;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtSaleLocation.Text.Trim();
                        objDsSalesLoc = objDServ5.udfnStockLocationList(objMR_Location);
                        objDServ5.CloseConnection();
                        //objDsSalesLoc = objDServ5.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSaleLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        if (objDsSalesLoc != null)
                        {
                            if (objDsSalesLoc.Tables.Count > 0)
                            {
                                if (objDsSalesLoc.Tables[0].Rows.Count > 0)
                                {
                                    varId_SalesLocation = Convert.ToString(objDsSalesLoc.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        lblSaleLocationCode.Text = Convert.ToString(varId_SalesLocation);
                        if (varId_SalesLocation == "0" || varId_SalesLocation == "-1")
                        {
                            errItems.SetError(txtSaleLocation, "Please select valid sales stock location");
                            txtSaleLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpsaleslocation.ShowAlways = true;
                            tpsaleslocation.Show("Please select valid sales stock location", txtSaleLocation, 5000);
                            blnErrorFlag = true;
                        }
                    }
                    if (Convert.ToString(txtSaleRack.Text) != "" && Convert.ToString(txtSaleRack.Text) != "None")
                    {
                        //check Sales location have a rack or not//
                        string varId_SalesRack = "0";
                        DataSet objDsSalesRack = new DataSet();
                        SPDataService objDServ7 = new SPDataService();
                        objDsSalesRack = objDServ7.udfnRackList(17, 0, 0, Convert.ToInt32(lblSaleLocationCode.Text), 0, txtSaleRack.Text.Trim(), 0, 0);
                        objDServ7.CloseConnection();
                        if (txtSaleRack.Text.Trim() != "")
                        {
                            if (lblSaleLocationCode.Text != "0")
                            {
                                if (objDsSalesRack != null)
                                {
                                    if (objDsSalesRack.Tables.Count > 0)
                                    {
                                        if (objDsSalesRack.Tables[0].Rows.Count > 0)
                                        {
                                            varId_SalesRack = Convert.ToString(objDsSalesRack.Tables[0].Rows[0][0]);
                                        }
                                    }
                                }
                                lblSaleRackCode.Text = Convert.ToString(varId_SalesRack);
                                if ((varId_SalesRack == "0" || varId_SalesRack == "-1") && txtSaleRack.Enabled)
                                {
                                    errItems.SetError(txtSaleRack, "Please select valid sales rack");
                                    txtSaleRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpsalesrack.ShowAlways = true;
                                    tpsalesrack.Show("Please select valid sales rack", txtSaleRack, 5000);
                                    blnErrorFlag = true;
                                }
                            }
                        }
                        else
                        {
                            if (lblSaleLocationCode.Text != "0")
                            {
                                if (objDsSalesRack != null)
                                {
                                    if (objDsSalesRack.Tables.Count > 0)
                                    {
                                        if (objDsSalesRack.Tables[1].Rows.Count > 0)
                                        {
                                            varId_SalesRack = Convert.ToString(objDsSalesRack.Tables[1].Rows[0][0]);
                                        }
                                    }
                                }
                                lblSaleRackCode.Text = Convert.ToString(varId_SalesRack);
                                if (varId_SalesRack != "0")
                                {
                                    errItems.SetError(txtSaleRack, "Please enter rack");
                                    txtSaleRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpsalesrack.ShowAlways = true;
                                    tpsalesrack.Show("Please enter rack", txtSaleRack, 5000);
                                    blnErrorFlag = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        txtSaleRack.BackColor = Color.White;
                        lblSaleRackCode.Text = "0";
                    }

                    //  if (btnSave.Text == "Save" && cbCompleted.Checked == true)
                    /* Changed by deepa on 29-07-2025 - Location validation for both save and update mode*/
                    //if (cbCompleted.Checked == true)
                    //{
                    //    /* Check Location Based on Subgroup or not */
                    //    //if (Convert.ToString(txtPurLocation.Text) != "")
                    //    //{
                    //    string varSubLocationId = "0";
                    //    DataSet objDsSubGroup = new DataSet();
                    //    SPDataService objDServ = new SPDataService();
                    //    objDsSubGroup = objDServ.udfnStockLocationList(19, 0, 0, 0, txtPurLocation.Text.Trim(), Convert.ToInt32(lblSubGroupCode.Text), 0, 0, "", "", 0);
                    //    objDServ.CloseConnection();
                    //    if (objDsSubGroup != null)
                    //    {
                    //        if (objDsSubGroup.Tables.Count > 0)
                    //        {
                    //            if (objDsSubGroup.Tables[0].Rows.Count > 0)
                    //            {
                    //                varSubLocationId = Convert.ToString(objDsSubGroup.Tables[0].Rows[0][0]);
                    //            }
                    //        }
                    //    }
                    //    lblPurLocationCode.Text = Convert.ToString(varSubLocationId);
                    //    if ((varSubLocationId == "0" || varSubLocationId == "-1"))
                    //    {
                    //        errItems.SetError(txtPurLocation, "Please select valid purchase stock location");
                    //        txtPurLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //        tppurchaselocation.ShowAlways = true;
                    //        tppurchaselocation.Show("Please select valid purchase stock location", txtPurLocation, 5000);
                    //        blnErrorFlag = true;
                    //    }
                    //    //}
                    //    /* Check Rack Based on Subgroup or not */
                    //    //if (Convert.ToString(txtPurRack.Text) != "" && Convert.ToString(txtPurRack.Text)!="None")
                    //    //{

                    //    //Rack Validation No Needed 
                    //    /*
                    //    string varSubRackId = "0";
                    //    DataSet objDsSubGroupRack = new DataSet();
                    //    SPDataService objDSRack = new SPDataService();
                    //    objDsSubGroupRack = objDSRack.udfnRackList(12, 0, 0, Convert.ToInt32(lblPurLocationCode.Text), 0, txtPurRack.Text.Trim(), Convert.ToInt32(lblSubGroupCode.Text), 0);
                    //    objDSRack.CloseConnection();
                    //    if (objDsSubGroupRack != null)
                    //    {
                    //        if (objDsSubGroupRack.Tables.Count > 0)
                    //        {
                    //            if (objDsSubGroupRack.Tables[0].Rows.Count > 0)
                    //            {
                    //                varSubRackId = Convert.ToString(objDsSubGroupRack.Tables[0].Rows[0][0]);
                    //            }
                    //        }
                    //    }
                    //    lblPurRackCode.Text = Convert.ToString(varSubRackId);
                    //    if ((varSubRackId == "0" || varSubRackId == "-1") && txtPurRack.Enabled)
                    //    {
                    //        errItems.SetError(txtPurRack, "Please select valid purchase rack");
                    //        txtPurRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //        tppurchaserack.ShowAlways = true;
                    //        tppurchaserack.Show("Please select valid purchase rack", txtPurRack, 5000);
                    //        blnErrorFlag = true;
                    //    }
                    //    */
                    //    //}
                    //}
                    if (grdPurHSN.Rows.Count < 1)
                    {
                        SPDataService objDataService = new SPDataService();
                        string varMessage = objDataService.udfnGetMessages(149);
                        objDataService.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrorFlag = true;
                        tbProduct.TabPages[1].Enabled = true;
                        tbProduct.SelectedIndex = 1;
                    }

                }
                if (Convert.ToInt32(cmbProductCategory.SelectedValue) == 16 && (Convert.ToString(txtIntermediateUPP.Text.Trim()) != "" || Convert.ToString(txtProductionMSQ.Text.Trim()) != ""))
                {
                    if (Convert.ToInt32(cmbIntermediateUnit.SelectedValue) == -1)
                    {
                        errItems.SetError(cmbIntermediateUnit, "Please select intermediate unit");
                        cmbIntermediateUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIntermediateUnit.ShowAlways = true;
                        tpIntermediateUnit.Show("Please select intermediate unit", cmbIntermediateUnit, 5000);
                        blnErrorFlag = true;
                    }
                }
                else
                {
                    cmbIntermediateUnit.BackColor = Color.White;
                }
                if (Convert.ToInt32(cmbProductCategory.SelectedValue) == 16 && Convert.ToInt32(cmbIntermediateUnit.SelectedValue) != -1)
                {
                    if (Convert.ToString(txtIntermediateUPP.Text.Trim()) == "")
                    {
                        errItems.SetError(txtIntermediateUPP, "Please enter intermediate upp");
                        txtIntermediateUPP.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIntermediateUnit.ShowAlways = true;
                        tpIntermediateUnit.Show("Please enter intermediate upp", txtIntermediateUPP, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        txtIntermediateUPP.BackColor = Color.White;
                    }
                    if (Convert.ToString(txtProductionMSQ.Text.Trim()) == "")
                    {
                        errItems.SetError(txtProductionMSQ, "Please enter production msq");
                        txtProductionMSQ.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpIntermediateUnit.ShowAlways = true;
                        tpIntermediateUnit.Show("Please enter production msq", txtProductionMSQ, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        txtProductionMSQ.BackColor = Color.White;
                    }
                }

                if (Convert.ToInt32(cmbProductCategory.SelectedValue) == 16 && Convert.ToInt32(cmbStockTakken.SelectedValue) == -1)
                {
                    errItems.SetError(cmbStockTakken, "Please select stock taken");
                    cmbStockTakken.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStocktaken.ShowAlways = true;
                    tpStocktaken.Show("Please select stock taken", cmbStockTakken, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    cmbStockTakken.BackColor = Color.White;
                }
                if (chkSalesProduct.Checked == true)
                {
                    if (txtSalesPICode.Text.Trim() == "")
                    {
                        errItems.SetError(txtSalesPICode, "Please enter sales pi code");
                        txtSalesPICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSalesPICode.ShowAlways = true;
                        tpSalesPICode.Show("Please enter sales pi code", txtSalesPICode, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (blnErrorFlag == false)
                {
                    SPDataService objspdservice = new SPDataService();
                    string result = "";
                    string varStatus = "1";
                    double netweight = 0, grossweight = 0, minstk = 0, maxstk = 0, reorderqty = 0, rminsale = 0, retailrate = 0, wminsaleqty = 0, wsalesrate = 0;
                    int shelflife = 0, rackmoq = 0, varshelflife = 0, varrmproduction = 0, varMRPflag = 0;
                    errItems.Clear();
                    udfncolorchange();

                    if (rbInActive.Checked == true && cbCompleted.Checked == false)
                    {
                        varStatus = "120";
                    }
                    else if (cbCompleted.Checked == true)
                    {
                        if (rbActive.Checked == true && cbCompleted.Checked == true)
                        {
                            varStatus = "1";
                        }
                        else if (rbInActive.Checked == true && cbCompleted.Checked == true && (varStatusID != 71 && varStatusID != 120))
                        {
                            varStatus = "2"; //Should not be pending or draft
                        }
                        else
                        {
                            varStatus = "71";
                        }
                    }
                    if (cbExpiry.Checked == true)
                    {
                        varshelflife = 1;
                    }
                    else
                    {
                        varshelflife = 0;
                    }
                    //if (cbRMFromProduction.Checked == true)
                    //{
                    //    varrmproduction = 1;
                    //}
                    //else
                    //{
                    //    varrmproduction = 0;
                    //}
                    if (Convert.ToInt32(cmbRM.SelectedValue) == 241)
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
                    int varviewtype = 0, varupdateproductcode = 0;
                    string varorignator = "", varbrandid = "0", varGroupId = "0", varSubgroupId = "0", varPurLocationId = "0", varSalesLocationId = "0", varPurRackId = "0", varSalesRackId = "0";

                    if (txtBrand.Text.Trim() != "")
                    {
                        varbrandid = lblBrand.Text;
                    }
                    if (txtGroup.Text.Trim() != "")
                    {
                        varGroupId = lblGroupCode.Text;
                    }
                    if (txtSubGroup.Text.Trim() != "")
                    {
                        varSubgroupId = lblSubGroupCode.Text;
                    }
                    if (txtPurLocation.Text.Trim() != "")
                    {
                        varPurLocationId = lblPurLocationCode.Text;
                    }
                    if (txtPurRack.Text.Trim() != "")
                    {
                        varPurRackId = lblPurRackCode.Text;
                    }
                    if (txtSaleLocation.Text.Trim() != "")
                    {
                        varSalesLocationId = lblSaleLocationCode.Text;
                    }
                    if (txtSaleRack.Text.Trim() != "")
                    {
                        varSalesRackId = lblSaleRackCode.Text;
                    }
                    if ((varproductcode == 0 || pbCloneFlag == 1))
                    {
                        varviewtype = 0;
                        varorignator = "Product Create";
                        varupdateproductcode = 0;
                    }
                    else if (varproductcode != 0)
                    {
                        varviewtype = 1;
                        varorignator = "Product Update";
                        varupdateproductcode = varproductcode;
                        varupdate = "1";
                    }
                    int varSupplierId = 0, varScheduleid = 0, varGRNID = 0, varNewPRoid = 0;
                    if (varMasterType == "1")
                    {
                        varSupplierId = Convert.ToInt32(MainForm.objCP_Purchase.lblSupplierCode.Text);
                        varScheduleid = Convert.ToInt32(MainForm.objCP_Purchase.lblschedule.Text);
                        varGRNID = Convert.ToInt32(MainForm.objCP_Purchase.pbGRNNo);
                        varNewPRoid = Convert.ToInt32(varNewproid);
                    }
                    if (chkMRP.Checked == true)
                    {
                        varMRPflag = 1;
                    }
                    else
                    {
                        varMRPflag = 0;
                    }
                    if (varproductcode != 0 && pbCloneFlag != 1)
                    {
                        varviewtype = 1;
                    }
                    if (varproductcode != 0 && pbCloneFlag == 2)
                    {
                        varviewtype = 1;
                    }
                    int varSalesProduct = 0;
                    if (chkSalesProduct.Checked == true)
                    {
                        varSalesProduct = 1;
                    }
                    int varIntermediateUPP = 0;
                    decimal varProductionMSQ = 0;
                    if (txtIntermediateUPP.Text.Trim() != "")
                    {
                        varIntermediateUPP = Convert.ToInt32(txtIntermediateUPP.Text);
                    }
                    if (txtProductionMSQ.Text.Trim() != "")
                    {
                        varProductionMSQ = Convert.ToDecimal(txtProductionMSQ.Text);
                    }

                    int FocusFlag = 0, Priority_Flag = 0, Spl_Flag = 0, OwnFlag = 0;

                    if (chkFocus.Checked == true)
                    {
                        FocusFlag = 1;
                    }
                    if (chkPrioirty.Checked == true)
                    {
                        Priority_Flag = 1;
                    }
                    if (chkSpl.Checked == true)
                    {
                        Spl_Flag = 1;
                    }
                    if (chkOwn.Checked == true)
                    {
                        OwnFlag = 1;
                    }
                    dtPrice_Markup = null;
                    if (tbProduct.SelectedIndex == 3)
                    {

                        decimal varRAteValue = 0;


                        dtPrice_Markup = new DataTable();
                        dtPrice_Markup.Columns.Add("PRPM_PRID", typeof(int));
                        dtPrice_Markup.Columns.Add("PRPM_TYPE", typeof(int));
                        dtPrice_Markup.Columns.Add("PRPM_STSID", typeof(int));
                        dtPrice_Markup.Columns.Add("PRPM_RATE", typeof(float));
                        dtPrice_Markup.Columns.Add("PRPM_MINQTY", typeof(float));
                        dtPrice_Markup.Columns.Add("PRPM_OFFSET", typeof(int));
                        dtPrice_Markup.Columns.Add("PRPM_OFFSET_VALUE", typeof(float));
                        dtPrice_Markup.Columns.Add("PRPM_OFFSET_VALUE_AMT", typeof(float));
                        dtPrice_Markup.Columns.Add("PRPM_RATE_BULK", typeof(float));
                        dtPrice_Markup.Columns.Add("PRPM_APPROVAL_Flag", typeof(int));
                        for (int i = 0; i < grdPrice.Rows.Count; i++)
                        {


                            dtPrice_Markup.Rows.Add(Convert.ToInt32(varproductcode),
                                Convert.ToInt32(grdPrice.Rows[i].Cells["clmTypeId"].Value),
                                //Convert.ToDecimal(grdPrice.Rows[i].Cells["clmMinQty"].Value), 
                                //Convert.ToDecimal(grdPrice.Rows[i].Cells["clmOffsetValuePer"].Value) 
                                //Convert.ToInt32(grdPrice.Rows[i].Cells["clmOffset"].Value),
                                Convert.ToInt32(string.IsNullOrWhiteSpace(grdPrice.Rows[i].Cells["clmStatus"].Value?.ToString())
                                ? "0" : grdPrice.Rows[i].Cells["clmStatus"].Value.ToString()),
                                 Convert.ToDecimal(grdPrice.Rows[i].Cells["clmRate"].Value)
                               ,
                                Convert.ToDecimal(string.IsNullOrWhiteSpace(grdPrice.Rows[i].Cells["clmMinQty"].Value?.ToString())
                                ? "0" : grdPrice.Rows[i].Cells["clmMinQty"].Value.ToString()),

                                 Convert.ToInt32(string.IsNullOrWhiteSpace(grdPrice.Rows[i].Cells["clmOffset"].Value?.ToString())
                                ? "0" : grdPrice.Rows[i].Cells["clmOffset"].Value.ToString()),

                                Convert.ToDecimal(string.IsNullOrWhiteSpace(grdPrice.Rows[i].Cells["clmOffsetValuePer"].Value?.ToString())
                                ? "0" : grdPrice.Rows[i].Cells["clmOffsetValuePer"].Value.ToString()),
                                Convert.ToDecimal(string.IsNullOrWhiteSpace(grdPrice.Rows[i].Cells["clmOffsetValue"].Value?.ToString())
                                ? "0" : grdPrice.Rows[i].Cells["clmOffsetValue"].Value.ToString()),
                                Convert.ToDecimal(grdPrice.Rows[i].Cells["clmBulkRate"].Value), 0



                                );
                        }
                        varorignator = "Price Markup Update";
                    }
                    if (lblParentcode.Text != "0" && lblParentcode.Text != "" && varupdateproductcode == 0)
                    {
                        txtItemNameEnglish.Text = txtItemNameEnglish.Text + " (" + txtUpp.Text + " " + cmbChildUnit.Text + ") ";
                        txtItemNameTamil.Text = txtItemNameTamil.Text + " (" + txtUpp.Text + " " + cmbChildUnit.Text + ") ";
                        txtPICode.Text = txtPICode.Text + " (" + txtUpp.Text + " " + cmbChildUnit.Text + ") ";
                        txtSalesPICode.Text = txtSalesPICode.Text + " (" + txtUpp.Text + " " + cmbChildUnit.Text + ") ";
                    }

                    result = objspdservice.udfnProductMaster(varviewtype, varupdateproductcode, txtItemNameEnglish.Text, txtItemNameTamil.Text, txtPICode.Text.Trim().ToUpper(), Convert.ToInt32(cmbConcern.SelectedValue),
                    Convert.ToInt32(cmbProductCategory.SelectedValue), Convert.ToInt32(varGroupId), Convert.ToInt32(varSubgroupId), Convert.ToInt32(varbrandid),
                    Convert.ToInt32(cmbUnit.SelectedValue), Convert.ToInt32(cmbChildUnit.SelectedValue), txtUpp.Text, Convert.ToInt32(varPurLocationId), Convert.ToInt32(varSalesLocationId)
                    , Convert.ToInt32(varPurRackId), Convert.ToInt32(varSalesRackId), rackmoq, Convert.ToInt32(cmbBatchNoEntry.SelectedValue), Convert.ToInt32(cmbBatchNoGeneration.SelectedValue),
                    varshelflife, netweight, maxstk, grossweight, minstk, reorderqty, rminsale, retailrate, wminsaleqty, wsalesrate, txtBarcode.Text, Convert.ToInt32(lblHsnName.Text), varrmproduction,
                    shelflife, Convert.ToInt32(cmbPeriod.SelectedValue), varStatus, MainForm.pbUserID, MainForm.pbIpAddress, varorignator, Convert.ToInt32(cmbNetQty.SelectedValue), null, 0, "",
                    varSupplierId, varScheduleid, varGRNID, varNewPRoid, varMRPflag, dtProductHSN, txtLabelNameEnglish.Text.Trim(), txtLabelNameTamil.Text.Trim(), lblParentcode.Text, varSalesProduct, txtTeller.Text.Trim(), "", varIntermediateUPP, Convert.ToInt32(cmbIntermediateUnit.SelectedValue), varProductionMSQ, null
                     , FocusFlag, Priority_Flag, Spl_Flag, OwnFlag, dtPrice_Markup, Convert.ToInt32(cmbStockTakken.SelectedValue), "", txtSalesPICode.Text.Trim(), "", ""
                    );

                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');

                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSave.Enabled = true;
                        TabControlCancelEventArgs args = new TabControlCancelEventArgs(tabPage3, 0, false, TabControlAction.Selecting);
                        udfnTabEnable(tbProduct, args);
                        if (varMasterType == "1")
                        {
                            MainForm.objCP_Purchase.lblProductcode.Text = varvalue[2];
                            MainForm.objCP_Purchase.txtProductName.Text = txtItemNameEnglish.Text;
                            varupdate = "1";
                            this.Close();
                        }
                        else if (varMasterType != "0")
                        {
                            varupdate = "1";
                            this.Close();
                        }
                        else
                        {
                            if (varproductcode != 0 && pbCloneFlag != 1)//Reqular Editmode
                            {
                                if (tbProduct.SelectedIndex == 1)
                                {
                                    MainForm.objCP_Itemlist.udfnDropdownbind();
                                    //MainForm.objCP_Itemlist.udfnList();
                                    varupdate = "1";
                                    this.Close();
                                }
                                else if (tbProduct.SelectedIndex == 3)
                                {
                                    MainForm.objCP_Itemlist.udfnDropdownbind();
                                    //MainForm.objCP_Itemlist.udfnList();
                                    varupdate = "1";
                                    this.Close();
                                }
                                else
                                {
                                    tbProduct.TabPages[1].Enabled = true;
                                    tbProduct.SelectedIndex = 1;
                                }
                            }
                            else
                            {
                                //Second tab save after form close, no clear data - added by sathish on 23-08-2025
                                if (tbProduct.SelectedIndex == 1/* && pbCloneFlag == 1*/)
                                {
                                    MainForm.objCP_Itemlist.udfnDropdownbind();
                                    //MainForm.objCP_Itemlist.udfnList();
                                    varupdate = "1";
                                    this.Close();
                                }
                                else if (tbProduct.SelectedIndex == 3)
                                {
                                    MainForm.objCP_Itemlist.udfnDropdownbind();
                                    //MainForm.objCP_Itemlist.udfnList();
                                    varupdate = "1";
                                    this.Close();
                                }
                                else
                                {
                                    varproductcode = Convert.ToInt32(varvalue[2]);
                                    tbProduct.TabPages[1].Enabled = true;
                                    tbProduct.SelectedIndex = 1;
                                    pbCloneFlag = 2;
                                }
                            }
                            //udfnclear();
                            //if (btnSave.Text != "Update")
                            //{
                            //    if (varFlag != 1)
                            //    {
                            //        varproductcode = Convert.ToInt32(varvalue[2]);
                            //        tbProduct.TabPages[1].Enabled = true;
                            //        tbProduct.SelectedIndex = 1;
                            //    }
                            //}
                        }
                        //if (btnSave.Text == "Update")
                        //{
                        //    this.Close();
                        //} 



                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnSave.Enabled = true;
                //cmbConcern.Focus();
            }
        }

        public void udfnclear()
        {
            try
            {
                txtSelfLife.Text = "";
                //cmbConcern.SelectedValue = -1;
                cmbProductCategory.SelectedValue = -1;
                txtSubGroup.Text = "";
                lblSubGroupCode.Text = "0";
                txtGroup.Text = "";
                lblGroupCode.Text = "0";
                txtBrand.Text = "";
                lblBrand.Text = "0";
                cmbUnit.SelectedValue = -1;
                cmbChildUnit.SelectedValue = -1;
                lblPurRackCode.Text = "0";
                txtPurRack.Text = "";
                lblPurLocationCode.Text = "0";
                txtPurLocation.Text = "";
                lblSaleRackCode.Text = "0";
                txtSaleRack.Text = "";
                lblSaleLocationCode.Text = "0";
                txtSaleLocation.Text = "";
                cmbBatchNoEntry.SelectedValue = -1;
                cmbBatchNoGeneration.SelectedValue = -1;
                cmbNetQty.SelectedValue = 6;
                cmbPeriod.SelectedValue = -1;
                cbExpiry.Checked = false;
                cbRMFromProduction.Checked = false;
                chkMRP.Checked = false;
                cbCompleted.Checked = false;
                lblHsnName.Text = "0";
                txtHsnName.Text = "";
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
                txtREnglishName.Text = "";
                txtRTamilName.Text = "";
                lblDPicode.Visible = false;
                txtRPICode.Text = "";
                cmbGst.SelectedValue = -1;
                txtPICode.Focus();
                cbExpiry.Checked = true;
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
                errItems.Clear();
                cmbConcern.BackColor = Color.White;
                cmbProductCategory.BackColor = Color.White;
                txtSubGroup.BackColor = Color.White;
                txtGroup.BackColor = Color.White;
                txtBrand.BackColor = Color.White;
                cmbUnit.BackColor = Color.White;
                cmbChildUnit.BackColor = Color.White;
                txtPurRack.BackColor = Color.White;
                txtDPurchaseLocation.BackColor = Color.White;
                txtSaleLocation.BackColor = Color.White;
                txtSaleRack.BackColor = Color.White;
                cmbBatchNoEntry.BackColor = Color.White;
                cmbBatchNoGeneration.BackColor = Color.White;
                cmbPeriod.BackColor = Color.White;
                cbExpiry.BackColor = Color.White; ;
                cbRMFromProduction.BackColor = Color.White; ;
                txtHsnName.BackColor = Color.White; ;
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
                txtSelfLife.BackColor = Color.White;
                txtProductName.BackColor = Color.White;
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
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvHsnCode.Visible = false;
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
                tpplno.ShowAlways = false;
                tpcompanyname.ShowAlways = false;
                tpunit.ShowAlways = false;
                tpbrand.ShowAlways = false;
                tpprdG.ShowAlways = false;
                tpprdSG.ShowAlways = false;
                tpprd.ShowAlways = false;
                tptamname.ShowAlways = false;
                tpengname.ShowAlways = false;
                tppurchaselocation.ShowAlways = false;
                tpsaleslocation.ShowAlways = false;
                tppurchaserack.ShowAlways = false;
                tpsalesrack.ShowAlways = false;
                tpPurHSN.ShowAlways = false;
                tpSalesHSN.ShowAlways = false;
                tpVerifier.ShowAlways = false;
                tpIntermediateUnit.ShowAlways = false;
                tpStocktaken.ShowAlways = false;
                this.Close();
                //MainForm.objCP_Itemlist.udfnList();
                MainForm.objCP_Itemlist.grdItemList.ClearSelection();
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
        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
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
                    if (txtSalesPICode.Enabled == true)
                    {
                        txtSalesPICode.Focus();
                    }
                    else
                    {
                        txtItemNameEnglish.Focus();
                    }
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
                if (e.KeyCode == Keys.Enter)
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
                    txtLabelNameEnglish.Focus();
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
                    txtBrand.Focus();
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
                    txtGroup.Focus();
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
                    if (txtUpp.Enabled == true)
                    {
                        txtUpp.Focus();
                    }
                    else if (cmbChildUnit.Enabled == true)
                    {
                        cmbChildUnit.Focus();
                    }
                    else
                    {
                        txtWeight.Focus();
                        //if (txtPurLocation.Enabled == true)
                        //{
                        //    txtPurLocation.Focus();
                        //}
                        //else if (txtPurRack.Enabled == true)
                        //{
                        //    txtPurRack.Focus();
                        //}
                        //else
                        //{
                        //    txtSaleLocation.Focus();
                        //}
                    }
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
                    if (txtIntermediateUPP.Enabled == true)
                    {
                        txtIntermediateUPP.Focus();
                    }
                    else
                    {
                        cmbBatchNoEntry.Focus();
                    }
                    //txtHsnName.Focus();
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
                    if (cmbPeriod.Visible == true)
                    {
                        txtSelfLife.Focus();
                    }
                    else
                    {
                        chkMRP.Focus();
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
                    txtBarcode.Focus();
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
                    if (txtTeller.Enabled == true)
                    {
                        txtTeller.Focus();
                    }
                    else
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

        private void RbInActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtTeller.Enabled == true)
                    {
                        txtTeller.Focus();
                    }
                    else
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

        private void TxtPICode_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
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
                    errItems.SetError(txtPICode, "Please enter PICode");
                    txtPICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter PICode", txtPICode, 5000);
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
                    errItems.SetError(txtItemNameEnglish, "Please enter product name in english");
                }
                else
                {
                    txtItemNameEnglish.BackColor = Color.White;
                    if (txtLabelNameEnglish.Text == "")
                    {
                        txtLabelNameEnglish.Text = txtItemNameEnglish.Text;
                    }
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
                    errItems.SetError(txtItemNameTamil, "Please enter product name in tamil");
                }
                else
                {
                    txtItemNameTamil.BackColor = Color.White;
                    if (txtLabelNameTamil.Text == "")
                    {
                        txtLabelNameTamil.Text = txtItemNameTamil.Text;
                    }
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
                //if (txtRetailRate.Text == "")
                //{
                //    txtRetailRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtRetailRate, "Please Enter Retail Rate");
                //}
                //else
                //{
                txtRetailRate.BackColor = Color.White;
                errItems.Clear();
                //}
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
                //if (txtWSaleRate.Text == "")
                //{
                //    txtWSaleRate.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtWSaleRate, "Please Enter W Sale Rate");
                //}
                //else
                //{
                txtWSaleRate.BackColor = Color.White;
                errItems.Clear();
                //}
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
                //if (txtMaxStock.Text == "")
                //{
                //    txtMaxStock.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtMaxStock, "Please Enter Max Stock");
                //}
                //else
                //{
                txtMaxStock.BackColor = Color.White;
                errItems.Clear();
                //}
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
                //if (txtMinStock.Text == "")
                //{
                //    txtMinStock.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtMinStock, "Please Enter Min Stock");
                //}
                //else
                //{
                txtMinStock.BackColor = Color.White;
                errItems.Clear();
                //}
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
                //if (txtWMinSaleQty.Text == "")
                //{
                //    txtWMinSaleQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtWMinSaleQty, "Please Enter Min Sale Qty");
                //}
                //else
                //{
                txtWMinSaleQty.BackColor = Color.White;
                errItems.Clear();
                //}
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
                //if (txtRMinSaleQty.Text == "")
                //{
                //    txtRMinSaleQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtRMinSaleQty, "Please Enter R Min Sale Qty");
                //}
                //else
                //{
                txtRMinSaleQty.BackColor = Color.White;
                errItems.Clear();
                //}
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
                //if (txtBarcode.Text == "")
                //{
                //    txtBarcode.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtBarcode, "Please Enter BarCode");
                //}
                //else
                //{
                txtBarcode.BackColor = Color.White;
                errItems.Clear();
                //}
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
                    errItems.SetError(txtGST, "Please enter GST");
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
                //if (txtReOrderQty.Text == "")
                //{
                //    txtReOrderQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtReOrderQty, "Please Enter ReOrder Qty");
                //}
                //else
                //{
                txtReOrderQty.BackColor = Color.White;
                errItems.Clear();
                // }
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
                    txtSelfLife.Text = "";
                    cmbPeriod.SelectedValue = -1;
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
                    chkSalesProduct.Focus();
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

        //private void CmbHSNName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        BeginInvoke(new Action(() => cmbHSNName.Select(int.MaxValue, 0)));

        //        DataSet objds;
        //        DataService objdservice = new DataService();
        //        objds = objdservice.GetDataset("SELECT HSN_Code,GST_Value FROM MR_HSN INNER JOIN DEF_GST ON HSN_GSTID=GSTID WHERE HSNID  IN ('" + Convert.ToInt32(cmbHSNName.SelectedValue) + "') AND GSTID  NOT IN (0,-1)");
        //        objdservice.CloseConnection();
        //        if (objds != null)
        //        {
        //            if (objds.Tables.Count > 0)
        //            {
        //                if (objds.Tables[0].Rows.Count > 0)
        //                {
        //                    txtHSNCode.Text = Convert.ToString(objds.Tables[0].Rows[0]["HSN_Code"]);
        //                    txtGST.Text = Convert.ToString(objds.Tables[0].Rows[0]["GST_Value"]);
        //                }
        //                else
        //                {
        //                    txtHSNCode.Text = "";
        //                    txtGST.Text = "";

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)

        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

        //private void CmbHSNName_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Convert.ToString(cmbHSNName.SelectedValue) == "" || Convert.ToString(cmbHSNName.SelectedValue) == "-1")
        //        {
        //            errItems.SetError(cmbHSNName, "Please select HSN name");
        //            cmbHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
        //            tpcompanyname.ShowAlways = true;
        //            tpcompanyname.Show("Please select sales HSN name", cmbHSNName, 5000);
        //        }
        //        else
        //        {
        //            errItems.Clear();
        //            cmbHSNName.BackColor = Color.White;
        //        }

        //    }
        //    catch (Exception ex)

        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

        //private void CmbHSNName_Enter(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cmbHSNName.BackColor = Color.LemonChiffon;
        //    }
        //    catch (Exception ex)

        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

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
                    if (cmbProductType.Enabled == true)
                    {
                        cmbProductType.Focus();
                    }
                    else
                    {
                        txtPICode.Focus();
                    }
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
                    errItems.SetError(cmbProductCategory, "Please select product category");
                    cmbProductCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpprd.ShowAlways = true;
                    tpprd.Show("Please select product category", cmbProductCategory, 5000);
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
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 16;
                objMR_Master.paraID = Convert.ToInt32(cmbProductCategory.SelectedValue);
                BeginInvoke(new Action(() => cmbProductCategory.Select(int.MaxValue, 0)));
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbBatchNoEntry.SelectedValue = objDT.Tables[0].Rows[0]["MSBT_BatchNo"].ToString();
                            cmbBatchNoGeneration.SelectedValue = objDT.Tables[0].Rows[0]["MSBT_BatchNoGeneration"].ToString();
                        }
                    }
                }
                if (Convert.ToInt32(cmbProductCategory.SelectedValue) == 16)
                {
                    cmbRM.SelectedValue = 241;
                    cmbRM.Enabled = true;
                }
                else
                {
                    cmbRM.Enabled = false;
                    cmbRM.SelectedValue = 240;
                }
                ////convertion type AND Production only allow child concept otherwise all are parent
                if (Convert.ToInt32(cmbProductCategory.SelectedValue) != 14 && Convert.ToInt32(cmbProductCategory.SelectedValue) != 16)
                {
                    cmbProductType.SelectedValue = 341;
                    cmbProductType.Enabled = false;
                    txtUpp.Enabled = false;
                    txtUpp.ReadOnly = true;
                }
                else
                {
                    cmbProductType.Enabled = true;
                }
                if (Convert.ToInt32(cmbProductCategory.SelectedValue) == 16)
                {
                    cmbIntermediateUnit.Enabled = true;
                    txtIntermediateUPP.Enabled = true;
                    txtProductionMSQ.Enabled = true;
                    cmbStockTakken.Enabled = true;
                }
                else
                {
                    cmbIntermediateUnit.Enabled = false;
                    txtIntermediateUPP.Enabled = false;
                    txtProductionMSQ.Enabled = false;
                    cmbStockTakken.Enabled = false;
                    txtIntermediateUPP.Text = "";
                    txtProductionMSQ.Text = "";
                    cmbIntermediateUnit.SelectedValue = -1;
                }
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
        private void cmbChildUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbChildUnit.SelectedValue) == -1)
                {
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(cmbChildUnit.SelectedValue) == "" || Convert.ToString(cmbChildUnit.SelectedValue) == "-1")
                //{
                //    errItems.SetError(cmbChildUnit, "Please select bulk unit");
                //    cmbChildUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpcompanyname.ShowAlways = true;
                //    tpcompanyname.Show("Please select bulk unit", cmbChildUnit, 5000);
                //}
                //else
                //{
                errItems.Clear();
                cmbChildUnit.BackColor = Color.White;
                //}
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildUnit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbChildUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWeight.Focus();
                    //if (txtPurLocation.Enabled == true)
                    //{
                    //    txtPurLocation.Focus();
                    //}
                    //else if (txtPurRack.Enabled == true)
                    //{
                    //    txtPurRack.Focus();
                    //}
                    //else
                    //{
                    //    txtSaleLocation.Focus();
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbChildUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbChildUnit.BackColor = Color.LemonChiffon;
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
                    errItems.SetError(txtUpp, "Please enter UPP");
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
                    if (cmbChildUnit.Enabled == true)
                    {
                        cmbChildUnit.Focus();
                    }
                    else
                    {
                        if (txtPurLocation.Enabled == true)
                        {
                            txtPurLocation.Focus();
                        }
                        else if (txtPurRack.Enabled == true)
                        {
                            txtPurRack.Focus();
                        }
                        else
                        {
                            txtSaleLocation.Focus();
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
                else
                {
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
                    if (cmbBatchNoGeneration.Enabled)
                    {
                        cmbBatchNoGeneration.Focus();
                    }
                    else { cbExpiry.Focus(); }
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

                //if (Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "" || Convert.ToString(cmbBatchNoGeneration.SelectedValue) == "-1")
                //{
                //    errItems.SetError(cmbBatchNoGeneration, "Please select Batch No. generation");
                //    cmbBatchNoGeneration.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpcompanyname.ShowAlways = true;
                //    tpcompanyname.Show("Please select sales Batch No. generation", cmbBatchNoGeneration, 5000);
                //}
                //else {

                cmbBatchNoGeneration.BackColor = Color.White;
                errItems.Clear();
                // }
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
                    chkMRP.Focus();
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
                    chkMRP.Focus();
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
                //if (txtRackMOQQty.Text == "")
                //{
                //    txtRackMOQQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                //    errItems.SetError(txtRackMOQQty, "Please enter the rach MOQ");
                //}
                //else
                //{
                txtRackMOQQty.BackColor = Color.White;
                errItems.Clear();
                //  }
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
                    if (pnlStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInActive.Focus();
                        }
                    }
                    else
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

        private void TxtMaxOrderQty_Enter(object sender, EventArgs e)
        {
            try
            {
                lvSaleRack.Visible = false;
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
                    errItems.SetError(cmbUnit, "Please select unit");
                    cmbUnit.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select unit", cmbUnit, 5000);
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
                lvBrand.Visible = false;
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
                //BeginInvoke(new Action(() => cmbUnit.Select(int.MaxValue, 0)));
                if (Convert.ToInt32(cmbUnit.SelectedValue) != -1)
                {
                    txtInterUnit.Text = cmbUnit.Text;
                }
                else
                {
                    txtInterUnit.Text = "";
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
                varStatusID = 120;//Draft
                dtProductHSN.Columns.Add("HSN_Type", typeof(int));
                dtProductHSN.Columns.Add("HSNID", typeof(int));
                dtProductHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtProductHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtProductHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtProductHSN.Columns.Add("PRHSN_MakerID", typeof(int));

                dtPurHSN.Columns.Add("HSN_Type", typeof(int));
                dtPurHSN.Columns.Add("HSNID", typeof(int));
                dtPurHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtPurHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtPurHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtPurHSN.Columns.Add("PRHSN_MakerID", typeof(int));

                dtSalesHSN.Columns.Add("HSN_Type", typeof(int));
                dtSalesHSN.Columns.Add("HSNID", typeof(int));
                dtSalesHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtSalesHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtSalesHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtSalesHSN.Columns.Add("PRHSN_MakerID", typeof(int));




                if (varMasterType == "0")
                {
                    MainForm.objCP_Itemlist.picLoader.Visible = false;
                }
                else
                {
                    txtItemNameEnglish.Text = varEname;
                }
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (btnSave.Text == "Save as Draft")
                {
                    this.ActiveControl = cmbConcern;
                }
                else
                {
                    this.ActiveControl = txtPICode;
                }
                if (btnSave.Text == "Save as Draft")
                {
                    udfnDropDownload();
                }
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (5,0) AND MSTID NOT IN (0,369)", "MST_DisplayText,MSTID", cmbProductCategory, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (76,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbRM, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (6,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbPeriod, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (25,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbBatchNoEntry, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (26,0) AND MSTID<>0", "MST_DisplayText,MSTID", cmbBatchNoGeneration, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,102) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbProductType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("MR_QtyUnit", " QUT_STSID =1", "QUT_Symbol,QUTID", cmbNetQty, "", "QUT_Symbol", "QUTID");
                objDataBind.BindComboBoxListSelected("DEF_GST", " GSTID  not in (0)", "GST_Text,GSTID", cmbGst, "", "GST_Text", "GSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,143) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbStockTakken, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                //cmbConcern.SelectedValue = -1;
                //cmbHSNName.SelectedValue = -1;
                if (btnSave.Text == "Save")
                {
                    cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                    cmbUnit.SelectedValue = -1;
                    cmbChildUnit.SelectedValue = -1;
                }
                cmbProductCategory.SelectedValue = -1;
                cmbPeriod.SelectedValue = -1;
                cmbBatchNoEntry.SelectedValue = 72;
                cmbBatchNoGeneration.SelectedValue = -1;
                cmbStockTakken.SelectedValue = -1;
                cbExpiry.Checked = true;
                if (varProductload == 1)
                {
                    txtPurLocation.Enabled = false;
                    txtPurRack.Enabled = false;
                }
                udfnEdit();
                txtHSNCode.Enabled = false;
                txtHSNCode.ReadOnly = true;
                if (pbCloneFlag == 1)
                {
                    btnSave.Text = "Save as Draft";
                    rbInActive.Checked = true;
                    pnlStatus.Enabled = false;
                    cbCompleted.Checked = false;
                    cbCompleted.Enabled = true;
                    pbFormStatus = 71;
                    varStatusFlag = 0;
                    txtTeller.Text = "";
                    txtTeller.Enabled = false;
                    txtTeller.ReadOnly = true;
                    this.ActiveControl = txtPICode;
                    varStatusID = 120;
                }
                //if (btnSave.Text != "Update")
                //{
                //    tbProduct.TabPages[1].Enabled = false;
                //}
                //else
                //{
                //    tbProduct.TabPages[1].Enabled = true;
                //}

                cmbUnit.Enabled = true;
                udfnUserAccess();
                //txtUpp.Enabled = true;
                btnSave.Visible = true;
                btnImageUpdate.Visible = false;
                UpdateSalesProductUI();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUserAccess()
        {
            try
            {
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    PurStkLocViewAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 1 && sp.EditAccess.Split(',').Contains("9"));
                    PurStkLocEditAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 1 && sp.EditAccess.Split(',').Contains("10"));

                    SalesStkLocViewAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 2 && sp.EditAccess.Split(',').Contains("9"));
                    SalesStkLocEditAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 2 && sp.EditAccess.Split(',').Contains("10"));

                    RetailRateViewAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 3 && sp.EditAccess.Split(',').Contains("9"));
                    RetailRateEditAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 3 && sp.EditAccess.Split(',').Contains("10"));

                    WholeSaleRateViewAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 4 && sp.EditAccess.Split(',').Contains("9"));
                    WholeSaleRateEditAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 4 && sp.EditAccess.Split(',').Contains("10"));

                    SalesHSNViewAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 5 && sp.EditAccess.Split(',').Contains("9"));
                    SalesHSNEditAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 5 && sp.EditAccess.Split(',').Contains("10"));

                    PurHSNViewAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 6 && sp.EditAccess.Split(',').Contains("9"));
                    PurHSNEditAcess = MainForm.objCP_Itemlist.SpecialPermissions.Any(sp => sp.MUP_Code == 6 && sp.EditAccess.Split(',').Contains("10"));

                    if (!PurStkLocViewAcess)
                    { txtPurLocation.UseSystemPasswordChar = true; txtPurLocation.Enabled = false; }
                    if (!SalesStkLocViewAcess)
                    { txtSaleLocation.UseSystemPasswordChar = true; txtSaleLocation.Enabled = false; }
                    if (!RetailRateViewAcess)
                    { txtRetailRate.UseSystemPasswordChar = true; txtRetailRate.Enabled = false; }
                    if (!WholeSaleRateViewAcess)
                    { txtWSaleRate.UseSystemPasswordChar = true; txtWSaleRate.Enabled = false; }
                    if (!SalesHSNViewAcess)
                    { grbSalesHSN.Visible = false; }
                    else { grbSalesHSN.Enabled = false; }
                    if (!PurHSNViewAcess)
                    { grbPurchaseHSN.Visible = false; }
                    else { grbPurchaseHSN.Enabled = false; }

                    if (PurStkLocEditAcess)
                    {
                        if (!txtPurLocation.ReadOnly)  // Allow editing only if it's not marked readonly by system logic
                        { txtPurLocation.ReadOnly = false; }
                    }
                    else // disable editing 
                    { txtPurLocation.ReadOnly = true; }

                    if (SalesStkLocEditAcess)
                    {
                        if (!txtSaleLocation.ReadOnly)  // Allow editing only if it's not marked readonly by system logic
                        { txtSaleLocation.ReadOnly = false; }
                    }
                    else // disable editing 
                    { txtSaleLocation.ReadOnly = true; }

                    if (RetailRateEditAcess)
                    {
                        if (!txtRetailRate.ReadOnly)  // Allow editing only if it's not marked readonly by system logic
                        { txtRetailRate.ReadOnly = false; }
                    }
                    else // disable editing 
                    { txtRetailRate.ReadOnly = true; }

                    if (WholeSaleRateEditAcess)
                    {
                        if (!txtWSaleRate.ReadOnly)  // Allow editing only if it's not marked readonly by system logic
                        { txtWSaleRate.ReadOnly = false; }
                    }
                    else // disable editing 
                    { txtWSaleRate.ReadOnly = true; }

                    if (SalesHSNEditAcess)
                    {
                        grbSalesHSN.Enabled = SalesHSNEditAcess;
                    }
                    if (PurHSNEditAcess)
                    {
                        grbPurchaseHSN.Enabled = SalesHSNEditAcess;
                    }

                    //Subgroup
                    var Subgroupresult = UserAccessHelper.LoadUserAccess(50503);
                    Subgroupprivilege = Subgroupresult.PrivilegeCode;
                    btnSubgroup.Visible = Subgroupprivilege.Contains("2");
                    //Group
                    var groupresult = UserAccessHelper.LoadUserAccess(50502);
                    Groupprivilege = groupresult.PrivilegeCode;
                    btnGroup.Visible = Groupprivilege.Contains("2");
                    //Brand
                    var Brandresult = UserAccessHelper.LoadUserAccess(50504);
                    Brandprivilege = Brandresult.PrivilegeCode;
                    btnBrand.Visible = Brandprivilege.Contains("2");
                    //Unit
                    var Unitresult = UserAccessHelper.LoadUserAccess(50505);
                    Unitprivilege = Unitresult.PrivilegeCode;
                    btnUnit.Visible = Unitprivilege.Contains("2");
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUnitLoad()
        {
            try
            {
                int varViewType = 2, varBulkViewType = 6;
                if (btnSave.Text == "Save as Draft")
                {
                    varViewType = 1; varBulkViewType = 5;
                }
                DataSet objDT = new DataSet();
                DataSet objDTBulkUnit = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDT = objdserv.udfnUnitList(varViewType, varUnitid, 0);
                objdserv.CloseConnection();
                cmbUnit.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbUnit.ValueMember = "UTID";
                            cmbUnit.DisplayMember = "UT_Symbol";
                            cmbUnit.DataSource = objDT.Tables[0];
                        }
                    }
                }
                objDT = null;
                objDT = objdserv.udfnUnitList(varViewType, varUnitid, 0);
                objdserv.CloseConnection();
                cmbChildUnit.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbChildUnit.ValueMember = "UTID";
                            cmbChildUnit.DisplayMember = "UT_Symbol";
                            cmbChildUnit.DataSource = objDT.Tables[0];
                        }
                    }
                }
                objDT = objdserv.udfnUnitList(varViewType, varUnitid, 0);
                objdserv.CloseConnection();
                cmbIntermediateUnit.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbIntermediateUnit.ValueMember = "UTID";
                            cmbIntermediateUnit.DisplayMember = "UT_Symbol";
                            cmbIntermediateUnit.DataSource = objDT.Tables[0];
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
        public void udfnDropDownload()
        {
            try
            {
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();
                int varViewType = 2;
                if (btnSave.Text == "Save")
                {
                    varViewType = 1;
                }
                //objDT = objdserv.udfnSubGroupList(varViewType, varSubGroupId, "",0,0,"");
                //objdserv.CloseConnection();
                //cmbSubGroup.DataSource = null;
                //if (objDT != null)
                //{
                //    if (objDT.Tables.Count > 0)
                //    {
                //        if (objDT.Tables[0].Rows.Count > 0)
                //        {
                //            cmbSubGroup.ValueMember = "PRSGID";
                //            cmbSubGroup.DisplayMember = "PRSG_EName";
                //            cmbSubGroup.DataSource = objDT.Tables[0];
                //        }
                //    }
                //}
                //objDT = objdserv.udfnHsnList(varViewType, varHsnId);
                //objdserv.CloseConnection();
                ////cmbHSNName.DataSource = null;
                //if (objDT != null)
                //{
                //    if (objDT.Tables.Count > 0)
                //    {
                //        if (objDT.Tables[0].Rows.Count > 0)
                //        {
                //            cmbHSNName.ValueMember = "HSNID";
                //            cmbHSNName.DisplayMember = "HSN_Name";
                //            cmbHSNName.DataSource = objDT.Tables[0];
                //        }
                //    }
                //}
                int varconcerntype = 4;
                if (btnSave.Text == "Save")
                {
                    varconcerntype = 3;
                }
                if (btnSave.Text == "Save as Draft")
                {
                    varconcerntype = 3;
                }
                objDT = objdserv.udfnCompanyList(varconcerntype, varcompanyid, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                cmbConcern.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDT.Tables[0];
                        }
                    }
                }
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                udfnUnitLoad();
                //int varbrnadViewtype = 4;
                //if (btnSave.Text == "Save")
                //{
                //    varbrnadViewtype = 3;
                //}
                //objDT = objdserv.udfnBrandList(varbrnadViewtype, Convert.ToString(varBrandId), 0, 0, 0,"");
                //objdserv.CloseConnection();
                //cmbBrand.DataSource = null;
                //if (objDT != null)
                //{
                //    if (objDT.Tables.Count > 0)
                //    {
                //        if (objDT.Tables[0].Rows.Count > 0)
                //        {
                //            cmbBrand.ValueMember = "ID";
                //            cmbBrand.DisplayMember = "Brand Name";
                //            cmbBrand.DataSource = objDT.Tables[0];
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnLabelingDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPICode.Text != "")
                {
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 2;
                    objMR_Product.paraPicode = txtPICode.Text;
                    SPDataService objdserv = new SPDataService();
                    lblDPicode.Visible = true;
                    objDs = objdserv.udfnproductmasterlist(objMR_Product);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                txtItemNameEnglish.Text = objDs.Tables[0].Rows[0]["ENAME"].ToString().Trim();
                                txtItemNameTamil.Text = objDs.Tables[0].Rows[0]["Tname"].ToString().Trim();
                                txtREnglishName.Text = objDs.Tables[0].Rows[0]["ENAME"].ToString().Trim();
                                txtRTamilName.Text = objDs.Tables[0].Rows[0]["Tname"].ToString().Trim();
                                txtRPICode.Text = txtPICode.Text;
                            }
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

        private void TxtBrand_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Visible = false;
                txtBrand.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvBrand.Items.Count == 0 || txtBrand.Text == "")
                    {
                        txtBrand.Focus();
                        lvBrand.Visible = false;
                    }
                    else
                    {
                        lvBrand.Focus();
                    }
                    if (lvBrand.Items.Count > 0)
                    {
                        lvBrand.Items[0].Selected = true;
                    }
                }
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

        private void TxtBrand_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBrand.Text == "")
                {
                    txtBrand.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtBrand, "Please enter brand");
                }
                else
                {
                    txtBrand.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Items.Clear();
                if (txtGroup.Text != "" && txtSubGroup.Text != "")
                {
                    if (txtBrand.Text.Length > 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnBrandList(6, "0", 0, Convert.ToInt32(lblSubGroupCode.Text), 0, txtBrand.Text.Trim(), 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["BD_EName"].ToString(), objDs.Tables[0].Rows[i]["BD_TName"].ToString(), objDs.Tables[0].Rows[i]["BDID"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvBrand.Items.Add(objList);
                                    }
                                    lvBrand.Visible = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        lvBrand.Visible = false;
                        lvBrand.Items.Clear();
                    }
                }
                else
                {
                    if (txtGroup.Text == "")
                    {
                        lvGroup.Items.Clear();
                        lvGroup.Visible = false;
                        txtGroup.Text = "";
                        lblGroupCode.Text = "0";
                        txtGroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errItems.SetError(txtSubGroup, "Please select subgroup");
                        txtBrand.Text = "";
                        lblBrand.Text = "0";
                    }
                    //else
                    //{
                    //    txtSubGroup.BackColor = Color.White;
                    //    errItems.Clear();
                    //}
                    if (txtSubGroup.Text == "")
                    {
                        txtSubGroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errItems.SetError(txtSubGroup, "Please select subgroup");
                        lvSubGroup.Items.Clear();
                        lvSubGroup.Visible = false;
                        txtSubGroup.Text = "";
                        lblSubGroupCode.Text = "0";
                        txtBrand.Text = "";
                        lblBrand.Text = "0";
                    }
                    //else
                    //{
                    //    txtSubGroup.BackColor = Color.White;
                    //    errItems.Clear();
                    //}
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
        public void udfnBrandAutocomplete()
        {
            try
            {
                if (txtBrand.Text != "")
                {
                    ListViewItem selectedItem = lvBrand.SelectedItems[0];
                    txtBrand.Text = selectedItem.SubItems[0].Text;
                    lblBrand.Text = selectedItem.SubItems[2].Text;
                    //lvBrand.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                cmbUnit.Focus();
                lvBrand.Visible = false;
            }
        }
        public void udfnGroupAutocomplete()
        {
            try
            {
                if (txtGroup.Text != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    txtGroup.Text = selectedItem.SubItems[0].Text;
                    lblGroupCode.Text = selectedItem.SubItems[2].Text;
                    txtBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvGroup.Visible = false;
            }
        }
        public void udfnSubGroupAutocomplete()
        {
            try
            {
                if (txtSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    txtSubGroup.Text = selectedItem.SubItems[0].Text;
                    lblSubGroupCode.Text = selectedItem.SubItems[2].Text;
                    txtGroup.Text = selectedItem.SubItems[4].Text;
                    lblGroupCode.Text = selectedItem.SubItems[5].Text;
                    txtPurLocation.Text = selectedItem.SubItems[7].Text;
                    lblPurLocationCode.Text = selectedItem.SubItems[6].Text;
                    lblPurRackCode.Text = selectedItem.SubItems[8].Text;
                    txtPurRack.Text = selectedItem.SubItems[9].Text;
                    string varbatchenable = selectedItem.SubItems[3].Text;
                    txtRackDescription.Text = selectedItem.SubItems[10].Text;
                    txtSubgroupType.Text = selectedItem.SubItems[11].Text;
                    txtBrand.Text = "";
                    lblBrand.Text = "0";
                    txtGroup.Focus();
                    lvSubGroup.Visible = false;
                    DGV_FilterPurLocation.Visible = false;
                    lvPurRack.Visible = false;
                    if (Convert.ToString(lblPurRackCode.Text) == "0")
                    {
                        txtPurRack.Text = "None";
                        txtPurRack.BackColor = Color.White;
                        txtPurRack.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSubGroup.Visible = false;
            }
        }
        public void udfnPurLocationAutocomplete()
        {
            try
            {
                if (txtPurLocation.Text != "")
                {
                    lblPurLocationCode.Text = DGV_FilterPurLocation.SelectedRows[0].Cells["SLID"].Value.ToString();
                    txtPurLocation.Text = DGV_FilterPurLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                    txtPurRack.Text = "";
                    lblPurRackCode.Text = "0";
                    txtRackDescription.Text = "";
                    udfnPLocationWiseRack();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPLocationWiseRack()
        {
            try
            {
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
                DataSet objDsPurchaseRack = new DataSet();
                SPDataService objDServ6 = new SPDataService();
                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(lblPurLocationCode.Text), 0, txtPurRack.Text.Trim(), 0, 0);
                objDServ6.CloseConnection();
                if (txtPurRack.Text.Trim() != "")
                {
                    if (lblPurLocationCode.Text != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        lblPurRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (varId_PurchaseRack == "0" || varId_PurchaseRack == "-1")
                        {
                            errItems.SetError(txtPurRack, "Please select valid purchase rack");
                            txtPurRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tppurchaserack.ShowAlways = true;
                            tppurchaserack.Show("Please select valid purchase rack", txtPurRack, 5000);
                        }
                    }
                }
                else
                {
                    if (lblPurLocationCode.Text != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                }
                            }
                        }
                        //lblPurRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (varId_PurchaseRack == "0")
                        {
                            txtPurRack.Text = "None";
                            txtPurRack.BackColor = Color.White;
                            txtPurRack.Enabled = false;
                            txtSaleLocation.Focus();
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
        public void udfnSLocationWiseRack()
        {
            try
            {
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
                DataSet objDsPurchaseRack = new DataSet();
                SPDataService objDServ6 = new SPDataService();
                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(lblSaleLocationCode.Text), 0, txtSaleRack.Text.Trim(), 0, 0);
                objDServ6.CloseConnection();
                if (txtSaleRack.Text.Trim() != "")
                {
                    if (lblSaleLocationCode.Text != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        lblSaleRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (varId_PurchaseRack == "0" || varId_PurchaseRack == "-1")
                        {
                            errItems.SetError(txtSaleRack, "Please select valid sales rack");
                            txtSaleRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpsalesrack.ShowAlways = true;
                            tpsalesrack.Show("Please select valid sales rack", txtSaleRack, 5000);
                        }
                    }
                }
                else
                {
                    if (lblSaleLocationCode.Text != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                }
                            }
                        }
                        //lblPurRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (varId_PurchaseRack == "0")
                        {
                            txtSaleRack.Text = "None";
                            txtSaleRack.BackColor = Color.White;
                            txtSaleRack.Enabled = false;
                            txtRackMOQQty.Text = "";
                            txtRackMOQQty.Enabled = false;
                            cmbBatchNoEntry.Focus();
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
        public void udfnPurRackAutocomplete()
        {
            try
            {
                if (txtPurRack.Text != "")
                {
                    ListViewItem selectedItem = lvPurRack.SelectedItems[0];
                    txtPurRack.Text = selectedItem.SubItems[0].Text;
                    lblPurRackCode.Text = selectedItem.SubItems[2].Text;
                    txtRackDescription.Text = selectedItem.SubItems[1].Text;
                    lvPurRack.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvPurRack.Visible = false;
            }
        }

        public void udfnSaleLocationAutocomplete()
        {
            try
            {
                if (txtSaleLocation.Text != "")
                {
                    lblSaleLocationCode.Text = DGV_FilterSalesLocation.SelectedRows[0].Cells["SLID"].Value.ToString();
                    txtSaleLocation.Text = DGV_FilterSalesLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                    txtSaleRack.Text = "";
                    txtRackDescriptionSales.Text = "";
                    lblSaleRackCode.Text = "0";
                    udfnSLocationWiseRack();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSaleRackAutocomplete()
        {
            try
            {
                if (txtSaleRack.Text != "")
                {
                    ListViewItem selectedItem = lvSaleRack.SelectedItems[0];
                    txtSaleRack.Text = selectedItem.SubItems[0].Text;
                    lblSaleRackCode.Text = selectedItem.SubItems[2].Text;
                    txtRackDescriptionSales.Text = selectedItem.SubItems[1].Text;
                    lvSaleRack.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvPurRack.Visible = false;
            }
        }
        private void LvBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnBrandAutocomplete();
                    cmbUnit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSubGroup.Items.Count == 0 || txtSubGroup.Text == "")
                    {
                        txtSubGroup.Focus();
                        lvSubGroup.Visible = false;
                    }
                    else
                    {
                        lvSubGroup.Focus();
                    }
                    if (lvSubGroup.Items.Count > 0)
                    {
                        lvSubGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSubGroup.Text == "")
                {
                    txtSubGroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtSubGroup, "Please enter subgroup");
                    txtGroup.Text = "";
                    lblGroupCode.Text = "0";
                    txtBrand.Text = "";
                    lblBrand.Text = "0";
                }
                else
                {
                    txtSubGroup.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Items.Clear();
                if (txtSubGroup.Text.Length > 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnSubGroupList(8, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_SLID"].ToString(), objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString(), objDs.Tables[0].Rows[i]["RackName"].ToString(), objDs.Tables[0].Rows[i]["Description"].ToString(), objDs.Tables[0].Rows[i]["SubgroupType"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvSubGroup.Items.Add(objList);
                                }
                                lvSubGroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvSubGroup.Visible = false;
                    lvSubGroup.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSubGroupAutocomplete();
                    txtBrand.Focus();
                    lvGroup.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.LemonChiffon;
                lvSubGroup.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvGroup.Items.Count == 0 || txtGroup.Text == "")
                    {
                        txtGroup.Focus();
                        lvGroup.Visible = false;
                    }
                    else
                    {
                        lvGroup.Focus();
                    }
                    if (lvGroup.Items.Count > 0)
                    {
                        lvGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtGroup.Text == "")
                {
                    txtGroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtGroup, "Please enter group");
                    txtSubGroup.Text = "";
                    lblSubGroupCode.Text = "0";
                    txtBrand.Text = "";
                    lblBrand.Text = "0";
                }
                else
                {
                    txtGroup.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtGroup.Text.Trim() != "")
                {
                    lvGroup.Items.Clear();
                    if (txtGroup.Text.Length > 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnGroupList(7, 0, Convert.ToInt32(lblSubGroupCode.Text), txtGroup.Text.Trim(), 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvGroup.Items.Add(objList);
                                    }
                                    lvGroup.Visible = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        lvGroup.Items.Clear();
                        lvGroup.Visible = false;
                    }
                    //if (txtSubGroup.Text != "")
                    //{
                    //    txtSubGroup.Text = "";
                    //    lblSubGroupCode.Text = "0";
                    //    txtBrand.Text = "";
                    //    lblBrand.Text = "0";
                    //}
                }
                else
                {
                    txtSubGroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtSubGroup, "Please select subgroup");
                    lvGroup.Items.Clear();
                    lvGroup.Visible = false;
                    txtGroup.Text = "";
                    txtSubGroup.Text = "";
                    lblGroupCode.Text = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGroupAutocomplete();
                    txtBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvGroup_DoubleClick(object sender, EventArgs e)
        {
            udfnGroupAutocomplete();
        }

        private void LvBrand_DoubleClick(object sender, EventArgs e)
        {
            udfnBrandAutocomplete();
        }

        private void TxtPurLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                txtPurLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyPurLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterPurLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterPurLocation.Visible == false)
                {
                    if (txtPurRack.Enabled == true)
                    {
                        txtPurRack.Focus();
                    }
                    else if (chkSameasPurchase.Checked == true)
                    {
                        txtRackMOQQty.Focus();
                    }
                    else
                    {
                        txtSaleLocation.Focus();
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterPurLocation.Focus();
                }
                if (DGV_FilterPurLocation.CurrentCell == null && DGV_FilterPurLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterPurLocation.Focus();
                    int RowIndex = DGV_FilterPurLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterPurLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyPurLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyPurLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterPurLocation.CurrentCell = DGV_FilterPurLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtPurLocation.Text = DGV_FilterPurLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtPurLocation.Focus();
                            txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterPurLocation.Rows.Count) DGV_FilterPurLocation.CurrentCell = DGV_FilterPurLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterPurLocation.Rows.Count))
                            {
                                txtPurLocation.Text = DGV_FilterPurLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtPurLocation.Focus();
                            txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterPurLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyPurLocation = 1;
                                    udfnPurLocationAutocomplete();
                                    DGV_FilterPurLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtPurLocation.Focus();
                    //txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtPurRack.Enabled == true)
                        {
                            txtPurRack.Focus();
                        }
                        else if (chkSameasPurchase.Checked == true)
                        {
                            txtRackMOQQty.Focus();
                        }
                        else
                        {
                            txtSaleLocation.Focus();
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

        private void TxtPurLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPurLocation.Text == "")
                {
                    txtPurLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtPurLocation, "Please enter purchase location");
                    txtPurRack.Text = "";
                    lblPurRackCode.Text = "0";
                    txtRackDescription.Text = "";
                }
                else
                {
                    txtPurLocation.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSameasPurchase.Checked == true)
                {
                    chkSameasPurchase.Checked = false;
                    txtSaleLocation.Text = "";
                    txtSaleRack.Text = "";
                    txtRackDescriptionSales.Text = "";
                    lblSaleLocationCode.Text = "0";
                    lblSaleRackCode.Text = "0";
                }
                txtPurRack.Text = "";
                txtRackDescription.Text = "";
                //txtPurRack.Enabled = true;
                if (varUpDownKeyPurLocation == 0)
                {
                    if (txtPurLocation.Text.Length > 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();

                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 10;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtPurLocation.Text.Trim();
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(10, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtPurLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterPurLocation.Visible = true;
                                    DGV_FilterPurLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterPurLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterPurLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterPurLocation.Columns["SL_EName"].HeaderText = "Location E Name";
                                    DGV_FilterPurLocation.Columns["SL_TName"].HeaderText = "Location T Name";
                                    DGV_FilterPurLocation.Columns["SL_EName"].Width = 180;
                                    DGV_FilterPurLocation.Columns["SL_TName"].Width = 180;
                                    DGV_FilterPurLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterPurLocation.Columns["SL_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterPurLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterPurLocation.Visible = false;
                                    DGV_FilterPurLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterPurLocation.Visible = false;
                                DGV_FilterPurLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterPurLocation.Visible = false;
                            DGV_FilterPurLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterPurLocation.Visible = false;
                        DGV_FilterPurLocation.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtPurLocation.Focus();
            }
        }

        private void TxtPurRack_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                txtPurRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvPurRack.Items.Count == 0 || txtPurRack.Text == "")
                    {
                        txtPurRack.Focus();
                        lvPurRack.Visible = false;
                    }
                    else
                    {
                        lvPurRack.Focus();
                    }
                    if (lvPurRack.Items.Count > 0)
                    {
                        lvPurRack.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtSaleLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvPurRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPurRackAutocomplete();
                    txtSaleLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSameasPurchase.Checked == true)
                {
                    chkSameasPurchase.Checked = false;
                    txtSaleLocation.Text = "";
                    txtSaleRack.Text = "";
                    txtRackDescriptionSales.Text = "";
                    lblSaleLocationCode.Text = "0";
                    lblSaleRackCode.Text = "0";
                }
                lvPurRack.Items.Clear();
                if (txtPurRack.Text.Length > 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(lblPurLocationCode.Text), 0, txtPurRack.Text.Trim(), 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RK_Description"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvPurRack.Items.Add(objList);
                                }
                                lvPurRack.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvPurRack.Visible = false;
                    lvPurRack.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPurRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPurRack.Text == "")
                {
                    txtRackDescription.Text = "";
                    txtPurRack.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtPurRack, "Please enter purchase rack");
                }
                else
                {
                    txtPurRack.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSaleLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
                txtSaleLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSaleLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySalesLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSalesLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSalesLocation.Visible == false)
                {
                    if (txtSaleRack.Enabled == true)
                    {
                        txtSaleRack.Focus();
                    }
                    else
                    {
                        if (pnlStatus.Enabled == true)
                        {
                            if (rbActive.Checked == true)
                            {
                                rbActive.Focus();
                            }
                            else
                            {
                                rbInActive.Focus();
                            }
                        }
                        else
                        {
                            btnSave.Focus();
                        }
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSalesLocation.Focus();
                }
                if (DGV_FilterSalesLocation.CurrentCell == null && DGV_FilterSalesLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSalesLocation.Focus();
                    int RowIndex = DGV_FilterSalesLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSalesLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySalesLocation = 1;
                    }
                    else
                    {
                        varUpDownKeySalesLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSalesLocation.CurrentCell = DGV_FilterSalesLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSaleLocation.Text = DGV_FilterSalesLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtSaleLocation.Focus();
                            txtSaleLocation.SelectionStart = txtSaleLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSalesLocation.Rows.Count) DGV_FilterSalesLocation.CurrentCell = DGV_FilterSalesLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSalesLocation.Rows.Count))
                            {
                                txtSaleLocation.Text = DGV_FilterSalesLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSaleLocation.Focus();
                            txtSaleLocation.SelectionStart = txtSaleLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSalesLocation.Rows.Count > 0)
                                {
                                    varUpDownKeySalesLocation = 1;
                                    udfnSaleLocationAutocomplete();
                                    DGV_FilterSalesLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSaleLocation.Focus();
                    //txtSaleLocation.SelectionStart = txtSaleLocation.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtSaleRack.Enabled == true)
                        {
                            txtSaleRack.Focus();
                        }
                        else
                        {
                            if (pnlStatus.Enabled == true)
                            {
                                if (rbActive.Checked == true)
                                {
                                    rbActive.Focus();
                                }
                                else
                                {
                                    rbInActive.Focus();
                                }
                            }
                            else
                            {
                                btnSave.Focus();
                            }
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

        private void TxtSaleLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSaleLocation.Text == "")
                {
                    txtSaleLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtSaleLocation, "Please enter sales location");
                    txtSaleRack.Text = "";
                    txtRackDescriptionSales.Text = "";
                    lblSaleRackCode.Text = "0";
                }
                else
                {
                    txtSaleLocation.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSaleLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtSaleRack.Text = "";
                txtRackDescriptionSales.Text = "";
                txtSaleRack.Enabled = true;
                if (varUpDownKeySalesLocation == 0)
                {
                    if (txtSaleLocation.Text.Length > 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();


                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 10;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtSaleLocation.Text.Trim();
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(10, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSaleLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterSalesLocation.Visible = true;
                                    DGV_FilterSalesLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterSalesLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterSalesLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterSalesLocation.Columns["SL_EName"].HeaderText = "Location E Name";
                                    DGV_FilterSalesLocation.Columns["SL_TName"].HeaderText = "Location T Name";
                                    DGV_FilterSalesLocation.Columns["SL_EName"].Width = 180;
                                    DGV_FilterSalesLocation.Columns["SL_TName"].Width = 180;
                                    DGV_FilterSalesLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterSalesLocation.Columns["SL_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterSalesLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSalesLocation.DataSource = null;
                                    DGV_FilterSalesLocation.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterSalesLocation.DataSource = null;
                                DGV_FilterSalesLocation.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterSalesLocation.DataSource = null;
                            DGV_FilterSalesLocation.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterSalesLocation.DataSource = null;
                        DGV_FilterSalesLocation.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtSaleLocation.Focus();
            }
        }


        private void LvPurRack_DoubleClick(object sender, EventArgs e)
        {
            udfnPurRackAutocomplete();
        }


        private void TxtSaleRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSaleRack.Items.Clear();
                if (txtSaleRack.Text.Length > 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(lblSaleLocationCode.Text), 0, txtSaleRack.Text.Trim(), 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RK_Description"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSaleRack.Items.Add(objList);
                                }
                                lvSaleRack.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvSaleRack.Visible = false;
                    lvSaleRack.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGst_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbGst.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGst_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbGst.SelectedValue) == "" || Convert.ToString(cmbGst.SelectedValue) == "-1")
                {
                    errItems.SetError(cmbGst, "Please select GST%");
                    cmbGst.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpgst.ShowAlways = true;
                    tpgst.Show("Please select GST%", cmbProductCategory, 5000);
                }
                else
                {
                    errItems.Clear();
                    cmbGst.BackColor = Color.White;
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbGst_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtHSNCode.Enabled == true)
                    {
                        txtHSNCode.Focus();
                    }
                    else
                    {
                        if (pnlStatus.Enabled == true)
                        {
                            if (rbActive.Checked == true)
                            {
                                rbActive.Focus();
                            }
                            else
                            {
                                rbInActive.Focus();
                            }
                        }
                        else
                        {
                            btnSave.Focus();
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

        private void CmbGst_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbGst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbGst.Select(int.MaxValue, 0)));
                if (txtHsnName.Text != "")
                {
                    string varId_HSN = "0"; string varId_HSNGST = "0";
                    DataSet objDsHSN = new DataSet();
                    DataSet objDsHSNGst = new DataSet();
                    SPDataService objDs = new SPDataService();
                    objDsHSN = objDs.udfnHsnList(7, 0, 0, 0, txtHsnName.Text.Trim(), "");
                    objDsHSNGst = objDs.udfnHsnList(8, 0, Convert.ToInt32(cmbGst.SelectedValue), 0, "", "");
                    objDs.CloseConnection();
                    if (objDsHSN != null)
                    {
                        if (objDsHSN.Tables.Count > 0)
                        {
                            if (objDsHSN.Tables[0].Rows.Count > 0)
                            {
                                varId_HSN = Convert.ToString(objDsHSN.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (objDsHSNGst != null)
                    {
                        if (objDsHSNGst.Tables.Count > 0)
                        {
                            if (objDsHSNGst.Tables[0].Rows.Count > 0)
                            {
                                varId_HSNGST = Convert.ToString(objDsHSNGst.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varId_HSN != varId_HSNGST)
                    {
                        txtHsnName.Text = "";
                        txtHSNCode.Text = "";
                    }

                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtHsnName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvHsnCode.Items.Count == 0 || txtHsnName.Text == "")
                    {
                        txtHsnName.Focus();
                        lvHsnCode.Visible = false;
                    }
                    else
                    {
                        lvHsnCode.Focus();
                    }
                    if (lvHsnCode.Items.Count > 0)
                    {
                        lvHsnCode.Items[0].Selected = true;
                    }
                }
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

        private void TxtHsnName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvHsnCode.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtHsnName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnHsnList(6, 0, 0, 0, txtHsnName.Text.Trim(), "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["HSN_Name"].ToString(), objDs.Tables[0].Rows[i]["HSN_Code"].ToString(), objDs.Tables[0].Rows[i]["HSNID"].ToString(), objDs.Tables[0].Rows[i]["HSN_GSTID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvHsnCode.Items.Add(objList);
                                }
                                lvHsnCode.Visible = true;
                                lvHsnCode.BringToFront();
                                lvHsnCode.Columns[0].Width = 200;
                                lvHsnCode.Columns[1].Width = 0;
                                lvHsnCode.Columns[2].Width = 0;
                            }
                        }
                    }
                }
                else
                {
                    lvHsnCode.Visible = false;
                    lvHsnCode.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHsnName_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(txtHsnName.Text.Trim()) == "")
                //{
                //    errItems.SetError(txtHsnName, "Please enter HSN name");
                //    txtHsnName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpHsnName.ShowAlways = true;
                //    tpHsnName.Show("Please enter HSN name", txtHsnName, 5000);
                //}
                //else
                //{
                //    errItems.Clear();
                //    txtHsnName.BackColor = Color.White;
                //}
                txtHsnName.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHSNAutocomplete()
        {
            try
            {
                if (txtHsnName.Text != "")
                {
                    ListViewItem selectedItem = lvHsnCode.SelectedItems[0];
                    cmbGst.SelectedValue = Convert.ToInt32(selectedItem.SubItems[3].Text);
                    txtHSNCode.Text = selectedItem.SubItems[1].Text;
                    lblHsnName.Text = selectedItem.SubItems[2].Text;
                    txtHsnName.Text = selectedItem.SubItems[0].Text;
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvHsnCode.Visible = false;
            }
        }
        private void LvHsnName_DoubleClick(object sender, EventArgs e)
        {
            try { udfnHSNAutocomplete(); }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvHsnName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnHSNAutocomplete();
                    if (pnlStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInActive.Focus();
                        }
                    }
                    else
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

        private void TxtHSNCode_Leave(object sender, EventArgs e)
        {

            try
            {
                txtHSNCode.BackColor = Color.White;
                errItems.Clear();
                //if (Convert.ToString(txtHSNCode.Text.Trim()) != "")
                //{
                //    if (Convert.ToString(lblHsnName.Text) == "" || Convert.ToString(lblHsnName.Text) == "0" || Convert.ToString(lblHsnName.Text) == "-1")
                //    {
                //        errItems.SetError(txtHSNCode, "Please enter valid HSN code");
                //        txtHSNCode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpHsnCode.ShowAlways = true;
                //        tpHsnCode.Show("Please enter valid HSN code", txtHSNCode, 5000);
                //        txtHSNCode.Text = "";
                //    }
                //}
                //else
                //{
                //    txtSubGroup.BackColor = Color.White;
                //    errItems.Clear();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNCode_Enter(object sender, EventArgs e)
        {
            try
            {
                txtHSNCode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtHSNCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvHsnCode.Items.Count == 0 || txtHSNCode.Text == "")
                    {
                        txtHSNCode.Focus();
                        lvHsnCode.Visible = false;
                    }
                    else
                    {
                        lvHsnCode.Focus();
                    }
                    if (lvHsnCode.Items.Count > 0)
                    {
                        lvHsnCode.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (pnlStatus.Enabled == true)
                    {
                        if (rbActive.Checked == true)
                        {
                            rbActive.Focus();
                        }
                        else
                        {
                            rbInActive.Focus();
                        }
                    }
                    else
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

        private void TxtHSNCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvHsnCode.Items.Clear();

                if (txtHSNCode.Text.Length > 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnHsnList(6, 0, Convert.ToInt32(cmbGst.SelectedValue), 0, txtHSNCode.Text.Trim(), "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["HSN_Code"].ToString(), objDs.Tables[0].Rows[i]["HSN_Name"].ToString(), objDs.Tables[0].Rows[i]["HSNID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvHsnCode.Items.Add(objList);
                                    lvHsnCode.Columns[0].Width = 90;
                                    lvHsnCode.Columns[1].Width = 160;
                                    lvHsnCode.Columns[2].Width = 0;
                                }
                                lvHsnCode.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvHsnCode.Visible = false;
                    lvHsnCode.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPICode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // txtPICode.Text = txtPICode.Text.ToUpper();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (varproductcode == 0 || pbCloneFlag == 1)
                {
                    if (cbCompleted.Checked)
                    {
                        btnSave.Text = "Save";
                    }
                    else
                    {
                        btnSave.Text = "Save as Draft";
                    }
                }
                else if (varproductcode != 0)
                {
                    if (cbCompleted.Checked)
                    {
                        btnSave.Text = "Update";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkSameasPurchase_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSameasPurchase.Checked == true)
                {

                    txtSaleLocation.Text = txtPurLocation.Text;
                    txtSaleRack.Text = txtPurRack.Text;
                    txtRackDescriptionSales.Text = txtRackDescription.Text;
                    lblSaleLocationCode.Text = lblPurLocationCode.Text;
                    DGV_FilterSalesLocation.DataSource = null;
                    DGV_FilterSalesLocation.Visible = false;
                    lblSaleRackCode.Text = lblPurRackCode.Text;
                    lvSaleRack.Visible = false;
                    txtSaleRack.Enabled = false;
                    txtSaleRack.ReadOnly = true;
                    txtSaleLocation.Enabled = false;
                    txtSaleLocation.ReadOnly = true;
                    txtRackDescriptionSales.Enabled = false;
                    txtRackDescriptionSales.ReadOnly = true;

                }
                else
                {
                    txtSaleRack.Enabled = true;
                    txtSaleRack.ReadOnly = false;
                    txtSaleLocation.Enabled = true;
                    txtSaleLocation.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkMRP_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtPurLocation.Enabled == true)
                    {
                        txtPurLocation.Focus();
                    }
                    else if (txtPurRack.Enabled == true)
                    {
                        txtPurRack.Focus();
                    }
                    else
                    {
                        txtSaleLocation.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkMRP_Enter(object sender, EventArgs e)
        {
            try
            {
                chkMRP.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkMRP_Leave(object sender, EventArgs e)
        {
            try
            {
                chkMRP.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbCompleted_Enter(object sender, EventArgs e)
        {
            try
            {
                cbCompleted.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbCompleted_Leave(object sender, EventArgs e)
        {
            try
            {
                cbCompleted.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPURHSNName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                varPurHSNID = 0;
                lvPURHSNCode.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtPURHSNName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnHsnList(6, pbProHSNID, 0, 0, txtPURHSNName.Text.Trim(), "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["HSN_Name"].ToString(), objDs.Tables[0].Rows[i]["HSN_Code"].ToString(), objDs.Tables[0].Rows[i]["HSNID"].ToString(), objDs.Tables[0].Rows[i]["HSN_GSTID"].ToString(), objDs.Tables[0].Rows[i]["GST_Text"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvPURHSNCode.Items.Add(objList);
                                }
                                lvPURHSNCode.Visible = true;
                                lvPURHSNCode.BringToFront();
                                lvPURHSNCode.Columns[0].Width = 180;
                                lvPURHSNCode.Columns[1].Width = 100;
                                lvPURHSNCode.Columns[2].Width = 0;
                                lvPURHSNCode.Columns[3].Width = 0;
                                lvPURHSNCode.Columns[4].Width = 0;
                            }
                        }
                    }
                }
                else
                {
                    lvPURHSNCode.Visible = false;
                    lvPURHSNCode.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvPURHSNCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPURHSNAutocomplete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPURHSNAutocomplete()
        {
            try
            {
                if (txtPURHSNName.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvPURHSNCode.SelectedItems[0];
                    varPurHSNCode = selectedItem.SubItems[1].Text;
                    varPurGST = selectedItem.SubItems[4].Text;
                    txtPURHSNName.Text = selectedItem.SubItems[0].Text;
                    varPurHSNID = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    dpPurEffectiveFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvPURHSNCode.Visible = false;
            }
        }
        public void udfnSalesHSNAutocomplete()
        {
            try
            {
                if (txtSalesHSNName.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvSalesHSNCode.SelectedItems[0];
                    varSalesHSNCode = selectedItem.SubItems[1].Text;
                    varSalesGST = selectedItem.SubItems[4].Text;
                    txtSalesHSNName.Text = selectedItem.SubItems[0].Text;
                    varSalesHSNID = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    dpSalesEffectiveFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSalesHSNCode.Visible = false;
            }
        }
        private void TxtPURHSNName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvPURHSNCode.Items.Count == 0 || txtPURHSNName.Text == "")
                    {
                        txtPURHSNName.Focus();
                        lvPURHSNCode.Visible = false;
                    }
                    else
                    {
                        lvPURHSNCode.Focus();
                    }
                    if (lvPURHSNCode.Items.Count > 0)
                    {
                        lvPURHSNCode.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    dpPurEffectiveFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpPurEffectiveFrom_Enter(object sender, EventArgs e)
        {
            try
            {
                lvPURHSNCode.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpSalesEffectiveFrom_Enter(object sender, EventArgs e)
        {
            try
            {
                lvSalesHSNCode.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesHSNName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSalesHSNCode.Items.Count == 0 || txtSalesHSNName.Text == "")
                    {
                        txtSalesHSNName.Focus();
                        lvSalesHSNCode.Visible = false;
                    }
                    else
                    {
                        lvSalesHSNCode.Focus();
                    }
                    if (lvSalesHSNCode.Items.Count > 0)
                    {
                        lvSalesHSNCode.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    dpSalesEffectiveFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSalesHSNCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSalesHSNAutocomplete();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvPURHSNCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnPURHSNAutocomplete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurHSN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPurHSN.Columns[e.ColumnIndex].Name)
                    {
                        case "clmPurRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                int varProductID = Convert.ToInt32(grdPurHSN.CurrentRow.Cells["clmPurHSNID"].Value);
                                string varEffectiveFrom = Convert.ToString(grdPurHSN.CurrentRow.Cells["clmPurEffectiveFrom"].Value);

                                var rowsToDelete = dtPurHSN.AsEnumerable().Where(row => row.Field<int>("HSNID") == varProductID && row.Field<string>("HSN_EffectiveFrom") == varEffectiveFrom).ToList();
                                foreach (var row in rowsToDelete)
                                {
                                    dtPurHSN.Rows.Remove(row);
                                }
                                grdPurHSN.Rows.RemoveAt(this.grdPurHSN.CurrentRow.Index);
                                //udfnSetPurMinDate();
                                udfnUpdateRemovableFlags();
                                udfnPurHideRemove();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnUpdateRemovableFlags()
        {
            try
            {
                foreach (DataGridViewRow row in grdPurHSN.Rows)
                {
                    row.Cells["clmPurAddFlag"].Value = "1";
                }
                if (grdPurHSN.Rows.Count > 0)
                {
                    var lastRow = grdPurHSN.Rows[grdPurHSN.Rows.Count - 1];
                    lastRow.Cells["clmPurAddFlag"].Value = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnUpdateSalesRemovableFlags()
        {
            try
            {
                foreach (DataGridViewRow row in grdSalesHSN.Rows)
                {
                    row.Cells["clmSalesAddFlag"].Value = "1";
                }
                if (grdSalesHSN.Rows.Count > 0)
                {
                    var lastRow = grdSalesHSN.Rows[grdSalesHSN.Rows.Count - 1];
                    lastRow.Cells["clmSalesAddFlag"].Value = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSalesHSN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdSalesHSN.Columns[e.ColumnIndex].Name)
                    {
                        case "clmSalesRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                int varProductID = Convert.ToInt32(grdSalesHSN.CurrentRow.Cells["clmSalesHSNID"].Value);
                                string varEffectiveFrom = Convert.ToString(grdSalesHSN.CurrentRow.Cells["clmSalesEffectiveFrom"].Value);

                                var rowsToDelete = dtSalesHSN.AsEnumerable().Where(row => row.Field<int>("HSNID") == varProductID && row.Field<string>("HSN_EffectiveFrom") == varEffectiveFrom).ToList();
                                foreach (var row in rowsToDelete)
                                {
                                    dtSalesHSN.Rows.Remove(row);
                                }
                                grdSalesHSN.Rows.RemoveAt(this.grdSalesHSN.CurrentRow.Index);

                                udfnUpdateSalesRemovableFlags();
                                udfnSalesHideRemove();
                                //udfnSetSalesMinDate();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPURHSNName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtPURHSNName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtPURHSNName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPURHSNName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesHSNName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesHSNName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesHSNName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesHSNName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSalesHSNCode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSalesHSNAutocomplete();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesHSNName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                varSalesHSNID = 0;
                lvSalesHSNCode.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSalesHSNName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnHsnList(6, pbSalesHSNID, 0, 0, txtSalesHSNName.Text.Trim(), "");
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["HSN_Name"].ToString(), objDs.Tables[0].Rows[i]["HSN_Code"].ToString(), objDs.Tables[0].Rows[i]["HSNID"].ToString(), objDs.Tables[0].Rows[i]["HSN_GSTID"].ToString(), objDs.Tables[0].Rows[i]["GST_Text"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSalesHSNCode.Items.Add(objList);
                                }
                                lvSalesHSNCode.Visible = true;
                                lvSalesHSNCode.BringToFront();
                                lvSalesHSNCode.Columns[0].Width = 180;
                                lvSalesHSNCode.Columns[1].Width = 100;
                                lvSalesHSNCode.Columns[2].Width = 0;
                                lvSalesHSNCode.Columns[3].Width = 0;
                                lvSalesHSNCode.Columns[4].Width = 0;
                            }
                        }
                    }
                }
                else
                {
                    lvSalesHSNCode.Visible = false;
                    lvSalesHSNCode.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnSave.Visible = true;
                btnImageUpdate.Visible = false;
                if (tbProduct.SelectedIndex == 1)
                {
                    txtPURHSNName.Focus();
                    lblProductEName.AutoSize = true;
                    lblProductEName.MaximumSize = new Size(500, 0);
                    lblProductEName.Text = txtItemNameTamil.Text.Trim();
                }
                if (tbProduct.SelectedIndex == 2)
                {
                    btnImageUpdate.Visible = true;
                    btnSave.Visible = false;
                    cbCompleted.Visible = false;
                }
                else
                {
                    btnImageUpdate.Visible = false;
                    cbCompleted.Visible = true;
                }

                btnSave.Enabled = true;
                if (Convert.ToInt32(tbProduct.SelectedIndex) == 3)
                {
                    btnSave.Enabled = false;
                    grdPrice.Rows.Clear();
                    udfnPriceMarkup();

                    DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                    grdPrice_DataBindingComplete(grdPrice, args);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSaveHsn_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPurHSN.Rows.Count < 1)
                {
                    SPDataService objDataService = new SPDataService();
                    string varMessage = objDataService.udfnGetMessages(149);
                    objDataService.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                /*
                if (grdSalesHSN.Rows.Count < 1)
                {
                    MessageBox.Show("Please add atleast one sales hsn.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                */

                dtProductHSN.Rows.Clear();
                foreach (DataRow row in dtPurHSN.Rows)
                {
                    dtProductHSN.ImportRow(row);
                }
                foreach (DataRow row in dtSalesHSN.Rows)
                {
                    dtProductHSN.ImportRow(row);
                }
                if (grdPurHSN.Rows.Count > 0 || grdSalesHSN.Rows.Count > 0)
                {
                    varPurEffectiveFromErr = 0;
                    varSalesEffectiveFromErr = 0;
                    udfnEffectiveDateValidation();
                }
                errItems.Clear();
                if (varPurEffectiveFromErr == 0 && varSalesEffectiveFromErr == 0)
                {
                    udfnSave();
                }
                //udfnHSNSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnEffectiveDateValidation()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 26;
                objMR_Master.ParaProduct_HSN = dtProductHSN;
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            string result = objDT.Tables[0].Rows[0][0].ToString();
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "4")
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varPurEffectiveFromErr = 1;
                                varSalesEffectiveFromErr = 1;
                            }
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
        public void udfnHSNSave()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                string result = "";
                result = objspdservice.udfnProductMaster(15, varproductcode, "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "", 0, null, 0, "", 0, 0, 0, 0, 0, dtProductHSN, txtLabelNameEnglish.Text.Trim(), txtLabelNameTamil.Text.Trim(), "", 0, "", "", 0, 0, 0, null, 0, 0, 0, 0, null, 0,"","", "", "");
                objspdservice.CloseConnection();
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (varMasterType == "1")
                    {
                        MainForm.objCP_Purchase.lblProductcode.Text = varvalue[2];
                        MainForm.objCP_Purchase.txtProductName.Text = txtItemNameEnglish.Text;
                        varupdate = "1";
                        this.Close();
                    }
                    else if (varMasterType != "0")
                    {
                        varupdate = "1";
                        this.Close();
                    }
                    else
                    {
                        MainForm.objCP_Itemlist.udfnDropdownbind();
                        //MainForm.objCP_Itemlist.udfnList();
                        //udfnclear();
                        varupdate = "1";
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnHSNClose_Click(object sender, EventArgs e)
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
        private void TxtRackMOQQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPurHSN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                udfnPurHideRemove();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnPurHideRemove()
        {
            try
            {
                if (pbCloneFlag != 1)
                {
                    for (int i = 0; i < grdPurHSN.Rows.Count; i++)
                    {
                        var addFlag = Convert.ToString(grdPurHSN.Rows[i].Cells["clmPurAddFlag"].Value);
                        var editFlag = Convert.ToString(grdPurHSN.Rows[i].Cells["clmPurEditFlag"].Value);
                        var removeCell = grdPurHSN.Rows[i].Cells["clmPurRemove"];

                        if (addFlag == "0" && editFlag == "0")
                        {
                            removeCell.Value = global::ROMS.Properties.Resources.remove;
                            removeCell.ReadOnly = false;
                        }
                        else
                        {
                            removeCell.Value = new Bitmap(1, 1);
                            removeCell.ReadOnly = true;
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
        private void udfnSalesHideRemove()
        {
            try
            {
                if (pbCloneFlag != 1)
                {
                    for (int i = 0; i < grdSalesHSN.Rows.Count; i++)
                    {
                        var addFlag = Convert.ToString(grdSalesHSN.Rows[i].Cells["clmSalesAddFlag"].Value);
                        var editFlag = Convert.ToString(grdSalesHSN.Rows[i].Cells["clmSalesEditFlag"].Value);
                        var removeCell = grdSalesHSN.Rows[i].Cells["clmSalesRemove"];

                        if (addFlag == "0" && editFlag == "0")
                        {
                            removeCell.Value = global::ROMS.Properties.Resources.remove;
                            removeCell.ReadOnly = false;
                        }
                        else
                        {
                            removeCell.Value = new Bitmap(1, 1);
                            removeCell.ReadOnly = true;
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

        private void GrdSalesHSN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                udfnSalesHideRemove();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelNameEnglish_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLabelNameEnglish.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelNameEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLabelNameTamil.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelNameEnglish_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLabelNameEnglish.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelNameTamil_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLabelNameTamil.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelNameTamil_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSubGroup.Enabled == false)
                    {
                        cmbUnit.Focus();
                    }
                    else { txtSubGroup.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLabelNameTamil_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLabelNameTamil.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbProductType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbProductType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbProductType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtProductName.Enabled == true)
                    {
                        txtProductName.Focus();
                    }
                    else
                    {

                        txtPICode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    if (txtProductName.Text.Length > 0)
                    {
                        DGV_FilterProduct.BringToFront();
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 71;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(0);
                        objMR_Product.paraProductName = "";
                        objMR_Product.paraPicode = txtProductName.Text;
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objMR_Product.paraProductName = txtProductName.Text.Trim();
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);

                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    //for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    //{
                                    DGV_FilterProduct.Visible = true;

                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["UTID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Visible = true;
                                    DGV_FilterProduct.Columns["PR_BatchNo"].Visible = false;
                                    DGV_FilterProduct.Columns["Product Shelf Life"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_ShelfLifeType"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_ShelfLife"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_ShelfLifeValue"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_BatchNoGeneration"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_MRPflag"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 115;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 60;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["Product Shelf Life"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["PR_RetailRate"].Visible = false;

                                    DGV_FilterProduct.Columns["PR_EName"].Visible = true;
                                    DGV_FilterProduct.Columns["PR_TName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2;

                                }
                                else
                                {
                                    DGV_FilterProduct.DataSource = null;
                                    DGV_FilterProduct.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                    }
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



        private void txtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                varUpDownKey = 0;


                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    //btnConditions.Focus();
                    txtPICode.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.RowCount > 0)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterProduct.Focus();
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }
                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {

                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnProductEvent();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtPICode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProductName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void DpPurEffectiveFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnPURHSN.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnProductEvent();
                txtPICode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnProductEvent();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtPICode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbProductType.SelectedValue) == 341) //Parent
                {
                    txtProductName.Text = "";
                    txtProductName.Enabled = false;
                    txtGroup.Enabled = true;
                    txtSubGroup.Enabled = true;
                    txtBrand.Enabled = true;
                    lblParentcode.Text = "0";

                    txtGroup.ReadOnly = false;
                    txtSubGroup.ReadOnly = false;
                    txtBrand.ReadOnly = false;
                    txtProductName.ReadOnly = true;
                }
                else if (Convert.ToInt32(cmbProductType.SelectedValue) == 342) //Child
                {
                    cmbChildUnit.Enabled = true;
                    txtGroup.Enabled = false;
                    txtSubGroup.Enabled = false;
                    txtBrand.Enabled = false;
                    txtProductName.Enabled = true;
                    txtUpp.Enabled = true;


                    txtGroup.ReadOnly = true;
                    txtSubGroup.ReadOnly = true;
                    txtBrand.ReadOnly = true;
                    txtProductName.ReadOnly = false;
                    txtUpp.ReadOnly = false;

                }

                if (Convert.ToInt32(cmbProductType.SelectedValue) != 342)
                {
                    txtUpp.Text = "";
                    txtUpp.Enabled = false;
                    cmbChildUnit.SelectedValue = -1;
                    cmbChildUnit.Enabled = false;
                }
                if (btnSave.Text != "Update" && pbCloneFlag != 1)// clone product no need to clear details added by Sathish on 23-08-2025
                {
                    txtProductName.Text = "";
                    lblParentcode.Text = "0";

                    txtPICode.Text = "";
                    txtItemNameEnglish.Text = "";
                    txtItemNameTamil.Text = "";
                    txtLabelNameEnglish.Text = "";
                    txtLabelNameTamil.Text = "";
                    varSubGroupId = 0;
                    lblSubGroupCode.Text = "";
                    txtSubGroup.Text = "";
                    varGroupId = 0;
                    lblGroupCode.Text = "";
                    txtGroup.Text = "";
                    varBrandId = 0;
                    lblBrand.Text = "";
                    txtBrand.Text = "";
                    varUnitid = 0;
                    cmbChildUnit.SelectedValue = -1;
                    varPURSLID = 0;
                    lblPurLocationCode.Text = "";
                    txtPurLocation.Text = "";
                    varPURRKID = 0;
                    lblPurRackCode.Text = "";
                    txtPurRack.Text = "";
                    txtRackDescription.Text = "";
                    txtGroup.BackColor = Color.White;
                    txtSubGroup.BackColor = Color.White;
                    txtBrand.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkSalesProduct_Enter(object sender, EventArgs e)
        {
            try
            {
                chkSalesProduct.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkSalesProduct_Leave(object sender, EventArgs e)
        {
            try
            {
                chkSalesProduct.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;  // Allow multiple selection
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        int varUploadFlag = 0;
                        foreach (string file in ofd.FileNames)
                        {
                            FileInfo fileInfo = new FileInfo(file);

                            if (fileInfo.Length > 512000) // 500KB limit
                            {
                                varUploadFlag++;
                                continue; // Skip this file
                            }
                        }
                        if (varUploadFlag == 0)
                        {
                            foreach (string file in ofd.FileNames)
                            {
                                FileInfo fileInfo = new FileInfo(file);

                                if (fileInfo.Length > 512000) // 500KB limit
                                {
                                    MessageBox.Show($"The file '{fileInfo.Name}' is too large. Please select an image below 500KB.",
                                                    "File Size Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    continue; // Skip this file
                                }
                                else
                                {
                                    if (!imagePaths.Contains(file))  // Avoid duplicate images
                                    {
                                        imagePaths.Add(file);
                                        AddImageToPanel(file);
                                        if (imagePaths.Count == 1)
                                        {
                                            ZoomImage(file);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show($"The file is too large. Please select an image below 500KB.",
                                                  "File Size Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private Image LoadImageWithoutLock(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (Image img = Image.FromStream(fs))
                {
                    return new Bitmap(img);
                }
            }
        }

        private void AddImageToPanel(string filePath)
        {
            try
            {
                Panel panel = new Panel
                {
                    Size = new Size(120, 150),
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10)
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = LoadImageWithoutLock(filePath),
                    ImageLocation = filePath,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(100, 100),
                    Dock = DockStyle.Top,
                    Cursor = Cursors.Hand
                };

                Button btnRemove = new Button
                {
                    Text = "X",
                    ForeColor = Color.White,
                    BackColor = Color.Red,
                    Font = new Font("Arial", 8, FontStyle.Bold),
                    Width = 20,
                    Height = 20,
                    Cursor = Cursors.Hand
                };
                btnRemove.Click += (s, e) => RemoveImage(panel, filePath);

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(btnRemove);
                btnRemove.Location = new Point(100, 0);
                flowLayoutPanel1.Controls.Add(panel);

                EditableImage ei = new EditableImage
                {
                    FilePath = filePath,
                    EditedImage = null,
                    Thumbnail = pictureBox,
                    ContainerPanel = panel
                };
                editableImages.Add(ei);
                pictureBox.Click += (s, e) =>
                {
                    LoadImageToEditor(ei);
                };
                if (currentImage == null)
                {
                    LoadImageToEditor(ei);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        EditableImage currentImage;
        private void ZoomImage(string path)
        {
            try
            {
                tsbCropImage.Enabled = false;
                if (originalImage != null)
                    originalImage.Dispose();

                originalImage = LoadImageWithoutLock(path);
                zoom = 1.0f;

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = new Bitmap(originalImage);
                pictureBox1.Size = pnlImageContainer.ClientSize;
                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.Height - pictureBox1.Height) / 2, 0)
                );
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LoadImageToEditor(EditableImage ei)
        {
            currentImage = ei;

            if (ei.EditedImage != null)
            {
                originalImage = new Bitmap(ei.EditedImage);
            }
            else
            {
                using (FileStream fs = new FileStream(ei.FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (Image temp = Image.FromStream(fs))
                    {
                        originalImage = new Bitmap(temp);
                    }
                }
            }

            zoom = 1.0f;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = new Bitmap(originalImage);
            pictureBox1.Size = pnlImageContainer.ClientSize;
            pictureBox1.Location = new Point(0, 0);
            UpdateZoomButtonsVisibility();
        }
        private void UpdateZoomButtonsVisibility()
        {
            bool hasImage = pictureBox1.Image != null;
            //btnPlus.Visible = hasImage;
            //btnMinus.Visible = hasImage;
            //btnClkRotate.Visible = hasImage;
            //btnAnticlkRotation.Visible = hasImage;
            //btnCrop.Visible = hasImage;
            //btnResetImage.Visible = hasImage;
            tsbZoomIn.Visible = hasImage;
            tsbZoomOut.Visible = hasImage;
            tsbRotateR.Visible = hasImage;
            tsbRotateL.Visible = hasImage;
            tsbCrop.Visible = hasImage;
            tsbColour.Visible = hasImage;
            tsbCropImage.Visible = hasImage;
            tsbReset.Visible = hasImage;
            tssEdit.Visible = hasImage;
            toolStripSeparator1.Visible = hasImage;
            toolStripSeparator2.Visible = hasImage;
            toolStripSeparator3.Visible = hasImage;
            toolStripSeparator4.Visible = hasImage;
            toolStripSeparator5.Visible = hasImage;
        }
        private void RemoveImage(Panel panel, string imagePath)
        {
            try
            {
                EditableImage toRemove = editableImages.FirstOrDefault(ei => ei.FilePath == imagePath && ei.ContainerPanel == panel);
                if (toRemove != null)
                {
                    editableImages.Remove(toRemove);
                }
                flowLayoutPanel1.Controls.Remove(panel);
                panel.Dispose();

                if (currentImage != null && currentImage.FilePath == imagePath)
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    if (originalImage != null)
                    {
                        originalImage.Dispose();
                        originalImage = null;
                    }

                    currentImage = null;
                    zoom = 1.0f;
                }
                UpdateZoomButtonsVisibility();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tbBrightness_Scroll(object sender, EventArgs e)
        {
            try
            {
                ApplyAllAdjustments();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ApplyAllAdjustments()
        {
            if (originalImage == null)
                return;

            float brightness = tbBrightness.Value / 100.0f;
            float contrast = (100.0f + tbContrast.Value) / 100.0f;
            contrast *= contrast;
            float saturation = (100.0f + tbSaturation.Value) / 100.0f;

            float lumR = 0.3086f;
            float lumG = 0.6094f;
            float lumB = 0.0820f;

            float sr = (1 - saturation) * lumR;
            float sg = (1 - saturation) * lumG;
            float sb = (1 - saturation) * lumB;

            float[][] colorMatrixElements = {
                                            new float[] { sr + saturation * contrast, sg, sb, 0, 0 },
                                            new float[] { sr, sg + saturation * contrast, sb, 0, 0 },
                                            new float[] { sr, sg, sb + saturation * contrast, 0, 0 },
                                            new float[] { 0, 0, 0, 1, 0 },
                                            new float[] {
                                                        brightness + (0.5f * (1.0f - contrast)),
                                                        brightness + (0.5f * (1.0f - contrast)),
                                                        brightness + (0.5f * (1.0f - contrast)),
                                                        0, 1
                                                        }
                                            };

            Bitmap adjustedBitmap = new Bitmap(originalImage.Width, originalImage.Height);
            using (Graphics g = Graphics.FromImage(adjustedBitmap))
            {
                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(originalImage,
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    0, 0, originalImage.Width, originalImage.Height,
                    GraphicsUnit.Pixel, attributes);
            }

            pictureBox1.Image = adjustedBitmap;
            if (currentImage != null)
            {
                currentImage.EditedImage?.Dispose();
                currentImage.EditedImage = new Bitmap(adjustedBitmap);
            }
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            try
            {
                ApplyAllAdjustments();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tbSaturation_Scroll(object sender, EventArgs e)
        {
            try
            {
                ApplyAllAdjustments();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbColour_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlControls.Visible == true)
                {
                    pnlControls.Visible = false;
                }
                else
                {
                    tbBrightness.Value = 0;
                    tbContrast.Value = 0;
                    tbSaturation.Value = 0;
                    pnlControls.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbCrop_Click(object sender, EventArgs e)
        {
            try
            {
                tsbCropImage.Visible = true;
                tsbCropImage.Enabled = true;
                cropMode = true;
                cropRect = new Rectangle(
                    0, 0,
                    pictureBox1.Width,
                    pictureBox1.Height
                );

                pictureBox1.Invalidate();
                UpdateZoomButtonsVisibility();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbCropImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cropMode || pictureBox1.Image == null) return;

                float scaleX = (float)originalImage.Width / pictureBox1.Width;
                float scaleY = (float)originalImage.Height / pictureBox1.Height;

                Rectangle actualRect = new Rectangle(
                    (int)(cropRect.X * scaleX),
                    (int)(cropRect.Y * scaleY),
                    (int)(cropRect.Width * scaleX),
                    (int)(cropRect.Height * scaleY)
                );

                if (actualRect.X < 0) actualRect.X = 0;
                if (actualRect.Y < 0) actualRect.Y = 0;
                if (actualRect.X + actualRect.Width > originalImage.Width)
                    actualRect.Width = originalImage.Width - actualRect.X;
                if (actualRect.Y + actualRect.Height > originalImage.Height)
                    actualRect.Height = originalImage.Height - actualRect.Y;

                if (actualRect.Width <= 0 || actualRect.Height <= 0)
                {
                    //MessageBox.Show("Invalid crop area!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Bitmap bmp = new Bitmap(originalImage);
                Bitmap cropped = bmp.Clone(actualRect, bmp.PixelFormat);

                pictureBox1.Image = cropped;
                originalImage = cropped;

                if (currentImage != null)
                {
                    currentImage.EditedImage = new Bitmap(cropped);
                }
                zoom = 1.0f;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = pnlImageContainer.ClientSize;
                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.Height - pictureBox1.Height) / 2, 0)
                );

                cropMode = false;
                pictureBox1.Invalidate();
                tsbCropImage.Enabled = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbZoomIn_Click(object sender, EventArgs e)
        {
            try
            {
                zoom += 0.1f;
                udfnApplyZoom();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbZoomOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (zoom > 0.2f)
                {
                    zoom -= 0.1f;
                    udfnApplyZoom();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnApplyZoom()
        {
            try
            {
                if (originalImage == null) return;

                int newWidth = (int)(originalImage.Width * zoom);
                int newHeight = (int)(originalImage.Height * zoom);

                pictureBox1.Size = new Size(newWidth, newHeight);
                pictureBox1.Image = new Bitmap(originalImage, new Size(newWidth, newHeight));

                pnlImageContainer.AutoScroll = false;

                if (newWidth <= pnlImageContainer.ClientSize.Width &&
                    newHeight <= pnlImageContainer.ClientSize.Height)
                {
                    pictureBox1.Location = new Point(
                        (pnlImageContainer.ClientSize.Width - newWidth) / 2,
                        (pnlImageContainer.ClientSize.Height - newHeight) / 2
                    );
                }
                else
                {
                    pnlImageContainer.AutoScroll = true;
                    pictureBox1.Location = new Point(0, 0);
                }

                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsbRotateL_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

                //Bitmap bmp = new Bitmap(originalImage);
                //bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

                //pictureBox1.Image?.Dispose();
                //pictureBox1.Image = new Bitmap(bmp);
                using (Bitmap bmp = new Bitmap(originalImage))  // safely clone original
                {
                    bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    // Dispose previous pictureBox image
                    pictureBox1.Image?.Dispose();

                    // Clone to avoid file lock or GDI+ issues
                    pictureBox1.Image = new Bitmap(bmp);
                }
                originalImage.Dispose();
                originalImage = new Bitmap(pictureBox1.Image);
                if (currentImage != null)
                {
                    currentImage.EditedImage?.Dispose();
                    currentImage.EditedImage = new Bitmap(pictureBox1.Image);
                }
                zoom = 1.0f;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = pnlImageContainer.ClientSize;
                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.Height - pictureBox1.Height) / 2, 0)
                );
                currentImage.RotationAngle = (currentImage.RotationAngle + 270) % 360;
                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbRotateR_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image == null) return;

                //Bitmap bmp = new Bitmap(originalImage);
                //bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

                //pictureBox1.Image?.Dispose();
                //pictureBox1.Image = new Bitmap(bmp);
                using (Bitmap bmp = new Bitmap(originalImage))  // safely clone original
                {
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // Dispose previous pictureBox image
                    pictureBox1.Image?.Dispose();

                    // Clone to avoid file lock or GDI+ issues
                    pictureBox1.Image = new Bitmap(bmp);
                }
                originalImage?.Dispose();
                originalImage = new Bitmap(pictureBox1.Image);
                if (currentImage != null)
                {
                    currentImage.EditedImage?.Dispose();
                    currentImage.EditedImage = new Bitmap(pictureBox1.Image);
                }
                zoom = 1.0f;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = pnlImageContainer.ClientSize;
                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.Height - pictureBox1.Height) / 2, 0)
                );
                currentImage.RotationAngle = (currentImage.RotationAngle + 90) % 360;
                pictureBox1.Invalidate();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentImage == null || string.IsNullOrEmpty(currentImage.FilePath))
                    return;
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                if (originalImage != null)
                {
                    originalImage.Dispose();
                    originalImage = null;
                }
                originalImage = Image.FromFile(currentImage.FilePath);
                pictureBox1.Image = new Bitmap(originalImage);
                zoom = 1.0f;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Size = pnlImageContainer.ClientSize;

                pictureBox1.Location = new Point(
                    Math.Max((pnlImageContainer.ClientSize.Width - pictureBox1.Width) / 2, 0),
                    Math.Max((pnlImageContainer.ClientSize.Height - pictureBox1.Height) / 2, 0)
                );
                cropMode = false;
                cropRect = Rectangle.Empty;
                if (currentImage.EditedImage != null)
                {
                    currentImage.EditedImage.Dispose();
                    currentImage.EditedImage = null;
                }
                currentImage.RotationAngle = 0;
                tbBrightness.Value = 0;
                tbContrast.Value = 0;
                tbSaturation.Value = 0;
                pictureBox1.Invalidate();
                UpdateZoomButtonsVisibility();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (!cropMode) return;
                foreach (var handle in GetHandleRects(cropRect))
                {
                    if (handle.Value.Contains(e.Location))
                    {
                        currentHandle = handle.Key;
                        dragStartPoint = e.Location;
                        return;
                    }
                }
                if (cropRect.Contains(e.Location))
                {
                    currentHandle = CropHandle.None;
                }
                //if (e.Button == MouseButtons.Left)
                //{
                //    isDragging = true;
                //    dragStartPoint = e.Location;
                //    pictureBox1.Cursor = Cursors.SizeAll;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {

                if (!cropMode || currentHandle == CropHandle.None || e.Button != MouseButtons.Left) return;

                int dx = e.X - dragStartPoint.X;
                int dy = e.Y - dragStartPoint.Y;

                switch (currentHandle)
                {
                    case CropHandle.TopLeft:
                        cropRect.X += dx;
                        cropRect.Y += dy;
                        cropRect.Width -= dx;
                        cropRect.Height -= dy;
                        break;

                    case CropHandle.TopRight:
                        cropRect.Y += dy;
                        cropRect.Width += dx;
                        cropRect.Height -= dy;
                        break;

                    case CropHandle.BottomLeft:
                        cropRect.X += dx;
                        cropRect.Width -= dx;
                        cropRect.Height += dy;
                        break;

                    case CropHandle.BottomRight:
                        cropRect.Width += dx;
                        cropRect.Height += dy;
                        break;

                    // Optional edge handles
                    case CropHandle.Left:
                        cropRect.X += dx;
                        cropRect.Width -= dx;
                        break;

                    case CropHandle.Right:
                        cropRect.Width += dx;
                        break;

                    case CropHandle.Top:
                        cropRect.Y += dy;
                        cropRect.Height -= dy;
                        break;

                    case CropHandle.Bottom:
                        cropRect.Height += dy;
                        break;
                }

                dragStartPoint = e.Location;
                pictureBox1.Invalidate();

                //if (isDragging)
                //{
                //    int dx = e.X - dragStartPoint.X;
                //    int dy = e.Y - dragStartPoint.Y;

                //    pnlImageContainer.AutoScrollPosition = new Point(
                //        -pnlImageContainer.AutoScrollPosition.X - dx,
                //        -pnlImageContainer.AutoScrollPosition.Y - dy
                //    );
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            currentHandle = CropHandle.None;
            //isDragging = false;
            //pictureBox1.Cursor = Cursors.Default;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                UpdateZoomButtonsVisibility();
                if (!cropMode) return;

                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, cropRect);
                }
                foreach (var handle in GetHandleRects(cropRect))
                {
                    e.Graphics.FillEllipse(Brushes.White, handle.Value);
                    e.Graphics.DrawEllipse(Pens.Black, handle.Value);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private Dictionary<CropHandle, Rectangle> GetHandleRects(Rectangle rect)
        {
            int hs = HANDLE_SIZE;
            Dictionary<CropHandle, Rectangle> handles = new Dictionary<CropHandle, Rectangle>
            {
                { CropHandle.TopLeft, new Rectangle(rect.Left - hs/2, rect.Top - hs/2, hs, hs) },
                { CropHandle.TopRight, new Rectangle(rect.Right - hs/2, rect.Top - hs/2, hs, hs) },
                { CropHandle.BottomLeft, new Rectangle(rect.Left - hs/2, rect.Bottom - hs/2, hs, hs) },
                { CropHandle.BottomRight, new Rectangle(rect.Right - hs/2, rect.Bottom - hs/2, hs, hs) },
                { CropHandle.Left, new Rectangle(rect.Left - hs/2, rect.Top + rect.Height/2 - hs/2, hs, hs) },
                { CropHandle.Right, new Rectangle(rect.Right - hs/2, rect.Top + rect.Height/2 - hs/2, hs, hs) },
                { CropHandle.Top, new Rectangle(rect.Left + rect.Width/2 - hs/2, rect.Top - hs/2, hs, hs) },
                { CropHandle.Bottom, new Rectangle(rect.Left + rect.Width/2 - hs/2, rect.Bottom - hs/2, hs, hs) },
            };
            return handles;
        }

        private void btnImageUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                List<string> imageNameList = new List<string>();

                DataService objdser = new DataService();
                string destinationPath = objdser.displaydata("SELECT TOP 1 image_path FROM DEF_SharedFolderPath ORDER BY SFID DESC");
                objdser.CloseConnection();

                string destinationFolder = Path.GetDirectoryName(destinationPath);
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                int varFileCount = 1;
                string varImagePath = "";

                string[] existingFiles = Directory.GetFiles(destinationPath, varproductcode + "_*");

                HashSet<string> updatedImages = new HashSet<string>(
                    editableImages.Select(ei =>
                        ei.EditedImage != null
                            ? $"{varproductcode}_{editableImages.IndexOf(ei) + 1}{Path.GetExtension(ei.FilePath)}"
                            : Path.GetFileName(ei.FilePath)
                    )
                );

                foreach (string file in existingFiles)
                {
                    string fileName = Path.GetFileName(file);
                    if (!updatedImages.Contains(fileName))
                    {
                        if (File.Exists(file))
                        {
                            File.SetAttributes(file, FileAttributes.Normal);
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = null;

                            originalImage?.Dispose();
                            originalImage = null;
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            File.Delete(file);
                        }
                    }
                }

                foreach (var ei in editableImages)
                {
                    string extensionName = Path.GetExtension(ei.FilePath);
                    string imageName = $"{varproductcode}_{varFileCount}{extensionName}";
                    string destinationFile = Path.Combine(destinationPath, imageName);

                    if (ei.EditedImage != null)
                    {
                        if (File.Exists(destinationFile))
                        {
                            File.SetAttributes(destinationFile, FileAttributes.Normal);
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = null;

                            originalImage?.Dispose();
                            originalImage = null;
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            File.Delete(destinationFile);
                        }
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ei.EditedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            File.WriteAllBytes(destinationFile, ms.ToArray());
                        }
                    }
                    else
                    {
                        if (ei.FilePath != destinationFile)
                        {
                            if (File.Exists(destinationFile))
                            {
                                File.SetAttributes(destinationFile, FileAttributes.Normal);
                                pictureBox1.Image?.Dispose();
                                pictureBox1.Image = null;

                                originalImage?.Dispose();
                                originalImage = null;
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                File.Delete(destinationFile);
                            }

                            using (FileStream sourceStream = new FileStream(ei.FilePath, FileMode.Open, FileAccess.Read))
                            using (FileStream destStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                            {
                                sourceStream.CopyTo(destStream);
                            }
                        }
                    }


                    imageNameList.Add(imageName);
                    varFileCount++;

                    if (string.IsNullOrEmpty(varImagePath))
                        varImagePath = imageName;
                    else
                        varImagePath += "," + imageName;
                }

                string result = objspdservice.udfnProductMaster(16, varproductcode, "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "", 0, null, 0, "", 0, 0, 0, 0, 0, dtProductHSN, txtLabelNameEnglish.Text.Trim(), txtLabelNameTamil.Text.Trim(), "", 0, "", varImagePath, 0, 0, 0, null, 0, 0, 0, 0, null, 0,"","", "", "");

                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varupdate = "1";
                    this.Close();
                    MainForm.objCP_Itemlist.udfnList();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tbProduct_Selecting(object sender, TabControlCancelEventArgs e)
        {
            udfnTabEnable(sender, e);
        }
        public void udfnTabEnable(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (varproductcode == 0)
                {
                    if (e.TabPage == tabPage3) // Replace with your TabPage name
                    {
                        e.Cancel = true; // Prevents the user from selecting this tab
                    }
                }
                else
                {
                    e.Cancel = false;
                }
                if (e.TabPage == tabPage4) // Replace with your TabPage name
                {
                    if (chkSalesProduct.Checked == true)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true; // Prevents the user from selecting this tab
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnImageClose_Click(object sender, EventArgs e)
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

        private void ChkSalesProduct_KeyDown(object sender, KeyEventArgs e)
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

        private void txtIntermediateUPP_Enter(object sender, EventArgs e)
        {
            try
            {
                txtIntermediateUPP.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtIntermediateUPP_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbIntermediateUnit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtIntermediateUPP_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtIntermediateUPP_Leave(object sender, EventArgs e)
        {
            try
            {
                txtIntermediateUPP.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbIntermediateUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbIntermediateUnit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbIntermediateUnit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductionMSQ.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbIntermediateUnit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbIntermediateUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbIntermediateUnit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbIntermediateUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbIntermediateUnit.SelectedValue) != -1)
                {
                    txtProductionUnit.Text = cmbIntermediateUnit.Text;
                }
                else
                {
                    txtProductionUnit.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProductionMSQ_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductionMSQ.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProductionMSQ_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbStockTakken.Enabled == true)
                    {
                        cmbStockTakken.Focus();
                    }
                    else
                    {
                        cmbBatchNoEntry.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProductionMSQ_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtProductionMSQ_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductionMSQ.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void tbProduct_Click(object sender, EventArgs e)
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

        private void DGV_FilterProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnProductEvent();
                txtPICode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnHideLists()
        {
            try
            {
                lvVerified1.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdPrice_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void grdPrice_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0) return;

                // When clmStatus changes
                //if (grdPrice.Columns[e.ColumnIndex].Name == "clmStatus")
                //{
                //}
                if (grdPrice.Columns[e.ColumnIndex].Name == "clmOffsetValuePer")
                {
                    UpdateRateWithGST(e.RowIndex);
                }

                if (grdPrice.Columns[e.ColumnIndex].Name == "clmOffsetValue")
                {
                    UpdateRateWithGSTValue(e.RowIndex);
                }

                if (grdPrice.Columns[e.ColumnIndex].Name == "clmOffset")
                {
                    RemoveRateWithGST(e.RowIndex);
                }

                if (e.ColumnIndex == grdPrice.Columns["chkColumn"].Index)
                {
                    bool isChecked = Convert.ToBoolean(grdPrice.Rows[e.RowIndex].Cells["chkColumn"].Value);

                    grdPrice.Rows[e.RowIndex].Cells["clmStatus"].Value = isChecked ? 453 : 454;

                    udfnRateenable(e.RowIndex);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdPrice_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdPrice.IsCurrentCellDirty)
                {
                    grdPrice.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTeller_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTeller.BackColor = Color.LemonChiffon;
                udfnHideLists();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdPrice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                // When user edits clmRate
                if (grdPrice.Columns[e.ColumnIndex].Name == "clmRate")
                {
                    UpdateRate(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTeller_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvVerified1.Items.Count == 0 || txtTeller.Text == "")
                    {
                        lvVerified1.Visible = false;
                    }
                    else
                    {
                        lvVerified1.Focus();
                    }
                    if (lvVerified1.Items.Count > 0)
                    {
                        lvVerified1.Items[0].Selected = true;
                    }
                }
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

        private void TxtTeller_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTeller.Text.Trim() == "" && txtTeller.Enabled == true)
                {
                    errItems.SetError(txtTeller, "Please enter name");
                    txtTeller.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpVerifier.ShowAlways = true;
                    tpVerifier.Show("Please enter name", txtTeller, 5000);
                }
                else
                {
                    txtTeller.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdPrice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdPrice.CurrentCell.OwningColumn.Name == "clmOffsetValuePer" || grdPrice.CurrentCell.OwningColumn.Name == "clmOffsetValue" || grdPrice.CurrentCell.OwningColumn.Name == "clmMinQty" || grdPrice.CurrentCell.OwningColumn.Name == "clmRate")
                {

                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int varDecimal = 2;
                if (grdPrice.CurrentCell.OwningColumn.Name == "clmOffsetValuePer" || grdPrice.CurrentCell.OwningColumn.Name == "clmOffsetValue" || grdPrice.CurrentCell.OwningColumn.Name == "clmMinQty" || grdPrice.CurrentCell.OwningColumn.Name == "clmRate")
                {

                    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    //{
                    //    e.Handled = true;  // Disallow the character
                    //}
                    TextBox textBox = (TextBox)sender; 
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (textBox.SelectionLength != textBox.TextLength)
                        {
                            if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                            {
                                e.Handled = true;
                            }
                        }
                    }
                    if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
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
        private void TxtTeller_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTeller.Text.Length > 0)
                {
                    lvVerified1.Items.Clear();
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnEmployeeList(14, txtTeller.Text.Trim(), 0, "", 1, 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["EMP_Name"].ToString(), objDs.Tables[0].Rows[i]["EMPID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvVerified1.Columns[1].Width = 0;
                                    lvVerified1.Items.Add(objList);
                                }
                                lvVerified1.BringToFront();
                                lvVerified1.Visible = true;
                            }
                            else
                            {
                                lvVerified1.Visible = false;
                            }
                        }
                        else
                        {
                            lvVerified1.Visible = false;
                        }
                    }
                    else
                    {
                        lvVerified1.Visible = false;
                    }
                }
                else
                {
                    lvVerified1.Visible = false;
                    lvVerified1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdPrice_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdPrice.Rows)
                {

                    if (row.Cells["clmTypeid"].Value != null &&
                        row.Cells["clmTypeid"].Value.ToString() == "446")
                    {
                        row.Cells["clmOffset"].ReadOnly = true;
                        row.Cells["chkColumn"].ReadOnly = true;

                        DataGridViewTextBoxCell print = new DataGridViewTextBoxCell();
                        print.Value = "";
                        row.Cells["chkColumn"] = print;
                        print.ReadOnly = true;

                        DataGridViewTextBoxCell print1 = new DataGridViewTextBoxCell();
                        print1.Value = "";
                        row.Cells["clmOffset"] = print1;
                        print1.ReadOnly = true;


                        // 1. Clear the ComboBox value
                        row.Cells["clmMinQty"].Value = "";
                        row.Cells["clmOffsetValuePer"].Value = "";
                        row.Cells["clmOffsetValue"].Value = "";

                        // 2. Make ComboBox cell readonly
                        row.Cells["clmMinQty"].ReadOnly = true;
                        row.Cells["clmOffsetValuePer"].ReadOnly = true;
                        row.Cells["clmOffsetValue"].ReadOnly = true;

                        // Optional: give a light gray background to show it's disabled
                        row.Cells["clmMinQty"].Style.BackColor = Color.LightGray;
                        row.Cells["chkColumn"].Style.BackColor = Color.LightGray;
                        row.Cells["clmOffset"].Style.BackColor = Color.LightGray;
                        row.Cells["clmOffsetValuePer"].Style.BackColor = Color.LightGray;
                        row.Cells["clmOffsetValue"].Style.BackColor = Color.LightGray;

                    }

                    if (row.Cells["clmTypeid"].Value != null &&
                        row.Cells["clmTypeid"].Value.ToString() == "447" || row.Cells["clmTypeid"].Value.ToString() == "448")
                    {
                        //row.Cells["clmOffset"].ReadOnly = true;


                        row.Cells["clmOffset"].Value = 453;
                        row.Cells["clmStatus"].Value = 453;

                        row.Cells["chkColumn"].ReadOnly = true;
                        row.Cells["chkColumn"].Value = true;
                        row.Cells["chkColumn"].Style.BackColor = Color.LightGray;

                        //// 1. Clear the ComboBox value
                        //row.Cells["clmMinQty"].Value = "";
                        //row.Cells["clmOffsetValuePer"].Value = "";

                        //// 2. Make ComboBox cell readonly
                        //row.Cells["clmMinQty"].ReadOnly = true;
                        //row.Cells["clmOffsetValuePer"].ReadOnly = true;

                        // Optional: give a light gray background to show it's disabled
                        //row.Cells["clmMinQty"].Style.BackColor = Color.LightGray;
                        //row.Cells["clmOffset"].Style.BackColor = Color.LightGray;
                        //row.Cells["clmOffsetValuePer"].Style.BackColor = Color.LightGray;
                        //row.Cells["clmOffset"].Style.BackColor = Color.LightGray; 

                    }

                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void LvVerified1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnVerified1();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStockTakken_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStockTakken.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStockTakken_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStockTakken.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbStockTakken_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbStockTakken_KeyPress(object sender, KeyPressEventArgs e)
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

        public void udfnVerified1()
        {
            try
            {
                if (txtTeller.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvVerified1.SelectedItems[0];
                    txtTeller.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvVerified1.Visible = false;
                btnSave.Focus();
            }
        }

        private void txtDSubGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubgroupType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDGroup_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDBrand_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSalesPICode_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                txtSalesPICode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void chkSalesProduct_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateSalesProductUI();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void UpdateSalesProductUI()
        {
            if (chkSalesProduct.Checked)
            {
                txtSalesPICode.Enabled = true;
                txtSalesPICode.ReadOnly = false;
            }
            else
            {
                txtSalesPICode.Text = "";
                txtSalesPICode.Enabled = false;
                txtSalesPICode.ReadOnly = true;
            }
        }
        private void txtSalesPICode_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSalesPICode_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesPICode.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvVerified1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnVerified1();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbActive_CheckedChanged(object sender, EventArgs e)
        {
            udfnStatusFlag();
        }
        public void udfnStatusFlag()
        {
            try
            {
                //varStatusFlag==1 when active to inactive varStatusFlag=0 active
                if (rbInActive.Checked == true)
                {
                    if (varStatusFlag == 0)
                    {
                        varStatusFlag = 1;
                    }
                }
                else
                {
                    varStatusFlag = 0;
                }
                if (varStatusFlag == 1)
                {
                    txtTeller.Enabled = true;
                    txtTeller.ReadOnly = false;
                }
                else
                {
                    txtTeller.Text = "";
                    txtTeller.Enabled = false;
                    txtTeller.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSalesLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySalesLocation = 1;
                udfnSaleLocationAutocomplete();
                DGV_FilterSalesLocation.Visible = false;
                if (txtSaleRack.Enabled == true)
                {
                    txtSaleRack.Focus();
                }
                else
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

        private void DGV_FilterSalesLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSalesLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSalesLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySalesLocation = 1;
                    }
                    else
                    {
                        varUpDownKeySalesLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSalesLocation.CurrentCell = DGV_FilterSalesLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtSaleLocation.Text = DGV_FilterSalesLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtSaleLocation.Focus();
                            txtSaleLocation.SelectionStart = txtSaleLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSalesLocation.Rows.Count) DGV_FilterSalesLocation.CurrentCell = DGV_FilterSalesLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSalesLocation.Rows.Count))
                            {
                                txtSaleLocation.Text = DGV_FilterSalesLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSaleLocation.Focus();
                            txtSaleLocation.SelectionStart = txtSaleLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSalesLocation.Rows.Count > 0)
                                {
                                    varUpDownKeySalesLocation = 1;
                                    udfnSaleLocationAutocomplete();
                                    DGV_FilterSalesLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtSaleRack.Enabled == true)
                        {
                            txtSaleRack.Focus();
                        }
                        else
                        {
                            cmbBatchNoEntry.Focus();
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

        private void DGV_FilterPurLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyPurLocation = 1;
                udfnPurLocationAutocomplete();
                if (txtPurRack.Enabled == true)
                {
                    txtPurRack.Focus();
                }
                else if (chkSameasPurchase.Checked == true)
                {
                    txtRackMOQQty.Focus();
                }
                else
                {
                    txtSaleLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterPurLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterPurLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterPurLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyPurLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyPurLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterPurLocation.CurrentCell = DGV_FilterPurLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtPurLocation.Text = DGV_FilterPurLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtPurLocation.Focus();
                            txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterPurLocation.Rows.Count) DGV_FilterPurLocation.CurrentCell = DGV_FilterPurLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterPurLocation.Rows.Count))
                            {
                                txtPurLocation.Text = DGV_FilterPurLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtPurLocation.Focus();
                            txtPurLocation.SelectionStart = txtPurLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterPurLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyPurLocation = 1;
                                    udfnPurLocationAutocomplete();
                                    DGV_FilterPurLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (txtPurRack.Enabled == true)
                        {
                            txtPurRack.Focus();
                        }
                        else if (chkSameasPurchase.Checked == true)
                        {
                            txtRackMOQQty.Focus();
                        }
                        else
                        {
                            txtSaleLocation.Focus();
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

        private void RbInActive_CheckedChanged(object sender, EventArgs e)
        {
            udfnStatusFlag();
        }
        private void LvSaleRack_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProductType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DpSalesEffectiveFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSalesHSN.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPURHSN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPURHSNName.Text.Trim() == "")
                {
                    errItems.SetError(txtPURHSNName, "Please enter purchase hsn name.");
                    txtPURHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpPurHSN.ShowAlways = true;
                    tpPurHSN.Show("Please enter purchase hsn name.", txtPURHSNName, 5000);
                    return;
                }
                else
                {
                    if (varPurHSNID == 0)
                    {
                        errItems.SetError(txtPURHSNName, "Please enter valid purchase hsn name.");
                        txtPURHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpPurHSN.ShowAlways = true;
                        tpPurHSN.Show("Please enter valid purchase hsn name.", txtPURHSNName, 5000);
                        return;
                    }
                }
                varPurEffectiveFromErr = 0;
                udfnPurMinDateValidation();
                errItems.Clear();
                if (varPurEffectiveFromErr == 0)
                {
                    foreach (DataGridViewRow row in grdPurHSN.Rows)
                    {
                        row.Cells["clmPurAddFlag"].Value = 1;
                    }
                    grdPurHSN.Rows.Add(txtPURHSNName.Text.Trim(), varPurHSNCode, varPurGST, dpPurEffectiveFrom.Text, "", varPurHSNID, 0, 0, "", 0);
                    dtPurHSN.Rows.Add(1, varPurHSNID, dpPurEffectiveFrom.Text, "", "", 0);
                    grdPurHSN.Columns["clmPurGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdPurHSN.ClearSelection();
                    udfnPurHideRemove();
                    //udfnSetPurMinDate();
                    txtPURHSNName.Text = "";
                    varPurHSNCode = "";
                    varPurGST = "";
                    varPurHSNID = 0;
                    txtPURHSNName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPurMinDateValidation()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 26;
                objMR_Master.ParaProduct_HSN = dtPurHSN;
                objMR_Master.paraDate = dpPurEffectiveFrom.Text;
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            string result = objDT.Tables[0].Rows[0][0].ToString();
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "4")
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varPurEffectiveFromErr = 1;
                            }
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
        private void udfnSetPurMinDate()
        {
            try
            {
                DateTime maxDate = DateTime.MinValue;

                foreach (DataGridViewRow row in grdPurHSN.Rows)
                {
                    if (row.IsNewRow) continue;
                    DateTime rowDate;
                    if (DateTime.TryParse(row.Cells["clmPurEffectiveFrom"].Value?.ToString(), out rowDate))
                    {
                        if (rowDate > maxDate)
                        {
                            maxDate = rowDate;
                        }
                    }
                }
                if (maxDate != DateTime.MinValue)
                {
                    dpPurEffectiveFrom.MinDate = maxDate.AddDays(1);
                    dpPurEffectiveFrom.Value = dpPurEffectiveFrom.MinDate;
                }
                else
                {
                    dpPurEffectiveFrom.MinDate = DateTimePicker.MinimumDateTime;
                    dpPurEffectiveFrom.Text = Convert.ToString(MainForm.pbCurrentDate);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSalesHSN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesHSNName.Text.Trim() == "")
                {
                    errItems.SetError(txtSalesHSNName, "Please enter sales hsn name.");
                    txtSalesHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSalesHSN.ShowAlways = true;
                    tpSalesHSN.Show("Please enter sales hsn name.", txtSalesHSNName, 5000);
                    return;
                }
                else
                {
                    if (varSalesHSNID == 0)
                    {
                        errItems.SetError(txtSalesHSNName, "Please enter valid sales hsn name.");
                        txtSalesHSNName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSalesHSN.ShowAlways = true;
                        tpSalesHSN.Show("Please enter valid sales hsn name.", txtSalesHSNName, 5000);
                        return;
                    }
                }
                varSalesEffectiveFromErr = 0;
                udfnSalesMinDateValidation();
                errItems.Clear();
                if (varSalesEffectiveFromErr == 0)
                {
                    foreach (DataGridViewRow row in grdSalesHSN.Rows)
                    {
                        row.Cells["clmSalesAddFlag"].Value = 1;
                    }
                    grdSalesHSN.Rows.Add(txtSalesHSNName.Text.Trim(), varSalesHSNCode, varSalesGST, dpSalesEffectiveFrom.Text, "", varSalesHSNID, 0, 0, "", 0);
                    dtSalesHSN.Rows.Add(2, varSalesHSNID, dpSalesEffectiveFrom.Text, "", "", 0);
                    grdSalesHSN.Columns["clmSalesGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdSalesHSN.ClearSelection();
                    udfnSalesHideRemove();
                    //udfnSetSalesMinDate();
                    txtSalesHSNName.Text = "";
                    varSalesHSNCode = "";
                    varSalesGST = "";
                    varSalesHSNID = 0;
                    txtSalesHSNName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSalesMinDateValidation()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 26;
                objMR_Master.ParaProduct_HSN = dtSalesHSN;
                objMR_Master.paraDate = dpSalesEffectiveFrom.Text;
                objDT = objdserv.udfnMaster(objMR_Master);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            string result = objDT.Tables[0].Rows[0][0].ToString();
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "4")
                            {
                                MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                varSalesEffectiveFromErr = 1;
                            }
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
        private void udfnSetSalesMinDate()
        {
            try
            {
                DateTime maxDate = DateTime.MinValue;

                foreach (DataGridViewRow row in grdSalesHSN.Rows)
                {
                    if (row.IsNewRow) continue;
                    DateTime rowDate;
                    if (DateTime.TryParse(row.Cells["clmSalesEffectiveFrom"].Value?.ToString(), out rowDate))
                    {
                        if (rowDate > maxDate)
                        {
                            maxDate = rowDate;
                        }
                    }
                }
                if (maxDate != DateTime.MinValue)
                {
                    dpSalesEffectiveFrom.MinDate = maxDate.AddDays(1);
                    dpSalesEffectiveFrom.Value = dpSalesEffectiveFrom.MinDate;
                }
                else
                {
                    dpSalesEffectiveFrom.MinDate = DateTimePicker.MinimumDateTime;
                    dpSalesEffectiveFrom.Text = Convert.ToString(MainForm.pbCurrentDate);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbNetQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void RbActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInActive_Enter(object sender, EventArgs e)
        {
            try
            {
                rbInActive.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbInActive_Leave(object sender, EventArgs e)
        {
            try
            {
                rbInActive.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRackDescription_Enter(object sender, EventArgs e)
        {
            try
            {
                lvPurRack.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSaleRack_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                txtSaleRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSaleRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvSaleRack.Items.Count == 0 || txtSaleRack.Text == "")
                    {
                        txtSaleRack.Focus();
                        lvSaleRack.Visible = false;
                    }
                    else
                    {
                        lvSaleRack.Focus();
                    }
                    if (lvSaleRack.Items.Count > 0)
                    {
                        lvSaleRack.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (lblSaleRackCode.Text != "0") { txtRackMOQQty.Focus(); }
                    else
                    {
                        if (pnlStatus.Enabled == true)
                        {
                            if (rbActive.Checked == true)
                            {
                                rbActive.Focus();
                            }
                            else
                            {
                                rbInActive.Focus();
                            }
                        }
                        else
                        {
                            btnSave.Focus();
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

        private void TxtSaleRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSaleRack.Text == "")
                {
                    txtRackDescriptionSales.Text = "";
                    txtRackMOQQty.Text = "";
                    txtSaleRack.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtSaleRack, "Please enter sales rack");
                    txtRackMOQQty.Enabled = false;
                }
                else
                {
                    if (Convert.ToString(lblSaleRackCode.Text) != "0")
                    {
                        txtRackMOQQty.Enabled = true;
                    }
                    txtSaleRack.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSaleRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSaleRackAutocomplete();

                    if (Convert.ToString(lblSaleRackCode.Text) != "0")
                    {
                        txtRackMOQQty.Enabled = true;
                    }
                    txtRackMOQQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSaleRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSaleRackAutocomplete();
                if (Convert.ToString(lblSaleRackCode.Text) != "0")
                {
                    txtRackMOQQty.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSubGroupAutocomplete();
                lvGroup.Visible = false;
                txtBrand.Focus();
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
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 1;
                    objMR_Product.ParaProductCode = varproductcode;
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objdserv.udfnproductmasterlist(objMR_Product);
                    objdserv.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            //cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["COMPANY"].ToString();//
                            varcompanyid = Convert.ToInt32(objDS.Tables[0].Rows[0]["COMPANY"].ToString());
                            //cmbConcern.Enabled = false;//
                            txtPICode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["PICODE"].ToString().Replace("''", "'"));
                            txtSalesPICode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["SalesPICODE"].ToString().Replace("''", "'"));
                            txtItemNameEnglish.Text = Convert.ToString(objDS.Tables[0].Rows[0]["ENAME"].ToString().Replace("''", "'"));
                            txtItemNameTamil.Text = Convert.ToString(objDS.Tables[0].Rows[0]["TNAME"].ToString().Replace("''", "'"));
                            txtLabelNameEnglish.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LENAME"].ToString().Replace("''", "'"));
                            txtLabelNameTamil.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LTNAME"].ToString().Replace("''", "'"));
                            cmbProductCategory.SelectedValue = objDS.Tables[0].Rows[0]["PRODUCTCATEGORY"].ToString();
                            varSubGroupId = Convert.ToInt32(objDS.Tables[0].Rows[0]["SUBGROUP"].ToString());
                            lblSubGroupCode.Text = objDS.Tables[0].Rows[0]["SUBGROUP"].ToString();
                            txtSubGroup.Text = objDS.Tables[0].Rows[0]["SubGroup Name"].ToString();
                            txtSubgroupType.Text = objDS.Tables[0].Rows[0]["SubgroupType"].ToString();
                            //CmbSubGroup_SelectedIndexChanged(cmbSubGroup, EventArgs.Empty);
                            varGroupId = Convert.ToInt32(objDS.Tables[0].Rows[0]["GROUP"].ToString());
                            lblGroupCode.Text = objDS.Tables[0].Rows[0]["GROUP"].ToString();
                            txtGroup.Text = objDS.Tables[0].Rows[0]["Group Name"].ToString();
                            varBrandId = Convert.ToInt32(objDS.Tables[0].Rows[0]["BRAND"].ToString());
                            lblBrand.Text = objDS.Tables[0].Rows[0]["BRAND"].ToString();
                            txtBrand.Text = objDS.Tables[0].Rows[0]["BRAND Name"].ToString();
                            varUnitid = Convert.ToInt32(objDS.Tables[0].Rows[0]["UNIT"].ToString());//
                            //cmbUnit.SelectedValue = objDS.Tables[0].Rows[0]["UNIT"].ToString();//
                            //cmbChildUnit.SelectedValue = objDS.Tables[0].Rows[0]["BULK UNIT"].ToString();//
                            varPURSLID = Convert.ToInt32(objDS.Tables[0].Rows[0]["LOCATION PURCHASE"]);
                            lblPurLocationCode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION PURCHASE"]);
                            txtPurLocation.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION PURCHASE Name"]);
                            varSALESLID = Convert.ToInt32(objDS.Tables[0].Rows[0]["LOCATION SALES"]);
                            lblSaleLocationCode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION SALES"]);
                            txtSaleLocation.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION SALES Name"]);
                            varPURRKID = Convert.ToInt32(objDS.Tables[0].Rows[0]["RACK LOCATION"].ToString());
                            lblPurRackCode.Text = objDS.Tables[0].Rows[0]["RACK LOCATION"].ToString();
                            txtPurRack.Text = objDS.Tables[0].Rows[0]["RACK LOCATION Name"].ToString();
                            txtRackDescription.Text = objDS.Tables[0].Rows[0]["Rack_Description"].ToString();
                            varSALERKID = Convert.ToInt32(objDS.Tables[0].Rows[0]["RACK SALES"].ToString());
                            lblSaleRackCode.Text = objDS.Tables[0].Rows[0]["RACK SALES"].ToString();
                            txtSaleRack.Text = objDS.Tables[0].Rows[0]["RACK SALES Name"].ToString();
                            txtRackDescriptionSales.Text = objDS.Tables[0].Rows[0]["Sales_Rack_Description"].ToString();
                            txtTeller.Text = Convert.ToString(objDS.Tables[0].Rows[0]["PR_Inactive_Teller"]);
                            pbProHSNID = Convert.ToInt32(objDS.Tables[0].Rows[0]["HSN"]);
                            pbSalesHSNID = Convert.ToInt32(objDS.Tables[0].Rows[0]["SalesHSN"]);
                            lvVerified1.Visible = false;
                            if (pbCloneFlag == 0)
                            {
                                txtUpp.Text = Convert.ToString(objDS.Tables[0].Rows[0]["UPP"].ToString().Replace("''", "'"));
                                txtRackMOQQty.Text = Convert.ToString(objDS.Tables[0].Rows[0]["RACK MOQ"].ToString().Replace("''", "'"));
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
                            }
                            else
                            {
                                txtUpp.Text = "";
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
                            }
                            cmbBatchNoEntry.SelectedValue = objDS.Tables[0].Rows[0]["BATCHNO"].ToString();
                            cmbBatchNoGeneration.SelectedValue = objDS.Tables[0].Rows[0]["BARCODE GENERATION"].ToString();
                            cmbPeriod.SelectedValue = objDS.Tables[0].Rows[0]["SHELF LIFE TYPE"].ToString();
                            txtSelfLife.Text = Convert.ToString(objDS.Tables[0].Rows[0]["SHELFLIFE VALUE"].ToString().Replace("''", "'"));
                            cmbGst.SelectedValue = Convert.ToInt32(objDS.Tables[0].Rows[0]["GSTID"]);
                            varHsnId = Convert.ToInt32(objDS.Tables[0].Rows[0]["HSN"].ToString());
                            lblHsnName.Text = objDS.Tables[0].Rows[0]["HSN"].ToString();
                            txtHsnName.Text = Convert.ToString(objDS.Tables[0].Rows[0]["HSN_Name"].ToString().Replace("''", "'"));
                            txtHSNCode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["HSN_Code"].ToString().Replace("''", "'"));
                            cmbNetQty.SelectedValue = objDS.Tables[0].Rows[0]["PR_QUTID"].ToString();
                            varStatusID = Convert.ToInt16(objDS.Tables[0].Rows[0]["STS"]);
                            lvHsnCode.Visible = false;

                            if (Convert.ToString(objDS.Tables[0].Rows[0]["SHELFLIFE"]) == "1") { cbExpiry.Checked = true; } else { cbExpiry.Checked = false; }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["PR_MRPflag"]) == "1") { chkMRP.Checked = true; } else { chkMRP.Checked = false; }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["RM PRODUCTION"]) == "1") { cmbRM.SelectedValue = 241; } else { cmbRM.SelectedValue = 240; }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "1")
                            {
                                rbActive.Checked = true;
                                pnlStatus.Enabled = true;
                                varStatusFlag = 0;
                            }
                            else if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "71" || Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "120")
                            {
                                pnlStatus.Enabled = false;
                                varStatusFlag = 0;
                            }
                            else
                            {
                                rbInActive.Checked = true;
                                pnlStatus.Enabled = true;
                                varStatusFlag = 1;
                            }
                            if (varStatusFlag == 0)
                            {
                                txtTeller.Enabled = false; txtTeller.ReadOnly = true;
                            }
                            else
                            {
                                txtTeller.Enabled = true; txtTeller.ReadOnly = false;
                            }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "1"
                                || Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "2" || Convert.ToString(objDS.Tables[0].Rows[0]["STS"]) == "71")
                            {
                                cbCompleted.Checked = true;
                                cbCompleted.Enabled = false;
                            }
                            else
                            {
                                cbCompleted.Checked = false;
                                cbCompleted.Enabled = true;
                            }
                            if ((txtPurLocation.Text == txtSaleLocation.Text) && (txtSaleRack.Text == txtPurRack.Text) && (txtRackDescription.Text == txtRackDescriptionSales.Text))
                            {
                                chkSameasPurchase.Checked = true;
                            }
                            else
                            {
                                chkSameasPurchase.Checked = false;
                            }
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["SalesProduct"]) == "1") { chkSalesProduct.Checked = true; } else { chkSalesProduct.Checked = false; }

                            udfnDropDownload();

                            //txtUpp.Text = Convert.ToString(objDS.Tables[0].Rows[0]["UPP"].ToString().Replace("''", "'"));

                            //objDS = objdservice.GetDataset("SELECT HSN_Code,GST_Value FROM MR_HSN INNER JOIN DEF_GST ON HSN_GSTID=GSTID WHERE HSNID  IN ('" + Convert.ToInt32(objDS.Tables[0].Rows[0]["HSN"].ToString()) + "') AND GSTID  NOT IN (0,-1)");
                            //objdservice.CloseConnection();
                            //if (objDS != null)
                            //{
                            //    if (objDS.Tables.Count > 0)
                            //    {
                            //        if (objDS.Tables[0].Rows.Count > 0)
                            //        {
                            //            txtHSNCode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["HSN_Code"]);
                            //            txtGST.Text = Convert.ToString(objDS.Tables[0].Rows[0]["GST_Value"]);
                            //        }
                            //    }
                            //}
                            if (objDS.Tables[0].Rows[0]["ParentId"].ToString() == "0")
                            {
                                cmbProductType.Text = "Parent";
                                txtProductName.Text = "";
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                                txtUpp.Text = "";
                                cmbChildUnit.SelectedIndex = 0;
                                lblParentcode.Text = "0";
                            }
                            else
                            {
                                cmbProductType.Text = "Child";
                                txtProductName.Text = objDS.Tables[0].Rows[0]["ParentName"].ToString();
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                                lblParentcode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["ParentId"]);

                            }
                            cmbUnit.SelectedValue = objDS.Tables[0].Rows[0]["UNIT"].ToString();
                            cmbChildUnit.SelectedValue = objDS.Tables[0].Rows[0]["CHILD UNIT"].ToString();
                            cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["COMPANY"].ToString();
                            cmbConcern.Enabled = false;



                            txtIntermediateUPP.Text = Convert.ToString(objDS.Tables[0].Rows[0]["IntermediateUPP"].ToString());
                            cmbIntermediateUnit.SelectedValue = Convert.ToInt32(objDS.Tables[0].Rows[0]["IntermediateUnit"].ToString());
                            txtProductionMSQ.Text = Convert.ToString(objDS.Tables[0].Rows[0]["ProductionMSQ"].ToString());


                            cmbIntermediateUnit.SelectedValue = Convert.ToInt32(objDS.Tables[0].Rows[0]["IntermediateUnit"].ToString());
                            cmbStockTakken.SelectedValue = Convert.ToInt32(objDS.Tables[0].Rows[0]["PR_Stk_Type"].ToString());

                            int FocusFlag = Convert.ToInt32(objDS.Tables[0].Rows[0]["PR_Focus_Flag"].ToString())
                                , Priority_Flag = Convert.ToInt32(objDS.Tables[0].Rows[0]["PR_Priority_Flag"].ToString())
                                , Spl_Flag = Convert.ToInt32(objDS.Tables[0].Rows[0]["PR_Spl_Flag"].ToString())
                                , OwnFlag = Convert.ToInt32(objDS.Tables[0].Rows[0]["PR_OwnFlag"].ToString());



                            if (FocusFlag == 1)
                            {
                                chkFocus.Checked = true;
                            }
                            if (Priority_Flag == 1)
                            {
                                chkPrioirty.Checked = true;
                            }
                            if (Spl_Flag == 1)
                            {
                                chkSpl.Checked = true;
                            }
                            if (OwnFlag == 1)
                            {
                                chkOwn.Checked = true;
                            }



                            btnSave.Text = "Update";
                            //pnlStatus.Enabled = true;
                            if (Convert.ToString(lblSaleRackCode.Text) != "0")
                            {
                                txtRackMOQQty.Enabled = true;
                            }
                            else
                            {
                                txtRackMOQQty.Enabled = false;
                            }
                        }
                        if (objDS.Tables[1] != null)
                        {
                            if (objDS.Tables.Count > 1 && objDS.Tables[1].Rows.Count > 0)
                            {
                                grdPurHSN.Rows.Clear();
                                grdSalesHSN.Rows.Clear();
                                dtPurHSN.Rows.Clear();
                                dtSalesHSN.Rows.Clear();
                                dtProductHSN.Rows.Clear();
                                DataTable dtHSN = objDS.Tables[1];
                                foreach (DataRow dr in dtHSN.Rows)
                                {
                                    int varHsnType = Convert.ToInt32(dr["PRHSN_Type"]);
                                    string varHsnName = dr["HSN_Name"]?.ToString().Trim();
                                    string varHsnCode = dr["HSN_Code"]?.ToString().Trim();
                                    string varGstText = dr["GST_Text"]?.ToString().Trim();
                                    string varEffectiveFrom = dr["PRHSN_EffectiveFrom"]?.ToString().Trim();
                                    string varEffectiveTo = dr["PRHSN_EffectiveTo"]?.ToString().Trim();
                                    int varHSNID = Convert.ToInt32(dr["PRHSN_HSNID"]);
                                    int varAddFlag = Convert.ToInt32(dr["AddFlag"]);
                                    int varEditFlag = Convert.ToInt32(dr["EditFlag"]);
                                    string changedDate = DateTime.TryParse(dr["PRHSN_ChangedDate"]?.ToString(), out DateTime dt) ? dt.ToString("yyyy-MM-dd HH:mm:ss.fff") : string.Empty;


                                    int userID = Convert.ToInt32(dr["PRHSN_MakerID"]);

                                    // Add row to Purchase Grid (Type = 1)
                                    if (varHsnType == 1)
                                    {
                                        grdPurHSN.Rows.Add(varHsnName, varHsnCode, varGstText, varEffectiveFrom, varEffectiveTo, varHSNID, varAddFlag, varEditFlag, changedDate, userID);
                                        dtPurHSN.Rows.Add(1, varHSNID, varEffectiveFrom, varEffectiveTo, changedDate, userID);
                                    }
                                    // Add row to Sales Grid (Type = 2)
                                    else if (varHsnType == 2)
                                    {
                                        grdSalesHSN.Rows.Add(varHsnName, varHsnCode, varGstText, varEffectiveFrom, varEffectiveTo, varHSNID, varAddFlag, varEditFlag, changedDate, userID);
                                        dtSalesHSN.Rows.Add(2, varHSNID, varEffectiveFrom, varEffectiveTo, changedDate, userID);
                                    }
                                    dtProductHSN.Rows.Add(varHsnType, varHSNID, varEffectiveFrom, varEffectiveTo, changedDate);
                                }
                                grdPurHSN.ClearSelection();
                                grdSalesHSN.ClearSelection();

                                grdPurHSN.Columns["clmPurGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdSalesHSN.Columns["clmSalesGST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                //Reset flag and Hide Remove Icon For Purchase HSN
                                udfnUpdateRemovableFlags();
                                udfnPurHideRemove();
                                //Reset flag and Hide Remove Icon For Sales HSN
                                udfnUpdateSalesRemovableFlags();
                                udfnSalesHideRemove();
                                //udfnSetPurMinDate();
                                //udfnSetSalesMinDate();
                            }
                        }
                        if (objDS.Tables[2].Rows.Count > 0)
                        {
                            udfnBindImages(objDS.Tables[2]);
                        }
                    }
                }
                if (varproductcode != 0)
                {
                    if (pnlStatus.Enabled == true)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 57;
                        objMR_Product.ParaProductCode = varproductcode;
                        SPDataService objspservice = new SPDataService();
                        DataSet objDS;
                        objDS = objdserv.udfnproductmasterlist(objMR_Product);
                        objdserv.CloseConnection();
                        if (objDS != null)
                        {
                            int PO_Status = 0;
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                PO_Status = Convert.ToInt32(objDS.Tables[0].Rows[0]["PO_CurrentSTSID"].ToString());
                                if (PO_Status == 12)
                                {
                                    pnlStatus.Enabled = false;
                                }
                                else
                                {
                                    pnlStatus.Enabled = true;
                                }
                            }
                        }
                    }
                }
                //if (pbFormStatus == 2 && pbCloneFlag == 0)
                if (varStatusID == 71)
                {
                    udfnDisable();
                }
                if (varProductload == 0)
                {
                    txtPurRack.Enabled = true;
                    txtPurLocation.Enabled = true;
                }
                //if (pbFormStatus == 1)
                //{
                //    cmbProductCategory.Enabled = false;
                //    cmbProductType.Enabled = false;
                //    txtProductName.Enabled = false;
                //    cmbChildUnit.Enabled = false; 
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvGroup.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvSaleRack.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
            }
        }
        public void udfnDisable()
        {
            grbform.Enabled = false;
            grplocation.Enabled = false;
            grbSalesStockLocation.Enabled = false;
            grbBatchNoDetails.Enabled = false;
            gpClassification.Enabled = false;
            rbActive.Enabled = false;
            grpExpire.Enabled = false;
            grpHsndetail.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            grbPurchaseHSN.Enabled = false;
            grbSalesHSN.Enabled = false;
            grbIntermediateDetails.Enabled = false;
            grpstktake.Enabled = false;
            tsMenu.Enabled = false;
            flowLayoutPanel1.Enabled = false;
            btnImageUpdate.Enabled = false;
            pictureBox1.Enabled = false;
            this.ActiveControl = rbInActive;
        }
        public void udfnBindImages(DataTable objdt)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear(); // Remove all controls
                imagePaths.Clear(); // Clear the stored paths
                pictureBox1.Image = null;
                if (objdt.Rows.Count > 0)
                {
                    for (int i = 0; i < objdt.Rows.Count; i++)
                    {
                        string varImageName = Convert.ToString(objdt.Rows[i]["image_name"]);
                        imagePaths.Add(varImageName);
                        AddImageToPanel(varImageName);
                        if (imagePaths.Count == 1)
                        {
                            ZoomImage(varImageName);
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
                //udfnDropDownload();
                lblSubGroupCode.Text = Convert.ToString(varSubgroupCode);
                txtSubGroup.Text = varSubGroupName;
                txtSubgroupType.Text = varSubgroupType;
                txtGroup.Text = varGroupName;
                lblGroupCode.Text = Convert.ToString(varGroupCode);
                lblPurLocationCode.Text = Convert.ToString(varPURSLID);
                lblSaleLocationCode.Text = Convert.ToString(varSALESLID);
                lblPurRackCode.Text = Convert.ToString(varPURRKID);
                // lblPurRackCode.Text = Convert.ToString(varPURRKID);
                lblSaleRackCode.Text = Convert.ToString("0");
                txtSaleLocation.Text = "";
                txtPurLocation.Text = varPurchaseLocation;
                // txtSaleRack.Text = varSalesRack;
                txtPurRack.Text = varPurchaseRack;
                txtRackDescription.Text = varRackDescription;
                //if (varBatchCode == 72)
                //{
                //    cmbBatchNoEntry.SelectedValue = 72;
                //}
                //else
                //{
                //    cmbBatchNoEntry.SelectedValue = 73;
                //}
                if (Convert.ToString(lblPurRackCode.Text) == "0")
                {
                    txtPurRack.Text = "None";
                    txtPurRack.BackColor = Color.White;
                    txtPurRack.Enabled = false;
                }
                txtSubGroup.Focus();
                lvGroup.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSubGroup.Visible = false;
                lvGroup.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                DGV_FilterSalesLocation.DataSource = null;
                DGV_FilterSalesLocation.Visible = false;
                lvPurRack.Visible = false;
                lvSaleRack.Visible = false;
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
                //  udfnDropDownload();
                lblGroupCode.Text = Convert.ToString(varGroupCode);
                txtGroup.Text = varGroupName;
                txtGroup.Focus();
                if (varGroupCode != 0)
                {
                    // cmbSubGroup.SelectedValue = -1;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally { lvGroup.Visible = false; }
        }

        private void BtnBrand_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGroup.Text != "" && txtSubGroup.Text != "")
                {
                    MainForm.objCP_Brand = new CP_Brand();
                    MainForm.objCP_Brand.MinimizeBox = false;
                    MainForm.objCP_Brand.MaximizeBox = false;
                    if (MainForm.objCP_Brand.FormBorderStyle == FormBorderStyle.None)
                    {
                        MainForm.objCP_Brand.FormBorderStyle = FormBorderStyle.FixedSingle;
                    }
                    /* Check product group is valid or not*/
                    string varId_Group = "0";
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(), 0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varId_Group = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                        varGroupName = txtGroup.Text.Trim();
                    }
                    if (varId_Group == "-1")
                    {
                        vargroupId = "0";
                    }
                    else
                    {
                        vargroupId = varId_Group;
                    }
                    /* Check product sub group is valid or not*/
                    string varId_SubGroup = "0";
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varId_SubGroup = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                        varSubGroupName = txtSubGroup.Text.Trim();
                    }
                    if (varId_SubGroup == "-1")
                    {
                        varSubgroupId = "0";
                    }
                    else
                    {
                        varSubgroupId = varId_SubGroup;
                    }

                    // varSubgroupId = lblSubGroupCode.Text;
                    MainForm.objCP_Brand.varmastertype = 1;
                    MainForm.objCP_Brand.ShowDialog();
                    if (btnSave.Text == "Save")
                    {
                        lblBrand.Text = Convert.ToString(varbrandcode);
                        txtBrand.Text = varBrandName;
                    }
                    else
                    {
                        if (varbrandcode != 0)
                        {
                            lblBrand.Text = Convert.ToString(varbrandcode);
                            txtBrand.Text = varBrandName;
                        }
                        else
                        {
                            lblBrand.Text = Convert.ToString(varbrandcode);
                            txtBrand.Text = varBrandName;
                        }
                    }
                    txtBrand.Focus();
                    lvBrand.Visible = false;
                }
                else
                {
                    if (txtSubGroup.Text == "")
                    {
                        txtSubGroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errItems.SetError(txtSubGroup, "Please select subgroup");
                    }
                    //else
                    //{
                    //    txtSubGroup.BackColor = Color.White;
                    //    errItems.Clear();
                    //}
                    if (txtGroup.Text == "")
                    {
                        txtGroup.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errItems.SetError(txtGroup, "Please select group");
                    }
                    //else
                    //{
                    //    txtGroup.BackColor = Color.White;
                    //    errItems.Clear();
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { varSubgroupId = ""; }
        }

        private void BtnUnit_Click(object sender, EventArgs e)
        {
            try
            {
                varUnitCode = 0;
                MainForm.objCP_Unit = new CP_Unit();
                MainForm.objCP_Unit.FormBorderStyle = FormBorderStyle.FixedSingle;
                MainForm.objCP_Unit.varmastertype = 1;
                MainForm.objCP_Unit.ShowDialog();
                //  udfnDropDownload();
                udfnUnitLoad();
                cmbUnit.SelectedValue = Convert.ToInt16(varUnitCode);
                cmbChildUnit.SelectedValue = Convert.ToInt16(-1);
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
                if (txtSelfLife.Text == "")
                {
                    txtSelfLife.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    errItems.SetError(txtSelfLife, "Please enter shelf life");
                }
                else
                {
                    if (Convert.ToInt32(txtSelfLife.Text) == 0)
                    {
                        txtSelfLife.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errItems.SetError(txtSelfLife, "Please enter valid shelf life");
                    }
                    else
                    {
                        txtSelfLife.BackColor = Color.White;
                        errItems.Clear();
                    }
                }
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
                    varF5Flag = 1;
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
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                //if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                //{
                //    e.Handled = true;
                //}

                // Allow only one decimal point
                //if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                //{
                //    e.Handled = true;
                //}
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
                if (MainForm.varCloseFlag == 0)
                {
                    if (varupdate == "0")
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                pictureBox1.Image?.Dispose();
                                pictureBox1.Image = null;

                                originalImage?.Dispose();
                                originalImage = null;

                                foreach (var ei in editableImages)
                                {
                                    ei.Thumbnail.Image?.Dispose();
                                    ei.Thumbnail.Image = null;
                                }

                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                e.Cancel = false;
                            }
                            catch (Exception ex)
                            {
                                objError = new DataError();
                                objError.WriteFile(ex);
                            }
                        }
                        else
                        {
                            e.Cancel = true;
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
        public void udfnProductEvent()
        {
            try
            {
                if (txtProductName.Text.Trim() != "")
                {

                    lblParentcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                    if (lblParentcode.Text == "" || lblParentcode.Text == "")
                    {
                        MessageBox.Show("Invalid parent name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (btnSave.Text != "Update")
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 1;
                        objMR_Product.ParaProductCode = Convert.ToInt32(lblParentcode.Text);
                        SPDataService objdserv = new SPDataService();
                        DataSet objDS;
                        objDS = objdserv.udfnproductmasterlist(objMR_Product);
                        objdserv.CloseConnection();
                        txtPICode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["PICODE"].ToString().Replace("''", "'"));
                        txtItemNameEnglish.Text = Convert.ToString(objDS.Tables[0].Rows[0]["ENAME"].ToString().Replace("''", "'"));
                        txtItemNameTamil.Text = Convert.ToString(objDS.Tables[0].Rows[0]["TNAME"].ToString().Replace("''", "'"));
                        txtLabelNameEnglish.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LENAME"].ToString().Replace("''", "'"));
                        txtLabelNameTamil.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LTNAME"].ToString().Replace("''", "'"));
                        varSubGroupId = Convert.ToInt32(objDS.Tables[0].Rows[0]["SUBGROUP"].ToString());
                        lblSubGroupCode.Text = objDS.Tables[0].Rows[0]["SUBGROUP"].ToString();
                        txtSubGroup.Text = objDS.Tables[0].Rows[0]["SubGroup Name"].ToString();
                        varGroupId = Convert.ToInt32(objDS.Tables[0].Rows[0]["GROUP"].ToString());
                        lblGroupCode.Text = objDS.Tables[0].Rows[0]["GROUP"].ToString();
                        txtGroup.Text = objDS.Tables[0].Rows[0]["Group Name"].ToString();
                        varBrandId = Convert.ToInt32(objDS.Tables[0].Rows[0]["BRAND"].ToString());
                        lblBrand.Text = objDS.Tables[0].Rows[0]["BRAND"].ToString();
                        txtBrand.Text = objDS.Tables[0].Rows[0]["BRAND Name"].ToString();
                        varUnitid = Convert.ToInt32(objDS.Tables[0].Rows[0]["CHILD UNIT"].ToString());//
                        cmbChildUnit.SelectedValue = objDS.Tables[0].Rows[0]["UNIT"].ToString();
                        varPURSLID = Convert.ToInt32(objDS.Tables[0].Rows[0]["LOCATION PURCHASE"]);
                        lblPurLocationCode.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION PURCHASE"]);
                        txtPurLocation.Text = Convert.ToString(objDS.Tables[0].Rows[0]["LOCATION PURCHASE Name"]);
                        varPURRKID = Convert.ToInt32(objDS.Tables[0].Rows[0]["RACK LOCATION"].ToString());
                        lblPurRackCode.Text = objDS.Tables[0].Rows[0]["RACK LOCATION"].ToString();
                        txtPurRack.Text = objDS.Tables[0].Rows[0]["RACK LOCATION Name"].ToString();
                        txtRackDescription.Text = objDS.Tables[0].Rows[0]["Rack_Description"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvBrand.Visible = false;
                lvSubGroup.Visible = false;
                lvGroup.Visible = false;
                DGV_FilterPurLocation.DataSource = null;
                DGV_FilterPurLocation.Visible = false;
                lvPurRack.Visible = false;
            }
        }

        public void udfnPriceMarkup()
        {
            try
            {
                lblMarkupProd.Text =   txtItemNameTamil.Text.Trim();
                if (txtUpp.Text != "" && txtUpp.Text != "0")
                {
                    varuppValue = Convert.ToDecimal(txtUpp.Text);
                }
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                if (varproductcode != 0)
                {
                    int ApprovalFlag = 0;
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 87;
                    objMR_Product.ParaProductCode = varproductcode;
                    SPDataService objspservice = new SPDataService();
                    objDs = objdserv.udfnproductmasterlist(objMR_Product);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            udfnGridStatusBind();  // Bind datasource FIRST
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdPrice.Rows.Add();
                                int row = grdPrice.Rows.Count - 1;
                                grdPrice.Rows[row].Cells["clmTypeId"].Value = objDs.Tables[0].Rows[i]["TYPEID"].ToString();
                                grdPrice.Rows[row].Cells["clmType"].Value = objDs.Tables[0].Rows[i]["TYPE"].ToString();
                                grdPrice.Rows[row].Cells["clmRate"].Value = objDs.Tables[0].Rows[i]["PRPM_RATE"].ToString(); 
                                grdPrice.Rows[row].Cells["clmRate"].Value = objDs.Tables[0].Rows[i]["PRPM_RATE"].ToString();


                                if (Convert.ToString(objDs.Tables[0].Rows[i]["PRPM_STSID"]) == "453")
                                {
                                    grdPrice.Rows[row].Cells["chkColumn"].Value = true;
                                }
                                else
                                {
                                    grdPrice.Rows[row].Cells["chkColumn"].Value = false;
                                }

                                grdPrice.Rows[row].Cells["clmMinQty"].Value = objDs.Tables[0].Rows[i]["PRPM_MINQTY"]; 
                                grdPrice.Rows[row].Cells["clmOffset"].Value = objDs.Tables[0].Rows[i]["PRPM_OFFSET_STSID"];
                                grdPrice.Rows[row].Cells["clmOffsetValuePer"].Value = objDs.Tables[0].Rows[i]["PRPM_OFFSET_VALUE"];
                                grdPrice.Rows[row].Cells["clmOffsetValue"].Value = objDs.Tables[0].Rows[i]["PRPM_OFFSET_VALUE_AMT"];
                                grdPrice.Rows[row].Cells["clmBulkRate"].Value = Convert.ToDecimal(objDs.Tables[0].Rows[i]["PRPM_RATE"]) * varuppValue;

                            }

                            if (varuppValue == 0)
                            {
                                grdPrice.Columns["clmBulkRate"].Visible = false;
                            }
                            else
                            {
                                grdPrice.Columns["clmBulkRate"].Visible = true;
                            }
                            //grdPrice.Columns["clmStatus"].DisplayIndex = 2;
                            //grdPrice.Columns["clmOffset"].DisplayIndex = 4;


                        }
                        ApprovalFlag = Convert.ToInt32(objDs.Tables[1].Rows[0]["ApprovalFlag"]);
                        if (ApprovalFlag == 122)
                        {
                            grdPrice.Enabled = true;
                            btnSave.Enabled = true;
                        }
                        else
                        {
                            grdPrice.Enabled = false;
                            btnSave.Enabled = false;
                        }


                        if (varStatusID == 71)
                        {
                            grdPrice.Enabled = false;
                            btnSave.Enabled = false;
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
        public void udfnGridStatusBind()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                //**** To call the function from SP ***************
                MR_Status objMR_Status = new MR_Status();
                objMR_Status.ViewType = 3;
                objDT = objdserv.udfnGetStatus(objMR_Status);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            //var varComboBoxColoumn = (DataGridViewComboBoxColumn)grdPrice.Columns["clmStatus"];
                            //DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                            //varComboBoxColoumn.ValueMember = "ID";
                            //varComboBoxColoumn.DisplayMember = "Status";
                            //varComboBoxColoumn.DataSource = objDT.Tables[0];

                            var varComboBoxColoumn2 = (DataGridViewComboBoxColumn)grdPrice.Columns["clmOffset"];
                            DataGridViewComboBoxColumn comboBoxColumn2 = new DataGridViewComboBoxColumn();
                            varComboBoxColoumn2.ValueMember = "ID";
                            varComboBoxColoumn2.DisplayMember = "Status";
                            varComboBoxColoumn2.DataSource = objDT.Tables[0];
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
        private void udfnRateenable(int row)
        {
            try
            {
                var status = grdPrice.Rows[row].Cells["clmStatus"].Value?.ToString();
                var typeId = grdPrice.Rows[row].Cells["clmTypeId"].Value?.ToString();

                // If status = 453 → disable clmRate
                if (typeId != "446")
                {
                    if (status == "453")
                    {
                        grdPrice.Rows[row].Cells["clmRate"].ReadOnly = true;
                        grdPrice.Rows[row].Cells["clmRate"].Style.BackColor = Color.LightGray;

                        grdPrice.Rows[row].Cells["clmOffsetValuePer"].ReadOnly = false;
                        grdPrice.Rows[row].Cells["clmOffsetValuePer"].Style.BackColor = Color.PaleGreen;

                        grdPrice.Rows[row].Cells["clmOffsetValue"].ReadOnly = false;
                        grdPrice.Rows[row].Cells["clmOffsetValue"].Style.BackColor = Color.PaleGreen;

                        grdPrice.Rows[row].Cells["clmOffset"].Value = 453;
                    }
                    else
                    {
                        grdPrice.Rows[row].Cells["clmRate"].ReadOnly = false;
                        grdPrice.Rows[row].Cells["clmRate"].Style.BackColor = Color.PaleGreen;

                        grdPrice.Rows[row].Cells["clmOffset"].Value = 454;
                        grdPrice.Rows[row].Cells["clmOffsetValuePer"].ReadOnly = true;
                        grdPrice.Rows[row].Cells["clmOffsetValuePer"].Value = 0;
                        grdPrice.Rows[row].Cells["clmOffsetValuePer"].Style.BackColor = Color.LightGray;

                        grdPrice.Rows[row].Cells["clmOffsetValue"].ReadOnly = true;
                        grdPrice.Rows[row].Cells["clmOffsetValue"].Value = 0;
                        grdPrice.Rows[row].Cells["clmOffsetValue"].Style.BackColor = Color.LightGray;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void UpdateRate(int rowIndex)
        {
            try
            {
                // Get status of the row where user typed
                var status = grdPrice.Rows[rowIndex].Cells["clmStatus"].Value?.ToString();
                var typeId = grdPrice.Rows[rowIndex].Cells["clmTypeId"].Value?.ToString();

                //   453 displayvalue is yes
                // typeId = 446 is base rate
                if (status == "453" || typeId == "446")
                {
                    var newRate = grdPrice.Rows[rowIndex].Cells["clmRate"].Value;
                    // Apply new rate to ALL rows
                    foreach (DataGridViewRow row in grdPrice.Rows)
                    {
                        if (Convert.ToString(row.Cells["clmStatus"].Value) == "453")
                        {
                            row.Cells["clmRate"].Value = newRate;
                            UpdateRateWithGST(row.Index);

                            if (varuppValue != 0)
                            {
                                row.Cells["clmBulkRate"].Value = Convert.ToDecimal(row.Cells["clmRate"].Value) * varuppValue;

                            }
                        }
                    }
                }
                if (varuppValue != 0)
                {
                    grdPrice.Rows[rowIndex].Cells["clmBulkRate"].Value = Convert.ToDecimal(grdPrice.Rows[rowIndex].Cells["clmRate"].Value) * varuppValue;

                }


                //var newRate = grdPrice.Rows[rowIndex].Cells["clmRate"].Value;
                //// Apply new rate to ALL rows
                //foreach (DataGridViewRow row in grdPrice.Rows)
                //{

                //    // Get status of the row where user typed
                //    var status = row.Cells["clmStatus"].Value?.ToString();
                //    var typeId = row.Cells["clmTypeId"].Value?.ToString();
                //    if (status == "453" || typeId == "446")
                //    {
                //        if (Convert.ToString(row.Cells["clmStatus"].Value) == "453")
                //        {
                //            row.Cells["clmRate"].Value = newRate;
                //            UpdateRateWithGST(row.Index);
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void UpdateRateWithGST(int rowIndex)
        {
            try
            {
                // Only update all rows if status == 154



                double Rate = Convert.ToDouble(grdPrice.Rows[0].Cells["clmRate"].Value);
                double newGst = Convert.ToDouble(string.IsNullOrWhiteSpace(grdPrice.Rows[rowIndex].Cells["clmOffsetValuePer"].Value?.ToString())
                                ? "0" : grdPrice.Rows[rowIndex].Cells["clmOffsetValuePer"].Value);
                double NewRate = Rate * (newGst / 100);
                var status = grdPrice.Rows[rowIndex].Cells["clmoffset"].Value?.ToString();
                var mainstatus = grdPrice.Rows[rowIndex].Cells["clmstatus"].Value?.ToString();

                NewRate = Math.Round(NewRate, 0, MidpointRounding.AwayFromZero);
                Rate = Math.Round(Rate, 0, MidpointRounding.AwayFromZero);



                if (mainstatus == "453") //yes
                {
                    if (status == "454") //no
                    {
                        grdPrice.Rows[rowIndex].Cells["clmRate"].Value = Rate;
                    }
                    else
                    {
                        grdPrice.Rows[rowIndex].Cells["clmRate"].Value = Rate + NewRate;
                        grdPrice.Rows[rowIndex].Cells["clmOffsetValue"].Value = NewRate;

                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void UpdateRateWithGSTValue(int rowIndex)
        {
            try
            {
                // Only update all rows if status == 154


                double Rate = Convert.ToDouble(grdPrice.Rows[0].Cells["clmRate"].Value);
                double NewRate = Convert.ToDouble(string.IsNullOrWhiteSpace(grdPrice.Rows[rowIndex].Cells["clmOffsetValue"].Value?.ToString())
                                ? "0" : grdPrice.Rows[rowIndex].Cells["clmOffsetValue"].Value);
                var status = grdPrice.Rows[rowIndex].Cells["clmoffset"].Value?.ToString();
                var mainstatus = grdPrice.Rows[rowIndex].Cells["clmstatus"].Value?.ToString();

                double newGst = (NewRate / Rate) * 100;

                if (NewRate == 0 && Rate == 0)
                {
                    newGst = 0;
                }


                newGst = Math.Round(newGst, 2);

                if (mainstatus == "453") //yes
                {
                    if (status == "454") //no
                    {
                        grdPrice.Rows[rowIndex].Cells["clmRate"].Value = Rate;
                    }
                    else
                    {
                        grdPrice.Rows[rowIndex].Cells["clmRate"].Value = Rate + NewRate;
                        grdPrice.Rows[rowIndex].Cells["clmOffsetValuePer"].Value = newGst;

                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void RemoveRateWithGST(int rowIndex)
        {
            try
            {
                // Only update all rows if status == 154





                var status = grdPrice.Rows[rowIndex].Cells["clmoffset"].Value?.ToString();
                var mainstatus = grdPrice.Rows[rowIndex].Cells["clmStatus"].Value?.ToString();
                if (mainstatus == "453") //yes
                {
                    if (status == "454") //no
                    {
                        double Rate = Convert.ToDouble(grdPrice.Rows[0].Cells["clmRate"].Value);
                        grdPrice.Rows[rowIndex].Cells["clmRate"].Value = Rate;

                        grdPrice.Rows[rowIndex].Cells["clmOffsetValuePer"].ReadOnly = true;
                        grdPrice.Rows[rowIndex].Cells["clmOffsetValuePer"].Style.BackColor = Color.LightGray;
                        grdPrice.Rows[rowIndex].Cells["clmOffsetValue"].ReadOnly = true;
                        grdPrice.Rows[rowIndex].Cells["clmOffsetValue"].Style.BackColor = Color.LightGray;

                    }
                    else
                    {
                        ////selected value is yes  
                        UpdateRateWithGST(rowIndex);

                        grdPrice.Rows[rowIndex].Cells["clmOffsetValuePer"].ReadOnly = false;
                        grdPrice.Rows[rowIndex].Cells["clmOffsetValuePer"].Style.BackColor = Color.PaleGreen;
                        grdPrice.Rows[rowIndex].Cells["clmOffsetValue"].ReadOnly = false;
                        grdPrice.Rows[rowIndex].Cells["clmOffsetValue"].Style.BackColor = Color.PaleGreen;
                    }
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdPrice.CurrentCell.OwningColumn.Name == "clmOffsetValuePer" || grdPrice.CurrentCell.OwningColumn.Name == "clmOffsetValue" || grdPrice.CurrentCell.OwningColumn.Name == "clmMinQty" || grdPrice.CurrentCell.OwningColumn.Name == "clmRate")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                    {
                        e.Handled = true;
                    }
                    //only allow one decimal point
                    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    //if ((e.KeyChar == '.'))
                    {
                        e.Handled = true;
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


