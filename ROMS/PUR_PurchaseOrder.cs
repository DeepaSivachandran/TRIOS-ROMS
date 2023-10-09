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
    public partial class PUR_PurchaseOrder : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        public int SupplierUpdate = 0, vardayMonthID = 0, varWeekID = 0, vardayID = 0, varrecyclecode = 0, varMonthID = 0, varMasterid = 0, varUnitid = 0;
        public string vardays = "";
        private ToolTip tpsalesman = new ToolTip();
        private ToolTip tpsalemanph = new ToolTip();
        public PUR_PurchaseOrder()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objCP_Supplier = new CP_Supplier();
                MainForm.objCP_Supplier.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void PUR_PurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {

                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (8,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnPolicy, "", "MST_DisplayText", "MSTID");
                objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (9,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbReturnType, "", "MST_DisplayText", "MSTID");
                objDataBind = null;
                udfnDropdownLoad();
                //cmbReturnPolicy.Items.Add("Yes");
                //cmbReturnPolicy.Items.Add("No");
                //cmbReturnPolicy.SelectedIndex = 0;
                //cmbReturnType.Items.Add("Any Time");
                //cmbReturnType.Items.Add("Weekly");
                //cmbReturnType.Items.Add("Monthly");
                //cmbReturnType.Items.Add("Quarterly");
                //cmbReturnType.SelectedIndex = 0;
                //cmbReturnPolicy.SelectedIndex = 0;
                //txtReturnText.Visible = false;
                //cmbPolicyContent.Visible = false;
                //txtNextLevel.Visible = false;
                //cmbSecondLevel.Visible = false;
                //dpPlanDate.MinDate = DateTime.Today;
                //dpPlanDate.MaxDate = DateTime.MaxValue;
                //dpPlanDate.Value = DateTime.Today;
                //udfnList();
                //grdPendingorder.Rows.Add("1","PO0001", "30/07/2023", "20");
                //cmbStatus.SelectedIndex = 0;
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
            int varconcerntype = 4;
            if (btnSave.Text == "Save")
            {
                varconcerntype = 3;
            }
            DataSet objDT = new DataSet();
            objDT = objdserv.udfnCompanyList(varconcerntype, 0, MainForm.pbUserID, MainForm.pbIpAddress);
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

            int varViewType = 2;
            if (btnSave.Text == "Save")
            {
                varViewType = 1;
            }
            objDT = objdserv.udfnUnitList(varViewType, varUnitid);
            objdserv.CloseConnection();
            cmbUnit.DataSource = null;
            if (objDT != null)
            {
                if (objDT.Tables.Count > 0)
                {
                    if (objDT.Tables[0].Rows.Count > 0)
                    {
                        cmbUnit.ValueMember = "UTID";
                        cmbUnit.DisplayMember = "UT_Symbol";
                        cmbUnit.DataSource = objDT.Tables[0];
                    }
                }
            }
        }

        public void udfndelete()
        {
            try
            {
                if (grdsupplieradd.SelectedRows.Count > 0)
                {
                    string result = "";
                    DialogResult dialogResult = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        SPDataService objspdservice = new SPDataService();
                        result = "";
                        //    result = objspdservice.udfnSPBrandMaster("Delete", grdBrandList.SelectedRows[0].Cells["BrandCode"].Value.ToString(), "", "","", "", MainForm.pbUserID, MainForm.pbIpAddress, "Brand Delete");

                        string[] varvalue = result.Split('~');
                        if (varvalue[0] == "3")
                        {
                            MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            udfnList();

                        }
                        else
                        {
                            MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void udfnEdit()
        {
            try
            {

                if (grdsupplieradd.SelectedRows.Count > 0)
                {
                    MainForm.objCP_Brand = new CP_Brand();
                    //MainForm.objCP_Brand.MdiParent = this.ParentForm; 
                    MainForm.objCP_Brand.ShowDialog();
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
                Application.DoEvents();
                //********** To display a data in a grid  ******************
                grdsupplieradd.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                //objDs = objdserv.udfnSPBrandList("List", "0", MainForm.pbUserID, MainForm.pbIpAddress);
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdsupplieradd.DataSource = objDs.Tables[0];
                            grdsupplieradd.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdsupplieradd.Columns["Total No. of FG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdsupplieradd.Columns["Brand Name in Tamil"].Width = 275;
                            grdsupplieradd.Columns["Brand Name in English"].Width = 275;
                            grdsupplieradd.Columns["Label Name in Tamil"].Width = 275;
                            grdsupplieradd.Columns["Label Name in English"].Width = 275;
                            grdsupplieradd.Columns["BrandCode"].Visible = false;
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
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
                    lblNoRecordsFound.BringToFront();
                }
                udfnSearchGridHead();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdsupplieradd.ClearSelection();
            }
        }

        private void PUR_PurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.N))
                {
                    tsbNew_Click(sender, e);
                }
                if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (e.KeyCode == Keys.E))
                {
                    tsbEdit_Click(sender, e);
                }
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

        public void grdBrandList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnEdit();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void grdBrandList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) { udfnEdit(); }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }


        private void udfnSearchGridHead()
        {

        }

        private void grdBrandList_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
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


        private void btnDC_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_PODamagedView = new PUR_PODamagedView();
                MainForm.objPUR_PODamagedView.ShowDialog();
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
                DialogResult result = MessageBox.Show("There are pending purchase returns for this supplier. Do you want to save & continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Close();
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnNewUnit_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_BulkUnit = new PUR_BulkUnit();
                MainForm.objPUR_BulkUnit.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnViewedProduct_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_POMappedProducts = new PUR_POMappedProducts();
                MainForm.objPUR_POMappedProducts.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);

            }
        }

        private void BtnAppprove_Click(object sender, EventArgs e)
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

        private void BtnSalesmanSave_Click(object sender, EventArgs e)
        {
            try
            {
                int errorflag = 0;
                if (txtSalesManMobile.Text.Length != 10 && txtSalesManMobile.Text != "")
                {
                    errPO.SetError(txtSalesManMobile, "Please enter valid salesman mobile No.");
                    txtSalesManMobile.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpsalemanph.ShowAlways = true;
                    tpsalemanph.Show("Please enter valid salesman mobile No.", txtSalesManMobile, 5000);
                    errorflag = 1;
                }
                if (txtSalesManwhatsapp.Text.Trim() != "")
                {
                    if (txtSalesManwhatsapp.Text.Length != 10)
                    {
                        errPO.SetError(txtSalesManwhatsapp, "Please enter valid salesman whatsapp No.");
                        txtSalesManwhatsapp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpsalemanph.ShowAlways = true;
                        tpsalemanph.Show("Please enter valid salesman whatsapp No.", txtSalesManwhatsapp, 5000);
                        errorflag = 1;
                    }
                }
                if (errorflag == 0)
                {
                    udfnSupplierOrderSave();
                    udfntphide();
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
        public void udfntphide()
        {
            tpsalemanph.Active = false;
            tpsalesman.Active = false; 
        }
        public void udfnSupplierOrderSave()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                string result = ""; 
                errPO.Clear();
                udfnSchedulecolorchange();
                result = objspdservice.udfnSupplierMaster(11, Convert.ToInt32(lblSupplierCode.Text), "", "", "", 0, "", "", "", "", "", "", 0,
                0, 0, 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Salesman Details Update PO",0, "", 0, 0, 0, 0, 0, txtSalesManName.Text,
                "", txtSalesManMobile.Text,txtSalesManwhatsapp.Text, 0, "",Convert.ToInt32(lblschedule.Text), 0, "", "", "", "", "", "", "", "", "");

                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            finally
            {
                udfnsalesman();
            }
        }
        private void GrdPendingorder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MainForm.objPUR_POProducts = new PUR_POProducts();
                MainForm.objPUR_POProducts.ShowDialog();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSchedulecolorchange()
        {
            try
            {
                txtSalesManwhatsapp.BackColor = Color.White;
                txtSalesManName.BackColor = Color.White;
                txtSalesManMobile.BackColor = Color.White;
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
                MainForm.objPUR_PODamaged.ShowDialog();
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
                    dpPlanDate.Focus();
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

        private void TxtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductName.Focus();
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
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSupplier.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(15, 0, 0, 0, 0, txtSupplier.Text, 0, 0, 0);
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
                txtProductName.BackColor = Color.White;
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
                    txtProductQty.Focus();
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

        private void TxtProductQty_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductQty.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProductQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbUnit.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtProductQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbUnit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbUnit.Select(int.MaxValue, 0)));
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void CmbUnit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbUnit.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnNewUnit_Enter(object sender, EventArgs e)
        {
            try
            {
                btnNewUnit.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnNewUnit_Leave(object sender, EventArgs e)
        {
            try
            {
                btnNewUnit.BackColor = Color.White;
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

        private void BtnViewedProduct_Leave(object sender, EventArgs e)
        {
            try
            {
                btnViewedProduct.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnViewedProduct_Enter(object sender, EventArgs e)
        {
            try
            {
                btnViewedProduct.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManName_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesManName.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSalesManName_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesManName.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtSalesManName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSalesManMobile.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void TxtSalesManMobile_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesManMobile.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            } 
        }

        private void TxtSalesManMobile_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesManMobile.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManMobile_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSalesManwhatsapp.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManwhatsapp_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSalesManwhatsapp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManwhatsapp_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSalesManwhatsapp.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtSalesManwhatsapp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSalesmanSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSalesmanSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSalesmanSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSalesmanSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSalesmanSave.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSalesmanUndo_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSalesmanUndo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSalesmanUndo_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSalesmanUndo.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbReturnType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReturnPolicy_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReturnPolicy.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_Enter(object sender, EventArgs e)
        {
            try
            {

                cmbReturnPolicy.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbPolicyContent.Visible == true)
                    {
                        cmbPolicyContent.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbReturnType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbReturnType.BackColor = Color.White; 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbReturnType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPolicyContent_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbPolicyContent.BackColor = Color.White;
                //if (Convert.ToString(cmbPolicyContent.SelectedValue) == "" || Convert.ToString(cmbPolicyContent.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbPolicyContent, "Please select policy content");
                //    cmbPolicyContent.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select policy content", cmbPolicyContent, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbPolicyContent.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void CmbPolicyContent_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbSecondLevel.Visible == true)
                    {
                        cmbSecondLevel.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
                    }
                }


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbPolicyContent_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbPolicyContent_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbPolicyContent.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbSecondLevel.BackColor = Color.White;
                //if (Convert.ToString(cmbSecondLevel.SelectedValue) == "" || Convert.ToString(cmbSecondLevel.SelectedValue) == "-1")
                //{
                //    errCompany.SetError(cmbSecondLevel, "Please select");
                //    cmbSecondLevel.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpstate.ShowAlways = true;
                //    tpstate.Show("Please select", cmbSecondLevel, 5000);
                //}
                //else
                //{
                //    errCompany.Clear();
                //    cmbSecondLevel.BackColor = Color.White;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnReturnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnReturnSave.Enabled = false;
                SPDataService objspdservice = new SPDataService();
                string result = "", varoriginator = "";
                int Vartype = 0;
                SupplierUpdate = Convert.ToInt32(lblSupplierCode.Text);
                //if (Convert.ToInt32(varsupplierID) != 0)
                //{
                //    SupplierUpdate = Convert.ToInt32(varsupplierID);
                //}
                //else
                //{
                //    SupplierUpdate = Convert.ToInt32(pbSupplierid);
                //} 
                result = objspdservice.udfnSupplierMaster(6, SupplierUpdate, "", "", "", 0, "", "", "", "", "", "", 0, Convert.ToInt32(cmbReturnPolicy.SelectedValue), Convert.ToInt32(cmbReturnType.SelectedValue), 0, 0, 0, 0, "", MainForm.pbUserID, MainForm.pbIpAddress, "Update supplier order type", 0, "", 0, vardayID, varMonthID, varWeekID, vardayMonthID, "", "", "", "", 0, "", 0, 0, "", "", "", "", "", "", "", "", "");
                string[] varvalue = result.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_Supplierlist.udfnList();
                    cmbReturnPolicy.Focus();
                }
                else
                {
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                btnReturnSave.Enabled = true;
                btnReturnSave.Focus();
                udfnReturnCycle();
            }
        }

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnproductmasterlist(29, 0, 0, 0, 0, txtProductName.Text, "", "", 0,0,0,0,0,0, txtProductName.Text);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.Columns[0].Width = 200;
                                lvproduct.Columns[1].Width = 200;
                                lvproduct.Columns[2].Width = 100;
                                lvproduct.Columns[3].Width = 0;
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
                    cmbReturnType.SelectedValue = 24;
                    ListViewItem selectedItem = LV_Supplier.SelectedItems[0];
                    txtSupplier.Text = selectedItem.SubItems[0].Text;
                    lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                    lblschedule.Text = selectedItem.SubItems[2].Text; 
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    if (lblSupplierCode.Text.Length > 0)
                    {
                        objDs = objspdservice.udfnSupplierList(16, Convert.ToInt32(lblSupplierCode.Text), Convert.ToInt32(lblschedule.Text), 0, 0, "", 0, 0, 0);
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
                                lblSupplierOrderpolicy.Text = objDs.Tables[0].Rows[0]["ORDERTYPE"].ToString().Replace("''", "'");  
                                cmbReturnPolicy.SelectedValue = Convert.ToInt64(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                                cmbReturnType.SelectedValue = objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString(); ;

                                if ((Convert.ToString(cmbReturnType.SelectedValue) == "23"))
                                {
                                    cmbPolicyContent.SelectedValue = 0;
                                    cmbSecondLevel.SelectedValue = 0;
                                }
                                if ((Convert.ToString(cmbReturnType.SelectedValue) == "25"))
                                {
                                    cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["DAYID"].ToString();
                                }
                                if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                                {
                                    cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["WEEKID"].ToString();
                                    cmbSecondLevel.SelectedValue = objDs.Tables[0].Rows[0]["DAYID"].ToString();
                                }
                                if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                                {
                                    cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["MONTHID"].ToString();
                                    cmbSecondLevel.SelectedValue = objDs.Tables[0].Rows[0]["DAYOFMONTHID"].ToString();
                                }
                            }
                            if (objDs.Tables[1].Rows.Count > 0)
                            {
                                txtSalesManMobile.Text = objDs.Tables[1].Rows[0]["SPSC_SMMobileNo"].ToString().Replace("''", "'");
                                txtSalesManName.Text = objDs.Tables[1].Rows[0]["SPSC_SMName"].ToString().Replace("''", "'");
                                txtSalesManwhatsapp.Text = objDs.Tables[1].Rows[0]["SPSC_SMWhatsAppNo"].ToString().Replace("''", "'");
                            }
                        }
                    }
                }
                txtProductName.Focus();
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
        public void udfnsalesman()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(17, 0, Convert.ToInt32(lblschedule.Text), 0, 0, "", 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            txtSalesManMobile.Text = objDs.Tables[0].Rows[0]["SPSC_SMMobileNo"].ToString().Replace("''", "'");
                            txtSalesManName.Text = objDs.Tables[0].Rows[0]["SPSC_SMName"].ToString().Replace("''", "'");
                            txtSalesManwhatsapp.Text = objDs.Tables[0].Rows[0]["SPSC_SMWhatsAppNo"].ToString().Replace("''", "'");
                        }
                        else
                        {
                            txtSalesManMobile.Text = "";
                            txtSalesManName.Text = "";
                            txtSalesManwhatsapp.Text = "";
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
        public void udfnReturnCycle()
        {
            try
            {
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (lblSupplierCode.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(18, Convert.ToInt32(lblSupplierCode.Text), 0, 0, 0, "", 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        cmbReturnPolicy.SelectedValue = Convert.ToInt64(objDs.Tables[0].Rows[0]["RETURN"].ToString());
                        cmbReturnType.SelectedValue = objDs.Tables[0].Rows[0]["RETURNCYCLEID"].ToString(); ;

                        if ((Convert.ToString(cmbReturnType.SelectedValue) == "23"))
                        {
                            cmbPolicyContent.SelectedValue = 0;
                            cmbSecondLevel.SelectedValue = 0;
                        }
                        if ((Convert.ToString(cmbReturnType.SelectedValue) == "25"))
                        {
                            cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["DAYID"].ToString();
                        }
                        if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                        {
                            cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["WEEKID"].ToString();
                            cmbSecondLevel.SelectedValue = objDs.Tables[0].Rows[0]["DAYID"].ToString();
                        }
                        if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                        {
                            cmbPolicyContent.SelectedValue = objDs.Tables[0].Rows[0]["MONTHID"].ToString();
                            cmbSecondLevel.SelectedValue = objDs.Tables[0].Rows[0]["DAYOFMONTHID"].ToString();
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
        public void udfnListviewProduct()
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    txtProductName.Text = selectedItem.SubItems[0].Text;
                    lblProductcode.Text = selectedItem.SubItems[3].Text;

                }
                txtProductQty.Focus();
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

        private void BtnSalesmanUndo_Click(object sender, EventArgs e)
        {
            try
            {
                udfnsalesman();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnReturnUndo_Click(object sender, EventArgs e)
        {
            try
            {
                udfnReturnCycle();
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

        private void CmbSecondLevel_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbSecondLevel.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnReturnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnPolicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReturnPolicy.Text == "Yes")
                // if (Convert.ToString(cmbReturnType.SelectedValue) == "22")
                {
                    cmbReturnType.Visible = true;
                    txtDReturnCycle.Visible = true;
                }
                else
                {
                    cmbReturnType.Visible = false;
                    txtDReturnCycle.Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReturnPolicy.Text == "Yes")
                // if (Convert.ToString(cmbReturnType.SelectedValue) == "22")
                {
                    cmbPolicyContent.Visible = true;
                    cmbSecondLevel.Visible = true;
                    txtReturnText.Visible = true;
                    txtNextLevel.Visible = true;
                }
                else
                {
                    cmbPolicyContent.Visible = false;
                    cmbSecondLevel.Visible = false;
                    txtReturnText.Visible = false;
                    txtNextLevel.Visible = false;
                }
                BeginInvoke(new Action(() => cmbReturnType.Select(int.MaxValue, 0)));
                if (Convert.ToString(cmbReturnType.SelectedValue) == "24")
                {
                    vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                    cmbPolicyContent.DataSource = null;
                    txtReturnText.Visible = false;
                    cmbPolicyContent.Visible = false;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                    varrecyclecode = Convert.ToInt32(cmbReturnType.SelectedValue);
                }
                else if ((Convert.ToString(cmbReturnType.SelectedValue) == "25"))
                {
                    txtReturnText.Text = "Day";
                    vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                    cmbPolicyContent.Enabled = true;
                    cmbPolicyContent.DataSource = null;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbPolicyContent, "", "DY_Name", "DYID");
                    objDataBind = null;
                    cmbPolicyContent.SelectedIndex = 0;
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    txtNextLevel.Visible = false;
                    cmbSecondLevel.Visible = false;
                    vardayID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                }
                else if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                {
                    vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                    txtReturnText.Text = "Week No.";
                    txtReturnText.Visible = true;
                    cmbPolicyContent.DataSource = null;
                    cmbSecondLevel.DataSource = null;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID in (28,0) AND MSTID NOT IN (0,-1) ORDER BY MSTID", "MST_DisplayText,MSTID", cmbPolicyContent, "", "MST_DisplayText", "MSTID");
                    objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbSecondLevel, "", "DY_Name", "DYID");
                    varWeekID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                    vardayID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                    cmbPolicyContent.SelectedIndex = 0;
                    cmbSecondLevel.SelectedIndex = 0;
                    txtNextLevel.Text = "Day";

                    objDataBind = null;
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                }
                else if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                {
                    txtReturnText.Text = "Month";
                    vardays = "";
                    vardayMonthID = 0; varWeekID = 0; vardayID = 0; varrecyclecode = 0; varMonthID = 0;
                    txtReturnText.Visible = true;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    cmbPolicyContent.DataSource = null;
                    cmbSecondLevel.DataSource = null;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Months", "MONID NOT IN (0,-1)", "MON_Name,MONID", cmbPolicyContent, "", "MON_Name", "MONID");
                    cmbPolicyContent.SelectedIndex = 0;
                    DataService objds = new DataService();
                    vardays = objds.displaydata("SELECT MON_DAY FROM DEF_Months WHERE MONID ='" + Convert.ToString(cmbPolicyContent.SelectedValue) + "'");
                    objds.CloseConnection();
                    txtNextLevel.Visible = true;
                    cmbSecondLevel.Visible = true;
                    txtNextLevel.Text = "Day of the month";
                    objDataBind.BindComboBoxListSelected("DEF_Month_Days", "MONDID <='" + vardays + "'", "MOND_Name,MONDID", cmbSecondLevel, "", "MOND_Name", "MONDID");
                    objDataBind = null;
                    cmbSecondLevel.SelectedIndex = 0;
                    varMonthID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
         
        private void CmbPolicyContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbPolicyContent.Select(int.MaxValue, 0)));
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                {
                    vardays = "";
                    vardayMonthID = 0;
                    cmbSecondLevel.DataSource = null;
                    DataBind objDataBind = new DataBind();
                    DataService objds = new DataService();
                    vardays = objds.displaydata("SELECT MON_DAY FROM DEF_Months WHERE MONID ='" + Convert.ToString(cmbPolicyContent.SelectedValue) + "'");
                    objds.CloseConnection();
                    objDataBind.BindComboBoxListSelected("DEF_Month_Days", "MONDID <='" + vardays + "'", "MOND_Name,MONDID", cmbSecondLevel, "", "MOND_Name", "MONDID");
                    objDataBind = null;
                    cmbSecondLevel.SelectedIndex = 0;
                    vardayMonthID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                }
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "25"))
                {
                    vardayID = 0;
                    vardayID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                }
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                {
                    vardays = "";
                    varWeekID = 0;
                    vardayID = 0;
                    cmbSecondLevel.DataSource = null;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    DataBind objDataBind = new DataBind();
                    objDataBind.BindComboBoxListSelected("DEF_Days", "DYID NOT IN (0,-1)", "DY_Name,DYID", cmbSecondLevel, "", "DY_Name", "DYID");
                    objDataBind = null;
                    varWeekID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                    vardayID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                }

            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbSecondLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() => cmbSecondLevel.Select(int.MaxValue, 0)));
                if ((Convert.ToString(cmbReturnType.SelectedValue) == "27"))
                {
                    vardayMonthID = 0;
                    DataBind objDataBind = new DataBind();
                    DataService objds = new DataService();
                    vardayMonthID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
                    varMonthID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                }

                if ((Convert.ToString(cmbReturnType.SelectedValue) == "26"))
                {
                    vardays = "";
                    varWeekID = 0;
                    vardayID = 0;
                    cmbPolicyContent.Visible = true;
                    cmbPolicyContent.Enabled = true;
                    varWeekID = Convert.ToInt32(cmbPolicyContent.SelectedValue);
                    vardayID = Convert.ToInt32(cmbSecondLevel.SelectedValue);
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
