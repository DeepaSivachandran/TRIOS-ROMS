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

namespace ROMS
{
    public partial class CP_Purchase : Form
    {
        DateTime varmaxdate;
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpconcern = new ToolTip();
        ToolTip tpInvoice = new ToolTip();
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();
        public string varPurchaseRate = "0", varcomid = "0", pbPONO="0";

        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = ""
            , varorderSaleQty = "", varorderqty = "", addproductid = "", varunitid = "0", varDamage = "0", varReturnDC = "0", pbGRNId = "0", pbSupplierId = "0", dcid = "0",
            varenablefalg = "0", varUserID = "0", varflag = "0", varExpiryDate = "", varTName = "", varexp = "", pbScheduleId = "0", pbPOIdS = "0",
            varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0", varBatchNo = "0", varNewFlag = "0";

        public int varGrnId = 0, varCloseflag = 0, pbDateflag = 0, varShelflife = 0, expirydateFlag = 0, varErrorFormat = 0, varcount = 0, varErroronGrid = 0;
        public CP_Purchase()
        {
            InitializeComponent();
        } 

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEntryType.SelectedValue.ToString() == "54") { // GRN
                    txtQRCode.ReadOnly = false;  
                    dpInvoiceDate.Enabled = false;
                    txtInvoiceNo.ReadOnly = true;
                    grdPODetails.Visible = true;
                    grdDCDetails.Visible = false;
                }
                if (cmbEntryType.SelectedValue.ToString() == "55") // PO
                {
                    udfnPendingPOLoad();
                    udfnDefGrnGridLoad();
                    txtQRCode.ReadOnly = true;
                    txtQRCode.Enabled = false;
                    dpInvoiceDate.Enabled = true;
                    txtInvoiceNo.ReadOnly = false;
                    grdPODetails.Visible = true;
                    grdDCDetails.Visible = false;
                }
                if (cmbEntryType.SelectedValue.ToString() == "56") // Direct
                {
                    txtQRCode.ReadOnly = true;
                    txtQRCode.Enabled = false;
                    dpInvoiceDate.Enabled = true;
                    txtInvoiceNo.ReadOnly = false;
                    grdPODetails.Visible = true;
                    grdDCDetails.Visible = false;
                }
                if (cmbEntryType.SelectedValue.ToString() == "57") // Direct DC
                {
                    MainForm.objPUR_DCDeatils = new PUR_DCDeatils();
                    MainForm.objPUR_DCDeatils.ShowDialog();
                    grdPODetails.Visible = false;
                    grdDCDetails.Visible = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnDefGrnGridLoad()
        {
            try
            {
                if (pbPONO != "0")
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet(); 
                    TRN_PurchaseEntry objTRN_PurchaseEntry = new TRN_PurchaseEntry(); 
                    objTRN_PurchaseEntry.ViewType = 0;
                    objTRN_PurchaseEntry.ParaPOIds = pbPONO;
                    objDs = objspdservice.udfnGetPurchaseEntry(objTRN_PurchaseEntry);
                    objspdservice.CloseConnection();

                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        grdSupplierList.Rows.Clear(); 
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            lblNoRecordsFound.Visible = false;
                            string varMRP = "";
                            if (Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_MRP"]) == "0")
                            {
                                varMRP = "";
                            }
                            else
                            {
                                varMRP = Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_MRP"]);
                            }
                            grdSupplierList.Rows.Add(grdSupplierList.Rows.Count + 1, Convert.ToString(objDs.Tables[0].Rows[i]["PONO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["PICODE"]) , Convert.ToString(objDs.Tables[0].Rows[i]["PTNAME"]),"", varMRP,
                            Convert.ToString(objDs.Tables[0].Rows[i]["GRNPR_Expirydate"]),Convert.ToString(objDs.Tables[0].Rows[i]["PRODUCTEXP"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]),Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["BATCHDate"]),Convert.ToString(objDs.Tables[0].Rows[i]["Location"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["RKNAME"]),Convert.ToString(objDs.Tables[0].Rows[i]["UNIT"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["POID"]),Convert.ToString(objDs.Tables[0].Rows[i]["PRID"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["UTID"]),Convert.ToString(objDs.Tables[0].Rows[i]["BATCHNO"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Batchnogeneration"]),Convert.ToString(objDs.Tables[0].Rows[i]["PR_ShelfLife"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["SLID"]),Convert.ToString(objDs.Tables[0].Rows[i]["RKID"])); 
                            grdSupplierList.Columns["clmGrnMrp"].Visible = false; 
                            DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdSupplierList_DataBindingComplete(grdSupplierList, args2);
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

        public void udfnPendingPOLoad()
        {
            try
            {
                pbPONO = "0";
                for (int i = 0; i < grdPODetails.Rows.Count; i++)
                {
                    if (pbPONO == "0")
                    {
                        pbPONO = Convert.ToString(grdPODetails.Rows[i].Cells["poid"].Value);
                    }
                    else
                    {
                        pbPONO = pbPONO + ',' + Convert.ToString(grdPODetails.Rows[i].Cells["poid"].Value);
                    }
                }
                MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                MainForm.objPUR_GRNOrderType.varMasterType = 2;
                MainForm.objPUR_GRNOrderType.ShowDialog();
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
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
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

        private void BtnDamage_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_POReturns = new PUR_POReturns();
                MainForm.objPUR_POReturns.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnRemarks_Click(object sender, EventArgs e)
        {
            try
            {

                MainForm.objPUR_RemarksHistory = new PUR_RemarksHistory();
                MainForm.objPUR_RemarksHistory.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            { 
                MainForm.objCP_Items = new  CP_Product();
                MainForm.objCP_Items.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Purchase_Load(object sender, EventArgs e)
        {
            try
            {
                udfnDateset();
                udfnDropdownLoad();
                cmbEntryType.Items.Insert(0, "Against GRN");
                cmbEntryType.Items.Insert(1, "Against PO");
                cmbEntryType.Items.Insert(2, "Direct");
                cmbEntryType.Items.Insert(3, "Against Purchase DC");
                cmbEntryType.SelectedIndex = 0;
                cmbTransactionType.SelectedIndex = 0;
                dpInvoiceDate.Enabled = true;
                // this.tbDetails.DrawMode = TabDrawMode.OwnerDrawFixed;
                //  this.tbDetails.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TbDetails_DrawItem);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnDropdownLoad()
        {
            SPDataService objdserv = new SPDataService();
            int varconcerntype = 3;  
            DataSet objDT = new DataSet();
            objDT = objdserv.udfnCompanyList(varconcerntype, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
            objdserv.CloseConnection();
            cmbConcern.DataSource = null;
            if (objDT != null)
            {
                if (objDT.Tables.Count > 0)
                {
                    if (objDT.Tables[0].Rows.Count > 0)
                    {
                        cmbConcern.ValueMember = "COMID";
                        cmbConcern.DisplayMember = "COM_ShortName";
                        cmbConcern.DataSource = objDT.Tables[0];
                    }
                }
            } 
            DataBind objDataBind = new DataBind();
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (17) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbEntryType, "", "MST_DisplayText", "MSTID");
            objDataBind.BindComboBoxListSelected("DEF_Master", " MST_TransactionID in (18) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
            objDataBind = null;
            cmbEntryType.SelectedValue = "56";
            cmbTransactionType.SelectedValue = "58";
        }
        public void udfnDateset()
        { 
            try
            {
                DataSet objd = new DataSet();
                SPDataService objDServ = new SPDataService();
                objd = objDServ.udfnMaster(4, 6, 0, "", "", 0, "", 0);
                objDServ.CloseConnection();
                if (objd.Tables[1].Rows.Count != 0)
                {
                    varmaxdate = DateTime.ParseExact(objd.Tables[1].Rows[0]["mintoday"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                } 
                DateTime varmindate = MainForm.pbFYStartDate;
                dpInvoiceDate.MinDate = varmindate;
                dpVoucherDate.MinDate = varmindate;
                dpInvoiceDate.MaxDate = varmaxdate;
                dpVoucherDate.MaxDate = varmaxdate;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_Purchase_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtSupplier_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSupplier.BackColor = Color.White;
                MainForm.objPUR_GSTIN = new PUR_GSTIN();
                MainForm.objPUR_GSTIN.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void ChkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCompleted.Checked) { btnSave.Text = "Save"; } else { btnSave.Text = "Draft"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TbDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private Color[] TColors = { Color.Salmon, Color.White, Color.LightBlue };
        private void TbDetails_DrawItem(object sender, DrawItemEventArgs e)
        {
            //// get ref to this page
            //TabPage tp = ((TabControl)sender).TabPages[e.Index];

            //using (Brush br = new SolidBrush(TColors[e.Index]))
            //{
            //    Rectangle rect = e.Bounds;
            //    e.Graphics.FillRectangle(br, e.Bounds);

            //    rect.Offset(1, 1);
            //    TextRenderer.DrawText(e.Graphics, tp.Text,
            //           tp.Font, rect, tp.ForeColor);

            //    // draw the border
            //    rect = e.Bounds;
            //    rect.Offset(0, 1);
            //    rect.Inflate(0, -1);

            //    // ControlDark looks right for the border
            //    using (Pen p = new Pen(SystemColors.ControlDark))
            //    {
            //        e.Graphics.DrawRectangle(p, rect);
            //    }

            //    if (e.State == DrawItemState.Selected) e.DrawFocusRectangle();
            //}
        }
        private void GrdPurchaseList_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.F4)
            //    {
            //        int column = grdPurchaseList.CurrentCellAddress.X;
            //        string columnName = grdPurchaseList.Columns[column].Name;
            //        if (columnName == "clmPurchaseRate") {
            //            MainForm.objPUR_Calculator = new PUR_Calculator();
            //            MainForm.objPUR_Calculator.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
        }

        private void GrdPurchaseList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    int varColumn = grdPurchaseList.CurrentCellAddress.X;
                    int varRow = grdPurchaseList.CurrentCellAddress.Y;
                    string columnName = grdPurchaseList.Columns[varColumn].Name;
                    if (columnName == "clmPurchaseRate")
                    {
                        MainForm.objPUR_Calculator = new PUR_Calculator();
                        MainForm.objPUR_Calculator.ShowDialog();
                        grdPurchaseList.Rows[varRow].Cells[varColumn].Value = Convert.ToString(varPurchaseRate);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 
        private void GrdSupplierList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.grdSupplierList.Columns[e.ColumnIndex].Name == "clmExpDate")
            {
                ShortFormDateFormat(e);
            }
        }
        private static void ShortFormDateFormat(DataGridViewCellFormattingEventArgs formatting)
        {
            if (formatting.Value != null)
            {
                try
                {
                    DateTime theDate = DateTime.Parse(formatting.Value.ToString());
                    String dateString = theDate.ToString("dd-MM-yy");
                    formatting.Value = dateString;
                    formatting.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    // Set to false in case there are other handlers interested trying to
                    // format this DataGridViewCellFormattingEventArgs instance.
                    formatting.FormattingApplied = false;
                }
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
                    cmbEntryType.Focus();
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

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 30;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
                   // objMR_Supplier.ParaPOID = varPOID;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
                                LV_Supplier.Columns[3].Width = 0;
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

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try { cmbConcern.BackColor = Color.LemonChiffon; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errPurchaseentry.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpconcern.ShowAlways = true;
                    tpconcern.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    errPurchaseentry.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        { 
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpVoucherDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbConcern_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbConcern.Select(int.MaxValue, 0)));
                if (btnSave.Text == "Draft")
                {
                    if (varcomid != Convert.ToString(cmbConcern.SelectedValue))
                    {
                        if (Convert.ToString(cmbConcern.SelectedValue) != "-1")
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(78);
                            objDServ.CloseConnection();

                            DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            { 
                                grdSupplierList.Rows.Clear();
                                grdPurchaseList.Rows.Clear();
                                txtSupplier.Text = "";
                                lblSupplierCode.Text = "0";
                                txtQRCode.Text = "";
                                lblschedule.Text = "0";
                                txtInvoiceNo.Text = "0";
                                cmbEntryType.SelectedValue = "56";
                                cmbTransactionType.SelectedValue = "58";
                                txtBroker.Text = "";
                                txtGstin.Text = "";
                                lblBrokerId.Text = "0";
                                ClearSupplier(); 
                            }
                        }
                    }
                }
                varcomid = Convert.ToString(cmbConcern.SelectedValue);
                udfnVocherno();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void ClearSupplier()
        {
            try
            {

                lblSuppliername.Text = "";
                lblSupplierCity.Text = "";
                lblsupplierGST.Text = "";
                lblsupplierScheduletype.Text = "";
                lblsupplierpayment.Text = "";
                lblSupplierOrderpolicy.Text = ""; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVocherno()
        {
            try
            {
                if (btnSave.Text == "Draft")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpVoucherDate.Text + "',103)");
                        objDservice.CloseConnection();
                        varResult = objspdservice.udfngetPONO("40", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string peno = parts[0];
                        if (peno != "")
                        {
                            txtPENO.Text = peno;
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(75);
                            objDServ.CloseConnection();
                            txtPENO.Text = "";
                            DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                MainForm.objCP_Settings = new CP_Settings();
                                MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                                MainForm.objCP_Settings.varValues = Convert.ToString(38);
                                MainForm.objCP_Settings.MdiParent = this.ParentForm;
                                MainForm.objCP_Settings.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        txtPENO.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    //varSuppliervalue = selectedItem.SubItems[3].Text;
                    udfnSupplierDetails(); 
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    cmbEntryType.Focus();
                }
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

        private void CmbEntryType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbEntryType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbEntryType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbEntryType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbEntryType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dpInvoiceDate.Enabled == true)
                    {
                        dpInvoiceDate.Focus();
                    }
                    else { txtInvoiceNo.Focus(); }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbEntryType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DpVoucherDate_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtInvoiceNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtInvoiceNo.Text) == "" )
                {
                    errPurchaseentry.SetError(txtInvoiceNo, "Please enter invoice");
                    txtInvoiceNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvoice.ShowAlways = true;
                    tpInvoice.Show("Please enter invoice", txtInvoiceNo, 5000);
                }
                else
                {
                    errPurchaseentry.Clear();
                    txtInvoiceNo.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbTransactionType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBroker_Leave(object sender, EventArgs e)
        {
            try
            {
                txtBroker.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBroker_KeyDown(object sender, KeyEventArgs e)
        { 
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGstin.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lv_Broker.Items.Count == 0 || txtBroker.Text == "")
                    {
                        txtBroker.Focus();
                        lv_Broker.Visible = false;
                    }
                    else
                    {
                        lv_Broker.Focus();
                    }
                    if (lv_Broker.Items.Count > 0)
                    {
                        lv_Broker.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }  
        }

        private void TxtBroker_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBroker.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGstin_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGstin.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGstin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    chkInvoice.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtGstin_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGstin.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPurchaseCash_Enter(object sender, EventArgs e)
        { 
            try
            {
                rbPurchaseCash.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPurchaseCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbPurchaseCredit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbPurchaseCash_Leave(object sender, EventArgs e)
        {
            try
            {
                rbPurchaseCash.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPurchaseCredit_Enter(object sender, EventArgs e)
        {
            try
            {
                rbPurchaseCredit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPurchaseCredit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbPaymentCash.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbPurchaseCredit_Leave(object sender, EventArgs e)
        {
            try
            {
                rbPurchaseCredit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbRateBefore_Enter(object sender, EventArgs e)
        {
            try
            {
                rbRateBefore.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void RbRateBefore_Leave(object sender, EventArgs e)
        {
            try
            {
                rbRateBefore.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void RbRateBefore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbAfterBefore.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbAfterBefore_Enter(object sender, EventArgs e)
        {
            try
            {
                rbAfterBefore.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void RbAfterBefore_Leave(object sender, EventArgs e)
        {
            try
            {
                rbAfterBefore.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbAfterBefore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbDiscountBefore.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbPurchaseCheque_Enter(object sender, EventArgs e)
        {
            try
            {
                rbPaymentCheque.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void RbPurchaseCheque_Leave(object sender, EventArgs e)
        {
            try
            {
                rbPaymentCheque.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void RbPurchaseCheque_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbRateBefore.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbDiscountBefore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbDiscountAfter.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbDiscountBefore_Leave(object sender, EventArgs e)
        {
            try
            {
                rbDiscountBefore.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void RbDiscountBefore_Enter(object sender, EventArgs e)
        {
            try
            {
                rbDiscountBefore.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbDiscountAfter_Enter(object sender, EventArgs e)
        {
            try
            {
                rbDiscountAfter.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void RbDiscountAfter_Leave(object sender, EventArgs e)
        {
            try
            {
                rbDiscountAfter.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbDiscountAfter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   // rbDiscountAfter.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbTransactionType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbTransactionType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBroker.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTransactionType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ChkInvoice_Enter(object sender, EventArgs e)
        {
            try
            {
                chkInvoice.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkInvoice_Leave(object sender, EventArgs e)
        { 
            try
            {
                chkInvoice.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbPurchaseCash.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPaymentCash_Enter(object sender, EventArgs e)
        {
            try
            {
                rbPaymentCash.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPaymentCash_Leave(object sender, EventArgs e)
        {
            try
            {
                rbPaymentCash.BackColor = Color.WhiteSmoke;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void RbPaymentCash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbPaymentCheque.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "59")
                {
                    cmbLocation.Enabled = false; 
                    cmbrack.Enabled = false; 
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBroker_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lv_Broker.Items.Clear();
                if (txtBroker.Text.Length > 0)
                {
                    DataSet objDs = new DataSet();
                    SPDataService objspservice = new SPDataService();
                    objDs = objspservice.udfnBrokerList(4, 0, 0, 0,txtBroker.Text);
                    objspservice.CloseConnection();
                    // objMR_Supplier.ParaPOID = varPOID;
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["BR_Name"].ToString(), objDs.Tables[0].Rows[i]["BRID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lv_Broker.Items.Add(objList);
                                }
                                lv_Broker.Visible = true;
                                lv_Broker.Columns[1].Width = 0; 
                            }
                        }
                    } 
                }
                else
                {
                    lv_Broker.Visible = false;
                    lv_Broker.Items.Clear();
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

        private void Lv_Broker_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnBrokerData();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Lv_Broker_DoubleClick(object sender, EventArgs e)
        {
            try
            { 
                 udfnBrokerData(); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdSupplierList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            try
            {
                for (int i = 0; i < grdSupplierList.Rows.Count; i++)
                {
                    if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "72" && Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchgeneration"].Value) == "74")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else if (Convert.ToString(grdSupplierList.Rows[i].Cells["clmBatchenable"].Value) == "73")
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmBatchno"];
                        cell.Style.BackColor = Color.PaleGreen;
                        cell.Style.ForeColor = Color.Black;
                    }
                     
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductName_Leave(object sender, EventArgs e)
        {
            try
            {  
                txtProductName.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMrp.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    if (lvproduct.Items.Count == 0 || txtSupplier.Text == "")
                    {
                        txtProductName.Focus();
                        lvproduct.Visible = false;
                    }
                    else
                    {
                        lvproduct.Focus();
                    }
                    if (lvproduct.Items.Count > 0)
                    {
                        lvproduct.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        private void Lvproduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListviewProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnListviewProduct()
        {
            try
            {

                if (txtProductName.Text != "")
                {
                    txtMrp.Text = "";
                    txtDate.Text = "";
                    txtMonth.Text = "";
                    txtYear.Text = "";
                    txtBatchno.Text = "";
                    varBatchNo = "0"; varBatchNoGeneration = "0"; varShelflife = 0; expirydateFlag = 0;
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[3].Text;
                    lblProductcode.Text = selectedItem.SubItems[4].Text;
                    varBatchNo = selectedItem.SubItems[5].Text;
                    varBatchNoGeneration = selectedItem.SubItems[6].Text;
                    varRMProduction = selectedItem.SubItems[7].Text;
                    varPrcategory = selectedItem.SubItems[8].Text;
                    varShelflife = Convert.ToInt32(selectedItem.SubItems[9].Text);
                    if (varShelflife == 1)
                    { expirydateFlag = 1; }
                    udfnProductAdd();

                    if (Convert.ToInt32(varBatchNo) == 73)  //disabled
                    {
                        txtBatchno.Text = "";
                        txtBatchno.Enabled = false;
                        //  txtBatchNo.ReadOnly = true;
                    }
                    else if (Convert.ToInt32(varBatchNo) == 72) //enabled
                    {
                        if (Convert.ToInt32(varBatchNoGeneration) == 75)  //manual
                        {
                            txtBatchno.Enabled = true;
                            //txtBatchNo.ReadOnly = false;
                        }
                        else if (Convert.ToInt32(varBatchNoGeneration) == 74) //auto
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(14, 0, 0, "", "", 0, "", 0);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtBatchno.Text = objDs.Tables[0].Rows[0]["Date"].ToString();
                                    txtBatchno.Enabled = false;
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(varPrcategory) == 16)
                    {
                        if (Convert.ToInt32(varRMProduction) == 1)
                        {
                            SPDataService objspdservice = new SPDataService();
                            DataSet objDs = new DataSet();
                            objDs = objspdservice.udfnMaster(15, 0, 0, dpVoucherDate.Text, "", Convert.ToInt32(lblProductcode.Text), "", 0);
                            objspdservice.CloseConnection();
                            if (objDs.Tables[0] != null)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    txtDate.Text = objDs.Tables[0].Rows[0][0].ToString();
                                    txtMonth.Text = objDs.Tables[0].Rows[1][0].ToString();
                                    txtYear.Text = objDs.Tables[0].Rows[2][0].ToString();
                                }
                            }
                        }
                    }
                }
                txtMrp.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvproduct.Visible = false;
            }
        }

        public void udfnProductAdd()
        {
            try
            {
                if (Convert.ToInt32(lblProductcode.Text) != 0)
                {
                    varPICode = ""; varEName = ""; var_Symbol = ""; var_Text = ""; var_RMinSaleQty = ""; varSTOCK = ""; varPrevious = "";
                    varPARITAL = ""; varReOrderQty = ""; varorderSaleQty = ""; addproductid = ""; varunitid = ""; varexp = "";
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 34;
                    objMR_Product.ParaProductCode = Convert.ToInt32(lblProductcode.Text);
                    objMR_Product.ParaScheduleid = lblschedule.Text;
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varPICode = objDs.Tables[0].Rows[0]["PR_PICode"].ToString();
                            varEName = objDs.Tables[0].Rows[0]["PR_EName"].ToString();
                            varTName = objDs.Tables[0].Rows[0]["PR_TName"].ToString();
                            var_Symbol = objDs.Tables[0].Rows[0]["UT_Symbol"].ToString();
                            var_Text = objDs.Tables[0].Rows[0]["GST_Text"].ToString();
                            var_RMinSaleQty = objDs.Tables[0].Rows[0]["PR_MinStock"].ToString();
                            varSTOCK = objDs.Tables[0].Rows[0]["STOCK"].ToString();
                            varPrevious = objDs.Tables[0].Rows[0]["PRE.PEND"].ToString();
                            varPARITAL = objDs.Tables[0].Rows[0]["PARITAL"].ToString();
                            varReOrderQty = objDs.Tables[0].Rows[0]["PR_ReOrderQty"].ToString();
                            varorderSaleQty = "0";
                            addproductid = objDs.Tables[0].Rows[0]["PRID"].ToString();
                            varunitid = objDs.Tables[0].Rows[0]["UTID"].ToString();
                            varexp = objDs.Tables[0].Rows[0]["PRODUCTEXP"].ToString();
                        }
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
                lvproduct.Visible = false;
            }
        }

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string varProductsCodes = "0";
                lvproduct.Items.Clear();
                varNewFlag = "0";
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                int GRNID = 0;
                if (txtProductName.Text.Length > 0)
                { 
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 29;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.ParaScheduleid = Convert.ToString(lblschedule.Text);
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                   // objMR_Product.paraId = Convert.ToInt32(cmbPONo.SelectedValue);
                    objMR_Product.ParaGRNID = GRNID;
                    objMR_Product.ParaProductsCode = varProductsCodes;
                    ////ParaGRNID

                    //if (VarSearchFlag == true)
                    //{
                    //    objMR_Product.paraPicode = txtProductName.Text;
                    //    objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    //}
                    //else
                    //{
                    //    objMR_Product.paraProductName = txtProductName.Text;
                    //    objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    //}
                    objspdservice.CloseConnection();

                    //lvproduct.BeginUpdate();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(),objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(),
                                        objDs.Tables[0].Rows[i]["PR_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["PR_BatchNoGeneration"].ToString(),objDs.Tables[0].Rows[i]["PR_RMForProduction"].ToString(),objDs.Tables[0].Rows[i]["PR_PRCTID"].ToString(),objDs.Tables[0].Rows[i]["PR_ShelfLife"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.Columns[0].Width = 100;
                                lvproduct.Columns[1].Width = 250;
                                lvproduct.Columns[2].Width = 250; 
                            }
                        }
                    }
                }
                else
                {
                    lvproduct.Visible = false;
                    lvproduct.Items.Clear();
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


        public void udfnBrokerData()
        {
            try
            {
                if (txtBroker.Text != "")
                {
                    ListViewItem selectedItem = lv_Broker.SelectedItems[0];
                    txtBroker.Text = selectedItem.SubItems[0].Text;
                    lblBrokerId.Text = selectedItem.SubItems[1].Text;
                    //varSuppliervalue = selectedItem.SubItems[3].Text; 
                }
                txtGstin.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lv_Broker.Visible = false;
            }
        }

        public void udfnSupplierDetails()
        {
            try
            {
                if (Convert.ToInt32(lblSupplierCode.Text) > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 27;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text); 
                    DataSet objDs = new DataSet();
                    SPDataService objspdservice = new SPDataService();
                    objDs = objspdservice.udfnSupplierList(objMR_Supplier);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            lblSuppliername.Text = objDs.Tables[0].Rows[0]["NAME"].ToString();
                            lblSupplierCity.Text = objDs.Tables[0].Rows[0]["CITY"].ToString();
                            lblsupplierGST.Text = objDs.Tables[0].Rows[0]["GSTIN"].ToString();
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString();
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString();
                            lblSupplierOrderpolicy.Text = "Return Policy -" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                            //cmbReturnPolicy.SelectedValue = Convert.ToInt64(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                            //cmbReturnType.SelectedValue = objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString(); ;
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

    }
}
