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
    public partial class INV_StockHold : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;

        private ToolTip tpProductNamePICode = new ToolTip();
        private ToolTip tpQty = new ToolTip();
        private ToolTip tpProductName = new ToolTip();
        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpStock = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tpStockLocation = new ToolTip();
        public string varResult = "";
        public string varUserID = "";
        
        public string varPICode="",varSHID="", varMrp="";
        public int SHID=0,varPRID = 0, varUTID = 0, varStockLocationId = 0, varRKID=0,varCOMID=0;
        Boolean BlnSearchImageYN = false;
        public bool VarSearchFlag = true;
        public INV_StockHold()
        {
            InitializeComponent();
        }
        private void INV_StockHold_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbConcern();
                cmbConcern.SelectedValue = 1;
                lblUnit.Text = "";
                udfnList();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        
        private void INV_StockHold_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    lvproduct.Visible = false;
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

        public void udfnclose()
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to Exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    MainForm objMainForm = new MainForm();
                    objMainForm.udfnCloseChildForms();
                    MainForm.objStart = new DEF_Start();
                    MainForm.objStart.MdiParent = this.ParentForm;
                    MainForm.objStart.Show();
                    this.Close();
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

        private void TxtProductNamePICode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtProductNamePICode.Text) == "")
                {
                    epStockHold.SetError(txtProductNamePICode, "Please enter the product");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductNamePICode.ShowAlways = true;
                    tpProductNamePICode.Show("Please enter the product", txtProductNamePICode, 5000);


                }
                else
                {
                    epStockHold.Clear();
                    txtProductNamePICode.BackColor = Color.White;
                    tpProductNamePICode.Active = false;
                }
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
                    if (lvproduct.Items.Count == 0 || txtProductNamePICode.Text == "")
                    {
                        txtQty.Focus();
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
                    txtQty.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQty_Enter(object sender, EventArgs e)
        {
            try
            {
                txtQty.BackColor = Color.LemonChiffon;
                lvproduct.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtQty.Text) == "")
                {
                    epStockHold.SetError(txtQty, "Please enter Quantity");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter Quantity", txtQty, 5000);


                }
                else
                {
                    epStockHold.Clear();
                    txtQty.BackColor = Color.White;
                    tpQty.Active = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void INV_StockHold_Load_1(object sender, EventArgs e)
        {
            try
            {
                udfnCmbConcern();
                this.ActiveControl = txtProductNamePICode;
                VarSearchFlag = true;
                lblProductName.Text = "Search by P.I Code";               
                lblUnit.Text = "";
                udfnList();
                //if (grdStockHold.Rows.Count>0)
                //{
                //    grdStockHold.Columns["clmDelete"].Visible = true;
                //    grdStockHold.Columns["clmEdit"].Visible = true;
                //}
                //else
                //{
                    //grdStockHold.Columns["clmDelete"].Visible = false;
                    //grdStockHold.Columns["clmEdit"].Visible = false;
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemark.Focus();
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
                txtQty.Focus();
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
                    txtQty.Focus();
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
                string varoriginator = ""; int ViewType = 0; 
                //if (btnSave.Text == "Save")
                if(SHID==0)
                {
                    ViewType = 0;
                    varoriginator = "Stock Hold Creation";
                }
                else
                {
                    ViewType = 1;
                    varoriginator = "Stock Hold Update";
                }
                bool blnErrorFlag = true;
                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epStockHold.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    epStockHold.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductNamePICode.ShowAlways = true;
                    tpProductNamePICode.Show("Please enter Product name", txtProductNamePICode, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtStockLoc.Text).Trim() == "")
                {
                    epStockHold.SetError(txtStockLoc, "Please enter stock location");
                    txtStockLoc.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter stock location", txtStockLoc, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtRack.Text).Trim() == "")
                {
                    epStockHold.SetError(txtRack, "Please enter rack name");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please enter rack name", txtRack, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtStockQty.Text).Trim() == "")
                {
                    epStockHold.SetError(txtStockQty, "Please enter stock quantity");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStock.ShowAlways = true;
                    tpStock.Show("Please enter stock quantity", txtStockQty, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToString(txtQty.Text).Trim() == "")
                {
                    epStockHold.SetError(txtQty, "Please enter quantity");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter quantity", txtQty, 5000);
                    blnErrorFlag = false;
                }
                if (Convert.ToInt32(txtQty.Text) > Convert.ToInt32(txtStockQty.Text) || Convert.ToInt32(txtQty.Text)==0)
                {
                    //epGoodsOutward.SetError(txtQty, "Please enter a correct Outward Quantity");
                    txtQty.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQty.ShowAlways = true;
                    tpQty.Show("Please enter a correct outward quantity", txtQty, 5000);
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(96);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = false;
                    txtQty.Focus();

                }
                if (blnErrorFlag == true)
                {
                    //string varMrp = string.Format("{0:G29}", decimal.Parse(Convert.ToString(txtMrp.Text.Trim())));
                    //varResult = objspservice.udfnStockHold(ViewType,SHID,Convert.ToInt32(cmbConcern.SelectedValue), varPRID, varStockLocationId, varRKID,Convert.ToString(txtMrp.Text), Convert.ToString(txtExpiryDate.Text),Convert.ToString(txtBatchNo.Text),varUTID,Convert.ToInt32(txtQty.Text), varoriginator);

                    DataTable objGrnPO = new DataTable();
                    TRNS_StockHold objTRNS_StockHold = new TRNS_StockHold();
                    SPDataService objspservice = new SPDataService();
                    objTRNS_StockHold.ViewType = ViewType;
                    objTRNS_StockHold.paraSHID = SHID;
                    objTRNS_StockHold.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    objTRNS_StockHold.paraPRID = varPRID;
                    objTRNS_StockHold.paraSLID = varStockLocationId;
                    objTRNS_StockHold.paraRKID = varRKID;
                    objTRNS_StockHold.paraMrp = Convert.ToDecimal(string.Format("{0:G29}", decimal.Parse(txtMrp.Text.Trim())));
                    objTRNS_StockHold.paraExpiryDate = Convert.ToString(txtExpiryDate.Text);
                    objTRNS_StockHold.paraBatchNo = Convert.ToString(txtBatchNo.Text);
                    objTRNS_StockHold.paraUTID = varUTID;
                    objTRNS_StockHold.paraBatchNo = Convert.ToString(txtBatchNo.Text);
                    objTRNS_StockHold.paraQty = Convert.ToInt32(txtQty.Text);
                    objTRNS_StockHold.paraRemarks = Convert.ToString(txtRemark.Text.Trim());
                    objTRNS_StockHold.paraUserID = Convert.ToInt32(MainForm.pbUserID);
                    objTRNS_StockHold.paraFlag = 0;
                    objTRNS_StockHold.paraOriginator = varoriginator;
                    varResult = objspservice.udfnStockHold(objTRNS_StockHold);
                    objspservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varResult.Split('~')[0] == "3")
                    {
                        if (varResult.Split('~')[1] == "1")
                        {
                            MainForm.objCP_Verify = new CP_Verify();
                            MainForm.objCP_Verify.ShowDialog();
                            varUserID = MainForm.objCP_Verify.varUserId;
                            if (MainForm.objCP_Verify.flag == 1)
                            {
                                objspservice = new SPDataService();
                                objTRNS_StockHold.ViewType = ViewType;
                                objTRNS_StockHold.paraSHID = SHID;
                                objTRNS_StockHold.paraCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                                objTRNS_StockHold.paraPRID = varPRID;
                                objTRNS_StockHold.paraSLID = varStockLocationId;
                                objTRNS_StockHold.paraRKID = varRKID;
                                objTRNS_StockHold.paraMrp = Convert.ToDecimal(string.Format("{0:G29}", decimal.Parse(txtMrp.Text.Trim())));
                                objTRNS_StockHold.paraExpiryDate = Convert.ToString(txtExpiryDate.Text);
                                objTRNS_StockHold.paraBatchNo = Convert.ToString(txtBatchNo.Text);
                                objTRNS_StockHold.paraUTID = varUTID;
                                objTRNS_StockHold.paraBatchNo = Convert.ToString(txtBatchNo.Text);
                                objTRNS_StockHold.paraQty = Convert.ToInt32(txtQty.Text);
                                objTRNS_StockHold.paraRemarks = Convert.ToString(txtRemark.Text.Trim());
                                objTRNS_StockHold.paraUserID = Convert.ToInt32(varUserID);
                                objTRNS_StockHold.paraFlag = 1;
                                objTRNS_StockHold.paraOriginator = varoriginator;
                                varResult = objspservice.udfnStockHold(objTRNS_StockHold);
                                objspservice.CloseConnection();
                                string[] varvalue1 = varResult.Split('~');
                                if (varvalue1[0] == "3")
                                {
                                    MessageBox.Show(varvalue1[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    udfnClear();
                                    udfnList();
                                }
                                else
                                {
                                    MessageBox.Show(varvalue1[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    udfnClear();
                                }
                            }
                        }
                        else if (varResult.Split('~')[0] == "4")
                        {
                            MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cmbConcern.Enabled = true;
                txtProductNamePICode.Enabled = true;
                grdStockHold.ClearSelection();
            }
        }
        public void udfnList()
        {
            try
            {
                //
                grdStockHold.DataSource = null;
                DataSet objDS = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDS = objdserv.udfnStockHoldList(0,0);
                objdserv.CloseConnection();
                if (objDS != null)
                {
                    if (objDS.Tables.Count != 0)
                    {
                        lblNoRecordsFound.Visible = false;
                        if (objDS.Tables[0].Rows.Count != 0)
                        {
                            lblNoRecordsFound.Visible = false;
                            lblNoRecordsFound.SendToBack();
                            grdStockHold.Columns["clmDelete"].Visible = true;
                            grdStockHold.Columns["clmEdit"].Visible = true;
                            grdStockHold.DataSource = objDS.Tables[0];
                            grdStockHold.Columns["S.No."].Width = 40;
                            grdStockHold.Columns["Created On"].Width = 140;
                            grdStockHold.Columns["Concern"].Width = 70;
                            grdStockHold.Columns["P.I Code"].Width = 100;
                            grdStockHold.Columns["Product Name"].Width = 300;
                            grdStockHold.Columns["Unit"].Width = 50;
                            grdStockHold.Columns["Stock Location"].Width = 100;
                            grdStockHold.Columns["Rack"].Width = 60;
                            grdStockHold.Columns["MRP"].Width = 60;
                            grdStockHold.Columns["Expiry Date"].Width = 90;
                            grdStockHold.Columns["Batch No."].Width = 70;
                            grdStockHold.Columns["Hold Qty"].Width = 70;
                            grdStockHold.Columns["Created By"].Width = 80;
                            grdStockHold.Columns["clmDelete"].Width = 40;
                            grdStockHold.Columns["clmEdit"].Width = 30;
                            grdStockHold.Columns["PRID"].Visible = false;
                            grdStockHold.Columns["SLID"].Visible = false;
                            grdStockHold.Columns["UTID"].Visible = false;
                            grdStockHold.Columns["RKID"].Visible = false;
                            grdStockHold.Columns["SHID"].Visible = false;
                            grdStockHold.Columns["COMID"].Visible = false;
                            grdStockHold.Columns["MRP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockHold.Columns["Hold Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            grdStockHold.Columns["S.No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockHold.Columns["Expiry Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockHold.Columns["Created On"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            grdStockHold.Columns["Product Name"].DefaultCellStyle.Font = new Font("Uni Ila.Sundaram-03", 11.75F);

                        }
                        else
                        {
                            lblNoRecordsFound.Visible = true;
                            lblNoRecordsFound.BringToFront();
                            grdStockHold.Columns["clmDelete"].Visible = false;
                            grdStockHold.Columns["clmEdit"].Visible = false;
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
            { grdStockHold.ClearSelection(); }
        }
        public void udfnClear()
        {
            try
            {
                //btnSave.Text = "Save";
                txtProductNamePICode.Text = "";
                txtStockLoc.Text = "";
                txtRack.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtMrp.Text = "";
                txtStockQty.Text = "";
                txtQty.Text = "";
                lblUnit.Text = "";
                txtRemark.Text = "";
                txtProductNamePICode.Focus();
                SHID = 0;
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
                lvproductPICode.Items.Clear();
                if (txtProductName.Text.Length > 0)
                {
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    var ViewType = 42;
                    MR_Product objMR_Product = new MR_Product();
                    objMR_Product.paraViewType = ViewType;
                    objMR_Product.paraProductName = txtProductName.Text.Trim();
                    objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PRODUCTLIST"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["STK_Qty"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["UTID"].ToString(), objDs.Tables[0].Rows[i]["STK_SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[2].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproductPICode.Items.Add(objList);
                                }
                                lvproductPICode.Visible = true;
                                lvproductPICode.Columns[0].Width = 0;
                                lvproductPICode.Columns[1].Width = 100;
                                lvproductPICode.Columns[2].Width = 550;
                                lvproductPICode.Columns[3].Width = 0;
                                lvproductPICode.Columns[4].Width = 0;
                                lvproductPICode.Columns[5].Width = 0;
                                lvproductPICode.Columns[6].Width = 0;
                                lvproductPICode.Columns[7].Width = 0;
                                lvproductPICode.Columns[8].Width = 0;
                                lvproductPICode.Columns[9].Width = 0;
                                lvproductPICode.Columns[10].Width = 0;
                                lvproductPICode.Columns[11].Width = 0;
                                lvproductPICode.Columns[12].Width = 0;
                                lvproductPICode.Columns[13].Width = 0;

                            }
                            else
                            {
                                lvproductPICode.Visible = false;
                            }
                        }
                        else
                        {
                            lvproductPICode.Visible = false;
                        }
                    }

                    else
                    {
                        lvproductPICode.Visible = false;
                    }
                }
                else
                {
                    lvproductPICode.Visible = false;
                    lvproductPICode.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvproductPICode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListviewProduct();
                txtProductNamePICode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvproductPICode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListviewProduct();
                    txtProductNamePICode.Focus();
                }
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
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvproductPICode.Items.Count == 0 || txtProductName.Text == "")
                    {
                        txtProductNamePICode.Focus();
                        lvproductPICode.Visible = false;
                    }
                    else
                    {
                        lvproductPICode.Focus();
                    }
                    if (lvproductPICode.Items.Count > 0)
                    {
                        lvproductPICode.Items[0].Selected = true;
                    }
                }
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

                        //epStockHold.Clear();
                 txtProductName.BackColor = Color.White;
                 tpProductName.Active = false;
                
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void CmbConcern_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbConcern.BackColor = Color.LemonChiffon;
                lvproduct.Visible = false;
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

        private void TsStockRequest_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void GrdStockHold_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdStockHold.Columns[e.ColumnIndex].Name)
                    {
                        case "clmDelete":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                udfnDelete();
                            }
                            break;
                        case "clmEdit":
                            udfnEdit();
                            lvproduct.Visible = false;
                            txtProductNamePICode.BackColor = Color.White;
                            tpProductNamePICode.Active = false;
                            txtQty.Focus();
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
        public void udfntooltiphide()
        {
            try
            {
                epStockHold.Clear();
                tpConcern.Active = false;
                tpProductNamePICode.Active = false;
                tpQty.Active = false;
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
                lvproduct.Visible = false;
                MainForm.objINV_StockHold.SHID = Convert.ToInt32(grdStockHold.SelectedRows[0].Cells["SHID"].Value);
                if (SHID != 0)
                {
                    Application.DoEvents();
                    //********** To display a data in a grid  ******************  
                    DataSet objDs = new DataSet();
                    //**** To call the function from SP ***************
                    SPDataService objdserv = new SPDataService();
                    int ViewType =1;
                    objDs = objdserv.udfnStockHoldList(ViewType, SHID);
                    objdserv.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables[0].Rows.Count != 0)
                        {
                            udfntooltiphide();
                            tpProductNamePICode.Active = false;
                            cmbConcern.SelectedValue = objDs.Tables[0].Rows[0]["COMID"];
                            //txtProductNamePICode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product"]);
                            txtProductNamePICode.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Product Name"]);
                            lblUnit.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Unit"]);
                            varStockLocationId = Convert.ToInt32(objDs.Tables[0].Rows[0]["SLID"]);
                            txtStockLoc.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Stock Location"]);
                            txtRack.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Rack"]);
                            txtMrp.Text = Convert.ToString(objDs.Tables[0].Rows[0]["MRP"]);
                            txtExpiryDate.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Expiry Date"]);
                            txtBatchNo.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Batch No"]);
                            txtStockQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Stock Qty"]);
                            txtQty.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Hold Qty"]);
                            varPRID = Convert.ToInt32(objDs.Tables[0].Rows[0]["PRID"]);
                            varRKID = Convert.ToInt32(objDs.Tables[0].Rows[0]["RKID"]);
                            varUTID = Convert.ToInt32(objDs.Tables[0].Rows[0]["UTID"]);
                            txtRemark.Text = Convert.ToString(objDs.Tables[0].Rows[0]["Remarks"]);
                           // btnSave.Text = "Update";
                        }
                    }
                   // btnSave.Text = "Update";
                    cmbConcern.Enabled = false;
                    lvproduct.Visible = false;
                    txtProductNamePICode.Enabled = false;
                    txtProductNamePICode.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LblExpiryDate_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtQty.TextAlign = HorizontalAlignment.Right;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void GrdStockHold_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void GrdStockHold_Scroll(object sender, ScrollEventArgs e)
        {

            try
            {
                int totalWidth = 0;
                int offSetValue = grdStockHold.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdStockHold.Width > grdStockHold.HorizontalScrollingOffset && grdStockHold.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
                udfnscrollVisible(DGV_SearchGrid, grdStockHold);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnscrollVisible(DataGridView DGV, DataGridView grdCityList)
        {
            try
            {
                var vScrollbar = grdCityList.Controls.OfType<VScrollBar>().First();
                if (vScrollbar.Visible == true)
                {
                    List<int> visibleColumns = new List<int>();
                    foreach (DataGridViewColumn col in DGV.Columns)
                    {
                        visibleColumns.Add(col.Index);
                    }
                    int I = DGV_SearchGrid.Rows.Count - 1;
                    if (I == 0)
                    {
                        int rowIndex = 1;
                        DGV_SearchGrid.Rows.Add();
                        for (int i = 0; i < visibleColumns.Count; i++)
                        {
                            DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
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
        private void udfnSearchGridHead()
        {
            try
            {
                udfnGridSearchHeading(grdStockHold, DGV_SearchGrid);
                DGV_SearchGrid.Columns.Clear();
                List<int> visibleColumns = new List<int>();
                foreach (DataGridViewColumn col in grdStockHold.Columns)
                {
                    DGV_SearchGrid.Columns.Add((DataGridViewColumn)col.Clone());
                    visibleColumns.Add(col.Index);
                }
                int rowIndex = 0;
                DGV_SearchGrid.Rows.Clear();
                DGV_SearchGrid.Rows.Add();
                DGV_SearchGrid.Columns[0].DefaultCellStyle.NullValue = null;
                DGV_SearchGrid.Columns[1].DefaultCellStyle.NullValue = null;
                for (int i = 2; i < visibleColumns.Count; i++)
                {
                    DGV_SearchGrid.Rows[rowIndex].Cells[i].Value = "";
                }
                DGV_SearchGrid.Columns["S.No."].ReadOnly = true;
                DGV_SearchGrid.Columns[0].ReadOnly = true;
                DGV_SearchGrid.Columns[1].ReadOnly = true;
                DGV_SearchGrid.Rows[0].Cells[0].Value = new Bitmap(1, 1);
                DGV_SearchGrid.Rows[0].Cells[1].Value = new Bitmap(1, 1);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }
        private void udfnGridSearchHeading(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
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
                int ColIndex = 0;
                dgv2.Rows.Clear();
                dgv2.Rows.Add();
                BlnSearchImageYN = false;
                for (int i = 0; i < visibleColumns.Count; i++)
                {
                    //dgv2.Rows[rowIndex].Cells[i].Value = ""; 
                    if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Image")
                    {
                        //dgv2.Rows[rowIndex].Visible = false;
                        BlnSearchImageYN = true;
                        ColIndex = i;
                        dgv2.Columns[i].DisplayIndex = dgv2.ColumnCount - 1;
                        dgv2.Rows[rowIndex].Cells[i].Value = new Bitmap(1, 1);
                        ((DataGridViewImageColumn)dgv2.Columns[i]).DefaultCellStyle.NullValue = null;
                    }
                    else if (dgv2.Rows[rowIndex].Cells[i].ValueType.Name == "Boolean")
                    {
                        BlnSearchImageYN = true;
                        dgv2.Rows[rowIndex].Cells[i].Value = false;
                    }
                    else
                    {
                        dgv2.Rows[rowIndex].Cells[i].Value = "";
                    }
                }
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdStockHold.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockHold);
                objDser.CloseConnection();
                grdStockHold.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                    return;
                if (!(e.ColumnIndex == 0 || e.ColumnIndex == 0))   /*If not our desired columns*/
                                                                   //return;

                    if (Convert.ToString(e.Value) == "" || e.Value == DBNull.Value)  /*If value is null*/
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All
                            & ~(DataGridViewPaintParts.ContentForeground));

                        TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                            e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);

                        e.Handled = true;
                    }

                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewColumn newColumn = grdStockHold.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = grdStockHold.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        grdStockHold.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                grdStockHold.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;

                DataGridViewColumn DGV = DGV_SearchGrid.Columns[e.ColumnIndex];
                DGV.HeaderCell.SortGlyphDirection = SortOrder.None;

                DGV_SearchGrid.HorizontalScrollingOffset = grdStockHold.HorizontalScrollingOffset;
                DGV_SearchGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void GrdStockHold_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

            try
            {
                if (grdStockHold.ColumnCount > 0)
                {
                    grdStockHold.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdStockHold.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_SearchGrid.IsCurrentCellDirty)
                {
                    // Commit the changes immediately
                    DGV_SearchGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdStockHold.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockHold);
                objDser.CloseConnection();
                grdStockHold.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //grdCompanyList(sender,e); 
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //udfnGridSearchFilter();
                DataService objDser = new DataService();
                grdStockHold.DataSource = objDser.udfnGridSearchFilter(DGV_SearchGrid, grdStockHold);
                objDser.CloseConnection();
                grdStockHold.HorizontalScrollingOffset = DGV_SearchGrid.HorizontalScrollingOffset;
                //DGV_SearchGrid_CellPainting(sender,e);
            }
            catch (Exception ex) { objError = new DataError(); objError.WriteFile(ex); }
        }

        private void DGV_SearchGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                int totalWidth = 0;
                int offSetValue = grdStockHold.HorizontalScrollingOffset;
                foreach (DataGridViewColumn col in DGV_SearchGrid.Columns)
                    totalWidth += col.Width;
                if (totalWidth - grdStockHold.Width > grdStockHold.HorizontalScrollingOffset && grdStockHold.HorizontalScrollingOffset > 0)
                {
                    offSetValue = offSetValue;
                }
                DGV_SearchGrid.HorizontalScrollingOffset = offSetValue;
                DGV_SearchGrid.Invalidate();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void Lvproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }

        }

        private void TxtStockQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtStockQty.TextAlign = HorizontalAlignment.Right;
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

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                 bool IsSpecialCharacter(char integers)
                {
                    string allowedCharacters = "0123456789\b";
                    return !allowedCharacters.Contains(integers);
                }
                if (IsSpecialCharacter(e.KeyChar))
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

        private void GrdStockHold_Enter(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
                txtQty.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DGV_SearchGrid_Enter(object sender, EventArgs e)
        {
            try
            {
                lvproduct.Visible = false;
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
        private void TxtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void INV_StockHold_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Escape)
                {
                    lvproduct.Visible = false;
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    BtnSave_Click(sender, e);
                }
                if (e.KeyCode == Keys.F11)
                {
                    if (VarSearchFlag == false)
                    {
                        VarSearchFlag = true;
                        lblProductName.Text = "Search by P.I Code";
                    }
                    else
                    {
                        VarSearchFlag = false;
                        lblProductName.Text = "Search by Product Name";
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        //private void UpdateLabelText()
        //{
        //    try
        //    {
        //        // Change the text of the label based on the current state
        //        lblProductName.Text = isText ? "Search by Product" : "Search by P.I Code";
        //    }
        //    catch (Exception ex)
        //    {
        //        objError = new DataError();
        //        objError.WriteFile(ex);
        //    }
        //}

        private void DGV_SearchGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                if (grdStockHold.ColumnCount > 0)
                {
                    grdStockHold.Columns[e.Column.Index].Width = e.Column.Width;
                    DGV_SearchGrid.HorizontalScrollingOffset = grdStockHold.HorizontalScrollingOffset;
                    //grdBrandList.HorizontalScrollingOffset = 0;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        public void udfnDelete()
        {
            try
            {
                string result = "";
                string varoriginator = "Stock Hold Delete";
                SPDataService objspservice = new SPDataService();
                DataTable objGrnPO = new DataTable();
                TRNS_StockHold objTRNS_StockHold = new TRNS_StockHold();
                MainForm.objCP_Verify = new CP_Verify();
                MainForm.objCP_Verify.ShowDialog();
                varUserID = MainForm.objCP_Verify.varUserId;
                if (MainForm.objCP_Verify.flag == 1)
                {
                    objTRNS_StockHold.ViewType = 2;
                    objTRNS_StockHold.paraSHID = Convert.ToInt32(grdStockHold.SelectedRows[0].Cells["SHID"].Value);
                    objTRNS_StockHold.paraCompanycode = 0;
                    objTRNS_StockHold.paraPRID = 0;
                    objTRNS_StockHold.paraSLID = 0;
                    objTRNS_StockHold.paraRKID = 0;
                    objTRNS_StockHold.paraMrp = 0;
                    objTRNS_StockHold.paraExpiryDate = "";
                    objTRNS_StockHold.paraBatchNo = "";
                    objTRNS_StockHold.paraUTID = 0;
                    objTRNS_StockHold.paraQty = 0;
                    objTRNS_StockHold.paraUserID = Convert.ToInt32(varUserID);
                    objTRNS_StockHold.paraOriginator = varoriginator;
                    result = objspservice.udfnStockHold(objTRNS_StockHold);
                    varSHID = grdStockHold.SelectedRows[0].Cells["SHID"].Value.ToString();
                    grdStockHold.Rows.RemoveAt(this.grdStockHold.SelectedRows[0].Index);
                    for (int i = 0; i < grdStockHold.RowCount; i++)
                    {
                        grdStockHold.Rows[i].Cells["S.No."].Value = i + 1;
                    }
                    objspservice.CloseConnection();
                    if (result.Split('~')[0] == "3")
                    {
                        MessageBox.Show(result.Split('~')[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        udfnList();
                    }
                    else if (result.Split('~')[0] == "4")
                    {
                        MessageBox.Show(result.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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
                    epStockHold.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    epStockHold.Clear();
                    cmbConcern.BackColor = Color.White;
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
                cmbConcern.SelectedValue = 1;
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
                if (txtProductNamePICode.Text != "")
                {
                    ListViewItem selectedItem = lvproduct.SelectedItems[0];
                    varPRID = Convert.ToInt32(selectedItem.SubItems[0].Text);
                    varPICode = selectedItem.SubItems[1].Text;
                    txtProductNamePICode.Text = selectedItem.SubItems[4].Text;
                    txtStockLoc.Text = selectedItem.SubItems[5].Text;
                    txtRack.Text = selectedItem.SubItems[6].Text;
                    txtMrp.Text = selectedItem.SubItems[7].Text;
                    txtExpiryDate.Text = selectedItem.SubItems[8].Text;
                    txtBatchNo.Text = selectedItem.SubItems[9].Text;
                    txtStockQty.Text = selectedItem.SubItems[10].Text;
                    lblUnit.Text = selectedItem.SubItems[11].Text;
                    varUTID = Convert.ToInt32(selectedItem.SubItems[12].Text);
                    varStockLocationId = Convert.ToInt32(selectedItem.SubItems[13].Text);
                    varRKID = Convert.ToInt32(selectedItem.SubItems[14].Text);
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

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                btnPrint.Enabled = false;
                lblNoRecordsFound.Visible = false;
                picLoader.Visible = true;
                RPTViewer.Visible = false;
                picLoader.BringToFront();
                Application.DoEvents();
                int varPrint = 0;
                DataSet objDs = new DataSet();
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnStockHoldList(0, 0);
                objdserv.CloseConnection();
                if (objDs != null) { if (objDs.Tables.Count > 0) { if (objDs.Tables[0].Rows.Count > 0) { varPrint = 1; } } }
                if (varPrint == 1)
                {
                    RPTViewer.Visible = true;
                    RPTViewer.BringToFront();
                    RPTViewer.ReuseParameterValuesOnRefresh = true;
                    RPTViewer.RefreshReport();
                    CrystalDecisions.CrystalReports.Engine.ReportDocument objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    objBillreport.Load(Application.StartupPath + "\\Reports\\RPT_INV_StockHold.rpt");
                    objBillreport.SetParameterValue("paraUserID", MainForm.pbUserID);
                    objBillreport.SetParameterValue("paraIPAddress", MainForm.pbIpAddress);
                    objBillreport.SetParameterValue("paraHostName", MainForm.pbHostName);
                    objBillreport.SetParameterValue("paraUserName", MainForm.pbUserName);
                    objValidation.CrySqlConnection(objBillreport);
                    RPTViewer.ReportSource = objBillreport;
                    RPTViewer.Refresh();
                }
                else
                {
                    lblNoRecordsFound.Visible = true;
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
                txtStockLoc.Text = "";
                txtRack.Text = "";
                txtMrp.Text = "";
                txtExpiryDate.Text = "";
                txtBatchNo.Text = "";
                txtStockQty.Text = "";
                txtQty.Text = "";
                lblUnit.Text = "";
                lvproduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductNamePICode.Text.Length > 0)
                {
                    MR_Product objMR_Product = new MR_Product();
                    var ViewType = 42;
                    objMR_Product.paraViewType = ViewType;
                    objMR_Product.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                    if (VarSearchFlag == false)
                    {
                        objMR_Product.paraProductName = txtProductNamePICode.Text.Trim();
                        objDs = objspdservice.udfnproductmasterlist(objMR_Product);
                    }
                    else
                    {
                        objMR_Product.paraPicode = txtProductNamePICode.Text.Trim();
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
                                    string[] row = { objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["PRODUCTLIST"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["SL_EName"].ToString(),
                                        objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["STK_Qty"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["UTID"].ToString(), objDs.Tables[0].Rows[i]["STK_SLID"].ToString(), objDs.Tables[0].Rows[i]["STK_RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    objList.UseItemStyleForSubItems = false;
                                    objList.SubItems[3].Font = new Font("Uni Ila.Sundaram-03", 11.75F);
                                    lvproduct.Items.Add(objList);
                                }
                                lvproduct.Visible = true;
                                lvproduct.BringToFront();
                                lvproduct.Columns[0].Width = 0;
                                lvproduct.Columns[1].Width = 100;
                                lvproduct.Columns[2].Width = 0;
                                lvproduct.Columns[3].Width = 270;
                                lvproduct.Columns[4].Width = 0;
                                lvproduct.Columns[5].Width = 70;
                                lvproduct.Columns[6].Width = 60;
                                lvproduct.Columns[7].Width = 70;
                                lvproduct.Columns[8].Width = 80;
                                lvproduct.Columns[9].Width = 60;
                                lvproduct.Columns[10].Width = 60;
                                lvproduct.Columns[11].Width = 40;
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
    }
}
