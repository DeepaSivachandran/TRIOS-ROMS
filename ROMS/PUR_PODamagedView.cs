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
    public partial class PUR_PODamagedView : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode,varMasterType="0";
        public string pbFormStatus;
        public PUR_PODamagedView()
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
        private void udfnList()
        { 
            try
            {
                Application.DoEvents();
                //********** To display a data in a grid  ****************** 

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                int varSupplierid = 0, varScheduleid = 0, varcompanyid = 0, varId = 0;
                if (varMasterType == "1")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue);
                }
                else if (varMasterType == "3")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_PurchaseEntryApproval.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_PurchaseEntryApproval.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_PurchaseEntryApproval.cmbConcern.SelectedValue);
                }
                else if (varMasterType == "5")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objCP_Purchase.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objCP_Purchase.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objCP_Purchase.cmbConcern.SelectedValue);
                }
                else if (varMasterType == "6")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objCP_Purchase.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objCP_Purchase.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objCP_Purchase.cmbConcern.SelectedValue);
                    varId = Convert.ToInt32(MainForm.objCP_Purchase.pbGRNNo);
                    this.Text = "Linked Return Delivery Challans";
                }
                else
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_GRNEntry.cmbConcern.SelectedValue);
                }

               // objDs = objdserv.udfnReturnDC(0, varSupplierid, varScheduleid, varcompanyid, 0,0,0,0,0);
                TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                objTRN_PurchaseReturnDC.paraViewType = 0;
                objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                objTRN_PurchaseReturnDC.paraCompanyId = varcompanyid;
                objTRN_PurchaseReturnDC.ParaSupplierId = varSupplierid;
                objTRN_PurchaseReturnDC.ParaScheduleID = varScheduleid;
                objTRN_PurchaseReturnDC.paraPurchaseId = varId;
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
                                grdGRNPODamaged.Rows.Add(objDs.Tables[0].Rows[i]["SINO"], objDs.Tables[0].Rows[i]["DCDATE"], objDs.Tables[0].Rows[i]["DCNO"], objDs.Tables[0].Rows[i]["REASON"], objDs.Tables[0].Rows[i]["prcount"], objDs.Tables[0].Rows[i]["DCVALUE"], objDs.Tables[0].Rows[i]["ID"]);
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
        }

        private void PUR_PODamagedView_Load(object sender, EventArgs e)
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
         

        private void GrdGRNPODamaged_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void GrdGRNPODamaged_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdGRNPODamaged.Columns[e.ColumnIndex].Name)
                    {
                        case "clmInvoiceNo":
                        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                        {
                            MainForm.objPUR_PurchaseOrderDamage = new PUR_PurchaseOrderDamage();
                            //if (varMasterType == "1")
                            //{
                            //    MainForm.objPUR_PurchaseOrderDamage.varMasterType = "1";
                            //}
                            //else
                            //{
                            //    MainForm.objPUR_PurchaseOrderDamage.varMasterType = "2";
                            //}

                            MainForm.objPUR_PurchaseOrderDamage.varMasterType = varMasterType;
                            MainForm.objPUR_PurchaseOrderDamage.varDcCode = Convert.ToString(grdGRNPODamaged.SelectedRows[0].Cells["ID"].Value);
                            MainForm.objPUR_PurchaseOrderDamage.ShowDialog();
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

        private void PUR_PODamagedView_KeyDown(object sender, KeyEventArgs e)
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
