using DocumentFormat.OpenXml.VariantTypes;
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

    public partial class PUR_DCGoodsInward : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpMonth = new ToolTip();
        private ToolTip tpDay = new ToolTip();
        private ToolTip tpYear = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpQty = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        public bool varDiscardFlag = true;
        DataTable dtPurchaseDC = new DataTable();

        public bool VarSearchFlag = true;
        public int expirydateFlag = 0, pbDateflag=0, varShelflife=0, varReturnDCID=0;
        public string varBatchNo = "0";
       public  int varcloseflag=0,varDecimal=0, varUpDownKey=0;
        public string varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0", varExpiryDate = "";
        public string varPICode = "", varTName = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = "",
        varorderSaleQty = "", varorderqty = "", addproductid = "", flag = "", varunitid = "0", pbProductsCode = "", pbunitname = "", varupdate = "0", varpendingPOID = "0", varReturnDC = "0", varDamage = "0", varcomid = "0";
        public int varConcernId = 0, varScheduleId = 0, varSupplierId = 0, varMRPflag = 0, varEditflag = 0, varshelflifeflag = 0, varDateEnable = 0;
        public string varReturnDCDate = "", varErrQty="0";
        public string varTodayDate = "",varExchangeReturns="";
        decimal ProShelflife = 0;
        public PUR_DCGoodsInward()
        {
            InitializeComponent();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (varDiscardFlag == false)
                {
                    udfnDiscard();
                }
                else
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
        public void udfnDiscard()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to discard changes ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        private void PUR_DCGoodsInward_Load(object sender, EventArgs e)
        {
            try
            {
                varTodayDate = Convert.ToString(MainForm.pbCurrentDate);
                dpExpProReturnDCDate.Text = Convert.ToString(MainForm.pbCurrentDate);
                udfnUddtTable();
                if(MainForm.objPUR_PurchaseReturns.varStatusId==16)
                {
                    if (MainForm.objPUR_PurchaseReturns.dtExchangeProducts.Rows.Count != 0)
                    {
                        // dtPurchaseDC.DataSet = MainForm.objPUR_PurchaseReturns.dtExchangeProducts;
                        dtPurchaseDC = (MainForm.objPUR_PurchaseReturns.dtExchangeProducts).Copy();
                        for (int i = 0; i < dtPurchaseDC.Rows.Count; i++)
                        {
                            MR_Product objMR_Product = new MR_Product();
                            objMR_Product.paraViewType = 34;
                            objMR_Product.ParaProductCode = Convert.ToInt32(dtPurchaseDC.Rows[i]["DCPR_PRID"].ToString());
                            objMR_Product.ParaScheduleid = Convert.ToString(varScheduleId);
                            objMR_Product.ParaSupplierId = varSupplierId;
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                            objspdservice.CloseConnection();
                            if (objDs != null)
                            {
                                if (objDs.Tables[0].Rows.Count > 0)
                                {
                                    flag = objDs.Tables[0].Rows[0]["PRODUCTEXP"].ToString();
                                }
                            }
                            int varflag = 0; ProShelflife = 0; int Shelflifevalue = 0, ProShelfLifeType = 0, ProShelflifeValue = 0;
                            string varShelflifevalue = "", varAcutalshelflife = "";
                            //if (varExpiryDate != "")
                            //{
                                SPDataService objDServ = new SPDataService();
                                DataSet objDS = new DataSet();
                                MR_Master objMR_Master = new MR_Master();
                                objMR_Master.ViewType = 7;
                                objMR_Master.paraDate = varReturnDCDate;
                                objMR_Master.ParaExpiryDate = Convert.ToString(dtPurchaseDC.Rows[i]["DCPR_ExpiryDate"].ToString());
                                objMR_Master.paraProductId = Convert.ToInt32(dtPurchaseDC.Rows[i]["DCPR_PRID"].ToString());
                                objDS = objDServ.udfnMaster(objMR_Master);
                                objDServ.CloseConnection();
                                if (Convert.ToInt32(dtPurchaseDC.Rows[i]["DCPR_Shelflifeflag"]) == 1)
                                {
                                    if (objDS.Tables[0].Rows.Count > 0)
                                    {
                                        if (Convert.ToString(objDS.Tables[0].Rows[0]["DATEVALIDATE"]) != "0")
                                        {
                                            if (objDS.Tables[1].Rows.Count > 0)
                                            {
                                                varShelflifevalue = Convert.ToString(objDS.Tables[1].Rows[0]["SHELFLIFE"]);
                                                string[] varProShelfLife = varShelflifevalue.Split(' ');
                                                if (Convert.ToString(varProShelfLife[0]) != "")
                                                {
                                                    ProShelflife = Convert.ToDecimal(varProShelfLife[0]);
                                                }
                                            }
                                            if (objDS.Tables[2].Rows.Count > 0)
                                            {
                                                varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                                                string[] varShelflifevaluesplit = varAcutalshelflife.Split(' ');
                                                if (Convert.ToString(varShelflifevaluesplit[0]) != "")
                                                {
                                                    Shelflifevalue = Convert.ToInt32(varShelflifevaluesplit[0]);
                                                }
                                            }
                                            if (objDS.Tables[3].Rows.Count > 0)
                                            {
                                                ProShelfLifeType = Convert.ToInt32(objDS.Tables[3].Rows[0]["PR_ShelfLifeType"]);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (objDS.Tables[2].Rows.Count > 0)
                                    {
                                        varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                                    }
                                }
                            //}

                            grdProductExchage.Rows.Add(i+1, dtPurchaseDC.Rows[i]["P.I Code"].ToString(),
                            dtPurchaseDC.Rows[i]["ProductName"].ToString(),
                            Convert.ToDecimal(dtPurchaseDC.Rows[i]["DCPR_MRP"]),
                            dtPurchaseDC.Rows[i]["DCPR_ExpiryDate"].ToString(), (flag).Trim(), varAcutalshelflife, varShelflifevalue, dtPurchaseDC.Rows[i]["DCPR_BatchNo"].ToString(),
                            dtPurchaseDC.Rows[i]["DCPR_Qty"].ToString(), dtPurchaseDC.Rows[i]["Unit"].ToString(), dtPurchaseDC.Rows[i]["Location"].ToString(), dtPurchaseDC.Rows[i]["Rack"].ToString(),
                            dtPurchaseDC.Rows[i]["DCPR_PRID"].ToString(), dtPurchaseDC.Rows[i]["DCPR_SLID"].ToString(),
                            dtPurchaseDC.Rows[i]["DCPR_RKID"].ToString(), Convert.ToString(dtPurchaseDC.Rows[i]["DCPR_UTID"]),0,0,0, Convert.ToInt32(dtPurchaseDC.Rows[i]["DCPR_MRPflag"]), Convert.ToInt32(dtPurchaseDC.Rows[i]["DCPR_Shelflifeflag"])
                            );

                            string[] varShelflifeper = Convert.ToString(ProShelflife).Split(' ');
                            if (varShelflifeper[0] != "")
                            {
                                if (Convert.ToDecimal(varShelflifeper[0]) > (MainForm.pbShelflifeLevel1) + 1 && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel2))
                                {
                                    DataGridView dataGridView = grdProductExchage;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                    cell.Style.BackColor = Color.Orange;
                                    cell.Style.ForeColor = Color.Black;
                                }
                                else if (Convert.ToDecimal(varShelflifeper[0]) > 0 && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel1))
                                {
                                    DataGridView dataGridView = grdProductExchage;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                    cell.Style.BackColor = Color.Red;
                                    cell.Style.ForeColor = Color.White;
                                }
                                else
                                {
                                    DataGridView dataGridView = grdProductExchage;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                                    cell.Style.BackColor = Color.White;
                                    cell.Style.ForeColor = Color.Black;
                                }
                            }

                        }
                        grdProductExchage.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdProductExchage.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdProductExchage.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdProductExchage.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdProductExchage.Columns["clmQuantity"].DefaultCellStyle.BackColor = Color.PaleGreen;
                        txtRemark.Text = MainForm.objPUR_PurchaseReturns.varExchangeRemarks;
                        grdProductExchage.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                        udfnProductCount();
                    }
                    this.ActiveControl = txtProductName;
                    txtProductName.Focus();
                }
                else
                {
                    EditLoad();
                    varcloseflag = 1;
                    grdProductExchage.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                    grpproductname.Enabled = false;
                    btnSave.Enabled = false;
                    txtRemark.Enabled = false;
                    grdProductExchage.Columns["clmRemove"].Visible = false;
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
                this.Close(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void EditLoad()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                objTRN_PurchaseReturnDC.paraViewType = 5;
                objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_PurchaseReturnDC.paraReturnDCID = varReturnDCID;
                objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                objDs = objdserv.udfnReturnDC(objTRN_PurchaseReturnDC);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {

                                grdProductExchage.Rows.Add(objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"].ToString(),
                                objDs.Tables[0].Rows[i]["Product Name"].ToString(),
                                Convert.ToDecimal(objDs.Tables[0].Rows[i]["MRP"]),
                                objDs.Tables[0].Rows[i]["Expiry Date"].ToString(), objDs.Tables[0].Rows[i]["Batch No."].ToString(),
                                objDs.Tables[0].Rows[i]["Qty"].ToString(), objDs.Tables[0].Rows[i]["Unit"].ToString(),
                                objDs.Tables[0].Rows[i]["Location"].ToString(), objDs.Tables[0].Rows[i]["Rack"].ToString()
                                , objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(),
                                objDs.Tables[0].Rows[i]["RKID"].ToString(), Convert.ToString(objDs.Tables[0].Rows[i]["UTID"]),0,0,0, Convert.ToInt32(objDs.Tables[0].Rows[i]["PURREDCEX_MRPflag"]),Convert.ToInt32(objDs.Tables[0].Rows[i]["PURREDCEX_ShelfLifeFlag"]) 
                                );

                                dtPurchaseDC.Rows.Add(objDs.Tables[0].Rows[i]["PRID"],
                                string.Format("{0:G29}", decimal.Parse(Convert.ToString(objDs.Tables[0].Rows[i]["MRP"]))), objDs.Tables[0].Rows[i]["Expiry Date"].ToString(),
                                objDs.Tables[0].Rows[i]["Batch No."].ToString(), objDs.Tables[0].Rows[i]["Qty"].ToString(),
                                objDs.Tables[0].Rows[i]["UTID"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(),
                                objDs.Tables[0].Rows[i]["RKID"].ToString(), objDs.Tables[0].Rows[i]["Unit"].ToString(),
                                objDs.Tables[0].Rows[i]["Location"].ToString(), objDs.Tables[0].Rows[i]["Rack"].ToString(), Convert.ToInt32(objDs.Tables[0].Rows[i]["PURREDCEX_MRPflag"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["PURREDCEX_ShelfLifeFlag"]));
                              
                            }
                            txtRemark.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Remarks"]);
                        }
                        grdProductExchage.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdProductExchage.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdProductExchage.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdProductExchage.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                udfnProductCount();
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdProductExchage.ClearSelection();
            }
        }
        public void udfnSave()
        {
            try
            {
                if (grdProductExchage.RowCount > 0)
                {
                    bool varErrorFlag = true;
                    for (int i = 0; i < grdProductExchage.Rows.Count; i++)
                    {
                        if (Convert.ToString(grdProductExchage.Rows[i].Cells["clmQuantity"].Value) == "0")
                        {
                            varErrorFlag = false;
                            grdProductExchage.Rows[i].Cells["clmError"].Value = 1;
                            grdProductExchage.Rows[i].Cells["clmQuantity"].Style.BackColor = Color.LightPink;
                        }
                        else
                        {
                            grdProductExchage.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                            grdProductExchage.Rows[i].Cells["clmQuantity"].Style.BackColor = Color.PaleGreen;
                        }
                    }
                    if (varErrorFlag == true && varErrQty == "0")
                    {
                        udfnTooltipHide(); int varDC_PURID = 0;
                        int varStatusID = 4;
                        if (grdProductExchage.Rows.Count > 0)
                        {
                            string result = "", varorginator = "Return DC exchange products";
                            int varviewtype = 1;
                            TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                            objTRN_PurchaseReturnDC.paraViewType = varviewtype;
                            objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                            objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                            objTRN_PurchaseReturnDC.paraOriginator = varorginator;
                            objTRN_PurchaseReturnDC.paraReturnDCID = varReturnDCID;
                            objTRN_PurchaseReturnDC.paraStatusID = Convert.ToInt32(MainForm.objPUR_PurchaseReturns.varStatusId);
                            objTRN_PurchaseReturnDC.paraReturnDC_Date = varTodayDate;
                            objTRN_PurchaseReturnDC.paraExchangeRemarks = txtRemark.Text.Trim();
                            objTRN_PurchaseReturnDC.paraDeleteFlag = 0;
                            objTRN_PurchaseReturnDC.ParaTRN_ReturnDCProducts = dtPurchaseDC;
                            SPDataService objspdservice = new SPDataService();
                            result = objspdservice.udfnPurchaseReturnDc(objTRN_PurchaseReturnDC);
                            objspdservice.CloseConnection();
                            string[] varvalue = result.Split('~');
                            if (varvalue[0] == "3")
                            {
                                MainForm.objPUR_PurchaseReturns.dtExchangeProducts = dtPurchaseDC;
                                MainForm.objPUR_PurchaseReturns.varExchangeRemarks = txtRemark.Text.Trim();
                                MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                varcloseflag = 1;
                                udfnclose();
                            }
                            else if (varvalue[0] == "4")
                            {
                                MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            if (varvalue[0] == "5")
                            {
                                MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                string varProductID = "", Expirydate = "";
                                for (int j = 0; j < grdProductExchage.RowCount; j++)
                                {
                                    grdProductExchage.Rows[j].DefaultCellStyle.BackColor = Color.White;
                                    string[] varFirstList = varvalue[2].Split('|');
                                    for (int i = 0; i < varFirstList.Length; i++)
                                    {
                                        string[] varSecondList = varFirstList[i].Split(',');
                                        varProductID = varSecondList[0];
                                        Expirydate = varSecondList[1];
                                        if (Convert.ToString(grdProductExchage.Rows[j].Cells["clmPRID"].Value) == varProductID && Convert.ToString(grdProductExchage.Rows[j].Cells["clmExpiryDate"].Value) == Expirydate)
                                        {
                                            grdProductExchage.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(100);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void PUR_DCGoodsInward_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    btnSave_Click(sender, e);
                }
                //if (e.KeyCode == Keys.F11)
                //{
                //    if (VarSearchFlag == false)
                //    {
                //        VarSearchFlag = true;
                //        lblProductName.Text = "Search by P.I Code";
                //    }
                //    else
                //    {
                //        VarSearchFlag = false;
                //        lblProductName.Text = "Search by Product Name";
                //    }
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbLocation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //grbLocation.BringToFront();
                //grbrack.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Rbrack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
               // grbrack.BringToFront();
                //grbLocation.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void PUR_DCGoodsInward_Leave(object sender, EventArgs e)
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

        private void PUR_DCGoodsInward_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varcloseflag == 0)
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
                if (txtProductName.Text.Trim() == "")
                {
                    epProductExchange.SetError(txtProductName, "Please enter product.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                }
                else
                {
                    epProductExchange.Clear();
                    txtProductName.BackColor = Color.White;
                    tpProduct.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblProductName.Text = "Search by P.I Code";
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductName.Text = "Search by Product Name";
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                /*
                if (e.KeyCode == Keys.Enter)
                {
                    txtMrp.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvproduct.Items.Count == 0 || txtProductName.Text == "")
                    {
                        txtProductName.Focus();
                        lvproduct.Visible = false;
                    }
                    else
                    {
                        lvproduct.Focus();
                    }
                    if (lvproduct.Items.Count > 0)
                    {
                        lvproduct.Items[0].Selected = true;
                    }
                }
                */
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
                                    udfnListviewProduct();
                                    txtMrp.Focus();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
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
                        txtMrp.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMrp_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                lvproduct.Visible = false;
                txtMrp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMrp.BackColor = Color.White;
                if (txtMrp.Text.Trim() != "")
                {
                    //string mrp = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                    txtMrp.Text = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDay.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtDay_Enter(object sender, EventArgs e)
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
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtDay_Leave(object sender, EventArgs e)
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
        private void TxtDay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDay.Text.Length == 2)
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
        private void TxtMonth_Enter(object sender, EventArgs e)
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
        private void TxtMonth_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtMonth_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtRack.Enabled == true)
                    { txtRack.Focus(); }
                    else
                    { btnAdd.Focus(); }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvStockLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        txtStockLocation.Focus();
                        lvStockLocation.Visible = false;
                    }
                    else
                    {
                        lvStockLocation.Focus();
                    }
                    if (lvStockLocation.Items.Count > 0)
                    {
                        lvStockLocation.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtStockLocation.Text.Trim() == "")
                {
                    txtStockLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductExchange.SetError(txtStockLocation, "Please enter stock location.");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location.", txtStockLocation, 5000);
                    txtRack.Enabled = true;
                }
                else
                {
                    txtStockLocation.BackColor = Color.White;
                    epProductExchange.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStockLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0)
                {
                    objDs = objspdservice.udfnStockLocationList(26,varConcernId, 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0, "", "",0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_TName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvStockLocation.Items.Add(objList);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                }
                                lvStockLocation.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvStockLocation.Visible = false;
                    lvStockLocation.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtStockLocation.Focus();
            }
        }
        public void udfnPurLocationAutocomplete()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    ListViewItem selectedItem = lvStockLocation.SelectedItems[0];
                    txtStockLocation.Text = selectedItem.SubItems[0].Text;
                    lblStockLocationCode.Text = selectedItem.SubItems[2].Text;
                    lvStockLocation.Visible = false;
                    txtRack.Text = "";
                    lblRackCode.Text = "0";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvStockLocation.Visible = false;
            }
        }
        private void LvStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPurLocationAutocomplete();
                    if (txtRack.Enabled == false)
                    { btnAdd.Focus(); }
                    else
                    { txtRack.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvStockLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnPurLocationAutocomplete();
                if (txtRack.Enabled == false)
                { txtRack.Focus(); }
                else
                { btnAdd.Focus(); }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtRack.Text == "")
                {
                    txtRack.Enabled = true;
                }
                lvStockLocation.Visible = false;
                txtRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvRack.Items.Count == 0 || txtRack.Text == "")
                    {
                        txtRack.Focus();
                        lvRack.Visible = false;
                    }
                    else
                    {
                        lvRack.Focus();
                    }
                    if (lvRack.Items.Count > 0)
                    {
                        lvRack.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRack.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, Convert.ToInt32(lblStockLocationCode.Text), 0, txtRack.Text.Trim(), 0, 0);
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
                                    lvRack.Items.Add(objList);
                                }
                                lvRack.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    lvRack.Visible = false;
                    lvRack.Items.Clear();
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
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                    lblRackCode.Text = selectedItem.SubItems[2].Text;
                    lvRack.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvRack.Visible = false;
            }
        }
        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnPurRackAutocomplete();
                btnAdd.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnPurRackAutocomplete();
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductCount()
        {
            try
            {
                txtTotalProducts.Text = Convert.ToString(grdProductExchage.Rows.Count);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRemark_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRemark.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRemark_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRemark.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
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
        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int varDecimal = Convert.ToInt32(grdProductExchage.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdProductExchage.CurrentCell.OwningColumn.Name == "clmQuantity")
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
                        if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                        {
                            e.Handled = true;
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

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
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
                                udfnListviewProduct();
                                txtMrp.Focus();
                                DGV_FilterProduct.Visible = false;
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
                    if (txtMrp.Enabled == true)
                    {
                        txtMrp.Focus();
                    }
                    else if (txtDay.Enabled == true)
                    {
                        txtDay.Focus();
                    }
                    else if (txtBatchNo.Enabled == true)
                    {
                        txtBatchNo.Focus();
                    }
                    else
                    {
                        txtActualQty.Focus();
                    }
                }
            }
        }

        private void TxtYear_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GrdProductExchage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdProductExchage.CurrentCell.OwningColumn.Name == "clmQuantity")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdProductExchage.CurrentCell.OwningColumn.Name == "clmQuantity")
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

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                udfnListviewProduct();
                if (txtMrp.Enabled == true)
                {
                    txtMrp.Focus();
                }
                else if (txtDay.Enabled == true)
                {
                    txtDay.Focus();
                }
                else if (txtBatchNo.Enabled == true)
                {
                    txtBatchNo.Focus();
                }
                else
                {
                    txtActualQty.Focus();
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
                if (grdProductExchage.CurrentCell.OwningColumn.Name == "clmQuantity")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdProductExchage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (grdProductExchage.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdProductExchage.SelectedRows[0].Cells["clmPRID"].Value);
                                DataGridViewRow row = grdProductExchage.Rows[e.RowIndex];
                                grdProductExchage.Rows.Remove(row);
                                for (int i = 0; i < dtPurchaseDC.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtPurchaseDC.Rows[i]["DCPR_PRID"]) == Convert.ToInt32(varProductID))
                                    {
                                        dtPurchaseDC.Rows[i].Delete();
                                        dtPurchaseDC.AcceptChanges();
                                    }
                                }
                                for (int i = 0; i < grdProductExchage.RowCount; i++)
                                {
                                    grdProductExchage.Rows[i].Cells["clmSno"].Value = i + 1;
                                }
                                udfnProductCount();
                                varDiscardFlag = false;
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
        private void GrdProductExchage_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Quantity = Convert.ToInt32(grdProductExchage.CurrentRow.Cells["clmQuantity"].Value);
                int Stock = Convert.ToInt32(grdProductExchage.CurrentRow.Cells["clmStockQuantity"].Value);
                if (Convert.ToString(Quantity) == "0" || Convert.ToString(Quantity) == "")
                {
                    varErrQty = "1";
                }
                else
                {
                    varErrQty = "0";
                }
                if (btnSave.Text == "Update")
                {
                    if (Quantity <= Stock)
                    {
                        // grdPurchaseDC.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.Red;
                        varErrQty = "1";
                        // grdPurchaseDC.Rows[e.RowIndex].Cells["clmError"].Value = varErrQty;
                    }
                    else
                    {
                        varErrQty = "0";
                    }
                }
                if (varErrQty == "1")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdProductExchage.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.LightPink;
                    grdProductExchage.Rows[e.RowIndex].Cells["clmError"].Value = varErrQty;
                }
                else
                {
                    varErrQty = "0";
                    grdProductExchage.CurrentRow.Cells["clmQuantity"].Style.BackColor = Color.PaleGreen;
                    grdProductExchage.Rows[e.RowIndex].Cells["clmError"].Value = varErrQty;
                }
                int varDecimal = Convert.ToInt32(grdProductExchage.CurrentRow.Cells["clmUTDecimal"].Value);

                string Qty = objValidation.udfnDecimal(Convert.ToString(grdProductExchage.CurrentRow.Cells["clmQuantity"].Value), varDecimal);
                grdProductExchage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;
                //Update the same column value in the DataTable
                object varEditQty = grdProductExchage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                dtPurchaseDC.Rows[e.RowIndex]["DCPR_Qty"] = varEditQty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMonth.Text.Length == 2)
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
        private void TxtYear_Enter(object sender, EventArgs e)
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
        private void TxtYear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBatchNo.Enabled == true)
                    {
                        txtBatchNo.Focus();
                    }
                    else
                    {
                        txtActualQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text.Length == 2)
                {
                    if (txtBatchNo.Enabled == false)
                    { txtActualQty.Focus(); }
                    else
                    {
                        txtBatchNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtActualQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtActualQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtStockLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductExchange.SetError(txtActualQty, "Please enter quantity.");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter quantity.", txtActualQty, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtActualQty.Text).Trim(), varDecimal);
                    txtActualQty.Text = Qty;
                    txtActualQty.BackColor = Color.White;
                    epProductExchange.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtActualQty_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                    {
                        e.Handled = true;
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
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
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
        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnExpiryDate()
        {
            try
            {
                string varDay = "", varMonth = "", varYear = "", varDate = ""; string varDcDay = "", varDcMonth = "", varDcYear = "", varExpiry = "";
                int varExpiryDays = 0; int error = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (txtDay.Text.Trim() == "")
                {
                    varDay = "01";
                }
                else
                {
                    if (Convert.ToInt64(txtDay.Text) > 31 || Convert.ToInt64(txtDay.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(95);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtDay.Text.Length == 1)
                        { txtDay.Text = 0 + txtDay.Text.Trim(); }
                        varDay = txtDay.Text.Trim();
                    }
                }
                if (txtMonth.Text.Trim() != "")
                {
                    if (Convert.ToInt64(txtMonth.Text) > 12 || Convert.ToInt64(txtMonth.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(90);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtMonth.Text.Length == 1)
                        { txtMonth.Text = 0 + txtMonth.Text.Trim(); }
                    }
                }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Length < 2)
                    {
                        pbDateflag = 1;
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(92);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (pbDateflag == 0)
                {
                    varMonth = Convert.ToString(txtMonth.Text.Trim());
                    varYear = 20 + Convert.ToString(txtYear.Text.Trim());
                    if (txtDay.Text.Trim() == "")
                    {
                        varDate = varDay + "/" + varMonth + "/" + varYear;
                        MR_Master objMR_Master1 = new MR_Master();
                        objMR_Master1.ViewType = 5;
                        objMR_Master1.paraDate = varDate;
                        objDS = objDServ.udfnMaster(objMR_Master1);
                        objDServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varExpiryDate = objDS.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();
                        }
                    }
                    else
                    {
                        varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                    }
                    MR_Master objMR_Master = new MR_Master();
                    objMR_Master.ViewType = 10;
                    objMR_Master.paraDate = MainForm.objPUR_PurchaseReturns.dpReturnDCDate.Text;
                    objMR_Master.ParaExpiryDate = varExpiryDate;
                    objMR_Master.paraProductId = Convert.ToInt32(lblProductcode.Text.Trim());
                    objDS = objDServ.udfnMaster(objMR_Master);
                    objDServ.CloseConnection();
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                        {
                            pbDateflag = 1; error = 1;
                        }
                        else
                        {
                            if (objDS.Tables.Count != 0)
                            {
                                if (objDS.Tables[1].Rows.Count > 0)
                                {
                                    varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                }
                            }
                            if (varExpiryDays < 0)
                            {
                                pbDateflag = 1; error = 1;
                            }
                            else
                            {
                                if (varShelflife == 1)
                                {
                                    if (objDS.Tables.Count > 1)
                                    {
                                        if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                        {
                                            pbDateflag = 1;
                                            txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            string varMessage = objDServ.udfnGetMessages(98);
                                            objDServ.CloseConnection();
                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        pbDateflag = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                if (error == 1)
                {
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    string varMessage = objDServ.udfnGetMessages(94);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUddtTable()
        {
            dtPurchaseDC.TableName = "TRN_ReturnDCProducts";
            dtPurchaseDC.Columns.Add("DCPR_PRID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_MRP", typeof(decimal));
            dtPurchaseDC.Columns.Add("DCPR_ExpiryDate", typeof(string));
            dtPurchaseDC.Columns.Add("DCPR_BatchNo", typeof(string));
            dtPurchaseDC.Columns.Add("DCPR_Qty", typeof(decimal));
            dtPurchaseDC.Columns.Add("DCPR_UTID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_SLID", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_RKID", typeof(int));
            dtPurchaseDC.Columns.Add("ProductName", typeof(string));
            dtPurchaseDC.Columns.Add("P.I code", typeof(string));
            dtPurchaseDC.Columns.Add("Unit", typeof(string));
            dtPurchaseDC.Columns.Add("Location", typeof(string));
            dtPurchaseDC.Columns.Add("Rack", typeof(string));
            dtPurchaseDC.Columns.Add("DCPR_MRPflag", typeof(int));
            dtPurchaseDC.Columns.Add("DCPR_Shelflifeflag", typeof(int));
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false; pbDateflag = 0;
                if (Convert.ToString(txtProductName.Text).Trim() == "")
                {
                    epProductExchange.SetError(txtProductName, "Please enter product.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    blnErrorFlag = true;
                }
              
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtMonth, "Please enter month.");
                        blnErrorFlag = true;
                    }
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtYear, "Please enter year.");
                        blnErrorFlag = true;
                    }
                }
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchNo.Text.Trim() == "")
                    {
                        txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtBatchNo, "Please enter BatchNo.");
                        tpBatchNo.ShowAlways = true;
                        tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (txtActualQty.Text.Trim() == "")
                {
                    txtActualQty.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductExchange.SetError(txtActualQty, "Please enter quantity.");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter quantity.", txtActualQty, 5000);
                    blnErrorFlag = true;
                }
                if (txtStockLocation.Text.Trim() == "")
                {
                    txtStockLocation.BackColor = ColorTranslator.FromHtml("#fabdbd");
                    epProductExchange.SetError(txtStockLocation, "Please enter location.");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location.", txtStockLocation, 5000);
                    blnErrorFlag = true;
                }
                /*Checking valid product or not */
                if (Convert.ToString(txtProductName.Text) != "")
                {
                    string varproductID = "0";
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 39;
                    objMR_Product.ParaCompanycode = varConcernId;
                    objMR_Product.paraProductName = txtProductName.Text;
                    objMR_Product.ParaSupplierId = varSupplierId;
                    DataSet objDsproductId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsproductId = objDserv.udfnproductmasterlist(objMR_Product);
                    objDserv.CloseConnection();
                    if (objDsproductId != null)
                    {
                        if (objDsproductId.Tables.Count > 0)
                        {
                            if (objDsproductId.Tables[0].Rows.Count > 0)
                            {
                                varproductID = Convert.ToString(objDsproductId.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varproductID == "-1")
                    {
                        lblProductcode.Text = "0";
                        //epPurchaseDC.SetError(txtProductName, "Invalid product");
                        //txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        //tpProduct.ShowAlways = true;
                        //tpProduct.Show("Invalid product", txtProductName, 5000);
                        SPDataService objDser = new SPDataService();
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDser.udfnGetMessages(91);
                        objDser.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        lblProductcode.Text = varproductID;
                        epProductExchange.Clear();
                        txtProductName.BackColor = Color.White;
                    }
                }
                /* Check location is valid or not*/
                if (txtStockLocation.Text != "")
                {
                    string varLocationId = "0";
                    DataSet objDsLocation = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsLocation = objDServ3.udfnStockLocationList(14, varConcernId, 0, 0, txtStockLocation.Text.Trim(), 0, 0, 0, "", "",0);
                    objDServ3.CloseConnection();
                    if (objDsLocation != null)
                    {
                        if (objDsLocation.Tables.Count > 0)
                        {
                            if (objDsLocation.Tables[0].Rows.Count > 0)
                            {
                                varLocationId = Convert.ToString(objDsLocation.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblStockLocationCode.Text = Convert.ToString(varLocationId);
                    if (varLocationId == "0" || varLocationId == "-1")
                    {
                        epProductExchange.SetError(txtStockLocation, "Please select valid location.");
                        txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please select location.", txtStockLocation, 5000);
                        blnErrorFlag = true;
                    }
                }
                /*check location have a rack or not*/
                string varId_PurchaseRack = "0";
                string varId_PurchaseRackCount = "0";
                DataSet objDsPurchaseRack = new DataSet();
                SPDataService objDServ6 = new SPDataService();
                objDsPurchaseRack = objDServ6.udfnRackList(17, 0, 0, Convert.ToInt32(lblStockLocationCode.Text), 0, txtRack.Text.Trim(), 0, 0);
                objDServ6.CloseConnection();
                if (txtRack.Text.Trim() != "")
                {
                    if (lblStockLocationCode.Text != "0")
                    {
                        if (objDsPurchaseRack != null)
                        {
                            if (objDsPurchaseRack.Tables.Count > 0)
                            {
                                if (objDsPurchaseRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_PurchaseRack = Convert.ToString(objDsPurchaseRack.Tables[0].Rows[0][0]);
                                }
                                if (objDsPurchaseRack.Tables[1].Rows.Count > 0)
                                {
                                    varId_PurchaseRackCount = Convert.ToString(objDsPurchaseRack.Tables[1].Rows[0][0]);
                                }
                                if (varId_PurchaseRackCount == "0")
                                { varId_PurchaseRack = "0"; }
                            }
                        }
                        lblRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (Convert.ToInt32(varId_PurchaseRackCount) > 0)
                        {
                            if (Convert.ToInt32(varId_PurchaseRack) < 0 || varId_PurchaseRack == "-1")
                            {
                                epProductExchange.SetError(txtRack, "Please enter valid rack.");
                                txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                tpRack.ShowAlways = true;
                                tpRack.Show("Please enter valid rack.", txtRack, 5000);
                                blnErrorFlag = true;
                            }
                        }
                    }
                }
                else
                {
                    if (lblStockLocationCode.Text != "0")
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
                        lblRackCode.Text = Convert.ToString(varId_PurchaseRack);
                        if (Convert.ToInt32(varId_PurchaseRack) > 0)
                        {
                            epProductExchange.SetError(txtRack, "Please enter rack.");
                            txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpRack.ShowAlways = true;
                            tpRack.Show("Please enter rack.", txtRack, 5000);
                            blnErrorFlag = true;
                        }
                        if (varId_PurchaseRack == "0")
                        {
                            txtRack.Text = "None";
                            txtRack.Enabled = false;
                            lblRackCode.Text = "0";
                        }
                        else
                        {
                            txtRack.Enabled = true;
                        }
                    }
                }
                if (Convert.ToString(txtProductName.Text.Trim()) != "")
                {
                    if (expirydateFlag == 1 || txtDay.Text != "" || txtMonth.Text != "" || txtYear.Text != "")
                    {
                        udfnExpiryDate();
                    }
                    else if(expirydateFlag == 0 || txtDay.Text == "" || txtMonth.Text == "" || txtYear.Text == "")
                    {
                        varExpiryDate = "";
                    }
                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    DataSet objDSExpiry = new DataSet();
                    int flag = 0;
                   
                    string varMRP = "0", varNewExpiryDate = "", varBatch = "", varSLID = "", varRKID = "", varmrptxt = "0.00";
                    if (txtMrp.Text == "") { varmrptxt = "0"; }
                    else
                    { varmrptxt = txtMrp.Text.Trim(); }
                    varmrptxt = string.Format("{0:0.00}", Math.Round(Convert.ToDecimal(varmrptxt), 2, MidpointRounding.AwayFromZero));
                    for (int i = 0; i < grdProductExchage.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(lblProductcode.Text) == Convert.ToInt32(grdProductExchage.Rows[i].Cells["ClmPRID"].Value))
                        {
                            varMRP = Convert.ToString(grdProductExchage.Rows[i].Cells["clmMRP"].Value).Trim();
                            varNewExpiryDate = Convert.ToString(grdProductExchage.Rows[i].Cells["clmExpiryDate"].Value).Trim();
                            varBatch = Convert.ToString(grdProductExchage.Rows[i].Cells["clmBatchNo"].Value).Trim();
                            varSLID = Convert.ToString(grdProductExchage.Rows[i].Cells["clmSLID"].Value).Trim();
                            varRKID = Convert.ToString(grdProductExchage.Rows[i].Cells["clmRKID"].Value).Trim();

                            if (varmrptxt == varMRP && varExpiryDate == varNewExpiryDate && txtBatchNo.Text.Trim() == varBatch)
                            {
                                if (lblStockLocationCode.Text.Trim() == varSLID && lblRackCode.Text.Trim() == varRKID)
                                {
                                    lblProductcode.Text = "0";
                                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    string varMessage = objDServ.udfnGetMessages(93);
                                    objDServ.CloseConnection();
                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    blnErrorFlag = true;
                                }
                            }
                        }
                    }
                }
                if (varMRPflag == 1 && Convert.ToString(txtMrp.Text) == "" || varMRPflag == 1 && Convert.ToDecimal(txtMrp.Text) == 0)
                {
                    epProductExchange.SetError(txtMrp, "Please enter MRP");
                    txtMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMRP.ShowAlways = true;
                    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false && pbDateflag == 0)
                {
                    udfnAdd();
                    varDiscardFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnAddClear()
        {
            try
            {
                lblUnit.Text = "";
                //txtProductName.Text = "";
                //lblProductcode.Text = "0";
                txtMrp.Text = "";
                txtDay.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchNo.Text = "";
                txtActualQty.Text = "";
                txtStockLocation.Text = "";
                lblStockLocationCode.Text = "0";
                txtRack.Text = "";
                lblRackCode.Text = "0";
                txtMrp.BackColor = Color.White;
                txtDay.BackColor = Color.White;
                txtMonth.BackColor = Color.White;
                txtYear.BackColor = Color.White;
                txtBatchNo.BackColor = Color.White;
                txtActualQty.BackColor = Color.White;
                txtRack.BackColor = Color.White;
                this.ActiveControl = txtProductName;
                epProductExchange.Clear();
                txtStockLocation.BackColor = Color.White;
                txtRack.Enabled = true;
                txtBatchNo.Enabled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTooltipHide()
        {
            try
            {
                tpProduct.Active = false;
                tpMRP.Active = false;
                tpDay.Active = false;
                tpMonth.Active = false;
                tpYear.Active = false;
                tpBatchNo.Active = false;
                tpQty.Active = false;
                tpStockLocation.Active = false;
                tpRack.Active = false;
                epProductExchange.Clear();
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
                if (varUpDownKey == 0)
                {
                    if (VarSearchFlag == true)
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        txtProductName.CharacterCasing = CharacterCasing.Normal;
                    }
                    if (txtProductName.Text != "" || txtProductName.Text == "")
                    {
                        udfnAddClear();
                        udfnTooltipHide();
                        //txtStockLocation.Text = "";
                        //lblStockLocationCode.Text = "0";
                        //lvStockLocation.Visible = false;
                    }
                    string varProductsCodes = "0";
                    txtRack.Text = "";
                    txtRack.Enabled = true;
                    lblRackCode.Text = "0";
                    //lvproduct.Items.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 29;
                        objMR_Product.ParaCompanycode = varConcernId;
                        objMR_Product.ParaScheduleid = Convert.ToString(varScheduleId);
                        objMR_Product.ParaSupplierId = varSupplierId;
                        objMR_Product.ParaProductsCode = varProductsCodes;
                        if (VarSearchFlag == true)
                        {
                            objMR_Product.paraPicode = txtProductName.Text;
                        }
                        else
                        {
                            objMR_Product.paraProductName = txtProductName.Text;
                        }
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        // lvproduct.BeginUpdate();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {   /*
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(),objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(),
                                        objDs.Tables[0].Rows[i]["PR_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PR_BatchNoGeneration"].ToString(),objDs.Tables[0].Rows[i]["PR_RMForProduction"].ToString(),objDs.Tables[0].Rows[i]["PR_PRCTID"].ToString(),objDs.Tables[0].Rows[i]["PR_ShelfLife"].ToString(),
                                      objDs.Tables[0].Rows[i]["UT_Decimal"].ToString()};
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvproduct.Items.Add(objList);
                                    }
                                    lvproduct.Visible = true;
                                    lvproduct.Columns[0].Width = 130;
                                    lvproduct.Columns[1].Width = 300;
                                    lvproduct.Columns[2].Width = 50;
                                    */
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Visible = true;
                                    DGV_FilterProduct.Columns["pr_retailrate"].Visible = true;
                                    DGV_FilterProduct.Columns["PR_BatchNo"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_BatchNoGeneration"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_RMForProduction"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PRCTID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_ShelfLife"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_MRPflag"].Visible = false;
                                    DGV_FilterProduct.Columns["pr_retailrate"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_HSNID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 355;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 355;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 60;
                                    //DGV_FilterProduct.Columns["pr_retailrate"].Width = 90;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 3;
                                    //DGV_FilterProduct.Columns["pr_retailrate"].DisplayIndex = 4;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["pr_retailrate"].HeaderText = "Retail Rate";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["pr_retailrate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                            else
                            {
                                DGV_FilterProduct.DataSource = null;
                                DGV_FilterProduct.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.DataSource = null;
                            DGV_FilterProduct.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                        //lvproduct.Visible = false;
                        //lvproduct.Items.Clear();
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
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    varBatchNo = "0"; varBatchNoGeneration = "0"; varShelflife = 0; expirydateFlag = 0; varMRPflag = 0;varEditflag = 0;varDateEnable = 0;
                    /*
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[3].Text;
                    lblProductcode.Text = selectedItem.SubItems[4].Text;
                    varBatchNo = selectedItem.SubItems[5].Text;
                    varBatchNoGeneration = selectedItem.SubItems[6].Text;
                    varRMProduction = selectedItem.SubItems[7].Text;
                    varPrcategory = selectedItem.SubItems[8].Text;
                    varShelflife = Convert.ToInt32(selectedItem.SubItems[9].Text);
                    */
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNo"].Value.ToString();
                    varBatchNoGeneration = DGV_FilterProduct.SelectedRows[0].Cells["PR_BatchNoGeneration"].Value.ToString();
                    varRMProduction = DGV_FilterProduct.SelectedRows[0].Cells["PR_RMForProduction"].Value.ToString();
                    varPrcategory = DGV_FilterProduct.SelectedRows[0].Cells["PR_PRCTID"].Value.ToString();
                    varShelflife = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_ShelfLife"].Value.ToString());
                    varMRPflag = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["PR_MRPflag"].Value);
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                    if (varShelflife == 1)
                    {
                        expirydateFlag = 1;
                        txtDay.Enabled = true;
                        txtDay.ReadOnly = false;
                        txtMonth.Enabled = true;
                        txtMonth.ReadOnly = false;
                        txtYear.Enabled = true;
                        txtYear.ReadOnly = false;
                    }
                    else
                    {
                        expirydateFlag = 0;
                        txtDay.Enabled = false;
                        txtDay.ReadOnly = true;
                        txtMonth.Enabled = false;
                        txtMonth.ReadOnly = true;
                        txtYear.Enabled = false;
                        txtYear.ReadOnly = true;
                        varDateEnable = 1;
                    }
                    udfnProductAdd();
                    udfnDefalutLocation();
                    if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                    {
                        txtBatchNo.Text = "";
                        txtBatchNo.Enabled = false;
                        //  txtBatchNo.ReadOnly = true;
                    }
                    else if (Convert.ToInt32(varBatchNo) == 72) //enabled
                    {
                        if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                        {
                            txtBatchNo.Enabled = true;
                            //txtBatchNo.ReadOnly = false;
                        }
                        else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                        {
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 14;
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(objMR_Master);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtBatchNo.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                    txtBatchNo.Enabled = false;
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(varPrcategory) == 16)
                    {
                        if (Convert.ToInt32(varRMProduction) == 1)
                        {
                            MR_Master objMR_Master = new MR_Master();
                            objMR_Master.ViewType = 15;
                            objMR_Master.paraDate = varTodayDate;
                            objMR_Master.paraProductId = Convert.ToInt32(lblProductcode.Text.Trim());
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(objMR_Master);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtDay.Text = objDs.Tables[0].Rows[0][0].ToString();
                                    txtMonth.Text = objDs.Tables[0].Rows[1][0].ToString();
                                    txtYear.Text = objDs.Tables[0].Rows[2][0].ToString();
                                }
                            }
                        }
                    }
                    
                    if (varMRPflag==1)
                    {
                        varEditflag = 1;
                        txtMrp.Enabled = true;
                        txtMrp.ReadOnly = false;
                    }
                    else
                    {
                        varEditflag = 0;
                        txtMrp.Enabled = false;
                        txtMrp.ReadOnly = true;
                    }
                }
                txtMrp.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterProduct.Visible=false;
                lvproduct.Visible = false;
            }
        }
        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    udfnListviewProduct();
            //    txtMrp.Focus();
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }
        public void udfnProductAdd()
        {
            try
            {
                if (Convert.ToInt32(lblProductcode.Text) != 0)
                {
                    varPICode = ""; varTName = ""; var_Symbol = ""; var_Text = ""; var_RMinSaleQty = ""; varSTOCK = ""; varPrevious = "";
                    varPARITAL = ""; varReOrderQty = ""; varorderSaleQty = ""; addproductid = ""; varunitid = ""; flag = "0";
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 34;
                    objMR_Product.ParaProductCode = Convert.ToInt32(lblProductcode.Text);
                    objMR_Product.ParaScheduleid =Convert.ToString(varScheduleId);
                    objMR_Product.ParaSupplierId = varSupplierId;
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varPICode = objDs.Tables[0].Rows[0]["PR_PICode"].ToString();
                            //varEName = objDs.Tables[0].Rows[0]["PR_EName"].ToString();
                            varTName = objDs.Tables[0].Rows[0]["PR_TName"].ToString();
                            var_Symbol = objDs.Tables[0].Rows[0]["UT_Symbol"].ToString();
                            var_Text = objDs.Tables[0].Rows[0]["GST_Text"].ToString();
                            var_RMinSaleQty = objDs.Tables[0].Rows[0]["PR_MinStock"].ToString();
                            varSTOCK = objDs.Tables[0].Rows[0]["STOCK"].ToString();
                            varPrevious = objDs.Tables[0].Rows[0]["PRE.PEND"].ToString();
                            varPARITAL = objDs.Tables[0].Rows[0]["PARITAL"].ToString();
                            varReOrderQty = objDs.Tables[0].Rows[0]["PR_ReOrderQty"].ToString();
                            varorderSaleQty = "0";
                            addproductid = objDs.Tables[0].Rows[0]["PRID"].ToString();
                            varunitid = objDs.Tables[0].Rows[0]["UTID"].ToString();
                            flag = objDs.Tables[0].Rows[0]["PRODUCTEXP"].ToString();
                            lblUnit.Text = objDs.Tables[0].Rows[0]["UT_Symbol"].ToString();

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
                lvproduct.Visible = false;
            }
        }

        private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnListviewProduct();
                //    txtMrp.Focus();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefalutLocation()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    if (lblProductcode.Text != "0" && lblProductcode.Text != "-1")
                    {
                        DataSet ObjsLocation = new DataSet();
                        SPDataService objDserv = new SPDataService();
                        ObjsLocation = objDserv.udfnStockLocationList(25, 0, 0, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0, 0, 0, "", "",0);
                        objDserv.CloseConnection();
                        if (ObjsLocation != null)
                        {
                            if (ObjsLocation.Tables.Count > 0)
                            {
                                if (ObjsLocation.Tables[0].Rows.Count > 0)
                                {
                                    lblStockLocationCode.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SLID"]);
                                    txtStockLocation.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["SL_EName"]);
                                    lblRackCode.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RKID"]);
                                    //if (lblRackCode.Text == "0")
                                    //{
                                    //    txtRack.Text = "None";
                                    //    txtRack.Enabled = false;
                                    //}
                                    //else
                                    //{
                                    //    txtRack.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RK_ShortName"]);
                                    //}
                                    if (Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RK_ShortName"]) != "")
                                    {
                                        txtRack.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RK_ShortName"]);
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(ObjsLocation.Tables[0].Rows[0]["RackCount"]) == 0)
                                        {
                                            txtRack.Text = Convert.ToString(ObjsLocation.Tables[0].Rows[0]["RKNAME"]);
                                            txtRack.Enabled = false;
                                            lblRackCode.Text = "0";
                                        }
                                    }
                                    lvStockLocation.Visible = false;
                                    lvRack.Visible = false;
                                }
                            }
                            else
                            {
                                lblStockLocationCode.Text = "0";
                                txtStockLocation.Text = "";
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
        public void udfnAdd()
        {
            try
            {
                if (txtActualQty.Text.Trim() == "0")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(77);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int varflag = 0; ProShelflife = 0; int Shelflifevalue = 0, ProShelfLifeType = 0, ProShelflifeValue = 0;
                    string varShelflifevalue = "", varAcutalshelflife = "";
                    if (varExpiryDate != "")
                    {
                        SPDataService objDServ = new SPDataService();
                        DataSet objDS = new DataSet();
                        MR_Master objMR_Master = new MR_Master();
                        objMR_Master.ViewType = 7;
                        objMR_Master.paraDate = varReturnDCDate;
                        objMR_Master.ParaExpiryDate = varExpiryDate;
                        objMR_Master.paraProductId = Convert.ToInt32(lblProductcode.Text.Trim());
                        objDS = objDServ.udfnMaster(objMR_Master);
                        objDServ.CloseConnection();
                        if (expirydateFlag == 1)
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(objDS.Tables[0].Rows[0]["DATEVALIDATE"]) == "0")
                                {
                                    epProductExchange.SetError(txtDay, "Invalid expiry date");
                                    txtDay.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpProduct.ShowAlways = true;
                                    tpProduct.Show("Invalid expiry date", txtDay, 5000);
                                    varflag = 1;
                                }
                                else
                                {
                                    if (objDS.Tables[1].Rows.Count > 0)
                                    {
                                        varShelflifevalue = Convert.ToString(objDS.Tables[1].Rows[0]["SHELFLIFE"]);
                                        string[] varProShelfLife = varShelflifevalue.Split(' ');
                                        if (Convert.ToString(varProShelfLife[0]) != "")
                                        {
                                            ProShelflife = Convert.ToDecimal(varProShelfLife[0]);
                                        }
                                    }
                                    if (objDS.Tables[2].Rows.Count > 0)
                                    {
                                        varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                                        string[] varShelflifevaluesplit = varAcutalshelflife.Split(' ');
                                        if (Convert.ToString(varShelflifevaluesplit[0]) != "")
                                        {
                                            Shelflifevalue = Convert.ToInt32(varShelflifevaluesplit[0]);
                                        }
                                    }
                                    if (objDS.Tables[3].Rows.Count > 0)
                                    {
                                        ProShelfLifeType = Convert.ToInt32(objDS.Tables[3].Rows[0]["PR_ShelfLifeType"]);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (objDS.Tables[2].Rows.Count > 0)
                            {
                                varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                            }
                        }
                    }
                    // udfnExpiryDate();
                    if (pbDateflag == 0)
                    {
                        if (txtMrp.Text == "")
                        { txtMrp.Text = "0"; }
                        decimal varMRP = Math.Round(Convert.ToDecimal(txtMrp.Text.Trim()), 2, MidpointRounding.AwayFromZero);
                        string mrp = string.Format("{0:0.00}", varMRP);
                        string mrp1 = string.Format("{0:G29}", decimal.Parse(mrp));
                        grdProductExchage.Rows.Add(grdProductExchage.Rows.Count + 1, varPICode.Trim(), varTName.Trim(), Convert.ToDecimal(mrp), varExpiryDate, (flag).Trim(), varAcutalshelflife, varShelflifevalue, txtBatchNo.Text.Trim(), txtActualQty.Text.Trim(), lblUnit.Text, txtStockLocation.Text.Trim(), txtRack.Text.Trim(), addproductid, lblStockLocationCode.Text, lblRackCode.Text, varunitid, varDecimal,0,0,varMRPflag,varShelflife);
                        dtPurchaseDC.Rows.Add(Convert.ToInt32(addproductid), Convert.ToDecimal(mrp1), varExpiryDate, txtBatchNo.Text.Trim(), Convert.ToDecimal(txtActualQty.Text.Trim()), Convert.ToInt32(varunitid), Convert.ToInt32(lblStockLocationCode.Text), Convert.ToInt32(lblRackCode.Text), varTName, varPICode, lblUnit.Text, txtStockLocation.Text.Trim(), txtRack.Text.Trim(),varMRPflag, varShelflife);
                        ((DataGridViewTextBoxColumn)grdProductExchage.Columns["clmQuantity"]).MaxInputLength = 8;
                        grdProductExchage.Columns["clmQuantity"].DefaultCellStyle.BackColor = Color.PaleGreen;
                        //grdPurchaseDC.Columns["clmQuantity"].ReadOnly = false;
                        grdProductExchage.Columns["clmMRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdProductExchage.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        grdProductExchage.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdProductExchage.Columns["clmProductName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                        udfnAddClear();
                        txtProductName.Text = "";
                        lblProductcode.Text = "0";
                        //  txtProductName.BackColor = Color.White;
                        udfnProductCount();
                        udfnShelflifeCheck();
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
                grdProductExchage.ClearSelection();
            }
        }
        public void udfnShelflifeCheck()
        {
            try
            {
                string[] varShelflifeper = Convert.ToString(ProShelflife).Split(' ');
                if (varShelflifeper[0] != "")
                {
                    if (Convert.ToDecimal(varShelflifeper[0]) > (MainForm.pbShelflifeLevel1) + 1 && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel2))
                    {
                        DataGridView dataGridView = grdProductExchage;
                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                        cell.Style.BackColor = Color.Orange;
                        cell.Style.ForeColor = Color.Black;
                    }
                    else if (Convert.ToDecimal(varShelflifeper[0]) > 0 && Convert.ToDecimal(varShelflifeper[0]) < (MainForm.pbShelflifeLevel1))
                    {
                        DataGridView dataGridView = grdProductExchage;
                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                        cell.Style.BackColor = Color.Red;
                        cell.Style.ForeColor = Color.White;
                    }
                    else
                    {
                        DataGridView dataGridView = grdProductExchage;
                        DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactuallife"];
                        cell.Style.BackColor = Color.White;
                        cell.Style.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAdd_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_Leave(object sender, EventArgs e)
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
        private void TxtBatchNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchNo.Text.Trim() == "")
                    {
                        txtBatchNo.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        epProductExchange.SetError(txtBatchNo, "Please enter BatchNo.");
                        tpBatchNo.ShowAlways = true;
                        tpBatchNo.Show("Please enter BatchNo.", txtBatchNo, 5000);
                    }
                    else
                    {
                        txtBatchNo.BackColor = Color.White;
                        epProductExchange.Clear();
                    }
                }
                else
                {
                    txtBatchNo.BackColor = Color.White;
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
