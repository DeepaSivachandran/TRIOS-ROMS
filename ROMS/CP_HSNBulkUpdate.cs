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
    // Name  : Sivabharathi    Date : 02/09/2023
    public partial class CP_HSNBulkUpdate : Form
    {
        DynamicWindowControl windowControl = new DynamicWindowControl();

        DataValidation objValidation = new DataValidation();
        DataError objError;
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public int varFormFlag = 0;

        public int varGroupId = 0, grid_flag = 0;
        public int varSubGroupId = 0;
        public int varBrandId = 0;
        public int varViewType = 0;
        public int varStatusId = 0, varErrorflag = 0, Varupdateflag = 0;
        public int   varUpDownKeySubgroup = 0, varUpDownKeyProduct = 0, varUpDownKeyBrand = 0, varUpDownKeyOldHSN=0;
        private ToolTip tpType = new ToolTip();
        private ToolTip tpSubgroup = new ToolTip();
        private ToolTip tpOldHSN = new ToolTip();
        private ToolTip tpNewHSN = new ToolTip();
        DataTable dtPurHSN = new DataTable();

        public int pbMenuFlag = 0;

        public CP_HSNBulkUpdate()
        {
            InitializeComponent();
            windowControl.Initialize(tsBulkAttribute, this);
        }
        public void udfnHideGrids()
        {
            try
            { 
                grdHSN.Visible = false; 
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
                Varupdateflag = 0; string varOriginator = "";
                int varHsnId = 0, varUnitId = 0; int varUpdateViewType = 0;
                int varGroupId = 0, varSubGroupId = 0, varBrandId = 0;
                int varPurSLID = 0, varSalesSLID = 0, varPurRKID = 0, varSalesRKID = 0;
                decimal varRMinSaleQty = 0, varWMinSaleQty = 0;
                decimal varMinStock = 0, varMaxStock = 0, varReOrderQty = 0;
                int varUpp = 0, varShelfLifeValue = 0, varShelfLifeTypeID = 0;
                decimal varNetQuantity = 0, varGrossWeight = 0; int varUnitQtyId = 0;
                int varPR_PRCTID = 0, PR_RMForProductionID = 0, PR_BatchNoID = 0, PR_BatchNoGenerationID = 0;
                decimal varCheckMinStock = 0, varCheckMaxStock = 0;
                SPDataService objspdservice = new SPDataService();
                DataTable objBulkUpdate = new DataTable();
                objBulkUpdate.TableName = "[MR_Product_BulkUpdate]";
                //HSN
                objBulkUpdate.Columns.Add("HSN Name-New", typeof(string));
                objBulkUpdate.Columns.Add("HSNIDOLD", typeof(int));
                objBulkUpdate.Columns.Add("HSNIDNEW", typeof(int));
                objBulkUpdate.Columns.Add("PRID", typeof(int));
                //Product
                objBulkUpdate.Columns.Add("UTID-OLD", typeof(int));
                objBulkUpdate.Columns.Add("UTID-NEW", typeof(int));
                objBulkUpdate.Columns.Add("PR_EName-Current", typeof(string));
                objBulkUpdate.Columns.Add("PR_TName-Current", typeof(string));
                objBulkUpdate.Columns.Add("PR_EName-New", typeof(string));
                objBulkUpdate.Columns.Add("PR_TName-New", typeof(string));
                objBulkUpdate.Columns.Add("PR_PICode-Current", typeof(string));
                objBulkUpdate.Columns.Add("PR_PICode-New", typeof(string));
                //Brand
                objBulkUpdate.Columns.Add("PRGID-Old", typeof(int));
                objBulkUpdate.Columns.Add("PRGID-New", typeof(int));
                objBulkUpdate.Columns.Add("PRSGID-Old", typeof(int));
                objBulkUpdate.Columns.Add("PRSGID-New", typeof(int));
                objBulkUpdate.Columns.Add("BDID-Old", typeof(int));
                objBulkUpdate.Columns.Add("BDID-New", typeof(int));
                //Location
                objBulkUpdate.Columns.Add("Pur_SLID-Old", typeof(int));
                objBulkUpdate.Columns.Add("Pur_SLID-NEW", typeof(int));
                objBulkUpdate.Columns.Add("Sales_SLID-Old", typeof(int));
                objBulkUpdate.Columns.Add("Sales_SLID-NEW", typeof(int));
                objBulkUpdate.Columns.Add("Pur_RKID-Old", typeof(int));
                objBulkUpdate.Columns.Add("Pur_RKID-New", typeof(int));
                objBulkUpdate.Columns.Add("Sales_RKID-Old", typeof(int));
                objBulkUpdate.Columns.Add("Sales_RKID-New", typeof(int));
                objBulkUpdate.Columns.Add("RackMOQ-Current", typeof(int));
                objBulkUpdate.Columns.Add("RackMOQ-New", typeof(string));
                //Min sales qty
                objBulkUpdate.Columns.Add("RMinSaleQty-Old", typeof(decimal));
                objBulkUpdate.Columns.Add("RMinSaleQty-New", typeof(string));
                objBulkUpdate.Columns.Add("WMinSaleQty-Old", typeof(decimal));
                objBulkUpdate.Columns.Add("WMinSaleQty-New", typeof(string));
                objBulkUpdate.Columns.Add("Barcode-Old", typeof(string));
                objBulkUpdate.Columns.Add("Barcode-New", typeof(string));
                //Stock
                objBulkUpdate.Columns.Add("PR_MinStock-Old", typeof(decimal));
                objBulkUpdate.Columns.Add("PR_MinStock-New", typeof(string));
                objBulkUpdate.Columns.Add("PR_MaxStock-Old", typeof(decimal));
                objBulkUpdate.Columns.Add("PR_MaxStock-New", typeof(string));
                objBulkUpdate.Columns.Add("PR_ReOrderQty-Old", typeof(decimal));
                objBulkUpdate.Columns.Add("PR_ReOrderQty-New", typeof(string));
                //Shelflife
                objBulkUpdate.Columns.Add("Upp-Old", typeof(int));
                objBulkUpdate.Columns.Add("Upp-New", typeof(string));
                objBulkUpdate.Columns.Add("ShelfLifeValue-Old", typeof(int));
                objBulkUpdate.Columns.Add("ShelfLifeValue-New", typeof(string));
                objBulkUpdate.Columns.Add("ShelfLifeTypeID-Old", typeof(int));
                objBulkUpdate.Columns.Add("ShelfLifeTypeID-New", typeof(int));
                //Weight
                objBulkUpdate.Columns.Add("Net Quantity-Current", typeof(decimal));
                objBulkUpdate.Columns.Add("Net Quantity-New", typeof(string));
                objBulkUpdate.Columns.Add("Gross Weight-Current", typeof(decimal));
                objBulkUpdate.Columns.Add("Gross Weight-New", typeof(string));
                objBulkUpdate.Columns.Add("Net-QUTID-Current", typeof(int));
                objBulkUpdate.Columns.Add("Net-QUTID-New", typeof(int));
                //Batch
                objBulkUpdate.Columns.Add("PR_PRCTID-Current", typeof(int));
                objBulkUpdate.Columns.Add("PR_PRCTID-New", typeof(int));
                objBulkUpdate.Columns.Add("PR_RMForProductionID-Current", typeof(int));
                objBulkUpdate.Columns.Add("PR_RMForProductionID-New", typeof(int));
                objBulkUpdate.Columns.Add("PR_BatchNoID-Current", typeof(int));
                objBulkUpdate.Columns.Add("PR_BatchNoID-New", typeof(int));
                objBulkUpdate.Columns.Add("PR_BatchNoGenerationID-Current", typeof(int));
                objBulkUpdate.Columns.Add("PR_BatchNoGenerationID-New", typeof(int));

                objBulkUpdate.Columns.Add("ErrorFlag", typeof(int));

                if (grdHSN.Visible == true)
                {
                    varUpdateViewType = 3; varViewType = 11; varOriginator = "Product Bulk Update-HSN";
                    for (int i = 0; i < grdHSN.Rows.Count; i++)
                    {
                        varHsnId = 0; varErrorflag = 0;
                        //var varValue = from r in objDSHSN.Tables[0].AsEnumerable() where (r.Field<string>("HSN Name").ToUpper().Equals(Convert.ToString(grdHSN.Rows[i].Cells["HSN Name-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        //if (varValue.Count() > 0) { varHsnId = Convert.ToInt32(varValue.ToList()[0]); }
                        //if (Convert.ToString(grdHSN.Rows[i].Cells["HSN Name-New"].Value).Trim() != "")
                        //{
                        //    if (varHsnId == 0)
                        //    {
                        //        varErrorflag = 1;
                        //    }
                        //}
                        //objBulkUpdate.Rows.Add(Convert.ToString(grdHSN.Rows[i].Cells["HSN Name-New"].Value).Trim(), Convert.ToInt32(grdHSN.Rows[i].Cells["HSNOLDID"].Value), varHsnId, grdHSN.Rows[i].Cells["PRID"].Value,
                        //    0, 0, "", "", "", "", "", "",
                        //    0, 0, 0, 0, 0, 0,
                        //    0, 0, 0, 0, 0, 0, 0, 0, 0, "",
                        //    0, "", 0, "", "", "",
                        //    0, "", 0, "", 0, "",
                        //    0, "", 0, "", 0, 0,
                        //    0, "", 0, "", 0, 0,
                        //    0, 0, 0, 0, 0, 0, 0, 0,
                        //    varErrorflag);
                    }
                }
               
                else if (grdHSN.Visible == true)
                {
                    //varUpdateViewType = 5; varViewType = 10; varOriginator = "Product Bulk Update-Brand";
                    //for (int i = 0; i < grdBrand.Rows.Count; i++)
                    //{
                    //    varGroupId = 0; varSubGroupId = 0; varBrandId = 0; varErrorflag = 0;
                    //    string varSubGroupName = Convert.ToString(grdBrand.Rows[i].Cells["Sub Group-New"].Value).Trim();
                    //    if (varSubGroupName == "") { varSubGroupName = Convert.ToString(grdBrand.Rows[i].Cells["Sub Group-Current"].Value).Trim(); }
                    //    string varGroupName = Convert.ToString(grdBrand.Rows[i].Cells["Group-New"].Value).Trim();
                    //    if (varGroupName == "") { varGroupName = Convert.ToString(grdBrand.Rows[i].Cells["Group-Current"].Value).Trim(); }

                    //    var varGroup = from r in objDSSubGroup.Tables[0].AsEnumerable() where (r.Field<string>("Product Group Name").ToUpper().Equals(Convert.ToString(varGroupName).Trim().ToUpper()) && r.Field<string>("Product Sub Group Name in English").ToUpper().Equals(varSubGroupName.ToUpper())) group r by r.Field<int>("Product Group Id") into g select g.Key;
                    //    if (varGroup.Count() > 0)
                    //    { varGroupId = Convert.ToInt32(varGroup.ToList()[0]); }

                    //    var varSubGroup = from r in objDSSubGroup.Tables[0].AsEnumerable() where (r.Field<string>("Product Sub Group Name in English").ToUpper().Equals(Convert.ToString(varSubGroupName).Trim().ToUpper()) && r.Field<string>("Product Group Name").ToUpper().Equals(varGroupName.ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                    //    if (varSubGroup.Count() > 0)
                    //    { varSubGroupId = Convert.ToInt32(varSubGroup.ToList()[0]); }

                    //    var varBrand = from r in objDSSubgroupBrand.Tables[0].AsEnumerable() where (r.Field<string>("BD_EName").Trim().ToUpper().Equals(Convert.ToString(grdBrand.Rows[i].Cells["Brand-New"].Value).Trim().ToUpper()) && r.Field<string>("Sub Group Name in English").Trim().ToUpper().Equals(varSubGroupName.Trim().ToUpper())) group r by r.Field<int>("BDID") into g select g.Key;
                    //    if (varBrand.Count() > 0)
                    //    { varBrandId = Convert.ToInt32(varBrand.ToList()[0]); }

                    //    if (Convert.ToString(grdBrand.Rows[i].Cells["Group-New"].Value).Trim() != "")
                    //    {
                    //        if (varGroupId == 0)
                    //        {
                    //            varErrorflag = 1;
                    //        }
                    //    }
                    //    if (Convert.ToString(grdBrand.Rows[i].Cells["Sub Group-New"].Value).Trim() != "")
                    //    {
                    //        if (varSubGroupId == 0)
                    //        {
                    //            varErrorflag = 2;
                    //        }
                    //    }
                    //    if (Convert.ToString(grdBrand.Rows[i].Cells["Brand-New"].Value).Trim() != "")
                    //    {
                    //        if (varBrandId == 0)
                    //        {
                    //            varErrorflag = 3;
                    //        }
                    //    }
                    //    if (Convert.ToString(grdBrand.Rows[i].Cells["Group-New"].Value).Trim() != "" && Convert.ToString(grdBrand.Rows[i].Cells["Sub Group-New"].Value).Trim() != "" && varBrandId == 0)
                    //    {
                    //        varErrorflag = 4;
                    //    }
                    //    if (varSubGroupId == 0 && Convert.ToString(grdBrand.Rows[i].Cells["Group-New"].Value).Trim() != "")
                    //    { varErrorflag = 5; }
                    //    objBulkUpdate.Rows.Add("", 0, 0, Convert.ToInt32(grdBrand.Rows[i].Cells["PRID"].Value),
                    //        0, 0, "", "", "", "", "", "",
                    //        Convert.ToInt32(grdBrand.Rows[i].Cells["PRGID-Old"].Value), varGroupId, Convert.ToInt32(grdBrand.Rows[i].Cells["PRSGID-Old"].Value), varSubGroupId, Convert.ToInt32(grdBrand.Rows[i].Cells["BDID-Old"].Value), varBrandId,
                    //         0, 0, 0, 0, 0, 0, 0, 0, 0, "",
                    //        0, "", 0, "", "", "",
                    //        0, "", 0, "", 0, "",
                    //        0, "", 0, "", 0, 0,
                    //        0, "", 0, "", 0, 0,
                    //        0, 0, 0, 0, 0, 0, 0, 0,
                    //        varErrorflag);
                    //}
                } 
                if (Varupdateflag == 0)
                {
                    MainForm.objCP_BulkAttributeVerify = new CP_BulkAttributeVerify();
                    MainForm.objCP_BulkAttributeVerify.ShowDialog();
                    string result = "", varUserID = "";
                    if (MainForm.objCP_BulkAttributeVerify.flag == 1)
                    {
                        varUserID = MainForm.objCP_BulkAttributeVerify.varUserId;
                        SPDataService objDSer = new SPDataService();
                        result = objDSer.udfnProductMaster(varUpdateViewType, 0, "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", varUserID, MainForm.pbIpAddress, varOriginator, 0, objBulkUpdate, 0, "", 0, 0, 0, 0, 0, null, "", "", "", 0, "", "", 0, 0, 0, null, 0, 0, 0, 0, null, 0);
                        objDSer.CloseConnection();
                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //udfnList();
                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        udfnList(); 
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
                btnUpdate.Focus();
            }
            finally
            {
                btnUpdate.Enabled = true;
                btnUpdate.Focus();
            }
        } 
         
        public void udfnTotalCount()
        {
            try
            { 
                if (grdHSN.Visible == true)
                { lblTotalCount.Text = Convert.ToString(grdHSN.Rows.Count); } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnList()
        {
            try
            {
                // Application.DoEvents(); 
                dtPurHSN.Rows.Clear();
                grdHSN.DataSource = null; 
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 11; 
                objMR_Product.paraSubgroup = Convert.ToInt16(lblSubGroupCode.Text);
                objMR_Product.paraType = Convert.ToInt32(cmbType.SelectedValue);
                objMR_Product.ParaProductCode = Convert.ToInt32(lblProductcode.Text); 
                objMR_Product.paraHsnId = Convert.ToInt32(lblOldHSNId.Text); 
                objMR_Product.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objMR_Product.paraIPAddress = MainForm.pbIpAddress;  
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            if (grdHSN.Visible == true)
                            {
                                grdHSN.DataSource = objDs.Tables[0];
                                dtPurHSN = objDs.Tables[1];
                                grdHSN.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                grdHSN.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                 

                                grdHSN.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdHSN.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdHSN.Columns["Unit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdHSN.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdHSN.Columns["Product Name in English"].Visible = false;
                                 
                                grdHSN.Columns["S.No."].Width = 50;
                                grdHSN.Columns["Product Name in Tamil"].Width = 350;
                                grdHSN.Columns["P.I Code"].Width = 120;
                                grdHSN.Columns["Unit"].Width = 80;
                                grdHSN.Columns["HSN Name"].Width = 150;
                                grdHSN.Columns["S.No."].Frozen = true;
                                grdHSN.Columns["P.I Code"].Frozen = true;
                                grdHSN.Columns["Product Name in Tamil"].Frozen = true;
                                grdHSN.Columns["Unit"].Frozen = true;
                                grdHSN.Columns["S.No."].ReadOnly = true;
                                grdHSN.Columns["P.I Code"].ReadOnly = true;
                                grdHSN.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdHSN.Columns["Unit"].ReadOnly = true;
                                grdHSN.Columns["PRID"].Visible = false;
                                 
                            }
                             
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        lblNoRecordsFound.BringToFront();
                    }
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                udfnTotalCount();
            }
        }
        
             
        private void TsbHsn_Click(object sender, EventArgs e)
        {
            try
            {
                //DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dialogResult == DialogResult.Yes)
                //{
                udfnFilterLoad();
                udfnHideGrids();        
                grdHSN.Visible = true;
                varViewType = 11;
                udfnList();
                tspHeader.Text = "Product Attributes Bulk Update : HSN Name";
                tsbHsn.BackColor = Color.SkyBlue;
                //}
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
                bool blnErrorFlag = true;
                epHSNBulkupdate.Clear();
                if (Convert.ToString(cmbType.SelectedValue) == "" || Convert.ToString(cmbType.SelectedValue) == "-1")
                {
                    epHSNBulkupdate.SetError(cmbType, "Please select type.");
                    cmbType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpType.ShowAlways = true;
                    tpType.Show("Please select type.", cmbType, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToInt64(lblSubGroupCode.Text)==0)
                {
                    epHSNBulkupdate.SetError(txtSubgroup, "Please enter subgroup.");
                    txtSubgroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSubgroup.ShowAlways = true;
                    tpSubgroup.Show("Please enter subgroup.", txtSubgroup, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToInt64(lblOldHSNId.Text) == 0)
                {
                    epHSNBulkupdate.SetError(txtOldHSN, "Please enter old HSN code.");
                    txtOldHSN.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOldHSN.ShowAlways = true;
                    tpOldHSN.Show("Please enter old HSN code.", txtOldHSN, 5000);
                    blnErrorFlag = false;
                }
                if (blnErrorFlag == true)
                {
                    btnView.Enabled = false;
                    udfnList();
                }
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
        public AutoCompleteStringCollection AutoCompleteHSN()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("select  HSNID, HSN_Name from MR_HSN where HSNID NOT IN(-1, 0) AND HSN_STSID=1 ");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("HSN_Name") into g select g.Key;
            //var varValueID = from r in objDt.AsEnumerable() group r by r.Field<string>("HSNID") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }

        public AutoCompleteStringCollection AutoCompleteLocationName(int varCOMID)
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();
            if (varCOMID == 0)
            {
                objds = objdservice.GetDataset("SELECT SLID,SL_EName FROM MR_StockLocation WHERE SLID NOT IN (-1,0) AND SL_STSID=1 ");
            }
            else
            { 
                objds = objdservice.GetDataset("SELECT SLID,SL_EName FROM MR_StockLocation WHERE SL_STSID=1 AND SL_COMID=" + varCOMID);
            }
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("SL_EName") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteRackName(int varSLID, int varPRID)
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();
            
            objds = objdservice.GetDataset("SELECT RKID,RK_Name FROM MR_Rack WHERE RKID NOT IN (-1,0) AND RK_STSID=1 AND RK_SLID= " + varSLID);

            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("RK_Name") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteRmPro()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT 'Yes' DisplayText,1 MSTID UNION ALL SELECT 'No', 0");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("DisplayText") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }


        public AutoCompleteStringCollection AutoCompleteShelfLife()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT MSTID,MST_DisplayText from DEF_Master where MST_TransactionID = 6");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("MST_DisplayText") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }

        public AutoCompleteStringCollection AutoCompleteProductCatergory()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT MSTID,MST_DisplayText from DEF_Master where MST_TransactionID = 5");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("MST_DisplayText") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteBatchNo()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT MSTID,MST_DisplayText from DEF_Master where MST_TransactionID = 25");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("MST_DisplayText") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        
        public AutoCompleteStringCollection AutoCompleteGroup()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT PRGID,PRG_EName from  MR_ProductGroup  where PRGID NOT IN(-1,0) AND PRG_STSID=1");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("PRG_EName") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteSubGroup(int varSubGroupId)
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();
            if (varSubGroupId == 0)
            {
                objds = objdservice.GetDataset("SELECT PRSGID,PRSG_EName from  MR_ProductSubGroup  where PRSGID NOT IN(-1,0) AND PRSG_STSID=1");
            }
            else
            {
                objds = objdservice.GetDataset("SELECT PRSGID,PRSG_EName from  MR_ProductSubGroup  where PRSGID NOT IN(-1,0) AND PRSG_STSID=1 AND PRSG_PRGID = " + varSubGroupId + " ");
            }
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("PRSG_EName") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteBrand(int varBrandId)
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();
            if (varBrandId == 0)
            {
                objds = objdservice.GetDataset("SELECT BDID,BD_EName from  MR_Brand  where BDID NOT IN(-1,0) AND BD_STSID=1");
            }
            else
            {
                objds = objdservice.GetDataset("SELECT BDID,BD_EName  FROM MR_Brand INNER JOIN MR_Brand_SubGroup ON BDS_BDID=BDID WHERE BDID NOT IN(-1, 0) AND BD_STSID=1 AND BDS_PRSGID= " + varBrandId + " ");
            }
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("BD_EName") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteUnitQtySymbol()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT QUTID, QUT_Symbol from MR_QtyUnit  WHERE QUT_STSID=1");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("QUT_Symbol") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        public AutoCompleteStringCollection AutoCompleteUnit()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT  UTID,UT_Symbol from MR_Unit WHERE UTID NOT IN (-1,0) AND UT_BulkUnit=0 AND UT_STSID=1");
            objdservice.CloseConnection();
            if (objds != null)
            {
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {
                        objDt = objds.Tables[0];
                    }
                }
            }
            var varValue = from r in objDt.AsEnumerable() group r by r.Field<string>("UT_Symbol") into g select g.Key;
            for (int i = 0; i < varValue.Count(); i++)
            {
                varstr.Add(varValue.ToList()[i].ToString());
            }
            return varstr;
        }
        private void GrdHSN_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdHSN.CurrentCell.OwningColumn.Name == "HSN Name-New")
                {
                    TextBox txtHSNName = e.Control as TextBox;
                    if (txtHSNName != null)
                    {
                        txtHSNName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtHSNName.AutoCompleteCustomSource = AutoCompleteHSN();
                        txtHSNName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSubgroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeySubgroup == 0)
                { 
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtSubgroup.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnSubGroupList(9, 0, "", 0, 0, txtSubgroup.Text, 0, 0, 0, 0, 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterSubgroup.Visible = true;
                                    DGV_FilterSubgroup.DataSource = objDs.Tables[0];
                                    DGV_FilterSubgroup.Columns["PRSGID"].Visible = false;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].HeaderText = "Subgroup English Name";
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].HeaderText = "Subgroup Tamil Name";
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].Width = 150;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].Width = 200;
                                    DGV_FilterSubgroup.Columns["PRSG_EName"].DisplayIndex = 0;
                                    DGV_FilterSubgroup.Columns["PRSG_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterSubgroup.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSubgroup.Visible = false;
                                    DGV_FilterSubgroup.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterSubgroup.Visible = false;
                                DGV_FilterSubgroup.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterSubgroup.Visible = false;
                            DGV_FilterSubgroup.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterSubgroup.Visible = false;
                        DGV_FilterSubgroup.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtSubgroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySubgroup = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSubgroup.Focus(); 
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSubgroup.Visible == false)
                {
                    txtProductName.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSubgroup.Focus();
                }
                if (DGV_FilterSubgroup.CurrentCell == null && DGV_FilterSubgroup.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSubgroup.Focus();
                    int RowIndex = DGV_FilterSubgroup.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSubgroup.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySubgroup = 1;
                    }
                    else
                    {
                        varUpDownKeySubgroup = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSubgroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }
                            txtSubgroup.Focus();
                            txtSubgroup.SelectionStart = txtSubgroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSubgroup.Rows.Count) DGV_FilterSubgroup.CurrentCell = DGV_FilterSubgroup.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSubgroup.Rows.Count))
                            {
                                txtSubgroup.Text = DGV_FilterSubgroup.Rows[RowIndex].Cells["PRSG_EName"].Value.ToString();
                            }

                            txtSubgroup.Focus();
                            txtSubgroup.SelectionStart = txtSubgroup.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSubgroup.Rows.Count > 0)
                                {
                                    varUpDownKeySubgroup = 1;
                                    udfnSubGroupAutocomplete();
                                    DGV_FilterSubgroup.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSubgroup.Focus();
                    //txtSubGroup.SelectionStart = txtSubGroup.Text.Length;
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
                        txtProductName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSubGroupAutocomplete()
        {
            try
            {
                if (txtSubgroup.Text.Trim() != "")
                {
                    lblSubGroupCode.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSGID"].Value.ToString();
                    txtSubgroup.Text = DGV_FilterSubgroup.SelectedRows[0].Cells["PRSG_EName"].Value.ToString();
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
            }
        }

        private void txtSubgroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSubgroup.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterSubgroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySubgroup = 1;
                udfnSubGroupAutocomplete();
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
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
                varUpDownKeyProduct = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    txtProductName.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
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
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
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
                        txtOldHSN.Focus();
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
                if (txtProductName.Text.Trim() != "")
                {
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                }
                txtOldHSN.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
             
        }

        public void udfnListviewOldHSN()
        {
            try
            {
                if (txtOldHSN.Text.Trim() != "")
                {
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["HSNID"].Value.ToString();
                    txtOldHSN.Text = DGV_FilterProduct.SelectedRows[0].Cells["HSNName"].Value.ToString();
                }
                btnView.Focus();
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

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyProduct == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {

                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 49; 
                        objMR_Product.paraSubgroup = Convert.ToInt32(lblSubGroupCode.Text);
                        objMR_Product.paraProductName = txtProductName.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
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
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50;
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
                txtOldHSN.Focus();
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
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
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
                        txtOldHSN.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void dpEffFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblProductSubGroup_Click(object sender, EventArgs e)
        {

        }

        private void lblDBrand_Click(object sender, EventArgs e)
        {

        }

        private void CP_HSNBulkUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID  IN (144,0) AND MSTID NOT IN (0) ORDER BY MSTID ASC", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                dtPurHSN.Columns.Add("HSN_Type", typeof(int));
                dtPurHSN.Columns.Add("HSNID", typeof(int));
                dtPurHSN.Columns.Add("HSN_EffectiveFrom", typeof(string));
                dtPurHSN.Columns.Add("HSN_EffectiveTo", typeof(string));
                dtPurHSN.Columns.Add("PRHSN_ChangedDate", typeof(string));
                dtPurHSN.Columns.Add("PRHSN_MakerID", typeof(int));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOldHSN_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtOldHSN.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOldHSN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyOldHSN == 0)
                {
                    //lvHsnName.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtOldHSN.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnHsnList(6, 0, 0, 0, txtOldHSN.Text.Trim(), "");
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_OldHSN.Visible = true;
                                    DGV_OldHSN.DataSource = objDs.Tables[0];
                                    DGV_OldHSN.Columns["HSNID"].Visible = false;
                                    DGV_OldHSN.Columns["HSN_GSTID"].Visible = false;
                                    DGV_OldHSN.Columns["GST_Text"].Visible = false;
                                    DGV_OldHSN.Columns["HSN_Name"].HeaderText = "HSN Name";
                                    DGV_OldHSN.Columns["HSN_Code"].HeaderText = "HSN Code";
                                    DGV_OldHSN.Columns["HSN_Name"].Width = 160;
                                    DGV_OldHSN.Columns["HSN_Code"].Width = 140;
                                    DGV_OldHSN.Columns["HSN_Code"].DisplayIndex = 0;
                                    DGV_OldHSN.Columns["HSN_Name"].DisplayIndex = 1;
                                    DGV_OldHSN.BringToFront();
                                }
                                else
                                {
                                    DGV_OldHSN.Visible = false;
                                    DGV_OldHSN.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_OldHSN.Visible = false;
                                DGV_OldHSN.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_OldHSN.Visible = false;
                            DGV_OldHSN.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_OldHSN.Visible = false;
                        DGV_OldHSN.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOldHSN_Leave(object sender, EventArgs e)
        {
            try
            {
                txtOldHSN.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_OldHSN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyOldHSN = 1;
                udfnHSNAutocomplete(); 
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
                if (txtOldHSN.Text.Trim() != "")
                {
                    txtOldHSN.Text = DGV_OldHSN.SelectedRows[0].Cells["HSN_Code"].Value.ToString();
                    lblOldHSNId.Text = DGV_OldHSN.SelectedRows[0].Cells["HSNID"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_OldHSN.Visible = false;
                DGV_OldHSN.DataSource = null; 
            }
        }

        private void DGV_OldHSN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            { 
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_OldHSN.CurrentCell.RowIndex;
                    int ClmIndex = DGV_OldHSN.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyOldHSN = 1;
                    }
                    else
                    {
                        varUpDownKeyOldHSN = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_OldHSN.CurrentCell = DGV_OldHSN.Rows[RowIndex].Cells[ClmIndex];

                            txtOldHSN.Text = DGV_OldHSN.SelectedRows[0].Cells["HSN_Code"].Value.ToString();

                            txtOldHSN.Focus();
                            txtOldHSN.SelectionStart = txtOldHSN.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_OldHSN.Rows.Count) DGV_OldHSN.CurrentCell = DGV_OldHSN.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_OldHSN.Rows.Count))
                            {
                                txtOldHSN.Text = DGV_OldHSN.Rows[RowIndex].Cells["HSN_Code"].Value.ToString();
                            }

                            txtOldHSN.Focus();
                            txtOldHSN.SelectionStart = txtOldHSN.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_OldHSN.Rows.Count > 0)
                                {
                                    varUpDownKeyOldHSN = 1;
                                    udfnHSNAutocomplete();
                                    DGV_OldHSN.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnView.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtOldHSN_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyOldHSN = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_OldHSN.Focus(); 
                }
                if (e.KeyCode == Keys.Enter && DGV_OldHSN.Visible == false)
                {
                    txtProductName.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_OldHSN.Focus();
                }
                if (DGV_OldHSN.CurrentCell == null && DGV_OldHSN.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_OldHSN.Focus();
                    int RowIndex = DGV_OldHSN.CurrentCell.RowIndex;
                    int ClmIndex = DGV_OldHSN.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyOldHSN = 1;
                    }
                    else
                    {
                        varUpDownKeyOldHSN = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_OldHSN.CurrentCell = DGV_OldHSN.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtOldHSN.Text = DGV_OldHSN.Rows[RowIndex].Cells["HSNName"].Value.ToString();
                            }
                            txtOldHSN.Focus();
                            txtOldHSN.SelectionStart = txtOldHSN.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_OldHSN.Rows.Count) DGV_OldHSN.CurrentCell = DGV_OldHSN.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_OldHSN.Rows.Count))
                            {
                                txtOldHSN.Text = DGV_OldHSN.Rows[RowIndex].Cells["HSNName"].Value.ToString();
                            } 
                            txtOldHSN.Focus();
                            txtOldHSN.SelectionStart = txtOldHSN.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_OldHSN.Rows.Count > 0)
                                {
                                   varUpDownKeyOldHSN = 1;
                                    udfnListviewOldHSN();
                                    DGV_OldHSN.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtOldHSN.Focus();
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
                        txtOldHSN.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBrand_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdHSN.CurrentCell.OwningColumn.Name == "Group-New")
                {
                    TextBox txtGroup = e.Control as TextBox;
                    if (txtGroup != null)
                    {
                        txtGroup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtGroup.AutoCompleteCustomSource = AutoCompleteGroup();
                        txtGroup.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdHSN.CurrentCell.OwningColumn.Name == "Sub Group-New")
                {
                    TextBox SubGroup = e.Control as TextBox;
                    if (SubGroup != null)
                    {
                        int varGRID = 0;
                        string varGroupName = "";
                        if (Convert.ToString(grdHSN.CurrentRow.Cells["Group-New"].Value) == "") { varGroupName = Convert.ToString(grdHSN.CurrentRow.Cells["Group-Current"].Value); }
                        else { varGroupName = Convert.ToString(grdHSN.CurrentRow.Cells["Group-New"].Value); }
                         
                        SubGroup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        SubGroup.AutoCompleteCustomSource = AutoCompleteSubGroup(varGRID);
                        SubGroup.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdHSN.CurrentCell.OwningColumn.Name == "Brand-New")
                {
                    TextBox txtBrand = e.Control as TextBox;
                    if (txtBrand != null)
                    {
                        int varSGRID = 0;
                        string varSubGroupName = "";
                        if (Convert.ToString(grdHSN.CurrentRow.Cells["Sub Group-New"].Value) == "") { varSubGroupName = Convert.ToString(grdHSN.CurrentRow.Cells["Sub Group-Current"].Value).Trim(); }
                        else { varSubGroupName = Convert.ToString(grdHSN.CurrentRow.Cells["Sub Group-New"].Value).Trim(); }
                       
                        
                        txtBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtBrand.AutoCompleteCustomSource = AutoCompleteBrand(varSGRID);
                        txtBrand.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void GrdBrand_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdHSN.CurrentCell.OwningColumn.Name == "Group-New")
                {
                    grdHSN.CurrentRow.Cells["Sub Group-New"].Value = "";
                    grdHSN.CurrentRow.Cells["Brand-New"].Value = "";
                }
                if (grdHSN.CurrentCell.OwningColumn.Name == "Sub Group-New")
                {
                    grdHSN.CurrentRow.Cells["Brand-New"].Value = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtSubgroup)
                {
                    varUpDownKeySubgroup = 0;
                    DGV_FilterSubgroup.DataSource = null;
                    DGV_FilterSubgroup.Visible = false;
                }
                
                if (skipControl != txtProductName)
                {
                    varUpDownKeyProduct = 0;
                    DGV_FilterProduct.DataSource = null;
                    DGV_FilterProduct.Visible = false;
                }
               
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void txtSubgroup_Enter(object sender, EventArgs e)
        {
            try
            { 
                udfnGridNull((Control)sender); 
                txtSubgroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
      
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if (grdHSN.Visible == true)
                {
                    if (grdHSN.Focused)
                    {
                        grid_flag = 1;
                    }
                    if (grdHSN.Rows.Count > 0)
                    {
                        if (grdHSN.CurrentCell.Selected == true && grdHSN.IsCurrentCellInEditMode == true)
                        {
                            grid_flag = 1;
                        }
                    }
                    if (grid_flag == 1)
                    {
                        if (keyData == Keys.Enter || keyData == Keys.Right || keyData == Keys.Tab)
                        {
                            int icolumn = grdHSN.CurrentCell.ColumnIndex;
                            int irow = grdHSN.CurrentCell.RowIndex;
                            int i = irow;
                            int intsection = 0, intlvariant = 0;
                            intsection = grdHSN.Columns.Count - 1;
                            intlvariant = grdHSN.Columns.Count - 2;
                            if (intsection == icolumn)
                            {
                                grdHSN.CurrentCell = grdHSN[intsection, irow + 1];
                                icolumn = grdHSN.Columns.Count - 1;//grdProDetails.CurrentCell.ColumnIndex;
                                irow = grdHSN.CurrentCell.RowIndex;
                            }
                            if (intlvariant == icolumn)
                            {
                            A: if (icolumn == grdHSN.Columns.Count - 2)
                                {
                                    //grdProDetails.Rows.Add();
                                    if (irow < grdHSN.Rows.Count - 1)
                                    {
                                        grdHSN.CurrentCell = grdHSN[8, irow + 1];
                                        icolumn = grdHSN.CurrentCell.ColumnIndex;
                                        irow = grdHSN.CurrentCell.RowIndex;
                                        //goto A;
                                    }
                                    else
                                    {
                                        grdHSN.CurrentCell = grdHSN[icolumn + 1, irow];
                                        if (grdHSN.CurrentCell.ReadOnly == true)
                                        {
                                            icolumn++; goto A;
                                        }

                                    }
                                }
                                else
                                {
                                    grdHSN.CurrentCell = grdHSN[icolumn + 1, irow];
                                    if (grdHSN.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                                }
                            }
                            else
                            {
                            A: if (icolumn == grdHSN.Columns.Count - 1)
                                {
                                    //grdProDetails.Rows.Add();
                                    if (irow < grdHSN.Rows.Count - 1)
                                    {
                                        grdHSN.CurrentCell = grdHSN[7, irow + 1];
                                        icolumn = grdHSN.CurrentCell.ColumnIndex;
                                        irow = grdHSN.CurrentCell.RowIndex;
                                        //goto A;
                                    }
                                    else
                                    {
                                        grdHSN.CurrentCell = grdHSN[icolumn + 1, irow];
                                        if (grdHSN.CurrentCell.ReadOnly == true)
                                        {
                                            icolumn++; goto A;
                                        }

                                    }
                                }
                                else
                                {
                                    if (grdHSN[icolumn + 1, irow].Visible == false)
                                    {
                                        { icolumn++; goto A; }
                                    }
                                    else
                                    {
                                        grdHSN.CurrentCell = grdHSN[icolumn + 1, irow];
                                        if (grdHSN.CurrentCell.ReadOnly == true) { icolumn++; goto A; }
                                    }
                                }
                            } 
                            grid_flag = 0;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            //// below is for escape key return
            //return base.ProcessCmdKey(ref msg, keyData);
            // below is for enter key return
            return base.ProcessCmdKey(ref msg, keyData);

        }

    }
}
