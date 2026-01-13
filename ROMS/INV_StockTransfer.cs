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
    public partial class INV_StockTransfer : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;


        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpDRack = new ToolTip();
        private ToolTip tpTransferNo = new ToolTip();
        private ToolTip tpProductName = new ToolTip();
        private ToolTip tpSStockLocation = new ToolTip();
        private ToolTip tpDStockLocation = new ToolTip();
        private ToolTip tpsRack = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpExpiryDate = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpStockQty = new ToolTip();
        private ToolTip tpTransferQty = new ToolTip();
        private ToolTip tpsno = new ToolTip();
        public bool VarSearchFlag = true;
        public string varlocationcode;
        public string varLocation;
        public string varUnitSymbol = "";
        public string varUTID = "";
        public string varQTY = "";
        public string varProductName = "";
        public string varPICode = "";
        public string varProductCode = "";
        public string varBatchNo = "";
        public string varExpiryDate = "";
        public string varMRP = "";
        public string varSRKID = "";
        public int varUpDownKeySLocation = 0, varUpDownKeyDLocation = 0;
        public int varCompanyID = 0;
        public int varDecimal = 0;
        public int varFlag = 0, varUpdateflag=0;
        public string varSNo = "0";
        public int varUpdate = 0;
        public int varStockTransferID = 0;
        public int varStockRequestID = 0;
        public int varStockRequestSLID = 0;
        public int varStatusID = 0;
        public int varSLID = 0, varSTSRQID=0;
        public int EditFlag = 0;
        public int varDLID = 0;
        public int VarConcernID = 0;
        public int varModifiedFlag = 0, varTransactionType = 0;
        public int varUpDownKey = 0;
        public int ComID = 0;
        public string VarSource = "0";
        public string VarDestination = "0";
        public string varErrQty = "0", varQtyError="0";
        public string varStockEdit = "Stock Request", varIDCOUNT = "";
        bool varVoucherSkip = false;
        public int varCloseFlag=0, varClose = 0, varDateChange = 0;
        DataTable dtStock = new DataTable();

        public INV_StockTransfer()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                udfnclose();
                MainForm.objINV_StockTransferList.udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnToolTipClear()
        {
            tpConcern.Active = false;
            tpTransferNo.Active = false;
            tpProductName.Active = false;
            tpSStockLocation.Active = false;
            tpDStockLocation.Active = false;
            tpTransferQty.Active = false;
    }
        public void udfnclose()
        {
            try
            {
                if (varClose == 0)
                {
                    udfnToolTipClear();
                    if (varModifiedFlag == 1)
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
                            MainForm.objINV_StockTransferList.udfnList();
                        }
                        else
                        { btnSave.Focus(); }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            this.Close();
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
        private void INV_StockTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    BtnSave_Click(sender,e);
                }
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
                MainForm.objPUR_RemarksHistory.ShowDialog();
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
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                cmbConcern.BackColor = Color.LemonChiffon;
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
                    dpTrannsferDate.Focus();
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
        private void CmbConcern_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errStockTransfer.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    errStockTransfer.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_StockTransfer_Load(object sender, EventArgs e)
        {
            try
            {
                MainForm objMainForm = new MainForm();
                objMainForm.udfnGetDefaultCompany();
                dtStock.TableName = "TRN_StockTransfer_Product_AutoComplete";
                dtStock.Columns.Add("STK_PRID", typeof(int));
                dtStock.Columns.Add("STK_MRP", typeof(decimal));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(string));
                dtStock.Columns.Add("STK_QTY", typeof(decimal));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(string));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(string));
                dtStock.Columns.Add("STK_ProType", typeof(int));
                dtStock.Columns.Add("STK_Status", typeof(int));
                udfnCmbConcern();
                dpTrannsferDate.MinDate = MainForm.pbFYStartDate;
                dpTrannsferDate.MaxDate = MainForm.pbCurrentDate;
                if (varStockTransferID == 0 && varStockRequestID == 0)
                {
                    cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                }
                if (varClose == 1)
                {
                    this.BeginInvoke(new MethodInvoker(Close));
                }
                else
                {
                    if (varStockTransferID != 0)
                    {
                      udfnEdit();
                    }
                    else if (varStockRequestID != 0)
                    {
                        udfnSREdit();
                        chkStatus.Visible = false;
                    }
                    else
                    {
                        this.ActiveControl = txtSLocation;
                    }
                }
                if (EditFlag == 1 && txtTransactionType.Text == "Shop Request")
                {
                    MainForm.objPUR_RemarksHistory = new PUR_RemarksHistory();
                    MainForm.objPUR_RemarksHistory.varSRQID = varStockRequestID;
                    MainForm.objPUR_RemarksHistory.varEditflag = 1;
                    MainForm.objPUR_RemarksHistory.udfnRequestDialog();
                }
                else if (EditFlag == 0 && txtTransactionType.Text == "Shop Request")
                {
                    MainForm.objPUR_RemarksHistory = new PUR_RemarksHistory();
                    MainForm.objPUR_RemarksHistory.varSRQID = varSTSRQID;
                    MainForm.objPUR_RemarksHistory.varSTRID = varStockTransferID;
                    MainForm.objPUR_RemarksHistory.varEditflag = 0;
                    MainForm.objPUR_RemarksHistory.udfnRequestDialog();
                }
                if (varIDCOUNT == "")
                {
                    btnRemarks.Enabled = false;
                }
                if (EditFlag == 1 || (varStatusID==32 && varTransactionType==173))
                {
                    udfnStatus();
                }
                else if (EditFlag==0 )
                {
                    grdStockTransfer.Columns["Status"].Visible = false;
                }
                udfnDefaultHeader();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (EditFlag == 1)
                {
                    grbDStockTransfer.Enabled = false;
                }
            }
        }
        public void udfnStatus()
        {
            try
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                //**** To call the function from SP ***************
                MR_Status objMR_Status = new MR_Status();
                objMR_Status.ViewType = 0;
                objDT = objdserv.udfnGetStatus(objMR_Status);
                objdserv.CloseConnection();
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            var varComboBoxColoumn = (DataGridViewComboBoxColumn)grdStockTransfer.Columns["Status"];
                            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                            varComboBoxColoumn.ValueMember = "ID";
                            varComboBoxColoumn.DisplayMember = "Status";
                            varComboBoxColoumn.DataSource = objDT.Tables[0];
                            //grdStockTransfer.Columns[19].HeaderText = "Status";
                            //grdStockTransfer.Columns[19].DisplayIndex = 18;
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
        public void udfnEdit()
        {
            try
            {
                if(varStockTransferID!=0)
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objspservice.udfnStockTransferList(1, varStockTransferID, 0, 0, 0, 0, 0, "", "", 0, varStockRequestID, "");
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtSLocation.Text = objDS.Tables[0].Rows[0]["Source"].ToString().Replace("''", "'");
                            //txtDLocation.Text = objDS.Tables[0].Rows[0]["Destination"].ToString().Replace("''", "'");
                            dpTrannsferDate.Text = objDS.Tables[0].Rows[0]["Transfer Date"].ToString().Replace("''", "'");
                            txtTransferNo.Text = objDS.Tables[0].Rows[0]["Transfer No."].ToString().Replace("''", "'");
                            cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["ConcernID"].ToString();
                            cmbDRack.SelectedValue = objDS.Tables[0].Rows[0]["DRKID"].ToString();
                            //txtSRack.Text = objDS.Tables[0].Rows[0]["Source Rack"].ToString();
                            varSRKID = objDS.Tables[0].Rows[0]["SRKID"].ToString();
                            txtRemarks.Text = objDS.Tables[0].Rows[0]["Remarks"].ToString();
                            lblSLocation.Text = objDS.Tables[0].Rows[0]["SLID"].ToString();
                            lblDLocation.Text = objDS.Tables[0].Rows[0]["DLID"].ToString();
                            txtTransactionType.Text = objDS.Tables[0].Rows[0]["Transaction Type"].ToString();
                            //btnSave.Text = "Update";
                            //if (EditFlag==1)
                            //{
                            //    txtTransactionType.Text = "Shop Request";
                            //}
                        }
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                            {
                                grdStockTransfer.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[0].Rows[i]["PICode"]), Convert.ToString(objDS.Tables[0].Rows[i]["Product"]), Convert.ToString(objDS.Tables[0].Rows[i]["Source Rack"]),
                                Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToString(objDS.Tables[0].Rows[i]["Destination"]), Convert.ToString(objDS.Tables[0].Rows[i]["Destination Rack"]), Convert.ToString(objDS.Tables[0].Rows[i]["Stock Qty"]),
                                Convert.ToDecimal(objDS.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDS.Tables[0].Rows[i]["Unit"]), Convert.ToString(objDS.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDS.Tables[0].Rows[i]["SRKID"]), Convert.ToString(objDS.Tables[0].Rows[i]["UnitID"]), Convert.ToDecimal(objDS.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDS.Tables[0].Rows[i]["Current StockQty"]), Convert.ToString(objDS.Tables[0].Rows[i]["UT_Decimal"]), Convert.ToString(objDS.Tables[0].Rows[i]["ProStatus"])); 
                                dtStock.Rows.Add(Convert.ToInt32(objDS.Tables[0].Rows[i]["PRID"]), string.Format("{0:G29}", decimal.Parse(Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]))), Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToString(objDS.Tables[0].Rows[i]["UnitID"]), Convert.ToDecimal(objDS.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDS.Tables[0].Rows[i]["SRKID"]), Convert.ToString(objDS.Tables[0].Rows[i]["DLID"]), Convert.ToString(objDS.Tables[0].Rows[i]["DRKID"]), Convert.ToString(objDS.Tables[0].Rows[i]["STRPR_ProType"]), Convert.ToString(objDS.Tables[0].Rows[i]["STRPR_STSID"]));
                                decimal CurrentStockQty = Convert.ToDecimal(grdStockTransfer.Rows[i].Cells["clmCurrentStockQty"].Value);
                                decimal TransferQty = Convert.ToDecimal(grdStockTransfer.Rows[i].Cells["clmquantity"].Value);

                                if (Convert.ToDecimal(CurrentStockQty) < Convert.ToDecimal(TransferQty))
                                {
                                    ((DataGridViewImageCell)grdStockTransfer.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1); 
                                    //grdStockTransfer.Rows[i].Cells["clmRemove"].ReadOnly = true;
                                }
                            }
                            //btnSave.Text = "Update";
                            ((DataGridViewTextBoxColumn)grdStockTransfer.Columns["clmquantity"]).MaxInputLength = 8;
                            grdStockTransfer.Columns["clmdsno"].Width = 50;
                            grdStockTransfer.Columns["clmmrp"].Width = 100;
                            grdStockTransfer.Columns["clmquantity"].Width = 100;
                            grdStockTransfer.Columns["clmExpirydate"].Width = 90;
                            grdStockTransfer.Columns["clmbatchno"].Width = 70;
                            grdStockTransfer.Columns["clmDestLocation"].Width = 130;
                            grdStockTransfer.Columns["clmDestRack"].Width = 120;
                            grdStockTransfer.Columns["clmUnit"].Width = 40;
                            grdStockTransfer.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockTransfer.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockTransfer.Columns["clmbatchno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            grdStockTransfer.Columns["clmquantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockTransfer.Columns["clmStockQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockTransfer.Columns["clmExpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    if (varStatusID != 21)
                    {
                        grdStockTransfer.ReadOnly = true;
                        grdStockTransfer.Columns["clmRemove"].Visible = false;
                        btnSave.Enabled = false;
                        chkStatus.Checked = true;chkStatus.Enabled = false;
                        txtProductNamePICode.Enabled = false;
                        txtDLocation.Enabled = false;
                        txtQuantity.Enabled = false;
                        cmbDRack.Enabled = false;
                        btnAdd.Enabled = false;
                        txtRemarks.Enabled = false;
                        this.ActiveControl = btnClose;
                        DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                        GrdStockTransfer_DataBindingComplete(grdStockTransfer, args);
                    }
                    DGV_FilterSLocation.Visible = false;
                    DGV_FilterSLocation.DataSource = null;
                    DGV_FilterDLocation.Visible = false;
                    DGV_FilterDLocation.DataSource = null;
                    cmbConcern.Enabled = false;
                    dpTrannsferDate.Enabled = false;
                    txtSLocation.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txttotalitem.Text = Convert.ToString(grdStockTransfer.Rows.Count);
                grdStockTransfer.ClearSelection();
            }
        }
        public void udfnSREdit()
        {
            try
            {
                if (varStockRequestID != 0)
                {
                    grdStockTransfer.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    this.ActiveControl = txtRemarks;
                    errStockTransfer.Clear();
                    grbStockTransfer.Enabled = false;
                    //grbDStockTransfer.Enabled = false;
                    txtTransactionType.Text = "Shop Request";
                    btnSave.Text = "Update";
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    Model.TRN_StockRequest objTRNG_StockRequest = new Model.TRN_StockRequest();
                    objTRNG_StockRequest.ViewType = 4;
                    objTRNG_StockRequest.paraStockRequestID = varStockRequestID;
                    objTRNG_StockRequest.paraSLID = varStockRequestSLID;
                    objDS = objspservice.udfnStockRequestList(objTRNG_StockRequest);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                            {
                                cmbConcern.Text = objDS.Tables[0].Rows[0]["Company"].ToString();
                                cmbConcern.SelectedValue = Convert.ToInt32(objDS.Tables[0].Rows[0]["COMID"].ToString());
                                txtSLocation.Text = objDS.Tables[0].Rows[0]["Source Location"].ToString();
                                grdStockTransfer.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["S.No"]), Convert.ToString(objDS.Tables[0].Rows[i]["PICode"]), Convert.ToString(objDS.Tables[0].Rows[i]["Product"]), Convert.ToString(objDS.Tables[0].Rows[i]["Source Rack"]), Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToString(objDS.Tables[0].Rows[i]["Location"]), Convert.ToString(objDS.Tables[0].Rows[i]["Dest Rack"]), Convert.ToString(objDS.Tables[0].Rows[i]["Stock Qty"]), Convert.ToString(objDS.Tables[0].Rows[i]["Qty"]), Convert.ToString(objDS.Tables[0].Rows[i]["Unit"]),Convert.ToString(objDS.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDS.Tables[0].Rows[i]["SRKID"]), Convert.ToString(objDS.Tables[0].Rows[i]["PR_UTID"]),0,0, Convert.ToString(objDS.Tables[0].Rows[i]["UT_Decimal"]));
                                string varMRP = "0";
                                if (Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]) != "") { varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]))); }
                                dtStock.Rows.Add(Convert.ToInt32(objDS.Tables[0].Rows[i]["PRID"]), varMRP, Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToString(objDS.Tables[0].Rows[i]["UTID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Qty"]), Convert.ToString(objDS.Tables[0].Rows[i]["RKID"]), Convert.ToString(objDS.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDS.Tables[0].Rows[i]["DRKID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Pro Type"]),0);
                                if(Convert.ToInt32(grdStockTransfer.Rows[i].Cells["clmStockQty"].Value)==0)
                                {
                                    grdStockTransfer.Rows[i].Cells["Status"].Value = 80;
                                    grdStockTransfer.Rows[i].Cells["Status"].ReadOnly = true;
                                    grdStockTransfer.Rows[i].Cells["clmquantity"].ReadOnly = true;
                                    dtStock.Rows[i]["STK_Status"] = 80;
                                    grdStockTransfer.Rows[i].Cells["clmquantity"].Style.BackColor = Color.LightGray;
                                }
                                //string varUTDec = Convert.ToString(objDS.Tables[0].Rows[i]["UT_Decimal"]);
                            }      
                            //int CurrentStockQty = Convert.ToInt32(grdStockTransfer.Rows[i].Cells["clmCurrentStockQty"].Value);
                            //int TransferQty = Convert.ToInt32(grdStockTransfer.Rows[i].Cells["clmquantity"].Value);

                            //if (Convert.ToInt32(CurrentStockQty) < Convert.ToInt32(TransferQty))
                            //{
                            //    ((DataGridViewImageCell)grdStockTransfer.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1); ;
                            //    //grdStockTransfer.Rows[i].Cells["clmRemove"].ReadOnly = true;
                            //}
                            //btnSave.Text = "Update";
                            ((DataGridViewTextBoxColumn)grdStockTransfer.Columns["clmquantity"]).MaxInputLength = 8;
                            grdStockTransfer.Columns["clmdsno"].Width = 50;
                            grdStockTransfer.Columns["clmmrp"].Width = 100;
                            grdStockTransfer.Columns["clmquantity"].Width = 100;
                            grdStockTransfer.Columns["clmExpirydate"].Width = 90;
                            grdStockTransfer.Columns["clmbatchno"].Width = 70;
                            grdStockTransfer.Columns["clmDestLocation"].Width = 130;
                            grdStockTransfer.Columns["clmDestRack"].Width = 120;
                            grdStockTransfer.Columns["clmUnit"].Width = 40;
                            grdStockTransfer.Columns["clmStockQty"].Visible = true;
                            grdStockTransfer.Columns["clmRemove"].Visible = true;
                            grdStockTransfer.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockTransfer.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockTransfer.Columns["clmbatchno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            grdStockTransfer.Columns["clmquantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockTransfer.Columns["clmStockQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockTransfer.Columns["clmExpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    //if (varStatusID != 21)
                    //{
                    //    grdStockTransfer.ReadOnly = true;
                    //    grdStockTransfer.Columns["clmRemove"].Visible = false;
                    //    btnSave.Enabled = false;
                    //    chkStatus.Checked = true; chkStatus.Enabled = false;
                    //    txtProductNamePICode.Enabled = false;
                    //    txtDLocation.Enabled = false;
                    //    txtQuantity.Enabled = false;
                    //    cmbDRack.Enabled = false;
                    //    btnAdd.Enabled = false;
                    //    txtRemarks.Enabled = false;
                    //    this.ActiveControl = btnClose;
                    //    DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                    //    GrdStockTransfer_DataBindingComplete(grdStockTransfer, args);
                    //}
                    //DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                    //GrdStockTransfer_DataBindingComplete(grdStockTransfer, args);

                    DGV_FilterSLocation.Visible = false;
                    DGV_FilterSLocation.DataSource = null;
                    DGV_FilterDLocation.Visible = false;
                    DGV_FilterDLocation.DataSource = null;
                    cmbConcern.Enabled = false;
                    dpTrannsferDate.Enabled = false;
                    txtSLocation.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                grdStockTransfer.ClearSelection();
                txttotalitem.Text = Convert.ToString(grdStockTransfer.Rows.Count);
            }
        }
        public void udfnCmbConcern()
        {
            try
            {
                //cmbConcern.Focus();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnCompanyList(3, 0, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                txtSLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeySLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterSLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterSLocation.Visible == false)
                {
                    txtProductNamePICode.Focus();
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterSLocation.Focus();
                }
                if (DGV_FilterSLocation.CurrentCell == null && DGV_FilterSLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterSLocation.Focus();
                    int RowIndex = DGV_FilterSLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySLocation = 1;
                    }
                    else
                    {
                        varUpDownKeySLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtSLocation.Text = DGV_FilterSLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtSLocation.Focus();
                            txtSLocation.SelectionStart = txtSLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSLocation.Rows.Count) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSLocation.Rows.Count))
                            {
                                txtSLocation.Text = DGV_FilterSLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSLocation.Focus();
                            txtSLocation.SelectionStart = txtSLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSLocation.Rows.Count > 0)
                                {
                                    varUpDownKeySLocation = 1;
                                    udfnSLocationEvent();
                                    DGV_FilterSLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtSLocation.Focus();
                    //txtSLocation.SelectionStart = txtSLocation.Text.Length;
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
                        txtProductNamePICode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtSLocation.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtSLocation, "Please enter location");
                    txtSLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSStockLocation.ShowAlways = true;
                    tpSStockLocation.Show("Please enter location", txtSLocation, 5000);
                    lblSLocation.Text = "0";
                }
                else
                {
                    errStockTransfer.Clear();
                    txtSLocation.BackColor = Color.White;
                }
                if (txtSLocation.Text == "")
                {
                    txtProductNamePICode.Focus();
                    DGV_FilterSLocation.Visible = false;
                    DGV_FilterSLocation.DataSource = null;
                }/*
                else
                {
                    lvSLocation.Focus();

                    if (grdStockTransfer.Rows.Count > 0)
                    {
                        udfnSLocationValid();
                        if (Convert.ToString(varlocationcode) != Convert.ToString(lblSLocation.Text))
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(78);
                            objDServ.CloseConnection();
                            DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdStockTransfer.Rows.Clear();
                                dtStock.Rows.Clear();
                                txtDLocation.Focus();
                                txtProductNamePICode.Text = "";
                                txtMRP.Text = "";
                                txtSRack.Text = "";
                                txtExpiryDate.Text = "";
                                txtBatchNo.Text = "";
                                txtStockQty.Text = "";
                                txtQuantity.Text = "";
                                txtDLocation.Text = "";
                                cmbDRack.Text = "None"; cmbDRack.Enabled = false;
                            }
                            else
                            {
                                txtSLocation.Text = varLocation;
                            }
                        }
                    }
                }*/
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDLocationValid()
        {
            /* Check purchase stock location is valid or not*/
            string varId_PurLocation = "0";
            if (txtDLocation.Text == "")
            {
                varId_PurLocation = "0";
            }
            else
            {
                DataSet objDsPurLoc = new DataSet();
                SPDataService objDServ3 = new SPDataService();
                MR_Location objMR_Location = new MR_Location();
                objMR_Location.paraViewType = 14;
                objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Location.paraLocationName = txtDLocation.Text.Trim();
                objDsPurLoc = objDServ3.udfnStockLocationList(objMR_Location);
                objDServ3.CloseConnection();
                //objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtDLocation.Text.Trim(), 0, 0, 0,"","",0);
                if (objDsPurLoc != null)
                {
                    if (objDsPurLoc.Tables.Count > 0)
                    {
                        if (objDsPurLoc.Tables[0].Rows.Count > 0)
                        {
                            varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                        }
                    }
                }
            }
            lblDLocation.Text = Convert.ToString(varId_PurLocation);
        }
        private void TxtSLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKeySLocation == 0)
                {
                    if (txtDLocation.Text == "")
                    { udfnDefaultHeader(); }
                    if (txtDLocation.Text != "" || txtProductNamePICode.Text != "")
                    {
                        txtProductNamePICode.Text = "";
                        txtMRP.Text = "";
                        txtSRack.Text = "";
                        txtExpiryDate.Text = "";
                        txtBatchNo.Text = "";
                        txtStockQty.Text = "";
                        txtQuantity.Text = "";
                        txtDLocation.Text = "";
                        cmbDRack.Text = "None"; cmbDRack.Enabled = false;
                        udfnDefaultHeader();
                    }
                    if (txtSLocation.Text.Length > 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 21;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtSLocation.Text.Trim();
                        objMR_Location.paraUserLocations = MainForm.pbUserMappedLocationIds;
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(21, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSLocation.Text, 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterSLocation.Visible = true;
                                    DGV_FilterSLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterSLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterSLocation.Columns["STK_Qty"].Visible = false;
                                    DGV_FilterSLocation.Columns["SL_COMID"].Visible = false;
                                    DGV_FilterSLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterSLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterSLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterSLocation.Columns["SL_EName"].Width = 180;
                                    DGV_FilterSLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterSLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterSLocation.Visible = false;
                                    DGV_FilterSLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterSLocation.Visible = false;
                                DGV_FilterSLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterSLocation.Visible = false;
                            DGV_FilterSLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterSLocation.Visible = false;
                        DGV_FilterSLocation.DataSource = null;
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
        public void udfnSLocationEvent()
        {
            try
            {
                if (txtSLocation.Text != "")
                {
                    lblSLocation.Text = Convert.ToString(DGV_FilterSLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtSLocation.Text = DGV_FilterSLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                //udfnSLocationValid();
                udfnSLocationRackValid();
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                lvProduct.Visible = false;
                DGV_FilterProduct.Visible = false;
                txtDLocation.BackColor = Color.LemonChiffon;
                if(txtProductNamePICode.Text.Trim()!="")
                {
                    txtProductNamePICode.BackColor = Color.White;
                    errStockTransfer.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKeyDLocation = 0;
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    DGV_FilterDLocation.Focus();

                }
                if (e.KeyCode == Keys.Enter && DGV_FilterDLocation.Visible == false)
                {
                    if (cmbDRack.Enabled == true)
                    {
                        cmbDRack.Focus();
                    }
                    else
                    {
                        txtQuantity.Focus();
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    DGV_FilterDLocation.Focus();
                }
                if (DGV_FilterDLocation.CurrentCell == null && DGV_FilterDLocation.RowCount == 0)
                {
                    return;
                }
                else
                {
                    DGV_FilterDLocation.Focus();
                    int RowIndex = DGV_FilterDLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterDLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyDLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyDLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterDLocation.CurrentCell = DGV_FilterDLocation.Rows[RowIndex].Cells[ClmIndex];
                            if (RowIndex != (-1))
                            {
                                txtDLocation.Text = DGV_FilterDLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }
                            txtDLocation.Focus();
                            txtDLocation.SelectionStart = txtDLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterDLocation.Rows.Count) DGV_FilterDLocation.CurrentCell = DGV_FilterDLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterDLocation.Rows.Count))
                            {
                                txtDLocation.Text = DGV_FilterDLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtDLocation.Focus();
                            txtDLocation.SelectionStart = txtDLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterDLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyDLocation = 1;
                                    udfnDLocationEvent();
                                    DGV_FilterDLocation.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtDLocation.Focus();
                    //txtDLocation.SelectionStart = txtDLocation.Text.Length;
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
                        if (cmbDRack.Enabled == true)
                        {
                            cmbDRack.Focus();
                        }
                        else
                        {
                            txtQuantity.Focus();
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
        private void TxtDLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtDLocation.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtDLocation, "Please enter location");
                    txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDStockLocation.ShowAlways = true;
                    tpDStockLocation.Show("Please enter location", txtDLocation, 5000);
                    lblDLocation.Text = "0";
                }
                else
                {
                    errStockTransfer.Clear();
                    txtDLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSLocationValid()
        {
            /* Check purchase stock location is valid or not*/
            string varId_PurLocation = "0";
            if (txtSLocation.Text == "")
            {
                varId_PurLocation = "0";
            }
            else
            {
                DataSet objDsPurLoc = new DataSet();
                SPDataService objDServ3 = new SPDataService();
                MR_Location objMR_Location = new MR_Location();
                objMR_Location.paraViewType = 14;
                objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objMR_Location.paraLocationName = txtSLocation.Text.Trim();
                objDsPurLoc = objDServ3.udfnStockLocationList(objMR_Location);
                objDServ3.CloseConnection();
                //objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSLocation.Text.Trim(), 0, 0, 0,"","",0);
                if (objDsPurLoc != null)
                {
                    if (objDsPurLoc.Tables.Count > 0)
                    {
                        if (objDsPurLoc.Tables[0].Rows.Count > 0)
                        {
                            varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                        }
                    }
                }
            }
            lblSLocation.Text = Convert.ToString(varId_PurLocation);
        }
        public void udfnSLocationRackValid()
        {
            /* Check purchase stock location is valid or not*/
            string varId_PurLocation = "0";
            if (txtSLocation.Text == "")
            {
                varId_PurLocation = "0";
            }
            else
            {
                DataSet objDsPurLoc = new DataSet();
                SPDataService objDServ3 = new SPDataService();
                MR_Location objMR_Location = new MR_Location();
                objMR_Location.paraViewType = 28;
                objMR_Location.paraLocationName = txtSLocation.Text.Trim();
                objMR_Location.paraRackId = Convert.ToInt32(varSRKID);
                objDsPurLoc = objDServ3.udfnStockLocationList(objMR_Location);
                objDServ3.CloseConnection();
                //objDsPurLoc = objDServ3.udfnStockLocationList(28, 0, 0, 0, txtSLocation.Text.Trim(),0, 0, 0, "", "",Convert.ToInt32(varSRKID));
                if (objDsPurLoc != null)
                {
                    if (objDsPurLoc.Tables.Count > 0)
                    {
                        if (objDsPurLoc.Tables[0].Rows.Count > 0)
                        {
                            varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                        }
                        else
                        {
                            varId_PurLocation = "0";
                        }
                    }
                }
            }
            varLocation = Convert.ToString(varId_PurLocation);
        }
        private void TxtDLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //udfnSLocationValid();
                if (varUpDownKeyDLocation == 0)
                {
                    int varSLID = 0;
                    if (txtSLocation.Text.Trim() != "")
                    {
                        varSLID = Convert.ToInt32(lblSLocation.Text);
                    }
                    if (txtDLocation.Text.Length > 0)
                    {
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 24;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationId = varSLID;
                        objMR_Location.paraLocationName = txtDLocation.Text.Trim();
                        objDs = objspdservice.udfnStockLocationList(objMR_Location);
                        objspdservice.CloseConnection();
                        //objDs = objspdservice.udfnStockLocationList(24, Convert.ToInt32(cmbConcern.SelectedValue), varSLID, 0, txtDLocation.Text, 0, 0, 0, "", "", 0);
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {
                                    DGV_FilterDLocation.Visible = true;
                                    DGV_FilterDLocation.DataSource = objDs.Tables[0];
                                    DGV_FilterDLocation.Columns["SLID"].Visible = false;
                                    DGV_FilterDLocation.Columns["SL_TName"].Visible = false;
                                    DGV_FilterDLocation.Columns["SL_ShortName"].Visible = false;
                                    DGV_FilterDLocation.Columns["SL_StockApplicable"].Visible = false;
                                    DGV_FilterDLocation.Columns["SL_COMID"].Visible = false;
                                    DGV_FilterDLocation.Columns["SL_EName"].HeaderText = "Location";
                                    DGV_FilterDLocation.Columns["SL_EName"].Width = 180;
                                    DGV_FilterDLocation.Columns["SL_EName"].DisplayIndex = 0;
                                    DGV_FilterDLocation.BringToFront();
                                }
                                else
                                {
                                    DGV_FilterDLocation.Visible = false;
                                    DGV_FilterDLocation.DataSource = null;
                                }
                            }
                            else
                            {
                                DGV_FilterDLocation.Visible = false;
                                DGV_FilterDLocation.DataSource = null;
                            }
                        }
                        else
                        {
                            DGV_FilterDLocation.Visible = false;
                            DGV_FilterDLocation.DataSource = null;
                        }
                    }
                    else
                    {
                        DGV_FilterDLocation.Visible = false;
                        DGV_FilterDLocation.DataSource = null;
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
        public void udfnDLocationEvent()
        {
            try
            {
                if (txtDLocation.Text != "")
                {
                    lblDLocation.Text = Convert.ToString(DGV_FilterDLocation.SelectedRows[0].Cells["SLID"].Value.ToString());
                    txtDLocation.Text = DGV_FilterDLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                    udfncmbDRack();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductNamePICode_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnSLocationValid();
                if (Convert.ToString(lblSLocation.Text).Trim() == "0" || Convert.ToString(lblSLocation.Text).Trim() == "-1")
                {
                    errStockTransfer.SetError(txtSLocation, "Please enter valid location");
                    txtSLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSStockLocation.ShowAlways = true;
                    tpSStockLocation.Show("Please enter valid location", txtSLocation, 5000);
                }
                else
                {
                    errStockTransfer.Clear();
                    txtSLocation.BackColor = Color.White;
                }
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                txtProductNamePICode.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductNamePICode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                varUpDownKey = 0;
                /*
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvProduct.Items.Count == 0 || txtProductNamePICode.Text == "")
                    {
                        txtProductNamePICode.Focus();
                        lvProduct.Visible = false;
                    }
                    else
                    {
                        lvProduct.Focus();
                    }
                    if (lvProduct.Items.Count > 0)
                    {
                        lvProduct.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtDLocation.Focus();
                }
                */
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblProductNamePICode.Text = "Search by P.I Code (F11)";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductNamePICode.Text = "Search by Product Name (F11)";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Normal;
                    }
                }
                if (e.KeyCode == Keys.Enter && DGV_FilterProduct.Visible == false)
                {
                    txtDLocation.Focus();
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
                                if (VarSearchFlag == true)
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnProductEvent();
                                    txtDLocation.Focus();
                                    DGV_FilterProduct.Visible = false;
                                }
                                e.Handled = e.SuppressKeyPress = true;
                                break;
                            }
                    }
                    txtProductNamePICode.Focus();
                    //txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
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
                        txtDLocation.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductNamePICode_Leave(object sender, EventArgs e)
        {
            try
            {
                errStockTransfer.Clear();
                txtProductNamePICode.BackColor = Color.White;
                /*
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductName.ShowAlways = true;
                    tpProductName.Show("Please enter product name", txtProductNamePICode, 5000);
                }
                else
                {
                    errStockTransfer.Clear();
                    txtProductNamePICode.BackColor = Color.White;
                }
                */
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductNamePICode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (varUpDownKey == 0)
                {
                    txtMRP.Text = "";
                    txtSRack.Text = "";
                    txtExpiryDate.Text = "";
                    txtBatchNo.Text = "";
                    txtStockQty.Text = "";
                    txtQuantity.Text = "";
                    txtDLocation.Text = "";
                    cmbDRack.Text = "None"; cmbDRack.Enabled = false;
                    varlocationcode = lblSLocation.Text;
                    lvProduct.Items.Clear();
                    if (txtProductNamePICode.Text.Length > 0)
                    {
                        DataSet objDs = new DataSet();
                        SPDataService objspdservice = new SPDataService();
                        MR_Product objMR_Product = new MR_Product();
                        objMR_Product.paraViewType = 35;
                        objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Product.paraId = varStockTransferID;
                        objMR_Product.paraLocationId = Convert.ToInt32(lblSLocation.Text);
                        objMR_Product.paraStockTransfer = dtStock;
                        if (VarSearchFlag == true)
                        {
                            objMR_Product.paraPicode = txtProductNamePICode.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        else
                        {
                            objMR_Product.paraProductName = txtProductNamePICode.Text;
                            objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                        }
                        objspdservice.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count != 0)
                            {
                                if (objDs.Tables[0].Rows.Count != 0)
                                {   /*
                                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                    {
                                        string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["Product"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["QTY"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["PR_UTID"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["STK_RKID"].ToString(), objDs.Tables[0].Rows[i]["UT_Decimal"].ToString() };
                                        ListViewItem objList = new ListViewItem(row);
                                        objList.UseItemStyleForSubItems = false;
                                        objList.SubItems[3].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                        lvProduct.Items.Add(objList);
                                    }
                                    lvProduct.Visible = true;
                                    lvProduct.BringToFront();
                                    lvProduct.Columns[0].Width = 110;
                                    lvProduct.Columns[1].Width = 0;

                                    lvProduct.Columns[2].Width = 0;
                                    lvProduct.Columns[3].Width = 0;
                                    lvProduct.Columns[4].Width = 80;
                                    lvProduct.Columns[5].Width = 70;
                                    lvProduct.Columns[6].Width = 90;
                                    lvProduct.Columns[7].Width = 60;
                                    lvProduct.Columns[8].Width = 80;
                                    lvProduct.Columns[9].Width = 0;
                                    lvProduct.Columns[10].Width = 0;
                                    lvProduct.Columns[11].Width = 80;
                                    lvProduct.Columns[12].Width = 0;
                                    //lvProduct.Columns[13].Width = 0;
                                    if (VarSearchFlag == false)
                                    {
                                        lvProduct.Columns[2].Width = 320;
                                        lvProduct.Columns[3].Width = 0;
                                    }
                                    else
                                    {
                                        lvProduct.Columns[2].Width = 0;
                                        lvProduct.Columns[3].Width = 320;
                                    }
                                    */

                                    DGV_FilterProduct.Visible = true;
                                    DGV_FilterProduct.DataSource = objDs.Tables[0];
                                    DGV_FilterProduct.Columns["PRID"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_UTID"].Visible = false;
                                    DGV_FilterProduct.Columns["STK_RKID"].Visible = false;
                                    DGV_FilterProduct.Columns["UT_Decimal"].Visible = false;
                                    DGV_FilterProduct.Columns["Product"].Visible = false;
                                    DGV_FilterProduct.Columns["PR_PICode"].Width = 120;
                                    DGV_FilterProduct.Columns["PR_EName"].Width = 320;
                                    DGV_FilterProduct.Columns["PR_TName"].Width = 320;
                                    DGV_FilterProduct.Columns["UT_Symbol"].Width = 50;
                                    DGV_FilterProduct.Columns["STK_MRP"].Width = 80;
                                    DGV_FilterProduct.Columns["STK_BatchNo"].Width = 80;
                                    DGV_FilterProduct.Columns["QTY"].Width = 70;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].Width = 90;
                                    DGV_FilterProduct.Columns["RK_ShortName"].Width = 70;
                                    DGV_FilterProduct.Columns["UPP"].Width = 70;
                                    DGV_FilterProduct.Columns["Retail Rate"].Width = 80;

                                    DGV_FilterProduct.Columns["PR_PICode"].DisplayIndex = 1;
                                    DGV_FilterProduct.Columns["RK_ShortName"].DisplayIndex = 3;
                                    DGV_FilterProduct.Columns["STK_MRP"].DisplayIndex = 4;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].DisplayIndex = 5;

                                    DGV_FilterProduct.Columns["Shelf Life"].DisplayIndex = 6;
                                    DGV_FilterProduct.Columns["MFD Date"].DisplayIndex = 7;
                                     
                                    DGV_FilterProduct.Columns["STK_BatchNo"].DisplayIndex = 8;
                                    DGV_FilterProduct.Columns["QTY"].DisplayIndex = 9;
                                    DGV_FilterProduct.Columns["UT_Symbol"].DisplayIndex = 10;
                                    DGV_FilterProduct.Columns["Retail Rate"].DisplayIndex = 11;
                                    DGV_FilterProduct.Columns["UPP"].DisplayIndex = 12;
                                     
                                    DGV_FilterProduct.Columns["PR_TName"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                    DGV_FilterProduct.Columns["PR_TName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_EName"].HeaderText = "Product Name";
                                    DGV_FilterProduct.Columns["PR_PICode"].HeaderText = "PI Code";
                                    DGV_FilterProduct.Columns["RK_ShortName"].HeaderText = "Rack";
                                    DGV_FilterProduct.Columns["STK_MRP"].HeaderText = "MRP";
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].HeaderText = "Expiry Date";
                                    DGV_FilterProduct.Columns["STK_BatchNo"].HeaderText = "Batch No.";
                                    DGV_FilterProduct.Columns["QTY"].HeaderText = "Quantity";
                                    DGV_FilterProduct.Columns["UT_Symbol"].HeaderText = "Unit";
                                    DGV_FilterProduct.Columns["UT_Symbol"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["STK_MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                    DGV_FilterProduct.Columns["STK_ExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["MFD Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    DGV_FilterProduct.Columns["Retail Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                                    if (VarSearchFlag == false)
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_EName"].DisplayIndex = 2;
                                    }
                                    else
                                    {
                                        DGV_FilterProduct.Columns["PR_EName"].Visible = false;
                                        DGV_FilterProduct.Columns["PR_TName"].Visible = true;
                                        DGV_FilterProduct.Columns["PR_TName"].DisplayIndex = 2;
                                    }
                                }
                                else
                                {
                                    DGV_FilterProduct.Visible = false;
                                    DGV_FilterProduct.DataSource = null;
                                    //lvProduct.Visible = false;
                                }
                            }
                            else
                            {
                                DGV_FilterProduct.Visible = false;
                                DGV_FilterProduct.DataSource = null;
                                //lvProduct.Visible = false;
                            }
                        }
                        else
                        {
                            DGV_FilterProduct.Visible = false;
                            DGV_FilterProduct.DataSource = null;
                            //lvProduct.Visible = false;
                        }
                    }
                    else
                    {
                        DGV_FilterProduct.Visible = false;
                        DGV_FilterProduct.DataSource = null;
                        //lvProduct.Visible = false;
                        //lvProduct.Items.Clear();
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
        private void TxtQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                lvProduct.Visible = false;
                txtQuantity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true;
                }

                TextBox textBox = (TextBox)sender;
                if (varDecimal == 0)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                    {
                        e.Handled = true;
                    }
                }
                if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = false;
                }
                if (varDecimal == 0)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
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
        private void TxtQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                if(txtQuantity.Text.Trim()=="")
                {
                    errStockTransfer.SetError(txtQuantity, "Please enter quantity");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransferQty.ShowAlways = true;
                    tpTransferQty.Show("Please enter quantity", txtQuantity, 5000);
                }
                else
                {
                    string Qty = objValidation.udfnDecimal((txtQuantity.Text).Trim(), varDecimal);
                    txtQuantity.Text = Qty;
                    errStockTransfer.Clear();
                    txtQuantity.BackColor = Color.White;
                }
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
                varDateChange = 0;
                udfnTransferNo();
                grdStockTransfer.Rows.Clear();
                dtStock.Rows.Clear();
                udfnProductClear();
                txttotalitem.Text = "";
                if (btnSave.Text == "Save")
                {
                    txtSLocation.Text = "";
                    txtDLocation.Text = "";
                    txttotalitem.Text = Convert.ToString(grdStockTransfer.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTransferNo()
        {
            if (varStockTransferID==0)
            {
                if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                {
                    string vardate = "", varResult = "";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    DataService objDservice = new DataService();
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'"+dpTrannsferDate.Text+"',103)");
                    varResult = objspdservice.udfngetVoucherNo("44", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                    objspdservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varResult != "")
                    {
                        txtTransferNo.Text = varvalue[0];
                    }
                    else
                    {
                        varVoucherSkip = false;
                        if (varDateChange == 0)
                        {
                            udfnvoucheradd();
                        }
                    }
                }
                else
                {
                    txtTransferNo.Text = "";
                }
            }
        }
        public void udfnvoucheradd()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(75);
                objDServ.CloseConnection();
                txtTransferNo.Text = "";
                if (varVoucherSkip == false)
                {
                    DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        varVoucherSkip = true;
                        varClose = 1;
                        udfnclose();
                        MainForm.objCP_Settings = new CP_Settings();
                        //MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                        //MainForm.objCP_Settings.varValues = Convert.ToString(44);
                        MainForm.objCP_Settings.MdiParent = this.ParentForm;
                        MainForm.objCP_Settings.Show();
                        varCloseFlag = 1;
                    }
                    else { varVoucherSkip = true; }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductName.ShowAlways = true;
                    tpProductName.Show("Please enter product name", txtProductNamePICode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtSRack.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtSRack, "Invalid source rack");
                    txtSRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpsRack.ShowAlways = true;
                    tpsRack.Show("Invalid source rack", txtSRack, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(cmbDRack.Text).Trim() == "-Select-")
                {
                    errStockTransfer.SetError(cmbDRack, "Please select destination rack");
                    cmbDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDRack.ShowAlways = true;
                    tpDRack.Show("Please select destination rack", cmbDRack, 5000);
                    blnErrorFlag = true;
                }
                //if (Convert.ToString(txtMRP.Text).Trim() == "")
                //{
                //    errStockTransfer.SetError(txtMRP, "Invalid mrp");
                //    txtMRP.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpMRP.ShowAlways = true;
                //    tpMRP.Show("Invalid mrp", txtMRP, 5000);
                //    blnErrorFlag = true;
                //}
                //if (Convert.ToString(txtExpiryDate.Text).Trim() == "")
                //{
                //    errStockTransfer.SetError(txtExpiryDate, "Invalid expiry date");
                //    txtExpiryDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpExpiryDate.ShowAlways = true;
                //    tpExpiryDate.Show("Invalid expiry date", txtExpiryDate, 5000);
                //    blnErrorFlag = true;
                //}
                //if (Convert.ToString(txtBatchNo.Text).Trim() == "")
                //{
                //    errStockTransfer.SetError(txtBatchNo, "Invalid batchno");
                //    txtBatchNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpBatchNo.ShowAlways = true;
                //    tpBatchNo.Show("Invalid batchno", txtBatchNo, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(txtStockQty.Text).Trim() == "" || Convert.ToDecimal((txtStockQty.Text).Trim())==0)
                {
                    errStockTransfer.SetError(txtStockQty, "Invalid stock qty");
                    txtStockQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockQty.ShowAlways = true;
                    tpStockQty.Show("Invalid stock qty", txtStockQty, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtDLocation.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtDLocation, "Please enter destination location");
                    txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDStockLocation.ShowAlways = true;
                    tpDStockLocation.Show("Please enter destination location", txtDLocation, 5000);
                    blnErrorFlag = true;
                }
                if(Convert.ToString(lblDLocation.Text)=="0" || Convert.ToString(lblDLocation.Text)=="")
                {
                    errStockTransfer.SetError(txtDLocation, "Please enter destination location");
                    txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDStockLocation.ShowAlways = true;
                    tpDStockLocation.Show("Please enter destination location", txtDLocation, 5000);
                    blnErrorFlag = true;
                }
                else 
                {
                    string varId_Location = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();

                    MR_Location objMR_Location = new MR_Location();
                    objMR_Location.paraViewType = 14;
                    objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Location.paraLocationName = txtDLocation.Text.Trim();
                    objDsPurLoc = objDServ3.udfnStockLocationList(objMR_Location);
                    objDServ3.CloseConnection();
                    //objDsPurLoc = objDServ3.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtDLocation.Text.Trim(), 0, 0, 0, "", "",0);
                    if (objDsPurLoc != null)
                    {
                        if (objDsPurLoc.Tables.Count > 0)
                        {
                            if (objDsPurLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_Location = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblDLocation.Text = Convert.ToString(varId_Location);
                    if (varId_Location == "0" || varId_Location == "-1")
                    {
                        errStockTransfer.SetError(txtDLocation, "Please select valid destination location");
                        txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpDStockLocation.ShowAlways = true;
                        tpDStockLocation.Show("Please select valid destination location", txtDLocation, 5000);
                        blnErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtQuantity.Text).Trim() != "")
                {
                    if (Convert.ToDecimal(txtStockQty.Text.Trim()) >= Convert.ToDecimal(txtQuantity.Text.Trim()))
                    {
                        errStockTransfer.Clear();
                        txtQuantity.BackColor = Color.White;
                    }
                    else
                    {
                        errStockTransfer.SetError(txtQuantity, "Please enter valid quantity");
                        txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpTransferQty.ShowAlways = true;
                        tpTransferQty.Show("Please enter valid quantity", txtQuantity, 5000);
                        blnErrorFlag = true;
                    }
                }
                else
                {
                    errStockTransfer.SetError(txtQuantity, "Please enter quantity");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransferQty.ShowAlways = true;
                    tpTransferQty.Show("Please enter quantity", txtQuantity, 5000);
                    blnErrorFlag = true;
                }
                
                if (blnErrorFlag == false)
                {
                    string DRKID = "";
                    if (cmbDRack.Text == "None")
                    {
                         DRKID = "0";
                    }
                    else
                    {
                        DRKID =Convert.ToString(cmbDRack.SelectedValue);
                    }
                    if (txtQuantity.Text != "")
                    {
                        string Qty = objValidation.udfnDecimal((txtQuantity.Text).Trim(), varDecimal);
                        txtQuantity.Text = Qty;
                    }
                    varLocation = txtSLocation.Text;
                    grdStockTransfer.Rows.Add(grdStockTransfer.Rows.Count + 1, varPICode, varProductName, (txtSRack.Text).Trim(), (txtMRP.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtDLocation.Text).Trim(), (cmbDRack.Text).Trim(), (txtStockQty.Text).Trim(), (txtQuantity.Text).Trim(), varUnitSymbol, (lblProduct.Text).Trim(), varSRKID,varUTID, (txtQuantity.Text).Trim(),0,varDecimal);
                    dtStock.Rows.Add((lblProduct.Text).Trim(), string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtMRP.Text.Trim()))), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), varUTID, (txtQuantity.Text).Trim(), varSRKID,(lblDLocation.Text).Trim(),DRKID,0,0);
                    txttotalitem.Text = Convert.ToString(grdStockTransfer.Rows.Count);
                    ((DataGridViewTextBoxColumn)grdStockTransfer.Columns["clmquantity"]).MaxInputLength = 8;
                    grdStockTransfer.Columns["clmdsno"].Width = 50;
                    grdStockTransfer.Columns["clmmrp"].Width = 100;
                    grdStockTransfer.Columns["clmquantity"].Width = 100;
                    grdStockTransfer.Columns["clmExpirydate"].Width = 90;
                    grdStockTransfer.Columns["clmbatchno"].Width = 70;
                    grdStockTransfer.Columns["clmDestLocation"].Width = 130;
                    grdStockTransfer.Columns["clmDestRack"].Width = 120;
                    grdStockTransfer.Columns["clmUnit"].Width = 40;
                    grdStockTransfer.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdStockTransfer.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdStockTransfer.Columns["clmbatchno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    grdStockTransfer.Columns["clmquantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdStockTransfer.Columns["clmExpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    varModifiedFlag = 1;
                    errStockTransfer.Clear();
                    grdStockTransfer.ClearSelection();
                    lblUnit.Text = "";
                    udfnProductClear();
                    txtProductNamePICode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (grdStockTransfer.Rows.Count > 0)
                {
                    txtSLocation.Enabled = false;
                    cmbConcern.Enabled = false;
                }
                else
                {
                    txtSLocation.Enabled = true;
                    cmbConcern.Enabled = true;
                }
            }
        }
        public void udfnProductClear()
        {
            txtProductNamePICode.Text = "";
            txtSRack.Text = "";
            txtMRP.Text = "";
            txtExpiryDate.Text = "";
            txtBatchNo.Text = "";
            txtStockQty.Text = "";
            txtDLocation.Text = "";
            cmbDRack.Text = "";
            txtQuantity.Text = "";
            udfnDefaultHeader();
        }
        public void udfnClear()
        {
            cmbConcern.SelectedValue = -1;
            txtTransferNo.Text = "";
            txtSLocation.Text = "";
            txtDLocation.Text = "";
        }
        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                lvProduct.Visible = false;
                DGV_FilterProduct.Visible = false;
                DGV_FilterProduct.DataSource = null;
                varUpDownKey = 0;
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //udfnProductEvent();
                //txtDLocation.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvProduct_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    udfnProductEvent();
                //    txtDLocation.Focus();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductEvent()
        {
            try
            {
                if (txtProductNamePICode.Text != "")
                {
                    /*
                    ListViewItem selectedItem = lvProduct.SelectedItems[0];
                    varPICode = selectedItem.SubItems[0].Text;
                    txtProductNamePICode.Text = selectedItem.SubItems[2].Text;
                    varProductName = selectedItem.SubItems[3].Text;
                    txtMRP.Text = selectedItem.SubItems[5].Text;
                    txtExpiryDate.Text = selectedItem.SubItems[6].Text;
                    txtBatchNo.Text = selectedItem.SubItems[7].Text;
                    txtStockQty.Text = selectedItem.SubItems[8].Text;
                    lblProduct.Text = selectedItem.SubItems[9].Text;
                    varUTID = selectedItem.SubItems[10].Text;
                    varUnitSymbol = selectedItem.SubItems[11].Text;
                    lblUnit.Text = selectedItem.SubItems[11].Text;
                    varMRP = selectedItem.SubItems[5].Text;
                    varExpiryDate = selectedItem.SubItems[6].Text;
                    varBatchNo = selectedItem.SubItems[7].Text;
                    varProductCode = selectedItem.SubItems[9].Text;
                    varSRKID = selectedItem.SubItems[12].Text;
                    varDecimal =Convert.ToInt32( selectedItem.SubItems[13].Text);
                    txtSRack.Text = selectedItem.SubItems[4].Text;
                    */
                    varPICode = DGV_FilterProduct.SelectedRows[0].Cells["PR_PICode"].Value.ToString();
                    varProductName = DGV_FilterProduct.SelectedRows[0].Cells["PR_TName"].Value.ToString();
                    txtMRP.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                    txtExpiryDate.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                    txtBatchNo.Text = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                    txtStockQty.Text = DGV_FilterProduct.SelectedRows[0].Cells["QTY"].Value.ToString();
                    lblProduct.Text = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varUTID = DGV_FilterProduct.SelectedRows[0].Cells["PR_UTID"].Value.ToString();
                    varUnitSymbol = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    lblUnit.Text = DGV_FilterProduct.SelectedRows[0].Cells["UT_Symbol"].Value.ToString();
                    varMRP = DGV_FilterProduct.SelectedRows[0].Cells["STK_MRP"].Value.ToString();
                    varExpiryDate = DGV_FilterProduct.SelectedRows[0].Cells["STK_ExpiryDate"].Value.ToString();
                    varBatchNo = DGV_FilterProduct.SelectedRows[0].Cells["STK_BatchNo"].Value.ToString();
                    varProductCode = DGV_FilterProduct.SelectedRows[0].Cells["PRID"].Value.ToString();
                    varSRKID = DGV_FilterProduct.SelectedRows[0].Cells["STK_RKID"].Value.ToString();
                    varDecimal = Convert.ToInt32(DGV_FilterProduct.SelectedRows[0].Cells["UT_Decimal"].Value.ToString());
                    txtSRack.Text = DGV_FilterProduct.SelectedRows[0].Cells["RK_ShortName"].Value.ToString();
                    txtProductNamePICode.Text = DGV_FilterProduct.SelectedRows[0].Cells["PR_EName"].Value.ToString();

                    udfnProductBasedStkLocation(Convert.ToInt32(varProductCode));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvProduct.Visible = false;
                errStockTransfer.Clear();
                txtSRack.BackColor = SystemColors.Control;
                txtMRP.BackColor = SystemColors.Control;
                txtExpiryDate.BackColor = SystemColors.Control;
                txtBatchNo.BackColor = SystemColors.Control;
                txtStockQty.BackColor =SystemColors.Control;
                txtDLocation.BackColor = Color.White;
                txtQuantity.BackColor = Color.White;
            }
        }
        private void GrdStockTransfer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0;
                string varMRP="",varExpiryDate="",varBatchNo="", varSRKID = "";
                if (e.RowIndex != -1)
                {
                    switch (grdStockTransfer.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            varProductID = Convert.ToInt32(grdStockTransfer.Rows[e.RowIndex].Cells["clmPRID"].Value);
                            varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdStockTransfer.Rows[e.RowIndex].Cells["clmmrp"].Value)));
                            varExpiryDate = Convert.ToString(grdStockTransfer.Rows[e.RowIndex].Cells["clmExpirydate"].Value);
                            varBatchNo = Convert.ToString(grdStockTransfer.Rows[e.RowIndex].Cells["clmbatchno"].Value);
                            varSRKID = Convert.ToString(grdStockTransfer.Rows[e.RowIndex].Cells["clmSRID"].Value);
                            grdStockTransfer.Rows.RemoveAt(this.grdStockTransfer.Rows[e.RowIndex].Index);
                            for (int i = 0; i < grdStockTransfer.RowCount; i++)
                            {
                                grdStockTransfer.Rows[i].Cells["clmdsno"].Value = i + 1;
                            }
                            varModifiedFlag = 1;
                            for (int i = 0; i < dtStock.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID) && Convert.ToString(dtStock.Rows[i]["STK_MRP"]) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToString(dtStock.Rows[i]["STK_Source_RKID"]) == varSRKID)
                                {
                                    dtStock.Rows[i].Delete();
                                    dtStock.AcceptChanges();
                                }
                            }
                        }
                        break;
                    }
                }
//////          List<DataRow> removeRows = from r in dtStock.AsEnumerable()
//////                                 where (r.Field<string>("STK_PRID").ToUpper().Equals(Convert.ToString(varProductID).Trim().ToUpper())) &&
//////(r.Field<string>("STK_MRP").ToUpper().Equals(Convert.ToString(varMRP).Trim().ToUpper())) &&
//////(r.Field<string>("STK_ExpiryDate").ToUpper().Equals(Convert.ToString(varExpiryDate).Trim().ToUpper())) &&
//////(r.Field<string>("STK_BatchNo").ToUpper().Equals(Convert.ToString(varBatchNo).Trim().ToUpper()))
//////                                 group r by r.Field<string>("STK_PRID")
//////                                into g
//////                                 select g.Key.ToList();


//                //  List<DataRow> removeRows =dtStock.Where(er => (er.STKPRID == varProductID) && (dtStock.STK_MRP == varMRP) && (dtStock.STK_ExpiryDate == varExpiryDate) && (dtStock.STK_Batchno == varBatchNo).ToString();
//                List<DataRow> removeRows = from r in dtStock.AsEnumerable() where (r.Field<string>("STK_PRID").Equals(Convert.ToString(varProductID))) into g select g.key.ToList();
//                removeRows.ForEach(dtStock.Rows.Remove);
//                dtStock.AcceptChanges();

                //List<DataRow> myRows = dtStock.AsEnumerable().Where(x => x.Field<int>("STK_PRID") == Convert.ToInt32(varProductID)).ToList();
                //foreach (DataRow row in myRows) {
                //    dtStock.Rows.Remove(row);
                //}
                //dtStock.AcceptChanges();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txttotalitem.Text = Convert.ToString(grdStockTransfer.Rows.Count);
                if (grdStockTransfer.Rows.Count > 0)
                {
                    txtSLocation.Enabled = false;
                    cmbConcern.Enabled = false;
                }
                else
                {
                    txtSLocation.Enabled = true;
                    cmbConcern.Enabled = true;
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errStockTransfer.Clear(); 
                bool blnErrorFlag = false;
                varErrQty = "0";
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errStockTransfer.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                //if (Convert.ToString(txtTransferNo.Text).Trim() == "")
                //{
                //    errStockTransfer.SetError(txtTransferNo, "Please enter transfer no.");
                //    txtTransferNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpTransferNo.ShowAlways = true;
                //    tpTransferNo.Show("Please enter transfer no.", txtTransferNo, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(txtSLocation.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtSLocation, "Please enter source location");
                    txtSLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSStockLocation.ShowAlways = true;
                    tpSStockLocation.Show("Please enter source location", txtSLocation, 5000);
                    blnErrorFlag = true;
                }
                //else
                //{
                //    udfnSLocationValid();
                //    if(lblSLocation.Text=="0" || lblSLocation.Text=="-1")
                //    {
                //        blnErrorFlag = true;
                //    }
                //}
                if(grdStockTransfer.Rows.Count<1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                for (int i = 0; i < grdStockTransfer.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(grdStockTransfer.Rows[i].Cells["clmStockQty"].Value)!=0 && (Convert.ToString(grdStockTransfer.Rows[i].Cells["clmquantity"].Value) == "" || Convert.ToDecimal(grdStockTransfer.Rows[i].Cells["clmquantity"].Value) == 0))
                    {
                        blnErrorFlag = true; varErrQty = "1";
                        grdStockTransfer.Rows[i].Cells["clmquantity"].Style.BackColor = Color.LightPink;
                    }
                    else
                    {
                        grdStockTransfer.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                        grdStockTransfer.Rows[i].Cells["clmquantity"].Style.BackColor = Color.PaleGreen;
                    }
                    if (EditFlag==1)
                    {

                        if (Convert.ToString(grdStockTransfer.Rows[i].Cells["Status"].Value) == "")
                        {
                            blnErrorFlag = true;
                            //grdStockTransfer.Rows[i].Cells["Status"].Style.BackColor = Color.LightPink;
                            varQtyError = "1";
                        }
                        if (Convert.ToDecimal(grdStockTransfer.Rows[i].Cells["clmquantity"].Value) != 0 && Convert.ToInt32(grdStockTransfer.Rows[i].Cells["Status"].Value) == 80)
                        {
                            blnErrorFlag = true; varQtyError = "1";
                            grdStockTransfer.Rows[i].Cells["clmquantity"].Style.BackColor = Color.LightPink;
                        }
                    }
                }
                if (varErrQty == "1" || varQtyError == "1")
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    errStockTransfer.Clear();
                    btnSave.Enabled = false;
                    udfnSave(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void udfnSave(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                if (btnSave.Text == "Save as Draft")
                {
                    varStockRequestID = 0;
                    varUpdateflag = 0;
                    varoriginator = "Stock Transfer Creation";
                    varType = 0;
                }
                else if (btnSave.Text == "Save" && chkStatus.Checked == true)
                {
                    varStockRequestID = 0;
                    varUpdateflag = 0;
                    varoriginator = "Stock Transfer Creation";
                    varType = 0;
                }
                //else if (btnSave.Text == "Save as Draft" && chkStatus.Checked == false)
                //{
                //    varStatusID = 21;
                //}
                else if (btnSave.Text == "Update" && varUpdateflag == 1)
                {
                    varUpdateflag = 1;
                    varType = 0;
                    varoriginator = "Stock Transfer Queue Updation";
                }
                /* Check source stock location is valid or not*/
                if (varUpdateflag == 0)
                {
                    if (txtSLocation.Text != "")
                    {
                        string varId_PurLocation = "0";
                        DataSet objDsSalesLoc = new DataSet();
                        SPDataService objDServ5 = new SPDataService();

                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 14;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtSLocation.Text.Trim();
                        objDsSalesLoc = objDServ5.udfnStockLocationList(objMR_Location);
                        objDServ5.CloseConnection();
                        //objDsSalesLoc = objDServ5.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtSLocation.Text.Trim(), 0, 0, 0, "", "",0);
                        if (objDsSalesLoc != null)
                        {
                            if (objDsSalesLoc.Tables.Count > 0)
                            {
                                if (objDsSalesLoc.Tables[0].Rows.Count > 0)
                                {
                                    varId_PurLocation = Convert.ToString(objDsSalesLoc.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        lblSLocation.Text = Convert.ToString(varId_PurLocation);
                        if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                        {
                            errStockTransfer.SetError(txtSLocation, "Please select valid source location");
                            txtSLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpSStockLocation.ShowAlways = true;
                            tpSStockLocation.Show("Please select valid source location", txtSLocation, 5000);
                        }
                    }
                    else
                    {
                        lblSLocation.Text = "0";
                    }

                    /* Check destination stock location is valid or not*/
                    if (txtDLocation.Text != "")
                    {
                        string varId_PurLocation = "0";
                        DataSet objDsSalesLoc = new DataSet();
                        SPDataService objDServ5 = new SPDataService();
                        MR_Location objMR_Location = new MR_Location();
                        objMR_Location.paraViewType = 14;
                        objMR_Location.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                        objMR_Location.paraLocationName = txtDLocation.Text.Trim();
                        objDsSalesLoc = objDServ5.udfnStockLocationList(objMR_Location);
                        objDServ5.CloseConnection();
                        //objDsSalesLoc = objDServ5.udfnStockLocationList(14, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtDLocation.Text.Trim(), 0, 0, 0, "", "",0);
                        if (objDsSalesLoc != null)
                        {
                            if (objDsSalesLoc.Tables.Count > 0)
                            {
                                if (objDsSalesLoc.Tables[0].Rows.Count > 0)
                                {
                                    varId_PurLocation = Convert.ToString(objDsSalesLoc.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        lblDLocation.Text = Convert.ToString(varId_PurLocation);
                        if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                        {
                            errStockTransfer.SetError(txtDLocation, "Please select valid destination location");
                            txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpDStockLocation.ShowAlways = true;
                            tpDStockLocation.Show("Please select valid destination location", txtDLocation, 5000);
                        }
                    }
                    else
                    {
                        lblDLocation.Text = "0";
                    }
                }
                int varStatus = 0;
                int varTransactionType = 0;
                if (varUpdateflag == 1)
                {
                    varStatus = 32;
                }
                if (chkStatus.Checked == false && varUpdateflag == 0)
                {
                    varStatus = 21;
                    dtStock.AsEnumerable().ToList().ForEach(r => r.SetField("STK_Status", varStatus));
                }
                 if (chkStatus.Checked == true && varUpdateflag == 0)
                {
                    varStatus = 32;
                    dtStock.AsEnumerable().ToList().ForEach(r => r.SetField("STK_Status", varStatus));
                }

                if (txtTransactionType.Text=="Regular")
                {
                    varTransactionType = 172;
                }
                else
                {
                    varTransactionType = 173;
                }

                if (varUpdateflag == 1)
                {
                    varResult = objspservice.udfnStockTransfer(varType, varStockTransferID, Convert.ToInt32(cmbConcern.SelectedValue), dpTrannsferDate.Text, Convert.ToInt32(varStockRequestSLID), 0, txtRemarks.Text.Trim(), varStatus, varoriginator, dtStock, 0, varTransactionType, varUpdateflag, varStockRequestID);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm.objINV_StockTransferQueue.udfnDate();
                        MainForm.objINV_StockTransferQueue.udfnList();
                        varModifiedFlag = 0;
                        try
                        {
                            if (varUpdateflag == 1)
                            {
                                string STID = "0";
                                if (varStockTransferID == 0)
                                {
                                    STID = varvalue[2];
                                }
                                else
                                {
                                    STID = Convert.ToString(varStockTransferID);
                                }
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
                                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_INV_Shop_Stock_Issued.rpt");
                                    varHeader = "Shop Stock Issued";

                                    objBillreport.SetParameterValue("paraStockTransferID", Convert.ToInt32(STID));
                                    objBillreport.SetParameterValue("paraStockTransferID", Convert.ToInt32(STID), objBillreport.Subreports[0].Name);
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName, objBillreport.Subreports[0].Name);
                                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName, objBillreport.Subreports[0].Name);
                                    objValidation.CrySqlConnection(objBillreport);

                                    MainForm.objReportLoad = new ReportLoad();
                                    MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                    MainForm.objReportLoad.Text = varHeader;
                                    MainForm.objReportLoad.ShowDialog();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            objError = new DataError();
                            objError.WriteFile(ex);
                        }
                        udfnClear();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    varResult = objspservice.udfnStockTransfer(varType, varStockTransferID, Convert.ToInt32(cmbConcern.SelectedValue), dpTrannsferDate.Text, Convert.ToInt32(lblSLocation.Text), 0, txtRemarks.Text.Trim(), varStatus, varoriginator, dtStock, 0, varTransactionType, varUpdateflag, varStockRequestID);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm.objINV_StockTransferList.udfnList();
                        udfnClear();
                        varModifiedFlag = 0;
                        this.Close();
                    }

                    else
                    {
                        errStockTransfer.Clear();
                        txtProductNamePICode.BackColor = Color.White;
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = true;
                        btnSave.Focus();
                        if (varvalue[0] == "5")
                        {
                            string[] varFirstList = varvalue[2].Split('|');
                            for (int i = 0; i < varFirstList.Length; i++)
                            {
                                string[] varSecondList = varFirstList[i].Split(',');
                                string varPRID = varSecondList[0];
                                string varMRP = varSecondList[1];
                                string varExpiryDate = varSecondList[2];
                                string varBatchNo = varSecondList[3];
                                string varRack = varSecondList[4];
                                for (int j = 0; j < grdStockTransfer.RowCount; j++)
                                {
                                    if (Convert.ToString(grdStockTransfer.Rows[j].Cells["clmPRID"].Value) == varPRID && Convert.ToString(grdStockTransfer.Rows[j].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdStockTransfer.Rows[j].Cells["clmExpirydate"].Value) == varExpiryDate && Convert.ToString(grdStockTransfer.Rows[j].Cells["clmbatchno"].Value) == varBatchNo && Convert.ToString(grdStockTransfer.Rows[j].Cells["clmSRID"].Value) == varRack)
                                    {
                                        grdStockTransfer.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //objError = new DataError();
                //objError.WriteFile(ex);
                //SPDataService objDServ = new SPDataService();
                //string varMessage = objDServ.udfnGetMessages(48);
                //objDServ.CloseConnection();
                //MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);              
                objError = new DataError();
                objError.WriteFile(ex);
            
        }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        private void BtnSave_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                btnSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSave_Leave(object sender, EventArgs e)
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
        private void BtnClose_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                btnClose.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnClose_Leave(object sender, EventArgs e)
        {
            try
            {
                btnClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpTrannsferDate_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                dpTrannsferDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTrannsferDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTrannsferDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpTrannsferDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTrannsferDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                varDateChange = 1;
                udfnTransferNo();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfncmbDRack()
        {
            try
            {
                int varRKID = 0;
                if(lblSLocation.Text!=lblDLocation.Text)
                {
                    varRKID = 0;
                }
                else
                {
                    varRKID =Convert.ToInt32(varSRKID);
                }
                //udfnDLocationValid();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnRackList(16,0,0,Convert.ToInt32(lblDLocation.Text),varRKID,"",0,0);
                objdserv.CloseConnection();
                cmbDRack.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 1)
                        {
                            cmbDRack.Enabled = true;
                            cmbDRack.ValueMember = "RKID";
                            cmbDRack.DisplayMember = "RK_ShortName";
                            cmbDRack.DataSource = objDT.Tables[0];
                        }
                        else
                        {
                            cmbDRack.Text = "None";
                            cmbDRack.Enabled = false;
                            txtQuantity.Focus();
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
        private void CmbDRack_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                cmbDRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDRack_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbDRack_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDRack.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRemarks_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                txtRemarks.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //btnRemarks.Focus();
                    chkStatus.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRemarks_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRemarks.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdStockTransfer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varQtyError = "0";
                if (grdStockTransfer.CurrentCell.OwningColumn.Name == "clmquantity")
                {
                    decimal TransferQty = Convert.ToDecimal(grdStockTransfer.CurrentRow.Cells["clmquantity"].Value);
                    decimal StockQty = Convert.ToDecimal(grdStockTransfer.CurrentRow.Cells["clmStockQty"].Value);

                    if (Convert.ToDecimal(TransferQty) > Convert.ToDecimal(StockQty))
                    {
                        //grdStockTransfer.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                        grdStockTransfer.Rows[e.RowIndex].Cells["clmquantity"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        //grdStockTransfer.CurrentRow.Cells["clmquantity"].Style.BackColor= System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        varQtyError = "1";
                    }
                    else if (StockQty!=0 && (Convert.ToString(TransferQty) == "0" || Convert.ToString(TransferQty) == ""))
                    {
                        grdStockTransfer.Rows[e.RowIndex].Cells["clmquantity"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(89);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varQtyError = "1";
                    }
                    else
                    {
                        grdStockTransfer.CurrentRow.Cells["clmquantity"].Style.BackColor = Color.PaleGreen;
                        varQtyError = "0";
                    }
                    int varDecimal = Convert.ToInt32(grdStockTransfer.CurrentRow.Cells["clmUnitDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdStockTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                    grdStockTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                    object varEditQty = grdStockTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // Update the same column value in the DataTable
                    dtStock.Rows[e.RowIndex]["STK_QTY"] = varEditQty;
                }
                else if (grdStockTransfer.CurrentCell.OwningColumn.Name == "Status")
                {
                    object varReqStatus = grdStockTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    dtStock.Rows[e.RowIndex]["STK_Status"] = varReqStatus;
                }
                decimal Quantity = Convert.ToDecimal(grdStockTransfer.CurrentRow.Cells["clmquantity"].Value);
                decimal Stock = Convert.ToDecimal(grdStockTransfer.CurrentRow.Cells["clmStockQty"].Value);
                int Status = Convert.ToInt32(grdStockTransfer.CurrentRow.Cells["Status"].Value);
                if (Stock != 0 && (Convert.ToDecimal(Quantity) == 0 && Convert.ToInt32(Status)==21) || (Convert.ToDecimal(Quantity) != 0 && Status==80))
                {
                    grdStockTransfer.Rows[e.RowIndex].Cells["clmquantity"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //SPDataService objDServ = new SPDataService();
                    //string varMessage = objDServ.udfnGetMessages(89);
                    //objDServ.CloseConnection();
                    //MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varQtyError = "1";
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                DGV_FilterSLocation.Visible = false;
                DGV_FilterSLocation.DataSource = null;
                DGV_FilterDLocation.Visible = false;
                DGV_FilterDLocation.DataSource = null;
                chkStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                chkStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void ChkStatus_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkStatus.Checked == true)
                {
                    btnSave.Text = "Save";
                }
                else
                {
                    btnSave.Text = "Save as Draft";
                }
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
                                if (VarSearchFlag == true)
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }
                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterProduct.Rows.Count) DGV_FilterProduct.CurrentCell = DGV_FilterProduct.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterProduct.Rows.Count))
                            {
                                if (VarSearchFlag == true)
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_PICode"].Value.ToString();
                                }
                                else
                                {
                                    txtProductNamePICode.Text = DGV_FilterProduct.Rows[RowIndex].Cells["PR_EName"].Value.ToString();
                                }
                            }

                            txtProductNamePICode.Focus();
                            txtProductNamePICode.SelectionStart = txtProductNamePICode.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterProduct.Rows.Count > 0)
                                {
                                    varUpDownKey = 1;
                                    udfnProductEvent();
                                    txtDLocation.Focus();
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
                        txtDLocation.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeySLocation = 1;
                udfnSLocationEvent();
                txtProductNamePICode.Focus();
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
                    int RowIndex = DGV_FilterSLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterSLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeySLocation = 1;
                    }
                    else
                    {
                        varUpDownKeySLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtSLocation.Text = DGV_FilterSLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtSLocation.Focus();
                            txtSLocation.SelectionStart = txtSLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterSLocation.Rows.Count) DGV_FilterSLocation.CurrentCell = DGV_FilterSLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterSLocation.Rows.Count))
                            {
                                txtSLocation.Text = DGV_FilterSLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtSLocation.Focus();
                            txtSLocation.SelectionStart = txtSLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterSLocation.Rows.Count > 0)
                                {
                                    varUpDownKeySLocation = 1;
                                    udfnSLocationEvent();
                                    DGV_FilterSLocation.Visible = false;
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
                        txtProductNamePICode.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterDLocation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                varUpDownKeyDLocation = 1;
                udfnDLocationEvent();
                if (cmbDRack.Enabled == true)
                {
                    cmbDRack.Focus();
                }
                else
                {
                    txtQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_FilterDLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
                {
                    int RowIndex = DGV_FilterDLocation.CurrentCell.RowIndex;
                    int ClmIndex = DGV_FilterDLocation.CurrentCell.ColumnIndex;
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                    {
                        varUpDownKeyDLocation = 1;
                    }
                    else
                    {
                        varUpDownKeyDLocation = 0;
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            RowIndex--;
                            if (RowIndex >= 0) DGV_FilterDLocation.CurrentCell = DGV_FilterDLocation.Rows[RowIndex].Cells[ClmIndex];

                            txtDLocation.Text = DGV_FilterDLocation.SelectedRows[0].Cells["SL_EName"].Value.ToString();

                            txtDLocation.Focus();
                            txtDLocation.SelectionStart = txtDLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Down:
                            RowIndex++;
                            if (RowIndex < DGV_FilterDLocation.Rows.Count) DGV_FilterDLocation.CurrentCell = DGV_FilterDLocation.Rows[RowIndex].Cells[ClmIndex];

                            if (RowIndex != (DGV_FilterDLocation.Rows.Count))
                            {
                                txtDLocation.Text = DGV_FilterDLocation.Rows[RowIndex].Cells["SL_EName"].Value.ToString();
                            }

                            txtDLocation.Focus();
                            txtDLocation.SelectionStart = txtDLocation.Text.Length;
                            e.Handled = true;
                            break;
                        case Keys.Enter:
                            {
                                if (DGV_FilterDLocation.Rows.Count > 0)
                                {
                                    varUpDownKeyDLocation = 1;
                                    udfnDLocationEvent();
                                    DGV_FilterDLocation.Visible = false;
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
                        if (cmbDRack.Enabled == true)
                        {
                            cmbDRack.Focus();
                        }
                        else
                        {
                            txtQuantity.Focus();
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

        private void btnProductInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductNamePICode.Text.Trim() != "" && lblProduct.Text != "" && lblProduct.Text != "0")
                {
                    MainForm.objCP_Product_Info = new CP_Product_Info();
                    MainForm.objCP_Product_Info.varProductId = Convert.ToInt32(lblProduct.Text);
                    MainForm.objCP_Product_Info.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        public void udfnProductBasedStkLocation(int varProductID)
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                TRN_GoodsOutward objTRNG_GoodsOutward = new TRN_GoodsOutward();
                objTRNG_GoodsOutward.ViewType = 3;
                objTRNG_GoodsOutward.paraPRID = Convert.ToInt32(varProductID);
                objDs = objdserv.udfnGOList(objTRNG_GoodsOutward);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        grdParentStock.RowTemplate.Height = 20;
                        grdParentStock.ColumnHeadersHeight = 25;
                        grdParentStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                        grdParentStock.DataSource = objDs.Tables[0];
                        grdParentStock.Columns["Location"].Width = 100;
                        grdParentStock.Columns["Quantity"].Width = 90;
                        grdParentStock.Columns["S.No."].Width = 50;
                        grdParentStock.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdParentStock.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        grdChildStock.DataSource = objDs.Tables[1];
                        grdChildStock.Columns["Location"].Width = 90;
                        grdChildStock.Columns["Quantity"].Width = 90;
                        grdChildStock.Columns["S.No."].Width = 50;
                        grdChildStock.Columns["Product"].Width = 200;
                        grdChildStock.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        grdChildStock.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        udfnDefaultHeader();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDefaultHeader()
        {
            try
            {
                grdParentStock.RowTemplate.Height = 20;
                grdParentStock.ColumnHeadersHeight = 25;
                grdParentStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                grdParentStock.DataSource = null;
                grdChildStock.DataSource = null;
                DataTable dt = new DataTable();
                dt.Columns.Add("S.No.");
                dt.Columns.Add("Location");
                dt.Columns.Add("Quantity");
                DataTable dtch = new DataTable();
                dtch.Columns.Add("S.No.");
                dtch.Columns.Add("Product");
                dtch.Columns.Add("Location");
                dtch.Columns.Add("Quantity");
                grdParentStock.DataSource = dt;
                grdChildStock.DataSource = dtch;
                grdParentStock.Columns["S.No."].Width = 50;
                grdParentStock.Columns["Location"].Width = 100;
                grdParentStock.Columns["Quantity"].Width = 70;
                grdParentStock.Columns["S.No."].Width = 50;
                grdParentStock.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdParentStock.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdChildStock.Columns["Location"].Width = 100;
                grdChildStock.Columns["Quantity"].Width = 70;
                grdChildStock.Columns["S.No."].Width = 50;
                grdChildStock.Columns["Product"].Width = 200;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void grdStockTransfer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdStockTransfer.SelectedRows.Count > 0)
                {
                    int varProductId = Convert.ToInt32(grdStockTransfer.CurrentRow.Cells["clmPRID"].Value);
                    udfnProductBasedStkLocation(varProductId);
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
                udfnProductEvent();
                txtDLocation.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockTransfer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockTransfer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //string val = grdStockTransfer.Columns[e.ColumnIndex].Name;
                //if (grdStockTransfer.Columns[e.ColumnIndex].Name=="Status")
                //{
                //    // Handle the value change here
                //    var selectedValue = grdStockTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //    // Do something with the selected value
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        
        }

        private void ChkStatus_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
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
        private void GrdStockTransfer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdStockTransfer.Rows.Count; i++)
                {
                    if (varStatusID == 32)
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmquantity"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmquantity"];
                        cell.Style.BackColor = Color.PaleGreen;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = false;
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
        private void GrdStockTransfer_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdStockTransfer.CurrentCell.OwningColumn.Name == "clmquantity")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdStockTransfer.CurrentCell.OwningColumn.Name == "clmquantity")
                {
                    e.Control.KeyPress += new KeyPressEventHandler(allowonlynumber);
                    return;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int varDecimal = Convert.ToInt32(grdStockTransfer.CurrentRow.Cells["clmUnitDecimal"].Value);
                if (grdStockTransfer.CurrentCell.OwningColumn.Name == "clmquantity")
                {
                    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    //{
                    //    e.Handled = true;  // Disallow the character
                    //}
                    TextBox textBox = (TextBox)sender;
                    textBox.SelectionStart = 0;
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal + 1)
                        {
                            e.Handled = true;
                        }
                    }
                    if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
                    {
                        e.Handled = false;
                    }
                    if (varDecimal == 0)
                    {
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
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
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdStockTransfer.CurrentCell.OwningColumn.Name == "clmquantity")
                {
                    if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '.'))
                    {
                        e.Handled = true;
                    }
                    //only allow one decimal point
                    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                    {
                        e.Handled = true;
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
