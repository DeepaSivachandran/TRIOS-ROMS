using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class CP_ProductDetails : Form
    {
        DataValidation objvalidation = new DataValidation();
        DataError objError;

        public int varUpDownKeyProduct = 0, varUpDownKey=0;
        public int pbPrid = 0;

        private List<string> imagePaths = new List<string>();
        private int currentImageIndex = 0; 
        private bool _isLoadingImage = false;
        private readonly System.Windows.Forms.Timer _imageTimer =
    new System.Windows.Forms.Timer();


        //tool tip
        private ToolTip tpRRate = new ToolTip();
        private ToolTip tpWRate = new ToolTip();
        private ToolTip tpVerifier = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        public CP_ProductDetails()
        {
            InitializeComponent();
        }

        private void InitializeImageSlider()
        {
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;

            _imageTimer.Interval = 3000; // 3 seconds
            _imageTimer.Tick += ImageTimer_Tick;
        }
        private void LoadProductImages(DataTable dt)
        {
            imagePaths.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string imagePath = row["image_name"]?.ToString();

                if (!string.IsNullOrWhiteSpace(imagePath) &&
                    File.Exists(imagePath))
                {
                    imagePaths.Add(imagePath);
                }
            }

            currentImageIndex = 0;

            if (imagePaths.Count > 0)
            {
                ShowImage(currentImageIndex);

                if (imagePaths.Count > 1)
                    _imageTimer.Start();
                else
                    _imageTimer.Stop();
            }
            else
            {
                ClearProductImage();
            }
        }
        private async Task ShowImageAsync(string imagePath)
        {
            if (_isLoadingImage)
                return;

            _isLoadingImage = true;

            try
            {
                Image newImage = await Task.Run(() =>
                {
                    using (var fs = new FileStream( imagePath, FileMode.Open,  FileAccess.Read, FileShare.Read))
                    {
                        using (var tempImage = Image.FromStream(fs))
                        {
                            return new Bitmap(tempImage);
                        }
                    }
                });

                if (picProduct.InvokeRequired)
                {
                    picProduct.BeginInvoke(new Action(() =>
                    {
                        ReplacePicture(newImage);
                    }));
                }
                else
                {
                    ReplacePicture(newImage);
                }
            }
            catch
            {
                // Handle invalid/missing image if required
            }
            finally
            {
                _isLoadingImage = false;
            }
        }
        private void ReplacePicture(Image newImage)
        {
            Image oldImage = picProduct.Image;

            picProduct.Image = newImage;

            oldImage?.Dispose();
        }
        private void ClearProductImage()
        {
            Image oldImage = picProduct.Image;

            picProduct.Image = null;

            oldImage?.Dispose();
        }
        private void ShowImage(int index)
        {
            if (imagePaths.Count == 0)
                return;

            if (index < 0 || index >= imagePaths.Count)
                return;

            _ = ShowImageAsync(imagePaths[index]);
        }
        private async void ImageTimer_Tick(object sender, EventArgs e)
        {
            if (_isLoadingImage || imagePaths.Count <= 1)
                return;

            currentImageIndex++;

            if (currentImageIndex >= imagePaths.Count)
                currentImageIndex = 0;

            await ShowImageAsync(imagePaths[currentImageIndex]);
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
        private void btnNext_Click(object sender, EventArgs e)
        {
            _imageTimer.Stop();
            if (imagePaths.Count == 0)
                return;

            currentImageIndex++;

            if (currentImageIndex >= imagePaths.Count)
                currentImageIndex = 0;

            ShowCurrentImage(); 
        }
        private void ShowCurrentImage()
        {
            if (imagePaths.Count == 0)
            {
                picProduct.Image = null;
                return;
            }

            string imagePath = imagePaths[currentImageIndex];

            if (!File.Exists(imagePath))
                return;

            Image newImage;

            using (FileStream fs = new FileStream(
                imagePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read))
            {
                using (Image tempImage = Image.FromStream(fs))
                {
                    newImage = new Bitmap(tempImage);
                }
            }

            // Dispose previous image
            Image oldImage = picProduct.Image;

            picProduct.Image = newImage;
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;

            oldImage?.Dispose();
        }
        
        
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _imageTimer.Stop();
            if (imagePaths.Count == 0)
                return;

            currentImageIndex--;

            if (currentImageIndex < 0)
                currentImageIndex = imagePaths.Count - 1;

            ShowCurrentImage();
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
        public void udfnProductDetails()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 104;
                objMR_Product.ParaProductCode = Convert.ToInt32(pbPrid);
                objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblPICode.Text = "P.I Code : " + (Convert.ToString(objDs.Tables[0].Rows[0]["PR_PICode"]));
                            lblStatus.Text = "Status : "+ Convert.ToString(objDs.Tables[0].Rows[0]["Status"]);
                            lblRetailRateValue.Text =Convert.ToString(objDs.Tables[0].Rows[0]["ParentTname"]);

                            lblPICodeValue.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PR_PICode"]);
                            lblProductName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PR_TName"]);
                            lblUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            lblGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Group"]);
                            lblSubGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Subgroup"]);
                            lblCategory.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Category"]);
                            lblProductType.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product Type"]); 
                            lblHSN.Text = Convert.ToString(objDs.Tables[0].Rows[0]["HSN"]);
                            lblTax.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Tax"]);
                            lblShelflife.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Shelf Life"]);  
                            lblBulk.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Bulk"]);  
                            lblProductScheme.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product Scheme Eligible"]);
                            lblBillScheme.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Bill Scheme Eligible"]); 
                            lblFocus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Focus"]);
                            lblPriority.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Priority"]);
                            lblSpecial.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Special"]);
                            lblOwn.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Own"]);
                             
                            lblStock.Text = Convert.ToString(objDs.Tables[0].Rows[0]["StockValue"]);
                            lblBarcode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Barcode"]);
                            lblRetailRate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RetailRate"]);  
                            lblPurLocation.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Pur_Location"]);
                            lblPurRack.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Pur_Rack"]);
                            lblSalesLocation.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Sales_Location"]);
                            lblRackGroup.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Rackgroup"]);
                            lblUpp.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UPP"]);
                             
                            lblInfoStatus.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Status"]);
                            lblProductUnitsTitle.Text = Convert.ToString(objDs.Tables[0].Rows[0]["ChildProdutType"]);
                        }
                        if (objDs.Tables.Count > 1)
                        {
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                grdSupplierList.DataSource = objDs.Tables[1];
                                grdSupplierList.Columns["S.No."].Width = 50; 
                                grdSupplierList.ClearSelection();
                                if (grdStock.Rows.Count != 0)
                                { lblSupplierNorecord.Visible = false;

                                    grdSupplierList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                }
                                else
                                { lblSupplierNorecord.Visible = true; }
                            }
                        }
                        if (objDs.Tables.Count > 2)
                        {
                            grdItemList.DataSource = objDs.Tables[2];
                            grdItemList.Columns["S.No."].Width = 50;
                            grdItemList.Columns["Product"].Width = 400;
                            grdItemList.Columns["Product"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                            
                            grdItemList.ClearSelection(); 
                            if(grdItemList.Rows.Count!=0)
                            { lblNoProductUnits.Visible = false;
                                grdSupplierList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else
                            { lblNoProductUnits.Visible = true; }
                        }
                        if (objDs.Tables.Count > 3)
                        {
                            lblTotalProduct.Text = Convert.ToString(objDs.Tables[3].Rows[0]["TotalProCount"]); 
                        }
                        if (objDs.Tables.Count > 4)
                        {
                            lblActiveProduct.Text = Convert.ToString(objDs.Tables[4].Rows[0]["ActiveProCount"]);
                        }
                        if (objDs.Tables.Count > 5)
                        {
                            lblInactiveIProduct.Text = Convert.ToString(objDs.Tables[5].Rows[0]["InactiveProCount"]);
                        }
                        if (objDs.Tables.Count > 6)
                        {
                            grdStock.DataSource = objDs.Tables[6];
                            grdStock.Columns["S.No."].Width = 50;
                            grdStock.Columns["Stock"].Width = 70;
                            grdStock.Columns["Location"].Width = 150; 
                           
                            grdStock.ClearSelection();
                            if (grdStock.Rows.Count != 0)
                            { lblstkNorecord.Visible = false;
                                grdStock.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else
                            { lblstkNorecord.Visible = true; }
                        }
                        if (objDs.Tables.Count > 7)
                        {
                            grdRateTypeList.DataSource = objDs.Tables[7];
                            grdRateTypeList.Columns["S.No."].Width = 50;
                            grdRateTypeList.Columns["Rate Type"].Width = 100; 
                            
                            grdRateTypeList.ClearSelection();
                            if (grdRateTypeList.Rows.Count != 0)
                            { lblRateNoRecord.Visible = false;
                                grdRateTypeList.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            else
                            { lblRateNoRecord.Visible = true; }
                        }   
                        if (objDs.Tables.Count > 9)
                        {
                            DataTable dt = objDs.Tables[9];
                            if (dt.Rows.Count != 0)
                            {
                                LoadProductImages(dt);
                                InitializeImageSlider();
                                if (dt.Rows.Count > 1)
                                {
                                    btnNext.Visible = true;
                                    btnPrevious.Visible = true;
                                }
                            }
                            else 
                            {
                                btnNext.Visible = false;
                                btnPrevious.Visible = false;
                            }
                        }
                        if (objDs.Tables.Count > 10)
                        {
                            lblDraftProCount.Text = Convert.ToString(objDs.Tables[10].Rows[0]["DraftProCount"]);
                        }
                        if (objDs.Tables.Count > 11)
                        {
                            lblRackIncharge.Text = Convert.ToString(objDs.Tables[11].Rows[0]["EMP_Name"]);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(pbPrid!=0)
            {
                udfnProductDetails();
            }

        }
        public void udfnProductClear()
        {
            try
            {
                lblPICode.Text = "";
                lblUnit.Text = "";
                lblGroup.Text = "";
                lblSubGroup.Text = "";
                lblCategory.Text = "";
                lblProductType.Text = "";
                lblPurLocation.Text = "";
                lblPurRack.Text = "";
                lblSalesLocation.Text = "";
                lblRackGroup.Text = "";
                lblUpp.Text = "";
                lblHSN.Text = "";
                lblTax.Text = "";
                lblShelflife.Text = "";
                lblShelflife.Text = "";
                lblStock.Text = "";
                lblBulk.Text = "";
                lblBarcode.Text = "";
                lblStatus.Text = "";
                lblRetailRate.Text = ""; 
                lblProductScheme.Text = "";
                lblBillScheme.Text = "";
                lblRetailRateValue.Text = "";
                lblFocus.Text = "";
                lblPriority.Text = "";
                lblSpecial.Text = "";
                lblOwn.Text = "";
                lblPICodeValue.Text = "";
                lblProductName.Text = "";
                txtSearch.Text = "";
                lblRackIncharge.Text = "";
                lblInfoStatus.Text = "";
                pbPrid = 0;
                grdStock.DataSource = null;
                grdItemList.DataSource = null;
                grdRateTypeList.DataSource = null;
                grdSupplierList.DataSource = null;
                btnNext.Visible = false;
                btnPrevious.Visible = false;
                _imageTimer.Stop(); 
                // Clear image list
                imagePaths.Clear(); 
                // Reset index
                currentImageIndex = 0; 
                // Clear PictureBox
                if (picProduct.Image != null)
                {
                    picProduct.Image.Dispose();
                    picProduct.Image = null;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Trim() == "")
                {
                    pbPrid = 0;
                    grdItemList.DataSource = null;
                    grdSupplierList.DataSource = null;
                    udfnProductClear();
                }
                if (varUpDownKey == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtSearch.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 49;
                        objMR_Product.paraProductName = txtSearch.Text;
                        objMR_Product.paraFlag = 1;                         //Load Only Eligible for Sales Products
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "P.I Code";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 100;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50;
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 0;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                     
                                    DGV_FilterProduct.BringToFront();
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

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyProduct = 1;
                udfnListviewProduct();
                btnSearch.Focus();
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
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtSearch.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtSearch.Focus();
                            txtSearch.SelectionStart = txtSearch.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtSearch.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtSearch.Focus();
                            txtSearch.SelectionStart = txtSearch.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                    btnSearch.Focus();
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
                if (txtSearch.Text.Trim() != "")
                {
                    pbPrid = Convert.ToInt16(DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value);
                    txtSearch.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    DGV_FilterProduct.Visible = false;
                    btnSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearch.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    errItems.SetError(txtSearch, "Please enter valid product");
                    txtSearch.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter valid product", txtSearch, 5000);
                }
                else
                {
                    txtSearch.BackColor = Color.White;
                    errItems.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up  )
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
                    if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                    {
                        btnSearch.Focus();
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSearch.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }
                            txtSearch.Focus();
                            txtSearch.SelectionStart = txtSearch.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtSearch.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            } 
                            txtSearch.Focus(); 
                            txtSearch.SelectionStart = txtSearch.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSearch.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            udfnProductClear();
        }

        private void label27_Click(object sender, EventArgs e)
        {

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


    