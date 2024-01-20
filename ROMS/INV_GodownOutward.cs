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

        public string varStockLocationId = "", varTamilname="";
        public string varStockApplicable = "";
        public int varErrQty = 0;
        public int varCloseFlag = 0;
        public int varGOId = 0;
        public int varSTSID = 0;
        public int varUpdate = 0,VarUpdateFlag=0;
        public int varCompanyId = 0, varDestSLID = 0, varDestRKID = 0,varStatusId=0;
        string varProductID = "", varMRP = "", varExpiryDate = "", varBatchNo = "",varRackId="";
        DataTable dtStock = new DataTable();
        public string vargroupcode;
        public String pbFormStatus;
        private bool varErrorFlag;
        public bool varChangeFlag=true;
        public bool VarSearchFlag = true;
        string SLID = "";
        int GOId = 0;
        string varLocation="";
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
                    lvproduct.Visible = false;
                    lvStockLocation.Visible = false;
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
                lvproduct.Visible = false;
                lvStockLocation.Visible = false;
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
                lvproduct.Visible = false;
                //udfnLvStockLocation();
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
                    epGoodsOutward.SetError(txtStockLocation, "Please enter stock location");
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location", txtStockLocation, 5000);
                }
                else
                {
                    epGoodsOutward.Clear();
                    txtStockLocation.BackColor = Color.White;
                }
                //if (varStockLocationId != SLID)
                //{
                //    MessageBox.Show("This will clear all the records from the grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    DGV_inward.Rows.Clear();
                //}
                //if (DGV_inward.Rows.Count > 0)
                //{
                //    udfnSLocationValid();
                //    if (Convert.ToString(SLID) != Convert.ToString(varStockLocationId))
                //    {
                //        SPDataService objDServ = new SPDataService();
                //        string varMessage = objDServ.udfnGetMessages(78);
                //        objDServ.CloseConnection();
                //        DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (dialogResult == DialogResult.Yes)
                //        {
                //            DGV_inward.Rows.Clear();
                //            dtStock.Rows.Clear();
                //            txtStockLocation.Focus();
                //        }
                //        else
                //        {
                //            varStockLocationId = varLocation;
                //        }
                //    }
                //}
                //lvStockLocation.Visible = false;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            //finally
            //{
            //    lvStockLocation.Visible = false;
            //}

        }

        private void txtStockLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvStockLocation.Items.Count == 0 || txtStockLocation.Text == "")
                    {
                        txtProduct.Focus();
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
                    txtProduct.Focus();
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
                lvproduct.Visible = false;
                lvStockLocation.Visible = false;
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
                    epGoodsOutward.SetError(cmbTransactionType, "Please select transaction type");
                    cmbTransactionType.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransactionType.ShowAlways = true;
                    tpTransactionType.Show("Please select transaction type", cmbTransactionType, 5000);
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
                lvStockLocation.Visible = false;
                //udfnListviewProduct();
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
            //finally
            //{
            //    lvproduct.Visible = false;
            //}
            //errPO.Clear();
        }

        private void TxtProduct_KeyDown(object sender, KeyEventArgs e)
    {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvproduct.Items.Count == 0 && txtProduct.Text == "")
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
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblProductName.Text = "Search by P.I Code";
                        txtProduct.CharacterCasing = CharacterCasing.Upper;

                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductName.Text = "Search by Product Name";
                        txtProduct.CharacterCasing = CharacterCasing.Normal;
                    }
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
                lvproduct.Visible = false;
                lvStockLocation.Visible = false;
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
                grdGoodsOutward.Rows.Clear();
                if (btnSave.Text == "Save as Draft")
                {
                    txtStockLocation.Text = "";
                    txtTotalItem.Text = Convert.ToString(grdGoodsOutward.Rows.Count);
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
                if (btnSave.Text == "Save as Draft")
                {
                    if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                    {
                        string vardate = "", varResult = "";
                        SPDataService objspdservice = new SPDataService();
                        DataSet objDs = new DataSet();
                        DataService objDservice = new DataService();
                        vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dtpOutwardDate.Text + "',103)");
                        varResult = objspdservice.udfngetVoucherNo("42", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
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
                dtStock.Columns.Add("STK_MRP", typeof(decimal));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(string));
                dtStock.Columns.Add("STK_QTY", typeof(string));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(int));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(int));
                udfnCmbConcern();
                cmbConcern.SelectedValue = MainForm.pbDefaultComId;
                udfnTransactionData();
                //dtpOutwardDate.MaxDate = DateTime.Now;
                dtpOutwardDate.MaxDate = MainForm.pbCurrentDate;
                grdGoodsOutward.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
                //txtStockLocation.BackColor = Color.White;
                lblProductName.Text = "Search by P.I Code";
                VarSearchFlag = true;
                if (varGOId == 0)
                {
                    this.ActiveControl = txtStockLocation;
                }
                else
                {
                    this.ActiveControl = txtProduct;
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
        public void udfnSLocationValid()
        {
            try
            {
                /* Check purchase stock location is valid or not*/
                string varId_PurLocation = "0";
                if (txtStockLocation.Text == "")
                {
                    varId_PurLocation = "0";
                }
                else
                {
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtStockLocation.Text, 0, 0, 0,"","");
                    objDServ3.CloseConnection();
                    if (objDsPurLoc != null)
                    {
                        if (objDsPurLoc.Tables.Count > 0)
                        {
                            if (objDsPurLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                }
                varStockLocationId = Convert.ToString(varId_PurLocation);
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
                txtProduct.Text = "";
                txtRack.Text = "";
                txtMrp.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStockQuantity.Text = "";
                txtOutwardQuantity.Text = "";
                lblQuantity.Text = "";
                udfnSLocationValid();
                lvStockLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtStockLocation.Text.Length > 0 || txtStockLocation.Text == " ")
                {
                    var ViewType = 23;
                    objDs = objspdservice.udfnStockLocationList(ViewType, Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, txtStockLocation.Text, 0, 0, 0,"","");
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
                                    objList.SubItems[1].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
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
                txtProduct.Focus();
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
                    txtProduct.Focus();
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
                if (VarSearchFlag == true)
                {
                    txtProduct.CharacterCasing = CharacterCasing.Upper;
                }
                else
                {
                    txtProduct.CharacterCasing = CharacterCasing.Normal;
                }
                txtRack.Text = "";
                txtMrp.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStockQuantity.Text = "";
                txtOutwardQuantity.Text = "";
                lblQuantity.Text = "";
                SLID = varStockLocationId;
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProduct.Text.Length > 0 || txtProduct.Text==" ")
                {
                    var ViewType = 37;
                    int varEntry = 0;
                    if (btnSave.Text == "Update") { varEntry = varGOId; }
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = ViewType;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objMR_Product.paraLocationId = Convert.ToInt32(varStockLocationId);
                    objMR_Product.paraStockTransfer = dtStock;
                    objMR_Product.paraId = varEntry;
                    if (VarSearchFlag == false)
                    {
                        objMR_Product.paraProductName = txtProduct.Text;
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    }
                    else
                    {
                        objMR_Product.paraPicode = txtProduct.Text;
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
                                    string[] row = { objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["PRODUCTLIST"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["STK_Qty"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["UTID"].ToString(), objDs.Tables[0].Rows[i]["STK_RKID"].ToString(), objDs.Tables[0].Rows[i]["UT_Name"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.Columns[0].Width = 0;
                                lvproduct.Columns[1].Width = 100;
                                lvproduct.Columns[2].Width = 300;
                                lvproduct.Columns[3].Width = 300;
                                lvproduct.Columns[4].Width = 0;
                                lvproduct.Columns[5].Width = 60;
                                lvproduct.Columns[6].Width = 60;
                                lvproduct.Columns[7].Width = 90;
                                lvproduct.Columns[8].Width = 80;
                                lvproduct.Columns[9].Width = 70;
                                lvproduct.Columns[10].Width = 50;

                                if (VarSearchFlag == false)
                                {
                                    lvproduct.Columns[3].Width = 320;
                                    lvproduct.Columns[2].Width = 0;
                                }
                                else
                                {
                                    lvproduct.Columns[3].Width = 0;
                                    lvproduct.Columns[2].Width = 320;
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
                //stxtProduct.BackColor = Color.White;
                epGoodsOutward.Clear();
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
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    varPRID = selectedItem.SubItems[0].Text;
                    txtProduct.Text = selectedItem.SubItems[3].Text;
                    varTamilname = selectedItem.SubItems[2].Text;
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
                    txtStockQuantity.TextAlign = HorizontalAlignment.Right;
                    txtMrp.TextAlign = HorizontalAlignment.Right;
                    //udfnProductAdd(); 
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
                dtStock.Columns.Add("STK_MRP", typeof(decimal));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(int));
                dtStock.Columns.Add("STK_QTY", typeof(string));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(int));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(int));
                for (int i = 0; i < grdGoodsOutward.Rows.Count; i++)
                {
                    DataService objDser = new DataService();
                    dtStock.Rows.Add(Convert.ToInt32(grdGoodsOutward.Rows[i].Cells["clmPRID"].Value), Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmmrp"].Value),
                    Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmExpiryDate"].Value), Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmBatchNo"].Value),
                    Convert.ToInt32(grdGoodsOutward.Rows[i].Cells["clmUTID"].Value), Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmOutward"].Value),
                    Convert.ToString(grdGoodsOutward.Rows[i].Cells["clmRKID"].Value),0,0);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            return dtStock;
        }

        private void TxtStockQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtStockQuantity.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMrp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMrp.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtExpiryDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtExpiryDate.TextAlign = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvStockLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                //    if (DGV_inward.Rows.Count > 0)
                //    {
                //        udfnSLocationValid();
                //        if (Convert.ToString(SLID) != Convert.ToString(varStockLocationId))
                //        {
                //            //SPDataService objDServ = new SPDataService();
                //            //string varMessage = objDServ.udfnGetMessages(78);
                //            //objDServ.CloseConnection();
                //            DialogResult dialogResult = MessageBox.Show("This will clear all the products from the Grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            DGV_inward.Rows.Clear();
                //            dtStock.Rows.Clear();
                //            txtStockLocation.Focus();
                //            //varStockLocationId = varLocation;
                //        }
                //    }
                //    lvStockLocation.Visible = false;&

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DtpOutwardDate_Enter(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
                lvStockLocation.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_inward_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (grdGoodsOutward.CurrentCell.OwningColumn.Name == "clmOutward")

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
        public void allowonlynumber(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdGoodsOutward.CurrentCell.OwningColumn.Name == "clmOutward")
                {
                    if (!(char.IsDigit(e.KeyChar)||char.IsControl(e.KeyChar)||e.KeyChar == '.'))
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

        private void TxtProduct_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtOutwardQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool udfnIsSpecialCharacter(char integers)
                {

                    string allowedCharacters = "0123456789\b";
                    return !allowedCharacters.Contains(integers);
                }
                if (udfnIsSpecialCharacter(e.KeyChar))
                {
                    // Cancel the keypress event if the character is a special character
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGoodsOutward_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int StockcellValue = Convert.ToInt32(grdGoodsOutward.CurrentRow.Cells["clmQty"].Value);
                int OutwardcellValue = Convert.ToInt32(grdGoodsOutward.CurrentRow.Cells["clmOutward"].Value);

                if (Convert.ToInt32(OutwardcellValue) > Convert.ToInt32(StockcellValue))
                {
                    grdGoodsOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //epGoodsOutward.SetError(DGV_inward, "Please enter valid outward qty");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter valid outward quantity", grdGoodsOutward, 5000);
                    SPDataService objDServ = new SPDataService();
                    objDServ.CloseConnection();
                    varErrQty = 1;
                    //MessageBox.Show("Please Enter Valid Outward Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(Convert.ToString(OutwardcellValue)=="" || Convert.ToString(OutwardcellValue) == "0")
                {
                    grdGoodsOutward.Rows[e.RowIndex].Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    varErrQty =1;
                }
                else
                {
                    grdGoodsOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = Color.PaleGreen;
                    varErrQty = 0;

                }
                object varEditQty = grdGoodsOutward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                // Update the same column value in the DataTable
                dtStock.Rows[e.RowIndex]["STK_QTY"] = varEditQty;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CbCompleted_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int varStatusId = 0;
                if (cbCompleted.Checked)
                {
                    BtnSave_Click(sender,e);
                }
                else
                {
                    btnSave.Text = "Save as Draft";
                }
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

        private void CbCompleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbCompleted.Checked)
                {
                    btnSave.Text = "Save";
                    varStatusId = 26;
                }
                else
                {
                    btnSave.Text = "Save as Draft";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void GrdGoodsOutward_Enter(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
                lvStockLocation.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtOutwardQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtOutwardQuantity.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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

                int StockcellValue =Convert.ToInt32( grdGoodsOutward.CurrentRow.Cells["clmQty"].Value);
                int OutwardcellValue = Convert.ToInt32(grdGoodsOutward.CurrentRow.Cells["clmOutward"].Value);

                if (Convert.ToInt32(OutwardcellValue) > Convert.ToInt32(StockcellValue))
                {
                    grdGoodsOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    //epGoodsOutward.SetError(DGV_inward, "Please enter valid outward qty");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please enter valid outward quantity", grdGoodsOutward, 5000);
                    SPDataService objDServ = new SPDataService();
                    objDServ.CloseConnection();
                    //MessageBox.Show("Please Enter Valid Outward Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    grdGoodsOutward.CurrentRow.Cells["clmOutward"].Style.BackColor = Color.PaleGreen;

                }
                object varEditQty = grdGoodsOutward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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
                grdGoodsOutward.Columns["clmOutward"].DefaultCellStyle.BackColor = Color.PaleGreen;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdGoodsOutward.ClearSelection();

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
                varoriginator = "Goods Outward Creation";
                ViewType = 0;
                bool GOID = Convert.ToBoolean(varGOId);
                if (btnSave.Text == "Save as Draft" && cbCompleted.Checked == false && !GOID)
                {
                    ViewType = 0;
                    varStatusId = 35;
                }
                else if (btnSave.Text == "Save" && cbCompleted.Checked == true && GOID)
                {
                    ViewType = 0;
                    varStatusId = 26;
                }
                else if (btnSave.Text == "Save" && cbCompleted.Checked == true && !GOID)
                {
                    ViewType = 0;
                    varStatusId = 26;
                }
                else if (btnSave.Text == "Save as Draft" && cbCompleted.Checked == false && GOID)
                {
                    ViewType = 0;
                    varStatusId = 35;
                }
                //if(btnSave.Text=="Save as Draft")
                //{
                //    ViewType = 0;
                //    varStatusId = 35;
                //    varoriginator = "Goods Outward Creation";
                //}
                //if (btnSave.Text == "Save")
                //{
                //    ViewType = 0;
                //    varStatusId = 26;
                //    varoriginator = "Goods Outward Updation";
                //}
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
                    tpStockLocation.Show("Please enter stock location", txtStockLocation, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(cmbTransactionType.SelectedValue) == "" || Convert.ToString(cmbTransactionType.SelectedValue) == "-1")
                {
                    epGoodsOutward.SetError(cmbTransactionType, "Please select transaction type");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select transaction type", cmbTransactionType, 5000);
                    blnErrorFlag = false;
                }
                //if (txtStockLocation.Text !="")
                //{
                //        /* Check purchase stock location is valid or not*/
                //        string varId_PurLocation = "0";
                //        if (txtStockLocation.Text == "")
                //        {
                //            varId_PurLocation = "0";
                //        }
                //        else
                //        {
                //            DataSet objDsPurLoc = new DataSet();
                //            SPDataService objDServ3 = new SPDataService();
                //            objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtStockLocation.Text, 0, 0, 0);
                //            objDServ3.CloseConnection();
                //            if (objDsPurLoc != null)
                //            {
                //                if (objDsPurLoc.Tables.Count > 0)
                //                {
                //                    if (objDsPurLoc.Tables[0].Rows.Count > 0)
                //                    {
                //                        varId_PurLocation = Convert.ToString(objDsPurLoc.Tables[0].Rows[0][0]);
                //                    }
                //                }
                //            }
                //        }
                //        varStockLocationId = Convert.ToString(varId_PurLocation);
                //    }          
                if (grdGoodsOutward.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(38);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                }
                if(varErrQty==1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(89);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                }
                if (blnErrorFlag == true)
                {
                    udfntooltiphide();
                    epGoodsOutward.Clear();
                    SPDataService objspdservice = new SPDataService();
                    DataTable objGrnPO = new DataTable();
                    TRN_GoodsOutward objTRNS_GoodsOutward = new TRN_GoodsOutward();
                    objTRNS_GoodsOutward.ViewType = ViewType;
                    objTRNS_GoodsOutward.ParaGOId = varGOId;
                    objTRNS_GoodsOutward.ParaCompanyCode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNS_GoodsOutward.paraOutwardDate = dtpOutwardDate.Text;
                    objTRNS_GoodsOutward.paraTransferType = Convert.ToInt32(cmbTransactionType.SelectedValue);
                    objTRNS_GoodsOutward.paraRemarks = txtRemark.Text.Trim();
                    objTRNS_GoodsOutward.paraSLID = Convert.ToInt32(varStockLocationId);
                    objTRNS_GoodsOutward.paraStockTransfer = dtStock;
                    objTRNS_GoodsOutward.paraOriginator = varoriginator;
                    objTRNS_GoodsOutward.paraStatusId = varStatusId;
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
                            for (int j = 0; j < grdGoodsOutward.RowCount; j++)
                            {
                                grdGoodsOutward.Rows[j].DefaultCellStyle.BackColor = Color.White;

                                string[] varFirstList = varvalue[2].Split('|');
                                for (int i = 0; i < varFirstList.Length; i++)
                                {
                                    string[] varSecondList = varFirstList[i].Split(',');
                                    varProductID = varSecondList[0];
                                    varMRP = varSecondList[1];
                                    varExpiryDate = varSecondList[2];
                                    varBatchNo = varSecondList[3];
                                    varRKID = varSecondList[4];
                                    if (Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmPRID"].Value) == varProductID && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmExpirydate"].Value) == varExpiryDate && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmBatchNo"].Value) == varBatchNo && Convert.ToString(grdGoodsOutward.Rows[j].Cells["clmRKID"].Value) == varRKID)
                                    {

                                        grdGoodsOutward.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
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
                grdGoodsOutward.ClearSelection();
            }
        }
        public void udfnClear()
        {
            try
            {
                btnSave.Enabled = true;
                cmbConcern.Text = "";
                txtOutwardNo.Text = "";
                txtStockLocation.Text = "";
                cmbTransactionType.Text = "";
                lblQuantity.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
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
                //txtProduct.BackColor = Color.White;
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
                    grdGoodsOutward.Columns["clmrequestqty"].Width = 100;
                    grdGoodsOutward.Columns["clmrequestqty"].Visible = true;
                }
                else // Stock Request
                {
                    grdGoodsOutward.Columns["clmrequestqty"].Width = 0;
                    grdGoodsOutward.Columns["clmrequestqty"].Visible = false;
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
            try
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
                lblQuantity.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_inward_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0,varRKID=0;
                string varMRP = "", varExpiryDate = "", varBatchNo = "";
                if (e.RowIndex != -1)
                {
                    switch (grdGoodsOutward.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                varProductID = Convert.ToInt32(grdGoodsOutward.SelectedRows[0].Cells["clmPRID"].Value);
                                //varMRP = Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmmrp"].Value);
                                varMRP = string.Format("{0:G29}", decimal.Parse(Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmmrp"].Value)));
                                varExpiryDate = Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmExpirydate"].Value);
                                varBatchNo = Convert.ToString(grdGoodsOutward.SelectedRows[0].Cells["clmBatchNo"].Value);
                                varRKID = Convert.ToInt32(grdGoodsOutward.SelectedRows[0].Cells["clmRKID"].Value);
                                grdGoodsOutward.Rows.RemoveAt(this.grdGoodsOutward.SelectedRows[0].Index);
                                for (int i = 0; i < grdGoodsOutward.RowCount; i++)
                                {
                                    grdGoodsOutward.Rows[i].Cells["clmdsno"].Value = i + 1;
                                }
                                for (int i = 0; i < dtStock.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtStock.Rows[i]["STK_PRID"]) == Convert.ToInt32(varProductID)  && string.Format("{0:G29}", decimal.Parse(Convert.ToString(dtStock.Rows[i]["STK_MRP"]))) == varMRP && Convert.ToString(dtStock.Rows[i]["STK_ExpiryDate"]) == varExpiryDate && Convert.ToString(dtStock.Rows[i]["STK_BatchNo"]) == varBatchNo && Convert.ToInt32(dtStock.Rows[i]["STK_Source_RKID"]) == Convert.ToInt32(varRKID))
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
                txtTotalItem.Text = Convert.ToString(grdGoodsOutward.Rows.Count);
                if (grdGoodsOutward.Rows.Count > 0)
                {
                    cmbConcern.Enabled = false;
                    txtStockLocation.Enabled = false;
                }
                else
                {
                    cmbConcern.Enabled = true;
                    txtStockLocation.Enabled = true;
                    txtStockLocation.BackColor = Color.White;
                    cmbConcern.BackColor = Color.White;

                }
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
                    epGoodsOutward.SetError(txtProduct, "Please enter product name");
                    txtProduct.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProduct.ShowAlways = true;
                    tpProduct.Show("Please enter product name", txtProduct, 5000);
                    varErrorFlag = false;
                }
                if (txtRack.Text == "")
                {
                    epGoodsOutward.SetError(txtRack, "Please enter the rack name");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter the rack name", txtRack, 5000);
                    varErrorFlag = false;
                }
                //if (txtMrp.Text == "")
                //{
                //    epGoodsOutward.SetError(txtMrp, "Please enter mrp");
                //    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpOutwardQuantity.ShowAlways = true;
                //    tpOutwardQuantity.Show("Please enter mrp", txtMrp, 5000);
                //    varErrorFlag = false;
                //}
                //if (txtExpiryDate.Text == "")
                //{
                //    epGoodsOutward.SetError(txtExpiryDate, "Please enter expiry date");
                //    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpOutwardQuantity.ShowAlways = true;
                //    tpOutwardQuantity.Show("Please enter expiry date", txtExpiryDate, 5000);
                //    varErrorFlag = false;
                //}
                //if (txtBatchNo.Text == "")
                //{
                //    epGoodsOutward.SetError(txtBatchNo, "Please enter batch number");
                //    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpOutwardQuantity.ShowAlways = true;
                //    tpOutwardQuantity.Show("Please enter batch number", txtBatchNo, 5000);
                //    varErrorFlag = false;
                //}
                if (txtStockQuantity.Text == "")
                {
                    epGoodsOutward.SetError(txtStockQuantity, "Please enter stock quantity");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter stock quantity", txtStockQuantity, 5000);
                    varErrorFlag = false;
                }
                if (txtOutwardQuantity.Text == "")
                {
                    epGoodsOutward.SetError(txtOutwardQuantity, "Please enter outward quantity");
                    txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpOutwardQuantity.ShowAlways = true;
                    tpOutwardQuantity.Show("Please enter outward quantity", txtOutwardQuantity, 5000);
                    varErrorFlag = false;
                }

                if (varErrorFlag == true)
                {
                    int varflag = 0;

                    if (varflag == 0)
                    {
                        if (Convert.ToInt32(txtOutwardQuantity.Text) > Convert.ToInt32(txtStockQuantity.Text) || Convert.ToInt32(txtOutwardQuantity.Text)==0)
                        {
                            txtOutwardQuantity.Focus();
                            epGoodsOutward.SetError(txtOutwardQuantity, "Please enter a valid outward quantity");
                            txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tpOutwardQuantity.ShowAlways = true;
                            tpOutwardQuantity.Show("Please enter a valid outward quantity", txtOutwardQuantity, 5000);
                        }
                        else
                        {
                            grdGoodsOutward.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                            grdGoodsOutward.Rows.Add(grdGoodsOutward.Rows.Count + 1, varPRID, varPICode, (varTamilname), varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtOutwardQuantity.Text).Trim(), varUnit, varUTID);
                            dtStock.Rows.Add(varPRID, string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtMrp.Text.Trim()))), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), varUTID, (txtOutwardQuantity.Text).Trim(), varRKID, varDestSLID, varDestRKID);
                            txtTotalItem.Text = Convert.ToString(grdGoodsOutward.Rows.Count);
                            //varTotalItem = Convert.ToString(DGV_inward.Rows.Count);
                            grdGoodsOutward.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdGoodsOutward.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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


                    varChangeFlag = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                grdGoodsOutward.Rows.Count.ToString();
                grdGoodsOutward.ClearSelection();
                if (grdGoodsOutward.Rows.Count > 0)
                {
                    txtStockLocation.Enabled = false;
                    cmbConcern.Enabled = false;
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
                }
                else
                {
                    //txtStockLocation.BackColor =Color.White;
                    cmbConcern.Enabled = true;
                    txtStockLocation.Enabled = true;
                }
                //DGV_inward.Sort(DGV_inward.Columns["clmpicode"], ListSortDirection.Ascending);

            }

        }

        private void Lvproduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //public void udfnProductAdd()
        //{
        //    try
        //    {
        //            SPDataService objspdservice = new SPDataService();
        //            DataSet objDs = new DataSet();
        //            objDs = objspdservice.udfnproductmasterlist(13, 0, 0, 0, 0, "", "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, txtProduct.Text, 0,"","",dtStock,0,null,"","");

        //        if (objDs != null)
        //        {
        //            if (objDs.Tables[0].Rows.Count > 0)
        //            {
                       
        //                    varPICode = objDs.Tables[0].Rows[0]["P.I Code"].ToString();
        //                    varPEname = objDs.Tables[0].Rows[0]["Product Name in English"].ToString();
        //                    varPTname = objDs.Tables[0].Rows[0]["Product Name in Tamil"].ToString();
        //                    varPID = objDs.Tables[0].Rows[0]["PRODUCTID"].ToString();
                     
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //    finally
        //    {
        //        lvproduct.Visible = false;
        //    }
        //}
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
                    TRN_GoodsOutward objTRNG_GoodsOutward = new TRN_GoodsOutward();
                    objTRNG_GoodsOutward.ViewType = ViewType;
                    objTRNG_GoodsOutward.ParaGOId = Convert.ToInt32(varGOId);
                    objDs = objdserv.udfnGOList(objTRNG_GoodsOutward);
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
                        }

                        if (objDs.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                            {
                                grdGoodsOutward.Columns["clmproductname"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                grdGoodsOutward.Rows.Add(Convert.ToString(objDs.Tables[1].Rows[i]["S.No"]), Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]),Convert.ToString(objDs.Tables[1].Rows[i]["PR_PICode"]), Convert.ToString(objDs.Tables[1].Rows[i]["PR_TName"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]),Convert.ToString(objDs.Tables[1].Rows[i]["RK_ShortName"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),
                                Convert.ToString(objDs.Tables[1].Rows[i]["STKQTY"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GOPR_ReqQty"]), Convert.ToInt32(objDs.Tables[1].Rows[i]["GOPR_OutwardQty"]),Convert.ToString(objDs.Tables[1].Rows[i]["UT_Symbol"]), Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]));
                                dtStock.Rows.Add(Convert.ToInt32(objDs.Tables[1].Rows[i]["PRID"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_MRP"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_ExpiryDate"]), Convert.ToString(objDs.Tables[1].Rows[i]["STK_BatchNo"]),Convert.ToString(objDs.Tables[1].Rows[i]["UTID"]), Convert.ToString(objDs.Tables[1].Rows[i]["GOPR_OutwardQty"]), Convert.ToString(objDs.Tables[1].Rows[i]["RKID"]),0,0);
                                grdGoodsOutward.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGoodsOutward.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGoodsOutward.Columns["clmOutward"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdGoodsOutward.Columns["clmExpiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //DGV_inward.Rows.Add(DGV_inward.Rows.Count + 1, varPRID, varPICode, (txtProduct.Text).Trim(), varRKID, (txtRack.Text).Trim(), (txtMrp.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtStockQuantity.Text).Trim(), 0, (txtOutwardQuantity.Text).Trim(), varUnit, varUTID);
                                //DGV_inward.Columns[10].ReadOnly = false;
                            }
                        }
                    }
                    
                    lvStockLocation.Visible = false;
                    cmbConcern.Enabled = false;
                    dtpOutwardDate.Enabled = false;
                    txtOutwardNo.Enabled = false;
                    txtStockLocation.Enabled = false;
                    cmbTransactionType.Enabled = false;
                    epGoodsOutward.Clear();
                    udfntooltiphide();
                    txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                    if (varSTSID == 26)
                    {
                        txtProduct.Enabled = false;
                        txtOutwardQuantity.Enabled = false;
                        txtRemark.Enabled = false;
                        cbCompleted.Checked = true;
                        btnSave.Enabled = false;
                        cbCompleted.Enabled = false;
                        btnAdd.Enabled = false;
                        txtProduct.BackColor = Color.White;
                        this.ActiveControl = btnClose;
                        epGoodsOutward.Clear();
                        grdGoodsOutward.ReadOnly = true;
                        udfntooltiphide();
                        txtStockLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtProduct.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        txtOutwardQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0f0");
                        for (int i = 0; i < grdGoodsOutward.Rows.Count; i++)
                        {
                            ((DataGridViewImageCell)grdGoodsOutward.Rows[i].Cells["clmRemove"]).Value = new System.Drawing.Bitmap(1, 1);
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
                grdGoodsOutward.ClearSelection();
                txtTotalItem.Text = Convert.ToString(grdGoodsOutward.Rows.Count);
            }
        }

     }                 
}




