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
    public partial class PUR_GRNEntry : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpInvNo = new ToolTip();
        private ToolTip tpordertype = new ToolTip();
        private ToolTip tpinvamt = new ToolTip();
        private ToolTip tpSuppliername = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        public string varbrandcode, varpendingPOID = "0", pbSupplierpend = "0", varReturnDC = "0", varDamage = "0", pbPONO = "0", varSupplierName = "";
        public string pbFormStatus;
        public int varCloseFlag = 0;
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
                if (varCloseFlag == 0)
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

        private void PUR_GRNEntry_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = cmbConcern;
                udfnDropdownLoad();
                udfnUnitListGrid();
                //grdUnitList.Rows.Add("Bag","");
                //grdUnitList.Rows.Add("Tin","");
                //grdUnitList.Rows.Add("Box","");
                //grdUnitList.Rows.Add("Excess","3");
                //grdUnitList.Rows.Add("Total","");
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
                DataService objdserv = new DataService();
                objDs = objdserv.GetDataset("SELECT MSTID,MST_DisplayText,'' AS VALUE FROM DEF_Master WHERE MST_TransactionID=27 UNION ALL SELECT 0,'Excess',(SELECT GS_GRNQty FROM MR_GeneralSettings) UNION ALL SELECT 1,'Total',(SELECT GS_GRNQty FROM MR_GeneralSettings) ");
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdUnitList.Rows.Add(objDs.Tables[0].Rows[i]["MST_DisplayText"].ToString() , objDs.Tables[0].Rows[i]["VALUE"].ToString() , objDs.Tables[0].Rows[i]["MSTID"].ToString() );
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
        private void udfnTotalUnitGrid()
        {
            try
            {
                double sum = 0;
                foreach (DataGridViewRow row in grdUnitList.Rows)
                {
                    if (!row.IsNewRow)  // ensure we aren't on the new row template
                    {
                        double cellValue;
                        if (double.TryParse(row.Cells[1].Value.ToString(), out cellValue))
                        {
                            sum += cellValue;
                        }
                    }
                } 
                if (grdUnitList.Rows.Count > 0) // Check to ensure there are rows
                {
                    DataGridViewRow lastRow = grdUnitList.Rows[grdUnitList.Rows.Count - 1];
                    int lastRowIndex = grdUnitList.Rows.Count - 1;
                    int lastColumnIndex = grdUnitList.Columns.Count - 2;
                    grdUnitList.Rows[lastRowIndex].Cells[lastColumnIndex].Value = sum;

                    //grdUnitList.columns
                    //lastRow.Cells["clmQty"].Value = sum;
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
                    txtSupplier.Focus();
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
                    string[] parts = varResult.Split('~');
                    string grnno = parts[0];
                    if (grnno != "")
                    {
                        txtgrnno.Text = grnno;
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(75);
                        objDServ.CloseConnection();
                        txtgrnno.Text = "";
                        DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MainForm.objCP_Settings = new CP_Settings();
                            MainForm.objCP_Settings.MdiParent = this.ParentForm;
                            MainForm.objCP_Settings.Show();
                            this.Close();
                        }
                    }
                }
                else
                {
                    txtgrnno.Text = "";
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
                    dpPlanDate.Focus();
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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(15, 0, 0, 0, 0, txtSupplier.Text, 0, 0, 0, "", 0, 0, 0, 0, 0, 0);
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
                    cmbOrderType.Focus();
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
                cmbOrderType.BackColor = Color.LemonChiffon;
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
                    txtInvoiceamt.Focus();
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
                    dpPlanDate.Focus();
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
                    grdUnitList.Focus();
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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(16, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, "", 0, 0, 0, "", 0, 0, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            lblSuppliername.Text = objDs.Tables[0].Rows[0]["NAME"].ToString() ;
                            lblSupplierCity.Text = objDs.Tables[0].Rows[0]["CITY"].ToString() ;
                            lblsupplierGST.Text = objDs.Tables[0].Rows[0]["GSTIN"].ToString() ;
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString() ;
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString() ;
                            lblSupplierOrderpolicy.Text = "Return Policy :" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString() ;
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            txtSalesManMobile.Text = objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString() ;
                            txtSalesManName.Text = objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString() ;
                            txtSalesManwhatsapp.Text = objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString() ;
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
                    udfnPendingPOLoad();
                    btnViewPO.Visible = true;
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

            }
        }

        public void udfnSave()
        {
            try
            {
                bool VarErrorFlag = true;
                int varSupplierId = 0;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errGRN.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select company", cmbConcern, 5000);
                    VarErrorFlag = false;
                }
                if (txtSupplier.Text == "")
                {
                    errGRN.SetError(txtSupplier, "Please enter supplier");
                    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSuppliername.ShowAlways = true;
                    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                    VarErrorFlag = false;
                }

                if (txtInvoiceno.Text == "")
                {
                    errGRN.SetError(txtInvoiceno, "Please enter invoice No.");
                    txtInvoiceno.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpInvNo.ShowAlways = true;
                    tpInvNo.Show("Please enter invoice No.", txtInvoiceno, 5000);
                    VarErrorFlag = false;
                }
                if (Convert.ToString(cmbOrderType.SelectedValue) == "-1")
                {
                    errGRN.SetError(cmbOrderType, "Please select order type");
                    cmbOrderType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpordertype.ShowAlways = true;
                    tpordertype.Show("Please select order type", cmbOrderType, 5000);
                    VarErrorFlag = false;
                }
                if (Convert.ToString(txtInvoiceamt.Text) == "")
                {
                    errGRN.SetError(txtInvoiceamt, "Please enter invoice amount");
                    txtInvoiceamt.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpinvamt.ShowAlways = true;
                    tpinvamt.Show("Please enter invoice amount", txtInvoiceamt, 5000);
                    VarErrorFlag = false;
                }
                if (Convert.ToString(txtSupplier.Text) != "")
                {
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(11, 0, 0, 0, 0, varSupplierName, 0, 0, 0, "", 0, 0, 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDsSupplierId != null)
                    {
                        if (objDsSupplierId.Tables.Count > 0)
                        {
                            if (objDsSupplierId.Tables[0].Rows.Count > 0)
                            {
                                varSupplierId = Convert.ToInt32(objDsSupplierId.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    if (varSupplierId == -1)
                    {
                        errGRN.SetError(txtSupplier, "Invalid supplier");
                        txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSuppliername.ShowAlways = true;
                        tpSuppliername.Show("Invalid supplier.", txtSupplier, 5000);
                        lblSupplierCode.Text = "0";
                        lblschedule.Text = "0";
                        VarErrorFlag = false;
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
                        VarErrorFlag = false;
                    }
                }
                if (VarErrorFlag == true)
                {
                    udfntooltiphide();

                    if (lblSupplierCode.Text != "0" && lblschedule.Text != "0")
                    {
                        string result = "", varorginator = "Po Create";
                        int varviewtype = 0;// GrnUpdate = varGrnId;
                        if (btnSave.Text == "Update")
                        {
                            varviewtype = 1;
                            varorginator = "Po Update";
                        }
                        SPDataService objspdservice = new SPDataService();
                        DataTable objGrnPO = new DataTable();
                        objGrnPO.TableName = "TRN_GRN_PO";
                        objGrnPO.Columns.Add("GRNPO_POID", typeof(int));
                        objGrnPO.Columns.Add("GRNPO_PODate", typeof(string));
                        objGrnPO.Columns.Add("GRNPO_PONo", typeof(string));
                        objGrnPO.Columns.Add("GRNPO_TotalPros", typeof(int));
                        objGrnPO = udfnGrnPO(); 
                        //result = objspdservice.udfnGRNEntry(varviewtype, POUpdate, Convert.ToInt32(cmbConcern.SelectedValue),
                        //txtpono.Text, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), "", varorginator, txtRemark.Text,
                        //txtTurnAroundTime.Text, objPurchaseOrder, "", "", "", "", Convert.ToInt32(cmbStatus.SelectedValue), dpPlanDate.Text);
                        //objspdservice.CloseConnection();
                        //string[] varvalue = result.Split('~');
                        //if (varvalue[0] == "3")
                        //{
                        //    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    this.ActiveControl = txtSupplier;
                        //    MainForm.objPUR_PurchaseOrderList.udfnPOEntryLoad();
                        //    varCloseFlag = 1;
                        //    udfnclose();
                        //}
                        //else
                        //{
                        //    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
                        //}
                        //this.ActiveControl = cmbConcern; 
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex); 
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
                    objGrnPO.Rows.Add(Convert.ToString(grdPODetails.Rows[i].Cells["poid"].Value), Convert.ToInt64(grdPODetails.Rows[i].Cells["clmPODate"].Value)
                    ,Convert.ToDouble(grdPODetails.Rows[i].Cells["clmpo"].Value) ,Convert.ToInt32(grdPODetails.Rows[i].Cells["clmtpro"].Value)); 
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
                dpPlanDate.BackColor = Color.LemonChiffon;
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
                dpPlanDate.BackColor = Color.White;
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
                MainForm.objPUR_PODamagedView = new PUR_PODamagedView();
                MainForm.objPUR_PODamagedView.varMasterType = "2";
                MainForm.objPUR_PODamagedView.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

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
            finally {
                grdUnitList.Rows[grdUnitList.RowCount - 1].Cells["clmQty"].Value = Convert.ToString(varTotal);
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
                    dpinvoicedate.Focus();
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
