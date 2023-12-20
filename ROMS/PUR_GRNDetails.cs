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
    public partial class PUR_GRNDetails : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        ToolTip tpProduct = new ToolTip();
        ToolTip tpconcern = new ToolTip();
        ToolTip tprate = new ToolTip();
        ToolTip tpbatchno = new ToolTip();
        ToolTip tpmonth = new ToolTip();
        ToolTip tpdate = new ToolTip();
        ToolTip tpyear = new ToolTip();
        public string varPICode = "", varEName = "", var_Symbol = "", var_Text = "", var_RMinSaleQty = "", varSTOCK = "", varPrevious = "", varPARITAL = "", varReOrderQty = ""
            , varorderSaleQty = "", varorderqty = "", addproductid = "", varunitid = "0", varDamage = "0", varReturnDC = "0", pbGRNId = "0", pbSupplierId = "0", dcid = "0",
            varenablefalg = "0", varUserID = "0", varflag = "0", varExpiryDate = "", varTName = "", varexp = "", pbScheduleId = "0", pbPOIdS = "0",
            varBatchNoGeneration = "0", varPrcategory = "0", varRMProduction = "0", varBatchNo = "0";

        public int varGrnId = 0, varCloseflag = 0, pbDateflag = 0, varShelflife = 0, expirydateFlag = 0, varErrorFormat = 0;
        public bool VarSearchFlag = true;
        public PUR_GRNDetails()
        {
            InitializeComponent();
        }
        private void PUR_GRNEntry_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = dpinvoicedate;
                udfnDropdownLoad();
                udfnEditLoad();
                udfnDateSet();
                udfnPODropdownload();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnPODropdownload()
        {
            try
            {
                DataSet objDT = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDT = null;
                objDT = objdserv.udfnPOEntry(5, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, 0, 0, 0, 0, "", "", 0, 0, "0", 0);
                objdserv.CloseConnection();
                cmbPONo.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbPONo.ValueMember = "poid";
                            cmbPONo.DisplayMember = "PO_No";
                            cmbPONo.DataSource = objDT.Tables[0];
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

        public void udfnDateSet()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(4, 6, 0, "", "", 0, "", 0);
                if (objd.Tables[1].Rows.Count != 0)
                {
                    DateTime varmindate = DateTime.ParseExact(Convert.ToString(objd.Tables[1].Rows[0]["MinToday"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpinvoicedate.MinDate = varmindate;
                }
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
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (16 ) OR MSTID  IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrderType, "", "MST_DisplayText", "MSTID");
            objDataBind = null;
        }

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
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
                    errGRNDetails.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpconcern.ShowAlways = true;
                    tpconcern.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    errGRNDetails.Clear();
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
                    dpGrnDate.Focus();
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
                if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                {
                    string vardate = "", varResult = "";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    DataService objDservice = new DataService();
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,GETDATE(),103)");
                    varResult = objspdservice.udfngetPONO("39", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                    objspdservice.CloseConnection();
                    if (varResult != "")
                    {
                        txtgrnno.Text = varResult;
                    }
                    else
                    {
                        txtgrnno.Text = "";
                    }
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
        public void udfnclose()
        {
            try
            {
                if (varCloseflag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
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

        private void BtnVerify1_Click(object sender, EventArgs e)
        {

            try
            {
                udfnverify();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnVerify2_Click(object sender, EventArgs e)
        {
            try
            {
                udfnverify();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        public void udfnverify()
        {
            try
            {
                MainForm.objPUR_GRNVerify = new PUR_GRNVerify();
                MainForm.objPUR_GRNVerify.pbGRNId = pbGRNId;
                if (btnVerify1.Enabled == true)
                {
                    MainForm.objPUR_GRNVerify.varVerifyType = 1;
                }
                else
                {
                    MainForm.objPUR_GRNVerify.varVerifyType = 2;
                }
                MainForm.objPUR_GRNVerify.ShowDialog();
                if (varenablefalg == "1")
                {
                    btnVerify1.Enabled = false;
                    btnVerify2.Enabled = true;
                    btnDC.Enabled = false;
                    gpAddrow.Enabled = false;
                }
                else if (varenablefalg == "2")
                {
                    btnVerify1.Enabled = false;
                    btnVerify2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                objDs = objdserv.udfnGrnListLoad(4, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblVerified1.Text = Convert.ToString(objDs.Tables[0].Rows[0]["VERIFIED1"]);
                            lblVerifyDateTime.Text = Convert.ToString(objDs.Tables[0].Rows[0]["VERIFIEDON1"]);
                        }
                        if (objDs.Tables[1].Rows.Count != 0)
                        {
                            lblVerified2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["VERIFIED2"]);
                            lblVerifyDateTime2.Text = Convert.ToString(objDs.Tables[1].Rows[0]["VERIFIEDON2"]);
                        }
                    }
                }
            }
        }

        private void TxtInvoiceamt_Leave(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceamt.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToInt32(cmbOrderType.SelectedValue) == 53)
            //    {

            //        MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
            //        MainForm.objPUR_GRNOrderType.ShowDialog();
            //    }
            //    else
            //    {
            //        MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
            //        MainForm.objPUR_GRNOrderType.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);

            //}
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_Product = new PUR_Product();
                MainForm.objPUR_Product.ShowDialog();
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
                string result = "", varPurchaseDC = "0";
                varflag = "0"; varUserID = "0";
                MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                MainForm.objPUR_GRNApprovalVerify.ShowDialog();
                if (varflag == "1")
                {
                    for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                    {
                        if (varPurchaseDC == "0")
                        {
                            varPurchaseDC = Convert.ToString(grdReurnDC.Rows[i].Cells["ID"].Value);
                        }
                        else
                        {
                            varPurchaseDC = varPurchaseDC + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["ID"].Value);
                        }
                    }

                    DataTable objGRNProd = new DataTable();
                    objGRNProd.TableName = "TRN_GRN_Products";
                    objGRNProd.Columns.Add("GRNPR_GRNID", typeof(int));
                    objGRNProd.Columns.Add("GRNPR_PRID", typeof(int));
                    objGRNProd.Columns.Add("GRNPR_UTID", typeof(float));
                    objGRNProd.Columns.Add("GRNPR_MRP", typeof(float));
                    objGRNProd.Columns.Add("GRNPR_EXP_DD", typeof(float));
                    objGRNProd.Columns.Add("GRNPR_EXP_MM", typeof(int));
                    objGRNProd.Columns.Add("GRNPR_EXP_YY", typeof(int));
                    objGRNProd.Columns.Add("GRNPR_BatchNo", typeof(int));
                    objGRNProd.Columns.Add("GRNPR_ShelfLifeValue", typeof(int));
                    objGRNProd.Columns.Add("GRNPR_ShelfLifeType", typeof(int));
                    objGRNProd.Columns.Add("GRNPR_POID", typeof(int));
                    objGRNProd.Columns.Add("GRNPR_ShelfLife_Per", typeof(int));
                    objGRNProd = udfnobjGRNProd();
                    SPDataService objspdservice = new SPDataService();
                    varGrnId = Convert.ToInt32(pbGRNId);
                    TRN_GRN objTRNS_GRN = new TRN_GRN();
                    objTRNS_GRN.ViewType = 3;
                    objTRNS_GRN.ParaGRNID = varGrnId;
                    objTRNS_GRN.paraINVDate = dpinvoicedate.Text;
                    objTRNS_GRN.paraINVNo = txtInvoiceno.Text;
                    objTRNS_GRN.ParaInvAmt = Convert.ToDouble(txtInvoiceamt.Text);
                    objTRNS_GRN.ParaPurchaseDC = varPurchaseDC;
                    objTRNS_GRN.paraUserID = Convert.ToInt32(varUserID);
                    objTRNS_GRN.paraRemarks = txtRemark.Text;
                    objTRNS_GRN.paraGRNProd = objGRNProd;
                    if (chkCompleted.Checked == true)
                    {
                        objTRNS_GRN.paraStatus = 23;
                    }
                    else
                    {
                        objTRNS_GRN.paraStatus = 17;
                    }
                    result = objspdservice.udfnGRNEntry(objTRNS_GRN);
                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = txtSupplier;
                        MainForm.objPUR_GRNDetailsList.udfnListLoad();
                        varCloseflag = 1;
                        udfnclose();
                    }
                    else
                    {
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        public DataTable udfnobjGRNProd()
        {
            DataTable objGRNProd = new DataTable();
            try
            {
                objGRNProd.TableName = "TRN_GRN_Products";
                objGRNProd.Columns.Add("GRNPR_GRNID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_PRID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_UTID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_MRP", typeof(float));
                objGRNProd.Columns.Add("GRNPR_EXP_DD", typeof(int));
                objGRNProd.Columns.Add("GRNPR_EXP_MM", typeof(int));
                objGRNProd.Columns.Add("GRNPR_EXP_YY", typeof(int));
                objGRNProd.Columns.Add("GRNPR_BatchNo", typeof(string));
                objGRNProd.Columns.Add("GRNPR_ShelfLifeValue", typeof(int));
                objGRNProd.Columns.Add("GRNPR_ShelfLifeType", typeof(int));
                objGRNProd.Columns.Add("GRNPR_POID", typeof(int));
                objGRNProd.Columns.Add("GRNPR_ShelfLife_Per", typeof(float));
                objGRNProd.Columns.Add("GRNPR_Expirydate", typeof(string));
                for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                {
                    decimal varMRP = 0;
                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmmrp"].Value) != "")
                    {
                        varMRP = Convert.ToDecimal(grdGrnlist.Rows[i].Cells["clmmrp"].Value);
                    }
                    DataService objDser = new DataService();
                    objGRNProd.Rows.Add(Convert.ToInt32(pbGRNId), Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmProid"].Value),
                    Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmUtid"].Value), varMRP,
                    0, 0, 0, Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value), 0, 0, Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmPOid"].Value)
                    , 0, "");
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return objGRNProd;
        }
        private void ChkCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCompleted.Checked) { btnSave.Text = "Update"; } else { btnSave.Text = "Draft"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void DpGrnDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpGrnDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void DpGrnDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpGrnDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void DpGrnDate_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbOrderType.Focus();
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

        private void TxtSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Items.Clear();
                if (txtSupplier.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 15;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
                                LV_Supplier.BringToFront();
                                LV_Supplier.Columns[1].Width = 0;
                                LV_Supplier.Columns[2].Width = 0;
                                LV_Supplier.Columns[0].Width = 300;
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
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text;
                    udfnsupplierLoad();
                }
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    cmbConcern.Focus();
                    cmbConcern.BackColor = Color.LemonChiffon;
                }
                else
                {
                    cmbOrderType.Focus();
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

        private void CmbOrderType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbOrderType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbOrderType.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpinvoicedate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbOrderType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txtmrprate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmrprate_Leave(object sender, EventArgs e)
        {
            try
            {
                txtmrprate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Txtmrprate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtmrprate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Month_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtYear.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Month_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtMonth, "Please enter month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
                else
                { txtMonth.BackColor = Color.White; }
                if (txtMonth.Text != "")
                {
                    if (Convert.ToInt32(txtMonth.Text.Trim()) > 12)
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtMonth, "Please enter valid month.");
                    }
                    else
                    {
                        txtMonth.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Month_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMonth.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Year_Leave(object sender, EventArgs e)
        {
            try
            {
                if (expirydateFlag == 1)
                {
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtYear, "Please enter year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
                else { txtYear.BackColor = Color.White; }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Trim() == "00")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtYear, "Please enter valid year.");
                    }
                    else
                    {
                        txtYear.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Year_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Year_Enter(object sender, EventArgs e)
        {
            try
            {
                txtYear.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBatchno_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtBatchno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchno.Text.Trim() == "")
                    {
                        txtBatchno.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtBatchno, "Please enter BatchNo.");
                        tpbatchno.ShowAlways = true;
                        tpbatchno.Show("Please enter BatchNo.", txtBatchno, 5000);
                    }
                    else
                    {
                        txtBatchno.BackColor = Color.White;
                        errGRNDetails.Clear();
                    }
                }
                else
                {
                    txtBatchno.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtBatchno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkCompleted_Leave(object sender, EventArgs e)
        {
            try
            {
                chkCompleted.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void ChkCompleted_Enter(object sender, EventArgs e)
        {
            try
            {
                chkCompleted.BackColor = Color.White;
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

        private void BtnDC_Click(object sender, EventArgs e)
        {
            try
            {
                dcid = "0";
                for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                {
                    if (dcid == "0")
                    {
                        dcid = Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                    }
                    else
                    {
                        dcid = dcid + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["id"].Value);
                    }
                }
                MainForm.objINV_GRNPODamaged = new INV_GRNPODamaged();
                MainForm.objINV_GRNPODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void Txtmrprate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void TxtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void Month_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string varProductsCodes = "0";
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductName.Text.Length > 0)
                {
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 29;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.ParaScheduleid = Convert.ToString(lblschedule.Text);
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Product.ParaProductsCode = varProductsCodes;
                    if (VarSearchFlag == true)
                    {
                        objMR_Product.paraPicode = txtProductName.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    }
                    else
                    {
                        objMR_Product.paraProductName = txtProductName.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    }
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
                                //lvproduct.Columns[3].Width = 0;
                                //lvproduct.Columns[4].Width = 0;
                                //lvproduct.Columns[5].Width = 0;
                                //lvproduct.Columns[6].Width = 0;
                                //lvproduct.Columns[7].Width = 0;
                                //lvproduct.Columns[8].Width = 0;
                                //lvproduct.Columns[9].Width = 0;
                                //lvproduct.EndUpdate();
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

        private void TxtInvoiceamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                pbDateflag = 0;
                udfnAddProductsgrid();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }



        private void GrdGrnlist_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                varErrorFormat = 0;
                if (Convert.ToString(grdGrnlist.Rows[e.RowIndex].Cells["clmShelflifeenable"].Value) == "1")
                {
                    if (grdGrnlist.Columns[e.ColumnIndex].Name == "clmexpirydate")
                    {
                        varExpiryDate = "";
                        string dateString = e.FormattedValue.ToString();
                        DataSet objDS = new DataSet();
                        SPDataService objDServ = new SPDataService();
                        objDS = objDServ.udfnMaster(8, 0, 0, dateString, "", 0, "", 0);
                        objDServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToString(objDS.Tables[0].Rows[0]["DATE"]) == "0")
                            {
                                varErrorFormat = 1;
                                MessageBox.Show("Invalid date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                e.Cancel = true;
                            }
                            else
                            {
                                varExpiryDate = e.FormattedValue.ToString();
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

        private void TxtInvoiceno_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceno.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDate.Text.Length == 2)
                {
                    txtMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMonth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMonth.Text.Length == 2)
                {
                    txtYear.Focus();
                }
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
                for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                {
                    if (Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchenable"].Value) == "72" || Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchgeneration"].Value) == "74")
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

        private void TxtYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text.Length == 2)
                {
                    if (txtBatchno.Enabled == true)
                    {
                        txtBatchno.Focus();
                    }
                    else
                    {
                        btnAdd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceno_Leave(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceno.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceamt.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnlist_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string varshelflife = "";
                SPDataService objdserv = new SPDataService();
                DataSet objDs = new DataSet();
                int varCellprodid = 0;
                if (grdGrnlist.Columns[e.ColumnIndex].Name == "clmexpirydate")
                {
                    varCellprodid = Convert.ToInt32(grdGrnlist.Rows[e.RowIndex].Cells["clmProid"].Value);
                    int rowIndex = e.RowIndex;
                    int columnIndex = e.ColumnIndex;
                    if (rowIndex >= 0 && columnIndex >= 0)
                    {
                        object cellValue = grdGrnlist.Rows[rowIndex].Cells[columnIndex].Value;
                        if (cellValue != null && Convert.ToString(cellValue) != "")
                        {
                            varshelflife = cellValue.ToString();
                            if (varshelflife != "" || varshelflife != null)
                                objDs = objdserv.udfnGrnListLoad(3, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, varshelflife, dpGrnDate.Text, varCellprodid);
                            objdserv.CloseConnection();
                            if (objDs != null)
                            {
                                if (objDs.Tables[0].Rows.Count > 0)
                                {
                                    grdGrnlist.Rows[rowIndex].Cells["clmshelfper"].Value = Convert.ToString(objDs.Tables[0].Rows[0]["SHELFLIFE"]);
                                }
                                if (objDs.Tables[1].Rows.Count > 0)
                                {
                                    grdGrnlist.Rows[rowIndex].Cells["clmactuallife"].Value = Convert.ToString(objDs.Tables[1].Rows[0]["ACUTAL"]);
                                }
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

        private void GrdGrnlist_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdGrnlist.IsCurrentCellDirty)
                {
                    grdGrnlist.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPONo_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPONo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPONo_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPONo.BackColor = Color.White;
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPONo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductName.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGrnlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdGrnlist.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdGrnlist.Rows.RemoveAt(this.grdGrnlist.SelectedCells[0].RowIndex);
                                for (int i = 0; i < grdGrnlist.RowCount; i++)
                                {
                                    grdGrnlist.Rows[i].Cells["clmsno"].Value = i + 1;
                                }
                            }
                            break;
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

        private void GrdGrnlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (varErrorFormat == 0)
                {
                    udfnGridaddvalue(e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGridaddvalue(DataGridViewCellEventArgs value)
        {
            try
            {
                int varExpiryDays = 0; int error = 0;
                pbDateflag = 0;
                int rowIndex = value.RowIndex;
                int columnIndex = value.ColumnIndex;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                objDS = objDServ.udfnMaster(10, 0, 0, dpGrnDate.Text.Trim(), varExpiryDate, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0);
                objDServ.CloseConnection();
                for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                {
                    if (pbDateflag == 0)
                    {
                        if (grdGrnlist.CurrentCell.OwningColumn.Name == "clmexpirydate")
                        {
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                                {
                                    pbDateflag = 1; error = 1;
                                }
                                else
                                {
                                    if (objDS.Tables.Count != 0)
                                    {
                                        if (objDS.Tables[1].Rows.Count > 0)
                                        {
                                            varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                        }
                                    }
                                    if (varExpiryDays < 0)
                                    {
                                        pbDateflag = 1; error = 1;
                                    }
                                    else
                                    {
                                        if (varShelflife == 1)
                                        {
                                            if (objDS.Tables.Count > 1)
                                            {
                                                if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                                {
                                                    pbDateflag = 1;
                                                    grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
                                                    string varMessage = objDServ.udfnGetMessages(98);
                                                    objDServ.CloseConnection();
                                                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                                else
                                                {
                                                    grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                                }
                                            }
                                            else
                                            {
                                                pbDateflag = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (error == 1)
                        {
                            grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.Pink;
                            string varMessage = objDServ.udfnGetMessages(94);
                            objDServ.CloseConnection();
                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        if (pbDateflag == 0)
                        { 
                            grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            if (Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmsno"].Value) != Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmsno"].Value))
                            {
                                if (Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmProid"].Value) == Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmProid"].Value))
                                {
                                    string varMRP = Convert.ToString(grdGrnlist.Rows[i].Cells["clmmrp"].Value).Trim();
                                    string varNewExpiryDate = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value).Trim();
                                    string varBatch = Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value).Trim();
                                    string varPoid = Convert.ToString(grdGrnlist.Rows[i].Cells["clmPOid"].Value).Trim();
                                    if (Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmexpirydate"].Value) == varNewExpiryDate && Convert.ToString(grdGrnlist.Rows[rowIndex].Cells["clmBatchno"].Value) == varBatch)
                                    {
                                        if (Convert.ToInt32(grdGrnlist.Rows[rowIndex].Cells["clmPOid"].Value) == Convert.ToInt32(varPoid))
                                        {
                                            MessageBox.Show("Product already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                                        }
                                        else
                                        {
                                            grdGrnlist.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                        }
                                    }
                                }
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

        private void CmbPONo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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


        private void GrdPODetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdPODetails.Rows.Count; i++)
                {
                    if (Convert.ToString(grdPODetails.Rows[i].Cells["clmsts"].Value) == "13")
                    {
                        grdPODetails.Rows[i].DefaultCellStyle.BackColor = Color.RoyalBlue;
                        grdPODetails.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        grdPODetails.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("255, 128, 0");
                        grdPODetails.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPODetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPODetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmpono":
                            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                            {
                                string cellPOValue = Convert.ToString(grdPODetails.Rows[e.RowIndex].Cells["clmpendpoid"].Value);
                                MainForm.objPUR_POProducts = new PUR_POProducts();
                                MainForm.objPUR_POProducts.pbPoid = cellPOValue;
                                MainForm.objPUR_POProducts.pbSupplierCode = lblSupplierCode.Text;
                                MainForm.objPUR_POProducts.pbScheduleCode = lblschedule.Text;
                                MainForm.objPUR_POProducts.ShowDialog();
                            }
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

        private void PUR_GRNDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    //udfnsave();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblDEGroup.Text = "Search by P.I Code";
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblDEGroup.Text = "Search by Product Name";
                    }
                }
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
                MainForm.objPUR_PODamaged = new PUR_PODamaged();
                MainForm.objPUR_PODamaged.varMasterType = "3";
                MainForm.objPUR_PODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        public void udfnAddProductsgrid()
        {
            try
            {
                bool varErrorFlag = false;
                lvproduct.Visible = false;
                if (txtProductName.Text == "")
                {
                    errGRNDetails.SetError(txtProductName, "Please enter product");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product.", txtProductName, 5000);
                    varErrorFlag = true;
                }
                if (expirydateFlag == 1)
                {
                    if (txtMonth.Text.Trim() == "")
                    {
                        txtMonth.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtMonth, "Please enter month.");
                        varErrorFlag = true;
                    }
                    if (txtYear.Text.Trim() == "")
                    {
                        txtYear.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtYear, "Please enter year.");
                        varErrorFlag = true;
                    }
                }
                if (varBatchNoGeneration == "75")
                {
                    if (txtBatchno.Text.Trim() == "")
                    {
                        txtBatchno.BackColor = ColorTranslator.FromHtml("#fabdbd");
                        errGRNDetails.SetError(txtBatchno, "Please enter BatchNo.");
                        tpbatchno.ShowAlways = true;
                        tpbatchno.Show("Please enter Batch No.", txtBatchno, 5000);
                        varErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtProductName.Text) != "")
                {
                    string varproductID = "0";
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 39;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.paraProductName = txtProductName.Text;
                    objMR_Product.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    DataSet objDsproductId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsproductId = objDserv.udfnproductmasterlist(objMR_Product);
                    objDserv.CloseConnection();
                    if (objDsproductId != null)
                    {
                        if (objDsproductId.Tables.Count > 0)
                        {
                            if (objDsproductId.Tables[0].Rows.Count > 0)
                            {
                                varproductID = Convert.ToString(objDsproductId.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varproductID == "-1")
                    {
                        lblProductcode.Text = "0";
                        errGRNDetails.SetError(txtProductName, "Invalid product");
                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpProduct.ShowAlways = true;
                        tpProduct.Show("Invalid product", txtProductName, 5000);
                        varErrorFlag = true;
                    }
                    else
                    {
                        lblProductcode.Text = varproductID;
                        errGRNDetails.Clear();
                        txtProductName.BackColor = Color.White;
                    }
                }
                if (varErrorFlag == false)
                {
                    int varflag = 0;
                    string varShelflifevalue = "", varAcutalshelflife = "";
                    lblNoRecordsFound.Visible = false;

                    if (expirydateFlag == 1 || txtDate.Text != "" || txtMonth.Text != "" || txtYear.Text != "")
                    {
                        udfnDatevalidationset();
                    }
                    SPDataService objDServ = new SPDataService();
                    DataSet objDS = new DataSet();
                    if (varExpiryDate != "")
                    {
                        if (expirydateFlag == 1)
                        {
                            objDS = objDServ.udfnMaster(7, 0, 0, dpGrnDate.Text, varExpiryDate, Convert.ToInt32(lblProductcode.Text), "", 0);
                            objDServ.CloseConnection();
                            if (objDS.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(objDS.Tables[0].Rows[0]["DATEVALIDATE"]) == "0")
                                {
                                    errGRNDetails.SetError(txtDate, "Invalid expiry date");
                                    txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                    tpProduct.ShowAlways = true;
                                    tpProduct.Show("Invalid expiry date", txtDate, 5000);
                                    varflag = 1;
                                }
                                else
                                {
                                    if (objDS.Tables[1].Rows.Count > 0)
                                    {
                                        varShelflifevalue = Convert.ToString(objDS.Tables[1].Rows[0]["SHELFLIFE"]);
                                    }
                                    if (objDS.Tables[2].Rows.Count > 0)
                                    {
                                        varAcutalshelflife = Convert.ToString(objDS.Tables[2].Rows[0]["ACUTAL"]);
                                    }
                                }
                            }
                        }
                    }
                    if (varflag == 0)
                    {
                        for (int i = 0; i < grdGrnlist.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(lblProductcode.Text) == Convert.ToInt32(grdGrnlist.Rows[i].Cells["clmProid"].Value))
                            {
                                string varMRP = Convert.ToString(grdGrnlist.Rows[i].Cells["clmmrp"].Value).Trim();
                                string varNewExpiryDate = Convert.ToString(grdGrnlist.Rows[i].Cells["clmexpirydate"].Value).Trim();
                                string varBatch = Convert.ToString(grdGrnlist.Rows[i].Cells["clmBatchno"].Value).Trim();
                                string varPoid = Convert.ToString(grdGrnlist.Rows[i].Cells["clmPOid"].Value).Trim();

                                if (txtmrprate.Text.Trim() == varMRP && varExpiryDate == varNewExpiryDate && txtBatchno.Text.Trim() == varBatch)
                                {
                                    if (Convert.ToString(cmbPONo.SelectedValue) == varPoid)
                                    {
                                        lblProductcode.Text = "0";
                                        errGRNDetails.SetError(txtProductName, "Product already Exist for this location");
                                        txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                        tpdate.ShowAlways = true;
                                        tpdate.Show("Product already Exist for this location", txtProductName, 5000);
                                        varflag = 1;
                                    }
                                }
                            }
                        }
                    }

                    if (Convert.ToInt32(lblProductcode.Text) != 0 && Convert.ToInt32(lblSupplierCode.Text) != 0)
                    {
                        if (varflag == 0)
                        {
                            if (pbDateflag == 0)
                            {
                                errGRNDetails.Clear();
                                tpdate.Active = false;
                                txtDate.BackColor = Color.White;
                                txtMonth.BackColor = Color.White;
                                txtYear.BackColor = Color.White;
                                string[] varpono = cmbPONo.Text.Split('~');

                                grdGrnlist.Rows.Add(grdGrnlist.Rows.Count + 1, (varpono[0]).Trim(), (varPICode).Trim(), (varEName).Trim(), (varTName).Trim(), (var_Symbol).Trim(), (txtmrprate.Text).Trim(), (varExpiryDate).Trim()
                                    , (varexp).Trim(), varAcutalshelflife, varShelflifevalue, (txtBatchno.Text).Trim(), (lblProductcode.Text).Trim(), (varunitid).Trim(), cmbPONo.SelectedValue);
                                udfnrowclear();
                                //grdsupplieradd.Sort(grdsupplieradd.Columns[1], ListSortDirection.Ascending);
                                //for (int i = 0; i < grdsupplieradd.RowCount; i++)
                                //{
                                //    grdsupplieradd.Rows[i].Cells["clmsno"].Value = i + 1;
                                //}
                                txtProductName.Focus();
                                if (varBatchNoGeneration == "73" || varBatchNoGeneration == "74")
                                {
                                    DataGridView dataGridView = grdGrnlist;
                                    DataGridViewCell cell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["clmBatchno"];
                                    cell.Style.BackColor = Color.LightGray;
                                    cell.Style.ForeColor = Color.Black;
                                    cell.ReadOnly = true;
                                }
                            }
                            else
                            {
                                //SPDataService objDServ1 = new SPDataService();
                                //string varMessage = objDServ1.udfnGetMessages(70);
                                //objDServ1.CloseConnection();
                                //MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                grdGrnlist.Sort(grdGrnlist.Columns[1], ListSortDirection.Ascending);
            }
        }

        public void udfnrowclear()
        {
            try
            {
                errGRNDetails.Clear();
                cmbPONo.SelectedIndex = 0;
                cmbPONo.BackColor = Color.White;
                txtProductName.Text = "";
                txtmrprate.Text = "";
                txtDate.Text = "";
                txtMonth.Text = "";
                txtYear.Text = "";
                txtBatchno.Text = "";
                txtProductName.BackColor = Color.White;
                txtmrprate.BackColor = Color.White;
                txtDate.BackColor = Color.White;
                txtMonth.BackColor = Color.White;
                txtYear.BackColor = Color.White;
                txtBatchno.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDatevalidationset()
        {
            try
            {
                string varDay = "", varMonth = "", varYear = "", varDate = ""; string varDcDay = "", varDcMonth = "", varDcYear = "", varExpiry = "";
                int varExpiryDays = 0; int error = 0;
                SPDataService objDServ = new SPDataService();
                DataSet objDS = new DataSet();
                if (txtDate.Text.Trim() == "")
                {
                    varDay = "01";
                }
                else
                {
                    if (Convert.ToInt64(txtDate.Text) > 31 || Convert.ToInt64(txtDate.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(95);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtDate.Text.Length == 1)
                        { txtDate.Text = 0 + txtDate.Text.Trim(); }
                        varDay = txtDate.Text.Trim();
                    }
                }
                if (txtMonth.Text.Trim() != "")
                {
                    if (Convert.ToInt64(txtMonth.Text) > 12 || Convert.ToInt64(txtMonth.Text) <= 0)
                    {
                        pbDateflag = 1;
                        txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(90);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txtMonth.Text.Length == 1)
                        { txtMonth.Text = 0 + txtMonth.Text.Trim(); }
                    }
                }
                if (txtYear.Text.Trim() != "")
                {
                    if (txtYear.Text.Length < 2)
                    {
                        pbDateflag = 1;
                        txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        string varMessage = objDServ.udfnGetMessages(92);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (pbDateflag == 0)
                {
                    varMonth = Convert.ToString(txtMonth.Text.Trim());
                    varYear = 20 + Convert.ToString(txtYear.Text.Trim());
                    if (txtDate.Text.Trim() == "")
                    {
                        varDate = varDay + "/" + varMonth + "/" + varYear;
                        objDS = objDServ.udfnMaster(5, 0, 0, varDate, "", 0, "", 0);
                        objDServ.CloseConnection();
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            varExpiryDate = objDS.Tables[0].Rows[0]["DD/MM/YYYY"].ToString();
                        }
                    }
                    else
                    {
                        varExpiryDate = varDay + "/" + varMonth + "/" + varYear;
                    }
                    objDS = objDServ.udfnMaster(10, 0, 0, dpGrnDate.Text.Trim(), varExpiryDate, Convert.ToInt32(lblProductcode.Text.Trim()), "", 0);
                    objDServ.CloseConnection();
                    if (objDS.Tables[0].Rows.Count > 0)
                    {
                        if (objDS.Tables[0].Rows[0]["Date"].ToString() == "0")
                        {
                            pbDateflag = 1; error = 1;
                        }
                        else
                        {
                            if (objDS.Tables.Count != 0)
                            {
                                if (objDS.Tables[1].Rows.Count > 0)
                                {
                                    varExpiryDays = Convert.ToInt32(objDS.Tables[1].Rows[0]["ExpiryDate"]);
                                }
                            }
                            if (varExpiryDays < 0)
                            {
                                pbDateflag = 1; error = 1;
                            }
                            else
                            {
                                if (varShelflife == 1)
                                {
                                    if (objDS.Tables.Count > 1)
                                    {
                                        if (Convert.ToInt32(objDS.Tables[2].Rows[0]["DATEVALIDATE"]) == 0)
                                        {
                                            pbDateflag = 1;
                                            txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                                            string varMessage = objDServ.udfnGetMessages(98);
                                            objDServ.CloseConnection();
                                            MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        pbDateflag = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                if (error == 1)
                {
                    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    txtDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    string varMessage = objDServ.udfnGetMessages(94);
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
        private void BtnAdd_Leave(object sender, EventArgs e)
        {
            try
            {
                btnAdd.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpinvoicedate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpinvoicedate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpinvoicedate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpinvoicedate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Dpinvoicedate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtInvoiceno.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceamt_Enter(object sender, EventArgs e)
        {
            try
            {
                txtInvoiceamt.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceamt_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbPONo.Focus();
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
                //if (txtProductName.Text == "")
                //{
                //    errPO.SetError(txtProductName, "Please enter product");
                //    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpProduct.ShowAlways = true;
                //    tpProduct.Show("Please enter product.", txtProductName, 5000);
                //}
                //else
                //{
                errGRNDetails.Clear();
                txtProductName.BackColor = Color.White;
                tpProduct.Active = false;
                //}
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
                    txtmrprate.Focus();
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
                            objDs = objspdservice.udfnMaster(15, 0, 0, dpGrnDate.Text, "", Convert.ToInt32(lblProductcode.Text), "", 0);
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
                txtmrprate.Focus();
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
                    objMR_Product.ParaSupplierId =Convert.ToInt32( lblSupplierCode.Text);
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

        public void udfnsupplierLoad()
        {
            try
            {
                if (lblSupplierCode.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
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
                        }
                        if (objDs.Tables[7].Rows.Count > 0)
                        {
                            varDamage = objDs.Tables[7].Rows[0]["DAMAGE"].ToString();
                            varReturnDC = objDs.Tables[7].Rows[0]["RETURNDC"].ToString();
                        }
                        if (objDs.Tables[5].Rows.Count > 0)
                        {
                            grdPODetails.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[5].Rows.Count; i++)
                            {
                                grdPODetails.Rows.Add(objDs.Tables[5].Rows[i]["PO_No"].ToString(),
                                objDs.Tables[5].Rows[i]["PO_Date"].ToString(), objDs.Tables[5].Rows[i]["QTY"].ToString(), objDs.Tables[5].Rows[i]["PO_Final_STSID"].ToString(), objDs.Tables[5].Rows[i]["POID"].ToString()
                                );
                            }
                            DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                            GrdPODetails_DataBindingComplete(grdPODetails, args);
                        }
                        else
                        {
                            grdPODetails.Rows.Clear();
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
                if (varReturnDC == "0")
                {
                    btnDC.Enabled = false;
                }
                else
                {
                    btnDC.Enabled = true;
                }
                if (varDamage == "0")
                {
                    btnDamage.Enabled = false;
                }
                else
                {
                    btnDamage.Enabled = true;
                }
            }
        }
        public void udfnEditLoad()
        {
            try
            {
                if (pbGRNId != "0")
                {
                    SPDataService objdserv = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objdserv.udfnGrnListLoad(2, Convert.ToInt32(pbSupplierId), 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0, "", "", 0);
                    objdserv.CloseConnection();


                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                cmbConcern.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_COMID"]);
                                dpGrnDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Date"]);
                                txtgrnno.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_No"]);
                                txtSupplier.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SUPPLIER"]);
                                lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_SPID"]);
                                cmbOrderType.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_OrderType"]);
                                lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_SPSCID"]);
                                dpinvoicedate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceDate"]);
                                txtInvoiceno.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceNo"]);
                                txtInvoiceamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceAmnt"]);
                                udfnsupplierLoad();
                                LV_Supplier.Visible = false;
                                cmbConcern.Enabled = false;
                                dpGrnDate.Enabled = false;
                                txtSupplier.Enabled = false;
                                cmbOrderType.Enabled = false;
                                if (Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "23" || Convert.ToString(objDs.Tables[0].Rows[0]["STSID"]) == "24")
                                {
                                    chkCompleted.Enabled = false;
                                    chkCompleted.Checked = true;
                                }
                                else
                                {
                                    chkCompleted.Enabled = true;
                                }
                                if (Convert.ToInt32(txtInvoiceamt.Text) >= 25000)
                                {
                                    if (chkCompleted.Enabled == false)
                                    {
                                        btnVerify1.Enabled = true;
                                    }
                                }
                                else
                                {
                                    btnVerify1.Enabled = false;
                                    btnVerify2.Enabled = false;
                                }
                            }
                            if (objDs.Tables[3].Rows.Count != 0)
                            {
                                grdGrnlist.Rows.Clear();
                                for (int i = 0; i < objDs.Tables[3].Rows.Count; i++)
                                {
                                    lblNoRecordsFound.Visible = false;
                                    grdGrnlist.Rows.Add(grdGrnlist.Rows.Count + 1, Convert.ToString(objDs.Tables[3].Rows[i]["PONO"])
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["PICODE"]), Convert.ToString(objDs.Tables[3].Rows[i]["PENAME"])
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["PTNAME"]), Convert.ToString(objDs.Tables[3].Rows[i]["UNIT"])
                                    , "", "", Convert.ToString(objDs.Tables[3].Rows[i]["PRODUCTEXP"]), "", "", Convert.ToString(objDs.Tables[3].Rows[i]["BATCHDate"]),
                                    Convert.ToString(objDs.Tables[3].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[3].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[3].Rows[i]["POID"])
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["BATCHNO"]), Convert.ToString(objDs.Tables[3].Rows[i]["Batchnogeneration"])
                                    , Convert.ToString(objDs.Tables[3].Rows[i]["PR_ShelfLife"])
                                    );
                                }
                                DataGridViewBindingCompleteEventArgs args2 = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                GrdGrnlist_DataBindingComplete(grdGrnlist, args2);
                            }

                            if (objDs.Tables[4].Rows.Count != 0)
                            {
                                txtTotalpro.Text = Convert.ToString(objDs.Tables[4].Rows[0]["Productcount"]);
                            }
                            if (objDs.Tables[5].Rows.Count != 0)
                            {
                                if (Convert.ToString(objDs.Tables[5].Rows[0]["VERIFIED1"]) != "")
                                {
                                    lblVerified1.Text = Convert.ToString(objDs.Tables[5].Rows[0]["VERIFIED1"]);
                                    lblVerifyDateTime.Text = Convert.ToString(objDs.Tables[5].Rows[0]["VERIFIEDON1"]);
                                    btnVerify1.Enabled = false;
                                    btnVerify2.Enabled = true;
                                    btnDC.Enabled = false;
                                    gpAddrow.Enabled = false;
                                    grdGrnlist.Columns["clmRemove"].Visible = false;
                                }
                                else
                                {
                                    gpAddrow.Enabled = true;
                                }
                            }
                            else
                            {
                                btnVerify1.Enabled = true;
                                btnVerify2.Enabled = true;
                                gpAddrow.Enabled = true;
                            }
                            if (objDs.Tables[6].Rows.Count != 0)
                            {
                                if (Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIED2"]) != "")
                                {
                                    lblVerified2.Text = Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIED2"]);
                                    lblVerifyDateTime2.Text = Convert.ToString(objDs.Tables[6].Rows[0]["VERIFIEDON2"]);
                                    btnVerify1.Enabled = false;
                                    btnVerify2.Enabled = false;
                                }
                            }
                            if (objDs.Tables[7].Rows.Count != 0)
                            {
                                grdReurnDC.Rows.Clear();
                                for (int i = 0; i < objDs.Tables[7].Rows.Count; i++)
                                {
                                    grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[7].Rows[i]["DCNO"]), Convert.ToString(objDs.Tables[7].Rows[i]["DCDATE"]),
                                    Convert.ToString(objDs.Tables[7].Rows[i]["PRCOUNT"]), Convert.ToString(objDs.Tables[7].Rows[i]["DCVALUE"]), Convert.ToString(objDs.Tables[7].Rows[i]["ID"]));
                                }
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
    }
}
