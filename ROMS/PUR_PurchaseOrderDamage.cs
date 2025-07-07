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
    public partial class PUR_PurchaseOrderDamage : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus, varMasterType="0";
        public string varDcCode = "0";
        public PUR_PurchaseOrderDamage()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
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
                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_PurchaseOrderDamage_Load(object sender, EventArgs e)
        {
            try
            {
                udfnList();
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
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 
                int varSupplierid = 0, varScheduleid = 0, varcompanyid = 0;
                //Varmaster type means which form is access this form
                if (varMasterType == "1")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue);
                }
                else if (varMasterType == "3")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_GRNDetails.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_GRNDetails.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_GRNDetails.cmbConcern.SelectedValue);
                }
                else if (varMasterType == "2")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_GRNEntry.cmbConcern.SelectedValue);
                }
                else if (varMasterType == "4")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.cmbConcern.SelectedValue);
                }
                else if (varMasterType == "5")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objCP_Purchase.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objCP_Purchase.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objCP_Purchase.cmbConcern.SelectedValue);
                }
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
               // objDs = objdserv.udfnReturnDC(1, varSupplierid, varScheduleid, varcompanyid, varDcCode,0,0,0,0);
                TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                objTRN_PurchaseReturnDC.paraViewType = 1;
                objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_PurchaseReturnDC.paraCompanyId = varcompanyid;
                objTRN_PurchaseReturnDC.ParaSupplierId = varSupplierid;
                objTRN_PurchaseReturnDC.ParaScheduleID = varScheduleid;
                objTRN_PurchaseReturnDC.paraDcID =Convert.ToInt32(varDcCode);
                objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                objDs = objdserv.udfnReturnDC(objTRN_PurchaseReturnDC);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();

                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdPurchaseOrder.Rows.Add(objDs.Tables[0].Rows[i]["SINO"], objDs.Tables[0].Rows[i]["PICODE"], objDs.Tables[0].Rows[i]["PRODUCT"], objDs.Tables[0].Rows[i]["MRP"], objDs.Tables[0].Rows[i]["EXPIRY"], objDs.Tables[0].Rows[i]["BATCH"], objDs.Tables[0].Rows[i]["Approximate Rate"], Convert.ToDecimal(objDs.Tables[0].Rows[i]["Qty"]), objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["Taxable Amt"], objDs.Tables[0].Rows[i]["Gst%"], objDs.Tables[0].Rows[i]["GST Amt"], objDs.Tables[0].Rows[i]["Nett Amt"], objDs.Tables[0].Rows[i]["ID"]);
                                grdPurchaseOrder.Columns["clmApproxRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPurchaseOrder.Columns["clmtotqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPurchaseOrder.Columns["clmTaxableAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPurchaseOrder.Columns["clmgstamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPurchaseOrder.Columns["clmnettamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdPurchaseOrder.Columns["clmunit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdPurchaseOrder.Columns["clmExpiry"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            txtDLNo.Text= objDs.Tables[1].Rows[0]["DCNO"].ToString();
                            txtReason.Text= objDs.Tables[1].Rows[0]["REASON"].ToString();
                            txtCreatedBy.Text= objDs.Tables[1].Rows[0]["CREATEDBY"].ToString();
                            txtCreatedOn.Text= objDs.Tables[1].Rows[0]["CREATEDON"].ToString();
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
        }

        private void PUR_PurchaseOrderDamage_KeyDown(object sender, KeyEventArgs e)
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
    }
}
