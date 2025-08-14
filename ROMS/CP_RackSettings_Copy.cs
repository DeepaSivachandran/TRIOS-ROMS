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
    //Created By:- Sathish
    //Created On:- 02-09-2023
    public partial class CP_RackSettings_Copy : Form
    {
        DataValidation objValidation = new DataValidation();
        DataError objError;
        private ToolTip tpStockLocation = new ToolTip();
        private ToolTip tppStockLocation = new ToolTip();
        private ToolTip tpRack = new ToolTip();
        private ToolTip tppRack = new ToolTip();
        private ToolTip tpProductGroup = new ToolTip();
        private ToolTip tppProductGroup = new ToolTip();
        private ToolTip tpProductSubGroup = new ToolTip();
        private ToolTip tppProductSubGroup = new ToolTip();

        public DataTable dtSupplierMapping = new DataTable();
        public DataTable dtViewProduct = new DataTable();
        public DataTable dtViewSupplierMapping = new DataTable();
        public DataTable dtMoveProduct = new DataTable();

        public int varId = 0;
        public int varGroupId = 0;
        public int varSubGroupId = 0;
        public int varCheckAllFlag = 0;
        public int varCheckAll = 0;
        public string varProductID = "";
        public int varUpdate = 0;
        public int varRacksettingID = 0;
        public int PbRKID = 0;
        public string PbStockLocation = "";
        public int PbLocationCode = 0;
        public string PbRackName = "";
        public string PbPICode = "";
        public string PbProductName = "";
        public string PbUnit = "";

        public CP_RackSettings_Copy()
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
        private void CP_BrandList_Load(object sender, EventArgs e)
        {
            try
            {
                txtLocation.Focus();
                MainForm.objCP_RackSettinglist.grdRackSettingList.ClearSelection();
                this.ActiveControl = txtLocation;
                dtSupplierMapping = new DataTable();
                dtSupplierMapping.Columns.Add("", typeof(Boolean));
                dtSupplierMapping.Columns.Add("S.No.", typeof(string));
                dtSupplierMapping.Columns.Add("P.I Code", typeof(string));
                dtSupplierMapping.Columns.Add("Product Name in English", typeof(string));
                dtSupplierMapping.Columns.Add("Product Name in Tamil", typeof(string));
                dtSupplierMapping.Columns.Add("Unit", typeof(string));
                dtSupplierMapping.Columns.Add("PRODUCTID", typeof(int));

                dtViewSupplierMapping = new DataTable();
                dtViewSupplierMapping.Columns.Add("P.I Code", typeof(string));
                dtViewSupplierMapping.Columns.Add("Product Name in English", typeof(string));
                dtViewSupplierMapping.Columns.Add("Product Name in Tamil", typeof(string));
                dtViewSupplierMapping.Columns.Add("Unit", typeof(string));
                dtViewSupplierMapping.Columns.Add("PRID", typeof(int));

                dtViewProduct = new DataTable();
                dtViewProduct.Columns.Add("", typeof(Boolean));
                dtViewProduct.Columns.Add("S.No.", typeof(string));
                dtViewProduct.Columns.Add("P.I Code", typeof(string));
                dtViewProduct.Columns.Add("Product Name in English", typeof(string));
                dtViewProduct.Columns.Add("Product Name in Tamil", typeof(string));
                dtViewProduct.Columns.Add("Unit", typeof(string));
                dtViewProduct.Columns.Add("PRODUCTID", typeof(int));

                dtMoveProduct = new DataTable();
                dtMoveProduct.Columns.Add("P.I Code", typeof(string));
                dtMoveProduct.Columns.Add("Product Name in English", typeof(string));
                dtMoveProduct.Columns.Add("Product Name in Tamil", typeof(string));
                dtMoveProduct.Columns.Add("Unit", typeof(string));
                dtMoveProduct.Columns.Add("PRID", typeof(int));

                if (btnSave.Text == "Update")
                {
                    udfnEditLoad();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnEditLoad()
        {
            try
            {
                txtLocation.Focus();
                lblSLocation.Text = Convert.ToString(PbLocationCode);
                
                lblSRack.Text = Convert.ToString(PbRKID);
                
                udfnList(PbLocationCode, PbRKID);
                lvLocation.Visible = false;
                lvRack.Visible = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void CP_BrandList_KeyDown(object sender, KeyEventArgs e)
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
                //if (e.KeyCode == Keys.Escape)
                //{
                //    MainForm.objStart = new DEF_Start();
                //    MainForm.objStart.MdiParent = this.ParentForm;
                //    MainForm.objStart.Show();
                //    this.Close();
                //}
                if (e.KeyCode == Keys.Escape)
                {
                    udfnclose();
                }
                if (e.KeyCode == Keys.F5)
                {
                    BtnSave_Click(sender, e);
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
        private void BtnClose_Click(object sender, EventArgs e)
        {
            udfnclose();
        }
        public void udfnclose()
        {
            try
            {
                if (varUpdate == 0)
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
        private void BtnView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnView.BackColor = Color.Transparent;
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
                bool blnErrorFlag = false;
                
                /* Check purchase stock location is valid or not*/
                if (txtLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtLocation.Text.Trim(),0, 0,0,"","",0);
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
                    lblSLocation.Text = Convert.ToString(varId_PurLocation);
                    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                    {
                        epRackSettings.SetError(txtLocation, "Please select valid stock location");
                        txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please select valid stock location", txtLocation, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        epRackSettings.Clear();
                    }
                }
                
                /* Check purchase rack is valid or not*/
                string varId_PurRack = "0";
                string varId_Rack = "0";
                if (txtRack.Text != "")
                {
                    DataSet objDsPurRack = new DataSet();
                    SPDataService objDServ4 = new SPDataService();
                    objDsPurRack = objDServ4.udfnRackList(9, 0, 0, Convert.ToInt32(lblSLocation.Text), 0, txtRack.Text.Trim(), 0, 0);
                    objDServ4.CloseConnection();
                    if (objDsPurRack != null)
                    {
                        if (objDsPurRack.Tables.Count > 0)
                        {
                            if (objDsPurRack.Tables[0].Rows.Count > 0)
                            {
                                varId_PurRack = Convert.ToString(objDsPurRack.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblSRack.Text = Convert.ToString(varId_PurRack);
                    if (varId_PurRack == "0" || varId_PurRack == "-1")
                    {
                        epRackSettings.SetError(txtRack, "Please select valid rack");
                        txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpRack.ShowAlways = true;
                        tpRack.Show("Please select valid rack", txtRack, 5000);
                        //grdViewSupplierMapping.DataSource = null;
                        //dtViewSupplierMapping.Rows.Clear();
                        txtRack.Focus();
                        blnErrorFlag = true;
                    }
                    else
                    {
                        epRackSettings.Clear();
                    }
                }
                if (varId_PurRack != "0" && varId_PurRack != "-1")
                {
                    if (txtLocation.Text != "")
                    {
                        DataSet objDsRack = new DataSet();
                        SPDataService objDserv4 = new SPDataService();
                        objDsRack = objDserv4.udfnRackList(7, 0, 0, Convert.ToInt32(lblSLocation.Text), 0, txtRack.Text, 0, 0);
                        objDserv4.CloseConnection();
                        if (objDsRack != null)
                        {
                            if (objDsRack.Tables.Count > 0)
                            {
                                if (objDsRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_Rack = Convert.ToString(objDsRack.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                    }
                    if (varId_PurRack == varId_Rack)
                    {
                        lblSRack.Text = Convert.ToString(varId_PurRack);
                    }
                    else
                    {
                        grdSupplierMapping.DataSource = null;
                        grdViewSupplierMapping.DataSource = null;
                        dtViewSupplierMapping.Rows.Clear();
                        dtSupplierMapping.Rows.Clear();
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(59);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRack.Text = "";
                        txtRack.Focus();
                        blnErrorFlag = true;
                    }
                }

                if (Convert.ToString(txtLocation.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtLocation, "Please enter location");
                    txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location", txtLocation, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtRack.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtRack, "Please enter rack");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please enter rack", txtRack, 5000);
                    blnErrorFlag = true;
                }
                if (grdViewSupplierMapping.Rows.Count > 0)
                {
                    if (Convert.ToString(txtLocation.Text).Trim() == "" && Convert.ToString(txtRack.Text).Trim()=="")
                    {
                        blnErrorFlag = true;
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(53);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
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
                    varoriginator = "RackSettings Creation";
                    varType = 0;
                }
                else
                {
                    varoriginator = "RackSettings Updation";
                    varType = 1;
                }
                varProductID = "";
                for (int i = 0; i < grdViewSupplierMapping.RowCount; i++)
                {
                    if (varProductID == "")
                    {
                        varProductID = Convert.ToString(grdViewSupplierMapping.Rows[i].Cells["PRID"].Value);
                    }
                    else
                    {
                        varProductID = varProductID + "," + Convert.ToString(grdViewSupplierMapping.Rows[i].Cells["PRID"].Value);
                    }
                }
                int varLocationId = 0;
                if (lblSLocation.Text == "" || lblSLocation.Text == "-1" || lblSLocation.Text == "0")
                {
                    varLocationId = 0;
                }
                else { varLocationId = Convert.ToInt32(lblSLocation.Text); }
                int varRackId = 0;
                if (lblSRack.Text == "" || lblSRack.Text == "-1" || lblSRack.Text == "0")
                {
                    varRackId = 0;
                }
                else { varRackId = Convert.ToInt32(lblSRack.Text); }

                varResult = objspservice.udfnRackSettings(varType, 0, varLocationId, varRackId, varProductID, 0, 0, varoriginator);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_RackSettinglist.udfnList();
                    txtLocation.Focus();
                    //udfnColorChange();
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1; 
                        grdViewSupplierMapping.DataSource=null;
                        grdSupplierMapping.DataSource = null;
                        dtSupplierMapping.Rows.Clear();
                        dtViewSupplierMapping.Rows.Clear();
                        udfnclose();
                    }
                    else
                    {
                        grdViewSupplierMapping.DataSource = null;
                        grdSupplierMapping.DataSource = null;
                        dtSupplierMapping.Rows.Clear();
                        dtViewSupplierMapping.Rows.Clear();
                    }
                    udfnclear();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnSave.Focus();
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
        public void udfnclear()
        {
            txtLocation.Text = "";
            txtRack.Text = "";
            txtDLocation.Text = "";
            txtDRack.Text = "";
            txtMoveLocation.Text = "";
            txtMoveRack.Text = "";
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
        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtLocation.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtLocation, "Please enter location");
                    txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location", txtLocation, 5000);
                    blnErrorFlag = true;
                }
                if (Convert.ToString(txtRack.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtRack, "Please enter rack");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please enter rack", txtRack, 5000);
                    blnErrorFlag = true;
                }
                if (blnErrorFlag == false)
                {
                    try
                    {
                        //if (btnSave.Text == "Update")
                        //{
                        //    PbLocationCode = Convert.ToInt32(lblSLocation.Text);
                        //    PbRKID = Convert.ToInt32(lblSRack.Text);
                        //    udfnList(PbLocationCode, PbRKID);
                        //}
                        //else
                        //{
                            udfnProductList();
                            for (int j = 0; j < grdSupplierMapping.RowCount; j++)
                            {
                                if (Convert.ToString(grdViewSupplierMapping.Rows[j].Cells["PRODUCTID"].Value) == Convert.ToString(grdSupplierMapping.Rows[j].Cells["PRODUCTID"].Value))
                                {
                                    grdSupplierMapping.Rows[j].Cells[0].Value = true;
                                }
                            }
                        //}
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnList(int locationcode, int rackcode)
        {
            try
            {
                int varViewType = 1;
                dtSupplierMapping.Rows.Clear();
                dtViewSupplierMapping.Rows.Clear();
                Application.DoEvents();
                //grdSupplierMapping.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                
                objDs = objdserv.udfnRackSettingsList(varViewType, 0, 0, locationcode, rackcode);
                objdserv.CloseConnection();
                btnSave.Text = "Update";
                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtSupplierMapping.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in English"],
                           objDs.Tables[0].Rows[i]["Product Name in Tamil"], objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["PRODUCTID"]);
                    }
                }
                grdSupplierMapping.DataSource = null;
                grdSupplierMapping.DataSource = dtSupplierMapping;
                grdSupplierMapping.Columns[0].HeaderText = "";
                grdSupplierMapping.Columns[0].Width = 50;
                grdSupplierMapping.Columns["S.No."].Width = 50;
                grdSupplierMapping.Columns["PRODUCTID"].Visible = false;
                grdSupplierMapping.Columns["P.I Code"].Width = 100;
                grdSupplierMapping.Columns["Product Name in English"].Width = 250;
                grdSupplierMapping.Columns["Product Name in Tamil"].Width = 250;
                grdSupplierMapping.Columns["S.No."].ReadOnly = true;
                grdSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                grdSupplierMapping.Columns["Product Name in English"].ReadOnly = true;
                grdSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                grdSupplierMapping.Columns["Unit"].ReadOnly = true;
                grdSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                
                if (objDs.Tables[1].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                    {
                        dtViewSupplierMapping.Rows.Add(objDs.Tables[1].Rows[i]["P.I Code"], objDs.Tables[1].Rows[i]["Product Name in English"],
                           objDs.Tables[1].Rows[i]["Product Name in Tamil"], objDs.Tables[1].Rows[i]["Unit"], objDs.Tables[1].Rows[i]["PRID"]);
                    }
                }

                grdViewSupplierMapping.DataSource = null;
                grdViewSupplierMapping.DataSource = dtViewSupplierMapping;
                grdViewSupplierMapping.Columns["clmRemoveSupplier"].DisplayIndex = 5;
                grdViewSupplierMapping.Columns["PRID"].Visible = false;
                grdViewSupplierMapping.Columns["P.I Code"].Width = 100;
                grdViewSupplierMapping.Columns["Product Name in English"].Width = 250;
                grdViewSupplierMapping.Columns["Product Name in Tamil"].Width = 250;
                grdViewSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                grdViewSupplierMapping.Columns["Product Name in English"].ReadOnly = true;
                grdViewSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                grdViewSupplierMapping.Columns["Unit"].ReadOnly = true;
                grdViewSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);

                for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                {
                    for (int j = 0; j < grdSupplierMapping.RowCount; j++)
                    {
                        if (Convert.ToString(objDs.Tables[1].Rows[i]["PRID"]) == Convert.ToString(grdSupplierMapping.Rows[j].Cells["PRODUCTID"].Value))
                        {
                            grdSupplierMapping.Rows[j].Cells[0].Value = true;
                        }
                    }
                }

                if (objDs.Tables[2].Rows.Count > 0)
                {
                    txtLocation.Text = objDs.Tables[2].Rows[0]["SL_EName"].ToString().Replace("''", "'");
                    txtRack.Text = objDs.Tables[2].Rows[0]["RK_ShortName"].ToString().Replace("''", "'");
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (btnSave.Text == "Update")
                {
                    foreach (TabPage page in tcRackSettings.TabPages)
                    {
                        if (page.Name == "MoveProduct")
                        {
                            tcRackSettings.TabPages.Remove(page);
                        }
                    }
                }
            }
        }
        private void GrdSupplierMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    udfnCalculateCheckedCount();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnCalculateCheckedCount()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdSupplierMapping.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSupplierMapping.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        varCheckedCount++;
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
                if (grdSupplierMapping.Rows.Count == varCheckedCount)
                {
                    varCheckAllFlag = 1;
                    chkRackSettings.Checked = true;
                }
                else
                {
                    varCheckAllFlag = 1;
                    chkRackSettings.Checked = false;
                }
            }
        }
        private void ChkRackSettings_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                udfnViewSupplier();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnViewSupplier()
        {
            try
            {
                string varRemoveRack = "", varAddRack = "";

                if (grdSupplierMapping.Rows.Count > 0)
                {
                    for (int i = 0; i < grdSupplierMapping.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdSupplierMapping.Rows[i].Cells[0].Value) == true)
                        {
                            int varFlag = 0, varcount = 1; ;

                            for (int j = 0; j < grdViewSupplierMapping.Rows.Count; j++)
                            {
                                varAddRack = Convert.ToString(grdSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
                                if (varAddRack == Convert.ToString(grdViewSupplierMapping.Rows[j].Cells["PRID"].Value))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                dtViewSupplierMapping.Rows.Add( grdSupplierMapping.Rows[i].Cells["P.I Code"].Value, grdSupplierMapping.Rows[i].Cells["Product Name in English"].Value,
                                    grdSupplierMapping.Rows[i].Cells["Product Name in Tamil"].Value, grdSupplierMapping.Rows[i].Cells["Unit"].Value, grdSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < dtViewSupplierMapping.Rows.Count; j++)
                            {
                                varAddRack = Convert.ToString(grdSupplierMapping.Rows[i].Cells["PRODUCTID"].Value);
                                if (varAddRack == Convert.ToString(dtViewSupplierMapping.Rows[j]["PRID"]))
                                {
                                    dtViewSupplierMapping.Rows[j].Delete();
                                    dtViewSupplierMapping.AcceptChanges();
                                }
                            }
                        }
                    }
                    grdViewSupplierMapping.DataSource = null;
                    grdViewSupplierMapping.DataSource = dtViewSupplierMapping;
                    grdViewSupplierMapping.Columns["clmRemoveSupplier"].DisplayIndex = 5;
                    grdViewSupplierMapping.Columns["PRID"].Visible = false;
                    grdViewSupplierMapping.Columns["P.I Code"].Width = 100;
                    grdViewSupplierMapping.Columns["Product Name in English"].Width = 250;
                    grdViewSupplierMapping.Columns["Product Name in Tamil"].Width = 250;
                    grdViewSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                    grdViewSupplierMapping.Columns["Product Name in English"].ReadOnly = true;
                    grdViewSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdViewSupplierMapping.Columns["Unit"].ReadOnly = true;
                    grdViewSupplierMapping.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);


                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(53);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdViewSupplierMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdViewSupplierMapping.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemoveSupplier":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdViewSupplierMapping.Rows.RemoveAt(this.grdViewSupplierMapping.SelectedRows[0].Index);
                                for (int i = 0; i < grdViewSupplierMapping.RowCount; i++)
                                {
                                    grdViewSupplierMapping.Rows[i].Cells["clmsno"].Value = i + 1;
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
        }
        private void TxtSearchByProduct1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchByProduct1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchByProduct1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdSupplierMapping.DataSource as BindingSource).Filter = "([Product Name in English]) LIKE '%" + txtSearchByProduct1.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchByProduct1.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchByProduct2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchByProduct2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchByProduct2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchByProduct2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdViewSupplierMapping.DataSource as BindingSource).Filter = "([Product Name in English]) LIKE '%" + txtSearchByProduct2.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchByProduct2.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtLocation.Text.Length > 0)
                {
                    objDs = objspdservice.udfnStockLocationList(12, 0, 0, 0, txtLocation.Text,0,0, 0,"","",0);
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
                                    lvLocation.Columns[1].Width = 0;
                                    lvLocation.Items.Add(objList);
                                }
                                lvLocation.Visible = true;
                            }
                            else
                            {
                                lvLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvLocation.Visible = false;
                    }
                }
                else
                {
                    lvLocation.Visible = false;
                    lvLocation.Items.Clear();
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
        private void TxtLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtLocation.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvLocation.Items.Count == 0 || txtLocation.Text == "")
                    {
                        txtRack.Focus();
                        txtRack.Text = "";
                        lvLocation.Visible = false;
                    }
                    else
                    {
                        lvLocation.Focus();
                    }
                    if (lvLocation.Items.Count > 0)
                    {
                        lvLocation.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtRack.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtLocation.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtLocation, "Please enter location");
                    txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location", txtLocation, 5000);
                }
                else
                {
                    epRackSettings.Clear();
                    txtLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSLocationEvent();
                txtRack.Focus();
                txtRack.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSLocationEvent();
                    txtRack.Focus();
                    txtRack.Text = "";
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
                if (txtLocation.Text != "")
                {
                    ListViewItem selectedItem = lvLocation.SelectedItems[0];
                    txtLocation.Text = selectedItem.SubItems[0].Text;
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
                lvLocation.Visible = false;
            }
        }
        private void TxtRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int varLocationId = 0;
                if (lblSLocation.Text == "" || lblSLocation.Text =="-1" || lblSLocation.Text =="0")
                {
                    varLocationId = 0;
                }
                else { varLocationId = Convert.ToInt32(lblSLocation.Text); }
                lvRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, varLocationId, 0, txtRack.Text, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_Name"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvRack.Columns[0].Width = 100;
                                    lvRack.Items.Add(objList);
                                }
                                lvRack.Visible = true;
                            }
                            else
                            {
                                lvRack.Visible = false;
                            }
                        }
                        else
                        {
                            lvRack.Visible = false;
                        }
                    }
                    else
                    {
                        lvRack.Visible = false;
                    }
                }
                else
                {
                    lvRack.Visible = false;
                    lvRack.Items.Clear();
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
        private void TxtRack_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtLocation.Text.Trim(),0,0, 0,"","",0);
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
                    lblSLocation.Text = Convert.ToString(varId_PurLocation);
                    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                    {
                        epRackSettings.SetError(txtLocation, "Please select valid stock location");
                        txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please select valid stock location", txtLocation, 5000);
                        txtRack.Text = "";
                        txtLocation.Focus();
                        txtRack.BackColor = Color.White;
                    }
                    else
                    {
                        epRackSettings.Clear();
                        txtLocation.BackColor = Color.White;

                        lvLocation.Visible = false;
                        txtRack.BackColor = Color.LemonChiffon;
                    }
                }
                txtRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvRack.Items.Count == 0 || txtRack.Text == "")
                    {
                        lvRack.Visible = false;
                    }
                    else
                    {
                        lvRack.Focus();
                    }
                    if (lvRack.Items.Count > 0)
                    {
                        lvRack.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnSourceView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtRack.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtRack, "Please enter rack");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please enter rack", txtRack, 5000);
                }
                else
                {
                    epRackSettings.Clear();
                    txtRack.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSRackEvent();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSRackEvent();
                    btnSourceView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSRackEvent()
        {
            try
            {
                if (txtRack.Text != "")
                {
                    ListViewItem selectedItem = lvRack.SelectedItems[0];
                    txtRack.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvRack.Visible = false;
            }
        }
        private void TxtDLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvDLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtDLocation.Text.Length > 0)
                {

                    objDs = objspdservice.udfnStockLocationList(12, 0, 0, 0, txtDLocation.Text, 0,0,0,"","",0);
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
        private void TxtDLocation_Enter(object sender, EventArgs e)
        {
            try
            {
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
                        txtDRack.Focus();
                        txtDRack.Text = "";
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
                    txtDRack.Focus();
                    txtDRack.Text = "";
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
                    epRackSettings.SetError(txtDLocation, "Please enter location");
                    txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppStockLocation.ShowAlways = true;
                    tppStockLocation.Show("Please enter location", txtDLocation, 5000);
                    lblDLocation.Text = "0";
                }
                else
                {
                    epRackSettings.Clear();
                    txtDLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvDRack.Items.Clear();
                int varDLocationId = 0;
                if (lblDLocation.Text == "" || lblDLocation.Text == "-1" || lblDLocation.Text == "0")
                {
                    varDLocationId = 0;
                }
                else { varDLocationId = Convert.ToInt32(lblDLocation.Text); }
                
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtDRack.Text.Length > 0)
                {
                    objDs = objspdservice.udfnRackList(7, 0, 0, varDLocationId, 0, txtDRack.Text, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_Name"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvDRack.Columns[0].Width = 100;
                                    lvDRack.Items.Add(objList);
                                }
                                lvDRack.Visible = true;
                            }
                            else
                            {
                                lvDRack.Visible = false;
                            }
                        }
                        else
                        {
                            lvDRack.Visible = false;
                        }
                    }
                    else
                    {
                        lvDRack.Visible = false;
                    }
                }
                else
                {
                    lvDRack.Visible = false;
                    lvDRack.Items.Clear();
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
        private void TxtDRack_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtDLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtDLocation.Text.Trim(),0,0, 0,"","",0);
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
                    lblDLocation.Text = Convert.ToString(varId_PurLocation);
                    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                    {
                        epRackSettings.SetError(txtDLocation, "Please select valid stock location");
                        txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppStockLocation.ShowAlways = true;
                        tppStockLocation.Show("Please select valid stock location", txtDLocation, 5000);
                        txtDRack.Text = "";
                        txtDLocation.Focus();
                    }
                    else
                    {
                        epRackSettings.Clear();
                    }
                }
                lvDLocation.Visible = false;
                txtDRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvDRack.Items.Count == 0 || txtDRack.Text == "")
                    {
                        lvDRack.Visible = false;
                    }
                    else
                    {
                        lvDRack.Focus();
                    }
                    if (lvDRack.Items.Count > 0)
                    {
                        lvDRack.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnDesignationView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtDRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtDRack.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtDRack, "Please enter rack");
                    txtDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppRack.ShowAlways = true;
                    tppRack.Show("Please enter rack", txtDRack, 5000);
                    lblDRack.Text = "0";
                }
                else
                {
                    epRackSettings.Clear();
                    txtDRack.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvDRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnDRackEvent();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvDRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnDRackEvent();
                    btnDesignationView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnDRackEvent()
        {
            try
            {
                if (txtDRack.Text != "")
                {
                    ListViewItem selectedItem = lvDRack.SelectedItems[0];
                    txtDRack.Text = selectedItem.SubItems[1].Text;
                    lblDRack.Text = selectedItem.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvDRack.Visible = false;
            }
        }

        private void LvDLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnDLocationEvent();
                txtDRack.Focus();
                txtDRack.Text="";
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
                    txtDRack.Focus();
                    txtDRack.Text = "";
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
        private void TxtProductGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtProductGroup.Text,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvGroup.Columns[2].Width = 200;
                                    lvGroup.Items.Add(objList);
                                }
                                lvGroup.Visible = true;
                            }
                            else
                            {
                                lvGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvGroup.Visible = false;
                    }
                }
                else
                {
                    lvGroup.Visible = false;
                    lvGroup.Items.Clear();
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
        private void TxtProductGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvGroup.Items.Count == 0 || txtProductGroup.Text == "")
                    {
                        txtProductGroup.Focus();
                        lvGroup.Visible = false;
                    }
                    else
                    {
                        lvGroup.Focus();
                    }
                    if (lvGroup.Items.Count > 0)
                    {
                        lvGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductGroup.BackColor = Color.White;
                if (txtProductGroup.Text.Trim() == "") { lblGroupId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnGroupevent();
                txtProductSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnGroupevent();
                    txtProductSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnGroupevent()
        {
            try
            {
                if (txtProductGroup.Text != "")
                {
                    ListViewItem selectedItem = lvGroup.SelectedItems[0];
                    lblGroupId.Text = selectedItem.SubItems[1].Text;
                    txtProductGroup.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvGroup.Visible = false;
            }
        }
        private void TxtProductSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtProductSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblGroupId.Text), 0, txtProductSubGroup.Text,0,0,0,0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvSubGroup.Columns[2].Width = 200;
                                    lvSubGroup.Items.Add(objList);
                                }
                                lvSubGroup.Visible = true;
                            }
                            else
                            {
                                lvSubGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvSubGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvSubGroup.Visible = false;
                    }
                }
                else
                {
                    lvSubGroup.Visible = false;
                    lvSubGroup.Items.Clear();
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
        private void TxtProductSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvGroup.Visible = false;
                txtProductSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvSubGroup.Items.Count == 0 || txtProductSubGroup.Text == "")
                    {
                        txtProductSubGroup.Focus();
                        lvSubGroup.Visible = false;
                    }
                    else
                    {
                        lvSubGroup.Focus();
                    }
                    if (lvSubGroup.Items.Count > 0)
                    {
                        lvSubGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtProductSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtProductSubGroup.BackColor = Color.White;
                if (txtProductSubGroup.Text.Trim() == "") { lblSubGroupId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnSubGroupevent();
                btnView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnSubGroupevent();
                    btnView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnSubGroupevent()
        {
            try
            {
                if (txtProductSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvSubGroup.SelectedItems[0];
                    lblSubGroupId.Text = selectedItem.SubItems[1].Text;
                    txtProductSubGroup.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvSubGroup.Visible = false;
            }
        }
        private void BtnSourceView_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtLocation.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtLocation, "Please enter location");
                    txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpStockLocation.ShowAlways = true;
                    tpStockLocation.Show("Please enter location", txtLocation, 5000);
                    blnErrorFlag = true;
                }
                /* Check purchase stock location is valid or not*/
                if (txtLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtLocation.Text.Trim(),0,0,0,"","",0);
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
                    lblSLocation.Text = Convert.ToString(varId_PurLocation);
                    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                    {
                        epRackSettings.SetError(txtLocation, "Please select valid stock location");
                        txtLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpStockLocation.ShowAlways = true;
                        tpStockLocation.Show("Please select valid stock location", txtLocation, 5000);
                        blnErrorFlag = true;
                    }
                    else
                    {
                        epRackSettings.Clear();
                    }
                }
                if (Convert.ToString(txtRack.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtRack, "Please enter rack");
                    txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tpRack.ShowAlways = true;
                    tpRack.Show("Please enter rack", txtRack, 5000);
                    blnErrorFlag = true;
                }

                /* Check purchase rack is valid or not*/
                string varId_PurRack = "0";
                string varId_Rack = "0";
                if (txtRack.Text != "")
                {
                    DataSet objDsPurRack = new DataSet();
                    SPDataService objDServ4 = new SPDataService();
                    objDsPurRack = objDServ4.udfnRackList(9, 0, 0, Convert.ToInt32(lblSLocation.Text), 0, txtRack.Text.Trim(), 0, 0);
                    objDServ4.CloseConnection();
                    if (objDsPurRack != null)
                    {
                        if (objDsPurRack.Tables.Count > 0)
                        {
                            if (objDsPurRack.Tables[0].Rows.Count > 0)
                            {
                                varId_PurRack = Convert.ToString(objDsPurRack.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblSRack.Text = Convert.ToString(varId_PurRack);
                    if (varId_PurRack == "0" || varId_PurRack == "-1")
                    {
                        epRackSettings.SetError(txtRack, "Please select valid rack");
                        txtRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpRack.ShowAlways = true;
                        tpRack.Show("Please select valid rack", txtRack, 5000);
                        grdViewSupplierMapping.DataSource = null;
                        dtViewSupplierMapping.Rows.Clear();
                        txtRack.Focus();
                        blnErrorFlag = true;
                    }
                    else
                    {
                        epRackSettings.Clear();
                    }
                }
                if (varId_PurRack != "0" && varId_PurRack != "-1")
                {
                    if (txtLocation.Text != "")
                    {
                        DataSet objDsRack = new DataSet();
                        SPDataService objDserv4 = new SPDataService();
                        objDsRack = objDserv4.udfnRackList(7, 0, 0, Convert.ToInt32(lblSLocation.Text), 0, txtRack.Text, 0, 0);
                        objDserv4.CloseConnection();
                        if (objDsRack != null)
                        {
                            if (objDsRack.Tables.Count > 0)
                            {
                                if (objDsRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_Rack = Convert.ToString(objDsRack.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                    }
                    if (varId_PurRack == varId_Rack)
                    {
                        lblSRack.Text = Convert.ToString(varId_PurRack);
                    }
                    else
                    {
                        grdSupplierMapping.DataSource = null;
                        grdViewSupplierMapping.DataSource = null;
                        dtSupplierMapping.Rows.Clear();
                        dtViewSupplierMapping.Rows.Clear();
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(59);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRack.Text = "";
                        txtRack.Focus();
                        blnErrorFlag = true;
                    }
                }
                if (blnErrorFlag == false)
                {
                    try
                    {
                        int varRackCount = 0;
                        //grdSupplierMapping.DataSource = null;
                        DataSet objDs = new DataSet();
                        //**** To call the function from SP ***************
                        SPDataService objdserv = new SPDataService();
                        objDs = objdserv.udfnRackSettingsList(2, 0, 0, 0, Convert.ToInt32(lblSRack.Text));
                        objdserv.CloseConnection();
                        if (objDs != null)
                        {
                            if (objDs.Tables.Count > 0)
                            {
                                if (objDs.Tables[0].Rows.Count > 0)
                                {
                                    varRackCount = Convert.ToInt32(objDs.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        if (varRackCount != 0) {
                            udfnList(Convert.ToInt32(lblSLocation.Text), Convert.ToInt32(lblSRack.Text));
                        }
                        else {
                            grdViewSupplierMapping.DataSource = null;
                            btnSave.Text = "Save";
                            udfnProductList();
                        }
                    }
                    catch (Exception ex)
                    {
                        objError = new DataError();
                        objError.WriteFile(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnProductList()
        {
            try
            {
                int varViewType = 0;
                int varStatusId = 1;
                int varRackId = 0;
                dtSupplierMapping.Rows.Clear();
                Application.DoEvents();
                //grdSupplierMapping.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                string varGroupId = "0";
                if (txtProductGroup.Text == "")
                {
                    varGroupId = "0";
                }
                else
                {
                    /* Check product group is valid or not*/
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtProductGroup.Text.Trim(),0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varGroupId = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblGroupId.Text = Convert.ToString(varGroupId);
                    if (lblGroupId.Text == "-1")
                    {
                        epRackSettings.SetError(txtProductGroup, "Please select valid group");
                        txtProductGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpProductGroup.ShowAlways = true;
                        tpProductGroup.Show("Please select valid group", txtProductGroup, 5000);
                    }
                    else
                    {
                        epRackSettings.Clear();
                    }
                }

                string varSubGroupId = "0";
                if (txtProductSubGroup.Text == "")
                {
                    varSubGroupId = "0";
                }
                else
                {
                    /* Check product sub group is valid or not*/
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtProductSubGroup.Text.Trim(), 0, 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varSubGroupId = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblSubGroupId.Text = Convert.ToString(varSubGroupId);
                    if (lblSubGroupId.Text == "-1")
                    {
                        epRackSettings.SetError(txtProductSubGroup, "Please select valid subgroup");
                        txtProductSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tpProductSubGroup.ShowAlways = true;
                        tpProductSubGroup.Show("Please select valid subgroup", txtProductSubGroup, 5000);
                    }
                    else
                    {
                        epRackSettings.Clear();
                    }
                }
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = varViewType;
                objMR_Product.paraGroup = Convert.ToInt32(varGroupId);
                objMR_Product.paraSubgroup = Convert.ToInt32(varSubGroupId);
                objMR_Product.paraStatusId = varStatusId;
                objDs = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();

                if (objDs.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                    {
                        dtSupplierMapping.Rows.Add(false, objDs.Tables[0].Rows[i]["S.No."], objDs.Tables[0].Rows[i]["P.I Code"], objDs.Tables[0].Rows[i]["Product Name in English"],
                           objDs.Tables[0].Rows[i]["Product Name in Tamil"], objDs.Tables[0].Rows[i]["Unit"], objDs.Tables[0].Rows[i]["ID"]);
                    }
                }
                grdSupplierMapping.DataSource = null;
                grdSupplierMapping.DataSource = dtSupplierMapping;
                grdSupplierMapping.Columns[0].HeaderText = "";
                grdSupplierMapping.Columns[0].Width = 50;
                grdSupplierMapping.Columns["S.No."].Width = 50;
                grdSupplierMapping.Columns["PRODUCTID"].Visible = false;
                grdSupplierMapping.Columns["P.I Code"].Width = 100;
                grdSupplierMapping.Columns["Product Name in English"].Width = 250;
                grdSupplierMapping.Columns["Product Name in Tamil"].Width = 250;
                grdSupplierMapping.Columns["S.No."].ReadOnly = true;
                grdSupplierMapping.Columns["P.I Code"].ReadOnly = true;
                grdSupplierMapping.Columns["Product Name in English"].ReadOnly = true;
                grdSupplierMapping.Columns["Product Name in Tamil"].ReadOnly = true;
                grdSupplierMapping.Columns["Unit"].ReadOnly = true;

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                if (btnSave.Text == "Update")
                {
                    foreach (TabPage page in tcRackSettings.TabPages)
                    {
                        if (page.Name == "MoveProduct")
                        {
                            tcRackSettings.TabPages.Remove(page);
                        }
                    }
                }
            }
        }
        private void BtnSourceView_Enter(object sender, EventArgs e)
        {
            try
            {
                lvLocation.Visible = false;
                lvRack.Visible = false;
                btnSourceView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSourceView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSourceView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnDesignationView_Click(object sender, EventArgs e)
        {
            try
            {
                int varDLocationId = 0, varDRackId = 0;
                bool blnErrorFlag = false;
                /* Check purchase stock location is valid or not*/
                if (txtDLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtDLocation.Text.Trim(),0,0,0,"","",0);
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
                    lblDLocation.Text = Convert.ToString(varId_PurLocation);
                    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                    {
                        epRackSettings.SetError(txtDLocation, "Please select valid stock location");
                        txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppStockLocation.ShowAlways = true;
                        tppStockLocation.Show("Please select valid stock location", txtDLocation, 5000);
                        blnErrorFlag = true;
                    }
                }
                string varId_PurRack = "0";
                string varId_Rack = "0";
                /* Check purchase rack is valid or not*/
                if (txtDRack.Text != "")
                {
                    DataSet objDsPurRack = new DataSet();
                    SPDataService objDServ4 = new SPDataService();
                    objDsPurRack = objDServ4.udfnRackList(9, 0, 0, Convert.ToInt32(lblDLocation.Text), 0, txtDRack.Text.Trim(), 0, 0);
                    objDServ4.CloseConnection();
                    if (objDsPurRack != null)
                    {
                        if (objDsPurRack.Tables.Count > 0)
                        {
                            if (objDsPurRack.Tables[0].Rows.Count > 0)
                            {
                                varId_PurRack = Convert.ToString(objDsPurRack.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblDRack.Text = Convert.ToString(varId_PurRack);
                    if (varId_PurRack == "0" || varId_PurRack == "-1")
                    {
                        epRackSettings.SetError(txtDRack, "Please select valid rack");
                        txtDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppRack.ShowAlways = true;
                        tppRack.Show("Please select valid rack", txtDRack, 5000);
                        grdViewProduct.DataSource = null;
                        //dtViewProduct.Rows.Clear();
                        blnErrorFlag = true;
                    }
                }
                if (varId_PurRack != "0" && varId_PurRack != "-1")
                {
                    if (txtDLocation.Text != "")
                    {
                        DataSet objDsRack = new DataSet();
                        SPDataService objDserv4 = new SPDataService();
                        objDsRack = objDserv4.udfnRackList(7, 0, 0, Convert.ToInt32(lblDLocation.Text), 0, txtDRack.Text, 0, 0);
                        objDserv4.CloseConnection();
                        if (objDsRack != null)
                        {
                            if (objDsRack.Tables.Count > 0)
                            {
                                if (objDsRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_Rack = Convert.ToString(objDsRack.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                    }
                    if (varId_PurRack == varId_Rack)
                    {
                        lblDRack.Text = Convert.ToString(varId_PurRack);
                    }
                    else
                    {
                        grdViewProduct.DataSource = null;
                        //dtViewProduct.Rows.Clear();
                        SPDataService objDServ = new SPDataService();
                        string varMessage = objDServ.udfnGetMessages(59);
                        objDServ.CloseConnection();
                        MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDRack.Text = "";
                        txtDRack.Focus();
                        blnErrorFlag = true;
                    }
                }
                if (blnErrorFlag == false)
                {
                    try
                    {
                        udfnMoveList();
                        for (int j = 0; j < grdViewProduct.RowCount; j++)
                        {
                            if (Convert.ToString(grdMoveProduct.Rows[j].Cells["productid"].Value) == Convert.ToString(grdViewProduct.Rows[j].Cells["PRODUCTID"].Value))
                            {
                                grdViewProduct.Rows[j].Cells[0].Value = true;
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnMoveList()
        {
            try
            {
                int varViewType = 14;
                dtViewProduct.Rows.Clear();
                Application.DoEvents();
                grdViewProduct.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                string varGroupId = "0";
                if (txtGroup.Text == "")
                {
                    varGroupId = "0";
                }
                else
                {
                    /* Check product group is valid or not*/
                    DataSet objDsGroup = new DataSet();
                    SPDataService objDServ1 = new SPDataService();
                    objDsGroup = objDServ1.udfnGroupList(9, 0, 0, txtGroup.Text.Trim(),0);
                    objDServ1.CloseConnection();
                    if (objDsGroup != null)
                    {
                        if (objDsGroup.Tables.Count > 0)
                        {
                            if (objDsGroup.Tables[0].Rows.Count > 0)
                            {
                                varGroupId = Convert.ToString(objDsGroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblProductGroupId.Text = Convert.ToString(varGroupId);
                    if (lblProductGroupId.Text == "-1")
                    {
                        epRackSettings.SetError(txtGroup, "Please select valid group");
                        txtGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppProductGroup.ShowAlways = true;
                        tppProductGroup.Show("Please select valid group", txtGroup, 5000);
                    }
                }

                string varSubGroupId = "0";
                if (txtSubGroup.Text == "")
                {
                    varSubGroupId = "0";
                }
                else
                {
                    /* Check product sub group is valid or not*/
                    DataSet objDssubgroup = new DataSet();
                    SPDataService objDserv = new SPDataService();
                    objDssubgroup = objDserv.udfnSubGroupList(11, 0, "", 0, 0, txtSubGroup.Text.Trim(), 0, 0, 0, 0, 0);
                    objDserv.CloseConnection();
                    if (objDssubgroup != null)
                    {
                        if (objDssubgroup.Tables.Count > 0)
                        {
                            if (objDssubgroup.Tables[0].Rows.Count > 0)
                            {
                                varSubGroupId = Convert.ToString(objDssubgroup.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblProductSubGroupId.Text = Convert.ToString(varSubGroupId);
                    if (lblProductSubGroupId.Text == "-1")
                    {
                        epRackSettings.SetError(txtSubGroup, "Please select valid subgroup");
                        txtSubGroup.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppProductSubGroup.ShowAlways = true;
                        tppProductSubGroup.Show("Please select valid subgroup", txtSubGroup, 5000);
                    }
                }

                string varRackId = "0";
                int varDLocationId = 0;
                if (lblDLocation.Text == "" || lblDLocation.Text == "-1" || lblDLocation.Text == "0")
                {
                    varDLocationId = 0;
                }
                else { varDLocationId = Convert.ToInt32(lblDLocation.Text); }

                if (Convert.ToString(txtDRack.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtDRack, "Please enter rack");
                    txtDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppRack.ShowAlways = true;
                    tppRack.Show("Please enter rack", txtDRack, 5000);
                }
                else
                {
                    //string varId_PurRack = "0";
                    DataSet objDsPurRack = new DataSet();
                    SPDataService objDServ4 = new SPDataService();
                    objDsPurRack = objDServ4.udfnRackList(9, 0, 0, varDLocationId, 0, txtDRack.Text.Trim(), 0, 0);
                    objDServ4.CloseConnection();
                    if (objDsPurRack != null)
                    {
                        if (objDsPurRack.Tables.Count > 0)
                        {
                            if (objDsPurRack.Tables[0].Rows.Count > 0)
                            {
                                varRackId = Convert.ToString(objDsPurRack.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblDRack.Text = Convert.ToString(varRackId);
                    if (varRackId == "0" || varRackId == "-1")
                    {
                        epRackSettings.SetError(txtDRack, "Please select valid rack");
                        txtDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppRack.ShowAlways = true;
                        tppRack.Show("Please select valid rack", txtDRack, 5000);
                    }
                }
                MR_Product objMR_Product = new MR_Product();
                objMR_Product.paraViewType = varViewType;
                objMR_Product.paraGroup = Convert.ToInt32(varGroupId);
                objMR_Product.paraSubgroup = Convert.ToInt32(varSubGroupId);
                objMR_Product.paraRackId = Convert.ToInt32(varRackId);
                objDs = objdserv.udfnproductmasterlist(objMR_Product);
                objdserv.CloseConnection();

                if (objDs.Tables[1].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                    {
                        dtViewProduct.Rows.Add(false, objDs.Tables[1].Rows[i]["S.No."], objDs.Tables[1].Rows[i]["P.I Code"], objDs.Tables[1].Rows[i]["Product Name in English"],
                           objDs.Tables[1].Rows[i]["Product Name in Tamil"], objDs.Tables[1].Rows[i]["Unit"], objDs.Tables[1].Rows[i]["PRID"]);
                    }
                }
                grdViewProduct.DataSource = null;
                grdViewProduct.DataSource = dtViewProduct;
                grdViewProduct.Columns[0].HeaderText = "";
                grdViewProduct.Columns[0].Width = 50;
                grdViewProduct.Columns["S.No."].Width = 50;
                grdViewProduct.Columns["PRODUCTID"].Visible = false;
                grdViewProduct.Columns["P.I Code"].Width = 100;
                grdViewProduct.Columns["Product Name in English"].Width = 250;
                grdViewProduct.Columns["Product Name in Tamil"].Width = 250;
                grdViewProduct.Columns["S.No."].ReadOnly = true;
                grdViewProduct.Columns["P.I Code"].ReadOnly = true;
                grdViewProduct.Columns["Product Name in English"].ReadOnly = true;
                grdViewProduct.Columns["Product Name in Tamil"].ReadOnly = true;
                grdViewProduct.Columns["Unit"].ReadOnly = true;
                grdViewProduct.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                //grdMoveProduct.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnDesignationView_Enter(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToString(txtDRack.Text).Trim()==Convert.ToString(txtMoveRack.Text).Trim())
                {
                    txtMoveRack.Text = "";
                    txtMoveRack.Focus();
                }
                lvDLocation.Visible = false;
                lvDRack.Visible = false;
                btnDesignationView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnDesignationView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnDesignationView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvProductGroup.Items.Count == 0 || txtGroup.Text == "")
                    {
                        txtGroup.Focus();
                        lvGroup.Visible = false;
                    }
                    else
                    {
                        lvProductGroup.Focus();
                    }
                    if (lvProductGroup.Items.Count > 0)
                    {
                        lvProductGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtGroup.BackColor = Color.White;
                if (txtGroup.Text.Trim() == "") { lblProductGroupId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvProductGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnGroupList(7, 0, 0, txtGroup.Text,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRGID"].ToString(), objDs.Tables[0].Rows[i]["PRG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvProductGroup.Columns[2].Width = 200;
                                    lvProductGroup.Items.Add(objList);
                                }
                                lvProductGroup.Visible = true;
                            }
                            else
                            {
                                lvProductGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvProductGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvProductGroup.Visible = false;
                    }
                }
                else
                {
                    lvProductGroup.Visible = false;
                    lvProductGroup.Items.Clear();
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
        private void TxtSubGroup_Enter(object sender, EventArgs e)
        {
            try
            {
                lvProductGroup.Visible = false;
                txtSubGroup.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvProductSubGroup.Items.Count == 0 || txtSubGroup.Text == "")
                    {
                        txtSubGroup.Focus();
                        lvProductSubGroup.Visible = false;
                    }
                    else
                    {
                        lvProductSubGroup.Focus();
                    }
                    if (lvProductSubGroup.Items.Count > 0)
                    {
                        lvProductSubGroup.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnProductView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSubGroup_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSubGroup.BackColor = Color.White;
                if (txtSubGroup.Text.Trim() == "") { lblProductSubGroupId.Text = "0"; }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSubGroup_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvProductSubGroup.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtSubGroup.Text.Length > 0)
                {
                    objDs = objspdservice.udfnSubGroupList(9, 0, "", Convert.ToInt32(lblProductGroupId.Text), 0, txtSubGroup.Text, 0, 0, 0, 0, 0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["PRSG_EName"].ToString(), objDs.Tables[0].Rows[i]["PRSGID"].ToString(), objDs.Tables[0].Rows[i]["PRSG_TName"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvProductSubGroup.Columns[2].Width = 200;
                                    lvProductSubGroup.Items.Add(objList);
                                }
                                lvProductSubGroup.Visible = true;
                            }
                            else
                            {
                                lvProductSubGroup.Visible = false;
                            }
                        }
                        else
                        {
                            lvProductSubGroup.Visible = false;
                        }
                    }
                    else
                    {
                        lvProductSubGroup.Visible = false;
                    }
                }
                else
                {
                    lvProductSubGroup.Visible = false;
                    lvProductSubGroup.Items.Clear();
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
        private void BtnProductView_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (blnErrorFlag == false)
                {
                    try
                    {
                        udfnMoveList();
                        for (int j = 0; j < grdViewProduct.RowCount; j++)
                        {
                            if (Convert.ToString(grdMoveProduct.Rows[j].Cells["PRODUCTID"].Value) == Convert.ToString(grdViewProduct.Rows[j].Cells["PRODUCTID"].Value))
                            {
                                grdViewProduct.Rows[j].Cells[0].Value = true;
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
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnProductView_Enter(object sender, EventArgs e)
        {
            try
            {
                btnProductView.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnProductView_Leave(object sender, EventArgs e)
        {
            try
            {
                btnProductView.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvProductGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnProductGroupevent();
                txtSubGroup.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvProductGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductGroupevent();
                    txtSubGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductGroupevent()
        {
            try
            {
                if (txtGroup.Text != "")
                {
                    ListViewItem selectedItem = lvProductGroup.SelectedItems[0];
                    lblProductGroupId.Text = selectedItem.SubItems[1].Text;
                    txtGroup.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvProductGroup.Visible = false;
            }
        }
        private void LvProductSubGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnProductSubGroupevent();
                    btnProductView.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvProductSubGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnProductSubGroupevent();
                btnProductView.Focus();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnProductSubGroupevent()
        {
            try
            {
                if (txtSubGroup.Text != "")
                {
                    ListViewItem selectedItem = lvProductSubGroup.SelectedItems[0];
                    lblProductSubGroupId.Text = selectedItem.SubItems[1].Text;
                    txtSubGroup.Text = selectedItem.SubItems[0].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvProductSubGroup.Visible = false;
            }
        }
        private void TxtSearchProductName1_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchProductName1.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProductName1_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchProductName1.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProductName1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdViewProduct.DataSource as BindingSource).Filter = "([Product Name in English]) LIKE '%" + txtSearchProductName1.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchProductName1.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProductName2_Enter(object sender, EventArgs e)
        {
            try
            {
                txtSearchProductName2.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProductName2_Leave(object sender, EventArgs e)
        {
            try
            {
                txtSearchProductName2.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtSearchProductName2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (grdMoveProduct.DataSource as BindingSource).Filter = "([Product Name in English]) LIKE '%" + txtSearchProductName2.Text + "%'or ([P.I Code]) LIKE '%" + txtSearchProductName2.Text + "%' ";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    udfnCalCheckedCount();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnCalCheckedCount()
        {
            int varCheckedCount = 0;
            try
            {
                for (int i = 0; i < grdViewProduct.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdViewProduct.Rows[i].Cells[0].EditedFormattedValue) == true)
                    {
                        varCheckedCount++;
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
                if (grdViewProduct.Rows.Count == varCheckedCount)
                {
                    varCheckAll = 1;
                    checkAll.Checked = true;
                }
                else
                {
                    varCheckAll = 1;
                    checkAll.Checked = false;
                }
            }
        }
        private void CheckAll_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void BtnAddgrid_Click(object sender, EventArgs e)
        {
            try
            {
                udfnMoveProduct();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnMoveProduct()
        {
            try
            {
                string varRemoveRack = "", varAddRack = "";

                if (grdViewProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < grdViewProduct.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(grdViewProduct.Rows[i].Cells[0].Value) == true)
                        {
                            int varFlag = 0, varcount = 1; ;

                            for (int j = 0; j < dtMoveProduct.Rows.Count; j++)
                            {
                                varAddRack = Convert.ToString(grdViewProduct.Rows[i].Cells["PRODUCTID"].Value);
                                if (varAddRack == Convert.ToString(dtMoveProduct.Rows[j]["PRID"]))
                                {
                                    varFlag = 1;
                                }
                                varcount++;
                            }
                            if (varFlag == 0)
                            {
                                dtMoveProduct.Rows.Add(grdViewProduct.Rows[i].Cells["P.I Code"].Value, grdViewProduct.Rows[i].Cells["Product Name in English"].Value,
                                    grdViewProduct.Rows[i].Cells["Product Name in Tamil"].Value, grdViewProduct.Rows[i].Cells["Unit"].Value, grdViewProduct.Rows[i].Cells["PRODUCTID"].Value);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < dtMoveProduct.Rows.Count; j++)
                            {
                                varRemoveRack = Convert.ToString(grdViewProduct.Rows[i].Cells["PRODUCTID"].Value);
                                if (varRemoveRack == Convert.ToString(dtMoveProduct.Rows[j]["PRID"]))
                                {
                                    dtMoveProduct.Rows[j].Delete();
                                    dtMoveProduct.AcceptChanges();
                                }
                            }
                        }
                    }
                    grdMoveProduct.DataSource = null;
                    grdMoveProduct.DataSource = dtMoveProduct;
                    grdMoveProduct.Columns["clmRemoveProduct"].DisplayIndex = 5;
                    grdMoveProduct.Columns["PRID"].Visible = false;
                    grdMoveProduct.Columns["P.I Code"].Width = 100;
                    grdMoveProduct.Columns["Product Name in English"].Width = 250;
                    grdMoveProduct.Columns["Product Name in Tamil"].Width = 250;
                    grdMoveProduct.Columns["P.I Code"].ReadOnly = true;
                    grdMoveProduct.Columns["Product Name in English"].ReadOnly = true;
                    grdMoveProduct.Columns["Product Name in Tamil"].ReadOnly = true;
                    grdMoveProduct.Columns["Unit"].ReadOnly = true;
                    grdMoveProduct.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(53);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnMoveSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool blnErrorFlag = false;
                if (Convert.ToString(txtDLocation.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtDLocation, "Please enter location");
                    txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppStockLocation.ShowAlways = true;
                    tppStockLocation.Show("Please enter location", txtDLocation, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    if (txtDLocation.Text != "")
                    {
                        string varId_PurLocation = "0";
                        DataSet objDsPurLoc = new DataSet();
                        SPDataService objDServ3 = new SPDataService();
                        objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtDLocation.Text.Trim(),0,0, 0,"","",0);
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
                        lblDLocation.Text = Convert.ToString(varId_PurLocation);
                        if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                        {
                            epRackSettings.SetError(txtDLocation, "Please select valid stock location");
                            txtDLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tppStockLocation.ShowAlways = true;
                            tppStockLocation.Show("Please select valid stock location", txtDLocation, 5000);
                            blnErrorFlag = true;
                        }
                    }
                }
                if (Convert.ToString(txtDRack.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtDRack, "Please enter rack");
                    txtDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppRack.ShowAlways = true;
                    tppRack.Show("Please enter rack", txtDRack, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    if (txtDRack.Text != "")
                    {
                        string varIdRack = "0";
                        DataSet objDSRack = new DataSet();
                        SPDataService objDServ4 = new SPDataService();
                        objDSRack = objDServ4.udfnRackList(9, 0, 0, Convert.ToInt32(lblDLocation.Text), 0, txtDRack.Text.Trim(), 0, 0);
                        objDServ4.CloseConnection();
                        if (objDSRack != null)
                        {
                            if (objDSRack.Tables.Count > 0)
                            {
                                if (objDSRack.Tables[0].Rows.Count > 0)
                                {
                                    varIdRack = Convert.ToString(objDSRack.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                        lblDRack.Text = Convert.ToString(varIdRack);
                        if (varIdRack == "0" || varIdRack == "-1")
                        {
                            epRackSettings.SetError(txtDRack, "Please select valid rack");
                            txtDRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tppRack.ShowAlways = true;
                            tppRack.Show("Please select valid rack", txtDRack, 5000);
                            blnErrorFlag = true;
                        }
                    }
                }
                if (Convert.ToString(txtMoveLocation.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtMoveLocation, "Please enter location");
                    txtMoveLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppStockLocation.ShowAlways = true;
                    tppStockLocation.Show("Please enter location", txtMoveLocation, 5000);
                    blnErrorFlag = true;
                }
                else
                {
                    if (txtMoveLocation.Text != "")
                    {
                        string varId_PurLocation = "0";
                        DataSet objDsPurLoc = new DataSet();
                        SPDataService objDServ3 = new SPDataService();
                        objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtMoveLocation.Text.Trim(),0, 0,0,"","",0);
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
                        lblMoveLocation.Text = Convert.ToString(varId_PurLocation);
                        if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                        {
                            epRackSettings.SetError(txtMoveLocation, "Please select valid stock location");
                            txtMoveLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                            tppStockLocation.ShowAlways = true;
                            tppStockLocation.Show("Please select valid stock location", txtMoveLocation, 5000);
                            blnErrorFlag = true;
                        }
                    }
                }
                if (Convert.ToString(txtMoveRack.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtMoveRack, "Please enter rack");
                    txtMoveRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppRack.ShowAlways = true;
                    tppRack.Show("Please enter rack", txtMoveRack, 5000);
                    blnErrorFlag = true;
                }
                string varId_PurRack = "0";
                string varId_Rack = "0";
                if (txtMoveRack.Text != "")
                {
                    DataSet objDsPurRack = new DataSet();
                    SPDataService objDServ4 = new SPDataService();
                    objDsPurRack = objDServ4.udfnRackList(9, 0, 0, Convert.ToInt32(lblMoveLocation.Text), 0, txtMoveRack.Text.Trim(), 0, 0);
                    objDServ4.CloseConnection();
                    if (objDsPurRack != null)
                    {
                        if (objDsPurRack.Tables.Count > 0)
                        {
                            if (objDsPurRack.Tables[0].Rows.Count > 0)
                            {
                                varId_PurRack = Convert.ToString(objDsPurRack.Tables[0].Rows[0][0]);
                            }
                        }
                    }
                    lblMoveRack.Text = Convert.ToString(varId_PurRack);
                    if (varId_PurRack == "0" || varId_PurRack == "-1")
                    {
                        epRackSettings.SetError(txtMoveRack, "Please select valid rack");
                        txtMoveRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppRack.ShowAlways = true;
                        tppRack.Show("Please select valid rack", txtMoveRack, 5000);
                        blnErrorFlag = true;
                    }
                }

                if(varId_PurRack!="0" && varId_PurRack!="-1")
                {
                    if (txtMoveLocation.Text != "")
                    {
                        DataSet objDsRack = new DataSet();
                        SPDataService objDserv4 = new SPDataService();
                        objDsRack = objDserv4.udfnRackList(7, 0, 0, Convert.ToInt32(lblMoveLocation.Text), 0, txtMoveRack.Text, 0,0);
                        objDserv4.CloseConnection();
                        if (objDsRack != null)
                        {
                            if (objDsRack.Tables.Count > 0)
                            {
                                if (objDsRack.Tables[0].Rows.Count > 0)
                                {
                                    varId_Rack = Convert.ToString(objDsRack.Tables[0].Rows[0][0]);
                                }
                            }
                        }
                    }
                    if (varId_PurRack == varId_Rack)
                    {
                        lblMoveRack.Text = Convert.ToString(varId_PurRack);
                    }
                    else
                    {
                        epRackSettings.SetError(txtMoveRack, "Please select valid rack");
                        txtMoveRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppRack.ShowAlways = true;
                        tppRack.Show("Please select valid rack", txtMoveRack, 5000);
                        txtMoveRack.Text = "";
                        grdMoveProduct.DataSource = null;
                        blnErrorFlag = true;
                    }
                }
                if (grdMoveProduct.Rows.Count > 0)
                {
                    if (Convert.ToString(txtMoveLocation.Text).Trim() == "" && Convert.ToString(txtMoveRack.Text).Trim() == "")
                    {
                        blnErrorFlag = true;
                    }
                }
                else
                {
                    SPDataService objDServ = new SPDataService();
                    string varMessage = objDServ.udfnGetMessages(53);
                    objDServ.CloseConnection();
                    MessageBox.Show(varMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    blnErrorFlag = true;
                }
                if(txtDRack.Text.Trim()==txtMoveRack.Text.Trim())
                {
                    txtMoveRack.Text = "";
                    blnErrorFlag = true;
                }

                if (blnErrorFlag == false)
                {
                    btnMoveSave.Enabled = false;
                    udfnMoveSave(sender, e);
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
        public void udfnMoveSave(object sender, EventArgs e)
        {
            try
            {
                SPDataService objspservice = new SPDataService();
                string varResult = "",
                varoriginator = ""; int varType = 0;
                if (btnMoveSave.Text == "Move")
                {
                    varoriginator = "RackSettings-Move Product";
                    varType = 3;
                    
                }
                varProductID = "";
                for (int i = 0; i < grdMoveProduct.RowCount; i++)
                {
                    if (varProductID == "")
                    {
                        varProductID = Convert.ToString(grdMoveProduct.Rows[i].Cells["PRID"].Value);
                    }
                    else
                    {
                        varProductID = varProductID + "," + Convert.ToString(grdMoveProduct.Rows[i].Cells["PRID"].Value);
                    }
                }
                int varDLocationId = 0;
                if (lblDLocation.Text == "" || lblDLocation.Text == "-1" || lblDLocation.Text == "0")
                {
                    varDLocationId = 0;
                }
                else { varDLocationId = Convert.ToInt32(lblDLocation.Text); }
                int varDRackId = 0;
                if (lblDRack.Text == "" || lblDRack.Text == "-1" || lblDRack.Text == "0")
                {
                    varDRackId = 0;
                }
                else { varDRackId = Convert.ToInt32(lblDRack.Text); }

                int varMoveLocationId = 0;
                if (lblMoveLocation.Text == "" || lblMoveLocation.Text == "-1" || lblMoveLocation.Text == "0")
                {
                    varMoveLocationId = 0;
                }
                else { varMoveLocationId = Convert.ToInt32(lblMoveLocation.Text); }
                int varMoveRackId = 0;
                if (lblMoveRack.Text == "" || lblMoveRack.Text == "-1" || lblMoveRack.Text == "0")
                {
                    varMoveRackId = 0;
                }
                else { varMoveRackId = Convert.ToInt32(lblMoveRack.Text); }

                varResult = objspservice.udfnRackSettings(varType, 0, varDLocationId, varDRackId, varProductID, varMoveLocationId, varMoveRackId, varoriginator);
                objspservice.CloseConnection();
                string[] varvalue = varResult.Split('~');
                if (varvalue[0] == "3")
                {
                    MessageBox.Show(varvalue[1], "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm.objCP_RackSettinglist.udfnList();
                    txtDLocation.Focus();
                    if (btnSave.Text == "Update")
                    {
                        varUpdate = 1;
                        grdMoveProduct.DataSource = null;
                        grdViewProduct.DataSource = null;
                        //dtMoveProduct.Rows.Clear();
                        //dtViewProduct.Rows.Clear();
                        udfnclose();
                    }
                    else
                    {
                        grdMoveProduct.DataSource = null;
                        grdViewProduct.DataSource = null;
                        //dtMoveProduct.Rows.Clear();
                        //dtViewProduct.Rows.Clear();
                    }
                    udfnclear();
                }
                else
                {
                    MessageBox.Show(varResult.Split('~')[1], "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnMoveSave.Enabled = true;
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
                btnMoveSave.Focus();
            }
            finally
            {
                btnMoveSave.Enabled = true;
            }
        }
        private void BtnMoveSave_Enter(object sender, EventArgs e)
        {
            try
            {
                btnMoveSave.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnMoveSave_Leave(object sender, EventArgs e)
        {
            try
            {
                btnMoveSave.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnMoveClose_Click(object sender, EventArgs e)
        {
            udfnclose();
        }
        private void TxtMoveLocation_Enter(object sender, EventArgs e)
        {
            try
            {
                txtMoveLocation.BackColor = Color.LemonChiffon;
                epRackSettings.Clear();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void TxtMoveLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvMoveLocation.Items.Count == 0 || txtMoveLocation.Text == "")
                    {
                        txtMoveRack.Focus();
                        txtMoveRack.Text = "";
                        lvMoveLocation.Visible = false;
                    }
                    else
                    {
                        lvMoveLocation.Focus();
                    }
                    if (lvMoveLocation.Items.Count > 0)
                    {
                        lvMoveLocation.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtMoveRack.Focus();
                    txtMoveRack.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMoveLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtMoveLocation.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtMoveLocation, "Please enter location");
                    txtMoveLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppStockLocation.ShowAlways = true;
                    tppStockLocation.Show("Please enter location", txtMoveLocation, 5000);
                    lblMoveLocation.Text = "0";
                }
                else
                {
                    epRackSettings.Clear();
                    txtMoveLocation.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMoveLocation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvMoveLocation.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtMoveLocation.Text.Length > 0)
                {

                    objDs = objspdservice.udfnStockLocationList(12, 0, 0, 0, txtMoveLocation.Text,0,0,0,"","",0);
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
                                    lvMoveLocation.Columns[1].Width = 0;
                                    lvMoveLocation.Items.Add(objList);
                                }
                                lvMoveLocation.Visible = true;
                            }
                            else
                            {
                                lvMoveLocation.Visible = false;
                            }
                        }
                        else
                        {
                            lvMoveLocation.Visible = false;
                        }
                    }
                    else
                    {
                        lvMoveLocation.Visible = false;
                    }
                }
                else
                {
                    lvMoveLocation.Visible = false;
                    lvMoveLocation.Items.Clear();
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
        private void TxtMoveRack_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtMoveLocation.Text != "")
                {
                    string varId_PurLocation = "0";
                    DataSet objDsPurLoc = new DataSet();
                    SPDataService objDServ3 = new SPDataService();
                    objDsPurLoc = objDServ3.udfnStockLocationList(14, 0, 0, 0, txtMoveLocation.Text.Trim(),0,0,0,"","",0);
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
                    lblMoveLocation.Text = Convert.ToString(varId_PurLocation);
                    if (varId_PurLocation == "0" || varId_PurLocation == "-1")
                    {
                        epRackSettings.SetError(txtMoveLocation, "Please select valid stock location");
                        txtMoveLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                        tppStockLocation.ShowAlways = true;
                        tppStockLocation.Show("Please select valid stock location", txtMoveLocation, 5000);
                        txtMoveRack.Text = "";
                        txtMoveLocation.Focus();
                    }
                    else
                    {
                        epRackSettings.Clear();
                    }
                }
                lvMoveLocation.Visible = false;
                txtMoveRack.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMoveRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Enter)
                {
                    if (lvMoveRack.Items.Count == 0 || txtMoveRack.Text == "")
                    {
                        lvMoveRack.Visible = false;
                    }
                    else
                    {
                        lvMoveRack.Focus();
                    }
                    if (lvMoveRack.Items.Count > 0)
                    {
                        lvMoveRack.Items[0].Selected = true;
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    txtGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMoveRack_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtMoveRack.Text).Trim() == "")
                {
                    epRackSettings.SetError(txtMoveRack, "Please enter rack");
                    txtMoveRack.BackColor = System.Drawing.ColorTranslator.FromHtml("#fabdbd");
                    tppRack.ShowAlways = true;
                    tppRack.Show("Please enter rack", txtMoveRack, 5000);
                    lblMoveRack.Text = "0";
                }
                else
                {
                    epRackSettings.Clear();
                    txtMoveRack.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void TxtMoveRack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvMoveRack.Items.Clear();
                SPDataService objspdservice = new SPDataService();
                DataSet objDs = new DataSet();
                if (txtMoveRack.Text.Length > 0)
                {
                    int varMoveLocationId = 0;
                    if (lblMoveLocation.Text == "" || lblMoveLocation.Text == "-1" || lblMoveLocation.Text == "0")
                    {
                        varMoveLocationId = 0;
                    }
                    else { varMoveLocationId = Convert.ToInt32(lblMoveLocation.Text); }
                    int varMoveRackId = 0;
                    if (lblDRack.Text == "" || lblDRack.Text == "-1" || lblDRack.Text == "0")
                    {
                        varMoveRackId = 0;
                    }
                    else { varMoveRackId = Convert.ToInt32(lblDRack.Text); }


                    objDs = objspdservice.udfnRackList(7, 0, 0, varMoveLocationId, varMoveRackId, txtMoveRack.Text, 0,0);
                    objspdservice.CloseConnection();
                    if (objDs != null)
                    {
                        if (objDs.Tables.Count != 0)
                        {
                            if (objDs.Tables[0].Rows.Count != 0)
                            {
                                for (int i = 0; i < objDs.Tables[0].Rows.Count; i++)
                                {
                                    string[] row = { objDs.Tables[0].Rows[i]["RK_Name"].ToString(), objDs.Tables[0].Rows[i]["RK_ShortName"].ToString(), objDs.Tables[0].Rows[i]["RKID"].ToString() };
                                    ListViewItem objList = new ListViewItem(row);
                                    lvMoveRack.Columns[1].Width = 100;
                                    lvMoveRack.Items.Add(objList);
                                }
                                lvMoveRack.Visible = true;
                            }
                            else
                            {
                                lvMoveRack.Visible = false;
                            }
                        }
                        else
                        {
                            lvMoveRack.Visible = false;
                        }
                    }
                    else
                    {
                        lvMoveRack.Visible = false;
                    }
                }
                else
                {
                    lvMoveRack.Visible = false;
                    lvMoveRack.Items.Clear();
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
        private void LvMoveLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnMoveLocationEvent();
                txtMoveRack.Focus();
                txtMoveRack.Text = "";
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void LvMoveLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnMoveLocationEvent();
                    txtMoveRack.Focus();
                    txtMoveRack.Text = "";
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnMoveLocationEvent()
        {
            try
            {
                if (txtMoveLocation.Text != "")
                {
                    ListViewItem selectedItem = lvMoveLocation.SelectedItems[0];
                    txtMoveLocation.Text = selectedItem.SubItems[0].Text;
                    lblMoveLocation.Text = selectedItem.SubItems[1].Text;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvMoveLocation.Visible = false;
            }
        }

        private void LvMoveRack_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                udfnMoveRackEvent();
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void LvMoveRack_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    udfnMoveRackEvent();
                    txtGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        public void udfnMoveRackEvent()
        {
            try
            {
                if (txtMoveRack.Text != "")
                {
                    ListViewItem selectedItem = lvMoveRack.SelectedItems[0];
                    txtMoveRack.Text = selectedItem.SubItems[0].Text;
                    lblMoveRack.Text = selectedItem.SubItems[2].Text;
                }

                int varRackCount = 0;
                //grdMoveProduct.DataSource = null;
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();
                objDs = objdserv.udfnRackSettingsList(2, 0, 0, 0, Convert.ToInt32(lblMoveRack.Text));
                objdserv.CloseConnection();
                if (objDs != null)
                {
                    if (objDs.Tables.Count > 0)
                    {
                        if (objDs.Tables[0].Rows.Count > 0)
                        {
                            varRackCount = Convert.ToInt32(objDs.Tables[0].Rows[0][0]);
                        }
                    }
                }
                //lblMoveRack.Text = Convert.ToString(varRackCount);

                if (varRackCount != 0)
                {
                    grdMoveProduct.DataSource = null;
                    //dtMoveProduct.Rows.Clear();
                    udfnMove(Convert.ToInt32(lblMoveLocation.Text), Convert.ToInt32(lblMoveRack.Text));
                }
                else
                {
                    grdMoveProduct.DataSource = null;
                    //dtMoveProduct.Rows.Clear();
                }


            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
            finally
            {
                lvMoveRack.Visible = false;
            }
        }
        private void udfnMove(int locationcode, int rackcode)
        {
            try
            {
                int varViewType = 1;
                //dtSupplierMapping.Rows.Clear();
                grdMoveProduct.DataSource = null;
                dtMoveProduct.Rows.Clear();
                Application.DoEvents();
                DataSet objDs = new DataSet();
                //**** To call the function from SP ***************
                SPDataService objdserv = new SPDataService();

                objDs = objdserv.udfnRackSettingsList(varViewType, 0, 0, locationcode, rackcode);
                objdserv.CloseConnection();
                
                if (objDs.Tables[1].Rows.Count != 0)
                {
                    for (int i = 0; i < objDs.Tables[1].Rows.Count; i++)
                    {
                        dtMoveProduct.Rows.Add(objDs.Tables[1].Rows[i]["P.I Code"], objDs.Tables[1].Rows[i]["Product Name in English"],
                           objDs.Tables[1].Rows[i]["Product Name in Tamil"], objDs.Tables[1].Rows[i]["Unit"], objDs.Tables[1].Rows[i]["PRID"]);
                    }
                }

                grdMoveProduct.DataSource = null;
                grdMoveProduct.DataSource = dtMoveProduct;
                grdMoveProduct.Columns["clmRemoveProduct"].DisplayIndex = 5;
                grdMoveProduct.Columns["PRID"].Visible = false;
                grdMoveProduct.Columns["P.I Code"].Width = 100;
                grdMoveProduct.Columns["Product Name in English"].Width = 250;
                grdMoveProduct.Columns["Product Name in Tamil"].Width = 250;
                grdMoveProduct.Columns["P.I Code"].ReadOnly = true;
                grdMoveProduct.Columns["Product Name in English"].ReadOnly = true;
                grdMoveProduct.Columns["Product Name in Tamil"].ReadOnly = true;
                grdMoveProduct.Columns["Unit"].ReadOnly = true;
                grdMoveProduct.Columns["Product Name in Tamil"].DefaultCellStyle.Font = new System.Drawing.Font("Uni Ila.Sundaram-03", 11.75F);

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void GrdMoveProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    switch (grdMoveProduct.Columns[e.ColumnIndex].Name)
                    {
                        case "clmRemoveProduct":
                            DialogResult dialogResult = MessageBox.Show("Are you sure want to remove ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                grdMoveProduct.Rows.RemoveAt(this.grdMoveProduct.SelectedRows[0].Index);
                                for (int i = 0; i < grdMoveProduct.RowCount; i++)
                                {
                                    grdMoveProduct.Rows[i].Cells["sno"].Value = i + 1;
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
        }
        private void TcRackSettings_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                try
                {
                    this.ActiveControl = txtLocation;
                    tppStockLocation.Active = false;
                    tppRack.Active = false;
                    tppProductGroup.Active = false;
                    tppProductSubGroup.Active = false;
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
            if (e.TabPageIndex == 2)
            {
                try
                {
                    this.ActiveControl = txtDLocation;
                    tpStockLocation.Active = false;
                    tpRack.Active = false;
                    tpProductGroup.Active = false;
                    tpProductSubGroup.Active = false;
                }
                catch (Exception ex)
                {
                    objError = new DataError();
                    objError.WriteFile(ex);
                }
            }
        }
        private void TcRackSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            epRackSettings.Clear();
            udfnColorChange();
            if (btnSave.Text == "Update")
            {
                MoveProduct.Hide();
            }
            if (tcRackSettings.SelectedIndex == 0)
            {
                txtLocation.Focus();
                this.ActiveControl = txtLocation;
                tppStockLocation.Active = false;
                tppRack.Active = false;
                tppProductGroup.Active = false;
                tppProductSubGroup.Active = false;
                txtLocation.SelectionStart = txtLocation.Text.Length;
            }
            else
            {
                txtDLocation.Focus();
                this.ActiveControl = txtDLocation;
                tpStockLocation.Active = false;
                tpRack.Active = false;
                tpProductGroup.Active = false;
                tpProductSubGroup.Active = false;
                txtDLocation.SelectionStart = txtDLocation.Text.Length;
            }
        }

        private void GrdSupplierMapping_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdSupplierMapping.IsCurrentCellDirty)
                {
                    grdSupplierMapping.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void CP_RackSettings_Leave(object sender, EventArgs e)
        {
            try
            {
                tpStockLocation.Active = false;
                tppStockLocation.Active = false;
                tpRack.Active = false;
                tppRack.Active = false;
                tpProductGroup.Active = false;
                tppProductGroup.Active = false;
                tpProductSubGroup.Active = false;
                tppProductSubGroup.Active = false;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdSupplierMapping.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnUnselectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                btnUnselectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnUnselectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnUnselectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                btnUnselectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdSupplierMapping.Rows.Count; i++)
                {
                    grdSupplierMapping.Rows[i].Cells[0].Value = chkRackSettings.Checked;
                }

                foreach (DataGridViewRow row in grdSupplierMapping.Rows)
                {
                    row.Cells[0].Value = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSelectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void BtnSubGrupUnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in grdViewProduct.Rows)
                {
                    row.Cells[0].Value = false;
                }

            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupUnSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                btnSubGrupUnSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupUnSelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnUnselectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnSubGrupUnSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                btnSubGrupUnSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdViewProduct.Rows.Count; i++)
                {
                    grdViewProduct.Rows[i].Cells[0].Value = checkAll.Checked;
                }

                foreach (DataGridViewRow row in grdViewProduct.Rows)
                {
                    row.Cells[0].Value = true;
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_Enter(object sender, EventArgs e)
        {
            try
            {
                BtnProductSelectAll.BackColor = Color.LemonChiffon;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnProductSelectAll_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }

        private void BtnProductSelectAll_Leave(object sender, EventArgs e)
        {
            try
            {
                BtnProductSelectAll.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                objError = new DataError();
                objError.WriteFile(ex);
            }
        }
        private void udfnColorChange()
        {
            txtLocation.BackColor = Color.White;
            txtRack.BackColor = Color.White;
            txtDLocation.BackColor = Color.White;
            txtDRack.BackColor = Color.White;
            txtMoveLocation.BackColor = Color.White;
            txtMoveRack.BackColor = Color.White;
            txtProductGroup.BackColor = Color.White;
            txtProductSubGroup.BackColor = Color.White;
            txtGroup.BackColor = Color.White;
            txtSubGroup.BackColor = Color.White;
        }
    }
}
