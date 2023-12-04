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
        public int varModifiedFlag = 0;
        public int varID = 0;
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
                //grdGodownStock.Rows.Add("Godown1","100 Pkts");
                //grdGodownStock.Rows.Add("Godown2","200 Pkts");
                //grdGodownStock.ColumnHeadersVisible = false;
                dtStock.TableName = "TRN_StockRequest_Details";
                dtStock.Columns.Add("SRQ_PRID", typeof(int));
                dtStock.Columns.Add("SRQ_SLID", typeof(int));
                dtStock.Columns.Add("SRQ_RKID", typeof(int));
                dtStock.Columns.Add("SRQ_RequestedQty", typeof(float));
                dpDate.Value = DateTime.Today;
                udfnCmbConcern();
                cmbConcern.SelectedValue = 1;
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
            try
            {
                if (chkCompleted.Checked) { btnSave.Text = "Save && Print"; } else { btnSave.Text = "Save as Draft"; }
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
            if (btnSave.Text == "Save as Draft")
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
                txtProductNamePICode.BackColor = Color.White;
                if (txtProductNamePICode.Text == "")
                {
                    lblProduct.Text = "0";
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
                grdGodownStock.Rows.Clear();
                lvProduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductNamePICode.Text.Length > 0)
                {
                    objDs = objspdservice.udfnproductmasterlist(36, 0, 0, 0, 0, "", "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0, txtProductNamePICode.Text, 0,varProducts,"",null,0, null);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvProduct.Items.Add(objList);
                                }
                                lvProduct.Visible = true;
                                lvProduct.BringToFront();
                                lvProduct.Columns[0].Width = 150;
                                lvProduct.Columns[1].Width = 250;
                                lvProduct.Columns[2].Width = 100;
                                lvProduct.Columns[3].Width = 0;
                                lvProduct.Columns[4].Width = 0;
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
                    txtProductNamePICode.Text = selectedItem.SubItems[1].Text;
                    lblProduct.Text = selectedItem.SubItems[4].Text;
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
                SPDataService objspservice = new SPDataService();
                DataSet objDS;
                objDS = objspservice.udfnproductmasterlist(43,Convert.ToInt32(lblProduct.Text),0,0,0,"","","",0,0,0,0,0,0,0,0,0,0,0,0,0,"",0,"","",null,0,null);
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
                        if (objDS.Tables[2].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[2].Rows.Count; i++)
                            {
                                grdStockRequest.Rows.Add(grdStockRequest.Rows.Count + 1, Convert.ToString(objDS.Tables[2].Rows[i]["PR_PICode"]), Convert.ToString(objDS.Tables[2].Rows[i]["PR_TName"]), Convert.ToString(objDS.Tables[2].Rows[i]["RKG_Name"]), Convert.ToString(objDS.Tables[2].Rows[i]["RK_ShortName"]), Convert.ToString(objDS.Tables[2].Rows[i]["EMP_Name"]), Convert.ToString(txtRequiredQty.Text), Convert.ToString(objDS.Tables[2].Rows[i]["UT_Symbol"]),Convert.ToString(lblProduct.Text));
                            }
                            dtStock.Rows.Add(Convert.ToInt32(lblProduct.Text),0,0,Convert.ToString(txtRequiredQty.Text));
                            for(int j=0;j<grdStockRequest.Rows.Count;j++)
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

                            VarAdd = "0";
                            txttotalitem.Text = Convert.ToString(grdStockRequest.Rows.Count);
                            errStockRequest.Clear();
                            txtProductNamePICode.Text = "";
                            txtStockQty.Text = "";
                            txtRequiredQty.Text = "";
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
                    if(chkCompleted.Enabled==true)
                    {
                        chkCompleted.Focus();
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
                if (Convert.ToString(txtStockQty.Text).Trim() == "")
                {
                    errStockRequest.SetError(txtStockQty, "Invalid stock");
                    txtStockQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockQty.ShowAlways = true;
                    tpStockQty.Show("Invalid stock", txtStockQty, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtRequiredQty.Text).Trim() != "")
                {
                    if (Convert.ToInt32(txtStockQty.Text.Trim()) >= Convert.ToInt32(txtRequiredQty.Text.Trim()))
                    {
                        errStockRequest.Clear();
                        txtRequiredQty.BackColor = Color.White;
                    }
                    else
                    {
                        errStockRequest.SetError(txtRequiredQty, "Please enter valid quentity");
                        txtRequiredQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpRequiredQty.ShowAlways = true;
                        tpRequiredQty.Show("Please enter valid quentity", txtRequiredQty, 5000);
                        blnErrorFlag = true;
                    }
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
                int varProductID = 0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "", varSRKID = "";
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
                                grdStockRequest.Rows[i].Cells["clmdsno"].Value = i + 1;
                            }
                            varModifiedFlag = 1;
                            for (int i = 0; i < dtStock.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID) && Convert.ToString(dtStock.Rows[i]["STK_MRP"]) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToString(dtStock.Rows[i]["STK_Source_RKID"]) == varSRKID)
                                {
                                    dtStock.Rows[i].Delete();
                                    dtStock.AcceptChanges();
                                }
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
                if(chkCompleted.Checked==true)
                {
                    varStatus = 29;
                }
                else
                {
                    varStatus = 28;
                }
                if (btnSave.Text == "Save as Draft" || btnSave.Text== "Save && Print")
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
                objTRNS_StockRequest.paraStockRequestID = varID;
                objTRNS_StockRequest.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRNS_StockRequest.paraRequestDate = dpDate.Text;
                objTRNS_StockRequest.paraRemarks = txtRemarks.Text;
                objTRNS_StockRequest.paraStatusId = varStatus;
                objTRNS_StockRequest.paraOriginator = varoriginator;
                objTRNS_StockRequest.paraStockRequest = dtStock;
                varResult = objspservice.udfnStockRequest(objTRNS_StockRequest);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objINV_StockRequestList.udfnList();
                    varModifiedFlag = 0;
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
    }
}
