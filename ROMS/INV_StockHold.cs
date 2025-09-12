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
    public partial class INV_StockHold : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtDefaultGrid = new DataTable();
        private ToolTip tpProductNamePICode = new ToolTip();
        private ToolTip tpQty = new ToolTip();
        private ToolTip tpReason = new ToolTip();
        private ToolTip tpProductName = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpStock = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        public string varResult = "";
        public string varUserID = "";
        public int varUpDownKeyProduct = 0, varUpDownKeyLocation = 0;

        public string varPICode="",varSHID="", varMrp="";
        public int SHID = 0, varPRID = 0, varUTID = 0, varStockLocationId = 0, varRKID = 0, varCOMID = 0, varDecimal = 0, varUpDownKey = 0, varFlag = 0;
        Boolean BlnSearchImageYN = false;
        public bool VarSearchFlag = true;
        bool varVoucherSkip = false;
        public int varClose = 0, varDateChange = 0, varDamage = 0, varParentSHID = 0, varParentQty=0;
        public INV_StockHold()
        {
            InitializeComponent();
        }
        private void INV_StockHold_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbConcern();
                DataBind objDBind = new DataBind();
                objDBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,75) AND MSTID NOT IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReason, "", "MST_DisplayText", "MSTID");
                objDBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID IN (0,114) AND MSTID<>-1 ORDER BY MSTID", "MST_DisplayText,MSTID", cmbType, "", "MST_DisplayText", "MSTID");
                objDBind = null;
                VarSearchFlag = true;
                cmbReason.SelectedValue = 0;
                cmbType.SelectedValue = 0;
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_StockHold_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    //tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    //tsbEdit_Click(sender, e);
                }
                if (e.KeyCode == Keys.Escape)
                {
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    udfntooltiphide();
                    this.Close();
                }
                //if (e.KeyCode == Keys.F11)
                //{
                //    if (VarSearchFlag == false)
                //    {
                //        VarSearchFlag = true;
                //        lblProductName.Text = "Search by P.I Code";
                //        txtProductName.CharacterCasing = CharacterCasing.Upper;
                //    }
                //    else
                //    {
                //        VarSearchFlag = false;
                //        lblProductName.Text = "Search by Product Name";
                //        txtProductName.CharacterCasing = CharacterCasing.Normal;
                //    }
                //}
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
                    MainForm objMainForm = new MainForm();
                    objMainForm.udfnCloseChildForms();
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
        public void udfnGridNull(Control skipControl)
        {
            try
            {
                if (skipControl != txtProductName)
                {
                    varUpDownKeyProduct = 0;
                    DGV_FilterProduct.DataSource = null;
                    DGV_FilterProduct.Visible = false;
                }
                if (skipControl != txtLocation)
                {
                    varUpDownKeyLocation = 0;
                    DGV_FilterLocation.DataSource = null;
                    DGV_FilterLocation.Visible = false;
                }
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
                int varLocationId = 0, varProductId = 0;
                if (txtLocation.Text.Trim() != "")
                {
                    varLocationId = Convert.ToInt32(lblLocationCode.Text);
                }
                if (txtProductName.Text.Trim() != "")
                {
                    varProductId = Convert.ToInt32(lblProductcode.Text);
                }
                varParentSHID = 0;
                dtDefaultGrid = null;
                DGV_SearchGrid.DataSource = null;
                grdStockHold.DataSource = null;
                DataSet objDS = new DataSet();
                SPDataService objdserv = new SPDataService();
                //objDS = objdserv.udfnStockHoldList(0,0);
                TRN_StockHold objTRNG_StockHold = new TRN_StockHold();
                objTRNG_StockHold.ViewType = 0;
                //objTRNG_StockHold.paraSHID = Convert.ToInt32(SHID);
                objTRNG_StockHold.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRNG_StockHold.paraFromDate = dpFromDate.Text;
                objTRNG_StockHold.paraToDate = dpToDate.Text;
                objTRNG_StockHold.paraSLID = varLocationId;
                objTRNG_StockHold.paraPRID = varProductId;
                objTRNG_StockHold.paraReason = Convert.ToInt32(cmbReason.SelectedValue);
                objTRNG_StockHold.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                objTRNG_StockHold.paraIPAddress = MainForm.pbIpAddress;
                objDS = objdserv.udfnStockHoldList(objTRNG_StockHold);
                objdserv.CloseConnection();
                if (objDS != null)
                {
                    if (objDS.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDS.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdStockHold.Columns["clmCheck"].Visible = true;
                            grdStockHold.Columns["clmDelete"].Visible = true;
                            grdStockHold.Columns["clmPrint"].Visible = true;
                            grdStockHold.Columns["clmMove"].Visible = true;
                            grdStockHold.Columns["clmConvert"].Visible = true;
                            grdStockHold.DataSource = objDS.Tables[0];
                            grdStockHold.Columns["S.No."].Width = 40;
                            grdStockHold.Columns["Created On"].Width = 140;
                            grdStockHold.Columns["Concern"].Width = 70;
                            grdStockHold.Columns["P.I Code"].Width = 100;
                            grdStockHold.Columns["Product Name"].Width = 300;
                            grdStockHold.Columns["Supplier"].Width = 220;
                            grdStockHold.Columns["Unit"].Width = 40;
                            grdStockHold.Columns["Stock Location"].Width = 100;
                            grdStockHold.Columns["Rack"].Width = 60;
                            grdStockHold.Columns["MRP"].Width = 60;
                            grdStockHold.Columns["Expiry Date"].Width = 90;
                            grdStockHold.Columns["Reason"].Width = 90;
                            grdStockHold.Columns["Batch No."].Width = 70;
                            grdStockHold.Columns["Hold Qty"].Width = 70;
                            grdStockHold.Columns["Created By"].Width = 80;
                            grdStockHold.Columns["clmCheck"].Width = 40;
                            grdStockHold.Columns["clmDelete"].Width = 40;
                            grdStockHold.Columns["clmPrint"].Width = 40;
                            grdStockHold.Columns["clmMove"].Width = 40;
                            grdStockHold.Columns["clmConvert"].Width = 50;
                            grdStockHold.Columns["SH_SPID"].Visible = false;
                            grdStockHold.Columns["SH_SPSCID"].Visible = false;
                            grdStockHold.Columns["SH_STSID"].Visible = false;
                            grdStockHold.Columns["PRID"].Visible = false;
                            grdStockHold.Columns["SLID"].Visible = false;
                            grdStockHold.Columns["UTID"].Visible = false;
                            grdStockHold.Columns["RKID"].Visible = false;
                            grdStockHold.Columns["SHID"].Visible = false;
                            grdStockHold.Columns["COMID"].Visible = false;
                            grdStockHold.Columns["SH_SPID"].Visible = false;
                            grdStockHold.Columns["SH_SPSCID"].Visible = false;
                            grdStockHold.Columns["SH_STSID"].Visible = false;
                            grdStockHold.Columns["MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockHold.Columns["Hold Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockHold.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockHold.Columns["Expiry Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockHold.Columns["Created On"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockHold.Columns["Product Name"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                            //DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            //GrdStockHold_DataBindingComplete(grdStockHold, args2);


                            grdStockHold.Columns["S.No."].ReadOnly = true;
                            grdStockHold.Columns["Concern"].ReadOnly = true;
                            grdStockHold.Columns["P.I Code"].ReadOnly = true;
                            grdStockHold.Columns["Product Name"].ReadOnly = true;
                            grdStockHold.Columns["Unit"].ReadOnly = true;
                            grdStockHold.Columns["Stock Location"].ReadOnly = true;
                            grdStockHold.Columns["Rack"].ReadOnly = true;
                            grdStockHold.Columns["MRP"].ReadOnly = true;
                            grdStockHold.Columns["Expiry Date"].ReadOnly = true;
                            grdStockHold.Columns["Batch No."].ReadOnly = true;
                            grdStockHold.Columns["Hold Qty"].ReadOnly = true;
                            grdStockHold.Columns["Reason"].ReadOnly = true;
                            grdStockHold.Columns["Supplier"].ReadOnly = true;
                            grdStockHold.Columns["Created By"].ReadOnly = true;
                            grdStockHold.Columns["Created On"].ReadOnly = true;
                            grdStockHold.Columns["Remarks"].ReadOnly = true;
                            grdStockHold.Columns["clmCheck"].ReadOnly = false;
                            picLoader.SendToBack();
                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                            grdStockHold.Columns["clmDelete"].Visible = false;
                            grdStockHold.Columns["clmPrint"].Visible = false;
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
                udfnSearchGridHead();

                if (lblNoRecordsFound.Visible == true)
                {
                    dtDefaultGrid = objDS.Tables[0];
                    udfnDefaultSearchGrid();
                }
                else { DGV_SearchGrid.ScrollBars = ScrollBars.Vertical; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            { grdStockHold.ClearSelection(); }
        }
        public void udfnDefaultSearchGrid()
        {
            try
            {
                DGV_SearchGrid.DataSource = dtDefaultGrid;
                DGV_SearchGrid.Columns["S.No."].Width = 40;
                DGV_SearchGrid.Columns["Created On"].Width = 140;
                DGV_SearchGrid.Columns["Concern"].Width = 70;
                DGV_SearchGrid.Columns["P.I Code"].Width = 100;
                DGV_SearchGrid.Columns["Product Name"].Width = 300;
                DGV_SearchGrid.Columns["Unit"].Width = 50;
                DGV_SearchGrid.Columns["Stock Location"].Width = 100;
                DGV_SearchGrid.Columns["Rack"].Width = 60;
                DGV_SearchGrid.Columns["MRP"].Width = 60;
                DGV_SearchGrid.Columns["Expiry Date"].Width = 90;
                DGV_SearchGrid.Columns["Batch No."].Width = 70;
                DGV_SearchGrid.Columns["Hold Qty"].Width = 70;
                DGV_SearchGrid.Columns["Created By"].Width = 80;
                //DGV_SearchGrid.Columns["Delete"].Width = 40;
                //DGV_SearchGrid.Columns["Edit"].Width = 30;
                DGV_SearchGrid.Columns["PRID"].Visible = false;
                DGV_SearchGrid.Columns["SLID"].Visible = false;
                DGV_SearchGrid.Columns["UTID"].Visible = false;
                DGV_SearchGrid.Columns["RKID"].Visible = false;
                DGV_SearchGrid.Columns["SHID"].Visible = false;
                DGV_SearchGrid.Columns["COMID"].Visible = false;
                DGV_SearchGrid.Columns["SH_SPID"].Visible = false;
                DGV_SearchGrid.Columns["SH_SPSCID"].Visible = false;
                DGV_SearchGrid.Columns["SH_STSID"].Visible = false;
                DGV_SearchGrid.ScrollBars = ScrollBars.Both;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
                DGV_FilterProduct.Visible = false;
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
                    dpFromDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdStockHold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdStockHold.Columns[e.ColumnIndex].Name)
                    {
                        case "clmDelete":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                udfnDelete();
                            }
                            break;
                        case "clmPrint":
                            string varSHID = "0";
                            varSHID = Convert.ToString(grdStockHold.SelectedRows[0].Cells["SHID"].Value.ToString());
                            udfnStockHoldPrint(varSHID);
                            break;
                        case "clmMove":
                            udfnMove();
                            break;
                        case "clmConvert":
                            udfnConvert();
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
        public void udfnStockHoldPrint(string varSHID)
        {
            try
            {
                DialogResult result1;
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(87);
                objDServ.CloseConnection();
                result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    string varHeader = "";
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_StockHold_Print.rpt");
                    varHeader = "Stock Hold Report";

                    objBillreport.SetParameterValue("paraSHID", Convert.ToInt32(varSHID));
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);

                    MainForm.objReportLoad = new ReportLoad();
                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                    MainForm.objReportLoad.Text = varHeader;
                    MainForm.objReportLoad.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnMove()
        {
            try
            {
                MainForm.objINV_StockHold_Location = new INV_StockHold_Location();
                MainForm.objINV_StockHold_Location.varCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                MainForm.objINV_StockHold_Location.varSLID = Convert.ToInt32(grdStockHold.SelectedRows[0].Cells["SLID"].Value);
                MainForm.objINV_StockHold_Location.varQty = Convert.ToInt32(grdStockHold.SelectedRows[0].Cells["Hold Qty"].Value);
                MainForm.objINV_StockHold_Location.varSHID = Convert.ToInt32(grdStockHold.SelectedRows[0].Cells["SHID"].Value);
                MainForm.objINV_StockHold_Location.ShowDialog();
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnConvert()
        {
            try
            {
                MainForm.objINV_StockHold_Damages = new INV_StockHold_Damages();
                MainForm.objINV_StockHold_Damages.varSHID = Convert.ToInt32(grdStockHold.SelectedRows[0].Cells["SHID"].Value);
                MainForm.objINV_StockHold_Damages.pbDamageReason = Convert.ToString(grdStockHold.SelectedRows[0].Cells["Reason"].Value);
                MainForm.objINV_StockHold_Damages.ShowDialog();
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfntooltiphide()
        {
            try
            {
                epStockHold.Clear();
                tpConcern.Active = false;
                tpProductName.Active = false;
                tpProductNamePICode.Active = false;
                tpStock.Active = false;
                tpRack.Active = false;
                tpStockLocation.Active = false;
                tpQty.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //txtQty.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }
        private void GrdStockHold_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdStockHold.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;
                    if (totalWidth - grdStockHold.Width > grdStockHold.HorizontalScrollingOffset && grdStockHold.HorizontalScrollingOffset > 0)
                    {
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                    udfnscrollVisible(DGV_SearchGrid, grdStockHold);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    var vScrollbar = grdStockHold.Controls.OfType<VScrollBar>().First();
                    if (vScrollbar.Visible == true)
                    {
                        List<int> visibleColumns = new List<int>();
                        foreach (DataGridViewColumn col in DGV.Columns)
                        {
                            visibleColumns.Add(col.Index);
                        }
                        int I = DGV_SearchGrid.Rows.Count - 1;
                        if (I == 0)
                        {
                            int rowIndex = 1;
                            DGV_SearchGrid.Rows.Add();
                            for (int i = 0; i < visibleColumns.Count; i++)
                            {
                                DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
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
        private void udfnSearchGridHead()
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    udfnGridSearchHeading(grdStockHold, DGV_SearchGrid);
                    DGV_SearchGrid.Columns.Clear();
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in grdStockHold.Columns)
                    {
                        DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                    int rowIndex = 0;
                    DGV_SearchGrid.Rows.Clear();
                    DGV_SearchGrid.Rows.Add();
                    DGV_SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                    DGV_SearchGrid.Columns[2].DefaultCellStyle.NullValue = null;
                    DGV_SearchGrid.Columns[3].DefaultCellStyle.NullValue = null;
                    DGV_SearchGrid.Columns[4].DefaultCellStyle.NullValue = null;
                    for (int i = 2; i < visibleColumns.Count; i++)
                    {
                        DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                    }
                    DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                    //DGV_SearchGrid.Columns[0].ReadOnly = true;
                    DGV_SearchGrid.Columns[1].ReadOnly = true;
                    DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Rows[0].Cells[2].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Rows[0].Cells[3].Value = new Bitmap(1, 1);
                    DGV_SearchGrid.Rows[0].Cells[4].Value = new Bitmap(1, 1);
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                dgv2.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in dgv1.Columns)
                {
                    if (col.Visible)
                    {
                        dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                }
                int rowIndex = 0;
                int ColIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                BlnSearchImageYN = false;
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                    if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                    {
                        //dgv2.Rows[rowIndex].Visible = false;
                        BlnSearchImageYN = true;
                        ColIndex = i;
                        dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                        dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                        ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                    }
                    else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                    {
                        BlnSearchImageYN = true;
                        dgv2.Rows[rowIndex].Cells[i].Value = false;
                    }
                    else
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdStockHold.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockHold);
                objDser.CloseConnection();
                grdStockHold.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 0))   /*If not our desired columns*/
                                                                   //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        //TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                        //    e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && DGV_SearchGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    if (e.Value == null || !(bool)e.Value)
                    {
                        e.PaintBackground(e.CellBounds, false);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewColumn newColumn = grdStockHold.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdStockHold.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdStockHold.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                if (newColumn.GetType() != typeof(DataGridViewImageColumn))
                {
                    grdStockHold.Sort(newColumn, direction);
                    newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;

                    DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                    DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                    DGV_SearchGrid.HorizontalScrollingOffset = grdStockHold.HorizontalScrollingOffset;
                    DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void GrdStockHold_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

            try
            {
                if (grdStockHold.ColumnCount > 0)
                {
                    grdStockHold.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdStockHold.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdStockHold.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockHold);
                objDser.CloseConnection();
                grdStockHold.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdStockHold.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockHold);
                objDser.CloseConnection();
                grdStockHold.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (lblNoRecordsFound.Visible == false)
                {
                    int totalWidth = 0;
                    int offSetValue = grdStockHold.HorizontalScrollingOffset;
                    foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                        totalWidth += col.Width;

                    if (totalWidth - grdStockHold.Width > grdStockHold.HorizontalScrollingOffset && grdStockHold.HorizontalScrollingOffset > 0)
                    {
                        //offSetValue = offSetValue ;
                        offSetValue = offSetValue;
                    }
                    DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                    DGV_SearchGrid.Invalidate();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdStockHold_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DGV_SearchGrid_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterProduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdStockHold_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdStockHold.Columns["clmCheck"].Frozen = true;
                grdStockHold.Columns["clmCheck"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdStockHold.Columns["clmDelete"].Frozen = true;
                grdStockHold.Columns["clmDelete"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdStockHold.Columns["clmPrint"].Frozen = true;
                grdStockHold.Columns["clmPrint"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdStockHold.Columns["clmMove"].Frozen = true;
                grdStockHold.Columns["clmMove"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdStockHold.Columns["clmConvert"].Frozen = true;
                grdStockHold.Columns["clmConvert"].DefaultCellStyle.BackColor = Color.AliceBlue;
                grdStockHold.ClearSelection();
                for (int i = 0; i < grdStockHold.Rows.Count; i++)
                {
                    if(Convert.ToString(grdStockHold.Rows[i].Cells["Reason"].Value) != "Damage" || Convert.ToString(grdStockHold.Rows[i].Cells["SH_STSID"].Value) == "97")
                    {
                        grdStockHold.Rows[i].Cells["clmConvert"].Value= new Bitmap(1, 1);
                    }
                    if (Convert.ToString(grdStockHold.Rows[i].Cells["SH_STSID"].Value) == "97")
                    {
                        grdStockHold.Rows[i].Cells["clmDelete"].Value = new Bitmap(1, 1);
                        //grdStockHold.Rows[i].Cells["clmEdit"].Value = new Bitmap(1, 1);
                        //grdStockHold.Rows[i].Cells["clmMove"].Value = new Bitmap(1, 1);
                        DataGridViewTextBoxCell print = new DataGridViewTextBoxCell();
                        print.Value = "";
                        grdStockHold.Rows[i].Cells["clmCheck"] = print;
                        print.ReadOnly = true;
                    }
                    if (Convert.ToString(grdStockHold.Rows[i].Cells["SH_STSID"].Value) == "95")
                    {
                        //grdStockHold.Rows[i].Cells["clmDelete"].Value = new Bitmap(1, 1);
                        //grdStockHold.Rows[i].Cells["clmEdit"].Value = new Bitmap(1, 1);
                        //grdStockHold.Rows[i].Cells["clmMove"].Value = new Bitmap(1, 1);
                    }
                    if (Convert.ToString(grdStockHold.Rows[i].Cells["Reason"].Value) == "Damage")
                    {
                        grdStockHold.Rows[i].Cells["clmMove"].Value = new Bitmap(1, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReason_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbReason.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string varStockHoldIds = "";
                if (grdStockHold.Rows.Count > 0)
                {
                    varStockHoldIds = string.Join(",",grdStockHold.Rows.Cast<DataGridViewRow>().Where(row => row.Cells[0].Value is bool isChecked && isChecked).Select(row => row.Cells["SHID"].Value?.ToString()).Where(id => !string.IsNullOrEmpty(id)));
                }
                if (varStockHoldIds != "")
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        udfnBulkDelete(varStockHoldIds);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnBulkDelete(string varStockHoldIds)
        {
            try
            {
                string result = "";
                string varoriginator = "Stock Hold Bulk Delete";
                SPDataService objspservice = new SPDataService();
                DataTable objGrnPO = new DataTable();
                TRN_StockHold objTRNS_StockHold = new TRN_StockHold();
                MainForm.objCP_Verify = new CP_Verify();
                MainForm.objCP_Verify.ShowDialog();
                varUserID = MainForm.objCP_Verify.varUserId;
                if (MainForm.objCP_Verify.flag == 1)
                {
                    objTRNS_StockHold.ViewType = 3;
                    objTRNS_StockHold.paraSHIds = varStockHoldIds;
                    objTRNS_StockHold.paraUserID = Convert.ToInt32(varUserID);
                    objTRNS_StockHold.paraOriginator = varoriginator;
                    result = objspservice.udfnStockHold(objTRNS_StockHold);
                    objspservice.CloseConnection();
                    if (result.Split('~')[0] == "3")
                    {
                        MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnList();
                    }
                    else if (result.Split('~')[0] == "4")
                    {
                        MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockHold_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    udfnCheckBoxEnable();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnCheckBoxEnable()
        {
            try
            {
                bool anyChecked = grdStockHold.Rows.Cast<DataGridViewRow>().Any(row => { var cellValue = row.Cells[0].Value;
                                  return cellValue is bool b && b; });

                tsbDelete.Enabled = anyChecked;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockHold_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdStockHold.CurrentCell is DataGridViewCheckBoxCell)
                {
                    grdStockHold.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objINV_StockHold_Entry = new INV_StockHold_Entry();
                MainForm.objINV_StockHold_Entry.FormBorderStyle = FormBorderStyle.FixedSingle;
                MainForm.objINV_StockHold_Entry.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpFromDate_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
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
                udfnGridNull((Control)sender);
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
                    txtLocation.Focus();
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

        private void TxtLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnGridNull((Control)sender);
                txtLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterLocation.Visible == false)
                {
                    txtProductName.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterLocation.Focus();
                }
                if (DGV_FilterLocation.CurrentCell == null && DGV_FilterLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterLocation.Focus();
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnLvStockLocation();
                                    DGV_FilterLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtLocation.Focus();
                    //txtLocation.SelectionStart = txtLocation.Text.Length;
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
                        txtProductName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtLocation.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyLocation == 0)
                {
                    //lvLocation.Items.Clear();
                    //lvLocation.BringToFront();
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtLocation.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnStockLocationList(26, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtLocation.Text.Trim(), 0, 0, 0, "", "", 0);
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterLocation.Visible = true;
                                    DGV_FilterLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_Default"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_StockApplicable"].Visible = false;
                                    DGV_FilterLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterLocation.Columns["SL_EName"].Width = 220;
                                    DGV_FilterLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterLocation.Visible = false;
                                    DGV_FilterLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterLocation.Visible = false;
                                DGV_FilterLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterLocation.Visible = false;
                            DGV_FilterLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterLocation.Visible = false;
                        DGV_FilterLocation.DataSource = null;
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
                txtLocation.Focus();
            }
        }

        private void DGV_FilterLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyLocation = 1;
                udfnLvStockLocation();
                txtProductName.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvStockLocation()
        {
            try
            {
                if (txtLocation.Text.Trim() != "")
                {
                    lblLocationCode.Text = Convert.ToString(DGV_FilterLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
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
                udfnGridNull((Control)sender);
                txtProductName.BackColor = Color.LemonChiffon;
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
                varUpDownKeyProduct = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterProduct.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    cmbReason.Focus();
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
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }
                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductName.Focus();
                    //txtProductName.SelectionStart = txtProductName.Text.Length;
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
                        cmbReason.Focus();
                    }
                }
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
        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeyProduct == 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (txtProductName.Text.Length > 0)
                    {
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 49;
                        objMR_Product.paraProductName = txtProductName.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Tamil Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "P.I Code";
                                    DGV_FilterProduct.Columns["UNIT"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 350;
                                    DGV_FilterProduct.Columns["UNIT"].Width = 50;
                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 0;
                                    DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
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
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text.Trim() != "")
                {
                    lblProductcode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();
                }
                cmbReason.Focus();
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
                varUpDownKeyProduct = 1;
                udfnListviewProduct();
                cmbReason.Focus();
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
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterProduct.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterProduct.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyProduct = 1;
                    }
                    else
                    {
                        varUpDownKeyProduct = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            txtProductName.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                txtProductName.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                            }

                            txtProductName.Focus();
                            txtProductName.SelectionStart = txtProductName.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKeyProduct = 1;
                                    udfnListviewProduct();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        cmbReason.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                udfnList();
                RPTViewer.SendToBack();
                RPTViewer.SendToBack();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnPrint.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtLocation.Text = DGV_FilterLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterLocation.Rows.Count) DGV_FilterLocation.CurrentCell = DGV_FilterLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterLocation.Rows.Count))
                            {
                                txtLocation.Text = DGV_FilterLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtLocation.Focus();
                            txtLocation.SelectionStart = txtLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyLocation = 1;
                                    udfnLvStockLocation();
                                    DGV_FilterLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.A))
                    {
                        TextBox txtProductName = sender as TextBox;
                        txtProductName.SelectAll();
                        e.Handled = true;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        txtProductName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnEditLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnEditLoad()
        {
            try
            {
                if (grdStockHold.SelectedRows.Count > 0)
                {
                    picLoader.Visible = true;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    MainForm.objINV_StockHold_Entry = new INV_StockHold_Entry();
                    MainForm.objINV_StockHold_Entry.btnSave.Text = "Update";
                    MainForm.objINV_StockHold_Entry.SHID = Convert.ToInt32(grdStockHold.SelectedRows[0].Cells["SHID"].Value);
                    picLoader.Visible = false;
                    picLoader.SendToBack();
                    MainForm.objINV_StockHold_Entry.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockHold_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnEditLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockHold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                udfnEditLoad();
            }
        }

        private void CmbReason_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReason.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbReason_KeyPress(object sender, KeyPressEventArgs e)
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
        private void CmbReason_KeyDown(object sender, KeyEventArgs e)
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
        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdStockHold.ColumnCount > 0)
                {
                    grdStockHold.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdStockHold.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDelete()
        {
            try
            {
                string result = "";
                string varoriginator = "Stock Hold Delete";
                SPDataService objspservice = new SPDataService();
                DataTable objGrnPO = new DataTable();
                TRN_StockHold objTRNS_StockHold = new TRN_StockHold();
                MainForm.objCP_Verify = new CP_Verify();
                MainForm.objCP_Verify.ShowDialog();
                varUserID = MainForm.objCP_Verify.varUserId;
                if (MainForm.objCP_Verify.flag == 1)
                {
                    objTRNS_StockHold.ViewType = 2;
                    objTRNS_StockHold.paraSHID = Convert.ToInt32(grdStockHold.SelectedRows[0].Cells["SHID"].Value);
                    objTRNS_StockHold.paraCompanycode = 0;
                    objTRNS_StockHold.paraPRID = 0;
                    objTRNS_StockHold.paraSLID = 0;
                    objTRNS_StockHold.paraRKID = 0;
                    objTRNS_StockHold.paraMrp = 0;
                    objTRNS_StockHold.paraExpiryDate = "";
                    objTRNS_StockHold.paraBatchNo = "";
                    objTRNS_StockHold.paraUTID = 0;
                    objTRNS_StockHold.paraQty = 0;
                    objTRNS_StockHold.paraUserID = Convert.ToInt32(varUserID);
                    objTRNS_StockHold.paraOriginator = varoriginator;
                    result = objspservice.udfnStockHold(objTRNS_StockHold);
                    varSHID = grdStockHold.SelectedRows[0].Cells["SHID"].Value.ToString();
                    grdStockHold.Rows.RemoveAt(this.grdStockHold.SelectedRows[0].Index);
                    for (int i = 0; i < grdStockHold.RowCount; i++)
                    {
                        grdStockHold.Rows[i].Cells["S.No."].Value = i + 1;
                    }
                    objspservice.CloseConnection();
                    if (result.Split('~')[0] == "3")
                    {
                        MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnList();
                    }
                    else if (result.Split('~')[0] == "4")
                    {
                        MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
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
                    epStockHold.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epStockHold.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbConcern()
        {
            try
            {
                cmbConcern.Focus();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(2, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
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
                //if (!RPTViewer.Visible)
                //{
                    //btnPrint.Image = global::ROMS.Properties.Resources.view;
                    btnPrint.Enabled = false;
                    lblNoRecordsFound.Visible = false;
                    picLoader.Visible = true;
                    RPTViewer.Visible = false;
                    picLoader.BringToFront();
                    Application.DoEvents();
                    int varPrint = 0;
                    int varLocationId = 0, varProductId = 0;
                    if (txtLocation.Text.Trim() != "")
                    {
                        varLocationId = Convert.ToInt32(lblLocationCode.Text);
                    }
                    if (txtProductName.Text.Trim() != "")
                    {
                        varProductId = Convert.ToInt32(lblProductcode.Text);
                    }
                    varParentSHID = 0;
                    dtDefaultGrid = null;
                    DGV_SearchGrid.DataSource = null;
                    grdStockHold.DataSource = null;
                    DataSet objDs = new DataSet();
                    SPDataService objdserv = new SPDataService();
                    //objDS = objdserv.udfnStockHoldList(0,0);
                    TRN_StockHold objTRNG_StockHold = new TRN_StockHold();
                    objTRNG_StockHold.ViewType = 0;
                    //objTRNG_StockHold.paraSHID = Convert.ToInt32(SHID);
                    objTRNG_StockHold.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNG_StockHold.paraFromDate = dpFromDate.Text;
                    objTRNG_StockHold.paraToDate = dpToDate.Text;
                    objTRNG_StockHold.paraSLID = varLocationId;
                    objTRNG_StockHold.paraPRID = varProductId;
                    objTRNG_StockHold.paraReason = Convert.ToInt32(cmbReason.SelectedValue);
                    objTRNG_StockHold.paraType = Convert.ToInt32(cmbType.SelectedValue);
                    objTRNG_StockHold.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRNG_StockHold.paraIPAddress = MainForm.pbIpAddress;
                    objDs = objdserv.udfnStockHoldList(objTRNG_StockHold);
                    objdserv.CloseConnection();
                    if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                    if (varPrint == 1)
                    {
                        RPTViewer.Visible = true;
                        RPTViewer.BringToFront();
                        RPTViewer.ReuseParameterValuesOnRefresh = true;
                        RPTViewer.RefreshReport();
                        CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_StockHold.rpt");
                        objBillreport.SetParameterValue("paraFromDate", dpFromDate.Text);
                        objBillreport.SetParameterValue("paraToDate", dpToDate.Text);
                        objBillreport.SetParameterValue("paraCompanyCode", Convert.ToInt32(cmbConcern.SelectedValue));
                        objBillreport.SetParameterValue("paraReason", Convert.ToInt32(cmbReason.SelectedValue));
                        objBillreport.SetParameterValue("paraType", Convert.ToInt32(cmbType.SelectedValue));
                        objBillreport.SetParameterValue("paraSLID", varLocationId);
                        objBillreport.SetParameterValue("paraPRID", varProductId);
                        objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                        objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                        objValidation.CrySqlConnection(objBillreport);
                        RPTViewer.ReportSource = objBillreport;
                        RPTViewer.Refresh();
                        grdStockHold.SendToBack();
                        RPTViewer.BringToFront();
                    }
                    else
                    {
                        lblNoRecordsFound.Visible = true;
                        //btnPrint.Image = global::ROMS.Properties.Resources.view;
                        RPTViewer.Visible = false;
                    }
                //}
                //else
                //{
                //    picLoader.Visible = true;
                //    RPTViewer.Visible = false;
                //    btnPrint.Image = global::ROMS.Properties.Resources.print;
                //    picLoader.SendToBack();
                //}
                if (lblNoRecordsFound.Visible == true)
                {
                    dtDefaultGrid = objDs.Tables[0];
                    udfnDefaultSearchGrid();
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
                btnPrint.Enabled = true;
                btnPrint.Focus();
                GC.Collect();
            }
        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                udfnPrint();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
