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
    public partial class PUR_PODamaged : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode,varMasterType="0";
        public string pbFormStatus;
        public PUR_PODamaged()
        {
            InitializeComponent();
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

        private void PUR_PODamaged_Load(object sender, EventArgs e)
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
        public void udfnList()
        {
            try
            {
                btnPrint.Focus();
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdPurchaseOrder.DataSource = null;

                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService(); 
                int varSupplierid = 0, varScheduleid = 0, varcompanyid = 0;
                if (varMasterType == "1")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue);
                }
                else if (varMasterType == "2")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_GRNEntry.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_GRNEntry.cmbConcern.SelectedValue);
                }
                else if (varMasterType == "3")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_GRNDetails.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_GRNDetails.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_GRNDetails.cmbConcern.SelectedValue);
                }
                objDs = objdserv.udfnproductDamage(0, varSupplierid, varScheduleid, varcompanyid);
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
                                grdPurchaseOrder.Rows.Add(objDs.Tables[0].Rows[i]["SINO"], objDs.Tables[0].Rows[i]["PICODE"], objDs.Tables[0].Rows[i]["PRODUCTNAME"], objDs.Tables[0].Rows[i]["QTY"], objDs.Tables[0].Rows[i]["UNIT"], objDs.Tables[0].Rows[i]["MRP"], objDs.Tables[0].Rows[i]["LASTPURCHASE"], objDs.Tables[0].Rows[i]["EXPIRY"], objDs.Tables[0].Rows[i]["BATCH"]);
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

        private void PUR_PODamaged_KeyDown(object sender, KeyEventArgs e)
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

        private void BrnPrint_Click(object sender, EventArgs e)
    { 
            try
            {

                int varSupplierid = 0, varScheduleid = 0, varcompanyid = 0;
                if (varMasterType == "1")
                {
                    varSupplierid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblSupplierCode.Text);
                    varScheduleid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.lblschedule.Text);
                    varcompanyid = Convert.ToInt32(MainForm.objPUR_PurchaseOrder.cmbConcern.SelectedValue);
                } 
                string varHeader = "";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_Damage_Product.rpt");
                varHeader = "Damage Product";
                objBillreport.SetParameterValue("paraDamageEntryID",0); 
                objBillreport.SetParameterValue("ParaDMFromDate", "");
                objBillreport.SetParameterValue("ParaDMToDate", "");
                objBillreport.SetParameterValue("ParaSupplierId", varSupplierid);
                objBillreport.SetParameterValue("paraCompanyID", varcompanyid);
                objBillreport.SetParameterValue("ParaScheduleId", varScheduleid); 
                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                objBillreport.SetParameterValue("paraStatus", 0);
                objValidation.CrySqlConnection(objBillreport);

                MainForm.objReportLoad = new ReportLoad();
                MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                MainForm.objReportLoad.Text = varHeader;
                MainForm.objReportLoad.ShowDialog();

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void BrnPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                btnPrint.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void BrnPrint_Leave(object sender, EventArgs e)
        {

            try
            {
                btnPrint.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BrnPrint_KeyDown(object sender, KeyEventArgs e)
        { 
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    btnClose.Focus();
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
    }
}
