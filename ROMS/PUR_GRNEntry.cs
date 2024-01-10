using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class PUR_GRNEntry : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        byte[] varobjBarCodeByte;
        private ToolTip tpInvNo = new ToolTip();
        private ToolTip tpordertype = new ToolTip();
        private ToolTip tpinvamt = new ToolTip();
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        public string varbrandcode, varpendingPOID = "0", pbSupplierpend = "0", varReturnDC = "0", varDamage = "0", pbPONO = "0", varSupplierName = "", pbSupplierId = "0", pbScheduleid = "0", pbGRNId = "0", pbGRNSTS = "0";
        public string pbFormStatus, dcid = "0", varflag = "0", varUserID = "0", GrnUpdatevalue="0";
        public int varCloseFlag = 0, varGrnId = 0, VarPrevSupplierid = 0;
        public PUR_GRNEntry()
        {
            InitializeComponent();
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

                this.Close();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                MainForm.objPUR_GRNDetailsList.grdGRNList.ClearSelection();
            }
        }

        private void PUR_GRNEntry_Load(object sender, EventArgs e)
        {
            try
            {
                btnDC.Enabled = false;
                this.ActiveControl = txtSupplier;
                udfnDropdownLoad();
                udfnUnitListGrid();
                udfnEditLoad();
                udfnDateSet();
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
                dpGRNDate.MinDate = MainForm.pbFYStartDate;
                dpGRNDate.MaxDate = MainForm.pbCurrentDate;
                dpinvoicedate.MinDate = MainForm.pbFYStartDate;
                dpinvoicedate.MaxDate = MainForm.pbCurrentDate;
                //SPDataService objDServ = new SPDataService();
                //DataSet objd = new DataSet();
                //objd = objDServ.udfnMaster(4, 6, 0,"","",0, "",0);
                //if (objd.Tables[1].Rows.Count != 0)
                //{
                //    DateTime varmindate = DateTime.ParseExact(Convert.ToString(objd.Tables[1].Rows[0]["MinToday"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //    dpGRNDate.MinDate = varmindate;
                //    dpinvoicedate.MinDate = varmindate;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnUnitListGrid()
        {
            try
            {
                DataSet objDs = new DataSet();
                SPDataService objspdservice = new SPDataService();
                objDs = objspdservice.udfnGrnListLoad(0, 0, 0, 0, 0, "", "", 0, 0, 0, "", "", 0,0);
                objspdservice.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdUnitList.Rows.Add(objDs.Tables[0].Rows[i]["NAME"].ToString(), objDs.Tables[0].Rows[i]["VALUE"].ToString(), objDs.Tables[0].Rows[i]["ID"].ToString());
                            }
                            grdUnitList.Rows[grdUnitList.RowCount - 1].DefaultCellStyle.BackColor = Color.SlateGray;
                            grdUnitList.Rows[grdUnitList.RowCount - 1].DefaultCellStyle.ForeColor = Color.White;
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

        public void udfnDropdownLoad()
        {
            try
            {
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (16 ) OR MSTID  IN (-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbOrderType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
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
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
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
                    errGRN.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    errGRN.Clear();
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
                    dpGRNDate.Focus();
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
                udfnvoucherload();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnvoucherload()
        {
            try
            {
                if (pbGRNId == "0")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpGRNDate.Text + "',103)");
                        varResult = objspdservice.udfngetPONO("39", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] parts = varResult.Split('~');
                        string grnno = parts[0];
                        if (grnno != "")
                        {
                            txtgrnno.Text = grnno;
                        }
                        else
                        {
                            udfnvoucheradd();
                        }
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


        public void udfnvoucheradd()
        {
            try
            {
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(75);
                objDServ.CloseConnection();
                txtgrnno.Text = "";
                DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //MainForm.objCP_Settings = new CP_Settings();
                    //MainForm.objCP_Settings.MdiParent = this.ParentForm;
                    //MainForm.objCP_Settings.Show();
                    //this.Close();

                    MainForm.objCP_Settings = new CP_Settings();
                    MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                    MainForm.objCP_Settings.varValues = Convert.ToString(44);
                    MainForm.objCP_Settings.MdiParent = this.ParentForm;
                    MainForm.objCP_Settings.Show();
                    this.Close();
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
                if (txtSupplier.Text == "")
                {
                    errGRN.SetError(txtSupplier, "Please enter supplier");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                }
                else
                {
                    errGRN.Clear();
                    txtSupplier.BackColor = Color.White;
                    tpSuppliername.Active = false;
                }
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
                                    string[] row = { objDs.Tables[0].Rows[i]["SP_Name"].ToString(), objDs.Tables[0].Rows[i]["SPID"].ToString(), objDs.Tables[0].Rows[i]["SPSCID"].ToString(), objDs.Tables[0].Rows[i]["SupplierName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    LV_Supplier.Items.Add(objList);
                                }
                                LV_Supplier.Visible = true;
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

        private void TxtInvoiceno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceno.Text == "")
                {
                    errGRN.SetError(txtInvoiceno, "Please enter invoice No.");
                    txtInvoiceno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvNo.ShowAlways = true;
                    tpInvNo.Show("Please enter invoice No.", txtInvoiceno, 5000);
                }
                else
                {
                    errGRN.Clear();
                    txtInvoiceno.BackColor = Color.White;
                    tpInvNo.Active = false;
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

        private void CmbOrderType_Enter(object sender, EventArgs e)
        {
            try
            {
                LV_Supplier.Visible = false;
                cmbOrderType.BackColor = Color.LemonChiffon;
                if (Convert.ToString(txtSupplier.Text) != "")
                {
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 23;
                    objMR_Supplier.paraSupplierName = txtSupplier.Text.Trim();
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
                        errGRN.SetError(txtSupplier, "Invalid supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        ClearSupplier();

                    }
                    else
                    {
                        errGRN.Clear();
                        lblSupplierCode.Text = values[0];
                        lblschedule.Text = values[1];
                        txtSupplier.BackColor = Color.White;
                        if (VarPrevSupplierid != Convert.ToInt32(lblSupplierCode.Text))
                        {
                            udfnsupplierLoad();
                        }
                    }
                    VarPrevSupplierid = Convert.ToInt32(lblSupplierCode.Text);
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

                txtSalesManMobile.Text = "";
                txtSalesManName.Text = "";
                txtSalesManwhatsapp.Text = "";
                grdPODetails.Rows.Clear();
                grdReurnDC.Rows.Clear();
                grdRepDetails.DataSource = null;
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
                    if (btnViewPO.Visible == true)
                    {
                        btnViewPO.Focus();
                    }
                    else
                    {
                        dpinvoicedate.Focus();
                    }
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

        private void CmbOrderType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbOrderType.SelectedValue) == "-1")
                {
                    errGRN.SetError(cmbOrderType, "Please select order type");
                    cmbOrderType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpordertype.ShowAlways = true;
                    tpordertype.Show("Please select order type", cmbOrderType, 5000);
                }
                else
                {
                    errGRN.Clear();
                    cmbOrderType.BackColor = Color.White;
                    tpordertype.Active = false;
                }
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
                    varSupplierName = selectedItem.SubItems[3].Text;
                    udfnsupplierLoad();
                }
                if (Convert.ToInt32(cmbConcern.SelectedValue) == -1)
                {
                    cmbConcern.Focus();
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

        private void TxtInvoiceamt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtInvoiceamt.Text) == "")
                {
                    errGRN.SetError(txtInvoiceamt, "Please enter invoice amount");
                    txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpinvamt.ShowAlways = true;
                    tpinvamt.Show("Please enter invoice amount", txtInvoiceamt, 5000);
                }
                else
                {
                    errGRN.Clear();
                    txtInvoiceamt.BackColor = Color.White;
                    tpinvamt.Active = false;
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
                    txtLoadingCharge.Focus();
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
                grdPODetails.Rows.Clear();
                grdReurnDC.Rows.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    MR_Supplier objMR_Supplier = new MR_Supplier();
                    objMR_Supplier.ViewType = 16;
                    objMR_Supplier.paraSupplierid = Convert.ToInt32(lblSupplierCode.Text);
                    objMR_Supplier.paraSupplierScheduleid = Convert.ToInt32(lblschedule.Text);
                    objMR_Supplier.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);

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
                            lblSupplierOrderpolicy.Text = "Return Policy :" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString();
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            txtSalesManMobile.Text = objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString();
                            txtSalesManName.Text = objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString();
                            txtSalesManwhatsapp.Text = objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString();
                        }
                        if (objDs.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                            {
                                grdRepDetails.DataSource = objDs.Tables[2];
                                grdRepDetails.Columns["S.No."].Width = 40;
                                grdRepDetails.Columns["Rep Name"].Width = 150;
                                grdRepDetails.Columns["Brand"].Width = 150;
                                grdRepDetails.Columns["Phone No."].Width = 90;
                                grdRepDetails.Columns["WhatsApp No."].Width = 90;
                                grdRepDetails.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            }
                        }

                        //if (objDs.Tables[5].Rows.Count > 0)
                        //{
                        //    varpendingPOID = "0";
                        //    grdPODetails.Rows.Clear();
                        //    for (int i = 0; i < objDs.Tables[5].Rows.Count; i++)
                        //    {
                        //        lblFinishedNoRecord.Visible = false;
                        //        grdPODetails.Rows.Add(objDs.Tables[5].Rows[i]["SINO"].ToString(), objDs.Tables[5].Rows[i]["PO_No"].ToString(),
                        //        objDs.Tables[5].Rows[i]["PO_Date"].ToString(), objDs.Tables[5].Rows[i]["QTY"].ToString(), objDs.Tables[5].Rows[i]["PO_Final_STSID"].ToString()
                        //        );
                        //        pbSupplierpend = "1";
                        //    }
                        //    varpendingPOID = objDs.Tables[5].Rows[0]["POID"].ToString();
                        //}
                        //else
                        //{
                        //    lblFinishedNoRecord.Visible = true;
                        //    grdPODetails.Rows.Clear();
                        //}

                        if (objDs.Tables[7].Rows.Count > 0)
                        {
                            varDamage = objDs.Tables[7].Rows[0]["DAMAGE"].ToString();
                            varReturnDC = objDs.Tables[7].Rows[0]["RETURNDC"].ToString();
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


        private void CmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbOrderType.SelectedValue) == 53)
                {
                    if (pbGRNId == "0")
                    {
                        udfnPendingPOLoad();
                        btnViewPO.Visible = true;
                    }
                }
                else
                {
                    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                    MainForm.objPUR_GRNOrderType.Close();
                    btnViewPO.Visible = false;
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
            MainForm.objPUR_GRNOrderType.ShowDialog();
        }

        private void GrdPODetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPODetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmpo":
                            string cellPOValue = Convert.ToString(grdPODetails.Rows[e.RowIndex].Cells["poid"].Value);
                            MainForm.objPUR_POProducts = new PUR_POProducts();
                            MainForm.objPUR_POProducts.pbPoid = cellPOValue;
                            MainForm.objPUR_POProducts.pbSupplierCode = lblSupplierCode.Text;
                            MainForm.objPUR_POProducts.pbScheduleCode = lblschedule.Text;
                            MainForm.objPUR_POProducts.ShowDialog();
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

        private void GrdUnitList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                int targetRowIndex = 3; // Replace with the desired row index
                int targetColumnIndex = 1; // Replace with the desired column index

                if (e.RowIndex == targetRowIndex && e.ColumnIndex == targetColumnIndex)
                {
                    // grdUnitList.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                    grdUnitList.Rows[e.RowIndex].ReadOnly = true;
                    grdUnitList.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                    grdUnitList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    //e.CellStyle.BackColor = System.Drawing.Color.LightGray;
                    //e.CellStyle.ForeColor = System.Drawing.Color.Black;
                }
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void udfnSave()
        {
            try
            {
                string varPurchaseDC = "0";
                bool VarErrorFlag = false;
                string varSupplierId = "0";
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errGRN.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select company", cmbConcern, 5000);
                    VarErrorFlag = true;
                }
                if (txtSupplier.Text == "")
                {
                    errGRN.SetError(txtSupplier, "Please enter supplier");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                    VarErrorFlag = true;
                }

                if (txtInvoiceno.Text == "")
                {
                    errGRN.SetError(txtInvoiceno, "Please enter invoice No.");
                    txtInvoiceno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvNo.ShowAlways = true;
                    tpInvNo.Show("Please enter invoice No.", txtInvoiceno, 5000);
                    VarErrorFlag = true;
                }
                if (Convert.ToString(cmbOrderType.SelectedValue) == "-1")
                {
                    errGRN.SetError(cmbOrderType, "Please select order type");
                    cmbOrderType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpordertype.ShowAlways = true;
                    tpordertype.Show("Please select order type", cmbOrderType, 5000);
                    VarErrorFlag = true;
                }
                if (Convert.ToString(txtInvoiceamt.Text) == "")
                {
                    errGRN.SetError(txtInvoiceamt, "Please enter invoice amount");
                    txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpinvamt.ShowAlways = true;
                    tpinvamt.Show("Please enter invoice amount", txtInvoiceamt, 5000);
                    VarErrorFlag = true;
                }
                if (btnSave.Text != "Update && Print")
                {
                    if (Convert.ToString(txtSupplier.Text) != "")
                    {
                        string[] values = new string[0];
                        MR_Supplier objMR_Supplier = new MR_Supplier();
                        objMR_Supplier.ViewType = 23;
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
                            errGRN.SetError(txtSupplier, "Invalid supplier");
                            txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpSuppliername.ShowAlways = true;
                            tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                            lblSupplierCode.Text = "0";
                            lblschedule.Text = "0";
                            VarErrorFlag = true;
                        }
                        else
                        {
                            errGRN.Clear();
                            lblSupplierCode.Text = values[0];
                            lblschedule.Text = values[1];
                            txtSupplier.BackColor = Color.White;
                        }
                    }
                }
                if (Convert.ToInt32(cmbOrderType.SelectedValue) == 53)
                {
                    if (grdPODetails.Rows.Count == 0)
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(82);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        VarErrorFlag = true;
                    }
                }
                if (Convert.ToString(txtgrnno.Text) == "")
                {
                    udfnvoucheradd();
                    VarErrorFlag = true;
                }
                if (VarErrorFlag == false)
                {
                    dcid = "0";
                    for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                    {
                        if (dcid == "0")
                        {
                            dcid = Convert.ToString(grdReurnDC.Rows[i].Cells["clmDCID"].Value);
                        }
                        else
                        {
                            dcid = dcid + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["clmDCID"].Value);
                        }
                    }
                    string varSkip = "0", varDC = "0";
                    udfntooltiphide();
                    DialogResult result1=DialogResult.Yes;
                    SPDataService objDServ = new SPDataService();
                    DataSet objDs = new DataSet();

                    TRN_ReturnDC objTRN_PurchaseReturnDC = new TRN_ReturnDC();
                    objTRN_PurchaseReturnDC.paraViewType = 6;
                    objTRN_PurchaseReturnDC.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRN_PurchaseReturnDC.paraIPAddress = MainForm.pbIpAddress;
                    objTRN_PurchaseReturnDC.ParaSupplierId = Convert.ToInt32(lblSupplierCode.Text);
                    objTRN_PurchaseReturnDC.ParaScheduleID = Convert.ToInt32(lblschedule.Text);
                    objTRN_PurchaseReturnDC.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRN_PurchaseReturnDC.paraDCIDs = Convert.ToString(dcid);
                    objDs = objDServ.udfnReturnDC(objTRN_PurchaseReturnDC);
                    objDServ.CloseConnection();
                    //objDs = objDServ.udfnReturnDC(6, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 
                    //    Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, Convert.ToString(dcid));
                    //objDServ.CloseConnection();
                    if (objDs.Tables[0].Rows.Count != 0)
                    {
                        varDC = "1";
                    }
                    if (varReturnDC != "0" && varDC == "1")
                    {
                        if (Convert.ToString(grdReurnDC.Rows.Count) != varReturnDC)
                        { 
                            string varMessage = objDServ.udfnGetMessages(102);
                            objDServ.CloseConnection();
                            varSkip = "1";
                            result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                    else
                    {
                        result1 = DialogResult.Yes;
                    }

                    if (result1 == DialogResult.Yes)
                    {
                        MainForm.objPUR_GRNApprovalVerify = new PUR_GRNApprovalVerify();
                        MainForm.objPUR_GRNApprovalVerify.varTrnType = 2;
                        MainForm.objPUR_GRNApprovalVerify.ShowDialog();
                        if (varflag == "1")
                        {
                            if (lblSupplierCode.Text != "0" && lblschedule.Text != "0")
                            {
                                for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                                {
                                    if (varPurchaseDC == "0")
                                    {
                                        varPurchaseDC = Convert.ToString(grdReurnDC.Rows[i].Cells["clmDCID"].Value);
                                    }
                                    else
                                    {
                                        varPurchaseDC = varPurchaseDC + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["clmDCID"].Value);
                                    }
                                }
                                string result = "", varpakage = "0", varorginator = "GRN Create";
                                int varviewtype = 0;
                                if (btnSave.Text == "Update && Print")
                                {
                                    varviewtype = 1;
                                    varorginator = "GRN Update";
                                }
                                if (varSkip == "1")
                                {
                                    varorginator = "GRN DC Skipped";
                                }
                                SPDataService objspdservice = new SPDataService();
                                DataTable objGrnPO = new DataTable();
                                objGrnPO.TableName = "TRN_GRN_PO";
                                objGrnPO.Columns.Add("GRNPO_POID", typeof(int));
                                objGrnPO.Columns.Add("GRNPO_PODate", typeof(string));
                                objGrnPO.Columns.Add("GRNPO_PONo", typeof(string));
                                objGrnPO.Columns.Add("GRNPO_TotalPros", typeof(int));
                                objGrnPO = udfnGrnPO();

                                for (int i = 0; i < grdUnitList.Rows.Count; i++)
                                {
                                    if (varpakage == "0")
                                    {
                                        varpakage = Convert.ToString(grdUnitList.Rows[i].Cells["clmQty"].Value) + '-' + Convert.ToString(grdUnitList.Rows[i].Cells["id"].Value);
                                    }
                                    else
                                    {
                                        varpakage = varpakage + '|' + Convert.ToString(grdUnitList.Rows[i].Cells["clmQty"].Value) + '-' + Convert.ToString(grdUnitList.Rows[i].Cells["id"].Value);
                                    }
                                } //objGrnP
                                varGrnId = Convert.ToInt32(pbGRNId); 

                                TRN_GRN objTRNS_GRN = new TRN_GRN();
                                objTRNS_GRN.ViewType = varviewtype;
                                objTRNS_GRN.ParaGRNID = varGrnId;
                                objTRNS_GRN.paraCompanyId = Convert.ToInt32(cmbConcern.SelectedValue);
                                objTRNS_GRN.paraSupplierID = Convert.ToInt32(lblSupplierCode.Text);
                                objTRNS_GRN.paraScheduleID = Convert.ToInt32(lblschedule.Text);
                                objTRNS_GRN.paraOriginator = varorginator;
                                objTRNS_GRN.paraGRNDate = dpGRNDate.Text;
                                objTRNS_GRN.paraINVDate = dpinvoicedate.Text;
                                objTRNS_GRN.paraINVNo = txtInvoiceno.Text;
                                objTRNS_GRN.ParaInvAmt = Convert.ToDecimal(txtInvoiceamt.Text);
                                objTRNS_GRN.ParaLoadingCharge = txtLoadingCharge.Text;
                                objTRNS_GRN.ParaFrightCharge = txtFrieghtamount.Text;
                                objTRNS_GRN.paraOrderType = Convert.ToInt32(cmbOrderType.SelectedValue);
                                objTRNS_GRN.ParaTRN_GRN_PO = objGrnPO;
                                objTRNS_GRN.ParaPurchaseDC = varPurchaseDC;
                                objTRNS_GRN.paraPAckage = varpakage;
                                objTRNS_GRN.paraUserID = Convert.ToInt32(varUserID);
                                objTRNS_GRN.paraSkipped = varSkip; 
                                result = objspdservice.udfnGRNEntry(objTRNS_GRN);
                                objspdservice.CloseConnection();
                                string[] varvalue = result.Split('~');
                                if (varvalue[0] == "3")
                                {
                                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (pbGRNId =="0")
                                    {
                                        GrnUpdatevalue = varvalue[2];
                                        string varQrcode= varvalue[3];
                                        var varImgMemoryStream = new MemoryStream();
                                        QrcodeImg.Text = varQrcode;
                                        QrcodeImg.Image.Save(varImgMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
                                        varobjBarCodeByte = varImgMemoryStream.GetBuffer();
                                        objTRNS_GRN.ViewType = 5;
                                        objTRNS_GRN.ParaGRNID = Convert.ToInt32(GrnUpdatevalue);
                                        objTRNS_GRN.paraQrimg = (varobjBarCodeByte);
                                        result = objspdservice.udfnGRNEntry(objTRNS_GRN);
                                        objspdservice.CloseConnection();
                                    }
                                    else
                                    {
                                        GrnUpdatevalue = Convert.ToString(pbGRNId);
                                    }
                                    this.ActiveControl = txtSupplier;
                                    MainForm.objPUR_GRNDetailsList.udfnListLoad();
                                    varCloseFlag = 1; 
                                    string varMessage = objDServ.udfnGetMessages(87);
                                    objDServ.CloseConnection();
                                    result1 = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result1 == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            string varHeader = "";
                                            CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                            objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                            objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_LP_GRN_QRCode.rpt"); 
                                            objBillreport.SetParameterValue("paraGRNID", GrnUpdatevalue); 
                                            objValidation.CrySqlConnection(objBillreport);

                                            MainForm.objReportLoad = new ReportLoad();
                                            MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                            MainForm.objReportLoad.Text = varHeader;
                                            MainForm.objReportLoad.ShowDialog();
                                        }
                                        catch (Exception ex)
                                        {
                                            objError = new DataError();
                                            objError.WriteFile(ex);
                                        }
                                        finally
                                        {
                                        }
                                        udfnclose();
                                    }
                                    else
                                    {
                                        udfnclose();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                this.ActiveControl = txtSupplier;
                            }
                        }
                    }
                    else
                    {
                        udfnDcADD();
                    }
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

        public DataTable udfnGrnPO()
        {

            DataTable objGrnPO = new DataTable();
            try
            {
                objGrnPO.TableName = "TRN_GRN_PO";
                objGrnPO.Columns.Add("GRNPO_POID", typeof(int));
                objGrnPO.Columns.Add("GRNPO_PODate", typeof(string));
                objGrnPO.Columns.Add("GRNPO_PONo", typeof(string));
                objGrnPO.Columns.Add("GRNPO_TotalPros", typeof(int));
                for (int i = 0; i < grdPODetails.Rows.Count; i++)
                {
                    DataService objDser = new DataService();
                    objGrnPO.Rows.Add(Convert.ToString(grdPODetails.Rows[i].Cells["poid"].Value), Convert.ToString(grdPODetails.Rows[i].Cells["clmPODate"].Value)
                    , Convert.ToString(grdPODetails.Rows[i].Cells["clmpo"].Value), Convert.ToInt32(grdPODetails.Rows[i].Cells["clmtpro"].Value));
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return objGrnPO;
        }
        public void udfntooltiphide()
        {
            try
            {
                errGRN.Clear();
                cmbConcern.BackColor = Color.White;
                tpConcern.Active = false;
                txtSupplier.BackColor = Color.White;
                tpSuppliername.Active = false;
                txtInvoiceno.BackColor = Color.White;
                tpInvNo.Active = false;
                cmbOrderType.BackColor = Color.White;
                tpordertype.Active = false;
                txtInvoiceamt.BackColor = Color.White;
                tpinvamt.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdUnitList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex != -1)
            //    {
            //        switch (grdUnitList.Columns[e.ColumnIndex].Name)
            //        {
            //            case "clmQty":
            //                udfnTotalUnitGrid();
            //                break;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);

            //}
        }

        private void DpPlanDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpGRNDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpPlanDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpGRNDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnViewPO_Click(object sender, EventArgs e)
        {
            try
            {
                udfnPendingPOLoad();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdPODetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdPODetails.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdPODetails.Rows.RemoveAt(this.grdPODetails.SelectedCells[0].RowIndex);
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
                if (grdPODetails.Rows.Count > 0)
                {
                    lblFinishedNoRecord.Visible = false;
                }
                else
                {
                    lblFinishedNoRecord.Visible = true;
                }
            }
        }

        private void BtnDC_Click(object sender, EventArgs e)
        {
            try
            {
                udfnDcADD();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnDcADD()
        {
            try
            {
                //MainForm.objPUR_PODamagedView = new PUR_PODamagedView();
                //MainForm.objPUR_PODamagedView.varMasterType = "2";
                //MainForm.objPUR_PODamagedView.ShowDialog();
                dcid = "0";
                for (int i = 0; i < grdReurnDC.Rows.Count; i++)
                {
                    if (dcid == "0")
                    {
                        dcid = Convert.ToString(grdReurnDC.Rows[i].Cells["clmDCID"].Value);
                    }
                    else
                    {
                        dcid = dcid + ',' + Convert.ToString(grdReurnDC.Rows[i].Cells["clmDCID"].Value);
                    }
                }
                MainForm.objINV_GRNPODamaged = new INV_GRNPODamaged();
                MainForm.objINV_GRNPODamaged.varMasterType = "2";
                MainForm.objINV_GRNPODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
            finally
            {
                if (grdReurnDC.Rows.Count > 0)
                {
                    lblDCFinishedNoRecord.Visible = false;
                }
                else
                {
                    lblDCFinishedNoRecord.Visible = true;
                }
            }
        }
        private void GrdUnitList_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex != -1)
            //    {
            //        switch (grdUnitList.Columns[e.ColumnIndex].Name)
            //        {
            //            case "clmQty":
            //                udfnTotalUnitGrid(); 
            //            break;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);

            //}
        }
        public void udfnCalculateTotal()
        {
            int varTotal = 0;
            try
            {
                for (int i = 0; i < grdUnitList.RowCount - 1; i++)
                {
                    varTotal += Convert.ToInt32(grdUnitList.Rows[i].Cells["clmQty"].Value);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdUnitList.Rows[grdUnitList.RowCount - 1].Cells["clmQty"].Value = Convert.ToString(varTotal);
            }
        }

        private void TxtLoadingCharge_Enter(object sender, EventArgs e)
        {
            try { txtLoadingCharge.BackColor = Color.LemonChiffon; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLoadingCharge_Leave(object sender, EventArgs e)
        {
            try { txtLoadingCharge.BackColor = Color.White; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtLoadingCharge_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtFrieghtamount.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtFrieghtamount_Enter(object sender, EventArgs e)
        {
            try { txtFrieghtamount.BackColor = Color.LemonChiffon; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtFrieghtamount_Leave(object sender, EventArgs e)
        {
            try { txtFrieghtamount.BackColor = Color.White; }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtFrieghtamount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
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

        private void TxtLoadingCharge_KeyPress(object sender, KeyPressEventArgs e)
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdReurnDC_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdReurnDC.Columns[e.ColumnIndex].Name)
                    {
                        case "InvoiceNo":
                            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                            {
                                string cellPOValue = Convert.ToString(grdReurnDC.Rows[e.RowIndex].Cells["clmDCID"].Value);
                                MainForm.objPUR_PurchaseOrderDamage = new PUR_PurchaseOrderDamage();
                                MainForm.objPUR_PurchaseOrderDamage.varMasterType = "2";
                                MainForm.objPUR_PurchaseOrderDamage.varDcCode = Convert.ToString(cellPOValue);
                                MainForm.objPUR_PurchaseOrderDamage.ShowDialog();
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

        private void TxtFrieghtamount_KeyPress(object sender, KeyPressEventArgs e)
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdUnitList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdUnitList.CurrentCell.ColumnIndex == 1)
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdReurnDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdReurnDC.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemoveDC":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdReurnDC.Rows.RemoveAt(this.grdReurnDC.SelectedCells[0].RowIndex);
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
                if (grdReurnDC.Rows.Count > 0)
                {
                    lblDCFinishedNoRecord.Visible = false;
                }
                else
                {
                    lblDCFinishedNoRecord.Visible = true;
                }
            }
        }

        private void udfnHandleKeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;  // Disallow the character
                }
                TextBox vartb = sender as TextBox;
                if (vartb.Text.Length >= 3 && !char.IsControl(e.KeyChar))
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

        private void PUR_GRNEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (varCloseFlag == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                //else
                //{
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                MainForm.objPUR_GRNDetailsList.grdGRNList.ClearSelection();
            }
        }

        private void DpGRNDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                udfnvoucherload();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtInvoiceamt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                //{
                //    e.Handled = true;
                //}
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                // Allow only one decimal point
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
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

        private void GrdUnitList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdUnitList.IsCurrentCellDirty)
                {
                    grdUnitList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                udfnCalculateTotal();
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
                MainForm.objPUR_PODamaged.varMasterType = "2";
                MainForm.objPUR_PODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void DpPlanDate_KeyDown(object sender, KeyEventArgs e)
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

        private void PUR_GRNEntry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    udfnSave();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
                    objDs = objdserv.udfnGrnListLoad(2, 0, 0, 0, 0, "", "", Convert.ToInt32(pbGRNId), 0, 0,"","",0,0);
                    objdserv.CloseConnection();
                    btnSave.Text = "Update && Print"; 
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                cmbConcern.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_COMID"]);
                                dpGRNDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_Date"]);
                                txtgrnno.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_No"]);
                                txtSupplier.Text = Convert.ToString(objDs.Tables[0].Rows[0]["SUPPLIER"]);
                                lblSupplierCode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_SPID"]);
                                cmbOrderType.SelectedValue = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_OrderType"]);
                                lblschedule.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_SPSCID"]);
                                dpinvoicedate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceDate"]);
                                txtInvoiceno.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceNo"]);
                                txtInvoiceamt.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_InvoiceAmnt"]);
                                txtLoadingCharge.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_LoadingCharges"]);
                                txtFrieghtamount.Text = Convert.ToString(objDs.Tables[0].Rows[0]["GRN_UnloadingCharges"]);
                                udfnsupplierLoad();
                                LV_Supplier.Visible = false;
                                cmbConcern.Enabled = false;
                                dpGRNDate.Enabled = false;
                                txtSupplier.Enabled = false;
                                cmbOrderType.Enabled = false; 
                                this.ActiveControl = dpinvoicedate;
                                if (pbGRNSTS == "24" || pbGRNSTS == "23")
                                {
                                    gpGRNEntry.Enabled = false;
                                    btnDC.Enabled = false;
                                    btnSave.Enabled = false;
                                    grdPODetails.Enabled = false;
                                    grdReurnDC.Enabled = false;
                                    grdRepDetails.Enabled = false;
                                    grdUnitList.Enabled = false; 
                                    grdPODetails.ClearSelection();
                                    grdReurnDC.ClearSelection();
                                    grdRepDetails.ClearSelection();
                                    grdUnitList.ClearSelection();
                                }
                                else
                                {
                                    gpGRNEntry.Enabled = true;
                                    btnDC.Enabled = true;
                                    btnSave.Enabled = true;
                                    grdPODetails.Enabled = true;
                                    grdReurnDC.Enabled = true;
                                    grdRepDetails.Enabled = true;
                                    grdUnitList.Enabled = true;
                                }
                            }
                            if (objDs.Tables[1].Rows.Count != 0)
                            {
                                grdUnitList.Rows.Clear();
                                for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                                {
                                    grdUnitList.Rows.Add(objDs.Tables[1].Rows[i]["NAME"].ToString(), objDs.Tables[1].Rows[i]["VALUE"].ToString(), objDs.Tables[1].Rows[i]["ID"].ToString());
                                }
                                grdUnitList.Rows[grdUnitList.RowCount - 1].DefaultCellStyle.BackColor = Color.SlateGray;
                                grdUnitList.Rows[grdUnitList.RowCount - 1].DefaultCellStyle.ForeColor = Color.White;
                            }
                            if (objDs.Tables[2].Rows.Count != 0)
                            {
                                lblFinishedNoRecord.Visible = false;
                                for (int i = 0; i < objDs.Tables[2].Rows.Count; i++)
                                {
                                    grdPODetails.Rows.Add(Convert.ToString(objDs.Tables[2].Rows[i]["PO.No"]), Convert.ToString(objDs.Tables[2].Rows[i]["PO Date"]), Convert.ToString(objDs.Tables[2].Rows[i]["Total Products"]), Convert.ToString(objDs.Tables[2].Rows[i]["POID"]));
                                }
                                grdPODetails.Columns["clmRemove"].Visible = false;
                            }
                            else
                            {
                                lblFinishedNoRecord.Visible = true;
                            }
                            if (objDs.Tables[7].Rows.Count != 0)
                            {
                                lblDCFinishedNoRecord.Visible = false;
                                grdReurnDC.Rows.Clear();
                                for (int i = 0; i < objDs.Tables[7].Rows.Count; i++)
                                {
                                   // grdReurnDC.Rows[i].Cells["clmRemoveDC"].Value = ""; 
                                    grdReurnDC.Rows.Add(Convert.ToString(objDs.Tables[7].Rows[i]["DCDATE"]), Convert.ToString(objDs.Tables[7].Rows[i]["DCNO"]),
                                    Convert.ToString(objDs.Tables[7].Rows[i]["PRCOUNT"]), Convert.ToString(objDs.Tables[7].Rows[i]["DCVALUE"]), Convert.ToString(objDs.Tables[7].Rows[i]["ID"]));
                                }
                                grdReurnDC.Columns["clmRemoveDC"].Visible = false;
                            }
                            else
                            {
                                lblDCFinishedNoRecord.Visible = true;
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
