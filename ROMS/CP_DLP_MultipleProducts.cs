using CrystalDecisions.Shared;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace ROMS
{
    //Author : Sathish
    //Created On : 20-02-2025
    public partial class CP_DLP_MultipleProducts : Form
    {
        //DynamicWindowControl windowControl = new DynamicWindowControl();

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtProduct = new DataTable();
        DataTable dtGrid = new DataTable();
        public static string varFGCode;
        public int varStickerType;
        private ToolTip tpTemplate = new ToolTip();
        private ToolTip tpType = new ToolTip();
        private ToolTip tpLabelSize = new ToolTip();
        private ToolTip tpLabelCount = new ToolTip();
        private ToolTip tpProdtctname = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpSalesRate = new ToolTip();
        private ToolTip tpTitle = new ToolTip();
        Boolean BlnSearchImageYN = false;

        public int varUpDownKey = 0;
        public bool VarSearchFlag = true;
        public int varClose = 0;

        public int pbLPID = 0, varErrorFlag = 0;
        public string varDirectLablPrintId = "0";
        public CP_DLP_MultipleProducts()
        {
            InitializeComponent();
            //windowControl.Initialize(tsDirectLabelPrint, this);
        }

        private void PROD_LabelPrinting_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbType_Enter(object sender, EventArgs e)
        {

        }

        private void CmbType_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CmbType_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void CmbType_Leave(object sender, EventArgs e)
        {

        }

        private void CmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbCompany_Enter(object sender, EventArgs e)
        {

        }

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void CmbCompany_Leave(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void BtnView_Enter(object sender, EventArgs e)
        {

        }

        private void BtnView_Leave(object sender, EventArgs e)
        {

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
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblDProduct.Text = "Search by P.I Code (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblDProduct.Text = "Search by Product Name (F11)";
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                }

                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    //btnConditions.Focus();
                    cmbPrintLanguage.Focus();
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
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
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
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
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
                        cmbPrintLanguage.Focus();
                    }
                }
            }
            catch (Exception ex) {
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
                        objMR_Product.paraViewType = 51;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(0);
                        objMR_Product.paraProductName = txtProductName.Text;
                        objMR_Product.paraProductName = "";
                        objMR_Product.paraPicode = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        if (VarSearchFlag == false)
                        {
                            objMR_Product.paraProductName = txtProductName.Text.Trim();
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraPicode = txtProductName.Text.Trim();
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                         
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
                                    DGV_FilterProduct.Columns["Retail Rate"].Visible = true;
                                    


                                    if (VarSearchFlag == false)
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2; 
                                    }
                                    else
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 2; 
                                    }

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
                txtProductName.Focus();
                lblPICode.Text = "";
                lblProductName.Text = "";
                lblUnit.Text = "";
                lblRetail.Text = "";
                lblWholesale.Text = "";
                txtLabelProduct.Text = "";
                txtMrp.Text = "";
                txtSalesRate.Text = "";
                txtNoofcopy.Text = "";
                cmbPrintLanguage.SelectedValue = 322;
            }
        }

        private void CP_DiectLabelPrint_Load(object sender, EventArgs e)
        {
            try
            {
                udfnDropdownLoad();
                lblPICode.Text = "";
                lblProductName.Text = "";
                lblUnit.Text = "";
                lblRetail.Text = "";
                lblWholesale.Text = "";
                if (pbLPID != 0)
                {
                    varDirectLablPrintId = Convert.ToString(pbLPID);
                    udfnEdit();
                    this.ActiveControl = txtProductName;
                }
                else
                {
                    this.ActiveControl = cmbPrintType;
                }
                lblTotalMappingProduct.Text = Convert.ToString(grdPrintProuducts.RowCount);
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
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                if (pbLPID != 0)
                {
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 1;
                    objMR_Product.paraDirectPrintId = pbLPID;
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objdserv.udfnLabelPrintList(objMR_Product);
                    objdserv.CloseConnection();
                    if (objDS != null && objDS.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = objDS.Tables[0];

                        /* HEADER BINDING (FIRST ROW) */

                        cmbPrintLanguage.SelectedValue = Convert.ToInt32(dt.Rows[0]["LanguageType"]);
                        cmbPrintType.SelectedValue = Convert.ToInt32(dt.Rows[0]["PrintType"]);
                        cmbLabelsize.SelectedValue = Convert.ToInt32(dt.Rows[0]["LabelSize"]);
                        cmbTemplate.SelectedValue = Convert.ToString(dt.Rows[0]["Template"]);

                        grdDetails.Enabled = false;
                        varDirectLablPrintId = pbLPID.ToString();

                        /* CLEAR EXISTING GRID */

                        dtProduct.Rows.Clear();
                        dtGrid.Rows.Clear();

                        int sNo = 1;

                        /* LOOP PRODUCTS */

                        foreach (DataRow dr in dt.Rows)
                        {
                            string mfdDate = dr["MfdDate"].ToString();
                            string expDate = dr["ExpiryDate"].ToString();

                            /* ADD TO PRODUCT DATATABLE */

                            dtProduct.Rows.Add(
                                Convert.ToInt32(dr["PRID"]),
                                Convert.ToInt32(dr["LanguageType"]),
                                dr["Label Name"].ToString(),
                                Convert.ToDecimal(dr["MRP"]),
                                Convert.ToDecimal(dr["S.Rate"]),
                                Convert.ToInt32(dr["No.Of Copies"]),
                                Convert.ToDecimal(dr["R.Rate"]),
                                Convert.ToDecimal(dr["W.Rate"]),
                                mfdDate,
                                expDate,
                                Convert.ToInt32(dr["Title"])
                            );

                            /* ADD TO GRID TABLE */

                            dtGrid.Rows.Add(
                                sNo,
                                dr["PI Code"].ToString(),
                                dr["Label Name"].ToString(),
                                dr["Unit"].ToString(),
                                Convert.ToDecimal(dr["MRP"]),
                                Convert.ToDecimal(dr["S.Rate"]),
                                Convert.ToInt32(dr["No.Of Copies"]),
                                Convert.ToInt32(dr["PRID"])
                            );

                            sNo++;
                        }

                        /* BIND GRID */

                        grdPrintProuducts.DataSource = null;
                        grdPrintProuducts.DataSource = dtGrid.Copy();

                        udfnGridAlignment();
                        udfnSearchGridHead();

                        grdPrintProuducts.ClearSelection();
                        //udfnReportView("Preview", varDirectLablPrintId);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnDropdownLoad()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=95 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPrintLanguage, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID=110 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPrintType, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,119) AND MSTID NOT IN (0,388) ORDER BY MST_OrderID", "MST_DisplayText,MSTID", cmbTitle, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                cmbTitle.SelectedValue = -1;

                dtProduct.TableName = "MR_DLP_MultipleProducts";
                dtProduct.Columns.Add("DLPP_PRID", typeof(int));
                dtProduct.Columns.Add("DLPP_Language", typeof(int));
                dtProduct.Columns.Add("DLPP_Name", typeof(string));
                dtProduct.Columns.Add("DLPP_MRP", typeof(decimal));
                dtProduct.Columns.Add("DLPP_SalesRate", typeof(decimal));
                dtProduct.Columns.Add("DLPP_NoOfCopies", typeof(int));
                dtProduct.Columns.Add("DLPP_RetailRate", typeof(decimal));
                dtProduct.Columns.Add("DLPP_WholeSaleRate", typeof(decimal));
                dtProduct.Columns.Add("DLPP_MfdDate", typeof(string));
                dtProduct.Columns.Add("DLPP_ExpDate", typeof(string));
                dtProduct.Columns.Add("DLPP_Title", typeof(int));

                dtGrid.Columns.Add("SNo", typeof(int));
                dtGrid.Columns.Add("PI Code", typeof(string));
                dtGrid.Columns.Add("Product Name", typeof(string));
                dtGrid.Columns.Add("Unit", typeof(string));
                dtGrid.Columns.Add("MRP", typeof(decimal));
                dtGrid.Columns.Add("S.Rate", typeof(decimal));
                dtGrid.Columns.Add("No.of Copies", typeof(int));
                dtGrid.Columns.Add("ProductID", typeof(int));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void cmbPrintLanguage_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                cmbPrintLanguage.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPrintLanguage_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPrintLanguage.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void cmbPrintLanguage_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter )
                {
                    txtLabelProduct.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMrp_Enter(object sender, EventArgs e)
        {
            try
            {

                txtMrp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtMrp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSalesRate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMrp.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtNoofcopy_Enter(object sender, EventArgs e)
        {
            try
            {
                txtNoofcopy.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtNoofcopy_Leave(object sender, EventArgs e)
        {
            try
            {
                txtNoofcopy.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtNoofcopy_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbTitle.Enabled == true)
                    {
                        cmbTitle.Focus();
                    }
                    else if (txtDay.Enabled == true)
                    {
                        txtDay.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbTemplate_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbTemplate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbTemplate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbTemplate_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTemplate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtMrp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSalesRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNoofcopy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSalesRate_Enter(object sender, EventArgs e)
        {

            try
            {
                txtSalesRate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSalesRate_Leave(object sender, EventArgs e)
        {

            try
            {
                txtSalesRate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSalesRate_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNoofcopy.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnExpiryDateBind()
        {
            try
            {
                if (txtDay.Text.Length == 1)
                { txtDay.Text = 0 + txtDay.Text.Trim(); }
                if (txtMonth.Text.Length == 1)
                { txtMonth.Text = 0 + txtMonth.Text.Trim(); }
                string varExpDate = Convert.ToString(txtDay.Text + "/" + txtMonth.Text + "/" + "20" + txtYear.Text);
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 33;
                objMR_Master.paraDate = varExpDate;
                objMR_Master.paraProductId = Convert.ToInt32(lblProduct.Text);
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objspdservice.udfnMaster(objMR_Master);
                objspdservice.CloseConnection();
                if (objDs.Tables[0] != null)
                {
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        txtEDay.Text = objDs.Tables[0].Rows[0][0].ToString();
                        txtEMonth.Text = objDs.Tables[0].Rows[1][0].ToString();
                        txtEYear.Text = objDs.Tables[0].Rows[2][0].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void btnpreview_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269 && Convert.ToInt32(cmbTemplate.SelectedIndex) == 2)
                {
                    udfnExpiryDateBind();
                }
                btnpreview.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnpreview_Leave(object sender, EventArgs e)
        {
            try
            {
                btnpreview.BackColor = Color.Transparent;
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
                varUpDownKey = 1;
                udfnProductEvent();
                cmbPrintLanguage.Focus();
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
                                if (VarSearchFlag == true)
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
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
                        cmbPrintLanguage.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbLabelsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbLabelsize.Select(int.MaxValue, 0)));
                DataBind objDataBind = new DataBind();
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) != -1)
                {
                    string value = "-1";
                    int varSelectedValue = Convert.ToInt32(cmbLabelsize.SelectedValue);

                    if (varSelectedValue == 268 || varSelectedValue == 269 || varSelectedValue == 301 || varSelectedValue == 302)
                    {
                        value = "";
                    }
                    cmbTemplate.Enabled = true;
                    objDataBind.BindComboBoxListSelected("DEF_Templates", "TEMP_Labelcode IN ('" + varSelectedValue + "') AND TEMP_Statuscode = 1", "TEMP_ShortCode,TEMP_RptName,TEMP_Description",
                        cmbTemplate, "", "TEMP_ShortCode", "TEMP_RptName");
                    objDataBind = null;
                }
                else
                {
                    cmbTemplate.Text = "-Select";
                    cmbTemplate.Enabled = false;
                    lblDescription.Text = "";
                    lblDesc.Text = "";
                }
                udfnTitleDisable();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            { 
                    udfnProductEvent();
                    cmbPrintLanguage.Focus(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lvProduct_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductEvent();
                    cmbPrintLanguage.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPrintProuducts.Rows.Count > 0)
                {
                    udfnPrintSave(0, "Preview");
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPrintType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPrintSave(int varFromFlag,string varPrintType)
        {
            try
            {
                //int varTempleteValue = Convert.ToInt32(cmbTemplate.Text);
                string result = "";
                int varFlag = 0;
                SPDataService objspdservice = new SPDataService();
                MR_Product objMR_Product = new MR_Product();
                string varExpiryDate = "", varMfdDate = "";
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269 && Convert.ToInt32(cmbTemplate.SelectedIndex) == 2)
                {
                    varMfdDate = txtDay.Text + "/" + txtMonth.Text + "/" + "20" + txtYear.Text;
                    varExpiryDate = txtEDay.Text + "/" + txtEMonth.Text + "/" + "20" + txtEYear.Text;
                }
                objMR_Product.paraViewType = 2;

                objMR_Product.paraLabelSize = Convert.ToInt32(cmbLabelsize.SelectedValue);
                objMR_Product.paraPrintType = Convert.ToInt32(cmbPrintType.SelectedValue);

                objMR_Product.paraLabelTemplate = Convert.ToString(cmbTemplate.SelectedValue);
                objMR_Product.paraTemplateText = Convert.ToString(cmbTemplate.Text);

                objMR_Product.paraTestPrintFlag = varFromFlag;

                objMR_Product.paraDirectPrintId = Convert.ToInt32(varDirectLablPrintId);

                objMR_Product.paraFlag = varFlag;

                objMR_Product.paraStockTransfer = dtProduct;

                objMR_Product.paraOriginator = "Direct Label Print Save";

                result = objspdservice.udfnLabelPrint(objMR_Product);
                objspdservice.CloseConnection();
                string[] varvalue = result.Split('~');
                if (result.Split('~')[0] == "3")
                {
                    if (result.Split('~')[0] != "1")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        varDirectLablPrintId = varvalue[2];
                        if (varFromFlag == 0 || varFromFlag == 2)
                        {
                            udfnReportView(varPrintType, varDirectLablPrintId);
                            this.Close();
                            MainForm.objCP_DLP_MultipleProducts_List.udfnList();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                udfnClear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        public void udfnClear()
        {
            try
            {
                errRack.Clear();
                txtProductName.Text = "";
                cmbPrintLanguage.SelectedIndex = 0; 
                txtMrp.Text = "";
                txtSalesRate.Text = "";
                txtNoofcopy.Text = "";
                lblProduct.Text ="0";   
                lbdname.Text = "";
                lbltname.Text = "";
                lblPICode.Text = "";
                lblProductName.Text = "";
                lblUnit.Text = "";
                lblRetail.Text = "";
                lblWholesale.Text = "";
                txtLabelProduct.Text = "";
                txtDay.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtEDay.Text = "";
                txtEMonth.Text = "";
                txtEYear.Text = "";
                if (grdPrintProuducts.Rows.Count < 1)
                {
                    cmbLabelsize.SelectedIndex = 0;
                    cmbTemplate.SelectedIndex = 0;
                    cmbTemplate.Text = "-Select-";
                    cmbPrintType.Enabled= true;
                    cmbLabelsize.Enabled = true;
                    cmbTemplate.Enabled = true;
                }
                else
                {
                    cmbPrintType.Enabled=false;
                    cmbLabelsize.Enabled = false;
                    cmbTemplate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }


        public void udfnReportView(string type,string varPrintId)
        {
            try
            {
                errRack.Clear();
                int varPrint = 0;
                SPDataService objSPdataservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 70;
                objMR_Product.paraId = Convert.ToInt32(varPrintId);
                objDs = objSPdataservice.udfnproductmasterlist(objMR_Product);
                objSPdataservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    string varReportName = "", varTemplateText = "";
                    if (objDs.Tables.Count > 1)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            varReportName = Convert.ToString(objDs.Tables[1].Rows[0]["ReportName"].ToString());
                            varTemplateText = Convert.ToString(objDs.Tables[1].Rows[0]["TemplateText"].ToString());
                        }
                    }
                    //int varTemplateIndex = cmbTemplate.SelectedIndex;
                    if (type == "Preview")
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                        string rptPath = Application.StartupPath + "\\Reports\\" + varReportName + "";
                        objBillreport.Load(rptPath);
                        int templateType = Convert.ToInt32(cmbLabelsize.SelectedValue);
                        if (templateType == 316 || templateType == 317 || templateType == 318 || templateType == 319)
                        {
                            objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        }
                        //Goods Inward Direct Label Print
                        if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269 && varTemplateText == "100*70 WOHGI")
                        {
                            objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        }
                        objBillreport.SetParameterValue("paraId", varPrintId);
                        objValidation.CrySqlConnection(objBillreport);

                        //Restrict test print for Sheet
                        if (Convert.ToInt32(cmbPrintType.SelectedValue) == 363)
                        {
                            btnPrint.Enabled = true;
                        }
                        btnDirectPrint.Enabled = true;

                        MainForm.objReportLoad = new ReportLoad();
                        MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                        if (templateType == 316 || templateType == 317 || templateType == 318 || templateType == 319)
                        {
                            MainForm.objReportLoad.cryptview.Zoom(100);
                        }
                        else
                        {
                            MainForm.objReportLoad.cryptview.Zoom(2);
                        }
                        MainForm.objReportLoad.ShowDialog();
                    }
                    else
                    {
                        ManagementScope scope = new ManagementScope(@"\root\cimv2");
                        scope.Connect();

                        // Select Printers from WMI Object Collections
                        ManagementObjectSearcher searcher = new
                         ManagementObjectSearcher("SELECT * FROM Win32_Printer");

                        DataValidation dserv = new DataValidation();
                        string varPrintName = dserv.DefPrinterName(Convert.ToString(cmbLabelsize.Text));
                        //lbl_Pro_PrnName.Text = dserv.DefPrinterName(lblPLCode.Text);
                        string printerName = "";
                        foreach (ManagementObject printer in searcher.Get())
                        {
                            printerName = printer["Name"].ToString();
                            if (printerName.Equals(@varPrintName.Trim()))
                            {
                                if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                                {
                                    MessageBox.Show("Printer is not connected.");
                                    varPrintName = "";
                                    //return;
                                }
                            }
                        }
                        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreportDirectPrint = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreportDirectPrint = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                        string rptPath = Application.StartupPath + "\\Reports\\" + varReportName + "";
                        objBillreportDirectPrint.Load(rptPath);
                        string templateType = Convert.ToString(cmbLabelsize.Text);
                        if (templateType == "A4" || templateType == "A5" || templateType == "A6" || templateType == "A7")
                        {
                            objBillreportDirectPrint.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreportDirectPrint.SetParameterValue("paraUserName", MainForm.pbUserName);
                        }
                        //Goods Inward Direct Label Print
                        if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269 && varTemplateText == "100*70 WOHGI")
                        {
                            objBillreportDirectPrint.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreportDirectPrint.SetParameterValue("paraUserName", MainForm.pbUserName);
                        }
                        objValidation.CrySqlConnection(objBillreportDirectPrint);
                        System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                        printerSettings.PrinterName = varPrintName;
                        objBillreportDirectPrint.PrintToPrinter(printerSettings, new System.Drawing.Printing.PageSettings(), false);

                    }
                }
                else
                {
                    btnPrint.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                btnPrint.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                udfnPrintSave(1, "Test Print");
               // udfnReportView("Test Print", varDirectLablPrintId);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnDirectPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPrintProuducts.Rows.Count > 0)
                {
                    udfnPrintSave(2, "Direct Print");
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPrintType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void lblSubGroup_Click(object sender, EventArgs e)
        {

        }

        private void txtMrp_TextChanged(object sender, EventArgs e)
        {
            try{
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLabelProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMrp.Focus();
                }
                else if(IsTypingKey(e.KeyCode))
                {
                    //Disable the Button when the user try to change the label name
                    btnUpdate.Enabled = true;
                    btnpreview.Enabled = false;
                    btnPrint.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private bool IsTypingKey(Keys key)
        {
            // Letters A-Z
            if (key >= Keys.A && key <= Keys.Z) return true;

            // Numbers 0-9 
            if ((key >= Keys.D0 && key <= Keys.D9) ||
                (key >= Keys.NumPad0 && key <= Keys.NumPad9))
                return true;

            // Backspace, Delete, Space
            if (key == Keys.Back || key == Keys.Delete || key == Keys.Space)
                return true;

            // Symbols
            if (key >= Keys.Oem1 && key <= Keys.OemBackslash) return true;

            return false;
        }
        private void txtLabelProduct_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLabelProduct.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtLabelProduct_TextChanged(object sender, EventArgs e)
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

        private void txtLabelProduct_Leave(object sender, EventArgs e)
        {
            try
            {

                txtLabelProduct.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblProduct.Text != "" && lblProduct.Text != "0")
                {
                    //Enable the Button when the user update the label name
                    btnpreview.Enabled = true;

                    SPDataService objspdservice = new SPDataService();
                    string result = "",itemTname="", itemEname="";

                    if (Convert.ToInt32(cmbPrintLanguage.SelectedValue) == 322)
                    {
                        itemEname = txtLabelProduct.Text ;
                    }
                    else
                    {
                        itemTname = txtLabelProduct.Text ;
                    }


                    result = objspdservice.udfnProductMaster(15, Convert.ToInt32(lblProduct.Text), "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "", 0, null, 0, "", 0, 0, 0, 0, 0, null, itemEname, itemTname, "", 0, "", "", 0, 0, 0,null, 0, 0, 0, 0, null,0,"","", "", "","", 0, 0);

                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnUpdate.Enabled = false;
                        btnpreview.Focus();
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbPrintLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbPrintLanguage.SelectedValue) == 322)
                {
                    txtLabelProduct.Text = lbdname.Text;
                    txtLabelProduct.Font = new Font("Oswald Regular", 10.75f);
                }
                else
                {
                    txtLabelProduct.Text = lbltname.Text;
                    txtLabelProduct.Font = new Font("Uni Ila.Sundaram-03", 12f);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPrintType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPrintType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPrintType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbLabelsize.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPrintType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPrintType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPrintType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPrintType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                if (Convert.ToInt32(cmbPrintType.SelectedValue) == 363)
                {
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79) AND MSTID NOT IN (0) ORDER BY ISNULL(MST_OrderID,0) ASC", "MST_DisplayText,MSTID", cmbLabelsize, "", "MST_DisplayText", "MSTID");
                }
                else
                {
                    btnPrint.Enabled = false;
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,93) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbLabelsize, "", "MST_DisplayText", "MSTID");
                }
                objDataBind = null;
                cmbTemplate.Text = "-Select-";
                cmbTemplate.Enabled = false;
                lblDescription.Text = "";
                lblDesc.Text = "";
                varDirectLablPrintId = "0";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPrintLanguage_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbTemplate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbTitle_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTitle.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbTitle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbTitle_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbTitle_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbTitle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTemplate.SelectedItem is DataRowView row)
                {
                    string description = row["TEMP_Description"].ToString();

                    lblDescription.Text = description;
                    lblDesc.Text = "*";
                }
                udfnTitleDisable();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTitleDisable()
        {
            try
            {
                varDirectLablPrintId = "0";
                int varLabelSize = Convert.ToInt32(cmbLabelsize.SelectedValue);
                int varTemplateIndex = cmbTemplate.SelectedIndex;
                var varSticker = new[] { 268, 269 };
                var varSheet = new[] { 316, 317, 318, 319 };
                if ((varSticker.Contains(varLabelSize) && varTemplateIndex == 0) ||
                    (varSheet.Contains(varLabelSize) && (varTemplateIndex == 0 || varTemplateIndex == 1)))
                {
                    cmbTitle.Enabled = true;
                }
                else
                {
                    cmbTitle.SelectedValue = -1;
                    cmbTitle.Enabled = false;
                    //chkNone.Checked = false;
                    //chkNone.Enabled = false;
                }
                if (Convert.ToInt32(cmbPrintType.SelectedValue) == 363)
                {
                    //chkNone.Checked = false;
                    //chkNone.Enabled = false;
                }
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269 && varTemplateIndex == 2)
                {
                    txtDay.Enabled = true;
                    txtMonth.Enabled = true;
                    txtYear.Enabled = true;
                }
                else
                {
                    txtDay.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtEDay.Text = "";
                    txtEMonth.Text = "";
                    txtEYear.Text = "";
                    txtDay.Enabled = false;
                    txtMonth.Enabled = false;
                    txtYear.Enabled = false;
                }
                if (Convert.ToInt32(cmbPrintType.SelectedValue) == 364)
                {
                    txtFontSize.Enabled = true;
                    udfnFontSize();
                }
                else
                {
                    txtFontSize.Text = "";
                    txtFontSize.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFontSize()
        {
            try
            {
                int varTempID = 0;
                if (cmbTemplate.SelectedItem is DataRowView drv)
                {
                    if (drv.Row.Table.Columns.Contains("TEMPID") && drv["TEMPID"] != DBNull.Value)
                    {
                        string varTemplateID = drv["TEMPID"]?.ToString() ?? string.Empty;
                        varTempID = Convert.ToInt32(varTemplateID);
                    }
                }
                if (varTempID == 11)    // A4 PWH
                {
                    txtFontSize.Text = "50";
                }
                else if (varTempID == 13)   // A5 PWH
                {
                    txtFontSize.Text = "32";
                }
                else if (varTempID == 15)   // A6 PWH
                {
                    txtFontSize.Text = "23";
                }
                else if (varTempID == 17)   // A7 PWH
                {
                    txtFontSize.Text = "20";
                }
                else if (varTempID == 19)   // A4 LWH
                {
                    txtFontSize.Text = "48";
                }
                else if (varTempID == 21)   // A5 LWH
                {
                    txtFontSize.Text = "34";
                }
                else if (varTempID == 23)   // A6 LWH
                {
                    txtFontSize.Text = "21";
                }
                else if (varTempID == 25)   // A7 LWH
                {
                    txtFontSize.Text = "16";
                }
                else if (varTempID == 27)   // A4 LWOH
                {
                    txtFontSize.Text = "70";
                }
                else if (varTempID == 28)   // A5 LWOH
                {
                    txtFontSize.Text = "48";
                }
                else if (varTempID == 29)   // A6 LWOH
                {
                    txtFontSize.Text = "35";
                }
                else if (varTempID == 30)   // A7 LWOH
                {
                    txtFontSize.Text = "25";
                }
                else if (varTempID == 31)   // A4 PWOH
                {
                    txtFontSize.Text = "65";
                }
                else if (varTempID == 32)   // A5 PWOH
                {
                    txtFontSize.Text = "50";
                }
                else if (varTempID == 33)   // A6 PWOH
                {
                    txtFontSize.Text = "32";
                }
                else if (varTempID == 34)   // A7 PWOH
                {
                    txtFontSize.Text = "24";
                }
                else if (varTempID == 0)
                {
                    txtFontSize.Text = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPrintDetailsEnable()
        {
            try
            {
                txtProductName.Focus();
                txtProductName.Text = "";
                lblPICode.Text = "";
                lblProductName.Text = "";
                lblUnit.Text = "";
                lblRetail.Text = "";
                lblWholesale.Text = "";
                txtLabelProduct.Text = "";
                txtMrp.Text = "";
                txtSalesRate.Text = "";
                txtNoofcopy.Text = "";
                cmbPrintType.SelectedValue = 363;
                cmbPrintLanguage.SelectedValue = 322;
                cmbLabelsize.SelectedValue = -1;

                cmbTemplate.Text = "-Select";
                txtProductName.Enabled = true;
                cmbPrintLanguage.Enabled = true;
                txtLabelProduct.Enabled = true;
                btnUpdate.Enabled = true;
                txtMrp.Enabled = true;
                txtSalesRate.Enabled = true;
                cmbPrintType.Enabled = true;
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
                if (varClose == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objCP_DLP_MultipleProducts_List.udfnList();
                    }
                }
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

        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            if (txtDay.Text.Length == 2)
            {
                txtMonth.Focus();
            }
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text.Length == 2)
            {
                txtYear.Focus();
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length == 2)
            {
                btnAdd.Focus();
            }
        }

        private void txtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtDay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtDay_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDay.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMonth_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMonth.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMonth_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtYear.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMonth.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtYear_Enter(object sender, EventArgs e)
        {
            try
            {
                txtYear.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                txtYear.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void cmbLabelsize_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbTemplate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

       
        private void cmbLabelsize_KeyPress(object sender, KeyPressEventArgs e)
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
        private void cmbLabelsize_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbLabelsize.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void cmbLabelsize_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbLabelsize.BackColor = Color.LemonChiffon;
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
                int varShelfLifeFlag = 0;
                if (txtProductName.Text.Trim() != "")
                {
                    lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString(); 
                    lblProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    lbdname.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    varShelfLifeFlag = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_ShelfLife"].Value.ToString());
                    udfnListviewProduct();

                    if (Convert.ToInt32(cmbPrintLanguage.SelectedValue) == 322)
                    { 
                        txtLabelProduct.Text = lbdname.Text; 
                    }
                    else
                    {
                        txtLabelProduct.Text = lbltname.Text;
                    }
                    if (varShelfLifeFlag == 0)
                    {
                        txtDay.Text = "";
                        txtMonth.Text = "";
                        txtYear.Text = "";
                        txtEDay.Text = "";
                        txtEMonth.Text = "";
                        txtEYear.Text = "";
                        txtDay.Enabled = false;
                        txtMonth.Enabled = false;
                        txtYear.Enabled = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269 && Convert.ToInt32(cmbTemplate.SelectedIndex) == 2)
                        {
                            txtDay.Enabled = true;
                            txtMonth.Enabled = true;
                            txtYear.Enabled = true;
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

        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    if (lblProduct.Text != "" && lblProduct.Text != "0")
                    {

                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 1;
                        objMR_Product.paraGroup = 0;
                        objMR_Product.paraSubgroup = 0;
                        objMR_Product.ParaProductCode = Convert.ToInt32(lblProduct.Text);
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    lblPICode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["PICODE"]); 
                                    lblUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["UT_Symbol"]);
                                    lblRetail.Text = Convert.ToString(objDs.Tables[0].Rows[0]["RetailRate"]); 
                                    lblWholesale.Text = Convert.ToString(objDs.Tables[0].Rows[0]["WholeSaleRate"]);
                                    lbdname.Text = Convert.ToString(objDs.Tables[0].Rows[0]["LENAME"]);  
                                    lbltname.Text = Convert.ToString(objDs.Tables[0].Rows[0]["LTNAME"]);

                                }
                                else { udfnClear(); }
                            }
                            else { udfnClear(); }
                        }
                        else { udfnClear(); }
                    }
                    else { udfnClear(); }
                }
                else { udfnClear(); }
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
        public void udfnPreview(int varFormFlag)
        {
            try
            {
                varErrorFlag = 1;
                bool blnErrFlag = false;
                if (Convert.ToString(cmbTemplate.SelectedValue) == "Select")
                {
                    errRack.SetError(cmbTemplate, "Please select template.");
                    cmbTemplate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTemplate.ShowAlways = true;
                    tpTemplate.Show("Please select template", cmbTemplate, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) == -1)
                {
                    errRack.SetError(cmbLabelsize, "Please select label size.");
                    cmbLabelsize.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLabelSize.ShowAlways = true;
                    tpLabelSize.Show("Please select label size", cmbLabelsize, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToString(txtNoofcopy.Text.Trim()) == "")
                {
                    errRack.SetError(txtNoofcopy, "Please enter No.of copy.");
                    txtNoofcopy.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpLabelCount.ShowAlways = true;
                    tpLabelCount.Show("Please enter No.of copy", txtNoofcopy, 5000);
                    blnErrFlag = true;
                }
                else
                {
                    if (Convert.ToInt32(txtNoofcopy.Text) < 1)
                    {
                        errRack.SetError(txtNoofcopy, "Please enter valid No.of copy.");
                        txtNoofcopy.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpLabelCount.ShowAlways = true;
                        tpLabelCount.Show("Please enter valid No.of copy", txtNoofcopy, 5000);
                        blnErrFlag = true;
                    }
                }
                if (Convert.ToString(txtProductName.Text.Trim()) == "")
                {
                    errRack.SetError(txtProductName, "Please enter productname.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProdtctname.ShowAlways = true;
                    tpProdtctname.Show("Please enter productname", txtProductName, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToString(txtMrp.Text.Trim()) == "")
                {
                    errRack.SetError(txtMrp, "Please enter MRP.");
                    txtMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMRP.ShowAlways = true;
                    tpMRP.Show("Please enter MRP", txtMrp, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToString(txtSalesRate.Text.Trim()) == "")
                {
                    errRack.SetError(txtSalesRate, "Please enter salesrate.");
                    txtSalesRate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSalesRate.ShowAlways = true;
                    tpSalesRate.Show("Please enter salesrate", txtSalesRate, 5000);
                    blnErrFlag = true;
                }
                if (Convert.ToString(txtMrp.Text.Trim()) != "")
                {
                    if (Convert.ToDecimal(txtMrp.Text) < Convert.ToDecimal(txtSalesRate.Text))
                    {
                        MessageBox.Show("MRP amount is less then retail sales amount...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (cmbTitle.Enabled == true)
                {
                    if (Convert.ToInt32(cmbTitle.SelectedValue) == -1)
                    {
                        errRack.SetError(cmbTitle, "Please select title.");
                        cmbTitle.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpTitle.ShowAlways = true;
                        tpTitle.Show("Please select title", cmbTitle, 5000);
                        blnErrFlag = true;
                    }
                }
                if (blnErrFlag == false)
                {
                    varErrorFlag = 0;
                }
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

                string result = "";
                SPDataService objspdservice = new SPDataService();
                MR_Product objMR_Product = new MR_Product();
                string varExpiryDate = "", varMfdDate = "";
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269 && Convert.ToInt32(cmbTemplate.SelectedIndex) == 2)
                {
                    varMfdDate= txtDay.Text + "/" + txtMonth.Text + "/" + txtYear.Text;
                    varExpiryDate= txtEDay.Text + "/" + txtEMonth.Text + "/" + txtEYear.Text;
                }
                objMR_Product.paraViewType = 0;
                objMR_Product.paraId = Convert.ToInt32(lblProduct.Text);
                objMR_Product.paraLanguage = Convert.ToInt32(cmbPrintLanguage.SelectedValue);
                objMR_Product.paraLPMRP = (float)Convert.ToDecimal(txtMrp.Text); 
                objMR_Product.parasales_rate = (float)Convert.ToDecimal(txtSalesRate.Text);
                objMR_Product.ParaRetail = (float)Convert.ToDecimal(lblRetail.Text);
                objMR_Product.parawholesale_rate = (float)Convert.ToDecimal(lblWholesale.Text);
                objMR_Product.paraLabelSize = Convert.ToInt32(cmbLabelsize.SelectedValue);
                objMR_Product.paraCopies = Convert.ToInt32(txtNoofcopy.Text);
                objMR_Product.paraPrintType = Convert.ToInt32(cmbPrintType.SelectedValue);
                objMR_Product.paraLabelTemplate = Convert.ToString(cmbTemplate.SelectedValue); ;
                objMR_Product.paraLabelTitle = Convert.ToInt32(cmbTitle.SelectedValue);     
                objMR_Product.paraProductLabelNameEng = txtLabelProduct.Text;
                objMR_Product.ParaFromDate = varMfdDate;
                objMR_Product.ParaToDate = varExpiryDate;
                objMR_Product.paraOriginator = "Label Print Save"; 
                result = objspdservice.udfnLabelPrint(objMR_Product);
                objspdservice.CloseConnection();
                string[] varvalue = result.Split('~');
                if (result.Split('~')[0] == "3")
                {
                    if (result.Split('~')[0] != "1")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm.objCP_DLP_SingleProduct_List.udfnList();
                    }
                } 
                else
                {
                    MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                varErrorFlag = 0;
                udfnPreview(1); 
                int varPRID = string.IsNullOrWhiteSpace(lblProduct.Text) ? 0 : Convert.ToInt32(lblProduct.Text);

                // Check if PRID already exists
                bool varExist = dtProduct.AsEnumerable().Any(row => row.Field<int>("DLPP_PRID") == varPRID);

                if (varExist)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(70);
                    objDServ.CloseConnection();

                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrorFlag = 1;
                }
                if (varErrorFlag == 0)
                {
                    errRack.Clear();
                    udfnAdd();
                    udfnClear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269 && Convert.ToInt32(cmbTemplate.SelectedIndex) == 2)
                {
                    udfnExpiryDateBind();
                }
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnAdd()
        {
            try
            {
                DGV_SearchGrid.DataSource = null;
                string varExpiryDate = "", varMfdDate = "";
                if (Convert.ToInt32(cmbLabelsize.SelectedValue) == 269 && Convert.ToInt32(cmbTemplate.SelectedIndex) == 2)
                {
                    varMfdDate = txtDay.Text + "/" + txtMonth.Text + "/" + "20" + txtYear.Text;
                    varExpiryDate = txtEDay.Text + "/" + txtEMonth.Text + "/" + "20" + txtEYear.Text;
                }
                dtProduct.Rows.Add(Convert.ToInt32(lblProduct.Text), Convert.ToInt32(cmbPrintLanguage.SelectedValue), txtLabelProduct.Text.Trim(), Convert.ToDecimal(txtMrp.Text), Convert.ToDecimal(txtSalesRate.Text), Convert.ToInt32(txtNoofcopy.Text), Convert.ToDecimal(lblRetail.Text), Convert.ToDecimal(lblWholesale.Text), varMfdDate, varExpiryDate, Convert.ToInt32(cmbTitle.SelectedValue));

                int sNo = dtGrid.Rows.Count + 1;

                dtGrid.Rows.Add(
                    sNo,
                    lblPICode.Text,
                    txtLabelProduct.Text.Trim(),
                    lblUnit.Text,
                    Convert.ToDecimal(txtMrp.Text),
                    Convert.ToDecimal(txtSalesRate.Text),
                    Convert.ToInt32(txtNoofcopy.Text),
                    Convert.ToInt32(lblProduct.Text)
                );

                grdPrintProuducts.DataSource = null;
                grdPrintProuducts.DataSource = dtGrid;


                udfnGridAlignment();
                udfnSearchGridHead();
                grdPrintProuducts.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblTotalMappingProduct.Text = Convert.ToString(grdPrintProuducts.RowCount);
            }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdPrintProuducts, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdPrintProuducts.Columns)
                {
                    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                int rowIndex = 0;
                DGV_SearchGrid.Rows.Clear();
                DGV_SearchGrid.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                }
                DGV_SearchGrid.Columns["SNo"].ReadOnly = true;
                DGV_SearchGrid.Columns[0].ReadOnly = true;
                DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataService objDser = new DataService();
                grdPrintProuducts.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPrintProuducts);
                objDser.CloseConnection();
                grdPrintProuducts.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 0))   /*If not our desired columns*/
                    //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                DataGridViewColumn newColumn = grdPrintProuducts.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdPrintProuducts.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdPrintProuducts.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                grdPrintProuducts.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGrid.HorizontalScrollingOffset = grdPrintProuducts.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdPrintProuducts.ColumnCount > 0)
                {
                    grdPrintProuducts.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdPrintProuducts.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdPrintProuducts.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPrintProuducts);
                objDser.CloseConnection();
                grdPrintProuducts.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdPrintProuducts.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdPrintProuducts);
                objDser.CloseConnection();
                grdPrintProuducts.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdPrintProuducts.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdPrintProuducts.Width > grdPrintProuducts.HorizontalScrollingOffset && grdPrintProuducts.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void grdPrintProuducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPrintProuducts.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":

                            DialogResult dialogResult = MessageBox.Show(
                                "Are you sure want to remove ?",
                                "Confirmation",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (dialogResult == DialogResult.Yes)
                            {
                                int rowIndex = grdPrintProuducts.CurrentRow.Index;
                                int productID = Convert.ToInt32(grdPrintProuducts.CurrentRow.Cells["ProductID"].Value);

                                /* REMOVE FROM GRID TABLE */

                                dtGrid.Rows.RemoveAt(rowIndex);

                                /* REMOVE FROM PRODUCT DATATABLE */

                                for (int i = dtProduct.Rows.Count - 1; i >= 0; i--)
                                {
                                    if (Convert.ToInt32(dtProduct.Rows[i]["DLPP_PRID"]) == productID)
                                    {
                                        dtProduct.Rows.RemoveAt(i);
                                    }
                                }

                                /* REFRESH GRID */

                                grdPrintProuducts.DataSource = null;
                                grdPrintProuducts.DataSource = dtGrid;

                                /* RESET SERIAL NUMBER */

                                for (int i = 0; i < dtGrid.Rows.Count; i++)
                                {
                                    dtGrid.Rows[i]["SNo"] = i + 1;
                                }

                                udfnGridAlignment();
                                grdPrintProuducts.ClearSelection();
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
            finally
            {
                lblTotalMappingProduct.Text = Convert.ToString(grdPrintProuducts.RowCount);
                if (grdPrintProuducts.Rows.Count == 0)
                {
                    cmbPrintType.Enabled = true;
                    cmbLabelsize.Enabled = true;
                    cmbTemplate.Enabled = true;
                }
                else
                {
                    cmbPrintType.Enabled = false;
                    cmbLabelsize.Enabled = false;
                    cmbTemplate.Enabled = false;
                }
            }
        }
        public void udfnGridAlignment()
        {
            try
            {
                grdPrintProuducts.Columns["SNo"].Width = 50;
                grdPrintProuducts.Columns["Product Name"].Width = 280;
                grdPrintProuducts.Columns["Unit"].Width = 50;
                grdPrintProuducts.Columns["MRP"].Width = 80;
                grdPrintProuducts.Columns["S.Rate"].Width = 70;
                grdPrintProuducts.Columns["No.of Copies"].Width = 90;

                grdPrintProuducts.Columns["SNo"].HeaderText = "S.No.";
                grdPrintProuducts.Columns["SNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdPrintProuducts.Columns["Product Name"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                grdPrintProuducts.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdPrintProuducts.Columns["MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdPrintProuducts.Columns["S.Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdPrintProuducts.Columns["No.of Copies"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdPrintProuducts.Columns["ProductID"].Visible = false;
                grdPrintProuducts.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void grdPrintProuducts_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdPrintProuducts.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdPrintProuducts.Width > grdPrintProuducts.HorizontalScrollingOffset && grdPrintProuducts.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdPrintProuducts);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdInwardList)
        {
            try
            {
                var vScrollbar = grdInwardList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
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

        private void grdPrintProuducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdPrintProuducts.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtFontSize_Enter(object sender, EventArgs e)
        {
            try
            {
                txtFontSize.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtFontSize_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnpreview.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtFontSize_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFontSize_Leave(object sender, EventArgs e)
        {
            try
            {
                txtFontSize.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                //dgv2.DataSource = null;
                dgv2.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in dgv1.Columns)
                {
                    if (col.Visible)
                    {
                        dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                }
                int rowIndex = 0;
                int ColIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                    {
                        //dgv2.Rows[rowIndex].Visible = false;
                        BlnSearchImageYN = true;
                        ColIndex = i;
                        dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                        dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                        ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                    }
                    else
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
    }
}
