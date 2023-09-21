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

        DataSet objDSHSN = new DataSet();
        DataSet objDSSubGroup = new DataSet();
        DataSet objDSGroup = new DataSet();
        DataSet objDSBrand = new DataSet();
        DataSet objDSUnit = new DataSet();
        DataSet objDSLocation = new DataSet();
        DataSet objDSRack = new DataSet();
        DataSet objDSShelfLifeType = new DataSet();
        DataSet objDSQTYUnit = new DataSet();
        DataSet objDSProductCategory = new DataSet();
        DataSet objDSRMPRO = new DataSet();
        DataSet objDSBatchNo = new DataSet();
        DataSet objDSBatchNoGeneration = new DataSet();

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
                objDataBind.BindComboBoxListSelected("DEF_Status", " STSID =0 OR  STS_ModuleID=1 ORDER BY STSID", "STSID,STS_Name", cmbStatus, "", "STS_Name", "STSID");
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
                txtProductGroup.Text = "";
                txtSubGroup.Text = "";
                txtBrand.Text = "";
                udfnCmbStatus();
                txtProductGroup.Focus();
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
        public void udfnDefalutDSLoad()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                objDSHSN = objDServ.udfnHsnList(0, 0);
                objDSUnit = objDServ.udfnUnitList(0,0);
                objDSGroup = objDServ.udfnGroupList(0, 0, 0, "");
                objDSSubGroup = objDServ.udfnSubGroupList(0,0,"",0,0,"");
                objDSBrand = objDServ.udfnBrandList(0,"",0,0,0,"");
                objDSLocation = objDServ.udfnStockLocationList(0,0,0,0,"");
                objDSRack = objDServ.udfnRackList(0,0,0,0,0,"");
                objDSShelfLifeType = objDServ.udfnMaster(0, 6);
                objDSQTYUnit = objDServ.udfnMaster(2, 0);
                objDSProductCategory = objDServ.udfnMaster(0, 5);
                objDSRMPRO = objDServ.udfnMaster(1, 0);
                objDSBatchNo = objDServ.udfnMaster(0, 25);
                objDSBatchNoGeneration = objDServ.udfnMaster(0, 26);
                objDServ.CloseConnection();
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdHSN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varHsnId = 0;
                for (int i = 0; i < grdHSN.Rows.Count; i++)
                {
                    varHsnId = 0;
                    var varValue = from r in objDSHSN.Tables[0].AsEnumerable() where (r.Field<string>("HSN Name").ToUpper().Equals(Convert.ToString(grdHSN.Rows[i].Cells["HSN Name-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                    if (varValue.Count() > 0)
                    {
                        varHsnId = Convert.ToInt32(varValue.ToList()[0]);
                        if (varHsnId!=0)
                        {
                            for (int k = 0; k < objDSHSN.Tables[0].Rows.Count; k++)
                            {
                                grdHSN.Rows[i].Cells["HSN_Code-New"].Value = objDSHSN.Tables[0].Rows[k]["HSN Code"];
                                grdHSN.Rows[i].Cells["GST%-New"].Value = objDSHSN.Tables[0].Rows[k]["GST%"];
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
        public void udfnUpdate()
        {
            try
            {
                int varHsnId = 0,varUnitId=0; int varUpdateViewType = 0;
                int varGroupId=0, varSubGroupId =0, varBrandId = 0;
                int varPurSLID = 0, varSalesSLID = 0, varPurRKID = 0, varSalesRKID = 0;
                decimal varRMinSaleQty = 0, varWMinSaleQty = 0;
                decimal varMinStock = 0, varMaxStock = 0,varReOrderQty=0;
                int varUpp = 0, varShelfLifeValue = 0,varShelfLifeTypeID=0;
                decimal varNetQuantity = 0, varGrossWeight = 0; int varUnitQtyId = 0;
                int varPR_PRCTID = 0, PR_RMForProductionID = 0, PR_BatchNoID = 0, PR_BatchNoGenerationID = 0;
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
                
                if (grdHSN.Visible == true)
                {
                    varUpdateViewType = 3; varViewType = 11;
                    for (int i = 0; i < grdHSN.Rows.Count; i++)
                    {
                        varHsnId = 0;
                        var varValue = from r in objDSHSN.Tables[0].AsEnumerable() where (r.Field<string>("HSN Name").ToUpper().Equals(Convert.ToString(grdHSN.Rows[i].Cells["HSN Name-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        if (varValue.Count() > 0) { varHsnId = Convert.ToInt32(varValue.ToList()[0]); }
                        objBulkUpdate.Rows.Add(Convert.ToString(grdHSN.Rows[i].Cells["HSN Name-New"].Value).Trim(), Convert.ToInt32(grdHSN.Rows[i].Cells["HSNOLDID"].Value), varHsnId, grdHSN.Rows[i].Cells["PRID"].Value,
                            0, 0, "", "", "", "", "", "",
                            0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, "",
                            0, "", 0, "", "", "",
                            0, "", 0, "", 0, "",
                            0, "", 0, "", 0, 0,
                            0, "", 0, "", 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0);
                    }
                }
                else if (grdBulkAttributes.Visible == true)
                {
                    varUpdateViewType = 4; varViewType = 12;
                    for (int i = 0; i < grdBulkAttributes.Rows.Count; i++)
                    {
                        varUnitId = 0;
                        var varValue = from r in objDSUnit.Tables[0].AsEnumerable() where (r.Field<string>("Unit").ToUpper().Equals(Convert.ToString(grdBulkAttributes.Rows[i].Cells["Unit-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        if (varValue.Count() > 0) { varUnitId = Convert.ToInt32(varValue.ToList()[0]); }
                        objBulkUpdate.Rows.Add("", 0, 0, Convert.ToInt32(grdBulkAttributes.Rows[i].Cells["PRID"].Value), 
                            Convert.ToInt16(grdBulkAttributes.Rows[i].Cells["UTID-OLD"].Value), varUnitId, Convert.ToString(grdBulkAttributes.Rows[i].Cells["Product Name in English"].Value).Trim(), Convert.ToString(grdBulkAttributes.Rows[i].Cells["Product Name in Tamil"].Value).Trim(), Convert.ToString(grdBulkAttributes.Rows[i].Cells["Product Name in English-New"].Value).Trim(), Convert.ToString(grdBulkAttributes.Rows[i].Cells["Product Name in Tamil-New"].Value).Trim(), Convert.ToString(grdBulkAttributes.Rows[i].Cells["P.I Code"].Value).Trim(), Convert.ToString(grdBulkAttributes.Rows[i].Cells["Product Code-New"].Value).Trim(),
                             0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, "",
                            0, "", 0, "", "", "",
                            0, "", 0, "", 0, "",
                            0, "", 0, "", 0, 0,
                            0, "", 0, "", 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0);
                    }
                }
                else if (grdBrand.Visible == true)
                {
                    varUpdateViewType = 5; varViewType = 10;
                    for (int i = 0; i < grdBrand.Rows.Count; i++)
                    {
                        varGroupId = 0; varSubGroupId = 0; varBrandId = 0;
                        var varGroup = from r in objDSGroup.Tables[0].AsEnumerable() where (r.Field<string>("Product Group Name in English").ToUpper().Equals(Convert.ToString(grdBrand.Rows[i].Cells["Group-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        if (varGroup.Count() > 0)
                        { varGroupId = Convert.ToInt32(varGroup.ToList()[0]); }
                        var varSubGroup = from r in objDSSubGroup.Tables[0].AsEnumerable() where (r.Field<string>("Product Sub Group Name in English").ToUpper().Equals(Convert.ToString(grdBrand.Rows[i].Cells["Sub Group-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        if (varSubGroup.Count() > 0)
                        { varSubGroupId = Convert.ToInt32(varSubGroup.ToList()[0]); }
                        var varBrand = from r in objDSBrand.Tables[0].AsEnumerable() where (r.Field<string>("Brand Name in English").ToUpper().Equals(Convert.ToString(grdBrand.Rows[i].Cells["Brand-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        if (varBrand.Count() > 0)
                        { varBrandId = Convert.ToInt32(varBrand.ToList()[0]); }
                        objBulkUpdate.Rows.Add("", 0, 0, Convert.ToInt32(grdBrand.Rows[i].Cells["PRID"].Value),
                            0, 0, "", "", "", "", "", "",
                            Convert.ToInt32(grdBrand.Rows[i].Cells["PRGID-Old"].Value), varGroupId, Convert.ToInt32(grdBrand.Rows[i].Cells["PRSGID-Old"].Value), varSubGroupId, Convert.ToInt32(grdBrand.Rows[i].Cells["BDID-Old"].Value), varBrandId,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, "",
                            0, "", 0, "", "", "",
                            0, "", 0, "", 0, "",
                            0, "", 0, "", 0, 0,
                            0, "", 0, "", 0, 0,
                            0, 0, 0, 0, 0, 0, 0, 0);
                    }
                }
                else if (grdLoction.Visible == true)
                {
                    varUpdateViewType = 6; varViewType = 4;
                    for (int i = 0; i < grdLoction.Rows.Count; i++)
                    {
                        varPurSLID = 0; varSalesSLID = 0; varPurRKID = 0; varSalesRKID = 0;
                        var varPurStockLocation = from r in objDSLocation.Tables[0].AsEnumerable() where (r.Field<string>("Location Name in English").ToUpper().Equals(Convert.ToString(grdLoction.Rows[i].Cells["Pur.Stock Location-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        if (varPurStockLocation.Count() > 0)
                        { varPurSLID = Convert.ToInt32(varPurStockLocation.ToList()[0]); }
                        var varSalesStockLocation = from r in objDSLocation.Tables[0].AsEnumerable() where (r.Field<string>("Location Name in English").ToUpper().Equals(Convert.ToString(grdLoction.Rows[i].Cells["Sales Location-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        if (varSalesStockLocation.Count() > 0)
                        { varSalesSLID = Convert.ToInt32(varSalesStockLocation.ToList()[0]); }
                        var varPurRack = from r in objDSRack.Tables[0].AsEnumerable() where (r.Field<string>("Rack Name").ToUpper().Equals(Convert.ToString(grdLoction.Rows[i].Cells["Pur.Rack-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        if (varPurRack.Count() > 0)
                        { varPurRKID = Convert.ToInt32(varPurRack.ToList()[0]); }
                        var varSalesRack = from r in objDSRack.Tables[0].AsEnumerable() where (r.Field<string>("Rack Name").ToUpper().Equals(Convert.ToString(grdLoction.Rows[i].Cells["Sales Rack-New"].Value).Trim().ToUpper())) group r by r.Field<int>("ID") into g select g.Key;
                        if (varSalesRack.Count() > 0)
                        { varSalesRKID = Convert.ToInt32(varSalesRack.ToList()[0]); }
                        objBulkUpdate.Rows.Add("", 0, 0, Convert.ToInt32(grdLoction.Rows[i].Cells["PRID"].Value),
                                               0, 0, "", "", "", "", "", "",
                                               0, 0, 0, 0, 0, 0,
                                               Convert.ToInt32(grdLoction.Rows[i].Cells["Pur_SLID-Old"].Value), varPurSLID,Convert.ToInt32(grdLoction.Rows[i].Cells["Sales_SLID-Old"].Value), varSalesSLID,
                                               Convert.ToInt32(grdLoction.Rows[i].Cells["Pur_RKID-Old"].Value), varPurRKID,  Convert.ToInt32(grdLoction.Rows[i].Cells["Sales_RKID-Old"].Value), varSalesRKID,
                                               Convert.ToInt32(grdLoction.Rows[i].Cells["Rack MSQ-Current"].Value), Convert.ToString(grdLoction.Rows[i].Cells["Rack MSQ-New"].Value).Trim(),
                                               0, "", 0, "", "", "",
                                               0, "", 0, "", 0, "",
                                               0, "", 0, "", 0, 0,
                                               0, "", 0, "", 0, 0,
                                               0, 0, 0, 0, 0, 0, 0, 0);
                    }
                }
                else if (grdMSQ.Visible == true)
                {
                    varUpdateViewType = 7; varViewType = 5;
                    for (int i = 0; i < grdMSQ.Rows.Count; i++)
                    {
                        varRMinSaleQty = 0;  varWMinSaleQty = 0;
                        if(Convert.ToString(grdMSQ.Rows[i].Cells["R Min Sale Qty-Current"].Value)=="")
                        { varRMinSaleQty = 0; }
                        else { varRMinSaleQty = Convert.ToDecimal(grdMSQ.Rows[i].Cells["R Min Sale Qty-Current"].Value); }
                        if(Convert.ToString(grdMSQ.Rows[i].Cells["W.Min Sale Qty-Current"].Value)=="")
                        { varWMinSaleQty = 0; }
                        else { varWMinSaleQty = Convert.ToDecimal(grdMSQ.Rows[i].Cells["W.Min Sale Qty-Current"].Value); }
                        objBulkUpdate.Rows.Add("", 0, 0, Convert.ToInt32(grdMSQ.Rows[i].Cells["PRID"].Value),
                                               0, 0, "", "", "", "", "", "",
                                               0, 0, 0, 0, 0, 0,
                                              0, 0, 0, 0, 0, 0, 0, 0, 0, "",
                                              varRMinSaleQty, Convert.ToString(grdMSQ.Rows[i].Cells["R Min Sale Qty-New"].Value).Trim(),varWMinSaleQty, Convert.ToString(grdMSQ.Rows[i].Cells["W.Min Sale Qty-New"].Value).Trim(), 
                                               Convert.ToString(grdMSQ.Rows[i].Cells["Barcode-Current"].Value).Trim(), Convert.ToString(grdMSQ.Rows[i].Cells["Barcode-New"].Value).Trim(),
                                                0, "", 0, "", 0, "",
                                               0, "", 0, "", 0, 0,
                                               0, "", 0, "", 0, 0,
                                               0, 0, 0, 0, 0, 0, 0, 0);

                    }
                }
                else if(grdStock.Visible==true)
                {
                    varUpdateViewType = 8; varViewType = 6;
                    for (int i = 0; i < grdStock.Rows.Count; i++)
                    {
                        varMinStock = 0; varMaxStock = 0; varReOrderQty = 0;
                        if (Convert.ToString(grdStock.Rows[i].Cells["Min Stock-Current"].Value) == "")
                        { varMinStock = 0; }
                        else { varMinStock = Convert.ToDecimal(grdStock.Rows[i].Cells["Min Stock-Current"].Value); }
                        if (Convert.ToString(grdStock.Rows[i].Cells["Max Stock-Current"].Value) == "")
                        { varMaxStock = 0; }
                        else { varMaxStock = Convert.ToDecimal(grdStock.Rows[i].Cells["Max Stock-Current"].Value); }
                        if (Convert.ToString(grdStock.Rows[i].Cells["Reorder Qty-Current"].Value) == "")
                        { varReOrderQty = 0; }
                        else { varReOrderQty = Convert.ToDecimal(grdStock.Rows[i].Cells["Reorder Qty-Current"].Value); }
                        objBulkUpdate.Rows.Add("", 0, 0, Convert.ToInt32(grdStock.Rows[i].Cells["PRID"].Value),
                                               0, 0, "", "", "", "", "", "",
                                               0, 0, 0, 0, 0, 0,
                                              0, 0, 0, 0, 0, 0, 0, 0, 0, "",0,"",0,"","","",
                                              varMinStock, Convert.ToString(grdStock.Rows[i].Cells["Min Stock-New"].Value).Trim(), varMaxStock, Convert.ToString(grdStock.Rows[i].Cells["Max Stock-New"].Value).Trim(),
                                               varReOrderQty, Convert.ToString(grdStock.Rows[i].Cells["Reorder Qty-New"].Value).Trim(),
                                               0, "", 0, "", 0, 0,
                                               0, "", 0, "", 0, 0,
                                               0, 0, 0, 0, 0, 0, 0, 0);
                    }
                }
                else if(grdShelfLife.Visible==true)
                {
                    varUpdateViewType = 9; varViewType = 7;
                    for (int i = 0; i < grdShelfLife.Rows.Count; i++)
                    {
                        varUpp = 0; varShelfLifeValue = 0; varShelfLifeTypeID = 0;
                        var varValue = from r in objDSShelfLifeType.Tables[0].AsEnumerable() where (r.Field<string>("MST_DisplayText").ToUpper().Equals(Convert.ToString(grdShelfLife.Rows[i].Cells["Shelf Life Type-New"].Value).Trim().ToUpper())) group r by r.Field<int>("MSTID") into g select g.Key;
                        if (varValue.Count() > 0) { varShelfLifeTypeID = Convert.ToInt32(varValue.ToList()[0]); }
                        if (Convert.ToString(grdShelfLife.Rows[i].Cells["UPP-Current"].Value) == "")
                        { varUpp = 0; }
                        else { varUpp = Convert.ToInt32(grdShelfLife.Rows[i].Cells["UPP-Current"].Value); }
                        if (Convert.ToString(grdShelfLife.Rows[i].Cells["Shelf Life-Current"].Value) == "")
                        { varShelfLifeValue = 0; }
                        else { varShelfLifeValue = Convert.ToInt32(grdShelfLife.Rows[i].Cells["Shelf Life-Current"].Value); }
                        objBulkUpdate.Rows.Add("", 0, 0, Convert.ToInt32(grdShelfLife.Rows[i].Cells["PRID"].Value),
                                               0, 0, "", "", "", "", "", "",
                                               0, 0, 0, 0, 0, 0,
                                              0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, "", 0, "", "", "",
                                              0, "", 0, "", 0, "",
                                              varUpp, Convert.ToString(grdShelfLife.Rows[i].Cells["UPP-New"].Value).Trim(), varShelfLifeValue, Convert.ToString(grdShelfLife.Rows[i].Cells["Shelf Life-New"].Value).Trim(),
                                               Convert.ToInt32(grdShelfLife.Rows[i].Cells["Shelf Life Type ID-OLD"].Value),varShelfLifeTypeID,
                                               0, "", 0, "", 0, 0,
                                               0, 0, 0, 0, 0, 0, 0, 0);
                    }
                }
                else if(grdWeight.Visible==true)
                {
                    varUpdateViewType = 10; varViewType = 9;
                    for (int i = 0; i < grdWeight.Rows.Count; i++)
                    {
                        varNetQuantity = 0;varGrossWeight = 0; varUnitQtyId = 0;
                        var varValue = from r in objDSQTYUnit.Tables[0].AsEnumerable() where (r.Field<string>("QUT_Symbol").ToUpper().Equals(Convert.ToString(grdWeight.Rows[i].Cells["Net Weight-Unit-New"].Value).Trim().ToUpper())) group r by r.Field<int>("QUTID") into g select g.Key;
                        if (varValue.Count() > 0) { varUnitQtyId = Convert.ToInt32(varValue.ToList()[0]); }
                        if (Convert.ToString(grdWeight.Rows[i].Cells["Net Quantity-Current"].Value) == "")
                        { varNetQuantity = 0; }
                        else { varNetQuantity = Convert.ToDecimal(grdWeight.Rows[i].Cells["Net Quantity-Current"].Value); }
                        if (Convert.ToString(grdWeight.Rows[i].Cells["Gross Weight-Current"].Value) == "")
                        { varGrossWeight = 0; }
                        else { varGrossWeight = Convert.ToDecimal(grdWeight.Rows[i].Cells["Gross Weight-Current"].Value); }
                        objBulkUpdate.Rows.Add("", 0, 0, Convert.ToInt32(grdWeight.Rows[i].Cells["PRID"].Value),
                                               0, 0, "", "", "", "", "", "",
                                               0, 0, 0, 0, 0, 0,
                                              0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, "", 0, "", "", "",
                                              0, "", 0, "", 0, "",
                                              0, "", 0, "", 0, 0,
                                            varNetQuantity, Convert.ToString(grdWeight.Rows[i].Cells["Net Quantity-New"].Value).Trim(),
                                            varGrossWeight, Convert.ToString(grdWeight.Rows[i].Cells["Gross Weight-New"].Value).Trim(),
                                            Convert.ToInt32(grdWeight.Rows[i].Cells["PR_QUTID-Old"].Value), varUnitQtyId,
                                            0, 0, 0, 0, 0, 0, 0, 0);
                    }
                }
                else if (grdBatch.Visible == true)
                {
                    varUpdateViewType = 11; varViewType = 8;
                    for (int i = 0; i < grdBatch.Rows.Count; i++)
                    {
                        varPR_PRCTID = 0; PR_RMForProductionID = 0; PR_BatchNoID = 0; PR_BatchNoGenerationID = 0;
                        var varPR_PRCTValue = from r in objDSProductCategory.Tables[0].AsEnumerable() where (r.Field<string>("MST_DisplayText").ToUpper().Equals(Convert.ToString(grdBatch.Rows[i].Cells["Product Category-New"].Value).Trim().ToUpper())) group r by r.Field<int>("MSTID") into g select g.Key;
                        if (varPR_PRCTValue.Count() > 0) { varPR_PRCTID = Convert.ToInt32(varPR_PRCTValue.ToList()[0]); }
                        var varRMForProductionValue = from r in objDSRMPRO.Tables[0].AsEnumerable() where (r.Field<string>("DisplayText").ToUpper().Equals(Convert.ToString(grdBatch.Rows[i].Cells["RM Pro-New"].Value).Trim().ToUpper())) group r by r.Field<int>("MSTID") into g select g.Key;
                        if (varRMForProductionValue.Count() > 0) { PR_RMForProductionID = Convert.ToInt32(varRMForProductionValue.ToList()[0]); }
                        var varBatchNoValue = from r in objDSBatchNo.Tables[0].AsEnumerable() where (r.Field<string>("MST_DisplayText").ToUpper().Equals(Convert.ToString(grdBatch.Rows[i].Cells["Batch No.-New"].Value).Trim().ToUpper())) group r by r.Field<int>("MSTID") into g select g.Key;
                        if (varBatchNoValue.Count() > 0) { PR_BatchNoID = Convert.ToInt32(varBatchNoValue.ToList()[0]); }
                        var varBatchNoGenerationValue = from r in objDSBatchNoGeneration.Tables[0].AsEnumerable() where (r.Field<string>("MST_DisplayText").ToUpper().Equals(Convert.ToString(grdBatch.Rows[i].Cells["Batch Generation-New"].Value).Trim().ToUpper())) group r by r.Field<int>("MSTID") into g select g.Key;
                        if (varBatchNoGenerationValue.Count() > 0) { PR_BatchNoGenerationID = Convert.ToInt32(varBatchNoGenerationValue.ToList()[0]); }
                        objBulkUpdate.Rows.Add("", 0, 0, Convert.ToInt32(grdBatch.Rows[i].Cells["PRID"].Value),
                                               0, 0, "", "", "", "", "", "",
                                               0, 0, 0, 0, 0, 0,
                                               0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, "", 0, "", "", "",
                                               0, "", 0, "", 0, "",
                                               0, "", 0, "", 0, 0,
                                               0, "", 0, "", 0, 0,
                                               Convert.ToInt32(grdBatch.Rows[i].Cells["PR_PRCTID-Current"].Value), varPR_PRCTID, 
                                               Convert.ToInt32(grdBatch.Rows[i].Cells["PR_RMForProductionID-Current"].Value), PR_RMForProductionID,
                                               Convert.ToInt32(grdBatch.Rows[i].Cells["PR_BatchNoID-Current"].Value), PR_BatchNoID,
                                               Convert.ToInt32(grdBatch.Rows[i].Cells["PR_BatchNoGenerationID-Current"].Value), PR_BatchNoGenerationID);
                    }
                }
                string result = "";
                SPDataService objDSer = new SPDataService();
                result = objDSer.udfnProductMaster(varUpdateViewType, 0, "", "", "", 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, "", "", "", "Product Bulk Update", 0, objBulkUpdate);
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
        private void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdLoction.Visible == true)
                {
                    if (grdLoction.CurrentCell.OwningColumn.Name == "Rack MSQ-New")
                    { 
                        if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                        {
                            e.Handled = true;
                        }
                        //if ((sender as TextBox).Text.Length >7)
                        //{
                        //    e.Handled = true;
                        //}
                        //if ((e.KeyChar == (char)Keys.Back)) {
                        //    e.Handled = false;
                        //}
                    }
                }
                else if (grdMSQ.Visible == true)
                {
                    if (grdMSQ.CurrentCell.OwningColumn.Name == "R Min Sale Qty-New" || grdMSQ.CurrentCell.OwningColumn.Name == "W.Min Sale Qty-New" || grdMSQ.CurrentCell.OwningColumn.Name == "Barcode-New")
                    {
                        if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.' ))
                        {
                            e.Handled = true;
                        }
                        //only allow one decimal point
                        if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                        {
                            e.Handled = true;
                        }
                    }
                }
                else if (grdStock.Visible == true)
                {
                    if (grdStock.CurrentCell.OwningColumn.Name == "Min Stock-New" || grdStock.CurrentCell.OwningColumn.Name == "Max Stock-New" || grdStock.CurrentCell.OwningColumn.Name == "Reorder Qty-New")
                    {
                        if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                        {
                            e.Handled = true;
                        }
                    }
                    //only allow one decimal point
                    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    {
                        e.Handled = true;
                    }
                }
                else if (grdWeight.Visible == true)
                {
                    if (grdWeight.CurrentCell.OwningColumn.Name == "Net Quantity-New" || grdWeight.CurrentCell.OwningColumn.Name == "Gross Weight-New" )
                    {
                        if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                        {
                            e.Handled = true;
                        }
                    }
                    //only allow one decimal point
                    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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
        public void udfnList()
        {
            try
            {
               // Application.DoEvents();
                grdLoction.DataSource = null;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnproductmasterlist(varViewType, 0, 0, varGroupId, varSubGroupId, "", MainForm.pbUserID, MainForm.pbIpAddress,0,Convert.ToInt32(cmbStatus.SelectedValue),varBrandId,0,0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            if (grdLoction.Visible == true)
                            {
                                grdLoction.DataSource = objDs.Tables[0];
                                grdLoction.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                ((DataGridViewTextBoxColumn)grdLoction.Columns["Rack MSQ-New"]).MaxInputLength = 8;
                                ((DataGridViewTextBoxColumn)grdLoction.Columns["Pur.Stock Location-New"]).MaxInputLength = 50;
                                ((DataGridViewTextBoxColumn)grdLoction.Columns["Sales Location-New"]).MaxInputLength = 50;
                                ((DataGridViewTextBoxColumn)grdLoction.Columns["Pur.Rack-New"]).MaxInputLength = 50;
                                ((DataGridViewTextBoxColumn)grdLoction.Columns["Sales Rack-New"]).MaxInputLength = 50;
                               
                                grdLoction.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdLoction.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdLoction.Columns["Unit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdLoction.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdLoction.Columns["Product Name in English"].Visible = false;
                                grdLoction.Columns["PRID"].Visible = false;
                                grdLoction.Columns["Pur_SLID-Old"].Visible = false;
                                grdLoction.Columns["Sales_SLID-Old"].Visible = false;
                                grdLoction.Columns["Pur_RKID-Old"].Visible = false;
                                grdLoction.Columns["Sales_RKID-Old"].Visible = false;

                                grdLoction.Columns["S.No."].Width = 50;
                                grdLoction.Columns["Product Name in Tamil"].Width = 270;
                                grdLoction.Columns["P.I Code"].Width = 80;
                                grdLoction.Columns["Unit"].Width = 80;
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
                                grdLoction.Columns["Pur.Rack-New"].Width = 120;
                                grdLoction.Columns["Sales Location-Current"].Width = 150;
                                grdLoction.Columns["Sales Location-New"].Width = 120;
                                grdLoction.Columns["Sales Rack -Current"].Width = 120;
                                grdLoction.Columns["Sales Rack-New"].Width = 120;
                                grdLoction.Columns["Rack MSQ-Current"].Width = 120;
                                grdLoction.Columns["Rack MSQ-New"].Width = 120;

                                grdLoction.Columns["Rack MSQ-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdLoction.Columns["Rack MSQ-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdLoction.Columns["Pur.Stock Location-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdLoction.Columns["Sales Location-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdLoction.Columns["Pur.Rack-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdLoction.Columns["Sales Rack-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdLoction.Columns["Rack MSQ-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                            }
                            else if(grdMSQ.Visible==true)
                            {
                                grdMSQ.DataSource = objDs.Tables[0];
                                grdMSQ.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                ((DataGridViewTextBoxColumn)grdMSQ.Columns["R Min Sale Qty-New"]).MaxInputLength = 5;
                                ((DataGridViewTextBoxColumn)grdMSQ.Columns["W.Min Sale Qty-New"]).MaxInputLength = 5;
                                ((DataGridViewTextBoxColumn)grdMSQ.Columns["Barcode-New"]).MaxInputLength = 20;
                               
                                grdMSQ.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdMSQ.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdMSQ.Columns["Unit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdMSQ.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdMSQ.Columns["Product Name in English"].Visible = false;
                                grdMSQ.Columns["PRID"].Visible = false;
                                grdMSQ.Columns["S.No."].Width = 50;
                                grdMSQ.Columns["Product Name in Tamil"].Width = 270;
                                grdMSQ.Columns["P.I Code"].Width = 80;
                                grdMSQ.Columns["Unit"].Width = 80;
                                grdMSQ.Columns["S.No."].Frozen = true;
                                grdMSQ.Columns["P.I Code"].Frozen = true;
                                grdMSQ.Columns["Product Name in Tamil"].Frozen = true;
                                grdMSQ.Columns["Unit"].Frozen = true;
                                grdMSQ.Columns["S.No."].ReadOnly = true;
                                grdMSQ.Columns["P.I Code"].ReadOnly = true;
                                grdMSQ.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdMSQ.Columns["Unit"].ReadOnly = true;

                                grdMSQ.Columns["R Min Sale Qty-Current"].ReadOnly = true;
                                grdMSQ.Columns["R.Rate"].ReadOnly = true;
                                grdMSQ.Columns["W.Min Sale Qty-Current"].ReadOnly = true;
                                grdMSQ.Columns["W.Sale Rate"].ReadOnly = true;
                                grdMSQ.Columns["Barcode-Current"].ReadOnly = true;

                                grdMSQ.Columns["R Min Sale Qty-Current"].Width = 150;
                                grdMSQ.Columns["R Min Sale Qty-New"].Width = 120;
                                grdMSQ.Columns["R.Rate"].Width = 100; 
                                grdMSQ.Columns["W.Min Sale Qty-Current"].Width = 150;
                                grdMSQ.Columns["W.Min Sale Qty-New"].Width = 150;
                                grdMSQ.Columns["W.Sale Rate"].Width = 120;
                                grdMSQ.Columns["Barcode-Current"].Width = 150;
                                grdMSQ.Columns["Barcode-New"].Width = 120;

                                grdMSQ.Columns["R Min Sale Qty-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdMSQ.Columns["W.Min Sale Qty-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdMSQ.Columns["Barcode-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdMSQ.Columns["R Min Sale Qty-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdMSQ.Columns["W.Min Sale Qty-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdMSQ.Columns["Barcode-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdMSQ.Columns["R Min Sale Qty-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdMSQ.Columns["W.Min Sale Qty-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdMSQ.Columns["Barcode-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            else if(grdStock.Visible==true)
                            {
                                grdStock.DataSource = objDs.Tables[0];
                                grdStock.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                ((DataGridViewTextBoxColumn)grdStock.Columns["Min Stock-New"]).MaxInputLength = 5;
                                ((DataGridViewTextBoxColumn)grdStock.Columns["Max Stock-New"]).MaxInputLength = 5;
                                ((DataGridViewTextBoxColumn)grdStock.Columns["Reorder Qty-New"]).MaxInputLength = 5;

                                grdStock.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdStock.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdStock.Columns["Unit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdStock.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdStock.Columns["Product Name in English"].Visible = false;
                                grdStock.Columns["PRID"].Visible = false;
                                grdStock.Columns["S.No."].Width = 50;
                                grdStock.Columns["Product Name in Tamil"].Width = 270;
                                grdStock.Columns["P.I Code"].Width = 80;
                                grdStock.Columns["Unit"].Width = 80;
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

                                grdStock.Columns["Min Stock-Current"].Width = 150;
                                grdStock.Columns["Max Stock-Current"].Width = 150;
                                grdStock.Columns["Reorder Qty-Current"].Width = 150;
                                grdStock.Columns["Min Stock-New"].Width = 150;
                                grdStock.Columns["Max Stock-New"].Width = 150;
                                grdStock.Columns["Reorder Qty-New"].Width = 150;

                                grdStock.Columns["Min Stock-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdStock.Columns["Max Stock-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdStock.Columns["Reorder Qty-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdStock.Columns["Min Stock-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStock.Columns["Max Stock-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStock.Columns["Reorder Qty-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStock.Columns["Min Stock-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStock.Columns["Max Stock-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStock.Columns["Reorder Qty-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            else if(grdShelfLife.Visible==true)
                            {
                                grdShelfLife.DataSource = objDs.Tables[0];
                                grdShelfLife.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                ((DataGridViewTextBoxColumn)grdShelfLife.Columns["UPP-New"]).MaxInputLength = 5;
                                ((DataGridViewTextBoxColumn)grdShelfLife.Columns["Shelf Life-New"]).MaxInputLength = 3;
                                ((DataGridViewTextBoxColumn)grdShelfLife.Columns["Shelf Life Type-New"]).MaxInputLength = 50;

                                grdShelfLife.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdShelfLife.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdShelfLife.Columns["Unit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdShelfLife.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdShelfLife.Columns["Product Name in English"].Visible = false;
                                grdShelfLife.Columns["PRID"].Visible = false;
                                grdShelfLife.Columns["Shelf Life Type ID-OLD"].Visible = false;
                                grdShelfLife.Columns["S.No."].Width = 50;
                                grdShelfLife.Columns["Product Name in Tamil"].Width = 270;
                                grdShelfLife.Columns["P.I Code"].Width = 80;
                                grdShelfLife.Columns["Unit"].Width = 80;
                                grdShelfLife.Columns["S.No."].Frozen = true;
                                grdShelfLife.Columns["P.I Code"].Frozen = true;
                                grdShelfLife.Columns["Product Name in Tamil"].Frozen = true;
                                grdShelfLife.Columns["Unit"].Frozen = true;
                                grdShelfLife.Columns["S.No."].ReadOnly = true;
                                grdShelfLife.Columns["P.I Code"].ReadOnly = true;
                                grdShelfLife.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdShelfLife.Columns["Unit"].ReadOnly = true;

                                grdShelfLife.Columns["Bulk Unit"].Width = 100;
                                grdShelfLife.Columns["UPP-Current"].Width = 100;
                                grdShelfLife.Columns["UPP-New"].Width = 100;
                                grdShelfLife.Columns["Shelf Life-Current"].Width = 120;
                                grdShelfLife.Columns["Shelf Life-New"].Width = 100;
                                grdShelfLife.Columns["Shelf Life Type-Current"].Width = 150;
                                grdShelfLife.Columns["Shelf Life Type-New"].Width = 150;

                                grdShelfLife.Columns["UPP-Current"].ReadOnly = true;
                                grdShelfLife.Columns["Shelf Life-Current"].ReadOnly = true;
                                grdShelfLife.Columns["Shelf Life Type-Current"].ReadOnly = true;
                                grdShelfLife.Columns["Bulk Unit"].ReadOnly = true;

                                grdShelfLife.Columns["UPP-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdShelfLife.Columns["Shelf Life-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdShelfLife.Columns["Shelf Life Type-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdShelfLife.Columns["Shelf Life-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdShelfLife.Columns["UPP-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdShelfLife.Columns["Shelf Life-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdShelfLife.Columns["UPP-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            else if(grdBatch.Visible==true)
                            {
                                grdBatch.DataSource = objDs.Tables[0];
                                grdBatch.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                ((DataGridViewTextBoxColumn)grdBatch.Columns["Product Category-New"]).MaxInputLength = 20;
                                ((DataGridViewTextBoxColumn)grdBatch.Columns["RM Pro-New"]).MaxInputLength = 20;
                                ((DataGridViewTextBoxColumn)grdBatch.Columns["Batch No.-New"]).MaxInputLength = 20;
                                ((DataGridViewTextBoxColumn)grdBatch.Columns["Batch Generation-New"]).MaxInputLength = 20;

                                grdBatch.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBatch.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBatch.Columns["Unit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBatch.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBatch.Columns["Product Name in English"].Visible = false;
                                grdBatch.Columns["PRID"].Visible = false;
                                grdBatch.Columns["PR_BatchNoID-Current"].Visible = false;
                                grdBatch.Columns["PR_PRCTID-Current"].Visible = false;
                                grdBatch.Columns["PR_RMForProductionID-Current"].Visible = false;
                                grdBatch.Columns["PR_BatchNoGenerationID-Current"].Visible = false;

                                grdBatch.Columns["S.No."].Width = 50;
                                grdBatch.Columns["Product Name in Tamil"].Width = 270;
                                grdBatch.Columns["P.I Code"].Width = 80;
                                grdBatch.Columns["Unit"].Width = 80;
                                grdBatch.Columns["S.No."].Frozen = true;
                                grdBatch.Columns["P.I Code"].Frozen = true;
                                grdBatch.Columns["Product Name in Tamil"].Frozen = true;
                                grdBatch.Columns["Unit"].Frozen = true;
                                grdBatch.Columns["S.No."].ReadOnly = true;
                                grdBatch.Columns["P.I Code"].ReadOnly = true;
                                grdBatch.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdBatch.Columns["Unit"].ReadOnly = true;

                                grdBatch.Columns["Product Category-Current"].ReadOnly = true;
                                grdBatch.Columns["RM Pro-Current"].ReadOnly = true;
                                grdBatch.Columns["Batch No.-Current"].ReadOnly = true;
                                grdBatch.Columns["Batch Generation-Current"].ReadOnly = true;

                                grdBatch.Columns["Product Category-Current"].Width = 150;
                                grdBatch.Columns["Product Category-New"].Width = 150;
                                grdBatch.Columns["RM Pro-Current"].Width = 100;
                                grdBatch.Columns["RM Pro-New"].Width = 100;
                                grdBatch.Columns["Batch No.-Current"].Width = 130;
                                grdBatch.Columns["Batch No.-New"].Width = 120;
                                grdBatch.Columns["Batch Generation-Current"].Width = 150;
                                grdBatch.Columns["Batch Generation-New"].Width = 150;

                                grdBatch.Columns["Product Category-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdBatch.Columns["RM Pro-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdBatch.Columns["Batch No.-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdBatch.Columns["Batch Generation-New"].DefaultCellStyle.BackColor = Color.PaleGreen;

                            }
                            else if(grdWeight.Visible==true)
                            {
                                grdWeight.DataSource = objDs.Tables[0];
                                grdWeight.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                ((DataGridViewTextBoxColumn)grdWeight.Columns["Net Quantity-New"]).MaxInputLength = 5;
                                ((DataGridViewTextBoxColumn)grdWeight.Columns["Gross Weight-New"]).MaxInputLength = 5;
                                grdWeight.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdWeight.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdWeight.Columns["Unit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdWeight.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdWeight.Columns["Product Name in English"].Visible = false;
                                grdWeight.Columns["PRID"].Visible = false;
                                grdWeight.Columns["PR_QUTID-Old"].Visible = false;

                                grdWeight.Columns["S.No."].Width = 50;
                                grdWeight.Columns["Product Name in Tamil"].Width = 270;
                                grdWeight.Columns["P.I Code"].Width = 80;
                                grdWeight.Columns["Unit"].Width = 80;
                                grdWeight.Columns["S.No."].Frozen = true;
                                grdWeight.Columns["P.I Code"].Frozen = true;
                                grdWeight.Columns["Product Name in Tamil"].Frozen = true;
                                grdWeight.Columns["Unit"].Frozen = true;
                                grdWeight.Columns["S.No."].ReadOnly = true;
                                grdWeight.Columns["P.I Code"].ReadOnly = true;
                                grdWeight.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdWeight.Columns["Unit"].ReadOnly = true;

                                grdWeight.Columns["Net Quantity-Current"].ReadOnly = true;
                                grdWeight.Columns["Gross Weight-Current"].ReadOnly = true;
                                grdWeight.Columns["Net Weight-Unit-Current"].ReadOnly = true;
                                grdWeight.Columns["Gross Weight-Unit"].ReadOnly = true;

                                grdWeight.Columns["Net Quantity-Current"].Width = 130;
                                grdWeight.Columns["Net Quantity-New"].Width = 120;
                                grdWeight.Columns["Net Weight-Unit-Current"].Width = 130;
                                grdWeight.Columns["Net Weight-Unit-New"].Width = 130;
                                grdWeight.Columns["Gross Weight-Current"].Width = 130;
                                grdWeight.Columns["Gross Weight-New"].Width = 130;
                                grdWeight.Columns["Gross Weight-Unit"].Width = 130;

                                grdWeight.Columns["Net Quantity-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdWeight.Columns["Gross Weight-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdWeight.Columns["Net Weight-Unit-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdWeight.Columns["Net Quantity-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdWeight.Columns["Gross Weight-Current"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdWeight.Columns["Net Quantity-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdWeight.Columns["Gross Weight-New"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                            else if(grdBrand.Visible==true)
                            {
                                grdBrand.DataSource = objDs.Tables[0];
                                grdBrand.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                ((DataGridViewTextBoxColumn)grdBrand.Columns["Group-New"]).MaxInputLength = 100;
                                ((DataGridViewTextBoxColumn)grdBrand.Columns["Sub Group-New"]).MaxInputLength = 100;
                                ((DataGridViewTextBoxColumn)grdBrand.Columns["Brand-New"]).MaxInputLength = 20;

                                grdBrand.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBrand.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBrand.Columns["Unit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBrand.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBrand.Columns["Product Name in English"].Visible = false;
                                grdBrand.Columns["PRID"].Visible = false;
                                grdBrand.Columns["PRGID-Old"].Visible = false;
                                grdBrand.Columns["PRSGID-Old"].Visible = false;
                                grdBrand.Columns["BDID-Old"].Visible = false;

                                grdBrand.Columns["S.No."].Width = 50;
                                grdBrand.Columns["Product Name in Tamil"].Width = 270;
                                grdBrand.Columns["P.I Code"].Width = 80;
                                grdBrand.Columns["Unit"].Width = 80;
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

                                grdBrand.Columns["Group-Current"].Width = 250;
                                grdBrand.Columns["Group-New"].Width = 250;
                                grdBrand.Columns["Sub Group-Current"].Width = 250;
                                grdBrand.Columns["Sub Group-New"].Width = 250;
                                grdBrand.Columns["Brand-Current"].Width = 250;
                                grdBrand.Columns["Brand-New"].Width = 250;

                                grdBrand.Columns["Group-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdBrand.Columns["Sub Group-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdBrand.Columns["Brand-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                            }
                            else if(grdHSN.Visible==true)
                            {
                                grdHSN.DataSource = objDs.Tables[0];
                                grdHSN.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                ((DataGridViewTextBoxColumn)grdHSN.Columns["HSN Name-New"]).MaxInputLength = 20;

                                grdHSN.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdHSN.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdHSN.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdHSN.Columns["Product Name in English"].Visible = false;
                                grdHSN.Columns["PRID"].Visible = false;
                                grdHSN.Columns["HSNOLDID"].Visible = false;
                                grdHSN.Columns["S.No."].Width = 50;
                                grdHSN.Columns["Product Name in Tamil"].Width = 270;
                                grdHSN.Columns["P.I Code"].Width = 80;
                                grdHSN.Columns["Unit"].Width = 80;
                                grdHSN.Columns["S.No."].Frozen = true;
                                grdHSN.Columns["P.I Code"].Frozen = true;
                                grdHSN.Columns["Product Name in Tamil"].Frozen = true;
                                grdHSN.Columns["Unit"].Frozen = true;
                                grdHSN.Columns["S.No."].ReadOnly = true;
                                grdHSN.Columns["P.I Code"].ReadOnly = true;
                                grdHSN.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdHSN.Columns["Unit"].ReadOnly = true;

                                grdHSN.Columns["HSN Name-Current"].ReadOnly = true;

                                grdHSN.Columns["HSN Name-Current"].Width = 150;
                                grdHSN.Columns["HSN Name-New"].Width = 150;
                                grdHSN.Columns["HSN"].Width = 100;
                                grdHSN.Columns["GST%"].Width = 100;

                                grdHSN.Columns["HSN Name-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                            }
                            else if (grdBulkAttributes.Visible == true)
                            {
                                grdBulkAttributes.DataSource = objDs.Tables[0];
                                grdBulkAttributes.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                grdBulkAttributes.Columns["Product Name in Tamil-New"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 10.75F);
                                ((DataGridViewTextBoxColumn)grdBulkAttributes.Columns["Product Code-New"]).MaxInputLength = 10;
                                ((DataGridViewTextBoxColumn)grdBulkAttributes.Columns["Product Name in Tamil-New"]).MaxInputLength = 100;
                                ((DataGridViewTextBoxColumn)grdBulkAttributes.Columns["Product Name in English-New"]).MaxInputLength = 100;
                                
                                grdBulkAttributes.Columns["S.No."].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBulkAttributes.Columns["Product Name in Tamil"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBulkAttributes.Columns["Unit"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBulkAttributes.Columns["P.I Code"].DefaultCellStyle.BackColor = Color.AliceBlue;
                                grdBulkAttributes.Columns["Product Name in English"].Visible = false;
                                grdBulkAttributes.Columns["PRID"].Visible = false;
                                grdBulkAttributes.Columns["UTID-OLD"].Visible = false;

                                grdBulkAttributes.Columns["S.No."].Width = 50;
                                grdBulkAttributes.Columns["Product Name in Tamil"].Width = 270;
                                grdBulkAttributes.Columns["P.I Code"].Width = 80;
                                grdBulkAttributes.Columns["Unit"].Width = 80;
                                grdBulkAttributes.Columns["S.No."].Frozen = true;
                                grdBulkAttributes.Columns["P.I Code"].Frozen = true;
                                grdBulkAttributes.Columns["Product Name in Tamil"].Frozen = true;
                                grdBulkAttributes.Columns["Unit"].Frozen = true;
                                grdBulkAttributes.Columns["S.No."].ReadOnly = true;
                                grdBulkAttributes.Columns["P.I Code"].ReadOnly = true;
                                grdBulkAttributes.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdBulkAttributes.Columns["Unit"].ReadOnly = true;

                                grdBulkAttributes.Columns["Product Code-New"].Width = 130;
                                grdBulkAttributes.Columns["Product Name in Tamil-New"].Width = 250;
                                grdBulkAttributes.Columns["Product Name in English-New"].Width = 250;
                                grdBulkAttributes.Columns["Product Name in English-Current"].Width = 280;
                                grdBulkAttributes.Columns["Unit-New"].Width = 100;

                                grdBulkAttributes.Columns["Product Code-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdBulkAttributes.Columns["Product Name in Tamil-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdBulkAttributes.Columns["Product Name in English-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdBulkAttributes.Columns["Unit-New"].DefaultCellStyle.BackColor = Color.PaleGreen;
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
                        udfnList();
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
                    grdMSQ.Visible = true;
                     varViewType = 5;
                    udfnList();
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
                    grdStock.Visible = true;
                    varViewType = 6;
                    udfnList();
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
                    varViewType = 7;
                    udfnList();
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
                    varViewType = 8;
                    udfnList();
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
                    grdWeight.Visible = true;
                    varViewType = 9;
                    udfnList();
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
                    grdBrand.Visible = true;
                    varViewType = 10;
                    udfnList();
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
                    varViewType = 11;
                    udfnList();
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
                    varViewType = 12;
                    udfnList();
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
                varViewType = 4;
                udfnList();
                udfnDefalutDSLoad();
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
        private void TxtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Visible = false;
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
                if (txtSubGroup.Text.Trim() == "") { varSubGroupId = 0; }
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
                    txtBrand.Focus();
                }
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
                lvBrand.Visible = false;
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
        private void TxtProductGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(8, 0, 0, txtProductGroup.Text.Trim());
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvGroup.Items.Add(objList);
                                }
                                lvGroup.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvGroup.Visible = false;
                    lvGroup.Items.Clear();
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
                if (txtProductGroup.Text != "")
                {
                    DataSet objDgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDgroup = objDserv.udfnGroupList(9, 0, 0, txtProductGroup.Text.Trim());
                    objDserv.CloseConnection();
                    if (objDgroup != null)
                    {
                        if (objDgroup.Tables.Count > 0)
                        {
                            if (objDgroup.Tables[0].Rows.Count > 0)
                            {
                                varGroupId = Convert.ToInt32(objDgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (txtSubGroup.Text != "" )
                {
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDServ = new SPDataService();
                    objDssubgroup = objDServ.udfnSubGroupList(11, 0, "", varGroupId, 0, txtSubGroup.Text.Trim());
                    objDServ.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varSubGroupId = Convert.ToInt32(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                if (txtBrand.Text != "")
                {
                    DataSet objDsBrand = new DataSet();
                    SPDataService objDS = new SPDataService();
                    objDsBrand = objDS.udfnBrandList(8, "", varGroupId, varSubGroupId, 0, txtBrand.Text.Trim());
                    objDS.CloseConnection();
                    if (objDsBrand != null)
                    {
                        if (objDsBrand.Tables.Count > 0)
                        {
                            if (objDsBrand.Tables[0].Rows.Count > 0)
                            {
                                varBrandId = Convert.ToInt32(objDsBrand.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
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
                if (txtSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(8, 0, "", varGroupId, 0, txtSubGroup.Text.Trim());
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {

                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), };
                                    //  string[] row = { objDs.Tables[0].Rows[i]["CTY_NAME"].ToString(), objDs.Tables[0].Rows[i]["ST_NAME"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
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
        public void udfnLvSubGroup()
        {
            try
            {
                if (txtSubGroup.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    txtSubGroup.Text = selectedItem.SubItems[0].Text;
                    varSubGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvSubGroup.Visible = false;
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
                udfnLvSubGroup();
                txtBrand.Focus();
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
                    udfnLvSubGroup();
                    txtBrand.Focus();
                }
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
        private void TxtProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvGroup.Items.Count == 0 || txtProductGroup.Text == "")
                    {
                        txtProductGroup.Focus();
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
                    txtSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.White;
                if (txtProductGroup.Text.Trim() == "") { varGroupId = 0; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvGroup()
        {
            try
            {
                if (txtProductGroup.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    txtProductGroup.Text = selectedItem.SubItems[0].Text;
                    varGroupId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvGroup.Visible = false;
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
            try
            {
                udfnLvGroup();
                txtSubGroup.Focus();
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
                    udfnLvGroup();
                    txtSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdBrand_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TxtBrand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvBrand.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtBrand.Text.Length > 0)
                {
                    objDs = objspdservice.udfnBrandList(7, "", varGroupId, varSubGroupId, 0, txtBrand.Text.Trim());
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["BD_EName"].ToString(), objDs.Tables[0].Rows[i]["BD_TName"].ToString(), objDs.Tables[0].Rows[i]["BDID"].ToString(), };
                                    ListViewItem objList = new ListViewItem(row);
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
                lvSubGroup.Visible = false;
                txtBrand.BackColor = Color.LemonChiffon;
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
                txtBrand.BackColor = Color.White;
                if (txtBrand.Text.Trim() == "") { varBrandId = 0; }
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
                    cmbStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvBrand()
        {
            try
            {
                if (txtBrand.Text.Trim() != "")
                {
                    ListViewItem selectedItem = lvBrand.SelectedItems[0];
                    txtBrand.Text = selectedItem.SubItems[0].Text;
                    varBrandId = Convert.ToInt32(selectedItem.SubItems[2].Text);
                    lvBrand.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvBrand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvBrand();
                    cmbStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvBrand_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvBrand();
                cmbStatus.Focus();
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
                //(grdSupplierMappingLoad.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtSearchByProduct1.Text + "%' OR ([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%'";
                if (grdLoction.Visible == true)
                { (grdLoction.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtProductName.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdMSQ.Visible == true)
                { (grdMSQ.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtProductName.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdStock.Visible == true)
                { (grdStock.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtProductName.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdWeight.Visible == true)
                { (grdWeight.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtProductName.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdShelfLife.Visible == true)
                { (grdShelfLife.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtProductName.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdBatch.Visible == true)
                { (grdBatch.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtProductName.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdBrand.Visible == true)
                { (grdBrand.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtProductName.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdHSN.Visible == true)
                { (grdHSN.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtProductName.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductName.Text + "%'"; }
                else if (grdBulkAttributes.Visible == true)
                { (grdBulkAttributes.DataSource as DataTable).DefaultView.RowFilter = "([Product Name in English]) LIKE '%" + txtProductName.Text + "%' OR ([P.I Code]) LIKE '%" + txtProductName.Text + "%'"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public AutoCompleteStringCollection AutoCompleteHSN()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("select  HSNID, HSN_Name from MR_HSN where HSNID NOT IN(-1, 0) ");
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

        public AutoCompleteStringCollection AutoCompleteLocationName()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT SLID,SL_EName FROM MR_StockLocation WHERE SLID NOT IN (-1,0) ");
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
        public AutoCompleteStringCollection AutoCompleteRackName()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT RKID,RK_Name FROM MR_Rack WHERE RKID NOT IN (-1,0)");
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
        public AutoCompleteStringCollection AutoCompleteBatchGeneration()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT MSTID,MST_DisplayText from DEF_Master where MST_TransactionID = 26");
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

            objds = objdservice.GetDataset("SELECT PRGID,PRG_EName from  MR_ProductGroup  where PRGID NOT IN(-1,0)");
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
        public AutoCompleteStringCollection AutoCompleteSubGroup()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT PRSGID,PRSG_EName from  MR_ProductSubGroup  where PRSGID NOT IN(-1,0)");
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
        public AutoCompleteStringCollection AutoCompleteBrand()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT BDID,BD_EName from  MR_Brand  where BDID NOT IN(-1,0)");
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
        public AutoCompleteStringCollection AutoCompleteUnitSymbol()
        {
            AutoCompleteStringCollection varstr = new AutoCompleteStringCollection();
            DataSet objds;
            objds = null;
            DataService objdservice = new DataService();
            DataTable objDt = new DataTable();

            objds = objdservice.GetDataset("SELECT UTID,UT_Symbol FROM MR_Unit WHERE UTID NOT IN(-1,0)");
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
        private void GrdLoction_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdLoction.CurrentCell.OwningColumn.Name == "Pur.Stock Location-New")
                {
                    TextBox txtPurStockLocation = e.Control as TextBox;
                    if (txtPurStockLocation != null)
                    {
                        txtPurStockLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtPurStockLocation.AutoCompleteCustomSource = AutoCompleteLocationName();
                        txtPurStockLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdLoction.CurrentCell.OwningColumn.Name == "Pur.Rack-New")
                {
                    TextBox txtPurRack = e.Control as TextBox;
                    if (txtPurRack != null)
                    {
                        txtPurRack.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtPurRack.AutoCompleteCustomSource = AutoCompleteRackName();
                        txtPurRack.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdLoction.CurrentCell.OwningColumn.Name == "Sales Location-New")
                {
                    TextBox txtSalesStockLocation = e.Control as TextBox;
                    if (txtSalesStockLocation != null)
                    {
                        txtSalesStockLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtSalesStockLocation.AutoCompleteCustomSource = AutoCompleteLocationName();
                        txtSalesStockLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdLoction.CurrentCell.OwningColumn.Name == "Sales Rack-New")
                {
                    TextBox txtSalesRack = e.Control as TextBox;
                    if (txtSalesRack != null)
                    {
                        txtSalesRack.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtSalesRack.AutoCompleteCustomSource = AutoCompleteRackName();
                        txtSalesRack.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdLoction.CurrentCell.OwningColumn.Name == "Rack MSQ-New")
                {
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
        private void GrdLoction_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //if (Convert.ToString(grdLoction.SelectedCells[0]))
                //{
                //    switch (grdLoction.Columns[].Name)
                //    {
                //        case "Rack MSQ-New":

                //            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                //            {
                //                e.Handled = true;
                //            }
                //            break;
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdShelfLife_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdShelfLife.CurrentCell.OwningColumn.Name == "Shelf Life Type-New")
                {
                    TextBox txtShelfLife = e.Control as TextBox;
                    if (txtShelfLife != null)
                    {
                        txtShelfLife.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtShelfLife.AutoCompleteCustomSource = AutoCompleteShelfLife();
                        txtShelfLife.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdBatch_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdBatch.CurrentCell.OwningColumn.Name == "Product Category-New")
                {
                    TextBox txtProductCategory = e.Control as TextBox;
                    if (txtProductCategory != null)
                    {
                        txtProductCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtProductCategory.AutoCompleteCustomSource = AutoCompleteProductCatergory();
                        txtProductCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdBatch.CurrentCell.OwningColumn.Name == "Batch No.-New")
                {
                    TextBox txtBatchNo = e.Control as TextBox;
                    if (txtBatchNo != null)
                    {
                        txtBatchNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtBatchNo.AutoCompleteCustomSource = AutoCompleteBatchNo();
                        txtBatchNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdBatch.CurrentCell.OwningColumn.Name == "Batch Generation-New")
                {
                    TextBox txtBatchGeneration = e.Control as TextBox;
                    if (txtBatchGeneration != null)
                    {
                        txtBatchGeneration.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtBatchGeneration.AutoCompleteCustomSource = AutoCompleteBatchGeneration();
                        txtBatchGeneration.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdBatch.CurrentCell.OwningColumn.Name == "RM Pro-New")
                {
                    TextBox txtRmPro = e.Control as TextBox;
                    if (txtRmPro != null)
                    {
                        txtRmPro.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtRmPro.AutoCompleteCustomSource = AutoCompleteRmPro();
                        txtRmPro.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                if (grdBrand.CurrentCell.OwningColumn.Name == "Group-New")
                {
                    TextBox txtGroup = e.Control as TextBox;
                    if (txtGroup != null)
                    {
                        txtGroup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtGroup.AutoCompleteCustomSource = AutoCompleteGroup();
                        txtGroup.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdBrand.CurrentCell.OwningColumn.Name == "Sub Group-New")
                {
                    TextBox SubGroup = e.Control as TextBox;
                    if (SubGroup != null)
                    {
                        SubGroup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        SubGroup.AutoCompleteCustomSource = AutoCompleteSubGroup();
                        SubGroup.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdBrand.CurrentCell.OwningColumn.Name == "Brand-New")
                {
                    TextBox txtBrand = e.Control as TextBox;
                    if (txtBrand != null)
                    {
                        txtBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtBrand.AutoCompleteCustomSource = AutoCompleteBrand();
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

        private void GrdWeight_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdWeight.CurrentCell.OwningColumn.Name == "Net Weight-Unit-New")
                {
                    TextBox txtUnit = e.Control as TextBox;
                    if (txtUnit != null)
                    {
                        txtUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtUnit.AutoCompleteCustomSource = AutoCompleteUnitSymbol();
                        txtUnit.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                else if (grdWeight.CurrentCell.OwningColumn.Name == "Net Quantity-New")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
                else if (grdWeight.CurrentCell.OwningColumn.Name == "Gross Weight-New")
                {
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

        private void GrdMSQ_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdMSQ.CurrentCell.OwningColumn.Name == "R Min Sale Qty-New")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
                else if (grdMSQ.CurrentCell.OwningColumn.Name == "W.Min Sale Qty-New")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
                else if (grdMSQ.CurrentCell.OwningColumn.Name == "Barcode-New")
                {
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

        private void GrdStock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdStock.CurrentCell.OwningColumn.Name == "Min Stock-New")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
                else if (grdStock.CurrentCell.OwningColumn.Name == "Max Stock-New")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
                else if (grdStock.CurrentCell.OwningColumn.Name == "Reorder Qty-New")
                {
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

        private void GrdBulkAttributes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox txtUnit = e.Control as TextBox;
                if (txtUnit != null)
                {
                    txtUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtUnit.AutoCompleteCustomSource = AutoCompleteUnitSymbol();
                    txtUnit.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
