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
    public partial class INV_StockHold_Damages : Form
    {

        //Created By Sathish on: 03-07-2024
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpSupplier = new ToolTip();
        public int varProductCode = 0, varQty = 0, varSLID = 0, varSHID = 0;
        private SecurityController _security;
        public string pbFormStatus, varFlag = "0", varVerified = "0", pbDamageReason = "";

        public INV_StockHold_Damages()
        {
            InitializeComponent();
            _security = new SecurityController();
        }
        private void INV_StockHold_Location_Load(object sender, EventArgs e)
        {
            try
            {
                lblProductName.MaximumSize = new Size(280, 0);
                lblProductName.AutoSize = true;
                udfnDataLoad();
                udfnsupplierLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDataLoad()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                TRN_StockHold objTRNG_StockHold = new TRN_StockHold();
                objTRNG_StockHold.ViewType = 1;
                objTRNG_StockHold.paraSHID = varSHID;
                objTRNG_StockHold.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRNG_StockHold.paraIPAddress = MainForm.pbIpAddress;
                objDs = objdserv.udfnStockHoldList(objTRNG_StockHold);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        lblSource.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Stock Location"]);
                        lblConcern.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Concern"]);
                        lblProductName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product Name"]);
                        lblMRP.Text = Convert.ToString(objDs.Tables[0].Rows[0]["MRP"]);
                        lblExpiryDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Expiry Date"]);
                        lblBatchNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Batch No"]);
                        lblSupplierName.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Supplier"]);
                        lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SH_SPID"]);
                        lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SH_SPSCID"]);
                        lblCompanyCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["COMID"]);
                        lblHoldQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Hold Qty"]);
                        varProductCode = Convert.ToInt32(objDs.Tables[0].Rows[0]["PRID"]);
                        lblTeller.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SH_Maker"]);
                    }
                    if (objDs.Tables[1].Rows.Count != 0)
                    {
                        lblLocationCode.Text = Convert.ToString(objDs.Tables[1].Rows[0]["SLID"]);
                        lblDestination.Text = Convert.ToString(objDs.Tables[1].Rows[0]["SL_EName"]);
                        lblTransactionDate.Text = Convert.ToString(objDs.Tables[1].Rows[0]["CurrentDate"]);
                    }

                    lblSource.Visible = true;
                    lblDestination.Visible = true;
                    lblConcern.Visible = true;
                    lblProductName.Visible = true;
                    lblMRP.Visible = true;
                    lblExpiryDate.Visible = true;
                    lblBatchNo.Visible = true;
                   // lblSupplierName.Visible = true;
                    lblHoldQty.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnsupplierLoad()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            grbSupplierDetails.Visible = true;
                            label19.Text = objDs.Tables[0].Rows[0]["NAME"].ToString();
                            lblSupplierCity.Text = objDs.Tables[0].Rows[0]["CITY"].ToString();
                            lblsupplierGST.Text = objDs.Tables[0].Rows[0]["GSTIN"].ToString();
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString();
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString();
                            lblSupplierOrderpolicy.Text = "Return Policy - " + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                            lblReturn.Text = objDs.Tables[0].Rows[0]["RETURNAPPLICABLE"].ToString();
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(132);
                objDServ.CloseConnection();
                DialogResult dialogResult=MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    MainForm.objINV_StockHold_Verify = new INV_StockHold_Verify();
                    MainForm.objINV_StockHold_Verify.ShowDialog();
                    varVerified = MainForm.objINV_StockHold_Verify.varUserId;
                    varFlag = Convert.ToString(MainForm.objINV_StockHold_Verify.flag);
                    if (varFlag == "1")
                    {
                        SPDataService objspservice = new SPDataService();
                        string varResult = "", varTellerChecker = "";
                        DataTable dtDamage = new DataTable();
                        dtDamage.TableName = "TRN_DM_Product_AutoComplete";
                        dtDamage.Columns.Add("DM_PRID", typeof(int));
                        dtDamage.Columns.Add("DM_SLID", typeof(int));
                        dtDamage.Columns.Add("DM_RKID", typeof(int));
                        dtDamage.Columns.Add("DM_MRP", typeof(decimal));
                        dtDamage.Columns.Add("DM_DD", typeof(int));
                        dtDamage.Columns.Add("DM_MM", typeof(int));
                        dtDamage.Columns.Add("DM_YYYY", typeof(int));
                        dtDamage.Columns.Add("DM_ExpiryDate", typeof(string));
                        dtDamage.Columns.Add("DM_BatchNo", typeof(string));
                        dtDamage.Columns.Add("DM_Qty", typeof(decimal));
                        dtDamage.Columns.Add("DM_UTID", typeof(string));
                        dtDamage.Columns.Add("DM_STSID", typeof(string));
                        dtDamage.Columns.Add("DM_SPID", typeof(string));
                        dtDamage.Columns.Add("DM_SPSCID", typeof(string));
                        dtDamage.Columns.Add("DM_REASON", typeof(string));
                        int varDay = 0, varMonth = 0, varYear = 0;
                        if (lblExpiryDate.Text != "")
                        {
                            string[] varExpiryDate = lblExpiryDate.Text.Split('/');
                            varDay = Convert.ToInt32(varExpiryDate[0]);
                            varMonth = Convert.ToInt32(varExpiryDate[1]);
                            varYear = Convert.ToInt32(varExpiryDate[2]);
                        }
                        varTellerChecker = lblTeller.Text + '~' + 1 + ',' + varVerified + '~' + 2;

                        dtDamage.Rows.Add(varProductCode, Convert.ToInt32(lblLocationCode.Text), 0, string.Format("{0:G29}", decimal.Parse(Convert.ToString(lblMRP.Text.Trim()))), varDay, varMonth, varYear, lblExpiryDate.Text, lblBatchNo.Text.Trim(), lblHoldQty.Text.Trim(), 0, 20, lblSupplierCode.Text.Trim(), lblschedule.Text.Trim(), 0);

                        TRN_Damage objTRN_Damage = new TRN_Damage();
                        objTRN_Damage.ViewType = 0;
                        objTRN_Damage.paraDamageEntryID = 0;
                        objTRN_Damage.ParaCompanycode = Convert.ToInt32(lblCompanyCode.Text);
                        objTRN_Damage.paraTransferDate = lblTransactionDate.Text;
                        objTRN_Damage.paraLocationID = Convert.ToInt32(lblLocationCode.Text);
                        objTRN_Damage.paraRemarks = pbDamageReason;
                        objTRN_Damage.paraStatusId = 20;
                        objTRN_Damage.paraOriginator = "Stock Hold Damage";
                        objTRN_Damage.paraDamageEntry = dtDamage;
                        objTRN_Damage.paraEmployeeId = "0~1,0~2";
                        objTRN_Damage.paraSHID = varSHID;
                        varResult = objspservice.udfnDamageEntry(objTRN_Damage);
                        objspservice.CloseConnection();
                        string[] varvalue = varResult.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void udfnSave()
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
    }
}
