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
    public partial class INV_GodownOutward : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpExpiryDate = new ToolTip();
        private ToolTip tpMrp = new ToolTip();
        private ToolTip tpProduct = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpOutwardQuantity = new ToolTip();
        private ToolTip tpRemark = new ToolTip();
        private ToolTip tpTotalItem = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpTransactionType = new ToolTip();

        public string varStockLocationId = "";
        public int varCloseFlag = 0;
        public int varGOId = 0;
        public int varUpdate = 0,VarUpdateFlag=0;
        public int varCompanyId = 0, varDestSLID = 0, varDestRKID = 0;
        string varProductID = "", varMRP = "", varExpiryDate = "", varBatchNo = "",varRackId="";
        DataTable dtStock = new DataTable();
        public string vargroupcode;
        public String pbFormStatus;
        private bool varErrorFlag;
        public bool varChangeFlag=true;
        string result = "";
        public string varPICode = "", varPEname = "", varPTname = "", varPID = "", varUTID = "", varPRID = "", varRKID = "", varTotalItem = "", varUnit = "", varTransType = "";
        private int varviewtype = 0;

        public INV_GodownOutward()
        {
            InitializeComponent();
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
        public void udfnDiscard()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Discard Changes ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (varChangeFlag == false)
                {
                    udfnDiscard();
                }
                else 
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

        private void INV_GodownOutward_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
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
        private void cmbConcern_Enter(object sender, EventArgs e)
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
        private void txtStockLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void txtStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                txtStockLocation.BackColor = Color.White;
                if (txtStockLocation.Text == "")
                {
                    varStockLocationId = "0";
                    epGoodsOutward.SetError(txtStockLocation, "Please enter StockLocation");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter StockLocation", txtStockLocation, 5000);
                }
                else
                {
                    epGoodsOutward.Clear();
                    txtStockLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void txtStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvStockLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        cmbTransactionType.Focus();
                        lvStockLocation.Visible = false;
                    }
                    else
                    {
                        lvStockLocation.Focus();
                    }
                    if (lvStockLocation.Items.Count > 0)
                    {
                        lvStockLocation.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbTransactionType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    

        private void cmbTransactionType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbTransactionType.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epGoodsOutward.SetError(cmbTransactionType, "Please select TransactionType");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select TransactionType", cmbTransactionType, 5000);
                }
                else
                {
                    epGoodsOutward.Clear();
                    cmbTransactionType.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbTransactionType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtProduct.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProduct_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProduct.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtProduct_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtProduct.Text) == "")
                {
                    epGoodsOutward.SetError(txtProduct, "Please enter the product");
                    txtProduct.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter the product", txtProduct, 5000);
                   

                }
                else
                {
                    epGoodsOutward.Clear();
                    txtProduct.BackColor = Color.White;
                    tpProduct.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            //errPO.Clear();
        }

        private void TxtProduct_KeyDown(object sender, KeyEventArgs e)
    {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvproduct.Items.Count == 0 || txtProduct.Text == "")
                    {
                        txtOutwardQuantity.Focus();
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
                if (e.KeyCode == Keys.Enter)
                {
                    txtOutwardQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtOutwardQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtOutwardQuantity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOutwardQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtOutwardQuantity.Text).Trim() == "")
                {
                    epGoodsOutward.SetError(txtOutwardQuantity, "Please enter outward quantity");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter outward quantity", txtOutwardQuantity, 5000);

                }
                else
                {
                    epGoodsOutward.Clear();
                    txtOutwardQuantity.BackColor = Color.White;
                }
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

        private void TxtTotalItem_Enter(object sender, EventArgs e)
        {
            try
            {
                txtTotalItem.BackColor = Color.LemonChiffon;
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
                    epGoodsOutward.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epGoodsOutward.Clear();
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
                    dtpOutwardDate.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOutwardQuantity_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtRemark_KeyDown(object sender, KeyEventArgs e)
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

        private void TxtTotalItem_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbConcern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                udfnVocherno();
                DGV_inward.Rows.Clear();
                if (btnSave.Text == "Save")
                {
                    txtStockLocation.Text = "";
                    txtTotalItem.Text = Convert.ToString(DGV_inward.Rows.Count);
                }
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnVocherno()
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dtpOutwardDate.Text + "',103)");
                        varResult = objspdservice.udfngetPONO("42", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                        objspdservice.CloseConnection();
                        string[] varvalue = varResult.Split('~');
                        if (varResult != "")
                        {
                            txtOutwardNo.Text = varvalue[0];
                        }
                        else
                        {
                            SPDataService objDServ = new SPDataService();
                            string varMessage = objDServ.udfnGetMessages(75);
                            objDServ.CloseConnection();
                            txtOutwardNo.Text = "";
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
                }
                else
                {
                    txtOutwardNo.Text = "";
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

        private void CmbTransactionType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void INV_GodownOutward_Load(object sender, EventArgs e)
        {
            try
            {
                dtStock.TableName = "TRN_StockTransfer_Product_AutoComplete";
                dtStock.Columns.Add("STK_PRID", typeof(int));
                dtStock.Columns.Add("STK_MRP", typeof(string));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(string));
                dtStock.Columns.Add("STK_QTY", typeof(string));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(int));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(int));
                udfnCmbConcern();
                udfnTransactionData();
                dtpOutwardDate.MaxDate = DateTime.Now;
                DGV_inward.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
                if (btnSave.Text == "Save")
                {

                }
                else
                {
                    udfnEdit();
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

        private void Button1_Click(object sender, EventArgs e)
        {

        }


        public void udfnTransactionData()
        {
            DataBind objDataBind = new DataBind();
            objDataBind.BindComboBoxListSelected("DEF_Master", "MST_TransactionID = 24", "MST_DisplayText,MSTID", cmbTransactionType, "", "MST_DisplayText", "MSTID");
            objDataBind = null;
        }

        private void DtpOutwardDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                udfnVocherno();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtStockLocation_TextChanged(object sender, EventArgs e)
       {
            try
            {
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0)
                {
                    var ViewType = 23;
                    objDs = objspdservice.udfnStockLocationList(ViewType, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_TName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(), };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    lvStockLocation.Items.Add(objList);
                                }
                                lvStockLocation.Visible = true;
                            }
                            else
                            {
                                lvStockLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvStockLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvStockLocation.Visible = false;
                    }
                }
                else
                {
                    lvStockLocation.Visible = false;
                    lvStockLocation.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStockLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnLvStockLocation();
                cmbTransactionType.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnLvStockLocation()
        {
            try
            {
                if (txtStockLocation.Text != "")
                {
                    ListViewItem selectedItem = lvStockLocation.SelectedItems[0];
                    txtStockLocation.Text = selectedItem.SubItems[0].Text;
                    varStockLocationId = selectedItem.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvStockLocation.Visible = false;
            }
        }

        private void LvStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation();
                    cmbTransactionType.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProduct.Text.Length > 0)
                {
                    var ViewType = 37;
                    objDs = objspdservice.udfnproductmasterlist(ViewType, 0, 0, 0, 0, "", "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(varStockLocationId), 0, 0, 0, 0, txtProduct.Text, 0,"","",dtStock,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRID"].ToString(),objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PRODUCTLIST"].ToString(),objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["STK_Qty"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["UTID"].ToString(), objDs.Tables[0].Rows[i]["STK_RKID"].ToString(), objDs.Tables[0].Rows[i]["UT_Name"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[3].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.Columns[0].Width = 0;
                                lvproduct.Columns[1].Width = 100;
                                lvproduct.Columns[2].Width = 550;
                                lvproduct.Columns[3].Width = 220;
                                lvproduct.Columns[4].Width = 0;
                                lvproduct.Columns[5].Width = 0;
                                lvproduct.Columns[6].Width = 0;
                                lvproduct.Columns[7].Width = 0;
                                lvproduct.Columns[8].Width = 0;
                                lvproduct.Columns[9].Width = 0;
                                lvproduct.Columns[10].Width = 0;
                                lvproduct.Columns[11].Width = 0;
                                lvproduct.Columns[12].Width = 0;
                                lvproduct.Columns[13].Width = 0;

                            }
                            else
                            {
                                lvproduct.Visible = false;
                            }
                        }
                        else
                        {
                            lvproduct.Visible = false;
                        }
                    }
                    
                    else
                    {
                        lvproduct.Visible = false;
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
        }

        private void Lvproduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListviewProduct();
                txtOutwardQuantity.Focus();
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
                    txtOutwardQuantity.Focus();
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
                if (txtProduct.Text != "")
                {
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    varPRID = selectedItem.SubItems[0].Text;
                    txtProduct.Text = selectedItem.SubItems[3].Text;
                    varPICode = selectedItem.SubItems[1].Text;
                    txtRack.Text = selectedItem.SubItems[5].Text;
                    txtMrp.Text = selectedItem.SubItems[6].Text;
                    txtExpiryDate.Text = selectedItem.SubItems[7].Text;
                    txtBatchNo.Text = selectedItem.SubItems[8].Text;
                    txtStockQuantity.Text = selectedItem.SubItems[9].Text;
                    lblQuantity.Text = selectedItem.SubItems[10].Text;
                    varUTID = selectedItem.SubItems[11].Text;
                    varRKID = selectedItem.SubItems[12].Text;
                    varUnit = selectedItem.SubItems[10].Text;
                    //udfnProductAdd();
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

        private void INV_GodownOutward_Leave(object sender, EventArgs e)
        {
            try
            {
                tpConcern.Active = false;
                tpStockLocation.Active = false;
                tpTransactionType.Active = false;
                tpStockLocation.Active = false;
                tpProduct.Active = false;
                tpOutwardQuantity.Active = false;
                tpRemark.Active = false;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public DataTable udfnPurchaseProduct()
        {
            DataTable dtStock = new DataTable();
            try
            {
                dtStock.TableName = "TRN_StockTransfer_Product_AutoComplete";
                dtStock.Columns.Add("STK_PRID", typeof(int));
                dtStock.Columns.Add("STK_MRP", typeof(string));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(int));
                dtStock.Columns.Add("STK_QTY", typeof(string));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(int));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(int));
                for (int i = 0; i < DGV_inward.Rows.Count; i++)
                {
                    DataService objDser = new DataService();
                    dtStock.Rows.Add(Convert.ToInt32(DGV_inward.Rows[i].Cells["clmPRID"].Value), Convert.ToString(DGV_inward.Rows[i].Cells["clmmrp"].Value),
                    Convert.ToString(DGV_inward.Rows[i].Cells["clmExpiryDate"].Value), Convert.ToString(DGV_inward.Rows[i].Cells["clmBatchNo"].Value),
                    Convert.ToInt32(DGV_inward.Rows[i].Cells["clmUTID"].Value), Convert.ToString(DGV_inward.Rows[i].Cells["clmOutward"].Value),
                    Convert.ToString(DGV_inward.Rows[i].Cells["clmRKID"].Value),0,0);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return dtStock;
        }

        private void TxtOutwardQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void DtpOutwardDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnLvStockLocation();
                    txtStockLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtTotalItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void DGV_inward_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                int StockcellValue =Convert.ToInt32( DGV_inward.CurrentRow.Cells["clmQty"].Value);
                int OutwardcellValue = Convert.ToInt32(DGV_inward.CurrentRow.Cells["clmOutward"].Value);

                if (Convert.ToInt32(OutwardcellValue) > Convert.ToInt32(StockcellValue))
                {
                    DGV_inward.CurrentRow.Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //epGoodsOutward.SetError(DGV_inward, "Please enter valid outward qty");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter valid outward qty", DGV_inward, 5000);
                    SPDataService objDServ = new SPDataService();
                    objDServ.CloseConnection();
                    //MessageBox.Show("Please Enter Valid Outward Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DGV_inward.CurrentRow.Cells["clmOutward"].Style.BackColor = Color.PaleGreen;

                }
                object varEditQty = DGV_inward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // Update the same column value in the DataTable
                    dtStock.Rows[e.RowIndex]["STK_QTY"] = varEditQty;
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

            //MessageBox.Show($"Cell Value Changed: {cellValue}", "Cell Value Changed");
        }

        private void DGV_inward_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DGV_inward.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_inward.ClearSelection();

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
                SPDataService objspservice = new SPDataService();
                string varoriginator = ""; int ViewType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Goods Outward Creation";
                    ViewType = 0;
                }
                else
                {
                    varoriginator = "Goods Outward Updation";
                    ViewType = 1;
                }

                epGoodsOutward.Clear();
                bool blnErrorFlag = true;

                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epGoodsOutward.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtStockLocation.Text).Trim() == "")
                {
                    epGoodsOutward.SetError(txtStockLocation, "Please enter stock location");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter Stock location", txtStockLocation, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epGoodsOutward.SetError(cmbTransactionType, "Please select Transaction Type");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select Transaction Type", cmbTransactionType, 5000);
                    blnErrorFlag = false;
                }
                if (DGV_inward.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(53);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                }
                //if (DGV_inward.SelectedCells.Count>0)
                //{
                //    string OutwardQty = DGV_inward.Cells["clmOutward"].Value.ToString();
                //    int stockQtyRowIndex = DGV_inward.SelectedCells[0].RowIndex;
                //    int stockQtyColumnIndex = DGV_inward.SelectedCells[9].ColumnIndex;
                //    object cellValue = DGV_inward[stockQtyColumnIndex, stockQtyRowIndex].Value;
                //    MessageBox.Show(cellValue);
                //}
                //int StockcellValue = Convert.ToInt32(DGV_inward.CurrentRow.Cells["clmQty"].Value);
                //int OutwardcellValue = Convert.ToInt32(DGV_inward.CurrentRow.Cells["clmOutward"].Value);

                //if (Convert.ToInt32(OutwardcellValue) > Convert.ToInt32(StockcellValue))
                //{
                //    SPDataService objDServ = new SPDataService();
                //    string varMessage = objDServ.udfnGetMessages(53);
                //    objDServ.CloseConnection();
                //    MessageBox.Show("Please Enter Valid Outward Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    blnErrorFlag = false;
                //}
                if (blnErrorFlag == true)
                {
                    udfntooltiphide();
                    epGoodsOutward.Clear();
                    btnSave.Enabled = false;
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();
                    TRNS_GoodsOutward objTRNS_GoodsOutward = new TRNS_GoodsOutward();
                    objTRNS_GoodsOutward.ViewType = ViewType;
                    objTRNS_GoodsOutward.ParaGOId = varGOId;
                    objTRNS_GoodsOutward.ParaCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNS_GoodsOutward.paraOutwardDate = dtpOutwardDate.Text.Trim();
                    objTRNS_GoodsOutward.paraTransferType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                    objTRNS_GoodsOutward.paraRemarks = txtRemark.Text.Trim();
                    objTRNS_GoodsOutward.paraOutwardDate = dtpOutwardDate.Text;
                    objTRNS_GoodsOutward.paraSLID = Convert.ToInt32(varStockLocationId);
                    objTRNS_GoodsOutward.paraStockTransfer = dtStock;
                    objTRNS_GoodsOutward.paraOriginator = varoriginator;
                    result = objspdservice.udfnGoodsOutward(objTRNS_GoodsOutward);

                    objspdservice.CloseConnection();
                    string[] varvalue = result.Split('~');
                    if (varvalue[0] == "3")
                    {
                        MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = txtProduct;
                        MainForm.objINV_GodownOutwardList.udfnList();
                        udfnClear();
                        this.Close();
                    }
                    else
                    {
                        epGoodsOutward.Clear();
                        txtProduct.BackColor = Color.White;
                        MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnSave.Enabled = true;
                        btnSave.Focus();
                        if (varvalue[0] == "5")
                        {
                            //for (int i = 0; i < varFirstList.Length; i++)
                            //{
                            //    string[] varSecondList = varFirstList[i].Split(',');
                            //    string varPRID = varSecondList[0];
                            //    string varMRP = varSecondList[1];
                            //    string varExpiryDate = varSecondList[2];
                            //    string varBatchNo = varSecondList[3];
                                for (int j = 0; j < DGV_inward.RowCount; j++)
                                {
                                     DGV_inward.Rows[j].DefaultCellStyle.BackColor = Color.White;
                                    
                                    string[] varFirstList = varvalue[2].Split('|');
                                    for (int i = 0; i < varFirstList.Length; i++)
                                    {
                                        string[] varSecondList = varFirstList[i].Split(',');
                                        varProductID = varSecondList[0];
                                        varMRP = varSecondList[1];
                                        varExpiryDate = varSecondList[2];
                                        varBatchNo = varSecondList[3];
                                        varRackId = varSecondList[4];
                                    if (Convert.ToString(DGV_inward.Rows[j].Cells["clmPRID"].Value) == varProductID && Convert.ToString(DGV_inward.Rows[j].Cells["clmmrp"].Value) == varMRP && Convert.ToString(DGV_inward.Rows[j].Cells["clmExpirydate"].Value) == varExpiryDate && Convert.ToString(DGV_inward.Rows[j].Cells["clmBatchNo"].Value) == varBatchNo && Convert.ToString(DGV_inward.Rows[j].Cells["clmRKID"].Value) == varRackId)
                                    {

                                          DGV_inward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
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
                SPDataService objDServ = new SPDataService();
                string varMessage = objDServ.udfnGetMessages(48);
                objDServ.CloseConnection();
                MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                DGV_inward.ClearSelection();
            }
        }
        public void udfnClear()
        {

            btnSave.Enabled = true;
            cmbConcern.Text = "";
            txtOutwardNo.Text = "";
            txtStockLocation.Text = "";
            cmbTransactionType.Text = "";
        }
        public void udfntooltiphide()
        {
            try
            {
                epGoodsOutward.Clear();
                cmbConcern.BackColor = Color.White;
                tpConcern.Active = false;
                cmbTransactionType.BackColor = Color.White;
                tpTransactionType.Active = false;
                txtStockLocation.BackColor = Color.White;
                tpStockLocation.Active = false;
                txtProduct.BackColor = Color.White;
                tpProduct.Active = false;
                txtOutwardQuantity.BackColor = Color.White;
                tpOutwardQuantity.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        } 

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbTransactionType.SelectedValue) != 70) // Regular
                {
                    DGV_inward.Columns["clmrequestqty"].Width = 100;
                    DGV_inward.Columns["clmrequestqty"].Visible = true;
                }
                else // Stock Request
                {
                    DGV_inward.Columns["clmrequestqty"].Width = 0;
                    DGV_inward.Columns["clmrequestqty"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductClear()
        {
            txtProduct.Text = "";
            txtRack.Text = "";
            txtMrp.Text = "";
            txtExpiryDate.Text = "";
            txtBatchNo.Text = "";
            txtStockQuantity.Text = "";
            txtOutwardQuantity.Text = "";
            varPRID = "";
            varPICode = "";
            varRKID = "";
            varUTID = "";
            lblQuantity.Text = "Pkts";
        }

        private void DGV_inward_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0,varRKID=0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (DGV_inward.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(DGV_inward.SelectedRows[0].Cells["clmPRID"].Value);
                                varRKID = Convert.ToInt32(DGV_inward.SelectedRows[0].Cells["clmRKID"].Value);
                                varMRP = Convert.ToString(DGV_inward.SelectedRows[0].Cells["clmmrp"].Value);
                                varExpiryDate = Convert.ToString(DGV_inward.SelectedRows[0].Cells["clmExpirydate"].Value);
                                varBatchNo = Convert.ToString(DGV_inward.SelectedRows[0].Cells["clmBatchNo"].Value);
                                DGV_inward.Rows.RemoveAt(this.DGV_inward.SelectedRows[0].Index);
                                for (int i = 0; i < DGV_inward.RowCount; i++)
                                {
                                    DGV_inward.Rows[i].Cells["clmdsno"].Value = i + 1;
                                }
                                for (int i = 0; i < dtStock.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID) && Convert.ToInt32(dtStock.Rows[i]["STK_Source_RKID"]) == Convert.ToInt32(varRKID) && Convert.ToString(dtStock.Rows[i]["STK_MRP"]) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo)
                                    {
                                        dtStock.Rows[i].Delete();
                                        dtStock.AcceptChanges();
                                    }
                                }
                            }
                            break;
                    }
                }
                varChangeFlag = false;
            }

            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtTotalItem.Text = Convert.ToString(DGV_inward.Rows.Count);
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
                varErrorFlag = true;
                if (txtProduct.Text == "")
                {
                    epGoodsOutward.SetError(txtProduct, "Please enter product");
                    txtProduct.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProduct, 5000);
                    varErrorFlag = false;
                }
                if (txtRack.Text == "")
                {
                    epGoodsOutward.SetError(txtRack, "Please enter the RackName");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter the RackName", txtRack, 5000);
                    varErrorFlag = false;
                }
                if (txtMrp.Text == "")
                {
                    epGoodsOutward.SetError(txtMrp, "Please enter MRP");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter MRP", txtMrp, 5000);
                    varErrorFlag = false;
                }
                if (txtExpiryDate.Text == "")
                {
                    epGoodsOutward.SetError(txtExpiryDate, "Please enter ExpiryDate");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter ExpiryDate", txtExpiryDate, 5000);
                    varErrorFlag = false;
                }
                if (txtBatchNo.Text == "")
                {
                    epGoodsOutward.SetError(txtBatchNo, "Please enter Batch Number");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter Batch number", txtBatchNo, 5000);
                    varErrorFlag = false;
                }
                if (txtStockQuantity.Text == "")
                {
                    epGoodsOutward.SetError(txtStockQuantity, "Please enter Stock qty");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter Stock qty", txtStockQuantity, 5000);
                    varErrorFlag = false;
                }
                if (txtOutwardQuantity.Text == "")
                {
                    epGoodsOutward.SetError(txtOutwardQuantity, "Please enter outward qty");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter orderqty.", txtOutwardQuantity, 5000);
                    varErrorFlag = false;
                }

                if (varErrorFlag == true)
                {
                    int varflag = 0; 

                    if (varflag == 0)
                    {
                        if (Convert.ToInt32(txtOutwardQuantity.Text) > Convert.ToInt32(txtStockQuantity.Text))
                        {
                            epGoodsOutward.SetError(txtOutwardQuantity, "Please enter a correct Outward Quantity");
                            txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpOutwardQuantity.ShowAlways = true;
                            tpOutwardQuantity.Show("Please enter a correct Outward Quantity", txtOutwardQuantity, 5000);
                        }
                        else
                        {
                            DGV_inward.Rows.Add(DGV_inward.Rows.Count + 1,varPRID, varPICode, (txtProduct.Text).Trim(),varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtOutwardQuantity.Text).Trim(),varUnit, varUTID);
                            dtStock.Rows.Add(varPRID, (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), varUTID, (txtOutwardQuantity.Text).Trim(), varRKID, varDestSLID, varDestRKID);
                            txtTotalItem.Text = Convert.ToString(DGV_inward.Rows.Count);
                            //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                            DGV_inward.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            DGV_inward.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            DGV_inward.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            DGV_inward.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            udfnProductClear();
                            txtProduct.Focus();
                            
                        }
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(70);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                varChangeFlag = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                DGV_inward.Rows.Count.ToString();
                //DGV_inward.Sort(DGV_inward.Columns["clmpicode"], ListSortDirection.Ascending);

            }

        }

        private void Lvproduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void udfnProductAdd()
        {
            try
            {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    objDs = objspdservice.udfnproductmasterlist(13, 0, 0, 0, 0, "", "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, txtProduct.Text, 0, "","",dtStock,0);

                if (objDs != null)
                {
                    if (objDs.Tables[0].Rows.Count > 0)
                    {
                       
                            varPICode = objDs.Tables[0].Rows[0]["P.I Code"].ToString();
                            varPEname = objDs.Tables[0].Rows[0]["Product Name in English"].ToString();
                            varPTname = objDs.Tables[0].Rows[0]["Product Name in Tamil"].ToString();
                            varPID = objDs.Tables[0].Rows[0]["PRODUCTID"].ToString();
                     
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
        public void udfnEdit()
        {
            try
            {
                if (varGOId != 0)
                {
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    int ViewType = 1;
                    objDs = objdserv.udfnGOList(ViewType, varGOId,0, "", "", 0, 0);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["GO_COMID"].ToString();
                            dtpOutwardDate.Text = objDs.Tables[0].Rows[0]["GO_Date"].ToString();
                            txtOutwardNo.Text = objDs.Tables[0].Rows[0]["GO_No"].ToString();
                            varStockLocationId = objDs.Tables[0].Rows[0]["GO_SLID"].ToString();
                            txtStockLocation.Text = objDs.Tables[0].Rows[0]["Stock Location"].ToString();
                            varTransType = objDs.Tables[0].Rows[0]["GO_TransactionType"].ToString();
                            cmbTransactionType.Text = objDs.Tables[0].Rows[0]["Transaction Type"].ToString();
                            txtRemark.Text = objDs.Tables[0].Rows[0]["Remarks"].ToString();
                            btnSave.Text = "Update";
                        }
                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                DGV_inward.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]),Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_EName"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]),Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GOPR_ReqQty"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GOPR_OutwardQty"]),Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]));
                                dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["GOPR_OutwardQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]),0,0);
                                DGV_inward.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                DGV_inward.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                DGV_inward.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                DGV_inward.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //DGV_inward.Rows.Add(DGV_inward.Rows.Count + 1, varPRID, varPICode, (txtProduct.Text).Trim(), varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtOutwardQuantity.Text).Trim(), varUnit, varUTID);
                                //DGV_inward.Columns[10].ReadOnly = false;
                            }
                            btnSave.Text = "Update";
                        }
                    }
                    lvStockLocation.Visible = false;
                    cmbConcern.Enabled = false;
                    dtpOutwardDate.Enabled = false;
                    txtOutwardNo.Enabled = false;
                    txtStockLocation.Enabled = false;
                    cmbTransactionType.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txtTotalItem.Text = Convert.ToString(DGV_inward.Rows.Count);
            }
        }

     }                 
}




