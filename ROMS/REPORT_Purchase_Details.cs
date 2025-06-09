using DocumentFormat.OpenXml.VariantTypes;
using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Runtime.InteropServices;
using ClosedXML.Excel;

namespace ROMS
{
    public partial class REPORT_Purchase_Details : Form
    {
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public REPORT_Purchase_Details()
        {
            InitializeComponent();
        }


public class PurchaseEntry
    {
        [JsonProperty("PURID")]
        public int PURID { get; set; }

        [JsonProperty("Header")]
        public string Header { get; set; }

        [JsonProperty("Products")]
        public List<Product> Products { get; set; }

        [JsonProperty("ProductSummary")]
        public string ProductSummary { get; set; }

        [JsonProperty("Charges")]
        public string Charges { get; set; }
    }

    public class Product
    {
        [JsonProperty("PR_PICode")]
        public string PR_PICode { get; set; }

        [JsonProperty("PR_TName")]
        public string PR_TName { get; set; }

        [JsonProperty("UT_Symbol")]
        public string UT_Symbol { get; set; }

        [JsonProperty("Condition")]
        public string Condition { get; set; }

        [JsonProperty("HSN_Code")]
        public string HSN_Code { get; set; }

        [JsonProperty("GST_Text")]
        public string GST_Text { get; set; }

        [JsonProperty("PURPR_InvoiceMRP")]
        public decimal PURPR_InvoiceMRP { get; set; }

        [JsonProperty("PURPR_ProductMRP")]
        public decimal PURPR_ProductMRP { get; set; }

        [JsonProperty("PURPR_ExpiryDate")]
        public string PURPR_ExpiryDate { get; set; }

        // If JSON properties have spaces, use JsonProperty attribute with exact name:
        [JsonProperty("Product Shelflife")]
        public string ProductShelflife { get; set; }

        [JsonProperty("Actual Shelflife")]
        public string ActualShelflife { get; set; }

        [JsonProperty("Shelflife Per")]
        public string ShelflifePer { get; set; }

        [JsonProperty("PURPR_Batch")]
        public string PURPR_Batch { get; set; }

        [JsonProperty("SL_ShortName")]
        public string SL_ShortName { get; set; }

        [JsonProperty("Rack")]
        public string Rack { get; set; }

        [JsonProperty("PURPR_InvoiceQty")]
        public decimal PURPR_InvoiceQty { get; set; }

        [JsonProperty("PURPR_ReceivedQty")]
        public decimal PURPR_ReceivedQty { get; set; }

        [JsonProperty("PURPR_DiffQty")]
        public decimal PURPR_DiffQty { get; set; }

        [JsonProperty("PURPR_FreeQty")]
        public decimal PURPR_FreeQty { get; set; }

        [JsonProperty("PURPR_PurchaseRate")]
        public decimal PURPR_PurchaseRate { get; set; }

        [JsonProperty("PURPR_DiscAmnt")]
        public decimal PURPR_DiscAmnt { get; set; }

        [JsonProperty("PURPR_TaxableValue")]
        public decimal PURPR_TaxableValue { get; set; }

        [JsonProperty("PURPR_GSTAmnt")]
        public decimal PURPR_GSTAmnt { get; set; }

        [JsonProperty("PURPR_NettAmnt")]
        public decimal PURPR_NettAmnt { get; set; }
    }



    private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbConditionType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbPayType_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbPayType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPayType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void cmbPayType_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbPayType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnListPrint_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnListPrint_Leave(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnListPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string varSupplierId = "0";
                if (txtSupplier.Text == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                else
                {
                    string[] values = new string[0];
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 31;
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedleCode.Text);
                    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(objMR_Supplier);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varSupplierId = Convert.ToString(objDsSupplierId.Tables[0].Rows[0][0]);
                                values = Convert.ToString(varSupplierId).Split(',');
                            }
                        }
                    }
                    if (values[0] == "-1")
                    {
                        lblSupplierCode.Text = "0";
                        lblschedleCode.Text = "0";
                    }
                    else
                    {
                        lblSupplierCode.Text = values[0];
                        lblschedleCode.Text = values[1];
                        txtSupplier.BackColor = Color.White;
                    }
                }
                LV_Supplier.Visible = false;
                udfnPurchaseDetails();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void ExportPurchaseJsonToExcelInterop(string jsonString)
        {
            try
            {
                var purchases = JArray.Parse(jsonString);

                Excel._Application ExcelObj = new Excel.Application();
                Excel._Workbook ExcelBook = ExcelObj.Workbooks.Add(Type.Missing);
                Excel._Worksheet ExcelSheet = ExcelBook.Sheets[1];
                ExcelSheet = ExcelBook.ActiveSheet;
                ExcelSheet.Name = "Purchase Report";
                ExcelObj.Visible = true;

                int maxColCount = 25;
                int currentRow = 1;

                // Title
                ExcelSheet.Cells[currentRow, 1].Value = "Purchase Details Report";
                Excel.Range titleRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, maxColCount]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titleRange.Interior.Color = Color.LightGray;
                currentRow++;

                // Filters
                string varSupplierName = string.IsNullOrWhiteSpace(txtSupplier.Text) ? "-All-" : txtSupplier.Text.Trim();
                string filterLine = $"Date : {dpFromDate.Text} - {dpToDate.Text}     Supplier Name : {varSupplierName}     Pay Type : {cmbPayType.Text}     Condition Type : {cmbConditionType.Text}";
                ExcelSheet.Cells[currentRow, 1].Value = filterLine;
                Excel.Range filterRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, maxColCount]];
                filterRange.Merge();
                filterRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                currentRow += 2;

                foreach (var purchase in purchases)
                {
                    var header = JObject.Parse(purchase["Header"].ToString());
                    var products = purchase["Products"] as JArray;
                    var footer = JObject.Parse(purchase["Footer"].ToString());

                    // --- Grouped Header Sections ---
                    ExcelSheet.Cells[currentRow, 1].Value = "Supplier Details";
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, 7]].Merge();
                    ExcelSheet.Cells[currentRow, 8].Value = "Invoice Details";
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 8], ExcelSheet.Cells[currentRow, 13]].Merge();
                    ExcelSheet.Cells[currentRow, 14].Value = "PO Details";
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 14], ExcelSheet.Cells[currentRow, 17]].Merge();
                    ExcelSheet.Cells[currentRow, 18].Value = "GRN Details";
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 18], ExcelSheet.Cells[currentRow, 20]].Merge();
                    ExcelSheet.Cells[currentRow, 21].Value = "Pur Entry Details";
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 21], ExcelSheet.Cells[currentRow, 22]].Merge();
                    ExcelSheet.Cells[currentRow, 23].Value = "Mismatch";
                    ExcelSheet.Cells[currentRow, 24].Value = "Pur App Details";
                    ExcelSheet.Cells[currentRow, 25].Value = "Cost App Details";
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, maxColCount]].Interior.Color = Color.LightGray;
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, maxColCount]].Font.Bold = true;
                    currentRow++;

                    // --- Actual Header Values ---
                    int col = 1;
                    foreach (var prop in header.Properties())
                    {
                        ExcelSheet.Cells[currentRow, col++].Value = prop.Value.ToString();
                    }
                    currentRow++;

                    // --- Product Headers ---
                    var productHeaders = new List<string> {
                "Sl", "P.I Code", "Product Name", "Unit", "Con", "HSN Code", "GST %", "Inv Mrp", "Mrp",
                "Exp Date", "To Shelf", "Lifet", "Shelf Life(days)", "Batch No", "St Loc", "Rack",
                "Bill Qty", "Rec Qty", "Diff Qty", "Free Qty", "Bill Rate", "Dis Amt", "Taxable Value", "Nett Amt"
            };

                    col = 1;
                    foreach (var h in productHeaders)
                    {
                        var cell = ExcelSheet.Cells[currentRow, col];
                        cell.Value = h;
                        cell.Font.Bold = true;
                        cell.Interior.Color = Color.LightGray;
                        col++;
                    }
                    currentRow++;

                    // --- Products Section ---
                    if (products != null && products.Count > 0)
                    {
                        col = 1;
                        var firstProduct = products[0] as JObject;

                        foreach (var prop in firstProduct.Properties())
                        {
                            var cell = ExcelSheet.Cells[currentRow, col];
                            cell.Value = prop.Name;
                            cell.Interior.Color = Color.LightGray;
                            cell.Font.Bold = true;
                            col++;
                        }
                        currentRow++;

                        foreach (var prod in products)
                        {
                            if (prod is JObject prodObj)
                            {
                                col = 1;

                                decimal invoiceQty = 0;
                                if (prodObj["InvoiceQty"] != null)
                                    decimal.TryParse(prodObj["InvoiceQty"].ToString(), out invoiceQty);

                                foreach (var prop in prodObj.Properties())
                                {
                                    var cell = ExcelSheet.Cells[currentRow, col];
                                    cell.Value = prop.Value?.ToString() ?? "";

                                    // Red font if InvoiceQty == 0
                                    cell.Font.Color = invoiceQty == 0 ? Color.Red : Color.Black;

                                    if (prop.Name == "PR_TName")
                                    {
                                        cell.Font.Bold = true;
                                        cell.Font.Name = "Uni Ila.Sundaram-03";
                                        cell.Font.Size = 9.75;
                                    }
                                    col++;
                                }
                                currentRow++;
                            }
                        }
                    }


                    // --- Footer Sections ---
                    ExcelSheet.Cells[currentRow, 1].Value = $"Bill Additions:   Loding charges: {GetValueOrEmpty(footer, "LodingCharges")}   Freight charges: {GetValueOrEmpty(footer, "FreightCharges")}   Other expenses: {GetValueOrEmpty(footer, "OtherExpenses")}";
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, maxColCount]].Merge();
                    currentRow++;

                    ExcelSheet.Cells[currentRow, 1].Value = $"Bill Deductions:   Discount %: {GetValueOrEmpty(footer, "DiscountPercent")}   Discount Amount: {GetValueOrEmpty(footer, "DiscountAmount")}   Round Off: {GetValueOrEmpty(footer, "RoundOff")}   GST @ 5%: {GetValueOrEmpty(footer, "GST5")}";
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, maxColCount]].Merge();
                    currentRow++;

                    ExcelSheet.Cells[currentRow, 1].Value = "Grand Total";
                    ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, maxColCount - 1]].Merge();
                    ExcelSheet.Cells[currentRow, maxColCount].Value = GetValueOrEmpty(footer, "GrandTotal");

                    Excel.Range gtRange = ExcelSheet.Range[ExcelSheet.Cells[currentRow, 1], ExcelSheet.Cells[currentRow, maxColCount]];
                    gtRange.Font.Bold = true;
                    gtRange.Interior.Color = Color.LightYellow;
                    currentRow += 2;

                }

                // Optional: Freeze panes below title row
                ExcelSheet.Application.ActiveWindow.SplitRow = 4;
                ExcelSheet.Application.ActiveWindow.FreezePanes = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        string GetValueOrEmpty(JObject obj, string key)
        {
            return obj != null && obj.TryGetValue(key, out var val) ? val.ToString() : "0.00";
        }



        public void udfnPurchaseDetails()
        {
            try
            {
                string varSupplierName = "",varDelay = ""; int varDelayMin = 0;
                if (txtSupplier.Text.Trim()=="")
                {
                    varSupplierName = "-All-";
                }
                else
                {
                    varSupplierName = txtSupplier.Text;
                }
                btnView.Enabled = false;
                lblNoRecordsFound.Visible = false;
                lblStatus.Focus();
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 20;
                objTRN_PurchaseEntry.paraConditionType = Convert.ToInt32(cmbConditionType.SelectedValue);
                objTRN_PurchaseEntry.paraType = Convert.ToInt32(cmbPayType.SelectedValue);
                objTRN_PurchaseEntry.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(lblschedleCode.Text);
                objTRN_PurchaseEntry.paraFromDate = dpFromDate.Text;
                objTRN_PurchaseEntry.paraToDate = dpToDate.Text;
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_Purchase_Details.rpt");
                    objBillreport.SetParameterValue("paraType", Convert.ToInt32(cmbPayType.SelectedValue));
                    objBillreport.SetParameterValue("paraConditionType", Convert.ToInt32(cmbConditionType.SelectedValue));
                    objBillreport.SetParameterValue("paraSupplierID", Convert.ToInt32(lblSupplierCode.Text));
                    objBillreport.SetParameterValue("paraScheduleID", Convert.ToInt32(lblschedleCode.Text));
                    objBillreport.SetParameterValue("paraFromDate", Convert.ToString(dpFromDate.Text));
                    objBillreport.SetParameterValue("paraToDate", Convert.ToString(dpToDate.Text));

                    objBillreport.SetParameterValue("paraPayTypeName", Convert.ToString(cmbPayType.Text));
                    objBillreport.SetParameterValue("paraConditionName", Convert.ToString(cmbConditionType.Text));
                    objBillreport.SetParameterValue("paraSupplierName", varSupplierName);
                    objBillreport.SetParameterValue("paraFromDateName", Convert.ToString(dpFromDate.Text));
                    objBillreport.SetParameterValue("paraToDateName", Convert.ToString(dpToDate.Text));
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
                picLoader.SendToBack();
                btnView.Enabled = true;
                GC.Collect();
            }
        }
        private void TxtSupplier_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPayType.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (LV_Supplier.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtSupplier.Focus();
                        LV_Supplier.Visible = false;
                    }
                    else
                    {
                        LV_Supplier.Focus();
                    }
                    if (LV_Supplier.Items.Count > 0)
                    {
                        LV_Supplier.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.BringToFront();
                //RPTViewer.SendToBack();
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 26;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                    objMR_Supplier.ParaFromDate = dpFromDate.Text;
                    objMR_Supplier.ParaToDate = dpToDate.Text;
                    objMR_Supplier.paraFlag = 5;
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString()
                                    , objDs.Tables[0].Rows[i]["SupplierName"].ToString(), objDs.Tables[0].Rows[i]["ScheduleName"].ToString()};
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.BringToFront();
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    LV_Supplier.Visible = false;
                    LV_Supplier.Items.Clear();
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
        private void LV_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LV_Supplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnListViewData()
        {
            try
            {
                if (txtSupplier.Text != "")
                {
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedleCode.Text = selectedItem.SubItems[2].Text;
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                }
                cmbPayType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                LV_Supplier.Visible = false;
            }
        }
        private void DpFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpFromDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpToDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupplier.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpToDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime varmindate = DateTime.ParseExact(dpFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dpToDate.MinDate = varmindate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConditionType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConditionType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConditionType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConditionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConditionType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbConditionType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void REPORT_GRN_Details_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void REPORT_Purchase_Details_Load(object sender, EventArgs e)
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID IN (0,7) AND STSID IN (0,17,23)", "STS_Name,STSID", cmbPayType, "", "STS_Name", "STSID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,61) AND MSTID<>-1 ORDER BY MST_OrderID ASC", "MST_DisplayText,MSTID", cmbConditionType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                cmbPayType.SelectedValue = 0;
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtPurchaseDetails = new DataTable();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry();
                objTRN_PurchaseEntry.ViewType = 20;
                objTRN_PurchaseEntry.paraConditionType = Convert.ToInt32(cmbConditionType.SelectedValue);
                objTRN_PurchaseEntry.paraType = Convert.ToInt32(cmbPayType.SelectedValue);
                objTRN_PurchaseEntry.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                objTRN_PurchaseEntry.paraScheduleID = Convert.ToInt32(lblschedleCode.Text);
                objTRN_PurchaseEntry.paraFromDate = dpFromDate.Text;
                objTRN_PurchaseEntry.paraToDate = dpToDate.Text;
                objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                objspdservice.CloseConnection();
                if (objDs.Tables[0] != null)
                {
                    dtPurchaseDetails = objDs.Tables[0];
                    List<JObject> purchaseList = new List<JObject>();
                    foreach (DataRow dr in dtPurchaseDetails.Rows)
                    {
                        string purchaseJson = dr["PurchaseJson"].ToString();
                        var purchaseObj = JObject.Parse(purchaseJson);
                        purchaseList.Add(purchaseObj);
                    }
                    string combinedJson = JsonConvert.SerializeObject(purchaseList);
                    ExportPurchaseJsonToExcelInterop(combinedJson);
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
