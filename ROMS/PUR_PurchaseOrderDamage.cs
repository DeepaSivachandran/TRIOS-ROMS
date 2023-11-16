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
        public int varDcCode = 0;
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
                else
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_GRNEntry.cmbConcern.SelectedValue);
                }
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnReturnDC(1, varSupplierid, varScheduleid, varcompanyid, varDcCode,0,0,0,0);
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
                                grdPurchaseOrder.Rows.Add(objDs.Tables[0].Rows[i]["SINO"], objDs.Tables[0].Rows[i]["PICODE"], objDs.Tables[0].Rows[i]["PRODUCT"], objDs.Tables[0].Rows[i]["QTY"], objDs.Tables[0].Rows[i]["UNIT"], objDs.Tables[0].Rows[i]["MRP"], objDs.Tables[0].Rows[i]["PURCHASERATE"], objDs.Tables[0].Rows[i]["EXPIRY"], objDs.Tables[0].Rows[i]["BATCH"], objDs.Tables[0].Rows[i]["ID"]);
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
