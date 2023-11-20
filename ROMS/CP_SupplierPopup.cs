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
    public partial class CP_SupplierPopup : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public CP_SupplierPopup()
        {
            InitializeComponent();
        }

        private void CP_SupplierPopup_Load(object sender, EventArgs e)
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
                grdHeaderview.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService(); 
                objDs = objdserv.udfnSupplierList(25, 0, 0, 0, 0, "", 0,0,0,"",0,0,0,0,0,0,"");
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        int varRowCount = 0;
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            varRowCount = objDs.Tables[1].Rows.Count;
                        }
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            DataTable objDT = objDs.Tables[0];
                            if (varRowCount > objDT.Rows.Count) {
                                for (int i = objDT.Rows.Count; i < varRowCount; i++)
                                {
                                    objDT.Rows.Add("", "");
                                }
                            }
                            grdPOSchedule.DataSource = objDT;
                            grdPOSchedule.ReadOnly = true;
                            grdPOSchedule.Enabled = false;
                            grdPOSchedule.ClearSelection();
                            grdPOSchedule.Columns[0].Width = 150;
                            grdPOSchedule.Columns[1].Width = 50;
                            grdPOSchedule.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            grdPOSchedule1.DataSource = objDs.Tables[1];
                            grdPOSchedule1.ReadOnly = true;
                            grdPOSchedule1.Enabled = false;
                            grdPOSchedule1.ClearSelection();
                            grdPOSchedule1.Columns[0].Width = 150;
                            grdPOSchedule1.Columns[1].Width = 50;
                            grdPOSchedule1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        if (objDs.Tables[2].Rows.Count != 0)
                        {
                            DataTable objDT = objDs.Tables[2];
                            if (varRowCount > objDT.Rows.Count)
                            {
                                for (int i = objDT.Rows.Count; i < varRowCount; i++)
                                {
                                    objDT.Rows.Add("", "");
                                }
                            }
                            grdPOSchedule2.DataSource = objDT;
                            grdPOSchedule2.ReadOnly = true;
                            grdPOSchedule2.Enabled = false;
                            grdPOSchedule2.ClearSelection();
                            grdPOSchedule2.Columns[0].Width = 150;
                            grdPOSchedule2.Columns[1].Width = 50;
                            grdPOSchedule2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        grdTotal.Rows.Add("Total",Convert.ToString(objDs.Tables[3].Rows[0][1]),"Total", Convert.ToString(objDs.Tables[4].Rows[0][1]), "Total", Convert.ToString(objDs.Tables[5].Rows[0][1]));
                        grdTotal.ReadOnly = true;
                        grdTotal.Enabled = false;
                        grdTotal.ClearSelection();
                    }
                } 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void BtnPrintdaywise_Enter(object sender, EventArgs e)
        {
            try
            {
                //btnPrintdaywise.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnPrintdaywise_Leave(object sender, EventArgs e)
        {
            try
            {
                //btnPrintdaywise.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void BtnPrintdaywise_Click(object sender, EventArgs e)
        {
            try
            {
                try
                { 
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument(); 
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_PUR_SupplierScheduleProductDayWise.rpt"); 
                    varHeader = "Day Wise Supplier List";
                    objBillreport.SetParameterValue("@paracompanycode", Convert.ToInt32(MainForm.objPUR_SupplierScheduleList.cmbConcern.SelectedValue)); 
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
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
                finally
                { 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CP_SupplierPopup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
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
    }
}
