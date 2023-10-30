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

        private ToolTip tpbrandname = new ToolTip();
        private ToolTip tpbrandtamilname = new ToolTip();
        private ToolTip tpbltname = new ToolTip();
        private ToolTip tpblename = new ToolTip();
        public string varbrandcode, varpendingPOID="0", pbSupplierpend="0";
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
                objDs = objdserv.GetDataset("SELECT MSTID,MST_DisplayText,'' AS VALUE FROM DEF_Master WHERE MST_TransactionID=27 UNION ALL SELECT 0,'Excess',(SELECT GS_GRNQty FROM MR_GeneralSettings) UNION ALL SELECT 1,'Total','' ");
                objdserv.CloseConnection(); 
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                            {
                                grdUnitList.Rows.Add(objDs.Tables[0].Rows[i]["MST_DisplayText"].ToString().Replace("''", "'"),objDs.Tables[0].Rows[i]["VALUE"].ToString().Replace("''", "'"), objDs.Tables[0].Rows[i]["MSTID"].ToString().Replace("''", "'"));
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

                // If the DataGridView isn't set up to allow user to add rows, 
                // you might not have an empty row at the bottom. 
                // In that case, you can create and add a new row first.
                //DataGridViewRow lastRow = grdUnitList.Rows[grdUnitList.Rows.Count - 1];
                //lastRow.Cells[0].Value = sum;
                if (grdUnitList.Rows.Count > 0) // Check to ensure there are rows
                {
                    DataGridViewRow lastRow = grdUnitList.Rows[grdUnitList.Rows.Count - 1];
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
                int varconcerntype = 4;
                if (btnSave.Text == "Save")
                {
                    varconcerntype = 3;
                }
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
                cmbConcern.BackColor = Color.White;
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
                //if (txtSupplier.Text == "")
                //{
                //    errPO.SetError(txtSupplier, "Please enter supplier");
                //    txtSupplier.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpSuppliername.ShowAlways = true;
                //    tpSuppliername.Show("Please enter supplier.", txtSupplier, 5000);
                //}
                //else
                //{
               // errPO.Clear();
                txtSupplier.BackColor = Color.White;
               // tpSuppliername.Active = false;
                //}
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
                    objDs = objspdservice.udfnSupplierList(15, 0, 0, 0, 0, txtSupplier.Text, 0, 0, 0,0);
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
                txtInvoiceno.BackColor = Color.White;
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
                cmbOrderType.BackColor = Color.White;
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
                dpPlanDate.Focus();
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
                txtInvoiceamt.BackColor = Color.White;
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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet(); 
                if (lblSupplierCode.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(16, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, "", 0, 0, 0,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            lblSuppliername.Text = objDs.Tables[0].Rows[0]["NAME"].ToString().Replace("''", "'");
                            lblSupplierCity.Text = objDs.Tables[0].Rows[0]["CITY"].ToString().Replace("''", "'");
                            lblsupplierGST.Text = objDs.Tables[0].Rows[0]["GSTIN"].ToString().Replace("''", "'");
                            lblsupplierScheduletype.Text = objDs.Tables[0].Rows[0]["SCHEDULE"].ToString().Replace("''", "'");
                            lblsupplierpayment.Text = objDs.Tables[0].Rows[0]["payment"].ToString().Replace("''", "'");
                            lblSupplierOrderpolicy.Text = "Return Policy :" + objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString().Replace("''", "'");  
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            txtSalesManMobile.Text = objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString().Replace("''", "'");
                            txtSalesManName.Text = objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString().Replace("''", "'");
                            txtSalesManwhatsapp.Text = objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString().Replace("''", "'");
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

                        if (objDs.Tables[5].Rows.Count > 0)
                        {
                            varpendingPOID = "0";
                            grdPODetails.Rows.Clear();
                            for (int i = 0; i < objDs.Tables[5].Rows.Count; i++)
                            {
                                lblFinishedNoRecord.Visible = false;
                                grdPODetails.Rows.Add(objDs.Tables[5].Rows[i]["SINO"].ToString(), objDs.Tables[5].Rows[i]["PO_No"].ToString(),
                                objDs.Tables[5].Rows[i]["PO_Date"].ToString(), objDs.Tables[5].Rows[i]["QTY"].ToString(), objDs.Tables[5].Rows[i]["PO_Final_STSID"].ToString()
                                );
                                pbSupplierpend = "1";
                            }
                            varpendingPOID = objDs.Tables[5].Rows[0]["POID"].ToString();
                        }
                        else
                        {
                            lblFinishedNoRecord.Visible = true;
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
        }
         

        private void CmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbOrderType.SelectedValue) == 53)
                {

                    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                    MainForm.objPUR_GRNOrderType.ShowDialog();
                }
                else
                {
                    MainForm.objPUR_GRNOrderType = new PUR_GRNOrderType();
                    MainForm.objPUR_GRNOrderType.Close();
                }
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

               // grdPODetails.Rows.Add(1, "GNM", "02/08/2023", "GRN001", "", "02/08/2023", "I001", "50,000", "", "", "Venkat", "02/08/2023");
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdPODetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MainForm.objPUR_POProducts = new PUR_POProducts();
                MainForm.objPUR_POProducts.pbPoid = varpendingPOID;
                MainForm.objPUR_POProducts.pbSupplierCode = lblSupplierCode.Text;
                MainForm.objPUR_POProducts.pbScheduleCode = lblschedule.Text;
                MainForm.objPUR_POProducts.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void GrdUnitList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void BtnDamage_Click(object sender, EventArgs e)
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

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamaged = new PUR_PODamaged();
                MainForm.objPUR_PODamaged.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void GrdUnitList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                udfnTotalUnitGrid();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
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
