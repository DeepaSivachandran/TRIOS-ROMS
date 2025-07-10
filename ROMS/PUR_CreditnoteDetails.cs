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
    public partial class PUR_CreditnoteDetails : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus, varMasterType="0";
        public string varCreditID = "0";
        public PUR_CreditnoteDetails()
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
                varSupplierid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.lblSupplierCode.Text);
                varScheduleid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.lblschedule.Text);
                varcompanyid = Convert.ToInt32(MainForm.objPAY_SupplierPayment.cmbConcern.SelectedValue);

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
               // objDs = objdserv.udfnReturnDC(1, varSupplierid, varScheduleid, varcompanyid, varDcCode,0,0,0,0);
                TRN_CreditNote objTRN_CreditNote = new TRN_CreditNote();
                objTRN_CreditNote.ViewType = 2;
                objTRN_CreditNote.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_CreditNote.paraCompanyCode = varcompanyid;
                objTRN_CreditNote.paraSupplierID = varSupplierid;
                objTRN_CreditNote.paraScheduleID = varScheduleid;
                objTRN_CreditNote.paraCreditID =Convert.ToInt32(varCreditID);
                objTRN_CreditNote.paraIPAddress = MainForm.pbIpAddress;
                objDs = objdserv.udfnCreditNoteList(objTRN_CreditNote);
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
                                grdCreditnote.Rows.Add(objDs.Tables[0].Rows[i]["S.No"], objDs.Tables[0].Rows[i]["PICode"], objDs.Tables[0].Rows[i]["Product"], objDs.Tables[0].Rows[i]["MRP"], objDs.Tables[0].Rows[i]["ExpiryDate"], objDs.Tables[0].Rows[i]["Batch"], objDs.Tables[0].Rows[i]["Approximate Rate"], Convert.ToDecimal(objDs.Tables[0].Rows[i]["Qty"]), objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["Taxable Amt"], objDs.Tables[0].Rows[i]["Gst%"], objDs.Tables[0].Rows[i]["GST Amt"], objDs.Tables[0].Rows[i]["Nett Amt"], objDs.Tables[0].Rows[i]["ID"]);
                                grdCreditnote.Columns["clmApproxRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdCreditnote.Columns["clmtotqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdCreditnote.Columns["clmTaxableAmt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdCreditnote.Columns["clmgstamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdCreditnote.Columns["clmnettamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdCreditnote.Columns["clmunit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdCreditnote.Columns["clmExpiry"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            txtDLNo.Text= objDs.Tables[1].Rows[0]["CreditNo"].ToString();
                            txtCreatedBy.Text= objDs.Tables[1].Rows[0]["CreatedBy"].ToString();
                            txtCreatedOn.Text= objDs.Tables[1].Rows[0]["CreatedOn"].ToString();
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
