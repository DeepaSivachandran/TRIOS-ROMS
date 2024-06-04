using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class PUR_GRNApproval : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varSupplierID = 0,varScheduleID=0,varConcernID=0,varID=0, varGRNAID = 0, varGRNAPRID = 0;
        decimal varInvoiceQty=0, VarReceivedQty=0, varPOID=0;
        public string result = "", varUserID = "0",varReason="";
        DataTable dtApproval = new DataTable();
        DataTable dtPurchaseReturnDC = new DataTable();
        public PUR_GRNApproval()
        {
            InitializeComponent();
        }

        
        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                    MainForm.objPUR_GRNApprovalList.udfnList();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnsupplierLoad()
        {
            try
            {
                //pbSupplierpend = 0;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();

                if (varSupplierID>0)
                {
                    int varReturnApplicable = 0, varReturnType = 0;
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(varSupplierID);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(varScheduleID);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(varConcernID);
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
                            lblSupplierOrderpolicy.Text = "Return Policy - " + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                            varReturnApplicable = Convert.ToInt16(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                            varReturnType = Convert.ToInt16(objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString());
                            lblReturn.Text = objDs.Tables[0].Rows[0]["RETURNAPPLICABLE"].ToString();
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            if (objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString() != "")
                            { lblSalesmanName.Text = "Salesman Name - " + objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString(); }
                            if (objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString() != "")
                            { lblMobileNo.Text = "Mobile No. - " + objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString(); }
                            if (objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString() != "")
                            { lblWhatsAppNo.Text = "WhatsApp No. - " + objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString(); }
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
                lblReturn.Text = "";
                //lblReturnType.Text = "";
                lblSalesmanName.Text = "";
                lblMobileNo.Text = "";
                lblWhatsAppNo.Text = "";
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
        private void TxtRemark_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRemark.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemark_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRemark.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSave_Enter(object sender, EventArgs e)
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
        private void BtnRemarks_Enter(object sender, EventArgs e)
        {
            try
            {
                btnRemarks.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnRemarks_Leave(object sender, EventArgs e)
        {
            try
            {
                btnRemarks.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnRemarks.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnRemarks_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void PUR_GRNApproval_KeyDown(object sender, KeyEventArgs e)
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
                    BtnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnApproval_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                try
                {
                    if (grdGrnApproval.CurrentCell.OwningColumn.Name == "clmreturnqty")
                    {
                        e.Control.KeyPress -= udfnHandleKeyPress;
                        e.Control.KeyPress += udfnHandleKeyPress;
                    }
                    if (grdGrnApproval.CurrentCell.OwningColumn.Name == "clmreturnqty")
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
                if (grdGrnApproval.CurrentCell.OwningColumn.Name == "clmreturnqty")
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

        private void GrdGrnApproval_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdGrnApproval.CurrentCell.OwningColumn.Name == "clmReason")
                {
                    object Reason = grdGrnApproval.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    //Update the same column value in the DataTable
                    dtApproval.Rows[e.RowIndex]["GRNAPR_Reason"] = Convert.ToInt32(Reason);
                }
                if(grdGrnApproval.CurrentCell.OwningColumn.Name == "clmreturnqty")
                {
                    int varDecimal = Convert.ToInt32(grdGrnApproval.CurrentRow.Cells["clmUnitDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdGrnApproval.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                    grdGrnApproval.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;
                    object Quantity = grdGrnApproval.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    //Update the same column value in the DataTable
                    dtApproval.Rows[e.RowIndex]["GRNAPR_ReturnedQty"] = Quantity;
                }
                if (grdGrnApproval.CurrentCell.OwningColumn.Name == "clmreturnqty")
                {
                    if (Convert.ToDecimal(grdGrnApproval.Rows[e.RowIndex].Cells["clmreceivedqty"].Value) < Convert.ToDecimal(grdGrnApproval.Rows[e.RowIndex].Cells["clmreturnqty"].Value))
                    {
                        grdGrnApproval.Rows[e.RowIndex].Cells["clmreturnqty"].Style.BackColor = Color.LightPink;
                    }
                    else
                    {
                        grdGrnApproval.Rows[e.RowIndex].Cells["clmreturnqty"].Style.BackColor = Color.PaleGreen;
                    }
                }
                if (grdGrnApproval.CurrentCell.OwningColumn.Name == "clmReason")
                {
                    if (Convert.ToString(grdGrnApproval.CurrentRow.Cells["clmReason"].Value) == "231")
                    {
                        string varReceivedQty = "";
                        varReceivedQty = Convert.ToString(grdGrnApproval.CurrentRow.Cells["clmreceivedqty"].Value);
                        grdGrnApproval.CurrentRow.Cells["clmreturnqty"].Value = VarReceivedQty;
                        object Quantity = varReceivedQty;
                        dtApproval.Rows[e.RowIndex]["GRNAPR_ReturnedQty"] = Quantity;
                        dtPurchaseReturnDC.Rows[e.RowIndex]["PURREDCPR_Qty"] = Quantity;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnApproval_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdGrnApproval.IsCurrentCellDirty)
                {
                    grdGrnApproval.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnApproval_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdGrnApproval.CurrentCell.OwningColumn.Name == "clmReason")
                {
                    if (Convert.ToString(grdGrnApproval.CurrentRow.Cells["clmReason"].Value) == "232")
                    {
                        MainForm.objCP_Verify = new CP_Verify();
                        MainForm.objCP_Verify.ShowDialog();
                        varUserID = MainForm.objCP_Verify.varUserId;
                        if (MainForm.objCP_Verify.flag == 1)
                        {
                            dtApproval.Rows[e.RowIndex]["GRNAPR_RiskAcceptedby"] = Convert.ToInt32(varUserID);
                            grdGrnApproval.CurrentCell = grdGrnApproval.Rows[e.RowIndex].Cells[e.ColumnIndex-1];
                        }
                        else
                        {
                            dtApproval.Rows[e.RowIndex]["GRNAPR_RiskAcceptedby"] = 0;
                            grdGrnApproval.CurrentRow.Cells["clmReason"].Value = 234;
                        }
                    }
                    else
                    {
                        dtApproval.Rows[e.RowIndex]["GRNAPR_RiskAcceptedby"] = 0;
                    }
                    //object Reason = grdGrnApproval.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    //dtApproval.Rows[e.RowIndex]["GRNAPR_Reason"] = Convert.ToInt32(Reason);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_GRNApproval_Load(object sender, EventArgs e)
        {
            try
            {
                udfnLastSeen();
                dtApproval.TableName = "TRN_GRNApproval_Product";
                dtApproval.Columns.Add("GRNAPR_PRID", typeof(int));
                dtApproval.Columns.Add("GRNAPR_MRP", typeof(decimal));
                dtApproval.Columns.Add("GRNAPR_ExpiryDate", typeof(string));
                dtApproval.Columns.Add("GRNAPR_ActualShelfLife", typeof(int));
                dtApproval.Columns.Add("GRNAPR_ShelfLifePer", typeof(decimal));
                dtApproval.Columns.Add("GRNAPR_BatchNo", typeof(string));
                dtApproval.Columns.Add("GRNAPR_Reason", typeof(int));
                dtApproval.Columns.Add("GRNAPR_ReturnedQty", typeof(decimal));
                dtApproval.Columns.Add("GRNAPR_RiskAcceptedBy", typeof(int));
                dtApproval.Columns.Add("GRNAPR_PURPRID", typeof(int));

                dtPurchaseReturnDC.TableName = "TRN_Purchase_ReturnDC";
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_PRID", typeof(int));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_MRP", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_ExpDate", typeof(string));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_BatchNo", typeof(string));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_AppRate", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_Qty", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_UTID", typeof(int));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_TaxableAmnt", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_GSTPer", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_GSTAmnt", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_NettAmnt", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("DMID", typeof(string));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_SLID", typeof(decimal));
                dtPurchaseReturnDC.Columns.Add("PURREDCPR_RKID", typeof(decimal));
                ClearSupplier();
                udfnsupplierLoad();
                udfnEdit();
                //udfnStatus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnStatus()
        {
            try
            {
                try
                {
                    SPDataService objdserv = new SPDataService();
                    DataSet objDT = new DataSet();
                    //**** To call the function from SP ***************
                    MR_Status objMR_Status = new MR_Status();
                    objMR_Status.ViewType = 2;
                    objDT = objdserv.udfnGetStatus(objMR_Status);
                    objdserv.CloseConnection();
                    if (objDT != null)
                    {
                        if (objDT.Tables.Count > 0)
                        {
                            if (objDT.Tables[0].Rows.Count > 0)
                            {
                                var varComboBoxColoumn = (DataGridViewComboBoxColumn)grdGrnApproval.Columns["clmStatus"];
                                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                                varComboBoxColoumn.ValueMember = "ID";
                                varComboBoxColoumn.DisplayMember = "Status";
                               varComboBoxColoumn.DataSource = objDT.Tables[0];
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnReason()
        {
            try
            {
                //**** To call the function from SP ***************
                MR_Master objMR_Master = new MR_Master();
                objMR_Master.ViewType = 22;
                DataSet objDSer = new DataSet();
                SPDataService objdServ = new SPDataService();
                objDSer = objdServ.udfnMaster(objMR_Master);
                objdServ.CloseConnection();
                if (objDSer != null)
                {
                    if (objDSer.Tables.Count > 0)
                    {
                        if (objDSer.Tables[0].Rows.Count > 0)
                        {
                            var varComboBoxColoumn = (DataGridViewComboBoxColumn)grdGrnApproval.Columns["clmReason"];
                            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                            varComboBoxColoumn.ValueMember = "ID";
                            varComboBoxColoumn.DisplayMember = "Reason";
                            varComboBoxColoumn.DataSource = objDSer.Tables[0];
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
        public void udfnLastSeen()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataTable objGrnPO = new DataTable();
                TRN_GRNApproval objTRN_GRNApproval = new TRN_GRNApproval();
                objspdservice = new SPDataService();
                objTRN_GRNApproval.ViewType = 1;
                objTRN_GRNApproval.paraPURID = varID;
                objTRN_GRNApproval.paraUserID = Convert.ToInt16(MainForm.pbUserID);
                objTRN_GRNApproval.paraOriginator = "GRN Approval-Last Seen";
                result = objspdservice.udfnSetGRNApproval(objTRN_GRNApproval);
                objspdservice.CloseConnection();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 udfnSave();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        public void udfnSave()
        {
            try
            {
                int varQtyErr = 0;
                bool varErrorFlag = true;
                for (int i=0;i<grdGrnApproval.Rows.Count;i++)
                {
                    if (Convert.ToDecimal(grdGrnApproval.Rows[i].Cells["clmreceivedqty"].Value)<Convert.ToDecimal(grdGrnApproval.Rows[i].Cells["clmreturnqty"].Value))
                    {
                        varQtyErr++;
                        //grdGrnApproval.Rows[i].Cells["clmreceivedqty"].Style.BackColor = Color.LightPink;
                        grdGrnApproval.Rows[i].Cells["clmreturnqty"].Style.BackColor = Color.LightPink;
                        varErrorFlag = false;
                    }
                    if(Convert.ToDecimal(grdGrnApproval.Rows[i].Cells["clmreturnqty"].Value)!=0 && Convert.ToString(grdGrnApproval.Rows[i].Cells["clmReason"].Value)=="")
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(131);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        varErrorFlag = false;
                    }
                }
                if (varQtyErr != 0)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(113);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrorFlag = false;
                }
                DateTime varDate = DateTime.Today;
                String vardate = Convert.ToString(varDate);
                string varoriginator = "GRN Approval Creation";
                if (varQtyErr == 0 && varErrorFlag == true)
                {
                    int varViewType = 0;
                    if(varGRNAID !=0)
                    {
                        varViewType = 2;
                    }
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();
                    TRN_GRNApproval objTRN_GRNApproval = new TRN_GRNApproval();
                    //objTRN_GRNApproval.ViewType = 0;
                    //objTRN_GRNApproval.paraPURID = varID;
                    //objTRN_GRNApproval.paraRemarks = txtRemark.Text;
                    //objTRN_GRNApproval.paraFlag = 0;
                    //objTRN_GRNApproval.paraOriginator = varoriginator;
                    //objTRN_GRNApproval.paraCompanyId = varConcernID;
                    //objTRN_GRNApproval.paraSupplierID = varSupplierID;
                    //objTRN_GRNApproval.paraScheduleID = varScheduleID;
                    //objTRN_GRNApproval.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    //objTRN_GRNApproval.paraReturnDC_Date = vardate;
                    //objTRN_GRNApproval.paraApprovalProduct = dtApproval;
                    //objTRN_GRNApproval.paraTRN_Purchase_ReturnDC = dtPurchaseReturnDC;
                    //result = objspdservice.udfnSetGRNApproval(objTRN_GRNApproval);
                    //objspdservice.CloseConnection();
                    //string[] varvalue = result.Split('~');
                    //if (result.Split('~')[0] == "3")
                    //{
                    //l: if (result.Split('~')[1] == "1")
                    //{
                    varUserID = Convert.ToString(MainForm.pbUserID);
                l: MainForm.objCP_Verify = new CP_Verify();
                    MainForm.objCP_Verify.ShowDialog();
                    varUserID = MainForm.objCP_Verify.varUserId;
                    if (MainForm.objCP_Verify.flag == 1)
                    {
                        objspdservice = new SPDataService();
                        objTRN_GRNApproval.ViewType = varViewType;
                        objTRN_GRNApproval.paraPURID = varID;
                        objTRN_GRNApproval.paraRemarks = txtRemark.Text;
                        objTRN_GRNApproval.paraFlag = 1;
                        objTRN_GRNApproval.paraCompanyId = varConcernID;
                        objTRN_GRNApproval.paraSupplierID = varSupplierID;
                        objTRN_GRNApproval.paraScheduleID = varScheduleID;
                        objTRN_GRNApproval.paraUserID = Convert.ToInt32(varUserID);
                        objTRN_GRNApproval.paraOriginator = varoriginator;
                        objTRN_GRNApproval.paraReturnDC_Date = vardate;
                        objTRN_GRNApproval.paraApprovalProduct = dtApproval;
                        objTRN_GRNApproval.paraTRN_Purchase_ReturnDC = dtPurchaseReturnDC;
                        objTRN_GRNApproval.ParaGRNAID = varGRNAID;
                        result = objspdservice.udfnSetGRNApproval(objTRN_GRNApproval);
                        objspdservice.CloseConnection();
                        string[] varvalue1 = result.Split('~');
                        if (varvalue1[0] == "3")
                        {
                            MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm.objPUR_GRNApprovalList.udfnDate();
                            MainForm.objPUR_GRNApprovalList.udfnList();
                            //udfnClear();
                            this.Close();
                        }
                        else
                        {
                            //epGoodsInward.Clear();
                            //txtProductName.BackColor = Color.White;
                            MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            btnSave.Enabled = true;
                            btnSave.Focus();
                            if (varvalue1[0] == "5")
                            {
                                goto l;
                            }
                        }
                    }
                    //}
                    //else if (result.Split('~')[0] == "4")
                    //{
                    //    MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                    //else if (result.Split('~')[0] == "5")
                    //{
                    //    MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //}
                    //}
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
                string varShelflifePer = "";
                if (varID!= 0)
                {
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    TRN_PurchaseEntry objTRNG_PurchaseEntry = new TRN_PurchaseEntry();
                    objTRNG_PurchaseEntry.ViewType = 8;
                    objTRNG_PurchaseEntry.paraPurchaseId = varID;
                    objDs = objdserv.udfnGetPurchaseEntry(objTRNG_PurchaseEntry);
                    objdserv.CloseConnection();
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            if(Convert.ToDecimal(objDs.Tables[0].Rows[i]["Shelflifeper"])==0)
                            {
                                varShelflifePer = "";
                            }
                            else
                            {
                                varShelflifePer=Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]);
                            }
                            //string[] varActualShelflife = Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]).Split(' ');
                            //int actualShelfLife = Convert.ToInt32(varActualShelflife);
                            grdGrnApproval.Columns["clmproduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdGrnApproval.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[0].Rows[i]["Unit"]), Convert.ToString(objDs.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[0].Rows[i]["ExpiryDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["Product Shelflife"]), Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]), varShelflifePer, Convert.ToString(objDs.Tables[0].Rows[i]["BatchNo"]), Convert.ToString(objDs.Tables[0].Rows[i]["PO Qty"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Qty"]), Convert.ToString(objDs.Tables[0].Rows[i]["Received Qty"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Returned Qty"]), /*Convert.ToString(objDs.Tables[0].Rows[i]["POID"])*/0, Convert.ToString(objDs.Tables[0].Rows[i]["Unit Decimal"]), Convert.ToString(objDs.Tables[0].Rows[i]["Status"]));
                            dtApproval.Rows.Add( Convert.ToInt32(objDs.Tables[0].Rows[i]["PURPR_PRID"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[0].Rows[i]["ExpiryDate"]),Convert.ToString(objDs.Tables[0].Rows[i]["actual"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]), Convert.ToString(objDs.Tables[0].Rows[i]["BatchNo"]), Convert.ToInt32(objDs.Tables[0].Rows[i]["Reason"]), 0/*Convert.ToDecimal(objDs.Tables[0].Rows[i]["Returned Qty"])*/,0, Convert.ToInt32(objDs.Tables[0].Rows[i]["PURPRID"]));
                            dtPurchaseReturnDC.Rows.Add(Convert.ToInt32(objDs.Tables[0].Rows[i]["PURPR_PRID"]), Convert.ToDecimal(objDs.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[0].Rows[i]["ExpiryDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["BatchNo"]), 0,0 /*Convert.ToDecimal(objDs.Tables[0].Rows[i]["Returned Qty"])*/, Convert.ToString(objDs.Tables[0].Rows[i]["UTID"]), 0, 0, 0, 0, 0);
                            grdGrnApproval.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clmexpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGrnApproval.Columns["clmShelflifeper"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clmpoqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clminvoiceqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clmreceivedqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clmreturnqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            //grdGrnApproval.Columns["clmReason"].DefaultCellStyle.BackColor = Color.PaleGreen;
                            grdGrnApproval.Columns["clmreturnqty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                            grdGrnApproval.Columns["clmPOID"].Visible = false;
                            string[] varShelflifeper = Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]).Split(' ');
                            varInvoiceQty = Convert.ToDecimal(objDs.Tables[0].Rows[i]["Invoice Qty"]);
                            VarReceivedQty = Convert.ToDecimal(objDs.Tables[0].Rows[i]["Received Qty"]);
                            //varPOID = Convert.ToInt32(objDs.Tables[0].Rows[i]["POID"]);
                            if (varShelflifeper[0] != "")
                            {
                                if (Convert.ToDecimal(varShelflifeper[0]) > 24 && Convert.ToDecimal(varShelflifeper[0]) < 50)
                                {
                                    DataGridView dataGridView = grdGrnApproval;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                    cell.Style.BackColor = Color.Orange;
                                    cell.Style.ForeColor = Color.Black;
                                    txtORPercentageCheck.Enabled = true;
                                    lblFivetyPercentage.Enabled = true;
                                }
                                else if (Convert.ToDecimal(varShelflifeper[0]) > 0 && Convert.ToDecimal(varShelflifeper[0]) < 25)
                                {
                                    DataGridView dataGridView = grdGrnApproval;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                    cell.Style.BackColor = Color.Red;
                                    cell.Style.ForeColor = Color.White;
                                    txtRDPercentageCheck.Enabled = true;
                                    lbltwentyfiveper.Enabled = true;
                                }
                                else
                                {
                                    DataGridView dataGridView = grdGrnApproval;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmactualshelflife"];
                                    cell.Style.BackColor = Color.White;
                                    cell.Style.ForeColor = Color.Black;
                                }
                            }

                            udfnReason();
                            if (Convert.ToString(objDs.Tables[0].Rows[i]["Reason"]) == "")
                            {
                                grdGrnApproval.Rows[i].Cells["clmReason"].Value = 234;
                            }
                            else
                            {
                                grdGrnApproval.Rows[i].Cells["clmReason"].Value = Convert.ToInt32(objDs.Tables[0].Rows[i]["Reason"]);
                            }
                            if(Convert.ToInt32(grdGrnApproval.Rows[i].Cells["clmReason"].Value)==230 || Convert.ToInt32(grdGrnApproval.Rows[i].Cells["clmReason"].Value) == 234)
                            {
                                grdGrnApproval.Rows[i].ReadOnly = false;
                            }
                            else
                            {
                                grdGrnApproval.Rows[i].ReadOnly = true;
                            }
                            udfnQtyCheck();    
                        }
                        txttotalitem.Text = Convert.ToString(grdGrnApproval.Rows.Count);
                    }
                    if(objDs.Tables[2].Rows.Count>0)
                    {
                        txtEnteredBy.Text = Convert.ToString(objDs.Tables[2].Rows[0]["Entered By"]);
                        txtCompletedBy.Text = Convert.ToString(objDs.Tables[2].Rows[0]["Completed By"]);
                        txtVerifiedBy1.Text = Convert.ToString(objDs.Tables[2].Rows[0]["Verified BY 1"]);
                        txtVerifiedBy2.Text = Convert.ToString(objDs.Tables[2].Rows[0]["Verified BY 2"]);
                    }
                    //if(objDs.Tables[1].Rows.Count>1)
                    //{
                    //    for(int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    //    {
                    //        grdpurchasedetails.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["PO_Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["PO_No"]), Convert.ToString(objDs.Tables[0].Rows[i]["Created By"]), Convert.ToString(objDs.Tables[0].Rows[i]["PO_IssuedBy"]));
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            finally
            {
                grdGrnApproval.ClearSelection();
            }
        }
        public void udfnQtyCheck()
        {
            try
            {
                if (VarReceivedQty > varInvoiceQty)
                {
                    DataGridView dataGridView = grdGrnApproval;
                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmreceivedqty"];
                    cell.Style.BackColor = Color.Moccasin;
                    cell.Style.ForeColor = Color.Black;
                }
                else if (VarReceivedQty < varInvoiceQty)
                {
                    DataGridView dataGridView = grdGrnApproval;
                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmreceivedqty"];
                    cell.Style.BackColor = Color.MediumAquamarine;
                    cell.Style.ForeColor = Color.Black;
                }
                if(varPOID==1)
                {
                    DataGridView dataGridView = grdGrnApproval;
                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmproduct"];
                    cell.Style.BackColor = Color.LightCoral;
                    cell.Style.ForeColor = Color.White;
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
                int varDecimal = Convert.ToInt32(grdGrnApproval.CurrentRow.Cells["clmUnitDecimal"].Value);
                if (grdGrnApproval.CurrentCell.OwningColumn.Name == "clmreturnqty")
                {
                    //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    //{
                    //    e.Handled = true;  // Disallow the character
                    //}
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
