using ROMS.Model;
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
    //Created By:- Sivabharathi
    //Created On:- 02-09-2023
    public partial class CP_RackSettings : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpDestinationLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tppRack = new ToolTip();
        private ToolTip tpProductGroup = new ToolTip();
        private ToolTip tppProductGroup = new ToolTip();
        private ToolTip tpProductSubGroup = new ToolTip();
        private ToolTip tppProductSubGroup = new ToolTip();

        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpSourceRack = new ToolTip();
        private ToolTip tpDestinationRack = new ToolTip();

        Boolean BlnSearchImageYN = false;
        public DataTable dtSupplierMapping = new DataTable();
        public DataTable dtViewProduct = new DataTable();
        public DataTable dtViewSupplierMapping = new DataTable();
        public DataTable dtMoveProduct = new DataTable();

        public int varId = 0, varUpDownKeySLocation = 0, varUpDownKeyDLocation;
        public int varGroupId = 0;
        public int varSubGroupId = 0;
        public int varCheckAllFlag = 0;
        public int varCheckAll = 0;
        public string varProductID = "";
        public int varUpdate = 0;
        public int varRacksettingID = 0;
        public int PbRKID = 0;
        public string PbStockLocation = "";
        public int PbLocationCode = 0;
        public string PbRackName = "";
        public string PbPICode = "";
        public string PbProductName = "";
        public string PbUnit = "";
        public int SearchFlag = 0;
        public int SearchFlag1 = 0;
        public int sourceFalg = 0,DestinationFlag=0;
        public int varSourceLocationID = 0, varDestinationLocationID = 0;
        public int varSourceRackID= 0, varDestinationRackID = 0;
        public string varRackid="0",varLocationid="0";
        public int productid = 0;

        public CP_RackSettings()
        {
            InitializeComponent();
            windowControl.Initialize(tsRackSettings, this);
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
        public void udfnGridColumn()
        {
            try
            {
                DGV_SearchGrid.Columns.Add("clmPIcode", "P.I Code");
                DGV_SearchGrid.Columns.Add("clmProductName", "Product Name in Tamil");
                DGV_SearchGrid.Columns.Add("clmUnit", "Unit");

                DGV_SearchGridMove.Columns.Add("clmRemove", "Remove");
                DGV_SearchGridMove.Columns.Add("clmPIcode", "P.I Code");
                DGV_SearchGridMove.Columns.Add("clmProductName", "Product Name in Tamil");
                DGV_SearchGridMove.Columns.Add("clmUnit", "Unit");
                DGV_SearchGridMove.Columns.Add("clmStock", "Stock Qty");

                DGV_SearchGrid.Columns["clmProductName"].Width = 250;

                DGV_SearchGridMove.Columns[0].Width = 50;
                DGV_SearchGridMove.Columns["clmPIcode"].Width = 100;
                DGV_SearchGridMove.Columns["clmStock"].Width = 80;
                DGV_SearchGridMove.Columns["clmUnit"].Width = 80;
                DGV_SearchGridMove.Columns["clmProductName"].Width = 250;

                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
                DGV_SearchGridMove.ScrollBars = ScrollBars.Both;

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
                //if (e.KeyCode == Keys.Escape)
                //{
                //    MainForm.objStart = new DEF_Start();
                //    MainForm.objStart.MdiParent = this.ParentForm;
                //    MainForm.objStart.Show();
                //    this.Close();
                //}
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
        public void udfnclose()
        {
            try
            {
                if (varUpdate == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //MainForm objMainForm = new MainForm();
                        //objMainForm.udfnCloseChildForms();
                        //MainForm.objStart = new DEF_Start();
                        //MainForm.objStart.MdiParent = this.ParentForm;
                        //MainForm.objStart.Show();
                        //this.Close();
                        windowControl?.TriggerClose();
                    }
                }
                else
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
        public void udfnclear()
        {
            txtSourceLocation.Text = "";
            varSourceLocationID = 0;
            varSourceRackID = 0;
            txtDestinationLocation.Text = "";
            varDestinationLocationID = 0;
            varDestinationRackID = 0;
            udfnCmbSourceRack();
            udfnCmbDestinationRack();
            grdViewProduct.DataSource = null;
            dtMoveProduct.Rows.Clear();
            dtMoveProduct.AcceptChanges();
            grdMoveProduct.DataSource = null;
            dtViewProduct.Rows.Clear();
            dtViewProduct.AcceptChanges();
            lblViewProductCount.Text = "0";
            lblMoveProCount.Text = "0";
            rbSales.Checked = true;
        } 
        public void udfnProductLoad()
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtSourceLocation.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtSourceLocation, "Please enter location.");
                    txtSourceLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location.", txtSourceLocation, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    udfnSLocationValidation();
                    if (sourceFalg == 0 && varSourceRackID != -1)
                    {
                        udfnMoveList();
                    }
                }
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLocationRack()
        {
            try
            {
                udfnSLocationValidation();
                if (sourceFalg == 0)
                {
                    int varRackCount = 0;
                    sourceFalg = 0;
                    /*check source location have a rack or not*/
                    string varId_SourceRack = "0";
                    DataSet objDsSourceRack = new DataSet();
                    SPDataService objDServ6 = new SPDataService();
                    objDsSourceRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(varSourceLocationID), 0, txtSourceRack.Text.Trim(), 0, 0);
                    objDServ6.CloseConnection();
                    if (varSourceLocationID!=0)
                    {
                        if (objDsSourceRack != null)
                        {
                            if (objDsSourceRack.Tables.Count > 0)
                            {
                                if (objDsSourceRack.Tables[1].Rows.Count > 0)
                                {
                                    varRackCount = Convert.ToInt32(objDsSourceRack.Tables[1].Rows[0][0]);
                                }
                                if (varRackCount != 0)
                                {
                                    if (objDsSourceRack.Tables.Count > 0)
                                    {
                                        if (objDsSourceRack.Tables[0].Rows.Count > 0)
                                        {
                                            varId_SourceRack = Convert.ToString(objDsSourceRack.Tables[0].Rows[0][0]);
                                        }
                                    }
                                   // varSourceLocationID = Convert.ToInt32(varId_SourceRack);
                                    if (Convert.ToInt32(varId_SourceRack) < 0)
                                    {
                                        epRackSettings.SetError(cmbSourceRack, "Please select valid rack.");
                                        cmbSourceRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                        tpRack.ShowAlways = true;
                                        tpRack.Show("Please select valid rack.", cmbSourceRack, 5000);
                                        sourceFalg = 1;
                                    }
                                }
                                else
                                {
                                    cmbSourceRack.Text = "None";
                                    cmbSourceRack.Enabled = false;
                                    varDestinationRackID=0;
                                    // txtDRack.ReadOnly = true;
                                    cmbSourceRack.BackColor = Color.White;
                                }
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
        public void udfnSLocationValidation()
        {
            try
            {
                sourceFalg = 0;
                //int varSLocationId = 0, varSRackId = 0;
                /* Check  source location is valid or not*/
                if (txtSourceLocation.Text != "")
                {
                    string varId_SourceLocation = "0";
                    DataSet objDsSourceLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 14;
                    objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Location.paraLocationName = txtSourceLocation.Text.Trim();
                    objDsSourceLoc = objDServ3.udfnStockLocationList(objMR_Location);
                    objDServ3.CloseConnection();

                    //objDsSourceLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSourceLocation.Text.Trim(), 0, 0, 0,"","",0);
                    if (objDsSourceLoc != null)
                    {
                        if (objDsSourceLoc.Tables.Count > 0)
                        {
                            if (objDsSourceLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_SourceLocation = Convert.ToString(objDsSourceLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varSourceLocationID = Convert.ToInt32(varId_SourceLocation);
                    if (varId_SourceLocation == "0" || varId_SourceLocation == "-1")
                    {
                        epRackSettings.SetError(txtSourceLocation, "Please select valid stock location.");
                        txtSourceLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please select valid stock location.", txtSourceLocation, 5000);
                        sourceFalg = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDLocationValidation()
        {
            try
            {
                DestinationFlag = 0;
                //int varSLocationId = 0, varSRackId = 0;
                /* Check  source location is valid or not*/
                if (txtDestinationLocation.Text != "")
                {
                    string varId_DestinationLocation = "0";
                    DataSet objDsDestinationLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();

                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 14;
                    objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Location.paraLocationName = txtDestinationLocation.Text.Trim();
                    objDsDestinationLoc = objDServ3.udfnStockLocationList(objMR_Location);
                    objDServ3.CloseConnection();
                    //objDsDestinationLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtDestinationLocation.Text.Trim(), 0, 0, 0,"","",0);
                    if (objDsDestinationLoc != null)
                    {
                        if (objDsDestinationLoc.Tables.Count > 0)
                        {
                            if (objDsDestinationLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_DestinationLocation = Convert.ToString(objDsDestinationLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    varDestinationLocationID = Convert.ToInt32(varId_DestinationLocation);
                    if (varId_DestinationLocation == "0" || varId_DestinationLocation == "-1")
                    {
                        epRackSettings.SetError(txtDestinationLocation, "Please select valid destination location.");
                        txtDestinationLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpDestinationLocation.ShowAlways = true;
                        tpDestinationLocation.Show("Please select valid destination location.", txtDestinationLocation, 5000);
                        DestinationFlag = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSLocationEvent()
        {
            try
            {
                if (txtSourceLocation.Text != "")
                {
                    txtSourceLocation.Text = DGV_FilterSLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                    varSourceLocationID = Convert.ToInt32(DGV_FilterSLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtDestinationLocation.Text = DGV_FilterSLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                    varDestinationLocationID = Convert.ToInt32(DGV_FilterSLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDLocationEvent()
        {
            try
            {
                if (txtDestinationLocation.Text != "")
                {
                    varDestinationLocationID = Convert.ToInt32(DGV_FilterDLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtDestinationLocation.Text = DGV_FilterDLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
            }
        }
        private void BtnDesignationView_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtDLocation.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtDLocation, "Please enter location.");
                    txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location.", txtDLocation, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag==false)
                {
                    udfnLocationRack();
                    if (sourceFalg == 0)
                    {
                        udfnMoveList();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdViewProduct, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdViewProduct.Columns)
                {
                    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                if (DGV_SearchGrid.ColumnCount > 1)
                {
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    for (int i = 0; i < visibleColumns.Count; i++)
                    {
                        if (i == 0)
                        { DGV_SearchGrid.Rows[0].Cells[i].ReadOnly = true; }
                        else
                        { DGV_SearchGrid.Rows[0].Cells[i].ReadOnly = false; }
                    }
                    DGV_SearchGrid.Columns[0].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnGridSearchHeadMove(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                DGV_SearchGridMove.ReadOnly = false;
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
                BlnSearchImageYN = false;
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                    if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                    {
                        //dgv2.Rows[rowIndex].Visible = false;
                        BlnSearchImageYN = true;
                        ColIndex = i;
                        dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                        dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                        ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                    }
                    else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                    {
                        BlnSearchImageYN = true;
                        dgv2.Rows[rowIndex].Cells[i].Value = false;
                    }
                    else
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnSearchGridHeadMove()
        {
            try
            {
                udfnGridSearchHeadMove(grdMoveProduct, DGV_SearchGridMove);
                DGV_SearchGridMove.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdMoveProduct.Columns)
                {
                    DGV_SearchGridMove.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                int rowIndex = 0;
                DGV_SearchGridMove.Rows.Clear();
                DGV_SearchGridMove.Rows.Add();
                DGV_SearchGridMove.Columns[0].DefaultCellStyle.NullValue = null;
                DGV_SearchGridMove.Columns[1].DefaultCellStyle.NullValue = null;
                for (int i = 2; i < visibleColumns.Count; i++)
                {
                    DGV_SearchGridMove.Rows[rowIndex].Cells[i].Value = "";
                }
                //DGV_SearchGridMove.Columns["S.No."].ReadOnly = true;
             //   DGV_SearchGridMove.Columns[0].ReadOnly = true;
                //DGV_SearchGridMove.Columns[1].ReadOnly = true;
                DGV_SearchGridMove.Rows[0].Cells[0].Value = new Bitmap(1, 1);
               // DGV_SearchGridMove.Rows[0].Cells[1].Value = new Bitmap(1, 1);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
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
        public void udfnSourceLocationRack()
        {
            try
            {
                sourceFalg = 0;
                int varDLocationId = 0, varDRackId = 0;
                bool blnErrorFlag = false;
                string varGroupId = "0";
                if (txtGroup.Text == "")
                {
                    varGroupId = "0";
                }
                else
                {
                    /* Check product group is valid or not*/
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
                                varGroupId = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblProductGroupId.Text = Convert.ToString(varGroupId);
                    if (lblProductGroupId.Text == "-1")
                    {
                        epRackSettings.SetError(txtGroup, "Please select valid group.");
                        txtGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppProductGroup.ShowAlways = true;
                        tppProductGroup.Show("Please select valid group.", txtGroup, 5000);
                    }
                }
                string varSubGroupId = "0";
                if (txtSubGroup.Text == "")
                {
                    varSubGroupId = "0";
                }
                else
                {
                    /* Check product sub group is valid or not*/
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
                                varSubGroupId = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblProductSubGroupId.Text = Convert.ToString(varSubGroupId);
                    if (lblProductSubGroupId.Text == "-1")
                    {
                        epRackSettings.SetError(txtSubGroup, "Please select valid subgroup.");
                        txtSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppProductSubGroup.ShowAlways = true;
                        tppProductSubGroup.Show("Please select valid subgroup.", txtSubGroup, 5000);
                    }
                }
                udfnLocationRack();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnMoveList()
        {
            try
            {
               // udfnSourceLocationRack();
                if (sourceFalg==0)
                {
                    dtViewProduct.Rows.Clear();
                    dtViewProduct.AcceptChanges();
                    grdViewProduct.DataSource = null;
                    string varProductID = "";
                    if (productid==1)
                    {
                       if(grdMoveProduct.Rows.Count!=0)
                       {
                            for (int i = 0; i < grdMoveProduct.RowCount; i++)
                            {
                                if (varProductID == "")
                                {
                                    varProductID = Convert.ToString(grdMoveProduct.Rows[i].Cells["PRID"].Value);
                                }
                                else
                                {
                                    varProductID = varProductID + "," + Convert.ToString(grdMoveProduct.Rows[i].Cells["PRID"].Value);
                                }
                            }
                       }
                    }
                    else
                    {
                        dtViewProduct.Rows.Clear();
                        dtViewProduct.AcceptChanges();
                        dtMoveProduct.Rows.Clear();
                        dtMoveProduct.AcceptChanges();
                        grdMoveProduct.DataSource = null;
                        grdViewProduct.DataSource = null;
                    }
                    int varId = 0;
                    if(rbSales.Checked==true)
                    { varId = 1; }
                    else if(rbPurchase.Checked==true)
                    { varId = 2; }
                    int varViewType = 14;
                   
                    Application.DoEvents();
                    
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = varViewType;
                    objMR_Product.paraGroup = Convert.ToInt32(lblProductGroupId.Text);
                    objMR_Product.paraSubgroup = Convert.ToInt32(lblProductSubGroupId.Text);
                    objMR_Product.paraRackId = Convert.ToInt32(varSourceRackID);
                    objMR_Product.paraLocationId = Convert.ToInt32(varSourceLocationID);
                    objMR_Product.@ParaProductsCode = varProductID;
                    objMR_Product.paraId = varId;
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    objDs = objdserv.udfnproductmasterlist(objMR_Product);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                dtViewProduct.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in English"],
                                   objDs.Tables[0].Rows[i]["Product Name in Tamil"], objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["PRID"], Convert.ToDecimal(objDs.Tables[0].Rows[i]["Stock Qty"]));
                            }
                        }
                        grdViewProduct.DataSource = null;
                        grdViewProduct.DataSource = dtViewProduct;
                        grdViewProduct.Columns[0].HeaderText = "";
                        grdViewProduct.Columns[0].Width = 40;
                        grdViewProduct.Columns["S.No."].Width = 50;
                        //grdViewProduct.Columns["PRODUCTID"].Visible = false;
                        grdViewProduct.Columns["P.I Code"].Width = 100;
                        grdViewProduct.Columns["Stock Qty"].Width = 80;
                        grdViewProduct.Columns["Unit"].Width = 80;
                        //grdViewProduct.Columns["Stock Qty"].Width = 100;
                        grdViewProduct.Columns["Product Name in English"].Width = 250;
                        grdViewProduct.Columns["Product Name in Tamil"].Width = 300;
                        grdViewProduct.Columns["S.No."].ReadOnly = true;
                        grdViewProduct.Columns["P.I Code"].ReadOnly = true;
                        grdViewProduct.Columns["Product Name in English"].ReadOnly = true;
                        grdViewProduct.Columns["Product Name in Tamil"].ReadOnly = true;
                        grdViewProduct.Columns["Product Name in English"].Visible = false;
                        grdViewProduct.Columns["Unit"].ReadOnly = true;
                        grdViewProduct.Columns["Stock Qty"].ReadOnly = true;
                        grdViewProduct.Columns["PRODUCTID"].Visible = false;
                        grdViewProduct.Columns["S.No."].Visible = false;
                        grdViewProduct.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                        udfnSearchGridHead();
                    }
                }
                SearchFlag = 1;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblViewProductCount.Text = Convert.ToString(grdViewProduct.Rows.Count);
                lblMoveProCount.Text = Convert.ToString(grdMoveProduct.Rows.Count);
            }
        }
        
        private void TxtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                lvProductSubGroup.Visible = false;
                txtGroup.BackColor = Color.LemonChiffon;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvProductGroup.Items.Count == 0 || txtGroup.Text == "")
                    {
                        txtGroup.Focus();
                        //lvGroup.Visible = false;
                    }
                    else
                    {
                        lvProductGroup.Focus();
                    }
                    if (lvProductGroup.Items.Count > 0)
                    {
                        lvProductGroup.Items[0].Selected = true;
                    }
                }
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
        private void TxtGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.White;
                if (txtGroup.Text.Trim() == "") { lblProductGroupId.Text = "0"; }
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
                lvProductGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtGroup.Text,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvProductGroup.Columns[2].Width = 200;
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvProductGroup.Items.Add(objList);
                                }
                                lvProductGroup.Visible = true;
                            }
                            else
                            {
                                lvProductGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvProductGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvProductGroup.Visible = false;
                    }
                }
                else
                {
                    lvProductGroup.Visible = false;
                    lvProductGroup.Items.Clear();
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
        private void TxtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                lvProductGroup.Visible = false;
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvProductSubGroup.Items.Count == 0 || txtSubGroup.Text == "")
                    {
                        txtSubGroup.Focus();
                        lvProductSubGroup.Visible = false;
                    }
                    else
                    {
                        lvProductSubGroup.Focus();
                    }
                    if (lvProductSubGroup.Items.Count > 0)
                    {
                        lvProductSubGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnProductView.Focus();
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
                txtSubGroup.BackColor = Color.White;
                if (txtSubGroup.Text.Trim() == "") { lblProductSubGroupId.Text = "0"; }
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
                lvProductSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblProductGroupId.Text), 0, txtSubGroup.Text, 0, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvProductSubGroup.Columns[2].Width = 200;
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvProductSubGroup.Items.Add(objList);
                                }
                                lvProductSubGroup.Visible = true;
                            }
                            else
                            {
                                lvProductSubGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvProductSubGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvProductSubGroup.Visible = false;
                    }
                }
                else
                {
                    lvProductSubGroup.Visible = false;
                    lvProductSubGroup.Items.Clear();
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
        private void BtnProductView_Click(object sender, EventArgs e)
        {
            try
            {
                productid = 1;
                udfnProductLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnProductView_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                lvProductGroup.Visible = false;
                lvProductSubGroup.Visible = false;
                btnProductView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnProductView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnProductView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvProductGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnProductGroupevent();
                txtSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductGroupevent();
                    txtSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductGroupevent()
        {
            try
            {
                if (txtGroup.Text != "")
                {
                    ListViewItem selectedItem = lvProductGroup.SelectedItems[0];
                    lblProductGroupId.Text = selectedItem.SubItems[1].Text;
                    txtGroup.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvProductGroup.Visible = false;
            }
        }
        private void LvProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductSubGroupevent();
                    btnProductView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvProductSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnProductSubGroupevent();
                btnProductView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductSubGroupevent()
        {
            try
            {
                if (txtSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvProductSubGroup.SelectedItems[0];
                    lblProductSubGroupId.Text = selectedItem.SubItems[1].Text;
                    txtSubGroup.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvProductSubGroup.Visible = false;
            }
        }
        private void TxtSearchProductName1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchProductName1.BackColor = Color.LemonChiffon;
                for (int i = 1; i < DGV_SearchGrid.ColumnCount; i++)
                {
                    DGV_SearchGrid.Rows[0].Cells[i].Value = "";
                }
                DGV_SearchGrid_CurrentCellDirtyStateChanged(sender, e);
                //SearchFlag = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProductName1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchProductName1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProductName1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SearchFlag == 1)
                {
                    (grdViewProduct.DataSource as BindingSource).Filter = "([Product Name in English]) LIKE '%" + txtSearchProductName1.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchProductName1.Text + "%' ";
                }
                else
                {
                    (grdViewProduct.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtSearchProductName1.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchProductName1.Text + "%' ";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblViewProductCount.Text = Convert.ToString(grdViewProduct.Rows.Count);
            }
        }
        private void TxtSearchProductName2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchProductName2.BackColor = Color.LemonChiffon;
                for (int i = 1; i < DGV_SearchGridMove.ColumnCount; i++)
                {
                    DGV_SearchGridMove.Rows[0].Cells[i].Value = "";
                }
                DGV_SearchGridMove_CurrentCellDirtyStateChanged(sender, e);
              //  SearchFlag1 = 0;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProductName2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchProductName2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProductName2_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // (grdMoveProduct.DataSource as BindingSource).Filter = "([Product Name in English]) LIKE '%" + txtSearchProductName2.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchProductName2.Text + "%' ";
                if (SearchFlag1 == 1)
                {
                    (grdMoveProduct.DataSource as BindingSource).Filter = "([Product Name in English]) LIKE '%" + txtSearchProductName2.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchProductName2.Text + "%' ";
                }
                else
                {
                    (grdMoveProduct.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtSearchProductName2.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchProductName2.Text + "%' ";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { lblMoveProCount.Text = Convert.ToString(grdMoveProduct.Rows.Count); }
        }
        private void GrdViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    udfnCalCheckedCount();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnCalCheckedCount()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdViewProduct.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdViewProduct.Rows[i].Cells[0].EditedFormattedValue) == true)
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
                if (grdViewProduct.Rows.Count == varCheckedCount)
                {
                    varCheckAll = 1;
                    checkAll.Checked = true;
                }
                else
                {
                    varCheckAll = 1;
                    checkAll.Checked = false;
                }
            }
        }
        private void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void BtnAddgrid_Click(object sender, EventArgs e)
        {
            try
            {
                udfnMoveProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void RemoveProduct()
        {
            try
            {
                string varRemoveGroup = "";
                for (int j = 0; j < dtMoveProduct.Rows.Count; j++)
                {
                    varRemoveGroup = Convert.ToString(grdMoveProduct.Rows[j].Cells["PRID"].Value);
                    for (int i = 0; i < dtViewProduct.Rows.Count; i++)
                    {
                        if (varRemoveGroup == Convert.ToString(dtViewProduct.Rows[i]["PRODUCTID"]))
                        {
                            dtViewProduct.Rows[i].Delete();
                            dtViewProduct.AcceptChanges();
                        }
                    }
                }
               // grdViewProduct.DataSource = dtViewProduct;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnMoveProduct()
        {
            try
            {
                string varRemoveRack = "", varAddRack = "";

                if (grdViewProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < grdViewProduct.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdViewProduct.Rows[i].Cells[0].Value) == true)
                        {
                            int varFlag = 0, varcount = 1; 

                            for (int j = 0; j < dtMoveProduct.Rows.Count; j++)
                            {
                                varAddRack = Convert.ToString(grdViewProduct.Rows[i].Cells["PRODUCTID"].Value);
                                if (varAddRack == Convert.ToString(dtMoveProduct.Rows[j]["PRID"]))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                dtMoveProduct.Rows.Add(grdViewProduct.Rows[i].Cells["P.I Code"].Value, grdViewProduct.Rows[i].Cells["Product Name in English"].Value,
                                    grdViewProduct.Rows[i].Cells["Product Name in Tamil"].Value, grdViewProduct.Rows[i].Cells["Unit"].Value, grdViewProduct.Rows[i].Cells["PRODUCTID"].Value, Convert.ToDecimal(grdViewProduct.Rows[i].Cells["Stock Qty"].Value));
                            }
                        }
                        else
                        {
                            for (int j = 0; j < dtMoveProduct.Rows.Count; j++)
                            {
                                varRemoveRack = Convert.ToString(grdViewProduct.Rows[i].Cells["PRODUCTID"].Value);
                                if (varRemoveRack == Convert.ToString(dtMoveProduct.Rows[j]["PRID"]))
                                {
                                    dtMoveProduct.Rows[j].Delete();
                                    dtMoveProduct.AcceptChanges();
                                }
                            }
                        }
                    }
                    grdMoveProduct.DataSource = null;
                    grdMoveProduct.DataSource = dtMoveProduct;
                   // grdMoveProduct.Columns["clmRemoveProduct"].DisplayIndex = 5;
                    grdMoveProduct.Columns["PRID"].Visible = false;
                    grdMoveProduct.Columns["P.I Code"].Width = 100;
                    //grdMoveProduct.Columns["Product Name in English"].Width = 250;
                    grdMoveProduct.Columns["Product Name in Tamil"].Width = 250;
                    grdMoveProduct.Columns["Stock Qty"].Width = 80;
                    //grdMoveProduct.Columns["P.I Code"].ReadOnly = true;
                    //grdMoveProduct.Columns["Product Name in English"].ReadOnly = true;
                    //grdMoveProduct.Columns["Product Name in Tamil"].ReadOnly = true;
                    //grdMoveProduct.Columns["Unit"].ReadOnly = true;
                    grdMoveProduct.Columns[0].ReadOnly = false;
                    grdMoveProduct.Columns["Product Name in English"].Visible = false;
                    RemoveProduct();
                    grdMoveProduct.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                    udfnSearchGridHeadMove();
                    SearchFlag1 = 1;
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblMoveProCount.Text = Convert.ToString(grdMoveProduct.Rows.Count);
                lblViewProductCount.Text = Convert.ToString(grdViewProduct.Rows.Count);
            }
        }

        private void BtnMoveSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (grdMoveProduct.Rows.Count > 0)
                {
                    udfnSLocationValidation();
                    udfnDLocationValidation();
                   // if (Convert.ToString(cmbSourceRack.SelectedValue) == "" || Convert.ToString(cmbSourceRack.SelectedValue) == "-1")
                    if ( Convert.ToString(cmbSourceRack.SelectedValue) == "-1")
                    {
                        epRackSettings.SetError(cmbSourceRack, "Please select source rack.");
                        cmbSourceRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSourceRack.ShowAlways = true;
                        tpSourceRack.Show("Please select source rack.", cmbSourceRack, 5000);
                        sourceFalg = 1;
                    }
                    //if (Convert.ToString(cmbDestinationRack.SelectedValue) == "" || Convert.ToString(cmbDestinationRack.SelectedValue) == "-1")
                    if (Convert.ToString(cmbDestinationRack.SelectedValue) == "-1")
                    {
                        epRackSettings.SetError(cmbDestinationRack, "Please select destination rack.");
                        cmbDestinationRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpDestinationRack.ShowAlways = true;
                        tpDestinationRack.Show("Please select destination rack.", cmbDestinationRack, 5000);
                        DestinationFlag = 1;
                    }
                    if (varSourceRackID!=-1 && varDestinationRackID!=-1 && sourceFalg==0 && DestinationFlag==0)
                    {
                        udfnMoveSave(sender, e);
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                    //if(txtDRack.Text.Trim()==txtMoveRack.Text.Trim())
                    //{
                    //    txtMoveRack.Text = "";
                    //    blnErrorFlag = true;
                    //}
                    //if (blnErrorFlag == false)
                    //{
                    //    btnMoveSave.Enabled = false;
                    //    udfnMoveSave(sender, e);
                    //}
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
        }
        public void udfnMoveSave(object sender, EventArgs e)
        {
            try
            {
                if (varSourceLocationID == varDestinationLocationID && varSourceRackID == varDestinationRackID)
                {
                    MessageBox.Show("Source and destination should not be same.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtSearchProductName2.Text = "";
                    string varResult = "",
                    varoriginator = ""; int varType = 13, varFlag = 0;
                    varProductID = "";
                    for (int i = 0; i < grdMoveProduct.RowCount; i++)
                    {
                        if (varProductID == "")
                        {
                            varProductID = Convert.ToString(grdMoveProduct.Rows[i].Cells["PRID"].Value);
                        }
                        else
                        {
                            varProductID = varProductID + "," + Convert.ToString(grdMoveProduct.Rows[i].Cells["PRID"].Value);
                        }
                    }
                    SPDataService objspservice = new SPDataService();
                    if (rbSales.Checked == true)
                    {
                        varFlag = 2;
                        varResult = objspservice.udfnProductMaster(varType, 0, "", "", "", 0, 0, 0, 0, 0, 0, 0, "", varSourceLocationID, varDestinationLocationID, varSourceRackID, varDestinationRackID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, varoriginator, 0, null, varFlag, varProductID,0,0,0,0,0, null, "", "","",0,"", "", 0, 0, 0, null, 0, 0, 0, 0, null,0,"");
                        objspservice.CloseConnection();
                    }
                    else if (rbPurchase.Checked == true)
                    {
                        varFlag = 1;
                        varResult = objspservice.udfnProductMaster(varType, 0, "", "", "", 0, 0, 0, 0, 0, 0, 0, "",varSourceLocationID, varDestinationLocationID, varSourceRackID, varDestinationRackID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, varoriginator, 0, null, varFlag, varProductID,0,0,0,0,0, null, "", "","",0,"", "", 0, 0, 0, null, 0, 0, 0, 0, null,0,"");
                        objspservice.CloseConnection();
                    }
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnclear();
                        txtSourceLocation.Focus();
                    }
                    else
                    {
                        MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnMoveSave.Enabled = true;
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
                btnMoveSave.Focus();
            }
            finally
            {
                btnMoveSave.Enabled = true;
            }
        }
        private void BtnMoveSave_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                btnMoveSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnMoveSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnMoveSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnMoveClose_Click(object sender, EventArgs e)
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
        public void udfnMoveRackEvent()
        {
            try
            {
                //if (txtMoveRack.Text != "")
                //{
                //    ListViewItem selectedItem = lvMoveRack.SelectedItems[0];
                //    txtMoveRack.Text = selectedItem.SubItems[1].Text;
                //    lblMoveRack.Text = selectedItem.SubItems[2].Text;
                //}

                int varRackCount = 0;
                //grdMoveProduct.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnRackSettingsList(2, 0, 0, 0, Convert.ToInt32(lblMoveRack.Text));
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varRackCount = Convert.ToInt32(objDs.Tables[0].Rows[0][0]);
                        }
                    }
                }
                //lblMoveRack.Text = Convert.ToString(varRackCount);

                if (varRackCount != 0)
                {
                    grdMoveProduct.DataSource = null;
                    //dtMoveProduct.Rows.Clear();
                    udfnMove(Convert.ToInt32(lblMoveLocation.Text), Convert.ToInt32(lblMoveRack.Text));
                }
                else
                {
                    grdMoveProduct.DataSource = null;
                    //dtMoveProduct.Rows.Clear();
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
        private void udfnMove(int locationcode, int rackcode)
        {
            try
            {
                int varViewType = 1;
                //dtSupplierMapping.Rows.Clear();
                grdMoveProduct.DataSource = null;
                dtMoveProduct.Rows.Clear();
                Application.DoEvents();
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();

                objDs = objdserv.udfnRackSettingsList(varViewType, 0, 0, locationcode, rackcode);
                objdserv.CloseConnection();
                
                if (objDs.Tables[1].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                    {
                        dtMoveProduct.Rows.Add(objDs.Tables[1].Rows[i]["P.I Code"], objDs.Tables[1].Rows[i]["Product Name in English"],
                           objDs.Tables[1].Rows[i]["Product Name in Tamil"], objDs.Tables[1].Rows[i]["Unit"], objDs.Tables[1].Rows[i]["PRID"]);
                    }
                }

                grdMoveProduct.DataSource = null;
                grdMoveProduct.DataSource = dtMoveProduct;
                grdMoveProduct.Columns["clmRemoveProduct"].DisplayIndex = 5;
                grdMoveProduct.Columns["PRID"].Visible = false;
                grdMoveProduct.Columns["P.I Code"].Width = 100;
                grdMoveProduct.Columns["Product Name in English"].Width = 250;
                grdMoveProduct.Columns["Product Name in Tamil"].Width = 250;
                grdMoveProduct.Columns["P.I Code"].ReadOnly = true;
                grdMoveProduct.Columns["Product Name in English"].ReadOnly = true;
                grdMoveProduct.Columns["Product Name in Tamil"].ReadOnly = true;
                grdMoveProduct.Columns["Unit"].ReadOnly = true;
                grdMoveProduct.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdMoveProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdMoveProduct.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemoveProduct":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                dtViewProduct.Rows.Add(false,grdViewProduct.Rows.Count+1,grdMoveProduct.SelectedRows[0].Cells["P.I Code"].Value, grdMoveProduct.SelectedRows[0].Cells["Product Name in English"].Value,
                                   grdMoveProduct.SelectedRows[0].Cells["Product Name in Tamil"].Value, grdMoveProduct.SelectedRows[0].Cells["Unit"].Value, grdMoveProduct.SelectedRows[0].Cells["PRID"].Value, Convert.ToDecimal(grdMoveProduct.SelectedRows[0].Cells["Stock Qty"].Value));
                                dtViewProduct.AcceptChanges();
                                grdMoveProduct.DataSource = null;
                                grdMoveProduct.DataSource = dtMoveProduct;
                                // grdMoveProduct.Columns["clmRemoveProduct"].DisplayIndex = 5;
                                grdMoveProduct.Columns["PRID"].Visible = false;
                                grdMoveProduct.Columns["Product Name in English"].Visible = false;
                                grdMoveProduct.Columns["P.I Code"].Width = 100;
                                //grdMoveProduct.Columns["Product Name in English"].Width = 250;
                                grdMoveProduct.Columns["Product Name in Tamil"].Width = 250;
                                grdMoveProduct.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                grdMoveProduct.Columns["Stock Qty"].Width = 80;
                                //grdMoveProduct.Columns["P.I Code"].ReadOnly = true;
                                //grdMoveProduct.Columns["Product Name in English"].ReadOnly = true;
                                //grdMoveProduct.Columns["Product Name in Tamil"].ReadOnly = true;
                                //grdMoveProduct.Columns["Unit"].ReadOnly = true;
                                grdMoveProduct.Columns[0].ReadOnly = false;
                                grdMoveProduct.Columns["Stock Qty"].ReadOnly = true;
                                grdMoveProduct.Rows.RemoveAt(this.grdMoveProduct.SelectedRows[0].Index);
                                //for (int i = 0; i < grdMoveProduct.RowCount; i++)
                                //{
                                //    grdMoveProduct.Rows[i].Cells["sno"].Value = i + 1;
                                //}
                                lblMoveProCount.Text =Convert.ToString(grdMoveProduct.Rows.Count);
                                lblViewProductCount.Text =Convert.ToString(grdViewProduct.Rows.Count);
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
        private void CP_RackSettings_Leave(object sender, EventArgs e)
        {
            try
            {
                tpStockLocation.Active = false;
                tpDestinationLocation.Active = false;
                tpRack.Active = false;
                tppRack.Active = false;
                tpProductGroup.Active = false;
                tppProductGroup.Active = false;
                tpProductSubGroup.Active = false;
                tppProductSubGroup.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {

        }
        

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
          
        }
           
        private void BtnSubGrupUnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdViewProduct.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupUnSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                btnSubGrupUnSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupUnSelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnUnselectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupUnSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSubGrupUnSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdViewProduct.Rows.Count; i++)
                {
                    grdViewProduct.Rows[i].Cells[0].Value = checkAll.Checked;
                }

                foreach (DataGridViewRow row in grdViewProduct.Rows)
                {
                    row.Cells[0].Value = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                BtnProductSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnProductSelectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                BtnProductSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdViewProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdViewProduct);
                objDser.CloseConnection();
                grdViewProduct.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            finally { SearchFlag = 1; }
        }
        private void DGV_SearchGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
            }
        }
        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0))   /*If not our desired columns*/ //return;
                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 0)
                {
                    DataGridViewColumn newColumn = grdViewProduct.Columns[e.ColumnIndex];
                    DataGridViewColumn oldColumn = grdViewProduct.SortedColumn;
                    ListSortDirection direction;
                    // If oldColumn is null, then the DataGridView is not sorted.
                    if (oldColumn != null)
                    {
                        // Sort the same column again, reversing the SortOrder.
                        if (oldColumn == newColumn &&
                            grdViewProduct.SortOrder == SortOrder.Ascending)
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
                    grdViewProduct.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdViewProduct.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdViewProduct.ColumnCount > 0)
                {
                    grdViewProduct.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdViewProduct.HorizontalScrollingOffset;
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
                txtSearchProductName1.Text = "";
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                DataService objDser = new DataService();
                grdViewProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdViewProduct);
                objDser.CloseConnection();
                grdViewProduct.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                lblViewProductCount.Text = grdViewProduct.Rows.Count.ToString();
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdViewProduct.RowCount; i++)
                {
                    if (Convert.ToString(grdViewProduct.Rows[i].Cells["MappedCount"].Value) != "0")
                    {
                        grdViewProduct.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
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
                grdViewProduct.ClearSelection();
            }
        }
        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdViewProduct.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdViewProduct.Width > grdViewProduct.HorizontalScrollingOffset && grdViewProduct.HorizontalScrollingOffset > 0)
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
        private void GrdViewProduct_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdViewProduct.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdViewProduct.Width > grdViewProduct.HorizontalScrollingOffset && grdViewProduct.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdViewProduct);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisibleMOve(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdMoveProduct.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGridMove.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGridMove.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGridMove.Rows[rowIndex].Cells[i].Value = "";
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
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdViewProduct.Controls.OfType<VScrollBar>().First();
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
        private void GrdViewProduct_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdViewProduct.IsCurrentCellDirty)
                {
                    grdViewProduct.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGridMove_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdMoveProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridMove, grdMoveProduct);
                objDser.CloseConnection();
                grdMoveProduct.HorizontalScrollingOffset = DGV_SearchGridMove.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
            finally { SearchFlag1 = 1; }
        }

        private void DGV_SearchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGV_SearchGridMove_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

                DGV_SearchGridMove.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridMove_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewColumn newColumn = grdMoveProduct.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdMoveProduct.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdMoveProduct.SortOrder == SortOrder.Ascending)
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
                grdMoveProduct.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGridMove.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGridMove.HorizontalScrollingOffset = grdMoveProduct.HorizontalScrollingOffset;
                DGV_SearchGridMove.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridMove_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdMoveProduct.ColumnCount > 0)
                {
                    grdMoveProduct.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGridMove.HorizontalScrollingOffset = grdMoveProduct.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGridMove_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                txtSearchProductName2.Text = "";
                if (DGV_SearchGridMove.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGridMove.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdMoveProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridMove, grdMoveProduct);
                objDser.CloseConnection();
                grdMoveProduct.HorizontalScrollingOffset = DGV_SearchGridMove.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lblMoveProCount.Text = Convert.ToString(grdMoveProduct.Rows.Count);
            }
        }
        private void DGV_SearchGridMove_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdMoveProduct.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGridMove, grdMoveProduct);
                objDser.CloseConnection();
                grdMoveProduct.HorizontalScrollingOffset = DGV_SearchGridMove.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGridMove_Scroll(object sender, ScrollEventArgs e)
        {
           try
            {
                int totalWidth = 0;
                int offSetValue = grdMoveProduct.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridMove.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdMoveProduct.Width > grdMoveProduct.HorizontalScrollingOffset && grdMoveProduct.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridMove.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridMove.Invalidate();
                udfnscrollVisibleMOve(DGV_SearchGridMove, grdMoveProduct);

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdMoveProduct_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdMoveProduct.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGridMove.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdMoveProduct.Width > DGV_SearchGridMove.HorizontalScrollingOffset && grdMoveProduct.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGridMove.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGridMove.Invalidate();
                udfnscrollVisibleMOve(DGV_SearchGridMove, grdMoveProduct);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_RackSettings_Load(object sender, EventArgs e)
        {
            try
            {
                dtSupplierMapping = new DataTable();
                dtSupplierMapping.Columns.Add("", typeof(Boolean));
                dtSupplierMapping.Columns.Add("S.No.", typeof(string));
                dtSupplierMapping.Columns.Add("P.I Code", typeof(string));
                dtSupplierMapping.Columns.Add("Product Name in English", typeof(string));
                dtSupplierMapping.Columns.Add("Product Name in Tamil", typeof(string));
                dtSupplierMapping.Columns.Add("Unit", typeof(string));
                dtSupplierMapping.Columns.Add("PRODUCTID", typeof(int));

                dtViewSupplierMapping = new DataTable();
                dtViewSupplierMapping.Columns.Add("P.I Code", typeof(string));
                dtViewSupplierMapping.Columns.Add("Product Name in English", typeof(string));
                dtViewSupplierMapping.Columns.Add("Product Name in Tamil", typeof(string));
                dtViewSupplierMapping.Columns.Add("Unit", typeof(string));
                dtViewSupplierMapping.Columns.Add("PRID", typeof(int));

                dtViewProduct = new DataTable();
                dtViewProduct.Columns.Add("", typeof(Boolean));
                dtViewProduct.Columns.Add("S.No.", typeof(string));
                dtViewProduct.Columns.Add("P.I Code", typeof(string));
                dtViewProduct.Columns.Add("Product Name in English", typeof(string));
                dtViewProduct.Columns.Add("Product Name in Tamil", typeof(string));
                dtViewProduct.Columns.Add("Unit", typeof(string));
                dtViewProduct.Columns.Add("PRODUCTID", typeof(int));
                dtViewProduct.Columns.Add("Stock Qty", typeof(decimal));

                dtMoveProduct = new DataTable();
                dtMoveProduct.Columns.Add("P.I Code", typeof(string));
                dtMoveProduct.Columns.Add("Product Name in English", typeof(string));
                dtMoveProduct.Columns.Add("Product Name in Tamil", typeof(string));
                dtMoveProduct.Columns.Add("Unit", typeof(string));
                dtMoveProduct.Columns.Add("PRID", typeof(int));
                dtMoveProduct.Columns.Add("Stock Qty", typeof(decimal));
                udfnCmbConcern();
                udfnCmbSourceRack();
                udfnCmbDestinationRack();
                udfnGridColumn();
                txtSourceLocation.Focus();
                this.ActiveControl = txtSourceLocation;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbConcern()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnCompanyList(3, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                cmbConcern.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.ValueMember = "COMID";
                            cmbConcern.DisplayMember = "COM_ShortName";
                            cmbConcern.DataSource = objDs.Tables[0];
                        }
                    }
                }
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbSourceRack()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnRackList(3,0,0, varSourceLocationID, 0,"",0,0);
                objdserv.CloseConnection();
                cmbSourceRack.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            if (Convert.ToInt32(objDs.Tables[1].Rows[0][0])==0)
                            {
                                cmbSourceRack.Text = "None";
                                varSourceRackID = 0;
                            }
                            else
                            {
                                if (objDs.Tables[0].Rows.Count > 0)
                                {
                                    cmbSourceRack.ValueMember = "RKID";
                                    cmbSourceRack.DisplayMember = "RK_ShortName";
                                    cmbSourceRack.DataSource = objDs.Tables[0];
                                    cmbSourceRack.Enabled = true;
                                }
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
        public void udfnCmbDestinationRack()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                if (varDestinationLocationID == varSourceLocationID)
                {
                    objDs = objdserv.udfnRackList(16, 0, 0, varDestinationLocationID, varSourceRackID, "", 0, 0);
                }
                else
                {
                    objDs = objdserv.udfnRackList(16, 0, 0, varDestinationLocationID, 0, "", 0, 0);
                }
                objdserv.CloseConnection();
                cmbDestinationRack.DataSource = null;
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            if (varDestinationLocationID == varSourceLocationID)
                            {
                                if (Convert.ToInt32(objDs.Tables[1].Rows[0][0]) <= 1)
                                {
                                    cmbDestinationRack.Text = "None";
                                    varDestinationRackID = 0;
                                    cmbDestinationRack.Enabled = false;
                                }
                                else
                                {
                                    if (objDs.Tables[0].Rows.Count > 0)
                                    {
                                        cmbDestinationRack.ValueMember = "RKID";
                                        cmbDestinationRack.DisplayMember = "RK_ShortName";
                                        cmbDestinationRack.DataSource = objDs.Tables[0];
                                        cmbDestinationRack.Enabled = true;
                                    }
                                }
                            }
                            else
                            {
                                if (objDs.Tables[0].Rows.Count > 0)
                                {
                                    cmbDestinationRack.ValueMember = "RKID";
                                    cmbDestinationRack.DisplayMember = "RK_ShortName";
                                    cmbDestinationRack.DataSource = objDs.Tables[0];
                                    cmbDestinationRack.Enabled = true;
                                }
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
        private void DGV_SearchGridMove_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_SearchGridMove.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.Value = null;
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
        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                cmbConcern.BackColor = Color.LemonChiffon;
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
                    txtSourceLocation.Focus();
                }
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
        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbConcern, "Please select company.");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select company.", cmbConcern, 5000);
                }
                else
                {
                    epRackSettings.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDSourceRack_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtSourceLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                txtSourceLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSourceLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSourceLocation.Text == "")
                {
                    txtSourceLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epRackSettings.SetError(txtSourceLocation, "Please select source location.");
                }
                else
                {
                    txtSourceLocation.BackColor = Color.White;
                    epRackSettings.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbSourceRack_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtSourceLocation.Text == "")
                {
                    txtSourceLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epRackSettings.SetError(txtSourceLocation, "Please select source location.");
                }
                cmbSourceRack.BackColor = Color.LemonChiffon;

                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbSourceRack_Leave(object sender, EventArgs e)
        {
            try
            {
               // if (Convert.ToString(cmbSourceRack.SelectedValue) == "" || Convert.ToString(cmbSourceRack.SelectedValue) == "-1")
                if (Convert.ToString(cmbSourceRack.SelectedValue) == "-1")
                {
                    epRackSettings.SetError(cmbSourceRack, "Please select source rack.");
                    cmbSourceRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSourceRack.ShowAlways = true;
                    tpSourceRack.Show("Please select source rack.", cmbSourceRack, 5000);
                }
                else
                {
                    epRackSettings.Clear();
                    cmbSourceRack.BackColor = Color.White;
                }
                //if (varSourceLocationID != 0)
                //{
                //    productid = 0;
                //    udfnProductLoad();
                //}
                //udfnCmbDestinationRack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbSourceRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDestinationLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbSourceRack_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbSourceRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSourceRack.Select(int.MaxValue, 0)));
                if (cmbSourceRack.Text == "None")
                { varSourceRackID = 0; }
                else
                { varSourceRackID = Convert.ToInt32(cmbSourceRack.SelectedValue); }
                if (varSourceLocationID != 0 && varSourceRackID!=-1 && cmbSourceRack.Text!="")
                {
                    productid = 0;
                    udfnProductLoad();
                }
                udfnCmbDestinationRack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                varSourceRackID = Convert.ToInt32(cmbSourceRack.SelectedValue);
            }
        }
        private void TxtDestinationLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                txtDestinationLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDestinationLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDestinationLocation.Text == "")
                {
                    txtDestinationLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epRackSettings.SetError(txtDestinationLocation, "Please select source location.");
                }
                else
                {
                    txtDestinationLocation.BackColor = Color.White;
                    epRackSettings.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbDestinationRack_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbDestinationRack.BackColor = Color.LemonChiffon;
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbDestinationRack_Leave(object sender, EventArgs e)
        {
            if (Convert.ToString(cmbDestinationRack.SelectedValue) == "-1")
            {
                epRackSettings.SetError(cmbDestinationRack, "Please select destination rack.");
                cmbDestinationRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                tpDestinationRack.ShowAlways = true;
                tpDestinationRack.Show("Please select destination rack.", cmbDestinationRack, 5000);
            }
            else
            {
                epRackSettings.Clear();
                cmbDestinationRack.BackColor = Color.White;
            }
            //if(cmbDestinationRack.Text.Trim()==cmbSourceRack.Text.Trim())
            //{
            //    epRackSettings.SetError(cmbDestinationRack, "Source and destination rack should not be same.");
            //    cmbDestinationRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
            //    tpDestinationRack.ShowAlways = true;
            //    tpDestinationRack.Show("Source and destination rack should not be same.", cmbDestinationRack, 5000);
            //}
        }
        private void CmbDestinationRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbDestinationRack.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { varDestinationRackID = Convert.ToInt32(cmbDestinationRack.SelectedValue); }
        }
        private void CmbDestinationRack_KeyDown(object sender, KeyEventArgs e)
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
        private void CmbDestinationRack_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtDestinationLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyDLocation == 0)
                {
                    if (txtDestinationLocation.Text.Length > 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();

                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 29;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtDestinationLocation.Text.Trim();
                        objMR_Location.paraUserLocations = MainForm.pbUserMappedLocationIds;
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();

                        //objDs = objspdservice.udfnStockLocationList(29, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtDestinationLocation.Text, 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterDLocation.Visible = true;
                                    DGV_FilterDLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterDLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterDLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterDLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterDLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterDLocation.Columns["SL_EName"].Width = 220;
                                    DGV_FilterDLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterDLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterDLocation.Visible = false;
                                    DGV_FilterDLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterDLocation.Visible = false;
                                DGV_FilterDLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterDLocation.Visible = false;
                            DGV_FilterDLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterDLocation.Visible = false;
                        DGV_FilterDLocation.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSourceLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSLocation.Visible == false)
                {
                    cmbSourceRack.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSLocation.Focus();
                }
                if (DGV_FilterSLocation.CurrentCell == null && DGV_FilterSLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSLocation.Focus();
                    int RowIndex = DGV_FilterSLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySLocation = 1;
                    }
                    else
                    {
                        varUpDownKeySLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSourceLocation.Text = DGV_FilterSLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtSourceLocation.Focus();
                            txtSourceLocation.SelectionStart = txtSourceLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSLocation.Rows.Count) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSLocation.Rows.Count))
                            {
                                txtSourceLocation.Text = DGV_FilterSLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSourceLocation.Focus();
                            txtSourceLocation.SelectionStart = txtSourceLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSLocation.Rows.Count > 0)
                                {
                                    varUpDownKeySLocation = 1;
                                    udfnSLocationEvent();
                                    udfnCmbSourceRack();
                                    DGV_FilterSLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSourceLocation.Focus();
                    //txtSourceLocation.SelectionStart = txtSourceLocation.Text.Length;
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
                        cmbSourceRack.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySLocation = 1;
                udfnSLocationEvent();
                udfnCmbSourceRack();
                cmbSourceRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterDLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyDLocation = 1;
                udfnDLocationEvent();
                udfnCmbDestinationRack();
                cmbDestinationRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterDLocation_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyDLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyDLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtDestinationLocation.Text = DGV_FilterSLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtDestinationLocation.Focus();
                            txtDestinationLocation.SelectionStart = txtDestinationLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSLocation.Rows.Count) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSLocation.Rows.Count))
                            {
                                txtDestinationLocation.Text = DGV_FilterSLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtDestinationLocation.Focus();
                            txtDestinationLocation.SelectionStart = txtDestinationLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyDLocation = 1;
                                    udfnDLocationEvent();
                                    DGV_FilterSLocation.Visible = false;
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
                        cmbDestinationRack.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterSLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySLocation = 1;
                    }
                    else
                    {
                        varUpDownKeySLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtSourceLocation.Text = DGV_FilterSLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtSourceLocation.Focus();
                            txtSourceLocation.SelectionStart = txtSourceLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSLocation.Rows.Count) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSLocation.Rows.Count))
                            {
                                txtSourceLocation.Text = DGV_FilterSLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSourceLocation.Focus();
                            txtSourceLocation.SelectionStart = txtSourceLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSLocation.Rows.Count > 0)
                                {
                                    varUpDownKeySLocation = 1;
                                    udfnSLocationEvent();
                                    udfnCmbSourceRack();
                                    DGV_FilterSLocation.Visible = false;
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
                        cmbSourceRack.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbSales_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (varSourceLocationID != 0 && varSourceRackID!=-1)
                {
                    productid = 0;
                    udfnProductLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPurchase_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (varSourceLocationID != 0 && varSourceRackID != -1)
                {
                    productid = 0;
                    udfnProductLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDestinationLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyDLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterDLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterDLocation.Visible == false)
                {
                    cmbDestinationRack.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterDLocation.Focus();
                }
                if (DGV_FilterDLocation.CurrentCell == null && DGV_FilterDLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterDLocation.Focus();
                    int RowIndex = DGV_FilterDLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterDLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyDLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyDLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterDLocation.CurrentCell = DGV_FilterDLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtDestinationLocation.Text = DGV_FilterDLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtDestinationLocation.Focus();
                            txtDestinationLocation.SelectionStart = txtDestinationLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterDLocation.Rows.Count) DGV_FilterDLocation.CurrentCell = DGV_FilterDLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterDLocation.Rows.Count))
                            {
                                txtDestinationLocation.Text = DGV_FilterDLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtDestinationLocation.Focus();
                            txtDestinationLocation.SelectionStart = txtDestinationLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterDLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyDLocation = 1;
                                    udfnDLocationEvent();
                                    udfnCmbDestinationRack();
                                    DGV_FilterDLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtDestinationLocation.Focus();
                    //txtLocation.SelectionStart = txtLocation.Text.Length;
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
                        cmbDestinationRack.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSourceLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeySLocation == 0)
                {
                    if (txtSourceLocation.Text.Length > 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();

                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 29;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtSourceLocation.Text.Trim();
                        objMR_Location.paraUserLocations = MainForm.pbUserMappedLocationIds;
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();

                        //objDs = objspdservice.udfnStockLocationList(29, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSourceLocation.Text, 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterSLocation.Visible = true;
                                    DGV_FilterSLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterSLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterSLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterSLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterSLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterSLocation.Columns["SL_EName"].Width = 220;
                                    DGV_FilterSLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterSLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSLocation.Visible = false;
                                    DGV_FilterSLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterSLocation.Visible = false;
                                DGV_FilterSLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterSLocation.Visible = false;
                            DGV_FilterSLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterSLocation.Visible = false;
                        DGV_FilterSLocation.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdViewProduct_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdViewProduct.ClearSelection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
