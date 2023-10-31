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
    public partial class PUR_POScheduledaywise : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode;
        public string pbFormStatus;
        public PUR_POScheduledaywise()
        {
            InitializeComponent();
            MainForm.objPUR_SupplierScheduleList.picLoader.Visible = false;
        }

        private void PUR_POScheduledaywise_Load(object sender, EventArgs e)
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
                objDs = objdserv.udfnSupplierList(9, 0, 0, 0, 0, "", 0,0,Convert.ToInt32(MainForm.objPUR_SupplierScheduleList.cmbConcern.SelectedValue),"",0,0,0,0,0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    { 
                        if (objDs.Tables[0].Rows.Count != 0)
                        { 
                            grdHeaderview.DataSource = objDs.Tables[0];
                            foreach (DataGridViewColumn column in grdHeaderview.Columns)
                            {
                                if (column.Index > 1)  
                                {
                                    column.Width = 200;
                                }
                            }

                        }

                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            grdPOSchedule.DataSource = objDs.Tables[1];
                            grdPOSchedule.Columns["DYID"].Visible = false;
                            grdPOSchedule.Columns["S.No."].Width = 50;
                            grdPOSchedule.Columns["Order Day"].Width = 100;
                            foreach (DataGridViewColumn column in grdPOSchedule.Columns)
                            {
                                if (column.Index > 1)
                                {
                                    column.Width = 100;
                                }
                                string[] parts = column.HeaderText.Split('-');
                                 
                                if (parts.Length > 1)
                                { 
                                    column.HeaderText = parts[parts.Length - 1];
                                }
                            } 
                            if (grdPOSchedule.Rows.Count > 0) // Check if there are any rows
                            {
                                grdPOSchedule.Rows[grdPOSchedule.Rows.Count - 1].Cells[1].Value = null;
                            }
                        }
                        if (objDs.Tables[2].Rows.Count != 0)
                        {
                            
                            if (grdPOSchedule.Rows.Count > 0 && grdPOSchedule.Columns.Count >= 2)
                            { 
                                DataGridViewRow lastRow = grdPOSchedule.Rows[grdPOSchedule.Rows.Count - 1]; 
                                DataGridViewCell beforeLastCell = lastRow.Cells[lastRow.Cells.Count - 2];
                                beforeLastCell.Value = Convert.ToString(objDs.Tables[2].Rows[0]["SuppCount"].ToString().Replace("''", "'")); ; 
                                DataGridViewCell lastCell = lastRow.Cells[lastRow.Cells.Count - 1];
                                lastCell.Value = Convert.ToString(objDs.Tables[2].Rows[0]["ProCount"].ToString().Replace("''", "'")); ;
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

        private void BtnPrintdaywise_Enter(object sender, EventArgs e)
        {
            try
            {
                btnPrintdaywise.BackColor = Color.LemonChiffon;
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
                btnPrintdaywise.BackColor = Color.Transparent;
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

        private void PUR_POScheduledaywise_KeyDown(object sender, KeyEventArgs e)
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
