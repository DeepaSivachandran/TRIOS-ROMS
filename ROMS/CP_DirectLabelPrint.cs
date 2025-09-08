using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.Shared;
using ROMS.Model;
using System.Management;

namespace ROMS
{
    //Author : Sathish
    //Created On : 20-02-2025
    public partial class CP_DirectLabelPrint : Form
    {

        //*************** Object for Service Classes Initialisation  ***********
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public DataTable dtPMGroup, dtSubgroup, dtProduct, dtGroup, dtRack;
        public static string varFGCode;
        public int varStickerType;
        private ToolTip tpTemplate = new ToolTip();
        private ToolTip tpType = new ToolTip();
        private ToolTip tpLabelSize = new ToolTip();
        private ToolTip tpLabelCount = new ToolTip();
        private ToolTip tpProdtctname = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpSalesRate = new ToolTip();
         
        public string varProductCodes, varSubgroupCodes, varGroupCodes, varRackCodes = "0";
        public int varUpDownKey = 0;
        public bool VarSearchFlag = true,varPrintflag = true;
        private int varsno;
        List<string> varListSubgroupCodes = new List<string>();
        List<string> varListGroupCodes = new List<string>();

        public CP_DirectLabelPrint()
        {
            InitializeComponent();
        }

        private void PROD_LabelPrinting_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
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

        private void BtnClose_Enter(object sender, EventArgs e)
        {

        }

        private void BtnClose_Leave(object sender, EventArgs e)
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
            try {
                
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
                objDataBind = null;
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
                    cmbPrintType.Focus();
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
                    btnpreview.Focus();
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

        private void btnpreview_Enter(object sender, EventArgs e)
        {
            try
            {
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
                    objDataBind.BindComboBoxListSelected("DEF_Templates","TEMP_Labelcode IN ('" + varSelectedValue + "') AND TEMP_Statuscode = 1","TEMP_ShortCode,TEMP_RptName",
                        cmbTemplate,"","TEMP_ShortCode","TEMP_RptName" );
                    objDataBind = null;
                    
                }
                else
                {
                    cmbTemplate.SelectedIndex = 0;
                    cmbTemplate.Enabled = false;
                }
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
                udfnPreview();
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

        public void udfnClear() {
            try
            {
                errRack.Clear();
                txtProductName.Text = "";
                cmbPrintLanguage.SelectedIndex = 0; 
                txtMrp.Text = "";
                txtSalesRate.Text = "";
                txtNoofcopy.Text = "";
                cmbLabelsize.SelectedIndex = 0;
                cmbTemplate.SelectedIndex = 0;
                lblProduct.Text ="0";   
                lbdname.Text = "";
                lblPICode.Text = "";
                lblProductName.Text = "";
                lblUnit.Text = "";
                lblRetail.Text = "";
                lblWholesale.Text = "";
                RPTViewer.ReportSource = null;
                lblNoRecordsFound.Visible = true;
                txtLabelProduct.Text = "";
                lblNoRecordsFound.BringToFront();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }


        public void udfnReportView(string type)
        {
            try
            {
                int flag = 1;

                if (Convert.ToInt32(cmbPrintLanguage.SelectedValue) == 322) {
                    flag = 2;
                } 
              
                picLoader4.Visible = true;
                errRack.Clear();
                int varPrint = 0;
                SPDataService objSPdataservice = new SPDataService();
                DataSet objDs = new DataSet();
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 70;  
                objMR_Product.paraFlag = flag;
                objMR_Product.ParaMRP = Convert.ToDouble(txtMrp.Text); 
                objMR_Product.ParaProductCode = Convert.ToInt32(lblProduct.Text);
                objMR_Product.ParaRetail = Convert.ToDouble(txtSalesRate.Text);
                objMR_Product.paraLabelCount = Convert.ToInt32(txtNoofcopy.Text); 
                objDs = objSPdataservice.udfnproductmasterlist(objMR_Product);
                objSPdataservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {

                    if (type == "Preview")
                    {
                        RPTViewer.ReportSource = null;
                        RPTViewer.Visible = true;
                        RPTViewer.BringToFront();
                        RPTViewer.ReuseParameterValuesOnRefresh = true;
                        RPTViewer.RefreshReport();
                        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                        string rptPath = Application.StartupPath + "\\Reports\\" + cmbTemplate.SelectedValue + "";
                        objBillreport.Load(rptPath);
                        int templateType = Convert.ToInt32(cmbLabelsize.SelectedValue);
                        if (templateType == 316 || templateType == 317 || templateType == 318 || templateType == 319)
                        {

                            objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        }
                        objBillreport.SetParameterValue("paraFlag", flag);
                        objBillreport.SetParameterValue("ParaMRP", Convert.ToDouble(txtMrp.Text));
                        objBillreport.SetParameterValue("ParaProductCode", Convert.ToInt32(lblProduct.Text));
                        objBillreport.SetParameterValue("ParaRetail", Convert.ToDouble(txtSalesRate.Text));
                        objBillreport.SetParameterValue("paraLabelCount", Convert.ToDouble(txtNoofcopy.Text));

                        objValidation.CrySqlConnection(objBillreport);
                        RPTViewer.ReportSource = objBillreport;
                        if (templateType == 316 || templateType == 317 || templateType == 318 || templateType == 319)
                        {
                            RPTViewer.Zoom(100);
                            // 1 =  Page Width , 2 = Whole Page, or use percentage
                        }
                        else
                        {
                            RPTViewer.Zoom(2);
                        }
                        //Restrict test print for Sheet
                        if (Convert.ToInt32(cmbPrintType.SelectedValue) == 363)
                        {
                            btnPrint.Enabled = true;
                        }
                        btnDirectPrint.Enabled = true;
                        RPTViewer.Refresh();
                        picLoader4.Visible = false;
                        lblNoRecordsFound.Visible = false;
                    }
                    else if (type == "Test Print")
                    {
                        ManagementScope scope = new ManagementScope(@"\root\cimv2");
                        scope.Connect();

                        // Select Printers from WMI Object Collections
                        ManagementObjectSearcher searcher = new
                         ManagementObjectSearcher("SELECT * FROM Win32_Printer");

                        DataValidation dserv = new DataValidation();
                        string varPrintName = dserv.DefPrinterName(cmbLabelsize.Text);
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
                        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreportTestPrint = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreportTestPrint = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                        string rptPath = Application.StartupPath + "\\Reports\\" + cmbTemplate.SelectedValue + "";
                        objBillreportTestPrint.Load(rptPath);
                        string templateType = Convert.ToString(cmbLabelsize.Text);
                        if (templateType == "A4" || templateType == "A5" || templateType == "A6" || templateType == "A7")
                        {

                            objBillreportTestPrint.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreportTestPrint.SetParameterValue("paraUserName", MainForm.pbUserName);
                        }
                        objBillreportTestPrint.SetParameterValue("paraFlag", flag);
                        objBillreportTestPrint.SetParameterValue("ParaMRP", Convert.ToDouble(txtMrp.Text));
                        if (templateType == "A4" || templateType == "100*70" )
                        {
                            objBillreportTestPrint.SetParameterValue("paraLabelCount", 1);
                        }
                        else if ( templateType == "A5" ||  templateType == "50*35" || templateType == "50*25" || templateType == "50*60")
                        {
                            objBillreportTestPrint.SetParameterValue("paraLabelCount", 2);
                        }
                        else if (templateType == "A6" )
                        {
                            objBillreportTestPrint.SetParameterValue("paraLabelCount", 4);
                        }
                        else if (templateType == "A7")
                        {
                            objBillreportTestPrint.SetParameterValue("paraLabelCount", 8);
                        }

                        objBillreportTestPrint.SetParameterValue("ParaRetail", Convert.ToDouble(txtSalesRate.Text));

                        objBillreportTestPrint.SetParameterValue("ParaProductCode", Convert.ToInt32(lblProduct.Text));

                        objValidation.CrySqlConnection(objBillreportTestPrint);
                        System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                        printerSettings.PrinterName = varPrintName;
                        objBillreportTestPrint.PrintToPrinter(printerSettings, new System.Drawing.Printing.PageSettings(), false);

                    }
                    else
                    {
                        ManagementScope scope = new ManagementScope(@"\root\cimv2");
                        scope.Connect();

                        // Select Printers from WMI Object Collections
                        ManagementObjectSearcher searcher = new
                         ManagementObjectSearcher("SELECT * FROM Win32_Printer");

                        DataValidation dserv = new DataValidation();
                        string varPrintName = dserv.DefPrinterName(cmbLabelsize.Text);
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

                        string rptPath = Application.StartupPath + "\\Reports\\" + cmbTemplate.SelectedValue + "";
                        objBillreportDirectPrint.Load(rptPath);
                        string templateType = Convert.ToString(cmbLabelsize.Text);
                        if (templateType == "A4" || templateType == "A5" || templateType == "A6" || templateType == "A7")
                        {

                            objBillreportDirectPrint.SetParameterValue("paraHostName", MainForm.pbHostName);
                            objBillreportDirectPrint.SetParameterValue("paraUserName", MainForm.pbUserName);
                        }
                        objBillreportDirectPrint.SetParameterValue("paraFlag", flag);
                        objBillreportDirectPrint.SetParameterValue("ParaMRP", Convert.ToDouble(txtMrp.Text));
                        objBillreportDirectPrint.SetParameterValue("ParaProductCode", Convert.ToInt32(lblProduct.Text));
                        objBillreportDirectPrint.SetParameterValue("ParaRetail", Convert.ToDouble(txtSalesRate.Text));
                        objBillreportDirectPrint.SetParameterValue("paraLabelCount", Convert.ToDouble(txtNoofcopy.Text));

                        objValidation.CrySqlConnection(objBillreportDirectPrint);
                        System.Drawing.Printing.PrinterSettings printerSettings = new System.Drawing.Printing.PrinterSettings();
                        printerSettings.PrinterName = varPrintName;
                        objBillreportDirectPrint.PrintToPrinter(printerSettings, new System.Drawing.Printing.PageSettings(), false);

                    }

                }
                else
                {

                    btnPrint.Enabled = false;
                    btnDirectPrint.Enabled = false;
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront(); 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                btnPrint.Enabled = false;
                btnDirectPrint.Enabled = false;
                lblNoRecordsFound.Visible = true;
                RPTViewer.ReportSource = null;
                lblNoRecordsFound.BringToFront(); 
            }
            finally
            {
                picLoader4.Visible = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
                udfnReportView("Test Print");
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
                udfnReportView("Direct Print");
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
                    btnpreview.Enabled = false;
                    btnPrint.Enabled = false;
                    btnDirectPrint.Enabled = false;
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


                    result = objspdservice.udfnProductMaster(15, Convert.ToInt32(lblProduct.Text), "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "", 0, null, 0, "", 0, 0, 0, 0, 0, null, itemEname, itemTname, "", 0);

                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { 
                    
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
                }
                else
                {
                    txtLabelProduct.Text = lbltname.Text;
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
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,79) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbLabelsize, "", "MST_DisplayText", "MSTID");
                }
                else
                {
                    btnPrint.Enabled = false;
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,93) AND MSTID NOT IN (0) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbLabelsize, "", "MST_DisplayText", "MSTID");
                }
                objDataBind = null;
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
                MainForm.objStart = new DEF_Start();
                MainForm.objStart.MdiParent = this.ParentForm;
                MainForm.objStart.Show();
                this.Close();
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
                if (txtProductName.Text.Trim() != "")
                {
                    lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString(); 
                    lblProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    lbdname.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    udfnListviewProduct();

                    if (Convert.ToInt32(cmbPrintLanguage.SelectedValue) == 322)
                    { 
                        txtLabelProduct.Text = lbdname.Text; 
                    }
                    else
                    {
                        txtLabelProduct.Text = lbltname.Text;
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
                lvProduct.Visible = false;
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
        public void udfnPreview()
        {
            try
            {
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
                if (Convert.ToString(txtMrp.Text.Trim())   != "")
                {
                    if (Convert.ToInt32(txtMrp.Text) < Convert.ToInt32(txtSalesRate.Text))
                    {
                        MessageBox.Show("MRP amount is less then retail sales amount...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (blnErrFlag == false)
                {
                    errRack.Clear();
                    udfnReportView("Preview");
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
