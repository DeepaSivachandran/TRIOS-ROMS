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
    //Created By:- Sathish
    //Created On:- 02-09-2023
    public partial class CP_RackSettings : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tpProductGroup = new ToolTip();
        private ToolTip tpProductSubGroup = new ToolTip();

        public DataTable dtSupplierMapping = new DataTable();
        public DataTable dtViewSupplierMapping = new DataTable();

        public int varId = 0;
        public int varStockLocationId = 0;
        public int varSRackId = 0;
        public int varGroupId = 0;
        public int varSubGroupId = 0;
        public int varCheckAllFlag = 0;
        public CP_RackSettings()
        {
            InitializeComponent();
        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Supplier = new CP_Supplier();
                MainForm.objCP_Supplier.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
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
        private void tsbDelete_Click(object sender, EventArgs e)
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

        private void CP_BrandList_Load(object sender, EventArgs e)
        {
            try
            {
                grbDestination.Visible = false;
                dtSupplierMapping = new DataTable();
                dtSupplierMapping.Columns.Add("", typeof(Boolean));
                dtSupplierMapping.Columns.Add("S.No.", typeof(string));
                dtSupplierMapping.Columns.Add("PRODUCTID", typeof(int));
                dtSupplierMapping.Columns.Add("P.I Code", typeof(string));
                dtSupplierMapping.Columns.Add("Product Name in English", typeof(string));
                dtSupplierMapping.Columns.Add("Product Name in Tamil", typeof(string));
                dtSupplierMapping.Columns.Add("Unit", typeof(string));


                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                int varViewType = 7;
                if (btnSave.Text == "Save")
                {
                    varViewType = 6;
                }
                objDs = objdserv.udfnStockLocationList(varViewType,0,0,0);
                objdserv.CloseConnection();
                cmbSStockLocation.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbSStockLocation.ValueMember = "SLID";
                            cmbSStockLocation.DisplayMember = "SL_EName";
                            cmbSStockLocation.DataSource = objDs.Tables[0];
                        }
                    }
                }

                DataSet objDS = new DataSet();
                SPDataService objsdserv = new SPDataService();
                int varviewType = 7;
                if (btnSave.Text == "Save")
                {
                    varviewType = 6;
                }
                objDS = objsdserv.udfnStockLocationList(varviewType, 0, 0, 0);
                objsdserv.CloseConnection();
                cmbDStockLocation.DataSource = null;
                if (objDS != null)
                {
                    if (objDS.Tables.Count > 0)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            cmbDStockLocation.ValueMember = "SLID";
                            cmbDStockLocation.DisplayMember = "SL_EName";
                            cmbDStockLocation.DataSource = objDS.Tables[0];
                        }
                    }
                }




                udfnCmbProductGroup();
                udfnCmbProductSubGroup();
                //udfnTotalSuppliers();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
        public void udfnCmbProductSubGroup()
        {
            try
            {
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();
                int varViewType = 5;
                if (varGroupId == 0)
                {
                    varViewType = 4;
                }
                objDT = objdserv.udfnSubGroupList(varViewType, 0, "",varGroupId, 0);
                objdserv.CloseConnection();
                cmbSubGroup.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbSubGroup.ValueMember = "PRSGID";
                            cmbSubGroup.DisplayMember = "PRSG_EName";
                            cmbSubGroup.DataSource = objDT.Tables[0];
                        }
                    }
                }
                objdserv.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_BrandList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    tsbEdit_Click(sender, e);
                }
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

        public void grdBrandList_DoubleClick(object sender, EventArgs e)
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

        public void grdBrandList_KeyDown(object sender, KeyEventArgs e)
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
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    dgv2.Rows[rowIndex].Cells[i].Value = "";
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        } 
        public void udfnscrollVisible(DataGridView DGV,DataGridView grdGroupList)
        {
            try
            {
                var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }

                     
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
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

        private void RbMove_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbAdd.Checked == true)
                {
                    grbDestination.Visible = false;
                }
                else
                {
                    grbDestination.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSStockLocation_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbSStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbSStockLocation.SelectedValue) == "" || Convert.ToString(cmbSStockLocation.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbSStockLocation, "Please select Stock Location");
                    cmbSStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please select Stock Location", cmbSStockLocation, 5000);
                }
                else
                {
                    epRackSettings.Clear();
                    cmbSStockLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSRack_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSRack_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbSRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbSRack.SelectedValue) == "" || Convert.ToString(cmbSRack.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbSRack, "Please select Rack");
                    cmbSRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please select Rack", cmbSRack, 5000);
                }
                else
                {
                    epRackSettings.Clear();
                    cmbSRack.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbDStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDStockLocation_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbDStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbDStockLocation.SelectedValue) == "" || Convert.ToString(cmbDStockLocation.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbDStockLocation, "Please select Stock Location");
                    cmbDStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please select Stock Location", cmbDStockLocation, 5000);
                }
                else
                {
                    epRackSettings.Clear();
                    cmbDStockLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDRack_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbDRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDRack_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbDRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbDRack.SelectedValue) == "" || Convert.ToString(cmbDRack.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbDRack, "Please select Rack");
                    cmbDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please select Rack", cmbDRack, 5000);
                }
                else
                {
                    epRackSettings.Clear();
                    cmbDRack.BackColor = Color.White;
                }
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;

                if (Convert.ToString(cmbSStockLocation.SelectedValue) == "" || Convert.ToString(cmbSStockLocation.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbSStockLocation, "Please select Stock Location");
                    cmbSStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please select Stock Location", cmbSStockLocation, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbDStockLocation.SelectedItem) == "" || Convert.ToString(cmbDStockLocation.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbDStockLocation, "Please select Stock Location");
                    cmbDStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please select Stock Location", cmbDStockLocation, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbSRack.SelectedValue) == "" || Convert.ToString(cmbSRack.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbSRack, "Please select Rack");
                    cmbSRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please select Rack", cmbSRack, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbDRack.SelectedItem) == "" || Convert.ToString(cmbDRack.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbDRack, "Please select Rack");
                    cmbDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please select Rack", cmbDRack, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnSave(object sender, EventArgs e)
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

        private void BtnSave_Enter(object sender, EventArgs e)
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

        private void BtnSave_Leave(object sender, EventArgs e)
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

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;

                if (Convert.ToString(cmbGroup.SelectedValue) == "" || Convert.ToString(cmbGroup.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbGroup, "Please select Product Group");
                    cmbGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductGroup.ShowAlways = true;
                    tpProductGroup.Show("Please select Product Group", cmbGroup, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbSubGroup.SelectedItem) == "" || Convert.ToString(cmbSubGroup.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbSubGroup, "Please select Product SubGroup");
                    cmbSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductSubGroup.ShowAlways = true;
                    tpProductSubGroup.Show("Please select Product SubGroup", cmbSubGroup, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    //btnSave.Enabled = false;
                    try
                    {
                        udfnList();
                        for (int j = 0; j < grdSupplierMapping.RowCount; j++)
                        {
                            if (Convert.ToString(grdViewSupplierMapping.Rows[j].Cells["PRODUCTID"].Value) == Convert.ToString(grdSupplierMapping.Rows[j].Cells["PRODUCTID"].Value))
                            {
                                grdSupplierMapping.Rows[j].Cells[0].Value = true;
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void udfnList()
        {
            try
            {
                int varViewType = 3;
                
                dtSupplierMapping.Rows.Clear();
                Application.DoEvents();
                grdSupplierMapping.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnproductmasterlist(varViewType, 0, 0, varGroupId,varSubGroupId, "", "", "", 0);
                objdserv.CloseConnection();

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtSupplierMapping.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["PRODUCTID"], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in English"],
                           objDs.Tables[0].Rows[i]["Product Name in Tamil"], objDs.Tables[0].Rows[i]["Unit"]);
                    }
                }
                grdSupplierMapping.DataSource = null;
                grdSupplierMapping.DataSource = dtSupplierMapping;
                grdSupplierMapping.Columns[0].HeaderText = "";
                grdSupplierMapping.Columns[0].Width = 50;
                grdSupplierMapping.Columns["S.No."].Width = 50;
                grdSupplierMapping.Columns["PRODUCTID"].Visible =false;
                grdSupplierMapping.Columns["P.I Code"].Width = 100;
                grdSupplierMapping.Columns["Product Name in English"].Width = 200;
                grdSupplierMapping.Columns["Product Name in Tamil"].Width = 200;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSStockLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSStockLocation.Select(int.MaxValue, 0)));
                varStockLocationId = Convert.ToInt16(cmbSStockLocation.SelectedValue);
                udfncmbRack();
                grdSupplierMapping.DataSource = null;
                grdViewSupplierMapping.Rows.Clear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfncmbRack()
        {


            DataSet objDS = new DataSet();
            SPDataService objsdserv = new SPDataService();
            int varviewType = 4;
            if (btnSave.Text == "Save")
            {
                varviewType = 3;
            }
            objDS = objsdserv.udfnRackList(varviewType, 0, 0, varStockLocationId, 0);
            objsdserv.CloseConnection();
            cmbSRack.DataSource = null;
            if (objDS != null)
            {
                if (objDS.Tables.Count > 0)
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        cmbSRack.ValueMember = "RKID";
                        cmbSRack.DisplayMember = "RK_Name";
                        cmbSRack.DataSource = objDS.Tables[0];
                    }
                }
            }


            /*
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varRackGroupID = 0;
                int varViewType = 2;
                if (btnSave.Text == "Save")
                {
                    if (varStockLocationId == -1)
                    {
                        varViewType = 3;
                    }
                    else { varViewType = 4; }
                }
                else
                {
                    if (varStockLocationId == -1)
                    {
                        varViewType = 3;
                    }
                    else { varViewType = 5; varRackGroupID = varId; }
                }
                objDT = objdserv.udfnStockLocationList(varViewType, varStockLocationId, varSRackId, varRackGroupID);
                objdserv.CloseConnection();
                cmbSRack.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbSRack.ValueMember = "RKID";
                            cmbSRack.DisplayMember = "RK_Name";
                            cmbSRack.DataSource = objDT.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            */
        }

        private void CmbSRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                varSRackId = Convert.ToInt32(cmbSRack.SelectedValue);
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
                udfnCmbProductSubGroup();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdSupplierMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    udfnCalculateCheckedCount();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnCalculateCheckedCount()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdSupplierMapping.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSupplierMapping.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        varCheckedCount++;
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
                if (grdSupplierMapping.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag = 1;
                    chkRackSettings.Checked = true;
                }
                else
                {
                    varCheckAllFlag = 1;
                    chkRackSettings.Checked = false;
                }
            }
        }

        private void CmbSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSubGroup.Select(int.MaxValue, 0)));
                varSubGroupId = Convert.ToInt32(cmbSubGroup.SelectedValue);
                //udfnCmbProductSubGroup();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkRackSettings_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (varCheckAllFlag != 1)
                {
                    for (int i = 0; i < grdSupplierMapping.Rows.Count; i++)
                    {
                        grdSupplierMapping.Rows[i].Cells[0].Value = chkRackSettings.Checked;
                    }
                }
                else
                {
                    varCheckAllFlag = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                udfnViewSupplier();
                //udfnTotalSuppliers();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnViewSupplier()
        {
            try
            {
                string varRemoveRack = "", varAddRack = "";

                if (grdSupplierMapping.Rows.Count > 0)
                {
                    for (int i = 0; i < grdSupplierMapping.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdSupplierMapping.Rows[i].Cells[0].Value) == true)
                        {
                            int varFlag = 0, varcount = 1; ;

                            for (int j = 0; j < grdViewSupplierMapping.Rows.Count; j++)
                            {
                                varAddRack = Convert.ToString(grdSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
                                if (varAddRack == Convert.ToString(grdViewSupplierMapping.Rows[j].Cells["PRODUCTID"].Value))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                grdViewSupplierMapping.Rows.Add(Convert.ToInt32(grdViewSupplierMapping.Rows.Count) + 1, grdSupplierMapping.Rows[i].Cells["P.I Code"].Value, grdSupplierMapping.Rows[i].Cells["Product Name in English"].Value,
                                    grdSupplierMapping.Rows[i].Cells["Product Name in Tamil"].Value, grdSupplierMapping.Rows[i].Cells["Unit"].Value);
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Please select atleast one row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTotalSuppliers()
        {
            int varCount = 0;
            try
            {
                if (grdViewSupplierMapping.Rows.Count != 0)
                {
                    for (int i = 0; i < grdViewSupplierMapping.RowCount; i++)
                    {
                        if (Convert.ToInt32(grdViewSupplierMapping.Rows[i].Cells["clmTotalProducts"].Value) != 0)
                        {
                            varCount = varCount + Convert.ToInt32(grdViewSupplierMapping.Rows[i].Cells["clmTotalProducts"].Value);
                        }
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

        private void GrdViewSupplierMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdViewSupplierMapping.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemoveSupplier":

                            grdViewSupplierMapping.Rows.RemoveAt(this.grdViewSupplierMapping.SelectedRows[0].Index);
                            for (int i = 0; i < grdViewSupplierMapping.RowCount; i++)
                            {
                                grdViewSupplierMapping.Rows[i].Cells["columnSNo"].Value = i + 1;
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

        private void TxtSearchByProduct1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSupplierMapping.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtSearchByProduct1.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSearchByProduct2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdViewSupplierMapping.DataSource as DataTable).DefaultView.RowFilter = "([clmProductEnglish]) LIKE '%" + txtSearchByProduct2.Text + "%'or ([clmdpicode]) LIKE '%" + txtSearchByProduct2.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDStockLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSStockLocation.Select(int.MaxValue, 0)));
                varStockLocationId = Convert.ToInt16(cmbSStockLocation.SelectedValue);
                udfncmbDRack();
                grdSupplierMapping.DataSource = null;
                grdViewSupplierMapping.Rows.Clear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfncmbDRack()
        {


            DataSet objDS = new DataSet();
            SPDataService objsdserv = new SPDataService();
            int varviewType = 4;
            if (btnSave.Text == "Save")
            {
                varviewType = 3;
            }
            objDS = objsdserv.udfnRackList(varviewType, 0, 0, varStockLocationId, 0);
            objsdserv.CloseConnection();
            cmbDRack.DataSource = null;
            if (objDS != null)
            {
                if (objDS.Tables.Count > 0)
                {
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        cmbDRack.ValueMember = "RKID";
                        cmbDRack.DisplayMember = "RK_Name";
                        cmbDRack.DataSource = objDS.Tables[0];
                    }
                }
            }
        }
        }
}
