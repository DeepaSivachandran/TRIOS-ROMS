using ROMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROMS
{
    public partial class INV_StockRequest : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        DataTable dtStock = new DataTable();

        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpStockQty = new ToolTip();
        private ToolTip tpRequiredQty = new ToolTip();

        public string VarAdd = "0";
        public string varProducts = "";
        public string varProductName = "";
        public int varModifiedFlag = 0;
        public int varStockRequestID = 0;
        public int varID = 0;
        public int varDecimal = 0;
        public int varStatus = 0;
        public int varSLID = 0;
        public int varRKID = 0;
        public string varErrQty = "0";
        public string SSRUpdatevalue = "";
        public bool VarSearchFlag = true;
        byte[] varobjBarCodeByte;
        string[] varProductsIDs;
        public INV_StockRequest()
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
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void tsbDelete_Click(object sender, EventArgs e)
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

        private void INV_StockRequest_Load(object sender, EventArgs e)
        {
            try
            {
                dtStock.TableName = "TRN_StockRequest_Details";
                dtStock.Columns.Add("SRQ_PRID", typeof(int));
                dtStock.Columns.Add("SRQ_SLID", typeof(int));
                dtStock.Columns.Add("SRQ_RKID", typeof(int));
                dtStock.Columns.Add("SRQ_RequestedQty", typeof(decimal));
                dtStock.Columns.Add("SRQ_ReceivedQty", typeof(decimal));
                udfnCmbConcern();
                DataBind objDataBind = new DataBind();
                objDataBind.BindComboBoxListSelected("DEF_Status", "STS_ModuleID=11 AND STSID IN(28,29)", "STS_Name,STSID", cmbStatus, "", "STS_Name", "STSID");
                objDataBind = null;
                if (btnSave.Text == "Save && Print")
                {
                    if (varStockRequestID == 0)
                    {
                        udfnTransferNo();
                        dpDate.Value = MainForm.pbCurrentDate;
                        cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                    }
                    else
                    {
                        udfnEdit();
                    }
                }
                else
                {
                    udfnEdit();
                }
                if (varStatus != 29)
                {
                    this.ActiveControl = txtProductNamePICode;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbConcern()
        {
            try
            {
                cmbConcern.Focus();
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
        public void udfnEdit()
        {
            try
            {
                if (varStockRequestID != 0)
                {
                    btnSave.Text = "Update";
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    Model.TRN_StockRequest objTRNG_StockRequest = new Model.TRN_StockRequest();
                    objTRNG_StockRequest.ViewType = 1;
                    objTRNG_StockRequest.paraStockRequestID = varStockRequestID;
                    objDS = objspservice.udfnStockRequestList(objTRNG_StockRequest);
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            dpDate.Text = objDS.Tables[0].Rows[0]["Request Date"].ToString().Replace("''", "'");
                            txtRequestNo.Text = objDS.Tables[0].Rows[0]["Request No."].ToString().Replace("''", "'");
                            txtRemarks.Text = objDS.Tables[0].Rows[0]["Remarks"].ToString().Replace("''", "'");
                            cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["ConcernID"].ToString();
                        }
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                            {
                                grdStockRequest.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[0].Rows[i]["PR_PICode"]), Convert.ToString(objDS.Tables[0].Rows[i]["PR_TName"]), Convert.ToString(objDS.Tables[0].Rows[i]["RKG_Name"]), Convert.ToString(objDS.Tables[0].Rows[i]["RK_ShortName"]), Convert.ToString(objDS.Tables[0].Rows[i]["EMP_Name"]), Convert.ToDecimal(objDS.Tables[0].Rows[i]["STOCK"]), Convert.ToDecimal(objDS.Tables[0].Rows[i]["SRQD_RequestedQty"]), Convert.ToString(objDS.Tables[0].Rows[i]["UT_Symbol"]), Convert.ToString(objDS.Tables[0].Rows[i]["UT_Decimal"]), Convert.ToString(objDS.Tables[0].Rows[i]["SRQD_PRID"]));
                                dtStock.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["SRQD_PRID"]), 0, 0, Convert.ToDecimal(objDS.Tables[0].Rows[i]["SRQD_RequestedQty"]),0);
                            }
                            for (int j = 0; j < grdStockRequest.Rows.Count; j++)
                            {
                                if (varProducts == "")
                                {
                                    varProducts = Convert.ToString(grdStockRequest.Rows[j].Cells["clmPRID"].Value);
                                }
                                else
                                {
                                    varProducts = varProducts + ',' + Convert.ToString(grdStockRequest.Rows[j].Cells["clmPRID"].Value);
                                }
                                
                            }
                            ((DataGridViewTextBoxColumn)grdStockRequest.Columns["clmRequiredQty"]).MaxInputLength = 8;
                            grdStockRequest.Columns["clmSno"].Width = 50;
                            grdStockRequest.Columns["clmRequiredQty"].Width = 100;
                            grdStockRequest.Columns["clmStockQty"].Width = 100;
                            grdStockRequest.Columns["clmRequiredQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockRequest.Columns["clmStockQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockRequest.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            if (varStatus != 28)
                            {
                                txtProductNamePICode.Enabled = false;
                                this.ActiveControl = txtRemarks;
                                txtRequiredQty.Enabled = false;
                                btnAdd.Enabled = false;
                                cmbStatus.Enabled = false;
                                grdStockRequest.ReadOnly = true;
                                grdStockRequest.Columns["clmRemove"].Visible = false;
                                cmbStatus.SelectedValue = 29;
                                DataGridViewBindingCompleteEventArgs args = new DataGridViewBindingCompleteEventArgs(ListChangedType.Reset);
                                GrdStockRequest_DataBindingComplete(grdStockRequest, args);
                                tpProduct.Active = false;
                                errStockRequest.Clear();
                            }
                            else
                            {
                                cmbStatus.SelectedValue = 28;
                            }
                        }
                    }
                    cmbConcern.Enabled = false;
                    dpDate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
            }
        }
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmRequiredQty")
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
        private void INV_StockRequest_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose.Focus();
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
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                //dgv2.DataSource = null;
                dgv2.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in dgv1.Columns)
                {
                    if (col.Visible)
                    {
                        dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                        visibleColumns.Add(col.Index);
                    }
                }
                int rowIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    dgv2.Rows[rowIndex].Cells[i].Value = "";
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        } 
        public void udfnscrollVisible(DataGridView DGV,DataGridView grdGroupList)
        {
            try
            {
                var vScrollbar = grdGroupList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
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
            udfnclose();
        }
        public void udfnclose()
        {
            try
            {
                if (varModifiedFlag == 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to discard changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm.objINV_StockRequestList.udfnList();
                    }
                    else
                    { btnSave.Focus(); }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
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
            //try
            //{
            //    if (chkCompleted.Checked) { btnSave.Text = "Save && Print"; } else { btnSave.Text = "Save as Draft"; }
            //}
            //catch (Exception ex)
            //{
            //    objError = new DataError();
            //    objError.WriteFile(ex);
            //}
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

        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductNamePICode.Focus();
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
                    errStockRequest.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    errStockRequest.Clear();
                    cmbConcern.BackColor = Color.White;
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
                udfnTransferNo();
                grdStockRequest.Rows.Clear();
                dtStock.Rows.Clear();
                varProducts = "";
                txttotalitem.Text = "";
                grdGodownStock.Rows.Clear();
                if (btnSave.Text == "Save")
                {
                    txtProductNamePICode.Text = "";
                    txtRequiredQty.Text = "";
                    txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
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
            if (varStockRequestID == 0)
            {
                if (btnSave.Text == "Save && Print")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpDate.Text + "',103)");
                        varResult = objspdservice.udfngetPONO("43", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] varvalue = varResult.Split('~');
                        if (varResult != "")
                        {
                            txtRequestNo.Text = varvalue[0];
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(75);
                            objDServ.CloseConnection();
                            txtRequestNo.Text = "";
                            DialogResult dialogResult = MessageBox.Show(varMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                MainForm.objCP_Settings = new CP_Settings();
                                //MainForm.objCP_Settings.varconcernvalue = Convert.ToString(cmbConcern.SelectedValue);
                                //MainForm.objCP_Settings.varValues = Convert.ToString(44);
                                MainForm.objCP_Settings.MdiParent = this.ParentForm;
                                MainForm.objCP_Settings.Show();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        txtRequestNo.Text = "";
                    }
                }
            }
        }

        private void TxtProductNamePICode_Enter(object sender, EventArgs e)
        {
            try
            {
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvProduct.Items.Count == 0 || txtProductNamePICode.Text == "")
                    {
                        txtRequiredQty.Focus();
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
                    txtRequiredQty.Focus();
                }
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblDEProductName.Text = "Search by P.I Code";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Upper;
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblDEProductName.Text = "Search by Product Name";
                        txtProductNamePICode.CharacterCasing = CharacterCasing.Normal;
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
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    errStockRequest.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductNamePICode, 5000);
                    lblProduct.Text = "0";
                }
                else
                {
                    errStockRequest.Clear();
                    txtProductNamePICode.BackColor = Color.White;
                }
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
                txtStockQty.Text = "";
                txtRequiredQty.Text = "";
                string PRID = "0";
                grdGodownStock.Rows.Clear();
                lvProduct.Items.Clear();
                if (varProducts != "")
                {
                    string[] strings = varProductsIDs;
                    var strings1 = strings.Select(xx => xx);
                    PRID = (string.Join(",", strings1));
                }
                if (txtProductNamePICode.Text.Length > 0)
                {
                    DataSet objDs = new DataSet();
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = 45;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.ParaProductsCode = PRID;
                    SPDataService objspdservice = new SPDataService();
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
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["UT_Decimal"].ToString(),objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvProduct.Items.Add(objList);
                                }
                                lvProduct.Visible = true;
                                lvProduct.BringToFront();
                                lvProduct.Columns[0].Width = 150;
                                lvProduct.Columns[1].Width = 0;
                                lvProduct.Columns[2].Width = 0;
                                lvProduct.Columns[3].Width = 60;
                                lvProduct.Columns[4].Width = 0;
                                lvProduct.Columns[5].Width = 0;
                                //lvProduct.Columns[6].Width = 0;
                                //lvProduct.Columns[7].Width = 0;
                                if (VarSearchFlag == false)
                                {
                                    lvProduct.Columns[1].Width = 320;
                                    lvProduct.Columns[2].Width = 0;
                                }
                                else
                                {
                                    lvProduct.Columns[1].Width = 0;
                                    lvProduct.Columns[2].Width = 320;
                                }
                            }
                            else
                            {
                                lvProduct.Visible = false;
                            }
                        }
                        else
                        {
                            lvProduct.Visible = false;
                        }
                    }
                    else
                    {
                        lvProduct.Visible = false;
                    }
                }
                else
                {
                    lvProduct.Visible = false;
                    lvProduct.Items.Clear();
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

        private void LvProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnProductEvent();
                txtRequiredQty.Focus();
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
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductEvent();
                    txtRequiredQty.Focus();
                }
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
                    ListViewItem selectedItem = lvProduct.SelectedItems[0];
                    varProductName = selectedItem.SubItems[2].Text;
                    txtProductNamePICode.Text = selectedItem.SubItems[1].Text;
                    lblUnit.Text = selectedItem.SubItems[3].Text;
                    varDecimal = Convert.ToInt32(selectedItem.SubItems[4].Text);
                    lblProduct.Text = selectedItem.SubItems[5].Text;
                    varSLID =Convert.ToInt32(selectedItem.SubItems[6].Text);
                    varRKID = Convert.ToInt32(selectedItem.SubItems[7].Text);
                    VarAdd = "1";
                    udfnStockLoad();
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
                txtStockQty.BackColor = SystemColors.Control;
                txtRequiredQty.BackColor = SystemColors.Control;
            }
        }
        public void udfnStockLoad()
        {
            try
            {
                DataSet objDS = new DataSet() ;
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = 43;
                objMR_Product.ParaProductCode = Convert.ToInt32(lblProduct.Text);
                SPDataService objspservice = new SPDataService();
                objDS = objspservice.udfnproductmasterlist(objMR_Product);
                objspservice.CloseConnection();
                if (objDS != null)
                {
                    if (VarAdd == "1")
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtStockQty.Text = objDS.Tables[0].Rows[0]["Stock"].ToString().Replace("''", "'");
                            txtStockQty.BackColor = SystemColors.Control;
                        }
                        if (objDS.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[1].Rows.Count; i++)
                            {
                                grdGodownStock.Rows.Add(Convert.ToString(objDS.Tables[1].Rows[i]["SL_ShortName"]), Convert.ToString(objDS.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDS.Tables[1].Rows[i]["STK_Qty"]));
                                varModifiedFlag = 1;
                            }
                        }
                    }
                    if(VarAdd=="2")
                    {
                        if (txtRequiredQty.Text != "")
                        {
                            //if (varDecimal == 6)
                            //{
                               string Qty= objValidation.udfnDecimal((txtRequiredQty.Text).Trim(), varDecimal);
                                txtRequiredQty.Text = Qty;
                            //}
                            //if (varDecimal == 7)
                            //{
                            //    string Qty = objValidation.udfnDecimal((txtRequiredQty.Text).Trim(), 2);
                            //    txtRequiredQty.Text = Qty;
                            //}
                            //if (varDecimal == 8)
                            //{
                            //    string Qty = objValidation.udfnDecimal((txtRequiredQty.Text).Trim(), 3);
                            //    txtRequiredQty.Text = Qty;
                            //}
                        }
                        if (objDS.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                            {
                                grdStockRequest.Rows.Add(grdStockRequest.Rows.Count + 1, Convert.ToString(objDS.Tables[2].Rows[i]["PR_PICode"]), Convert.ToString(objDS.Tables[2].Rows[i]["PR_TName"]), Convert.ToString(objDS.Tables[2].Rows[i]["RKG_Name"]), Convert.ToString(objDS.Tables[2].Rows[i]["RK_ShortName"]), Convert.ToString(objDS.Tables[2].Rows[i]["EMP_Name"]), Convert.ToString(txtStockQty.Text), Convert.ToString(txtRequiredQty.Text), Convert.ToString(objDS.Tables[2].Rows[i]["UT_Symbol"]), Convert.ToString(objDS.Tables[2].Rows[i]["UT_Decimal"]), Convert.ToString(lblProduct.Text));
                            }
                            dtStock.Rows.Add(Convert.ToInt32(lblProduct.Text),varSLID,varRKID,Convert.ToString(txtRequiredQty.Text),0);
                            //for(int j=0;j<grdStockRequest.Rows.Count;j++)
                            //{
                                if (varProducts == "")
                                {
                                    varProducts = Convert.ToString(lblProduct.Text);
                                }
                                else
                                {
                                    varProducts = varProducts + ',' + Convert.ToString(lblProduct.Text);
                                }
                                varProductsIDs = varProducts.Split(',');
                            //}
                            ((DataGridViewTextBoxColumn)grdStockRequest.Columns["clmRequiredQty"]).MaxInputLength = 8;
                            grdStockRequest.Columns["clmSno"].Width = 50;
                            grdStockRequest.Columns["clmRequiredQty"].Width = 100;
                            grdStockRequest.Columns["clmStockQty"].Width = 100;
                            grdStockRequest.Columns["clmRequiredQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockRequest.Columns["clmStockQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockRequest.Columns["clmSno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            VarAdd = "0";
                            txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
                            errStockRequest.Clear();
                            txtProductNamePICode.Text = "";
                            txtStockQty.Text = "";
                            txtRequiredQty.Text = "";
                            lblUnit.Text = "";
                            grdGodownStock.Rows.Clear();
                            grdStockRequest.ClearSelection();
                            txtProductNamePICode.Focus();
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
                if(grdStockRequest.Rows.Count>0)
                {
                    cmbConcern.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                }
            }
        }
        private void TxtRequiredQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRequiredQty.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtRequiredQty_KeyDown(object sender, KeyEventArgs e)
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
        private void TxtRequiredQty_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (textBox.Text.IndexOf('.') > -1 && textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= varDecimal+1)
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
        private void TxtRequiredQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRequiredQty.Text.Trim() == "")
                {
                    errStockRequest.SetError(txtRequiredQty, "Please enter quentity");
                    txtRequiredQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRequiredQty.ShowAlways = true;
                    tpRequiredQty.Show("Please enter quentity", txtRequiredQty, 5000);
                }
                else
                {
                    errStockRequest.Clear();
                    txtRequiredQty.BackColor = Color.White;
                }
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
                btnAdd.BackColor = Color.Transparent;
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
                    if (cmbStatus.Enabled == true)
                    {
                        cmbStatus.Focus();
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    errStockRequest.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProductNamePICode, 5000);
                    blnErrorFlag = true;
                }
                //if (Convert.ToString(txtStockQty.Text).Trim() == "")
                //{
                //    errStockRequest.SetError(txtStockQty, "Invalid stock");
                //    txtStockQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpStockQty.ShowAlways = true;
                //    tpStockQty.Show("Invalid stock", txtStockQty, 5000);
                //    blnErrorFlag = true;
                //}
                if (Convert.ToString(txtRequiredQty.Text).Trim() != "")
                {
                    //if (Convert.ToInt32(txtStockQty.Text.Trim()) >= Convert.ToInt32(txtRequiredQty.Text.Trim()))
                    //{
                    //    errStockRequest.Clear();
                    //    txtRequiredQty.BackColor = Color.White;
                    //}
                    //else
                    //{
                    //    errStockRequest.SetError(txtRequiredQty, "Please enter valid quentity");
                    //    txtRequiredQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //    tpRequiredQty.ShowAlways = true;
                    //    tpRequiredQty.Show("Please enter valid quentity", txtRequiredQty, 5000);
                    //    blnErrorFlag = true;
                    //}
                }
                else
                {
                    errStockRequest.SetError(txtRequiredQty, "Please enter quentity");
                    txtRequiredQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRequiredQty.ShowAlways = true;
                    tpRequiredQty.Show("Please enter quentity", txtRequiredQty, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    VarAdd = "2";
                    udfnStockLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockRequest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdStockRequest.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            grdStockRequest.Rows.RemoveAt(this.grdStockRequest.SelectedRows[0].Index);
                            for (int i = 0; i < grdStockRequest.RowCount; i++)
                            {
                                grdStockRequest.Rows[i].Cells["clmSno"].Value = i + 1;
                            }
                            //varProductsIDs = varProducts.Split(',');
                            int varPRID = Convert.ToInt32(grdStockRequest.SelectedRows[0].Cells["clmPRID"].Value);

                            for (int j = 0; j < varProductsIDs.Length; j++)
                            {
                                    // varProductsIDs=varProductsIDs.

                                    //List<string[]> nums = new List<string[]>(varProductsIDs);
                                    //                            nums.RemoveAt(nums.IndexOf(Convert.ToString( j));
                                    varProductsIDs = varProductsIDs.Where((val, idx) => idx != j).ToArray();
                            }
                            varModifiedFlag = 1;
                            for (int i = 0; i < dtStock.Rows.Count; i++)
                            {
                                dtStock.Rows[i].Delete();
                                dtStock.AcceptChanges();
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
                txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
                if (grdStockRequest.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                }
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errStockRequest.Clear();
                bool blnErrorFlag = false;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errStockRequest.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                if (grdStockRequest.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                //if (varErrQty == "1")
                //{
                //    SPDataService objDServ = new SPDataService();
                //    string varMessage = objDServ.udfnGetMessages(89);
                //    objDServ.CloseConnection();
                //    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    blnErrorFlag = true;
                //}
                if (blnErrorFlag == false)
                {
                    errStockRequest.Clear();
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
                varoriginator = ""; int varType = 0,varStatus = 0;
                varStatus = Convert.ToInt32(cmbStatus.SelectedValue);
                if (btnSave.Text== "Save && Print")
                {
                    varoriginator = "Stock Request Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Stock Request Updation";
                    varType = 1;
                }
                Model.TRN_StockRequest objTRNS_StockRequest = new Model.TRN_StockRequest();
                objTRNS_StockRequest.ViewType = varType;
                objTRNS_StockRequest.paraStockRequestID = varStockRequestID;
                objTRNS_StockRequest.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRNS_StockRequest.paraRequestDate = dpDate.Text;
                objTRNS_StockRequest.paraRemarks = txtRemarks.Text;
                objTRNS_StockRequest.paraStatusId = Convert.ToInt32(cmbStatus.SelectedValue);
                objTRNS_StockRequest.paraOriginator = varoriginator;
                objTRNS_StockRequest.paraStockRequest = dtStock;
                varResult = objspservice.udfnStockRequest(objTRNS_StockRequest);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    varModifiedFlag = 0;
                    try
                    {
                        if (Convert.ToInt32(cmbStatus.SelectedValue)==29)
                        {
                            string SSR = "0";
                            if (varStockRequestID == 0)
                            {
                                SSR = varvalue[2];
                            }
                            else
                            {
                                SSR = Convert.ToString(varStockRequestID);
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
                                objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_TP_INV_Shop_Stock_Request.rpt");
                                varHeader = "Shop Stock Request";

                                objBillreport.SetParameterValue("paraStockRequestID", Convert.ToInt32(SSR));
                                objBillreport.SetParameterValue("paraConcern", Convert.ToInt32(cmbConcern.SelectedValue));
                                objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                                objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                                objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                                objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                                objValidation.CrySqlConnection(objBillreport);

                                MainForm.objReportLoad = new ReportLoad();
                                MainForm.objReportLoad.cryptview.ReportSource = objBillreport;
                                MainForm.objReportLoad.Text = varHeader;
                                MainForm.objReportLoad.ShowDialog();
                            }
                        }
                        if(varStockRequestID==0)
                        {
                            SSRUpdatevalue = varvalue[2];
                            string varQrcode = varvalue[3];
                            var varImgMemoryStream = new MemoryStream();
                            QrcodeImg.Text = varQrcode;
                            QrcodeImg.Image.Save(varImgMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
                            varobjBarCodeByte = varImgMemoryStream.GetBuffer();
                            objTRNS_StockRequest.ViewType = 3;
                            objTRNS_StockRequest.paraStockRequestID = Convert.ToInt32(SSRUpdatevalue);
                            objTRNS_StockRequest.paraQrimg = (varobjBarCodeByte);
                            varResult = objspservice.udfnStockRequest(objTRNS_StockRequest);
                            objspservice.CloseConnection();
                        }
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                    MainForm.objINV_StockRequestList.udfnList();
                    this.Close();
                }
                else
                {
                    errStockRequest.Clear();
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
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

        private void GrdStockRequest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varDecimal = Convert.ToInt32(grdStockRequest.CurrentRow.Cells["clmUTDecimal"].Value);

                    string Qty = objValidation.udfnDecimal(Convert.ToString(grdStockRequest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), varDecimal);
                    grdStockRequest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Qty;

                object varEditQty = grdStockRequest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                // Update the same column value in the DataTable
                dtStock.Rows[e.RowIndex]["SRQ_RequestedQty"] = varEditQty;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CmbStatus_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbStatus_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbStatus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbStatus.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdStockRequest_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdStockRequest.Rows.Count; i++)
                {
                    if (varStatus == 29)
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmRequiredQty"];
                        cell.Style.BackColor = Color.LightGray;
                        cell.Style.ForeColor = Color.Black;
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        DataGridView dataGridView = (DataGridView)sender;
                        DataGridViewCell cell = dataGridView.Rows[i].Cells["clmRequiredQty"];
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
        private void GrdStockRequest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmRequiredQty")
                {
                    e.Control.KeyPress -= udfnHandleKeyPress;
                    e.Control.KeyPress += udfnHandleKeyPress;
                }
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmRequiredQty")
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
                int varDecimal = Convert.ToInt32(grdStockRequest.CurrentRow.Cells["clmUTDecimal"].Value);
                if (grdStockRequest.CurrentCell.OwningColumn.Name == "clmRequiredQty")
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
