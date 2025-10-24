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
using System.IO;

namespace ROMS
{
    public partial class REPORT_Purchase_Details : Form
    {
        MainForm objMainForm = new MainForm();
        DynamicWindowControl windowControl = new DynamicWindowControl();
        ToolTip tpSupplier = new ToolTip();
        DataValidation objValidation = new DataValidation();
        DataError objError;
        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        public int varUpDownKey = 0;
        public REPORT_Purchase_Details()
        {
            InitializeComponent();
            windowControl.Initialize(tsPurchaseDetailsReport, this);
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
                varUpDownKey = 0;
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                //LV_Supplier.Visible = false;
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
        public void udfnList(int varFlag)
        {
            try
            {
                SPDataService objDataService = new SPDataService();
                string varMessage = objDataService.udfnGetMessages(161);
                MessageBox.Show(varMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objDataService.CloseConnection();
                if (txtSupplier.Text.Trim() == "")
                {
                    lblSupplierCode.Text = "0";
                    lblschedleCode.Text = "0";
                }
                udfnPurchaseDetails(varFlag);
                //udfnExcel();
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
                udfnList(0);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnExcel()
        {
            try
            {
                btnView.Enabled = false;
                lblNoRecordsFound.Visible = false;
                lblStatus.Focus();
                picLoader.Visible = true;
                picLoader.BringToFront();
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
                    if (objDs.Tables[0].Rows.Count > 0)
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
                        string varSupplierName = "-All-";
                        if (txtSupplier.Text.Trim() != "")
                        {
                            varSupplierName = txtSupplier.Text.Trim();
                        }
                        if (objDs.Tables[1] != null)
                        {
                            if (objDs.Tables[1].Rows.Count > 0)
                            {
                                ExportPurchaseJsonToExcelInterop(combinedJson, dpFromDate.Text + "-" + dpToDate.Text, varSupplierName, cmbPayType.Text, cmbConditionType.Text, objDs.Tables[1]);
                            }
                        }
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                    }
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
        public void ExportPurchaseJsonToExcelInterop(string jsonString, string fromDate, string supplierName, string payType, string conditionType,DataTable footerData)
        {

            try
            {
                picLoader.Visible = true;
                picLoader.BringToFront();
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnCompanyList(7, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
                objdserv.CloseConnection();
                var purchases = JArray.Parse(jsonString);
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet sheet = workbook.Sheets[1];
                excelApp.Visible = false;

                int row = 1;
                // Company Header
                if (objDs.Tables[0].Rows.Count > 0)
                {
                    var rowData = objDs.Tables[0].Rows[0];
                    string companyName = rowData["COM_Name"].ToString();
                    string address = rowData["AddressValue"].ToString();
                    string gstin = rowData["GSTIN"].ToString();

                    //sheet.Cells[row, 1] = companyName;
                    //((Excel.Range)sheet.Cells[row, 1]).Font.Bold = true;
                    //row++;

                    //sheet.Cells[row, 1] = address;
                    //row++;

                    //sheet.Cells[row, 1] = $"GSTIN : {gstin}";
                    //row++;
                    var compNameRange = sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 3]];
                    compNameRange.Merge();
                    compNameRange.Value = companyName;
                    compNameRange.Font.Bold = true;
                    row++;

                    var addressRange = sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 3]];
                    addressRange.Merge();
                    addressRange.Value = address;
                    row++;

                    var gstinRange = sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 3]];
                    gstinRange.Merge();
                    gstinRange.Value = $"GSTIN : {gstin}";
                    row++;

                }

                // Title
                sheet.Cells[row, 1] = "Purchase Details Report";
                var titleRange = sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                row++;

                // Filter Info
                //  sheet.Cells[row, 1] = $"Date : {fromDate}     Supplier Name : {supplierName}     Pay Type : {payType}     Condition Type : {conditionType}";
                sheet.Cells[row, 1] = $"Date : {fromDate}     Supplier Name : {supplierName}     Condition Type : {conditionType}";
                sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].Merge();
                row++;

                int purchaseIndex = 1;

                foreach (var purchase in purchases)
                {
                    var headerJson = purchase["Header"]?.ToString() ?? "{}";

                    if (headerJson.Contains("}{"))
                    {
                        var parts = headerJson.Split(new[] { "},{" }, StringSplitOptions.None);
                        headerJson = "{" + parts[0].Trim('{', '}') + "}";
                    }

                    int endIndex = headerJson.LastIndexOf('}');
                    if (endIndex != -1 && endIndex < headerJson.Length - 1)
                    {
                        headerJson = headerJson.Substring(0, endIndex + 1);
                    }

                    JObject header;
                    try
                    {
                        header = JsonConvert.DeserializeObject<JObject>(headerJson) ?? new JObject();
                    }
                    catch (JsonReaderException ex)
                    {
                        header = new JObject();
                    }
                    var footerJson = purchase["Footer"]?.ToString() ?? "{}";

                    if (footerJson.Contains("}{"))
                    {
                        var parts = footerJson.Split(new[] { "},{" }, StringSplitOptions.None);
                        footerJson = "{" + parts[0].Trim('{', '}') + "}";
                    }

                    endIndex = footerJson.LastIndexOf('}');
                    if (endIndex != -1 && endIndex < footerJson.Length - 1)
                    {
                        footerJson = footerJson.Substring(0, endIndex + 1);
                    }

                    JObject footer;
                    try
                    {
                        footer = JsonConvert.DeserializeObject<JObject>(footerJson) ?? new JObject();
                    }
                    catch (JsonReaderException ex)
                    {
                        footer = new JObject();
                    }
                    var products = purchase["Products"] as JArray ?? new JArray();

                    if (purchaseIndex > 1)
                    {
                        row += 1;
                    }
                    // Section headers
                    sheet.Cells[row, 1] = "SI";
                    sheet.Cells[row, 2] = "Supplier Details";
                    sheet.Range[sheet.Cells[row, 2], sheet.Cells[row, 5]].Merge();
                    sheet.Cells[row, 6] = "Invoice Details";
                    sheet.Range[sheet.Cells[row, 6], sheet.Cells[row, 11]].Merge();
                    sheet.Cells[row, 12] = "Po Details";
                    sheet.Range[sheet.Cells[row, 12], sheet.Cells[row, 13]].Merge();
                    sheet.Cells[row, 14] = "GRN Details";
                    sheet.Range[sheet.Cells[row, 14], sheet.Cells[row, 15]].Merge();
                    sheet.Cells[row, 16] = "Pur Entry Details";
                    sheet.Range[sheet.Cells[row, 16], sheet.Cells[row, 18]].Merge();
                    sheet.Cells[row, 19] = "Pur Mismatch App";
                    sheet.Range[sheet.Cells[row, 19], sheet.Cells[row, 21]].Merge();
                    sheet.Cells[row, 22] = "Pur App Details";
                    sheet.Range[sheet.Cells[row, 22], sheet.Cells[row, 24]].Merge();

                    sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].Font.Bold = true;
                    sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                    sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    row++;

                    sheet.Cells[row, 1] = purchaseIndex++;

                    //Supplier Details
                    var supplierRange = sheet.Range[sheet.Cells[row, 2], sheet.Cells[row, 3]];
                    supplierRange.Merge();
                    supplierRange.Value = $"{header["Supplier"]}";
                    supplierRange.WrapText = true;
                    supplierRange.Font.Bold = true;
                    supplierRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    var gstinRange = sheet.Range[sheet.Cells[row + 1, 2], sheet.Cells[row + 1, 3]];
                    gstinRange.Merge();
                    gstinRange.Value = $"{header["GSTIN"]}";
                    gstinRange.WrapText = true;
                    gstinRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    var cityRange = sheet.Range[sheet.Cells[row + 2, 2], sheet.Cells[row + 2, 3]];
                    cityRange.Merge();
                    cityRange.Value = $"{header["City"]}";
                    cityRange.WrapText = true;
                    cityRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    //Supplier Details Second Data
                    var gstTypeRange = sheet.Range[sheet.Cells[row, 4], sheet.Cells[row, 5]];
                    gstTypeRange.Merge();
                    string gstTypeLabel = "GST Type: ";
                    string supplierType = header["SupplierType"]?.ToString() ?? "";
                    gstTypeRange.Value = gstTypeLabel + supplierType;
                    gstTypeRange.WrapText = true;
                    gstTypeRange.Characters[gstTypeLabel.Length + 1, supplierType.Length].Font.Bold = true;

                    var payTypeRange = sheet.Range[sheet.Cells[row + 1, 4], sheet.Cells[row + 1, 5]];
                    payTypeRange.Merge();
                    string ptLabel = "PT: ";
                    string paymentTerm = header["PaymentTerm"]?.ToString() ?? "";
                    payTypeRange.Value = ptLabel + paymentTerm;
                    payTypeRange.WrapText = true;
                    payTypeRange.Characters[ptLabel.Length + 1, paymentTerm.Length].Font.Bold = true;

                    //Invoice Details
                    var invDateRange = sheet.Range[sheet.Cells[row, 6], sheet.Cells[row, 7]];
                    invDateRange.Merge();
                    string dtLabel = "DT: ";
                    string invDate = header["InvDate"]?.ToString() ?? "";
                    invDateRange.WrapText = true;
                    invDateRange.NumberFormat = "@";
                    if (!string.IsNullOrWhiteSpace(invDate))
                    {
                        invDateRange.Value = dtLabel + invDate;
                        invDateRange.Characters[dtLabel.Length + 1, invDate.Length].Font.Bold = true;
                    }
                    else
                    {
                        invDateRange.Value = dtLabel;
                    }

                    var invNoRange = sheet.Range[sheet.Cells[row + 1, 6], sheet.Cells[row + 1, 7]];
                    invNoRange.Merge();
                    string invNoLabel = "No : ";
                    string invNo = header["InvNo"]?.ToString() ?? "";
                    invNoRange.Value = invNoLabel + invNo;
                    invNoRange.WrapText = true;
                    invNoRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    invNoRange.Characters[invNoLabel.Length + 1, invNo.Length].Font.Bold = true;

                    var invAmtRange = sheet.Range[sheet.Cells[row + 2, 6], sheet.Cells[row + 2, 7]];
                    invAmtRange.Merge();
                    string invAmtLabel = "Amt : ";
                    string invAmt = header["InvAmt"]?.ToString() ?? "";
                    invAmtRange.Value = invAmtLabel + invAmt;
                    invAmtRange.WrapText = true;
                    invAmtRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    invAmtRange.Characters[invAmtLabel.Length + 1, invAmt.Length].Font.Bold = true;

                    //Invoice Details Second data
                    var entryTypeRange = sheet.Range[sheet.Cells[row, 8], sheet.Cells[row, 9]];
                    entryTypeRange.Merge();
                    string entryLabel = "Entry Type : ";
                    string entryVal = header["EntryType"]?.ToString() ?? "";
                    entryTypeRange.Value = entryLabel + entryVal;
                    entryTypeRange.WrapText = true;
                    entryTypeRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    entryTypeRange.Characters[entryLabel.Length + 1, entryVal.Length].Font.Bold = true;

                    var transactionTypeRange = sheet.Range[sheet.Cells[row + 1, 8], sheet.Cells[row + 1, 9]];
                    transactionTypeRange.Merge();
                    string trLabel = "Tr Type : ";
                    string trVal = header["TransactionType"]?.ToString() ?? "";
                    transactionTypeRange.Value = trLabel + trVal;
                    transactionTypeRange.WrapText = true;
                    transactionTypeRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    transactionTypeRange.Characters[trLabel.Length + 1, trVal.Length].Font.Bold = true;

                    var brokerRange = sheet.Range[sheet.Cells[row + 2, 8], sheet.Cells[row + 2, 9]];
                    brokerRange.Merge();
                    string brokerLabel = "Broker : ";
                    string brokerVal = header["Broker"]?.ToString() ?? "";
                    brokerRange.Value = brokerLabel + brokerVal;
                    brokerRange.WrapText = true;
                    brokerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    brokerRange.Characters[brokerLabel.Length + 1, brokerVal.Length].Font.Bold = true;

                    //Invoice Details Third data
                    var purchaseTypeRange = sheet.Range[sheet.Cells[row, 10], sheet.Cells[row, 11]];
                    purchaseTypeRange.Merge();
                    string purTypeLabel = "Pur Type: ";
                    string purTypeVal = header["PurchaseType"]?.ToString() ?? "";
                    purchaseTypeRange.Value = purTypeLabel + purTypeVal;
                    purchaseTypeRange.WrapText = true;
                    purchaseTypeRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    purchaseTypeRange.Characters[purTypeLabel.Length + 1, purTypeVal.Length].Font.Bold = true;

                    var paymentTypeRange = sheet.Range[sheet.Cells[row + 1, 10], sheet.Cells[row + 1, 11]];
                    paymentTypeRange.Merge();
                    //string payTypeLabel = "Pay Type : ";
                    //string payTypeVal = header["PaymentType"]?.ToString() ?? "";
                    string payTypeLabel = " ";
                    string payTypeVal = "";
                    paymentTypeRange.Value = payTypeLabel + payTypeVal;
                    paymentTypeRange.WrapText = true;
                    paymentTypeRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    paymentTypeRange.Characters[payTypeLabel.Length + 1, payTypeVal.Length].Font.Bold = true;

                    var eInvoiceRange = sheet.Range[sheet.Cells[row + 2, 10], sheet.Cells[row + 2, 11]];
                    eInvoiceRange.Merge();
                    string einvLabel = "E.Inv : ";
                    string einvVal = header["EInvoice"]?.ToString() ?? "";
                    eInvoiceRange.Value = einvLabel + einvVal;
                    eInvoiceRange.WrapText = true;
                    eInvoiceRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    eInvoiceRange.Characters[einvLabel.Length + 1, einvVal.Length].Font.Bold = true;

                    //PO Details
                    var ponoRange = sheet.Range[sheet.Cells[row, 12], sheet.Cells[row, 13]];
                    ponoRange.Merge();
                    ponoRange.Value = $"{header["PONo"] ?? "-"}";
                    ponoRange.WrapText = true;
                    ponoRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    var pouserRange = sheet.Range[sheet.Cells[row + 1, 12], sheet.Cells[row + 1, 13]];
                    pouserRange.Merge();
                    pouserRange.Value = $"{header["POUser"] ?? "-"}";
                    pouserRange.WrapText = true;
                    pouserRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    var pohostRange = sheet.Range[sheet.Cells[row + 2, 12], sheet.Cells[row + 2, 13]];
                    pohostRange.Merge();
                    pohostRange.Value = $"{header["POHost"] ?? "-"}";
                    pohostRange.WrapText = true;
                    pohostRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //GRN Details
                    var grnnoRange = sheet.Range[sheet.Cells[row, 14], sheet.Cells[row, 15]];
                    grnnoRange.Merge();
                    grnnoRange.Value = $"{header["GRNNo"] ?? "-"}";
                    grnnoRange.WrapText = true;
                    grnnoRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    var grnuserRange = sheet.Range[sheet.Cells[row + 1, 14], sheet.Cells[row + 1, 15]];
                    grnuserRange.Merge();
                    grnuserRange.Value = $"{header["GRNUser"]}";
                    grnuserRange.WrapText = true;
                    grnuserRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    var grnhostRange = sheet.Range[sheet.Cells[row + 2, 14], sheet.Cells[row + 2, 15]];
                    grnhostRange.Merge();
                    grnhostRange.Value = $"{header["GRNHost"]}";
                    grnhostRange.WrapText = true;
                    grnhostRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //Purchase Entry Details
                    var purnoRange = sheet.Range[sheet.Cells[row, 16], sheet.Cells[row, 18]];
                    purnoRange.Merge();
                    purnoRange.Value = $"{header["PURNo"]}";
                    purnoRange.WrapText = true;
                    purnoRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    var puruserRange = sheet.Range[sheet.Cells[row + 1, 16], sheet.Cells[row + 1, 18]];
                    puruserRange.Merge();
                    puruserRange.Value = $"{header["PURUser"]}";
                    puruserRange.WrapText = true;
                    puruserRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    var purhostRange = sheet.Range[sheet.Cells[row + 2, 16], sheet.Cells[row + 2, 18]];
                    purhostRange.Merge();
                    purhostRange.Value = $"{header["PURHost"]}";
                    purhostRange.WrapText = true;
                    purhostRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //Purchase Mismatch Approval Details
                    var grnaNoRange = sheet.Range[sheet.Cells[row, 19], sheet.Cells[row, 21]];
                    grnaNoRange.Merge();

                    var grnauserRange = sheet.Range[sheet.Cells[row + 1, 19], sheet.Cells[row + 1, 21]];
                    grnauserRange.Merge();
                    grnauserRange.Value = $"{header["GRNAUser"] ?? "-"}";
                    grnauserRange.WrapText = true;
                    grnauserRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    var grnahostRange = sheet.Range[sheet.Cells[row + 2, 19], sheet.Cells[row + 2, 21]];
                    grnahostRange.Merge();
                    grnahostRange.Value = $"{header["GRNAHost"] ?? ""}";
                    grnahostRange.WrapText = true;
                    grnahostRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //Purchase Entry Approval Details
                    var pureaRange = sheet.Range[sheet.Cells[row, 22], sheet.Cells[row, 24]];
                    pureaRange.Merge();
                    pureaRange.Value = $"{header["PUREANo"] ?? "-"}";
                    pureaRange.WrapText = true;
                    pureaRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    var pureauserRange = sheet.Range[sheet.Cells[row + 1, 22], sheet.Cells[row + 1, 24]];
                    pureauserRange.Merge();
                    pureauserRange.Value = $"{header["PUREAUser"]}";
                    pureauserRange.WrapText = true;
                    pureauserRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    var pureahostRange = sheet.Range[sheet.Cells[row + 2, 22], sheet.Cells[row + 2, 24]];
                    pureahostRange.Merge();
                    pureahostRange.Value = $"{header["PUREAHost"]}";
                    pureahostRange.WrapText = true;
                    pureahostRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    row += 3;
                    int productStartRow = row;
                    string[] productHeaders = { "PI Code", "Product Name", "Unit", "Condition", "HSN Code", "GST %", "Invoice MRP", "MRP", "Expiry Date", "Product Shelflife", "Actual Shelflife", "Shelf Life %", "Batch No", "Stock Location", "Rack", "Bill Qty", "Received Qty", "Diff Qty", "Free Qty", "Bill Rate", "Dis Amt", "Taxable Value", "Tax Value", "Nett Amount" };

                    for (int i = 0; i < productHeaders.Length; i++)
                        sheet.Cells[row, i + 1] = productHeaders[i];
                    var headerRange = sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]];
                    headerRange.Font.Bold = true;
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    row++;


                    decimal totalTaxable = 0, totalGst = 0, totalNet = 0;

                    foreach (var prod in products)
                    {
                        int col = 1;
                        foreach (var key in productHeaders)
                        {
                            if (key == "Expiry Date")
                            {
                                var expiryDate = prod["Expiry Date"]?.ToString();
                                if (!string.IsNullOrEmpty(expiryDate))
                                {
                                    var cell = sheet.Cells[row, col];
                                    cell.NumberFormat = "@"; // Force as text
                                    cell.Value = expiryDate;
                                }
                                else
                                {
                                    sheet.Cells[row, col] = "";
                                }
                            }
                            else
                            {
                                sheet.Cells[row, col] = prod[key];
                            }
                            col++;
                        }

                        sheet.Cells[row, 2].Font.Name = "Uni Ila.Sundaram-03";
                        sheet.Cells[row, 2].Font.Size = 11.75;

                        decimal invoiceQty = SafeConvertDecimal(prod["Bill Qty"]);
                        if (invoiceQty == 0)
                            sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                        totalTaxable += SafeConvertDecimal(prod["Taxable Value"]);
                        totalGst += SafeConvertDecimal(prod["Tax Value"]);
                        totalNet += SafeConvertDecimal(prod["Nett Amount"]);
                        row++;

                        int productEndRow = row - 1;
                        var productTableRange = sheet.Range[sheet.Cells[productStartRow, 1], sheet.Cells[productEndRow, 25]];
                        productTableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    }

                    // Aligned Net Total
                    sheet.Cells[row, 21] = "Net Total:";
                    sheet.Cells[row, 22] = totalTaxable;
                    sheet.Cells[row, 23] = totalGst;
                    sheet.Cells[row, 24] = totalNet;
                    sheet.Range[sheet.Cells[row, 22], sheet.Cells[row, 24]].Font.Bold = true;
                    row++;

                    sheet.Cells[row, 23] = "Grand Total:";
                    sheet.Cells[row, 24] = footer["GrandTotal"]?.ToString() ?? "0";
                    sheet.Range[sheet.Cells[row, 23], sheet.Cells[row, 24]].Font.Bold = true;
                    row++;


                    // Charges
                    sheet.Cells[row, 1] = $"Bill Addition:    Loading Charges: {footer["Unloading"]}    Freight Charges: {footer["Freight"]}    Courier Charges: {footer["Courier"]}    Other Expenses: {footer["OtherExpenses"]}    TCS Amount: {footer["TCS"]}    Unloading GRN: {footer["UnloadingGRN"]}    Freight GRN: {footer["FreightGRN"]}";
                    sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].Merge();
                    sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].Font.Bold = true;
                    row++;

                    sheet.Cells[row, 1] = $"Bill Deduction:    Discount: {footer["DiscAmnt"]}    Other Discount: {footer["OtherDisc"]}    Damage Cost: {footer["DamageCost"]}    Round Off: {footer["RoundOff"]}";
                    sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].Merge();
                    sheet.Range[sheet.Cells[row, 1], sheet.Cells[row, 25]].Font.Bold = true;
                    row += 2;
                }

                if (footerData != null && footerData.Rows.Count > 0)
                {
                    row += 2; // Leave space from previous section
                    int footerStartRow = row;

                    int footerStartCol = 4; // Column D

                    // Main Headers
                    sheet.Cells[row, footerStartCol] = "GST %";

                    string[] mainHeaders = { "Register", "IGST", "URD", "Composite", "" };
                    int[] headerColSpan = { 2, 2, 2, 2, 1 };
                    int startCol = footerStartCol + 1;

                    for (int i = 0; i < mainHeaders.Length; i++)
                    {
                        int endCol = startCol + headerColSpan[i] - 1;
                        var headerRange = sheet.Range[sheet.Cells[row, startCol], sheet.Cells[row, endCol]];
                        headerRange.Merge();
                        headerRange.Value = mainHeaders[i];
                        headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        headerRange.Font.Bold = true;

                        headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        startCol = endCol + 1;
                    }

                    var gstHeaderCell = sheet.Cells[row, footerStartCol];
                    gstHeaderCell.Font.Bold = true;
                    gstHeaderCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    gstHeaderCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    ((Excel.Range)gstHeaderCell).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    row++;

                    // Subheaders
                    string[] subHeaders = {
        "Taxable Value", "Tax Value",
        "Taxable Value", "IGST Value",
        "Taxable Value", "Reverse Tax Value",
        "Taxable Value", "Reverse Tax Value",
        "Total"
    };

                    for (int col = footerStartCol + 1; col <= footerStartCol + 9; col++)
                    {
                        sheet.Cells[row, col] = subHeaders[col - (footerStartCol + 1)];
                    }

                    var subHeaderRange = sheet.Range[
                        sheet.Cells[row, footerStartCol],
                        sheet.Cells[row, footerStartCol + 9]
                    ];
                    subHeaderRange.Font.Bold = true;
                    subHeaderRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    subHeaderRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    subHeaderRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    row++;

                    int dataRowStart = row;

                    // Insert Data Rows
                    for (int i = 0; i < footerData.Rows.Count; i++)
                    {
                        decimal rowTotal = 0;

                        for (int j = 0; j < footerData.Columns.Count; j++)
                        {
                            object cellValue = footerData.Rows[i][j];
                            int colIndex = footerStartCol + j;

                            sheet.Cells[row, colIndex] = cellValue;

                            if (j > 0 && decimal.TryParse(cellValue?.ToString(), out decimal numericValue))
                            {
                                rowTotal += numericValue;
                            }
                        }

                        sheet.Cells[row, footerStartCol + 9] = rowTotal;

                        var dataRowRange = sheet.Range[
                            sheet.Cells[row, footerStartCol],
                            sheet.Cells[row, footerStartCol + 9]
                        ];
                        dataRowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        row++;
                    }


                    int dataRowEnd = row - 1;

                    // Add Total Row
                    sheet.Cells[row, footerStartCol] = "Total";
                    sheet.Cells[row, footerStartCol].Font.Bold = true;

                    for (int col = footerStartCol + 1; col <= footerStartCol + 9; col++)
                    {
                        string colLetter = GetExcelColumnName(col);
                        string sumFormula = $"=SUM({colLetter}{dataRowStart}:{colLetter}{dataRowEnd})";
                        sheet.Cells[row, col].Formula = sumFormula;
                        sheet.Cells[row, col].Font.Bold = true;
                    }

                    var totalRowRange = sheet.Range[
                        sheet.Cells[row, footerStartCol],
                        sheet.Cells[row, footerStartCol + 9]
                    ];
                    totalRowRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow);
                    totalRowRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                    row++;

                    var footerTableRange = sheet.Range[
                        sheet.Cells[footerStartRow, footerStartCol],
                        sheet.Cells[row - 1, footerStartCol + 9]
                    ];
                    footerTableRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                string GetExcelColumnName(int columnNumber)
                {
                    int dividend = columnNumber;
                    string columnName = String.Empty;
                    int modulo;

                    while (dividend > 0)
                    {
                        modulo = (dividend - 1) % 25;
                        columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                        dividend = (dividend - modulo) / 25;
                    }

                    return columnName;
                }


                sheet.Columns.AutoFit();

                sheet.Columns[1].ColumnWidth = 11;
                sheet.Columns[2].ColumnWidth = 28;


                decimal SafeConvertDecimal(JToken token)
                {
                    decimal.TryParse(token?.ToString(), out decimal value);
                    return value;
                }
                excelApp.Visible = false;

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = "Purchase Details Report" + " _ " + dpFromDate.Text.Replace("/", "-") + "_" + dpToDate.Text.Replace("/", "-") + ".xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName);
                    MessageBox.Show("Excel file saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                workbook.Close(false);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                picLoader.Visible = false;
            }
        }
        public void udfnPurchaseDetails(int varFlag)
        {
            try
            {
                string varSupplierName = "", varDelay = ""; int varDelayMin = 0;
                if (txtSupplier.Text.Trim() == "")
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
                objTRN_PurchaseEntry.ViewType = 24;
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


                    objBillreport.SetParameterValue("paraType", Convert.ToInt32(cmbPayType.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraConditionType", Convert.ToInt32(cmbConditionType.SelectedValue), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraSupplierID", Convert.ToInt32(lblSupplierCode.Text), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraScheduleID", Convert.ToInt32(lblschedleCode.Text), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraFromDate", Convert.ToString(dpFromDate.Text), objBillreport.Subreports[0].Name.ToString());
                    objBillreport.SetParameterValue("paraToDate", Convert.ToString(dpToDate.Text), objBillreport.Subreports[0].Name.ToString());

                    objBillreport.SetParameterValue("paraPayTypeName", Convert.ToString(cmbPayType.Text));
                    objBillreport.SetParameterValue("paraConditionName", Convert.ToString(cmbConditionType.Text));
                    objBillreport.SetParameterValue("paraSupplierName", varSupplierName);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);
                    /* 0 - from view, 1- from telegram*/
                    if (varFlag == 0)
                    {
                        RPTViewer.ReportSource = objBillreport;
                        RPTViewer.Refresh();
                        //Btn_Print.Enabled = true;
                    }
                    else
                    {
                        MainForm.varcurrentdate = DateTime.Now.ToString("dd-MM-yyyy HH-mm tt");
                        string varReportName = "Purchase_Details";
                        string varfilePath = MainForm.pbTelegramPath + "\\" + varReportName + "-" + MainForm.varcurrentdate + ".pdf";
                        if (File.Exists(varfilePath)) { File.Delete(varfilePath); }
                        objBillreport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, varfilePath);
                        objMainForm.udfnSendToTelegram(varfilePath);
                        btnTelegram.Enabled = true;
                        MessageBox.Show("Sent Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
                varUpDownKey = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    cmbConditionType.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterProduct.Focus();
                }
                if (DGV_FilterProduct.CurrentCell == null && DGV_FilterProduct.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterProduct.Focus();
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSupplier.Text = DGV_FilterProduct.Rows[RowIndex].Cells["SP_NAME"].Value.ToString();
                            }
                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtSupplier.Text = DGV_FilterProduct.Rows[RowIndex].Cells["SP_NAME"].Value.ToString();
                            }

                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListViewData();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSupplier.Focus();
                    e.Handled = true;
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbConditionType.Focus();
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
                if (varUpDownKey == 0)
                {
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
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["SPID"].Visible = false;
                                    DGV_FilterProduct.Columns["SPSCID"].Visible = false;
                                    DGV_FilterProduct.Columns["SupplierName"].Visible = false;
                                    DGV_FilterProduct.Columns["ScheduleName"].Visible = false;
                                    DGV_FilterProduct.Columns["SP_NAME"].HeaderText = "Supplier";
                                    DGV_FilterProduct.Columns["SP_NAME"].Width = 260;
                                    DGV_FilterProduct.Columns["SP_NAME"].DisplayIndex = 0;
                                    DGV_FilterProduct.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                        }
                        objspdservice.CloseConnection();
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                    }
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
                if (txtSupplier.Text.Trim() != "")
                {
                    //ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    //lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    //lblschedleCode.Text = selectedItem.SubItems[2].Text;
                    //txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = DGV_FilterProduct.SelectedRows[0].Cells["SPID"].Value.ToString();
                    lblschedleCode.Text = DGV_FilterProduct.SelectedRows[0].Cells["SPSCID"].Value.ToString();
                    txtSupplier.Text = DGV_FilterProduct.SelectedRows[0].Cells["SP_NAME"].Value.ToString();
                }
                cmbConditionType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
              //  LV_Supplier.Visible = false;
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
                dynamicLabelControl.PlaceholderLabel = tsLabelPlaceholder;
                int currentMUCode = 80302;
                dynamicLabelControl.BindMenuHierarchy(currentMUCode);
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,81) AND MSTID<>-1 ORDER BY MST_OrderID ASC", "MST_DisplayText,MST_OrderID", cmbPayType, "", "MST_DisplayText", "MST_OrderID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,82) AND MSTID<>-1 ORDER BY MST_OrderID ASC", "MST_DisplayText,MSTID", cmbConditionType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                dpFromDate.MinDate = MainForm.pbFYStartDate;
                dpFromDate.MaxDate = MainForm.pbCurrentDate;
                dpToDate.MaxDate = MainForm.pbCurrentDate;
                cmbPayType.SelectedValue = 0;
                RPTViewer.Visible = true;
                RPTViewer.BringToFront();
                lblNoRecordsFound.Visible = true;
                lblNoRecordsFound.BringToFront();
                if (Convert.ToInt32(MainForm.pbUserRoleId) != 1)
                {
                    string privilege = "";
                    var result = UserAccessHelper.LoadUserAccess(currentMUCode);
                    privilege = result.PrivilegeCode;
                    btnTelegram.Visible = privilege.Contains("7");
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKey = 1;
                udfnListViewData();
                cmbConditionType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnGridviewProduct();
                //    udfnPossibleSupplierLoad();
                //}
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKey = 1;
                    }
                    else
                    {
                        varUpDownKey = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtSupplier.Text = DGV_FilterProduct.SelectedRows[0].Cells["SP_NAME"].Value.ToString();

                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtSupplier.Text = DGV_FilterProduct.Rows[RowIndex].Cells["SP_NAME"].Value.ToString();
                            }

                            txtSupplier.Focus();
                            txtSupplier.SelectionStart = txtSupplier.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnListViewData();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        //txtProductName.SelectedText = true;
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbConditionType.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnTelegram_Enter(object sender, EventArgs e)
        {
            try
            {
                btnTelegram.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnTelegram_Leave(object sender, EventArgs e)
        {
            try
            {
                btnTelegram.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void btnTelegram_Click(object sender, EventArgs e)
        {
            udfnList(1);
        }
    }
}
