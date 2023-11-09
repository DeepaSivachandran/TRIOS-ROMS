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
    public partial class INV_StockTransfer : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;


        private ToolTip tpConcern = new ToolTip();
        private ToolTip tpTransferNo = new ToolTip();
        private ToolTip tpProductName = new ToolTip();
        private ToolTip tpSStockLocation = new ToolTip();
        private ToolTip tpDStockLocation = new ToolTip();
        private ToolTip tpTransferQty = new ToolTip();
        private ToolTip tpsno = new ToolTip();
        public string varlocationcode;
        public string varLocation;
        public string varUnitSymbol = "";
        public string varUTID = "";
        public string varQTY = "";
        public string varPICode = "";
        public string varProductCode = "";
        public string varBatchNo = "";
        public string varExpiryDate = "";
        public string varMRP = "";
        public string varSRKID = "";
        public int varFlag = 0;
        public string varSNo = "0";
        public int varUpdate = 0;
        public int varStockTransferID = 0;
        public int varStatusID = 0;
        public int varSLID = 0;
        public int varDLID = 0;
        public int VarConcernID = 0;
        public string VarSource = "0";
        public string VarDestination = "0";

        DataTable dtStock = new DataTable();

        public INV_StockTransfer()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
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
        public void udfnToolTipClear()
        {
            tpConcern.Active = false;
            tpTransferNo.Active = false;
            tpProductName.Active = false;
            tpSStockLocation.Active = false;
            tpDStockLocation.Active = false;
            tpTransferQty.Active = false;
    }
        public void udfnclose()
        {
            try
            {
                udfnToolTipClear();
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
        private void INV_StockTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    btnSave.Focus();
                    BtnSave_Click(sender,e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnRemarks_Click(object sender, EventArgs e)
        {
            try
            {

                MainForm.objPUR_RemarksHistory = new PUR_RemarksHistory();
                MainForm.objPUR_RemarksHistory.ShowDialog();
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
                    dpTrannsferDate.Focus();
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
                    errStockTransfer.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
                }
                else
                {
                    errStockTransfer.Clear();
                    cmbConcern.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void INV_StockTransfer_Load(object sender, EventArgs e)
        {
            try
            {
                dpTrannsferDate.MaxDate = DateTime.Now;
                dtStock.TableName = "TRN_StockTransfer_Product_AutoComplete";
                dtStock.Columns.Add("STK_PRID", typeof(int));
                dtStock.Columns.Add("STK_MRP", typeof(string));
                dtStock.Columns.Add("STK_ExpiryDate", typeof(string));
                dtStock.Columns.Add("STK_BatchNo", typeof(string));
                dtStock.Columns.Add("STK_UTID", typeof(string));
                dtStock.Columns.Add("STK_QTY", typeof(string));
                dtStock.Columns.Add("STK_Source_RKID", typeof(string));
                dtStock.Columns.Add("STK_Dest_SLID", typeof(string));
                dtStock.Columns.Add("STK_Dest_RKID", typeof(string));
                udfnCmbConcern();
                if (btnSave.Text=="Save")
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
        public void udfnEdit()
        {
            try
            {
                if(varStockTransferID!=0)
                {
                    SPDataService objspservice = new SPDataService();
                    DataSet objDS;
                    objDS = objspservice.udfnStockTransferList(1,varStockTransferID,0,0,0,0,0,"","");
                    objspservice.CloseConnection();
                    if (objDS != null)
                    {
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            txtSLocation.Text = objDS.Tables[0].Rows[0]["Source"].ToString().Replace("''", "'");
                            //txtDLocation.Text = objDS.Tables[0].Rows[0]["Destination"].ToString().Replace("''", "'");
                            dpTrannsferDate.Text = objDS.Tables[0].Rows[0]["Transfer Date"].ToString().Replace("''", "'");
                            txtTransferNo.Text = objDS.Tables[0].Rows[0]["Transfer No."].ToString().Replace("''", "'");
                            cmbConcern.SelectedValue = objDS.Tables[0].Rows[0]["ConcernID"].ToString();
                            cmbDRack.SelectedValue = objDS.Tables[0].Rows[0]["DRKID"].ToString();
                            //txtSRack.Text = objDS.Tables[0].Rows[0]["Source Rack"].ToString();
                            varSRKID = objDS.Tables[0].Rows[0]["SRKID"].ToString();
                            txtRemarks.Text = objDS.Tables[0].Rows[0]["Remarks"].ToString();
                            lblSLocation.Text = objDS.Tables[0].Rows[0]["SLID"].ToString();
                            lblDLocation.Text = objDS.Tables[0].Rows[0]["DLID"].ToString();
                            btnSave.Text = "Update";
                        }
                        if (objDS.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                            {
                                //grdStockTransfer.Rows.Add(grdStockTransfer.Rows.Count + 1, varPICode,
                                //(txtProductNamePICode.Text).Trim(), (txtMRP.Text).Trim(), (txtExpiryDate.Text).Trim(), 
                                //(txtBatchNo.Text).Trim(), (txtQuantity.Text).Trim(), varUnitSymbol, (lblProduct.Text).Trim(),
                                //varUTID, (txtQuantity.Text).Trim());
                                grdStockTransfer.Rows.Add(Convert.ToString(objDS.Tables[0].Rows[i]["S.No."]), Convert.ToString(objDS.Tables[0].Rows[i]["PICode"]), Convert.ToString(objDS.Tables[0].Rows[i]["Product"]), Convert.ToString(objDS.Tables[0].Rows[i]["Source Rack"]),
                                Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToString(objDS.Tables[0].Rows[i]["Destination"]), Convert.ToString(objDS.Tables[0].Rows[i]["Destination Rack"]),
                                Convert.ToString(objDS.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDS.Tables[0].Rows[i]["Unit"]), Convert.ToString(objDS.Tables[0].Rows[i]["PRID"]), Convert.ToString(objDS.Tables[0].Rows[i]["SRKID"]));
                                dtStock.Rows.Add(Convert.ToInt32(objDS.Tables[0].Rows[i]["PRID"]),Convert.ToString(objDS.Tables[0].Rows[i]["MRP"]), Convert.ToString(objDS.Tables[0].Rows[i]["Expiry Date"]), Convert.ToString(objDS.Tables[0].Rows[i]["Batch No"]), Convert.ToString(objDS.Tables[0].Rows[i]["UnitID"]), Convert.ToString(objDS.Tables[0].Rows[i]["QTY"]), Convert.ToString(objDS.Tables[0].Rows[i]["SRKID"]), Convert.ToString(objDS.Tables[0].Rows[i]["DLID"]), Convert.ToString(objDS.Tables[0].Rows[i]["DRKID"]));
                                //dtStock.Rows.Add((lblProduct.Text).Trim(), (txtMRP.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), varUTID, (txtQuantity.Text).Trim());
                                grdStockTransfer.Columns["clmdsno"].Width = 50;
                                grdStockTransfer.Columns["clmmrp"].Width = 50;
                                grdStockTransfer.Columns["clmquantity"].Width = 70;
                                grdStockTransfer.Columns["clmExpirydate"].Width = 90;
                                grdStockTransfer.Columns["clmbatchno"].Width = 70;
                                grdStockTransfer.Columns["clmDestLocation"].Width = 140;
                                grdStockTransfer.Columns["clmDestRack"].Width = 140;
                                grdStockTransfer.Columns["clmUnit"].Width = 60;
                                grdStockTransfer.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                grdStockTransfer.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStockTransfer.Columns["clmbatchno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                grdStockTransfer.Columns["clmquantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                grdStockTransfer.Columns["clmExpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            }
                            btnSave.Text = "Update";
                        }
                    }
                    lvSLocation.Visible = false;
                    lvDLocation.Visible = false;
                    cmbConcern.Enabled = false;
                    dpTrannsferDate.Enabled = false;
                    txtSLocation.Enabled = false;
                }

            }
            catch(Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txttotalitem.Text = Convert.ToString(grdStockTransfer.Rows.Count);
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
        private void TxtSLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvSLocation.Items.Count == 0 || txtSLocation.Text == "")
                    {
                        txtProductNamePICode.Focus();
                        lvSLocation.Visible = false;
                    }
                    else
                    {
                        lvSLocation.Focus();
                    }
                    if (lvSLocation.Items.Count > 0)
                    {
                        lvSLocation.Items[0].Selected = true;
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
        private void TxtSLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtSLocation.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtSLocation, "Please enter location");
                    txtSLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSStockLocation.ShowAlways = true;
                    tpSStockLocation.Show("Please enter location", txtSLocation, 5000);
                    lblSLocation.Text = "0";
                }
                else
                {
                    errStockTransfer.Clear();
                    txtSLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDLocationValid()
        {
            /* Check purchase stock location is valid or not*/
            string varId_PurLocation = "0";
            if (txtDLocation.Text == "")
            {
                varId_PurLocation = "0";
            }
            else
            {
                DataSet objDsPurLoc = new DataSet();
                SPDataService objDServ3 = new SPDataService();
                objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtDLocation.Text.Trim(), 0, 0, 0);
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
            lblDLocation.Text = Convert.ToString(varId_PurLocation);
        }
        private void TxtSLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnDLocationValid();
                lvSLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSLocation.Text.Length > 0)
                {
                    objDs = objspdservice.udfnStockLocationList(21, Convert.ToInt32(cmbConcern.SelectedValue), Convert.ToInt32(lblDLocation.Text), 0, txtSLocation.Text, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSLocation.Columns[1].Width = 0;
                                    lvSLocation.Items.Add(objList);
                                }
                                lvSLocation.BringToFront();
                                lvSLocation.Visible = true;
                            }
                            else
                            {
                                lvSLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvSLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvSLocation.Visible = false;
                    }
                }
                else
                {
                    lvSLocation.Visible = false;
                    lvSLocation.Items.Clear();
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
        private void LvSLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSLocationEvent();
                txtProductNamePICode.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvSLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSLocationEvent();
                    txtProductNamePICode.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSLocationEvent()
        {
            try
            {
                if (txtSLocation.Text != "")
                {
                    ListViewItem selectedItem = lvSLocation.SelectedItems[0];
                    txtSLocation.Text = selectedItem.SubItems[0].Text;
                    lblSLocation.Text = selectedItem.SubItems[1].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSLocation.Visible = false;
            }
        }
        private void TxtDLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                if (grdStockTransfer.Rows.Count > 0)
                {
                    udfnSLocationValid();
                    if (Convert.ToString(varlocationcode) != Convert.ToString(lblSLocation.Text))
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(78);
                        objDServ.CloseConnection();
                        DialogResult dialogResult = MessageBox.Show(varMessage, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            grdStockTransfer.Rows.Clear();
                            dtStock.Rows.Clear();
                            txtDLocation.Focus();
                        }
                        else
                        {
                            txtSLocation.Text = varLocation;
                        }
                    }
                }
                lvSLocation.Visible = false;
                txtDLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvDLocation.Items.Count == 0 || txtDLocation.Text == "")
                    {
                        cmbDRack.Focus();
                        lvDLocation.Visible = false;
                    }
                    else
                    {
                        lvDLocation.Focus();
                    }
                    if (lvDLocation.Items.Count > 0)
                    {
                        lvDLocation.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    cmbDRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtDLocation.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtDLocation, "Please enter location");
                    txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDStockLocation.ShowAlways = true;
                    tpDStockLocation.Show("Please enter location", txtDLocation, 5000);
                    lblDLocation.Text = "0";
                }
                else
                {
                    errStockTransfer.Clear();
                    txtDLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSLocationValid()
        {
            /* Check purchase stock location is valid or not*/
            string varId_PurLocation = "0";
            if (txtSLocation.Text == "")
            {
                varId_PurLocation = "0";
            }
            else
            {
                DataSet objDsPurLoc = new DataSet();
                SPDataService objDServ3 = new SPDataService();
                objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtSLocation.Text.Trim(), 0, 0, 0);
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
            lblSLocation.Text = Convert.ToString(varId_PurLocation);
        }
        private void TxtDLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                udfnSLocationValid();
                lvDLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtDLocation.Text.Length > 0)
                {
                    objDs = objspdservice.udfnStockLocationList(21, Convert.ToInt32(cmbConcern.SelectedValue),Convert.ToInt32(lblSLocation.Text) , 0, txtDLocation.Text, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["SL_EName"].ToString(), objDs.Tables[0].Rows[i]["SLID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvDLocation.Columns[1].Width = 0;
                                    lvDLocation.Items.Add(objList);
                                }
                                lvDLocation.BringToFront();
                                lvDLocation.Visible = true;
                            }
                            else
                            {
                                lvDLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvDLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvDLocation.Visible = false;
                    }
                }
                else
                {
                    lvDLocation.Visible = false;
                    lvDLocation.Items.Clear();
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
        private void LvDLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnDLocationEvent();
                cmbDRack.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvDLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnDLocationEvent();
                    cmbDRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDLocationEvent()
        {
            try
            {
                if (txtDLocation.Text != "")
                {
                    ListViewItem selectedItem = lvDLocation.SelectedItems[0];
                    txtDLocation.Text = selectedItem.SubItems[0].Text;
                    lblDLocation.Text = selectedItem.SubItems[1].Text;

                    udfncmbDRack();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvDLocation.Visible = false;
            }
        }
        private void TxtProductNamePICode_Enter(object sender, EventArgs e)
        {
            try
            {
                udfnSLocationValid();
                lvDLocation.Visible = false;
                lvSLocation.Visible = false;
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
                        txtProductNamePICode.Focus();
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
                    txtDLocation.Focus();
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
                    errStockTransfer.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductName.ShowAlways = true;
                    tpProductName.Show("Please enter product name", txtProductNamePICode, 5000);
                }
                else
                {
                    errStockTransfer.Clear();
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
                if (txtProductNamePICode.Text == "")
                {
                    txtMRP.Text = "";
                    txtExpiryDate.Text = "";
                    txtBatchNo.Text = "";
                    txtStockQty.Text = "";
                    txtQuantity.Text = "";
                }
                varlocationcode = lblSLocation.Text;
                lvProduct.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductNamePICode.Text.Length > 0)
                {
                    objDs = objspdservice.udfnproductmasterlist(35,0, 0, 0,0,"","","",Convert.ToInt32(cmbConcern.SelectedValue),0,0,0,0,0,0,0,Convert.ToInt32(lblSLocation.Text),0,0,0,0,txtProductNamePICode.Text.Trim(),0,"",dtStock);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PR_PICode"].ToString(), objDs.Tables[0].Rows[i]["Product"].ToString(), objDs.Tables[0].Rows[i]["PR_TName"].ToString(), objDs.Tables[0].Rows[i]["PR_EName"].ToString(), objDs.Tables[0].Rows[i]["STK_MRP"].ToString(), objDs.Tables[0].Rows[i]["STK_ExpiryDate"].ToString(), objDs.Tables[0].Rows[i]["STK_BatchNo"].ToString(), objDs.Tables[0].Rows[i]["QTY"].ToString(), objDs.Tables[0].Rows[i]["PRID"].ToString(), objDs.Tables[0].Rows[i]["PR_UTID"].ToString(), objDs.Tables[0].Rows[i]["UT_Symbol"].ToString(), objDs.Tables[0].Rows[i]["STK_RKID"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvProduct.Items.Add(objList);
                                }
                                lvProduct.Visible = true;
                                lvProduct.BringToFront();
                                lvProduct.Columns[0].Width = 150;
                                lvProduct.Columns[1].Width = 480;
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
        private void TxtQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                lvProduct.Visible = false;
                txtQuantity.BackColor = Color.LemonChiffon;
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
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
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
        private void TxtQuantity_Leave(object sender, EventArgs e)
        {
            try
            {
                if(txtQuantity.Text.Trim()=="")
                {
                    errStockTransfer.SetError(txtQuantity, "Please enter quentity");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransferQty.ShowAlways = true;
                    tpTransferQty.Show("Please enter quentity", txtQuantity, 5000);
                }
                else
                {
                    errStockTransfer.Clear();
                    txtQuantity.BackColor = Color.White;
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
                grdStockTransfer.Rows.Clear();
                if (btnSave.Text == "Save")
                {
                    txtSLocation.Text = "";
                    txtDLocation.Text = "";
                    txttotalitem.Text = Convert.ToString(grdStockTransfer.Rows.Count);
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
            if (btnSave.Text == "Save")
            {
                if (Convert.ToInt32(cmbConcern.SelectedValue) != -1)
                {
                    string vardate = "", varResult = "";
                    SPDataService objspdservice = new SPDataService();
                    DataSet objDs = new DataSet();
                    DataService objDservice = new DataService();
                    vardate = objDservice.displaydata("SELECT CONVERT(NVARCHAR,'"+dpTrannsferDate.Text+"',103)");
                    varResult = objspdservice.udfngetPONO("44", vardate, Convert.ToInt32(cmbConcern.SelectedValue));
                    objspdservice.CloseConnection();
                    string[] varvalue = varResult.Split('~');
                    if (varResult != "")
                    {
                        txtTransferNo.Text = varvalue[0];
                    }
                    else
                    {
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(75);
                        objDServ.CloseConnection();
                        txtTransferNo.Text = "";
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
                    txtTransferNo.Text = "";
                }
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtProductNamePICode.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtProductNamePICode, "Please enter product name");
                    txtProductNamePICode.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpProductName.ShowAlways = true;
                    tpProductName.Show("Please enter product name", txtProductNamePICode, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtDLocation.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtDLocation, "Please enter destination location");
                    txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpDStockLocation.ShowAlways = true;
                    tpDStockLocation.Show("Please enter destination location", txtDLocation, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtQuantity.Text).Trim() != "")
                {
                    if (Convert.ToInt32(txtStockQty.Text.Trim()) >= Convert.ToInt32(txtQuantity.Text.Trim()))
                    {
                        errStockTransfer.Clear();
                        txtQuantity.BackColor = Color.White;
                    }
                    else
                    {
                        errStockTransfer.SetError(txtQuantity, "Please enter valid quentity");
                        txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpTransferQty.ShowAlways = true;
                        tpTransferQty.Show("Please enter valid quentity", txtQuantity, 5000);
                        blnErrorFlag = true;
                    }
                }
                else
                {
                    errStockTransfer.SetError(txtQuantity, "Please enter quentity");
                    txtQuantity.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpTransferQty.ShowAlways = true;
                    tpTransferQty.Show("Please enter quentity", txtQuantity, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    string DRKID = "";
                    if (cmbDRack.Text == "None")
                    {
                         DRKID = "0";
                    }
                    else
                    {
                        DRKID =Convert.ToString(cmbDRack.SelectedValue);
                    }
                    varLocation = txtSLocation.Text;
                    grdStockTransfer.Rows.Add(grdStockTransfer.Rows.Count + 1, varPICode, (txtProductNamePICode.Text).Trim(), (txtSRack.Text).Trim(), (txtMRP.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), (txtDLocation.Text).Trim(), (cmbDRack.Text).Trim(), (txtQuantity.Text).Trim(), varUnitSymbol, (lblProduct.Text).Trim(), varSRKID,varUTID, (txtQuantity.Text).Trim());
                    dtStock.Rows.Add((lblProduct.Text).Trim(), (txtMRP.Text).Trim(), (txtExpiryDate.Text).Trim(), (txtBatchNo.Text).Trim(), varUTID, (txtQuantity.Text).Trim(), varSRKID,(lblDLocation.Text).Trim(),DRKID);
                    txttotalitem.Text = Convert.ToString(grdStockTransfer.Rows.Count);
                    grdStockTransfer.Columns["clmdsno"].Width = 50;
                    grdStockTransfer.Columns["clmmrp"].Width = 50;
                    grdStockTransfer.Columns["clmquantity"].Width = 70;
                    grdStockTransfer.Columns["clmExpirydate"].Width = 90;
                    grdStockTransfer.Columns["clmbatchno"].Width = 70;
                    grdStockTransfer.Columns["clmDestLocation"].Width = 140;
                    grdStockTransfer.Columns["clmDestRack"].Width = 140;
                    grdStockTransfer.Columns["clmUnit"].Width = 60;
                    grdStockTransfer.Columns["clmdsno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdStockTransfer.Columns["clmmrp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdStockTransfer.Columns["clmbatchno"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    grdStockTransfer.Columns["clmquantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdStockTransfer.Columns["clmExpirydate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    txtProductNamePICode.Focus();
                    errStockTransfer.Clear();
                    udfnProductClear();
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
            txtProductNamePICode.Text = "";
            txtSRack.Text = "";
            txtMRP.Text = "";
            txtExpiryDate.Text = "";
            txtBatchNo.Text = "";
            txtStockQty.Text = "";
            txtDLocation.Text = "";
            cmbDRack.Text = "None";
            txtQuantity.Text = "";
        }
        public void udfnClear()
        {
            cmbConcern.SelectedValue = -1;
            txtTransferNo.Text = "";
            txtSLocation.Text = "";
            txtDLocation.Text = "";
        }
        private void BtnAdd_Enter(object sender, EventArgs e)
        {
            try
            {
                lvSLocation.Visible = false;
                lvDLocation.Visible = false;
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
                btnAdd.BackColor = Color.White;
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
                txtDLocation.Focus();
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
                    txtDLocation.Focus();
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
                    varPICode = selectedItem.SubItems[0].Text;
                    txtProductNamePICode.Text = selectedItem.SubItems[3].Text;
                    txtMRP.Text = selectedItem.SubItems[4].Text;
                    txtExpiryDate.Text = selectedItem.SubItems[5].Text;
                    txtBatchNo.Text = selectedItem.SubItems[6].Text;
                    txtStockQty.Text = selectedItem.SubItems[7].Text;
                    lblProduct.Text = selectedItem.SubItems[8].Text;
                    varUTID = selectedItem.SubItems[9].Text;
                    varUnitSymbol = selectedItem.SubItems[10].Text;
                    varMRP = selectedItem.SubItems[4].Text;
                    varExpiryDate = selectedItem.SubItems[5].Text;
                    varBatchNo = selectedItem.SubItems[6].Text;
                    varProductCode = selectedItem.SubItems[8].Text;
                    varSRKID = selectedItem.SubItems[11].Text;
                    txtSRack.Text = selectedItem.SubItems[12].Text;
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
        private void GrdStockTransfer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int varProductID = 0;
                string varMRP="",varExpiryDate="",varBatchNo="", varSRKID = "";
                if (e.RowIndex != -1)
                {
                    switch (grdStockTransfer.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemove":
                        DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            varProductID = Convert.ToInt32(grdStockTransfer.SelectedRows[0].Cells["clmPRID"].Value);
                            varMRP = Convert.ToString(grdStockTransfer.SelectedRows[0].Cells["clmmrp"].Value);
                            varExpiryDate = Convert.ToString(grdStockTransfer.SelectedRows[0].Cells["clmExpirydate"].Value);
                            varBatchNo = Convert.ToString(grdStockTransfer.SelectedRows[0].Cells["clmbatchno"].Value);
                            varBatchNo = Convert.ToString(grdStockTransfer.SelectedRows[0].Cells["clmbatchno"].Value);
                            varSRKID = Convert.ToString(grdStockTransfer.SelectedRows[0].Cells["clmSRID"].Value);
                            grdStockTransfer.Rows.RemoveAt(this.grdStockTransfer.SelectedRows[0].Index);
                            for (int i = 0; i < grdStockTransfer.RowCount; i++)
                            {
                                grdStockTransfer.Rows[i].Cells["clmdsno"].Value = i + 1;
                            }
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
//////          List<DataRow> removeRows = from r in dtStock.AsEnumerable()
//////                                 where (r.Field<string>("STK_PRID").ToUpper().Equals(Convert.ToString(varProductID).Trim().ToUpper())) &&
//////(r.Field<string>("STK_MRP").ToUpper().Equals(Convert.ToString(varMRP).Trim().ToUpper())) &&
//////(r.Field<string>("STK_ExpiryDate").ToUpper().Equals(Convert.ToString(varExpiryDate).Trim().ToUpper())) &&
//////(r.Field<string>("STK_BatchNo").ToUpper().Equals(Convert.ToString(varBatchNo).Trim().ToUpper()))
//////                                 group r by r.Field<string>("STK_PRID")
//////                                into g
//////                                 select g.Key.ToList();


//                //  List<DataRow> removeRows =dtStock.Where(er => (er.STKPRID == varProductID) && (dtStock.STK_MRP == varMRP) && (dtStock.STK_ExpiryDate == varExpiryDate) && (dtStock.STK_Batchno == varBatchNo).ToString();
//                List<DataRow> removeRows = from r in dtStock.AsEnumerable() where (r.Field<string>("STK_PRID").Equals(Convert.ToString(varProductID))) into g select g.key.ToList();
//                removeRows.ForEach(dtStock.Rows.Remove);
//                dtStock.AcceptChanges();

                //List<DataRow> myRows = dtStock.AsEnumerable().Where(x => x.Field<int>("STK_PRID") == Convert.ToInt32(varProductID)).ToList();
                //foreach (DataRow row in myRows) {
                //    dtStock.Rows.Remove(row);
                //}
                //dtStock.AcceptChanges();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                txttotalitem.Text = Convert.ToString(grdStockTransfer.Rows.Count);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errStockTransfer.Clear();
                bool blnErrorFlag = false;

                if (Convert.ToString(cmbConcern.SelectedValue) == "" || Convert.ToString(cmbConcern.SelectedValue) == "-1")
                {
                    errStockTransfer.SetError(cmbConcern, "Please select concern");
                    cmbConcern.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpConcern.ShowAlways = true;
                    tpConcern.Show("Please select concern", cmbConcern, 5000);
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
                if (Convert.ToString(txtSLocation.Text).Trim() == "")
                {
                    errStockTransfer.SetError(txtSLocation, "Please enter source location");
                    txtSLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpSStockLocation.ShowAlways = true;
                    tpSStockLocation.Show("Please enter source location", txtSLocation, 5000);
                    blnErrorFlag = true;
                }
                if(grdStockTransfer.Rows.Count<1)
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(53);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    errStockTransfer.Clear();
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
                    varoriginator = "Stock Transfer Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "Stock Transfer Updation";
                    varType = 1;
                }

                /* Check source stock location is valid or not*/
                if (txtSLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsSalesLoc = new DataSet();
                    SPDataService objDServ5 = new SPDataService();
                    objDsSalesLoc = objDServ5.udfnStockLocationList(14, 0, 0, 0, txtSLocation.Text.Trim(), 0, 0, 0);
                    objDServ5.CloseConnection();
                    if (objDsSalesLoc != null)
                    {
                        if (objDsSalesLoc.Tables.Count > 0)
                        {
                            if (objDsSalesLoc.Tables[0].Rows.Count > 0)
                            {
                                varId_PurLocation = Convert.ToString(objDsSalesLoc.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblSLocation.Text = Convert.ToString(varId_PurLocation);
                    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                    {
                        errStockTransfer.SetError(txtSLocation, "Please select valid source location");
                        txtSLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpSStockLocation.ShowAlways = true;
                        tpSStockLocation.Show("Please select valid source location", txtSLocation, 5000);
                    }
                }
                else
                {
                    lblSLocation.Text = "0";
                }
                /* Check destination stock location is valid or not*/
                //if (txtDLocation.Text != "")
                //{
                //    string varId_PurLocation = "0";
                //    DataSet objDsSalesLoc = new DataSet();
                //    SPDataService objDServ5 = new SPDataService();
                //    objDsSalesLoc = objDServ5.udfnStockLocationList(14, 0, 0, 0, txtDLocation.Text.Trim(), 0, 0, 0);
                //    objDServ5.CloseConnection();
                //    if (objDsSalesLoc != null)
                //    {
                //        if (objDsSalesLoc.Tables.Count > 0)
                //        {
                //            if (objDsSalesLoc.Tables[0].Rows.Count > 0)
                //            {
                //                varId_PurLocation = Convert.ToString(objDsSalesLoc.Tables[0].Rows[0][0]);
                //            }
                //        }
                //    }
                //    lblDLocation.Text = Convert.ToString(varId_PurLocation);
                //    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                //    {
                //        errStockTransfer.SetError(txtDLocation, "Please select valid destination location");
                //        txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                //        tpDStockLocation.ShowAlways = true;
                //        tpDStockLocation.Show("Please select valid destination location", txtDLocation, 5000);
                //    }
                //}
                //else
                //{
                //    lblDLocation.Text = "0";
                //}
                varResult = objspservice.udfnStockTransfer(varType,varStockTransferID,Convert.ToInt32(cmbConcern.SelectedValue),dpTrannsferDate.Text,Convert.ToInt32(lblSLocation.Text),0,txtRemarks.Text.Trim(),0,varoriginator,dtStock);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objINV_StockTransferList.udfnList();
                    udfnClear();
                    this.Close();
                }
                else
                {
                    errStockTransfer.Clear();
                    txtProductNamePICode.BackColor = Color.White;
                    MessageBox.Show(varvalue[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSave.Enabled = true;
                    btnSave.Focus();
                    if (varvalue[0] == "5")
                    {
                        string[] varFirstList = varvalue[2].Split('|');
                        for (int i = 0; i < varFirstList.Length; i++)
                        {
                            string[] varSecondList = varFirstList[i].Split(',');
                            string varPRID = varSecondList[0];
                            string varMRP = varSecondList[1];
                            string varExpiryDate = varSecondList[2];
                            string varBatchNo = varSecondList[3];
                            for (int j = 0; j < grdStockTransfer.RowCount; j++)
                            {
                                if (Convert.ToString(grdStockTransfer.Rows[j].Cells["clmPRID"].Value) == varPRID && Convert.ToString(grdStockTransfer.Rows[j].Cells["clmmrp"].Value) == varMRP && Convert.ToString(grdStockTransfer.Rows[j].Cells["clmExpirydate"].Value) == varExpiryDate && Convert.ToString(grdStockTransfer.Rows[j].Cells["clmbatchno"].Value) == varBatchNo)
                                {
                                    grdStockTransfer.Rows[j].DefaultCellStyle.BackColor = Color.LightPink;
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
                btnSave.Enabled = true;
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

        private void INV_StockTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void DpTrannsferDate_Enter(object sender, EventArgs e)
        {
            try
            {
                dpTrannsferDate.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTrannsferDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSLocation.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTrannsferDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dpTrannsferDate.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void DpTrannsferDate_ValueChanged(object sender, EventArgs e)
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
        public void udfncmbDRack()
        {
            try
            {
                //udfnDLocationValid();
                SPDataService objdserv = new SPDataService();
                DataSet objDT = new DataSet();
                objDT = objdserv.udfnRackList(16,0,0,Convert.ToInt32(lblDLocation.Text) ,0,"",0,0);
                objdserv.CloseConnection();
                cmbDRack.DataSource = null;
                if (objDT != null)
                {
                    if (objDT.Tables.Count > 0)
                    {
                        if (objDT.Tables[0].Rows.Count > 0)
                        {
                            cmbDRack.Enabled = true;
                            cmbDRack.ValueMember = "RKID";
                            cmbDRack.DisplayMember = "RK_ShortName";
                            cmbDRack.DataSource = objDT.Tables[0];
                        }
                        else
                        {
                            cmbDRack.Text = "None";
                            cmbDRack.Enabled = false;
                            txtQuantity.Focus();
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
        private void CmbDRack_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbDRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CmbDRack_KeyDown(object sender, KeyEventArgs e)
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

        private void CmbDRack_KeyPress(object sender, KeyPressEventArgs e)
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

        private void CmbDRack_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbDRack.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
    }
}
