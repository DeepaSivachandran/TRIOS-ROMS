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
    public partial class INV_InwardPurchase : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int varConcernId = 0, varSupplierId = 0, varScheduleId = 0, varLocationId = 0, VarRackId = 0, varUnitId = 0,varGRNId=0;
        DataTable dtInwardPurchase = new DataTable();
        public INV_InwardPurchase()
        {
            InitializeComponent();
        }

        private void INV_InwardPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                ClearSupplier();
                EditLoad();
                udfnUddtTable();
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

        private void GrdGrnlist_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                grdGrnlist.ClearSelection();
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
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUddtTable()
        {
            try
            {
                dtInwardPurchase.TableName = "TRN_GoodsInward_Purchase_Products";
                dtInwardPurchase.Columns.Add("GIPPR_PRID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_UTID", typeof(int));
                dtInwardPurchase.Columns.Add("GIPPR_ReceivedQty", typeof(decimal));
                dtInwardPurchase.Columns.Add("GIPPR_ShopQty", typeof(string));
                dtInwardPurchase.Columns.Add("IDS", typeof(string));
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
        public void EditLoad()
        {
            try
            {
                if (varGRNId != 0)
                {
                    int varviewtype = 0;
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    TRN_GoodsInward_Purchase objTRN_GoodsInward_Purchase = new TRN_GoodsInward_Purchase();
                    objTRN_GoodsInward_Purchase.ViewType = varviewtype;
                    objTRN_GoodsInward_Purchase.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_GoodsInward_Purchase.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_GoodsInward_Purchase.paraGRNID = varGRNId;
                    objTRN_GoodsInward_Purchase.paraSLID = varLocationId;
                    objDs = objdserv.udfnInwardPurchaseList(objTRN_GoodsInward_Purchase);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                grdGrnlist.Rows.Clear();
                                grdGrnlist.DataSource = objDs.Tables[0];
                                grdGrnlist.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdGrnlist.Columns["MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["Invoice Received Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["Received Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGrnlist.Columns["Shop Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                                //grdGrnlist.Columns["Net Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                //grdGrnlist.Columns["GST%"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                //grdGrnlist.Columns["Expiry Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdGrnlist.Columns["Product Name in English"].Width = 300;
                                grdGrnlist.Columns["Product Name in Tamil"].Width = 300;
                                grdGrnlist.Columns["S.No."].Width = 50;
                                grdGrnlist.Columns["MRP"].Width = 80;
                                grdGrnlist.Columns["Unit"].Width = 70;

                                //grdGrnlist.Columns["GRNPR_PRID"].Visible = false;
                                //grdGrnlist.Columns["GRNPR_UTID"].Visible = false;
                                //grdGrnlist.Columns["UTID"].Visible = false;

                                grdGrnlist.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                //btnSave.Text = "Update";
                                udfnsupplierLoad();
                            }
                            else
                            {
                                lblNoRecordsFound.Visible = true;
                                lblNoRecordsFound.BringToFront();
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
            finally
            {
                grdGrnlist.ClearSelection();
                txttotalProduct.Text = Convert.ToString(grdGrnlist.Rows.Count);
            }
        }
        public void udfnsupplierLoad()
        {
            try
            {
                //pbSupplierpend = 0;
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (varSupplierId!=0)
                {
                    int varReturnApplicable = 0, varReturnType = 0;
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(varSupplierId);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(varScheduleId);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(varConcernId);
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
                        //if (objDs.Tables[1].Rows.Count > 0)
                        //{
                        //    if (objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString() != "")
                        //    { lblSalesmanName.Text = "Salesman Name - " + objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString(); }
                        //    if (objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString() != "")
                        //    { lblMobileNo.Text = "Mobile No. - " + objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString(); }
                        //    if (objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString() != "")
                        //    { lblWhatsAppNo.Text = "WhatsApp No. - " + objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString(); }
                        //}
                        //if (objDs.Tables[2].Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                        //    {
                        //        grdRepDetails.DataSource = objDs.Tables[2];
                        //        grdRepDetails.Columns["S.No."].Width = 40;
                        //        grdRepDetails.Columns["Rep Name"].Width = 150;
                        //        grdRepDetails.Columns["Brand"].Width = 150;
                        //        grdRepDetails.Columns["Phone No."].Width = 90;
                        //        grdRepDetails.Columns["WhatsApp No."].Width = 90;
                        //        grdRepDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        //    }
                        //}
                    }
                }
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
                lblReturn.Text = "";
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

    }
}
