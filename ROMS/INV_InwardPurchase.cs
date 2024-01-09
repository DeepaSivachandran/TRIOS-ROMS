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
                btnClose.BackColor = Color.Transparent;
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
                dtInwardPurchase.Columns.Add("GIPPR_ShopQty", typeof(decimal));
                dtInwardPurchase.Columns.Add("GIPPR_RKID", typeof(int));
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
                if (grdGrnlist.RowCount > 0)
                {
                    bool varErrorFlag = true;

                    if (txtInwardNo.Text == "")
                    {
                        //epInwardPurchase.SetError(txtInwardNo, "INward No. is empty.");
                        ////txtDcNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        //tpInwardNo.ShowAlways = true;
                        //tpInwardNo.Show("DC No. is empty.", txtInwardNo, 5000);
                        //varErrorFlag = false;
                    }
                    if (varErrorFlag == true )
                    {
                        int varStatusID = 0;
                        //if (grdGrnlist.Rows.Count > 0)
                        //{
                        //    if (varSupplierId!=0 && varLocationId!=0 && varGRNId!=0)
                        //    {
                        //        string result = "", varorginator = "Inward from GRN";
                        //        int varviewtype = 0;
                               
                        //        if (chkCompleted.Checked == true)
                        //        { varStatusID = 45; }
                        //        else { varStatusID = 46; }
                                
                        //        TRN_Purchase_DC objTRNS_Purchase_DC = new TRN_Purchase_DC();
                        //        objTRNS_Purchase_DC.ViewType = varviewtype;
                        //        objTRNS_Purchase_DC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                        //        objTRNS_Purchase_DC.paraIPAddress = MainForm.pbIpAddress;
                        //        objTRNS_Purchase_DC.paraOriginator = varorginator;
                        //        objTRNS_Purchase_DC.paraDCID = varDCID;
                        //        objTRNS_Purchase_DC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                        //        objTRNS_Purchase_DC.paraDC_Date = dpDCDate.Text;
                        //        objTRNS_Purchase_DC.paraDC_NO = txtDcNo.Text.Trim();
                        //        objTRNS_Purchase_DC.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text.Trim());
                        //        objTRNS_Purchase_DC.paraScheduleID = Convert.ToInt32(lblschedule.Text.Trim());
                        //        objTRNS_Purchase_DC.paraDC_Remarks = txtRemark.Text.Trim();
                        //        objTRNS_Purchase_DC.paraDC_PURID = varDC_PURID;
                        //        objTRNS_Purchase_DC.paraStatusID = varStatusID;
                        //        objTRNS_Purchase_DC.ParaTRN_Purchase_DC = dtPurchaseDC;
                        //        SPDataService objspdservice = new SPDataService();
                        //        result = objspdservice.udfnPurchaseDc(objTRNS_Purchase_DC);
                        //        objspdservice.CloseConnection();
                        //        string[] varvalue = result.Split('~');
                        //        if (varvalue[0] == "3")
                        //        {
                        //            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //            this.ActiveControl = txtSupplier;
                        //            //if(btnSave.Text=="Save")
                        //            //{
                        //            //   udfnClear();
                        //            //}
                        //            //else
                        //            //{
                        //            //    varCloseFlag = 1;
                        //            //    udfnclose();
                        //            //}
                        //            varCloseFlag = 1;
                        //            udfnclose();
                        //            MainForm.objPUR_PurchaseDCList.udfnList();
                        //        }
                        //        else if (varvalue[0] == "4")
                        //        {
                        //            MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //        }
                        //        if (varvalue[0] == "5")
                        //        {
                        //            MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //            string varProductID = "", Expirydate = "";
                        //            for (int j = 0; j < grdPurchaseDC.RowCount; j++)
                        //            {
                        //                grdPurchaseDC.Rows[j].DefaultCellStyle.BackColor = Color.White;

                        //                string[] varFirstList = varvalue[2].Split('|');
                        //                for (int i = 0; i < varFirstList.Length; i++)
                        //                {
                        //                    string[] varSecondList = varFirstList[i].Split(',');
                        //                    varProductID = varSecondList[0];
                        //                    Expirydate = varSecondList[1];
                        //                    if (Convert.ToString(grdPurchaseDC.Rows[j].Cells["clmPRID"].Value) == varProductID && Convert.ToString(grdPurchaseDC.Rows[j].Cells["clmExpiryDate"].Value) == Expirydate)
                        //                    {
                        //                        grdPurchaseDC.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                        //                        //  grdPurchaseDC.Rows[j].Cells["clmExpiryDate"].Style.BackColor = Color.LightPink;
                        //                    }
                        //                }
                        //            }
                        //        }
                        //        if (varvalue[0] == "6")
                        //        {
                        //            MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //            string varProductID = "", varMRP = "", varSLID = "", varRKID = "", varBatchNo = "", Expirydate = "";
                        //            for (int j = 0; j < grdPurchaseDC.RowCount; j++)
                        //            {
                        //                grdPurchaseDC.Rows[j].DefaultCellStyle.BackColor = Color.White;

                        //                string[] varFirstList = varvalue[2].Split('|');
                        //                for (int i = 0; i < varFirstList.Length; i++)
                        //                {
                        //                    string[] varSecondList = varFirstList[i].Split(',');
                        //                    varProductID = varSecondList[0];
                        //                    varMRP = varSecondList[1];
                        //                    varSLID = varSecondList[2];
                        //                    varRKID = varSecondList[3];
                        //                    /// varBatchNo = varSecondList[4];
                        //                    //Expirydate = varSecondList[5];
                        //                    if (Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmPRID"].Value) == varProductID && Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmExpiryDate"].Value) == Expirydate && Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmSLID"].Value) == varSLID && Convert.ToString(grdPurchaseDC.Rows[i].Cells["clmRKID"].Value) == varRKID &&
                        //                        Convert.ToString(grdPurchaseDC.Rows[j].Cells["clmMRP"].Value) == varMRP && Convert.ToString(grdPurchaseDC.Rows[j].Cells["clmBatchNo"].Value) == varBatchNo)
                        //                    {
                        //                        // grdPurchaseDC.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                        //                        grdPurchaseDC.Rows[j].Cells["clmQuantity"].Style.BackColor = Color.LightPink;
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(100);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                if (chkCompleted.Checked == true)
                { btnSave.Text = "Save"; }
                else { btnSave.Text = "Draft"; }
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

                                grdGrnlist.Columns["Product Name in English"].Width = 300;
                                grdGrnlist.Columns["Product Name in Tamil"].Width = 300;
                                grdGrnlist.Columns["S.No."].Width = 50;
                                grdGrnlist.Columns["MRP"].Width = 80;
                                grdGrnlist.Columns["Unit"].Width = 70;

                                //grdGrnlist.Columns["GRNPR_PRID"].Visible = false;
                                //grdGrnlist.Columns["GRNPR_UTID"].Visible = false;
                                //grdGrnlist.Columns["UTID"].Visible = false;
                                //grdGrnlist.Columns["UTID"].Visible = false;
                                //grdGrnlist.Columns["PR_PUR_SLID"].Visible = false;
                                //grdGrnlist.Columns["PR_PUR_RKID"].Visible = false;
                                //grdGrnlist.Columns["Invoice Received Qty"].Visible = false;

                                grdGrnlist.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                                grdGrnlist.Columns["Received Qty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdGrnlist.Columns["Shop Qty"].DefaultCellStyle.BackColor = Color.PaleGreen;
                                grdGrnlist.Columns["Rack"].DefaultCellStyle.BackColor = Color.PaleGreen;

                                grdGrnlist.Columns["S.No."].ReadOnly = true;
                                grdGrnlist.Columns["MRP"].ReadOnly = true;
                                grdGrnlist.Columns["P.I Code"].ReadOnly = true;
                                grdGrnlist.Columns["Product Name in English"].ReadOnly = true;
                                grdGrnlist.Columns["Product Name in Tamil"].ReadOnly = true;
                                grdGrnlist.Columns["Batch No."].ReadOnly = true;
                                grdGrnlist.Columns["Unit"].ReadOnly = true;
                                ((DataGridViewTextBoxColumn)grdGrnlist.Columns["Received Qty"]).MaxInputLength = 8;
                                ((DataGridViewTextBoxColumn)grdGrnlist.Columns["Shop Qty"]).MaxInputLength = 8;
                                ((DataGridViewTextBoxColumn)grdGrnlist.Columns["Invoice Received Qty"]).MaxInputLength = 8;
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
