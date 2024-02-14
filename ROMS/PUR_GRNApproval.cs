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
    public partial class PUR_GRNApproval : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varSupplierID = 0,varScheduleID=0,varConcernID=0,varID=0;

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
        private void PUR_GRNApproval_Load(object sender, EventArgs e)
        {
            try
            {
                ClearSupplier();
                udfnsupplierLoad();
                udfnEdit();
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
                MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                MainForm.objPUR_GRNApprovalVerify.ShowDialog();
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
                            grdGrnApproval.Columns["clmproduct"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdGrnApproval.Rows.Add(Convert.ToString(objDs.Tables[0].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[0].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[0].Rows[i]["Unit"]), Convert.ToString(objDs.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDs.Tables[0].Rows[i]["ExpiryDate"]), Convert.ToString(objDs.Tables[0].Rows[i]["Product Shelflife"]), Convert.ToString(objDs.Tables[0].Rows[i]["actuallife"]), Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]), Convert.ToString(objDs.Tables[0].Rows[i]["BatchNo"]), Convert.ToString(objDs.Tables[0].Rows[i]["PO Qty"]), Convert.ToString(objDs.Tables[0].Rows[i]["Invoice Qty"]), Convert.ToString(objDs.Tables[0].Rows[i]["Received Qty"]),
                            Convert.ToString(objDs.Tables[0].Rows[i]["Returned Qty"]));
                            grdGrnApproval.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clmexpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdGrnApproval.Columns["clmShelflifeper"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clmpoqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clminvoiceqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clmreceivedqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clmreturnqty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGrnApproval.Columns["clmReason"].DefaultCellStyle.BackColor = Color.PaleGreen;
                            string[] varShelflifeper = Convert.ToString(objDs.Tables[0].Rows[i]["Shelflifeper"]).Split(' ');
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
                                else if (Convert.ToDecimal(varShelflifeper[0]) >= 0 && Convert.ToDecimal(varShelflifeper[0]) < 25)
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
                        }
                    }
                    if(objDs.Tables[1].Rows.Count>1)
                    {
                        for(int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                        {
                            grdpurchasedetails.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["PO_Date"]), Convert.ToString(objDs.Tables[0].Rows[i]["PO_No"]), Convert.ToString(objDs.Tables[0].Rows[i]["Created By"]), Convert.ToString(objDs.Tables[0].Rows[i]["PO_IssuedBy"]));
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
                grdGrnApproval.ClearSelection();
            }
        }
    }
}
