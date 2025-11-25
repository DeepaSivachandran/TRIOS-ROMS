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
    public partial class CP_CustomerType : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpCancel = new ToolTip();
        public string varSupplierIds, varGIId="0";
        public int varPrid=0,varFlag=0;
        public CP_CustomerType()
        {
            InitializeComponent();
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCount.Text.Trim() == "")
                {
                    errBrand.SetError(txtCount, "Please enter no. of copies.");
                    txtCount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpCancel.ShowAlways = true;
                    tpCancel.Show("Please enter no. of copies.", txtCount, 5000);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(txtCount.Text.Trim()) < 1)
                    {
                        errBrand.SetError(txtCount, "Please enter valid no. of copies.");
                        txtCount.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpCancel.ShowAlways = true;
                        tpCancel.Show("Please enter valid no. of copies.", txtCount, 5000);
                        return;
                    }
                }
                if (varFlag == 1) ///inward sticker print count
                {
                    udfnStickerPrint();
                }
                if (varFlag == 2) ///inward sticker print count
                {
                    udfnStickerFormPurchasePrint();
                }
                else { 
                    udfnPrint();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPrint()
        {
            try
            {
                errBrand.Clear();
                SPDataService objSPdataservice = new SPDataService();
                DataSet objDs = new DataSet();
                CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                MR_Supplier objMR_Supplier = new MR_Supplier();
                objMR_Supplier.ViewType = 42;
                objMR_Supplier.paraSupplierIds = varSupplierIds;
                objMR_Supplier.paraStickerCount = Convert.ToInt32(txtCount.Text.Trim());
                objDs = objSPdataservice.udfnSupplierList(objMR_Supplier);
                objSPdataservice.CloseConnection();
                if (objDs != null)
                {
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Supplier_Envelope.rpt");
                    objBillreport.SetParameterValue("paraSupplierIds", varSupplierIds);
                    objBillreport.SetParameterValue("paraStickerCount", Convert.ToInt32(txtCount.Text.Trim()));
                    objValidation.CrySqlConnection(objBillreport);
                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                    MainForm.objReportLoad.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                this.Close();
            }
        }


        public void udfnStickerPrint()
        {
            try
            {
                if (varGIId != "0")
                {
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Inward_Sticker_Print_100x70.rpt");

                    objBillreport.SetParameterValue("paraGIID", Convert.ToInt32(varGIId));
                    objBillreport.SetParameterValue("paraPRID", Convert.ToInt32(varPrid));
                    objBillreport.SetParameterValue("paraStickerCount", Convert.ToInt32(txtCount.Text.Trim()));
                    objBillreport.SetParameterValue("paraFlag", 2); ////item wise sticker print  for inward
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);

                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                    MainForm.objReportLoad.Text = varHeader;
                    MainForm.objReportLoad.ShowDialog();
                }
                else {
                    return;

                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                this.Close();
            }
        }

        public void udfnStickerFormPurchasePrint()
        {
            try
            {
                if (varGIId != "0")
                {
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Inward_FPurchase_Sticker_Print_100x70.rpt");

                    objBillreport.SetParameterValue("paraGIID", Convert.ToInt32(varGIId));
                    objBillreport.SetParameterValue("paraPRID", Convert.ToInt32(varPrid));
                    objBillreport.SetParameterValue("paraStickerCount", Convert.ToInt32(txtCount.Text.Trim()));
                    objBillreport.SetParameterValue("paraFlag", 2); ////item wise sticker print  for inward
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);

                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                    MainForm.objReportLoad.Text = varHeader;
                    MainForm.objReportLoad.ShowDialog();
                }
                else
                {
                    return;

                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                this.Close();
            }
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
        private void CP_Brand_Leave(object sender, EventArgs e)
        {
            try
            {
                tpCancel.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Brand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CancelReason_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Supplier Envelope Label";
                if (varFlag == 1) ///inward sticker print count
                {
                    this.Text = "Inward Label print";
                }

                txtCount.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtReason_Enter(object sender, EventArgs e)
        {
            try
            {
                txtCount.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtReason_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtReason_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCount.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
    }
}
