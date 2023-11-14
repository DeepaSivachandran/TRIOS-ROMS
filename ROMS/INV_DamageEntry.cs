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
    public partial class INV_DamageEntry : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpplno = new ToolTip();
        private ToolTip tpMRP = new ToolTip();
        private ToolTip tpMonth = new ToolTip();
        private ToolTip tpYear = new ToolTip();
        private ToolTip tpBatchNo = new ToolTip();
        private ToolTip tpQuantity = new ToolTip();
        private ToolTip tpSupplierName = new ToolTip();
        private ToolTip tpcompanyname = new ToolTip();
        public string varPICode = "";
        public string varUnitSymbol = "";
        public string varUTID = "";
        public string varSLID = "";
        public string varProductCode = "";
        public string varBatchNo = "";
        public string varExpiryDate = "";
        public string varMRP = "";
        public string varRKID = "";
        public string varSPID = "";
        public string varSPSCID = "";
        public int varID = 0;
        public int varUpdate = 0;

        DataTable dtDamage = new DataTable();

        public INV_DamageEntry()
        {
            InitializeComponent();
        }
        public void udfnAdd()
        {
            try
            {
                string varExpiryDate = "",Day = "", Month = "", Year = ""; ;
                varExpiryDate = txtExpiryDate.Text.Trim();
                string[] DMY = varExpiryDate.Split('/');
                Day = DMY[0];
                Month = DMY[1];
                Year = DMY[2];
                grdDamageEntry.Rows.Add(grdDamageEntry.Rows.Count + 1,varPICode, txtProductName.Text.Trim(),Convert.ToString(txtMrp.Text.Trim()),txtExpiryDate.Text.Trim(),txtBatchNo.Text.Trim(),txtQuantity.Text.Trim(), varUnitSymbol,txtsuppliername.Text.Trim(),Day,Month,Year,(lblProduct.Text).Trim(),varSLID,varRKID,varUTID, (lblSupplierCode.Text).Trim(), (lblScheduleCode.Text).Trim());
                grdDamageEntry.Columns["clmDay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmMonth"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmYear"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmBatchNo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmQuantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdDamageEntry.Columns["clmexpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtDamage.Rows.Add(Convert.ToInt32((lblProduct.Text).Trim()),Convert.ToInt32(varSLID),Convert.ToInt32(varRKID),Convert.ToString(txtMrp.Text.Trim()),Convert.ToInt32(Day), Convert.ToInt32(Month), Convert.ToInt32(Year), txtExpiryDate.Text.Trim(),txtBatchNo.Text.Trim(),txtQuantity.Text.Trim(),varUTID,20,lblSupplierCode.Text.Trim(),lblScheduleCode.Text.Trim());
                txttotalitem.Text = Convert.ToString(grdDamageEntry.Rows.Count);
                txtProductName.Focus();
                epDamageEntry.Clear();
                udfnProductClear();
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductClear()
        {
            txtProductName.Text = "";
            txtLocation.Text = "";
            txtRack.Text = "";
            txtMrp.Text = "";
            txtExpiryDate.Text = "";
            txtBatchNo.Text = "";
            txtStockQty.Text = "";
            txtQuantity.Text = "";
            txtsuppliername.Text = "";
        }
        public void udfnClear()
        {
            try
            {
                txtProductName.Text = "";
                txtMrp.Text = "";
                txtBatchNo.Text = "";
                txtQuantity.Text = "";
                txtsuppliername.Text = "";
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnCmbConcernLoad()
        {
            try
            {
                cmbConcern.Focus();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                int varViewType = 3, varConcernId = 0;
                objDT = objdserv.udfnCompanyList(varViewType, varConcernId, MainForm.pbUserID, MainForm.pbIpAddress, 0);
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
        private void INV_DamageEntry_Load(object sender, EventArgs e)
        {
            try
            {
                udfnCmbConcernLoad();
                SPDataService objDServ = new SPDataService();
                DataSet objd = new DataSet();
                objd = objDServ.udfnMaster(4, 6, 0);
                if (objd.Tables[1].Rows.Count != 0)
                {
                    DateTime varmaxdate = DateTime.ParseExact(Convert.ToString(objd.Tables[1].Rows[0]["MinToday"]), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpEntryDate.MaxDate = varmaxdate;
                }

                dtDamage.TableName = "TRN_DM_Product_AutoComplete";
                dtDamage.Columns.Add("DM_PRID", typeof(int));
                dtDamage.Columns.Add("DM_SLID", typeof(int));
                dtDamage.Columns.Add("DM_RKID", typeof(int));
                dtDamage.Columns.Add("DM_MRP", typeof(string));
                dtDamage.Columns.Add("DM_DD", typeof(int));
                dtDamage.Columns.Add("DM_MM", typeof(int));
                dtDamage.Columns.Add("DM_YYYY", typeof(int));
                dtDamage.Columns.Add("DM_ExpiryDate", typeof(string));
                dtDamage.Columns.Add("DM_BatchNo", typeof(string));
                dtDamage.Columns.Add("DM_Qty", typeof(string));
                dtDamage.Columns.Add("DM_UTID", typeof(string));
                dtDamage.Columns.Add("DM_STSID", typeof(string));
                dtDamage.Columns.Add("DM_SPID", typeof(string));
                dtDamage.Columns.Add("DM_SPSCID", typeof(string));
                if (btnSave.Text == "Save")
                {
                    cmbConcern.Enabled = true;
                    dpEntryDate.Enabled = true;
                }
                else
                {
                    cmbConcern.Enabled = false;
                    dpEntryDate.Enabled = false;
                    udfnEdit();
                }
            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnclose()
        {
            try
            {
                if (varUpdate == 1) { this.Close(); }
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
        private void INV_Inward_Load(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                grpproductname.Visible = true;
                txtsuppliername.Enabled = true;
            }
            else
            {
                grpproductname.Visible = false;
                txtsuppliername.Enabled = false;
                //cmbvoucherno.Enabled = false;
                //cmbPoNo.Enabled = false;
                //cmbinwardtype.Enabled = false;
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
                    epDamageEntry.SetError(cmbConcern, "Please select company");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select company", cmbConcern, 5000);
                }
                else
                {
                    epDamageEntry.Clear();
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
            }
            catch (Exception ex)

            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnTransferNo()
        {
            if (btnSave.Text == "Save")
            {
                if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                {
                    string vardate = "", varResult = "";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    DataService objDservice = new DataService();
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'" + dpEntryDate.Text + "',103)");
                    varResult = objspdservice.udfngetPONO("45", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                    objspdservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    string value = varvalue[0];
                    string[] EntryNo = value.Split('/');
                    if (varResult != "")
                    {
                        txtEntryNo.Text = EntryNo[0];
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(75);
                        objDServ.CloseConnection();
                        txtEntryNo.Text = "";
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
                    txtEntryNo.Text = "";
                }
            }
        }
        private void CmbConcern_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dpEntryDate.Focus();
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
                if (txtProductName.Text == "")
                {
                    epDamageEntry.SetError(txtProductName, "Please enter product name or P.I Code");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter product name or P.I Code", txtProductName, 5000);
                }
                else
                {
                    txtProductName.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMrp.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMrp.Text == "")
                {
                    epDamageEntry.SetError(txtMrp, "Please enter MRP.");
                    txtMrp.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpMRP.ShowAlways = true;
                    tpMRP.Show("Please enter MRP.", txtMrp, 5000);
                }
                else
                {
                    txtMrp.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpEntryDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpEntryDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void DpEntryDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpEntryDate.BackColor = Color.White;
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
                    if (lvProduct.Items.Count == 0 || txtProductName.Text == "")
                    {
                        txtProductName.Focus();
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
                    //txtDLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtDay_Enter(object sender, EventArgs e)
        {
            try
            {
                //txtDay.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDay_Leave(object sender, EventArgs e)
        {
            try
            {
                //txtDay.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_Enter(object sender, EventArgs e)
        {
            try
            {
                //txtMonth.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtMonth.Text == "")
                //{
                //    //epDamageEntry.SetError(txtMonth, "Please enter Month.");
                //    txtMonth.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpMonth.ShowAlways = true;
                //    tpMonth.Show("Please enter Month.", txtMonth, 5000);
                //}
                //else
                //{
                //    txtMonth.BackColor = Color.White;
                //    epDamageEntry.Clear();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtDay.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMonth_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txtYear.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_Enter(object sender, EventArgs e)
        {
            try
            {
                //txtYear.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBatchNo.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtYear_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtYear.Text == "")
                //{
                //    //epDamageEntry.SetError(txtYear, "Please enter Year.");
                //    txtYear.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpYear.ShowAlways = true;
                //    tpYear.Show("Please enter Year.", txtYear, 5000);
                //}
                //else
                //{
                //    txtYear.BackColor = Color.White;
                //    epDamageEntry.Clear();
                //}
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_Enter(object sender, EventArgs e)
        {
            try
            {
                txtBatchNo.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBatchNo.Text == "")
                {
                    epDamageEntry.SetError(txtBatchNo, "Please enter batch No.");
                    txtBatchNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpBatchNo.ShowAlways = true;
                    tpBatchNo.Show("Please enter batch No.", txtBatchNo, 5000);
                }
                else
                {
                    txtBatchNo.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                txtQuantity.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantity.Text == "")
                {
                    epDamageEntry.SetError(txtQuantity, "Please enter quantity.");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quantity.", txtQuantity, 5000);
                }
                else
                {
                    txtQuantity.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtsuppliername.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliername_Enter(object sender, EventArgs e)
        {
            try
            {
                txtsuppliername.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliername_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtsuppliername.Text == "")
                {
                    epDamageEntry.SetError(txtsuppliername, "Please enter supplier name.");
                    txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSupplierName.ShowAlways = true;
                    tpSupplierName.Show("Please enter supplier name.", txtsuppliername, 5000);
                }
                else
                {
                    txtsuppliername.BackColor = Color.White;
                    epDamageEntry.Clear();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void Txtsuppliername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvSupplier.Items.Count == 0 || txtsuppliername.Text == "")
                    {
                        txtsuppliername.Focus();
                        lvSupplier.Visible = false;
                    }
                    else
                    {
                        lvSupplier.Focus();
                    }
                    if (lvSupplier.Items.Count > 0)
                    {
                        lvSupplier.Items[0].Selected = true;
                    }
                }
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
        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                lvSupplier.Visible = false;
                lvProduct.Visible = false;
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
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                int varflag = 0;
                if (txtProductName.Text == "")
                {
                    epDamageEntry.SetError(txtProductName, "Please enter product name or P.I Code.");
                    txtProductName.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpplno.ShowAlways = true;
                    tpplno.Show("Please enter product name or P.I Code.", txtProductName, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtQuantity.Text).Trim() != "")
                {
                    if (Convert.ToInt32(txtStockQty.Text.Trim()) >= Convert.ToInt32(txtQuantity.Text.Trim()))
                    {
                        epDamageEntry.Clear();
                        txtQuantity.BackColor = Color.White;
                    }
                    else
                    {
                        epDamageEntry.SetError(txtQuantity, "Please enter valid quentity");
                        txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpQuantity.ShowAlways = true;
                        tpQuantity.Show("Please enter valid quentity", txtQuantity, 5000);
                        blnErrorFlag = true;
                    }
                }
                else
                {
                    epDamageEntry.SetError(txtQuantity, "Please enter quentity");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpQuantity.ShowAlways = true;
                    tpQuantity.Show("Please enter quentity", txtQuantity, 5000);
                    blnErrorFlag = true;
                }
                if (txtsuppliername.Text == "")
                {
                    epDamageEntry.SetError(txtsuppliername, "Please enter supplier name.");
                    txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSupplierName.ShowAlways = true;
                    tpSupplierName.Show("Please enter supplier name.", txtsuppliername, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtsuppliername.Text) != "")
                {
                    string[] values = new string[0];
                    string varSupplierId = "0";
                    DataSet objDsSupplierId = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDsSupplierId = objDserv.udfnSupplierList(23, 0, 0, 0, 0, txtsuppliername.Text.Trim(), 0, 0, 0, "", 0, 0, 0, 0, 0);
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
                        epDamageEntry.SetError(txtsuppliername, "Invalid supplier");
                        txtsuppliername.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSupplierName.ShowAlways = true;
                        tpSupplierName.Show("Invalid supplier.", txtsuppliername, 5000);
                        lblSupplierCode.Text = "0";
                        lblScheduleCode.Text = "0";
                        blnErrorFlag = true;
                    }
                    else
                    {
                        epDamageEntry.Clear();
                        lblSupplierCode.Text = values[0];
                        lblScheduleCode.Text = values[1];
                        txtsuppliername.BackColor = Color.White;
                    }
                }
                if (blnErrorFlag == false)
                {
                    lvProduct.Visible = false;
                    lvSupplier.Visible = false;
                /////IF add any additional column in the grdDamageEntry then Change the upcoming row.cells value[] /////
                    foreach (DataGridViewRow row in grdDamageEntry.Rows)
                    {
                        if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                        {
                            string gridValue1 = row.Cells[12].Value.ToString();
                            string gridValue2 = row.Cells[13].Value.ToString();
                            string gridValue3 = row.Cells[14].Value.ToString();
                            string gridValue4 = row.Cells[3].Value.ToString();
                            string gridValue5 = row.Cells[4].Value.ToString();
                            string gridValue6 = row.Cells[5].Value.ToString();
                            string gridValue7 = row.Cells[16].Value.ToString();

                            if (gridValue1.ToUpper() == (lblProduct.Text).Trim().ToUpper() && gridValue2.ToUpper() == (varSLID).Trim().ToUpper() && gridValue3.ToUpper() == (varRKID).Trim().ToUpper() && gridValue4.ToUpper() == (txtMrp.Text).Trim().ToUpper() && gridValue5.ToUpper() == (txtExpiryDate.Text).Trim().ToUpper() && gridValue6.ToUpper() == (txtBatchNo.Text).Trim().ToUpper() && gridValue7.ToUpper() == (lblSupplierCode.Text).Trim().ToUpper())
                            {
                                varflag = 1;
                            }
                        }
                    }
                    if (varflag == 0)
                    {
                        udfnAdd();
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(70);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnSave.Focus();
            }
        }
        private void BtnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnAdd_Click(sender, e);
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
                if (varID != 0)
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objspservice.udfnproductDamage(2,varID, 0,0, 0, 0, "", "");
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["ConcernID"].ToString();
                            dpEntryDate.Text = objDS.Tables[0].Rows[0]["Transfer Date"].ToString().Replace("''", "'");
                            txtEntryNo.Text = objDS.Tables[0].Rows[0]["Transfer No."].ToString().Replace("''", "'");
                            txtRemark.Text = objDS.Tables[0].Rows[0]["Remarks"].ToString().Replace("''", "'");
                            varSLID= objDS.Tables[0].Rows[0]["SLID"].ToString().Replace("''", "'");
                            varRKID= objDS.Tables[0].Rows[0]["RKID"].ToString().Replace("''", "'");
                            varSPID= objDS.Tables[0].Rows[0]["Supplier ID"].ToString().Replace("''", "'");
                            lblProduct.Text= objDS.Tables[0].Rows[0]["PRID"].ToString().Replace("''", "'");
                            btnSave.Text = "Update";
                        }
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                            {
                                //grdDamageEntry.Rows.Add(grdDamageEntry.Rows.Count + 1, varPICode, txtProductName.Text.Trim(), txtMrp.Text.Trim(), txtExpiryDate.Text.Trim(), txtBatchNo.Text.Trim(), txtQuantity.Text.Trim(), varUnitSymbol, txtsuppliername.Text.Trim(), Day, Month, Year, (lblProduct.Text).Trim(), varSLID, varRKID, varUTID, (lblSupplierCode.Text).Trim(), (lblScheduleCode.Text).Trim());
                                grdDamageEntry.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[0].Rows[i]["PICode"]), Convert.ToString(objDS.Tables[0].Rows[i]["Product"]),
                                Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToString(objDS.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDS.Tables[0].Rows[i]["Unit"]),
                                 Convert.ToString(objDS.Tables[0].Rows[i]["Supplier"]), Convert.ToString(objDS.Tables[0].Rows[i]["Day"]), Convert.ToString(objDS.Tables[0].Rows[i]["Month"]), Convert.ToString(objDS.Tables[0].Rows[i]["Year"]), Convert.ToString(objDS.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDS.Tables[0].Rows[i]["SLID"]),Convert.ToString(objDS.Tables[0].Rows[i]["RKID"]),
                                 Convert.ToString(objDS.Tables[0].Rows[i]["UnitID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Supplier ID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Schedule ID"]));



                                dtDamage.Rows.Add(Convert.ToInt32(objDS.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDS.Tables[0].Rows[i]["SLID"]), Convert.ToString(objDS.Tables[0].Rows[i]["RKID"]), Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDS.Tables[0].Rows[i]["Day"]), Convert.ToString(objDS.Tables[0].Rows[i]["Month"]), Convert.ToString(objDS.Tables[0].Rows[i]["Year"]), Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToString(objDS.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDS.Tables[0].Rows[i]["UnitID"]), 20,Convert.ToString(objDS.Tables[0].Rows[i]["Supplier ID"]), Convert.ToString(objDS.Tables[0].Rows[i]["Schedule ID"]));

                                //dtDamage.Rows.Add(Convert.ToInt32((lblProduct.Text).Trim()), Convert.ToInt32(varSLID), Convert.ToInt32(varRKID), Convert.ToDouble(txtMrp.Text.Trim()), Convert.ToInt32(Day), Convert.ToInt32(Month), Convert.ToInt32(Year), txtExpiryDate.Text.Trim(), txtBatchNo.Text.Trim(), txtQuantity.Text.Trim(), varUTID, 20, lblSupplierCode.Text.Trim(), lblScheduleCode.Text.Trim());

                                grdDamageEntry.Columns["clmdsno"].Width = 50;
                                //grdDamageEntry.Columns["clmmrp"].Width = 50;
                                //grdDamageEntry.Columns["clmquantity"].Width = 70;
                                //grdDamageEntry.Columns["clmExpirydate"].Width = 90;
                                //grdDamageEntry.Columns["clmbatchno"].Width = 70;
                                //grdDamageEntry.Columns["clmDestLocation"].Width = 140;
                                //grdDamageEntry.Columns["clmDestRack"].Width = 140;
                                //grdDamageEntry.Columns["clmUnit"].Width = 60;
                                //grdDamageEntry.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                //grdDamageEntry.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                //grdDamageEntry.Columns["clmbatchno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                //grdDamageEntry.Columns["clmquantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                //grdDamageEntry.Columns["clmExpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            btnSave.Text = "Update";
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
                txttotalitem.Text = Convert.ToString(grdDamageEntry.Rows.Count);
            }
        }
        private void GrdDamageEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int PRID = 0,SLID=0,MRP=0;
                string ExpiryDate = "", BatchNo = "",SPID="",RKID;
                if (e.RowIndex != -1)
                {
                    switch (grdDamageEntry.Columns[e.ColumnIndex].Name)
                    {
                        case "clmremove":
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                                PRID = Convert.ToInt32(grdDamageEntry.SelectedRows[0].Cells["clmPRID"].Value);
                                SLID = Convert.ToInt32(grdDamageEntry.SelectedRows[0].Cells["clmSLID"].Value);
                                RKID = Convert.ToString(grdDamageEntry.SelectedRows[0].Cells["clmRKID"].Value);
                                MRP = Convert.ToInt32(grdDamageEntry.SelectedRows[0].Cells["clmmrp"].Value);
                                ExpiryDate = Convert.ToString(grdDamageEntry.SelectedRows[0].Cells["clmexpirydate"].Value);
                                BatchNo = Convert.ToString(grdDamageEntry.SelectedRows[0].Cells["clmBatchNo"].Value);
                                SPID = Convert.ToString(grdDamageEntry.SelectedRows[0].Cells["clmSPID"].Value);
                            grdDamageEntry.Rows.RemoveAt(this.grdDamageEntry.SelectedRows[0].Index);
                            for (int i = 0; i < grdDamageEntry.RowCount; i++)
                            {
                                grdDamageEntry.Rows[i].Cells["clmdsno"].Value = i + 1;
                            }
                                for (int i = 0; i < dtDamage.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtDamage.Rows[i]["DM_PRID"]) == Convert.ToInt32(PRID) && Convert.ToInt32(dtDamage.Rows[i]["DM_SLID"]) == SLID && Convert.ToString(dtDamage.Rows[i]["DM_RKID"]) == RKID && Convert.ToInt32(dtDamage.Rows[i]["DM_MRP"]) == MRP && Convert.ToString(dtDamage.Rows[i]["DM_ExpiryDate"]) == ExpiryDate && Convert.ToString(dtDamage.Rows[i]["DM_BatchNo"]) == BatchNo && Convert.ToString(dtDamage.Rows[i]["DM_SPID"]) == SPID)
                                    {
                                        dtDamage.Rows[i].Delete();
                                        dtDamage.AcceptChanges();
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
                txttotalitem.Text = Convert.ToString(grdDamageEntry.Rows.Count);
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
        private void BtnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                epDamageEntry.Clear();
                bool blnErrorFlag = false;

                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    epDamageEntry.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpcompanyname.ShowAlways = true;
                    tpcompanyname.Show("Please select concern", cmbConcern, 5000);
                    blnErrorFlag = true;
                }
                //if (Convert.ToString(txtTransferNo.Text).Trim() == "")
                //{
                //    errStockTransfer.SetError(txtTransferNo, "Please enter transfer no.");
                //    txtTransferNo.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //    tpTransferNo.ShowAlways = true;
                //    tpTransferNo.Show("Please enter transfer no.", txtTransferNo, 5000);
                //    blnErrorFlag = true;
                //}
                if (grdDamageEntry.Rows.Count < 1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(53);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    epDamageEntry.Clear();
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
                varoriginator = ""; int varType = 0;
                if (btnSave.Text == "Save")
                {
                    varoriginator = "Damage Entry Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Damage Entry Updation";
                    varType = 1;
                }
                TRN_Damage objTRN_Damage = new TRN_Damage();
                objTRN_Damage.ViewType = varType;
                objTRN_Damage.paraDamageEntryID = varID;
                objTRN_Damage.ParaCompanycode = Convert.ToInt32(cmbConcern.SelectedValue);
                objTRN_Damage.paraTransferDate = dpEntryDate.Text;
                objTRN_Damage.paraLocationID = Convert.ToInt32(varSLID);
                objTRN_Damage.paraRemarks = txtRemark.Text.Trim();
                objTRN_Damage.paraOriginator = varoriginator;
                objTRN_Damage.paraDamageEntry = dtDamage;
                varResult = objspservice.udfnDamageEntry(objTRN_Damage);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objINV_DamageEntryList.udfnList();
                    udfnClear();
                    this.Close();
                }
                else
                {
                    epDamageEntry.Clear();
                    txtProductName.BackColor = Color.White;
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
                    //if (varvalue[0] == "5")
                    //{
                    //    string[] varFirstList = varvalue[2].Split('|');
                    //    for (int i = 0; i < varFirstList.Length; i++)
                    //    {
                    //        string[] varSecondList = varFirstList[i].Split(',');
                    //        string varPRID = varSecondList[0];
                    //        string varMRP = varSecondList[1];
                    //        string varExpiryDate = varSecondList[2];
                    //        string varBatchNo = varSecondList[3];
                    //        for (int j = 0; j < grdDamageEntry.RowCount; j++)
                    //        {
                    //            if (Convert.ToString(grdDamageEntry.Rows[j].Cells["clmPRID"].Value) == varPRID && Convert.ToString(grdDamageEntry.Rows[j].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdDamageEntry.Rows[j].Cells["clmExpirydate"].Value) == varExpiryDate && Convert.ToString(grdDamageEntry.Rows[j].Cells["clmbatchno"].Value) == varBatchNo)
                    //            {
                    //                grdDamageEntry.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
                    //            }
                    //        }
                    //    }
                    //}
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
                btnSave.Enabled = true;
            }
        }
        private void BtnClose_Enter(object sender, EventArgs e)
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
                btnSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_DamageEntry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Escape)
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
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMrp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
        private void TxtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
        private void TxtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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
        private void TxtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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

        private void TxtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtProductName.Text == "")
                //{
                //    txtMrp.Text = "";
                //    txtExpiryDate.Text = "";
                //    txtBatchNo.Text = "";
                //    txtStockQty.Text = "";
                //    txtQuantity.Text = "";
                //}
                lvProduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductName.Text.Length > 0)
                {
                    objDs = objspdservice.udfnproductmasterlist(38, 0, 0, 0, 0, "", "", "", Convert.ToInt32(cmbConcern.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, txtProductName.Text.Trim(), 0, null);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["Product"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["QTY"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString(), objDs.Tables[0].Rows[i]["SL_ShortName"].ToString(), objDs.Tables[0].Rows[i]["PR_UTID"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["STK_RKID"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvProduct.Items.Add(objList);
                                }
                                lvProduct.Visible = true;
                                lvProduct.BringToFront();
                                lvProduct.Columns[0].Width = 150;
                                lvProduct.Columns[1].Width = 550;
                                lvProduct.Columns[2].Width = 250;
                                lvProduct.Columns[3].Width = 0;
                                lvProduct.Columns[4].Width = 0;
                                lvProduct.Columns[5].Width = 0;
                                lvProduct.Columns[6].Width = 0;
                                lvProduct.Columns[7].Width = 0;
                                lvProduct.Columns[8].Width = 0;
                                lvProduct.Columns[9].Width = 0;
                                lvProduct.Columns[10].Width = 0;
                                lvProduct.Columns[11].Width = 0;
                                lvProduct.Columns[12].Width = 0;
                                lvProduct.Columns[13].Width = 0;
                                lvProduct.Columns[14].Width = 0;
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

        private void DpEntryDate_KeyDown(object sender, KeyEventArgs e)
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

        private void LvProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnProductEvent();
                txtQuantity.Focus();
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
                    txtQuantity.Focus();
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
                if (txtProductName.Text != "")
                {
                    ListViewItem selectedItem = lvProduct.SelectedItems[0];
                    varPICode = selectedItem.SubItems[0].Text;
                    txtProductName.Text = selectedItem.SubItems[3].Text;
                    txtLocation.Text = selectedItem.SubItems[10].Text;
                    txtRack.Text = selectedItem.SubItems[14].Text;
                    txtMrp.Text = selectedItem.SubItems[4].Text;
                    txtExpiryDate.Text = selectedItem.SubItems[5].Text;
                    txtBatchNo.Text = selectedItem.SubItems[6].Text;
                    txtStockQty.Text = selectedItem.SubItems[7].Text;
                    lblProduct.Text = selectedItem.SubItems[8].Text;
                    varSLID = selectedItem.SubItems[9].Text;
                    varUTID = selectedItem.SubItems[11].Text;
                    varUnitSymbol = selectedItem.SubItems[12].Text;
                    varMRP = selectedItem.SubItems[4].Text;
                    varExpiryDate = selectedItem.SubItems[5].Text;
                    varBatchNo = selectedItem.SubItems[6].Text;
                    varProductCode = selectedItem.SubItems[8].Text;
                    varRKID = selectedItem.SubItems[13].Text;
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
            }
        }

        private void Txtsuppliername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSupplier.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtsuppliername.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSupplierList(15, 0, 0, 0, 0, txtsuppliername.Text, 0, 0, 0, "", 0, 0, 0, 0, 0);
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
                                    lvSupplier.Items.Add(objList);
                                }
                                lvSupplier.Visible = true;
                                lvSupplier.BringToFront();
                                lvSupplier.Columns[1].Width = 0;
                                lvSupplier.Columns[2].Width = 0;
                                lvSupplier.Columns[0].Width = 250;
                                lvSupplier.Columns[3].Width = 0;
                            }
                        }
                    }
                    objspdservice.CloseConnection();
                }
                else
                {
                    lvSupplier.Visible = false;
                    lvSupplier.Items.Clear();
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
        private void LvSupplier_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnListViewData();
                btnAdd.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnListViewData();
                    btnAdd.Focus();
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
                if (txtsuppliername.Text != "")
                {
                        ListViewItem selectedItem = lvSupplier.SelectedItems[0];
                        txtsuppliername.Text = selectedItem.SubItems[0].Text;
                        lblSupplierCode.Text = selectedItem.SubItems[1].Text;
                        lblScheduleCode.Text = selectedItem.SubItems[2].Text;
                        //varSuppliervalue = selectedItem.SubItems[3].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSupplier.Visible = false;
            }
        }

        private void TxtQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DpEntryDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                udfnTransferNo();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
