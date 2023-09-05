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
    // Name  : Sivabharathi    Date : 02/09/2023
    public partial class CP_BulkAttributes : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public int varFormFlag = 0;

        public int varGroupId = 0;
        public int varSubGroupId = 0;
        public int varBrandId = 0;
        public int varViewType = 0;
        public int varStatusId = 0;
        public CP_BulkAttributes()
        {
            InitializeComponent();
        }
        public void udfnHideGrids() {
            try {
                grdLoction.Visible = false;
                grdMSQ.Visible = false;
                grdStock.Visible = false;
                grdShelfLife.Visible = false;
                grdBatch.Visible = false;
                grdWeight.Visible = false;
                grdBrand.Visible = false;
                grdHSN.Visible = false;
                grdBulkAttributes.Visible = false;
                tsbLocation.BackColor = SystemColors.MenuBar;
                tsbMSQ.BackColor = SystemColors.MenuBar;
                tsbStock.BackColor = SystemColors.MenuBar;
                tsbShelflife.BackColor = SystemColors.MenuBar;
                tsbBatch.BackColor = SystemColors.MenuBar;
                tsbWeight.BackColor = SystemColors.MenuBar;
                tsbBrand.BackColor = SystemColors.MenuBar;
                tsbHsn.BackColor = SystemColors.MenuBar;
                tsbName.BackColor = SystemColors.MenuBar;
            }
            catch (Exception ex) {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbStatus()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STSID NOT IN(-1)", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnFilterLoad()
        {
            try
            {
                varGroupId = 0;
                varSubGroupId = 0;
                varBrandId = 0;
                varStatusId = 0;
                udfnCmbProductGroup();
                udfnCmbBrand();
                udfnCmbStatus();
                cmbGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnClose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    MainForm objMainForm = new MainForm();
                    objMainForm.udfnCloseChildForms();
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
        public void udfnLoadLocation() {
            try
            {
                udfnHideGrids();
                grdLoction.Visible = true;
                
                tspHeader.Text = "Product Attributes Bulk Update : Stock location, Rack & MSQ";
                tsbLocation.BackColor = Color.SkyBlue;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUpdate()
        {
            try
            {
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnUpdate.Enabled = true;
                btnUpdate.Focus();
            }
        }
        public void udfnList()
        {
            try
            {
               // Application.DoEvents();
                grdLoction.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnproductmasterlist(varViewType, 0, 0, varGroupId, varSubGroupId, "", MainForm.pbUserID, MainForm.pbIpAddress,0,varStatusId,varBrandId);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        //lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            if (grdLoction.Visible == true)
                            {
                                grdLoction.DataSource = objDs.Tables[0];
                                grdLoction.Columns["S.No."].Width = 50;
                                grdLoction.Columns["Product Name in Tamil"].Width = 200;
                                grdLoction.Columns["S.No."].Frozen = true;
                                grdLoction.Columns["P.I Code"].Frozen = true;
                                grdLoction.Columns["Product Name in Tamil"].Frozen = true;
                                grdLoction.Columns["Unit"].Frozen = true;
                                grdLoction.Columns["S.No."].ReadOnly = true;
                                grdLoction.Columns["P.I Code"].ReadOnly = true;
                                grdLoction.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdLoction.Columns["Unit"].ReadOnly = true;

                                grdLoction.Columns["Pur.Stock Location-Current"].ReadOnly = true;
                                grdLoction.Columns["Rack MSQ-Current"].ReadOnly = true;
                                grdLoction.Columns["Pur.Rack-Current"].ReadOnly = true;
                                grdLoction.Columns["Sales Location-Current"].ReadOnly = true;
                                grdLoction.Columns["Sales Rack -Current"].ReadOnly = true;

                                grdLoction.Columns["Pur.Stock Location-Current"].Width = 150;
                                grdLoction.Columns["Pur.Stock Location-New"].Width = 150;
                                grdLoction.Columns["Pur.Rack-Current"].Width = 120;
                                grdLoction.Columns["Sales Location-Current"].Width = 150;
                                grdLoction.Columns["Sales Location-New"].Width = 120;
                                grdLoction.Columns["Sales Rack -Current"].Width = 120;
                                grdLoction.Columns["Rack MSQ-Current"].Width = 150;
                            }
                            else if(grdMSQ.Visible==true)
                            {
                                grdMSQ.DataSource = objDs.Tables[0];
                                grdMSQ.Columns["S.No."].Width = 50;
                                grdMSQ.Columns["Product Name in Tamil"].Width = 200;
                                grdMSQ.Columns["S.No."].Frozen = true;
                                grdMSQ.Columns["P.I Code"].Frozen = true;
                                grdMSQ.Columns["Product Name in Tamil"].Frozen = true;
                                grdMSQ.Columns["Unit"].Frozen = true;
                                grdMSQ.Columns["S.No."].ReadOnly = true;
                                grdMSQ.Columns["P.I Code"].ReadOnly = true;
                                grdMSQ.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdMSQ.Columns["Unit"].ReadOnly = true;

                                grdMSQ.Columns["R Min Sale Qty-Current"].ReadOnly = true;
                                grdMSQ.Columns["R.Rate-Current"].ReadOnly = true;
                                grdMSQ.Columns["W.Min Sale Qty-Current"].ReadOnly = true;
                                grdMSQ.Columns["W.Sale Rate-Current"].ReadOnly = true;
                                grdMSQ.Columns["Barcode-Current"].ReadOnly = true;

                            }
                            else if(grdStock.Visible==true)
                            {
                                grdStock.DataSource = objDs.Tables[0];
                                grdStock.Columns["S.No."].Width = 50;
                                grdStock.Columns["Product Name in Tamil"].Width = 200;
                                grdStock.Columns["S.No."].Frozen = true;
                                grdStock.Columns["P.I Code"].Frozen = true;
                                grdStock.Columns["Product Name in Tamil"].Frozen = true;
                                grdStock.Columns["Unit"].Frozen = true;
                                grdStock.Columns["S.No."].ReadOnly = true;
                                grdStock.Columns["P.I Code"].ReadOnly = true;
                                grdStock.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdStock.Columns["Unit"].ReadOnly = true;

                                grdStock.Columns["Min Stock-Current"].ReadOnly = true;
                                grdStock.Columns["Max Stock-Current"].ReadOnly = true;
                                grdStock.Columns["Reorder Qty-Current"].ReadOnly = true;
                            }
                            else if(grdWeight.Visible==true)
                            {
                                grdWeight.DataSource = objDs.Tables[0];
                                grdWeight.Columns["S.No."].Width = 50;
                                grdWeight.Columns["Product Name in Tamil"].Width = 200;
                                grdWeight.Columns["S.No."].Frozen = true;
                                grdWeight.Columns["P.I Code"].Frozen = true;
                                grdWeight.Columns["Product Name in Tamil"].Frozen = true;
                                grdWeight.Columns["Unit"].Frozen = true;
                                grdWeight.Columns["S.No."].ReadOnly = true;
                                grdWeight.Columns["P.I Code"].ReadOnly = true;
                                grdWeight.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdWeight.Columns["Unit"].ReadOnly = true;

                                grdWeight.Columns["Net Weight-Current"].ReadOnly = true;
                                grdWeight.Columns["Gross Weight-Current"].ReadOnly = true;
                            }
                            else if(grdBrand.Visible==true)
                            {
                                grdBrand.DataSource = objDs.Tables[0];
                                grdBrand.Columns["S.No."].Width = 50;
                                grdBrand.Columns["Product Name in Tamil"].Width = 200;
                                grdBrand.Columns["S.No."].Frozen = true;
                                grdBrand.Columns["P.I Code"].Frozen = true;
                                grdBrand.Columns["Product Name in Tamil"].Frozen = true;
                                grdBrand.Columns["Unit"].Frozen = true;
                                grdBrand.Columns["S.No."].ReadOnly = true;
                                grdBrand.Columns["P.I Code"].ReadOnly = true;
                                grdBrand.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdBrand.Columns["Unit"].ReadOnly = true;

                                grdBrand.Columns["Group-Current"].ReadOnly = true;
                                grdBrand.Columns["Sub Group-Current"].ReadOnly = true;
                                grdBrand.Columns["Brand-Current"].ReadOnly = true;

                            }
                        }
                        else
                        {
                            //lblNoRecordsFound.Visible = true;
                            //lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        //lblNoRecordsFound.Visible = true;
                        //lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    //lblNoRecordsFound.Visible = true;
                    //lblNoRecordsFound.BringToFront();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                //picLoader.Visible = false;
                //picLoader.SendToBack();
            }
        }
        public void udfnCmbProductGroup()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varViewType = 3;
                objDT = objdserv.udfnGroupList(varViewType, 0, 0);
                objdserv.CloseConnection();
                cmbGroup.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbGroup.ValueMember = "PRGID";
                            cmbGroup.DisplayMember = "PRG_EName";
                            cmbGroup.DataSource = objDT.Tables[0];
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
        public void udfnCmbBrand()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varViewType = 2;
                if (varGroupId != 0 || varSubGroupId != 0)
                {
                     varViewType = 5;
                }
                
                objDT = objdserv.udfnBrandList(varViewType,"", varGroupId,varSubGroupId,0);
                objdserv.CloseConnection();
                cmbBrand.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbBrand.ValueMember = "BDID";
                            cmbBrand.DisplayMember = "BD_EName";
                            cmbBrand.DataSource = objDT.Tables[0];
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
        private void TsbLocation_Click(object sender, EventArgs e)
        {
            try
            {
                varViewType = 4;
                if (varFormFlag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        udfnFilterLoad();
                        udfnLoadLocation();
                    }
                }
                else
                {
                    udfnLoadLocation();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                varFormFlag = 0;
            }
        }
        private void TsbMSQ_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnFilterLoad();
                    udfnHideGrids();
                    varViewType = 5;
                    grdMSQ.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Minsales Qty & Barcode";
                    tsbMSQ.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbStock_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnFilterLoad();
                    udfnHideGrids();
                    varViewType = 6;
                    grdStock.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Min, Max stock & Reorder Qty";
                    tsbStock.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbShelflife_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnFilterLoad();
                    udfnHideGrids();
                    grdShelfLife.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Bulk Unit, UPP & Shelf Life";
                    tsbShelflife.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbBatch_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnFilterLoad();
                    udfnHideGrids();
                    grdBatch.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Product Category, RM Flag & Batch";
                    tsbBatch.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbWeight_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnFilterLoad();
                    udfnHideGrids();
                    varViewType = 9;
                    grdWeight.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Net & Gross Weight";
                    tsbWeight.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbBrand_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnFilterLoad();
                    udfnHideGrids();
                    varViewType = 10;
                    grdBrand.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Group, Subgroup & Brand";
                    tsbBrand.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbHsn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnFilterLoad();
                    udfnHideGrids();
                    grdHSN.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : HSN Name";
                    tsbHsn.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TsbName_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    udfnFilterLoad();
                    udfnHideGrids();
                    grdBulkAttributes.Visible = true;
                    tspHeader.Text = "Product Attributes Bulk Update : Pro. Code, Name & Unit";
                    tsbName.BackColor = Color.SkyBlue;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_BulkAttributes_Load(object sender, EventArgs e)
        {
            try
            {
                varFormFlag = 1;
                TsbLocation_Click(sender,e);
                udfnFilterLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_BulkAttributeVerify = new CP_BulkAttributeVerify();
                MainForm.objCP_BulkAttributeVerify.ShowDialog();
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
        private void CmbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSubGroup.Focus();
                }
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
                varGroupId = Convert.ToInt32(cmbGroup.SelectedValue);
                udfnCmbBrand();
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
        private void TxtSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSubGroup.BackColor = Color.White;
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
                    if (lvSubGroup.Items.Count == 0 || lvSubGroup.Text == "")
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
                    cmbBrand.Focus();
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
        private void CmbBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbStatus.Focus();
                }
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
        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStatus_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.White;
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
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnView_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                btnView.Enabled = false;
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnView.Enabled = true;
                btnView.Focus();
            }
        }
        private void TxtProductName_Enter(object sender, EventArgs e)
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
        private void TxtProductName_Leave(object sender, EventArgs e)
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
        private void BtnClose_Enter(object sender, EventArgs e)
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
        private void BtnClose_Leave(object sender, EventArgs e)
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnClose();
                
                //this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUpdate_Enter(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUpdate_Leave(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnUpdate_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                udfnUpdate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_BulkAttributes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                udfnClose();
            }
            if (e.KeyCode == Keys.F5)
            {
                BtnUpdate_Click(sender, e);
            }
        }
        private void TxtSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSubGroup.Text.Length > 2)
                {
                  objDs = objspdservice.udfnSubGroupList(8,0,"",varGroupId,0,Convert.ToString(txtSubGroup.Text));
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSubGroup.Items.Add(objList);
                                    lvSubGroup.Columns[0].Width = 150;
                                    lvSubGroup.Columns[1].Width = 0;
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
        public void udfnlvSubGroup()
        {
            try
            {
                if (txtSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    txtSubGroup.Text = selectedItem.SubItems[0].Text;
                    varSubGroupId =Convert.ToInt32( selectedItem.SubItems[1].Text);
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
        private void LvSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnlvSubGroup();
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
                    udfnlvSubGroup();
                    cmbBrand.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdLoction.Visible == true)
                { (grdLoction.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in Tamil]) LIKE '%" + txtProductName.Text + "%' "; }
                // or ([P.I Code]) LIKE '% " + txtProductName.Text +
                else if (grdMSQ.Visible == true)
                { (grdMSQ.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in Tamil]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdStock.Visible == true)
                { (grdStock.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in Tamil]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdWeight.Visible == true)
                { (grdWeight.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in Tamil])  LIKE '%" + txtProductName.Text + "%'"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbStatus.Select(int.MaxValue, 0)));
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
    }
}
